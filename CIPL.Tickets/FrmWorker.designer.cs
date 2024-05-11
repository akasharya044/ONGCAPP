using System.Drawing;
using System.Windows.Forms;

namespace CIPLV2.Tickets
{
    partial class FrmWorker
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorker));
            CIPL = new System.Windows.Forms.NotifyIcon(components);
            toolTip1 = new ToolTip(components);
            lblfb = new Label();
            lblhb = new Label();
            label1 = new Label();
            cmdclose = new Button();
            SuspendLayout();
            // 
            // CIPL
            // 
            CIPL.Icon = (Icon)resources.GetObject("CIPL.Icon");
            CIPL.Text = "CIPL IT ASSIST";
            CIPL.Visible = true;
            // 
            // lblfb
            // 
            lblfb.AutoSize = true;
            lblfb.Font = new Font("Arial", 6F, FontStyle.Regular, GraphicsUnit.Point);
            lblfb.ForeColor = Color.RoyalBlue;
            lblfb.Location = new Point(1, 122);
            lblfb.Name = "lblfb";
            lblfb.Size = new Size(10, 13);
            lblfb.TabIndex = 27;
            lblfb.Text = "-";
            // 
            // lblhb
            // 
            lblhb.AutoSize = true;
            lblhb.Font = new Font("Arial", 6F, FontStyle.Regular, GraphicsUnit.Point);
            lblhb.ForeColor = Color.Red;
            lblhb.Location = new Point(1, 137);
            lblhb.Name = "lblhb";
            lblhb.Size = new Size(10, 13);
            lblhb.TabIndex = 26;
            lblhb.Text = "-";
            // 
            // label1
            // 
            label1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.InfoText;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(426, 77);
            label1.TabIndex = 28;
            label1.Text = "Your System is Online and Connected With Microfocus.\r\n\r\nWe will notify you, once receive feedback.";
            // 
            // cmdclose
            // 
            cmdclose.BackColor = SystemColors.ButtonFace;
            cmdclose.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            cmdclose.ForeColor = Color.Black;
            cmdclose.Location = new Point(344, 107);
            cmdclose.Name = "cmdclose";
            cmdclose.Size = new Size(94, 45);
            cmdclose.TabIndex = 29;
            cmdclose.Text = "Close Me";
            cmdclose.UseVisualStyleBackColor = false;
            cmdclose.Click += cmdclose_Click;
            // 
            // FrmWorker
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(441, 157);
            ControlBox = false;
            Controls.Add(cmdclose);
            Controls.Add(label1);
            Controls.Add(lblfb);
            Controls.Add(lblhb);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmWorker";
            StartPosition = FormStartPosition.CenterScreen;
            toolTip1.SetToolTip(this, "CIPL IT Assist");
            TopMost = true;
            FormClosing += FrmWorker_FormClosing;
            FormClosed += FrmWorker_FormClosed;
            Load += FrmWorker_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NotifyIcon CIPL;
        private ToolTip toolTip1;
        private Label lblfb;
        private Label lblhb;
        private Label label1;
        private Button cmdclose;
    }
}