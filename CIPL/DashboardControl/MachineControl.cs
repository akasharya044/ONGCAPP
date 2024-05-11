using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CIPL.AppCode;

namespace CIPL.DashboardControl
{
	public partial class MachineControl : UserControl
	{
		public MachineControl()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SelfHeal selfcontrol = new SelfHeal();
			selfcontrol.Visible = true;
			this.Visible = false;
		}



		private void MachineControl_Load(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{
			var processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = "cmd.exe";
			processStartInfo.Arguments = "/c cleanmgr /sagerun:1";
			processStartInfo.UseShellExecute = false;
			processStartInfo.RedirectStandardOutput = true;
            processStartInfo.CreateNoWindow = true;
            var process = new Process();
			process.StartInfo = processStartInfo;
			process.Start();
		}

		//private void label4_Click(object sender, EventArgs e)
		//{
		//    // Hard-coded Command Prompt script content
		//    string cmdScriptContent = @"
		//            @echo off
		//            echo Clearing Standby List to free up memory...
		//            echo|set /p= "" "" > ""%temp%\EmptyStandbyList.vbs""
		//            echo Set objWMI = GetObject(""winmgmts:{impersonationLevel=impersonate}!\\.\root\cimv2"") >> ""%temp%\EmptyStandbyList.vbs""
		//            echo Set colOS = objWMI.ExecQuery(""SELECT * FROM Win32_OperatingSystem"") >> ""%temp%\EmptyStandbyList.vbs""
		//            echo For Each objOS in colOS >> ""%temp%\EmptyStandbyList.vbs""
		//            echo   objOS.EmptyWorkingSet() >> ""%temp%\EmptyStandbyList.vbs""
		//            echo Next >> ""%temp%\EmptyStandbyList.vbs""
		//            cscript //NoLogo ""%temp%\EmptyStandbyList.vbs""
		//            del ""%temp%\EmptyStandbyList.vbs""
		//            echo Memory optimization complete.
		//            ";

		//    // Specify the full path where you want to save the script file
		//    string cmdFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MemoryBoost.cmd");

		//    // Save the script content to the specified path
		//    File.WriteAllText(cmdFile, cmdScriptContent);

		//    var startInfo = new ProcessStartInfo()
		//    {
		//        FileName = "cmd.exe",
		//        Arguments = $"/c \"{cmdFile}\"",
		//        UseShellExecute = true,
		//        CreateNoWindow = true
		//    };

		//    Process.Start(startInfo);
		//    MessageBox.Show("Memory Boosted");
		//}

		private void label4_Click(object sender, EventArgs e)
		{
			try
			{
				label4.Text = "Memory[Working...]";

				// Hard-coded Command Prompt script content
				Events events = new Events();
				events.Event = "Memory Boost";
				events.EventDate = DateTime.Now;
				events.SystemId = System.Environment.MachineName;
				APIs.EventLog(events);
				DialogResult result = MessageBox.Show("This Feature Will Run Disk Clean Process Will Take Time. Are You Sure Want To Procced Further ?", "Disk Clean Up", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{

					using (Process cmd = new Process())
					{
						// Configure the process
						string scriptPath = Path.Combine("ScriptFiles\\M20242201.bat");


						string scriptContents = File.ReadAllText(scriptPath);
						cmd.StartInfo.FileName = "cmd.exe";
						cmd.StartInfo.Arguments = $"/C \"{scriptPath}\"";
						cmd.StartInfo.UseShellExecute = false;
						cmd.StartInfo.RedirectStandardOutput = true;
						cmd.StartInfo.CreateNoWindow = true;
						//cmd.StartInfo.Verb = "runas";

						// Start the process
						cmd.Start();
						//MessageBox.Show("Memory Boosting In Progress. Please Wait...", "Memory Boost", MessageBoxButtons.OK, MessageBoxIcon.Information);

						// Read the output (if needed)
						string output = cmd.StandardOutput.ReadToEnd();

						// Wait for the process to finish
						cmd.WaitForExit();
						label4.Text = "Memory";
						MessageBox.Show("Memory Optimization Complete.", "Memory Boost", MessageBoxButtons.OK, MessageBoxIcon.Information);

						// Display the output (if needed)
						MessageBox.Show(output);
					}
				}
				else
				{
					label4.Text = "Memory";
					MessageBox.Show("Process Has Been Terminated By User..", "Proceess Terminated", MessageBoxButtons.OK, MessageBoxIcon.Error);

				}

			}
			catch (Exception ex)
			{
				label4.Text = "Memory";

				MessageBox.Show(ex.Message.ToString());
			}

		}

		private void label3_Click(object sender, EventArgs e)
		{
			try
			{
				label3.Text = "Disk Clean Up[Working...]";
				Events events = new Events();
				events.Event = "Disk Cleanup";
				events.EventDate = DateTime.Now;
				events.SystemId = System.Environment.MachineName;
				APIs.EventLog(events);

				DialogResult result = MessageBox.Show("This Feature Will Run Disk Clean Process Will Take Time. Are You Sure Want To Procced Further ?", "Disk Clean Up", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					//MessageBox.Show("Disk Clean Up In Process", "Disk Clean", MessageBoxButtons.OK, MessageBoxIcon.Information);
					var processStartInfo = new ProcessStartInfo();
					processStartInfo.FileName = "cmd.exe";
					processStartInfo.Arguments = "/c cleanmgr /sagerun:1";
					processStartInfo.UseShellExecute = false;
					processStartInfo.RedirectStandardOutput = true;
					processStartInfo.CreateNoWindow = true;
					var process = new Process();
					process.StartInfo = processStartInfo;
					process.Start();
					label3.Text = "Disk Clean Up";
				}
				else
				{
					label3.Text = "Disk Clean Up";
					MessageBox.Show("Process Has Been Terminated By User..", "Proceess Terminated", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				label3.Text = "Disk Clean Up";
				MessageBox.Show("Disk Clean Up Is  Not Working Contact Administrator");
			}

		}
	}
}
