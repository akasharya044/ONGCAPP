using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using CIPL.AppCode;

namespace CIPL.DashboardControl
{
	public partial class ChromeControl : UserControl
	{
		string[] profiles = new string[]
		{
			"Default",
			"Guest Profile",
			"Profile 1",
			"Profile 2",
			"Profile 3",
			"Profile 4",
			"Profile 5",
			"Profile 6",
			"Profile 7",
			"Profile 8",
			"Profile 9",
			"Profile 10",

		};

		public ChromeControl()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SelfHeal selfcontrol = new SelfHeal();
			selfcontrol.Visible = true;
			this.Visible = false;
		}
        private string[] GetUsersDirectory()
        {
            string[] directories = Directory.GetDirectories("C:\\Users");
            return directories;

        }
        private int KillRunningChrome()
		{
			int msg = (int)MessageBox.Show("This Process Will Stop Any Running Chrome Instance. Do You Want To Continue?","Cleaner",MessageBoxButtons.YesNo);
			if(msg == 6)
			{
				Process[] Path1 = Process.GetProcessesByName("chrome");
				foreach (Process p in Path1)
				{
					try
					{
						p.Kill();
					}
					catch { }
					p.WaitForExit();
					p.Dispose();
				}
            }
			label2.Text = "Clear History";
			label3.Text = "Clear Cache";
			label4.Text = "Clear Cookies";
			label5.Text = "All Clear";
			label6.Text = "Clear BookMark";

			return msg;
        }
		static bool IsValidPath(string path)
		{
			try
			{
				Path.GetFullPath(path);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		private void ClearHistory(string UserName)
		{
			label2.Text = "Clear History [Working...]";
            string rootDrive = Path.GetPathRoot(Environment.SystemDirectory); // for getting primary drive 
			string userName = UserName;// Environment.UserName; // for getting user name
            try
            {
                string path1 = userName + "\\AppData\\Local\\Google\\Chrome\\User Data\\";
				string path2 = userName + "\\AppData\\Roaming\\Google\\Chrome\\User Data\\";
				string path3 = rootDrive + "Users\\admin\\AppData\\Local\\Google\\Chrome\\User Data\\";
                try
                {
                    foreach (string profile in profiles)
                    {
                        string profilePath1 = Path.Combine(path1, profile);
                        string profilePath2 = Path.Combine(path2, profile);
                        string profilePath3 = Path.Combine(path3, profile);

                        if (IsValidPath(profilePath1))
                        {
                            DirectoryInfo downloadedMessageInfo = new DirectoryInfo(profilePath1);
                            if (downloadedMessageInfo.Exists)
                            {
                                foreach (FileInfo file in downloadedMessageInfo.GetFiles())
                                {
                                    if (file.Name.Contains("History"))
                                        file.Delete();
                                }
                                foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
                                {
                                    if (dir.Name.Contains("History"))
                                        dir.Delete(true);
                                }
                            }
                        }
                        if (IsValidPath(profilePath2))
                        {
                            DirectoryInfo RomingInfo = new DirectoryInfo(profilePath2);
                            if (RomingInfo.Exists)
                            {
                                foreach (FileInfo file in RomingInfo.GetFiles())
                                {
                                    if (file.Name.Contains("History"))
                                        file.Delete();
                                }
                                foreach (DirectoryInfo dir in RomingInfo.GetDirectories())
                                {
                                    if (dir.Name.Contains("History"))
                                        dir.Delete(true);
                                }
                            }
                        }
                        if (IsValidPath(profilePath3))
                        {
                            DirectoryInfo adminInfo = new DirectoryInfo(profilePath3);
                            if (adminInfo.Exists)
                            {
                                foreach (FileInfo file in adminInfo.GetFiles())
                                {
                                    if (file.Name.Contains("History"))
                                        file.Delete();
                                }
                                foreach (DirectoryInfo dir in adminInfo.GetDirectories())
                                {
                                    if (dir.Name.Contains("History"))
                                        dir.Delete(true);
                                }
                            }
                        }
                    }

					label2.Text = "Clear History";
				}
                catch(IOException ex)
                {
					MessageBox.Show("History is not clear.");
					label2.Text = "Clear History";
					return;
				}
			}
            catch (IOException ex)
            {
				MessageBox.Show("History is not clear.");
				return;
			}
		}
        private void ClearHistory_Click(object sender, System.EventArgs e)
		{
			try
			{
				label2.Text = "Clear History[Working...]";

				Events events = new Events();
                events.Event = "Clear History";
                events.EventDate = DateTime.Now;
                events.SystemId = System.Environment.MachineName;
                APIs.EventLog(events);

                if (KillRunningChrome() == 7)
					return;
				// for Google Chrome.
				string[] directories = GetUsersDirectory();
				for (int i = 0; i < directories.Length; i++)
				{
					ClearHistory(directories[i]);
				}
				label2.Text = "Clear History";
				MessageBox.Show("History Deleted Successfully.");
			}
			catch(Exception ex)
			{
				label2.Text = "Clear History";
				MessageBox.Show("History is not clear.");
				return;

			}

		}
		private void ClearCache(string UserName)
		{
            string rootDrive = Path.GetPathRoot(Environment.SystemDirectory); // for getting primary drive 
			string userName = UserName;//Environment.UserName; // for getting user name

            try
            {
				string path1 = userName + "\\AppData\\Local\\Google\\Chrome\\User Data";
				string path2 = userName + "\\AppData\\Roaming\\Google\\Chrome\\User Data";
				string path3 = rootDrive + "Users\\admin\\AppData\\Local\\Google\\Chrome\\User Data";
				try
				{
					foreach (string profile in profiles)
					{
						string profilePath1 = Path.Combine(path1, profile);
						string profilePath2 = Path.Combine(path2, profile);
						string profilePath3 = Path.Combine(path3, profile);

						if (IsValidPath(profilePath1))
						{
							DirectoryInfo downloadedMessageInfo = new DirectoryInfo(profilePath1);
							if (downloadedMessageInfo.Exists)
							{
								foreach (FileInfo file in downloadedMessageInfo.GetFiles())
								{
									if (file.Name.Contains("Cache"))
										file.Delete();
								}
								foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
								{
									if (dir.Name.Contains("Cache"))
										dir.Delete(true);
								}
							}
						}
						if (IsValidPath(profilePath2))
						{
							DirectoryInfo RomingInfo = new DirectoryInfo(profilePath2);
							if (RomingInfo.Exists)
							{
								foreach (FileInfo file in RomingInfo.GetFiles())
								{
									if (file.Name.Contains("Cache"))
										file.Delete();
								}
								foreach (DirectoryInfo dir in RomingInfo.GetDirectories())
								{
									if (dir.Name.Contains("Cache"))
										dir.Delete(true);
								}
							}
						}
						if (IsValidPath(profilePath3))
						{
							DirectoryInfo adminInfo = new DirectoryInfo(profilePath3);
							if (adminInfo.Exists)
							{
								foreach (FileInfo file in adminInfo.GetFiles())
								{
									if (file.Name.Contains("Cache"))
										file.Delete();
								}
								foreach (DirectoryInfo dir in adminInfo.GetDirectories())
								{
									if (dir.Name.Contains("Cache"))
										dir.Delete(true);
								}
							}
						}
					}
				}
				catch (IOException ex)
				{
					MessageBox.Show("Cache is not clear.");
					return;
				}
            }
            catch (IOException ex)
            {
				MessageBox.Show("Cache is not clear.");
			}

		}
        private void ClearCache_Click(object sender, System.EventArgs e)
		{
			try
			{
				label3.Text = "Clear Cache[Working...]";
				Events events = new Events();
                events.Event = "Clear Cache";
                events.EventDate = DateTime.Now;
                events.SystemId = System.Environment.MachineName;
                APIs.EventLog(events);
                if (KillRunningChrome() == 7)
					return;

				string[] directories = GetUsersDirectory();
				for (int i = 0; i < directories.Length; i++)
				{
					ClearCache(directories[i]);
				}
				label3.Text = "Clear Cache";
				MessageBox.Show("Cache Deleted Successfully.");
			}
			catch(Exception ex)
			{
				label3.Text = "Clear Cache";
				MessageBox.Show("Cache is not clear.");
			}


		}
		private void ClearCookies(string UserName)
		{
            string rootDrive = Path.GetPathRoot(Environment.SystemDirectory); // for getting primary drive 
            string userName = UserName;// UserName; // Environment.UserName; // for getting user name
            try
            {
                string path1 = userName + "\\AppData\\Local\\Google\\Chrome\\User Data\\";
                string path2 = userName + "\\AppData\\Roaming\\Google\\Chrome\\User Data\\";
                string path3 = rootDrive + "Users\\admin\\AppData\\Local\\Google\\Chrome\\User Data\\";

				try
				{
					foreach (string profile in profiles)
					{
						string profilePath1 = Path.Combine(path1, profile);
						string profilePath2 = Path.Combine(path2, profile);
						string profilePath3 = Path.Combine(path3, profile);

						if (IsValidPath(profilePath1))
						{
							DirectoryInfo downloadedMessageInfo = new DirectoryInfo(profilePath1);
							if (downloadedMessageInfo.Exists)
							{
								foreach (FileInfo file in downloadedMessageInfo.GetFiles())
								{
									if (file.Name.Contains("Network") || file.Name.Contains("Session") || file.Name.Contains("Extensions"))
										file.Delete();
								}
								foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
								{
									if (dir.Name.Contains("Network") || dir.Name.Contains("Session") || dir.Name.Contains("Extensions"))
										dir.Delete(true);
								}
							}
						}
						if (IsValidPath(profilePath2))
						{
							DirectoryInfo RomingInfo = new DirectoryInfo(profilePath2);
							if (RomingInfo.Exists)
							{
								foreach (FileInfo file in RomingInfo.GetFiles())
								{
									if (file.Name.Contains("Network") || file.Name.Contains("Session") || file.Name.Contains("Extensions"))
										file.Delete();
								}
								foreach (DirectoryInfo dir in RomingInfo.GetDirectories())
								{
									if (dir.Name.Contains("Network") || dir.Name.Contains("Session") || dir.Name.Contains("Extensions"))
										dir.Delete(true);
								}
							}
						}
						if (IsValidPath(profilePath3))
						{
							DirectoryInfo adminInfo = new DirectoryInfo(profilePath3);
							if (adminInfo.Exists)
							{
								foreach (FileInfo file in adminInfo.GetFiles())
								{
									if (file.Name.Contains("Network") || file.Name.Contains("Session") || file.Name.Contains("Extensions"))
										file.Delete();
								}
								foreach (DirectoryInfo dir in adminInfo.GetDirectories())
								{
									if (dir.Name.Contains("Network") || dir.Name.Contains("Session") || dir.Name.Contains("Extensions"))
										dir.Delete(true);
								}
							}
						}
					}
				}
				catch (IOException ex)
				{
					MessageBox.Show("Cookies is not clear.");
					return;
				}
            }
            catch (IOException ex)
            {
				MessageBox.Show("Cookies is not clear.");
			}
		}
        private void ClearCookies_Click(object sender, System.EventArgs e)
		{
			try
			{
				label4.Text = "Clear Cookies[Working...]";

				Events events = new Events();
                events.Event = "Clear Cookies";
                events.EventDate = DateTime.Now;
                events.SystemId = System.Environment.MachineName;
                APIs.EventLog(events);
                if (KillRunningChrome() == 7)
					return;

				string[] directories = GetUsersDirectory();
				for (int i = 0; i < directories.Length; i++)
				{
					ClearCookies(directories[i]);
				}
				label4.Text = "Clear Cookies";
				MessageBox.Show("Cookies Deleted Successfully.");
			}
			catch (Exception ex)
			{
				label3.Text = "Clear Cookies";
				MessageBox.Show("Cookies is not clear.");
				return;
			}
			

		}
		private void ClearBookMark(string UserName)
        {
            string rootDrive = Path.GetPathRoot(Environment.SystemDirectory); // for getting primary drive 
            string userName = UserName;// Environment.UserName; // for getting user name
            try
            {

                string path1 = userName + "\\AppData\\Local\\Google\\Chrome\\User Data\\";
                string path2 = userName + "\\AppData\\Roaming\\Google\\Chrome\\User Data\\";
                string path3 = rootDrive + "Users\\admin\\AppData\\Local\\Google\\Chrome\\User Data\\";
				try
				{
					foreach (string profile in profiles)
					{
						string profilePath1 = Path.Combine(path1, profile);
						string profilePath2 = Path.Combine(path2, profile);
						string profilePath3 = Path.Combine(path3, profile);

						if (IsValidPath(profilePath1))
						{
							DirectoryInfo downloadedMessageInfo = new DirectoryInfo(profilePath1);
							if (downloadedMessageInfo.Exists)
							{
								foreach (FileInfo file in downloadedMessageInfo.GetFiles())
								{
									if (file.Name.Contains("Bookmarks"))
										file.Delete();
								}
								foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
								{
									if (dir.Name.Contains("Bookmarks"))
										dir.Delete(true);
								}
							}
						}
						if (IsValidPath(profilePath2))
						{
							DirectoryInfo RomingInfo = new DirectoryInfo(profilePath2);
							if (RomingInfo.Exists)
							{
								foreach (FileInfo file in RomingInfo.GetFiles())
								{
									if (file.Name.Contains("Bookmarks"))
										file.Delete();
								}
								foreach (DirectoryInfo dir in RomingInfo.GetDirectories())
								{
									if (dir.Name.Contains("Bookmarks"))
										dir.Delete(true);
								}
							}
						}
						if (IsValidPath(profilePath3))
						{
							DirectoryInfo adminInfo = new DirectoryInfo(profilePath3);
							if (adminInfo.Exists)
							{
								foreach (FileInfo file in adminInfo.GetFiles())
								{
									if (file.Name.Contains("Bookmarks"))
										file.Delete();
								}
								foreach (DirectoryInfo dir in adminInfo.GetDirectories())
								{
									if (dir.Name.Contains("Bookmarks"))
										dir.Delete(true);
								}
							}
						}
					}
				}
				catch (IOException ex)
				{
					MessageBox.Show("BookMark is not clear.");
					return;
				}
            }
            catch (IOException ex)
            {
				MessageBox.Show("BookMark is not clear.");
			}

		}
        private void ClearBookMark_Click(object sender, System.EventArgs e)
        {
			try
			{
				label6.Text = "Clear BookMark[Working...]";
				Events events = new Events();
                events.Event = "Clear BookMark";
                events.EventDate = DateTime.Now;
                events.SystemId = System.Environment.MachineName;
                APIs.EventLog(events);
                if (KillRunningChrome() == 7)
					return;
				string[] directories = GetUsersDirectory();
				for (int i = 0; i < directories.Length; i++)
				{
					ClearBookMark(directories[i]);
				}
				label6.Text = "Clear BookMark";
				MessageBox.Show("BookMark Deleted Successfully.");
			}
			catch (Exception ex)
			{
				label6.Text = "Clear BookMark";
				MessageBox.Show("BookMark is not clear.");
				return;
			}
		}
		private void AllClear(string UserName)
        {
            string rootDrive = Path.GetPathRoot(Environment.SystemDirectory); // for getting primary drive 
            string userName = UserName;// Environment.UserName; // for getting user name
            try
            {
				string path1 = userName + "\\AppData\\Local\\Google\\Chrome\\User Data";
				string path2 = userName + "\\AppData\\Roaming\\Google\\Chrome\\User Data";
				string path3 = rootDrive + "Users\\admin\\AppData\\Local\\Google\\Chrome\\User Data\\";
				try
				{
					foreach (string profile in profiles)
					{
						string profilePath1 = Path.Combine(path1, profile);
						string profilePath2 = Path.Combine(path2, profile);
						string profilePath3 = Path.Combine(path3, profile);

						if (IsValidPath(profilePath1))
						{
							DirectoryInfo downloadedMessageInfo = new DirectoryInfo(profilePath1);
							if (downloadedMessageInfo.Exists)
							{
								foreach (FileInfo file in downloadedMessageInfo.GetFiles())
								{
										file.Delete();
								}
								foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
								{
										dir.Delete(true);
								}
							}
						}
						if (IsValidPath(profilePath2))
						{
							DirectoryInfo RomingInfo = new DirectoryInfo(profilePath2);
							if (RomingInfo.Exists)
							{
								foreach (FileInfo file in RomingInfo.GetFiles())
								{
										file.Delete();
								}
								foreach (DirectoryInfo dir in RomingInfo.GetDirectories())
								{
										dir.Delete(true);
								}
							}
						}
						if (IsValidPath(profilePath3))
						{
							DirectoryInfo adminInfo = new DirectoryInfo(profilePath3);
							if (adminInfo.Exists)
							{
								foreach (FileInfo file in adminInfo.GetFiles())
								{
										file.Delete();
								}
								foreach (DirectoryInfo dir in adminInfo.GetDirectories())
								{
										dir.Delete(true);
								}
							}
						}
					}
				}
				catch (IOException ex)
				{
					MessageBox.Show("All is not Clear.");
					return;
				}
            }
            catch (IOException ex)
            {
				MessageBox.Show("All is not Clear.");
			}

		}
        private void AllClear_Click(object sender, System.EventArgs e)
		{
			try
			{
				label5.Text = "All Clear [Working...]";
				Events events = new Events();
                events.Event = "Clear All";
                events.EventDate = DateTime.Now;
                events.SystemId = System.Environment.MachineName;
                APIs.EventLog(events);

                if (KillRunningChrome() == 7)
					return;

				string[] directories = GetUsersDirectory();
				for (int i = 0; i < directories.Length; i++)
				{
					AllClear(directories[i]);
				}
				label5.Text = "All Clear";
				MessageBox.Show("All Deleted Successfully.");
			}
			catch (Exception ex)
			{
				label5.Text = "All Clear ";
				MessageBox.Show("All is not Clear.");
				return;
			}
		}
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			ClearHistory_Click(sender, e);
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
