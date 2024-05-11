using CIPL.AppCode;

namespace CIPL.ChatBotControl
{
	partial class ChatControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.RichTextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.QuestionDetailText = new System.Windows.Forms.TextBox();
            this.GoQuestionDetails = new System.Windows.Forms.Button();
            this.questionlistBox = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.WebBrowser();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(819, 59);
            this.panel1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.SteelBlue;
            this.textBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(842, 58);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Hi UserName Welcome to ONGC!  I\'am  IT Assist Bot intelligent virtual Assistant,H" +
    "ow may  I help you?";
            // 
            // btnSubmit
            // 
            this.btnSubmit.AccessibleName = "submit";
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(176)))), ((int)(((byte)(19)))));
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(654, 6);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(67, 47);
            this.btnSubmit.TabIndex = 33;
            this.btnSubmit.Text = "Yes";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.Satisfied);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleName = "close";
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(728, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 47);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "NO";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.notSatisfied);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(267, 534);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(373, 25);
            this.label7.TabIndex = 35;
            this.label7.Text = "Are You Satisfied with Answer ?";
            // 
            // QuestionDetailText
            // 
            this.QuestionDetailText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionDetailText.Location = new System.Drawing.Point(0, 67);
            this.QuestionDetailText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.QuestionDetailText.MaxLength = 255;
            this.QuestionDetailText.MinimumSize = new System.Drawing.Size(4, 40);
            this.QuestionDetailText.Name = "QuestionDetailText";
            this.QuestionDetailText.Size = new System.Drawing.Size(765, 40);
            this.QuestionDetailText.TabIndex = 43;
            this.QuestionDetailText.Text = "Type your query here...";
            this.QuestionDetailText.TextChanged += new System.EventHandler(this.QuestionDetailText_TextChanged);
            this.QuestionDetailText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QuestionDetailText_KeyDown);
            this.QuestionDetailText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.QuestionDetailText_KeyUp);
            this.QuestionDetailText.Leave += new System.EventHandler(this.QuestionDetailText_Leave);
            this.QuestionDetailText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.QuestionDetails_MouseDown);
            this.QuestionDetailText.MouseEnter += new System.EventHandler(this.QuestionDetails_MouseEnter);
            this.QuestionDetailText.MouseLeave += new System.EventHandler(this.QuestionDetails_MouseLeave);
            // 
            // GoQuestionDetails
            // 
            this.GoQuestionDetails.BackColor = System.Drawing.SystemColors.Window;
            this.GoQuestionDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GoQuestionDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoQuestionDetails.FlatAppearance.BorderSize = 0;
            this.GoQuestionDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GoQuestionDetails.Image = ((System.Drawing.Image)(resources.GetObject("GoQuestionDetails.Image")));
            this.GoQuestionDetails.Location = new System.Drawing.Point(771, 68);
            this.GoQuestionDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GoQuestionDetails.Name = "GoQuestionDetails";
            this.GoQuestionDetails.Size = new System.Drawing.Size(44, 30);
            this.GoQuestionDetails.TabIndex = 49;
            this.GoQuestionDetails.UseVisualStyleBackColor = true;
            this.GoQuestionDetails.Click += new System.EventHandler(this.GoQuestionDetails_Click);
            // 
            // questionlistBox
            // 
            this.questionlistBox.BackColor = System.Drawing.Color.White;
            this.questionlistBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.questionlistBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.questionlistBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline);
            this.questionlistBox.ForeColor = System.Drawing.Color.Black;
            this.questionlistBox.FormattingEnabled = true;
            this.questionlistBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.questionlistBox.ItemHeight = 19;
            this.questionlistBox.Location = new System.Drawing.Point(0, 105);
            this.questionlistBox.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.questionlistBox.Name = "questionlistBox";
            this.questionlistBox.Size = new System.Drawing.Size(815, 399);
            this.questionlistBox.TabIndex = 50;
            this.questionlistBox.SelectedIndexChanged += new System.EventHandler(this.userlistBox_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnSubmit);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(3, 517);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(809, 58);
            this.panel2.TabIndex = 52;
            // 
            // button1
            // 
            this.button1.AccessibleName = "close";
            this.button1.BackColor = System.Drawing.Color.Blue;
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(4, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 47);
            this.button1.TabIndex = 51;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 114);
            this.textBox1.MinimumSize = new System.Drawing.Size(0, 350);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(812, 404);
            this.textBox1.TabIndex = 53;
            this.textBox1.WebBrowserShortcutsEnabled = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ChatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.Controls.Add(this.GoQuestionDetails);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.QuestionDetailText);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.questionlistBox);
            this.Controls.Add(this.textBox1);
            this.Location = new System.Drawing.Point(650, 100);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ChatControl";
            this.Size = new System.Drawing.Size(819, 588);
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSubmit;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox QuestionDetailText;
        private System.Windows.Forms.Button GoQuestionDetails;
        private System.Windows.Forms.ListBox questionlistBox;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.WebBrowser textBox1;
        private System.Windows.Forms.RichTextBox textBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
