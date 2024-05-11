using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CIPL.AppCode;
using Newtonsoft.Json;

namespace CIPL.ChatBotControl
{
	public partial class ChatControl : UserControl
	{
		

		public ChatControl()
		{
			InitializeComponent();
			//ChatAPIs.FirstName = "Ankur";

        }
        public void AllClear()
		{
			//textBox1.Clear();
//RIk			label4.Visible = false;
//RIk            label6.Visible = true; 
			label7.Visible = false;
			textBox1.Visible = false;
			//comboBox4.Visible = false;
			btnClose.Visible = false;
			btnSubmit.Visible = false;
			button1.Visible = false;
			panel2.Visible = false;
            textBox1.DocumentText = "";
            QuestionDetailText.Text = "Type your query here...";
            textBox2.Text = "Hi " + ChatAPIs.FirstName.ToString() + ", Welcome to ONGC!  \r\n I'am \" IT Assist Bot\" intelligent virtual Assistant,How may  I help you?";
		}

        private void ChatForm_Load(object sender, EventArgs e)
		{
			label7.Visible = false;
			textBox1.Visible = false;
			btnClose.Visible = false;
			btnSubmit.Visible = false;
            QuestionDetailText.Text = "Type your query here...";
            textBox1.DocumentText = "";
            QuestionDetailText.ForeColor = Color.Silver;
            btnSubmit.Visible = false;
            questionlistBox.Visible = false;
			button1.Visible = false;
			panel2.Visible = false;
			GoQuestionDetails.Enabled = true;
			textBox2.Visible = true;
            //this.textBox2.Text = "Hi " + ChatAPIs.FirstName != null ? ChatAPIs.FirstName.ToString() : "" + ", Welcome to ONGC  🙏😊 I'm * IT support Bot*, your intelligent virtual assistant. What can I help you with today?TIP: Try typing your query directly.";
        }

        private void notSatisfied(object sender, EventArgs e)
		{
            //open RaiseTicControl
            QuestionDetailText.Text = "Type your query here...";
            textBox1.DocumentText = "";
			QuestionDetailText.Enabled = true;
			GoQuestionDetails.Enabled = true;
			Dashboard dashboard = this.ParentForm as Dashboard;
			dashboard.SetVisibleTrueRaiseTicControl();
			this.Visible = false;
		}
		private void Satisfied(object sender, EventArgs e)
		{
            QuestionDetailText.Text = "Type your query here...";
			textBox1.DocumentText = "";
			QuestionDetailText.Enabled = true;
			GoQuestionDetails.Enabled = true;
			Dashboard dashboard = this.ParentForm as Dashboard;
			dashboard.SetVisibleTrueRatingControl();
			this.Visible = false;

		}
		
