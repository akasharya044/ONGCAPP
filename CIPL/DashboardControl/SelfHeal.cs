using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIPL.DashboardControl
{
	public partial class SelfHeal : UserControl
	{
		public SelfHeal()
		{
			InitializeComponent();
		}
		private void Chromebtn_MouseEnter(object sender, EventArgs e)
		{
			browserbtn.BackColor = Color.DarkSlateGray;
		}

		private void Chromebtn_MouseLeave(object sender, EventArgs e)
		{
			browserbtn.BackColor = Color.Black;

		}
		private void windowbtn_MouseEnter(object sender, EventArgs e)
		{
			windowbtn.BackColor = Color.DarkSlateGray;
		}

		private void windowbtn_MouseLeave(object sender, EventArgs e)
		{
			windowbtn.BackColor = Color.Black;

		}
		private void Machinebtn_MouseEnter(object sender, EventArgs e)
		{
			Machinebtn.BackColor = Color.DarkSlateGray;
		}

		private void Machinebtn_MouseLeave(object sender, EventArgs e)
		{
			Machinebtn.BackColor = Color.Black;

		}
		private void printerbtn_MouseEnter(object sender, EventArgs e)
		{
			printerbtn.BackColor = Color.DarkSlateGray;
		}

		private void printerbtn_MouseLeave(object sender, EventArgs e)
		{
			printerbtn.BackColor = Color.Black;

		}
		private void pdfbtn_MouseEnter(object sender, EventArgs e)
		{
			pdfbtn.BackColor = Color.DarkSlateGray;
		}

		private void pdfbtn_MouseLeave(object sender, EventArgs e)
		{
			pdfbtn.BackColor = Color.Black;

		}
		private void lotusbtn_MouseEnter(object sender, EventArgs e)
		{
			lotusbtn.BackColor = Color.DarkSlateGray;
		}

		private void lotusbtn_MouseLeave(object sender, EventArgs e)
		{
			lotusbtn.BackColor = Color.Black;

		}
		private void imagebtn_MouseEnter(object sender, EventArgs e)
		{
			imagebtn.BackColor = Color.DarkSlateGray;
		}

		private void imagebtn_MouseLeave(object sender, EventArgs e)
		{
			imagebtn.BackColor = Color.Black;

		}

		private void browserbtn_Click(object sender, EventArgs e)
		{
			if (!chromeControl.Visible)
			{
				chromeControl.Visible = true;
			}
			windowControl1.Visible = false;

		}

		private void SelfHeal_Load(object sender, EventArgs e)
		{
			chromeControl.Visible = false;
			windowControl1.Visible = false;
			machineControl11.Visible = false;
			printerControl11.Visible = false;
			pdfControl11.Visible = false;
			lotusControl11.Visible = false;
			imageControl11.Visible = false;

		}

		private void windowbtn_Click(object sender, EventArgs e)
		{

			if (!windowControl1.Visible)
			{
				windowControl1.Visible = true;
			}
		}

		private void Machinebtn_Click(object sender, EventArgs e)
		{
			if (!machineControl11.Visible)
			{
				machineControl11.Visible = true;
			}
		}

		private void printerbtn_Click(object sender, EventArgs e)
		{
			if (!printerControl11.Visible)
			{
				printerControl11.Visible = true;
			}
		}

		private void pdfbtn_Click(object sender, EventArgs e)
		{
			if (!pdfControl11.Visible)
			{
				pdfControl11.Visible = true;
			}
		}

		private void lotusbtn_Click(object sender, EventArgs e)
		{
			if (!lotusControl11.Visible)
			{
				lotusControl11.Visible = true;
			}
		}

		private void imagebtn_Click(object sender, EventArgs e)
		{
			if (!imageControl11.Visible)
			{
				imageControl11.Visible = true;
			}
		}
	}
}
