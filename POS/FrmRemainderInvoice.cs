using ClosedXML.Excel;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.Report;
using System;
using System.Configuration;
using System.Data;
using System.Net.Mail;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace POS
{
    public partial class FrmRemainderInvoiceReport : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtDetail = new DataTable();
        Decimal Total = 0;

        public FrmRemainderInvoiceReport()
        {
            InitializeComponent();
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(0, 0);
        }

       

        private Boolean CheckValidation()
        {
            Boolean ISValid = false;
            try
            {
                if (rdbAll.Checked == false && rdbDue.Checked == false)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select Option");
                    rdbAll.Focus();
                    goto Final;
                }
                else
                    ISValid = true;

                Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmRemainderInvoiceReport,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            DataTable dtCustomer = new DataTable();
            try
            {
                if(CheckValidation())
                {
                    if(rdbAll.Checked == true)
                    {
                       
                        if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                            dtCustomer = new BALCustomerMaster().SelectCus(new BOLCustomerMaster() { SalesRepID = 0 });
                        else
                            dtCustomer = new BALCustomerMaster().SelectCus(new BOLCustomerMaster() { SalesRepID = ClsCommon.UserID });
                        if (dtCustomer.Rows.Count > 0)
                        {
                            rptRemainderInv cryRptCustomerQuickReport = new rptRemainderInv();
                            cryRptCustomerQuickReport.Database.Tables[0].SetDataSource(dtCustomer);
                            //cryRptCustomerQuickReport.SetParameterValue("TagName", "Invoice");
                            FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
 
                            crViewer.Text = "Invoice Report";
                            crViewer.crystalReportViewer.ReportSource = cryRptCustomerQuickReport;
                            crViewer.Show();
                        }
                        else
                        {
                            MessageBox.Show("No records found");
                        }
                    }

                    else if(rdbDue.Checked == true)
                    {
                        
                        if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                            dtCustomer = new BALCustomerMaster().SelectBySalesRep(new BOLCustomerMaster() { SalesRepID = 0 });
                        else
                            dtCustomer = new BALCustomerMaster().SelectBySalesRep(new BOLCustomerMaster() { SalesRepID = ClsCommon.UserID });
                        if (dtCustomer.Rows.Count > 0)
                        {
                            foreach(DataRow dr in dtCustomer.Rows)
                            {
                                if(dr["RemainderDays"].ToString() == "" || dr["RemainderDays"].ToString() == "0")
                                {
                                    dr.Delete();
                                }
                            }
                            dtCustomer.AcceptChanges();
                            rptRemainderInv cryRptCustomerQuickReport = new rptRemainderInv();
                            cryRptCustomerQuickReport.Database.Tables[0].SetDataSource(dtCustomer);
                            //cryRptCustomerQuickReport.SetParameterValue("TagName", "Invoice");
                            FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                            crViewer.Text = "Invoice Report";
                            crViewer.crystalReportViewer.ReportSource = cryRptCustomerQuickReport;
                            crViewer.Show();
                        }
                        else
                        {
                            MessageBox.Show("No records found");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmRemainderInvoiceReport,Function :btnPrint_Click_1. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void FrmRemainderInvoiceReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.Parent = null;
        }

        private void rdbDue_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dtCustomer = new DataTable();
            if (CheckValidation())
            {
                if (rdbAll.Checked == true)
                {

                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtCustomer = new BALCustomerMaster().SelectCus(new BOLCustomerMaster() { SalesRepID = 0 });
                    else
                        dtCustomer = new BALCustomerMaster().SelectCus(new BOLCustomerMaster() { SalesRepID = ClsCommon.UserID });
                    if (dtCustomer.Rows.Count > 0)
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
                            wb.Worksheets.Add(dtCustomer, "Sheet1");
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

                else if (rdbDue.Checked == true)
                {

                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtCustomer = new BALCustomerMaster().SelectBySalesRep(new BOLCustomerMaster() { SalesRepID = 0 });
                    else
                        dtCustomer = new BALCustomerMaster().SelectBySalesRep(new BOLCustomerMaster() { SalesRepID = ClsCommon.UserID });
                    if (dtCustomer.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtCustomer.Rows)
                        {
                            if (dr["RemainderDays"].ToString() == "" || dr["RemainderDays"].ToString() == "0")
                            {
                                dr.Delete();
                            }
                        }
                        dtCustomer.AcceptChanges();
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
                            wb.Worksheets.Add(dtCustomer, "Sheet1");
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

        }
    }
}