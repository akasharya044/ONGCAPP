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
using System.Threading.Tasks;
using System.Windows.Forms;
using CIPL.AppCode;

namespace CIPL.DashboardControl
{
	public partial class PdfControl : UserControl
	{
		public PdfControl()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SelfHeal selfcontrol = new SelfHeal();
			selfcontrol.Visible = true;
			this.Visible = false;
		}

		private void PdfControl_Load(object sender, EventArgs e)
		{

		}

        private void label1_Click(object sender, EventArgs e)
        {
			try
			{
				label1.Text = "Repair PDF [Working ...]";
				DialogResult result = MessageBox.Show("This Feature Will Set Adobe As A Default Application", "PDF Repair", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
				if (result == DialogResult.OK)
				{
					Events events = new Events();
					events.Event = "Repair Pdf";
					events.EventDate = DateTime.Now;
					events.SystemId = System.Environment.MachineName;
					APIs.EventLog(events);


					using (Process cmd = new Process())
					{
						cmd.StartInfo.FileName = "cmd.exe";
						cmd.StartInfo.Arguments = $"/c SetUserFTA .pdf AcroExch.Document.DC";

						cmd.StartInfo.UseShellExecute = false;
						cmd.StartInfo.RedirectStandardOutput = true;
						cmd.StartInfo.CreateNoWindow = true;
						cmd.Start();
						// Read the output (if needed)
						string output = cmd.StandardOutput.ReadToEnd();

						// Wait for the process to finish
						cmd.WaitForExit();

						label1.Text = "Repair PDF";
						MessageBox.Show("Adobe App Set Default Application Successfully");

					}
				}
				else
				{
					label1.Text = "Repair PDF";
					MessageBox.Show("Process Has Been Terminated By User..", "Proceess Terminated", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

			}
			catch (Exception ex)
			{
				label1.Text = "Repair PDF";
				MessageBox.Show(ex.ToString());

			}
		}
		private bool IsAdministrator()
		{

			WindowsIdentity identity = WindowsIdentity.GetCurrent();
			WindowsPrincipal principal = new WindowsPrincipal(identity);
			return principal.IsInRole(WindowsBuiltInRole.Administrator);

		}

		private void RunAsAdministrator()
		{
			var startInfo = new ProcessStartInfo()
			{
				FileName = Application.ExecutablePath,
				UseShellExecute = true,
				Verb = "runas"
			};

			try
			{
				Process.Start(startInfo);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error While Attempting To Restart As Administrator: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			Application.Exit();

		}
	}
}
