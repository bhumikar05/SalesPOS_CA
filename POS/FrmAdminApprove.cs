using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmAdminApprove : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALCustomerRequest objBALCus = new BALCustomerRequest();
        BOLCustomerRequest objBOLCus = new BOLCustomerRequest();
        public string RequestID = "";

        public FrmAdminApprove()
        {
            InitializeComponent();
        }

        private void FrmAdminApprove_Load(object sender, EventArgs e)
        {
        }

        private void pnlRequest_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pnlRequest.ClientRectangle, Color.Gainsboro, ButtonBorderStyle.Solid);
        }

        private void Clear()
        {
            txtAllow.Text = "";
            txtNumberOfDays.Text = "";
        }

        private Boolean CheckValidation()
        {
            Boolean ISValid = false;
            try
            {
                if (rdbAllow.Checked  == true && Convert.ToInt32(txtAllow.Text) < 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter How many Time Allowes Number");
                    txtAllow.Focus();
                    goto Final;
                }
                else if (rdbNumberOfDays.Checked == true && Convert.ToInt32(txtNumberOfDays.Text) < 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter Number Of days");
                    txtNumberOfDays.Focus();
                    goto Final;
                }
                else
                    ISValid = true;

                Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmAdminApprove,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidation())
                {
                    objBOLCus.ID = Convert.ToInt32(RequestID);
                    if (rdbAllow.Checked == true)
                    {
                        objBOLCus.AllowesNo = Convert.ToInt32(txtAllow.Text);
                        objBOLCus.UseAllowesNo = Convert.ToInt32(txtAllow.Text);
                    }
                    else
                    {
                        objBOLCus.AllowesNo = 0;
                        objBOLCus.UseAllowesNo = 0;
                    }
                    if (rdbNumberOfDays.Checked == true)
                    {
                        objBOLCus.NoOFDays = Convert.ToInt32(txtNumberOfDays.Text);
                        objBOLCus.UseNoOFDays = Convert.ToInt32(txtNumberOfDays.Text);
                    }
                    else
                    {
                        objBOLCus.NoOFDays = 0;
                        objBOLCus.UseNoOFDays = 0;
                    }
                    if (rdbCurrentInvoice.Checked == true)
                    {
                        objBOLCus.CurrentInvoice = 1;
                        objBOLCus.UseCurrentInvoice = 1;
                    }
                    else
                    {
                        objBOLCus.CurrentInvoice = 0;
                        objBOLCus.UseCurrentInvoice = 0;
                    }
                    objBOLCus.Status = 1;
                    objBOLCus.ModifiedTime = DateTime.Now;
                    objBOLCus.ModifiedID = ClsCommon.UserID;

                    objBALCus.UpdateStatus(objBOLCus);
                    ClsCommon.ObjAdminRequestList.DateWiseInvoiceLoad();
                    Clear();
                    this.Close();
                    ClsCommon.ObjInvoiceMaster.Close();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmAdminRequest,Function :btnApprove_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void rdbAllow_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbAllow.Checked == true)
                    txtAllow.Visible = true;
                else
                {
                    txtAllow.Text = "";
                    txtAllow.Visible = false;
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmAdminRequest,Function :rdbAllow_CheckedChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
           
        }

        private void rdbNumberOfDays_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbNumberOfDays.Checked == true)
                    txtNumberOfDays.Visible = true;
                else
                {
                    txtNumberOfDays.Text = "";
                    txtNumberOfDays.Visible = false;
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmAdminRequest,Function :rdbNumberOfDays_CheckedChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
           
        }

        private void txtAllow_KeyPress(object sender, KeyPressEventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmAdminApprove,Function :txtAllow_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void txtNumberOfDays_KeyPress(object sender, KeyPressEventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmAdminApprove,Function :txtNumberOfDays_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}