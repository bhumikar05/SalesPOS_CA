using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using POS.BAL;
using POS.BOL;

namespace POS
{
    public partial class FrmPrinterSetting : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALPrinterSetting ObjPrinterBAL = new BALPrinterSetting();
        BOLPrinterSetting ObjPrinterBOL = new BOLPrinterSetting();      
        public FrmPrinterSetting() 
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
            Boolean ISValid = false;
            try
            {
                if (txtName.Text == "")
                {
                    ISValid = false;
                    DisplayMessage("Please Select Printer", "E");
                    txtName.Focus();
                    goto Final;
                }              
                else
                    ISValid = true;

                Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                DisplayMessage("Error:" + ex.Message, "E");
                return ISValid;
            }
        }

        public void Display()
        {
            try
            {
                lblErrorMsg.Text = "";
                DataTable dt1 = ObjPrinterBAL.Select();
                if (dt1.Rows.Count > 0)
                {
                    txtName.Text = dt1.Rows[0]["Name"].ToString();
                }

            }
            catch (Exception ex)
            {
                DisplayMessage("Error:" + ex.Message, "E");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            try
            {
                if (CheckValidation())
                {
                    DataTable dt1 = ObjPrinterBAL.Select();
                    if(dt1.Rows.Count == 0)
                    {
                        ObjPrinterBOL.ID = 0;
                        ObjPrinterBOL.Name = txtName.Text;
                        ObjPrinterBAL.Insert(ObjPrinterBOL);
                        DisplayMessage("Record save successfully", "I");
                    }
                    else
                    {
                        ObjPrinterBOL.ID = Convert.ToInt32(dt1.Rows[0]["ID"].ToString());
                        ObjPrinterBOL.Name = txtName.Text;
                        ObjPrinterBAL.Insert(ObjPrinterBOL);
                        DisplayMessage("Record save successfully", "I");
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayMessage("Error:" + ex.Message, "E");
            }
        }
        private void btnPrinterSettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtName.Text = printDialog1.PrinterSettings.PrinterName;
                }
            }
            catch(Exception ex)
            {
                DisplayMessage("Error:" + ex.Message, "E");
            }
           
        }

        private void FrmPrinterSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.Parent = null;
        }
    }
}