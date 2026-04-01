using DocumentFormat.OpenXml.Spreadsheet;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmUPSSettings : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BOLAccessUPSSettings BOLAccessUPSSettings = new BOLAccessUPSSettings();
        BALAccessUPSSettings BALAccessUPSSettings = new BALAccessUPSSettings();
        DataTable dt = new DataTable();
        string Copies = "";
        string Landscape = "";
        string Margins = "";
        string PaperSize = "";
        string PaperSource = "";
        string PrinterResolution = "";
        public FrmUPSSettings()
        {
            InitializeComponent();
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(0, 0);
        }

        private void FrmUPSSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ClsCommon.FrmUPSSettings.Hide();
                ClsCommon.FrmUPSSettings.Parent = null;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "E");
                ClsCommon.WriteErrorLogs("Form: FrmUPSSettings, Function: FrmUPSSettings_FormClosing, Message:" + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (CheckValidation())
                {
                    dt = new BALAccessUPSSettings().Select(Convert.ToInt32(ClsCommon.UserID));
                    if (dt.Rows.Count > 0)
                    {
                        BOLAccessUPSSettings.ID = ClsCommon.UserID;
                        if (chkNegotiatedRate.Checked == true)
                        {
                            BOLAccessUPSSettings.NegotiatedRate = 1;
                        }
                        else
                        {
                            BOLAccessUPSSettings.NegotiatedRate = 0;
                        }
                        if (chkCOD.Checked == true)
                        {
                            BOLAccessUPSSettings.COD = 1;
                        }
                        else
                        {
                            BOLAccessUPSSettings.COD = 0;
                        }
                        if (chkDeliveryConfirmation.Checked == true)
                        {
                            BOLAccessUPSSettings.DeliveryConfirmation = 1;
                        }
                        else
                        {
                            BOLAccessUPSSettings.DeliveryConfirmation = 0;
                        }
                        if (chkotherservice.Checked == true)
                        {
                            BOLAccessUPSSettings.OtherService = 1;
                        }
                        else
                        {
                            BOLAccessUPSSettings.OtherService = 0;
                        }
                        BOLAccessUPSSettings.PrinterName = txtName.Text;

                        BOLAccessUPSSettings.Copies = Copies;
                        BOLAccessUPSSettings.Landscape = Landscape;
                        BOLAccessUPSSettings.Margins = Margins;
                        BOLAccessUPSSettings.PaperSize = PaperSize;
                        BOLAccessUPSSettings.PaperSource = PaperSource;
                        BOLAccessUPSSettings.PrinterResolution = PrinterResolution;
                        BALAccessUPSSettings.Update(BOLAccessUPSSettings);
                        MessageBox.Show("Update Successfully");
                    }
                    else
                    {
                        BOLAccessUPSSettings.ID = ClsCommon.UserID;
                        if (chkNegotiatedRate.Checked == true)
                        {
                            BOLAccessUPSSettings.NegotiatedRate = 1;
                        }
                        else
                        {
                            BOLAccessUPSSettings.NegotiatedRate = 0;
                        }
                        if (chkCOD.Checked == true)
                        {
                            BOLAccessUPSSettings.COD = 1;
                        }
                        else
                        {
                            BOLAccessUPSSettings.COD = 0;
                        }
                        if (chkDeliveryConfirmation.Checked == true)
                        {
                            BOLAccessUPSSettings.DeliveryConfirmation = 1;
                        }
                        else
                        {
                            BOLAccessUPSSettings.DeliveryConfirmation = 0;
                        }
                        if (chkotherservice.Checked == true)
                        {
                            BOLAccessUPSSettings.OtherService = 1;
                        }
                        else
                        {
                            BOLAccessUPSSettings.OtherService = 0;
                        }
                        BOLAccessUPSSettings.PrinterName = txtName.Text;
                        BOLAccessUPSSettings.Copies = Copies;
                        BOLAccessUPSSettings.Landscape = Landscape;
                        BOLAccessUPSSettings.Margins = Margins;
                        BOLAccessUPSSettings.PaperSize = PaperSize;
                        BOLAccessUPSSettings.PaperSource = PaperSource;
                        BOLAccessUPSSettings.PrinterResolution = PrinterResolution;
                        BALAccessUPSSettings.Insert(BOLAccessUPSSettings);
                        MessageBox.Show("Save Successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "E");
                ClsCommon.WriteErrorLogs("Form: FrmUPSSettings, Function: btnSave_Click, Message:" + ex.Message);
            }

        }

        private void FrmUPSSettings_Load(object sender, EventArgs e)
        {
            Display();
        }
        public void Display()
        {
            try
            {
                dt = new BALAccessUPSSettings().Select(Convert.ToInt32(ClsCommon.UserID));
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["NegotiatedRate"].ToString() == "1")
                    {
                        chkNegotiatedRate.Checked = true;
                    }
                    else
                    {
                        chkNegotiatedRate.Checked = false;
                    }
                    if (dt.Rows[0]["COD"].ToString() == "1")
                    {
                        chkCOD.Checked = true;
                    }
                    else
                    {
                        chkCOD.Checked = false;

                    }
                    if (dt.Rows[0]["DeliveryConfirmation"].ToString() == "1")
                    {
                        chkDeliveryConfirmation.Checked = true;
                    }
                    else
                    {
                        chkDeliveryConfirmation.Checked = false;
                    }
                    if (dt.Rows[0]["OtherService"].ToString() == "1")
                    {
                        chkotherservice.Checked = true;
                    }
                    else
                    {
                        chkotherservice.Checked = false;
                    }
                    txtName.Text = dt.Rows[0]["PrinterName"].ToString();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "E");
                ClsCommon.WriteErrorLogs("Form: FrmUPSSettings, Function: Display, Message:" + ex.Message);
            }
        }

        private void btnPrinterSettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtName.Text = printDialog1.PrinterSettings.PrinterName;
                    Copies= printDialog1.PrinterSettings.Copies.ToString();
                    Landscape = printDialog1.PrinterSettings.DefaultPageSettings.Landscape.ToString();
                    Margins = printDialog1.PrinterSettings.DefaultPageSettings.Margins.ToString();
                    PaperSize = printDialog1.PrinterSettings.DefaultPageSettings.PaperSize.ToString();
                    PaperSource= printDialog1.PrinterSettings.DefaultPageSettings.PaperSource.ToString();
                    PrinterResolution = printDialog1.PrinterSettings.PrinterResolutions.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "E");
                ClsCommon.WriteErrorLogs("Form: FrmUPSSettings, Function: btnPrinterSettings_Click, Message:" + ex.Message);
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
                    MessageBox.Show("Please Select Printer", "E");
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
                MessageBox.Show("Error:" + ex.Message, "E");

                return ISValid;
            }
        }
    }
}