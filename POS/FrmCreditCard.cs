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
using DocumentFormat.OpenXml.Vml;
using TextBox = System.Windows.Forms.TextBox;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Drawing;
using System.Web.Services;
using Interop.QBFC13;
using System.Net;
using AuthorizeNet.Api.Controllers.Bases;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Contracts.V1;
using Microsoft.Office.Interop.Outlook;
using Application = System.Windows.Forms.Application;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Exception = System.Exception;
using AuthorizeNet.Util;
using Microsoft.Build.Utilities;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using System.Reflection.Emit;

namespace POS
{
    public partial class FrmCreditCard : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BOLCreditMemoPayment ObjBolCreditPayment = new BOLCreditMemoPayment();
        BALCreditMemoPayment ObjBalCreditPayment = new BALCreditMemoPayment();
        //FrmPaymentDetail frmPaymentDetail = new FrmPaymentDetail();

        BOLInvoiceMaster BOLInvoiceMaster = new BOLInvoiceMaster();
        BALInvoiceMaster BALInvoiceMaster = new BALInvoiceMaster();

        BOLCreditCardDetails BOLCreditCardDetails = new BOLCreditCardDetails();
        BALCreditCardDetails BALCreditCardDetails = new BALCreditCardDetails();

        BALPayment PayBAL = new BALPayment();
        BOLPayment PayBOL = new BOLPayment();

        DataTable dtGried = new DataTable();
        public int InvoiceID = 0;
        public static int CustomerID = 0;
        BALCreditMemo BALCreditMemo = new BALCreditMemo();
        BOLCreditMemo BOLCreditMemo = new BOLCreditMemo();
        public static int CardID = 0;
        decimal payamount = 0;
        string apiResponse = "";
        public static string TransctionID = "";
        public static string[] key = { "YzJsaWJHa3RjR2xyYVc1cA==", "Y21GcVlYSmhibU5vYUc5aw==", "VTJoeVpXVkxjbWx6YUc1aA==" };

