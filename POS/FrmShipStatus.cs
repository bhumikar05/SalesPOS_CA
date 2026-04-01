
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
    public partial class FrmShipStatus : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dt = new DataTable();
        BALShipStatus BALShipStatus = new BALShipStatus();
        BOLShipStatus BOLShipStatus = new BOLShipStatus();
        public FrmShipStatus()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFilterName.Text != "")
            {
                BOLShipStatus.ShipStatus = txtFilterName.Text;
                BALShipStatus.Insert(BOLShipStatus);
                txtFilterName.Clear();
            }
            else
            {
                MessageBox.Show("Please Enter ShipStatus");
            }
            LoadData();
        }
        public void LoadData()
        {
            try
            {
                dgvFilter.Rows.Clear();
                dt = BALShipStatus.Select(BOLShipStatus);
                if (dt.Rows.Count > 0)
                {
                    int iRow = 0;
                    foreach (DataRow Method in dt.Rows)
                    {
                        dgvFilter.Rows.Add();
                        dgvFilter[0, iRow].Value = Method["ID"].ToString();
                        dgvFilter[1, iRow].Value = Method["ShipStatus"].ToString();
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
            LoadData();
            btnUpdate.Enabled = false;
        }
        public void ShowData(Int32 ID)
        {
            DataTable dt1 = BALShipStatus.SelectByID(ID);

            if (dt1.Rows.Count > 0)
            {
                txtFilterName.Text = dt1.Rows[0]["ShipStatus"].ToString();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            txtFilterName.Clear();
            this.Hide();
            this.Parent = null;
        }

        private void dgvPaymentMethod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                ShowData(Convert.ToInt32(dgvFilter.CurrentRow.Cells[0].Value.ToString()));
           
            }
            else if (e.ColumnIndex == 3)
            {
                if (MessageBox.Show("Are you Sure you want to Delete This Records ?????", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    BALShipStatus.DeleteByID(Convert.ToInt32(dgvFilter.CurrentRow.Cells[0].Value.ToString()));
                    MessageBox.Show("Record Deleted Successfully");
                    LoadData();
                }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtFilterName.Text != "")
            {
                BOLShipStatus.ID = Convert.ToInt32(dgvFilter.CurrentRow.Cells[0].Value.ToString());
                BOLShipStatus.ShipStatus = txtFilterName.Text;
                BALShipStatus.Update(BOLShipStatus);
                txtFilterName.Clear();
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please Enter ShipStatus");
            }
            LoadData();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtFilterName.Clear();
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
        }
    }
}
