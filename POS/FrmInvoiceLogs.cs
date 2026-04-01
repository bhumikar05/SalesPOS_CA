using ClosedXML.Excel;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace POS
{
    public partial class FrmInvoiceLogs : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BOLInvoiceMasterLog objBOLInvoiceMasterLog = new BOLInvoiceMasterLog();
        BALInvoiceMasterLog objBALInvoiceMasterLog = new BALInvoiceMasterLog();
        BOLInvoiceDetailsLog objBOLInvoiceDetailsLog = new BOLInvoiceDetailsLog();

        DataTable dtAllInvoice = new DataTable();
        public FrmInvoiceLogs()
        {
            InitializeComponent();
            cmbInvoiceDate.SelectedIndex = 0;
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(0, 0);

        }
        public void HideColumn()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = new BALInvoiceLogHideColumn().Select(new BOLInvoiceLogHideColumn() { InvoiceID = ClsCommon.UserID });
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["NewRefNumber"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["NewRefNumber"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["NewRefNumber"].Visible = true;
                    }


                    if (dt.Rows[0]["NewCustomerName"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["NewCustomerName"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["NewCustomerName"].Visible = true;
                    }
                    if (dt.Rows[0]["OldCustomerName"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["OldCustomerName"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["OldCustomerName"].Visible = true;
                    }
                    if (dt.Rows[0]["NewPONumber"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["NewPONumber"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["NewPONumber"].Visible = true;
                    }
                    if (dt.Rows[0]["OldPONumber"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["OldPONumber"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["OldPONumber"].Visible = true;
                    }
                    if (dt.Rows[0]["NewTermsName"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["NewTermsName"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["NewTermsName"].Visible = true;
                    }
                    if (dt.Rows[0]["OldTermsName"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["OldTermsName"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["OldTermsName"].Visible = true;
                    }
                    if (dt.Rows[0]["NewDueDate"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["NewDueDate"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["NewDueDate"].Visible = true;
                    }
                    if (dt.Rows[0]["OldDueDate"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["OldDueDate"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["OldDueDate"].Visible = true;
                    }
                    if (dt.Rows[0]["NewSalesRepName"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["NewSalesRepName"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["NewSalesRepName"].Visible = true;
                    }
                    if (dt.Rows[0]["OldSalesRepName"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["OldSalesRepName"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["OldSalesRepName"].Visible = true;
                    }
                    if (dt.Rows[0]["NewshipDate"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["NewshipDate"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["NewshipDate"].Visible = true;
                    }






                    if (dt.Rows[0]["OldShipDate"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["OldShipDate"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["OldShipDate"].Visible = true;
                    }


                    if (dt.Rows[0]["NewShipping"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["NewShipping"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["NewShipping"].Visible = true;
                    }
                    if (dt.Rows[0]["OldShipping"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["OldShipping"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["OldShipping"].Visible = true;
                    }
                    if (dt.Rows[0]["NewTotal"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["NewTotal"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["NewTotal"].Visible = true;
                    }
                    if (dt.Rows[0]["OldTotal"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["OldTotal"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["OldTotal"].Visible = true;
                    }
                    if (dt.Rows[0]["NewAppliedAmount"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["NewAppliedAmount"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["NewAppliedAmount"].Visible = true;
                    }
                    if (dt.Rows[0]["OldAppliedAmount"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["OldAppliedAmount"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["OldAppliedAmount"].Visible = true;
                    }
                    if (dt.Rows[0]["NewBalanceDue"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["NewBalanceDue"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["NewBalanceDue"].Visible = true;
                    }
                    if (dt.Rows[0]["OldBalanceDue"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["OldBalanceDue"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["OldBalanceDue"].Visible = true;
                    }
                    if (dt.Rows[0]["NewMemo"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["NewMemo"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["NewMemo"].Visible = true;
                    }
                    if (dt.Rows[0]["OldMemo"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["OldMemo"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["OldMemo"].Visible = true;
                    }
                    if (dt.Rows[0]["EditCount"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["EditCount"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["EditCount"].Visible = true;
                    }
                    if (dt.Rows[0]["UpdateDate"].ToString() == "1")
                    {
                        dgvAllInvoiceList.Columns["UpdateDate"].Visible = false;
                    }
                    else
                    {
                        dgvAllInvoiceList.Columns["UpdateDate"].Visible = true;
                    }
                }
                else
                {
                    ClsCommon.WriteErrorLogs("Form:FrmInvoiceLogs,Function :HideColumn. Table Not Count");

                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceLogs,Function :HideColumn. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DataTable dtExport = new DataTable();
            //    dtExport.Columns.Add("RefNumber");
            //    dtExport.Columns.Add("CustomerName");
            //    dtExport.Columns.Add("OldCustomerName");
            //    dtExport.Columns.Add("PoNumber");
            //    dtExport.Columns.Add("OldPoNumber");
            //    dtExport.Columns.Add("DueDate");
            //    dtExport.Columns.Add("OldDueDate");
            //    dtExport.Columns.Add("ShipDate");
            //    dtExport.Columns.Add("OldShipDate");
            //    dtExport.Columns.Add("ShippingVia");
            //    dtExport.Columns.Add("OldShippingVia");
            //    dtExport.Columns.Add("TermsName");
            //    dtExport.Columns.Add("OldTermsName");
            //    dtExport.Columns.Add("SalesRepName");
            //    dtExport.Columns.Add("OldSalesRepName");
            //    dtExport.Columns.Add("EditCount");
            //    dtExport.Columns.Add("UpdateDate");

            //    if (dtAllInvoice.Rows.Count > 0)
            //    {
            //        foreach (DataRow row in dtAllInvoice.Rows)
            //        {
            //            dtExport.Rows.Add(
            //                row["NewRefNumber"].ToString(),
            //                row["NewCustomerName"].ToString(),
            //                row["OldCustomerName"].ToString(),
            //                row["NewPoNumber"].ToString(),
            //                row["OldPoNumber"].ToString(),
            //                row["NewDueDate"].ToString(),
            //                row["OldDueDate"].ToString(),
            //                row["NewShipDate"].ToString(),
            //                row["OldShipDate"].ToString(),
            //                row["NewShippingVia1"].ToString(),
            //                row["OldShippingVia1"].ToString(),
            //                row["NewTermsName"].ToString(),
            //                row["OldTermsName"].ToString(),
            //                row["NewSalesRepName"].ToString(),
            //                row["OldSalesRepName"].ToString(),
            //                row["EditCount"].ToString(),
            //                row["UpdateDate"].ToString()
            //            );


            //            DataTable dt = new BALInvoiceLineItemLog().SelectByInvID(new BOLInvoiceLineItemLog() { InvoiceID = Convert.ToInt32(row["InvoiceID"].ToString()), });
            //            if (dt.Rows.Count > 0)
            //            {
            //                foreach (DataRow dr in dt.Rows)
            //                {

            //                    dtExport.Rows.Add(
            //                "",
            //                "",
            //                "",
            //                "",
            //                "",
            //                "",
            //                "",
            //                "",
            //                "",
            //                dr["FullName"].ToString(),
            //                dr["Qty"].ToString(),
            //                dr["OldQty"].ToString(),
            //                dr["Description"].ToString(),
            //                dr["PriceEach"].ToString(),
            //                dr["Amount"].ToString(),
            //                dr["EditCount"].ToString(),
            //                dr["EditMode"].ToString()
            //            );

            //                }
            //            }

            //        }

            //        SaveFileDialog sfd = new SaveFileDialog();
            //        sfd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            //        sfd.FilterIndex = 1;
            //        sfd.RestoreDirectory = true;
            //        sfd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "Excel//Book1.xlsx";

            //        //if (sfd.ShowDialog() == DialogResult.OK)
            //        //{
            //        Cursor.Current = Cursors.WaitCursor;
            //        using (XLWorkbook wb = new XLWorkbook())
            //        {
            //            wb.Worksheets.Add(dtExport, "Sheet1");
            //            wb.SaveAs(sfd.InitialDirectory);
            //        }
            //        //MessageBox.Show("Export Successfully");
            //        //}
            //        var app = new Microsoft.Office.Interop.Excel.Application();
            //        app.Visible = true;
            //        app.Workbooks.Open(sfd.InitialDirectory, ReadOnly: false);
            //    }
            //    else
            //    {
            //        MessageBox.Show("No data Found");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ClsCommon.WriteErrorLogs("Form:FrmCustomerLogs,Function :btnExport_Click. Message:" + ex.Message);
            //    MessageBox.Show("Error:" + ex.Message);
            //}
        }
        private void cmbInvoiceDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Display();
        }
        public void Display()
        {
            try
            {
                lblFrom.Visible = false; lblTo.Visible = false; dtFrom.Visible = false; dtTo.Visible = false;
                if (cmbInvoiceDate.SelectedIndex == 0)
                {
                    //today
                    dtAllInvoice = new DataTable();
                    dtAllInvoice = new BALInvoiceMasterLog().SelectByDate(new BOLInvoiceMasterLog() { StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                }
                else if (cmbInvoiceDate.SelectedIndex == 1)
                {
                    //yesterday
                    dtAllInvoice = new DataTable();
                    DateTime dt1 = DateTime.Now.AddDays(-1);

                    dtAllInvoice = new BALInvoiceMasterLog().SelectByDate(new BOLInvoiceMasterLog() { StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }
                else if (cmbInvoiceDate.SelectedIndex == 2)
                {
                    //this month
                    dtAllInvoice = new DataTable();
                    DateTime dt = DateTime.Now;
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    dtAllInvoice = new BALInvoiceMasterLog().SelectByDate(new BOLInvoiceMasterLog() { StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }
                else if (cmbInvoiceDate.SelectedIndex == 3)
                {
                    //this week
                    dtAllInvoice = new DataTable();
                    DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
                    DateTime dt1 = dt.AddDays(6);
                    dtAllInvoice = new BALInvoiceMasterLog().SelectByDate(new BOLInvoiceMasterLog() { StartDate = dt.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }
                else if (cmbInvoiceDate.SelectedIndex == 4)
                {
                    //last month
                    dtAllInvoice = new DataTable();
                    DateTime dt = DateTime.Now.AddMonths(-1);
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    dtAllInvoice = new BALInvoiceMasterLog().SelectByDate(new BOLInvoiceMasterLog() { StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }
                else if (cmbInvoiceDate.SelectedIndex == 5)
                {
                    //this ficsal year
                    dtAllInvoice = new DataTable();
                    int year = DateTime.Now.Year;
                    DateTime firstDay = Convert.ToDateTime(year + "-" + "01" + "-" + "01");
                    dtAllInvoice = new BALInvoiceMasterLog().SelectByDate(new BOLInvoiceMasterLog() { StartDate = firstDay.ToString("yyyy-MM-dd"), EndDate = firstDay.AddYears(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }
                else if (cmbInvoiceDate.SelectedIndex == 6)
                {
                    //all
                    dtAllInvoice = new DataTable();
                    dtAllInvoice = new BALInvoiceMasterLog().SelectByDate(new BOLInvoiceMasterLog() { StartDate = null, EndDate = null });
                }

                else if (cmbInvoiceDate.SelectedIndex == 7)
                {
                    //custom
                    dtAllInvoice = new DataTable();
                    dtAllInvoice = new BALInvoiceMasterLog().SelectByDate(new BOLInvoiceMasterLog() { StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
                    lblFrom.Visible = true; lblTo.Visible = true; dtFrom.Visible = true; dtTo.Visible = true;
                }
                dgvAllInvoiceList.Rows.Clear();

                if (dtAllInvoice.Rows.Count > 0)
                {
                    foreach (DataRow row in dtAllInvoice.Rows)
                    {
                        dgvAllInvoiceList.Rows.Add(
                            row["ID"].ToString(),
                            row["InvoiceID"].ToString(),
                            row["NewRefNumber"].ToString(),
                            row["NewCustomerName"].ToString(),
                            row["OldCustomerName"].ToString(),
                            row["NewPoNumber"].ToString(),
                            row["OldPoNumber"].ToString(),
                            row["NewTerms"].ToString(),
                            row["OldTerms"].ToString(),
                            row["NewDueDate"].ToString(),
                            row["OldDueDate"].ToString(),
                            row["NewSalesRep"].ToString(),
                            row["OldSalesRep"].ToString(),
                            row["NewShipDate"].ToString(),
                            row["OldShipDate"].ToString(),
                            row["NewShipMethodName"].ToString(),
                            row["OldShipMethodName"].ToString(),
                            row["NewTotal"].ToString(),
                            row["OldTotal"].ToString(),
                            row["NewAppliedAmount"].ToString(),
                            row["OldAppliedAmount"].ToString(),
                            row["NewBalanceDue"].ToString(),
                            row["OldBalanceDue"].ToString(),
                            row["NewMemo"].ToString(),
                            row["OldMemo"].ToString(),
                            row["EditCount"].ToString(),
                            Convert.ToDateTime(row["UpdateDate"].ToString()).ToShortDateString()
                        );

                    }
                }
                HideColumn();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerLogs,Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void dtFrom_Leave(object sender, EventArgs e)
        {
            dtAllInvoice = new DataTable();
            dtAllInvoice = new BALInvoiceMasterLog().SelectByDate(new BOLInvoiceMasterLog() { StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
            dgvAllInvoiceList.Rows.Clear();

            if (dtAllInvoice.Rows.Count > 0)
            {
                foreach (DataRow row in dtAllInvoice.Rows)
                {

                    dgvAllInvoiceList.Rows.Add(
                            row["ID"].ToString(),
                            row["InvoiceID"].ToString(),
                            row["NewRefNumber"].ToString(),
                            row["NewCustomerName"].ToString(),
                            row["OldCustomerName"].ToString(),
                            row["NewPoNumber"].ToString(),
                            row["OldPoNumber"].ToString(),
                            row["NewTerms"].ToString(),
                            row["OldTerms"].ToString(),
                            row["NewDueDate"].ToString(),
                            row["OldDueDate"].ToString(),
                            row["NewSalesRep"].ToString(),
                            row["OldSalesRep"].ToString(),
                            row["NewShipDate"].ToString(),
                            row["OldShipDate"].ToString(),
                            row["NewShipMethodName"].ToString(),
                            row["OldShipMethodName"].ToString(),
                            row["NewTotal"].ToString(),
                            row["OldTotal"].ToString(),
                            row["NewAppliedAmount"].ToString(),
                            row["OldAppliedAmount"].ToString(),
                            row["NewBalanceDue"].ToString(),
                            row["OldBalanceDue"].ToString(),
                            row["NewMemo"].ToString(),
                            row["OldMemo"].ToString(),
                            row["EditCount"].ToString(),
                            Convert.ToDateTime(row["UpdateDate"].ToString()).ToShortDateString()
                        );
                }
            }
        }
        private void dtTo_Leave(object sender, EventArgs e)
        {
            dtAllInvoice = new DataTable();
            dtAllInvoice = new BALInvoiceMasterLog().SelectByDate(new BOLInvoiceMasterLog() { StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
            dgvAllInvoiceList.Rows.Clear();

            if (dtAllInvoice.Rows.Count > 0)
            {
                foreach (DataRow row in dtAllInvoice.Rows)
                {
                    dgvAllInvoiceList.Rows.Add(
                               row["ID"].ToString(),
                               row["InvoiceID"].ToString(),
                               row["NewRefNumber"].ToString(),
                               row["NewCustomerName"].ToString(),
                               row["OldCustomerName"].ToString(),
                               row["NewPoNumber"].ToString(),
                               row["OldPoNumber"].ToString(),
                               row["NewTerms"].ToString(),
                               row["OldTerms"].ToString(),
                               row["NewDueDate"].ToString(),
                               row["OldDueDate"].ToString(),
                               row["NewSalesRep"].ToString(),
                               row["OldSalesRep"].ToString(),
                               row["NewShipDate"].ToString(),
                               row["OldShipDate"].ToString(),
                               row["NewShipMethodName"].ToString(),
                               row["OldShipMethodName"].ToString(),
                               row["NewTotal"].ToString(),
                               row["OldTotal"].ToString(),
                               row["NewAppliedAmount"].ToString(),
                               row["OldAppliedAmount"].ToString(),
                               row["NewBalanceDue"].ToString(),
                               row["OldBalanceDue"].ToString(),
                               row["NewMemo"].ToString(),
                               row["OldMemo"].ToString(),
                               row["EditCount"].ToString(),
                               Convert.ToDateTime(row["UpdateDate"].ToString()).ToShortDateString()
                           );
                }
            }
        }
        private void FrmCustomerLogs_Load(object sender, EventArgs e)
        {
            cmbInvoiceDate.SelectedIndex = 0;
            Display();
            HideColumn();
        }
        private void FrmCustomerLogs_FormClosing(object sender, FormClosingEventArgs e)
        {
            cmbInvoiceDate.SelectedIndex = 0;
            ClsCommon.ObjInvoiceLogs.Hide();
            ClsCommon.ObjInvoiceLogs.Parent = null;
            e.Cancel = true;
        }
        private void dgvAllInvoiceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 27)
                {
                    int INVID = Convert.ToInt32(dgvAllInvoiceList.CurrentRow.Cells[0].Value);
                    lblRefno.Text = dgvAllInvoiceList.CurrentRow.Cells[2].Value.ToString();
                    dgInvDetail.Rows.Clear();
                    DataTable dt = new BALInvoiceMasterLog().SelectByInvID(new BOLInvoiceDetailsLog() { MasterLogID = INVID });
                    if (dt.Rows.Count > 0)
                    {
                        int iRow = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            dgInvDetail.Rows.Add();
                            dgInvDetail[0, iRow].Value = dr["NewItemName"].ToString();
                            dgInvDetail[1, iRow].Value = dr["OldItemName"].ToString();
                            dgInvDetail[2, iRow].Value = dr["Description"].ToString();
                            dgInvDetail[3, iRow].Value = dr["OldDescription"].ToString();
                            dgInvDetail[4, iRow].Value = dr["Qty"].ToString();
                            dgInvDetail[5, iRow].Value = dr["OldQty"].ToString();
                            dgInvDetail[6, iRow].Value = dr["PriceEach"].ToString();
                            dgInvDetail[7, iRow].Value = dr["OldPriceEach"].ToString();
                            dgInvDetail[8, iRow].Value = dr["Amount"].ToString();
                            dgInvDetail[9, iRow].Value = dr["OldAmount"].ToString();
                            dgInvDetail[10, iRow].Value = dr["EditCount"].ToString();
                            dgInvDetail[11, iRow].Value = dr["EditMode"].ToString();
                            dgInvDetail[12, iRow].Value = Convert.ToDateTime(dr["UpdateTime"].ToString()).ToShortDateString();

                            iRow++;
                        }
                    }
                    pnlInvDetails.Visible = true;

                }
                if (e.ColumnIndex == 28)
                {
                    DialogResult result = MessageBox.Show("Are you sure to delete this record?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        int ID = Convert.ToInt32(dgvAllInvoiceList.CurrentRow.Cells["ID"].Value.ToString());
                        objBOLInvoiceMasterLog.ID = ID;
                        objBALInvoiceMasterLog.DeleteMaster(objBOLInvoiceMasterLog);
                        objBOLInvoiceDetailsLog.MasterLogID = ID;
                        objBALInvoiceMasterLog.DeleteDetail(objBOLInvoiceMasterLog);
                        MessageBox.Show("Record delete successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceLogs,Function :dgvAllInvoiceList_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            pnlInvDetails.Visible = false;

        }
    }
}