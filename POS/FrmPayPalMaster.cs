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
    public partial class FrmPayPalMaster : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        static BOLPayPalMaster BOLPayPalMaster = new BOLPayPalMaster();
        static BALPaypalMaster BALPaypalMaster = new BALPaypalMaster();

        public FrmPayPalMaster()
        {
            InitializeComponent();
        }

        private void FrmPayPalMaster_Load(object sender, EventArgs e)
        {
            try
            {


                dgvPayPalList.ForeColor = Color.Black;
                this.dgvPayPalList.DefaultCellStyle.Font = new Font("", 10);
                dgvPayPalList.RowTemplate.Height = 34;
                dgvPayPalList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

        public void LoadData()
        {
            try
            {
                dgvPayPalList.Rows.Clear();
                DataTable dt = new DataTable();
                dt =BALPaypalMaster.Select(BOLPayPalMaster);
                if (dt.Rows.Count > 0)
                {
                    int iRow = 0;
                    foreach (DataRow Payment in dt.Rows)
                    {
                        dgvPayPalList.Rows.Add();
                        dgvPayPalList[0, iRow].Value = Payment["ID"].ToString();
                        dgvPayPalList[1, iRow].Value = Payment["payer_name"].ToString();
                        dgvPayPalList[2, iRow].Value = Payment["email_address"].ToString();
                        dgvPayPalList[3, iRow].Value = Payment["transaction_updated_date"].ToString();
                        dgvPayPalList[4, iRow].Value = Payment["transaction_id"].ToString();
                        dgvPayPalList[5, iRow].Value = Payment["transaction_amount"].ToString();
                        iRow++;
                    }
                }
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


                if (e.ColumnIndex == 6)
                {
                    int ID = Convert.ToInt32(dgvPayPalList.CurrentRow.Cells[0].Value);
                    //FrmPayPalDetails frmPayPalDetails = new FrmPayPalDetails();
                    //frmPayPalDetails.ShowData(ID);
                    //frmPayPalDetails.ShowDialog();
                    ClsCommon.frmPayPalDetails.Show();
                    ClsCommon.frmPayPalDetails.Clear();
                    ClsCommon.frmPayPalDetails.ShowData(ID);

                    ClsCommon.frmPayPalDetails.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

        private void FrmPayPalMaster_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}