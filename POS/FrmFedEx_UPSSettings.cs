using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmFedEx_UPSSettings : ComponentFactory.Krypton.Toolkit.KryptonForm
    {

        BALUPSSettings ObjUPSBAL = new BALUPSSettings();
        BOLUPSSettings ObjUPSBOL = new BOLUPSSettings();

        public FrmFedEx_UPSSettings()
        {
            InitializeComponent();
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(0, 0);
            Clear();
            LoadData();
        }

        public void LoadFunction()
        {
            Clear();
            LoadData();
        }

        private Boolean CheckValidationFedEx()
        {
            Boolean IsValid = false;
            if (txtFedxAccountNo.Text == "")
            {
                MessageBox.Show("Please Enter FedEx Account No");
                txtFedxAccountNo.Focus();
                IsValid = false;
            }
            else if (txtFedExClientID.Text == "")
            {
                MessageBox.Show("Please Enter FedEx Client ID");
                txtFedExClientID.Focus();
                IsValid = false;
            }
            else if (txtFedExClientSecret.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter To FedEx Client Secret");
                txtFedExClientSecret.Focus();
                IsValid = false;
            }
            else if (txtFedXAccessToken.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter To FedEx Access Token");
                txtFedXAccessToken.Focus();
                IsValid = false;
            }
            else
                IsValid = true;
            return IsValid;
        }

        private Boolean CheckValidationUPS()
        {
            Boolean IsValid = false;
            if (txtUPSAccountNo.Text == "")
            {
                MessageBox.Show("Please Enter UPS Account No");
                txtUPSAccountNo.Focus();
                IsValid = false;
            }
            else if (txtUPSClientID.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter To UPS Client ID");
                txtUPSClientID.Focus();
                IsValid = false;
            }
            else if (txtUPSClientSecret.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter To UPS Client Secret");
                txtUPSClientSecret.Focus();
                IsValid = false;
            }
            else if (txtUPSAccessToken.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter To UPS Access Token");
                txtUPSAccessToken.Focus();
                IsValid = false;
            }
            else if (txtUPSRefreshToken.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter To UPS Refresh Token");
                txtUPSRefreshToken.Focus();
                IsValid = false;
            }
            else
                IsValid = true;
            return IsValid;
        }

        private void LoadData()
        {
            try
            {
                DataTable dtFedEx = ObjUPSBAL.Select();
                if (dtFedEx.Rows.Count > 0)
                {

                    for (int i = 0; i < dtFedEx.Rows.Count; i++)
                    {

                        if (dtFedEx.Rows[i]["Type"].ToString() == "FedX")
                        {
                            txtFedxAccountNo.Text = dtFedEx.Rows[i]["AccountNo"].ToString();
                            txtFedExClientID.Text = dtFedEx.Rows[i]["ClientID"].ToString();
                            txtFedExClientSecret.Text = dtFedEx.Rows[i]["ClientSecret"].ToString();
                            txtFedXAccessToken.Text = dtFedEx.Rows[i]["AccessToken"].ToString();
                        }
                        else
                        {

                            txtUPSAccountNo.Text = dtFedEx.Rows[i]["AccountNo"].ToString();
                            txtUPSClientID.Text = dtFedEx.Rows[i]["ClientID"].ToString();
                            txtUPSClientSecret.Text = dtFedEx.Rows[i]["ClientSecret"].ToString();
                            txtUPSAccessToken.Text = dtFedEx.Rows[i]["AccessToken"].ToString();
                            txtUPSRefreshToken.Text = dtFedEx.Rows[i]["RefreshToken"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFedEx_UPSSettings,Function :LoadData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void Clear()
        {
            txtFedxAccountNo.Text = "";
            txtFedExClientID.Text = "";
            txtFedExClientSecret.Text = "";
            txtFedXAccessToken.Text = "";
            txtUPSAccountNo.Text = "";
            txtUPSClientID.Text = "";
            txtUPSClientSecret.Text = "";
            txtUPSAccessToken.Text = "";
            txtUPSRefreshToken.Text = "";
        }

        private void FrmFromShipping_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnFedExSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidationFedEx())
                {
                    ObjUPSBOL.AccountNo = txtFedxAccountNo.Text;
                    ObjUPSBOL.ClientID = txtFedExClientID.Text;
                    ObjUPSBOL.ClientSecret = txtFedExClientSecret.Text;
                    ObjUPSBOL.AccessToken = txtFedXAccessToken.Text;
                    ObjUPSBOL.RefreshToken = "";
                    ObjUPSBOL.Type = "FedX";
                    ObjUPSBAL.Insert_Update(ObjUPSBOL);
                    MessageBox.Show("FedEx Setting Saved Successfully");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFedEx_UPSSettings,Function :btnFedExSave_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnUPSSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidationUPS())
                {

                    ObjUPSBOL.AccountNo = txtUPSAccountNo.Text;
                    ObjUPSBOL.ClientID = txtUPSClientID.Text;
                    ObjUPSBOL.ClientSecret = txtUPSClientSecret.Text;
                    ObjUPSBOL.AccessToken = txtUPSAccessToken.Text;
                    ObjUPSBOL.RefreshToken = txtUPSRefreshToken.Text;
                    ObjUPSBOL.Type = "UPS";
                    ObjUPSBAL.Insert_Update(ObjUPSBOL);

                    MessageBox.Show("UPS Saved Successfully");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFedEx_UPSSettings,Function :btnUPSSave_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
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

        private void FrmFedEx_UPSSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ClsCommon.objFedEx_UPSSettings.Hide();
                ClsCommon.objFedEx_UPSSettings.Parent = null;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFedEx_UPSSettings,Function :FrmFedEx_UPSSettings_FormClosing. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}