using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POS.HelperClass;
using POS.BAL;
using POS.BOL;

namespace POS
{
    public partial class FrmResetPassword : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALSalesRepMaster BALSalesRepMaster = new BALSalesRepMaster();
        BOLSalesRepMaster BOLSalesRepMaster = new BOLSalesRepMaster();
        DataTable dt = new DataTable();
        public FrmResetPassword()
        {
            InitializeComponent();           
        }
        public void DisplayMessage(string Text, string Mode)
        {
            try
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
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmResetPassword,Function :DisplayMessage. Message:" + ex.Message);
                DisplayMessage("Error:" + ex.Message, "E");
            }

        }

        private void FrmUserType_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            txtID.Text = ClsCommon.UserID.ToString();
            txtUserName.Text = ClsCommon.UserName;
           // txtPassword.Text = ClsCommon.Password;
        }
        private Boolean CheckValidation()
        {
            Boolean ISValid = false;
            
            try
            {

                if (txtPassword.Text == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter Old password");
                    txtPassword.Focus();
                    goto Final;
                }
                if (txtNewPass.Text.Trim() == txtPassword.Text.Trim())
                {
                    ISValid = false;
                    MessageBox.Show("Password is Already Exist");
                    txtNewPass.Focus();
                    goto Final;
                }
                if (txtNewPass.Text == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter New password");
                    txtNewPass.Focus();
                    goto Final;
                }
                if (txtConPass.Text == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter Confirm password");
                    txtConPass.Focus();
                    goto Final;
                }
                else if(txtNewPass.Text.Trim() != txtConPass.Text.Trim())
                {

                    ISValid = false;
                    MessageBox.Show("New Password and Confirm password does not match");
                    txtConPass.Focus();
                    goto Final;
                }
                else
                {
                    ISValid = true;
                }

            Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmResetPassword,Function :CheckValidation. Message:" + ex.Message);
                return ISValid;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClsCommon.objPassword.Hide();
        }

        private void FrmResetPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.Parent = null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(CheckValidation())
                {
                    DataTable dtUserName = new BALSalesRepMaster().SelectByPassword(new BOLSalesRepMaster() { UserName = txtUserName.Text.Trim(),Password=txtPassword.Text.Trim() });
                    if(dtUserName.Rows.Count > 0)
                    {
                        BOLSalesRepMaster.ID = Convert.ToInt32(txtID.Text);
                        BOLSalesRepMaster.Password = txtNewPass.Text;
                        BOLSalesRepMaster.ModifiedTime = DateTime.Now;
                        BALSalesRepMaster.UpdatePassword(BOLSalesRepMaster);

                        MessageBox.Show("Password Update SuccessFully");
                        ClsCommon.Password = txtNewPass.Text;
                        Reset();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Old Password is Wrong");
                        txtPassword.Focus();
                    }

                   
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmResetPassword,Function :btnUpdate_Click. Message:" + ex.Message);
                DisplayMessage("Error :" , ex.Message + "E");
            }
        }

        private void Reset()
        {
            txtPassword.Text = "";
            txtNewPass.Text = "";
            txtConPass.Text = "";
        }
    }
}