using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Interop.QBFC13;
using Microsoft.Office.Interop.Outlook;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.Report;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using Telerik.WinControls.VirtualKeyboard;
using Application = System.Windows.Forms.Application;
using Color = System.Drawing.Color;
using Exception = System.Exception;
using Font = System.Drawing.Font;

namespace POS
{
    public partial class FrmPaymentDetail : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public string Mode = "Insert";
        public int InID = 0;
        public int Invoice = 0;
        public int CustomerID = 0;
        public decimal remainingAmount = 0;
        BALPaymentMethod objpayBAL = new BALPaymentMethod();
        BOLPaymentMethod objpayBOL = new BOLPaymentMethod();

        BALPaymentDetail objpaypalBAL = new BALPaymentDetail();
        BOLPaymentDetail objpaypalBOL = new BOLPaymentDetail();

        BALPayment PayBAL = new BALPayment();
        BOLPayment PayBOL = new BOLPayment();

        BALInvoiceMaster objBALInvoice = new BALInvoiceMaster();
        BOLInvoiceMaster objBOLInvoice = new BOLInvoiceMaster();

        BALCreditMemoPayment BALCreditMemoPayment = new BALCreditMemoPayment();
        BOLCreditMemoPayment BOLCreditMemoPayment = new BOLCreditMemoPayment();

        BOLCreditMemo BOLCreditMemo = new BOLCreditMemo();
        BALCreditMemo BALCreditMemo = new BALCreditMemo();

        //Hiren
        DataTable dtGried = new DataTable();
        Boolean IsPaymentManually = false;
        Boolean Isvalid = true;
        public int PayID = 0;
        public FrmPaymentDetail()
        {
            InitializeComponent();
        }

