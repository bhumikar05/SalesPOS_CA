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
    public partial class FrmAssignPriceTier : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALCustomerMaster BALCUST = new BALCustomerMaster();
        BOLCustomerMaster BOLCUST = new BOLCustomerMaster();
        DataTable dtCustomer = new DataTable();
        string str;
        public FrmAssignPriceTier()
        {
            InitializeComponent();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow[] row = dtCustomer.Select("Customer like '%" + txtFilter.Text + "%' or Primarycontact like '%" + txtFilter.Text + "%' or  MainEmail like '%" + txtFilter.Text + "%'");

                if (row.Length > 0)
                {
                    DataTable dtNew = row.CopyToDataTable();
                    int j = 0;
                    dgvInActiveCustomer.Rows.Clear();
                    for (int i = 0; i < dtNew.Rows.Count; i++)
                    {
                        dgvInActiveCustomer.Rows.Add();
                        dgvInActiveCustomer.Rows[j].Cells[0].Value = dtNew.Rows[i]["ID"].ToString();
                        //if (dtNew.Rows[i]["AllowLowestPrice"].ToString() == "1")

                        //{
                        //    dgvInActiveCustomer.Rows[j].Cells[1].Value = true;
                        //}
                        //else
                        //{
                        //    dgvInActiveCustomer.Rows[j].Cells[1].Value = false;
                        //}
                        dgvInActiveCustomer.Rows[j].Cells[1].Value = dtNew.Rows[i]["Customer"].ToString();
                        dgvInActiveCustomer.Rows[j].Cells[2].Value = dtNew.Rows[i]["Primarycontact"].ToString();
                        dgvInActiveCustomer.Rows[j].Cells[3].Value = dtNew.Rows[i]["MainEmail"].ToString();
                        str = "";
                        str = dtNew.Rows[i]["PriceTier"].ToString();
                        if (str.ToString() != "")
                        {
                            if (str.Contains("Cost") == true)
                            {
                                dgvInActiveCustomer.Rows[j].Cells[4].Value = true;
                            }
                            else
                            {
                                dgvInActiveCustomer.Rows[j].Cells[4].Value = false;
                            }
                            if (str.Contains("PriceTier1") == true)
                            {
                                dgvInActiveCustomer.Rows[j].Cells[5].Value = true;
                            }
                            else
                            {
                                dgvInActiveCustomer.Rows[j].Cells[5].Value = false;
                            }
                            if (str.Contains("PriceTier2") == true)
                            {
                                dgvInActiveCustomer.Rows[j].Cells[6].Value = true;
                            }
                            else
                            {
                                dgvInActiveCustomer.Rows[j].Cells[6].Value = false;
                            }
                            if (str.Contains("PriceTier3") == true)
                            {
                                dgvInActiveCustomer.Rows[j].Cells[7].Value = true;
                            }
                            else
                            {
                                dgvInActiveCustomer.Rows[j].Cells[7].Value = false;
                            }
                        }
                        
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
                dtCustomer = new DataTable();
                if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                    dtCustomer = new BALCustomerMaster().SelectPriceTier();
            
            if (dtCustomer.Rows.Count > 0)
            {
                int j = 0;
                dgvInActiveCustomer.Rows.Clear();
                for (int i = 0; i < dtCustomer.Rows.Count; i++)
                {
                    dgvInActiveCustomer.Rows.Add();
                    dgvInActiveCustomer.Rows[j].Cells[0].Value = dtCustomer.Rows[i]["ID"].ToString();
                    //if (dtCustomer.Rows[i]["AllowLowestPrice"].ToString() == "1")
                    //{
                    //    dgvInActiveCustomer.Rows[j].Cells[1].Value = true;
                    //}
                    //else
                    //{
                    //    dgvInActiveCustomer.Rows[j].Cells[1].Value = false;
                    //}
                    dgvInActiveCustomer.Rows[j].Cells[1].Value = dtCustomer.Rows[i]["Customer"].ToString();
                    dgvInActiveCustomer.Rows[j].Cells[2].Value = dtCustomer.Rows[i]["Primarycontact"].ToString();
                    dgvInActiveCustomer.Rows[j].Cells[3].Value = dtCustomer.Rows[i]["MainEmail"].ToString();
                    str = "";
                    str = dtCustomer.Rows[i]["PriceTier"].ToString();
                    if (str.ToString() != "")
                    {
                        if (str.Contains("Cost") == true)
                        {
                            dgvInActiveCustomer.Rows[j].Cells[4].Value = true;
                        }
                        else
                        {
                            dgvInActiveCustomer.Rows[j].Cells[4].Value = false;
                        }
                        if (str.Contains("PriceTier1") == true)
                        {
                            dgvInActiveCustomer.Rows[j].Cells[5].Value = true;
                        }
                        else
                        {
                            dgvInActiveCustomer.Rows[j].Cells[5].Value = false;
                        }
                        if (str.Contains("PriceTier2") == true)
                        {
                            dgvInActiveCustomer.Rows[j].Cells[6].Value = true;
                        }
                        else
                        {
                            dgvInActiveCustomer.Rows[j].Cells[6].Value = false;
                        }
                        if (str.Contains("PriceTier3") == true)
                        {
                            dgvInActiveCustomer.Rows[j].Cells[7].Value = true;
                        }
                        else
                        {
                            dgvInActiveCustomer.Rows[j].Cells[7].Value = false;
                        }
                    }
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

                str = "";
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dgvInActiveCustomer.Rows[j].Cells["Cost"];
                if (checkCell.Value != null)
                {
                    if (checkCell.Value.ToString().ToLower() == "true")
                    {
                        str = "Cost,";
                    }
                }
                DataGridViewCheckBoxCell checkCell1 = (DataGridViewCheckBoxCell)dgvInActiveCustomer.Rows[j].Cells["PriceTier1"];
                if (checkCell1.Value != null)
                {
                    if (checkCell1.Value.ToString().ToLower() == "true")
                    {
                        str = "PriceTier1,";
                    }
                }
                DataGridViewCheckBoxCell checkCell2 = (DataGridViewCheckBoxCell)dgvInActiveCustomer.Rows[j].Cells["PriceTier2"];
                if (checkCell2.Value != null)
                {
                    if (checkCell2.Value.ToString().ToLower() == "true")
                    {
                        str = "PriceTier2,";
                    }
                }
                DataGridViewCheckBoxCell checkCell3 = (DataGridViewCheckBoxCell)dgvInActiveCustomer.Rows[j].Cells["PriceTier3"];
                if (checkCell3.Value != null)
                {
                    if (checkCell3.Value.ToString().ToLower() == "true")
                    {
                        str = "PriceTier3";
                    }
                }
                if(str!="")
                {
                    BOLCUST.ID = Convert.ToInt32(dgvInActiveCustomer.Rows[j].Cells["ID"].Value.ToString());
                    BOLCUST.PriceTier = str.TrimEnd(',');
                    BALCUST.UpdatePriceTier(BOLCUST);
                }
            }
            MessageBox.Show("Assign PriceTier successfully");
            txtFilter.Clear();
            LoadData();
        }

      
        private void PckRefreshCus_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            LoadData();
        }

        private void lblSearchCustomerName_Paint(object sender, PaintEventArgs e)
        {

        }
    }
 }
