using ClosedXML.Excel;
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
    public partial class FrmItemInventoryStock : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtItem = new DataTable();
        BALItemMaster ObjItemBAL = new BALItemMaster();
        BOLItemMaster ObjItemBOL = new BOLItemMaster();

        public FrmItemInventoryStock()
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

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if(rdbIncrement.Checked == true || rdbRecreate.Checked == true || rdbPrice.Checked == true)
                {
                    string FilePath = "";
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        FilePath = openFileDialog1.FileName;
                    }
                    DataTable dt = new DataTable();
                    if(FilePath != "")
                    {
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

                    }

                    if (dt.Rows.Count > 0)
                    {
                        if(rdbRecreate.Checked == true)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr["NewStock"].ToString() != "")
                                {
                                    ObjItemBOL = new BOLItemMaster();
                                    ObjItemBOL.ID = Convert.ToInt32(dr["ID"].ToString());
                                    ObjItemBOL.QtyOnHand = Convert.ToDecimal(dr["NewStock"].ToString());

                                    ObjItemBAL.UpdateQtyOnHand(ObjItemBOL);
                                }
                                  
                            }
                            MessageBox.Show("File Read Successfully");
                            LoadItem();
                        }

                        else if(rdbIncrement.Checked == true)
                        {
                            decimal OldStock = 0;
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr["NewStock"].ToString() != "" && dr["ID"].ToString() != "")
                                {
                                    OldStock = 0;
                                    dtItem = new DataTable();
                           
                                    dtItem = new BALItemMaster().SelectByID(new BOLItemMaster() { ID = Convert.ToInt32(dr["ID"].ToString()) });
                                    if(dtItem.Rows.Count > 0)
                                    {
                                        ObjItemBOL = new BOLItemMaster();
                                        ObjItemBOL.ID = Convert.ToInt32(dr["ID"].ToString());
                                        if (dtItem.Rows[0]["QtyOnHand"].ToString() != "")
                                        {
                                            OldStock = Convert.ToDecimal(dtItem.Rows[0]["QtyOnHand"].ToString());
                                        }
                                        ObjItemBOL.QtyOnHand = Convert.ToDecimal(dr["NewStock"].ToString()) + OldStock;
                                        ObjItemBAL.UpdateQtyOnHand(ObjItemBOL);
                                    }
                                                                                                      
                                }
                            }
                            MessageBox.Show("File Read Successfully");
                            LoadItem();
                        }

                        else
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr["SalesPrice"].ToString() != "")
                                {
                                    ObjItemBOL = new BOLItemMaster();
                                    ObjItemBOL.ID = Convert.ToInt32(dr["ID"].ToString());
                                    ObjItemBOL.SalesPrice = Convert.ToDecimal(dr["SalesPrice"].ToString());
                                    ObjItemBAL.UpdateSalesPrice(ObjItemBOL);
                                }

                            }
                            MessageBox.Show("File Read Successfully");
                            LoadItem();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select radiobutton");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemInventoryStock, Function :btnImport_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        // Export Inventory Item
        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dtInventory = new DataTable();
            try
            {
                dtInventory = new BALItemMaster().SelectInvItem(new BOLItemMaster() { });
                if (ClsCommon.FunctionVisibility("Export", "ItemInventoryList"))
                {
                    if (dtInventory.Rows.Count > 0)
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
                                wb.Worksheets.Add(dtInventory, "Sheet1");
                                wb.SaveAs(sfd.FileName);
                            }
                            MessageBox.Show("Export Successfully");
                        }
                    }
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

        private void btnpnlClose_Click(object sender, EventArgs e)
        {
            pnlItem.Visible = false;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            pnlItem.Visible = true;
        }
    }
}