        private void Collapse_Click(object sender, EventArgs e)
        {
            //Expand.Visible = true;
            //Collapse.Hide();
            //splitContainer1.Panel1Collapsed = false;
            //groupBox1.Show();
            //groupBox2.Show();
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Expand_Click(object sender, EventArgs e)
        {
            //Collapse.Visible = true;
            //Expand.Hide();
            //groupBox1.Hide();
            //splitContainer1.Panel1Collapsed = true;
            //label3.Visible = true;
            //groupBox2.Show();
        }
        private void DisplayMessage(string Text, string Mode)
        {
            //switch (Mode)
            //{
            //    case "W":
            //        lblErrorMsg.StateCommon.TextColor = Color.FromArgb(16, 6, 244);
            //        lblErrorMsg.StateNormal.TextColor = Color.FromArgb(16, 6, 244);
            //        lblErrorMsg.Text = Text;
            //        break;
            //    case "I":
            //        lblErrorMsg.StateCommon.TextColor = Color.DarkGreen;
            //        lblErrorMsg.StateNormal.TextColor = Color.DarkGreen;
            //        lblErrorMsg.Text = Text;
            //        break;
            //    case "E":
            //        lblErrorMsg.StateCommon.TextColor = Color.DarkRed;
            //        lblErrorMsg.StateNormal.TextColor = Color.DarkRed;
            //        lblErrorMsg.Text = "Error: " + Text;
            //        break;
            //}
            switch (Mode)
            {
                case "W":
                    lblErrorMsg1.ForeColor = Color.FromArgb(16, 6, 244);
                    lblErrorMsg1.Text = Text;
                    break;
                case "I":
                    lblErrorMsg1.ForeColor = Color.DarkGreen;
                    lblErrorMsg1.Text = Text;
                    break;
                case "E":
                    lblErrorMsg1.ForeColor = Color.DarkRed;
                    lblErrorMsg1.Text = "Error: " + Text;
                    break;
                default:
                    lblErrorMsg1.ForeColor = Color.Black;
                    lblErrorMsg1.Text = Text;
                    break;
            }
        }
        public void LoadMethod()
        {

            DataTable dt = new BALPaymentMethod().Select(new BOLPaymentMethod() { });
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = "--Select--";
                dr["ID"] = "0";
                dt.Rows.InsertAt(dr, 0);
                cmbPayMethod.DataSource = dt;
                cmbPayMethod.DisplayMember = "Name";
                cmbPayMethod.ValueMember = "ID";
                cmbPayMethod.SelectedIndex = 0;
            }
        }
        public void LoadCustomer()
        {
            //Nidhi Changes
            DataTable dc = new BALCustomerMaster().SelectAllCustomerName(new BOLCustomerMaster() { });
            if (dc.Rows.Count > 0)
            {
                DataRow dr = dc.NewRow();
                dr["CustomerName"] = "--Select--";
                dr["ID"] = "0";
                dc.Rows.InsertAt(dr, 0);
                cmbCustomerName.DataSource = dc;
                cmbCustomerName.DisplayMember = "CustomerName";
                cmbCustomerName.ValueMember = "ID";
                cmbCustomerName.SelectedIndex = 0;
            }
        }
        public void loadData(int InvID)
        {
            try
            {
                InID = InvID;
                Mode = "Insert";

                DataTable dt = new BALInvoiceMaster().SelectByID(new BOLInvoiceMaster() { ID = Convert.ToInt32(InvID) });
                if (dt.Rows.Count > 0)
                {
                    cmbCustomerName.Text = dt.Rows[0]["CustomerFullName"].ToString();

                    //Hiren
                    txtPaidAmt.Text = dt.Rows[0]["BalanceDue"].ToString();
                    //
                    txtInvID.Text = dt.Rows[0]["ID"].ToString();
                    cmbInvoiceNo.Text = dt.Rows[0]["RefNumber"].ToString();
                    txtTotalamt.Text = dt.Rows[0]["Total"].ToString();
                    txtunPaid.Text = dt.Rows[0]["BalanceDue"].ToString();
                    txtPaid.Text = Convert.ToString(Convert.ToDecimal(dt.Rows[0]["Total"].ToString()) - Convert.ToDecimal(dt.Rows[0]["BalanceDue"].ToString()));
                    DataTable dt1 = PayBAL.Select(txtInvID.Text);
                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt1.Rows)
                        {
                            if (dr["CreditAmount"].ToString() != "")
                            {
                                txtCreditAmt.Text = dr["CreditAmount"].ToString();
                            }
                            else
                            {
                                txtCreditAmt.Text = "0.00";
                            }
                            //Hiren
                            txtRef.Text = dt1.Rows[0]["Reference"].ToString();
                        }
                        txtRef.Text = dt1.Rows[0]["Reference"].ToString();
                    }
                    else
                    {
                        txtCreditAmt.Text = "0.00";
                    }

                    DataTable DT2 = new BALPayment().Select(txtInvID.Text);
                    if (DT2.Rows.Count > 0)
                    {
                        int nRowIndex = DT2.Rows.Count - 1;
                        cmbPayMethod.SelectedValue = Convert.ToInt32(DT2.Rows[nRowIndex]["PaymentMethodID"]);
                    }
                    else
                    {
                        DataTable DT3 = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString()) });
                        if (DT3.Rows.Count > 0)
                        {
                            if (DT3.Rows[0]["PaymentMethodID"].ToString() != "")
                            {
                                cmbPayMethod.SelectedValue = DT3.Rows[0]["PaymentMethodID"].ToString();
                            }

                        }
                    }
                    //Hiren
                    decimal NowApplied = 0;
                    string refNumber = dt.Rows[0]["RefNumber"].ToString();
                    foreach (DataGridViewRow row in dgvApplyamount.Rows)
                    {
                        if (row.Cells["Number"] != null && row.Cells["Number"].Value != null && row.Cells["Number"].Value.ToString() == refNumber)
                        {
                            if (row.Cells["SelectAll"] != null)
                            {
                                row.Cells["SelectAll"].Value = true;
                                if (row.Cells["AvailableBalance"] != null && row.Cells["AmtApplied"] != null)
                                {
                                    row.Cells["AmtApplied"].Value = row.Cells["AvailableBalance"].Value;
                                }
                            }
                        }
                        if (row.Cells["AmtApplied"] != null)
                        {
                            decimal AppliedBalance = 0;
                            if (row.Cells["AmtApplied"].ToString() != "")
                            {
                                AppliedBalance = Convert.ToDecimal(row.Cells["AmtApplied"].Value);
                            }
                            NowApplied += AppliedBalance;
                        }
                    }
                    lblPayAmt.Text = NowApplied.ToString("F2");
                    Display();
                    CreditMemoDetails();
                    //LoadInvGriedData();
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function :loadData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        //Hiren
        //public void LoadData(int InvID)
        //{
        //    try
        //    {
        //        InID = InvID;
        //        Mode = "Insert";
        //        DataTable dt = new BALPaymentDetail().SelectByID(new BOLPaymentDetail() { ID = Convert.ToInt32(InvID) });
        //        if (dt.Rows.Count > 0)
        //        {
        //            //Nidhi add
        //            //this.cmbCustomerName.Text = value.ToString();
        //            cmbCustomerName.Text = dt.Rows[0]["CustomerFullName"].ToString();
        //            //

        //            //Hiren
        //            txtPaidAmt.Text = dt.Rows[0]["BalanceDue"].ToString();
        //            //

        //            txtInvID.Text = dt.Rows[0]["ID"].ToString();
        //            cmbInvoiceNo.Text = dt.Rows[0]["RefNumber"].ToString();
        //            txtTotalamt.Text = dt.Rows[0]["Total"].ToString();
        //            txtunPaid.Text = dt.Rows[0]["BalanceDue"].ToString();
        //            txtPaid.Text = Convert.ToString(Convert.ToDecimal(dt.Rows[0]["Total"].ToString()) - Convert.ToDecimal(dt.Rows[0]["BalanceDue"].ToString()));
        //            //if (txtunPaid.Text == "0.00")
        //            //{
        //            //    txtPaidAmt.Enabled = false;
        //            //    cmbPayMethod.Enabled = false;
        //            //}

        //            DataTable dt1 = PayBAL.SelectByPaymentID(txtInvID.Text);
        //            if (dt1.Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in dt1.Rows)
        //                {
        //                    if (dr["CreditAmount"].ToString() != "")
        //                    {
        //                        txtCreditAmt.Text = dr["CreditAmount"].ToString();
        //                    }
        //                    else
        //                    {
        //                        txtCreditAmt.Text = "0.00";
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                txtCreditAmt.Text = "0.00";
        //            }

        //            DataTable DT2 = new BALPayment().Select(txtInvID.Text);
        //            if (DT2.Rows.Count > 0)
        //            {
        //                int nRowIndex = DT2.Rows.Count - 1; //last row index
        //                cmbPayMethod.SelectedValue = Convert.ToInt32(DT2.Rows[nRowIndex]["PaymentMethodID"]);
        //            }
        //            else
        //            {
        //                DataTable DT3 = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString()) });
        //                if (DT3.Rows.Count > 0)
        //                {
        //                    if (DT3.Rows[0]["PaymentMethodID"].ToString() != "")
        //                    {
        //                        cmbPayMethod.SelectedValue = DT3.Rows[0]["PaymentMethodID"].ToString();
        //                    }

        //                }
        //            }
        //            //Hiren
        //            decimal NowApplied = 0;
        //            string refNumber = dt.Rows[0]["RefNumber"].ToString();
        //            foreach (DataGridViewRow row in dgvApplyamount.Rows)
        //            {
        //                if (row.Cells["Number"] != null && row.Cells["Number"].Value != null && row.Cells["Number"].Value.ToString() == refNumber)
        //                {
        //                    if (row.Cells["SelectAll"] != null)
        //                    {
        //                        row.Cells["SelectAll"].Value = true;
        //                        if (row.Cells["AvailableBalance"] != null && row.Cells["AmtApplied"] != null)
        //                        {
        //                            row.Cells["AmtApplied"].Value = row.Cells["AvailableBalance"].Value;
        //                        }
        //                    }
        //                }
        //                if (row.Cells["AmtApplied"] != null)
        //                {
        //                    decimal AppliedBalance = 0;
        //                    if (row.Cells["AmtApplied"].ToString() != "")
        //                    {
        //                        AppliedBalance = Convert.ToDecimal(row.Cells["AmtApplied"].Value);
        //                    }
        //                    NowApplied += AppliedBalance;
        //                }
        //            }
        //            lblPayAmt.Text = NowApplied.ToString("F2");
        //            if (Convert.ToInt32(dt.Rows[0]["PaidInvoice"]) == 1)
        //            {
        //                Display();
        //            }
        //            else
        //            {
        //                DisplayPayment();
        //            }
        //            CreditMemoDetails();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function :loadData. Message:" + ex.Message);
        //        MessageBox.Show("Error:" + ex.Message);
        //    }
        //}
        public void CustomerLoad(int ID)
        {
            DataTable dtCustomer = new BALPaymentDetail().SelectCustomer(ID);
            cmbCustomerName.SelectedValue = dtCustomer.Rows[0]["ID"];
            cmbCustomerName.Text = dtCustomer.Rows[0]["FullName"].ToString();
        }
        //
        private Boolean CheckValidation()
        {
            Boolean ISValid = true;
            try
            {
                if (txtPaidAmt.Text == "")
                {
                    DisplayMessage("Please enter amount for Paid", "E");
                    ISValid = false;
                    txtPaidAmt.Focus();
                }
                //else if(txtPaidAmt.Text != "")
                //{
                //    //if(Convert.ToDecimal(txtPaidAmt.Text) > Convert.ToDecimal(txtunPaid.Text))
                //    //{
                //    //    DisplayMessage("Paid Amount should not greater then unpaid Amount", "E");
                //    //    ISValid = false;
                //    //    txtPaidAmt.Focus();
                //    //}
                //}
                if (cmbPayMethod.SelectedIndex == -1 || cmbPayMethod.SelectedIndex == 0)
                {
                    DisplayMessage("Please select Payment Method", "E");
                    ISValid = false;
                    cmbPayMethod.Focus();
                }

                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }
        private Boolean CheckValidate()
        {
            decimal TotalPaid = 0; decimal Paid = 0;
            Boolean ISValid = true;
            try
            {
                if (txtPaidAmt.Text == "")
                {
                    DisplayMessage("Please enter amount for Paid", "E");
                    ISValid = false;
                    txtPaidAmt.Focus();
                }
                else if (txtPaidAmt.Text != "")
                {
                    for (int i = 0; i < dgvInvoicePaymentList.Rows.Count - 1; i++)
                    {
                        if (txtTranID.Text != dgvInvoicePaymentList.Rows[i].Cells[0].Value.ToString())
                        {
                            TotalPaid += Convert.ToDecimal(dgvInvoicePaymentList.Rows[i].Cells[4].Value.ToString());
                        }
                    }
                    Paid = Convert.ToDecimal(txtTotalamt.Text) - TotalPaid;
                    if (Paid < Convert.ToDecimal(txtPaidAmt.Text))
                    {
                        DisplayMessage("Please Correct paid Amount", "E");
                        ISValid = false;
                        txtPaidAmt.Focus();
                    }

                }
                if (cmbPayMethod.SelectedIndex == -1 || cmbPayMethod.SelectedIndex == 0)
                {
                    DisplayMessage("Please select Payment Method", "E");
                    ISValid = false;
                    cmbPayMethod.Focus();
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
            return ISValid;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            ClsCommon.objPaymentMaster.GetInvoiceByID(txtInvID.Text);
            this.Close();
        }
        private void btnSave1_Click(object sender, EventArgs e)
        {
            lblErrorMsg1.Text = "";
            try
            {

                if (CheckValidation())
                {
                    if (cmbPayMethod.Text == "Credit")
                    {
                        //PayBOL.InvoiceID = Convert.ToInt32(txtInvID.Text);
                        //PayBOL.PaymentMethodID = Convert.ToInt32(cmbPayMethod.SelectedValue);
                        //PayBOL.CreditAmount = Convert.ToDecimal(txtPaidAmt.Text);
                        //PayBOL.PayAmount = null;
                        //PayBOL.Date = DateTime.Now;
                        //PayBAL.Insert(PayBOL);
                        foreach (DataGridViewRow row in dgvApplyamount.Rows)
                        {
                            int ID = Convert.ToInt32(row.Cells["InvID"].EditedFormattedValue);
                            decimal amtApplied = 0;
                            if (row.Cells["AmtApplied"].EditedFormattedValue.ToString() != "")
                            {
                                amtApplied = Convert.ToDecimal(row.Cells["AmtApplied"].EditedFormattedValue);
                            }
                            decimal AlreadyApplied = Convert.ToDecimal(row.Cells["AppliedBalance"].EditedFormattedValue);
                            decimal BalanceDue = Convert.ToDecimal(row.Cells["AvailableBalance"].EditedFormattedValue);

                            if (amtApplied != 0)
                            {
                                PayBOL.InvoiceID = Convert.ToInt32(ID);
                                PayBOL.PaymentMethodID = Convert.ToInt32(cmbPayMethod.SelectedValue);
                                PayBOL.CreditAmount = amtApplied;
                                PayBOL.PayAmount = null;
                                PayBOL.Date = DateTime.Now;
                                PayBOL.Reference = txtRef.Text;
                                PayBAL.Insert(PayBOL);
                            }
                        }
                    }
                    else
                    {

                        //if (Convert.ToDecimal(txtunPaid.Text) == Convert.ToDecimal(txtPaidAmt.Text))
                        //{
                        //    objBOLInvoice.ID = Convert.ToInt32(txtInvID.Text);
                        //    objBOLInvoice.PaidInvoice = 2;
                        //    objBOLInvoice.AppliedAmount = (Convert.ToDecimal(txtPaid.Text) + Convert.ToDecimal(txtPaidAmt.Text));
                        //    objBOLInvoice.BalanceDue = (Convert.ToDecimal(txtunPaid.Text) - Convert.ToDecimal(txtPaidAmt.Text));
                        //    objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                        //}
                        //else if (Convert.ToDecimal(txtunPaid.Text) > Convert.ToDecimal(txtPaidAmt.Text))
                        //{
                        //    objBOLInvoice.ID = Convert.ToInt32(txtInvID.Text);
                        //    objBOLInvoice.PaidInvoice = 1;
                        //    objBOLInvoice.AppliedAmount = (Convert.ToDecimal(txtPaid.Text) + Convert.ToDecimal(txtPaidAmt.Text));
                        //    objBOLInvoice.BalanceDue = (Convert.ToDecimal(txtunPaid.Text) - Convert.ToDecimal(txtPaidAmt.Text));
                        //    objBALInvoice.UpdatePaidInvoice(objBOLInvoice);

                        //}
                        //else if (Convert.ToDecimal(txtunPaid.Text) < Convert.ToDecimal(txtPaidAmt.Text))
                        //{
                        //    objBOLInvoice.ID = Convert.ToInt32(txtInvID.Text);
                        //    objBOLInvoice.PaidInvoice = 2;
                        //    objBOLInvoice.AppliedAmount = (Convert.ToDecimal(txtPaid.Text) + Convert.ToDecimal(txtPaidAmt.Text));
                        //    objBOLInvoice.BalanceDue = (Convert.ToDecimal(txtunPaid.Text) - Convert.ToDecimal(txtPaidAmt.Text));
                        //    objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                        //}


                        foreach (DataGridViewRow row in dgvApplyamount.Rows)
                        {
                            int ID = Convert.ToInt32(row.Cells["InvID"].EditedFormattedValue);
                            decimal amtApplied = 0;
                            if (row.Cells["AmtApplied"].EditedFormattedValue.ToString() != "")
                            {
                                amtApplied = Convert.ToDecimal(row.Cells["AmtApplied"].EditedFormattedValue);
                            }
                            decimal AlreadyApplied = Convert.ToDecimal(row.Cells["AppliedBalance"].EditedFormattedValue);
                            decimal BalanceDue = Convert.ToDecimal(row.Cells["AvailableBalance"].EditedFormattedValue);

                            if (amtApplied != 0)
                            {
                                //if (row.Cells["AmtApplied"].Value != null && decimal.TryParse(row.Cells["AmtApplied"].Value.ToString(), out decimal amtApplied) && amtApplied != 0 &&
                                //     row.Cells["AvailableBalance"].Value != null && decimal.TryParse(row.Cells["AvailableBalance"].Value.ToString(), out decimal availableBalance))
                                //{
                                objBOLInvoice.ID = ID;
                                if (BalanceDue == amtApplied)
                                {
                                    objBOLInvoice.PaidInvoice = 2;
                                    objBOLInvoice.AppliedAmount = AlreadyApplied + amtApplied;
                                    objBOLInvoice.BalanceDue = BalanceDue - amtApplied;
                                    objBALInvoice.UpdateInvoicePaidAmount(objBOLInvoice);
                                }
                                else if (BalanceDue > amtApplied)
                                {
                                    objBOLInvoice.PaidInvoice = 1;
                                    objBOLInvoice.AppliedAmount = AlreadyApplied + amtApplied;
                                    objBOLInvoice.BalanceDue = BalanceDue - amtApplied;
                                    objBALInvoice.UpdateInvoicePaidAmount(objBOLInvoice);
                                }
                                else if (BalanceDue < amtApplied)
                                {
                                    objBOLInvoice.PaidInvoice = 2;
                                    objBOLInvoice.AppliedAmount = AlreadyApplied + amtApplied;
                                    objBOLInvoice.BalanceDue = BalanceDue - amtApplied;
                                    objBALInvoice.UpdateInvoicePaidAmount(objBOLInvoice);
                                }
                                //}
                                PayBOL.InvoiceID = Convert.ToInt32(ID);
                                PayBOL.PaymentMethodID = Convert.ToInt32(cmbPayMethod.SelectedValue);
                                PayBOL.PayAmount = amtApplied;
                                PayBOL.CreditAmount = null;
                                PayBOL.Date = DateTime.Now;
                                //Hiren
                                PayBOL.Reference = txtRef.Text;
                                PayBAL.Insert(PayBOL);
                            }
                        }
                    }
                    Display();
                    CreditMemoDetails();
                    ClearData();
                    if (!string.IsNullOrEmpty(txtInvID.Text))
                    {
                        loadData(Convert.ToInt32(txtInvID.Text));
                    }

                    //LoadData(Convert.ToInt32(txtInvID.Text));
                    LoadInvGriedData();
                    if (!string.IsNullOrWhiteSpace(txtPaidAmt.Text) && txtPaidAmt.Text != "0.00")
                    {
                        IsPaymentManually = true;
                    }
                    else
                    {
                        IsPaymentManually = false;
                    }
                    cmbPayMethod.SelectedIndex = 0;
                    this.Close();
                    ClsCommon.ObjCustomerCenter.LoadAllInvoices();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function :btnSave_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal Balance = 0; decimal TotalPaid = 0; decimal Paid = 0;
                lblErrorMsg1.Text = "";
                if (dgvInvoicePaymentList.CurrentRow.Cells[7].Value.ToString() != "")
                {
                    if (dgvInvoicePaymentList.CurrentRow.Cells[7].Value.ToString() == "0")
                    {
                        DataTable dt = new BALInvoiceMaster().SelectByID(new BOLInvoiceMaster() { ID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[8].Value) });
                        if (dt.Rows.Count > 0)
                        {
                            if (CheckValidate())
                            {

                                if (cmbPayMethod.Text == "Credit")
                                {
                                    for (int i = 0; i < dgvInvoicePaymentList.Rows.Count; i++)
                                    {
                                        TotalPaid += Convert.ToDecimal(dgvInvoicePaymentList.Rows[i].Cells[4].Value.ToString());
                                    }
                                    Paid = TotalPaid - Convert.ToDecimal(txtPaidAmt.Text);
                                    Balance = Convert.ToDecimal(dt.Rows[0]["Total"].ToString()) - Paid;

                                    objBOLInvoice.ID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[8].Value);
                                    objBOLInvoice.AppliedAmount = Paid;
                                    objBOLInvoice.BalanceDue = Balance;
                                    if (Paid == Convert.ToDecimal(dt.Rows[0]["Total"].ToString()))
                                    {
                                        objBOLInvoice.PaidInvoice = 2;
                                    }
                                    else if (Paid != 0 && Paid < Convert.ToDecimal(dt.Rows[0]["Total"].ToString()))
                                    {
                                        objBOLInvoice.PaidInvoice = 1;
                                    }
                                    else
                                    {
                                        objBOLInvoice.PaidInvoice = 0;
                                    }
                                    objBALInvoice.UpdatePaidInvoice(objBOLInvoice);

                                    PayBOL.ID = Convert.ToInt32(txtTranID.Text);
                                    PayBOL.InvoiceID = Convert.ToInt32(txtInvID.Text);
                                    PayBOL.PaymentMethodID = Convert.ToInt32(cmbPayMethod.SelectedValue);
                                    PayBOL.PayAmount = null;
                                    PayBOL.CreditAmount = Convert.ToDecimal(txtPaidAmt.Text);
                                    PayBOL.Date = DateTime.Now;
                                    //Hiren
                                    PayBOL.Reference = txtRef.Text;
                                    PayBAL.UpdateAll(PayBOL);
                                }

                                else
                                {
                                    for (int i = 0; i < dgvInvoicePaymentList.Rows.Count; i++)
                                    {
                                        if (txtTranID.Text != dgvInvoicePaymentList.Rows[i].Cells[0].Value.ToString())
                                        {
                                            TotalPaid += Convert.ToDecimal(dgvInvoicePaymentList.Rows[i].Cells[4].Value.ToString());
                                        }
                                    }
                                    Paid = Convert.ToDecimal(txtPaidAmt.Text) + TotalPaid;
                                    Balance = Convert.ToDecimal(dt.Rows[0]["Total"].ToString()) - Paid;

                                    objBOLInvoice.ID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[8].Value);
                                    objBOLInvoice.AppliedAmount = Paid;
                                    objBOLInvoice.BalanceDue = Balance;
                                    if (Paid == Convert.ToDecimal(dt.Rows[0]["Total"].ToString()))
                                    {
                                        objBOLInvoice.PaidInvoice = 2;
                                    }
                                    else if (Paid != 0 && Paid < Convert.ToDecimal(dt.Rows[0]["Total"].ToString()))
                                    {
                                        objBOLInvoice.PaidInvoice = 1;
                                    }
                                    else
                                    {
                                        objBOLInvoice.PaidInvoice = 0;
                                    }
                                    objBALInvoice.UpdatePaidInvoice(objBOLInvoice);

                                    PayBOL.ID = Convert.ToInt32(txtTranID.Text);
                                    //PayBOL.InvoiceID = Convert.ToInt32(txtInvID.Text);
                                    //Hiren
                                    PayBOL.InvoiceID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                                    PayBOL.PaymentMethodID = Convert.ToInt32(cmbPayMethod.SelectedValue);
                                    PayBOL.PayAmount = Convert.ToDecimal(txtPaidAmt.Text);
                                    PayBOL.CreditAmount = null;
                                    PayBOL.Date = DateTime.Now;
                                    //Hiren
                                    PayBOL.Reference = txtRef.Text;
                                    PayBAL.UpdateAll(PayBOL);
                                }

                                Display();
                                CreditMemoDetails();
                                ClearData();
                                loadData(Convert.ToInt32(txtInvID.Text));
                                LoadInvGriedData();
                                btnSave1.Enabled = true;
                                btnUpdate.Enabled = false;
                                //Hiren
                                label10.Visible = false;
                                txtPaid.Visible = false;
                                label7.Visible = false;
                                txtCreditAmt.Visible = false;
                                label12.Visible = false;
                                cmbInvoiceNo.Visible = false;
                                label1.Visible = false;
                                txtTotalamt.Visible = false;
                                label9.Visible = false;
                                txtunPaid.Visible = false;
                                //Hiren
                                //ClsCommon.ObjCustomerCenter.LoadAllInvoices();
                                cmbPayMethod.SelectedIndex = 0;
                            }
                        }
                    }
                    else
                    {
                        ClearData();
                        btnSave1.Enabled = true;
                        btnUpdate.Enabled = false;
                        DisplayMessage("You can not update this Payment it is already sync in QB", "E");
                    }
                }

                label6.Visible = false;
                txtTotalamt.Visible = false;
                label3.Visible = false;
                txtunPaid.Visible = false;
                label5.Visible = false;
                txtPaid.Visible = false;
                label7.Visible = false;
                txtCreditAmt.Visible = false;
                Mode = "Insert";
                if (!string.IsNullOrWhiteSpace(txtPaidAmt.Text) && txtPaidAmt.Text != "0.00")
                {
                    IsPaymentManually = true;
                }
                else
                {
                    IsPaymentManually = false;
                }
                this.Close();
                ClsCommon.ObjCustomerCenter.LoadAllInvoices();

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function :btnUpdate_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void ClearData()
        {
            cmbPayMethod.SelectedIndex = 0;
            txtPaidAmt.Text = "";
            txtTranID.Text = "";
            //lblTotalAmt.Text = "";
            //lblDueAmt.Text = "";
            lblPayAmt.Text = "";
            dgvCreditMemoPaymentList.Rows.Clear();
            txtRef.Text = "";
            //dgvInvoicePaymentList.Rows.Clear();
        }
        //princy changes
        private void Display()
        {
            try
            {
                dgvInvoicePaymentList.Rows.Clear();
                DataTable dt = new DataTable();
                dt = PayBAL.Select(txtInvID.Text);
                if (dt.Rows.Count > 0)
                {
                    int iRow = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        dgvInvoicePaymentList.Rows.Add();
                        dgvInvoicePaymentList[0, iRow].Value = item["ID"].ToString();
                        dgvInvoicePaymentList[1, iRow].Value = item["RefNumber"].ToString();
                        dgvInvoicePaymentList[2, iRow].Value = item["Name"].ToString();
                        dgvInvoicePaymentList[3, iRow].Value = item["Date"].ToString();
                        if (item["PayAmount"].ToString() != "")
                        {
                            dgvInvoicePaymentList[4, iRow].Value = item["PayAmount"].ToString();
                        }
                        else
                        {
                            dgvInvoicePaymentList[4, iRow].Value = "0.00";
                        }
                        if (item["CreditAmount"].ToString() != "")
                        {
                            dgvInvoicePaymentList[5, iRow].Value = item["CreditAmount"].ToString();
                        }
                        else
                        {
                            dgvInvoicePaymentList[5, iRow].Value = "0.00";
                        }
                        dgvInvoicePaymentList[7, iRow].Value = item["IsQBSync"].ToString();
                        dgvInvoicePaymentList[8, iRow].Value = item["InvoiceID"].ToString();
                        iRow++;
                    }
                }
                int selectedInvoiceID = PayID;

                foreach (DataGridViewRow row in dgvInvoicePaymentList.Rows)
                {
                    if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int rowInvoiceID))
                    {
                        if (rowInvoiceID == selectedInvoiceID)
                        {
                            row.DefaultCellStyle.BackColor = Color.Yellow;
                            row.DefaultCellStyle.Font = new Font(dgvInvoicePaymentList.Font, FontStyle.Bold);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function :Display. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        //Hiren
        //private void DisplayPayment()
        //{
        //    try
        //    {
        //        dgvInvoicePaymentList.Rows.Clear();
        //        DataTable dt = new DataTable();
        //        dt = PayBAL.SelectByPaymentID(txtInvID.Text);
        //        if (dt.Rows.Count > 0)
        //        {
        //            int iRow = 0;
        //            foreach (DataRow item in dt.Rows)
        //            {
        //                dgvInvoicePaymentList.Rows.Add();
        //                dgvInvoicePaymentList[0, iRow].Value = item["ID"].ToString();
        //                dgvInvoicePaymentList[1, iRow].Value = item["RefNumber"].ToString();
        //                dgvInvoicePaymentList[2, iRow].Value = item["Name"].ToString();
        //                dgvInvoicePaymentList[3, iRow].Value = item["Date"].ToString();
        //                if (item["PayAmount"].ToString() != "")
        //                {
        //                    dgvInvoicePaymentList[4, iRow].Value = item["PayAmount"].ToString();
        //                }
        //                else
        //                {
        //                    dgvInvoicePaymentList[4, iRow].Value = "0.00";
        //                }
        //                if (item["CreditAmount"].ToString() != "")
        //                {
        //                    dgvInvoicePaymentList[5, iRow].Value = item["CreditAmount"].ToString();
        //                }
        //                else
        //                {
        //                    dgvInvoicePaymentList[5, iRow].Value = "0.00";
        //                }
        //                dgvInvoicePaymentList[7, iRow].Value = item["IsQBSync"].ToString();
        //                dgvInvoicePaymentList[8, iRow].Value = item["InvoiceID"].ToString();
        //                iRow++;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function :Display. Message:" + ex.Message);
        //        MessageBox.Show("Error:" + ex.Message);
        //    }
        //}

        private void dgvInvoicePaymentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    decimal PaidAmt = 0; decimal Balance = 0;
                    if (dgvInvoicePaymentList.CurrentRow.Cells[7].Value.ToString() != "")
                    {
                        DataTable dt = new BALInvoiceMaster().SelectByID(new BOLInvoiceMaster() { ID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[8].Value) });
                        if (dgvInvoicePaymentList.CurrentRow.Cells[7].Value.ToString() == "0")
                        {
                            if (dt.Rows.Count > 0)
                            {
                                if (dgvInvoicePaymentList.CurrentRow.Cells[4].Value.ToString() != "0.00")
                                {
                                    PaidAmt = Convert.ToDecimal(dt.Rows[0]["AppliedAmount"].ToString()) - Convert.ToDecimal(dgvInvoicePaymentList.CurrentRow.Cells[4].Value.ToString());
                                    Balance = Convert.ToDecimal(dt.Rows[0]["Total"].ToString()) - PaidAmt;

                                    objBOLInvoice.ID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[8].Value);
                                    objBOLInvoice.AppliedAmount = PaidAmt;
                                    objBOLInvoice.BalanceDue = Balance;
                                    if (PaidAmt == Convert.ToDecimal(dt.Rows[0]["Total"].ToString()))
                                    {
                                        objBOLInvoice.PaidInvoice = 2;
                                    }
                                    else if (PaidAmt != 0 && PaidAmt < Convert.ToDecimal(dt.Rows[0]["Total"].ToString()))
                                    {
                                        objBOLInvoice.PaidInvoice = 1;
                                    }
                                    else
                                    {
                                        objBOLInvoice.PaidInvoice = 0;
                                    }
                                    objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                                    objpaypalBAL.DeleteByID(Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[0].Value));
                                    cmbPayMethod.Enabled = true;
                                    txtPaidAmt.Enabled = true;
                                }

                                else if (dgvInvoicePaymentList.CurrentRow.Cells[5].Value.ToString() != "0.00")
                                {
                                    objpaypalBAL.DeleteByID(Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[0].Value));
                                }

                            }

                            Display();
                            CreditMemoDetails();
                            loadData(Convert.ToInt32(txtInvID.Text));
                            LoadInvGriedData();
                            txtPaidAmt.Text = "";
                            cmbPayMethod.SelectedIndex = 0;
                        }
                        else
                        {
                            if (dgvInvoicePaymentList.CurrentRow.Cells[7].Value.ToString() != "0.00")
                            {
                                int ID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[0].Value.ToString());
                                PayBOL.ID = ID;
                                PayBAL.DeletePayment(ID);
                                PaidAmt = Convert.ToDecimal(dt.Rows[0]["AppliedAmount"].ToString()) - Convert.ToDecimal(dgvInvoicePaymentList.CurrentRow.Cells[4].Value.ToString());
                                Balance = Convert.ToDecimal(dt.Rows[0]["Total"].ToString()) - PaidAmt;

                                objBOLInvoice.ID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[8].Value);
                                objBOLInvoice.AppliedAmount = PaidAmt;
                                objBOLInvoice.BalanceDue = Balance;
                                if (PaidAmt == Convert.ToDecimal(dt.Rows[0]["Total"].ToString()))
                                {
                                    objBOLInvoice.PaidInvoice = 2;
                                }
                                else if (PaidAmt != 0 && PaidAmt < Convert.ToDecimal(dt.Rows[0]["Total"].ToString()))
                                {
                                    objBOLInvoice.PaidInvoice = 1;
                                }
                                else
                                {
                                    objBOLInvoice.PaidInvoice = 0;
                                }
                                objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                                cmbPayMethod.Enabled = true;
                                txtPaidAmt.Enabled = true;
                            }
                            else
                            {
                                DisplayMessage("You can not delete this Payment it is already sync in QB", "E");
                            }
                            Display();
                        }
                    }
                }
                else if (e.ColumnIndex == 9)
                {
                    int ID1 = Convert.ToInt32(Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[8].Value));
                    //ClsCommon.ObjCustomerCenter.PrintINV(ref ID1);
                    ClsCommon.ObjCustomerCenter.PreviewINV(ref ID1);
                    ClsCommon.INVID = ID1;
                    ClsCommon.ObjInvoiceMaster.InvoicePrintHistory(ClsCommon.INVID);
                    //ClsCommon.ObjInvoiceMaster.PrintSave(ClsCommon.INVID);
                    //MessageBox.Show("Invoice Print Successfully");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function :dgvInvoicePaymentList_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgvInvoicePaymentList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(dgvInvoicePaymentList.CurrentRow.Cells[8].Value);
                DataTable dt = new BALPayment().SelectByInvID(ID);
                if (dgvInvoicePaymentList.Rows.Count > 0)
                {
                    txtTranID.Text = dgvInvoicePaymentList.CurrentRow.Cells[0].Value.ToString();
                    cmbPayMethod.Text = dgvInvoicePaymentList.CurrentRow.Cells[2].Value.ToString();
                    if (dgvInvoicePaymentList.CurrentRow.Cells[4].Value.ToString() != "0.00")
                    {
                        txtPaidAmt.Text = dgvInvoicePaymentList.CurrentRow.Cells[4].Value.ToString();
                    }
                    else if (dgvInvoicePaymentList.CurrentRow.Cells[5].Value.ToString() != "0.00")
                    {
                        txtPaidAmt.Text = dgvInvoicePaymentList.CurrentRow.Cells[5].Value.ToString();
                    }
                    txtRef.Text = dt.Rows[0]["Reference"].ToString();
                }
                label6.Visible = true;
                txtTotalamt.Visible = true;
                label3.Visible = true;
                txtunPaid.Visible = true;
                label5.Visible = true;
                txtPaid.Visible = true;
                label7.Visible = true;
                txtCreditAmt.Visible = true;
                label10.Visible = true;
                label12.Visible = true;
                label1.Visible = true;
                label9.Visible = true;
                cmbPayMethod.Enabled = true;
                txtPaidAmt.Enabled = true;
                btnSave1.Enabled = false;
                btnUpdate.Enabled = true;
                cmbInvoiceNo.Visible = true;
                Mode = "Update";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function :dgvInvoicePaymentList_CellContentDoubleClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
            btnSave1.Enabled = true;
            btnUpdate.Enabled = false;

            foreach (DataGridViewRow row in dgvApplyamount.Rows)
            {
                row.Cells["SelectAll"].Value = false;
                row.Cells["AmtApplied"].Value = DBNull.Value;
            }
            //cmbCustomerName.SelectedIndex = 0;
            //dgvApplyamount.Rows.Clear();
        }
        public void CreditMemoDetails()
        {

            try
            {
                decimal TotalCredit = 0;
                DataTable dt = new DataTable();
                if (Invoice != 0)
                {
                    dt = new BALCreditMemoPayment().Select(Invoice.ToString());
                }
                else
                {
                    dt = new BALCreditMemoPayment().Select(txtInvID.Text);
                }
                if (dt.Rows.Count > 0)
                {
                    dgvCreditMemoPaymentList.Rows.Clear();
                    int iRow = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        dgvCreditMemoPaymentList.Rows.Add();
                        dgvCreditMemoPaymentList["ID1", iRow].Value = item["ID"].ToString();
                        dgvCreditMemoPaymentList["CreditMemoID", iRow].Value = item["CreditMemoID"].ToString();
                        dgvCreditMemoPaymentList["CreditNumber", iRow].Value = item["RefNumber"].ToString();
                        dgvCreditMemoPaymentList["CreditDate", iRow].Value = item["Date"].ToString();
                        dgvCreditMemoPaymentList["CreditPayAmount", iRow].Value = item["PayAmount"].ToString();
                        iRow++;
                        TotalCredit += Convert.ToDecimal(item["PayAmount"].ToString());
                    }
                }
                else
                {
                    dgvCreditMemoPaymentList.Rows.Clear();
                }
                txtApplyCredit.Text = TotalCredit.ToString();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function :CreditMemoDetails. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void dgvCreditMemoPaymentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                txtunPaid.Text = (Convert.ToDecimal(txtunPaid.Text) + Convert.ToDecimal(dgvCreditMemoPaymentList.CurrentRow.Cells["CreditPayAmount"].Value)).ToString();
                txtPaid.Text = (Convert.ToDecimal(txtPaid.Text) - Convert.ToDecimal(dgvCreditMemoPaymentList.CurrentRow.Cells["CreditPayAmount"].Value)).ToString();
                txtApplyCredit.Text = (Convert.ToDecimal(txtApplyCredit.Text) - Convert.ToDecimal(dgvCreditMemoPaymentList.CurrentRow.Cells["CreditPayAmount"].Value)).ToString();

                //CREDITMEMO UPDATE


                DataTable Memo = BALCreditMemo.SelectByInvID(Convert.ToInt32(dgvCreditMemoPaymentList.CurrentRow.Cells["CreditMemoID"].Value));


                BOLCreditMemo.ID = Convert.ToInt32(dgvCreditMemoPaymentList.CurrentRow.Cells["CreditMemoID"].Value);

                if ((Convert.ToDecimal(Memo.Rows[0]["AppliedAmount"].ToString()) - Convert.ToDecimal(dgvCreditMemoPaymentList.CurrentRow.Cells["CreditPayAmount"].Value) == Convert.ToDecimal(Memo.Rows[0]["Total"].ToString())))
                {
                    BOLCreditMemo.PaidInvoice = 2;
                }
                else if ((Convert.ToDecimal(Memo.Rows[0]["AppliedAmount"].ToString()) - Convert.ToDecimal(dgvCreditMemoPaymentList.CurrentRow.Cells["CreditPayAmount"].Value) < Convert.ToDecimal(Memo.Rows[0]["Total"].ToString())))
                {
                    BOLCreditMemo.PaidInvoice = 1;
                }
                else
                {
                    BOLCreditMemo.PaidInvoice = 0;
                }
                BOLCreditMemo.BalanceDue = Convert.ToDecimal(Memo.Rows[0]["BalanceDue"].ToString()) + Convert.ToDecimal(dgvCreditMemoPaymentList.CurrentRow.Cells["CreditPayAmount"].Value);
                BOLCreditMemo.AppliedAmount = Convert.ToDecimal(Memo.Rows[0]["AppliedAmount"].ToString()) - Convert.ToDecimal(dgvCreditMemoPaymentList.CurrentRow.Cells["CreditPayAmount"].Value);
                BALCreditMemo.UpdatePaidInvoice(BOLCreditMemo);

                BALCreditMemoPayment.Delete(Convert.ToInt32(dgvCreditMemoPaymentList.CurrentRow.Cells["ID1"].Value));


                if (Convert.ToDecimal(txtunPaid.Text) == Convert.ToDecimal(txtPaid.Text))
                {
                    objBOLInvoice.ID = Convert.ToInt32(txtInvID.Text);
                    objBOLInvoice.PaidInvoice = 2;
                    objBOLInvoice.AppliedAmount = Convert.ToDecimal(txtPaid.Text);
                    objBOLInvoice.BalanceDue = Convert.ToDecimal(txtunPaid.Text);
                    objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                }
                else if (Convert.ToDecimal(txtunPaid.Text) > Convert.ToDecimal(txtPaid.Text) && Convert.ToDecimal(txtPaid.Text) != 0)
                {
                    objBOLInvoice.ID = Convert.ToInt32(txtInvID.Text);
                    objBOLInvoice.PaidInvoice = 1;
                    objBOLInvoice.AppliedAmount = Convert.ToDecimal(txtPaid.Text);
                    objBOLInvoice.BalanceDue = Convert.ToDecimal(txtunPaid.Text);
                    objBALInvoice.UpdatePaidInvoice(objBOLInvoice);

                }
                else if (Convert.ToDecimal(txtunPaid.Text) < Convert.ToDecimal(txtPaid.Text) && Convert.ToDecimal(txtPaid.Text) != 0)
                {
                    objBOLInvoice.ID = Convert.ToInt32(txtInvID.Text);
                    objBOLInvoice.PaidInvoice = 2;
                    objBOLInvoice.AppliedAmount = Convert.ToDecimal(txtPaid.Text);
                    objBOLInvoice.BalanceDue = Convert.ToDecimal(txtunPaid.Text);
                    objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                }
                else if (Convert.ToDecimal(txtPaid.Text) == 0)
                {
                    objBOLInvoice.ID = Convert.ToInt32(txtInvID.Text);
                    objBOLInvoice.PaidInvoice = 0;
                    objBOLInvoice.AppliedAmount = 0;
                    objBOLInvoice.BalanceDue = Convert.ToDecimal(txtunPaid.Text);
                    objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                }

                CreditMemoDetails();
            }
            LoadInvGriedData();
        }
        public void CheckEnable()
        {
            cmbCustomerName.Enabled = false;
            cmbInvoiceNo.Enabled = false;
        }

        private void cmbInvoiceNo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbInvoiceNo.SelectedIndex != 0)
            {
                ClearData();
                DataTable IN = new DataTable();
                int id = 0;
                id = Convert.ToInt32(cmbInvoiceNo.SelectedValue);
                Invoice = id;
                loadData(Convert.ToInt32(id));
            }
        }
        public void LoadRefnumber()
        {
            try
            {
                int CustomerID = 0;
                DataTable dtCustomer = new DataTable();
                if (cmbCustomerName.SelectedIndex != 0)
                {
                    ClearData();
                    CustomerID = Convert.ToInt32(cmbCustomerName.SelectedValue);
                    dtCustomer = objBALInvoice.SelectByRefNumber(CustomerID);
                    DataRow dr = dtCustomer.NewRow();
                    dr["RefNumber"] = "--Select--";
                    dr["ID"] = "0";
                    dtCustomer.Rows.InsertAt(dr, 0);
                    cmbInvoiceNo.DataSource = dtCustomer;
                    cmbInvoiceNo.DisplayMember = "RefNumber";
                    cmbInvoiceNo.ValueMember = "ID";
                    cmbInvoiceNo.SelectedIndex = 0;
                }
                else
                {
                    cmbInvoiceNo.Enabled = false;
                    cmbInvoiceNo.Text = "";
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function :cmbCustomerName_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtTotalamt.Text = "";
            //txtunPaid.Text = "";
            //txtPaid.Text = "";
            //txtCreditAmt.Text = "";
            //LoadRefnumber();


            txtTotalamt.Text = "";
            txtunPaid.Text = "";
            txtPaid.Text = "";
            txtCreditAmt.Text = "";
            cmbInvoiceNo.Enabled = true;
            LoadRefnumber();
            //Hiren
            LoadInvGriedData();
        }
        private void cmbPayMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPayMethod.Text == "Credit Card")
            {
                btnApplyCreditCard.Visible = true;
            }
            else
            {
                btnApplyCreditCard.Visible = false;

            }
        }
        private void btnApplyCreditCard_Click(object sender, EventArgs e)
        {
            if (InID != 0)
            {
                ClsCommon.objCreditCard.InvoiceID = InID;
                ClsCommon.objCreditCard.LoadData(InID);
                ClsCommon.objCreditCard.Show();
            }
            else
            {
                MessageBox.Show("Please Select Refnumber First");
            }
        }
        public void LoadInvGriedData()
        {
            try
            {
                dgvApplyamount.Rows.Clear();
                if (cmbCustomerName.SelectedValue != null && cmbCustomerName.SelectedValue is DataRowView dataRowView)
                {
                    CustomerID = Convert.ToInt32(dataRowView["ID"]);
                }
                else
                {
                    CustomerID = Convert.ToInt32(cmbCustomerName.SelectedValue);
                }
                DataTable dtGried = new BALInvoiceMaster().SelectByUnpaidInvoice(CustomerID);
                if (dtGried.Rows.Count > 0)
                {
                    dtGried.DefaultView.Sort = "TxnDate DESC";
                    DataTable sortedTable = dtGried.DefaultView.ToTable();
                    int iRow = 0;
                    decimal totalAmt = 0;
                    decimal availableBalance = 0;
                    foreach (DataRow item in sortedTable.Rows)
                    {
                        dgvApplyamount.Rows.Add();
                        dgvApplyamount["InvID", iRow].Value = item["ID"].ToString();
                        dgvApplyamount["Date", iRow].Value = Convert.ToDateTime(item["TxnDate"]).ToString("MM/dd/yyyy");
                        dgvApplyamount["Number", iRow].Value = item["RefNumber"].ToString();
                        decimal total = Convert.ToDecimal(item["Total"]);
                        decimal balanceDue = Convert.ToDecimal(item["BalanceDue"]);
                        decimal AppliedBalance = Convert.ToDecimal(item["AppliedAmount"]);
                        dgvApplyamount["TotalAmt", iRow].Value = total.ToString("F2");
                        dgvApplyamount["AvailableBalance", iRow].Value = balanceDue.ToString("F2");
                        dgvApplyamount["AppliedBalance", iRow].Value = AppliedBalance.ToString("F2");
                        totalAmt += total;
                        availableBalance += balanceDue;
                        //NowApplied += AppliedBalance;
                        iRow++;
                    }
                    lblTotalAmt.Text = totalAmt.ToString("F2");
                    lblDueAmt.Text = availableBalance.ToString("F2");
                    //lblPayAmt.Text = NowApplied.ToString("F2");


                }
                else
                {
                    lblTotalAmt.Text = "0.00";
                    lblDueAmt.Text = "0.00";
                    //lblPayAmt.Text = "0.00";
                }
                decimal NowApplied = 0;

                //foreach (DataGridViewRow row in dgvApplyamount.Rows)
                //{

                //    if (row.Cells["AmtApplied"] != null)
                //    {
                //        decimal AppliedBalance = 0;
                //        if (row.Cells["AmtApplied"].EditedFormattedValue.ToString() != "")
                //        {
                //            AppliedBalance = Convert.ToDecimal(row.Cells["AmtApplied"].Value);
                //        }
                //        NowApplied += AppliedBalance;
                //    }
                //}
                //lblPayAmt.Text = NowApplied.ToString("F2");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function:LoadInvGriedData. Message:" + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void dgvApplyamount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvApplyamount.Columns["SelectAll"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvApplyamount.Rows[e.RowIndex];
                    bool isChecked = Convert.ToBoolean(row.Cells["SelectAll"].Value);
                    row.Cells["SelectAll"].Value = !isChecked;

                    if (!IsPaymentManually)
                    {
                        if (!isChecked)
                        {
                            row.Cells["AmtApplied"].Value = row.Cells["AvailableBalance"].Value;
                        }
                        else
                        {
                            row.Cells["AmtApplied"].Value = string.Empty;
                        }
                        UpdateTotalAppliedAmount();
                    }
                    else
                    {
                        if (e.ColumnIndex == dgvApplyamount.Columns["SelectAll"].Index && e.RowIndex >= 0)
                        {
                            DataGridViewRow row1 = dgvApplyamount.Rows[e.RowIndex];
                            bool isChecked1 = Convert.ToBoolean(row.Cells["SelectAll"].EditedFormattedValue);
                            ManageInvoiceSelection(row, isChecked);
                        }
                    }
                    UpdateSelectedInvoicesTotal();
                }
                else if (e.ColumnIndex == 8)
                {
                    int ID1 = Convert.ToInt32(Convert.ToInt32(dgvApplyamount.CurrentRow.Cells[0].Value));
                    //ClsCommon.ObjCustomerCenter.PrintINV(ref ID1);
                    ClsCommon.ObjCustomerCenter.PreviewINV(ref ID1);
                    ClsCommon.INVID = ID1;
                    ClsCommon.ObjInvoiceMaster.InvoicePrintHistory(ClsCommon.INVID);
                    //ClsCommon.ObjInvoiceMaster.PrintSave(ClsCommon.INVID);
                    //MessageBox.Show("Invoice Print Successfully");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function:dgvApplyamount_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void UpdateTotalAppliedAmount()
        {
            try
            {
                decimal totalAppliedAmount = 0;
                foreach (DataGridViewRow row in dgvApplyamount.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["SelectAll"].Value);
                    if (isSelected)
                    {

                        if (decimal.TryParse(row.Cells["AmtApplied"].Value?.ToString(), out decimal amtApplied) && amtApplied > 0)
                        {
                            totalAppliedAmount += amtApplied;
                        }
                    }
                }
                txtPaidAmt.Text = totalAppliedAmount.ToString("F2");
                lblPayAmt.Text = totalAppliedAmount.ToString("F2");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function:UpdateTotalAppliedAmount. Message:" + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //public void ManagePayment()
        //{
        //    try
        //    {
        //        decimal totalPaidAmount = 0;
        //        bool isPaidAmtValid = decimal.TryParse(txtPaidAmt.Text, out totalPaidAmount);
        //        if (!isPaidAmtValid)
        //        {
        //            foreach (DataGridViewRow row in dgvApplyamount.Rows)
        //            {
        //                row.Cells["AmtApplied"].Value = null;
        //                row.Cells["SelectAll"].Value = false;
        //            }
        //            //MessageBox.Show("Invalid Paid Amount.");
        //            return;
        //        }
        //        decimal totalDueAmount = 0;
        //        foreach (DataGridViewRow row in dgvApplyamount.Rows)
        //        {
        //            if (row.Cells["AvailableBalance"] != null && decimal.TryParse(row.Cells["AvailableBalance"].Value?.ToString(), out decimal availableBalance))
        //            {
        //                totalDueAmount += availableBalance;
        //                if (totalPaidAmount >= availableBalance)
        //                {
        //                    row.Cells["AmtApplied"].Value = availableBalance;
        //                    row.Cells["SelectAll"].Value = true;
        //                    totalPaidAmount -= availableBalance;
        //                }
        //                else
        //                {
        //                    row.Cells["AmtApplied"].Value = totalPaidAmount;
        //                    row.Cells["SelectAll"].Value = false;
        //                    totalPaidAmount = 0;
        //                }
        //            }
        //        }
        //        if (totalPaidAmount > 0)
        //        {
        //            foreach (DataGridViewRow row in dgvApplyamount.Rows)
        //            {
        //                if (row.Cells["AmtApplied"].Value == null)
        //                {
        //                    row.Cells["AmtApplied"].Value = null;
        //                    row.Cells["SelectAll"].Value = false;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error in managing payment: " + ex.Message);
        //    }
        //}
        public void ManagePayment()
        {
            try
            {
                decimal totalPaidAmount = 0;
                bool isPaidAmtValid = decimal.TryParse(txtPaidAmt.Text, out totalPaidAmount);

                if (!isPaidAmtValid)
                {
                    foreach (DataGridViewRow row in dgvApplyamount.Rows)
                    {
                        row.Cells["AmtApplied"].Value = null;
                        row.Cells["SelectAll"].Value = false;
                    }
                    return;
                }

                decimal totalDueAmount = 0;
                foreach (DataGridViewRow row in dgvApplyamount.Rows)
                {
                    if (row.Cells["AvailableBalance"] != null && decimal.TryParse(row.Cells["AvailableBalance"].Value?.ToString(), out decimal availableBalance))
                    {
                        totalDueAmount += availableBalance;

                        if (totalPaidAmount >= availableBalance)
                        {
                            row.Cells["AmtApplied"].Value = availableBalance;
                            totalPaidAmount -= availableBalance;
                        }
                        else
                        {
                            row.Cells["AmtApplied"].Value = totalPaidAmount;
                            totalPaidAmount = 0;
                        }

                        // Check if AmtApplied has a value greater than 0
                        if (row.Cells["AmtApplied"]?.Value != null && decimal.TryParse(row.Cells["AmtApplied"].Value.ToString(), out decimal appliedAmount) && appliedAmount > 0)
                        {
                            row.Cells["SelectAll"].Value = true;
                        }
                        else
                        {
                            row.Cells["SelectAll"].Value = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in managing payment: " + ex.Message);
            }
        }
        private void dgvApplyamount_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == dgvApplyamount.Columns["AmtApplied"].Index && e.RowIndex > 0)
            //    {
            //        var amtAppliedValue = Convert.ToDecimal(dgvApplyamount.Rows[e.RowIndex].Cells["AmtApplied"].Value);
            //        var availableBalanceValue = Convert.ToDecimal(dgvApplyamount.Rows[e.RowIndex].Cells["AvailableBalance"].Value);
            //        if (amtAppliedValue == availableBalanceValue)
            //        {
            //            dgvApplyamount.Rows[e.RowIndex].Cells["SelectAll"].Value = true;
            //        }
            //        else if (amtAppliedValue > availableBalanceValue)
            //        {
            //            //MessageBox.Show("AmtApplied cannot be greater than AvailableBalance.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            dgvApplyamount.Rows[e.RowIndex].Cells["AmtApplied"].Value = availableBalanceValue;
            //        }
            //        else
            //        {
            //            dgvApplyamount.Rows[e.RowIndex].Cells["SelectAll"].Value = false;
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function:dgvApplyamount_CellValueChanged. Message:" + ex.Message);
            //    MessageBox.Show("Error: " + ex.Message);
            //}
        }
        private void FrmPaymentDetail_Load(object sender, EventArgs e)
        {
            Mode = "Insert";
            LoadCustomer();
            LoadMethod();
            Display();
            CreditMemoDetails();
            dgvInvoicePaymentList.ForeColor = Color.Black;
            btnApplyCreditCard.Visible = false;
            //txtRemainingAmt.Visible = false;
        }
        private void FrmPaymentDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            cmbCustomerName.Enabled = true;
            LoadCustomer();
            LoadRefnumber();
            //this.Close();
            ClsCommon.objPayment.Hide();
            ClsCommon.objPayment.Parent = null;
            //e.Cancel = true;
            ClsCommon.ObjCustomerCenter.LoadAllInvoices();
        }
        private void txtPaid_Leave(object sender, EventArgs e)
        {
            Calculation();
        }
        private void txtPaidAmt_Leave(object sender, EventArgs e)
        {
            try
            {
                //    if (Mode == "Insert")
                //    {
                //        decimal newPaidAmount = 0;
                //        if (decimal.TryParse(txtPaidAmt.Text, out decimal enteredAmount))
                //        {
                //            newPaidAmount = enteredAmount;
                //        }
                //        foreach (DataGridViewRow row in dgvApplyamount.Rows)
                //        {
                //            decimal oldBalance = 0;
                //            if (row.Cells["AvailableBalance"] != null && decimal.TryParse(row.Cells["AvailableBalance"].Value?.ToString(), out decimal availableBalance))
                //            {
                //                oldBalance = availableBalance;
                //            }
                //            bool isChecked = row.Cells["SelectAll"].Value != null && Convert.ToBoolean(row.Cells["SelectAll"].Value);
                //            if (isChecked)
                //            {
                //                if (newPaidAmount != oldBalance)
                //                {
                //                    row.Cells["SelectAll"].Value = false;
                //                    row.Cells["AmtApplied"].Value = null;
                //                }
                //                else
                //                {
                //                    row.Cells["SelectAll"].Value = true;
                //                    row.Cells["AmtApplied"].Value = oldBalance;
                //                }
                //            }
                //        }
                //        ManagePayment();
                //    }

                if (!string.IsNullOrWhiteSpace(txtPaidAmt.Text) && txtPaidAmt.Text != "0.00")
                {
                    IsPaymentManually = true;
                }
                else
                {
                    IsPaymentManually = false;
                }
                Calculation();
                txtRemainingAmt.Text = "";
                remainingAmount = 0;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function:txtPaidAmt_Leave. Message:" + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnApplyCredit_Click(object sender, EventArgs e)
        {
            //FrmApplyCreditToInvoice frmApplyCreditToInvoice = new FrmApplyCreditToInvoice();

            InID = Convert.ToInt32(dgvApplyamount.Rows[0].Cells["InvID"].Value);
            if (InID != 0)
            {
                ClsCommon.objApplyCreditToInvoice.InvoiceID = InID;
                ClsCommon.objApplyCreditToInvoice.LoadData(InID);
                ClsCommon.objApplyCreditToInvoice.Show();
            }
            else
            {
                MessageBox.Show("Please Select Refnumber First");
            }
        }
        private void tabMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void pnlEntry_Paint(object sender, PaintEventArgs e)
        {

        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void txtPaidAmt_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPaidAmt.Text) && txtPaidAmt.Text != "0.00")
            {
                IsPaymentManually = true;
            }
            else
            {
                IsPaymentManually = false;
            }
            Calculation();
            txtRemainingAmt.Text = "";
            remainingAmount = 0;

        }
        public void Calculation()
        {
            try
            {
                if (Mode == "Insert")
                {
                    decimal newPaidAmount = 0;
                    if (decimal.TryParse(txtPaidAmt.Text, out decimal enteredAmount))
                    {
                        newPaidAmount = enteredAmount;
                    }
                    foreach (DataGridViewRow row in dgvApplyamount.Rows)
                    {
                        decimal oldBalance = 0;
                        if (row.Cells["AvailableBalance"] != null && decimal.TryParse(row.Cells["AvailableBalance"].Value?.ToString(), out decimal availableBalance))
                        {
                            oldBalance = availableBalance;
                        }
                        bool isChecked = row.Cells["SelectAll"].Value != null && Convert.ToBoolean(row.Cells["SelectAll"].Value);
                        if (isChecked)
                        {
                            if (newPaidAmount != oldBalance)
                            {
                                row.Cells["SelectAll"].Value = false;
                                row.Cells["AmtApplied"].Value = null;
                            }
                            else
                            {
                                row.Cells["SelectAll"].Value = true;
                                row.Cells["AmtApplied"].Value = oldBalance;
                            }
                        }
                    }
                    ManagePayment();
                    decimal NowApplied = 0;

                    foreach (DataGridViewRow row in dgvApplyamount.Rows)
                    {

                        if (row.Cells["AmtApplied"] != null)
                        {
                            decimal AppliedBalance = 0;
                            if (row.Cells["AmtApplied"].ToString() != "")
                            {
                                AppliedBalance = Convert.ToDecimal(row.Cells["AmtApplied"].Value);
                            }
                            NowApplied += AppliedBalance;
                        }
                    }
                    lblPayAmt.Text = NowApplied.ToString("F2");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function:txtPaidAmt_Leave. Message:" + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void txtPaidAmt_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPaidAmt.Text) && txtPaidAmt.Text != "0.00")
            {
                IsPaymentManually = true;
            }
            else
            {
                IsPaymentManually = false;
            }
            Calculation();
            txtRemainingAmt.Text = "";
            remainingAmount = 0;

        }
        private void txtPaidAmt_DragLeave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPaidAmt.Text) && txtPaidAmt.Text != "0.00")
            {
                IsPaymentManually = true;
            }
            else
            {
                IsPaymentManually = false;
            }
            Calculation();
            txtRemainingAmt.Text = "";
            remainingAmount = 0;

        }
        private void txtPaidAmt_TextChanged(object sender, EventArgs e)
        {
            txtRemainingAmt.Text = "";
            remainingAmount = 0;
        }
        private void ManageInvoiceSelection(DataGridViewRow row, bool isChecked)
        {
            try
            {
                decimal dueBalance = Convert.ToDecimal(row.Cells["AvailableBalance"].Value);
                decimal appliedAmount = Convert.ToDecimal(row.Cells["AmtApplied"].Value);
                if (isChecked)
                {
                    if (remainingAmount > 0)
                    {
                        if (row.Cells["AmtApplied"].Value == null || Convert.ToDecimal(row.Cells["AmtApplied"].Value) == 0)
                        {
                            decimal newAppliedAmount = Math.Min(dueBalance, remainingAmount);
                            row.Cells["AmtApplied"].Value = newAppliedAmount;
                            remainingAmount -= newAppliedAmount;
                        }
                        else
                        {
                            appliedAmount = Convert.ToDecimal(row.Cells["AmtApplied"].Value);
                            remainingAmount += appliedAmount;
                            row.Cells["AmtApplied"].Value = 0;
                        }
                    }
                    else
                    {
                        appliedAmount = Convert.ToDecimal(row.Cells["AmtApplied"].Value);
                        remainingAmount += appliedAmount;
                        row.Cells["AmtApplied"].Value = 0;
                    }
                }
                else
                {
                    if (remainingAmount != 0)
                    {
                        decimal newAppliedAmount = Math.Min(dueBalance, remainingAmount);
                        row.Cells["AmtApplied"].Value = newAppliedAmount;
                        remainingAmount -= newAppliedAmount;
                    }
                    else
                    {
                        row.Cells["SelectAll"].Value = false;
                        MessageBox.Show("You Cannot Apply an greater than the total payment plus any existing credits.\nTip: to apply a discount or credit to an invoice,highlight the invoice by clicking on its date or number field");
                    }
                }
                txtRemainingAmt.Text = remainingAmount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void dgvApplyamount_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvApplyamount.Columns["AmtApplied"].Index)
            {
                DataGridViewRow row = dgvApplyamount.Rows[e.RowIndex];

                if (!decimal.TryParse(row.Cells["AmtApplied"].Value.ToString(), out decimal appliedAmount) || appliedAmount < 0)
                {
                    MessageBox.Show("Invalid amount entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    row.Cells["AmtApplied"].Value = 0;
                    return;
                }

                decimal dueBalance = Convert.ToDecimal(row.Cells["DueBalance"].Value);

                if (appliedAmount > dueBalance)
                {
                    MessageBox.Show("Amount exceeds due balance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["AmtApplied"].Value = dueBalance;
                    appliedAmount = dueBalance;
                }

                remainingAmount = Convert.ToDecimal(txtPaidAmt.Text) - dgvApplyamount.Rows.Cast<DataGridViewRow>()
                    .Sum(r => Convert.ToDecimal(r.Cells["AmtApplied"].Value));

                txtRemainingAmt.Text = remainingAmount.ToString();
            }
        }
        private void UpdateSelectedInvoicesTotal()
        {
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in dgvApplyamount.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["SelectAll"].Value);
                if (isChecked)
                {
                    decimal appliedAmount;
                    if (decimal.TryParse(row.Cells["AmtApplied"].Value?.ToString(), out appliedAmount))
                    {
                        totalAmount += appliedAmount;
                    }
                }
            }

            lblPayAmt.Text = totalAmount.ToString("N2");
        }
        private void dgvApplyamount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvApplyamount.Columns["SelectAll"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvApplyamount.Rows[e.RowIndex];
                    bool isChecked = Convert.ToBoolean(row.Cells["SelectAll"].Value);
                    row.Cells["SelectAll"].Value = !isChecked;

                    if (!IsPaymentManually)
                    {
                        if (!isChecked)
                        {
                            row.Cells["AmtApplied"].Value = row.Cells["AvailableBalance"].Value;
                        }
                        else
                        {
                            row.Cells["AmtApplied"].Value = string.Empty;
                        }
                        UpdateTotalAppliedAmount();
                    }
                    else
                    {
                        if (e.ColumnIndex == dgvApplyamount.Columns["SelectAll"].Index && e.RowIndex >= 0)
                        {
                            DataGridViewRow row1 = dgvApplyamount.Rows[e.RowIndex];
                            bool isChecked1 = Convert.ToBoolean(row.Cells["SelectAll"].EditedFormattedValue);
                            ManageInvoiceSelection(row, isChecked);
                        }
                    }
                    UpdateSelectedInvoicesTotal();
                }
                else
                {

                    ClsCommon.ObjInvoiceMaster.LoadTable();
                    ClsCommon.ObjInvoiceMaster.EditableField();
                    ClsCommon.TaxWithoutTax = "";
                    ClsCommon.ObjInvoiceMaster.Show();
                    ClsCommon.ObjInvoiceMaster.LoadData(dgvApplyamount.CurrentRow.Cells["InvID"].Value.ToString());
                    ClsCommon.ObjInvoiceMaster.AllowLowestPrice();
                    ClsCommon.ObjInvoiceMaster.CheckDate();

                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function:dgvApplyamount_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSaveAndNew_Click_1(object sender, EventArgs e)
        {
            lblErrorMsg1.Text = "";
            try
            {
                if (CheckValidation())
                {
                    if (cmbPayMethod.Text == "Credit")
                    {
                        foreach (DataGridViewRow row in dgvApplyamount.Rows)
                        {
                            int ID = Convert.ToInt32(row.Cells["InvID"].EditedFormattedValue);
                            decimal amtApplied = 0;
                            if (row.Cells["AmtApplied"].EditedFormattedValue.ToString() != "")
                            {
                                amtApplied = Convert.ToDecimal(row.Cells["AmtApplied"].EditedFormattedValue);
                            }
                            decimal AlreadyApplied = Convert.ToDecimal(row.Cells["AppliedBalance"].EditedFormattedValue);
                            decimal BalanceDue = Convert.ToDecimal(row.Cells["AvailableBalance"].EditedFormattedValue);

                            if (amtApplied != 0)
                            {
                                PayBOL.InvoiceID = Convert.ToInt32(ID);
                                PayBOL.PaymentMethodID = Convert.ToInt32(cmbPayMethod.SelectedValue);
                                PayBOL.CreditAmount = amtApplied;
                                PayBOL.PayAmount = null;
                                PayBOL.Date = DateTime.Now;
                                PayBOL.Reference = txtRef.Text;
                                PayBAL.Insert(PayBOL);
                            }
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow row in dgvApplyamount.Rows)
                        {
                            int ID = Convert.ToInt32(row.Cells["InvID"].EditedFormattedValue);
                            decimal amtApplied = 0;
                            if (row.Cells["AmtApplied"].EditedFormattedValue.ToString() != "")
                            {
                                amtApplied = Convert.ToDecimal(row.Cells["AmtApplied"].EditedFormattedValue);
                            }
                            decimal AlreadyApplied = Convert.ToDecimal(row.Cells["AppliedBalance"].EditedFormattedValue);
                            decimal BalanceDue = Convert.ToDecimal(row.Cells["AvailableBalance"].EditedFormattedValue);

                            if (amtApplied != 0)
                            {
                                objBOLInvoice.ID = ID;
                                if (BalanceDue == amtApplied)
                                {
                                    objBOLInvoice.PaidInvoice = 2;
                                    objBOLInvoice.AppliedAmount = AlreadyApplied + amtApplied;
                                    objBOLInvoice.BalanceDue = BalanceDue - amtApplied;
                                    objBALInvoice.UpdateInvoicePaidAmount(objBOLInvoice);
                                }
                                else if (BalanceDue > amtApplied)
                                {
                                    objBOLInvoice.PaidInvoice = 1;
                                    objBOLInvoice.AppliedAmount = AlreadyApplied + amtApplied;
                                    objBOLInvoice.BalanceDue = BalanceDue - amtApplied;
                                    objBALInvoice.UpdateInvoicePaidAmount(objBOLInvoice);
                                }
                                else if (BalanceDue < amtApplied)
                                {
                                    objBOLInvoice.PaidInvoice = 2;
                                    objBOLInvoice.AppliedAmount = AlreadyApplied + amtApplied;
                                    objBOLInvoice.BalanceDue = BalanceDue - amtApplied;
                                    objBALInvoice.UpdateInvoicePaidAmount(objBOLInvoice);
                                }
                                //}
                                PayBOL.InvoiceID = Convert.ToInt32(ID);
                                PayBOL.PaymentMethodID = Convert.ToInt32(cmbPayMethod.SelectedValue);
                                PayBOL.PayAmount = amtApplied;
                                PayBOL.CreditAmount = null;
                                PayBOL.Date = DateTime.Now;
                                //Hiren
                                PayBOL.Reference = txtRef.Text;
                                PayBAL.Insert(PayBOL);
                            }
                        }
                    }
                    //Display();
                    CreditMemoDetails();
                    ClearData();
                    //if (!string.IsNullOrEmpty(txtInvID.Text))
                    //{
                    //    loadData(Convert.ToInt32(txtInvID.Text));
                    //}

                    //LoadData(Convert.ToInt32(txtInvID.Text));
                    LoadInvGriedData();
                    if (!string.IsNullOrWhiteSpace(txtPaidAmt.Text) && txtPaidAmt.Text != "0.00")
                    {
                        IsPaymentManually = true;
                    }
                    else
                    {
                        IsPaymentManually = false;
                    }
                    cmbPayMethod.SelectedIndex = 0;
                    cmbCustomerName.SelectedIndex = 0;
                    cmbCustomerName.Enabled = true;
                    ClsCommon.ObjCustomerCenter.LoadAllInvoices();
                    ClsCommon.ObjCustomerCenter.LoadFunction();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentDetail,Function :btnSaveAndNew_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
