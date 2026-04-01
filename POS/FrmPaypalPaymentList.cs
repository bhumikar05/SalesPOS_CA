using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmPaypalPaymentList : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtPayment = new DataTable(); DataTable dtBankAcc = new DataTable();
        DataTable dtInvoice = new DataTable();
        BALInvoiceMaster ObjInvoiceBAL = new BALInvoiceMaster();
        BOLInvoiceMaster ObjInvoiceBOL = new BOLInvoiceMaster();
        BALPaypalPaymentVerifaction ObjPaypalPaymentBAL = new BALPaypalPaymentVerifaction();
        BOLPaypalPaymentVerifaction ObjPaypalPaymentBOL = new BOLPaypalPaymentVerifaction();

        public FrmPaypalPaymentList()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 50);
            lblTotal.Text = "0";
            LoadPayment();
            GetInvoice();
            LoadBankAcc();
        }

        private void FrmItemList_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvInvoicePaymentList.DefaultCellStyle.Font = new Font("", 10);
                dgvInvoicePaymentList.RowTemplate.Height = 25;
                dgvInvoicePaymentList.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvInvoicePaymentList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                dgvInvoicePaymentList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                dgvInvoicePaymentList.EnableHeadersVisualStyles = false;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaypalPaymentList, Function :FrmItemList_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void LoadBankAcc()
        {
            try
            {                
                dtBankAcc = new BALAccount().SelectBankAccount();
                if(dtBankAcc.Rows.Count>0)
                {
                    DataRow dr = dtBankAcc.NewRow();
                    dr["FullName"] = "--Select--";
                    dr["ID"] = "0";
                    dtBankAcc.Rows.InsertAt(dr, 0);
                    QBBankAcc.DataSource = dtBankAcc;
                    QBBankAcc.DisplayMember = "FullName";
                    QBBankAcc.ValueMember = "ID";
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.WaitCursor;
                ClsCommon.WriteErrorLogs("Form:FrmPaypalPaymentList, Function :LoadBankAcc. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void LoadPayment()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                dtPayment = new DataTable();
                dtPayment = new BALPaypalPaymentVerifaction().Select(new BOLPaypalPaymentVerifaction() { });
                if (dtPayment.Rows.Count > 0)
                {
                    int j = 0;
                    dgvInvoicePaymentList.Rows.Clear();
                    for (int i = 0; i < dtPayment.Rows.Count; i++)
                    {
                        dgvInvoicePaymentList.Rows.Add();
                        dgvInvoicePaymentList.Rows[j].Cells[0].Value = dtPayment.Rows[i]["ID"].ToString();
                        dgvInvoicePaymentList.Rows[j].Cells[1].Value = dtPayment.Rows[i]["TransactionID"].ToString();
                        dgvInvoicePaymentList.Rows[j].Cells[2].Value = dtPayment.Rows[i]["DueAmount"].ToString();
                        dgvInvoicePaymentList.Rows[j].Cells[3].Value = Convert.ToDateTime(dtPayment.Rows[i]["TransactionInitiationDate"].ToString()).ToString("MM-dd-yyyy");
                        j++;
                    }
                }
                else
                {
                    dgvInvoicePaymentList.Rows.Clear();
                }
                Cursor.Current = Cursors.WaitCursor;
                lblTotal.Text = dtPayment.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.WaitCursor;
                ClsCommon.WriteErrorLogs("Form:FrmPaypalPaymentList, Function :LoadPayment. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void GetInvoice()
        {
            try
            {
                dtInvoice = new DataTable();
                dtInvoice = new BALInvoiceMaster().SelectUnPaidInvoice(new BOLInvoiceMaster() { });
                if (dtInvoice.Rows.Count > 0)
                {
                    DataRow dr = dtInvoice.NewRow();
                    dr["InvoiceNo"] = "--Select--";
                    dr["ID"] = "0";
                    dtInvoice.Rows.InsertAt(dr, 0);
                    Invoice.DataSource = dtInvoice;
                    Invoice.DisplayMember = "InvoiceNo";
                    Invoice.ValueMember = "ID";
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoicePayment,Function :GetInvoice. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void dgvInvoicePaymentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {

                    if (ClsCommon.FunctionVisibility("PaidInvoice", "PaypalPaymentList"))
                    {
                        if (dgvInvoicePaymentList.CurrentRow.Cells[4].Value != null)
                        {
                            if (dgvInvoicePaymentList.CurrentRow.Cells[4].Value.ToString() != "0")
                            {
                                if (dgvInvoicePaymentList.CurrentRow.Cells[5].Value != null)
                                {
                                    if (dgvInvoicePaymentList.CurrentRow.Cells[5].Value.ToString() != "0")
                                    {
                                        //Find Invoice 
                                        DataTable dtInv = new BALInvoiceMaster().SelectByID(new BOLInvoiceMaster() { ID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[4].Value) });
                                        if (dtInv.Rows.Count > 0)
                                        {
                                            if (Convert.ToDecimal(dtInv.Rows[0]["BalanceDue"].ToString()) == Convert.ToDecimal(dgvInvoicePaymentList.CurrentRow.Cells[2].Value))
                                            {
                                                // PaypalPaymentVerifaction Status Change
                                                ObjPaypalPaymentBOL.ID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[0].Value);
                                                ObjPaypalPaymentBOL.PaymentStatus = 2;
                                                ObjPaypalPaymentBOL.DueAmount = Convert.ToDecimal(dtInv.Rows[0]["BalanceDue"].ToString()) - Convert.ToDecimal(dgvInvoicePaymentList.CurrentRow.Cells[2].Value);
                                                ObjPaypalPaymentBOL.InvoiceID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[4].Value);
                                                ObjPaypalPaymentBOL.Amount = Convert.ToDecimal(dgvInvoicePaymentList.CurrentRow.Cells[2].Value);
                                                ObjPaypalPaymentBOL.ModifiedTime = DateTime.Now;
                                                ObjPaypalPaymentBOL.BankAccID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[5].Value.ToString());
                                                ObjPaypalPaymentBAL.UpdatePaymentStatus(ObjPaypalPaymentBOL);

                                                // Invoice Payment Status Change
                                                ObjInvoiceBOL.ID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[4].Value);
                                                ObjInvoiceBOL.PaidInvoice = 2;
                                                ObjInvoiceBOL.AppliedAmount = (Convert.ToDecimal(dtInv.Rows[0]["AppliedAmount"].ToString()) + Convert.ToDecimal(dgvInvoicePaymentList.CurrentRow.Cells[2].Value));
                                                ObjInvoiceBOL.BalanceDue = (Convert.ToDecimal(dtInv.Rows[0]["BalanceDue"].ToString()) - Convert.ToDecimal(dgvInvoicePaymentList.CurrentRow.Cells[2].Value));
                                                ObjInvoiceBAL.UpdatePaidInvoice(ObjInvoiceBOL);

                                                // Mail Send
                                                FrmEmailTemplateList obj = new FrmEmailTemplateList();
                                                DataTable dtCus = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(dtInv.Rows[0]["CustomerID"].ToString()) });
                                                if (dtCus.Rows.Count > 0)
                                                {
                                                    obj.EmialLoadDataPayment("Payment Verifaction", dtCus.Rows[0]["FullName"].ToString(), dtCus.Rows[0]["FirstName"].ToString(), dtCus.Rows[0]["LastName"].ToString(), dtInv.Rows[0]["RefNumber"].ToString(), Convert.ToDecimal(dtInv.Rows[0]["Total"].ToString()), dtCus.Rows[0]["CompanyName"].ToString(), Convert.ToDateTime(dtInv.Rows[0]["TxnDate"].ToString()).ToShortDateString(), Convert.ToDateTime(dtInv.Rows[0]["ShipDate"].ToString()).ToShortDateString(), Convert.ToDateTime(dtInv.Rows[0]["DueDate"].ToString()).ToShortDateString(), dtCus.Rows[0]["Email"].ToString(), dgvInvoicePaymentList.CurrentRow.Cells[1].Value.ToString(), (Convert.ToDecimal(dtInv.Rows[0]["AppliedAmount"].ToString()) + Convert.ToDecimal(dgvInvoicePaymentList.CurrentRow.Cells[2].Value)), (Convert.ToDecimal(dtInv.Rows[0]["BalanceDue"].ToString()) - Convert.ToDecimal(dgvInvoicePaymentList.CurrentRow.Cells[2].Value)), dtInv.Rows[0]["CustomerID"].ToString());
                                                }
                                                obj.ShowDialog();
                                            }
                                            else if (Convert.ToDecimal(dtInv.Rows[0]["BalanceDue"].ToString()) > Convert.ToDecimal(dgvInvoicePaymentList.CurrentRow.Cells[2].Value))
                                            {
                                                // PaypalPaymentVerifaction Status Change
                                                ObjPaypalPaymentBOL.ID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[0].Value);
                                                ObjPaypalPaymentBOL.PaymentStatus = 2;
                                                ObjPaypalPaymentBOL.DueAmount = 0;
                                                ObjPaypalPaymentBOL.Amount = Convert.ToDecimal(dgvInvoicePaymentList.CurrentRow.Cells[2].Value);
                                                ObjPaypalPaymentBOL.InvoiceID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[4].Value);
                                                ObjPaypalPaymentBOL.ModifiedTime = DateTime.Now;
                                                ObjPaypalPaymentBOL.BankAccID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[5].Value.ToString());
                                                ObjPaypalPaymentBAL.UpdatePaymentStatus(ObjPaypalPaymentBOL);

                                                // Invoice Payment Status Change
                                                ObjInvoiceBOL.ID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[4].Value);
                                                ObjInvoiceBOL.PaidInvoice = 1;
                                                ObjInvoiceBOL.AppliedAmount = (Convert.ToDecimal(dtInv.Rows[0]["AppliedAmount"].ToString()) + Convert.ToDecimal(dgvInvoicePaymentList.CurrentRow.Cells[2].Value));
                                                ObjInvoiceBOL.BalanceDue = (Convert.ToDecimal(dtInv.Rows[0]["BalanceDue"].ToString()) - Convert.ToDecimal(dgvInvoicePaymentList.CurrentRow.Cells[2].Value));
                                                ObjInvoiceBAL.UpdatePaidInvoice(ObjInvoiceBOL);

                                                // Mail Send
                                                FrmEmailTemplateList obj = new FrmEmailTemplateList();
                                                DataTable dtCus = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(dtInv.Rows[0]["CustomerID"].ToString()) });
                                                if (dtCus.Rows.Count > 0)
                                                {
                                                    obj.EmialLoadDataPayment("Payment Verifaction", dtCus.Rows[0]["FullName"].ToString(), dtCus.Rows[0]["FirstName"].ToString(), dtCus.Rows[0]["LastName"].ToString(), dtInv.Rows[0]["RefNumber"].ToString(), Convert.ToDecimal(dtInv.Rows[0]["Total"].ToString()), dtCus.Rows[0]["CompanyName"].ToString(), Convert.ToDateTime(dtInv.Rows[0]["TxnDate"].ToString()).ToShortDateString(), Convert.ToDateTime(dtInv.Rows[0]["ShipDate"].ToString()).ToShortDateString(), Convert.ToDateTime(dtInv.Rows[0]["DueDate"].ToString()).ToShortDateString(), dtCus.Rows[0]["Email"].ToString(), dgvInvoicePaymentList.CurrentRow.Cells[1].Value.ToString(), (Convert.ToDecimal(dtInv.Rows[0]["AppliedAmount"].ToString()) + Convert.ToDecimal(dgvInvoicePaymentList.CurrentRow.Cells[2].Value)), (Convert.ToDecimal(dtInv.Rows[0]["BalanceDue"].ToString()) - Convert.ToDecimal(dgvInvoicePaymentList.CurrentRow.Cells[2].Value)), dtInv.Rows[0]["CustomerID"].ToString());
                                                }
                                                obj.ShowDialog();
                                            }
                                            else if (Convert.ToDecimal(dgvInvoicePaymentList.CurrentRow.Cells[2].Value) > Convert.ToDecimal(dtInv.Rows[0]["BalanceDue"].ToString()))
                                            {
                                                // PaypalPaymentVerifaction Status Change
                                                ObjPaypalPaymentBOL.ID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[0].Value);
                                                ObjPaypalPaymentBOL.PaymentStatus = 1;
                                                ObjPaypalPaymentBOL.DueAmount = Convert.ToDecimal(dgvInvoicePaymentList.CurrentRow.Cells[2].Value) - Convert.ToDecimal(dtInv.Rows[0]["BalanceDue"].ToString());
                                                ObjPaypalPaymentBOL.InvoiceID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[4].Value);
                                                ObjPaypalPaymentBOL.Amount = Convert.ToDecimal(dtInv.Rows[0]["BalanceDue"].ToString());
                                                ObjPaypalPaymentBOL.ModifiedTime = DateTime.Now;
                                                ObjPaypalPaymentBOL.BankAccID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[5].Value.ToString());
                                                ObjPaypalPaymentBAL.UpdatePaymentStatus(ObjPaypalPaymentBOL);

                                                // Invoice Payment Status Change
                                                ObjInvoiceBOL.ID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[4].Value);
                                                ObjInvoiceBOL.PaidInvoice = 2;
                                                if (dtInv.Rows[0]["AppliedAmount"].ToString() != "")
                                                {
                                                    if (Convert.ToDecimal(dtInv.Rows[0]["AppliedAmount"].ToString()) > 0)
                                                    {
                                                        ObjInvoiceBOL.AppliedAmount = Convert.ToDecimal(dtInv.Rows[0]["AppliedAmount"].ToString()) + Convert.ToDecimal(dtInv.Rows[0]["BalanceDue"].ToString());
                                                    }
                                                    else
                                                        ObjInvoiceBOL.AppliedAmount = Convert.ToDecimal(dtInv.Rows[0]["BalanceDue"].ToString());
                                                }
                                                else
                                                    ObjInvoiceBOL.AppliedAmount = Convert.ToDecimal(dtInv.Rows[0]["BalanceDue"].ToString());
                                                ObjInvoiceBOL.BalanceDue = 0;
                                                ObjInvoiceBAL.UpdatePaidInvoice(ObjInvoiceBOL);

                                                // Mail Send
                                                FrmEmailTemplateList obj = new FrmEmailTemplateList();
                                                DataTable dtCus = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(dtInv.Rows[0]["CustomerID"].ToString()) });
                                                if (dtCus.Rows.Count > 0)
                                                {
                                                    obj.EmialLoadDataPayment("Payment Verifaction", dtCus.Rows[0]["FullName"].ToString(), dtCus.Rows[0]["FirstName"].ToString(), dtCus.Rows[0]["LastName"].ToString(), dtInv.Rows[0]["RefNumber"].ToString(), Convert.ToDecimal(dtInv.Rows[0]["Total"].ToString()), dtCus.Rows[0]["CompanyName"].ToString(), Convert.ToDateTime(dtInv.Rows[0]["TxnDate"].ToString()).ToShortDateString(), Convert.ToDateTime(dtInv.Rows[0]["ShipDate"].ToString()).ToShortDateString(), Convert.ToDateTime(dtInv.Rows[0]["DueDate"].ToString()).ToShortDateString(), dtCus.Rows[0]["Email"].ToString(), dgvInvoicePaymentList.CurrentRow.Cells[1].Value.ToString(), Convert.ToDecimal(dtInv.Rows[0]["BalanceDue"].ToString()), 0, dtInv.Rows[0]["CustomerID"].ToString());
                                                }
                                                obj.ShowDialog();
                                            }
                                        }

                                        LoadPayment();
                                        GetInvoice();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please select QB BankAccount");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please select QB BankAccount");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please select invoice first");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select invoice first");
                        }
                    }
                    else
                        MessageBox.Show("You can not access");

                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoicePayment, Function :dgvInvoicePaymentList_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void PnlTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}