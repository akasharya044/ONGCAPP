using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CIPL.AppCode;
using Microsoft.Win32;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CIPL.DashboardControl
{
    public partial class SoftwareControl : UserControl
    {
        List<SystemSoftware> softwareInfo { get; set; } = new List<SystemSoftware>();
        public SoftwareControl()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
		private void SoftwareControl_Load(object sender, EventArgs e)
		{
			List<object> systeminfo = new List<object>();
			string registry_keys = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
			dataGridView1.Columns.Add("DisplayVersion", "Version");
			dataGridView1.Columns.Add("Publisher", "Publisher");
			dataGridView1.Columns.Add("EstimatedSize", "Size");
			dataGridView1.Columns.Add("InstallDate", "Installed Date");
			using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_keys))
			{
				foreach (string subkey_name in key.GetSubKeyNames())
				{
					using (RegistryKey subkey = key.OpenSubKey(subkey_name))
					{
						if (subkey != null)
						{
							object name = subkey.GetValue("DisplayName");
							object Version = subkey.GetValue("DisplayVersion");
							object publisher = subkey.GetValue("Publisher");
							object size = subkey.GetValue("EstimatedSize");
							object installDateString = subkey.GetValue("InstallDate");


							if (name != null)
							{
								string displayName = name.ToString();
								string displayVersion = Version?.ToString() ?? "N/A";
								string softwarePublisher = publisher?.ToString() ?? "N/A";
								string softwaresize = size?.ToString() ?? "N/A";
								string installedOn = "N/A";

								if (DateTime.TryParseExact(installDateString?.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime installDate))
								{
									installedOn = installDate.ToString("yyyy-MM-dd");
								}

								dataGridView1.Rows.Add(displayName, displayVersion, softwarePublisher, softwaresize, installedOn);


								// Create SystemSoftware object and add it to softwareInfo list
								SystemSoftware system = new SystemSoftware();
								system.Name = displayName;
								system.Version = displayVersion;
								system.Publisher = softwarePublisher;
								system.Size = softwaresize;
								system.InstalledOn = installedOn;
								system.SystemId = System.Environment.MachineName;

								//dataGridView1.DataSource= system;
								softwareInfo.Add(system);
							}
						}
					}

				}


				//SoftwareInfo(softwareInfo);

			}
			string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
			using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
			{
				foreach (string subkey_name in key.GetSubKeyNames())
				{
					using (RegistryKey subkey = key.OpenSubKey(subkey_name))
					{
						if (subkey != null)
						{
							object name = subkey.GetValue("DisplayName");
							object Version = subkey.GetValue("DisplayVersion");
							object publisher = subkey.GetValue("Publisher");
							object size = subkey.GetValue("EstimatedSize");
							object installDateString = subkey.GetValue("InstallDate");


							if (name != null)
							{
								string displayName = name.ToString();
								string displayVersion = Version?.ToString() ?? "N/A";
								string softwarePublisher = publisher?.ToString() ?? "N/A";
								string softwaresize = size?.ToString() ?? "N/A";
								string installedOn = "N/A";

								if (DateTime.TryParseExact(installDateString?.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime installDate))
								{
									installedOn = installDate.ToString("yyyy-MM-dd");
								}

								dataGridView1.Rows.Add(displayName, displayVersion, softwarePublisher, softwaresize, installedOn);


								// Create SystemSoftware object and add it to softwareInfo list
								SystemSoftware system = new SystemSoftware();
								system.Name = displayName;
								system.Version = displayVersion;
								system.Publisher = softwarePublisher;
								system.Size = softwaresize;
								system.InstalledOn = installedOn;
								system.SystemId = System.Environment.MachineName;

								//dataGridView1.DataSource= system;
								softwareInfo.Add(system);
							}
						}
					}

				}
				SoftwareInfo(softwareInfo);



			}


		}

		public async Task SoftwareInfo(List<SystemSoftware> data)
		{
			var jsonData = JsonConvert.SerializeObject(data);
			using (HttpClient httpClient = new HttpClient())
			{
				var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
				HttpResponseMessage response = await httpClient.PostAsync(ChatAPIs.Software_url, content);
				if (response.IsSuccessStatusCode)
				{
					string responseBody = await response.Content.ReadAsStringAsync();
					Response responseModel = JsonConvert.DeserializeObject<Response>(responseBody);
					if (responseModel != null)
					{

					}
				}
			}
		}
	}
}
