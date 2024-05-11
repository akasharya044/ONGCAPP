using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CIPL.ChatbotItems
{
    public static class Util
    {
        public static int GetTextHeight(Label lbl, int width)
        {
            Size proposedSize = new Size(width, int.MaxValue);
            TextFormatFlags flags = TextFormatFlags.WordBreak;
            Size size = TextRenderer.MeasureText(lbl.Text, lbl.Font, proposedSize, flags);
            return size.Height;
        }
    }
}
