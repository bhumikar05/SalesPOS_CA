using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmShippingOptions : ComponentFactory.Krypton.Toolkit.KryptonForm
    {

        public FrmShippingOptions()
        {
            InitializeComponent();
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(0, 50);
        }

        private void FrmShippingOptions_Load(object sender, EventArgs e)
        {
        }

        private void btnFedExandUPSAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //ClsCommon.objFromShipping.StartPosition = FormStartPosition.Manual;
                //ClsCommon.objFromShipping.Location = new Point(230, 80);
                ClsCommon.objFromShipping.LoadFunction();
                ClsCommon.objFromShipping.Show();
                ClsCommon.objFromShipping.BringToFront();

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmShippingOptions,Function :btnFedExandUPSAdd_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void btnFedExandUpsConfig_Click(object sender, EventArgs e)
        {
            try
            {
                //ClsCommon.objFedEx_UPSSettings.StartPosition = FormStartPosition.Manual;
                //ClsCommon.objFedEx_UPSSettings.Location = new Point(230, 80);
                ClsCommon.objFedEx_UPSSettings.LoadFunction();
                ClsCommon.objFedEx_UPSSettings.Show();
                ClsCommon.objFedEx_UPSSettings.BringToFront();

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmShippingOptions,Function :btnFedExandUpsConfig_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void btnSetTrackingMessage_Click(object sender, EventArgs e)
        {
            //FrmTrackMessage oTrack = new FrmTrackMessage();
            //oTrack.BringToFront();
            //oTrack.StartPosition = FormStartPosition.Manual;
            //oTrack.Location = new Point(230, 80);
            //oTrack.Show();
        }

        private void btnUPSSettings_Click(object sender, EventArgs e)
        {
            ClsCommon.objUPS.BringToFront();
            ClsCommon.objUPS.StartPosition = FormStartPosition.Manual;
            ClsCommon.objUPS.Location = new Point(230, 80);
            ClsCommon.objUPS.Show();
        }

        private void btnShippingbyFedEx_Click(object sender, EventArgs e)
        {
            ClsCommon.objFedEx.BringToFront();
            ClsCommon.objFedEx.StartPosition = FormStartPosition.Manual;
            ClsCommon.objFedEx.Location = new Point(230, 80);
            ClsCommon.objFedEx.Show();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmShippingOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClsCommon.objShippingOptions.Hide();
            ClsCommon.objShippingOptions.Parent = null;
            e.Cancel = true;
        }

        private void btnUPSSetting_Click(object sender, EventArgs e)
        {
            //ClsCommon.FrmUPSSettings.StartPosition = FormStartPosition.CenterScreen;
            //ClsCommon.FrmUPSSettings.Location = new Point(230, 80);
            ClsCommon.FrmUPSSettings.Show();
            ClsCommon.FrmUPSSettings.BringToFront();

        }
    }
}