		private void bindQuestion(string text)
		{
			try
			{
                //textBox2.Text = "Hi " +  ChatAPIs.FirstName.ToString() + ", Welcome to ONGC  🙏😊 I'm * IT support Bot*, your intelligent virtual assistant. What can I help you with today?TIP: Try typing your query directly.";

                if (text.Length < 3)
				{
					MessageBox.Show("Atleast Three(3) Letter Is Required For Query.");
					return;
				}
				var questionsdata = webGetMethod(ChatAPIs.Question_Url + text);
				var data = JsonConvert.DeserializeObject<dynamic>(questionsdata.ToString());
				ChatAPIs.questiondata = JsonConvert.DeserializeObject<List<QuestionData>>(data.data.ToString());
				if (ChatAPIs.questiondata.Count <= 0 || ChatAPIs.questiondata == null)
				{
					textBox1.Visible = false;
					label7.Visible = false;
					btnClose.Visible = false;
					btnSubmit.Visible = false;

					DialogResult result = MessageBox.Show("I Am Sorry And Am Unable To Help You With This Currently. I Am Still Learning And Will Note This Question For My Training. You Can Reach Out To The Helpdesk For More Help Or Log The Ticket.", "Q&A Ticket Confirmation.\r\n", MessageBoxButtons.OK);
					//if (result == DialogResult.Yes)
					//{
					//	Dashboard dashboard = this.ParentForm as Dashboard;
					//	dashboard.SetVisibleTrueRaiseTicControl();
					//	this.Visible = false;
					//}
					//else
					//{
					
					//	QuestionDetailText.Focus();
					//	return;
					//	//RIk
					//	//Dashboard dashboard = this.ParentForm as Dashboard;
					//	//dashboard.SetVisibleTrueRatingControl();
					//	//this.Visible = false;

					//}
				}
				if (ChatAPIs.questiondata != null)
				{
					foreach (var item in ChatAPIs.questiondata)
					{
                        questionlistBox.Items.Add(item.Question);
                    }
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show("IT Assit Is Not Able To Communicate From Server. Please Try After Sometime!!!", "IT Assist");

			}
		}
		private void bindAnswer(int questionId)
		{
			try
			{
				var answersdata = webGetMethod(ChatAPIs.Answer_Url + questionId +"/answers");
				var data = JsonConvert.DeserializeObject<dynamic>(answersdata.ToString());
				ChatAPIs.answerdata = JsonConvert.DeserializeObject<List<AnswerData>>(data.data.ToString());
				foreach(var anss in ChatAPIs.answerdata)
				{
//                    string ans = Regex.Replace(anss.Answer, "<.*?>", String.Empty);
                    textBox1.DocumentText= anss.Answer;

                }
                //textBox1.WordWrap = true;
				//textBox1.ScrollBars = ScrollBars.Vertical;
				textBox1.Height = 150;
                textBox1.Visible = true;
//RIk                label6.Visible = true;
//RIk                label4.Visible = true;
                label7.Visible = true;
                btnClose.Visible = true;
                btnSubmit.Visible = true;
				button1.Visible = true;
				panel2.Visible = true;
				QuestionDetailText.Enabled = false;
				GoQuestionDetails.Enabled = false;
			}
			catch (Exception ex)
			{
                MessageBox.Show("IT Assit Is Not Able To Communicate From Server. Please Try After Sometime!!!", "IT Assist");

            }
        }
		public string webGetMethod(string URL)
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
                MessageBox.Show("IT Assit Is Not Able To Communicate From Server. Please Try After Sometime!!!", "IT Assist");

            }
            return jsonString;
		}
        private void QuestionDetailText_KeyDown(object sender, KeyEventArgs e)
        {
            if (QuestionDetailText.Text == "Type your query here...")
            {
                QuestionDetailText.Text = "";
                QuestionDetailText.ForeColor = Color.Black;
                questionlistBox.Visible = false;
            }

        }
        private void QuestionDetails_MouseEnter(object sender, EventArgs e)
        {
            if (QuestionDetailText.Text == "Type your query here...")
            {
                QuestionDetailText.Text = "";
                QuestionDetailText.ForeColor = Color.Black;
                questionlistBox.Visible = false;
            }
        }
        private void QuestionDetails_MouseLeave(object sender, EventArgs e)
        {
            if (QuestionDetailText.Text == "")
            {
                QuestionDetailText.Text = "Type your query here...";
                QuestionDetailText.ForeColor = Color.Silver;
                questionlistBox.Visible = false;
            }
        }
        private void QuestionDetails_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                questionlistBox.Visible = false;
            }
        }
        private void QuestionDetailText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Back)
            {
                questionlistBox.Items.Clear();
                questionlistBox.ResetText();
                ChatAPIs.questionId = 0;
            }
            if (e.KeyData == Keys.Enter)
            {
                GoQuestionDetails_Click(sender, e);
            }
        }
        private void GoQuestionDetails_Click(object sender, EventArgs e)
        {
            var searchText = QuestionDetailText.Text;
            //textBox1.Clear();
            if (searchText.Length >= 3 && searchText != "Type your query here...")
            {
                questionlistBox.Items.Clear();
                questionlistBox.ResetText();
               
                bindQuestion(searchText);
//				QuestionDetailText.Text = "";
                questionlistBox.Visible = true;
            }
            else
            {
                questionlistBox.Items.Clear();
                questionlistBox.ResetText();
                questionlistBox.Visible = false;
				MessageBox.Show("Please Enter Atleast Three(3) Letter.");
				return;
			}
        }
        private void userlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
			try
			{
				if (questionlistBox.SelectedIndex > -1)
				{
					if (ChatAPIs.questiondata != null)
					{
						if (ChatAPIs.questiondata.Count > 0)
						{
							var data = ChatAPIs.questiondata.Find(x => x.Question.ToString() == questionlistBox.SelectedItem?.ToString());
							if (data != null)
							{
								ChatAPIs.questionId = data.Id;
								ChatAPIs.catid = data.categoryId;
								ChatAPIs.subcatid = data.subCategoryId;
								ChatAPIs.areaid = data.MfAreaId;
								bindAnswer(ChatAPIs.questionId);
							}

						}
					}

					QuestionDetailText.Text = questionlistBox.SelectedItem?.ToString();
					questionlistBox.Visible = false;
				}
            }
			catch(Exception ex)
			{
                MessageBox.Show("Some Error Occurs At Server. Please Try After Sometime!!!", "CIPL IT ASSIST");

            }

        }

		private void button1_Click(object sender, EventArgs e)
		{
			QuestionDetailText.Enabled = true;
			panel2.Visible = false;
			textBox1.Visible = false;
//RIk			label4.Visible = false;
			label7.Visible = false;
			btnClose.Visible = false;
			btnSubmit.Visible = false;
//RIk			label6.Visible = true;
			button1.Visible= false;
			questionlistBox.Visible = false;
			GoQuestionDetails.Enabled = true;
			QuestionDetailText.Text = "";
        }

        private void QuestionDetailText_TextChanged(object sender, EventArgs e)
        {

        }

        private void QuestionDetailText_Leave(object sender, EventArgs e)
        {
			//if(QuestionDetailText.Text == "")
			//{
			//	QuestionDetailText.Text = "Type your query here...";

   //         }
        }

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

	}
}
