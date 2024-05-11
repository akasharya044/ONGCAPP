using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using Microsoft.Win32;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CIPL
{
    

    [RunInstaller(true)]
    public class InstallerClass : System.Configuration.Install.Installer
    {
        public InstallerClass()
          : base()
        {
			this.BeforeInstall += new InstallEventHandler(BeforeInstallEventHandler);
			
			this.Committed += new InstallEventHandler(MyInstaller_Committed);
           
            this.Committing += new InstallEventHandler(MyInstaller_Committing);
        }
		private void BeforeInstallEventHandler(object sender, InstallEventArgs e)
		{
			try
			{
				string processName = "cipl";

				
				Process[] processes = Process.GetProcessesByName(processName);

				if (processes.Length > 0)
				{
					processes[0].Kill();
					
				}
				
				using (Process compiler = new Process())
				{
					compiler.StartInfo.FileName = "cmd.exe";
					compiler.StartInfo.Arguments = "msiexec /x {B7C0E2D2-061E-4C74-B6EE-F4A8FE3BBF3F}";
					compiler.StartInfo.UseShellExecute = false;
					compiler.StartInfo.RedirectStandardOutput = true;
					compiler.StartInfo.CreateNoWindow = true;
					compiler.Start();

					
					compiler.Close();
					//compiler.WaitForExit();
				}
				string path = "C:\\Program Files (x86)\\Corporate Infotech\\CIPL IT ASSIST";
				DirectoryInfo dir = new DirectoryInfo(path);

				if (Directory.Exists(path))
				{

					try
					{
						dir.Delete(true);
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Error deleting directory: {ex.Message}");
					}
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}
			
		}
		// Event handler for 'Committing' event.
		private void MyInstaller_Committing(object sender, InstallEventArgs e)
        {
            
        }

        // Event handler for 'Committed' event.
        private void MyInstaller_Committed(object sender, InstallEventArgs e)
        {
   
        }

       
        public override void Install(IDictionary savedState)
		{

			base.Install(savedState);
			
		}

        
        public override void Commit(IDictionary savedState)
        {
            try
            {
                //new icon remove and add , code starts here


                string desktopShortcutPath = @"C:\Users\Public\Desktop\CIPL.lnk";

                try
                {
                    if (System.IO.File.Exists(desktopShortcutPath))
                    {
                        System.IO.File.Delete(desktopShortcutPath);
                        Console.WriteLine("Shortcut deleted successfully.");
                        //MessageBox.Show("Icon Deleted Successfully");

                    }
                    else
                    {
                        Console.WriteLine("Shortcut does not exist.");
                        //MessageBox.Show("Not Able to Find Previous Icon");

                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Exception occurred In Icon Delete: " + ex.Message);
                }


                try
                {
                    string targetExePath = @"C:\Program Files (x86)\Corporate Infotech\CIPL IT Assist V2\CIPL.exe";
                    string shortcutLocation = @"C:\Users\Public\Desktop\CIPLV2.lnk";



                    var shell = new WshShell();
                    var shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
                    shortcut.TargetPath = targetExePath;
                    shortcut.IconLocation = Path.Combine(Path.GetDirectoryName(targetExePath), "ic_launcher.ico");
                    shortcut.Description = "CIPL";
                    shortcut.WorkingDirectory = Path.GetDirectoryName(targetExePath);
                    shortcut.Save();
                    //MessageBox.Show("New Icon Created");
                }
                catch(Exception ex)
                {
                    //MessageBox.Show("Exception Occured In Icon Creation"+ ex.Message.ToString());
                }

                try
                {
                    string keyPath = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Run";
                    string executablePath = @"C:\Program Files (x86)\Corporate Infotech\CIPL IT Assist V2\CIPLV2.Tickets.exe";

                    // Create or open the key
                    using (RegistryKey key = Registry.LocalMachine.CreateSubKey(keyPath , true))
                    {
                        // Set the value (e.g., path to your executable)
                        key.SetValue("CIPL", executablePath);
                    }
                    

                }
                catch(Exception ex)
                {
                    
                }

                try
                {
                    string targetExePath = @"C:\Program Files (x86)\Corporate Infotech\CIPL IT Assist V2\CIPLV2.Tickets.exe";

                    string shortcutLocation = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp\Ticket.lnk";



                    var shell = new WshShell();
                    var shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
                    shortcut.TargetPath = targetExePath;
                    shortcut.IconLocation = Path.Combine(Path.GetDirectoryName(targetExePath), "ic_launcher.ico");
                    shortcut.Description = "CIPL Ticket";
                    shortcut.WorkingDirectory = Path.GetDirectoryName(targetExePath);
                    shortcut.Save();

                }
                catch(Exception ex)
                {

                }

                try
                {
                    Directory.SetCurrentDirectory(Path.GetDirectoryName
                    (Assembly.GetExecutingAssembly().Location));
                    Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\CIPLV2.Tickets.exe");
                    //MessageBox.Show("Ticket.exe Started");
                }
                catch(Exception ex)
                {
                    //MessageBox.Show("Exception Occured In Ticket StartUp" +ex.Message.ToString());
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Exception Error In Whole Commit Process :" + ex.Message.ToString());
            }

            base.Commit(savedState);
        }

       














        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }

















        public override void Uninstall(IDictionary savedState)
        {

            string desktopShortcutPath1 = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp\Ticket.lnk";

            try
            {
                if (System.IO.File.Exists(desktopShortcutPath1))
                {
                    System.IO.File.Delete(desktopShortcutPath1);
                    Console.WriteLine("Shortcut deleted successfully.");
                    //MessageBox.Show("Icon Deleted Successfully");

                }
                else
                {
                    Console.WriteLine("Shortcut does not exist.");
                    //MessageBox.Show("Not Able to Find Previous Icon");

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Exception occurred In Icon Delete: " + ex.Message);
            }

            try
            {

                string processName = "CIPLV2.Tickets";


                Process[] processes = Process.GetProcessesByName(processName);

                if (processes.Length > 0)
                {
                    processes[0].Kill();

                }
            }
            catch (Exception ex)
            {
            }

            try
            {


                string keyPath = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Run";
                string executableKeyName = "CIPL";

                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath, true))
                {
                    if (key != null)
                    {
                        // Check if the value exists and delete it
                        if (key.GetValue(executableKeyName) != null)
                        {
                            key.DeleteValue(executableKeyName);
                        }
                        else
                        {
                            Console.WriteLine("Value not found in registry: " + executableKeyName);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Registry key not found: " + keyPath);
                    }
                }



            }
            catch (Exception ex)
            {

            }


            string desktopShortcutPath = @"C:\Users\Public\Desktop\CIPLV2.lnk";

            try
            {
                if (System.IO.File.Exists(desktopShortcutPath))
                {
                    System.IO.File.Delete(desktopShortcutPath);
                    Console.WriteLine("Shortcut deleted successfully.");
                    //MessageBox.Show("Icon Deleted Successfully");

                }
                else
                {
                    Console.WriteLine("Shortcut does not exist.");
                    //MessageBox.Show("Not Able to Find Previous Icon");

                }
            }
            catch (Exception ex)
            {
                
            }


            

            string path = @"C:\Program Files (x86)\Corporate Infotech\CIPL IT Assist V2";
            DirectoryInfo dir = new DirectoryInfo(path);

            if (Directory.Exists(path))
            {

                try
                {
                    dir.Delete(true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting directory: {ex.Message}");
                }
            }




            base.Uninstall(savedState);
        }


    }
}
