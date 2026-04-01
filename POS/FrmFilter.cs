
using ClosedXML.Excel;
using Interop.QBFC13;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;

using System.Windows.Forms;


namespace POS
{
    public partial class FrmFilter : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dt = new DataTable();
        BALFilterMater BALFilterMater = new BALFilterMater();
        BOLFilterMater BOLFilterMater = new BOLFilterMater();
        public FrmFilter()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFilterName.Text != "")
            {
                BOLFilterMater.FilterName = txtFilterName.Text;
                BOLFilterMater.Weight = txtWeight.Text;
                BALFilterMater.Insert(BOLFilterMater);
                txtFilterName.Clear();
                txtWeight.Clear();

            }
            else
            {
                MessageBox.Show("Please Enter FilterName");
            }
            LoadData();
        }
        public void LoadData()
        {
            try
            {
                dgvFilter.Rows.Clear();
                dt = BALFilterMater.Select(BOLFilterMater);
                if (dt.Rows.Count > 0)
                {
                    int iRow = 0;
                    foreach (DataRow Method in dt.Rows)
                    {
                        dgvFilter.Rows.Add();
                        dgvFilter[0, iRow].Value = Method["ID"].ToString();
                        dgvFilter[1, iRow].Value = Method["FilterName"].ToString();
                        dgvFilter[2, iRow].Value = Method["Weight"].ToString();
                        iRow++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }
        private void FrmPaymentMethod_Load(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            LoadData();
            btnUpdate.Enabled = false;
        }
        public void ShowData(Int32 ID)
        {
            DataTable dt1 = BALFilterMater.SelectByID(ID);

            if (dt1.Rows.Count > 0)
            {
                txtFilterName.Text = dt1.Rows[0]["FilterName"].ToString();
                txtWeight.Text = dt1.Rows[0]["Weight"].ToString();

            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            txtWeight.Clear();
            txtFilterName.Clear();
            this.Hide();
            this.Parent = null;
        }

        private void dgvPaymentMethod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                ShowData(Convert.ToInt32(dgvFilter.CurrentRow.Cells[0].Value.ToString()));
           
            }
            else if (e.ColumnIndex == 4)
            {
                if (MessageBox.Show("Are you Sure you want to Delete This Records ?????", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    BALFilterMater.DeleteByID(Convert.ToInt32(dgvFilter.CurrentRow.Cells[0].Value.ToString()));
                    MessageBox.Show("Record Deleted Successfully");
                    LoadData();
                }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtFilterName.Text != "")
            {
                BOLFilterMater.ID = Convert.ToInt32(dgvFilter.CurrentRow.Cells[0].Value.ToString());
                BOLFilterMater.FilterName = txtFilterName.Text;
                BOLFilterMater.Weight = txtWeight.Text;
                BALFilterMater.Update(BOLFilterMater);
                txtFilterName.Clear();
                txtWeight.Clear();
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please Enter FilterName");
            }
            LoadData();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtFilterName.Clear();
            txtWeight.Clear();
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
                {
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFILTER,Function :txtWeight_KeyPress. Message:" + ex.Message);
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow[] row = dt.Select("FilterName like '%" + txtFilter.Text + "%' OR Convert(Weight, 'System.String') like '%" + txtFilter.Text + "%'");

                if (row.Length > 0)
                {
                    DataTable dtNew = row.CopyToDataTable();
                    int j = 0;
                    dgvFilter.Rows.Clear();
                    for (int i = 0; i < dtNew.Rows.Count; i++)
                    {
                        dgvFilter.Rows.Add();
                        dgvFilter.Rows[j].Cells[0].Value = dtNew.Rows[i]["ID"].ToString();
                        dgvFilter.Rows[j].Cells[1].Value = dtNew.Rows[i]["FilterName"].ToString();
                        dgvFilter.Rows[j].Cells[2].Value = dtNew.Rows[i]["Weight"].ToString();
                        j++;
                    }
                }
                else
                {
                    dgvFilter.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            dt = BALFilterMater.Select(BOLFilterMater);
            if (dt.Rows.Count > 0)
            {
                dt.Columns.Remove("ID");
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
    }
}
