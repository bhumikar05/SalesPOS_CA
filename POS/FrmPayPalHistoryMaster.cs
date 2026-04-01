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

namespace POS
{
    public partial class FrmPayPalHistoryMaster : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
       
        DataTable dt = new DataTable();
        static BALPaypalMaster BALPaypalMaster = new BALPaypalMaster();
        static BOLPayPalMaster BOLPayPalMaster = new BOLPayPalMaster();

        static BALPayment BALPayment = new BALPayment();
        static BOLPayment BOLPayment = new BOLPayment();
        public FrmPayPalHistoryMaster() 
        {
            InitializeComponent();
        }

        private void FrmPayPalHistoryMaster_Load(object sender, EventArgs e)
        {
            try
            {
                dgvPayPalList.ForeColor = Color.Black;
                this.dgvPayPalList.DefaultCellStyle.Font = new Font("", 10);
                dgvPayPalList.RowTemplate.Height = 34;
                dgvPayPalList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                LoadData();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }
        public void LoadData()
        {
              try
                {
                    dgvPayPalList.Rows.Clear();
            
                    dt = BALPaypalMaster.PayPalHistory(BOLPayPalMaster);
                    if (dt.Rows.Count > 0)
                    {
                        int iRow = 0;
                        foreach (DataRow Payment in dt.Rows)
                        {
                            dgvPayPalList.Rows.Add();
                            dgvPayPalList[0, iRow].Value = Payment["ID"].ToString();
                            //dgvPayPalList[1, iRow].Value = Payment["transaction_id"].ToString();
                            dgvPayPalList[2, iRow].Value = Payment["payer_name"].ToString();
                            //dgvPayPalList[3, iRow].Value = Payment["email_address"].ToString();
                            dgvPayPalList[4, iRow].Value = Payment["Transaction_Balance"].ToString();
                            iRow++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "E");
                }
        }
        private void FrmPayPalHistoryMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                this.Hide();
                this.Parent = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

        private void dgvPayPalList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    if (dgvPayPalList.CurrentRow.Cells[0].Value.ToString() != "")
                    {
                        dgHistory.Rows.Clear();
                        int ID = Convert.ToInt32(dgvPayPalList.CurrentRow.Cells[0].Value.ToString());
                        DataTable dthistory = new DataTable();
                        dthistory = new BALPayment().SelectByTransactionID(new BOLPayment() { ID = ID });
                        if (dthistory.Rows.Count > 0)
                        {
                            decimal sum = 0;
                            int iRow = 0;
                            foreach (DataRow History in dthistory.Rows)
                            {
                                dgHistory.Rows.Add();
                                dgHistory[1, iRow].Value = History["RefNumber"].ToString();
                                dgHistory[2, iRow].Value = History["PaymentMethodType"].ToString();
                                dgHistory[3, iRow].Value = History["PayAmount"].ToString();
                                sum += Convert.ToDecimal(History["PayAmount"]);
                                lblTotalPaidAmount.Text = sum.ToString();
                                iRow++;
                            }
                        }

                        pnlHistory.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "E");

            }
        }
        public void visiblefalse()
        {
            pnlHistory.Visible = false;
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            pnlHistory.Visible = false;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow[] row = dt.Select("payer_name like '%" + txtFilter.Text.Replace("'","''") + "%'");
        

                if (row.Length > 0)
                {
                    DataTable dtNew = row.CopyToDataTable();
                    int j = 0;
                    dgvPayPalList.Rows.Clear();
                    for (int i = 0; i < dtNew.Rows.Count; i++)
                    {
                        dgvPayPalList.Rows.Add();
                        //dgvPayPalList.Rows[j].Cells[1].Value = dtNew.Rows[i]["transaction_id"].ToString();
                        dgvPayPalList.Rows[j].Cells[2].Value = dtNew.Rows[i]["payer_name"].ToString();
                        //dgvPayPalList.Rows[j].Cells[3].Value = dtNew.Rows[i]["email_address"].ToString();
                        dgvPayPalList.Rows[j].Cells[4].Value = dtNew.Rows[i]["Transaction_Balance"].ToString();
                        j++;
                    }
                }
                else
                {
                    dgvPayPalList.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "E");

            }
        }

        
    }
}