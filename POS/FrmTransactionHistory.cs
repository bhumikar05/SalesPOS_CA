using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.Report;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmTransactionHistory : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public string InvoiceID = "";
        DataTable dtPayment = new DataTable();

        public FrmTransactionHistory()
        {
            InitializeComponent();
        }

        private void FrmTransactionHistory_Load(object sender, EventArgs e)
        {
            try
            {
                if (InvoiceID != "")
                {
                    txtID.Text = "";
                    dtPayment = new DataTable();
                    dtPayment = new BALInvoiceMaster().SelectByID(new BOLInvoiceMaster() { ID = Convert.ToInt32(InvoiceID) });
                    if (dtPayment.Rows.Count > 0)
                    {
                        txtID.Text = dtPayment.Rows[0]["ID"].ToString();
                        lblCustomer.Text = dtPayment.Rows[0]["CustomerFullName"].ToString();
                        lblInvoiceDate.Text = Convert.ToDateTime(dtPayment.Rows[0]["TxnDate"].ToString()).ToString("MM-dd-yyyy");
                        lblInvoiceNo.Text = dtPayment.Rows[0]["RefNumber"].ToString();
                        lblMemo.Text = dtPayment.Rows[0]["Memo"].ToString();
                        lblInvoiceTotal.Text = dtPayment.Rows[0]["Total"].ToString();
                    }
                    this.dgvPaymentList.DefaultCellStyle.Font = new Font("", 10);
                    dgvPaymentList.RowTemplate.Height = 24;

                    LoadPaymentDetails();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmTransactionHistory,Function :FrmTransactionHistory_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void LoadPaymentDetails()
        {
            try
            {
                if (dtPayment.Rows.Count > 0)
                {
                    dgvPaymentList.Rows.Clear();
                    dgvPaymentList.Rows.Add();
                    dgvPaymentList.Rows[0].Cells[0].Value = dtPayment.Rows[0]["ID"].ToString();
                    dgvPaymentList.Rows[0].Cells[1].Value = "Payment";
                    dgvPaymentList.Rows[0].Cells[2].Value = Convert.ToDateTime(dtPayment.Rows[0]["TxnDate"].ToString()).ToString("MM-dd-yyyy");
                    dgvPaymentList.Rows[0].Cells[3].Value = Convert.ToDecimal(dtPayment.Rows[0]["Total"].ToString());
                    dgvPaymentList.Rows[0].Cells[4].Value = Convert.ToDecimal(dtPayment.Rows[0]["AppliedAmount"].ToString());
                    dgvPaymentList.Rows[0].Cells[5].Value = Convert.ToDecimal(dtPayment.Rows[0]["BalanceDue"].ToString());
                }
                else
                    dgvPaymentList.Rows.Clear();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmTransactionHistory,Function :LoadPaymentDetails. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void pnlInvoiceDetails_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pnlInvoiceDetails.ClientRectangle, Color.Gainsboro, ButtonBorderStyle.Solid);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtPayment.Rows.Count > 0)
                {
                    rptTransactionHistoryReport cryRptTransactionHistory = new rptTransactionHistoryReport();
                    cryRptTransactionHistory.Database.Tables[0].SetDataSource(dtPayment);
                    cryRptTransactionHistory.SetParameterValue("CustomerName", lblCustomer.Text);
                    cryRptTransactionHistory.SetParameterValue("InvoiceDate", lblInvoiceDate.Text);
                    cryRptTransactionHistory.SetParameterValue("InvoiceNo", lblInvoiceNo.Text);
                    cryRptTransactionHistory.SetParameterValue("Memo", lblMemo.Text);
                    cryRptTransactionHistory.SetParameterValue("InvoiceTotal", lblInvoiceTotal.Text);
                    cryRptTransactionHistory.SetParameterValue("Type", "Payment");

                    FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                    crViewer.Text = "Invoice Transaction History Report";
                    crViewer.crystalReportViewer.ReportSource = cryRptTransactionHistory;
                    crViewer.Show();
                }
                else
                {
                    MessageBox.Show("No records found");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmTransactionHistory,Function :btnPrint_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}