
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;

using System.Windows.Forms;


namespace POS
{
    public partial class FrmFindInvoice : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
       
        public FrmFindInvoice()
        {
            InitializeComponent();
        } 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();         
        }
        private void DisplayMessage(string Text, string Mode)
        {
            switch (Mode)
            {
                case "W":
                    lblErrorMsg.StateCommon.TextColor = Color.FromArgb(16, 6, 244);
                    lblErrorMsg.StateNormal.TextColor = Color.FromArgb(16, 6, 244);
                    lblErrorMsg.Text = Text;
                    break;
                case "I":
                    lblErrorMsg.StateCommon.TextColor = Color.DarkGreen;
                    lblErrorMsg.StateNormal.TextColor = Color.DarkGreen;
                    lblErrorMsg.Text = Text;
                    break;
                case "E":
                    lblErrorMsg.StateCommon.TextColor = Color.DarkRed;
                    lblErrorMsg.StateNormal.TextColor = Color.DarkRed;
                    lblErrorMsg.Text = "Error: " + Text;
                    break;
            }
        }
        private Boolean CheckValidation()
        {
            Boolean ISValid = true;
            try
            {
                if (txtno.Text == "")
                {
                    ISValid = false;
                    DisplayMessage("Please Enter InvoiceNo", "E");
                    txtno.Focus();
                    goto Final;
                }

            Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Function :CheckValidation. Message:" + ex.Message);
                return ISValid;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if(CheckValidation())
                {
                    DataTable dtInvRefNo = new BALInvoiceMaster().SelectByRefNumber(new BOLInvoiceMaster { RefNumber = txtno.Text });
                    if (dtInvRefNo.Rows.Count > 0)
                    {
                        if(ClsCommon.UserName == "Admin")
                        {
                            if (ClsCommon.FunctionVisibility("InvUpdate", "CustomerCenter"))
                            {
                                ClsCommon.ObjInvoiceMaster.LoadTable();
                                ClsCommon.ObjInvoiceMaster.MdiParent = this.MdiParent;
                                ClsCommon.ObjInvoiceMaster.EditableField();
                                ClsCommon.ObjInvoiceMaster.Show();
                                ClsCommon.ObjInvoiceMaster.LoadData(dtInvRefNo.Rows[0]["ID"].ToString());
                            }
                        }
                        else
                        {
                            if(ClsCommon.UserID == Convert.ToInt32(dtInvRefNo.Rows[0]["CreatedID"].ToString()))
                            {
                                if (ClsCommon.FunctionVisibility("InvUpdate", "CustomerCenter"))
                                {
                                    ClsCommon.ObjInvoiceMaster.LoadTable();
                                    ClsCommon.ObjInvoiceMaster.MdiParent = this.MdiParent;
                                    ClsCommon.ObjInvoiceMaster.EditableField();
                                    ClsCommon.ObjInvoiceMaster.Show();
                                    ClsCommon.ObjInvoiceMaster.LoadData(dtInvRefNo.Rows[0]["ID"].ToString());
                                }
                            }
                            else
                            {
                                DisplayMessage("Invoice is not Found" , "E");
                            }
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Invoice is not Found");
                    }
                    //DataTable dtInvRefNo = new BALInvoiceMaster().SelectByRefNumber(new BOLInvoiceMaster { RefNumber = txtno.Text });
                    //if (dtInvRefNo.Rows.Count > 0)
                    //{
                    //    int ID1 = Convert.ToInt32(dtInvRefNo.Rows[0]["ID"].ToString());
                    //    ClsCommon.ObjCustomerCenter.PrintINV(ref ID1);
                    //    ClsCommon.INVID = ID1;
                    //}
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Function :btnSearch_Click. Message:" + ex.Message);
            }
        }
    }
}