        public FrmCreditCard()
        {
            InitializeComponent();
        }
        private void FrmApplyCreditToInvoice_Load(object sender, EventArgs e)
        {
            lblCreditUsed.Text = "0.00";
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
            txtPayamount.Text = "";
            payamount = 0;
            lblCreditUsed.Text = "0.00";
            dgvApplyCredit.Rows.Clear();
            dtGried = new BALCreditCardDetails().SelectByCustomerID(CustomerID);
            if (dtGried.Rows.Count > 0)
            {
                int iRow = 0;
                foreach (DataRow item in dtGried.Rows)
                {
                    dgvApplyCredit.Rows.Add();
                    dgvApplyCredit["ID", iRow].Value = item["ID"].ToString();
                    dgvApplyCredit["CreditCardNo", iRow].Value = item["CardNumber"].ToString();
                    iRow++;
                }
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (txtPayamount.Text != "")
            {
                for (int i = 0; i < dgvApplyCredit.Rows.Count; i++)
                {
                    if (dgvApplyCredit.Rows[i].Cells[1].Value != null)
                    {
                        if (dgvApplyCredit.Rows[i].Cells[1].Value.ToString() == "True")
                        {
                            CardID = Convert.ToInt32(dgvApplyCredit.Rows[i].Cells[0].Value);
                            break;
                        }
                    }
                    if (dgvApplyCredit.Rows.Count == 1)
                    {
                        CardID = Convert.ToInt32(dgvApplyCredit.Rows[i].Cells[0].Value);
                        break;
                    }
                }
                DataTable dtKeys = new BALAuthorizeKEY().Select();
                if (dtKeys.Rows.Count > 0 && CardID != 0)
                {

                    bool IsPaid=false;
                    //ANetApiResponse response = Run("4E82buxLXx", "89a2Q8BT2J4c7d92", Convert.ToDecimal(lblCreditUsed.Text), CardID, CustomerID, lblRefNumber.Text, InvoiceID);
                    ANetApiResponse response = ChargeCreditCard(dtKeys.Rows[0]["Login_ID"].ToString(), dtKeys.Rows[0]["Transaction_Key"].ToString(), Convert.ToDecimal(lblCreditUsed.Text), lblRefNumber.Text,ref IsPaid);

                    if (response != null)
                    {
                        if (response.messages.resultCode == messageTypeEnum.Ok && IsPaid == true)
                        {
                            
                                decimal TotalBalanceDue = 0;
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
                                    DataTable dtPaymethod = new BALPaymentMethod().SelectPaymentMethodType(new BOLPaymentMethod() { PaymentMethodType = "Credit Card" });
                                    if (dtPaymethod.Rows.Count > 0)
                                    {
                                        PayBOL.InvoiceID = Convert.ToInt32(InvoiceID);
                                        PayBOL.PaymentMethodID = Convert.ToInt32(dtPaymethod.Rows[0]["ID"].ToString());
                                        PayBOL.PayAmount = Convert.ToDecimal(lblCreditUsed.Text);
                                        PayBOL.CreditAmount = null;
                                        PayBOL.Date = DateTime.Now;
                                        PayBAL.Insert(PayBOL);
                                    }
                                    BOLCreditCardDetails.CreditID = CardID;
                                    BOLCreditCardDetails.RefNumber = lblRefNumber.Text;
                                    BOLCreditCardDetails.PayAmount = Convert.ToDecimal(lblCreditUsed.Text);
                                    BOLCreditCardDetails.Date = DateTime.Now;
                                    BOLCreditCardDetails.TransctionID = TransctionID;
                                    BALCreditCardDetails.CreditPayment(BOLCreditCardDetails);
                                    this.Close();

                                }
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Respopnse null");

                    }

                }
                else
                {
                    MessageBox.Show("select creditcard");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Amount");
                txtPayamount.Focus();

            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Calculated()
        {
            decimal BalanceDue = 0;
            if (txtPayamount.Text != "")
            {
                if (payamount != Convert.ToDecimal(txtPayamount.Text))
                {
                    BalanceDue = Convert.ToDecimal(lblRemainingCredit.Text);
                    lblRemainingCredit.Text = (Convert.ToDecimal(lblRemainingCredit.Text) + payamount).ToString();
                    BalanceDue = Convert.ToDecimal(lblRemainingCredit.Text);
                    payamount = Convert.ToDecimal(Math.Round(Convert.ToDecimal(txtPayamount.Text), 2).ToString("F2"));
                    if (payamount < BalanceDue)
                    {
                        lblRemainingCredit.Text = (Convert.ToDecimal(lblRemainingCredit.Text) - payamount).ToString();
                        lblCreditUsed.Text = payamount.ToString();
                    }
                    else if (payamount == BalanceDue)
                    {
                        lblRemainingCredit.Text = "0.00";
                        lblCreditUsed.Text = payamount.ToString();
                    }
                    else
                    {
                        lblCreditUsed.Text = "0.00";
                        payamount = 0;
                        txtPayamount.Text = "";
                        MessageBox.Show("Please check balance due");
                    }

                }
            }
            else if (payamount != 0)
            {
                lblRemainingCredit.Text = (Convert.ToDecimal(lblRemainingCredit.Text) + payamount).ToString();
                lblCreditUsed.Text = "0.00";
                payamount = 0;
            }
        }
        private void FrmApplyCreditToInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {

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
                foreach (DataGridViewRow row in dgvApplyCredit.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];

                    if (row.Index == dgvApplyCredit.CurrentRow.Index)
                    {
                        // Select the checkbox in the current row
                        chk.Value = true;
                    }
                    else
                    {
                        // Deselect the checkbox in all other rows
                        chk.Value = false;
                        //row.Cells[3].Value = "";
                    }
                }
            }
        }
     
        private void dgvApplyCredit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //// Suppress the default behavior (moving to the next row)
                //e.Handled = true;
                //e.SuppressKeyPress = true;

                //// Optionally, move to the next cell in the current row or perform another action
                //// Example: Move to the next cell
                //int columnIndex = dgvApplyCredit.CurrentCell.ColumnIndex;
                //int rowIndex = dgvApplyCredit.CurrentCell.RowIndex;
                //if (IsNext == false)
                //{
                //    if (columnIndex < dgvApplyCredit.Columns.Count - 1)
                //    {
                //        dgvApplyCredit.CurrentCell = dgvApplyCredit.Rows[rowIndex].Cells[columnIndex + 1];
                //    }

                //}
                //// Move to the next cell in the same row, if there is one

                ////else
                ////{
                ////    // Optionally, you could cycle back to the first cell in the row
                ////    dgvApplyCredit.CurrentCell = dgvApplyCredit.Rows[rowIndex].Cells[0];
                ////}
            }
        }
       
