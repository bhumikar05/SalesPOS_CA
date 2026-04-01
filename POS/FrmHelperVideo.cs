using POS.HelperClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;


namespace POS
{
    public partial class FrmHelperVideo : Form
    {
        
        public FrmHelperVideo()
        {
            InitializeComponent();
        }
        private void FrmHelperVideo_Load(object sender, EventArgs e)
        {
            try
            {              
                axWindowsMediaPlayer2.URL = Application.StartupPath + @"\Video\" + ClsCommon.Variable + "";
                axWindowsMediaPlayer2.Ctlcontrols.play();             
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmHelperVideo,Function :FrmHelperVideo_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void FrmHelperVideo_FormClosing(object sender, FormClosingEventArgs e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.stop();
        }
    }
}
