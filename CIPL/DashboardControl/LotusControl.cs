using CIPL.AppCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIPL.DashboardControl
{
	public partial class LotusControl : UserControl
	{
		public LotusControl()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SelfHeal selfcontrol = new SelfHeal();
			selfcontrol.Visible = true;
			this.Visible = false;
		}		

		private void label1_Click_1(object sender, EventArgs e)
		{
			try
			{
				label1.Text = "Repair Lotus[Working...]";
				Events events = new Events();
				events.Event = "Lotus Services Has Been Terminated";
				events.EventDate = DateTime.Now;
				events.SystemId = System.Environment.MachineName;
				APIs.EventLog(events);
				int msg = (int)MessageBox.Show("This Process Will Stop Any Running Lotus Instance. Do You Want To Continue?", "Lotus Repair", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (msg == 6)
				{
					foreach (Process clsProcess in Process.GetProcesses())
						if (clsProcess.ProcessName.Contains("nlnotes") || clsProcess.ProcessName.Contains("notes2"))  //Process Excel?
							clsProcess.Kill();
					label1.Text = "Repair Lotus";
					MessageBox.Show("All Lotus Services Has Been Terminted");
				}
				else
				{
					label1.Text = "Repair Lotus";
					MessageBox.Show("Process Has Been Terminated By User..", "Proceess Terminated", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				label1.Text = "Repair Lotus";
				MessageBox.Show(ex.Message.ToString());

			}

		}


	}
}

