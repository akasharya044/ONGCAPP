using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CIPL.ChatbotItems
{
    public partial class Outgoing : UserControl
    {
        public Outgoing()
        {
            InitializeComponent();
        }
        public string Message
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
                AdjustHeight();
            }

        }
        public void AdjustHeight()
        {
            label1.Height = Util.GetTextHeight(label1, label1.Width) + 10;
            this.Height = label1.Bottom+10;
        }
        private void Outgoing_Resize(object sender, EventArgs e)
        {
            AdjustHeight();

        }

        private void Outgoing_DockChanged(object sender, EventArgs e)
        {
            AdjustHeight();

        }
    }
}