        public static ANetApiResponse ChargeCreditCard(string apiLoginID, string apiTransactionKey, decimal amount, string invoiceNumber,ref bool Payment)
        {
            //declare
            extendedAmountType shipping = null;
            string cardNumber = "";
            string expirationDate = "";
            string cardCode = "";
            string BillFirstName = "";
            string BillLastName = "";
            string BillAddress = "";
            string BillCity = "";
            string BillState = "";
            string BillZipCode = "";
            string BillCountry = "";
            string ShipFirstName = "";
            string ShipLastName = "";
            string ShipAddress = "";
            string ShipCity = "";
            string ShipState = "";
            string ShipZipCode = "";
            string ShipCountry = "";

            string CustomerNumber = "";
            DataTable dtcustomer = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = CustomerID });
            if(dtcustomer.Rows.Count>0)
            {
                CustomerNumber = dtcustomer.Rows[0]["CustomerNumber"].ToString();
            }
            DataTable dtShipAddress = new BALInvoiceMaster().SelectShipAddressByRefnumber(invoiceNumber);
            if(dtShipAddress.Rows.Count>0)
            {
                ShipFirstName = dtcustomer.Rows[0]["FirstName"].ToString();
                ShipLastName = dtcustomer.Rows[0]["LastName"].ToString();
                ShipAddress = dtShipAddress.Rows[0]["Address"].ToString();
                ShipCity = dtShipAddress.Rows[0]["City"].ToString();
                ShipState = dtShipAddress.Rows[0]["State"].ToString();
                ShipZipCode = dtShipAddress.Rows[0]["PostalCode"].ToString();
                ShipCountry = dtShipAddress.Rows[0]["Country"].ToString();
            }
            DataTable dtCardDetails = new BALCreditCardDetails().SelectByID(Convert.ToInt32(CardID));
            if (dtCardDetails.Rows.Count > 0)
            {
                cardNumber = dtCardDetails.Rows[0]["CardNumber"].ToString();
                expirationDate = Decrypt(dtCardDetails.Rows[0]["Year"].ToString()) + "-" + Decrypt(dtCardDetails.Rows[0]["Month"].ToString());
                cardCode = Decrypt(dtCardDetails.Rows[0]["CVV"].ToString());
                BillFirstName = dtCardDetails.Rows[0]["FirstName"].ToString();
                BillLastName = dtCardDetails.Rows[0]["LastName"].ToString();
                BillAddress = dtCardDetails.Rows[0]["Address"].ToString();
                BillCity = dtCardDetails.Rows[0]["City"].ToString();
                BillState = dtCardDetails.Rows[0]["State"].ToString();
                BillZipCode = dtCardDetails.Rows[0]["ZipCode"].ToString();
                BillCountry = dtCardDetails.Rows[0]["Country"].ToString();
            }
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //sandbox PRODUCTION
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.PRODUCTION;

            //Keys
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = apiLoginID,
                ItemElementName = ItemChoiceType.transactionKey,
                Item = apiTransactionKey,
            };
            ClsCommon.WriteErrorLogs("apiLoginID " + apiLoginID + " ,apiTransactionKey " + apiTransactionKey);

            var creditCard = new creditCardType
            {
                cardNumber = cardNumber,
                expirationDate = expirationDate, // Format: YYYY-MM
                cardCode = cardCode
            };
            ClsCommon.WriteErrorLogs(" creditCard.cardCode " + creditCard.cardCode + " creditCard.cardNumber " + creditCard.cardNumber + " creditCard.expirationDate " + creditCard.expirationDate);


            var paymentType = new paymentType
            {
                Item = creditCard
            };

            //Order and Customer Number
            var order = new orderType
            {
                invoiceNumber = invoiceNumber,
                description = CustomerNumber // Replace with your actual customer number
            };

            //Shipping
            DataTable dtshipping = new BALUPS_FedExHistory().SelectByRefNo(invoiceNumber.ToString());
            if (dtshipping.Rows.Count > 0)
            {
                shipping = new extendedAmountType
                {
                    amount = Convert.ToDecimal(dtshipping.Rows[0]["TotalCost"]), // Replace with actual shipping amount
                    name = dtshipping.Rows[0]["Service"].ToString(), // Optional: Provide a name for the charge
                    description = "Shipping Charge" // Optional: Provide a description for the charge
                };
            }
            //billaddress
            var billingAddress = new customerAddressType
            {
                firstName = BillFirstName,
                lastName = BillLastName,
                address = BillAddress,
                state = BillState,
                city = BillCity,
                zip = BillZipCode,
                country = BillCountry,
            };

            var ShippingAddress = new customerAddressType
            {
                firstName = ShipFirstName,
                lastName = ShipLastName,
                address = ShipAddress,
                state = ShipState,
                city = ShipCity,
                zip = ShipZipCode,
                country = ShipCountry,
            };

            var transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(), // Charge the card immediately
                payment = paymentType,
                amount = amount,
                order = order,
                billTo = billingAddress,
                shipTo = ShippingAddress,
                shipping = shipping,
            };
            var request = new createTransactionRequest
            {
                transactionRequest = transactionRequest
            };
            var controller = new createTransactionController(request);
            controller.Execute();
            var response = controller.GetApiResponse();
            if (response != null)
            {
                if (response.messages.resultCode == messageTypeEnum.Ok)
                {
                    if (response.transactionResponse != null && response.transactionResponse.messages != null)
                    {
                        Payment = true;
                        MessageBox.Show("Successfully created transaction with Transaction ID: " + response.transactionResponse.transId);
                        ClsCommon.WriteErrorLogs("Successfully created transaction with Transaction ID: " + response.transactionResponse.transId);
                        ClsCommon.WriteErrorLogs("Response Code: " + response.transactionResponse.responseCode);
                        ClsCommon.WriteErrorLogs("Message Code: " + response.transactionResponse.messages[0].code);
                        ClsCommon.WriteErrorLogs("Description: " + response.transactionResponse.messages[0].description);
                        ClsCommon.WriteErrorLogs("Auth Code: " + response.transactionResponse.authCode);
                    }
                    else
                    {
                        if (response.transactionResponse.errors != null)
                        {
                            MessageBox.Show("Error message: " + response.transactionResponse.errors[0].errorText);
                            ClsCommon.WriteErrorLogs("Failed Transaction.");
                            ClsCommon.WriteErrorLogs("Error Code: " + response.transactionResponse.errors[0].errorCode);
                            ClsCommon.WriteErrorLogs("Error message: " + response.transactionResponse.errors[0].errorText);
                        }
                    }
                }
                else
                {
                    ClsCommon.WriteErrorLogs("Failed Transaction.");
                    if (response.transactionResponse != null && response.transactionResponse.errors != null)
                    {
                        MessageBox.Show("Error message: " + response.transactionResponse.errors[0].errorText);
                        ClsCommon.WriteErrorLogs("Error Code: " + response.transactionResponse.errors[0].errorCode);
                        ClsCommon.WriteErrorLogs("Error message: " + response.transactionResponse.errors[0].errorText);
                    }
                    else
                    {
                        MessageBox.Show("Error message: " + response.messages.message[0].text);
                        ClsCommon.WriteErrorLogs("Error Code: " + response.messages.message[0].code);
                        ClsCommon.WriteErrorLogs("Error message: " + response.messages.message[0].text);
                    }
                }
            }
            else
            {
                MessageBox.Show("Null Response.");

                ClsCommon.WriteErrorLogs("Null Response.");
            }
            return response;
        }
        public static string Decrypt(string encryptedText)
        {
            try
            {
                for (int i = key.Length - 1; i >= 0; i--)
                {
                    byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                    using (Aes aesAlg = Aes.Create())
                    {
                        aesAlg.Key = Encoding.UTF8.GetBytes(DecodeFrom64(key[i]).PadRight(32));
                        aesAlg.IV = new byte[16]; // Assuming initialization vector is not included in the encrypted text and is all zeros
                        aesAlg.Mode = CipherMode.CBC; // Using Cipher Block Chaining (CBC) mode
                        aesAlg.Padding = PaddingMode.PKCS7; // Using PKCS7 padding
                        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                        byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                        encryptedText = Encoding.UTF8.GetString(decryptedBytes).Trim('"');
                    }
                }
                return encryptedText;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public static string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new System.String(decoded_char);
            return result;
        }
        private void txtPayamount_KeyPress(object sender, KeyPressEventArgs e)
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
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Calculated();

        }
        private void txtPayamount_Leave(object sender, EventArgs e)
        {
            Calculated();
        }



    }
}
