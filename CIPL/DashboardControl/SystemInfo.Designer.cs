namespace CIPL.DashboardControl
{
	partial class SystemInfo
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.softwareControl1 = new CIPL.DashboardControl.SoftwareControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.hardwareInfo1 = new CIPL.DashboardControl.HardwareInfo();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(471, 420);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.softwareControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(463, 382);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Software Installed";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // softwareControl1
            // 
            this.softwareControl1.BackColor = System.Drawing.Color.White;
            this.softwareControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.softwareControl1.Location = new System.Drawing.Point(3, 3);
            this.softwareControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.softwareControl1.Name = "softwareControl1";
            this.softwareControl1.Size = new System.Drawing.Size(457, 376);
            this.softwareControl1.TabIndex = 0;
            this.softwareControl1.Load += new System.EventHandler(this.softwareControl1_Load);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.hardwareInfo1);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(463, 382);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hardware Information";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // hardwareInfo1
            // 
            this.hardwareInfo1.BackColor = System.Drawing.SystemColors.Control;
            this.hardwareInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hardwareInfo1.Location = new System.Drawing.Point(3, 3);
            this.hardwareInfo1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hardwareInfo1.Name = "hardwareInfo1";
            this.hardwareInfo1.Size = new System.Drawing.Size(457, 376);
            this.hardwareInfo1.TabIndex = 0;
            // 
            // SystemInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "SystemInfo";
            this.Size = new System.Drawing.Size(471, 420);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private DashboardControl.SoftwareControl softwareControl1;
		private HardwareInfo hardwareInfo1;
	}
}
