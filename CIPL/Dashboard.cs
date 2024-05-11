using System;
using System.Diagnostics;

//using System.Data;
//using System.Linq;
//using System.Management;
//using System.Net;
//using System.Net.NetworkInformation;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using CIPL.AppCode;
//using Newtonsoft.Json;


namespace CIPL
{
	public partial class Dashboard : Form
	{
		//string HWID = "";
		//string ram = "";
		public Dashboard()
		{
			InitializeComponent();
			//try
			//{
			//	ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
			//	WebClient NewWebClient = new WebClient();
			//}
			//catch (Exception ex)
			//{
			//}
		}

		private void Dashboard_Load(object sender, EventArgs e)
		{
			try
			{
				AutoUpdater.Start(APIs.HostURl + "/ciplupdate.xml");
			}
			catch
			{
				// rik				MessageBox.Show("You may need to provide administrative priviledge for AutoUpdater facility.", "Auto Updater Access");
			}

			selfHeal.Visible = false;
			chromeControl.Visible = false;
			systemInfo.Visible = false;
			antiControl.Visible = false;
			ticketControl.Visible = false;
			panel1.Visible = false;
			chatControl1.Visible = false;
			raiseTicControl1.Visible = false;
			ratingControl1.Visible = false;
			ShowSelfHeal();

			
		}
		private void CheckLogin()
		{
			if (APIs.UserName != "" && APIs.UserName != "Enter DomainId" && APIs.Password != "" && APIs.Password != "Enter password")
			{
				loginControl1.Visible = false;
				chatControl1.Visible = true;
			}
		}
		private void softbtn_Click(object sender, EventArgs e)
		{
			selfHeal.Visible = false;
			systemInfo.Visible = true;
			antiControl.Visible = false;
			ticketControl.Visible = false;
			panel1.Visible = false; ;
			loginControl1.Visible = false;
			chatControl1.Visible = false;
			ratingControl1.Visible = false;
			raiseTicControl1.Visible = false;
		}

		private void antibtn_Click(object sender, EventArgs e)
		{
			selfHeal.Visible = false;
			systemInfo.Visible = false;
			antiControl.Visible = true;
			ticketControl.Visible = false;
			panel1.Visible = false; ;
			loginControl1.Visible = false;
			chatControl1.Visible = false;
			ratingControl1.Visible = false;
			raiseTicControl1.Visible = false;
		}

		private void LoginClick()
		{
			panel1.Visible = true;
			selfHeal.Visible = false;
			systemInfo.Visible = false;
			antiControl.Visible = false;
			ticketControl.Visible = false;
			loginControl1.Visible = true; // rik now it's correct
			chatControl1.Visible = false;
			ratingControl1.Visible = false;
			raiseTicControl1.Visible = false; // rik now it's correct
			CheckLogin();

		}
		private void chatbtn_Click(object sender, EventArgs e)
		{
			LoginClick();
		}

		private void selfbtn_Click(object sender, EventArgs e)
		{

			ShowSelfHeal();
		}

		private void ShowSelfHeal()
		{
			selfHeal.Visible = true;
			chromeControl.Visible = false;
			ticketControl.Visible = false;
			panel1.Visible = false; ;
			loginControl1.Visible = false;
			chatControl1.Visible = false;
			ratingControl1.Visible = false;
			raiseTicControl1.Visible = false;
			systemInfo.Visible = false;
		}

		private void ticketbtn_Click(object sender, EventArgs e)
		{
			selfHeal.Visible = true;
			systemInfo.Visible = false;
			antiControl.Visible = false;
			ticketControl.Visible = false;
			panel1.Visible = false; ;
			loginControl1.Visible = false;
			chatControl1.Visible = false;
			ratingControl1.Visible = false;
			raiseTicControl1.Visible = false;

		}
		private void CIPL_MouseDoubleClick(object sender, MouseEventArgs e)
		{

		}

		private void toolTip1_Popup(object sender, PopupEventArgs e)
		{

		}

		private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
		{

		}

		public void SetVisibleTrueChatControl()
		{
			panel1.Visible = true;
			selfHeal.Visible = false;
			systemInfo.Visible = false;
			antiControl.Visible = false;
			ticketControl.Visible = false;
			loginControl1.Visible = false;
			chatControl1.Visible = true;
			ratingControl1.Visible = false;
			raiseTicControl1.Visible = false;
			chatControl1.AllClear();

		}
		public void SetVisibleTrueCustCareControl()
		{
			panel1.Visible = true;
			selfHeal.Visible = false;
			systemInfo.Visible = false;
			antiControl.Visible = false;
			ticketControl.Visible = false;
			loginControl1.Visible = false;
			chatControl1.Visible = false;
			ratingControl1.Visible = false;
			raiseTicControl1.Visible = false;

		}
		public void SetVisibleTrueRaiseTicControl()
		{
			panel1.Visible = true;
			selfHeal.Visible = false;
			systemInfo.Visible = false;
			antiControl.Visible = false;
			ticketControl.Visible = false;
			loginControl1.Visible = false;
			chatControl1.Visible = false;
			ratingControl1.Visible = false;
			raiseTicControl1.Visible = true;
			raiseTicControl1.AllClear();
		}
		public void SetVisibleTrueRatingControl()
		{
			panel1.Visible = true;
			selfHeal.Visible = false;
			systemInfo.Visible = false;
			antiControl.Visible = false;
			ticketControl.Visible = false;
			loginControl1.Visible = false;
			chatControl1.Visible = false;
			ratingControl1.Visible = true;
			raiseTicControl1.Visible = false;

		}

		private void loginControl1_Load(object sender, EventArgs e)
		{

		}

		private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.OnClosed(e);
			GC.WaitForFullGCComplete();
		}
	}
}
