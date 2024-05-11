using CIPL.AppCode;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIPL.DashboardControl
{
	public partial class ImageControl : UserControl
	{
		public ImageControl()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SelfHeal selfcontrol = new SelfHeal();
			selfcontrol.Visible = true;
			this.Visible = false;
		}



		private void label1_Click(object sender, EventArgs e)
		{
			try
			{


				label1.Text = "Repair Image [Working...]";
				DialogResult result = MessageBox.Show("This Feature Will Set Photos App As A Default Application", "Repair Image", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

				if (result == DialogResult.OK)
				{

					Events events = new Events();
					events.Event = "Repair Image";
					events.EventDate = DateTime.Now;
					events.SystemId = System.Environment.MachineName;
					APIs.EventLog(events);

					var processStartInfo = new ProcessStartInfo();
					processStartInfo.FileName = "cmd.exe";
					processStartInfo.Arguments = $"/c SetUserFTA .png  AppX43hnxtbyyps62jhe9sqpdzxn1790zetc && SetUserFTA .jpg  AppX43hnxtbyyps62jhe9sqpdzxn1790zetc && SetUserFTA .jpeg  AppX43hnxtbyyps62jhe9sqpdzxn1790zetc"; processStartInfo.UseShellExecute = false;
					processStartInfo.RedirectStandardOutput = true;
					processStartInfo.CreateNoWindow = true;
					//processStartInfo.Verb = "runas";

					var process = new Process();
					process.StartInfo = processStartInfo;
					process.Start();
					label1.Text = "Repair Image ";
					MessageBox.Show("Photos App Set Default Application Successfully");
				}
				else
				{
					label1.Text = "Repair Image ";
					MessageBox.Show("Process Has Been Terminated By User", "Repair Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}




			}
			catch (Exception ex)
			{
				label1.Text = "Repair Image";
				MessageBox.Show("This Feature Requires Admin Rights. Contact Administrator", "Image Repair", MessageBoxButtons.OK, MessageBoxIcon.Error);


			}
		}
		
		private void panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void ImageControl_Load(object sender, EventArgs e)
		{

		}

		private void pictureBox6_Click(object sender, EventArgs e)
		{

		}

	}
}
