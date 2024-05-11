using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using CIPL.AppCode;

namespace CIPL
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
			
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dashboard());
        }
    }

}

