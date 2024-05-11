using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CIPL.AppCode;

namespace CIPL.DashboardControl
{
	public partial class PrinterControl : UserControl
	{
		public PrinterControl()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SelfHeal selfcontrol = new SelfHeal();
			selfcontrol.Visible = true;
			this.Visible = false;
		}

        private void lblPrinter_Click(object sender, EventArgs e)
        {
			try
			{
				Events events = new Events();
				events.Event = "Repair Printer";
				events.EventDate = DateTime.Now;
				events.SystemId = System.Environment.MachineName;
				APIs.EventLog(events);

				DialogResult result = MessageBox.Show("This Feature Require Adminstrator Rights. Are You An Administrator ?", "Repair Printer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{

					Cursor = Cursors.WaitCursor;

					// Stop the spooler.
					ServiceController service = new ServiceController("Spooler");
					if ((!service.Status.Equals(ServiceControllerStatus.Stopped)) &&
						(!service.Status.Equals(ServiceControllerStatus.StopPending)))
					{
						service.Stop();
						service.WaitForStatus(ServiceControllerStatus.Stopped);
					}

					// Start the spooler.

					service.Start();
					service.WaitForStatus(ServiceControllerStatus.Running);

					Cursor = Cursors.Default;
					MessageBox.Show("Printer Spooler Restart Successfully");

				}
				else
				{
					MessageBox.Show("Process Terminated..", "Terminated", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Require Administrator Rights , Contact Your Administrator", "Repair Printer", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
