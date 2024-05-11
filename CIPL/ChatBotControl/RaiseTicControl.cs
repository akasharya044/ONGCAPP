using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CIPL.AppCode;
using Newtonsoft.Json;


namespace CIPL.ChatBotControl
{
    public partial class RaiseTicControl : UserControl
    {
        string ticketNo;
        public RaiseTicControl()
        {
            InitializeComponent();

        }
        public void AllClear()
        {
            btnSubmit.Visible = true;
            userlistBox.Visible = false;
            devicelistBox.Visible = false;
            userlistBox.Items.Clear();
            userlistBox.ResetText();
            devicelistBox.Items.Clear();
            devicelistBox.ResetText();
            userlistBox.SelectedIndex = -1;
            devicelistBox.SelectedIndex = -1;
            UserDetailText.Text = "Select";
            DeviceText.Text = "Select";
            textBox1.Clear();
        }
        private void RaiseTicForm_Load(object sender, EventArgs e)
        {
            UserDetailText.Text = "Select";
            UserDetailText.ForeColor = Color.Silver;
            DeviceText.Text = "Select";
            DeviceText.ForeColor = Color.Silver;
            btnSubmit.Visible = true;
            userlistBox.Visible = false;
            devicelistBox.Visible = false;

        }

        private void CIDevice_MouseEnter(object sender, EventArgs e)
        {
            if (DeviceText.Text == "Select")
            {
                DeviceText.Text = "";
                DeviceText.ForeColor = Color.Black;
                devicelistBox.Visible = false;

            }
        }

