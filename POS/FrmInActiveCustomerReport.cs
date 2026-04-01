using ClosedXML.Excel;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.Report;
using System;
using System.Data;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmInActiveCustomerReport : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtDetail = new DataTable();

        public FrmInActiveCustomerReport()
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

                GetSalesRep();
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInActiveCustomerReport,Function :FrmCustomerNotBoughtReport_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
           
        }

        private void GetSalesRep()
        {
            try
            {
                DataTable dtSalesRep = new BALSalesRepMaster().SelectUser(new BOLSalesRepMaster() { });
                DataRow dr = dtSalesRep.NewRow();
                dr["Name"] = "--Select--";
                dr["ID"] = "0";
                dtSalesRep.Rows.InsertAt(dr, 0);
                cmbSalesRep.DataSource = dtSalesRep;
                cmbSalesRep.DisplayMember = "Name";
                cmbSalesRep.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInActiveCustomerReport,Function :GetSalesRep. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void Clear()
        {
            txtDays.Text = "0";
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
                if (txtDays.Text == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter Days");
                    txtDays.Focus();
                    goto Final;
                }
                else if (txtDays.Text == "0")
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter Valid Days");
                    txtDays.Focus();
                    goto Final;
                }
                else if (Convert.ToDateTime(dtpToDate.Value).Date < Convert.ToDateTime(dtpFromDate.Value).Date)
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
                ClsCommon.WriteErrorLogs("Form:FrmInActiveCustomerReport,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("Print", "InActiveCustomers"))
                {


                    if (CheckValidation())
                    {
                        dtpFromDate.Value = DateTime.Now.AddDays(-Convert.ToInt32(txtDays.Text));
                        dtpToDate.Value = DateTime.Now;

                        dtDetail = new DataTable();
                        if (cmbSalesRep.SelectedIndex == 0)
                        {
                            dtDetail = new BALCustomerMaster().SelectInActiveCustomer(new BOLCustomerMaster() { FromDate = dtpFromDate.Value, ToDate = dtpToDate.Value });
                        }
                        else
                        {
                            dtDetail = new BALCustomerMaster().SelectInActiveCustomerSalesRep(new BOLCustomerMaster() { FromDate = dtpFromDate.Value, ToDate = dtpToDate.Value,SalesRepID=Convert.ToInt32(cmbSalesRep.SelectedValue.ToString()) });
                        }
                        if (dtDetail.Rows.Count > 0)
                        {
                            rptCustomerInActiveReport cryRptCustomerSaleHistoryReport = new rptCustomerInActiveReport();
                            cryRptCustomerSaleHistoryReport.Database.Tables[0].SetDataSource(dtDetail);
                            FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                            crViewer.Text = "InActive Customers";
                            crViewer.crystalReportViewer.ReportSource = cryRptCustomerSaleHistoryReport;
                            crViewer.btnExport.Visible = true;
                            crViewer.dtExport = dtDetail.Copy();
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
                ClsCommon.WriteErrorLogs("Form:FrmInActiveCustomerReport,Function :btnPrint_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void txtDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
                {
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInActiveCustomerReport,Function :txtDays_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void cmbSalesRep_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            if (ClsCommon.FunctionVisibility("Print", "InActiveCustomers"))
            {


                if (CheckValidation())
                {
                    dtpFromDate.Value = DateTime.Now.AddDays(-Convert.ToInt32(txtDays.Text));
                    dtpToDate.Value = DateTime.Now;

                    dtDetail = new DataTable();
                    if (cmbSalesRep.SelectedIndex == 0)
                    {
                        dtDetail = new BALCustomerMaster().SelectInActiveCustomer(new BOLCustomerMaster() { FromDate = dtpFromDate.Value, ToDate = dtpToDate.Value });
                    }
                    else
                    {
                        dtDetail = new BALCustomerMaster().SelectInActiveCustomerSalesRep(new BOLCustomerMaster() { FromDate = dtpFromDate.Value, ToDate = dtpToDate.Value, SalesRepID = Convert.ToInt32(cmbSalesRep.SelectedValue.ToString()) });
                    }
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