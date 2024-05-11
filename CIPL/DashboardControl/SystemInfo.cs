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
	public partial class SystemInfo : UserControl
	{
		public SystemInfo()
		{
			InitializeComponent();
		}

		private void softwareControl1_Load(object sender, EventArgs e)
		{
			softwareControl1.Show();
			hardwareInfo1.Show();

		}
	}
}
