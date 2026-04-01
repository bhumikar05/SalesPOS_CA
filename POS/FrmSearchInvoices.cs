using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmSearchInvoices : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public Int32 InvoiceID = 0;

        public FrmSearchInvoices()
        {
            InitializeComponent();
            GetCustomer();
            dgvInvoiceList.Visible = false;
        }

        public void LoadFunction()
        {
            GetCustomer();
            dgvInvoiceList.Visible = false;
            ClsCommon.ObjSearchInvoices.Width = 480;
            ClsCommon.ObjSearchInvoices.Height = 174;
        }

        private void FrmFindInvoices_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvInvoiceList.DefaultCellStyle.Font = new Font("", 10);
                dgvInvoiceList.RowTemplate.Height = 24;
                dgvInvoiceList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                ClsCommon.ObjSearchInvoices.Width = 480;
                ClsCommon.ObjSearchInvoices.Height = 174;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFindInvoices,Function :FrmFindInvoices_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void GetCustomer()
        {
            try
            {
                DataTable dtCustomer = new BALCustomerMaster().SelectAllCustomer(new BOLCustomerMaster() { });
                DataRow dr = dtCustomer.NewRow();
                dr["FullName"] = "--Select--";
                dr["ID"] = "0";
                dtCustomer.Rows.InsertAt(dr, 0);
                cmbCustomer.DataSource = dtCustomer;
                cmbCustomer.DisplayMember = "FullName";
                cmbCustomer.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFindInvoices,Function :GetCustomer. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void Clear()
        {
            cmbCustomer.SelectedIndex = 0;
            txtInvoiceNumber.Text = "";
            dgvInvoiceList.Rows.Clear();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                // CustomerWise Search
                if (cmbCustomer.SelectedIndex > 0 && txtInvoiceNumber.Text == "")
                {
                    DataTable dtInv = new BALInvoiceMaster().SelectByCusID(new BOLInvoiceMaster { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                    if (dtInv.Rows.Count == 1)
                    {
                        dgvInvoiceList.Visible = false;
                        ClsCommon.ObjSearchInvoices.Width = 480;
                        ClsCommon.ObjSearchInvoices.Height = 174;
                        InvoiceID = Convert.ToInt32(dtInv.Rows[0]["ID"].ToString());
                        ClsCommon.ObjInvoiceMaster.LoadData(InvoiceID.ToString());
                        Clear();
                        this.Close();
                    }
                    else if (dtInv.Rows.Count > 1)
                    {
                        dgvInvoiceList.Visible = true;
                        ClsCommon.ObjSearchInvoices.Width = 930;
                        ClsCommon.ObjSearchInvoices.Height = 440;

                        int j = 0;
                        dgvInvoiceList.Rows.Clear();
                        for (int i = 0; i < dtInv.Rows.Count; i++)
                        {
                            dgvInvoiceList.Rows.Add();
                            dgvInvoiceList.Rows[j].Cells[0].Value = dtInv.Rows[i]["ID"].ToString();
                            dgvInvoiceList.Rows[j].Cells[1].Value = Convert.ToDateTime(dtInv.Rows[i]["TxnDate"].ToString()).ToString("MM-dd-yyyy");
                            dgvInvoiceList.Rows[j].Cells[2].Value = "INV";
                            dgvInvoiceList.Rows[j].Cells[3].Value = dtInv.Rows[i]["RefNumber"].ToString();
                            dgvInvoiceList.Rows[j].Cells[4].Value = dtInv.Rows[i]["CustomerName"].ToString();
                            dgvInvoiceList.Rows[j].Cells[5].Value = dtInv.Rows[i]["Memo"].ToString();
                            dgvInvoiceList.Rows[j].Cells[6].Value = dtInv.Rows[i]["Total"].ToString();
                      
                            j++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Matching Transactions were found");
                    }
                }
                // InvoiceNumber Wise Search
                else if (cmbCustomer.SelectedIndex == 0 && txtInvoiceNumber.Text != "")
                {
                    DataTable dtInvRefNo = new BALInvoiceMaster().SelectByRefNumber(new BOLInvoiceMaster { RefNumber = txtInvoiceNumber.Text });
                    if (dtInvRefNo.Rows.Count == 1)
                    {
                        dgvInvoiceList.Visible = false;
                        ClsCommon.ObjSearchInvoices.Width = 480;
                        ClsCommon.ObjSearchInvoices.Height = 174;
                        InvoiceID = Convert.ToInt32(dtInvRefNo.Rows[0]["ID"].ToString());
                        ClsCommon.ObjInvoiceMaster.LoadData(InvoiceID.ToString());
                        this.Close();
                        Clear();
                    }
                    else if (dtInvRefNo.Rows.Count > 1)
                    {
                        dgvInvoiceList.Visible = true;
                        ClsCommon.ObjSearchInvoices.Width = 930;
                        ClsCommon.ObjSearchInvoices.Height = 440;

                        int j = 0;
                        dgvInvoiceList.Rows.Clear();
                        for (int i = 0; i < dtInvRefNo.Rows.Count; i++)
                        {
                            dgvInvoiceList.Rows.Add();
                            dgvInvoiceList.Rows[j].Cells[0].Value = dtInvRefNo.Rows[i]["ID"].ToString();
                            dgvInvoiceList.Rows[j].Cells[1].Value = Convert.ToDateTime(dtInvRefNo.Rows[i]["TxnDate"].ToString()).ToString("MM-dd-yyyy");
                            dgvInvoiceList.Rows[j].Cells[2].Value = "INV";
                            dgvInvoiceList.Rows[j].Cells[3].Value = dtInvRefNo.Rows[i]["RefNumber"].ToString();
                            dgvInvoiceList.Rows[j].Cells[4].Value = dtInvRefNo.Rows[i]["CustomerName"].ToString();
                            dgvInvoiceList.Rows[j].Cells[5].Value = dtInvRefNo.Rows[i]["Memo"].ToString();
                            dgvInvoiceList.Rows[j].Cells[6].Value = dtInvRefNo.Rows[i]["Total"].ToString();

                            j++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Matching Transactions were found");
                    }
                }
                // Customer & InvoiceNumber Wise Search
                else if (cmbCustomer.SelectedIndex > 0 && txtInvoiceNumber.Text != "")
                {
                    DataTable dtInv1 = new BALInvoiceMaster().SelectByCusAndRefNumber(new BOLInvoiceMaster { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), RefNumber = txtInvoiceNumber.Text });
                    if (dtInv1.Rows.Count == 1)
                    {
                        dgvInvoiceList.Visible = false;
                        ClsCommon.ObjSearchInvoices.Width = 480;
                        ClsCommon.ObjSearchInvoices.Height = 174;
                        InvoiceID = Convert.ToInt32(dtInv1.Rows[0]["ID"].ToString());
                        ClsCommon.ObjInvoiceMaster.LoadData(InvoiceID.ToString());
                        this.Close();
                        Clear();
                    }
                    else if (dtInv1.Rows.Count > 1)
                    {
                        dgvInvoiceList.Visible = true;
                        ClsCommon.ObjSearchInvoices.Width = 930;
                        ClsCommon.ObjSearchInvoices.Height = 440;

                        int j = 0;
                        dgvInvoiceList.Rows.Clear();
                        for (int i = 0; i < dtInv1.Rows.Count; i++)
                        {
                            dgvInvoiceList.Rows.Add();
                            dgvInvoiceList.Rows[j].Cells[0].Value = dtInv1.Rows[i]["ID"].ToString();
                            dgvInvoiceList.Rows[j].Cells[1].Value = Convert.ToDateTime(dtInv1.Rows[i]["TxnDate"].ToString()).ToString("MM-dd-yyyy");
                            dgvInvoiceList.Rows[j].Cells[2].Value = "INV";
                            dgvInvoiceList.Rows[j].Cells[3].Value = dtInv1.Rows[i]["RefNumber"].ToString();
                            dgvInvoiceList.Rows[j].Cells[4].Value = dtInv1.Rows[i]["CustomerName"].ToString();
                            dgvInvoiceList.Rows[j].Cells[5].Value = dtInv1.Rows[i]["Memo"].ToString();
                            dgvInvoiceList.Rows[j].Cells[6].Value = dtInv1.Rows[i]["Total"].ToString();

                            j++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Matching Transactions were found");
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFindInvoices,Function :btnFind_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void FrmFindInvoices_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClsCommon.ObjSearchInvoices.Hide();
            ClsCommon.ObjSearchInvoices.Parent = null;
            e.Cancel = true;
        }

        private void dgvInvoiceList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ClsCommon.ObjInvoiceMaster.LoadData(dgvInvoiceList.CurrentRow.Cells["ID"].Value.ToString());
                ClsCommon.ObjInvoiceMaster.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFindInvoices,Function :dgvInvoiceList_CellContentDoubleClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}