        private void CIDevice_MouseLeave(object sender, EventArgs e)
        {
            if (DeviceText.Text == "")
            {
                DeviceText.Text = "Select";
                DeviceText.ForeColor = Color.Silver;
                devicelistBox.Visible = false;

            }
        }
        private void CIDevice_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                devicelistBox.Visible = false;
            }
        }
        private void UserDetails_MouseEnter(object sender, EventArgs e)
        {
            if (UserDetailText.Text == "Select")
            {
                UserDetailText.Text = "";
                UserDetailText.ForeColor = Color.Black;
                userlistBox.Visible = false;
            }
        }
        private void UserDetails_MouseLeave(object sender, EventArgs e)
        {
            if (UserDetailText.Text == "")
            {
                UserDetailText.Text = "Select";
                UserDetailText.ForeColor = Color.Silver;
                userlistBox.Visible = false;
            }
        }
        private void UserDetails_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                userlistBox.Visible = false;
            }
        }
        private void SubmitTic_Click(object sender, EventArgs e)
        {
            RaiseTicketPostMethod();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private async void bindCIDevice(string name)
        {
            try
            {
                string url = ChatAPIs.CIDevice_GetUrl + name;
                var cidevicedata = webGetMethod(url);
                ChatAPIs.deviceDetails = JsonConvert.DeserializeObject<DeviceRoot>(cidevicedata.ToString());
                if (ChatAPIs.deviceDetails != null)
                {
                    if (ChatAPIs.deviceDetails.data.Count == 0)
                    {
                        devicelistBox.Visible = false;
                    }
                    foreach (var item in ChatAPIs.deviceDetails.data)
                    {
                        devicelistBox.Items.Add(item.properties.DisplayLabel);
                    }
                }
            }
            catch (Exception ex)
            {
                devicelistBox.Visible = false;
                MessageBox.Show("Some Error Occurs At Server. Please Try After Sometime!!!", " ");
            }
        }

        private async void bindUserData(string name)
        {
            try
            {
                string url = ChatAPIs.PersonDetail_GetUrl + name;
                var cidevicedata = webGetMethod(url);
                ChatAPIs.personDetails = JsonConvert.DeserializeObject<PersonRoot>(cidevicedata.ToString());
                if (ChatAPIs.personDetails != null)
                {
                    if (ChatAPIs.personDetails.data.Count == 0)
                    {
                        userlistBox.Visible = false;
                    }
                    foreach (var item in ChatAPIs.personDetails.data)
                    {

                        userlistBox.Items.Add(item.properties.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                userlistBox.Visible = false;
                MessageBox.Show("Some Error Occurs At Server (name). Please Try After Sometime!!!", "");

            }
        }

        public async Task RaiseTicketPostMethod()
        {

            using (HttpClient httpClient = new HttpClient())
            {

                try
                {
                    if (ChatAPIs.personDetailsId == "" || ChatAPIs.personDetailsId == null)
                    {
                        MessageBox.Show("Please Enter Domain ID / Name");
                        return;
                    }
                    if (ChatAPIs.deviceId == 0 || ChatAPIs.deviceId == null)
                    {
                        MessageBox.Show("Please Enter Affected HostName ID");
                        return;
                    }
                    if (textBox1.Text == null || textBox1.Text == "")
                    {
                        MessageBox.Show("Description Is Mandatory");
                        return;
                    }
                    if (ChatAPIs.catid == 0 || ChatAPIs.catid == null)
                    {
                        MessageBox.Show("Invalid Category");
                        return;
                    }
                    if (ChatAPIs.subcatid == 0 || ChatAPIs.subcatid == null)
                    {
                        MessageBox.Show("Invalid SubCategory");
                        return;
                    }


                    RaiseMFTicketDTO ticketDTO = new RaiseMFTicketDTO();

                    ticketDTO.entities = new List<MFEntity>();
                    MFEntity entity = new MFEntity();
                    entity.entity_type = "Incident";

                    ticketDTO.entities.Add(entity);
                    ticketDTO.operation = "CREATE";

                    foreach (var item in ticketDTO.entities)
                    {
                        item.properties = new MFProperty();
                        item.properties.Priority = "CriticalPriority";
                        item.properties.ContactPerson = ChatAPIs.personDetailsId;// ChatAPIs.MfuserId.ToString();
                        item.properties.RequestedByPerson = "3078782";
                        item.properties.ONGCCAT_c = ChatAPIs.catid.ToString();
                        item.properties.ONGCSUB_c = ChatAPIs.subcatid.ToString();
                        //item.properties.DisplayLabel = System.Environment.MachineName; //By the device
                        item.properties.DisplayLabel = textBox1.Text;
                        item.properties.SystemId = devicelistBox.Text;//Device need to be repaire
                        item.properties.Description = textBox1.Text;
                        item.properties.RegisteredForActualService = "82398"; //Consultation required
                        item.properties.ServiceDeskGroup = "31448"; //Consultation required
                        item.properties.ONGCAREA_c = ChatAPIs.areaid.ToString();
                        item.properties.RegisteredForDevice_c = ChatAPIs.deviceId;
                    }
                    string jsondata = JsonConvert.SerializeObject(ticketDTO);
                    var content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(ChatAPIs.ticketgenerate, content);
                    if (response.IsSuccessStatusCode)
                    {

                        string responseBody = await response.Content.ReadAsStringAsync();
                        var responseModel = JsonConvert.DeserializeObject<Response>(responseBody.ToString());
                        if (responseModel.Data != null)
                        {
                            ticketNo = responseModel.Data.ToString();
                        }
                        MessageBox.Show("Incident Ticket Number " + ticketNo + " Has Been Successfully Generated For Your Issue", "CIPL Ticket Generator");
                        userlistBox.Items.Clear();
                        userlistBox.ResetText();
                        userlistBox.SelectedIndex = -1;
                        devicelistBox.Items.Clear();
                        devicelistBox.ResetText();
                        devicelistBox.SelectedIndex = -1;
                        UserDetailText.Clear();
                        DeviceText.Clear();
                        textBox1.Clear();
                        btnSubmit.Visible = true;
                        Dashboard dashboard = this.ParentForm as Dashboard;
                        dashboard.SetVisibleTrueChatControl();
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Ticket Generation Failed.", "CIPL Ticket Generator");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some Error Occurs At Server.(Ticket) Please Try After Sometime!!!", "");
                }

            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void userlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChatAPIs.personDetails != null)
                {
                    if (ChatAPIs.personDetails.data.Count > 0)
                    {
                        if (userlistBox.SelectedItems != null)
                        {
                            var data = ChatAPIs.personDetails.data.Find(x => x.properties.Name.ToString() == userlistBox.SelectedItem.ToString());
                            if (data != null)
                            {
                                ChatAPIs.personDetailsId = data.properties.MfpersonId;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Select Domain Id");
                        }

                    }
                }
                UserDetailText.Text = userlistBox.SelectedItem.ToString();
                userlistBox.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some Error Occurs At Server. Please Try After Sometime!!!", " ");
            }


        }
        private void DevicelistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChatAPIs.deviceDetails != null)
                {
                    if (ChatAPIs.deviceDetails.data.Count > 0)
                    {
                        if (devicelistBox.SelectedItems != null)
                        {
                            var data = ChatAPIs.deviceDetails.data.Find(x => x.properties.DisplayLabel.ToString() == devicelistBox.SelectedItem.ToString());
                            if (data != null)
                            {
                                ChatAPIs.deviceId = Convert.ToInt32(data.properties.MfDeviceId);
                            }
                        }
                    }
                }
                DeviceText.Text = devicelistBox.SelectedItem.ToString();
                devicelistBox.Visible = false;
                btnSubmit.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some Error Occurs At Server. Please Try After Sometime!!!", " ");

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = this.ParentForm as Dashboard;
            dashboard.SetVisibleTrueChatControl();
            this.Visible = false;

        }

        private void UserDetailText_KeyDown(object sender, KeyEventArgs e)
        {
            if (UserDetailText.Text == "Select")
            {
                UserDetailText.Text = "";
                UserDetailText.ForeColor = Color.Black;
                userlistBox.Visible = false;
            }

        }

        private void DeviceText_KeyDown(object sender, KeyEventArgs e)
        {
            if (DeviceText.Text == "Select")
            {
                DeviceText.Text = "";
                DeviceText.ForeColor = Color.Black;
                devicelistBox.Visible = false;

            }
        }

        private void UserDetailText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Back)
            {
                userlistBox.Items.Clear();
                userlistBox.ResetText();
                ChatAPIs.personDetailsId = "";
            }
            if (e.KeyData == Keys.Enter)
            {
                GoUserDetails_Click(sender, e);
            }
        }

        private void DeviceText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Back)
            {
                devicelistBox.Items.Clear();
                devicelistBox.ResetText();
                ChatAPIs.deviceId = 0;
            }
            if (e.KeyData == Keys.Enter)
            {
                GoCIDevice_Click(sender, e);
            }
        }

        public static string webGetMethod(string URL)
        {
            string jsonString = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "GET";
                request.Credentials = CredentialCache.DefaultCredentials;
                ((HttpWebRequest)request).UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 7.1; Trident/5.0)";
                request.Accept = "/";
                request.UseDefaultCredentials = true;
                request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                request.ContentType = "application/x-www-form-urlencoded";

                WebResponse response = request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                jsonString = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some Error Occurs At Server. Please Try After Sometime!!!", " ");

            }
            return jsonString;
        }

        private void GoUserDetails_Click(object sender, EventArgs e)
        {
            var searchText = UserDetailText.Text;
            if (searchText.Length >= 3 && searchText != "Select")
            {
                userlistBox.Items.Clear();
                userlistBox.ResetText();
                bindUserData(searchText);
                userlistBox.Visible = true;
            }
            else
            {
                userlistBox.Items.Clear();
                userlistBox.ResetText();
                userlistBox.Visible = false;
            }
        }

        private void GoCIDevice_Click(object sender, EventArgs e)
        {
            var searchText2 = DeviceText.Text;
            if (searchText2.Length >= 3 && searchText2 != "Select")
            {
                devicelistBox.Items.Clear();
                devicelistBox.ResetText();
                bindCIDevice(searchText2);
                devicelistBox.Visible = true;

            }
            else
            {
                devicelistBox.Items.Clear();
                devicelistBox.ResetText();
                devicelistBox.Visible = false;
            }
        }

        private void UserDetailText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
