using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CIPLV2.Tickets.Services;
using Newtonsoft.Json;

namespace CIPLV2.Tickets
{
	public partial class FrmWorker : Form
	{

		private List<FeedBack> feedBacks = new List<FeedBack>();
		private readonly IBus _busControl;
		private string systemid = System.Environment.MachineName;
		string basepath = AppDomain.CurrentDomain.BaseDirectory;
		string settingspath = "";
		AdditionalInfo addinfo = new AdditionalInfo();
		//        FrmLanding a = new FrmLanding();
		public FrmWorker()
		{
			try
			{
				//LogWriter.LogWrite("Enter in try block of frmworker constructor");
				InitializeComponent();
				this.Resize += SetMinimizeState;

				// When tray icon clicked, trigger window state change.       
				CIPL.DoubleClick += ToggleMinimizeState;

				//_busControl = RabbitConnector.CreateBus("65.2.100.52"); production IP

#if (DEBUG)
                settingspath = Path.Combine(basepath, "appsettings.Development.json");

#else
				settingspath = Path.Combine(basepath, "appsettings.Production.json");

#endif
				string jsondata = File.ReadAllText(settingspath);
				dynamic output = JsonConvert.DeserializeObject<object>(jsondata);

				_busControl = RabbitConnector.CreateBus(output.RabittMqHost.ToString());

				Scheduler();
				Task.Run(async () =>
				{
					await _busControl.ReceiveFromExchangeAsync<string>("feedbackdata", async x =>
					{
						await OnFeedBackReceived(x);

					});
				}, CancellationToken.None);
			}
			catch (Exception ex)
			{
				LogWriter.LogWrite("Server Error - " + ex.Message);
			}
		}

		public async void RegisterDevice()
		{
			//_ = Task.Factory.StartNew(async () =>
			//{
			try
			{
                string macAddress = GetMacAddress().ToString();
				LogWriter.LogWrite("macaddress" + macAddress);
                string hostName = Dns.GetHostName();

				// Get the IP addresses associated with the host
				IPAddress[] addresses = Dns.GetHostAddresses(hostName);

				// Find the first IPv4 address in the list
				IPAddress ipv4Address = Array.Find(addresses, address => address.AddressFamily == AddressFamily.InterNetwork);

				DeviceDetailsDto deviceDetailsDto = new DeviceDetailsDto();
				//string mac_address = (from nic in NetworkInterface.GetAllNetworkInterfaces() where nic.OperationalStatus == OperationalStatus.Up select nic.GetPhysicalAddress().ToString()).FirstOrDefault();
				//string ipaddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
				deviceDetailsDto.entity_type = "Device";
				deviceDetailsDto.properties.IsDeleted = false;
				if (ipv4Address != null)
				{
					deviceDetailsDto.properties.IpAddress = ipv4Address.ToString();
				}
				else
				{
					deviceDetailsDto.properties.IpAddress = "";
				}

				deviceDetailsDto.properties.MacAddress = macAddress.ToString();
				TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
				long secondsSinceEpoch = (long)t.TotalSeconds;
				deviceDetailsDto.properties.AgentVersion = "2.0.1";
				deviceDetailsDto.properties.DisplayLabel = System.Environment.MachineName;
				deviceDetailsDto.properties.LastUpdateTime = secondsSinceEpoch;
				//deviceDetailsDto.properties.LastUpdateTime = DateTime.Now.Ticks;// TimeSpan.TicksPerMillisecond;
				deviceDetailsDto.properties.SubType = "Desktop";
				string jsondata = File.ReadAllText(settingspath);
				dynamic output = JsonConvert.DeserializeObject<object>(jsondata);
				string registerurl = output.REGISTER_DEVICE.ToString();

				using (HttpClient httpClient = new HttpClient())
				{
					var jsonData = JsonConvert.SerializeObject(deviceDetailsDto);
					var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
					HttpResponseMessage response = await httpClient.PostAsync(registerurl, content);
					if (response.IsSuccessStatusCode)
					{
						string responseBody = await response.Content.ReadAsStringAsync();
						Response responseModel = JsonConvert.DeserializeObject<Response>(responseBody);
						string test = "T";

					}
				}
			}
			catch (Exception ex)
			{

				//LogWriter.LogWrite("Device Registeration problem: " + ex.Message);

			}
			//}, CancellationToken.None);
		}
		public void GoToTicket()
		{
			try
			{
				//LogWriter.LogWrite("Enter in Gototicket Method ");

				FrmLanding landing = new FrmLanding();
				landing.ShowDialog();
			}
			catch (Exception ex)
			{
				LogWriter.LogWrite("Exception in Gototicket Method - " + ex.Message);
			}

		}
		public void WriteTolblhb(string text)
		{
			try
			{
				if (lblhb.InvokeRequired)
				{
					Action safeWrite = delegate { WriteTolblhb($"{text}"); };
					lblhb.Invoke(safeWrite);
				}
				else
					lblhb.Text = text;
			}
			catch (Exception ex)
			{
				LogWriter.LogWrite("Exception in WriteTolblhb Method - " + ex.Message);

			}
		}
		public void WriteToFd(string text)
		{
			try
			{
				if (lblfb.InvokeRequired)
				{
					Action safeWrite = delegate { WriteToFd($"{text}"); };
					lblfb.Invoke(safeWrite);
				}
				else
					lblfb.Text = text;
			}
			catch (Exception ex)
			{
				LogWriter.LogWrite("Exception in WriteToFd Method - " + ex.Message);
			}
		}
		private async Task OnFeedBackReceived(string message)
		{
			try
			{
				if (message.ToLower() != null && message.ToLower() == System.Environment.MachineName.ToLower())
				{
					//LogWriter.LogWrite(" After  if condition on OnFeedBackReceived function" + message);
					//LogWriter.LogWrite(" SystemId on OnFeedBackReceived function" + message);
					WriteToFd("Received :" + DateTime.Now.ToString());
					GoToTicket();

				}
			}
			catch (Exception ex)
			{
				LogWriter.LogWrite("Exception in OnFeedBackReceived Method: " + ex.Message);
			}
		}

