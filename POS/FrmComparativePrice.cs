using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmComparativePrice : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dt = new DataTable();
        BALItemMaster ObjItemBAL = new BALItemMaster();
        BOLItemMaster ObjItemBOL = new BOLItemMaster();
        BALGroupSubItem ObjGroupItemBAL = new BALGroupSubItem();
        BOLGroupSubItem ObjGroupItemBOL = new BOLGroupSubItem();

        public FrmComparativePrice()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 50);
        }

        private void FrmLowestPriceItemList_Load(object sender, EventArgs e)
        {
            try
            {
             

                this.dgvItemList.DefaultCellStyle.Font = new Font("", 10);
                dgvItemList.RowTemplate.Height = 25;
                dgvItemList.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvItemList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dgvItemList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                dgvItemList.EnableHeadersVisualStyles = false;

                lblTotal.Text = "0";
                LoadItem();
            }
            catch (Exception ex)
            {            
                ClsCommon.WriteErrorLogs("Form:FrmLowestPriceItemList, Function :FrmLowestPriceItemList_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void LoadItem()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                txtItemName.Text = "";
                dt = new BALItemMaster().Select(new BOLItemMaster() { });
                if (dt.Rows.Count > 0)
                {
                    int j = 0;
                    dgvItemList.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvItemList.Rows.Add();
                        dgvItemList.Rows[j].Cells["ID"].Value = dt.Rows[i]["ID"].ToString();
                        dgvItemList.Rows[j].Cells["FilterName"].Value = dt.Rows[i]["FilterName"].ToString();
                        dgvItemList.Rows[j].Cells["ItemName"].Value = dt.Rows[i]["FullName"].ToString();
                        dgvItemList.Rows[j].Cells["Description"].Value = dt.Rows[i]["SalesDesc"].ToString();
                        dgvItemList.Rows[j].Cells["Type"].Value = dt.Rows[i]["ItemType"].ToString();
                        dgvItemList.Rows[j].Cells["Account"].Value = dt.Rows[i]["IncomeAccount"].ToString();
                        dgvItemList.Rows[j].Cells["ComparativePrice1"].Value = dt.Rows[i]["ComparativePrice1"].ToString();
                        dgvItemList.Rows[j].Cells["C1Date"].Value = dt.Rows[i]["C1Date"].ToString();
                        dgvItemList.Rows[j].Cells["ComparativePrice2"].Value = dt.Rows[i]["ComparativePrice2"].ToString();
                        dgvItemList.Rows[j].Cells["C2Date"].Value = dt.Rows[i]["C2Date"].ToString();
                        dgvItemList.Rows[j].Cells["ComparativePrice3"].Value = dt.Rows[i]["ComparativePrice3"].ToString();
                        dgvItemList.Rows[j].Cells["C3Date"].Value = dt.Rows[i]["C3Date"].ToString();
                        dgvItemList.Rows[j].Cells["ComparativePrice4"].Value = dt.Rows[i]["ComparativePrice4"].ToString();
                        dgvItemList.Rows[j].Cells["C4Date"].Value = dt.Rows[i]["C4Date"].ToString();
                        dgvItemList.Rows[j].Cells["ComparativePrice5"].Value = dt.Rows[i]["ComparativePrice5"].ToString();
                        dgvItemList.Rows[j].Cells["C5Date"].Value = dt.Rows[i]["C5Date"].ToString();
                        j++;
                    }
                }
                else
                {
                    dgvItemList.Rows.Clear();
                }
                Cursor.Current = Cursors.Default;
                lblTotal.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmLowestPriceItemList, Function :LoadItem. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {      
             LoadItem();
             txtItemName.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtItemName.Text != "")
                {
                    DataRow[] row = dt.Select("ItemName like '%" + txtItemName.Text + "%' or FilterName like '%" + txtItemName.Text + "%' ");
                    if (row.Length > 0)
                    {
                        DataTable dtNew = row.CopyToDataTable();

                        int j = 0;
                        dgvItemList.Rows.Clear();
                        for (int i = 0; i < dtNew.Rows.Count; i++)
                        {
                            dgvItemList.Rows.Add();
                            dgvItemList.Rows[j].Cells["ID"].Value = dtNew.Rows[i]["ID"].ToString();
                            dgvItemList.Rows[j].Cells["ItemName"].Value = dtNew.Rows[i]["FullName"].ToString();
                            dgvItemList.Rows[j].Cells["FilterName"].Value = dtNew.Rows[i]["FilterName"].ToString();
                            dgvItemList.Rows[j].Cells["Description"].Value = dtNew.Rows[i]["SalesDesc"].ToString();
                            dgvItemList.Rows[j].Cells["Type"].Value = dtNew.Rows[i]["ItemType"].ToString();
                            dgvItemList.Rows[j].Cells["Account"].Value = dtNew.Rows[i]["IncomeAccount"].ToString();
                            dgvItemList.Rows[j].Cells["ComparativePrice1"].Value = dtNew.Rows[i]["ComparativePrice1"].ToString();
                            dgvItemList.Rows[j].Cells["C1Date"].Value = dtNew.Rows[i]["C1Date"].ToString();
                            dgvItemList.Rows[j].Cells["ComparativePrice2"].Value = dtNew.Rows[i]["ComparativePrice2"].ToString();
                            dgvItemList.Rows[j].Cells["C2Date"].Value = dtNew.Rows[i]["C2Date"].ToString();
                            dgvItemList.Rows[j].Cells["ComparativePrice3"].Value = dtNew.Rows[i]["ComparativePrice3"].ToString();
                            dgvItemList.Rows[j].Cells["C3Date"].Value = dtNew.Rows[i]["C3Date"].ToString();
                            dgvItemList.Rows[j].Cells["ComparativePrice4"].Value = dtNew.Rows[i]["ComparativePrice4"].ToString();
                            dgvItemList.Rows[j].Cells["C4Date"].Value = dtNew.Rows[i]["C4Date"].ToString();
                            dgvItemList.Rows[j].Cells["ComparativePrice5"].Value = dtNew.Rows[i]["ComparativePrice5"].ToString();
                            dgvItemList.Rows[j].Cells["C5Date"].Value = dtNew.Rows[i]["C5Date"].ToString();
                            j++;
                        }
                        lblTotal.Text = dtNew.Rows.Count.ToString();
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmLowestPriceItemList,Function :btnSearch_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
                                                                                                                            
        private void btmClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        //private void dgvItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.ColumnIndex == 8)
        //        {
        //            if (ClsCommon.FunctionVisibility("SetPrice", "SetLowestPrice"))
        //            {
        //                FrmSetLowestItemPrice obj = new FrmSetLowestItemPrice();
        //                obj.LoadItem(Convert.ToInt32(dgvItemList.CurrentRow.Cells["ID"].Value));
        //                obj.Show();
        //                LoadItem();
        //            }
        //            else
        //                MessageBox.Show("You can not access");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ClsCommon.WriteErrorLogs("Form:FrmLowestPriceItemList,Function :dgvItemList_CellContentClick. Message:" + ex.Message);
        //        MessageBox.Show("Error:" + ex.Message);
        //    }
        //}

        private void dgvItemList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void FrmLowestPriceItemList_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClsCommon.ObjComparativePrice.Hide();
            ClsCommon.ObjComparativePrice.Parent = null;
            e.Cancel = true;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                dt = new BALItemMaster().SelectByComparativePrice();
                if (dt.Rows.Count > 0)
                {
                    dt.Columns.Remove("ID");
                    dt.Columns["ComparativePrice1"].ColumnName = "Ms";
                    //dt.Columns["C1Date"].ColumnName = "MsDate";
                    dt.Columns["ComparativePrice2"].ColumnName = "P4s";
                    //dt.Columns["C2Date"].ColumnName = "P4sDate";
                    dt.Columns["ComparativePrice3"].ColumnName = "NC";
                    dt.Columns["GfDate"].ColumnName = "NCDate";
                    dt.Columns["ComparativePrice4"].ColumnName = "XCELL";
                    //dt.Columns["C4Date"].ColumnName = "XCELLDate";
                    dt.Columns["ComparativePrice5"].ColumnName = "p4s-D";
                    //dt.Columns["C5Date"].ColumnName = "p4s-DDate";
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

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                string FilePath = "";
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FilePath = openFileDialog1.FileName;
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

                            //if (dr["FilterName"].ToString() != "")
                            //{
                            //    DataTable dtFilterName = new BALFilterMater().SelectByName(new BOLFilterMater() { FilterName = dr["FilterName"].ToString() });
                            //    if (dtFilterName.Rows.Count > 0)
                            //    {
                            //        ObjItemBOL.FilterID = Convert.ToInt32(dtFilterName.Rows[0]["ID"].ToString());
                            //    }
                            //    else
                            //    {
                            //        ObjItemBOL.FilterID = 0;
                            //    }
                            //}
                            //else
                            //{
                            //    ObjItemBOL.FilterID = 0;
                            //}
                            ObjItemBOL.ItemName = dr["FullName"].ToString();
                            if (dt.Columns.Contains("Ms") == true)
                            {
                                if (dr["Ms"].ToString() != "")
                                    ObjItemBOL.ComparativePrice1 = Convert.ToDecimal(dr["Ms"].ToString());
                            }
                            if (dt.Columns.Contains("P4s") == true)
                            {
                                if (dr["P4s"].ToString() != "")
                                    ObjItemBOL.ComparativePrice2 = Convert.ToDecimal(dr["P4s"].ToString());
                            }
                            if (dt.Columns.Contains("NC") == true)
                            {
                                if (dr["NC"].ToString() != "")
                                    ObjItemBOL.ComparativePrice3 = Convert.ToDecimal(dr["NC"].ToString());
                            }
                            if (dt.Columns.Contains("XCELL") == true)
                            {
                                if (dr["XCELL"].ToString() != "")
                                    ObjItemBOL.ComparativePrice4 = Convert.ToDecimal(dr["XCELL"].ToString());
                            }
                            if (dt.Columns.Contains("P4s-D") == true)
                            {
                                if (dr["P4s-D"].ToString() != "")
                                    ObjItemBOL.ComparativePrice5 = Convert.ToDecimal(dr["P4s-D"].ToString());
                            }
                            ObjItemBAL.UpdateComparativePrice(ObjItemBOL);
                        }
                        MessageBox.Show("File Read Successfully");
                        LoadItem();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Excel File");

                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemList,Function :btnImport_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void FrmComparativePrice_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvItemList.DefaultCellStyle.Font = new Font("", 10);
                dgvItemList.RowTemplate.Height = 25;
                dgvItemList.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvItemList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dgvItemList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                dgvItemList.EnableHeadersVisualStyles = false;

                lblTotal.Text = "0";
                LoadItem();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmLowestPriceItemList, Function :FrmLowestPriceItemList_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgvItemList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dgvItemList.Columns[e.ColumnIndex].Name;


            if (columnName == "C1Date" || columnName == "C2Date" || columnName == "C3Date" || columnName == "C4Date" || columnName == "C5Date")
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
                    rows = rows
                        .OrderByDescending(r =>
                            string.IsNullOrWhiteSpace(Convert.ToString(r.Cells[columnName].Value))
                                ? DateTime.MinValue
                                : Convert.ToDateTime(r.Cells[columnName].Value))
                        .ToList();                    //rows = rows.OrderByDescending(r => Convert.ToDateTime(r.Cells[columnName].Value)).ToList();

                    dgvItemList.Tag = "DESC";
                }
                else
                {

                    //rows = rows.OrderBy(r => Convert.ToDateTime(r.Cells[columnName].Value)).ToList();

                    rows = rows
                        .OrderBy(r =>
                            string.IsNullOrWhiteSpace(Convert.ToString(r.Cells[columnName].Value))
                                ? DateTime.MinValue
                                : Convert.ToDateTime(r.Cells[columnName].Value))
                        .ToList();

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
            else if (columnName == "ComparativePrice1" || columnName == "ComparativePrice2" || columnName == "ComparativePrice3" || columnName == "ComparativePrice4" || columnName == "ComparativePrice5")
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
                    rows = rows.OrderByDescending(r => string.IsNullOrWhiteSpace(Convert.ToString(r.Cells[columnName].Value)) ? decimal.MinValue : Convert.ToDecimal(r.Cells[columnName].Value)).ToList();

                    //rows = rows.OrderByDescending(r => Convert.ToDecimal(r.Cells[columnName].Value)).ToList();

                    dgvItemList.Tag = "DESC";
                }
                else
                {
                    rows = rows.OrderBy(r => string.IsNullOrWhiteSpace(Convert.ToString(r.Cells[columnName].Value)) ? decimal.MinValue : Convert.ToDecimal(r.Cells[columnName].Value)).ToList();


                    //rows = rows.OrderBy(r => Convert.ToDecimal(r.Cells[columnName].Value)).ToList();

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