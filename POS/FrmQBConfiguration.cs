using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.QBClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmQBConfiguration : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BOLQBConfig objBOLConfig = new BOLQBConfig();
        BALQBConfig objBALConfig = new BALQBConfig();

        public FrmQBConfiguration()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
        }

        private void FrmQBConfiguration_Load(object sender, EventArgs e)
        {
            try
            {
                LoadYear();
                LoadExistingData();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:frmQBConfiguration,Function :FrmQBConfiguration_Load. Message:" + ex.Message);
                DisplayMessage("Error:" + ex.Message, "E");
            }
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void LoadYear()
        {
            try
            {
                DataTable dtYear = new DataTable();
                dtYear.Columns.Add("Year", typeof(string));
                dtYear.Columns.Add("Version", typeof(string));

                DataRow dr = dtYear.NewRow();
                dtYear.Rows.Add("--Select--", "0");
                dtYear.Rows.Add("2010", "9.0");
                dtYear.Rows.Add("2011", "10.0");
                dtYear.Rows.Add("2012", "10.0");
                dtYear.Rows.Add("2013", "12.0");
                dtYear.Rows.Add("2014", "13.0");
                dtYear.Rows.Add("2015", "13.0");
                dtYear.Rows.Add("2016", "13.0");
                dtYear.Rows.Add("2017", "13.0");
                dtYear.Rows.Add("2018", "13.0");
                dtYear.Rows.Add("2019", "13.0");
                dtYear.Rows.Add("2020", "13.0");
                dtYear.Rows.Add("2020+", "13.0");
                cmbYear.DataSource = dtYear;
                cmbYear.DisplayMember = "Year";
                cmbYear.ValueMember = "Version";
                cmbYear.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmQBConfiguration,Function :LoadYear. Message:" + ex.Message);
                DisplayMessage("Error:" + ex.Message, "E");
            }
        }

        private void LoadExistingData()
        {
            try
            {
                DataTable dtConfig = new BALQBConfig().Select(new BOLQBConfig() { });
                if (dtConfig.Rows.Count > 0)
                {
                    if (dtConfig.Rows[0]["Path"].ToString() != "")
                    {
                        txtQBPath.Text = dtConfig.Rows[0]["Path"].ToString();
                        txtVersion.Text = dtConfig.Rows[0]["Version"].ToString();
                        cmbYear.Text = dtConfig.Rows[0]["Year"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmQBConfiguration,Function :LoadExistingData. Message:" + ex.Message);
                DisplayMessage("Error:" + ex.Message, "E");
            }
        }

        private Boolean CheckValidation()
        {
            Boolean ISValid = true;
            try
            {
                if (cmbYear.SelectedIndex == 0)
                {
                    ISValid = false;
                    DisplayMessage("Please Select Year", "E");
                    cmbYear.Focus();
                    goto Final;
                }

            Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmQBConfiguration,Function :CheckValidation. Message:" + ex.Message);
                DisplayMessage("Error:" + ex.Message, "E");
                return ISValid;
            }
        }

        private void btnQBAccess_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("QBAccess", "QBConfiguration"))
                {
                    if (CheckValidation())
                    {
                        lblErrorMsg.Text = "";
                        ClsCommon.retMessage.Clear();
                        //Program.dispose();
                        QBConnection.Close_QBConnection();
                        ClsCommon.retMessage = QBConnection.OpenConnection_anyMode();
                        if (ClsCommon.retMessage["Status"].Contains("Error:") == false)
                        {
                            ClsCommon.retMessage = QBConnection.GetCompanyInfo(txtVersion.Text);
                            txtQBPath.Text = ClsCommon.retMessage["Path"].ToString();
                            txtVersion.Text = ClsCommon.retMessage["Version"].ToString();

                            DisplayMessage("QuickBooks Company File Permission set Successfully", "I");
                            ClsCommon.WriteErrorLogs("Function :btnQBAccess_Click. Message:QuickBooks Company File Permission set Successfully");

                          //  ClsCommon.retMessage = QBCompany.Get_QBCompany();

                            DataTable dtConfig = new BALQBConfig().Select(new BOLQBConfig() { });
                            if (dtConfig.Rows.Count == 0)
                            {
                                // Insert
                                objBOLConfig.Path = txtQBPath.Text;
                                objBOLConfig.Version = txtVersion.Text;
                                objBOLConfig.Year = cmbYear.Text.ToString();
                                //if (ClsCommon.dtQBMaster.Rows.Count>0)
                                //{
                                //    objBOLConfig.CompanyName = ClsCommon.dtQBMaster.Rows[0]["Name"].ToString();
                                //    objBOLConfig.CompanyAddress = ClsCommon.dtQBMaster.Rows[0]["Address"].ToString();
                                //}
                                objBOLConfig.Flag = 0;
                                objBALConfig.Insert(objBOLConfig);
                            }
                            else
                            {
                                // Update
                                objBOLConfig.ID = Convert.ToInt16(dtConfig.Rows[0]["ID"].ToString());
                                objBOLConfig.Path = txtQBPath.Text;
                                objBOLConfig.Version = txtVersion.Text;
                                objBOLConfig.Year = cmbYear.Text.ToString();
                                objBOLConfig.Flag = 0;
                                //if (ClsCommon.dtQBMaster.Rows.Count > 0)
                                //{
                                //    objBOLConfig.CompanyName = ClsCommon.dtQBMaster.Rows[0]["Name"].ToString();
                                //    objBOLConfig.CompanyAddress = ClsCommon.dtQBMaster.Rows[0]["Address"].ToString();
                                //}
                                objBALConfig.UpdateConfig(objBOLConfig);
                            }
                            LoadExistingData();
                        }
                        else
                        {
                            DisplayMessage(ClsCommon.retMessage["Status"].ToString(), "E");
                            ClsCommon.WriteErrorLogs("Form:FrmQBConfiguration,Function :btnQBAccess_Click. Message:" + ClsCommon.retMessage["Status"].ToString());
                        }
                        //Program.dispose();
                    }
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmQBConfiguration,Function :btnQBAccess_Click. Message:" + ex.Message);
                DisplayMessage("Error:" + ex.Message, "E");
            }
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbYear.SelectedIndex == 0)
                {
                    txtVersion.Text = "";
                }
                else
                {
                    txtVersion.Text = cmbYear.SelectedValue.ToString();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmQBConfiguration,Function :cmbYear_SelectedIndexChanged. Message:" + ex.Message);
                DisplayMessage("Error:" + ex.Message, "E");
            }
        }

        private void lblUserName_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}