using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.IO;

using ClosedXML.Excel;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;

namespace POS
{
    public partial class FrmAllowLowestPriceCustomer : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALCustomerMaster BALCUST = new BALCustomerMaster();
        BOLCustomerMaster BOLCUST = new BOLCustomerMaster();
        DataTable dtCustomer = new DataTable();
        public FrmAllowLowestPriceCustomer()
        {
            InitializeComponent();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow[] row = dtCustomer.Select("Customer like '%" + txtFilter.Text + "%'");

                if (row.Length > 0)
                {
                    DataTable dtNew = row.CopyToDataTable();
                    int j = 0;
                    dgvInActiveCustomer.Rows.Clear();
                    for (int i = 0; i < dtNew.Rows.Count; i++)
                    {
                        dgvInActiveCustomer.Rows.Add();
                        dgvInActiveCustomer.Rows[j].Cells[0].Value = dtNew.Rows[i]["ID"].ToString();
                        if (dtNew.Rows[i]["AllowLowestPrice"].ToString() == "1")
                        {
                            dgvInActiveCustomer.Rows[j].Cells[1].Value = true;
                        }
                        else
                        {
                            dgvInActiveCustomer.Rows[j].Cells[1].Value = false;
                        }
                        dgvInActiveCustomer.Rows[j].Cells[2].Value = dtNew.Rows[i]["Customer"].ToString();
                        dgvInActiveCustomer.Rows[j].Cells[3].Value = dtNew.Rows[i]["Primarycontact"].ToString();
                        dgvInActiveCustomer.Rows[j].Cells[4].Value = dtNew.Rows[i]["MainEmail"].ToString();
                        dgvInActiveCustomer.Rows[j].Cells[5].Value = dtNew.Rows[i]["BalanceTotal"].ToString();
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
        public void LoadData()
        {
            if (ClsCommon.FunctionVisibility("CustomerNumberOnly", "CustomerCenter"))
            {
                dtCustomer = new DataTable();
                if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                    dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = 0, IsCustomerNumber = 0 });
                else
                    dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = 0, IsCustomerNumber = 1 });
            }
            else
            {
                dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = 0, IsCustomerNumber = 0 });
            }
            if (dtCustomer.Rows.Count > 0)
            {
                int j = 0;
                dgvInActiveCustomer.Rows.Clear();
                for (int i = 0; i < dtCustomer.Rows.Count; i++)
                {
                    dgvInActiveCustomer.Rows.Add();
                    dgvInActiveCustomer.Rows[j].Cells[0].Value = dtCustomer.Rows[i]["ID"].ToString();
                    if (dtCustomer.Rows[i]["AllowLowestPrice"].ToString() == "1")
                    {
                        dgvInActiveCustomer.Rows[j].Cells[1].Value = true;
                    }
                    else
                    {
                        dgvInActiveCustomer.Rows[j].Cells[1].Value = false;
                    }
                    dgvInActiveCustomer.Rows[j].Cells[2].Value = dtCustomer.Rows[i]["Customer"].ToString();
                    dgvInActiveCustomer.Rows[j].Cells[3].Value = dtCustomer.Rows[i]["Primarycontact"].ToString();
                    dgvInActiveCustomer.Rows[j].Cells[4].Value = dtCustomer.Rows[i]["MainEmail"].ToString();
                    dgvInActiveCustomer.Rows[j].Cells[5].Value = dtCustomer.Rows[i]["BalanceTotal"].ToString();
                    j++;
                }
            }
        }
        private void FrmAllowLowestPriceCustomer_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAllowLowestPrice_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < dgvInActiveCustomer.Rows.Count; j++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dgvInActiveCustomer.Rows[j].Cells["ChkSelectCustomer"];
                if (checkCell.Value != null)
                {
                    if (checkCell.Value.ToString().ToLower() == "true")
                    {
                        BOLCUST.ID = Convert.ToInt32(dgvInActiveCustomer.Rows[j].Cells["ID"].Value.ToString());
                        BOLCUST.AllowLowestPrice = 1;
                        BALCUST.UpdateAllowLowest(BOLCUST);
                    }
                    else
                    {
                        BOLCUST.ID = Convert.ToInt32(dgvInActiveCustomer.Rows[j].Cells["ID"].Value.ToString());
                        BOLCUST.AllowLowestPrice = 0;
                        BALCUST.UpdateAllowLowest(BOLCUST);
                    }
                }
            }
            MessageBox.Show("Customer Lowest Price Allow successfully");
            txtFilter.Clear();
            LoadData();
            this.Close();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked == true)
                {
                    for (int i = 0; i < dgvInActiveCustomer.Rows.Count; i++)
                    {
                        dgvInActiveCustomer.Rows[i].Cells[1].Value = true;
                    }
                }
                else
                {
                    for (int i = 0; i < dgvInActiveCustomer.Rows.Count; i++)
                    {
                        dgvInActiveCustomer.Rows[i].Cells[1].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

        private void PckRefreshCus_Click(object sender, EventArgs e)
        {
            LoadData();
            txtFilter.Text = "";
         
        }

        private void lblSearchCustomerName_Paint(object sender, PaintEventArgs e)
        {

        }
    }
 }