		private void Scheduler()
		{
			// MessageBox.Show("enter in scheduler method");

			Task.Run(async () =>
			{
				while (true)
				{
					try
					{
						//MessageBox.Show("enter in try block of scheduler");
						await SendHeartBeat();

					}
					catch (Exception ex)
					{
						LogWriter.LogWrite("Exception in Scheduler Method - " + ex.Message);

						//MessageBox.Show("enter in catch block of scheduler");
						//MessageBox.Show(ex.Message);

					}


					await Task.Delay(30000);
				}
			});
		}
		private async Task SendHeartBeat()
		{
			try
			{
				//MessageBox.Show("enter in sendheartbeat block");

				await _busControl.SendAsync<string>("deviceshb", systemid);
				LogWriter.LogWrite("Heartbeat Received" + DateTime.Now.ToString());
				WriteTolblhb("Heartbeat- " + DateTime.Now.ToString());
			}
			catch (Exception ex)
			{
				LogWriter.LogWrite("Exception in SendHeartBeat Method : " + ex.Message);
			}

		}
		private void ToggleMinimizeState(object sender, EventArgs e)
		{
			try
			{
				bool isMinimized = this.WindowState == FormWindowState.Minimized;
				this.WindowState = (isMinimized) ? FormWindowState.Normal : FormWindowState.Minimized;
			}
			catch (Exception ex)
			{
				LogWriter.LogWrite("Exception in ToggleMinimizeState Method - " + ex.Message);
			}
		}
		private void SetMinimizeState(object sender, EventArgs e)
		{

			bool isMinimized = this.WindowState == FormWindowState.Minimized;
			this.ShowInTaskbar = !isMinimized;
			CIPL.Visible = isMinimized;
		}

		private void FrmWorker_Load(object sender, EventArgs e)
		{
			try
			{
				// MessageBox.Show("Enter in FrmWorker_Load");
				this.WindowState = FormWindowState.Minimized;//
				toolTip1.AutoPopDelay = 5000;
				toolTip1.InitialDelay = 1000;
				toolTip1.ReshowDelay = 500;
				toolTip1.IsBalloon = true;
				toolTip1.ToolTipTitle = "CIPL IT Assist";
				toolTip1.ToolTipIcon = ToolTipIcon.Info;
				toolTip1.UseAnimation = true;
				toolTip1.UseFading = true;
				// Force the ToolTip text to be displayed whether or not the form is active.
				toolTip1.ShowAlways = true;
				// ToolTip
				CIPL.BalloonTipText = "CIPL IT Assist [Working]";
				CIPL.BalloonTipTitle = "CIPL IT Assist";
				RegisterDevice();
				//addinfo.OSVersionInfo();
				//addinfo.HardDiskInfo();
				//addinfo.NoOfServices();
				//addinfo.DeviceData();
			}
			catch (Exception ex)
			{
				LogWriter.LogWrite("Exception in FrmWorker_Load Method - " + ex.Message);
			}

		}

		private void FrmWorker_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				this.WindowState = FormWindowState.Minimized;
				e.Cancel = true;

			}
			else
			{
				e.Cancel = false;
			}
		}

		private void FrmWorker_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.OnClosed(e);
			CIPL.Dispose();
			GC.WaitForFullGCComplete();
		}

		private void cmdclose_Click(object sender, EventArgs e)
		{
			Close();

		}
        static string GetMacAddress()
        {
            string macAddress = "";

            try
            {
                // Get all network interfaces on the system 
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface nic in networkInterfaces)
                {
					// Check if the network interface is not a loopback and has a valid physical address
					//if (!nic.Description.ToLower().Contains("loopback") && nic.OperationalStatus == OperationalStatus.Up && nic.GetPhysicalAddress().ToString() != "")
					//{
					//    macAddress = nic.GetPhysicalAddress().ToString();
					//    break; // Break out of the loop once a valid MAC address is found
					//}
					
                    string tempMac = nic.GetPhysicalAddress().ToString();
                    if (!string.IsNullOrEmpty(tempMac) &&
                        tempMac.Length >= 8)
                    {
                        macAddress = tempMac;
						return macAddress;
                    }
                }
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite("Error retrieving MAC address: " + ex.Message);
                Console.WriteLine("Error retrieving MAC address: " + ex.Message);
            }

            return macAddress;
        }
    }
}

