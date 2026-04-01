using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using POS.BOL;
using POS.BAL;
using POS.HelperClass;

namespace POS
{
    public partial class FrmCusLogCall : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALCusCallLog ObjCusBAL = new BALCusCallLog();
        BOLCusCallLog ObjCusBOL = new BOLCusCallLog();

        DataTable dt = new DataTable();

        public FrmCusLogCall() 
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
                if(cmbCustomer.SelectedIndex <= 0)
                {
                    ISValid = false;
                    DisplayMessage("Please Select Customer", "E");
                    cmbCustomer.Focus();
                    goto Final;
                }
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

        public void GetCustomer()
        {
            try
            {
                DataTable dtCustomer = new DataTable();
                if (ClsCommon.FunctionVisibility("CustomerNumberOnly", "CustomerCenter"))
                {
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = 0, IsCustomerNumber = 0 });
                    else
                        dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = ClsCommon.UserID, IsCustomerNumber = 1});
                }
                else
                {
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = 0, IsCustomerNumber = 0 });
                    else
                        dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = ClsCommon.UserID, IsCustomerNumber = 0 });
                }
                DataRow dr = dtCustomer.NewRow();
                dr["Customer"] = "--Select--";
                dr["ID"] = "0";
                dr["ActiveStatus"] = "0";
                dtCustomer.Rows.InsertAt(dr, 0);
                cmbCustomer.DataSource = dtCustomer;
                cmbCustomer.DisplayMember = "Customer";
                cmbCustomer.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCusLogCall,Function :GetCustomer. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            GetCustomer();
            displaydata();
        }

        public void ShowDetail(int id)
        {
            cmbCustomer.SelectedValue = id;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidation())
                {

                    if(txtID.Text == "")
                    {
                        ObjCusBOL.CusID = Convert.ToInt32(cmbCustomer.SelectedValue);
                        ObjCusBOL.UserID = ClsCommon.UserID;
                        ObjCusBOL.LogName = txtlog.Text;
                        ObjCusBOL.CreatedDate = DateTime.Now;
                        ObjCusBAL.Insert(ObjCusBOL);
                    }
                    else
                    {
                        ObjCusBOL.ID = Convert.ToInt32(txtID.Text);
                        ObjCusBOL.CusID = Convert.ToInt32(cmbCustomer.SelectedValue);
                        ObjCusBOL.UserID = ClsCommon.UserID;
                        ObjCusBOL.LogName = txtlog.Text;
                        ObjCusBOL.UpdatedDate = DateTime.Now;
                        ObjCusBAL.Update(ObjCusBOL);
                    }                 
                    DisplayMessage("Record save successfully", "I");
                    displaydata();
                    ResetData();
                }
            }
            catch (Exception ex)
            {
                DisplayMessage("Error:" + ex.Message, "E");
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
                if(ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                {
                    dt = new BALCusCallLog().SelectBySalesRep(0);
                }
                else
                {
                    dt = new BALCusCallLog().SelectBySalesRep(ClsCommon.UserID);
                }           
                int iRow = 0;
                foreach (DataRow item in dt.Rows)
                {
                    dgUser.Rows.Add();
                    dgUser[0, iRow].Value = item["ID"].ToString();
                    dgUser[1, iRow].Value = item["UserName"].ToString();
                    dgUser[2, iRow].Value = item["FullName"].ToString();
                    dgUser[3, iRow].Value = item["LogName"].ToString();
                    if(item["CreatedDate"].ToString() != "")
                    {
                        DateTime date = Convert.ToDateTime(item["CreatedDate"].ToString());
                        dgUser[4, iRow].Value = date.ToString("dd/MM/yyyy");
                    }
                    if (item["UpdatedDate"].ToString() != "")
                    {
                        DateTime date = Convert.ToDateTime(item["UpdatedDate"].ToString());
                        dgUser[5, iRow].Value = date.ToString("dd/MM/yyyy");
                    }
                    iRow++;
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
                if (e.ColumnIndex == 6)
                {
                    int id = Convert.ToInt32(dgUser.CurrentRow.Cells[0].Value.ToString());
                    dt = ObjCusBAL.SelectByID(id);
                    if (dt.Rows.Count > 0)
                    {
                        txtlog.Text = dt.Rows[0]["LogName"].ToString();
                        txtID.Text = dt.Rows[0]["ID"].ToString();
                        cmbCustomer.SelectedValue= dt.Rows[0]["CusID"].ToString();                       
                    }
                   
                }
                if(e.ColumnIndex == 7)
                {
                    int id = Convert.ToInt32(dgUser.CurrentRow.Cells[0].Value.ToString());
                    ObjCusBAL.Delete(id);
                    DisplayMessage("Record Delete successfully", "I");
                    displaydata();
                }
            }
            catch (Exception ex)
            {

                DisplayMessage("Error:" + ex.Message, "E");
            }
        }

        private void FrmCusLogCall_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.Parent = null;
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}