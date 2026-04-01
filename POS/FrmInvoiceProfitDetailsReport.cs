using ClosedXML.Excel;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.Report;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace POS
{
    public partial class FrmInvoiceProfitDetailsReport : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtDetail = new DataTable();
        DataTable dtAllInvoice=new DataTable();
        public FrmInvoiceProfitDetailsReport()
        {
            InitializeComponent();
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(0, 0);
        }

        private void FrmInvoiceAuditReport_Load(object sender, EventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceAuditReport,Function :FrmInvoiceAuditReport_Load. Message:" + ex.Message);
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
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceAuditReport,Function :CheckValidation. Message:" + ex.Message);
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
                if (ClsCommon.FunctionVisibility("Print", "InvoiceProfitDetailsReport"))
                {
                    if (CheckValidation())
                    {
                     
                            DataTable DATA = new DataTable();
                            DATA.Columns.Add("CustomerName");
                            DATA.Columns.Add("InvoiceNumber");
                            DATA.Columns.Add("Date");
                            DATA.Columns.Add("ItemName");
                            DATA.Columns.Add("ComparativePrice");
                            DATA.Columns.Add("Qty");
                            DATA.Columns.Add("Rate");
                            DATA.Columns.Add("Amount");
                            DATA.Columns.Add("Cost");
                            DATA.Columns.Add("Profit");
                            DATA.Columns.Add("ProfitPerPiece");
                            DATA.Columns.Add("Profit%");
                                //custom
                             dtAllInvoice = new DataTable();
                             if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                                  dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                              else
                                 dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });

                            DATA.Rows.Clear();
                            if (dtAllInvoice.Rows.Count > 0)
                            {
                                int j = 0;

                                for (int i = 0; i < dtAllInvoice.Rows.Count; i++)
                                {
                                try
                                    {
                                        DATA.NewRow();
                                        DATA.Rows.Add();
                                   
                                        //DATA.Rows[j].Cells[0].Value = dtAllInvoice.Rows[i]["ID"].ToString();
                                      

                                        int INVID = Convert.ToInt32(dtAllInvoice.Rows[i]["ID"].ToString());
                                        decimal Total = 0;
                                        DataTable dt = new BALInvoiceDetails().SelectByInvID(new BOLInvoiceDetails() { InvoiceID = INVID });
                                        if (dt.Rows.Count > 0)
                                        {
                                            //int iRow = 0;
                                            foreach (DataRow dr in dt.Rows)
                                            {
                                            DATA.Rows[j]["CustomerName"] = dtAllInvoice.Rows[i]["Customer"].ToString();
                                            if (dtAllInvoice.Rows[i]["Num"].ToString() != "")
                                            {
                                                DATA.Rows[j]["InvoiceNumber"] = Convert.ToInt32(dtAllInvoice.Rows[i]["Num"].ToString());
                                            }
                                            DateTime date = Convert.ToDateTime(dtAllInvoice.Rows[i]["Date"].ToString());
                                            DATA.Rows[j]["Date"] = date.ToShortDateString();
                                            //if (DATA.Rows[j]["InvoiceNumber"].ToString() == "")
                                            //{
                                            //    DATA.NewRow();
                                            //    DATA.Rows.Add();
                                            //}
                                            DATA.Rows[j]["ItemName"] = dr["ItemName"].ToString();
                                                DATA.Rows[j]["ComparativePrice"] = dr["ComparativePrice1"].ToString();
                                                DATA.Rows[j]["Qty"] = dr["Quantity"].ToString();
                                                DATA.Rows[j]["Rate"] = dr["Rate"].ToString();
                                                DATA.Rows[j]["Amount"] = dr["Amount"].ToString();

                                                DATA.Rows[j]["Cost"] = dr["Cost"].ToString();
                                                if (dr["Cost"].ToString() == "0.00")
                                                {
                                                    DATA.Rows[j]["Profit"] = 0;
                                                }
                                                else
                                                {
                                                    DATA.Rows[j]["Profit"] = decimal.Round(Convert.ToDecimal(dr["Quantity"].ToString()) * (Convert.ToDecimal(dr["Rate"].ToString()) - Convert.ToDecimal(dr["Cost"].ToString())), 2);
                                                }
                                                if (dr["Cost"].ToString() == "0.00")
                                                {
                                                    DATA.Rows[j]["ProfitPerPiece"] = 0;
                                                }
                                                else
                                                {
                                                    DATA.Rows[j]["ProfitPerPiece"] = decimal.Round(Convert.ToDecimal(dr["Rate"].ToString()) - (Convert.ToDecimal(dr["Cost"].ToString())), 2);
                                                }
                                                if (dr["Cost"].ToString() == "0.00")
                                                {
                                                    DATA.Rows[j]["Profit%"] = 0;
                                                }
                                                else
                                                {
                                                    if (DATA.Rows[j]["Profit"].ToString() == "0.00")
                                                    {
                                                        DATA.Rows[j]["Profit%"] = 0.00;
                                                    }
                                                    else
                                                    {
                                                        if (dr["Amount"].ToString() != "0.00")
                                                        {
                                                            DATA.Rows[j]["Profit%"] = string.Concat(decimal.Round((Convert.ToDecimal(DATA.Rows[j]["Profit"]) / (Convert.ToDecimal(dr["Amount"].ToString())) * 100), 2), '%');
                                                        }
                                                        else
                                                        {
                                                            DATA.Rows[j]["Profit%"] = 0.00;
                                                        }
                                                    }
                                                }
                                                DATA.NewRow();
                                                DATA.Rows.Add();
                                                Total += Convert.ToDecimal(DATA.Rows[j]["Profit"]);
                                                //iRow++;
                                                j++;
                                            }
                                            //DATA.Rows.Add();
                                            //DATA.Rows[iRow]["Profit"] = Total;
                                            DATA.Rows[j]["Profit"] = Total;
                                        }
                                        j++;
                                    }
                                    catch (Exception ex)
                                    {
                                        ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster, Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                                        MessageBox.Show("Error:" + ex.Message);
                                    }
                                }
                            }
                        
                        dtDetail = new DataTable();
                        dtDetail = DATA;
                        //dtDetail = new BALInvoiceHistoryMaster().SelectAuditReport(new BOLInvoiceHistoryMaster() { StartDate = dtpFromDate.Value, EndDate = dtpToDate.Value });
                        if (dtDetail.Rows.Count > 0)
                        {
                            rptInvoiceProfitDetailsReport rptInvoiceProfitDetailsReport = new rptInvoiceProfitDetailsReport();
                            rptInvoiceProfitDetailsReport.Database.Tables[0].SetDataSource(dtDetail);

                            FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                            //crViewer.Text = "Invoice Audit Report";
                            crViewer.crystalReportViewer.ReportSource = rptInvoiceProfitDetailsReport;
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
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceAuditReport,Function :btnPrint_Click. Message:" + ex.Message);

            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("Export", "InvoiceProfitDetailsReport"))
                {
                    if (CheckValidation())
                    {

                        DataTable DATA = new DataTable();
                        DATA.Columns.Add("CustomerName");
                        DATA.Columns.Add("InvoiceNumber");
                        DATA.Columns.Add("Date");
                        DATA.Columns.Add("ItemName");
                        DATA.Columns.Add("Ms");
                        DATA.Columns.Add("P4s");
                        DATA.Columns.Add("Gf");
                        DATA.Columns.Add("XCELL");
                        DATA.Columns.Add("Qty");
                        DATA.Columns.Add("Rate");
                        DATA.Columns.Add("Amount");
                        DATA.Columns.Add("Cost");
                        DATA.Columns.Add("Profit");
                        DATA.Columns.Add("ProfitPerPiece");
                        DATA.Columns.Add("Profit%");
                        //custom
                        dtAllInvoice = new DataTable();
                        if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                            dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                        else
                            dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });

                        DATA.Rows.Clear();
                        if (dtAllInvoice.Rows.Count > 0)
                        {
                            int j = 0;

                            for (int i = 0; i < dtAllInvoice.Rows.Count; i++)
                            {
                                try
                                {
                                    DATA.NewRow();
                                    DATA.Rows.Add();

                                    //DATA.Rows[j].Cells[0].Value = dtAllInvoice.Rows[i]["ID"].ToString();


                                    int INVID = Convert.ToInt32(dtAllInvoice.Rows[i]["ID"].ToString());
                                    decimal Total = 0;
                                    DataTable dt = new BALInvoiceDetails().SelectByInvID(new BOLInvoiceDetails() { InvoiceID = INVID });
                                    if (dt.Rows.Count > 0)
                                    {
                                        //int iRow = 0;
                                        foreach (DataRow dr in dt.Rows)
                                        {
                                            DATA.Rows[j]["CustomerName"] = dtAllInvoice.Rows[i]["Customer"].ToString();
                                            if (dtAllInvoice.Rows[i]["Num"].ToString() != "")
                                            {
                                                DATA.Rows[j]["InvoiceNumber"] = Convert.ToInt32(dtAllInvoice.Rows[i]["Num"].ToString());
                                            }
                                            DateTime date = Convert.ToDateTime(dtAllInvoice.Rows[i]["Date"].ToString());
                                            DATA.Rows[j]["Date"] = date.ToShortDateString();
                                            //if (DATA.Rows[j]["InvoiceNumber"].ToString() == "")
                                            //{
                                            //    DATA.NewRow();
                                            //    DATA.Rows.Add();
                                            //}
                                            DATA.Rows[j]["ItemName"] = dr["ItemName"].ToString();
                                            DATA.Rows[j]["Ms"] = dr["ComparativePrice1"].ToString();
                                            DATA.Rows[j]["P4s"] = dr["ComparativePrice2"].ToString();
                                            DATA.Rows[j]["Gf"] = dr["ComparativePrice3"].ToString();
                                            DATA.Rows[j]["XCELL"] = dr["ComparativePrice4"].ToString();
                                            DATA.Rows[j]["Qty"] = dr["Quantity"].ToString();
                                            DATA.Rows[j]["Rate"] = dr["Rate"].ToString();
                                            DATA.Rows[j]["Amount"] = dr["Amount"].ToString();

                                            DATA.Rows[j]["Cost"] = dr["Cost"].ToString();
                                            if (dr["Cost"].ToString() == "0.00")
                                            {
                                                DATA.Rows[j]["Profit"] = 0;
                                            }
                                            else
                                            {
                                                DATA.Rows[j]["Profit"] = decimal.Round(Convert.ToDecimal(dr["Quantity"].ToString()) * (Convert.ToDecimal(dr["Rate"].ToString()) - Convert.ToDecimal(dr["Cost"].ToString())), 2);
                                            }
                                            if (dr["Cost"].ToString() == "0.00")
                                            {
                                                DATA.Rows[j]["ProfitPerPiece"] = 0;
                                            }
                                            else
                                            {
                                                DATA.Rows[j]["ProfitPerPiece"] = decimal.Round(Convert.ToDecimal(dr["Rate"].ToString()) - (Convert.ToDecimal(dr["Cost"].ToString())), 2);
                                            }
                                            if (dr["Cost"].ToString() == "0.00")
                                            {
                                                DATA.Rows[j]["Profit%"] = 0;
                                            }
                                            else
                                            {
                                                if (DATA.Rows[j]["Profit"].ToString() == "0.00")
                                                {
                                                    DATA.Rows[j]["Profit%"] = 0.00;
                                                }
                                                else
                                                {
                                                    if (dr["Amount"].ToString() != "0.00")
                                                    {
                                                        DATA.Rows[j]["Profit%"] = string.Concat(decimal.Round((Convert.ToDecimal(DATA.Rows[j]["Profit"]) / (Convert.ToDecimal(dr["Amount"].ToString())) * 100), 2), '%');
                                                    }
                                                    else
                                                    {
                                                        DATA.Rows[j]["Profit%"] = 0.00;
                                                    }
                                                }
                                            }
                                            DATA.NewRow();
                                            DATA.Rows.Add();
                                            Total += Convert.ToDecimal(DATA.Rows[j]["Profit"]);
                                            //iRow++;
                                            j++;
                                        }
                                        //DATA.Rows.Add();
                                        //DATA.Rows[iRow]["Profit"] = Total;
                                        DATA.Rows[j]["Profit"] = Total;
                                    }
                                    j++;
                                }
                                catch (Exception ex)
                                {
                                    ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster, Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                                    MessageBox.Show("Error:" + ex.Message);
                                }
                            }
                        }

                        dtDetail = new DataTable();
                        dtDetail = DATA;
                        //dtDetail = new BALInvoiceHistoryMaster().SelectAuditReport(new BOLInvoiceHistoryMaster() { StartDate = dtpFromDate.Value, EndDate = dtpToDate.Value });
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
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceAuditReport,Function :btnPrint_Click. Message:" + ex.Message);

            }
        }
    }
}