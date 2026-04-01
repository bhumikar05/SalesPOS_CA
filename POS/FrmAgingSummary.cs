using ClosedXML.Excel;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.Report;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace POS
{
    public partial class FrmAgingSummary : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        decimal TotalCurrentBalance = 0;
        decimal TotalOneToThirty = 0;
        decimal TotalThirtyOneToSixty = 0;
        decimal TotalSixtyOneToNinety = 0;
        decimal TotalOverNinety = 0;
        decimal FinalTotal = 0;
        DataTable dt = new DataTable();

        public FrmAgingSummary()
        {
            InitializeComponent();
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(0, 0);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);
            return res;
        }

        private void FrmAgingSummary_Load(object sender, System.EventArgs e)
        {
            lblDate.Text = $"As of {DateTime.Now.ToString("MMMM dd, yyyy")}";
            LoadData();
        }

        public void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            dt = new BALCustomerMaster().SelectAgingReport();
            if (dt.Rows.Count > 0)
            {
                int j = 0;
                dgvRequestList.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvRequestList.Rows.Add();
                    dgvRequestList.Rows[j].Cells["CustomerName"].Value = dt.Rows[i]["CustomerName"].ToString();

                    TotalCurrentBalance += Convert.ToDecimal(dt.Rows[i]["CurrentBalance"].ToString());
                    dgvRequestList.Rows[j].Cells["Current"].Value = dt.Rows[i]["CurrentBalance"].ToString();

                    TotalOneToThirty += Convert.ToDecimal(dt.Rows[i]["1-30"].ToString());
                    dgvRequestList.Rows[j].Cells["OneToThirty"].Value = dt.Rows[i]["1-30"].ToString();

                    TotalThirtyOneToSixty += Convert.ToDecimal(dt.Rows[i]["31-60"].ToString());
                    dgvRequestList.Rows[j].Cells["ThirtyOneToSixty"].Value = dt.Rows[i]["31-60"].ToString();


                    TotalSixtyOneToNinety += Convert.ToDecimal(dt.Rows[i]["61-90"].ToString());
                    dgvRequestList.Rows[j].Cells["SixtyOneToNinety"].Value = dt.Rows[i]["61-90"].ToString();

                    TotalOverNinety += Convert.ToDecimal(dt.Rows[i][">90"].ToString());
                    dgvRequestList.Rows[j].Cells["OverNinety"].Value = dt.Rows[i][">90"].ToString();

                    FinalTotal += Convert.ToDecimal(dt.Rows[i]["Total"].ToString());
                    dgvRequestList.Rows[j].Cells["Total"].Value = dt.Rows[i]["Total"].ToString();

                    j++;
                }
            }
            else
                dgvRequestList.Rows.Clear();
            Cursor.Current = Cursors.Default;
            lblTotal.Text = dt.Rows.Count.ToString();
        }

        private void FrmAgingSummary_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClsCommon.ObjAgingSummary.Hide();
            ClsCommon.ObjAgingSummary.Parent = null;
            e.Cancel = true;
        }

        private void btnExport_Click(object sender, EventArgs e)
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
                wb.Worksheets.Add(dt, "Sheet1");
                wb.SaveAs(sfd.InitialDirectory);
            }
            //MessageBox.Show("Export Successfully");
            //}
            var app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            app.Workbooks.Open(sfd.InitialDirectory, ReadOnly: false);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string filterText = txtFilter.Text.Trim(); // Ensure no leading/trailing spaces
                string numericFilter = decimal.TryParse(filterText, out _) ? filterText : "NULL";

                // Construct the filter expression
                string filterExpression =
                    "CustomerName LIKE '%" + filterText.Replace("'", "''") + "%' OR " +
                    "CurrentBalance = " + numericFilter + " OR " +
                    "[31-60] = " + numericFilter + " OR " +
                    "[61-90] = " + numericFilter + " OR " +
                    "[>90] = " + numericFilter + " OR " +
                    "Total = " + numericFilter;
                DataRow[] row = dt.Select(filterExpression);

                if (row.Length > 0)
                {
                    DataTable dtNew = row.CopyToDataTable();
                    int j = 0;
                    dgvRequestList.Rows.Clear();
                    for (int i = 0; i < dtNew.Rows.Count; i++)
                    {
                        dgvRequestList.Rows.Add();
                        dgvRequestList.Rows[j].Cells["CustomerName"].Value = dtNew.Rows[i]["CustomerName"].ToString();
                        dgvRequestList.Rows[j].Cells["Current"].Value = dtNew.Rows[i]["CurrentBalance"].ToString();
                        dgvRequestList.Rows[j].Cells["OneToThirty"].Value = dtNew.Rows[i]["1-30"].ToString();
                        dgvRequestList.Rows[j].Cells["ThirtyOneToSixty"].Value = dtNew.Rows[i]["31-60"].ToString();
                        dgvRequestList.Rows[j].Cells["SixtyOneToNinety"].Value = dtNew.Rows[i]["61-90"].ToString();
                        dgvRequestList.Rows[j].Cells["OverNinety"].Value = dtNew.Rows[i][">90"].ToString();
                        dgvRequestList.Rows[j].Cells["Total"].Value = dtNew.Rows[i]["Total"].ToString();
                        j++;
                    }
                }
                else
                {
                    dgvRequestList.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemList,Function :txtFilter_TextChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                rptAgingReport cryRptAgingReport = new rptAgingReport();
                cryRptAgingReport.Database.Tables[0].SetDataSource(dt);
                cryRptAgingReport.SetParameterValue("TotalCurrentBalance", TotalCurrentBalance);
                cryRptAgingReport.SetParameterValue("TotalOneToThirty", TotalOneToThirty);
                cryRptAgingReport.SetParameterValue("TotalThirtyOneToSixty", TotalThirtyOneToSixty);
                cryRptAgingReport.SetParameterValue("TotalSixtyOneToNinety", TotalSixtyOneToNinety);
                cryRptAgingReport.SetParameterValue("TotalOverNinety", TotalOverNinety);
                cryRptAgingReport.SetParameterValue("FinalTotal", FinalTotal);
                FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                crViewer.Text = "Aging Report";
                crViewer.crystalReportViewer.ReportSource = cryRptAgingReport;
                crViewer.Show();
            }

            
        }
    }
}