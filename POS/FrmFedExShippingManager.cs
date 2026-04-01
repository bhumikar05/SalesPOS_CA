using POS.HelperClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmFedExShippingManager : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public FrmFedExShippingManager()
        {
            InitializeComponent();
        }

        private void FrmFedExShipping_Load(object sender, EventArgs e)
        {
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void txtZip_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char c = e.KeyChar;

                // Allow letters/digits for Canadian postal codes (e.g., "K1A 0B1")
                // Also allow space/hyphen for common formatting.
                if (char.IsControl(c))
                    return;

                if (char.IsLetterOrDigit(c) || c == ' ' || c == '-')
                    return;

                e.Handled = true;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFedExShippingManager,Function :txtZip_KeyPress. Message:" + ex.Message);
            }
        }

        private void FrmFedExShippingManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClsCommon.objFedEx.Hide();
            ClsCommon.objFedEx.Parent = null;
            e.Cancel = true;
        }
    }
}