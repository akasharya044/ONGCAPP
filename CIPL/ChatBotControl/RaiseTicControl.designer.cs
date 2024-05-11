namespace CIPL.ChatBotControl
{
	partial class RaiseTicControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaiseTicControl));
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.fontDialog2 = new System.Windows.Forms.FontDialog();
			this.fontDialog3 = new System.Windows.Forms.FontDialog();
			this.btnSubmit = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.UserDetailText = new System.Windows.Forms.TextBox();
			this.userlistBox = new System.Windows.Forms.ListBox();
			this.DeviceText = new System.Windows.Forms.TextBox();
			this.devicelistBox = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.GoUserDetails = new System.Windows.Forms.Button();
			this.GoCIDevice = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnSubmit
			// 
			this.btnSubmit.AccessibleName = "submit";
			this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(176)))), ((int)(((byte)(19)))));
			this.btnSubmit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
			this.btnSubmit.ForeColor = System.Drawing.Color.White;
			this.btnSubmit.Location = new System.Drawing.Point(616, 518);
			this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new System.Drawing.Size(133, 43);
			this.btnSubmit.TabIndex = 35;
			this.btnSubmit.Text = "Submit";
			this.btnSubmit.UseVisualStyleBackColor = false;
			this.btnSubmit.Click += new System.EventHandler(this.SubmitTic_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(414, 119);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(225, 25);
			this.label2.TabIndex = 36;
			this.label2.Text = "Affected Hostname";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(42, 120);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(225, 25);
			this.label1.TabIndex = 38;
			this.label1.Text = "Domain ID / Name";
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(49, 367);
			this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(700, 120);
			this.textBox1.TabIndex = 40;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(41, 326);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(141, 25);
			this.label3.TabIndex = 41;
			this.label3.Text = "Description";
			// 
			// UserDetailText
			// 
			this.UserDetailText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UserDetailText.Location = new System.Drawing.Point(49, 152);
			this.UserDetailText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.UserDetailText.Multiline = true;
			this.UserDetailText.Name = "UserDetailText";
			this.UserDetailText.Size = new System.Drawing.Size(300, 32);
			this.UserDetailText.TabIndex = 42;
			this.UserDetailText.Text = "Select";
			this.UserDetailText.TextChanged += new System.EventHandler(this.UserDetailText_TextChanged);
			this.UserDetailText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserDetailText_KeyDown);
			this.UserDetailText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UserDetailText_KeyUp);
			this.UserDetailText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserDetails_MouseDown);
			this.UserDetailText.MouseEnter += new System.EventHandler(this.UserDetails_MouseEnter);
			this.UserDetailText.MouseLeave += new System.EventHandler(this.UserDetails_MouseLeave);
			// 
			// userlistBox
			// 
			this.userlistBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.userlistBox.FormattingEnabled = true;
			this.userlistBox.ItemHeight = 18;
			this.userlistBox.Location = new System.Drawing.Point(49, 184);
			this.userlistBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.userlistBox.Name = "userlistBox";
			this.userlistBox.Size = new System.Drawing.Size(300, 112);
			this.userlistBox.TabIndex = 43;
			this.userlistBox.SelectedIndexChanged += new System.EventHandler(this.userlistBox_SelectedIndexChanged);
			// 
			// DeviceText
			// 
			this.DeviceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DeviceText.Location = new System.Drawing.Point(420, 152);
			this.DeviceText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.DeviceText.Multiline = true;
			this.DeviceText.Name = "DeviceText";
			this.DeviceText.Size = new System.Drawing.Size(329, 32);
			this.DeviceText.TabIndex = 44;
			this.DeviceText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DeviceText_KeyDown);
			this.DeviceText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DeviceText_KeyUp);
			this.DeviceText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CIDevice_MouseDown);
			this.DeviceText.MouseEnter += new System.EventHandler(this.CIDevice_MouseEnter);
			this.DeviceText.MouseLeave += new System.EventHandler(this.CIDevice_MouseLeave);
			// 
			// devicelistBox
			// 
			this.devicelistBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.devicelistBox.FormattingEnabled = true;
			this.devicelistBox.ItemHeight = 18;
			this.devicelistBox.Location = new System.Drawing.Point(420, 184);
			this.devicelistBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.devicelistBox.Name = "devicelistBox";
			this.devicelistBox.Size = new System.Drawing.Size(329, 112);
			this.devicelistBox.TabIndex = 45;
			this.devicelistBox.SelectedIndexChanged += new System.EventHandler(this.DevicelistBox_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.Location = new System.Drawing.Point(15, 15);
			this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(46, 27);
			this.button1.TabIndex = 46;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.SteelBlue;
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(831, 58);
			this.panel1.TabIndex = 47;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(304, 15);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(159, 29);
			this.label4.TabIndex = 0;
			this.label4.Text = "Raise Ticket";
			// 
			// GoUserDetails
			// 
			this.GoUserDetails.BackColor = System.Drawing.SystemColors.Window;
			this.GoUserDetails.Cursor = System.Windows.Forms.Cursors.Hand;
			this.GoUserDetails.FlatAppearance.BorderSize = 0;
			this.GoUserDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.GoUserDetails.Image = ((System.Drawing.Image)(resources.GetObject("GoUserDetails.Image")));
			this.GoUserDetails.Location = new System.Drawing.Point(309, 156);
			this.GoUserDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.GoUserDetails.Name = "GoUserDetails";
			this.GoUserDetails.Size = new System.Drawing.Size(25, 25);
			this.GoUserDetails.TabIndex = 48;
			this.GoUserDetails.UseVisualStyleBackColor = true;
			this.GoUserDetails.Click += new System.EventHandler(this.GoUserDetails_Click);
			// 
			// GoCIDevice
			// 
			this.GoCIDevice.Cursor = System.Windows.Forms.Cursors.Hand;
			this.GoCIDevice.FlatAppearance.BorderSize = 0;
			this.GoCIDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.GoCIDevice.Image = ((System.Drawing.Image)(resources.GetObject("GoCIDevice.Image")));
			this.GoCIDevice.Location = new System.Drawing.Point(713, 156);
			this.GoCIDevice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.GoCIDevice.Name = "GoCIDevice";
			this.GoCIDevice.Size = new System.Drawing.Size(23, 25);
			this.GoCIDevice.TabIndex = 49;
			this.GoCIDevice.UseVisualStyleBackColor = true;
			this.GoCIDevice.Click += new System.EventHandler(this.GoCIDevice_Click);
			// 
			// RaiseTicControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.MintCream;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.GoCIDevice);
			this.Controls.Add(this.GoUserDetails);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.userlistBox);
			this.Controls.Add(this.DeviceText);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnSubmit);
			this.Controls.Add(this.devicelistBox);
			this.Controls.Add(this.UserDetailText);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "RaiseTicControl";
			this.Size = new System.Drawing.Size(831, 578);
			this.Load += new System.EventHandler(this.RaiseTicForm_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.FontDialog fontDialog2;
		private System.Windows.Forms.FontDialog fontDialog3;
		private System.Windows.Forms.Button btnSubmit;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox UserDetailText;
		private System.Windows.Forms.ListBox userlistBox;
		private System.Windows.Forms.TextBox DeviceText;
		private System.Windows.Forms.ListBox devicelistBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button GoUserDetails;
		private System.Windows.Forms.Button GoCIDevice;
	}
}
