using System.Windows.Forms;

namespace CIPLV2.Tickets
{
    partial class FrmLanding
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLanding));
			this.pnlfeddback = new System.Windows.Forms.Panel();
			this.pnlcontrols = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.LinkLabel();
			this.lblresolvedon = new System.Windows.Forms.Label();
			this.lblassignedto = new System.Windows.Forms.Label();
			this.lblsubject = new System.Windows.Forms.Label();
			this.lblincidentno = new System.Windows.Forms.Label();
			this.cmdsubmit = new System.Windows.Forms.Button();
			this.cmdclose = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btn_5 = new System.Windows.Forms.Button();
			this.btn_4 = new System.Windows.Forms.Button();
			this.btn_3 = new System.Windows.Forms.Button();
			this.btn_2 = new System.Windows.Forms.Button();
			this.btn_1 = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlfeddback.SuspendLayout();
			this.pnlcontrols.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlfeddback
			// 
			this.pnlfeddback.BackColor = System.Drawing.Color.Green;
			this.pnlfeddback.Controls.Add(this.pnlcontrols);
			this.pnlfeddback.Controls.Add(this.label1);
			this.pnlfeddback.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlfeddback.Location = new System.Drawing.Point(0, 0);
			this.pnlfeddback.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlfeddback.Name = "pnlfeddback";
			this.pnlfeddback.Size = new System.Drawing.Size(924, 545);
			this.pnlfeddback.TabIndex = 0;
			this.pnlfeddback.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlfeddback_Paint_1);
			// 
			// pnlcontrols
			// 
			this.pnlcontrols.BackColor = System.Drawing.Color.MintCream;
			this.pnlcontrols.Controls.Add(this.button1);
			this.pnlcontrols.Controls.Add(this.lblresolvedon);
			this.pnlcontrols.Controls.Add(this.lblassignedto);
			this.pnlcontrols.Controls.Add(this.lblsubject);
			this.pnlcontrols.Controls.Add(this.lblincidentno);
			this.pnlcontrols.Controls.Add(this.cmdsubmit);
			this.pnlcontrols.Controls.Add(this.cmdclose);
			this.pnlcontrols.Controls.Add(this.label12);
			this.pnlcontrols.Controls.Add(this.textBox1);
			this.pnlcontrols.Controls.Add(this.pictureBox1);
			this.pnlcontrols.Controls.Add(this.btn_5);
			this.pnlcontrols.Controls.Add(this.btn_4);
			this.pnlcontrols.Controls.Add(this.btn_3);
			this.pnlcontrols.Controls.Add(this.btn_2);
			this.pnlcontrols.Controls.Add(this.btn_1);
			this.pnlcontrols.Controls.Add(this.label11);
			this.pnlcontrols.Controls.Add(this.label10);
			this.pnlcontrols.Controls.Add(this.label9);
			this.pnlcontrols.Controls.Add(this.label8);
			this.pnlcontrols.Controls.Add(this.label7);
			this.pnlcontrols.Controls.Add(this.label6);
			this.pnlcontrols.Controls.Add(this.label5);
			this.pnlcontrols.Controls.Add(this.label4);
			this.pnlcontrols.Controls.Add(this.label3);
			this.pnlcontrols.Controls.Add(this.label2);
			this.pnlcontrols.Location = new System.Drawing.Point(16, 35);
			this.pnlcontrols.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlcontrols.Name = "pnlcontrols";
			this.pnlcontrols.Size = new System.Drawing.Size(897, 495);
			this.pnlcontrols.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.AutoSize = true;
			this.button1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(520, 54);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(94, 24);
			this.button1.TabIndex = 25;
			this.button1.TabStop = true;
			this.button1.Text = "Read More";
			this.button1.Visible = false;
			this.button1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.button1_LinkClicked);
			// 
			// lblresolvedon
			// 
			this.lblresolvedon.AutoSize = true;
			this.lblresolvedon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.lblresolvedon.Location = new System.Drawing.Point(217, 130);
			this.lblresolvedon.Name = "lblresolvedon";
			this.lblresolvedon.Size = new System.Drawing.Size(20, 28);
			this.lblresolvedon.TabIndex = 23;
			this.lblresolvedon.Text = "-";
			// 
			// lblassignedto
			// 
			this.lblassignedto.AutoSize = true;
			this.lblassignedto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.lblassignedto.Location = new System.Drawing.Point(217, 93);
			this.lblassignedto.Name = "lblassignedto";
			this.lblassignedto.Size = new System.Drawing.Size(20, 28);
			this.lblassignedto.TabIndex = 22;
			this.lblassignedto.Text = "-";
			// 
			// lblsubject
			// 
			this.lblsubject.AutoSize = true;
			this.lblsubject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.lblsubject.Location = new System.Drawing.Point(217, 52);
			this.lblsubject.Name = "lblsubject";
			this.lblsubject.Size = new System.Drawing.Size(20, 28);
			this.lblsubject.TabIndex = 21;
			this.lblsubject.Text = "-";
			// 
			// lblincidentno
			// 
			this.lblincidentno.AutoSize = true;
			this.lblincidentno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.lblincidentno.Location = new System.Drawing.Point(217, 18);
			this.lblincidentno.Name = "lblincidentno";
			this.lblincidentno.Size = new System.Drawing.Size(20, 28);
			this.lblincidentno.TabIndex = 20;
			this.lblincidentno.Text = "-";
			// 
			// cmdsubmit
			// 
			this.cmdsubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.cmdsubmit.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
			this.cmdsubmit.ForeColor = System.Drawing.Color.White;
			this.cmdsubmit.Location = new System.Drawing.Point(726, 425);
			this.cmdsubmit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cmdsubmit.Name = "cmdsubmit";
			this.cmdsubmit.Size = new System.Drawing.Size(123, 40);
			this.cmdsubmit.TabIndex = 19;
			this.cmdsubmit.Text = "SUBMIT";
			this.cmdsubmit.UseVisualStyleBackColor = false;
			this.cmdsubmit.Click += new System.EventHandler(this.cmdsubmit_Click);
			// 
			// cmdclose
			// 
			this.cmdclose.BackColor = System.Drawing.Color.Red;
			this.cmdclose.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
			this.cmdclose.ForeColor = System.Drawing.Color.White;
			this.cmdclose.Location = new System.Drawing.Point(589, 425);
			this.cmdclose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cmdclose.Name = "cmdclose";
			this.cmdclose.Size = new System.Drawing.Size(123, 40);
			this.cmdclose.TabIndex = 18;
			this.cmdclose.Text = "CLOSE";
			this.cmdclose.UseVisualStyleBackColor = false;
			this.cmdclose.Click += new System.EventHandler(this.cmdclose_Click);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.label12.Location = new System.Drawing.Point(17, 219);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(95, 28);
			this.label12.TabIndex = 17;
			this.label12.Text = "REMARK";
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(12, 249);
			this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(849, 153);
			this.textBox1.TabIndex = 16;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::CIPLV2.Tickets.Properties.Resources.ongclogo;
			this.pictureBox1.Location = new System.Drawing.Point(620, 30);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(229, 195);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 15;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// btn_5
			// 
			this.btn_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.btn_5.BackgroundImage = global::CIPLV2.Tickets.Properties.Resources.b_star;
			this.btn_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btn_5.Location = new System.Drawing.Point(389, 177);
			this.btn_5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btn_5.Name = "btn_5";
			this.btn_5.Size = new System.Drawing.Size(37, 30);
			this.btn_5.TabIndex = 14;
			this.btn_5.Tag = "feedback";
			this.btn_5.UseVisualStyleBackColor = false;
			this.btn_5.Click += new System.EventHandler(this.btn_5_Click);
			// 
			// btn_4
			// 
			this.btn_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.btn_4.BackgroundImage = global::CIPLV2.Tickets.Properties.Resources.b_star;
			this.btn_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btn_4.Location = new System.Drawing.Point(346, 177);
			this.btn_4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btn_4.Name = "btn_4";
			this.btn_4.Size = new System.Drawing.Size(37, 30);
			this.btn_4.TabIndex = 13;
			this.btn_4.Tag = "feedback";
			this.btn_4.UseVisualStyleBackColor = false;
			this.btn_4.Click += new System.EventHandler(this.btn_4_Click);
			// 
			// btn_3
			// 
			this.btn_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.btn_3.BackgroundImage = global::CIPLV2.Tickets.Properties.Resources.b_star;
			this.btn_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btn_3.Location = new System.Drawing.Point(303, 177);
			this.btn_3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btn_3.Name = "btn_3";
			this.btn_3.Size = new System.Drawing.Size(37, 30);
			this.btn_3.TabIndex = 12;
			this.btn_3.Tag = "feedback";
			this.btn_3.UseVisualStyleBackColor = false;
			this.btn_3.Click += new System.EventHandler(this.btn_3_Click);
			// 
			// btn_2
			// 
			this.btn_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.btn_2.BackgroundImage = global::CIPLV2.Tickets.Properties.Resources.b_star;
			this.btn_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btn_2.Location = new System.Drawing.Point(260, 177);
			this.btn_2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btn_2.Name = "btn_2";
			this.btn_2.Size = new System.Drawing.Size(37, 30);
			this.btn_2.TabIndex = 11;
			this.btn_2.Tag = "feedback";
			this.btn_2.UseVisualStyleBackColor = false;
			this.btn_2.Click += new System.EventHandler(this.btn_2_Click);
			// 
			// btn_1
			// 
			this.btn_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.btn_1.BackgroundImage = global::CIPLV2.Tickets.Properties.Resources.b_star;
			this.btn_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btn_1.Location = new System.Drawing.Point(217, 177);
			this.btn_1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btn_1.Name = "btn_1";
			this.btn_1.Size = new System.Drawing.Size(37, 30);
			this.btn_1.TabIndex = 10;
			this.btn_1.Tag = "feedback";
			this.btn_1.UseVisualStyleBackColor = false;
			this.btn_1.Click += new System.EventHandler(this.btn1_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.label11.Location = new System.Drawing.Point(179, 174);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(17, 28);
			this.label11.TabIndex = 9;
			this.label11.Text = ":";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.label10.Location = new System.Drawing.Point(179, 130);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(17, 28);
			this.label10.TabIndex = 8;
			this.label10.Text = ":";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.label9.Location = new System.Drawing.Point(179, 93);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(17, 28);
			this.label9.TabIndex = 7;
			this.label9.Text = ":";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.label8.Location = new System.Drawing.Point(179, 52);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(17, 28);
			this.label8.TabIndex = 6;
			this.label8.Text = ":";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.label7.Location = new System.Drawing.Point(179, 18);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(17, 28);
			this.label7.TabIndex = 5;
			this.label7.Text = ":";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.label6.Location = new System.Drawing.Point(17, 177);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(86, 28);
			this.label6.TabIndex = 4;
			this.label6.Text = "RATING";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.label5.Location = new System.Drawing.Point(17, 130);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(147, 28);
			this.label5.TabIndex = 3;
			this.label5.Text = "RESOLVED ON";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.label4.Location = new System.Drawing.Point(17, 93);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(142, 28);
			this.label4.TabIndex = 2;
			this.label4.Text = "ASSIGNED TO";
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.label3.Location = new System.Drawing.Point(17, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 28);
			this.label3.TabIndex = 1;
			this.label3.Text = "SUBJECT";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(17, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(124, 28);
			this.label2.TabIndex = 0;
			this.label2.Text = "INCIDENT #";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label1.Location = new System.Drawing.Point(291, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(353, 35);
			this.label1.TabIndex = 0;
			this.label1.Text = "INCIDENT TICKET FEEDBACK";
			// 
			// FrmLanding
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(924, 545);
			this.Controls.Add(this.pnlfeddback);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximizeBox = false;
			this.Name = "FrmLanding";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Incident Ticket Feedback V2.0.1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLanding_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLanding_FormClosed);
			this.Load += new System.EventHandler(this.FrmLanding_Load);
			this.pnlfeddback.ResumeLayout(false);
			this.pnlfeddback.PerformLayout();
			this.pnlcontrols.ResumeLayout(false);
			this.pnlcontrols.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Panel pnlfeddback;
        private Label label1;
        private Panel pnlcontrols;
        private Label label2;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label11;
        private Label label10;
        private Button btn_1;
        private Button btn_5;
        private Button btn_4;
        private Button btn_3;
        private Button btn_2;
        private Label label12;
        private TextBox textBox1;
        private Button cmdclose;
        private Label lblresolvedon;
        private Label lblassignedto;
        private Label lblsubject;
        private Label lblincidentno;
        private Button cmdsubmit;
		private PictureBox pictureBox1;
        private LinkLabel button1;
    }
}