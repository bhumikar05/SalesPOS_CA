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
    public partial class FrmPayPalDetails : ComponentFactory.Krypton.Toolkit.KryptonForm
    {

        DataTable dt = new DataTable();
        BALInvoiceMaster objBALInvoice = new BALInvoiceMaster();
        BOLInvoiceMaster objBOLInvoice = new BOLInvoiceMaster();

        BOLPayment BOLPayment = new BOLPayment();
        BALPayment BALPayment = new BALPayment();

        BOLPayPalMaster BOLPayPalMaster = new BOLPayPalMaster();
        BALPaypalMaster BALPaypalMaster = new BALPaypalMaster();

        BOLPaymentMethod BOLPaymentMethod = new BOLPaymentMethod();
        BALPaymentMethod BALPaymentMethod = new BALPaymentMethod();
        static int PaypalID;

        public FrmPayPalDetails()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            try
            {
                dgvPayPalList.Rows.Clear();

                dt = objBALInvoice.PayPalSelect();
                if (dt.Rows.Count > 0)
                {
                    int iRow = 0;
                    foreach (DataRow Invoice in dt.Rows)
                    {
                        dgvPayPalList.Rows.Add();
                        dgvPayPalList[0, iRow].Value = Invoice["ID"].ToString();
                        dgvPayPalList[1, iRow].Value = Invoice["CustomerName"].ToString();
                        dgvPayPalList[2, iRow].Value = Invoice["RefNumber"].ToString();
                        dgvPayPalList[3, iRow].Value = Invoice["PayPalName"].ToString();
                        dgvPayPalList[4, iRow].Value = Invoice["PayPalEmail"].ToString();
                        dgvPayPalList[5, iRow].Value = Invoice["TxnDate"].ToString();
                        dgvPayPalList[6, iRow].Value = Invoice["BalanceDue"].ToString();
                        iRow++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }
        private void FrmPayPalDetails_Load(object sender, EventArgs e)
        {
            try
            {
                dgvPayPalList.ForeColor = Color.Black;
                this.dgvPayPalList.DefaultCellStyle.Font = new Font("", 10);
                dgvPayPalList.RowTemplate.Height = 34;
                dgvPayPalList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                //LoadData();
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

                if (e.ColumnIndex == 8)
                {

                    if (dgvPayPalList.CurrentRow.Cells[7].Value != null)
                    {
                        if (Convert.ToDecimal(dgvPayPalList.CurrentRow.Cells[7].Value) > 0)
                        {
                            DataTable dtPayPal = new DataTable();
                            dtPayPal = BALPaypalMaster.SelectByID(Convert.ToInt32(PaypalID));
                            if (dtPayPal.Rows.Count > 0)
                            {
                                if (Convert.ToDecimal(dtPayPal.Rows[0]["transaction_amount"]) > 0)
                                {
                                    decimal Amount = Convert.ToDecimal(dgvPayPalList.CurrentRow.Cells[7].Value.ToString());
                                    int id = Convert.ToInt32(dgvPayPalList.CurrentRow.Cells[0].Value);
                                    DataTable dtinvoice = new DataTable();
                                    dtinvoice = objBALInvoice.SelectByInvID(id);
                                    if (dtinvoice.Rows.Count > 0)
                                    {
                                        if (dtinvoice.Rows.Count > 0)
                                        {
                                            if (Convert.ToDecimal(dtinvoice.Rows[0]["BalanceDue"]) < Convert.ToDecimal(Amount))
                                            {
                                                dgvPayPalList.CurrentRow.Cells[7].Value = "";
                                                MessageBox.Show("You Can not Pay More Than Invoice DueAmount");
                                            }
                                            else if (Convert.ToDecimal(dtPayPal.Rows[0]["transaction_amount"]) < Convert.ToDecimal(Amount))
                                            {
                                                dgvPayPalList.CurrentRow.Cells[7].Value = "";
                                                MessageBox.Show("You Can not Pay More Than TotalAmount");
                                            }
                                            else
                                            {
                                                decimal ToTALAMOUNT = Convert.ToDecimal(Convert.ToDecimal(dtinvoice.Rows[0]["BalanceDue"]) - Convert.ToDecimal(Amount));
                                                decimal ShowLabalAmounr = Convert.ToDecimal(dtPayPal.Rows[0]["transaction_amount"]) - Convert.ToDecimal(Amount);
                                                TotalAmount.Text = ShowLabalAmounr.ToString();
                                                BOLPayPalMaster.ID = PaypalID;
                                                BOLPayPalMaster.transaction_amount = ShowLabalAmounr;
                                                BALPaypalMaster.Updatetransactionamount(BOLPayPalMaster);

                                                BOLPayment.InvoiceID = id;
                                                DataTable dtPaymentMethod = new DataTable();
                                                dtPaymentMethod = new BALPaymentMethod().SelectPaymentMethodType(new BOLPaymentMethod() { PaymentMethodType = "Credit Card" });
                                                if (dtPaymentMethod.Rows.Count > 0)
                                                {
                                                    BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                }
                                                BOLPayment.PayAmount = Amount;
                                                BOLPayment.Date = DateTime.Now;
                                                BOLPayment.TransactionID = dtPayPal.Rows[0]["transaction_id"].ToString();
                                                BOLPayment.CreditAmount = null;
                                                BOLPayment.PayPalID = PaypalID;
                                                BALPayment.Insert(BOLPayment);

                                                if (Convert.ToDecimal(dtinvoice.Rows[0]["BalanceDue"].ToString()) == Amount)
                                                {
                                                    objBOLInvoice.ID = Convert.ToInt32(dtinvoice.Rows[0]["ID"]);
                                                    objBOLInvoice.PaidInvoice = 2;
                                                    objBOLInvoice.AppliedAmount = (Convert.ToDecimal(dtinvoice.Rows[0]["AppliedAmount"].ToString()) + Amount);
                                                    objBOLInvoice.BalanceDue = (Convert.ToDecimal(dtinvoice.Rows[0]["BalanceDue"].ToString()) - Amount);
                                                    dgvPayPalList.CurrentRow.Cells[4].Value = objBOLInvoice.BalanceDue;
                                                    objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                                                }
                                                else if (Convert.ToDecimal(dtinvoice.Rows[0]["BalanceDue"]) > Amount)
                                                {
                                                    objBOLInvoice.ID = Convert.ToInt32(dtinvoice.Rows[0]["ID"]);
                                                    objBOLInvoice.PaidInvoice = 1;
                                                    objBOLInvoice.AppliedAmount = (Convert.ToDecimal(dtinvoice.Rows[0]["AppliedAmount"].ToString()) + Amount);
                                                    objBOLInvoice.BalanceDue = (Convert.ToDecimal(dtinvoice.Rows[0]["BalanceDue"]) - Amount);
                                                    dgvPayPalList.CurrentRow.Cells[4].Value = objBOLInvoice.BalanceDue;
                                                    objBALInvoice.UpdatePaidInvoice(objBOLInvoice);

                                                }
                                                MessageBox.Show("Payment SuccessFully");
                                            }
                                        }
                                        dgvPayPalList.CurrentRow.Cells[7].Value = "";
                                        if (dgvPayPalList.CurrentRow.Cells[4].Value.ToString() == "0.00")
                                        {
                                            dgvPayPalList.Rows.RemoveAt(dgvPayPalList.CurrentRow.Index);

                                        }
                                    }
                                }
                                else
                                {
                                    dgvPayPalList.CurrentRow.Cells[7].Value = "";
                                    MessageBox.Show("You Can not Pay More Than Transaction Amount");
                                }
                            }
                        }
                        else
                        {
                            dgvPayPalList.CurrentRow.Cells[7].Value = "";
                            MessageBox.Show("Please Enter Amount Greater Than Zero");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Amount");
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
            try
            {
                LoadData();
                txtFilter.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }
        
        private void CheckKey(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        public void ShowData(int ID)
        {
            try
            {
                PaypalID = ID;
                DataTable dt = new DataTable();
                dt = BALPaypalMaster.SelectByID(Convert.ToInt32(ID));
                if (dt.Rows.Count > 0)
                {
                    PayeeName.Text = dt.Rows[0]["payer_name"].ToString();
                    TotalAmount.Text = dt.Rows[0]["transaction_amount"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "E");
            }

        }

        private void FrmPayPalDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {


                ClsCommon.frmPayPalDetails.Hide();
                e.Cancel = true;
                this.Hide();
                this.Parent = null;
                ClsCommon.FrmPayPalMaster.Show();
                ClsCommon.FrmPayPalMaster.LoadData();
                ClsCommon.FrmPayPalMaster.BringToFront();
                //FrmPayPalMaster FrmPayPalMaster = new FrmPayPalMaster();
                //FrmPayPalDetails FrmPayPalDetails = new FrmPayPalDetails();
                //FrmPayPalDetails.Close();
                //FrmPayPalMaster.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                dt = objBALInvoice.PayPalSelect();
                if (txtFilter.Text != "")
                {
                    DataRow[] row = dt.Select("CustomerName like '%" + txtFilter.Text.Replace("'", "''") + "%' OR PayPalName like '%" + txtFilter.Text.Replace("'", "''") + "%' OR RefNumber like '%" + txtFilter.Text.Replace("'", "''") + "%' OR PayPalEmail like '%" + txtFilter.Text.Replace("'", "''") + "%' ");
                    if (row.Length > 0)
                    {
                        DataTable dtNew = row.CopyToDataTable();
                        int j = 0;
                        dgvPayPalList.Rows.Clear();
                        for (int i = 0; i < dtNew.Rows.Count; i++)
                        {
                            dgvPayPalList.Rows.Add();
                            dgvPayPalList.Rows[j].Cells[0].Value = dtNew.Rows[i]["ID"].ToString();
                            dgvPayPalList.Rows[j].Cells[1].Value = dtNew.Rows[i]["CustomerName"].ToString();
                            dgvPayPalList.Rows[j].Cells[2].Value = dtNew.Rows[i]["RefNumber"].ToString();
                            dgvPayPalList.Rows[j].Cells[3].Value = dtNew.Rows[i]["PayPalName"].ToString();
                            dgvPayPalList.Rows[j].Cells[4].Value = dtNew.Rows[i]["PayPalEmail"].ToString();
                            dgvPayPalList.Rows[j].Cells[5].Value = dtNew.Rows[i]["TxnDate"].ToString();
                            dgvPayPalList.Rows[j].Cells[6].Value = dtNew.Rows[i]["BalanceDue"].ToString();
                            j++;
                        }
                    }
                    else
                    {
                        dgvPayPalList.Rows.Clear();
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void Clear()
        {
            txtFilter.Text = "";
            dgvPayPalList.Rows.Clear();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
            //LoadData();
        }

        private void dgvPayPalList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string sCellName = "EnterPaymentAmount";
            if ((sCellName) == "EnterPaymentAmount")
            {
                e.Control.KeyPress += new KeyPressEventHandler(CheckKey);

            }
        }
    }
}