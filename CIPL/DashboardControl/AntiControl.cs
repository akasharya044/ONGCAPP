using System.Diagnostics;
using System.IO;
using System;
using System.Management;
using System.Windows.Forms;
using System.Text;
using Microsoft.Win32;
using System.Reflection.Emit;
using System.Security.Principal;
using CIPL.AppCode;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Drawing;

namespace CIPL.DashboardControl
{
    public partial class AntiControl : UserControl
    {
        List<string> antipro = new List<string>();
        public AntiControl()
        {
            InitializeComponent();
        }

        private void Antivirus_Load(object sender, EventArgs e)
        {
            label1_Click(sender,e);

        }
        private void label1_Click(object sender, EventArgs e)
        {

            try
            {
                Events events = new Events();
                events.Event = "Antivirus Info Fetched";
                events.EventDate = DateTime.Now;
                events.SystemId = System.Environment.MachineName;
                APIs.EventLog(events);

                //MessageBox.Show("We are fetching Information. Please Wait...","Antivirus Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                // PowerShell command to get antivirus information using WSC API
                string powershellCommand = @"
                $antivirusInfo = Get-WmiObject -Namespace 'Root/SecurityCenter2' -Class AntiVirusProduct

                if ($antivirusInfo) {
                    $antivirusProduct = $antivirusInfo.displayName
                    $antivirusStatus = $antivirusInfo.productState

                    [PSCustomObject]@{
                        AntivirusProduct = $antivirusProduct
                        AntivirusStatus = $antivirusStatus
                    } | ConvertTo-Json
                } else {
                    Write-Host 'No antivirus product found.'
                }
                ";

                var startInfo = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{powershellCommand}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };

				using (Process process = new Process() { StartInfo = startInfo })
				{
					process.Start();
					string output = process.StandardOutput.ReadToEnd();
					process.WaitForExit();
                    try
                    {
                        AntivirusData antivirusData = JsonConvert.DeserializeObject<AntivirusData>(output);

                        AVList.ReadOnly = true;
                        AVList.Text = "";
                        AVList.SelectionFont = new Font(AVList.Font.FontFamily, 10, FontStyle.Bold);
                        //AVList.AppendText("Antivirus Products\n");
                        //AVList.AppendText(Environment.NewLine);
                        //AVList.SelectionIndent = 0;

                        //AVList.SelectionFont = new Font(AVList.Font, FontStyle.Regular);
                        HashSet<string> uniqueProducts = new HashSet<string>();

                        for (int i = 0; i < antivirusData.AntivirusProduct.Length; i++)
                        {
                            uniqueProducts.Add(antivirusData.AntivirusProduct[i]);
                        }

                        int baseFontSize = 10;
                        int productNumber = 1;
                        AVList.AppendText(uniqueProducts.Count + " " + "Antivirus Products Found\n");
                        AVList.AppendText(Environment.NewLine);
                        AVList.SelectionIndent = 0;

                        AVList.SelectionFont = new Font(AVList.Font, FontStyle.Regular);

                        foreach (string product in uniqueProducts)
                        {
                            Font productFont = new Font(AVList.Font.FontFamily, baseFontSize, FontStyle.Regular);
                            AVList.SelectionFont = productFont;

                            AVList.AppendText($"{productNumber}. {product}{Environment.NewLine}");
                            productNumber++;
                        }
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            AntivirusSingleData antivirusData = JsonConvert.DeserializeObject<AntivirusSingleData>(output);

                            AVList.ReadOnly = true;
                            AVList.Text = "";
                            AVList.SelectionFont = new Font(AVList.Font.FontFamily, 10, FontStyle.Bold);
                            int baseFontSize = 10;
                            AVList.AppendText("There are One Antivirus Products Found\n");
                            AVList.AppendText(Environment.NewLine);
                            AVList.SelectionIndent = 0;

                            AVList.SelectionFont = new Font(AVList.Font, FontStyle.Regular);
                            Font productFont = new Font(AVList.Font.FontFamily, baseFontSize, FontStyle.Regular);
                            AVList.SelectionFont = productFont;

                            AVList.AppendText($"{antivirusData.AntivirusProduct} with status {antivirusData.AntivirusStatus} {Environment.NewLine}");
                        }
                        catch(Exception)
                        {
                            CheckSoftwareInstallAntiVirus();

                        }
                    }


                }
			}
            catch (Exception ex)
            {
                MessageBox.Show("Some Problem Occurred. Contact Your Administrator.");
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            label1_Click(sender, e);
        }

        private void CheckSoftwareInstallAntiVirus()
        {
            try
            {
                //Events events = new Events();
                //events.Event = "Antivirus Info Fetched";
                //events.EventDate = DateTime.Now;
                //events.SystemId = System.Environment.MachineName;
                //APIs.EventLog(events);

                var searcher = new ManagementObjectSearcher(@"root\SecurityCenter2", "SELECT * FROM AntiVirusProduct");

                var antivirusData = new List<string>();

                foreach (var result in searcher.Get())
                {
                    antivirusData.Add(result["displayName"].ToString());
                }

                AVList.ReadOnly = true;
                AVList.Text = "";
                AVList.SelectionFont = new Font(AVList.Font.FontFamily, 13, FontStyle.Bold);

                int baseFontSize = 12;
                int productNumber = 1;
                AVList.AppendText(antivirusData.Count + " Antivirus Products Found\n");
                AVList.AppendText(Environment.NewLine);
                AVList.SelectionIndent = 0;

                AVList.SelectionFont = new Font(AVList.Font, FontStyle.Regular);

                foreach (string product in antivirusData)
                {
                    Font productFont = new Font(AVList.Font.FontFamily, baseFontSize, FontStyle.Regular);
                    AVList.SelectionFont = productFont;

                    AVList.AppendText($"{productNumber}. {product}{Environment.NewLine}");
                    productNumber++;
                }
            }
            catch (Exception ex)
            {
                AVList.Text = $"Somthing wrong happen, Please consult Administrator";
            }
        }
    }
}
