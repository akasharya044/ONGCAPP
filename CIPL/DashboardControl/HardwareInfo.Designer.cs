namespace CIPL.DashboardControl
{
	partial class HardwareInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvWMI = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWMI)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWMI
            // 
            this.dgvWMI.BackgroundColor = System.Drawing.Color.White;
            this.dgvWMI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWMI.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWMI.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWMI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWMI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWMI.Location = new System.Drawing.Point(0, 0);
            this.dgvWMI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvWMI.Name = "dgvWMI";
            this.dgvWMI.RowHeadersVisible = false;
            this.dgvWMI.RowHeadersWidth = 51;
            this.dgvWMI.Size = new System.Drawing.Size(776, 416);
            this.dgvWMI.TabIndex = 2;
            // 
            // HardwareInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.dgvWMI);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "HardwareInfo";
            this.Size = new System.Drawing.Size(776, 416);
            this.Load += new System.EventHandler(this.HardewareInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWMI)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion


		private System.Windows.Forms.DataGridView dgvWMI;

	}
}
