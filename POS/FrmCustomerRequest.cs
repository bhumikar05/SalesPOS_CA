using POS.BAL;
using POS.BOL;
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
    public partial class FrmCustomerRequest : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALCustomerRequest objBALCus = new BALCustomerRequest();
        BOLCustomerRequest objBOLCus = new BOLCustomerRequest();
        public string CustomerID = "";
        public string SalesRepID = "";
        public string ItemID = "";

        public FrmCustomerRequest()
        {
            InitializeComponent();
        }

        private void FrmCustomerRequest_Load(object sender, EventArgs e)
        {
        }

        private void pnlCustomerRequest_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pnlCustomerRequest.ClientRectangle, Color.Gainsboro, ButtonBorderStyle.Solid);
        }

        private void Clear()
        {
            txtMessage.Text = "";
            txtLowestPrice.Text = "0.00";
        }

        private Boolean CheckValidation()
        {
            Boolean ISValid = false;
            try
            {
                if (txtMessage.Text == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter Message");
                    txtMessage.Focus();
                    goto Final;
                }
                else if (Convert.ToDecimal(txtLowestPrice.Text) < 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter LowestPrice");
                    txtLowestPrice.Focus();
                    goto Final;
                }
                else
                    ISValid = true;

                Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerRequest,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidation())
                {
                    objBOLCus.SalesRepID = ClsCommon.UserID;
                    objBOLCus.CustomerID = Convert.ToInt32(CustomerID);
                    objBOLCus.ItemID = Convert.ToInt32(ItemID);
                    //objBOLCus.RequestMessage = txtMessage.Text.Trim();
                    objBOLCus.LowestPrice = Convert.ToDecimal(txtLowestPrice.Text);
                    objBOLCus.Status = 0;
                    objBOLCus.CreatedTime = DateTime.Now;
                    objBOLCus.ModifiedTime = DateTime.Now;
                    objBOLCus.CreatedID = ClsCommon.UserID;
                    objBOLCus.IsRead = 0;

                    objBALCus.Insert(objBOLCus);
                    Clear();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerRequest,Function :btnSave_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void txtLowestPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
                {
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerRequest,Function :txtLowestPrice_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}