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
using DocumentFormat.OpenXml.Bibliography;
using ClosedXML;
using SalesPOS.QBClass;

namespace POS
{
    public partial class FrmApplyCreditToInvoice : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BOLCreditMemoPayment ObjBolCreditPayment = new BOLCreditMemoPayment();
        BALCreditMemoPayment ObjBalCreditPayment = new BALCreditMemoPayment();
        //FrmPaymentDetail frmPaymentDetail = new FrmPaymentDetail();

        BOLInvoiceMaster BOLInvoiceMaster = new BOLInvoiceMaster();
        BALInvoiceMaster BALInvoiceMaster = new BALInvoiceMaster();

        DataTable dtGried = new DataTable();
        public int InvoiceID = 0;
        public int CustomerID = 0;
        BALCreditMemo BALCreditMemo = new BALCreditMemo();
        BOLCreditMemo BOLCreditMemo = new BOLCreditMemo();
        Boolean Isvalid = true;
        public FrmApplyCreditToInvoice()
        {
            InitializeComponent();
        }
        private void FrmApplyCreditToInvoice_Load(object sender, EventArgs e)
        {
            LoadData(InvoiceID);
            LoadGriedData();
        }
        public void LoadData(int InvoiceID)
        {
            DataTable dt = new BALInvoiceMaster().SelectByID(new BOLInvoiceMaster() { ID = Convert.ToInt32(InvoiceID) });
            if (dt.Rows.Count > 0)
            {
                CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());
                lblCustomer.Text = dt.Rows[0]["CustomerFullName"].ToString();
                lblRefNumber.Text = dt.Rows[0]["RefNumber"].ToString();
                lblDate.Text = Convert.ToDateTime(dt.Rows[0]["TxnDate"].ToString()).ToString("MM/dd/yyyy");
                lblOriginalAmt.Text = dt.Rows[0]["Total"].ToString();
                lblRemainingCredit.Text = dt.Rows[0]["BalanceDue"].ToString();
            }
            LoadGriedData();
        }
        public void LoadGriedData()
        {
            dgvApplyCredit.Rows.Clear();
            dtGried = new BALCreditMemo().SelectByUnpaidInvoice(CustomerID);
            dtGried.Columns.Add("AmtApplied", typeof(string));
            dtGried.Columns.Add("LatestBalanceDue", typeof(string));
            if (dtGried.Rows.Count > 0)
            {
                int iRow = 0;
                foreach (DataRow item in dtGried.Rows)
                {
                    dgvApplyCredit.Rows.Add();
                    dgvApplyCredit["ID", iRow].Value = item["ID"].ToString();
                    dgvApplyCredit["Date", iRow].Value = Convert.ToDateTime(item["TxnDate"].ToString()).ToString("MM/dd/yyyy");
                    dgvApplyCredit["Number", iRow].Value = item["RefNumber"].ToString();
                    dgvApplyCredit["TotalAmt", iRow].Value = item["Total"].ToString();
                    dgvApplyCredit["AvailableBalance", iRow].Value = item["BalanceDue"].ToString();
                    iRow++;
                }
            }
        }
        private void dgvApplyCredit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                Calculated();
            }
        }
        private void dgvApplyCredit_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
        }
        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        private void btnDone_Click(object sender, EventArgs e)
        {
            decimal TotalBalanceDue = 0;

            for (int i = 0; i < dtGried.Rows.Count; i++)
            {
                if (dtGried.Rows[i]["AmtApplied"].ToString() != "")
                {
                    //CreditMemo Payment
                    ObjBolCreditPayment.InvoiceID = InvoiceID;
                    ObjBolCreditPayment.CreditMemoID = Convert.ToInt32(dtGried.Rows[i]["ID"].ToString());
                    ObjBolCreditPayment.Date = DateTime.Now;
                    ObjBolCreditPayment.PayAmount = Convert.ToDecimal(dtGried.Rows[i]["AmtApplied"].ToString());
                    ObjBolCreditPayment.IsQBSync = 0;
                    ObjBalCreditPayment.Insert(ObjBolCreditPayment);
                    //CreditMemo Update
                    BOLCreditMemo.ID = Convert.ToInt32(dtGried.Rows[i]["ID"].ToString());
                    if (Convert.ToDecimal(dtGried.Rows[i]["AmtApplied"].ToString()) == Convert.ToDecimal(dtGried.Rows[i]["Total"].ToString()))
                    {
                        BOLCreditMemo.PaidInvoice = 2;
                        //Nidhi Change
                        BOLCreditMemo.AppliedAmount = Convert.ToDecimal(dtGried.Rows[i]["AmtApplied"].ToString());
                        //
                    }
                    else if (Convert.ToDecimal(dtGried.Rows[i]["Total"].ToString()) == (Convert.ToDecimal(dtGried.Rows[i]["AppliedAmount"].ToString()) + Convert.ToDecimal(dtGried.Rows[i]["AmtApplied"].ToString())))
                    {
                        BOLCreditMemo.PaidInvoice = 2;
                        //Nidhi Change
                        BOLCreditMemo.AppliedAmount = Convert.ToDecimal(dtGried.Rows[i]["AmtApplied"].ToString()) + Convert.ToDecimal(dtGried.Rows[i]["AppliedAmount"].ToString());
                        //
                    }
                    // Nidhi Change
                    else if (Convert.ToDecimal(dtGried.Rows[i]["AmtApplied"].ToString()) != 0 && (Convert.ToDecimal(dtGried.Rows[i]["AmtApplied"].ToString()) + Convert.ToDecimal(dtGried.Rows[i]["AppliedAmount"].ToString())) < Convert.ToDecimal(dtGried.Rows[i]["Total"].ToString()))
                    {
                        BOLCreditMemo.PaidInvoice = 1;
                        BOLCreditMemo.AppliedAmount = Convert.ToDecimal(dtGried.Rows[i]["AmtApplied"].ToString()) + Convert.ToDecimal(dtGried.Rows[i]["AppliedAmount"].ToString());
                    }
                    //
                    else
                    {
                        BOLCreditMemo.PaidInvoice = 0;
                        BOLCreditMemo.AppliedAmount = Convert.ToDecimal(dtGried.Rows[i]["AmtApplied"].ToString());
                    }
                    BOLCreditMemo.BalanceDue = Convert.ToDecimal(dtGried.Rows[i]["LatestBalanceDue"].ToString());

                    //BOLCreditMemo.AppliedAmount = Convert.ToDecimal(dtGried.Rows[i]["AmtApplied"].ToString());
                    BALCreditMemo.UpdatePaidInvoice(BOLCreditMemo);
                }

            }

            DataTable Invoice = new BALInvoiceMaster().SelectByInvID(InvoiceID);
            TotalBalanceDue = Convert.ToDecimal(lblRemainingCredit.Text) + Convert.ToDecimal(lblCreditUsed.Text);
            if (InvoiceID != 0 && Convert.ToDecimal(lblCreditUsed.Text) != 0)
            {
                if (Convert.ToDecimal(TotalBalanceDue) == Convert.ToDecimal(lblCreditUsed.Text))
                {
                    BOLInvoiceMaster.ID = InvoiceID;
                    BOLInvoiceMaster.PaidInvoice = 2;
                    BOLInvoiceMaster.AppliedAmount = Convert.ToDecimal(Invoice.Rows[0]["AppliedAmount"].ToString()) + Convert.ToDecimal(lblCreditUsed.Text);
                    BOLInvoiceMaster.BalanceDue = Convert.ToDecimal(lblRemainingCredit.Text);
                    BALInvoiceMaster.UpdatePaidInvoice(BOLInvoiceMaster);
                }
                else if (Convert.ToDecimal(TotalBalanceDue) > Convert.ToDecimal(lblCreditUsed.Text))
                {
                    BOLInvoiceMaster.ID = InvoiceID;
                    BOLInvoiceMaster.PaidInvoice = 1;
                    BOLInvoiceMaster.AppliedAmount = Convert.ToDecimal(Invoice.Rows[0]["AppliedAmount"].ToString()) + Convert.ToDecimal(lblCreditUsed.Text);
                    BOLInvoiceMaster.BalanceDue = Convert.ToDecimal(lblRemainingCredit.Text);
                    BALInvoiceMaster.UpdatePaidInvoice(BOLInvoiceMaster);

                }
            }

            this.Close();
            //ClsCommon.objApplyCreditToInvoice.Hide();
            //FrmApplyCreditToInvoice1.Hide();
            //ClsCommon.objPayment.Invoice = InvoiceID;
            //ClsCommon.objPayment.CreditMemoDetails();
            //ClsCommon.objPayment.loadData(InvoiceID);
            //ClsCommon.objPayment.Show();



            //FrmPaymentDetail FrmPaymentDetail = new FrmPaymentDetail();
            //FrmPaymentDetail.Invoice = InvoiceID;
            //FrmPaymentDetail.CreditMemoDetails();
            //FrmPaymentDetail.loadData(InvoiceID);
            //FrmPaymentDetail.ShowDialog();

            //this.Hide();
            //FrmPaymentDetail b = new FrmPaymentDetail();
            //b.Invoice = InvoiceID;
            //b.CreditMemoDetails();
            //b.loadData(InvoiceID);
            //b.Closed += (s, args) => this.Close();
            //b.Show();

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //ClsCommon.objApplyCreditToInvoice.Hide();
            ////FrmApplyCreditToInvoice1.Hide();
            //ClsCommon.objPayment.CreditMemoDetails();
            //ClsCommon.objPayment.loadData(InvoiceID);
            //ClsCommon.objPayment.Show();

            //FrmPaymentDetail FrmPaymentDetail = new FrmPaymentDetail();
            //FrmPaymentDetail.Invoice = InvoiceID;
            //FrmPaymentDetail.CreditMemoDetails();
            //FrmPaymentDetail.loadData(InvoiceID);
            //FrmPaymentDetail.Show();

            //this.Hide();
            //FrmPaymentDetail b = new FrmPaymentDetail();
            //b.Invoice = InvoiceID;
            //b.CreditMemoDetails();
            //b.loadData(InvoiceID);
            //b.Closed += (s, args) => this.Close();
            //b.ShowDialog();
            this.Close();


            //foreach (Form aForm in Application.OpenForms)
            //{
            //    if (aForm.Name.Equals("FrmPaymentDetail"))
            //    {
            //        aForm.Close();

            //        FrmPaymentDetail FrmPaymentDetail = new FrmPaymentDetail();
            //        FrmPaymentDetail.Invoice = InvoiceID;
            //        FrmPaymentDetail.CreditMemoDetails();
            //        FrmPaymentDetail.loadData(InvoiceID);
            //        FrmPaymentDetail.Show();
            //        break;
            //    }
            //}


        }
        private void dgvApplyCredit_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                Calculated();
            }
        }
        public void Calculated()
        {
            
            if (dgvApplyCredit.CurrentRow != null)
            {
            Top:
            
                DataView dv = null;
                dv = dtGried.DefaultView;
                dv.RowFilter = "[ID] = '" + dgvApplyCredit.CurrentRow.Cells[0].EditedFormattedValue.ToString() + "'";
                if (Convert.ToDecimal(lblRemainingCredit.Text) != 0 && lblRemainingCredit.Text.Contains("-")==false)
                {
                    decimal Total = 0;
                    decimal Credit = 0;
                    decimal ApplyAmount = 0;

                    
                    for (int i = 0; i < dtGried.Rows.Count; i++)
                    {
                        if (dtGried.Rows[i]["AmtApplied"].ToString() == "")
                        {
                            ApplyAmount = 0;
                        }
                        else if (dtGried.Rows[i]["AmtApplied"].ToString() != "")
                        {
                            ApplyAmount = Convert.ToDecimal(dtGried.Rows[i]["AmtApplied"].ToString());
                        }
                        Credit += ApplyAmount;
                        lblCreditUsed.Text = (decimal.Round(Credit, 2)).ToString();
                    }

                    if (dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString() != "")
                    {
                        Total = Convert.ToDecimal(lblCreditUsed.Text) + Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString());
                        if (Total <= Convert.ToDecimal(lblOriginalAmt.Text))
                        {
                            if (Convert.ToDecimal(lblRemainingCredit.Text) >= Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString()))
                            {
                                if (dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString() == dv.ToTable().Rows[0]["AmtApplied"].ToString())
                                {
                                    //SkipCalculation
                                }
                                else if (Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString()) > 0)
                                {
                                    if (Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString()) <= Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[5].EditedFormattedValue.ToString()))
                                    {
                                        if (dv.ToTable().Rows[0]["AmtApplied"].ToString() != "")
                                        {
                                            lblRemainingCredit.Text = (Convert.ToDecimal(lblRemainingCredit.Text) + Convert.ToDecimal(dv.ToTable().Rows[0]["AmtApplied"].ToString())).ToString();
                                            dgvApplyCredit.CurrentRow.Cells[5].Value = Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[5].EditedFormattedValue.ToString()) + Convert.ToDecimal(dv.ToTable().Rows[0]["AmtApplied"].ToString());
                                        }
                                        foreach (DataRow dr in dtGried.Rows)
                                        {
                                            if (dr["ID"].ToString() == dv.ToTable().Rows[0]["ID"].ToString())
                                            {
                                                dr["AmtApplied"] = dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString();
                                                dr["LatestBalanceDue"] = Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[5].EditedFormattedValue.ToString()) - Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString());
                                            }
                                        }
                                        dgvApplyCredit.CurrentRow.Cells[5].Value = Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[5].EditedFormattedValue.ToString()) - Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString());
                                        lblRemainingCredit.Text = (Convert.ToDecimal(lblRemainingCredit.Text) - Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString())).ToString();

                                    }
                                    else if (dv.ToTable().Rows[0]["AmtApplied"].ToString() != "")
                                    {
                                        lblRemainingCredit.Text = (Convert.ToDecimal(lblRemainingCredit.Text) + Convert.ToDecimal(dv.ToTable().Rows[0]["AmtApplied"].ToString())).ToString();
                                        dgvApplyCredit.CurrentRow.Cells[5].Value = Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[5].EditedFormattedValue.ToString()) + Convert.ToDecimal(dv.ToTable().Rows[0]["AmtApplied"].ToString());

                                        foreach (DataRow dr in dtGried.Rows)
                                        {
                                            if (dr["ID"].ToString() == dv.ToTable().Rows[0]["ID"].ToString())
                                            {
                                                dr["AmtApplied"] = dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString();
                                                dr["LatestBalanceDue"] = Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[5].EditedFormattedValue.ToString()) - Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString());
                                            }
                                        }
                                        dgvApplyCredit.CurrentRow.Cells[5].Value = Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[5].EditedFormattedValue.ToString()) - Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString());
                                        lblRemainingCredit.Text = (Convert.ToDecimal(lblRemainingCredit.Text) - Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString())).ToString();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Please Don't Enter Amt.Applied more than credit balance");
                                        dgvApplyCredit.CurrentRow.Cells[6].Value = "";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please Enter an amount greater than 0");
                                    dgvApplyCredit.CurrentRow.Cells[6].Value = "";
                                }
                            }
                            else
                            {

                                MessageBox.Show("Please Don't Enter Amt.Applied more than Remaining Balance");
                                dgvApplyCredit.CurrentRow.Cells[6].Value = "";
                            }
                        }
                        else if (dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString() == dv.ToTable().Rows[0]["AmtApplied"].ToString())
                        {
                            //SkipCalculation
                        }
                        else if (Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString()) <= Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[5].EditedFormattedValue.ToString()) && dv.ToTable().Rows[0]["AmtApplied"].ToString() != "")
                        {
                            if (dv.ToTable().Rows[0]["AmtApplied"].ToString() != "")
                            {
                                lblRemainingCredit.Text = (Convert.ToDecimal(lblRemainingCredit.Text) + Convert.ToDecimal(dv.ToTable().Rows[0]["AmtApplied"].ToString())).ToString();
                                dgvApplyCredit.CurrentRow.Cells[5].Value = Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[5].EditedFormattedValue.ToString()) + Convert.ToDecimal(dv.ToTable().Rows[0]["AmtApplied"].ToString());
                            }
                            foreach (DataRow dr in dtGried.Rows)
                            {
                                if (dr["ID"].ToString() == dv.ToTable().Rows[0]["ID"].ToString())
                                {
                                    dr["AmtApplied"] = dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString();
                                    dr["LatestBalanceDue"] = Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[5].EditedFormattedValue.ToString()) - Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString());
                                }
                            }
                            dgvApplyCredit.CurrentRow.Cells[5].Value = Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[5].EditedFormattedValue.ToString()) - Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString());
                            lblRemainingCredit.Text = (Convert.ToDecimal(lblRemainingCredit.Text) - Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString())).ToString();
                            for (int i = 0; i < dtGried.Rows.Count; i++)
                            {
                                if (dtGried.Rows[i]["AmtApplied"].ToString() == "")
                                {
                                    ApplyAmount = 0;
                                }
                                else if (dtGried.Rows[i]["AmtApplied"].ToString() != "")
                                {
                                    ApplyAmount = Convert.ToDecimal(dtGried.Rows[i]["AmtApplied"].ToString());
                                }
                                Credit += ApplyAmount;
                                lblCreditUsed.Text = (decimal.Round(Credit, 2)).ToString();
                            }

                            goto Top;
                        }
                        else
                        {

                            dgvApplyCredit.CurrentRow.Cells[6].Value = "";
                            MessageBox.Show("Please Don't Enter Amt.Applied more than BalanceDue");
                        }
                    }
                    else if (dv.ToTable().Rows[0]["AmtApplied"].ToString() != "" && dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString() == "")
                    {
                        lblRemainingCredit.Text = (Convert.ToDecimal(lblRemainingCredit.Text) + Convert.ToDecimal(dv.ToTable().Rows[0]["AmtApplied"].ToString())).ToString();
                        dgvApplyCredit.CurrentRow.Cells[5].Value = Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[5].EditedFormattedValue.ToString()) + Convert.ToDecimal(dv.ToTable().Rows[0]["AmtApplied"].ToString());
                        foreach (DataRow dr in dtGried.Rows)
                        {
                            if (dr["ID"].ToString() == dv.ToTable().Rows[0]["ID"].ToString())
                            {
                                dr["AmtApplied"] = "";
                                dr["LatestBalanceDue"] = "";
                            }
                        }
                    }
                    Credit = 0;
                    ApplyAmount = 0;
                    for (int i = 0; i < dtGried.Rows.Count; i++)
                    {
                        if (dtGried.Rows[i]["AmtApplied"].ToString() == "")
                        {
                            ApplyAmount = 0;
                        }
                        else if (dtGried.Rows[i]["AmtApplied"].ToString() != "")
                        {
                            ApplyAmount = Convert.ToDecimal(dtGried.Rows[i]["AmtApplied"].ToString());
                        }
                        Credit += ApplyAmount;
                        lblCreditUsed.Text = (decimal.Round(Credit, 2)).ToString();
                    }
                }
                else if (Convert.ToDecimal(lblRemainingCredit.Text) == 0 && dv.ToTable().Rows[0]["AmtApplied"].ToString() != "" && (dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString() != dv.ToTable().Rows[0]["AmtApplied"].ToString()))
                {
                    if (dv.ToTable().Rows[0]["AmtApplied"].ToString() != "")
                    {
                        lblRemainingCredit.Text = (Convert.ToDecimal(lblRemainingCredit.Text) + Convert.ToDecimal(dv.ToTable().Rows[0]["AmtApplied"].ToString())).ToString();
                        dgvApplyCredit.CurrentRow.Cells[5].Value = Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[5].EditedFormattedValue.ToString()) + Convert.ToDecimal(dv.ToTable().Rows[0]["AmtApplied"].ToString());
                    }
                    
                    lblCreditUsed.Text = (Convert.ToDecimal(lblCreditUsed.Text) - Convert.ToDecimal(dv.ToTable().Rows[0]["AmtApplied"].ToString())).ToString();
                    foreach (DataRow dr in dtGried.Rows)
                    {
                        if (dr["ID"].ToString() == dv.ToTable().Rows[0]["ID"].ToString())
                        {
                            dr["AmtApplied"] = "";
                            dr["LatestBalanceDue"] = "";
                        }
                    }
                }
                else if(dgvApplyCredit.CurrentRow.Cells[6].EditedFormattedValue.ToString() == dv.ToTable().Rows[0]["AmtApplied"].ToString())
                {
                    //skip Calculation
                }
                else if(Isvalid ==true)
                {
                    Isvalid = false;
                   MessageBox.Show("Balance Due is 0");
                   dgvApplyCredit.CurrentRow.Cells[6].Value = "";
                }
                else
                {
                    Isvalid = true;
                }

            }
        }
        private void FrmApplyCreditToInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ClsCommon.objApplyCreditToInvoice.Hide();
            //ClsCommon.objApplyCreditToInvoice.Parent = null;
            //e.Cancel = true;

            ////FrmApplyCreditToInvoice1.Hide();
            //ClsCommon.objPayment.CreditMemoDetails();
            //ClsCommon.objPayment.loadData(InvoiceID);
            //ClsCommon.objPayment.Show();



            //this.Hide();
            //e.Cancel = true;
            //FrmPaymentDetail b = new FrmPaymentDetail();
            //b.Invoice = InvoiceID;
            //b.CreditMemoDetails();
            //b.loadData(InvoiceID);
            //b.Closed += (s, args) => this.Close();
            //b.ShowDialog();
            FrmPaymentDetail b = new FrmPaymentDetail();
            //if (b != null);   // call the delegate
            //Hide();
            //e.Cancel = true;

            Hide();
            e.Cancel = true;
            foreach (Form aForm in Application.OpenForms)
            {
                if (aForm.Name.Equals("FrmPaymentDetail"))
                {
                    aForm.Close();
                    FrmPaymentDetail FrmPaymentDetail = new FrmPaymentDetail();
                    FrmPaymentDetail.Invoice = InvoiceID;
                    FrmPaymentDetail.CreditMemoDetails();
                    FrmPaymentDetail.loadData(InvoiceID);
                    FrmPaymentDetail.Show();
                    FrmPaymentDetail.loadData(InvoiceID);
                    break;
                }
            }


        }
        private void dgvApplyCredit_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {
            if (e.ColumnIndex == 1)
            {
                if (Convert.ToBoolean(dgvApplyCredit.CurrentRow.Cells[1].EditedFormattedValue) == true)
                {
                    if (Convert.ToDecimal(lblRemainingCredit.Text) != 0)
                    {
                        if (Convert.ToDecimal(lblRemainingCredit.Text) < Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[5].Value))
                        {
                            dgvApplyCredit.CurrentRow.Cells[6].Value = lblRemainingCredit.Text;
                        }
                        else if (Convert.ToDecimal(lblRemainingCredit.Text) > Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[5].Value))
                        {
                            dgvApplyCredit.CurrentRow.Cells[6].Value = dgvApplyCredit.CurrentRow.Cells[5].Value;
                        }
                        else if(Convert.ToDecimal(lblRemainingCredit.Text) == Convert.ToDecimal(dgvApplyCredit.CurrentRow.Cells[5].Value))
                        {
                            dgvApplyCredit.CurrentRow.Cells[6].Value = dgvApplyCredit.CurrentRow.Cells[5].Value;

                        }
                        dgvApplyCredit.CurrentRow.Cells[1].Value = true;
                    }
                }
                else if(Convert.ToBoolean(dgvApplyCredit.CurrentRow.Cells[1].EditedFormattedValue) == false)
                {
                    dgvApplyCredit.CurrentRow.Cells[6].Value = "";
                }
            }
        }
    }
 }
