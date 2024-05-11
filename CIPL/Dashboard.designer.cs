using CIPL.DashboardControl;

namespace CIPL
{
	partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.sysbutton = new System.Windows.Forms.Button();
            this.softbtn = new System.Windows.Forms.Button();
            this.antibtn = new System.Windows.Forms.Button();
            this.chatbtn = new System.Windows.Forms.Button();
            this.selfbtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.ratingControl1 = new CIPL.ChatBotControl.RatingControl();
            this.loginControl1 = new CIPL.ChatBotControl.LoginControl();
            this.raiseTicControl1 = new CIPL.ChatBotControl.RaiseTicControl();
            this.chatControl1 = new CIPL.ChatBotControl.ChatControl();
            this.ticketControl = new CIPL.DashboardControl.TicketControl();
            this.systemInfo = new CIPL.DashboardControl.SystemInfo();
            this.selfHeal = new CIPL.DashboardControl.SelfHeal();
            this.antiControl = new CIPL.DashboardControl.AntiControl();
            this.chromeControl = new CIPL.DashboardControl.ChromeControl();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sysbutton
            // 
            this.sysbutton.AutoSize = true;
            this.sysbutton.BackColor = System.Drawing.Color.DarkGreen;
            this.sysbutton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.sysbutton.FlatAppearance.BorderSize = 0;
            this.sysbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.sysbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.sysbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sysbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sysbutton.ForeColor = System.Drawing.Color.Transparent;
            this.sysbutton.Image = ((System.Drawing.Image)(resources.GetObject("sysbutton.Image")));
            this.sysbutton.Location = new System.Drawing.Point(0, 0);
            this.sysbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sysbutton.Name = "sysbutton";
            this.sysbutton.Size = new System.Drawing.Size(193, 112);
            this.sysbutton.TabIndex = 0;
            this.sysbutton.Text = "System Info";
            this.sysbutton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sysbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.sysbutton.UseVisualStyleBackColor = false;
            // 
            // softbtn
            // 
            this.softbtn.AutoSize = true;
            this.softbtn.BackColor = System.Drawing.Color.DarkGreen;
            this.softbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.softbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.softbtn.FlatAppearance.BorderSize = 0;
            this.softbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.softbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.softbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.softbtn.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.softbtn.ForeColor = System.Drawing.Color.Transparent;
            this.softbtn.Image = ((System.Drawing.Image)(resources.GetObject("softbtn.Image")));
            this.softbtn.Location = new System.Drawing.Point(0, 0);
            this.softbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.softbtn.Name = "softbtn";
            this.softbtn.Size = new System.Drawing.Size(192, 126);
            this.softbtn.TabIndex = 1;
            this.softbtn.Text = "Software Info";
            this.softbtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.softbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.softbtn.UseVisualStyleBackColor = false;
            this.softbtn.Click += new System.EventHandler(this.softbtn_Click);
            // 
            // antibtn
            // 
            this.antibtn.AutoSize = true;
            this.antibtn.BackColor = System.Drawing.Color.DarkGreen;
            this.antibtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.antibtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.antibtn.FlatAppearance.BorderSize = 0;
            this.antibtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.antibtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.antibtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.antibtn.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.antibtn.ForeColor = System.Drawing.Color.Transparent;
            this.antibtn.Image = ((System.Drawing.Image)(resources.GetObject("antibtn.Image")));
            this.antibtn.Location = new System.Drawing.Point(0, 126);
            this.antibtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.antibtn.Name = "antibtn";
            this.antibtn.Size = new System.Drawing.Size(192, 161);
            this.antibtn.TabIndex = 2;
            this.antibtn.Text = "Antivirus Info";
            this.antibtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.antibtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.antibtn.UseVisualStyleBackColor = false;
            this.antibtn.Click += new System.EventHandler(this.antibtn_Click);
            // 
            // chatbtn
            // 
            this.chatbtn.AutoSize = true;
            this.chatbtn.BackColor = System.Drawing.Color.DarkGreen;
            this.chatbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.chatbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.chatbtn.FlatAppearance.BorderSize = 0;
            this.chatbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.chatbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.chatbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chatbtn.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatbtn.ForeColor = System.Drawing.Color.Transparent;
            this.chatbtn.Image = ((System.Drawing.Image)(resources.GetObject("chatbtn.Image")));
            this.chatbtn.Location = new System.Drawing.Point(0, 287);
            this.chatbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chatbtn.Name = "chatbtn";
            this.chatbtn.Size = new System.Drawing.Size(192, 155);
            this.chatbtn.TabIndex = 3;
            this.chatbtn.Text = "Chatbot";
            this.chatbtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chatbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.chatbtn.UseVisualStyleBackColor = false;
            this.chatbtn.Click += new System.EventHandler(this.chatbtn_Click);
            // 
            // selfbtn
            // 
            this.selfbtn.AutoSize = true;
            this.selfbtn.BackColor = System.Drawing.Color.DarkGreen;
            this.selfbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.selfbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.selfbtn.FlatAppearance.BorderSize = 0;
            this.selfbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.selfbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.selfbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selfbtn.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selfbtn.ForeColor = System.Drawing.Color.Transparent;
            this.selfbtn.Image = ((System.Drawing.Image)(resources.GetObject("selfbtn.Image")));
            this.selfbtn.Location = new System.Drawing.Point(0, 442);
            this.selfbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selfbtn.Name = "selfbtn";
            this.selfbtn.Size = new System.Drawing.Size(192, 144);
            this.selfbtn.TabIndex = 4;
            this.selfbtn.Text = "Self-Heal";
            this.selfbtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.selfbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.selfbtn.UseVisualStyleBackColor = false;
            this.selfbtn.Click += new System.EventHandler(this.selfbtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MintCream;
            this.panel2.Controls.Add(this.selfbtn);
            this.panel2.Controls.Add(this.chatbtn);
            this.panel2.Controls.Add(this.antibtn);
            this.panel2.Controls.Add(this.softbtn);
            this.panel2.Controls.Add(this.sysbutton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 586);
            this.panel2.TabIndex = 3;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Subject";
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ratingControl1);
            this.panel1.Controls.Add(this.loginControl1);
            this.panel1.Controls.Add(this.raiseTicControl1);
            this.panel1.Controls.Add(this.chatControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(192, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 586);
            this.panel1.TabIndex = 8;
            // 
            // ratingControl1
            // 
            this.ratingControl1.BackColor = System.Drawing.Color.MintCream;
            this.ratingControl1.Location = new System.Drawing.Point(141, 101);
            this.ratingControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ratingControl1.Name = "ratingControl1";
            this.ratingControl1.Size = new System.Drawing.Size(524, 308);
            this.ratingControl1.TabIndex = 4;
            this.ratingControl1.Visible = false;
            // 
            // loginControl1
            // 
            this.loginControl1.BackColor = System.Drawing.SystemColors.Control;
            this.loginControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginControl1.Location = new System.Drawing.Point(0, 0);
            this.loginControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loginControl1.Name = "loginControl1";
            this.loginControl1.Size = new System.Drawing.Size(835, 586);
            this.loginControl1.TabIndex = 0;
            this.loginControl1.Load += new System.EventHandler(this.loginControl1_Load);
            // 
            // raiseTicControl1
            // 
            this.raiseTicControl1.BackColor = System.Drawing.Color.MintCream;
            this.raiseTicControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.raiseTicControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.raiseTicControl1.Location = new System.Drawing.Point(0, 0);
            this.raiseTicControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.raiseTicControl1.Name = "raiseTicControl1";
            this.raiseTicControl1.Size = new System.Drawing.Size(835, 586);
            this.raiseTicControl1.TabIndex = 3;
            this.raiseTicControl1.Visible = false;
            // 
            // chatControl1
            // 
            this.chatControl1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chatControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatControl1.Location = new System.Drawing.Point(0, 0);
            this.chatControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chatControl1.Name = "chatControl1";
            this.chatControl1.Size = new System.Drawing.Size(835, 586);
            this.chatControl1.TabIndex = 1;
            this.chatControl1.Visible = false;
            // 
            // ticketControl
            // 
            this.ticketControl.BackColor = System.Drawing.Color.White;
            this.ticketControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ticketControl.Location = new System.Drawing.Point(192, 0);
            this.ticketControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ticketControl.Name = "ticketControl";
            this.ticketControl.Size = new System.Drawing.Size(835, 586);
            this.ticketControl.TabIndex = 7;
            // 
            // systemInfo
            // 
            this.systemInfo.BackColor = System.Drawing.Color.White;
            this.systemInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.systemInfo.Location = new System.Drawing.Point(192, 0);
            this.systemInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.systemInfo.Name = "systemInfo";
            this.systemInfo.Size = new System.Drawing.Size(835, 586);
            this.systemInfo.TabIndex = 6;
            // 
            // selfHeal
            // 
            this.selfHeal.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.selfHeal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selfHeal.Location = new System.Drawing.Point(192, 0);
            this.selfHeal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selfHeal.Name = "selfHeal";
            this.selfHeal.Size = new System.Drawing.Size(835, 586);
            this.selfHeal.TabIndex = 4;
            // 
            // antiControl
            // 
            this.antiControl.BackColor = System.Drawing.Color.White;
            this.antiControl.Location = new System.Drawing.Point(197, 0);
            this.antiControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.antiControl.Name = "antiControl";
            this.antiControl.Size = new System.Drawing.Size(824, 656);
            this.antiControl.TabIndex = 6;
            // 
            // chromeControl
            // 
            this.chromeControl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chromeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chromeControl.Location = new System.Drawing.Point(198, 0);
            this.chromeControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chromeControl.Name = "chromeControl";
            this.chromeControl.Size = new System.Drawing.Size(824, 658);
            this.chromeControl.TabIndex = 5;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1027, 586);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ticketControl);
            this.Controls.Add(this.systemInfo);
            this.Controls.Add(this.selfHeal);
            this.Controls.Add(this.antiControl);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CIPL V2.0.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dashboard_FormClosed);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button sysbutton;
		private System.Windows.Forms.Button softbtn;
		private System.Windows.Forms.Button antibtn;
		private System.Windows.Forms.Button chatbtn;
		private System.Windows.Forms.Button selfbtn;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label lblIncident;
		private SelfHeal selfHeal;
		private ChromeControl chromeControl;
		private AntiControl antiControl;
		private SystemInfo systemInfo;
		private TicketControl ticketControl;
		private System.Windows.Forms.Panel panel1;
		private ChatBotControl.LoginControl loginControl1;
		private ChatBotControl.ChatControl chatControl1;
		private ChatBotControl.RatingControl ratingControl1;
		private ChatBotControl.RaiseTicControl raiseTicControl1;
    }
}