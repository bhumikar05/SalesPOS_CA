
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
    public partial class FrmPaymentMethod : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dt = new DataTable();
        BALPaymentMethod BALPaymentMethod = new BALPaymentMethod();
        BOLPaymentMethod BOLPaymentMethod = new BOLPaymentMethod();
        public FrmPaymentMethod()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtPaymentMethod.Text != "")
            {
                BOLPaymentMethod.Name = txtPaymentMethod.Text;
                BOLPaymentMethod.PaymentMethodType = cmbPaymentType.Text;
                BALPaymentMethod.Insert(BOLPaymentMethod);
                txtPaymentMethod.Clear();
            }
            else
            {
                MessageBox.Show("Please Enter PaymentMethod");
            }
            LoadData();
        }
        public void LoadData()
        {
            try
            {
                dgvPaymentMethod.Rows.Clear();

                dt = BALPaymentMethod.SelectAll();
                if (dt.Rows.Count > 0)
                {
                    int iRow = 0;
                    foreach (DataRow Method in dt.Rows)
                    {
                        dgvPaymentMethod.Rows.Add();
                        dgvPaymentMethod[0, iRow].Value = Method["ID"].ToString();
                        dgvPaymentMethod[1, iRow].Value = Method["Name"].ToString();
                        dgvPaymentMethod[2, iRow].Value = Method["PaymentMethodType"].ToString();
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
            //btnUpdate.Enabled = false;
        }
        public void ShowData(Int32 ID)
        {
            DataTable dt1 = BALPaymentMethod.SelectByID(ID);

            if (dt1.Rows.Count > 0)
            {
                txtPaymentMethod.Text = dt1.Rows[0]["Name"].ToString();
                cmbPaymentType.Text = dt1.Rows[0]["PaymentMethodType"].ToString();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            txtPaymentMethod.Clear();
            this.Hide();
            this.Parent = null;
        }

        private void dgvPaymentMethod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 2)
            //{
            //    btnAdd.Enabled = false;
            //    //btnUpdate.Enabled = true;
            //    ShowData(Convert.ToInt32(dgvPaymentMethod.CurrentRow.Cells[0].Value.ToString()));
            //}
            //else 
            if (e.ColumnIndex == 3)
            {
                if (MessageBox.Show("Are you Sure you want to Delete This Records ?????", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    BALPaymentMethod.DeleteByID(Convert.ToInt32(dgvPaymentMethod.CurrentRow.Cells[0].Value.ToString()));
                    MessageBox.Show("Record Deleted Successfully");
                    LoadData();
                }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPaymentMethod.Text != "")
            {
                BOLPaymentMethod.ID = Convert.ToInt32(dgvPaymentMethod.CurrentRow.Cells[0].Value.ToString());
                BOLPaymentMethod.Name = txtPaymentMethod.Text;
                BALPaymentMethod.Update(BOLPaymentMethod);
                txtPaymentMethod.Clear();
                btnAdd.Enabled = true;
                //btnUpdate.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please Enter PaymentMethod");
            }
            LoadData();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPaymentMethod.Clear();
            //btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
        }
    }
}
