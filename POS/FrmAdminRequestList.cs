using ClosedXML.Excel;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using SalesPOS.QBClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmAdminRequestList : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dt = new DataTable();
        BALCustomerRequest objBALCus = new BALCustomerRequest();
        BOLCustomerRequest objBOLCus = new BOLCustomerRequest();
        DataTable dtAdminRequest = new DataTable();


        public FrmAdminRequestList()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            lblTotal.Text = "0";
            cmbTransactionsFilterDate.SelectedIndex=0;
            DateWiseInvoiceLoad();
        }

        public void LoadFunction()
        {
            dgvRequestList.Rows.Clear();
            cmbTransactionsFilterDate.SelectedIndex = 0;
            DateWiseInvoiceLoad();
        }

        private void FrmAdminRequestList_Load(object sender, EventArgs e)
        {
            try
            {

                //View Button
                //DataGridViewLinkColumn ViewButton = new DataGridViewLinkColumn();
                //ViewButton.UseColumnTextForLinkValue = true;
                //ViewButton.HeaderText = "View";
                //ViewButton.DataPropertyName = "View";
                //ViewButton.Text = "View";
                //dgvRequestList.Columns.Add(ViewButton);
                //dgvRequestList.Columns[10].Width = 100;


                //DataGridViewLinkColumn Remove = new DataGridViewLinkColumn();
                //ViewButton.UseColumnTextForLinkValue = true;
                //ViewButton.HeaderText = "Remove";
                //ViewButton.DataPropertyName = "Remove";
                //ViewButton.Text = "Remove";
                //dgvRequestList.Columns.Add(Remove);
                //dgvRequestList.Columns[11].Width = 100;



                ////Approve Button
                //DataGridViewLinkColumn ApproveButton = new DataGridViewLinkColumn();
                //ApproveButton.UseColumnTextForLinkValue = true;
                //ApproveButton.HeaderText = "Approve";
                //ApproveButton.DataPropertyName = "Approve";
                //ApproveButton.Text = "Approve";
                //dgvRequestList.Columns.Add(ApproveButton);
                //dgvRequestList.Columns[8].Width = 100;

                ////Reject Button
                //DataGridViewLinkColumn RejectButton = new DataGridViewLinkColumn();
                //RejectButton.UseColumnTextForLinkValue = true;
                //RejectButton.HeaderText = "Reject";
                //RejectButton.DataPropertyName = "Reject";
                //RejectButton.Text = "Reject";
                //dgvRequestList.Columns.Add(RejectButton);
                //dgvRequestList.Columns[9].Width = 100;

                this.dgvRequestList.DefaultCellStyle.Font = new Font("", 10);
                dgvRequestList.RowTemplate.Height = 24;
                dgvRequestList.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvRequestList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                dgvRequestList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                dgvRequestList.EnableHeadersVisualStyles = false;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmAdminRequestList, Function :FrmAdminRequestList_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        //public void LoadData()
        //{
        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;
        //        dt = new BALCustomerRequest().Select(new BOLCustomerRequest() { });
        //        if (dt.Rows.Count > 0)
        //        {
        //            int j = 0;
        //            dgvRequestList.Rows.Clear();
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                dgvRequestList.Rows.Add();
        //                dgvRequestList.Rows[j].Cells["ID"].Value = dt.Rows[i]["ID"].ToString();
        //                dgvRequestList.Rows[j].Cells["InvoiceID"].Value = dt.Rows[i]["InvoiceID"].ToString();
        //                dgvRequestList.Rows[j].Cells["CustomerName"].Value = dt.Rows[i]["CustomerFullName"].ToString();
        //                dgvRequestList.Rows[j].Cells["InvoiceNo"].Value = dt.Rows[i]["InvoiceNumber"].ToString();
        //                dgvRequestList.Rows[j].Cells["ItemName"].Value = dt.Rows[i]["ItemFullName"].ToString();
        //                dgvRequestList.Rows[j].Cells["Date"].Value = Convert.ToDateTime(dt.Rows[i]["CreatedTime"].ToString()).ToShortDateString();
        //                dgvRequestList.Rows[j].Cells["SalesRepName"].Value = dt.Rows[i]["SalesRepName"].ToString();
        //                dgvRequestList.Rows[j].Cells["PurchaseCost"].Value = dt.Rows[i]["PurchaseCost"].ToString();
        //                dgvRequestList.Rows[j].Cells["ComparativePrice1"].Value = dt.Rows[i]["ComparativePrice1"].ToString();
        //                dgvRequestList.Rows[j].Cells["ComparativePrice2"].Value = dt.Rows[i]["ComparativePrice2"].ToString();
        //                dgvRequestList.Rows[j].Cells["ComparativePrice3"].Value = dt.Rows[i]["ComparativePrice3"].ToString();
        //                dgvRequestList.Rows[j].Cells["ComparativePrice4"].Value = dt.Rows[i]["ComparativePrice4"].ToString();
        //                dgvRequestList.Rows[j].Cells["CurrentLowestPrice"].Value = dt.Rows[i]["ItemLowestPrice"].ToString();
        //                dgvRequestList.Rows[j].Cells["UserLowestPrice"].Value = dt.Rows[i]["LowestPrice"].ToString();
        //                if (dt.Rows[i]["Status"].ToString() == "0")
        //                {
        //                    dgvRequestList.Rows[j].Cells["Status"].Style.ForeColor = Color.Red;
        //                    dgvRequestList.Rows[j].Cells["Status"].Value = "Pending";
        //                }
        //                else if (dt.Rows[i]["Status"].ToString() == "1")
        //                    dgvRequestList.Rows[j].Cells["Status"].Value = "Approved";
        //                else if (dt.Rows[i]["Status"].ToString() == "2")
        //                {
        //                    dgvRequestList.Rows[j].Cells["Status"].Style.ForeColor = Color.Red;
        //                    dgvRequestList.Rows[j].Cells["Status"].Value = "Rejected";
        //                }
        //                j++;
        //            }
        //        }
        //        else
        //            dgvRequestList.Rows.Clear();
        //        lblTotal.Text = dt.Rows.Count.ToString();
        //        Cursor.Current = Cursors.Default;
        //    }
        //    catch (Exception ex)
        //    {
        //        Cursor.Current = Cursors.Default;
        //        ClsCommon.WriteErrorLogs("Form:FrmAdminRequestList, Function :LoadData. Message:" + ex.Message);
        //        MessageBox.Show("Error:" + ex.Message);
        //    }
        //}

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text != "")
                {
                    txtSearch.Text = "";

                    if (lblFrom.Visible == true)
                    {
                        this.dtTranTo.Click += new System.EventHandler(this.dtTranTo_Leave);
                    }
                    DateWiseInvoiceLoad();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmAdminRequestList, Function :btnReset_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //if (txtSearch.Text != "")
            //    //{
            //    //    DataRow[] row = dt.Select("CustomerFullName like '%" + txtSearch.Text + "%' OR ItemFullName like '%" + txtSearch.Text + "%' OR SalesRepName like '%" + txtSearch.Text + "%'");
            //    //    if (row.Length > 0)
            //    //    {
            //    //        DataTable dtNew = row.CopyToDataTable();

            //    //        int j = 0;
            //    //        dgvRequestList.Rows.Clear();
            //    //        for (int i = 0; i < dtNew.Rows.Count; i++)
            //    //        {

            //    //            dgvRequestList.Rows.Add();
            //    //            dgvRequestList.Rows[j].Cells["ID"].Value = dtNew.Rows[i]["ID"].ToString();
            //    //            dgvRequestList.Rows[j].Cells["InvoiceID"].Value = dtNew.Rows[i]["InvoiceID"].ToString();
            //    //            dgvRequestList.Rows[j].Cells["CustomerName"].Value = dtNew.Rows[i]["CustomerFullName"].ToString();
            //    //            dgvRequestList.Rows[j].Cells["InvoiceNo"].Value = dtNew.Rows[i]["InvoiceNumber"].ToString();
            //    //            dgvRequestList.Rows[j].Cells["ItemName"].Value = dtNew.Rows[i]["ItemFullName"].ToString();
            //    //            dgvRequestList.Rows[j].Cells["Date"].Value = Convert.ToDateTime(dtNew.Rows[i]["CreatedTime"].ToString()).ToShortDateString();
            //    //            dgvRequestList.Rows[j].Cells["SalesRepName"].Value = dtNew.Rows[i]["SalesRepName"].ToString();
            //    //            dgvRequestList.Rows[j].Cells["PurchaseCost"].Value = dtNew.Rows[i]["PurchaseCost"].ToString();
            //    //            dgvRequestList.Rows[j].Cells["ComparativePrice1"].Value = dtNew.Rows[i]["ComparativePrice1"].ToString();
            //    //            dgvRequestList.Rows[j].Cells["ComparativePrice2"].Value = dtNew.Rows[i]["ComparativePrice2"].ToString();
            //    //            dgvRequestList.Rows[j].Cells["ComparativePrice3"].Value = dtNew.Rows[i]["ComparativePrice3"].ToString();
            //    //            dgvRequestList.Rows[j].Cells["ComparativePrice4"].Value = dtNew.Rows[i]["ComparativePrice4"].ToString();
            //    //            dgvRequestList.Rows[j].Cells["CurrentLowestPrice"].Value = dtNew.Rows[i]["ItemLowestPrice"].ToString();
            //    //            dgvRequestList.Rows[j].Cells["UserLowestPrice"].Value = dtNew.Rows[i]["LowestPrice"].ToString();
            //    //            if (dtNew.Rows[i]["Status"].ToString() == "0")
            //    //            {
            //    //                dgvRequestList.Rows[j].Cells["Status"].Style.ForeColor = Color.Red;
            //    //                dgvRequestList.Rows[j].Cells["Status"].Value = "Pending";
            //    //            }
            //    //            else if (dtNew.Rows[i]["Status"].ToString() == "1")
            //    //                dgvRequestList.Rows[j].Cells["Status"].Value = "Approved";
            //    //            else if (dtNew.Rows[i]["Status"].ToString() == "2")
            //    //            {
            //    //                dgvRequestList.Rows[j].Cells["Status"].Style.ForeColor = Color.Red;
            //    //                dgvRequestList.Rows[j].Cells["Status"].Value = "Rejected";
            //    //            }
            //    //            j++;
            //    //        }
            //    //        lblTotal.Text = dtNew.Rows.Count.ToString();
            //    //    }
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    ClsCommon.WriteErrorLogs("Form:FrmAdminRequestList,Function :btnSearch_Click. Message:" + ex.Message);
            //    MessageBox.Show("Error:" + ex.Message);
            //}

            try
            {
                if (txtSearch.Text != "")
                {
                    if (dtAdminRequest.Rows.Count > 0)
                    {
                        DataRow[] row = dtAdminRequest.Select("CustomerFullName like '%" + txtSearch.Text + "%' OR ItemFullName like '%" + txtSearch.Text + "%' OR SalesRepName like '%" + txtSearch.Text + "%'");
                        if (row.Length > 0)
                        {
                            DataTable dtNew = row.CopyToDataTable();
                            int j = 0;
                            dgvRequestList.Rows.Clear();
                            for (int i = 0; i < dtNew.Rows.Count; i++)
                            {
                                dgvRequestList.Rows.Add();
                                dgvRequestList.Rows[j].Cells["ID"].Value = dtNew.Rows[i]["ID"].ToString();
                                dgvRequestList.Rows[j].Cells["InvoiceID"].Value = dtNew.Rows[i]["InvoiceID"].ToString();
                                dgvRequestList.Rows[j].Cells["CustomerName"].Value = dtNew.Rows[i]["CustomerFullName"].ToString();
                                dgvRequestList.Rows[j].Cells["InvoiceNo"].Value = dtNew.Rows[i]["InvoiceNumber"].ToString();
                                dgvRequestList.Rows[j].Cells["ItemName"].Value = dtNew.Rows[i]["ItemFullName"].ToString();
                                dgvRequestList.Rows[j].Cells["Date"].Value = Convert.ToDateTime(dtNew.Rows[i]["CreatedTime"].ToString()).ToShortDateString();
                                dgvRequestList.Rows[j].Cells["SalesRepName"].Value = dtNew.Rows[i]["SalesRepName"].ToString();
                                dgvRequestList.Rows[j].Cells["PurchaseCost"].Value = dtNew.Rows[i]["PurchaseCost"].ToString();
                                dgvRequestList.Rows[j].Cells["ComparativePrice1"].Value = dtNew.Rows[i]["ComparativePrice1"].ToString();
                                dgvRequestList.Rows[j].Cells["ComparativePrice2"].Value = dtNew.Rows[i]["ComparativePrice2"].ToString();
                                dgvRequestList.Rows[j].Cells["ComparativePrice3"].Value = dtNew.Rows[i]["ComparativePrice3"].ToString();
                                dgvRequestList.Rows[j].Cells["ComparativePrice4"].Value = dtNew.Rows[i]["ComparativePrice4"].ToString();
                                dgvRequestList.Rows[j].Cells["ComparativePrice5"].Value = dtNew.Rows[i]["ComparativePrice5"].ToString();
                                dgvRequestList.Rows[j].Cells["CurrentLowestPrice"].Value = dtNew.Rows[i]["ItemLowestPrice"].ToString();
                                dgvRequestList.Rows[j].Cells["UserLowestPrice"].Value = dtNew.Rows[i]["LowestPrice"].ToString();
                                if (dtNew.Rows[i]["Status"].ToString() == "0")
                                {
                                    dgvRequestList.Rows[j].Cells["Status"].Style.ForeColor = Color.Red;
                                    dgvRequestList.Rows[j].Cells["Status"].Value = "Pending";
                                }
                                else if (dtNew.Rows[i]["Status"].ToString() == "1")
                                    dgvRequestList.Rows[j].Cells["Status"].Value = "Approved";
                                else if (dtNew.Rows[i]["Status"].ToString() == "2")
                                {
                                    dgvRequestList.Rows[j].Cells["Status"].Style.ForeColor = Color.Red;
                                    dgvRequestList.Rows[j].Cells["Status"].Value = "Rejected";
                                }
                                j++;
                            }
                            lblTotal.Text = dtNew.Rows.Count.ToString();
                        }
                        else
                        {
                            dgvRequestList.Rows.Clear();
                        }
                    }
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    DateWiseInvoiceLoad();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmAdminRequestList,Function :btnSearch_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btmClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRequestList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 16)
                {
                    //if (ClsCommon.FunctionVisibility("InvUpdate", "CustomerCenter"))
                    //{
                    //   // ClsCommon.ObjInvoiceMaster.EditableField();
                    //    ClsCommon.ObjInvoiceMaster.LoadTable();
                    //    ClsCommon.ObjInvoiceMaster.NonEditableField();
                    //    ClsCommon.ObjInvoiceMaster.RequestID = Convert.ToInt32(dgvRequestList.CurrentRow.Cells["ID"].Value);
                    //    ClsCommon.ObjInvoiceMaster.Show();
                    //    ClsCommon.ObjInvoiceMaster.LoadData(dgvRequestList.CurrentRow.Cells["InvoiceID"].Value.ToString());
                    //    ClsCommon.ObjInvoiceMaster.DisplayLowestItem();
                    //    ClsCommon.ObjInvoiceMaster.AllowLowestPrice();

                    //}
                    //else
                    //    MessageBox.Show("You can not access");
                    if (ClsCommon.FunctionVisibility("InvUpdate", "CustomerCenter"))
                    {
                        ClsCommon.ObjInvoiceMaster.LoadTable();
                        ClsCommon.ObjInvoiceMaster.EditableField();
                        ClsCommon.ObjInvoiceMaster.Show();
                        ClsCommon.ObjInvoiceMaster.RequestID = Convert.ToInt32(dgvRequestList.CurrentRow.Cells["ID"].Value);
                        ClsCommon.ObjInvoiceMaster.LoadData(dgvRequestList.CurrentRow.Cells["InvoiceID"].Value.ToString());
                        ClsCommon.ObjInvoiceMaster.AllowLowestPrice();
                        ClsCommon.ObjInvoiceMaster.CheckDate();
                        ClsCommon.ObjInvoiceMaster.DisplayLowestItemList();
                        ClsCommon.ObjInvoiceMaster.AllowLowestPrice();
                        //ClsCommon.ObjInvoiceMaster.DisplayNotes();
                    }
                    else
                        MessageBox.Show("You can not access");
                }

                if (e.ColumnIndex == 17)
                {
                    DataTable datatable = new DataTable();
                    if (dgvRequestList.CurrentRow.Cells["ID"].Value.ToString() != "")
                    {

                        datatable = new BALCustomerRequest().Select(new BOLCustomerRequest());

                        //DataRow[] row = datatable.Select("InvoiceID='" + dgvRequestList.CurrentRow.Cells["ID"].Value.ToString().Replace("'", "''") + "'");
                        //if (row.Length > 0)
                        //{
                        //    for (int i = 0; i < row.Length; i++)
                        //    {
                        //        DataRow dr = row[i];
                        objBOLCus.ID = Convert.ToInt32(dgvRequestList.CurrentRow.Cells["ID"].Value.ToString());
                        objBOLCus.AllowesNo = 0;
                        objBOLCus.UseAllowesNo = 0;
                        objBOLCus.NoOFDays = 0;
                        objBOLCus.UseNoOFDays = 0;
                        objBOLCus.CurrentInvoice = 0;
                        objBOLCus.UseCurrentInvoice = 0;
                        objBOLCus.Status = 1;
                        objBOLCus.ModifiedTime = DateTime.Now;
                        objBOLCus.ModifiedID = ClsCommon.UserID;
                        objBALCus.UpdateStatus(objBOLCus);
                        MessageBox.Show("Remove Successfully");
                        //    }
                        //}
                    }
                    DateWiseInvoiceLoad();
                }

                //if (e.ColumnIndex == 9)
                //{
                //    if (ClsCommon.FunctionVisibility("Approve", "AdminRequestList"))
                //    {
                //        FrmAdminApprove obj = new FrmAdminApprove();
                //        obj.RequestID = dgvRequestList.CurrentRow.Cells["ID"].Value.ToString();
                //        obj.Show();
                //        LoadData();
                //    }
                //    else
                //        MessageBox.Show("You can not access");
                //}
                //else if (e.ColumnIndex == 10)
                //{
                //    if (ClsCommon.FunctionVisibility("Reject", "AdminRequestList"))
                //    {
                //        objBOLCus.ID = Convert.ToInt32(dgvRequestList.CurrentRow.Cells["ID"].Value.ToString());
                //        objBOLCus.Status = 2;
                //        objBOLCus.IsActive = 0;
                //        objBOLCus.ModifiedTime = DateTime.Now;
                //        objBOLCus.ModifiedID = ClsCommon.UserID;
                //        objBALCus.UpdateRejectStatus(objBOLCus);
                //        LoadData();
                //    }
                //    else
                //        MessageBox.Show("You can not access");
                //}
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerRequest,Function :dgvRequestList_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void FrmAdminRequestList_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ClsCommon.ObjAdminRequestList.Hide();
                ClsCommon.ObjAdminRequestList.Parent = null;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerRequest,Function :FrmAdminRequestList_FormClosing. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }

        }

        private void PnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                foreach (DataGridViewColumn column in dgvRequestList.Columns)
                {
                    dt.Columns.Add(column.HeaderText);
                }
                foreach (DataGridViewRow row in dgvRequestList.Rows)
                {
                    dt.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                        {
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                        }
                    }
                }
                // dt = new BALItemMaster().SelectByQtyOnHand();
                if (dt.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    sfd.RestoreDirectory = true;
                    sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "Sheet1");
                            wb.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Export Successfully");
                    }
                    var app = new Microsoft.Office.Interop.Excel.Application();
                    app.Visible = true;
                    app.Workbooks.Open(sfd.FileName, ReadOnly: false);
                }

            }

            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemList,Function :btnExport_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }


        public void DateWiseInvoiceLoad()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lblFrom.Visible = false; lblto.Visible = false; dtTranFrom.Visible = false; dtTranTo.Visible = false;

                if (cmbTransactionsFilterDate.SelectedIndex == 0)
                {
                    dtAdminRequest = new DataTable();
                    dtAdminRequest = new BALCustomerRequest().SelectByFilter(new BOLCustomerRequest() { StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 1)
                {
                    dtAdminRequest = new DataTable();
                    DateTime dt1 = DateTime.Now.AddDays(-1);
                    dtAdminRequest = new BALCustomerRequest().SelectByFilter(new BOLCustomerRequest() { StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 2)
                {
                    dtAdminRequest = new DataTable();
                    DateTime dt = DateTime.Now;
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    dtAdminRequest = new BALCustomerRequest().SelectByFilter(new BOLCustomerRequest() { StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 3)
                {
                    dtAdminRequest = new DataTable();
                    DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
                    DateTime dt1 = dt.AddDays(6);
                    dtAdminRequest = new BALCustomerRequest().SelectByFilter(new BOLCustomerRequest() { StartDate = dt.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 4)
                {
                    dtAdminRequest = new DataTable();
                    DateTime dt = DateTime.Now.AddMonths(-1);
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    dtAdminRequest = new BALCustomerRequest().SelectByFilter(new BOLCustomerRequest() { StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 5)
                {
                    dtAdminRequest = new DataTable();
                    int year = DateTime.Now.Year;
                    DateTime firstDay = Convert.ToDateTime(year + "-" + "01" + "-" + "01");
                    dtAdminRequest = new BALCustomerRequest().SelectByFilter(new BOLCustomerRequest() { StartDate = firstDay.ToString("yyyy-MM-dd"), EndDate = firstDay.AddYears(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 6)
                {
                    dtAdminRequest = new DataTable();
                    dtAdminRequest = new BALCustomerRequest().SelectByFilter(new BOLCustomerRequest() { StartDate = null, EndDate = null });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 7)
                {
                    dtAdminRequest = new DataTable();
                    lblFrom.Visible = true; lblto.Visible = true; dtTranFrom.Visible = true; dtTranTo.Visible = true;
                }

                if (dtAdminRequest.Rows.Count > 0)
                {
                    dgvRequestList.Rows.Clear();

                    for (int i = 0; i < dtAdminRequest.Rows.Count; i++)
                    {
                        dgvRequestList.Rows.Add();

                        dgvRequestList.Rows[i].Cells["ID"].Value = dtAdminRequest.Rows[i]["ID"].ToString();
                        dgvRequestList.Rows[i].Cells["InvoiceID"].Value = dtAdminRequest.Rows[i]["InvoiceID"].ToString();
                        dgvRequestList.Rows[i].Cells["CustomerName"].Value = dtAdminRequest.Rows[i]["CustomerFullName"].ToString();
                        dgvRequestList.Rows[i].Cells["InvoiceNo"].Value = dtAdminRequest.Rows[i]["InvoiceNumber"].ToString();
                        dgvRequestList.Rows[i].Cells["ItemName"].Value = dtAdminRequest.Rows[i]["ItemFullName"].ToString();
                        dgvRequestList.Rows[i].Cells["Date"].Value = dtAdminRequest.Rows[i]["CreatedTime"].ToString();
                        dgvRequestList.Rows[i].Cells["SalesRepName"].Value = dtAdminRequest.Rows[i]["SalesRepName"].ToString();
                        dgvRequestList.Rows[i].Cells["PurchaseCost"].Value = dtAdminRequest.Rows[i]["PurchaseCost"].ToString();
                        dgvRequestList.Rows[i].Cells["ComparativePrice1"].Value = dtAdminRequest.Rows[i]["ComparativePrice1"].ToString();
                        dgvRequestList.Rows[i].Cells["ComparativePrice2"].Value = dtAdminRequest.Rows[i]["ComparativePrice2"].ToString();
                        dgvRequestList.Rows[i].Cells["ComparativePrice3"].Value = dtAdminRequest.Rows[i]["ComparativePrice3"].ToString();
                        dgvRequestList.Rows[i].Cells["ComparativePrice4"].Value = dtAdminRequest.Rows[i]["ComparativePrice4"].ToString();
                        dgvRequestList.Rows[i].Cells["ComparativePrice5"].Value = dtAdminRequest.Rows[i]["ComparativePrice5"].ToString();
                        dgvRequestList.Rows[i].Cells["CurrentLowestPrice"].Value = dtAdminRequest.Rows[i]["ItemLowestPrice"].ToString();
                        dgvRequestList.Rows[i].Cells["UserLowestPrice"].Value = dtAdminRequest.Rows[i]["LowestPrice"].ToString();
                        dgvRequestList.Rows[i].Cells["Status"].Value = dtAdminRequest.Rows[i]["Status"].ToString();

                        if (dtAdminRequest.Columns.Contains("Status"))
                        {
                            var statusValue = dtAdminRequest.Rows[i]["Status"].ToString();
                            dgvRequestList.Rows[i].Cells["Status"].Value = statusValue;
                            if (statusValue == "1")
                            {
                                dgvRequestList.Rows[i].Cells["Status"].Value = "Approved";
                            }
                            else if (statusValue == "2")
                            {
                                dgvRequestList.Rows[i].Cells["Status"].Style.ForeColor = Color.Red;
                                dgvRequestList.Rows[i].Cells["Status"].Value = "Rejected";
                            }
                            else
                            {
                                dgvRequestList.Rows[i].Cells["Status"].Value = "Pending";
                            }
                        }
                    }
                }
                else
                {
                    dgvRequestList.Rows.Clear();
                }
                Cursor.Current = Cursors.Default;
                lblTotal.Text = dtAdminRequest.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmAdminRequestList,Function :DateWiseInvoiceLoad. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void cmbTransactionsFilterDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTransactionsFilterDate.SelectedIndex >= 0)
            {
                DateWiseInvoiceLoad();
            }
        }

        private void dtTranTo_Leave(object sender, EventArgs e)
        {
            dtAdminRequest = new DataTable();
            dtAdminRequest = new BALCustomerRequest().SelectByFilter(new BOLCustomerRequest() { StartDate = dtTranFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTranTo.Value.ToString("yyyy-MM-dd") });
            if (dtAdminRequest.Rows.Count > 0)
            {
                dgvRequestList.Rows.Clear();

                for (int i = 0; i < dtAdminRequest.Rows.Count; i++)
                {
                    dgvRequestList.Rows.Add();

                    dgvRequestList.Rows[i].Cells["ID"].Value = dtAdminRequest.Rows[i]["ID"].ToString();
                    dgvRequestList.Rows[i].Cells["InvoiceID"].Value = dtAdminRequest.Rows[i]["InvoiceID"].ToString();
                    dgvRequestList.Rows[i].Cells["CustomerName"].Value = dtAdminRequest.Rows[i]["CustomerFullName"].ToString();
                    dgvRequestList.Rows[i].Cells["InvoiceNo"].Value = dtAdminRequest.Rows[i]["InvoiceNumber"].ToString();
                    dgvRequestList.Rows[i].Cells["ItemName"].Value = dtAdminRequest.Rows[i]["ItemFullName"].ToString();
                    dgvRequestList.Rows[i].Cells["Date"].Value = dtAdminRequest.Rows[i]["CreatedTime"].ToString();
                    dgvRequestList.Rows[i].Cells["SalesRepName"].Value = dtAdminRequest.Rows[i]["SalesRepName"].ToString();
                    dgvRequestList.Rows[i].Cells["PurchaseCost"].Value = dtAdminRequest.Rows[i]["PurchaseCost"].ToString();
                    dgvRequestList.Rows[i].Cells["ComparativePrice1"].Value = dtAdminRequest.Rows[i]["ComparativePrice1"].ToString();
                    dgvRequestList.Rows[i].Cells["ComparativePrice2"].Value = dtAdminRequest.Rows[i]["ComparativePrice2"].ToString();
                    dgvRequestList.Rows[i].Cells["ComparativePrice3"].Value = dtAdminRequest.Rows[i]["ComparativePrice3"].ToString();
                    dgvRequestList.Rows[i].Cells["ComparativePrice4"].Value = dtAdminRequest.Rows[i]["ComparativePrice4"].ToString();
                    dgvRequestList.Rows[i].Cells["ComparativePrice5"].Value = dtAdminRequest.Rows[i]["ComparativePrice5"].ToString();
                    dgvRequestList.Rows[i].Cells["CurrentLowestPrice"].Value = dtAdminRequest.Rows[i]["ItemLowestPrice"].ToString();
                    dgvRequestList.Rows[i].Cells["UserLowestPrice"].Value = dtAdminRequest.Rows[i]["LowestPrice"].ToString();
                    dgvRequestList.Rows[i].Cells["Status"].Value = dtAdminRequest.Rows[i]["Status"].ToString();

                    if (dtAdminRequest.Columns.Contains("Status"))
                    {
                        var statusValue = dtAdminRequest.Rows[i]["Status"].ToString();
                        dgvRequestList.Rows[i].Cells["Status"].Value = statusValue;
                        if (statusValue == "1")
                        {
                            dgvRequestList.Rows[i].Cells["Status"].Value = "Approved";
                        }
                        else if (statusValue == "2")
                        {
                            dgvRequestList.Rows[i].Cells["Status"].Style.ForeColor = Color.Red;
                            dgvRequestList.Rows[i].Cells["Status"].Value = "Rejected";
                        }
                        else
                        {
                            dgvRequestList.Rows[i].Cells["Status"].Value = "Pending";
                        }
                    }
                }
            }
            else
            {
                dgvRequestList.Rows.Clear();
            }
            Cursor.Current = Cursors.Default;
            lblTotal.Text = dtAdminRequest.Rows.Count.ToString();
        }
    }
}