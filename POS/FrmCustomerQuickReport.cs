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
    public partial class FrmCustomerQuickReport : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtDetail = new DataTable();
        public string CustomerID = "";

        public FrmCustomerQuickReport()
        {
            InitializeComponent();
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(0, 0);
        }

        private void FrmCustomerQuickReport_Load(object sender, EventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmCustomerQuickReport,Function :FrmCustomerQuickReport_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
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
                else
                    ISValid = true;

                Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerQuickReport,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidation())
                {
                    dtDetail = new DataTable();
                    dtDetail = new BALCustomerMaster().CustomerInvoiceList(new BOLCustomerMaster() { ID = Convert.ToInt32(CustomerID), StartDate = Convert.ToDateTime(dtpFromDate.Value).ToString("yyyy-MM-dd"), EndDate = Convert.ToDateTime(dtpToDate.Value).ToString("yyyy-MM-dd")});
                    if (dtDetail.Rows.Count > 0)
                    {
                        rptCustomerQuickReport cryRptCustomerQuickReport = new rptCustomerQuickReport();
                        cryRptCustomerQuickReport.Database.Tables[0].SetDataSource(dtDetail);

                        FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                        crViewer.Text = "Customer Quick Report";
                        crViewer.crystalReportViewer.ReportSource = cryRptCustomerQuickReport;
                        crViewer.Show();
                    }
                    else
                    {
                        MessageBox.Show("No records found");
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerQuickReport,Function :btnPrint_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

    }
}