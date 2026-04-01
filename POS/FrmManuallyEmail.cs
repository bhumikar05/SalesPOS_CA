using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using SalesPOS.BAL;
using SalesPOS.BOL;
using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmManuallyEmail : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALManuallyEmail BALManuallyEmail = new BALManuallyEmail();
        BOLManuallyEmail BOLManuallyEmail = new BOLManuallyEmail();
        DataTable dt = new DataTable();
        public FrmManuallyEmail()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                if (dt.Rows.Count > 0)
                {
                    BOLManuallyEmail.ID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                    BOLManuallyEmail.ConsolePath = txtApplicationPath.Text;
                    BOLManuallyEmail.FromDate = dtpFromDate.Value;
                    BOLManuallyEmail.ToDate = dtpTodate.Value;

                    BOLManuallyEmail.DailyShipTo=txtToDAILYSHIPUNSHIP.Text;
                    BOLManuallyEmail.DailyShipCC = txtCCDAILYSHIPUNSHIP.Text;
                    if(chkDAILYSHIPUNSHIP.Checked==true)
                    {
                        BOLManuallyEmail.DailyShipMail = 1;
                    }
                    else
                    {
                        BOLManuallyEmail.DailyShipMail = 0;
                    }

                    BOLManuallyEmail.ItemCodesTo=txtToNewItemCodes.Text;
                    BOLManuallyEmail.ItemCodesCC=txtCCNewItemCodes.Text;
                    if (chkNewItemCodes.Checked == true)
                    {
                        BOLManuallyEmail.ItemCodesMail = 1;
                    }
                    else
                    {
                        BOLManuallyEmail.ItemCodesMail = 0;
                    }

                    BOLManuallyEmail.ProfitReportTo=txtToInvoiceProfitReport.Text;
                    BOLManuallyEmail.ProfitReportCC = txtCCInvoiceProfitReport.Text;
                    if (chkInvoiceProfitReport.Checked == true)
                    {
                        BOLManuallyEmail.ProfitReportMail = 1;
                    }
                    else
                    {
                        BOLManuallyEmail.ProfitReportMail = 0;
                    }

                    BOLManuallyEmail.PaymentsAndCreditMemoTo=txtToPaymentsAndCreditMemo.Text;
                    BOLManuallyEmail.PaymentsAndCreditMemoCC=txtCCPaymentsAndCreditMemo.Text;
                    if (chkPaymentsAndCreditMemo.Checked == true)
                    {
                        BOLManuallyEmail.PaymentsAndCreditMemoMail = 1;
                    }
                    else
                    {
                        BOLManuallyEmail.PaymentsAndCreditMemoMail = 0;
                    }

                    BOLManuallyEmail.SummaryReportTo=txtToItemSummaryReport.Text;
                    BOLManuallyEmail.SummaryReportCC=txtCCItemSummaryReport.Text;
                    if (chkItemSummaryReport.Checked == true)
                    {
                        BOLManuallyEmail.SummaryReportMail = 1;
                    }
                    else
                    {
                        BOLManuallyEmail.SummaryReportMail = 0;
                    }

                    BALManuallyEmail.Update(BOLManuallyEmail);
                    MessageBox.Show("Update SuccessFully");

                }
                else
                {
                    BOLManuallyEmail.ConsolePath = txtApplicationPath.Text;
                    BOLManuallyEmail.FromDate = dtpFromDate.Value;
                    BOLManuallyEmail.ToDate = dtpTodate.Value;

                    BOLManuallyEmail.DailyShipTo = txtToDAILYSHIPUNSHIP.Text;
                    BOLManuallyEmail.DailyShipCC = txtCCDAILYSHIPUNSHIP.Text;
                    if (chkDAILYSHIPUNSHIP.Checked == true)
                    {
                        BOLManuallyEmail.DailyShipMail = 1;
                    }
                    else
                    {
                        BOLManuallyEmail.DailyShipMail = 0;
                    }

                    BOLManuallyEmail.ItemCodesTo = txtToNewItemCodes.Text;
                    BOLManuallyEmail.ItemCodesCC = txtCCNewItemCodes.Text;
                    if (chkNewItemCodes.Checked == true)
                    {
                        BOLManuallyEmail.ItemCodesMail = 1;
                    }
                    else
                    {
                        BOLManuallyEmail.ItemCodesMail = 0;
                    }

                    BOLManuallyEmail.ProfitReportTo = txtToInvoiceProfitReport.Text;
                    BOLManuallyEmail.ProfitReportCC = txtCCInvoiceProfitReport.Text;
                    if (chkInvoiceProfitReport.Checked == true)
                    {
                        BOLManuallyEmail.ProfitReportMail = 1;
                    }
                    else
                    {
                        BOLManuallyEmail.ProfitReportMail = 0;
                    }

                    BOLManuallyEmail.PaymentsAndCreditMemoTo = txtToPaymentsAndCreditMemo.Text;
                    BOLManuallyEmail.PaymentsAndCreditMemoCC = txtCCPaymentsAndCreditMemo.Text;
                    if (chkPaymentsAndCreditMemo.Checked == true)
                    {
                        BOLManuallyEmail.PaymentsAndCreditMemoMail = 1;
                    }
                    else
                    {
                        BOLManuallyEmail.PaymentsAndCreditMemoMail = 0;
                    }

                    BOLManuallyEmail.SummaryReportTo = txtToItemSummaryReport.Text;
                    BOLManuallyEmail.SummaryReportCC = txtCCItemSummaryReport.Text;
                    if (chkItemSummaryReport.Checked == true)
                    {
                        BOLManuallyEmail.SummaryReportMail = 1;
                    }
                    else
                    {
                        BOLManuallyEmail.SummaryReportMail = 0;
                    }
                    BALManuallyEmail.Insert(BOLManuallyEmail);
                    MessageBox.Show("Insert SuccessFully");
                }
                Loaddata();
            }
        }

        public bool Validation()
        {
            bool IsValid = false;
            if (txtApplicationPath.Text == "")
            {
                txtApplicationPath.Focus();
                MessageBox.Show("Please Enter ApplicationPath");
                IsValid = false;
            }
            else
            {
                IsValid = true;

            }
            return IsValid;
        }

        private void FrmManuallySyncPrint_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void FrmManuallySyncPrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.Parent = null;
        }

        private void btnRunApplication_Click(object sender, EventArgs e)
        {
            if (txtApplicationPath.Text!="")
            {
                System.Diagnostics.Process.Start(txtApplicationPath.Text);
            }
            else
            {
                MessageBox.Show("Please Enter ApplicationPath");
            }
        }
        public void Loaddata()
        {
            dt = BALManuallyEmail.Select();
            if (dt.Rows.Count > 0)
            {
                txtApplicationPath.Text = dt.Rows[0]["ConsolePath"].ToString();
                if (dt.Rows[0]["FromDate"].ToString() != "")
                {
                    dtpFromDate.Value = Convert.ToDateTime(dt.Rows[0]["FromDate"].ToString());
                }
                if (dt.Rows[0]["ToDate"].ToString() != "")
                {
                    dtpTodate.Value = Convert.ToDateTime(dt.Rows[0]["ToDate"].ToString());
                }
                txtToDAILYSHIPUNSHIP.Text =dt.Rows[0]["DailyShipTo"].ToString();
                txtCCDAILYSHIPUNSHIP.Text =dt.Rows[0]["DailyShipCC"].ToString();
                if(dt.Rows[0]["DailyShipMail"].ToString()=="1")
                {
                    chkDAILYSHIPUNSHIP.Checked = true;
                }
                else
                {
                    chkDAILYSHIPUNSHIP.Checked = false;
                }


                txtToNewItemCodes.Text = dt.Rows[0]["ItemCodesTo"].ToString();
                txtCCNewItemCodes.Text = dt.Rows[0]["ItemCodesCC"].ToString();
                if (dt.Rows[0]["ItemCodesMail"].ToString() == "1")
                {
                    chkNewItemCodes.Checked = true;
                }
                else
                {
                    chkNewItemCodes.Checked = false;
                }


                txtToInvoiceProfitReport.Text = dt.Rows[0]["ProfitReportTo"].ToString();
                txtCCInvoiceProfitReport.Text = dt.Rows[0]["ProfitReportCC"].ToString();
                if (dt.Rows[0]["ProfitReportMail"].ToString() == "1")
                {
                    chkInvoiceProfitReport.Checked = true;
                }
                else
                {
                    chkInvoiceProfitReport.Checked = false;
                }


                txtToPaymentsAndCreditMemo.Text = dt.Rows[0]["PaymentsAndCreditMemoTo"].ToString();
                txtCCPaymentsAndCreditMemo.Text = dt.Rows[0]["PaymentsAndCreditMemoCC"].ToString();
                if (dt.Rows[0]["PaymentsAndCreditMemoMail"].ToString() == "1")
                {
                    chkPaymentsAndCreditMemo.Checked = true;
                }
                else
                {
                    chkPaymentsAndCreditMemo.Checked = false;
                }

                txtToItemSummaryReport.Text = dt.Rows[0]["SummaryReportTo"].ToString();
                txtCCItemSummaryReport.Text = dt.Rows[0]["SummaryReportCC"].ToString();
                if (dt.Rows[0]["SummaryReportMail"].ToString() == "1")
                {
                    chkItemSummaryReport.Checked = true;
                }
                else
                {
                    chkItemSummaryReport.Checked = false;
                }
            }
        }
    }
}