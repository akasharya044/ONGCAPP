using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using CIPL.AppCode;
using Newtonsoft.Json;

namespace CIPL.ChatBotControl
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.DeepSkyBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.DodgerBlue;
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Enter DomainId";
            textBox2.Text = "Enter password";
        }
        private async void button1_Click_1(object sender, EventArgs e)
        {

            APIs.UserName = textBox1.Text;
            APIs.Password = textBox2.Text;

            //if (APIs.UserName == APIs.Password)
            //{
            //    ChatAPIs.FirstName = "Ankur";
            //    Dashboard dashboard = this.ParentForm as Dashboard;
            //    dashboard.SetVisibleTrueChatControl();
            //    this.Visible = false;
            //    return;
            //}

            if (string.IsNullOrWhiteSpace(APIs.UserName) || string.IsNullOrWhiteSpace(APIs.Password))
            {
                MessageBox.Show("Please Enter Your Username and Password.");
                return;
            }
            if (APIs.UserName == "Enter DomainId" || APIs.Password == "Enter password")
            {
                MessageBox.Show("Please Enter Your Username and Password.");
                return;
            }
            string requestData = "{\"login\":\"" + APIs.UserName + "\", \"password\":\"" + APIs.Password + "\"}";
            byte[] requestDataBytes = Encoding.UTF8.GetBytes(requestData);
            try
            {
                AdminUsersDto user = new AdminUsersDto();
                user.UserName = APIs.UserName;
                user.Password = APIs.Password;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(APIs.ApiUrl);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = requestDataBytes.Length;
                string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(user);

                using (var httpclient = new HttpClient())
                {
                    var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpclient.PostAsync(APIs.ApiUrl, content);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var responsedata = JsonConvert.DeserializeObject<Response>(responseBody);
                    if (responsedata.Data != null)
                    {
                        var responsedata1 = JsonConvert.DeserializeObject<AdminUsersDto>(responsedata.Data.ToString());
                        ChatAPIs.token = responsedata1.Token;
                        ChatAPIs.MfuserId = responsedata1.MfuserId;
                        ChatAPIs.Location = responsedata1.Location;
                        ChatAPIs.FirstName = responsedata1.FirstName.ToString();
                        Dashboard dashboard = this.ParentForm as Dashboard;
                        dashboard.SetVisibleTrueChatControl();
                        this.Visible = false;
                    }
                    else
                    {
                        APIs.UserName = "";
                        APIs.Password = "";
						MessageBox.Show("Invalid Username and Password");
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
				APIs.UserName = "";
				APIs.Password = "";
				MessageBox.Show("Invalid Username and Password");

            }
        }


        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter DomainId")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black; // Change text color to black when entering
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Enter DomainId";
                textBox1.ForeColor = SystemColors.GrayText; // Change text color to gray when leaving
            }
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black; // Change text color to black when entering
                textBox2.UseSystemPasswordChar = true; // Show the actual password characters
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Text = "Enter password";
                textBox2.ForeColor = SystemColors.GrayText; // Change text color to gray when leaving
                textBox2.UseSystemPasswordChar = false; // Show the placeholder characters
            }
        }
    }
}
