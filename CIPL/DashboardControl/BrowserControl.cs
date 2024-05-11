using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.IO;
using CIPL.AppCode;

namespace CIPL.DashboardControl
{
	public partial class BrowserControl : UserControl
	{
		public BrowserControl()
		{
			InitializeComponent();
		}

		private void fireControl1_Load(object sender, System.EventArgs e)
		{

		}

		private void button1_Click(object sender, System.EventArgs e)
		{

		}

		private void ClearHistory_Click(object sender, System.EventArgs e)
		{
            Events events = new Events();
            events.Event = "Clear History";
            events.EventDate = DateTime.Now;
            events.SystemId = System.Environment.MachineName;
            APIs.EventLog(events);
        }

		private void ClearCache_Click(object sender, System.EventArgs e)
		{
            Events events = new Events();
            events.Event = "Clear Cache";
            events.EventDate = DateTime.Now;
            events.SystemId = System.Environment.MachineName;
            APIs.EventLog(events);
        }

		private void ClearCookies_Click(object sender, System.EventArgs e)
		{
            Events events = new Events();
            events.Event = "Clear Cookies";
            events.EventDate = DateTime.Now;
            events.SystemId = System.Environment.MachineName;
            APIs.EventLog(events);
        }

		private void AllClear_Click(object sender, System.EventArgs e)
		{
            Events events = new Events();
            events.Event = "All Clear";
            events.EventDate = DateTime.Now;
            events.SystemId = System.Environment.MachineName;
            APIs.EventLog(events);
        }

		private void ClearBookMark_Click(object sender, System.EventArgs e)
		{
            Events events = new Events();
            events.Event = "Clear BookMark";
            events.EventDate = DateTime.Now;
            events.SystemId = System.Environment.MachineName;
            APIs.EventLog(events);
        }

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			ClearHistory_Click(sender,e);
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			ClearCache_Click(sender, e);
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			ClearCookies_Click(sender, e);
		}

		private void pictureBox4_Click(object sender, EventArgs e)
		{
			AllClear_Click(sender, e);
		}

		private void pictureBox5_Click(object sender, EventArgs e)
		{
			ClearBookMark_Click(sender, e);
		}
	}
}
