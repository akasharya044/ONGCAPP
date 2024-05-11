using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Windows.Forms;
using CIPLV2.Tickets.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CIPLV2.Tickets
{
	public partial class FrmLanding : Form
	{
		private string _ticketID = string.Empty;
		private int rating = 0;
		private List<TicketRecord> feedBacks = new List<TicketRecord>();
		private string currentincidentid = string.Empty;

		private string systemid = System.Environment.MachineName;
		string basepath = AppDomain.CurrentDomain.BaseDirectory;
		bool close5 = false;
		public string fullText = string.Empty;
		public static bool instancebool { get;set; }=false;
		public FrmLanding()
		{
			try
			{
				//LogWriter.LogWrite("try block of frmlanding constructor");
				InitializeComponent();
				string settingspath = "";


#if (DEBUG)
                settingspath = Path.Combine(basepath, "appsettings.Development.json");

#else
				settingspath = Path.Combine(basepath, "appsettings.Production.json");

#endif
				string jsondata = File.ReadAllText(settingspath);
				dynamic output = JsonConvert.DeserializeObject<object>(jsondata);
				TicketApi.GET_TICKET_URL = output.GET_TICKET_URL;
				TicketApi.UPDATE_TICKET_URL = output.UPDATE_TICKET_URL;
				//LogWriter.LogWrite(TicketApi.GET_TICKET_URL);
				//LogWriter.LogWrite(TicketApi.UPDATE_TICKET_URL);
				instancebool = false;
			}
			catch (Exception ex)
			{
				LogWriter.LogWrite("exception in getting config - " + ex.Message);
				currentincidentid = string.Empty;
				this.Hide();
			}
		}


		private async void FrmLanding_Load(object sender, EventArgs e)
		{
			if (instancebool == false)
			{
				//LogWriter.LogWrite("Start Ticket Count");
				await GetTicketCount();
				//LogWriter.LogWrite("End Ticket Count");

			}
			else
			{
				currentincidentid = string.Empty;
				this.Hide();
			}
		}

		private async Task GetTicketCount()
		{
			try
			{
				//LogWriter.LogWrite("try block of getticketcount method");
				var systemid = System.Environment.MachineName;
				HttpClient httpClient = new HttpClient();
				var response = await httpClient.GetAsync(new Uri(TicketApi.GET_TICKET_URL + "?systemid=" + systemid));
				if(response.IsSuccessStatusCode)
				{
					string responseBody = await response.Content.ReadAsStringAsync();
					Response responseModel = JsonConvert.DeserializeObject<Response>(responseBody);
					if (responseModel.Status == "Success" && responseModel != null)
					{
						feedBacks = JsonConvert.DeserializeObject<List<TicketRecord>>(responseModel.Data.ToString());
						if (feedBacks != null && feedBacks.Count > 0)
						{
							//LogWriter.LogWrite("Feedback Count" + feedBacks.Count);
							LoadFeedback();
						}
						else
						{
							instancebool = true;
							currentincidentid = string.Empty;
							this.Hide();
						}

					}
					else
					{
						instancebool = true;

						currentincidentid = string.Empty;
						this.Hide();
					}
				}
				else
				{
					instancebool = true;
					currentincidentid = string.Empty;
					this.Hide();
				}
			}
			catch (Exception ex)
			{
				LogWriter.LogWrite("exception in getticketcount method- " + ex.Message.ToString());
				currentincidentid = string.Empty;
				this.Hide();
			}

		}
		private void LoadFeedback()
		{
			try
			{
				//LogWriter.LogWrite("try block of loadfeedback");
				if (feedBacks.Count == 0 || feedBacks == null)
				{
					//LogWriter.LogWrite(" Enter into if condition feedBacks.Count == 0 on LoadFeedback Method");
					currentincidentid = string.Empty;
					this.Hide();
					return;
				}
				else
				{
					pnlfeddback.Visible = true;
					if (feedBacks[0].TicketId == null|| feedBacks[0].TicketId==0)
					{
						currentincidentid = string.Empty;
						this.Hide();
					}
					else
					{

						fullText = feedBacks[0].Description.ToString();
						if (fullText.Length > 25)
						{
                            button1.Visible = true;
                        }
						else
						{
                            button1.Visible = false;
                        }
                        currentincidentid = feedBacks[0].TicketId.ToString();
						if (feedBacks[0].close_count == 0)
						{
							lblincidentno.Text = feedBacks[0].TicketId.ToString();

						}
						if (feedBacks[0].close_count <= 4 && feedBacks[0].close_count > 0)
						{

							lblincidentno.Text = feedBacks[0].TicketId.ToString() + " " + "(Reminder" + feedBacks[0].close_count.ToString() + ")";
						}
						if (feedBacks[0].close_count == 5)
						{
							lblincidentno.Text = feedBacks[0].TicketId.ToString() + " " + "(final Reminder)";

						}
                        lblsubject.Text = GetShortenedText(fullText);

                        //lblsubject.Text = feedBacks[0].Description;
                        lblassignedto.Text = feedBacks[0].ExpertAssigneeName;
						if (feedBacks[0].ResolvedDateTime != null && feedBacks[0].ResolvedDateTime != "")
						{
							long unixTimestampInMilliseconds = Convert.ToInt64(feedBacks[0].ResolvedDateTime);
							if (feedBacks[0].ResolvedDateTime.Length > 10)
							{
								DateTimeOffset resolvedDateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(unixTimestampInMilliseconds);
								DateTime resolvedDateTime = resolvedDateTimeOffset.UtcDateTime.AddHours(5).AddMinutes(30); // Use UtcDateTime to get the UTC time if your timestamp is in UTC.

								string formattedDate = resolvedDateTime.ToString("dd/MM/yyyy");
								lblresolvedon.Text = formattedDate;

							}
							else
							{
								DateTimeOffset resolvedDateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTimestampInMilliseconds);
								DateTime resolvedDateTime = resolvedDateTimeOffset.UtcDateTime.AddHours(5).AddMinutes(30); // Use UtcDateTime to get the UTC time if your timestamp is in UTC.

								string formattedDate = resolvedDateTime.ToString("dd/MM/yyyy");
								lblresolvedon.Text = formattedDate;

							}

						}

					}
				}
			}
			catch (Exception ex)
			{
				LogWriter.LogWrite("exception in loadfeedback method - " + ex.Message);
				currentincidentid = string.Empty;
				this.Hide();
			}

		}
		private void btn1_Click(object sender, EventArgs e)
		{

			UpdateRating(1);
		}
		private void UpdateRating(int ratings)
		{
			rating = ratings;
			TicketApi.starcount = rating;
			foreach (var control in this.pnlcontrols.Controls)
			{
				string ctlname = control.GetType().Name;
				//Console.WriteLine("Control Name " + ctlname);
				if (control.GetType().Name == "Button")
				{
					var ctl = (Button)control;
					if (ctl.Tag != ""&& ctl.Tag!=null)
					{
						if (ctl.Tag.ToString() == "feedback")
						{
							ctl.BackgroundImage = global::CIPLV2.Tickets.Properties.Resources.b_star;
						}
						if (ctl.Tag.ToString() == "feedback" && Convert.ToInt32(ctl.Name[4].ToString()) <= rating)
						{
							ctl.BackgroundImage = global::CIPLV2.Tickets.Properties.Resources.y_star;
						}
					}

				}
			}

		}

		private void pnlfeddback_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btn_2_Click(object sender, EventArgs e)
		{
			UpdateRating(2);
		}

		private void btn_3_Click(object sender, EventArgs e)
		{
			UpdateRating(3);
		}

		private void btn_4_Click(object sender, EventArgs e)
		{
			UpdateRating(4);
		}

		private void btn_5_Click(object sender, EventArgs e)
		{
			UpdateRating(5);
		}

		private void cmdclose_Click(object sender, EventArgs e)
		{
			CloseAction();

		}
		private async Task CloseAction()
		{
			try
			{
				//LogWriter.LogWrite("try block of closeaction");
				foreach (var item in feedBacks)
				{
					if (item.close_count == 5)
					{
						close5 = true;
						TicketApi.starcount = 5;
						textBox1.Text = "popup has been closed five times,so taking into consideration your five star rated services";
						SubmitFeedback();
					}
				}
				if (close5 == false)
				{
					if (currentincidentid != null&& currentincidentid!="")
					{
						UpdateTicket updateTicket = new UpdateTicket();
						updateTicket.starcount = TicketApi.starcount;
						updateTicket.action = "close";
						updateTicket.IncidentId = Convert.ToInt32(currentincidentid);
						updateTicket.Remarks = textBox1.Text;
						string jsonData = JsonConvert.SerializeObject(updateTicket);
						HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
						HttpClient httpClient = new HttpClient();
						var response = await httpClient.PostAsync(new Uri(TicketApi.UPDATE_TICKET_URL), content);
						if (response.IsSuccessStatusCode)
						{
							string responseBody = await response.Content.ReadAsStringAsync();
							Response responseModel = JsonConvert.DeserializeObject<Response>(responseBody);
							if (responseModel.Status == "Success" && responseModel != null)
							{
								feedBacks = JsonConvert.DeserializeObject<List<TicketRecord>>(responseModel.Data.ToString());
								MessageBox.Show(updateTicket.IncidentId + " Ticket Close Successfully...");
								clear();
								if (feedBacks != null && feedBacks.Count > 0)
								{
									LoadFeedback();
								}
								else
								{
									instancebool = true;

									currentincidentid = string.Empty;
									this.Hide();
								}

							}
							else
							{
								instancebool = true;

								currentincidentid = string.Empty;
								this.Hide();
							}
						}
						else
						{
							instancebool = true;

							currentincidentid = string.Empty;
							this.Hide();
						}
					}
					else
					{
						instancebool = true;

						currentincidentid = string.Empty;
						this.Hide();
						return;
					}
				}
			}
			catch (Exception ex)
			{
				LogWriter.LogWrite("Exception in CloseAction Method- " + ex.Message);
				currentincidentid = string.Empty;
				this.Hide();
			}
		}


		private void FrmLanding_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseAction();


		}

		private async Task SubmitFeedback()
		{
			try
			{
				//LogWriter.LogWrite("try block of submitfeedback");
				if (currentincidentid != null && currentincidentid!="")
				{
					UpdateTicket updateTicket = new UpdateTicket();
					updateTicket.starcount = TicketApi.starcount;// TicketApi.starcount;
					updateTicket.action = "submit";
					updateTicket.IncidentId = Convert.ToInt32(currentincidentid);
					updateTicket.Remarks = textBox1.Text;
					if (updateTicket.starcount <= 3 && (updateTicket.Remarks==null||updateTicket.Remarks==""))
					{
						MessageBox.Show("Remarks is Mandatory");
						return;
					}
					string jsonData = JsonConvert.SerializeObject(updateTicket);
					HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");


					HttpClient httpClient = new HttpClient();
					var response = await httpClient.PostAsync(new Uri(TicketApi.UPDATE_TICKET_URL), content);
					if (response.IsSuccessStatusCode)
					{
						string responseBody = await response.Content.ReadAsStringAsync();
						Response responseModel = JsonConvert.DeserializeObject<Response>(responseBody);
						if (responseModel.Status == "Success" && responseModel != null)
						{
							feedBacks = JsonConvert.DeserializeObject<List<TicketRecord>>(responseModel.Data.ToString());
							MessageBox.Show(updateTicket.IncidentId + " Ticket Sumbit Successfully...");
							clear();
							if (feedBacks != null && feedBacks.Count > 0)
							{
								LoadFeedback();
							}
							else
							{
								currentincidentid = string.Empty;
								this.Hide();
							}

						}
						else
						{
							instancebool = true;

							currentincidentid = string.Empty;
							this.Hide();
						}
					}
					else
					{
						instancebool = true;

						currentincidentid = string.Empty;
						this.Hide();
					}
				}
				else
				{
					currentincidentid = string.Empty;
					this.Hide();
				}
			}
			catch (Exception ex)
			{
				LogWriter.LogWrite("Exception in Submit Feedback - " + ex.Message);
				currentincidentid = string.Empty;
				this.Hide();
			}

		}

		private void clear()
		{
			TicketApi.starcount = 0;
			textBox1.Text = "";
			UpdateRating(0);
		}

		private void cmdsubmit_Click(object sender, EventArgs e)
		{
			SubmitFeedback();
		}

		private void FrmLanding_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.OnClosed(e);

			GC.WaitForFullGCComplete();
		}

		private void CIPL_MouseDoubleClick(object sender, MouseEventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void pnlfeddback_Paint_1(object sender, PaintEventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}
        private string GetShortenedText(string text)
        {
            const int maxDisplayLength = 25; // Set the maximum number of characters to display initially
			if (text.Length <= maxDisplayLength)
				return text;
			else
			{
				button1.Visible = true;
				return text.Substring(0, maxDisplayLength) + "...";
			}
        }

       
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(fullText, "Subject", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}