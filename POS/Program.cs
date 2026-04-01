using POS.HelperClass;
using POS.Properties;
using System;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    static class Program
    {
        public static Settings mySetting = new Settings();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //if ((new DateTime(2022, 11, 30) - DateTime.Now).Days > 0)
            //{
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MDIParent());
            //}
            //else
            //{
            //    MessageBox.Show("Application Test Demo Experied. Please Contact Administrator");
            //    Application.Exit();
            //}
        }
    }
}