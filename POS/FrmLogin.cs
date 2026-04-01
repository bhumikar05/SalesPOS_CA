using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmLogin : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALSalesRepMaster ObjUserBAL = new BALSalesRepMaster();
        BOLSalesRepMaster ObjUserBOL = new BOLSalesRepMaster();
        public bool IsloginSuccess = false;
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            btnshow.Visible = false;
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
                        //lblErrorMsg.Text = Text;
                        if (lblErrorMsg.InvokeRequired)
                        {
                            lblErrorMsg.Invoke(new Action(() =>
                            {
                                lblErrorMsg.Text = Text;
                            }));
                        }
                        else
                        {
                            lblErrorMsg.Text = Text;
                        }
                        break;
                    case "I":
                        lblErrorMsg.StateCommon.TextColor = Color.DarkGreen;
                        lblErrorMsg.StateNormal.TextColor = Color.DarkGreen;
                        //lblErrorMsg.Text = Text;
                        if (lblErrorMsg.InvokeRequired)
                        {
                            lblErrorMsg.Invoke(new Action(() =>
                            {
                                lblErrorMsg.Text = Text;
                            }));
                        }
                        else
                        {
                            lblErrorMsg.Text = Text;
                        }
                        break;
                    case "E":
                        lblErrorMsg.StateCommon.TextColor = Color.DarkRed;
                        lblErrorMsg.StateNormal.TextColor = Color.DarkRed;
                        //lblErrorMsg.Text = "Error: " + Text;

                        if (lblErrorMsg.InvokeRequired)
                        {
                            lblErrorMsg.Invoke(new Action(() =>
                            {
                                lblErrorMsg.Text = Text;
                            }));
                        }
                        else
                        {
                            lblErrorMsg.Text = Text;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmLogin,Function :DisplayMessage. Message:" + ex.Message);
                DisplayMessage("Error:" + ex.Message, "E");
            }

        }
        private Boolean CheckValidation()
        {
            Boolean ISValid = false;
            try
            {
                if (txtUserName.Text == "")
                {
                    ISValid = false;
                    DisplayMessage("Please Enter UserName", "E");
                    //txtUserName.Focus();
                    if (txtUserName.InvokeRequired)
                    {
                        txtUserName.Invoke(new Action(() =>
                        {
                            txtUserName.Focus();
                        }));
                    }
                    else
                    {
                        txtUserName.Focus();
                    }
                    goto Final;
                }
                if (txtPassword.Text == "")
                {
                    ISValid = false;
                    DisplayMessage("Please Enter Password", "E");
                    //txtPassword.Focus();
                    if (txtPassword.InvokeRequired)
                    {
                        txtPassword.Invoke(new Action(() =>
                        {
                            txtPassword.Focus();
                        }));
                    }
                    else
                    {
                        txtPassword.Focus();
                    }
                    goto Final;
                }
                else
                    ISValid = true;

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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                pctLoader.Visible = true;
                pctLoader.Dock = DockStyle.Fill;
                backgroundWorker1.RunWorkerAsync();

                //if (CheckValidation())
                //{
                    //lblErrorMsg.Text = "";
                    //DataTable dtLogin = new BALSalesRepMaster().SelectForLogin(new BOLSalesRepMaster() { UserName = txtUserName.Text, Password = txtPassword.Text });
                    //if (dtLogin.Rows.Count > 0)
                    //{
                    //    if (dtLogin.Rows[0]["IsLogin"].ToString() == "0")
                    //    {
                    //        ClsCommon.UserID = Convert.ToInt32(dtLogin.Rows[0]["ID"].ToString());
                    //        ClsCommon.UserName = dtLogin.Rows[0]["UserName"].ToString();
                    //        ClsCommon.UserType = dtLogin.Rows[0]["UserType"].ToString();
                    //        ClsCommon.Name = dtLogin.Rows[0]["Name"].ToString();

                    //        // Update IsLogin in SalesRepMaster
                    //        ObjUserBOL.ID = ClsCommon.UserID;
                    //        ObjUserBOL.IsLogin = 1;
                    //        ObjUserBAL.UpdateIsLogin(ObjUserBOL);

                    //        this.Hide();
                    //    }
                    //    else
                    //    {
                    //        DisplayMessage("This user is already login", "E");
                    //    }
                    //}
                    //else
                    //{
                    //    DisplayMessage("Invalid UserName or Password", "E");
                    //}
                //}
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmLogin,Function :btnLogin_Click. Message:" + ex.Message);
                DisplayMessage("Error:" + ex.Message, "E");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (CheckValidation())
                {
                    if (lblErrorMsg.InvokeRequired)
                    {
                        lblErrorMsg.Invoke(new Action(() =>
                        {
                            lblErrorMsg.Text = "";
                        }));
                    }
                    else
                    {
                        lblErrorMsg.Text = "";
                    }
                    DataTable dtLogin = new BALSalesRepMaster().SelectForLogin(new BOLSalesRepMaster() { UserName = txtUserName.Text, Password = txtPassword.Text });

                    if (dtLogin.Rows.Count > 0)
                    {
                        if (dtLogin.Rows[0]["IsLogin"].ToString() == "0")
                        {
                            if(dtLogin.Rows[0]["IsActive"].ToString() == "1")
                            {
                                Thread.Sleep(500);
                                IsloginSuccess = true;

                                ClsCommon.UserID = Convert.ToInt32(dtLogin.Rows[0]["ID"].ToString());
                                ClsCommon.UserName = dtLogin.Rows[0]["UserName"].ToString();
                                ClsCommon.UserType = dtLogin.Rows[0]["UserType"].ToString();
                                ClsCommon.Name = dtLogin.Rows[0]["Name"].ToString();
                                ClsCommon.Password = dtLogin.Rows[0]["Password"].ToString();
                                ClsCommon.UserTypeID = dtLogin.Rows[0]["UserTypeID"].ToString();

                                // Update IsLogin in SalesRepMaster
                                ObjUserBOL.ID = ClsCommon.UserID;
                                ObjUserBOL.IsLogin = 1;
                                ObjUserBAL.UpdateIsLogin(ObjUserBOL);

                                //this.Hide();
                            }
                            else
                            {
                                IsloginSuccess = false;
                                MessageBox.Show("This user is Inactive");
                            }



                        }
                        else
                        {
                            IsloginSuccess = false;
                            MessageBox.Show("This user is already login");
                            //DisplayMessage("This user is already login", "E");
                        }
                    }
                    else
                    {
                        IsloginSuccess = false;
                        MessageBox.Show("Invalid UserName or Password");
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmLogin,Function :backgroundWorker1_DoWork. Message:" + ex.Message);
                DisplayMessage("Error:" + ex.Message, "E");
            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (IsloginSuccess)
                    this.Hide();
                else
                    pctLoader.Visible = false;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmLogin,Function :backgroundWorker1_RunWorkerCompleted. Message:" + ex.Message);
                DisplayMessage("Error:" + ex.Message, "E");
            }
        }
        private void pctLoader_Click(object sender, EventArgs e)
        {

        }
        private void btnshow_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                txtPassword.UseSystemPasswordChar = true;
                btnshow.Visible = false;
                btnhide.Visible = true;
                
            }
            txtPassword.Focus();

        }
        private void btnhide_Click(object sender, EventArgs e)
        {
                if (txtPassword.PasswordChar == '●')
                {
                    txtPassword.UseSystemPasswordChar = false;
                    btnshow.Visible = true;
                    btnhide.Visible = false;
                }
                txtPassword.Focus();
        }
    }
}