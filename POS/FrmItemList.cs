using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace POS
{
    public partial class FrmItemList : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dt = new DataTable();
        BALItemMaster ObjItemBAL = new BALItemMaster();
        BOLItemMaster ObjItemBOL = new BOLItemMaster();
        BALGroupSubItem ObjGroupItemBAL = new BALGroupSubItem();
        BOLGroupSubItem ObjGroupItemBOL = new BOLGroupSubItem();
        bool isSorting = false;

        public FrmItemList()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 50);
            LoadItem();
        }
        private void FrmItemList_Load(object sender, EventArgs e)
        {
            try
            {
                //Delete Button
                DataGridViewLinkColumn DeleteButton = new DataGridViewLinkColumn();
                DeleteButton.UseColumnTextForLinkValue = true;
                DeleteButton.HeaderText = "Delete";
                DeleteButton.DataPropertyName = "Delete";
                DeleteButton.Text = "Delete";
                dgvItemList.Columns.Add(DeleteButton);

                //Print Button
                DataGridViewLinkColumn PrintButton = new DataGridViewLinkColumn();
                PrintButton.UseColumnTextForLinkValue = true;
                PrintButton.HeaderText = "Print";
                PrintButton.DataPropertyName = "Print";
                PrintButton.Text = "Print";
                dgvItemList.Columns.Add(PrintButton);

                this.dgvItemList.DefaultCellStyle.Font = new Font("", 10);
                dgvItemList.RowTemplate.Height = 25;
                dgvItemList.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvItemList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dgvItemList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                dgvItemList.EnableHeadersVisualStyles = false;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemList, Function :FrmItemList_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void LoadItem()
        {
            if (txtItemName.Text == "")
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    //txtItemName.Text = "";
                    DataTable dtActive = new BALItemMaster().SelectInActiveItemName(new BOLItemMaster() { });
                    if (dtActive.Rows.Count == 0)
                        chkActive.Enabled = false;
                    else
                        chkActive.Enabled = true;

                    if (chkActive.Checked == true)
                    {
                        dt = new DataTable();
                        dt = new BALItemMaster().Select(new BOLItemMaster() { });
                        if (dt.Rows.Count > 0)
                        {
                            int j = 0;
                            dgvItemList.Rows.Clear();
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dgvItemList.Rows.Add();
                                dgvItemList.Rows[j].Cells["ID"].Value = dt.Rows[i]["ID"].ToString();
                                if (dt.Rows[i]["IsActive"].ToString() == "0")
                                    dgvItemList.Rows[j].Cells["InActive"].Value = "X";
                                else
                                    dgvItemList.Rows[j].Cells["InActive"].Value = "";
                                dgvItemList.Rows[j].Cells["ItemName"].Value = dt.Rows[i]["FullName"].ToString();
                                dgvItemList.Rows[j].Cells["Description"].Value = dt.Rows[i]["SalesDesc"].ToString();
                                dgvItemList.Rows[j].Cells["Type"].Value = dt.Rows[i]["ItemType"].ToString();
                                dgvItemList.Rows[j].Cells["Account"].Value = dt.Rows[i]["IncomeAccount"].ToString();
                                dgvItemList.Rows[j].Cells["TotalQtyOnHand"].Value = dt.Rows[i]["QtyOnHand"].ToString();
                                dgvItemList.Rows[j].Cells["Price"].Value = dt.Rows[i]["SalesPrice"].ToString();
                                dgvItemList.Rows[j].Cells["COST"].Value = dt.Rows[i]["PurchaseCost"].ToString();
                                dgvItemList.Rows[j].Cells["CreatedDate"].Value = Convert.ToDateTime(dt.Rows[i]["CreatedTime"].ToString()).ToShortDateString();
                                dgvItemList.Rows[j].Cells["SalesRep"].Value = dt.Rows[i]["SalesRep"].ToString();
                                dgvItemList.Rows[j].Cells["FilterName"].Value = dt.Rows[i]["FilterName"].ToString();

                                j++;
                            }
                        }
                        else
                        {
                            dgvItemList.Rows.Clear();
                        }
                    }
                    else
                    {
                        dt = new DataTable();
                        dt = new BALItemMaster().SelectActiveItemName(new BOLItemMaster() { });
                        if (dt.Rows.Count > 0)
                        {
                            int j = 0;
                            dgvItemList.Rows.Clear();
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dgvItemList.Rows.Add();
                                dgvItemList.Rows[j].Cells["ID"].Value = dt.Rows[i]["ID"].ToString();
                                if (dt.Rows[i]["IsActive"].ToString() == "0")
                                    dgvItemList.Rows[j].Cells["InActive"].Value = "X";
                                else
                                    dgvItemList.Rows[j].Cells["InActive"].Value = "";
                                dgvItemList.Rows[j].Cells["ItemName"].Value = dt.Rows[i]["FullName"].ToString();
                                dgvItemList.Rows[j].Cells["Description"].Value = dt.Rows[i]["SalesDesc"].ToString();
                                dgvItemList.Rows[j].Cells["Type"].Value = dt.Rows[i]["ItemType"].ToString();
                                dgvItemList.Rows[j].Cells["Account"].Value = dt.Rows[i]["IncomeAccount"].ToString();
                                dgvItemList.Rows[j].Cells["TotalQtyOnHand"].Value = dt.Rows[i]["QtyOnHand"].ToString();
                                dgvItemList.Rows[j].Cells["Price"].Value = dt.Rows[i]["SalesPrice"].ToString();
                                dgvItemList.Rows[j].Cells["COST"].Value = dt.Rows[i]["PurchaseCost"].ToString();
                                dgvItemList.Rows[j].Cells["CreatedDate"].Value = Convert.ToDateTime(dt.Rows[i]["CreatedTime"].ToString()).ToShortDateString();
                                dgvItemList.Rows[j].Cells["SalesRep"].Value = dt.Rows[i]["SalesRep"].ToString();
                                dgvItemList.Rows[j].Cells["FilterName"].Value = dt.Rows[i]["FilterName"].ToString();
                                j++;
                            }
                        }
                        else
                        {
                            dgvItemList.Rows.Clear();
                        }
                    }
                    Cursor.Current = Cursors.Default;
                    lblTotal.Text = dt.Rows.Count.ToString();
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    ClsCommon.WriteErrorLogs("Form:FrmItemList, Function :LoadItem. Message:" + ex.Message);
                    MessageBox.Show("Error:" + ex.Message);
                }
            }
            else
            {
                ItemSerachLoad();
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text != "")
            {
                txtItemName.Text = "";
                LoadItem();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ItemSerachLoad();
        }
        public void ItemSerachLoad()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtItemName.Text != "")
                {
                    dt = new BALItemMaster().Select(new BOLItemMaster() { });
                    DataRow[] row = dt.Select("ItemName like '%" + txtItemName.Text + "%' OR SalesDesc like '%" + txtItemName.Text + "%' OR ItemType like '%" + txtItemName.Text + "%' OR IncomeAccount like '%" + txtItemName.Text + "%' OR  SalesRep like '%" + txtItemName.Text + "%' OR FilterName like '%" + txtItemName.Text + "%'");
                    if (row.Length > 0)
                    {
                        DataTable dtNew = row.CopyToDataTable();

                        int j = 0;
                        dgvItemList.Rows.Clear();
                        for (int i = 0; i < dtNew.Rows.Count; i++)
                        {
                            dgvItemList.Rows.Add();
                            dgvItemList.Rows[j].Cells["ID"].Value = dtNew.Rows[i]["ID"].ToString();
                            if (dtNew.Rows[i]["IsActive"].ToString() == "0")
                                dgvItemList.Rows[j].Cells["InActive"].Value = "X";
                            else
                                dgvItemList.Rows[j].Cells["InActive"].Value = "";
                            dgvItemList.Rows[j].Cells["ItemName"].Value = dtNew.Rows[i]["FullName"].ToString();
                            dgvItemList.Rows[j].Cells["Description"].Value = dtNew.Rows[i]["SalesDesc"].ToString();
                            dgvItemList.Rows[j].Cells["Type"].Value = dtNew.Rows[i]["ItemType"].ToString();
                            dgvItemList.Rows[j].Cells["Account"].Value = dtNew.Rows[i]["IncomeAccount"].ToString();
                            dgvItemList.Rows[j].Cells["TotalQtyOnHand"].Value = dtNew.Rows[i]["QtyOnHand"].ToString();
                            dgvItemList.Rows[j].Cells["Price"].Value = dtNew.Rows[i]["SalesPrice"].ToString();
                            dgvItemList.Rows[j].Cells["COST"].Value = dtNew.Rows[i]["PurchaseCost"].ToString();
                            dgvItemList.Rows[j].Cells["CreatedDate"].Value = Convert.ToDateTime(dtNew.Rows[i]["CreatedTime"].ToString()).ToShortDateString();
                            dgvItemList.Rows[j].Cells["SalesRep"].Value = dtNew.Rows[i]["SalesRep"].ToString();
                            dgvItemList.Rows[j].Cells["FilterName"].Value = dtNew.Rows[i]["FilterName"].ToString();

                            j++;
                        }
                        lblTotal.Text = dtNew.Rows.Count.ToString();
                    }
                    else
                    {
                        dgvItemList.Rows.Clear();
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmItemList,Function :btnSearch_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("Insert", "ItemList"))
                {
                    ClsCommon.ObjItemMaster.Mode = "insert";
                    ClsCommon.ObjItemMaster.Text = "New Item";
                    ClsCommon.ObjItemMaster.ShowDialog();
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemList,Function :btnAddNew_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadItem();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemList,Function :chkActive_CheckedChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgvItemList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 12 && e.ColumnIndex != 13)
                {
                    if (ClsCommon.FunctionVisibility("Update", "ItemList"))
                    {
                        ClsCommon.ObjItemMaster.LoadFunction();
                        ClsCommon.ObjItemMaster.ShowType(dgvItemList.CurrentRow.Cells["Type"].Value.ToString());
                        ClsCommon.ObjItemMaster.LoadData(dgvItemList.CurrentRow.Cells["ID"].Value.ToString());
                        ClsCommon.ObjItemMaster.ShowDialog();
                        //LoadItem();
                    }
                    else
                        MessageBox.Show("You can not access");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemList,Function :dgvItemList_CellContentDoubleClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgvItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 12)
                {
                    if (ClsCommon.FunctionVisibility("Delete", "ItemList"))
                    {
                        DataTable dtItem = new BALInvoiceDetails().SelectByItemID(new BOLInvoiceDetails() { ItemID = Convert.ToInt32(dgvItemList.CurrentRow.Cells["ID"].Value.ToString()) });
                        if (dtItem.Rows.Count == 0)
                        {
                            DialogResult result = MessageBox.Show("Are you sure to delete this record?", "Confirmation", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                if (dgvItemList.CurrentRow.Cells["Type"].Value.ToString() == "SalesTaxItem")
                                {
                                    int SalesTaxID = Convert.ToInt32(dgvItemList.CurrentRow.Cells["ID"].Value.ToString());
                                    ObjItemBAL.UpdateInactive(SalesTaxID);
                                    MessageBox.Show("Record delete successfully");
                                }
                                else
                                {
                                    DataTable dtParent = new BALItemMaster().SelectByParentID(new BOLItemMaster() { ParentID = Convert.ToInt32(dgvItemList.CurrentRow.Cells["ID"].Value.ToString()) });
                                    if (dtParent.Rows.Count > 0)
                                    {
                                        MessageBox.Show("You can delete an item that has subitems.Delete or move the subitems first.", "Warning");
                                    }
                                    else
                                    {
                                        ObjItemBOL.ID = Convert.ToInt32(dgvItemList.CurrentRow.Cells["ID"].Value.ToString());
                                        ObjGroupItemBOL.GroupItemID = Convert.ToInt32(dgvItemList.CurrentRow.Cells["ID"].Value.ToString());
                                        ObjItemBAL.Delete(ObjItemBOL);
                                        ObjGroupItemBAL.DeleteByGroupID(ObjGroupItemBOL);
                                        MessageBox.Show("Record delete successfully");
                                    }
                                }
                                LoadItem();
                            }
                        }
                        else
                        {
                            MessageBox.Show("You cannot delete this item because it is used in Transactions ", "Warning");
                        }
                    }
                    else
                        MessageBox.Show("You can not access");
                }
                else if (e.ColumnIndex == 13)
                {
                    if (ClsCommon.FunctionVisibility("Print", "ItemList"))
                    {
                        DataTable dtItemSaleReport = new BALItemSaleHistory().SelectItemSaleHistory(new BOLItemSaleHistory() { ItemID = Convert.ToInt32(dgvItemList.CurrentRow.Cells["ID"].Value.ToString()) });
                        if (dtItemSaleReport.Rows.Count > 0)
                        {
                            rptItemWiseSaleHistoryReport cryRptSaleHistoryReport = new rptItemWiseSaleHistoryReport();
                            cryRptSaleHistoryReport.Database.Tables[0].SetDataSource(dtItemSaleReport);

                            FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                            crViewer.Text = "Item Sale History Report";
                            crViewer.crystalReportViewer.ReportSource = cryRptSaleHistoryReport;
                            crViewer.Show();
                        }
                        else
                        {
                            MessageBox.Show("No records found");
                        }
                    }
                    else
                        MessageBox.Show("You can not access");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemList,Function :dgvItemList_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void FrmItemList_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtItemName.Text = "";
            ClsCommon.ObjItemList.Hide();
            ClsCommon.ObjItemList.Parent = null;
            e.Cancel = true;
        }

        //private void dgvItemList_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.ColumnIndex != 12 && e.ColumnIndex != 13)
        //        {
        //            if (ClsCommon.FunctionVisibility("Update", "ItemList"))
        //            {
        //                ClsCommon.ObjItemMaster.LoadFunction();
        //                ClsCommon.ObjItemMaster.ShowType(dgvItemList.CurrentRow.Cells["Type"].Value.ToString());
        //                ClsCommon.ObjItemMaster.LoadData(dgvItemList.CurrentRow.Cells["ID"].Value.ToString());
        //                ClsCommon.ObjItemMaster.ShowDialog();
        //                //LoadItem();
        //            }
        //            else
        //                MessageBox.Show("You can not access");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ClsCommon.WriteErrorLogs("Form:FrmItemList,Function :dgvItemList_CellContentDoubleClick. Message:" + ex.Message);
        //        MessageBox.Show("Error:" + ex.Message);
        //    }
        //}

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                dt = new BALItemMaster().SelectItemForRead();
                if (dt.Rows.Count > 0)
                {
                    //SaveFileDialog sfd = new SaveFileDialog();
                    //sfd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    //sfd.FilterIndex = 1;
                    //sfd.RestoreDirectory = true;
                    //sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    //if (sfd.ShowDialog() == DialogResult.OK)
                    //{
                    //    Cursor.Current = Cursors.WaitCursor;
                    //    using (XLWorkbook wb = new XLWorkbook())
                    //    {
                    //        wb.Worksheets.Add(dt, "Sheet1");
                    //        wb.SaveAs(sfd.FileName);
                    //    }
                    //    MessageBox.Show("Export Successfully");
                    //}


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

            }

            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemList,Function :btnExport_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                string FilePath = "";
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FilePath = openFileDialog1.FileName;
                }
                DataTable dt = new DataTable();
                using (XLWorkbook workbook = new XLWorkbook(FilePath))
                {
                    IXLWorksheet worksheet = workbook.Worksheet(1);
                    bool FirstRow = true;
                    string readRange = "1:1";
                    foreach (IXLRow row in worksheet.RowsUsed())
                    {
                        if (FirstRow)
                        {
                            readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                            foreach (IXLCell cell in row.Cells(readRange))
                            {
                                dt.Columns.Add(cell.Value.ToString());
                            }
                            FirstRow = false;
                        }
                        else
                        {
                            dt.Rows.Add();
                            int cellIndex = 0;
                            foreach (IXLCell cell in row.Cells(readRange))
                            {
                                dt.Rows[dt.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                cellIndex++;

                            }
                        }
                    }
                    if (FirstRow)
                    {
                        MessageBox.Show("Empty Excel File!");
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ObjItemBOL = new BOLItemMaster();
                        if (dr["FilterName"].ToString() != "")
                        {
                            DataTable dtFilterName = new BALFilterMater().SelectByName(new BOLFilterMater() { FilterName = dr["FilterName"].ToString() });
                            if (dtFilterName.Rows.Count > 0)
                            {
                                ObjItemBOL.FilterID = Convert.ToInt32(dtFilterName.Rows[0]["ID"].ToString());
                            }
                            else
                            {
                                ObjItemBOL.FilterID = 0;
                            }
                        }
                        else
                        {
                            ObjItemBOL.FilterID = 0;
                        }

                        ObjItemBOL.FullName = dr["FullName"].ToString();
                        ObjItemBOL.SalesDesc = dr["SalesDesc"].ToString();
                        if (dr["SalesPrice"].ToString() != "")
                        {
                            ObjItemBOL.SalesPrice = Convert.ToDecimal(dr["SalesPrice"].ToString());
                        }
                        ObjItemBOL.PurchaseDesc = dr["PurchaseDesc"].ToString();
                        if (dr["PurchaseCost"].ToString() != "")
                        {
                            ObjItemBOL.PurchaseCost = Convert.ToDecimal(dr["PurchaseCost"].ToString());
                        }
                        if (dr["QtyOnHand"].ToString() != "")
                        {
                            ObjItemBOL.QtyOnHand = Convert.ToDecimal(dr["QtyOnHand"].ToString());
                        }
                        if (dr["TierGF"].ToString() != "")
                        {
                            ObjItemBOL.PriceTier1 = Convert.ToDecimal(dr["TierGF"].ToString());
                        }
                        if (dr["TierP4C"].ToString() != "")
                        {
                            ObjItemBOL.PriceTier2 = Convert.ToDecimal(dr["TierP4C"].ToString());
                        }
                        if (dr["TierMS"].ToString() != "")
                        {
                            ObjItemBOL.PriceTier3 = Convert.ToDecimal(dr["TierMS"].ToString());
                        }
                        ObjItemBAL.UpdatePrice(ObjItemBOL);
                    }
                    MessageBox.Show("File Read Successfully");
                    LoadItem();
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemList,Function :btnImport_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        //Hiren Change
        private void dgvItemList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            string columnName = dgvItemList.Columns[e.ColumnIndex].Name;

            if (columnName == "CreatedDate")
            {
                List<DataGridViewRow> rows = new List<DataGridViewRow>();

                foreach (DataGridViewRow row in dgvItemList.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        rows.Add(row);
                    }
                }

                if (dgvItemList.Tag == null || dgvItemList.Tag.ToString() == "ASC")
                {
                    rows = rows.OrderByDescending(r => Convert.ToDateTime(r.Cells["CreatedDate"].Value)).ToList();
                    dgvItemList.Tag = "DESC";
                }
                else
                {
                    rows = rows.OrderBy(r => Convert.ToDateTime(r.Cells["CreatedDate"].Value)).ToList();
                    dgvItemList.Tag = "ASC";
                }

                dgvItemList.Rows.Clear();

                foreach (DataGridViewRow sortedRow in rows)
                {
                    int rowIndex = dgvItemList.Rows.Add();
                    for (int i = 0; i < sortedRow.Cells.Count; i++)
                    {
                        dgvItemList.Rows[rowIndex].Cells[i].Value = sortedRow.Cells[i].Value;
                    }
                }

            }

        }
    }
}