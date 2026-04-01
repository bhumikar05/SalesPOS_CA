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
    public partial class FrmGRADING : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dt = new DataTable();
        BALGRADING BALReasonMaster = new BALGRADING();
        BOLReasonMaster BOLReasonMaster = new BOLReasonMaster();
        public FrmGRADING()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtGRADINGName.Text != "")
            {
                BOLReasonMaster.GRADINGName = txtGRADINGName.Text;
                BALReasonMaster.Insert(BOLReasonMaster);
                txtGRADINGName.Clear();
            }
            else
            {
                MessageBox.Show("Please Enter GRADINGName");
            }
            LoadData();
        }
        public void LoadData()
        {
            try
            {
                dgvFilter.Rows.Clear();
                dt = BALReasonMaster.Select(BOLReasonMaster);
                if (dt.Rows.Count > 0)
                {
                    int iRow = 0;
                    foreach (DataRow Method in dt.Rows)
                    {
                        dgvFilter.Rows.Add();
                        dgvFilter[0, iRow].Value = Method["ID"].ToString();
                        dgvFilter[1, iRow].Value = Method["GRADINGName"].ToString();
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
            DataTable dt1 = BALReasonMaster.SelectByID(ID);

            if (dt1.Rows.Count > 0)
            {
                txtGRADINGName.Text = dt1.Rows[0]["GRADINGName"].ToString();

            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            txtGRADINGName.Clear();
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
                    BALReasonMaster.DeleteByID(Convert.ToInt32(dgvFilter.CurrentRow.Cells[0].Value.ToString()));
                    MessageBox.Show("Record Deleted Successfully");
                    LoadData();
                }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtGRADINGName.Text != "")
            {
                BOLReasonMaster.ID = Convert.ToInt32(dgvFilter.CurrentRow.Cells[0].Value.ToString());
                BOLReasonMaster.GRADINGName = txtGRADINGName.Text;
                BALReasonMaster.Update(BOLReasonMaster);
                txtGRADINGName.Clear();
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please Enter GRADINGName");
            }
            LoadData();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtGRADINGName.Clear();
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
                ClsCommon.WriteErrorLogs("Form:FrmReason,Function :txtWeight_KeyPress. Message:" + ex.Message);
            }
        }
    }
}
