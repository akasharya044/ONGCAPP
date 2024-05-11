using System;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using CIPL.AppCode;
using Newtonsoft.Json;
using System.Security.Principal;

namespace CIPL.ChatBotControl
{
    public partial class RatingControl : UserControl
    {
        string ticketNo;
        public RatingControl()
        {
            InitializeComponent();
        }
        private void RatingForm_Load(object sender, EventArgs e)
        {

        }
        private void Star_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
            if (btn.Name == "btn1")
            {
                if (btn.AccessibleName == "black")
                {
                    this.btn1.BackgroundImage = global::CIPL.Properties.Resources.y_star;
                    this.btn2.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn3.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn4.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn5.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn1.AccessibleName = "yellow";
                }
                else
                {
                    this.btn1.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn2.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn3.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn4.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn5.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn1.AccessibleName = this.btn2.AccessibleName = this.btn3.AccessibleName = this.btn4.AccessibleName = this.btn5.AccessibleName = "black";
                }
            }
            else if (btn.Name == "btn2")
            {
                if (btn.AccessibleName == "black")
                {
                    this.btn1.BackgroundImage = global::CIPL.Properties.Resources.y_star;
                    this.btn2.BackgroundImage = global::CIPL.Properties.Resources.y_star;
                    this.btn3.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn4.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn5.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn1.AccessibleName = btn2.AccessibleName = "yellow";
                }
                else
                {
                    this.btn2.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn3.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn4.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn5.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn2.AccessibleName = this.btn3.AccessibleName = this.btn4.AccessibleName = this.btn5.AccessibleName = "black";
                }
            }
            else if (btn.Name == "btn3")
            {
                if (btn.AccessibleName == "black")
                {
                    this.btn1.BackgroundImage = global::CIPL.Properties.Resources.y_star;
                    this.btn2.BackgroundImage = global::CIPL.Properties.Resources.y_star;
                    this.btn3.BackgroundImage = global::CIPL.Properties.Resources.y_star;
                    this.btn4.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn5.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn1.AccessibleName = this.btn2.AccessibleName = this.btn3.AccessibleName = "yellow";
                }
                else
                {
                    this.btn3.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn4.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn5.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn3.AccessibleName = this.btn4.AccessibleName = this.btn5.AccessibleName = "black";
                }
            }
            else if (btn.Name == "btn4")
            {
                if (btn.AccessibleName == "black")
                {
                    this.btn1.BackgroundImage = global::CIPL.Properties.Resources.y_star;
                    this.btn2.BackgroundImage = global::CIPL.Properties.Resources.y_star;
                    this.btn3.BackgroundImage = global::CIPL.Properties.Resources.y_star;
                    this.btn4.BackgroundImage = global::CIPL.Properties.Resources.y_star;
                    this.btn5.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn1.AccessibleName = this.btn2.AccessibleName = this.btn3.AccessibleName = this.btn4.AccessibleName = "yellow";
                }
                else
                {
                    this.btn4.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn5.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn4.AccessibleName = this.btn5.AccessibleName = "black";
                }
            }
            else
            {
                if (btn.AccessibleName == "black")
                {
                    this.btn1.BackgroundImage = global::CIPL.Properties.Resources.y_star;
                    this.btn2.BackgroundImage = global::CIPL.Properties.Resources.y_star;
                    this.btn3.BackgroundImage = global::CIPL.Properties.Resources.y_star;
                    this.btn4.BackgroundImage = global::CIPL.Properties.Resources.y_star;
                    this.btn5.BackgroundImage = global::CIPL.Properties.Resources.y_star;
                    this.btn1.AccessibleName = this.btn2.AccessibleName = this.btn3.AccessibleName = this.btn4.AccessibleName = this.btn5.AccessibleName = "yellow";
                }
                else
                {
                    this.btn5.BackgroundImage = global::CIPL.Properties.Resources.b_star;
                    this.btn5.AccessibleName = "black";
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
            int StatCount = 0;
            if (btn.Text == "Submit")
            {
                if (btn5.AccessibleName == "yellow")
                {
                    StatCount = 5;
                }
                else if (btn4.AccessibleName == "yellow")
                {
                    StatCount = 4;
                }
                else if (btn3.AccessibleName == "yellow")
                {
                    StatCount = 3;
                }
                else if (btn2.AccessibleName == "yellow")
                {
                    StatCount = 2;
                }
                else if (btn1.AccessibleName == "yellow")
                {
                    StatCount = 1;
                }
                if (StatCount == 0)
                {
                    MessageBox.Show("Please Select Rating.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                RaiseTicketPostMethod(StatCount);

            }

        }

        public async Task RaiseTicketPostMethod(int starcount)
        {
            StarRating rating = new StarRating();
            using (HttpClient httpClient = new HttpClient())
            {
                rating.ONGCCAT_c = ChatAPIs.catid;
                rating.ONGCSUB_c = ChatAPIs.subcatid;
                rating.ONGCAREA_c = ChatAPIs.areaid;
                rating.starcount = starcount;
                rating.UserName = APIs.UserName;
               
                var jsonData = JsonConvert.SerializeObject(rating);
                try
                {
                    var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(ChatAPIs.StarRating_postUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Response responseModel = JsonConvert.DeserializeObject<Response>(responseBody);
                        if (responseModel != null)
                        {
                            MessageBox.Show("ThankYou For Using ONGC IT Assist ChatBot.", "Ticket Rating");
                            Dashboard dashboard = this.ParentForm as Dashboard;
                            dashboard.SetVisibleTrueChatControl();
                            this.Visible = false;
                        }
                        ClearFeedBack();


                    }
                    else
                    {
                        MessageBox.Show("Ticket Generation Failed.", "Ticket Generator");
                        starcount = 0;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some Error occurs at server. Please try after sometime!!!", "");
                    starcount = 0; ;
                }

            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClearFeedBack();
            Dashboard dashboard = this.ParentForm as Dashboard;
            dashboard.SetVisibleTrueChatControl();
            this.Visible = false;
        }
        void ClearFeedBack()
        {
            this.btn1.BackgroundImage = global::CIPL.Properties.Resources.b_star;
            this.btn2.BackgroundImage = global::CIPL.Properties.Resources.b_star;
            this.btn3.BackgroundImage = global::CIPL.Properties.Resources.b_star;
            this.btn4.BackgroundImage = global::CIPL.Properties.Resources.b_star;
            this.btn5.BackgroundImage = global::CIPL.Properties.Resources.b_star;
            this.btn1.AccessibleName = this.btn2.AccessibleName = this.btn3.AccessibleName = this.btn4.AccessibleName = this.btn5.AccessibleName = "black";
        }
    }
}
