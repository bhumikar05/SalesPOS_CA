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
    public partial class FrmCustomerRequestList : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dt = new DataTable();

        public FrmCustomerRequestList()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            lblTotal.Text = "0";
            LoadData();
        }

        public void LoadFunction()
        {
            LoadData();
        }

        private void FrmCustomerRequestList_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvRequestList.DefaultCellStyle.Font = new Font("", 10);
                dgvRequestList.RowTemplate.Height = 24;
                dgvRequestList.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvRequestList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                dgvRequestList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                dgvRequestList.EnableHeadersVisualStyles = false;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerRequestList, Function :FrmCustomerRequestList_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void LoadData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                dt = new BALCustomerRequest().Select(new BOLCustomerRequest() { });
                if (dt.Rows.Count > 0)
                {
                    int j = 0;
                    dgvRequestList.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvRequestList.Rows.Add();
                        dgvRequestList.Rows[j].Cells[0].Value = dt.Rows[i]["ID"].ToString();
                        dgvRequestList.Rows[j].Cells[1].Value = dt.Rows[i]["CustomerFullName"].ToString();
                        dgvRequestList.Rows[j].Cells[2].Value = dt.Rows[i]["ItemFullName"].ToString();
                        dgvRequestList.Rows[j].Cells[3].Value = dt.Rows[i]["SalesRepName"].ToString();
                        if (dt.Rows[i]["LowestPrice"].ToString() != null && dt.Rows[i]["LowestPrice"].ToString() != "")
                            dgvRequestList.Rows[j].Cells[4].Value = dt.Rows[i]["LowestPrice"].ToString();
                        else
                            dgvRequestList.Rows[j].Cells[4].Value = "0.00";
                        if (dt.Rows[i]["Status"].ToString() == "0")
                        {
                            dgvRequestList.Rows[j].Cells[5].Value = "Pending";
                            dgvRequestList.Rows[j].Cells[5].Style.ForeColor = Color.Red;
                        }
                        else if (dt.Rows[i]["Status"].ToString() == "1")
                            dgvRequestList.Rows[j].Cells[5].Value = "Approved";
                        else if (dt.Rows[i]["Status"].ToString() == "2")
                        {
                            dgvRequestList.Rows[j].Cells[5].Value = "Rejected";
                            dgvRequestList.Rows[j].Cells[5].Style.ForeColor = Color.Red;
                        }
                        dgvRequestList.Rows[j].Cells[6].Value = dt.Rows[i]["InvoiceNumber"].ToString();                        
                        j++;
                    }
                }
                else
                    dgvRequestList.Rows.Clear();
                Cursor.Current = Cursors.Default;
                lblTotal.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmCustomerRequestList, Function :LoadData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text != "")
                {
                    txtSearch.Text = "";
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerRequestList, Function :btnReset_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtSearch.Text != "")
                {
                    DataRow[] row = dt.Select("CustomerFullName like '%" + txtSearch.Text + "%' OR ItemFullName like '%" + txtSearch.Text + "%' OR SalesRepName like '%" + txtSearch.Text + "%'");
                    if (row.Length > 0)
                    {
                        DataTable dtNew = row.CopyToDataTable();

                        int j = 0;
                        dgvRequestList.Rows.Clear();
                        for (int i = 0; i < dtNew.Rows.Count; i++)
                        {
                            dgvRequestList.Rows.Add();
                            dgvRequestList.Rows[j].Cells[0].Value = dtNew.Rows[i]["ID"].ToString();
                            dgvRequestList.Rows[j].Cells[1].Value = dtNew.Rows[i]["CustomerFullName"].ToString();
                            dgvRequestList.Rows[j].Cells[2].Value = dtNew.Rows[i]["ItemFullName"].ToString();
                            dgvRequestList.Rows[j].Cells[3].Value = dtNew.Rows[i]["SalesRepName"].ToString();
                            if (dtNew.Rows[i]["LowestPrice"].ToString() != null && dtNew.Rows[i]["LowestPrice"].ToString() != "")
                                dgvRequestList.Rows[j].Cells[4].Value = dtNew.Rows[i]["LowestPrice"].ToString();
                            else
                                dgvRequestList.Rows[j].Cells[4].Value = "0.00";
                            if (dtNew.Rows[i]["Status"].ToString() == "0")
                            {
                                dgvRequestList.Rows[j].Cells[5].Value = "Pending";
                                dgvRequestList.Rows[j].Cells[5].Style.ForeColor = Color.Red;
                            }
                            else if (dtNew.Rows[i]["Status"].ToString() == "1")
                                dgvRequestList.Rows[j].Cells[5].Value = "Approved";
                            else if (dtNew.Rows[i]["Status"].ToString() == "2")
                            {
                                dgvRequestList.Rows[j].Cells[5].Value = "Rejected";
                                dgvRequestList.Rows[j].Cells[5].Style.ForeColor = Color.Red;
                            }
                            dgvRequestList.Rows[j].Cells[6].Value = dtNew.Rows[i]["InvoiceNumber"].ToString();
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
                ClsCommon.WriteErrorLogs("Form:FrmCustomerRequestList,Function :btnSearch_Click. Message:" + ex.Message);
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
    }
}