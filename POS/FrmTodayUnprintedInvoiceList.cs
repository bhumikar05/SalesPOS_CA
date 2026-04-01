using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmTodayUnprintedInvoiceList : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtInvoice = new DataTable();
        BALInvoicePrintHistory objInvoicePrintBAL = new BALInvoicePrintHistory();
        BOLInvoicePrintHistory objInvoicePrintBOL = new BOLInvoicePrintHistory();
        BALHistoryMaster BALHistory = new BALHistoryMaster();
        public FrmTodayUnprintedInvoiceList()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            LoadInvoice();
        }

        public void LoadFunction()
        {
            lblTotal.Text = "0";
            LoadInvoice();
        }

        private void FrmTodayInvoiceList_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvInvoiceList.DefaultCellStyle.Font = new Font("", 10);
                dgvInvoiceList.RowTemplate.Height = 25;
                dgvInvoiceList.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvInvoiceList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                dgvInvoiceList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                dgvInvoiceList.EnableHeadersVisualStyles = false;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmTodayUnprintedInvoiceList,Function :FrmTodayInvoiceList_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void LoadInvoice()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                txtInvoiceNo.Text = "";
                dtInvoice = new DataTable();
                dtInvoice = new BALInvoiceMaster().SelectTodayInvoice(new BOLInvoiceMaster() { StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                if (dtInvoice.Rows.Count > 0)
                {
                    int j = 0;
                    dgvInvoiceList.Rows.Clear();
                    for (int i = 0; i < dtInvoice.Rows.Count; i++)
                    {
                        dgvInvoiceList.Rows.Add();
                        dgvInvoiceList.Rows[j].Cells[0].Value = dtInvoice.Rows[i]["ID"].ToString();
                        dgvInvoiceList.Rows[j].Cells[1].Value = dtInvoice.Rows[i]["CustomerName"].ToString();
                        dgvInvoiceList.Rows[j].Cells[2].Value = Convert.ToDateTime(dtInvoice.Rows[i]["TxnDate"].ToString()).ToString("MM-dd-yyyy");
                        dgvInvoiceList.Rows[j].Cells[3].Value = dtInvoice.Rows[i]["RefNumber"].ToString();
                        dgvInvoiceList.Rows[j].Cells[4].Value = Convert.ToDateTime(dtInvoice.Rows[i]["DueDate"].ToString()).ToString("MM-dd-yyyy");
                        dgvInvoiceList.Rows[j].Cells[5].Value = dtInvoice.Rows[i]["SalesRepName"].ToString();
                        dgvInvoiceList.Rows[j].Cells[6].Value = dtInvoice.Rows[i]["Total"].ToString();

                        int INVID = Convert.ToInt32(dtInvoice.Rows[i]["ID"].ToString());
                        DataTable dt = BALHistory.Select(INVID);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["IsPrintDate"].ToString() != "" && dt.Rows[0]["IsUpdateDate"].ToString() != "")
                            {
                                if (Convert.ToDateTime(dt.Rows[0]["IsUpdateDate"]) > Convert.ToDateTime(dt.Rows[0]["IsPrintDate"]))
                                {
                                    dgvInvoiceList.Rows[j].DefaultCellStyle.BackColor = Color.Orange;
                                }
                                else if (Convert.ToDateTime(dt.Rows[0]["IsPrintDate"]) > Convert.ToDateTime(dt.Rows[0]["IsUpdateDate"]))
                                {
                                    dgvInvoiceList.Rows[j].DefaultCellStyle.BackColor = Color.LightSeaGreen;
                                }
                            }
                            else if (dt.Rows[0]["IsPrintDate"].ToString() == "" && dt.Rows[0]["IsUpdateDate"].ToString() != "")
                            {
                                dgvInvoiceList.Rows[j].DefaultCellStyle.BackColor = Color.Orange;
                            }

                        }
                        j++;
                    }
                }
                else
                {
                    dgvInvoiceList.Rows.Clear();
                }
                lblTotal.Text = dtInvoice.Rows.Count.ToString();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmTodayInvoiceList, Function :LoadInvoice. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (txtInvoiceNo.Text != "")
            {
                txtInvoiceNo.Text = "";
                LoadInvoice();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtInvoiceNo.Text != "")
                {
                    DataRow[] row = dtInvoice.Select("RefNumber like '%" + txtInvoiceNo.Text + "%'");
                    if (row.Length > 0)
                    {
                        DataTable dtNew = row.CopyToDataTable();

                        int j = 0;
                        dgvInvoiceList.Rows.Clear();
                        for (int i = 0; i < dtNew.Rows.Count; i++)
                        {
                            dgvInvoiceList.Rows.Add();
                            dgvInvoiceList.Rows[j].Cells[0].Value = dtNew.Rows[i]["ID"].ToString();
                            dgvInvoiceList.Rows[j].Cells[1].Value = dtNew.Rows[i]["CustomerName"].ToString();
                            dgvInvoiceList.Rows[j].Cells[2].Value = Convert.ToDateTime(dtNew.Rows[i]["TxnDate"].ToString()).ToString("MM-dd-yyyy");
                            dgvInvoiceList.Rows[j].Cells[3].Value = dtNew.Rows[i]["RefNumber"].ToString();
                            dgvInvoiceList.Rows[j].Cells[4].Value = Convert.ToDateTime(dtNew.Rows[i]["DueDate"].ToString()).ToString("MM-dd-yyyy");
                            dgvInvoiceList.Rows[j].Cells[5].Value = dtNew.Rows[i]["SalesRepName"].ToString();
                            dgvInvoiceList.Rows[j].Cells[6].Value = dtNew.Rows[i]["Total"].ToString();
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
                ClsCommon.WriteErrorLogs("Form:FrmTodayInvoiceList,Function :btnSearch_Click. Message:" + ex.Message);
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

        private void FrmTodayInvoiceList_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClsCommon.objTodayInvoice.Hide();
            ClsCommon.objTodayInvoice.Parent = null;
            e.Cancel = true;
        }

        private void dgvInvoiceList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvInvoiceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7)
                {
                    if (ClsCommon.FunctionVisibility("Print", "TodayUnPrintedInvoiceList"))
                    {
                        ClsCommon.ObjInvoiceMaster.Show();
                        ClsCommon.ObjInvoiceMaster.LoadData(dgvInvoiceList.CurrentRow.Cells["ID"].Value.ToString());
                        LoadInvoice();
                    }
                    else
                        MessageBox.Show("You can not access");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmTodayUnprintedInvoiceList,Function :dgvInvoiceList_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

      
    }
}