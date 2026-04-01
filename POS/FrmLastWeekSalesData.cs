using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmLastWeekSalesData : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dt = new DataTable();

        public FrmLastWeekSalesData()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
        }

        private void FrmLastWeekSalesData_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvInvoice.DefaultCellStyle.Font = new Font("", 10);
                dgvInvoice.RowTemplate.Height = 25;
                dgvInvoice.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvInvoice.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                dgvInvoice.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                dgvInvoice.EnableHeadersVisualStyles = false;
                LoadSalesRep();
                lblTotal.Text = "0";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmLastWeekSalesData, Function :FrmLastWeekSalesData_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void LoadSalesRep()
        {
            try
            {
                DataTable dtSalesRep = new BALSalesRepMaster().SelectUser(new BOLSalesRepMaster() { });
                DataRow dr = dtSalesRep.NewRow();
                dr["Name"] = "---Select---";
                dr["ID"] = "0";
                dtSalesRep.Rows.InsertAt(dr, 0);
                cmbSalesRep.DataSource = dtSalesRep;
                cmbSalesRep.ValueMember = "ID";
                cmbSalesRep.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmLastWeekSalesData, Function :LoadSalesRep. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void LoadInvoice()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                dt = new DataTable();
                dt = new BALInvoiceMaster().SelectLastWeekSalesData(new BOLInvoiceMaster() { SalesRepID = Convert.ToInt32(cmbSalesRep.SelectedValue) });
                if (dt.Rows.Count > 0)
                {
                    int j = 0;
                    dgvInvoice.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvInvoice.Rows.Add();
                        dgvInvoice.Rows[j].Cells[0].Value = dt.Rows[i]["ID"].ToString();
                        dgvInvoice.Rows[j].Cells[1].Value = dt.Rows[i]["CustomerName"].ToString();
                        dgvInvoice.Rows[j].Cells[2].Value = Convert.ToDateTime(dt.Rows[i]["TxnDate"].ToString()).ToString("MM-dd-yyyy");
                        dgvInvoice.Rows[j].Cells[3].Value = dt.Rows[i]["RefNumber"].ToString();
                        dgvInvoice.Rows[j].Cells[4].Value = dt.Rows[i]["Total"].ToString();
                        j++;
                    }
                }
                else
                    dgvInvoice.Rows.Clear();
                Cursor.Current = Cursors.Default;
                lblTotal.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmLastWeekSalesData, Function :LoadInvoice. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSalesRep.SelectedIndex != 0 && cmbSalesRep.SelectedIndex != -1)
                {
                    LoadInvoice();
                }
                else
                {
                    dgvInvoice.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                
                ClsCommon.WriteErrorLogs("Form:FrmLastWeekSalesData, Function :btnSearch_Click. Message:" + ex.Message);
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

        private void dgvInvoice_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

    }
}