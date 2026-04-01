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
    public partial class FrmCustomerNotBoughtReport : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtDetail = new DataTable();

        public FrmCustomerNotBoughtReport()
        {
            InitializeComponent();
        }

        private void FrmCustomerNotBoughtReport_Load(object sender, EventArgs e)
        {
            try
            {
                dtpFromDate.Format = DateTimePickerFormat.Custom;
                dtpFromDate.CustomFormat = "MM/dd/yyyy";

                dtpToDate.Format = DateTimePickerFormat.Custom;
                dtpToDate.CustomFormat = "MM/dd/yyyy";

                Clear();
                dtpFromDate.Value = DateTime.Now.AddDays(-29);
                dtpToDate.Value = DateTime.Now;
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerNotBoughtReport,Function :FrmCustomerNotBoughtReport_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
           
        }

        private void Clear()
        {
            rdbThirtyDays.Checked = false;
            rdbSixtyDays.Checked = false;
            rdbNintyDays.Checked = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
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
                //if (rdbThirteenDays.Checked == false && rdbSixteenDays.Checked == false && rdbNinteenDays.Checked == false)
                //{
                //    ISValid = false;
                //    MessageBox.Show("Please Select 30 or 60 or 90 Days", "W");
                //    rdbThirteenDays.Focus();
                //}
                else
                    ISValid = true;

                Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerNotBoughtReport,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("Print", "CustomerSaleHistory"))
                {
                    if (CheckValidation())
                    {
                        dtDetail = new DataTable();
                        dtDetail = new BALItemSaleHistory().SelectCustomerSaleHistory(new BOLItemSaleHistory() { FromDate = dtpFromDate.Value, ToDate = dtpToDate.Value });
                        if (dtDetail.Rows.Count > 0)
                        {
                            rptCustomerSaleHistoryReport cryRptCustomerSaleHistoryReport = new rptCustomerSaleHistoryReport();
                            cryRptCustomerSaleHistoryReport.Database.Tables[0].SetDataSource(dtDetail);
                            FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                            crViewer.Text = "Customer History Report";
                            crViewer.crystalReportViewer.ReportSource = cryRptCustomerSaleHistoryReport;
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
                ClsCommon.WriteErrorLogs("Form:FrmCustomerNotBoughtReport,Function :btnPrint_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void rdbThirtyDays_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtpFromDate.Value = DateTime.Now.AddDays(-30);
                dtpToDate.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerNotBoughtReport,Function :rdbThirtyDays_CheckedChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void rdbSixtyDays_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtpFromDate.Value = DateTime.Now.AddDays(-60);
                dtpToDate.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerNotBoughtReport,Function :rdbSixtyDays_CheckedChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void rdbNintyDays_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtpFromDate.Value = DateTime.Now.AddDays(-90);
                dtpToDate.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerNotBoughtReport,Function :rdbNintyDays_CheckedChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            if (ClsCommon.FunctionVisibility("Print", "CustomerSaleHistory"))
            {
                if (CheckValidation())
                {
                    dtDetail = new DataTable();
                    dtDetail = new BALItemSaleHistory().SelectCustomerSaleHistory(new BOLItemSaleHistory() { FromDate = dtpFromDate.Value, ToDate = dtpToDate.Value });
                    if (dtDetail.Rows.Count > 0)
                    {
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