using ClosedXML.Excel;
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
    public partial class FrmPaidInvoiceReport : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtDetail = new DataTable();

        public FrmPaidInvoiceReport()
        {
            InitializeComponent();
        }

        private void FrmPaidInvoiceReport_Load(object sender, EventArgs e)
        {
            try
            {
                dtpFromDate.Format = DateTimePickerFormat.Custom;
                dtpFromDate.CustomFormat = "MM/dd/yyyy";

                dtpToDate.Format = DateTimePickerFormat.Custom;
                dtpToDate.CustomFormat = "MM/dd/yyyy";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaidInvoiceReport,Function :FrmPaidInvoiceReport_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
               
            }
        }

        private Boolean CheckValidation()
        {
            Boolean ISValid = false;
            try
            {
                if (Convert.ToDateTime(dtpToDate.Value).Date < Convert.ToDateTime(dtpFromDate.Value).Date)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select Correct Date");
                    dtpToDate.Focus();
                    goto Final;
                }
                else
                    ISValid = true;

                Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaidInvoiceReport,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
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
                if (ClsCommon.FunctionVisibility("Print", "PaidInvoiceHistory"))
                {
                    if (CheckValidation())
                    {
                        dtDetail = new DataTable();
                        dtDetail = new BALInvoiceMaster().SelectPaidInvoice(new BOLInvoiceMaster() { FromDate = dtpFromDate.Value, ToDate = (dtpToDate.Value) });
                        if (dtDetail.Rows.Count > 0)
                        {

                            rptPaidInvoiceReport cryRptPaidInvoiceReport = new rptPaidInvoiceReport();
                            cryRptPaidInvoiceReport.Database.Tables[0].SetDataSource(dtDetail);
                            FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                            crViewer.Text = "Paid Invoice History Report";
                            crViewer.crystalReportViewer.ReportSource = cryRptPaidInvoiceReport;
                            crViewer.Show();
                        }
                        else
                        {
                            MessageBox.Show("No records found");
                        }
                    }
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaidInvoiceReport,Function :btnPrint_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);

            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (ClsCommon.FunctionVisibility("Print", "PaidInvoiceHistory"))
            {
                if (CheckValidation())
                {
                    dtDetail = new DataTable();
                    dtDetail = new BALInvoiceMaster().SelectPaidInvoice(new BOLInvoiceMaster() { FromDate = dtpFromDate.Value, ToDate = (dtpToDate.Value) });
                    if (dtDetail.Rows.Count > 0)
                    {
                        DataColumnCollection dcCollection = dtDetail.Columns;
                        if (dcCollection.Contains("AccountName"))
                        {
                            dcCollection.Remove("AccountName");
                        }


                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                        sfd.FilterIndex = 1;
                        sfd.RestoreDirectory = true;
                        sfd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "Excel//Book1.xlsx";

                        //if (sfd.ShowDialog() == DialogResult.OK)
                        //{
                        Cursor.Current = Cursors.WaitCursor;
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dtDetail, "Sheet1");
                            wb.SaveAs(sfd.InitialDirectory);
                        }
                        //MessageBox.Show("Export Successfully");
                        //}
                        var app = new Microsoft.Office.Interop.Excel.Application();
                        app.Visible = true;
                        app.Workbooks.Open(sfd.InitialDirectory, ReadOnly: false);
                    }
                    else
                    {
                        MessageBox.Show("No records found");
                    }
                }
            }
            else
                MessageBox.Show("You can not access");
        }
    }
}