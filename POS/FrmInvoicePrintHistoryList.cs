using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmInvoicePrintHistoryList : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtInvoice = new DataTable();

        public FrmInvoicePrintHistoryList()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            lblTotal.Text = "0";
            LoadInvoice();
        }

        public void LoadFunction()
        {
            LoadInvoice();
        }

        private void FrmInvoicePrintHistoryList_Load(object sender, EventArgs e)
        {
            try
            {
                DataGridViewLinkColumn PrintButton = new DataGridViewLinkColumn();
                PrintButton.UseColumnTextForLinkValue = true;
                PrintButton.HeaderText = "PrintHistory";
                PrintButton.DataPropertyName = "PrintHistory";
                PrintButton.Text = "PrintHistory";
                dgvInvoiceList.Columns.Add(PrintButton);
                dgvInvoiceList.Columns[7].Width = 100;

                this.dgvInvoiceList.DefaultCellStyle.Font = new Font("", 10);
                dgvInvoiceList.RowTemplate.Height = 25;
                dgvInvoiceList.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvInvoiceList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                dgvInvoiceList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                dgvInvoiceList.EnableHeadersVisualStyles = false;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoicePrintHistoryList, Function :FrmInvoicePrintHistoryList_Load. Message:" + ex.Message);
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
                dtInvoice = new BALInvoiceMaster().SelectAllInvoiceList(new BOLInvoiceMaster() { });
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
                        j++;
                    }
                }
                else
                {
                    dgvInvoiceList.Rows.Clear();
                }
                Cursor.Current = Cursors.Default;
                lblTotal.Text = dtInvoice.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmInvoicePrintHistoryList, Function :LoadInvoice. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if(txtInvoiceNo.Text != "")
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
                    }
                }
                Cursor.Current = Cursors.Default;
                lblTotal.Text = dtInvoice.Rows.Count.ToString();
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

        private void FrmInvoicePrintHistoryList_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ClsCommon.objTodayInvoice.Hide();
            //ClsCommon.objTodayInvoice.Parent = null;
            //e.Cancel = true;
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
                    if (ClsCommon.FunctionVisibility("PrintHistory", "InvoicePrintHistory"))
                    {
                        DataTable dtHistory = new BALInvoiceMaster().SelectByInvoicePrintHistory(new BOLInvoiceMaster() { ID = Convert.ToInt32(dgvInvoiceList.CurrentRow.Cells["ID"].Value) });
                        if (dtHistory.Rows.Count > 0)
                        {
                            FrmInvoicePrintHistory obj = new FrmInvoicePrintHistory();
                            obj.InvoiceId = Convert.ToInt32(dgvInvoiceList.CurrentRow.Cells["ID"].Value);
                            obj.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("No History found");
                        }
                    }
                    else
                        MessageBox.Show("You can not access");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoicePrintHistoryList,Function :dgvInvoiceList_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }
    }
}