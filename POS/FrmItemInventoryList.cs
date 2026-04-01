using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace POS
{
    public partial class FrmItemInventoryList : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtItem = new DataTable();
        BALItemMaster ObjItemBAL = new BALItemMaster();
        BOLItemMaster ObjItemBOL = new BOLItemMaster();

        public FrmItemInventoryList()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 50);
            lblTotal.Text = "0";
            LoadItem();
        }

        private void FrmItemList_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvItemInventoryList.DefaultCellStyle.Font = new Font("", 10);
                dgvItemInventoryList.RowTemplate.Height = 25;
                dgvItemInventoryList.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvItemInventoryList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dgvItemInventoryList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                dgvItemInventoryList.EnableHeadersVisualStyles = false;

            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemInventoryList, Function :LoadItem. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
           
        }

        public void LoadItem()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                txtItemName.Text = "";
                dtItem = new DataTable();
                dtItem = new BALItemMaster().SelectInventoryItem(new BOLItemMaster() { });
                if (dtItem.Rows.Count > 0)
                {
                    int j = 0;
                    dgvItemInventoryList.Rows.Clear();
                    for (int i = 0; i < dtItem.Rows.Count; i++)
                    {
                        dgvItemInventoryList.Rows.Add();
                        dgvItemInventoryList.Rows[j].Cells[0].Value = dtItem.Rows[i]["ID"].ToString();
                        dgvItemInventoryList.Rows[j].Cells[1].Value = dtItem.Rows[i]["Item"].ToString();
                        dgvItemInventoryList.Rows[j].Cells[2].Value = dtItem.Rows[i]["Description"].ToString();
                        dgvItemInventoryList.Rows[j].Cells[3].Value = dtItem.Rows[i]["Type"].ToString();
                        dgvItemInventoryList.Rows[j].Cells[4].Value = dtItem.Rows[i]["Account"].ToString();
                        dgvItemInventoryList.Rows[j].Cells[5].Value = dtItem.Rows[i]["QuantityOnHand"].ToString();
                        dgvItemInventoryList.Rows[j].Cells[6].Value = dtItem.Rows[i]["Price"].ToString();
                        j++;
                    }
                }
                else
                {
                    dgvItemInventoryList.Rows.Clear();
                }
                Cursor.Current = Cursors.WaitCursor;
                lblTotal.Text = dtItem.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.WaitCursor;
                ClsCommon.WriteErrorLogs("Form:FrmItemInventoryList, Function :LoadItem. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtItemName.Text = "";
            LoadItem();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtItemName.Text != "")
                {
                    DataRow[] row = dtItem.Select("Item like '%" + txtItemName.Text + "%'");
                    if (row.Length > 0)
                    {
                        DataTable dtNew = row.CopyToDataTable();

                        int j = 0;
                        dgvItemInventoryList.Rows.Clear();
                        for (int i = 0; i < dtNew.Rows.Count; i++)
                        {
                            dgvItemInventoryList.Rows.Add();
                            dgvItemInventoryList.Rows[j].Cells[0].Value = dtNew.Rows[i]["ID"].ToString();
                            dgvItemInventoryList.Rows[j].Cells[1].Value = dtNew.Rows[i]["Item"].ToString();
                            dgvItemInventoryList.Rows[j].Cells[2].Value = dtNew.Rows[i]["Description"].ToString();
                            dgvItemInventoryList.Rows[j].Cells[3].Value = dtNew.Rows[i]["Type"].ToString();
                            dgvItemInventoryList.Rows[j].Cells[4].Value = dtNew.Rows[i]["Account"].ToString();
                            dgvItemInventoryList.Rows[j].Cells[5].Value = dtNew.Rows[i]["QuantityOnHand"].ToString();
                            dgvItemInventoryList.Rows[j].Cells[6].Value = dtNew.Rows[i]["Price"].ToString();
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
                ClsCommon.WriteErrorLogs("Form:FrmItemInventory,Function :btnSearch_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        // Export Inventory Item
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("Export", "ItemInventoryList"))
                {
                    if (dtItem.Rows.Count > 0)
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                        sfd.FilterIndex = 1;
                        sfd.RestoreDirectory = true;
                        sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            string NewFileName = sfd.FileName;
                            int n = dtItem.Columns.Count - 1;
                            string[] strArr = new string[n];
                            object objValue = System.Reflection.Missing.Value;
                            Excel.Application sXLApp = new Excel.Application();
                            Excel.Workbooks sXLBooks = (Excel.Workbooks)sXLApp.Workbooks;
                            Excel._Workbook sXLBook = (Excel._Workbook)(sXLBooks.Add(objValue));
                            Excel.Sheets sXLSheets = (Excel.Sheets)sXLBook.Worksheets;
                            Excel._Worksheet sXLWorksheet = (Excel._Worksheet)(sXLSheets.get_Item(1));

                            int p = 1;
                            for (int x = 0; x < n; x++)
                            {
                                strArr[x] = dtItem.Columns[p].ColumnName.ToString().Trim();
                                p++;
                            }
                            object objHeaders = (object)strArr;
                            Excel.Range sXLRange = sXLWorksheet.get_Range("A1", "IV1");
                            sXLRange.set_Value(objValue, objHeaders);
                            Excel.Font sXLFont = sXLRange.Font;

                            // To Assign Empty Column Header is null
                            for (int y = n + 1; y <= sXLRange.Count; y++)
                            {
                                sXLRange[1, y] = null;
                            }
                            sXLFont.Bold = true;

                            object[,] objData = new object[dtItem.Rows.Count, dtItem.Columns.Count];

                            for (int nRow = 0; nRow < dtItem.Rows.Count; nRow++)
                            {
                                for (int nCol = 1; nCol < dtItem.Columns.Count; nCol++)
                                {
                                    objData[nRow, nCol - 1] = dtItem.Rows[nRow][nCol].ToString().Trim();
                                }
                            }

                            sXLRange = sXLWorksheet.get_Range("A2", objValue);
                            sXLRange = sXLRange.get_Resize(dtItem.Rows.Count, dtItem.Columns.Count);
                            sXLRange.set_Value(objValue, objData);

                            Excel.Range BorderRAnge1;
                            BorderRAnge1 = sXLWorksheet.get_Range("A1", "L1");
                            BorderRAnge1.Font.Bold = true;
                            BorderRAnge1.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

                            //If you need Apply the color into Excel Cell based on Grid Cell     
                            for (int c = 1; c < dtItem.Columns.Count; c++)
                            {
                                // To get the Excel Cell Name     
                                string sCell = GetExcelCell(c + 1);

                                for (int r = 0; r < dtItem.Rows.Count; r++)
                                {
                                    sXLRange = sXLWorksheet.get_Range(sCell + (r + 2), sCell + (r + 2));
                                }
                            }

                            sXLApp.Columns.EntireColumn.AutoFit();
                            sXLApp.Columns.EntireRow.AutoFit();

                            sXLBook.SaveAs(NewFileName, objValue, objValue, objValue, objValue, objValue,
                                                Excel.XlSaveAsAccessMode.xlNoChange, objValue, objValue, objValue, objValue, objValue);
                            sXLBook.Close(false, objValue, objValue);
                            sXLApp.Quit();
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show("Export Successfully");
                            var app = new Microsoft.Office.Interop.Excel.Application();
                            app.Visible = true;
                            app.Workbooks.Open(sfd.FileName, ReadOnly: false);
                        }
                    }
                    else
                        MessageBox.Show("No Record Found");
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemInventoryList, Function :btnExport_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private string GetExcelCell(int nID)
        {
            string sCell = string.Empty;
            if (nID < 27)
            {
                switch (nID)
                {
                    case 0:
                        sCell = "z";
                        break;
                    case 1:
                        sCell = "A";
                        break;
                    case 2:
                        sCell = "B";
                        break;
                    case 3:
                        sCell = "C";
                        break;
                    case 4:
                        sCell = "D";
                        break;
                    case 5:
                        sCell = "E";
                        break;
                    case 6:
                        sCell = "F";
                        break;
                    case 7:
                        sCell = "G";
                        break;
                    case 8:
                        sCell = "H";
                        break;
                    case 9:
                        sCell = "I";
                        break;
                    case 10:
                        sCell = "J";
                        break;
                    case 11:
                        sCell = "K";
                        break;
                    case 12:
                        sCell = "L";
                        break;
                    case 13:
                        sCell = "M";
                        break;
                    case 14:
                        sCell = "N";
                        break;
                    default:
                        sCell = String.Empty;
                        break;
                }
                return sCell;
            }
            else
            {
                int nDiv = nID / 26;
                int nMod = nID % 26;
                if (nMod.Equals(0))
                {
                    nDiv = nDiv - 1;
                }
                sCell = GetExcelCell(nDiv);
                sCell = sCell + GetExcelCell(nMod);
                return sCell;
            }
        }

        private void PnlTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}