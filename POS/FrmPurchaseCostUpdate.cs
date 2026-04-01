using ClosedXML.Excel;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmPurchaseCostUpdate : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dt = new DataTable();
        BALItemMaster ObjItemBAL = new BALItemMaster();
        BOLItemMaster ObjItemBOL = new BOLItemMaster();
        BALGroupSubItem ObjGroupItemBAL = new BALGroupSubItem();
        BOLGroupSubItem ObjGroupItemBOL = new BOLGroupSubItem();

        public FrmPurchaseCostUpdate()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 50);
        }

        private void FrmLowestPriceItemList_Load(object sender, EventArgs e)
        {
            try
            {
                //SetPrice Button
                //DataGridViewLinkColumn SetPriceButton = new DataGridViewLinkColumn();
                //SetPriceButton.UseColumnTextForLinkValue = true;
                //SetPriceButton.HeaderText = "SetPrice";
                //SetPriceButton.DataPropertyName = "SetPrice";
                //SetPriceButton.Text = "SetPrice";
                //dgvItemList.Columns.Add(SetPriceButton);

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
                        dgvItemList.Rows[j].Cells[0].Value = dt.Rows[i]["ID"].ToString();
                        dgvItemList.Rows[j].Cells[1].Value = dt.Rows[i]["FullName"].ToString();
                        dgvItemList.Rows[j].Cells[2].Value = dt.Rows[i]["SalesDesc"].ToString();
                        dgvItemList.Rows[j].Cells[3].Value = dt.Rows[i]["ItemType"].ToString();
                        dgvItemList.Rows[j].Cells[4].Value = dt.Rows[i]["IncomeAccount"].ToString();
                        dgvItemList.Rows[j].Cells[5].Value = dt.Rows[i]["PurchaseCost"].ToString();
                        dgvItemList.Rows[j].Cells[6].Value = dt.Rows[i]["PCDate"].ToString();
                        //dgvItemList.Rows[j].Cells[6].Value = dt.Rows[i]["SalesPrice"].ToString();
                        //dgvItemList.Rows[j].Cells[7].Value = dt.Rows[i]["LowestPrice"].ToString();
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
                    DataRow[] row = dt.Select("ItemName like '%" + txtItemName.Text + "%'");
                    if (row.Length > 0)
                    {
                        DataTable dtNew = row.CopyToDataTable();

                        int j = 0;
                        dgvItemList.Rows.Clear();
                        for (int i = 0; i < dtNew.Rows.Count; i++)
                        {
                            dgvItemList.Rows.Add();
                            dgvItemList.Rows[j].Cells[0].Value = dtNew.Rows[i]["ID"].ToString();
                            dgvItemList.Rows[j].Cells[1].Value = dtNew.Rows[i]["FullName"].ToString();
                            dgvItemList.Rows[j].Cells[2].Value = dtNew.Rows[i]["SalesDesc"].ToString();
                            dgvItemList.Rows[j].Cells[3].Value = dtNew.Rows[i]["ItemType"].ToString();
                            dgvItemList.Rows[j].Cells[4].Value = dtNew.Rows[i]["IncomeAccount"].ToString();
                            dgvItemList.Rows[j].Cells[5].Value = dtNew.Rows[i]["PurchaseCost"].ToString();
                            dgvItemList.Rows[j].Cells[6].Value = dtNew.Rows[i]["PCDate"].ToString();
                            //dgvItemList.Rows[j].Cells[5].Value = dtNew.Rows[i]["QtyOnHand"].ToString();
                            //dgvItemList.Rows[j].Cells[6].Value = dtNew.Rows[i]["SalesPrice"].ToString();
                            //dgvItemList.Rows[j].Cells[7].Value = dtNew.Rows[i]["LowestPrice"].ToString();
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

        private void dgvItemList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void FrmLowestPriceItemList_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClsCommon.ObjPurchaseCostUpdate.Hide();
            ClsCommon.ObjPurchaseCostUpdate.Parent = null;
            e.Cancel = true;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                dt = new BALItemMaster().SelectByPurchaseCost();
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
                        //if (dt.Columns.Contains("FilterName") == true)
                        //{
                        //    if (dr["FilterName"].ToString() != "")
                        //    {
                        //        DataTable dtFilterName = new BALFilterMater().SelectByName(new BOLFilterMater() { FilterName = dr["FilterName"].ToString() });
                        //        if (dtFilterName.Rows.Count > 0)
                        //        {
                        //            ObjItemBOL.FilterID = Convert.ToInt32(dtFilterName.Rows[0]["ID"].ToString());
                        //        }
                        //        else
                        //        {
                        //            ObjItemBOL.FilterID = 0;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        ObjItemBOL.FilterID = 0;
                        //    }
                        //}
                        ObjItemBOL.FullName = dr["FullName"].ToString();
                        if (dr["PurchaseCost"].ToString() != "")
                        {
                            ObjItemBOL.PurchaseCost = Convert.ToDecimal(dr["PurchaseCost"].ToString());
                        }
                        else
                        {
                            ObjItemBOL.PurchaseCost = 0;
                        }

                        ObjItemBAL.UpdatePurchaseCost(ObjItemBOL);
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
    }
}