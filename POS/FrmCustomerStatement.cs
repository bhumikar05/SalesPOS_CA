using ClosedXML.Excel;
using CrystalDecisions.CrystalReports.Engine;
using DocumentFormat.OpenXml.Drawing.Charts;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Markup;
using Telerik.WinControls.Drawing;
using DataTable = System.Data.DataTable;

namespace POS
{
    public partial class FrmCustomerStatement : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtCustomer = new DataTable();
        BALCustomerMaster objBALCustomer = new BALCustomerMaster();
        BOLCustomerMaster objBOLCustomer = new BOLCustomerMaster();
        DataTable dtDetail = new DataTable();
        DataTable dtDayBalance = new DataTable();
        string BillAddress = "";
        Decimal Total = 0;

        public FrmCustomerStatement()
        {
            InitializeComponent();
            GetCustomer();
        }
        public void GetCustomer()
        {
            try
            {
                if (ClsCommon.FunctionVisibility("CustomerNumberOnly", "CustomerCenter"))
                {
                    dtCustomer = new DataTable();
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = 0 , IsCustomerNumber = 0 });
                    else
                        dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = ClsCommon.UserID, IsCustomerNumber = 1 });
                }
                else
                {
                    dtCustomer = new DataTable();
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = 0, IsCustomerNumber = 0 });
                    else
                        dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = ClsCommon.UserID, IsCustomerNumber = 0 });
                }
                DataRow dr = dtCustomer.NewRow();
                dr["Customer"] = "--Select--";
                dr["ID"] = "0";
                dr["ActiveStatus"] = "0";
                dtCustomer.Rows.InsertAt(dr, 0);
                cmbCustomer.DataSource = dtCustomer;
                cmbCustomer.DisplayMember = "Customer";
                cmbCustomer.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :GetCustomer. Message:" + ex.Message);
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
                ClsCommon.WriteErrorLogs("Form:FrmCustomerSummaryReport,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }
        private void btnprint_Click(object sender, EventArgs e)
        {

            if (CheckValidation())
            {
                dtDetail = new DataTable();
                dtCustomer = new DataTable();
                dtDayBalance = new DataTable();
                dtDetail.Columns.Add("Balance");
                dtDetail.Columns.Add("INVNo");
                dtDetail.Columns.Add("TxnDate");
                dtDetail.Columns.Add("Amount");
                DataTable MergeData = new DataTable();
                MergeData.Columns.Add("Balance");
                MergeData.Columns.Add("INVNo");
                MergeData.Columns.Add("TxnDate");
                MergeData.Columns.Add("Amount");
                MergeData.Columns.Add("ReportDate");

                DataTable dtManuallyData = new BALInvoiceMaster().SelectByPay(new BOLInvoiceMaster() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                if (dtManuallyData.Rows.Count > 0)
                {
                    dtDetail.ImportRow(dtManuallyData.Rows[0]);
                    //int N = 0;
                    for (int i = 1; i < dtManuallyData.Rows.Count; i++)
                    {
                        dtDetail.ImportRow(dtManuallyData.Rows[i]);
                        string[] str = dtManuallyData.Rows[i]["INVNo"].ToString().Split('#');
                        string[] str1 = str[1].ToString().Split('.');

                        DataTable dtPayment = new BALInvoiceMaster().SelectByPayment(new BOLInvoiceMaster() { RefNumber = str1[0], StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                        if (dtPayment.Rows.Count > 0)
                        {
                            for (int b = 0; b < dtPayment.Rows.Count; b++)
                            {
                                dtDetail.ImportRow(dtPayment.Rows[b]);
                            }
                        }
                    }

                    //dtCustomer = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue)});
                    dtDetail.Columns["Balance"].ReadOnly = false;
                    dtDetail.Columns["TxnDate"].ReadOnly = false;
                    dtDetail.Rows[0]["TxnDate"] = Convert.ToDateTime(dtpFromDate.Value.ToString("yyyy-MM-dd")).AddDays(-1).ToShortDateString();

                    dtDayBalance = new BALInvoiceMaster().SelectByDays(new BOLInvoiceMaster() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                    if (dtDayBalance.Rows.Count > 0)
                    {
                        decimal balance = 0;
                        balance = Convert.ToDecimal(dtDetail.Rows[0]["Balance"].ToString());
                        for (int i = 1; i < dtDetail.Rows.Count; i++)
                        {
                            balance += Convert.ToDecimal(dtDetail.Rows[i]["Amount"].ToString());
                            dtDetail.Rows[i]["Balance"] = balance.ToString();
                            dtDetail.AcceptChanges();
                        }
                        dtDetail.Columns.Add("ReportDate");
                        dtDetail.Rows[0]["ReportDate"] = dtpToDate.Value.ToShortDateString();
                        dtDayBalance.Columns.Add("FromDate");
                        dtDayBalance.Columns.Add("ToDate");
                        dtDayBalance.Rows[0]["FromDate"] = dtpFromDate.Value.ToShortDateString();
                        dtDayBalance.Rows[0]["ToDate"] = dtpToDate.Value.ToShortDateString(); ;



                        foreach (DataRow row in dtDetail.Rows)
                        {
                            if (DateTime.TryParse(row["TxnDate"].ToString(), out DateTime dateValue))
                            {
                                // Convert the date to the desired format (MM-dd-yyyy) and update the column
                                row["TxnDate"] = dateValue.ToString("MM-dd-yyyy");
                            }
                            else
                            {
                                // Handle invalid date values if necessary
                                row["TxnDate"] = ""; // Or set a default value like "01-01-2000"
                            }
                        }
                       
                        MergeData.ImportRow(dtDetail.Rows[0]);
                        for (int i = 1; i < dtDetail.Rows.Count; i++)
                        {
                            if (dtDetail.Rows[i]["INVNo"].ToString().Contains("INV") == true)
                            {

                                MergeData.ImportRow(dtDetail.Rows[i]);

                                string[] str = dtDetail.Rows[i]["INVNo"].ToString().Split('#');
                                string[] str1 = str[1].ToString().Split('.');
                                DataTable dtItemDetails = new BALInvoiceMaster().SelectByPayItem(new BOLInvoiceMaster() { RefNumber = str1[0], StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                                if (dtItemDetails.Rows.Count > 0)
                                {


                                    for (int b = 0; b < dtItemDetails.Rows.Count; b++)
                                    {
                                        if (dtItemDetails.Rows[b][0] != DBNull.Value || dtItemDetails.Rows[b][0].ToString() != "")
                                        {
                                            MergeData.ImportRow(dtItemDetails.Rows[b]);
                                        }

                                    }
                                }

                                DataTable dtTax = new BALInvoiceMaster().SelectByPayTax(new BOLInvoiceMaster() { RefNumber = str1[0], StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                                if (dtTax.Rows.Count > 0)
                                {
                                    for (int b = 0; b < dtTax.Rows.Count; b++)
                                    {

                                        MergeData.ImportRow(dtTax.Rows[b]);

                                    }
                                }

                            }
                            else if(dtDetail.Rows[i]["INVNo"].ToString().Contains("PAY") == true)
                            {
                                MergeData.ImportRow(dtDetail.Rows[i]);
                            }
                        }
                        rptCustomerStatementReport cryrptCustomerStatementReport = new rptCustomerStatementReport();
                        cryrptCustomerStatementReport.Database.Tables[0].SetDataSource(MergeData);
                        cryrptCustomerStatementReport.Database.Tables[1].SetDataSource(dtDayBalance);
                        FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                        crViewer.crystalReportViewer.ReportSource = cryrptCustomerStatementReport;
                        crViewer.Show();
                    }
                    else
                    {
                        MessageBox.Show("No records found");
                    }
                }
                else
                {
                    MessageBox.Show("No records found");
                }
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                dtDetail = new DataTable();
                dtCustomer = new DataTable();
                dtDayBalance = new DataTable();
                dtDetail.Columns.Add("Balance");
                dtDetail.Columns.Add("INVNo");
                dtDetail.Columns.Add("TxnDate");
                dtDetail.Columns.Add("Amount");
                DataTable MergeData = new DataTable();
                MergeData.Columns.Add("Balance");
                MergeData.Columns.Add("INVNo");
                MergeData.Columns.Add("TxnDate");
                MergeData.Columns.Add("Amount");
                MergeData.Columns.Add("ReportDate");

                DataTable dtManuallyData = new BALInvoiceMaster().SelectByPay(new BOLInvoiceMaster() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                if (dtManuallyData.Rows.Count > 0)
                {
                    dtDetail.ImportRow(dtManuallyData.Rows[0]);
                    //int N = 0;
                    for (int i = 1; i < dtManuallyData.Rows.Count; i++)
                    {
                        dtDetail.ImportRow(dtManuallyData.Rows[i]);
                        string[] str = dtManuallyData.Rows[i]["INVNo"].ToString().Split('#');
                        string[] str1 = str[1].ToString().Split('.');

                        DataTable dtPayment = new BALInvoiceMaster().SelectByPayment(new BOLInvoiceMaster() { RefNumber = str1[0], StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                        if (dtPayment.Rows.Count > 0)
                        {
                            for (int b = 0; b < dtPayment.Rows.Count; b++)
                            {
                                dtDetail.ImportRow(dtPayment.Rows[b]);
                            }
                        }
                    }

                    //dtCustomer = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue)});
                    dtDetail.Columns["Balance"].ReadOnly = false;
                    dtDetail.Columns["TxnDate"].ReadOnly = false;
                    dtDetail.Rows[0]["TxnDate"] = Convert.ToDateTime(dtpFromDate.Value.ToString("yyyy-MM-dd")).AddDays(-1).ToShortDateString();
                    dtDayBalance = new BALInvoiceMaster().SelectByDays(new BOLInvoiceMaster() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                    if (dtDayBalance.Rows.Count > 0)
                    {
                        decimal balance = 0;
                        balance = Convert.ToDecimal(dtDetail.Rows[0]["Balance"].ToString());
                        for (int i = 1; i < dtDetail.Rows.Count; i++)
                        {
                            balance += Convert.ToDecimal(dtDetail.Rows[i]["Amount"].ToString());
                            dtDetail.Rows[i]["Balance"] = balance.ToString();
                            dtDetail.AcceptChanges();
                        }
                        dtDetail.Columns.Add("ReportDate");
                        dtDetail.Rows[0]["ReportDate"] = dtpToDate.Value.ToShortDateString();
                        dtDayBalance.Columns.Add("FromDate");
                        dtDayBalance.Columns.Add("ToDate");
                        dtDayBalance.Rows[0]["FromDate"] = dtpFromDate.Value.ToShortDateString();
                        dtDayBalance.Rows[0]["ToDate"] = dtpToDate.Value.ToShortDateString(); ;

                        foreach (DataRow row in dtDetail.Rows)
                        {
                            if (DateTime.TryParse(row["TxnDate"].ToString(), out DateTime dateValue))
                            {
                                // Convert the date to the desired format (MM-dd-yyyy) and update the column
                                row["TxnDate"] = dateValue.ToString("MM-dd-yyyy");
                            }
                            else
                            {
                                // Handle invalid date values if necessary
                                row["TxnDate"] = ""; // Or set a default value like "01-01-2000"
                            }
                        }

                        MergeData.ImportRow(dtDetail.Rows[0]);
                        for (int i = 1; i < dtDetail.Rows.Count; i++)
                        {
                            if (dtDetail.Rows[i]["INVNo"].ToString().Contains("INV") == true)
                            {

                                MergeData.ImportRow(dtDetail.Rows[i]);

                                string[] str = dtDetail.Rows[i]["INVNo"].ToString().Split('#');
                                string[] str1 = str[1].ToString().Split('.');
                                DataTable dtItemDetails = new BALInvoiceMaster().SelectByPayItem(new BOLInvoiceMaster() { RefNumber = str1[0], StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                                if (dtItemDetails.Rows.Count > 0)
                                {

                                    for (int b = 0; b < dtItemDetails.Rows.Count; b++)
                                    {
                                        if (dtItemDetails.Rows[b][0] != DBNull.Value || dtItemDetails.Rows[b][0].ToString() != "")
                                        {
                                            MergeData.ImportRow(dtItemDetails.Rows[b]);
                                        }
                                    }
                                }

                                DataTable dtTax = new BALInvoiceMaster().SelectByPayTax(new BOLInvoiceMaster() { RefNumber = str1[0], StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                                if (dtTax.Rows.Count > 0)
                                {
                                    for (int b = 0; b < dtTax.Rows.Count; b++)
                                    {

                                        MergeData.ImportRow(dtTax.Rows[b]);

                                    }
                                }

                            }
                            else if (dtDetail.Rows[i]["INVNo"].ToString().Contains("PAY") == true)
                            {
                                MergeData.ImportRow(dtDetail.Rows[i]);
                            }
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
                            wb.Worksheets.Add(MergeData, "Sheet1");
                            wb.Worksheets.Add(dtDayBalance, "Sheet2");
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
                else
                {
                    MessageBox.Show("No records found");
                }
            }
        }
        private void btnEmail_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                dtDetail = new DataTable();
                dtCustomer = new DataTable();
                dtDayBalance = new DataTable();
                dtDetail.Columns.Add("Balance");
                dtDetail.Columns.Add("INVNo");
                dtDetail.Columns.Add("TxnDate");
                dtDetail.Columns.Add("Amount");
                DataTable MergeData = new DataTable();
                MergeData.Columns.Add("Balance");
                MergeData.Columns.Add("INVNo");
                MergeData.Columns.Add("TxnDate");
                MergeData.Columns.Add("Amount");
                MergeData.Columns.Add("ReportDate");

                DataTable dtManuallyData = new BALInvoiceMaster().SelectByPay(new BOLInvoiceMaster() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                if (dtManuallyData.Rows.Count > 0)
                {
                    dtDetail.ImportRow(dtManuallyData.Rows[0]);
                    //int N = 0;
                    for (int i = 1; i < dtManuallyData.Rows.Count; i++)
                    {
                        dtDetail.ImportRow(dtManuallyData.Rows[i]);
                        string[] str = dtManuallyData.Rows[i]["INVNo"].ToString().Split('#');
                        string[] str1 = str[1].ToString().Split('.');

                        DataTable dtPayment = new BALInvoiceMaster().SelectByPayment(new BOLInvoiceMaster() { RefNumber = str1[0], StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                        if (dtPayment.Rows.Count > 0)
                        {
                            for (int b = 0; b < dtPayment.Rows.Count; b++)
                            {
                                dtDetail.ImportRow(dtPayment.Rows[b]);
                            }
                        }
                    }

                    //dtCustomer = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue)});
                    dtDetail.Columns["Balance"].ReadOnly = false;
                    dtDetail.Columns["TxnDate"].ReadOnly = false;
                    dtDetail.Rows[0]["TxnDate"] = Convert.ToDateTime(dtpFromDate.Value.ToString("yyyy-MM-dd")).AddDays(-1).ToShortDateString();

                    dtDayBalance = new BALInvoiceMaster().SelectByDays(new BOLInvoiceMaster() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                    if (dtDayBalance.Rows.Count > 0)
                    {
                        decimal balance = 0;
                        balance = Convert.ToDecimal(dtDetail.Rows[0]["Balance"].ToString());
                        for (int i = 1; i < dtDetail.Rows.Count; i++)
                        {
                            balance += Convert.ToDecimal(dtDetail.Rows[i]["Amount"].ToString());
                            dtDetail.Rows[i]["Balance"] = balance.ToString();
                            dtDetail.AcceptChanges();
                        }
                        dtDetail.Columns.Add("ReportDate");
                        dtDetail.Rows[0]["ReportDate"] = dtpToDate.Value.ToShortDateString();
                        dtDayBalance.Columns.Add("FromDate");
                        dtDayBalance.Columns.Add("ToDate");
                        dtDayBalance.Rows[0]["FromDate"] = dtpFromDate.Value.ToShortDateString();
                        dtDayBalance.Rows[0]["ToDate"] = dtpToDate.Value.ToShortDateString(); ;



                        foreach (DataRow row in dtDetail.Rows)
                        {
                            if (DateTime.TryParse(row["TxnDate"].ToString(), out DateTime dateValue))
                            {
                                // Convert the date to the desired format (MM-dd-yyyy) and update the column
                                row["TxnDate"] = dateValue.ToString("MM-dd-yyyy");
                            }
                            else
                            {
                                // Handle invalid date values if necessary
                                row["TxnDate"] = ""; // Or set a default value like "01-01-2000"
                            }
                        }

                        MergeData.ImportRow(dtDetail.Rows[0]);
                        for (int i = 1; i < dtDetail.Rows.Count; i++)
                        {
                            if (dtDetail.Rows[i]["INVNo"].ToString().Contains("INV") == true)
                            {
                                MergeData.ImportRow(dtDetail.Rows[i]);
                                string[] str = dtDetail.Rows[i]["INVNo"].ToString().Split('#');
                                string[] str1 = str[1].ToString().Split('.');
                                DataTable dtItemDetails = new BALInvoiceMaster().SelectByPayItem(new BOLInvoiceMaster() { RefNumber = str1[0], StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                                if (dtItemDetails.Rows.Count > 0)
                                {
                                    for (int b = 0; b < dtItemDetails.Rows.Count; b++)
                                    {
                                        if (dtItemDetails.Rows[b][0] != DBNull.Value || dtItemDetails.Rows[b][0].ToString() != "")
                                        {
                                            MergeData.ImportRow(dtItemDetails.Rows[b]);
                                        }
                                    }
                                }

                                DataTable dtTax = new BALInvoiceMaster().SelectByPayTax(new BOLInvoiceMaster() { RefNumber = str1[0], StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                                if (dtTax.Rows.Count > 0)
                                {
                                    for (int b = 0; b < dtTax.Rows.Count; b++)
                                    {
                                        MergeData.ImportRow(dtTax.Rows[b]);
                                    }
                                }

                            }
                            else if (dtDetail.Rows[i]["INVNo"].ToString().Contains("PAY") == true)
                            {
                                MergeData.ImportRow(dtDetail.Rows[i]);
                            }
                        }
                    //rptCustomerStatementReport cryrptCustomerStatementReport = new rptCustomerStatementReport();
                    //cryrptCustomerStatementReport.Database.Tables[0].SetDataSource(MergeData);
                    //cryrptCustomerStatementReport.Database.Tables[1].SetDataSource(dtDayBalance);
                    //FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                    //crViewer.crystalReportViewer.ReportSource = cryrptCustomerStatementReport;
                    //crViewer.Show();


                    
                        ReportDocument reportDocument = new ReportDocument();
                        reportDocument.Load(Application.StartupPath + "\\Report\\rptCustomerStatementReport.rpt");
                        //reportDocument.SetDataSource(MergeData);
                        //reportDocument.SetDataSource(dtDayBalance);
                        reportDocument.Database.Tables[0].SetDataSource(MergeData);
                        reportDocument.Database.Tables[1].SetDataSource(dtDayBalance);
                        reportDocument.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + @"\PrintReport\" + "Customer_Statement_" + cmbCustomer.Text + ".pdf");


                        FrmEmailTemplateList obj = new FrmEmailTemplateList();
                        DataTable dtCus = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                        if (dtCus.Rows.Count > 0)
                        {
                            
                          obj.EmialCustomerStatement("Customer Statement", dtCus.Rows[0]["Email"].ToString(), Application.StartupPath + @"\PrintReport\" + "Customer_Statement_" + cmbCustomer.Text + ".pdf", cmbCustomer.SelectedValue.ToString());
                            
                        }
                        obj.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No records found");
                    }
                }
                else
                {
                    MessageBox.Show("No records found");
                }
            }
        }
    }
}   