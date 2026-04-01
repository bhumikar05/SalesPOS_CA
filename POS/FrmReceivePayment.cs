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
    public partial class FrmReceivePayment : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtInvoice = new DataTable(); 

        public FrmReceivePayment()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 50);
        }

        public void GetInvoiceByID(string ID)
        {
            try
            {
                if (ID != "")
                {
                    DataTable dtInvoice = new BALInvoiceMaster().SelectByID(new BOLInvoiceMaster() { ID = Convert.ToInt32(ID) });
                    if (dtInvoice.Rows.Count > 0)
                    {
                        if (dtInvoice.Rows[0]["PaidInvoice"].ToString() == "2")
                        {
                            foreach (DataGridViewRow item in dgvInvoicePaymentList.Rows)
                            {
                                if (item.Cells["ID"].Value.ToString() == dtInvoice.Rows[0]["ID"].ToString())
                                {
                                    dgvInvoicePaymentList.Rows.Remove(item);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentMaster,Function :GetInvoice. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void GetInvoice()
        {
            try
            {
                dgvInvoicePaymentList.Rows.Clear();
                dtInvoice = new DataTable();
                if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                {
                    dtInvoice = new BALInvoiceMaster().UnPaidInvoice(new BOLInvoiceMaster() { SalesRepID = 0 });
                }
                else
                {
                    dtInvoice = new BALInvoiceMaster().UnPaidInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID });
                }
                   
                if (dtInvoice.Rows.Count > 0)
                {
                    int iRow = 0;
                    foreach (DataRow item in dtInvoice.Rows)
                    {
                        dgvInvoicePaymentList.Rows.Add();
                        dgvInvoicePaymentList[0, iRow].Value = item["ID"].ToString();
                        dgvInvoicePaymentList[1, iRow].Value = item["FullName"].ToString();
                        dgvInvoicePaymentList[2, iRow].Value = item["RefNumber"].ToString();
                        dgvInvoicePaymentList[3, iRow].Value = item["BalanceDue"].ToString();
                        iRow++;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentMaster,Function :GetInvoice. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void FrmPaymentMaster_Load(object sender, EventArgs e)
        {
            this.dgvInvoicePaymentList.DefaultCellStyle.Font = new Font("", 10);
            dgvInvoicePaymentList.RowTemplate.Height = 25;
            dgvInvoicePaymentList.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvInvoicePaymentList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            dgvInvoicePaymentList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvInvoicePaymentList.EnableHeadersVisualStyles = false;

            GetInvoice();
        }

        private void dgvInvoicePaymentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.ColumnIndex == 4)
                {
                  
                    FrmPaymentDetail frm = new FrmPaymentDetail();
                    frm.loadData(Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[0].Value.ToString()));
                    frm.MdiParent = ClsCommon.objMDIParent;
                    panel1.Controls.Add(frm);
                    frm.Show();
                    frm.BringToFront();
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentMaster,Function :dgvInvoicePaymentList_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void FrmPaymentMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.Parent = null;
        }
    }
}