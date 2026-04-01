using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;

namespace POS
{
    public partial class FrmInActiveCustomer : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALCustomerMaster BALCUST = new BALCustomerMaster();
        BOLCustomerMaster BOLCUST = new BOLCustomerMaster();
        DataTable dtCustomer = new DataTable();

        public FrmInActiveCustomer()
        {
            InitializeComponent();
        }
        private void FrmInActiveCustomer_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            try
            {
                if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                {
                    dtCustomer = new BALCustomerMaster().SelectByAll(0);
                }
                else
                {
                    dtCustomer = new BALCustomerMaster().SelectByAll(ClsCommon.UserID);
                }
                if (dtCustomer.Rows.Count > 0)
                {
                    int j = 0;
                    dgvInActiveCustomer.Rows.Clear();
                    for (int i = 0; i < dtCustomer.Rows.Count; i++)
                    {
                        dgvInActiveCustomer.Rows.Add();
                        dgvInActiveCustomer.Rows[j].Cells[0].Value = dtCustomer.Rows[i]["ID"].ToString();
                        if (dtCustomer.Rows[i]["IsActive"].ToString() == "1")
                        {
                            dgvInActiveCustomer.Rows[i].Cells[1].Value = true;
                        }
                        else
                        {
                            dgvInActiveCustomer.Rows[i].Cells[1].Value = false;
                        }
                        dgvInActiveCustomer.Rows[j].Cells[2].Value = dtCustomer.Rows[i]["CustomerName"].ToString();
                        dgvInActiveCustomer.Rows[j].Cells[3].Value = dtCustomer.Rows[i]["Phone"].ToString();
                        dgvInActiveCustomer.Rows[j].Cells[4].Value = dtCustomer.Rows[i]["Email"].ToString();
                        dgvInActiveCustomer.Rows[j].Cells[5].Value = dtCustomer.Rows[i]["TotalBalance"].ToString();
                        j++;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:InActiveCustomer, Function:LoadData" + ex.Message);
                MessageBox.Show("Form:InActiveCustomer, Function:LoadData" + ex.Message, "E");
            }
        }
        private void btnActiveCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                for (int j = 0; j < dgvInActiveCustomer.Rows.Count; j++)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dgvInActiveCustomer.Rows[j].Cells["ChkSelectCustomer"];
                    if (checkCell.Value != null)
                    {
                        if (checkCell.Value.ToString().ToLower() == "true")
                        {
                            BOLCUST.ID = Convert.ToInt32(dgvInActiveCustomer.Rows[j].Cells["ID"].Value.ToString());
                            BOLCUST.IsActive = 1;
                            BALCUST.UpdateInactiveTransferActive(BOLCUST);

                        }
                        else
                        {
                            BOLCUST.ID = Convert.ToInt32(dgvInActiveCustomer.Rows[j].Cells["ID"].Value.ToString());
                            BOLCUST.IsActive = 0;
                            BALCUST.UpdateInactiveTransferActive(BOLCUST);
                        }
                    }
                }
                MessageBox.Show("Customer Save successfully");
                txtFilter.Clear();
                LoadData();
                this.Close();
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:InActiveCustomer, Function:btnActiveCustomer_Click" + ex.Message);
                MessageBox.Show("Form:InActiveCustomer, Function:btnActiveCustomer_Click" + ex.Message, "E");
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow[] row = dtCustomer.Select("CustomerName like '%" + txtFilter.Text + "%'");
            
                if (row.Length > 0)
                {
                    DataTable dtNew = row.CopyToDataTable();
                    int j = 0;
                    dgvInActiveCustomer.Rows.Clear();
                    for (int i = 0; i < dtNew.Rows.Count; i++)
                    {
                        dgvInActiveCustomer.Rows.Add();
                        dgvInActiveCustomer.Rows[j].Cells[0].Value = dtNew.Rows[i]["ID"].ToString();
                        if (dtNew.Rows[i]["IsActive"].ToString() == "1")
                        {
                            dgvInActiveCustomer.Rows[i].Cells[1].Value = true;
                        }
                        else
                        {
                            dgvInActiveCustomer.Rows[i].Cells[1].Value = false;
                        }
                        dgvInActiveCustomer.Rows[j].Cells[2].Value = dtNew.Rows[i]["CustomerName"].ToString();
                        dgvInActiveCustomer.Rows[j].Cells[3].Value = dtNew.Rows[i]["Phone"].ToString();
                        dgvInActiveCustomer.Rows[j].Cells[4].Value = dtNew.Rows[i]["Email"].ToString();
                        dgvInActiveCustomer.Rows[j].Cells[5].Value = dtNew.Rows[i]["TotalBalance"].ToString();
                        j++;
                    }
                }
                else
                {
                    dgvInActiveCustomer.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }
    }
}
    


