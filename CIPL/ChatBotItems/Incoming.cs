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
    public partial class Incoming : UserControl
    {
        public Incoming()
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
            using (Graphics g = label1.CreateGraphics())
            {
                SizeF size = g.MeasureString(label1.Text, label1.Font, label1.Width);
                label1.Height = (int)size.Height + 10;
            }

            this.Height = label1.Bottom + 10;
        }
    
        private void Incoming_Resize(object sender, EventArgs e)
        {
           
            AdjustHeight();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

