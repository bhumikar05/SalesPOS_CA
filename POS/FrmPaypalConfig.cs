using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmPaypalConfig : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        string apiResponse = "";
        public bool IsloginSuccess = false;

        public FrmPaypalConfig()
        {
            InitializeComponent();
        }      

        public void DisplayMessage(string Text, string Mode)
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
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean CheckValidation()
        {
            Boolean IsValid = true;
            if(txtClientID.Text=="")
            {
                DisplayMessage("Please enter ClientID first","E");
                txtClientID.Focus();
                IsValid = false;
            }
            else if (txtClientSecret.Text == "")
            {
                DisplayMessage("Please enter ClientSecret first", "E");
                txtClientSecret.Focus();
                IsValid = false;
            }
            return IsValid;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidation())
                {
                    apiResponse = ClsPaypal.GetPaypalAuthToken(txtClientID.Text, txtClientSecret.Text, dtDate.Value);
                    if(apiResponse.ToLower().Contains("error")==false)
                    {
                        DisplayMessage("Paypal Configuration save successfully in database..!!","I");
                    }
                    else
                    {
                        DisplayMessage(apiResponse, "E");
                        ClsCommon.WriteErrorLogs("Form:FrmPaypalConfig,Function :btnConfig_Click. Message:" + apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaypalConfig,Function :btnConfig_Click. Message:" + ex.Message);
                DisplayMessage("Error:" + ex.Message, "E");
            }
        }

        private void FrmPaypalConfig_Load(object sender, EventArgs e)
        {

        }
    }
}