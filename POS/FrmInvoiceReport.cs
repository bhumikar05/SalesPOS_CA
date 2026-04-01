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
    public partial class FrmInvoiceReport : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALCustomerTransferList objBAL = new BALCustomerTransferList();
        BOLCustomerTransferList objBOL = new BOLCustomerTransferList();
        public FrmInvoiceReport() 
        {
            InitializeComponent();
        }

        private void FrmInvoiceReport_Load(object sender, EventArgs e)
        {
            display();
        }

        public void display()
        {
            dgUser.Rows.Clear();
            DataTable dt = objBAL.Select();
            int iRow = 0;
            foreach (DataRow item in dt.Rows)
            {
                dgUser.Rows.Add();
                dgUser[0, iRow].Value = item["ID"].ToString();
                dgUser[1, iRow].Value = item["FullName"].ToString();
                dgUser[2, iRow].Value = item["OldSalesRep"].ToString();
                dgUser[3, iRow].Value = item["NewSalesRep"].ToString();
                if (item["Date"].ToString() != "")
                {
                    DateTime date = Convert.ToDateTime(item["Date"].ToString());
                    dgUser[4, iRow].Value = date.ToString("dd/MM/yyyy");
                } 
                dgUser[5, iRow].Value = item["TotalInvoice"].ToString();
                iRow++;
            }
        }

        public void Reset()
        {
            pnlInvDetails.Visible = false;
        }

        private void dgUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                if(e.ColumnIndex == 6)
                {
                    dgInvDetail.Rows.Clear();
                    int ID = Convert.ToInt32(dgUser.CurrentRow.Cells["ID"].Value);
                    DataTable dt1 = objBAL.SelectByID(ID);
                    if (dt1.Rows.Count > 0)
                    {
                        int iRow = 0;
                        foreach (DataRow item in dt1.Rows)
                        {
                            dgInvDetail.Rows.Add();
                            dgInvDetail[0, iRow].Value = item["RefNumber"].ToString();
                            if (item["TxnDate"].ToString() != "")
                            {
                                DateTime date=Convert.ToDateTime(item["TxnDate"].ToString());
                                dgInvDetail[1, iRow].Value = date.ToString("dd/MM/yyyy");
                            }
                        
                            iRow++;
                        }
                        pnlInvDetails.Visible = true;
                    }
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceReport, Function :dgUser_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            pnlInvDetails.Visible = false;
        }

        private void FrmInvoiceReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.Parent = null;
        }
    }
}