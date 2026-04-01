using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.Properties;
using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmTrackMessage : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        static Settings mySetting = new Settings();

        public FrmTrackMessage()
        {
            InitializeComponent();
        }

        private void FrmTrackMessage_Load(object sender, EventArgs e)
        {
            txtMessage.Text = mySetting.TrackingMessage;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMessage.Text.Trim() != "")
                {
                    mySetting.TrackingMessage = txtMessage.Text;
                    mySetting.Save();
                    MessageBox.Show("Default Tracking Message Saved Successfully");
                }
                else
                {
                    MessageBox.Show("Insert Default Message Structure for Tracking Update");
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmTrackMessage,Function :btnSave_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}