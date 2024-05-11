using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Principal;
using CIPL.AppCode;
using System.Threading;

namespace CIPL.DashboardControl
{
    public partial class WindowControl : UserControl
    {

        [DllImport("Shell32.dll")]

        static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlag dwFlags);

        enum RecycleFlag : int

        {

            SHERB_NOCONFIRMATION = 0x00000001, // No confirmation, when emptying

            SHERB_NOPROGRESSUI = 0x00000001, // No progress tracking window during the emptying of the recycle bin

            SHERB_NOSOUND = 0x00000004 // No sound when the emptying of the recycle bin is complete

        }
        public WindowControl()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SelfHeal selfcontrol = new SelfHeal();
            selfcontrol.Visible = true;
            this.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            try
            {
                label3.Text = "Recycle Bin [Cleaning...]";
                Events events = new Events();
                events.Event = "Recycle Bin Cleared";
                events.EventDate = DateTime.Now;
                events.SystemId = System.Environment.MachineName;
                APIs.EventLog(events);
                DialogResult result = MessageBox.Show(" Are You Sure Want To Clear Recycle Bin ?", "Recycle Bin", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlag.SHERB_NOSOUND | RecycleFlag.SHERB_NOCONFIRMATION);
                    label3.Text = "Recycle Bin";
                    MessageBox.Show("Recycle Bin Cleared", "Recycle Bin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    label3.Text = "Recycle Bin";
                    MessageBox.Show("Process Has Been Terminated By User..", "Proceess Terminated", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                label3.Text = "Recycle Bin";
            }
        }



        private void lblsetTimeZone_Click(object sender, EventArgs e)
        {

            try
            {
                lblsetTimeZone.Text = "Set Time Zone [working...]";
                Events events = new Events();
                events.Event = "Time Zone Changed";
                events.EventDate = DateTime.Now;
                events.SystemId = System.Environment.MachineName;
                APIs.EventLog(events);
                DialogResult result = MessageBox.Show("This Feature Will Set Time Zone To IST. Are You Sure ?", "Time Zone", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                    // Hard-coded Command Prompt script content
                    string scriptContent = @"
								 @echo off
								 set ""targetTimeZone=India Standard Time""

								 REM Display the current time zone
								 for /f %%i in ('tzutil /g') do set ""currentTimeZone=%%i""
								 echo Current Time Zone: %currentTimeZone%

								 REM Display the target time zone
								 echo Target Time Zone: %targetTimeZone%

								 REM Set the new time zone
								 tzutil /s ""%targetTimeZone%""

								 REM Display the new time zone
								 for /f %%i in ('tzutil /g') do set ""newTimeZone=%%i""
								 echo Time Zone changed successfully. New Time Zone: %newTimeZone%
								 ";

                    // Specify the full path where you want to save the script file
                    string cmdFile = Path.Combine(Path.GetTempPath(), "ChangeTimeZone.cmd");

                    // Save the script content to the specified path
                    File.WriteAllText(cmdFile, scriptContent);

                    // Now 'cmdFile' contains the path to the temporary script file

                    var startInfo = new ProcessStartInfo()
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/c \"{cmdFile}\"",
                        UseShellExecute = true,
                        CreateNoWindow = true
                    };

                    Process.Start(startInfo);
                    lblsetTimeZone.Text = "Set Time Zone to IST";

                    MessageBox.Show("Time Zone Has Been Changed to IST", "Time Zone", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblsetTimeZone.Text = "Set Time Zone to IST";
                    MessageBox.Show("Process Has Been Terminated By User..", "Proceess Terminated", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                lblsetTimeZone.Text = "Set Time Zone to IST";
                MessageBox.Show("Failed To Default The TimeZone Contact Administrator");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("This Feature Will Run Cache Clear Process Will Take Time. Are You Sure Want To Procced Further ?", "Disk Clean Up", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    label5.Text = "Cache Clear Process [Working...]";
                    // Hard-coded Command Prompt script content
                    Events events = new Events();
                    events.Event = "Cache Clear";
                    events.EventDate = DateTime.Now;
                    events.SystemId = System.Environment.MachineName;
                    APIs.EventLog(events);
                    using (Process cmd = new Process())
                    {
                        // Configure the process
                        string scriptPath = Path.Combine("ScriptFiles\\C20242201.bat");


                        string scriptContents = File.ReadAllText(scriptPath);
                        cmd.StartInfo.FileName = "cmd.exe";
                        cmd.StartInfo.Arguments = $"/C \"{scriptPath}\"";
                        cmd.StartInfo.UseShellExecute = false;
                        cmd.StartInfo.RedirectStandardOutput = true;
                        cmd.StartInfo.CreateNoWindow = true;
                        //cmd.StartInfo.Verb = "runas";

                        // Start the process
                        cmd.Start();


                        // Read the output (if needed)
                        string output = cmd.StandardOutput.ReadToEnd();

                        // Wait for the process to finish
                        cmd.WaitForExit();
                        Thread.Sleep(1500);
                        label5.Text = "Cache";
                        MessageBox.Show("Cache Clear Complete.", "Cache Clear", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Display the output (if needed)
                        //MessageBox.Show(output);
                    }

                    

                }
                else
                {
                    label5.Text = "Cache";
                    MessageBox.Show("Process Has Been Terminated By User..", "Proceess Terminated", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                label5.Text = "Cache";
                MessageBox.Show($"Error Clearing Temporary Files: {ex.Message}");
            }
        }


        private void lblwifi_Click(object sender, EventArgs e)
        {
            try
            {
                lblwifi.Text = "Wifi Reset [Working...]";
                // Hard-coded Command Prompt script content
                Events events = new Events();
                events.Event = "Wifi Reset";
                events.EventDate = DateTime.Now;
                events.SystemId = System.Environment.MachineName;
                APIs.EventLog(events);
                DialogResult result = MessageBox.Show("This Feature Will Wipe All The Key and Reset The Wifi Adapter! Are You Sure ?", "Wifi Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    using (Process cmd = new Process())
                    {
                        // Configure the process
                        string scriptPath = Path.Combine("ScriptFiles\\W20242201.bat");


                        string scriptContents = File.ReadAllText(scriptPath);
                        cmd.StartInfo.FileName = "cmd.exe";
                        cmd.StartInfo.Arguments = $"/C \"{scriptPath}\"";
                        cmd.StartInfo.UseShellExecute = false;
                        cmd.StartInfo.RedirectStandardOutput = true;
                        cmd.StartInfo.CreateNoWindow = true;
                        //cmd.StartInfo.Verb = "runas";

                        // Start the process
                        cmd.Start();


                        // Read the output (if needed)
                        string output = cmd.StandardOutput.ReadToEnd();

                        // Wait for the process to finish
                        cmd.WaitForExit();
                        lblwifi.Text = "Wifi Reset";
                        MessageBox.Show("Wifi Reset Complete.", "Wifi Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Display the output (if needed)
                        //MessageBox.Show(output);



                    }
                }
                else
                {
                    lblwifi.Text = "Wifi Reset";
                    MessageBox.Show("Process Has Been Terminated By User..", "Proceess Terminated", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblwifi.Text = "Wifi Reset";
                MessageBox.Show($"Error Reseting Wifi: {ex.Message}");
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

            try
            {
                label2.Text = "Excel Clearing Process [Working...]";
                Events events = new Events();
                events.Event = "Excel Process Terminated";
                events.EventDate = DateTime.Now;
                events.SystemId = System.Environment.MachineName;
                APIs.EventLog(events);
                int msg = (int)MessageBox.Show("This Process Will Stop Any Running Excel Instance. Do You Want To Continue?", "Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msg == 6)
                {

                    foreach (Process clsProcess in Process.GetProcesses())
                        if (clsProcess.ProcessName.Contains("EXCEL"))  //Process Excel?
                            clsProcess.Kill();
                    label2.Text = "Excel";
                    MessageBox.Show("All Excel Processes Have Been Terminated", "Excel");
                }
                else
                {
                    label2.Text = "Excel";
                    MessageBox.Show("Process Has Been Terminated By User..", "Proceess Terminated", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed To Closed Excel Instances Contact Administrator");
            }
        }


    }
}
