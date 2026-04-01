using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmCustomerMessage : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALInvoiceMessage ObjInvBAL = new BALInvoiceMessage();
        BOLInvoiceMessage ObjInvBOL = new BOLInvoiceMessage();
        DataTable dt = new DataTable();
        public FrmCustomerMessage()
        {
            InitializeComponent();
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

                if (txtlog.Text == "")
                {
                    ISValid = false;
                    DisplayMessage("Please Enter Text", "E");
                    txtlog.Focus();
                    goto Final;
                }

            Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmLogin,Function :CheckValidation. Message:" + ex.Message);
                DisplayMessage("Error:" + ex.Message, "E");
                return ISValid;
            }
        }
        public void ResetData()
        {
            lblErrorMsg.Text = "";
            txtID.Text = "";
            txtlog.Text = "";
        }

        public void displaydata()
        {
            try
            {
                dgUser.Rows.Clear();
                if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                {
                    dt = new BALInvoiceMessage().SelectAll();
                }
                else
                {
                    dt = new BALInvoiceMessage().SelectAll();
                }
                int iRow = 0;
                foreach (DataRow item in dt.Rows)
                {
                    dgUser.Rows.Add();
                    dgUser[0, iRow].Value = item["ID"].ToString();

                    dgUser[1, iRow].Value = item["LogName"].ToString();

                    iRow++;
                }
            }
            catch (Exception ex)
            {
                DisplayMessage("Error:" + ex.Message, "E");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidation())
                {
                    ClsCommon.ObjInvoiceMaster.isCustomerMessageFormOpen = false;
                    ClsCommon.ObjInvoiceMaster.LastEditedID = 0;
                    if (txtID.Text == "")
                    {
                        ClsCommon.ObjInvoiceMaster.isCustomerMessageFormOpen = true;
                        ObjInvBOL.LogName = txtlog.Text;
                        ObjInvBOL.CreatedDate = DateTime.Now;
                        ObjInvBAL.Insert(ObjInvBOL);
                    }
                    else
                    {
                        ClsCommon.ObjInvoiceMaster.isCustomerMessageFormOpen = true;
                        ObjInvBOL.ID = Convert.ToInt32(txtID.Text);
                        ObjInvBOL.LogName = txtlog.Text;
                        ObjInvBAL.Update(ObjInvBOL);
                        ClsCommon.ObjInvoiceMaster.LastEditedID = Convert.ToInt32(txtID.Text);
                    }
                    DisplayMessage("Record save successfully", "I");
                    displaydata();
                    ResetData();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                DisplayMessage("Error:" + ex.Message, "E");
            }
        }
        private void dgUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    ClsCommon.ObjInvoiceMaster.isCustomerMessageFormOpen = true;
                    int id = Convert.ToInt32(dgUser.CurrentRow.Cells[0].Value.ToString());
                    dt = ObjInvBAL.SelectByID(id);
                    if (dt.Rows.Count > 0)
                    {
                        txtlog.Text = dt.Rows[0]["LogName"].ToString();
                        txtID.Text = dt.Rows[0]["ID"].ToString();
                    }
                }
                if (e.ColumnIndex == 3)
                {
                    ClsCommon.ObjInvoiceMaster.isCustomerMessageFormOpen = true;
                    int id = Convert.ToInt32(dgUser.CurrentRow.Cells[0].Value.ToString());
                    ObjInvBAL.Delete(id);
                    // DisplayMessage("Record Delete successfully", "I");
                    displaydata();
                    ResetData();
                }
            }
            catch (Exception ex)
            {
                DisplayMessage("Error:" + ex.Message, "E");
            }
        }


        private void FrmCustomerMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.Parent = null;
            ResetData();
            displaydata();
        }

        private void FrmCustomerMessage_Load(object sender, EventArgs e)
        {
            displaydata();

        }

    }
}