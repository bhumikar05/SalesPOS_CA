using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ClosedXML.Excel;
using ComponentFactory.Krypton.Toolkit;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;

namespace POS
{

    public partial class FrmPaymentAll : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        static Boolean IsAuthorizeExcel = false;
        static Boolean IsAuthorize = false;
        static Boolean IsPayPALExcel = false;
        static Boolean IsPayPAL = false;
        static Boolean IsZelleExcel = false;
        static Boolean IsZelle = false;
        static Boolean IsCashAppExcel = false;
        static Boolean IsCashApp = false;
        static DataTable dt = new DataTable(); Thread oThread;
        //static DataTable dtData = new DataTable(); static string apiResponse = "";
        //static NameValueCollection retData = new NameValueCollection(); 
        //static BALPaypalConfig objConfig = new BALPaypalConfig(); 
        //static BALAuthorizeKEY BALAuthorizeKEY = new BALAuthorizeKEY();
        //static BOLAuthorizeDate BOLAuthorizeDate = new BOLAuthorizeDate();

        static BALPayment BALPAYMENT = new BALPayment();
        static BOLPayment BOLPayment = new BOLPayment();

        static BALInvoiceMaster objBALInvoice = new BALInvoiceMaster();
        static BOLInvoiceMaster objBOLInvoice = new BOLInvoiceMaster();

        static BALAuthorizePayment BALAuthorizePayment = new BALAuthorizePayment();
        static BOLAuthorizePayment BOLAuthorizePayment = new BOLAuthorizePayment();

        static BOLPayPalMaster BOLPayPalMaster = new BOLPayPalMaster();
        static BALPaypalMaster BALPaypalMaster = new BALPaypalMaster();

        static BALZelleMaster BALZelleMaster = new BALZelleMaster();
        static BOLZelleMaster BOLZelleMaster = new BOLZelleMaster();

        static BALCashAppMaster BALCashAppMaster = new BALCashAppMaster();
        static BOLCashAppMaster BOLCashAppMaster = new BOLCashAppMaster();

        public FrmPaymentAll()
        {
            InitializeComponent();
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                string FilePath = "";
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FilePath = openFileDialog1.FileName;
                    txtFilePath.Text = FilePath;
                    oThread = new Thread(new ThreadStart(StartProcess));
                    CheckForIllegalCrossThreadCalls = false;
                    oThread.Start();
                }
               
                
            }
            catch (Exception ex)
            {
                ClsCommon.WritePaymentErrorLogs("Class:FrmPaymentAll,Function :btnImport_Click. Message:" + ex.Message);
                DisplayMessage("Class:FrmPaymentAll,Function :btnImport_Click. Message:" + ex.Message, "E");
            }
        }
        public void StartProcess()
        {
            try
            {
                lblErrorMsg.Text = "";
                DataTable dt = new DataTable();
                if (txtFilePath.Text != "")
                {
                    ClsCommon.WritePaymentErrorLogs("---------------------------------------------------------------------------------------------------------------");
                    ClsCommon.WritePaymentErrorLogs("*****************************Authorize.Net Start*****************************");
                    ClsCommon.WritePaymentErrorLogs("Authorize.Net From Authorize To DB");
                    DisplayMessage("Authorize.Net From Authorize To DB", "I");
                    AuthorizeExcelRead();
                    ClsCommon.WritePaymentErrorLogs("Authorize.Net Succesfully From Authorize To DB");
                    DisplayMessage("Authorize.Net Succesfully From Authorize To DB", "I");
                    ClsCommon.WritePaymentErrorLogs("-------------------------------------------------------------------------------");
                    ClsCommon.WritePaymentErrorLogs("Authorize.Net Payment From Authorize");
                    DisplayMessage("Authorize.Net Payment From Authorize", "I");
                    AuthorizeInvoicePayment();
                    ClsCommon.WritePaymentErrorLogs("Authorize.Net Payment Succesfully From Authorize");
                    DisplayMessage("Authorize.Net Payment Succesfully From Authorize", "I");
                    ClsCommon.WritePaymentErrorLogs("*****************************Authorize.Net End*****************************");
                    ClsCommon.WritePaymentErrorLogs("-------------------------------------------------------------------------------");
                    ClsCommon.WritePaymentErrorLogs("*****************************PayPal Start*****************************");
                    ClsCommon.WritePaymentErrorLogs("PayPal From PayPal To DB");
                    DisplayMessage("PayPal From PayPal To DB", "I");
                    PayPalExcelRead();
                    DisplayMessage("PayPal Succesfully From PayPal To DB", "I");
                    ClsCommon.WritePaymentErrorLogs("PayPal Succesfully From PayPal To DB");
                    ClsCommon.WritePaymentErrorLogs("-------------------------------------------------------------------------------");
                    ClsCommon.WritePaymentErrorLogs("PayPal Payment From PayPal");
                    DisplayMessage("PayPal Payment From PayPall", "I");
                    PayPalInvoicePayment();
                    DisplayMessage("PayPal Payment Succesfully From PayPal", "I");
                    ClsCommon.WritePaymentErrorLogs("PayPal Payment Succesfully From PayPal");
                    ClsCommon.WritePaymentErrorLogs("*****************************PayPal End*****************************");
                    ClsCommon.WritePaymentErrorLogs("-------------------------------------------------------------------------------");
                    ClsCommon.WritePaymentErrorLogs("*****************************Zelle Start*****************************");
                    ClsCommon.WritePaymentErrorLogs("Zelle From Zelle To DB");
                    DisplayMessage("Zelle From Zelle To DB", "I");
                    ZelleExcelRead();
                    DisplayMessage("Zelle Succesfully From Zelle To DB", "I");
                    ClsCommon.WritePaymentErrorLogs("Zelle Succesfully From Zelle To DB");
                    ClsCommon.WritePaymentErrorLogs("-------------------------------------------------------------------------------");
                    ClsCommon.WritePaymentErrorLogs("Zelle Payment From Zelle");
                    DisplayMessage("Zelle Payment From Zelle", "I");
                    ZelleInvoicePayment();
                    DisplayMessage("Zelle Payment Succesfully From Zelle", "I");
                    ClsCommon.WritePaymentErrorLogs("Zelle Payment Succesfully From Zelle");
                    ClsCommon.WritePaymentErrorLogs("*****************************Zelle End*****************************");
                    ClsCommon.WritePaymentErrorLogs("-------------------------------------------------------------------------------");
                    ClsCommon.WritePaymentErrorLogs("*****************************CashApp Start*****************************");
                    DisplayMessage("CashApp From CashApp To DB", "I");
                    ClsCommon.WritePaymentErrorLogs("CashApp From CashApp To DB");
                    CashAppExcelRead();
                    DisplayMessage("CashApp Succesfully From CashApp To DB", "I");
                    ClsCommon.WritePaymentErrorLogs("CashApp Succesfully From CashApp To DB");
                    ClsCommon.WritePaymentErrorLogs("-------------------------------------------------------------------------------");
                    ClsCommon.WritePaymentErrorLogs("CashApp Payment From CashApp");
                    DisplayMessage("CashApp Payment From CashApp", "I");
                    CashAppInvoicePayment();
                    DisplayMessage("CashApp Payment Succesfully From CashApp", "I");
                    ClsCommon.WritePaymentErrorLogs("CashApp Payment Succesfully From CashApp");
                    ClsCommon.WritePaymentErrorLogs("*****************************CashApp End*****************************");
                    MoveExcel(txtFilePath.Text.ToString());
                    ClsCommon.WritePaymentErrorLogs("---------------------------------------------------------------------------------------------------------------");
                }
                else
                {
                    DisplayMessage("File Path is Blank", "E");
                }
            }
            catch(Exception EX)
            {
                DisplayMessage("Class:FrmPaymentAll,FucationName:StartProcess, Message:" + EX.Message + "", "E");
                ClsCommon.WritePaymentErrorLogs("Class:FrmPaymentAll,FucationName:StartProcess, Message:" + EX.Message + "");
            }
        }

        public  Boolean Validations()
        {
            Boolean isvalid = false;
            try
            {
          
                if (IsAuthorize == false)
                {
                    isvalid = false;
                    //Console.WriteLine("Authorize in Payment Issue");
                    ClsCommon.WritePaymentErrorLogs("Authorize in Payment Issue");
                    DisplayMessage("Authorize in Payment Issue", "E");
                }
                else if (IsAuthorizeExcel == false)
                {
                    isvalid = false;
                    //Console.WriteLine("Authorize in Excel Issue");
                    ClsCommon.WritePaymentErrorLogs("Authorize in Excel Issue");
                    DisplayMessage("Authorize in Excel Issue", "E");
                }
                else if (IsPayPALExcel == false)
                {
                    isvalid = false;
                    //Console.WriteLine("Paypal In Excel Issue");
                    ClsCommon.WritePaymentErrorLogs("Paypal In Excel Issue");
                    DisplayMessage("Paypal In Excel Issue", "E");
                }
                else if (IsPayPAL == false)
                {
                    isvalid = false;
                    //Console.WriteLine("Paypal In Payment Issue");
                    ClsCommon.WritePaymentErrorLogs("Paypal In Payment Issue");
                    DisplayMessage("Paypal In Payment Issue", "E");
                }
                else if (IsZelleExcel == false)
                {
                    isvalid = false;
                    //Console.WriteLine("Zelle In Excel Issue");
                    ClsCommon.WritePaymentErrorLogs("Zelle In Excel Issue");
                    DisplayMessage("Zelle In Excel Issue", "E");
                }
                else if (IsZelle == false)
                {
                    isvalid = false;
                    //Console.WriteLine("Zelle In Payment Issue");
                    ClsCommon.WritePaymentErrorLogs("Zelle In Payment Issue");
                    DisplayMessage("Zelle In Payment Issue", "E");
                }
                else if (IsCashAppExcel == false)
                {
                    isvalid = false;
                    //Console.WriteLine("CashApp In Excel Issue");
                    ClsCommon.WritePaymentErrorLogs("CashApp In Excel Issue");
                    DisplayMessage("CashApp In Excel Issue", "E");
                }
                else if (IsCashApp == false)
                {
                    isvalid = false;
                    //Console.WriteLine("CashApp In Payment Issue");
                    ClsCommon.WritePaymentErrorLogs("CashApp In Payment Issue");
                    DisplayMessage("CashApp In Payment Issue", "E");
                }
                else
                {
                    isvalid = true;
                }
            }     
           
            catch (Exception ex)
            {
                DisplayMessage("Class:FrmPaymentAll,FucationName:Validations, Message:" + ex.Message + "", "E");
                ClsCommon.WritePaymentErrorLogs("Class:FrmPaymentAll,FucationName:Validations, Message:" + ex.Message + "");
            }
            return isvalid;
        }
        public void AuthorizeExcelRead()
        {
            try
            {
                ClsCommon.dtAuthorizePayment = new DataTable();
                dt = new DataTable();
                using (XLWorkbook workbook = new XLWorkbook(txtFilePath.Text.ToString()))
                {
                    IXLWorksheet worksheet = workbook.Worksheet(1);
                    bool FirstRow = true;
                    string readRange = "1:1";

                    foreach (IXLRow row in worksheet.RowsUsed())
                    {
                        if (FirstRow)
                        {
                            readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                            //readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                            foreach (IXLCell cell in row.Cells(readRange))
                            {
                                dt.Columns.Add(cell.Value.ToString());
                            }
                            if (readRange == "1:1")
                            {
                                dt.Columns.RemoveAt(0);
                                FirstRow = true;
                            }
                            else
                            {
                                FirstRow = false;
                            }
                        }
                        else
                        {
                            dt.Rows.Add();
                            int cellIndex = 0;
                            foreach (IXLCell cell in row.Cells(readRange))
                            {
                                dt.Rows[dt.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                cellIndex++;
                            }
                        }
                    }
                    ClsCommon.dtAuthorizePayment.Merge(dt);

                    foreach (DataRow DR in ClsCommon.dtAuthorizePayment.Rows)
                    {
                        DataTable dtTransactionID = new BALAuthorizePayment().SelectTransIDDublicateCheck(new BOLAuthorizePayment() { transId = DR["Trans ID"].ToString() });
                        if (dtTransactionID.Rows.Count == 0)
                        {
                            BOLAuthorizePayment.transId = DR["Trans ID"].ToString();
                            BOLAuthorizePayment.invoiceNumber = DR["Invoice Number"].ToString();
                            string[] Name = DR["Customer"].ToString().Split(',');

                            BOLAuthorizePayment.firstName = Name[0].ToString();
                            BOLAuthorizePayment.lastName = Name[1].ToString();
                            BOLAuthorizePayment.accountType = DR["Card"].ToString();
                            string[] Amount = DR["Payment Amount"].ToString().Split(' ');

                            BOLAuthorizePayment.settleAmount = Convert.ToDecimal(Amount[1].ToString());
                            BOLAuthorizePayment.submitTimeUTC = Convert.ToDateTime(DR["Submit Date"].ToString());
                            BOLAuthorizePayment.transactionStatus = DR["Trans Status"].ToString();
                            BOLAuthorizePayment.IsUpdate = 0;
                            BALAuthorizePayment.Insert(BOLAuthorizePayment);
                            //Console.WriteLine("Authorize Insert Successfully,CustomerName:" + Name[0].ToString() + "" + Name[1].ToString() + "");
                            ClsCommon.WritePaymentErrorLogs("Authorize Insert Successfully,CustomerName:" + Name[0].ToString() + "" + Name[1].ToString() + "");
                            DisplayMessage("Authorize Insert Successfully,CustomerName:" + Name[0].ToString() + "" + Name[1].ToString() + "", "I");
                        }
                        else
                        {
                            BOLAuthorizePayment.ID = Convert.ToInt32(dtTransactionID.Rows[0]["ID"]);
                            BOLAuthorizePayment.transId = DR["Trans ID"].ToString();
                            BOLAuthorizePayment.invoiceNumber = DR["Invoice Number"].ToString();
                            string[] Name = DR["Customer"].ToString().Split(',');

                            BOLAuthorizePayment.firstName = Name[0].ToString();
                            BOLAuthorizePayment.lastName = Name[1].ToString();
                            BOLAuthorizePayment.accountType = DR["Card"].ToString();
                            string[] Amount = DR["Payment Amount"].ToString().Split(' ');

                            BOLAuthorizePayment.settleAmount = Convert.ToDecimal(Amount[1].ToString());
                            BOLAuthorizePayment.submitTimeUTC = Convert.ToDateTime(DR["Submit Date"].ToString());
                            BOLAuthorizePayment.transactionStatus = DR["Trans Status"].ToString();
                            BALAuthorizePayment.Update(BOLAuthorizePayment);
                            //Console.WriteLine("Authorize Update Successfully,CustomerName:" + Name[0].ToString() + "" + Name[1].ToString() + "");
                            ClsCommon.WritePaymentErrorLogs("Authorize Update Successfully,CustomerName:" + Name[0].ToString() + "" + Name[1].ToString() + "");
                            DisplayMessage("Authorize Update Successfully,CustomerName:" + Name[0].ToString() + "" + Name[1].ToString() + "", "I");
                        }
                    }
                }
                IsAuthorizeExcel = true;
            }
            catch (Exception EX)
            {
                ClsCommon.WritePaymentErrorLogs("Class:FrmPaymentAll,FucationName:AuthorizeExcelRead, Message:" + EX.Message + "");
                DisplayMessage("Class:FrmPaymentAll,FucationName:AuthorizeExcelRead, Message:" + EX.Message + "", "E");
            }
        }
        public void AuthorizeInvoicePayment()
        {
            try
            {
                DisplayMessage("Try To AuthorizeInvoicePayment", "I");
                //Console.WriteLine("Try To AuthorizeInvoicePayment");
                ClsCommon.WritePaymentErrorLogs("Try To AuthorizeInvoicePayment");
                DataTable dtPayment = new DataTable();
                dtPayment = new BALAuthorizePayment().Select();
                if (dtPayment.Rows.Count > 0)
                {
                    for (int i = 0; i < dtPayment.Rows.Count; i++)
                    {
                        if (dtPayment.Rows[i]["invoiceNumber"].ToString() != "")
                        {
                            DataTable dtinvoiceNO = new DataTable();
                            dtinvoiceNO = new BALInvoiceMaster().SelectRefNumber(new BOLInvoiceMaster() { RefNumber = dtPayment.Rows[i]["invoiceNumber"].ToString() });
                            if (dtinvoiceNO.Rows.Count > 0)
                            {
                                BOLPayment.InvoiceID = Convert.ToInt32(dtinvoiceNO.Rows[0]["ID"]);
                                DataTable dtPaymentMethod = new DataTable();
                                dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = dtPayment.Rows[i]["accountType"].ToString() });
                                if (dtPaymentMethod.Rows.Count > 0)
                                {
                                    if (dtPaymentMethod.Rows[0]["IsActive"].ToString() == "0")
                                    {
                                        dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                        if (dtPaymentMethod.Rows.Count > 0)
                                        {
                                            BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                        }
                                    }
                                    else
                                    {
                                        BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                    }
                                }
                                else
                                {
                                    dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                    if (dtPaymentMethod.Rows.Count > 0)
                                    {
                                        BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                    }
                                }
                                if (Convert.ToDecimal(dtinvoiceNO.Rows[0]["BalanceDue"].ToString()) < Convert.ToDecimal(dtPayment.Rows[i]["settleAmount"]))
                                {
                                    BOLPayment.PayAmount = Convert.ToDecimal(dtinvoiceNO.Rows[0]["BalanceDue"]);
                                }
                                else
                                {
                                    BOLPayment.PayAmount = Convert.ToDecimal(dtPayment.Rows[i]["settleAmount"]);
                                }
                                BOLPayment.Date = DateTime.Now;
                                BOLPayment.TransactionID = dtPayment.Rows[i]["transId"].ToString();
                                BOLPayment.CreditAmount = null;
                                BOLPayment.IsQBSync = 0;
                                BALPAYMENT.Insert(BOLPayment);

                                int ID = Convert.ToInt32(dtPayment.Rows[i]["ID"].ToString());
                                BOLAuthorizePayment.ID = ID;
                                if (Convert.ToDecimal(dtinvoiceNO.Rows[0]["BalanceDue"].ToString()) < Convert.ToDecimal(dtPayment.Rows[i]["settleAmount"]))
                                {
                                    BOLAuthorizePayment.settleAmount = Convert.ToDecimal(dtPayment.Rows[i]["settleAmount"]) - Convert.ToDecimal(dtinvoiceNO.Rows[0]["BalanceDue"].ToString());
                                    BOLAuthorizePayment.IsUpdate = 0;
                                }
                                else
                                {
                                    BOLAuthorizePayment.settleAmount = Convert.ToDecimal(dtPayment.Rows[i]["settleAmount"]);
                                    BOLAuthorizePayment.IsUpdate = 1;
                                }
                                BALAuthorizePayment.IsUpdate(BOLAuthorizePayment);


                                if (Convert.ToDecimal(dtinvoiceNO.Rows[0]["BalanceDue"].ToString()) == Convert.ToDecimal(dtPayment.Rows[i]["settleAmount"]))
                                {
                                    objBOLInvoice.ID = Convert.ToInt32(dtinvoiceNO.Rows[0]["ID"]);
                                    objBOLInvoice.PaidInvoice = 2;
                                    objBOLInvoice.AppliedAmount = (Convert.ToDecimal(dtinvoiceNO.Rows[0]["AppliedAmount"].ToString()) + Convert.ToDecimal(dtPayment.Rows[i]["settleAmount"]));
                                    objBOLInvoice.BalanceDue = (Convert.ToDecimal(dtinvoiceNO.Rows[0]["BalanceDue"].ToString()) - Convert.ToDecimal(dtPayment.Rows[i]["settleAmount"]));
                                    objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                                    //Console.WriteLine("Authorize Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[0]["RefNumber"].ToString() + "");
                                    ClsCommon.WritePaymentErrorLogs("Authorize Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[0]["RefNumber"].ToString() + "");
                                    DisplayMessage("Authorize Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[0]["RefNumber"].ToString() + "", "I");
                                }
                                else if (Convert.ToDecimal(dtinvoiceNO.Rows[0]["BalanceDue"]) > Convert.ToDecimal(dtPayment.Rows[i]["settleAmount"]))
                                {
                                    objBOLInvoice.ID = Convert.ToInt32(dtinvoiceNO.Rows[0]["ID"]);
                                    objBOLInvoice.PaidInvoice = 1;
                                    objBOLInvoice.AppliedAmount = (Convert.ToDecimal(dtinvoiceNO.Rows[0]["AppliedAmount"].ToString()) + Convert.ToDecimal(dtPayment.Rows[i]["settleAmount"]));
                                    objBOLInvoice.BalanceDue = (Convert.ToDecimal(dtinvoiceNO.Rows[0]["BalanceDue"]) - Convert.ToDecimal(dtPayment.Rows[i]["settleAmount"]));
                                    objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                                    //Console.WriteLine("Authorize Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[0]["RefNumber"].ToString() + "");
                                    ClsCommon.WritePaymentErrorLogs("Authorize Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[0]["RefNumber"].ToString() + "");
                                    DisplayMessage("Authorize Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[0]["RefNumber"].ToString() + "", "I");
                                }
                                else if (Convert.ToDecimal(dtinvoiceNO.Rows[0]["BalanceDue"].ToString()) < Convert.ToDecimal(dtPayment.Rows[i]["settleAmount"]))
                                {
                                    objBOLInvoice.ID = Convert.ToInt32(dtinvoiceNO.Rows[0]["ID"]);
                                    objBOLInvoice.PaidInvoice = 2;
                                    objBOLInvoice.AppliedAmount = (Convert.ToDecimal(dtinvoiceNO.Rows[0]["AppliedAmount"].ToString()) + Convert.ToDecimal(dtinvoiceNO.Rows[0]["BalanceDue"]));
                                    objBOLInvoice.BalanceDue = Convert.ToDecimal(0.00);
                                    objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                                    //Console.WriteLine("Authorize Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[0]["RefNumber"].ToString() + "");
                                    ClsCommon.WritePaymentErrorLogs("Authorize Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[0]["RefNumber"].ToString() + "");
                                    DisplayMessage("Authorize Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[0]["RefNumber"].ToString() + "", "I");
                                }
                            }
                            else
                            {
                                //Console.WriteLine("No InvoiceNo Found:" + dtPayment.Rows[i]["invoiceNumber"].ToString() + "");
                                ClsCommon.WritePaymentErrorLogs("No InvoiceNo Found:" + dtPayment.Rows[i]["invoiceNumber"].ToString() + "");
                                DisplayMessage("No InvoiceNo Found:" + dtPayment.Rows[i]["invoiceNumber"].ToString() + "", "I");
                            }
                        }
                        else
                        {
                            //Console.WriteLine("Authorize:-invoiceNumber is Blank");
                            ClsCommon.WritePaymentErrorLogs("Authorize:-invoiceNumber is Blank");
                            DisplayMessage("Authorize:-invoiceNumber is Blank", "I");
                        }

                    }
                }
                else
                {
                    //Console.WriteLine("Authorize Invoice Payment No Found");
                    ClsCommon.WritePaymentErrorLogs("Authorize Invoice Payment No Found");
                    DisplayMessage("Authorize Invoice Payment No Found", "I");
                }
                IsAuthorize = true;
            }
            catch (Exception EX)
            {
                //Console.WriteLine("Class:AuthorizeToDB,FucationName:AuthorizeInvoicePayment, Message:" + EX.Message, "E");
                ClsCommon.WritePaymentErrorLogs("Class:FrmPaymentAll,FucationName:AuthorizeInvoicePayment, Message:" + EX.Message + "");
                DisplayMessage("Class:FrmPaymentAll,FucationName:AuthorizeInvoicePayment, Message:" + EX.Message + "", "I");
            }
        }
        public void PayPalExcelRead()
        {
            try
            {
                dt = new DataTable();
                ClsCommon.dtPayPalPayment = new DataTable();

                using (XLWorkbook workbook = new XLWorkbook(txtFilePath.Text.ToString()))
                {
                    IXLWorksheet worksheet = workbook.Worksheet(2);
                    bool FirstRow = true;
                    string readRange = "1:1";
                    foreach (IXLRow row in worksheet.RowsUsed())
                    {
                        if (FirstRow)
                        {
                            readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                            foreach (IXLCell cell in row.Cells(readRange))
                            {
                                dt.Columns.Add(cell.Value.ToString());
                            }
                            FirstRow = false;
                        }
                        else
                        {
                            dt.Rows.Add();
                            int cellIndex = 0;
                            foreach (IXLCell cell in row.Cells(readRange))
                            {
                                dt.Rows[dt.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                cellIndex++;
                            }
                        }
                    }
                    ClsCommon.dtPayPalPayment.Merge(dt);
                    if (ClsCommon.dtPayPalPayment.Rows.Count > 0)
                    {
                        for (int i = 0; i < ClsCommon.dtPayPalPayment.Rows.Count; i++)
                        {

                            BOLPayPalMaster.transaction_updated_date = DateTime.Now.ToString();
                            string[] Gross = ClsCommon.dtPayPalPayment.Rows[i]["Gross"].ToString().Split('$');
                            var rx = new Regex(@"\s+", RegexOptions.Compiled);
                            var data = rx.Split(Gross[1].ToString());
                            BOLPayPalMaster.transaction_amount = Convert.ToDecimal(data[0]);
                            BOLPayPalMaster.currency_code = data[1];
                            BOLPayPalMaster.payer_name = ClsCommon.dtPayPalPayment.Rows[i]["Name"].ToString();
                            BOLPayPalMaster.Transaction_Balance = Convert.ToDecimal(data[0]);
                            BALPaypalMaster.Insert(BOLPayPalMaster);
                            //Console.WriteLine("PayPal Insert Successfully,PayerName:" + ClsCommon.dtPayPalPayment.Rows[i]["Name"].ToString() + "");
                            ClsCommon.WritePaymentErrorLogs("PayPal Insert Successfully,PayerName:" + ClsCommon.dtPayPalPayment.Rows[i]["Name"].ToString() + "");
                            DisplayMessage("PayPal Insert Successfully,PayerName:" + ClsCommon.dtPayPalPayment.Rows[i]["Name"].ToString() + "", "I");
                        }
                    }
                }
                IsPayPALExcel = true;
            }
            catch (Exception EX)
            {
                //Console.WriteLine("Class:AuthorizeToDB,FucationName:PayPalExcelRead, Message:" + EX.Message, "E");
                ClsCommon.WritePaymentErrorLogs("Class:FrmPaymentAll,FucationName:PayPalExcelRead, Message:" + EX.Message + "");
                DisplayMessage("Class:FrmPaymentAll,FucationName:PayPalExcelRead, Message:" + EX.Message + "", "E");
            }
        }
        public  void PayPalInvoicePayment()
        {
            try
            {
                DisplayMessage("Try To PayPalInvoicePayment", "I");
                //Console.WriteLine("Try To PayPalInvoicePayment");
                ClsCommon.WritePaymentErrorLogs("Try To PayPalInvoicePayment");
                string DayName = DateTime.Now.DayOfWeek.ToString();
                string Transaction_date = DateTime.Now.AddDays(-2).ToString();
                DataTable dtPayment = new DataTable();
                if (DayName == "Monday")
                {
                    dtPayment = new BALPaypalMaster().SelectPayment(new BOLPayPalMaster() { transaction_updated_date = Transaction_date });
                }
                else
                {
                    dtPayment = new BALPaypalMaster().SelectPayment(new BOLPayPalMaster() { transaction_updated_date = DateTime.Now.ToString()});
                }
                if (dtPayment.Rows.Count > 0)
                {
                    for (int i = 0; i < dtPayment.Rows.Count; i++)
                    {
                        try
                        {
                            if (dtPayment.Rows[i]["payer_name"].ToString() != "")
                            {
                                DataTable dtCustomer = new DataTable();
                                dtCustomer = new BALCustomerMaster().SelectPayPalName(new BOLCustomerMaster() { PayPalName = dtPayment.Rows[i]["payer_name"].ToString() });
                                if (dtCustomer.Rows.Count > 0)
                                {
                                    for (int I = 0; I < dtCustomer.Rows.Count; I++)
                                    {
                                        DataTable dtinvoiceNO = new DataTable();
                                        dtinvoiceNO = new BALInvoiceMaster().SelectByCusIDAmount(new BOLInvoiceMaster() { ID = Convert.ToInt32(dtCustomer.Rows[I]["ID"].ToString()), TxnDate = Convert.ToDateTime(dtPayment.Rows[i]["transaction_updated_date"]), BalanceDue = Convert.ToDecimal(dtPayment.Rows[i]["transaction_amount"].ToString()), COUNT = 0 });
                                        if (dtinvoiceNO.Rows.Count > 0)
                                        {
                                            BOLPayment.InvoiceID = Convert.ToInt32(dtinvoiceNO.Rows[0]["ID"]);
                                            DataTable dtPaymentMethod = new DataTable();
                                            dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                            if (dtPaymentMethod.Rows.Count > 0)
                                            {
                                                if (dtPaymentMethod.Rows[0]["IsActive"].ToString() == "0")
                                                {
                                                    dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                    if (dtPaymentMethod.Rows.Count > 0)
                                                    {
                                                        BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                    }
                                                }
                                                else
                                                {
                                                    BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                }
                                            }
                                            else
                                            {
                                                dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                if (dtPaymentMethod.Rows.Count > 0)
                                                {
                                                    BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                }
                                            }
                                            int ID = Convert.ToInt32(dtPayment.Rows[i]["ID"].ToString());
                                            BOLPayment.PayAmount = Convert.ToDecimal(dtPayment.Rows[i]["transaction_amount"]);
                                            BOLPayment.Date = DateTime.Now;
                                            BOLPayment.TransactionID = dtPayment.Rows[i]["transaction_id"].ToString();
                                            BOLPayment.CreditAmount = null;
                                            BOLPayment.IsQBSync = 0;
                                            BOLPayment.PayPalID = ID;
                                            BALPAYMENT.Insert(BOLPayment);


                                            BOLPayPalMaster.ID = ID;
                                            BOLPayPalMaster.transaction_amount = Convert.ToDecimal("0.00");
                                            BALPaypalMaster.UpdateAmount(BOLPayPalMaster);

                                            if (Convert.ToDecimal(dtinvoiceNO.Rows[0]["BalanceDue"].ToString()) == Convert.ToDecimal(dtPayment.Rows[i]["transaction_amount"]))
                                            {
                                                objBOLInvoice.ID = Convert.ToInt32(dtinvoiceNO.Rows[0]["ID"]);
                                                objBOLInvoice.PaidInvoice = 2;
                                                objBOLInvoice.AppliedAmount = (Convert.ToDecimal(dtinvoiceNO.Rows[0]["AppliedAmount"].ToString()) + Convert.ToDecimal(dtPayment.Rows[i]["transaction_amount"]));
                                                objBOLInvoice.BalanceDue = (Convert.ToDecimal(dtinvoiceNO.Rows[0]["BalanceDue"].ToString()) - Convert.ToDecimal(dtPayment.Rows[i]["transaction_amount"]));
                                                objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                                                //Console.WriteLine("PayPal Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[0]["RefNumber"].ToString() + "");
                                                ClsCommon.WritePaymentErrorLogs("PayPal Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[0]["RefNumber"].ToString() + "");
                                                DisplayMessage("PayPal Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[0]["RefNumber"].ToString() + "", "I");
                                            }
                                        }
                                        else
                                        {
                                            dtinvoiceNO = new BALInvoiceMaster().SelectByCusIDAmount(new BOLInvoiceMaster() { ID = Convert.ToInt32(dtCustomer.Rows[I]["ID"].ToString()), TxnDate = Convert.ToDateTime(dtPayment.Rows[i]["transaction_updated_date"]), BalanceDue = Convert.ToDecimal(dtPayment.Rows[i]["transaction_amount"].ToString()), COUNT = 1 });
                                            if (dtinvoiceNO.Rows.Count > 0)
                                            {
                                                decimal transaction_amount = Convert.ToDecimal(dtPayment.Rows[i]["transaction_amount"]);

                                                for (int J = 0; J < dtinvoiceNO.Rows.Count; J++)
                                                {
                                                    if (transaction_amount != 0 && transaction_amount > Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]))
                                                    {
                                                        BOLPayment.InvoiceID = Convert.ToInt32(dtinvoiceNO.Rows[J]["ID"]);
                                                        DataTable dtPaymentMethod = new DataTable();
                                                        dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                        if (dtPaymentMethod.Rows.Count > 0)
                                                        {
                                                            if (dtPaymentMethod.Rows[0]["IsActive"].ToString() == "0")
                                                            {
                                                                dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                                if (dtPaymentMethod.Rows.Count > 0)
                                                                {
                                                                    BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                            if (dtPaymentMethod.Rows.Count > 0)
                                                            {
                                                                BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                            }
                                                        }
                                                        int ID = Convert.ToInt32(dtPayment.Rows[i]["ID"].ToString());
                                                        BOLPayment.PayAmount = Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]);
                                                        BOLPayment.Date = DateTime.Now;
                                                        BOLPayment.TransactionID = dtPayment.Rows[i]["transaction_id"].ToString();
                                                        BOLPayment.CreditAmount = null;
                                                        BOLPayment.IsQBSync = 0;
                                                        BOLPayment.PayPalID = ID;
                                                        BALPAYMENT.Insert(BOLPayment);


                                                        BOLPayPalMaster.ID = ID;
                                                        transaction_amount = transaction_amount - Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]);
                                                        BOLPayPalMaster.transaction_amount = transaction_amount;
                                                        BALPaypalMaster.UpdateAmount(BOLPayPalMaster);


                                                        objBOLInvoice.ID = Convert.ToInt32(dtinvoiceNO.Rows[J]["ID"]);
                                                        objBOLInvoice.PaidInvoice = 2;
                                                        objBOLInvoice.AppliedAmount = (Convert.ToDecimal(dtinvoiceNO.Rows[J]["AppliedAmount"].ToString()) + Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]));
                                                        objBOLInvoice.BalanceDue = Convert.ToDecimal("0.00");
                                                        objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                                                        //Console.WriteLine("PayPal Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "");
                                                        ClsCommon.WritePaymentErrorLogs("PayPal Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "");
                                                        DisplayMessage("PayPal Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "", "I");

                                                    }
                                                    else if (transaction_amount != 0 && transaction_amount < Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]))
                                                    {
                                                        decimal Paymentamount = transaction_amount;
                                                        BOLPayment.InvoiceID = Convert.ToInt32(dtinvoiceNO.Rows[J]["ID"]);
                                                        DataTable dtPaymentMethod = new DataTable();
                                                        dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                        if (dtPaymentMethod.Rows.Count > 0)
                                                        {
                                                            if (dtPaymentMethod.Rows[0]["IsActive"].ToString() == "0")
                                                            {
                                                                dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                                if (dtPaymentMethod.Rows.Count > 0)
                                                                {
                                                                    BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                            if (dtPaymentMethod.Rows.Count > 0)
                                                            {
                                                                BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                            }
                                                        }
                                                        int ID = Convert.ToInt32(dtPayment.Rows[i]["ID"].ToString());
                                                        BOLPayment.PayAmount = transaction_amount;
                                                        BOLPayment.Date = DateTime.Now;
                                                        BOLPayment.TransactionID = dtPayment.Rows[i]["transaction_id"].ToString();
                                                        BOLPayment.CreditAmount = null;
                                                        BOLPayment.IsQBSync = 0;
                                                        BOLPayment.PayPalID = ID;
                                                        BALPAYMENT.Insert(BOLPayment);


                                                        BOLPayPalMaster.ID = ID;
                                                        transaction_amount = Convert.ToDecimal("0.00");
                                                        BOLPayPalMaster.transaction_amount = transaction_amount;
                                                        BALPaypalMaster.UpdateAmount(BOLPayPalMaster);


                                                        objBOLInvoice.ID = Convert.ToInt32(dtinvoiceNO.Rows[J]["ID"]);
                                                        objBOLInvoice.PaidInvoice = 1;
                                                        objBOLInvoice.AppliedAmount = (Convert.ToDecimal(dtinvoiceNO.Rows[J]["AppliedAmount"].ToString()) + Paymentamount);
                                                        objBOLInvoice.BalanceDue = Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]) - Paymentamount;
                                                        objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                                                        //Console.WriteLine("PayPal Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "");
                                                        ClsCommon.WritePaymentErrorLogs("PayPal Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "");
                                                        DisplayMessage("PayPal Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "", "I");
                                                    }
                                                    else if (transaction_amount != 0 && transaction_amount == Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]))
                                                    {
                                                        decimal Paymentamount = transaction_amount;
                                                        BOLPayment.InvoiceID = Convert.ToInt32(dtinvoiceNO.Rows[J]["ID"]);
                                                        DataTable dtPaymentMethod = new DataTable();
                                                        dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                        if (dtPaymentMethod.Rows.Count > 0)
                                                        {
                                                            if (dtPaymentMethod.Rows[0]["IsActive"].ToString() == "0")
                                                            {
                                                                dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                                if (dtPaymentMethod.Rows.Count > 0)
                                                                {
                                                                    BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                            if (dtPaymentMethod.Rows.Count > 0)
                                                            {
                                                                BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                            }
                                                        }
                                                        int ID = Convert.ToInt32(dtPayment.Rows[i]["ID"].ToString());
                                                        BOLPayment.PayAmount = transaction_amount;
                                                        BOLPayment.Date = DateTime.Now;
                                                        BOLPayment.TransactionID = dtPayment.Rows[i]["transaction_id"].ToString();
                                                        BOLPayment.CreditAmount = null;
                                                        BOLPayment.IsQBSync = 0;
                                                        BOLPayment.PayPalID = ID;
                                                        BALPAYMENT.Insert(BOLPayment);


                                                        BOLPayPalMaster.ID = ID;
                                                        transaction_amount = Convert.ToDecimal("0.00");
                                                        BOLPayPalMaster.transaction_amount = transaction_amount;
                                                        BALPaypalMaster.UpdateAmount(BOLPayPalMaster);


                                                        objBOLInvoice.ID = Convert.ToInt32(dtinvoiceNO.Rows[J]["ID"]);
                                                        objBOLInvoice.PaidInvoice = 2;
                                                        objBOLInvoice.AppliedAmount = (Convert.ToDecimal(dtinvoiceNO.Rows[J]["AppliedAmount"].ToString()) + Paymentamount);
                                                        objBOLInvoice.BalanceDue = Convert.ToDecimal("0.00");
                                                        objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                                                        //Console.WriteLine("PayPal Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "");
                                                        ClsCommon.WritePaymentErrorLogs("PayPal Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "");
                                                        DisplayMessage("PayPal Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "", "I");
                                                    }

                                                }
                                            }
                                            else
                                            {
                                                //Console.WriteLine("No Invoice Found");
                                                ClsCommon.WritePaymentErrorLogs("No Invoice Found");
                                                DisplayMessage("No Invoice Found", "I");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    //Console.WriteLine("No Customer Found " + dtPayment.Rows[i]["payer_name"].ToString() + "");
                                    ClsCommon.WritePaymentErrorLogs("No Customer Found " + dtPayment.Rows[i]["payer_name"].ToString() + "");
                                    DisplayMessage("No Customer Found " + dtPayment.Rows[i]["payer_name"].ToString() + "", "I");
                                }
                            }
                            else
                            {
                                //Console.WriteLine("PayPal:-PayerName is Blank");
                                ClsCommon.WritePaymentErrorLogs("PayPal:-PayerName is Blank");
                                DisplayMessage("PayPal:-PayerName is Blank", "I");
                            }

                        }
                        catch (Exception ex)
                        {
                            //Console.WriteLine("Message" + ex.Message, "E");
                            ClsCommon.WritePaymentErrorLogs("Message" + ex.Message + "E");
                            DisplayMessage("Message" + ex.Message +"", "E");

                        }
                    }
                }
                else
                {
                    //Console.WriteLine("PayPal Invoice Payment No Found");
                    ClsCommon.WritePaymentErrorLogs("PayPal Invoice Payment No Found");
                    DisplayMessage("PayPal Invoice Payment No Found", "I");
                }
                IsPayPAL = true;
            }
            catch (Exception EX)
            {
                //Console.WriteLine("Class:AuthorizeToDB,FucationName:PayPalInvoicePayment, Message:" + EX.Message, "E");
                ClsCommon.WritePaymentErrorLogs("Class:FrmPaymentAll,FucationName:PayPalInvoicePayment, Message:" + EX.Message + "");
                DisplayMessage("Class:FrmPaymentAll,FucationName:PayPalInvoicePayment, Message:" + EX.Message + "", "E");
            }
        }
        public void ZelleExcelRead()
        {
            try
            {
                ClsCommon.dtZellePayment = new DataTable();
                dt = new DataTable();
                using (XLWorkbook workbook = new XLWorkbook(txtFilePath.Text.ToString()))
                {
                    IXLWorksheet worksheet = workbook.Worksheet(3);
                    bool FirstRow = true;
                    string readRange = "1:1";
                    foreach (IXLRow row in worksheet.RowsUsed())
                    {
                        if (FirstRow)
                        {
                            readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                            foreach (IXLCell cell in row.Cells(readRange))
                            {
                                dt.Columns.Add(cell.Value.ToString());
                            }
                            FirstRow = false;
                        }
                        else
                        {
                            dt.Rows.Add();
                            int cellIndex = 0;
                            foreach (IXLCell cell in row.Cells(readRange))
                            {
                                dt.Rows[dt.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                cellIndex++;
                            }
                        }
                    }
                    ClsCommon.dtZellePayment.Merge(dt);

                    if (ClsCommon.dtZellePayment.Rows.Count > 0)
                    {
                        for (int i = 0; i < ClsCommon.dtZellePayment.Rows.Count; i++)
                        {
                            BOLZelleMaster.Date = Convert.ToDateTime(ClsCommon.dtZellePayment.Rows[i]["Date"].ToString());
                            string ZelleName = ClsCommon.dtZellePayment.Rows[i]["Description"].ToString();
                            string[] spearator = { "Zelle From " };
                            // using the method
                            string[] ZelleNameList = ZelleName.Split(spearator,
                                   StringSplitOptions.RemoveEmptyEntries);
                            string[] Name = ZelleNameList[1].Split('+');
                            BOLZelleMaster.ZelleName = Name[0].TrimEnd(' ');
                            BOLZelleMaster.Amount = Convert.ToDecimal(ClsCommon.dtZellePayment.Rows[i]["Credits"]);
                            BOLZelleMaster.TotalAmount = Convert.ToDecimal(ClsCommon.dtZellePayment.Rows[i]["Credits"]);
                            BALZelleMaster.Insert(BOLZelleMaster);
                            //Console.WriteLine("Zelle Insert Successfully,ZelleName:" + Name[0] + "");
                            ClsCommon.WritePaymentErrorLogs("Zelle Insert Successfully,ZelleName:" + Name[0] + "");
                            DisplayMessage("Zelle Insert Successfully,ZelleName:" + Name[0] + "", "I");
                        }
                    }
                }
                IsZelleExcel = true;
            }
            catch (Exception EX)
            {
                //Console.WriteLine("Class:AuthorizeToDB,FucationName:ZelleExcelRead, Message:" + EX.Message, "E");
                ClsCommon.WritePaymentErrorLogs("Class:FrmPaymentAll,FucationName:ZelleExcelRead, Message:" + EX.Message + "");
                DisplayMessage("Class:FrmPaymentAll,FucationName:ZelleExcelRead, Message:" + EX.Message + "", "E");
            }
        }
        public  void ZelleInvoicePayment()
        {
            try
            {
                DisplayMessage("Try To ZelleInvoicePayment", "I");
                //Console.WriteLine("Try To ZelleInvoicePayment");
                ClsCommon.WritePaymentErrorLogs("Try To ZelleInvoicePayment");
                DataTable dtZelle = new DataTable();
                dtZelle = new BALZelleMaster().Select();
                if (dtZelle.Rows.Count > 0)
                {
                    for (int i = 0; i < dtZelle.Rows.Count; i++)
                    {
                        if (dtZelle.Rows[i]["ZelleName"].ToString() != "")
                        {
                            DataTable dtCustomer = new DataTable();
                            dtCustomer = new BALCustomerMaster().SelectPayPalName(new BOLCustomerMaster() { PayPalName = dtZelle.Rows[i]["ZelleName"].ToString() });
                            if (dtCustomer.Rows.Count > 0)
                            {
                                for (int I = 0; I < dtCustomer.Rows.Count; I++)
                                {
                                    DataTable dtinvoiceNO = new DataTable();
                                    dtinvoiceNO = new BALInvoiceMaster().SelectByCusIDAmount(new BOLInvoiceMaster() { ID = Convert.ToInt32(dtCustomer.Rows[I]["ID"].ToString()), TxnDate = Convert.ToDateTime(dtZelle.Rows[i]["Date"].ToString()), BalanceDue = Convert.ToDecimal(dtZelle.Rows[i]["Amount"].ToString()), COUNT = 0 });
                                    if (dtinvoiceNO.Rows.Count > 0)
                                    {
                                        BOLPayment.InvoiceID = Convert.ToInt32(dtinvoiceNO.Rows[0]["ID"]);
                                        DataTable dtPaymentMethod = new DataTable();
                                        dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                        if (dtPaymentMethod.Rows.Count > 0)
                                        {
                                            if (dtPaymentMethod.Rows[0]["IsActive"].ToString() == "0")
                                            {
                                                dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                if (dtPaymentMethod.Rows.Count > 0)
                                                {
                                                    BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                }
                                            }
                                            else
                                            {
                                                BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                            }
                                        }
                                        else
                                        {
                                            dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                            if (dtPaymentMethod.Rows.Count > 0)
                                            {
                                                BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                            }
                                        }
                                        int ID = Convert.ToInt32(dtZelle.Rows[i]["ID"].ToString());
                                        BOLPayment.PayAmount = Convert.ToDecimal(dtZelle.Rows[i]["Amount"]);
                                        BOLPayment.Date = DateTime.Now;
                                        BOLPayment.CreditAmount = null;
                                        BOLPayment.IsQBSync = 0;
                                        BOLPayment.PayPalID = null;
                                        BALPAYMENT.Insert(BOLPayment);

                                        BOLZelleMaster.ID = ID;
                                        BOLZelleMaster.Amount = Convert.ToDecimal("0.00");
                                        BALZelleMaster.UpdateAmount(BOLZelleMaster);

                                        if (Convert.ToDecimal(dtinvoiceNO.Rows[0]["BalanceDue"].ToString()) == Convert.ToDecimal(dtZelle.Rows[i]["Amount"]))
                                        {
                                            objBOLInvoice.ID = Convert.ToInt32(dtinvoiceNO.Rows[0]["ID"]);
                                            objBOLInvoice.PaidInvoice = 2;
                                            objBOLInvoice.AppliedAmount = (Convert.ToDecimal(dtinvoiceNO.Rows[0]["AppliedAmount"].ToString()) + Convert.ToDecimal(dtZelle.Rows[i]["Amount"]));
                                            objBOLInvoice.BalanceDue = (Convert.ToDecimal(dtinvoiceNO.Rows[0]["BalanceDue"].ToString()) - Convert.ToDecimal(dtZelle.Rows[i]["Amount"]));
                                            objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                                            DisplayMessage("Zelle Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[0]["RefNumber"].ToString() + "", "I");
                                            //Console.WriteLine("Zelle Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[0]["RefNumber"].ToString() + "");
                                            ClsCommon.WritePaymentErrorLogs("Zelle Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[0]["RefNumber"].ToString() + "");
                                        }
                                    }
                                    else
                                    {
                                        dtinvoiceNO = new BALInvoiceMaster().SelectByCusIDAmount(new BOLInvoiceMaster() { ID = Convert.ToInt32(dtCustomer.Rows[I]["ID"].ToString()), TxnDate = Convert.ToDateTime(dtZelle.Rows[i]["Date"].ToString()), BalanceDue = Convert.ToDecimal(dtZelle.Rows[i]["Amount"].ToString()), COUNT = 1 });
                                        if (dtinvoiceNO.Rows.Count > 0)
                                        {
                                            decimal transaction_amount = Convert.ToDecimal(dtZelle.Rows[i]["Amount"]);


                                            for (int J = 0; J < dtinvoiceNO.Rows.Count; J++)
                                            {
                                                if (transaction_amount != 0 && transaction_amount > Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]))
                                                {

                                                    BOLPayment.InvoiceID = Convert.ToInt32(dtinvoiceNO.Rows[J]["ID"]);
                                                    DataTable dtPaymentMethod = new DataTable();
                                                    dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                    if (dtPaymentMethod.Rows.Count > 0)
                                                    {
                                                        if (dtPaymentMethod.Rows[0]["IsActive"].ToString() == "0")
                                                        {
                                                            dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                            if (dtPaymentMethod.Rows.Count > 0)
                                                            {
                                                                BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                        if (dtPaymentMethod.Rows.Count > 0)
                                                        {
                                                            BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                        }
                                                    }
                                                    int ID = Convert.ToInt32(dtZelle.Rows[i]["ID"].ToString());
                                                    BOLPayment.PayAmount = Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]);
                                                    BOLPayment.Date = DateTime.Now;
                                                    BOLPayment.IsQBSync = 0;
                                                    BOLPayment.PayPalID = null;
                                                    BALPAYMENT.Insert(BOLPayment);


                                                    BOLZelleMaster.ID = ID;
                                                    transaction_amount = transaction_amount - Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]);
                                                    BOLZelleMaster.Amount = transaction_amount;
                                                    BALZelleMaster.UpdateAmount(BOLZelleMaster);


                                                    objBOLInvoice.ID = Convert.ToInt32(dtinvoiceNO.Rows[J]["ID"]);
                                                    objBOLInvoice.PaidInvoice = 2;
                                                    objBOLInvoice.AppliedAmount = (Convert.ToDecimal(dtinvoiceNO.Rows[J]["AppliedAmount"].ToString()) + Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]));
                                                    objBOLInvoice.BalanceDue = Convert.ToDecimal("0.00");
                                                    objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                                                    //Console.WriteLine("Zelle Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "");
                                                    ClsCommon.WritePaymentErrorLogs("Zelle Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "");
                                                    DisplayMessage("Zelle Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "", "I");

                                                }
                                                else if (transaction_amount != 0 && transaction_amount < Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]))
                                                {
                                                    decimal Paymentamount = transaction_amount;
                                                    BOLPayment.InvoiceID = Convert.ToInt32(dtinvoiceNO.Rows[J]["ID"]);
                                                    DataTable dtPaymentMethod = new DataTable();
                                                    dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                    if (dtPaymentMethod.Rows.Count > 0)
                                                    {
                                                        if (dtPaymentMethod.Rows[0]["IsActive"].ToString() == "0")
                                                        {
                                                            dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                            if (dtPaymentMethod.Rows.Count > 0)
                                                            {
                                                                BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                        if (dtPaymentMethod.Rows.Count > 0)
                                                        {
                                                            BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                        }
                                                    }
                                                    int ID = Convert.ToInt32(dtZelle.Rows[i]["ID"].ToString());
                                                    BOLPayment.PayAmount = transaction_amount;
                                                    BOLPayment.Date = DateTime.Now;
                                                    BOLPayment.IsQBSync = 0;
                                                    BOLPayment.PayPalID = null;
                                                    BALPAYMENT.Insert(BOLPayment);

                                                    BOLZelleMaster.ID = ID;
                                                    transaction_amount = Convert.ToDecimal("0.00");
                                                    BOLZelleMaster.Amount = transaction_amount;
                                                    BALZelleMaster.UpdateAmount(BOLZelleMaster);


                                                    objBOLInvoice.ID = Convert.ToInt32(dtinvoiceNO.Rows[J]["ID"]);
                                                    objBOLInvoice.PaidInvoice = 1;
                                                    objBOLInvoice.AppliedAmount = (Convert.ToDecimal(dtinvoiceNO.Rows[J]["AppliedAmount"].ToString()) + Paymentamount);
                                                    objBOLInvoice.BalanceDue = Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]) - Paymentamount;
                                                    objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                                                    //Console.WriteLine("Zelle Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "");
                                                    ClsCommon.WritePaymentErrorLogs("Zelle Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "");
                                                    DisplayMessage("Zelle Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "", "I");
                                                }
                                                else if (transaction_amount != 0 && transaction_amount == Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]))
                                                {
                                                    decimal Paymentamount = transaction_amount;
                                                    BOLPayment.InvoiceID = Convert.ToInt32(dtinvoiceNO.Rows[J]["ID"]);
                                                    DataTable dtPaymentMethod = new DataTable();
                                                    dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                    if (dtPaymentMethod.Rows.Count > 0)
                                                    {
                                                        if (dtPaymentMethod.Rows[0]["IsActive"].ToString() == "0")
                                                        {
                                                            dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                            if (dtPaymentMethod.Rows.Count > 0)
                                                            {
                                                                BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                        if (dtPaymentMethod.Rows.Count > 0)
                                                        {
                                                            BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                        }
                                                    }
                                                    int ID = Convert.ToInt32(dtZelle.Rows[i]["ID"].ToString());
                                                    BOLPayment.PayAmount = transaction_amount;
                                                    BOLPayment.Date = DateTime.Now;
                                                    BOLPayment.IsQBSync = 0;
                                                    BOLPayment.PayPalID = null;
                                                    BALPAYMENT.Insert(BOLPayment);

                                                    BOLZelleMaster.ID = ID;
                                                    transaction_amount = Convert.ToDecimal("0.00");
                                                    BOLZelleMaster.Amount = transaction_amount;
                                                    BALZelleMaster.UpdateAmount(BOLZelleMaster);


                                                    objBOLInvoice.ID = Convert.ToInt32(dtinvoiceNO.Rows[J]["ID"]);
                                                    objBOLInvoice.PaidInvoice = 2;
                                                    objBOLInvoice.AppliedAmount = (Convert.ToDecimal(dtinvoiceNO.Rows[J]["AppliedAmount"].ToString()) + Paymentamount);
                                                    objBOLInvoice.BalanceDue = Convert.ToDecimal("0.00");
                                                    objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                                                    //Console.WriteLine("Zelle Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "");
                                                    ClsCommon.WritePaymentErrorLogs("Zelle Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "");
                                                    DisplayMessage("Zelle Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "", "I");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            //Console.WriteLine("No Invoice Found");
                                            ClsCommon.WritePaymentErrorLogs("No Invoice Found");
                                            DisplayMessage("No Invoice Found", "I");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //Console.WriteLine("No Customer Found " + dtZelle.Rows[i]["ZelleName"].ToString() + "");
                                ClsCommon.WritePaymentErrorLogs("No Customer Found " + dtZelle.Rows[i]["ZelleName"].ToString() + "");
                                DisplayMessage("No Customer Found " + dtZelle.Rows[i]["ZelleName"].ToString() + "", "I");
                            }
                        }
                        else
                        {
                            //Console.WriteLine("Zelle:-ZelleName is Blank");
                            ClsCommon.WritePaymentErrorLogs("Zelle:-ZelleName is Blank");
                            DisplayMessage("Zelle:-ZelleName is Blank", "I");
                        }
                    }
                }
                else
                {
                    //Console.WriteLine("Zelle Invoice Payment No Found");
                    ClsCommon.WritePaymentErrorLogs("Zelle Invoice Payment No Found");
                    DisplayMessage("Zelle Invoice Payment No Found", "I");
                }
                IsZelle = true;
            }
            catch (Exception EX)
            {
                //Console.WriteLine("Class:AuthorizeToDB,FucationName:ZelleInvoicePayment, Message:" + EX.Message, "E");
                ClsCommon.WritePaymentErrorLogs("Class:FrmPaymentAll,FucationName:ZelleInvoicePayment, Message:" + EX.Message + "");
                DisplayMessage("Class:FrmPaymentAll,FucationName:ZelleInvoicePayment, Message:" + EX.Message + "", "E");
            }
        }
        public  void CashAppExcelRead()
        {
            try
            {
                ClsCommon.dtCashAppPayment = new DataTable();
                dt = new DataTable();
                using (XLWorkbook workbook = new XLWorkbook(txtFilePath.Text.ToString()))
                {
                    IXLWorksheet worksheet = workbook.Worksheet(4);
                    bool FirstRow = true;
                    string readRange = "1:1";
                    foreach (IXLRow row in worksheet.RowsUsed())
                    {
                        if (FirstRow)
                        {
                            readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                            foreach (IXLCell cell in row.Cells(readRange))
                            {
                                dt.Columns.Add(cell.Value.ToString());
                            }
                            FirstRow = false;
                        }
                        else
                        {
                            dt.Rows.Add();
                            int cellIndex = 0;
                            foreach (IXLCell cell in row.Cells(readRange))
                            {
                                dt.Rows[dt.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                cellIndex++;
                            }
                        }
                    }
                    ClsCommon.dtCashAppPayment.Merge(dt);
                    if (ClsCommon.dtCashAppPayment.Rows.Count > 0)
                    {
                        for (int i = 0; i < ClsCommon.dtCashAppPayment.Rows.Count; i++)
                        {
                            bool Istrue = true;
                            string s = ClsCommon.dtCashAppPayment.Rows[i]["TRANSACTIONS"].ToString();
                            int n;
                            //bool isNumeric = ;
                            if (int.TryParse(s, out n) == false)
                            {
                                Istrue = false;
                            }
                            else
                            {
                                Istrue = true;
                                BOLCashAppMaster.CashAppName = ClsCommon.dtCashAppPayment.Rows[i - 3]["TRANSACTIONS"].ToString();
                                BOLCashAppMaster.Date = DateTime.Now;
                                BOLCashAppMaster.Amount = Convert.ToDecimal(ClsCommon.dtCashAppPayment.Rows[i]["TRANSACTIONS"].ToString());
                                BOLCashAppMaster.TotalAmount = Convert.ToDecimal(ClsCommon.dtCashAppPayment.Rows[i]["TRANSACTIONS"].ToString());
                                BALCashAppMaster.Insert(BOLCashAppMaster);
                                //Console.WriteLine("CashApp Insert Successfully,CashAppName:" + ClsCommon.dtCashAppPayment.Rows[i - 3]["TRANSACTIONS"].ToString() + "");
                                ClsCommon.WritePaymentErrorLogs("CashApp Insert Successfully,CashAppName:" + ClsCommon.dtCashAppPayment.Rows[i - 3]["TRANSACTIONS"].ToString() + "");
                                DisplayMessage("CashApp Insert Successfully,CashAppName:" + ClsCommon.dtCashAppPayment.Rows[i - 3]["TRANSACTIONS"].ToString() + "", "I");
                            }
                        }
                    }
                }
                IsCashAppExcel = true;
            }
            catch (Exception EX)
            {
                //Console.WriteLine("Class:AuthorizeToDB,FucationName:CashAppExcelRead, Message:" + EX.Message, "E");
                ClsCommon.WritePaymentErrorLogs("Class:FrmPaymentAll,FucationName:CashAppExcelRead, Message:" + EX.Message + "");
                DisplayMessage("Class:FrmPaymentAll,FucationName:CashAppExcelRead, Message:" + EX.Message + "", "E");
            }
        }
        public void CashAppInvoicePayment()
        {
            try
            {
                //Console.WriteLine("Try To CashAppInvoicePayment");
                ClsCommon.WritePaymentErrorLogs("Try To CashAppInvoicePayment");
                DisplayMessage("Try To CashAppInvoicePayment", "I");
                string DayName = DateTime.Now.DayOfWeek.ToString();
                string Transaction_date = DateTime.Now.AddDays(-2).ToString();
                DataTable dtPayment = new DataTable();
                if (DayName == "Monday")
                {
                    dtPayment = new BALCashAppMaster().Select(new BOLCashAppMaster() { Date = Convert.ToDateTime(Transaction_date) });
                }
                else
                {
                    dtPayment = new BALCashAppMaster().Select(new BOLCashAppMaster() { Date = DateTime.Now });
                }
                if (dtPayment.Rows.Count > 0)
                {
                    for (int i = 0; i < dtPayment.Rows.Count; i++)
                    {
                        try
                        {
                            if (dtPayment.Rows[i]["CashAppName"].ToString() != "")
                            {
                                DataTable dtCustomer = new DataTable();
                                dtCustomer = new BALCustomerMaster().SelectPayPalName(new BOLCustomerMaster() { PayPalName = dtPayment.Rows[i]["CashAppName"].ToString() });
                                if (dtCustomer.Rows.Count > 0)
                                {
                                    for (int I = 0; I < dtCustomer.Rows.Count; I++)
                                    {
                                        DataTable dtinvoiceNO = new DataTable();
                                        dtinvoiceNO = new BALInvoiceMaster().SelectByCusIDAmount(new BOLInvoiceMaster() { ID = Convert.ToInt32(dtCustomer.Rows[I]["ID"].ToString()), TxnDate = Convert.ToDateTime(dtPayment.Rows[i]["Date"].ToString()), BalanceDue = Convert.ToDecimal(dtPayment.Rows[i]["Amount"].ToString()), COUNT = 0 });
                                        if (dtinvoiceNO.Rows.Count > 0)
                                        {
                                            BOLPayment.InvoiceID = Convert.ToInt32(dtinvoiceNO.Rows[0]["ID"]);
                                            DataTable dtPaymentMethod = new DataTable();
                                            dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                            if (dtPaymentMethod.Rows.Count > 0)
                                            {
                                                if (dtPaymentMethod.Rows[0]["IsActive"].ToString() == "0")
                                                {
                                                    dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                    if (dtPaymentMethod.Rows.Count > 0)
                                                    {
                                                        BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                    }
                                                }
                                                else
                                                {
                                                    BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                }
                                            }
                                            else
                                            {
                                                dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                if (dtPaymentMethod.Rows.Count > 0)
                                                {
                                                    BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                }
                                            }
                                            int ID = Convert.ToInt32(dtPayment.Rows[i]["ID"].ToString());
                                            BOLPayment.PayAmount = Convert.ToDecimal(dtPayment.Rows[i]["Amount"]);
                                            BOLPayment.Date = DateTime.Now;
                                            BOLPayment.CreditAmount = null;
                                            BOLPayment.IsQBSync = 0;
                                            BOLPayment.PayPalID = null;
                                            BALPAYMENT.Insert(BOLPayment);
                                            BOLCashAppMaster.ID = ID;
                                            BOLCashAppMaster.Amount = Convert.ToDecimal("0.00");
                                            BALCashAppMaster.UpdateAmount(BOLCashAppMaster);

                                            if (Convert.ToDecimal(dtinvoiceNO.Rows[0]["BalanceDue"].ToString()) == Convert.ToDecimal(dtPayment.Rows[i]["Amount"]))
                                            {
                                                objBOLInvoice.ID = Convert.ToInt32(dtinvoiceNO.Rows[0]["ID"]);
                                                objBOLInvoice.PaidInvoice = 2;
                                                objBOLInvoice.AppliedAmount = (Convert.ToDecimal(dtinvoiceNO.Rows[0]["AppliedAmount"].ToString()) + Convert.ToDecimal(dtPayment.Rows[i]["Amount"]));
                                                objBOLInvoice.BalanceDue = (Convert.ToDecimal(dtinvoiceNO.Rows[0]["BalanceDue"].ToString()) - Convert.ToDecimal(dtPayment.Rows[i]["Amount"]));
                                                objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                                                //Console.WriteLine("CashApp Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[0]["RefNumber"].ToString() + "");
                                                ClsCommon.WritePaymentErrorLogs("CashApp Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[0]["RefNumber"].ToString() + "");
                                                DisplayMessage("CashApp Payment Successfully InvoiceNo: " + dtinvoiceNO.Rows[0]["RefNumber"].ToString() + "", "I");
                                            }
                                        }
                                        else
                                        {
                                            dtinvoiceNO = new BALInvoiceMaster().SelectByCusIDAmount(new BOLInvoiceMaster() { ID = Convert.ToInt32(dtCustomer.Rows[I]["ID"].ToString()), TxnDate = Convert.ToDateTime(dtPayment.Rows[i]["Date"].ToString()), BalanceDue = Convert.ToDecimal(dtPayment.Rows[i]["Amount"].ToString()), COUNT = 1 });
                                            if (dtinvoiceNO.Rows.Count > 0)
                                            {
                                                decimal transaction_amount = Convert.ToDecimal(dtPayment.Rows[i]["Amount"]);


                                                for (int J = 0; J < dtinvoiceNO.Rows.Count; J++)
                                                {


                                                    if (transaction_amount != 0 && transaction_amount > Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]))
                                                    {

                                                        BOLPayment.InvoiceID = Convert.ToInt32(dtinvoiceNO.Rows[J]["ID"]);
                                                        DataTable dtPaymentMethod = new DataTable();
                                                        dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                        if (dtPaymentMethod.Rows.Count > 0)
                                                        {
                                                            if (dtPaymentMethod.Rows[0]["IsActive"].ToString() == "0")
                                                            {
                                                                dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                                if (dtPaymentMethod.Rows.Count > 0)
                                                                {
                                                                    BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                            if (dtPaymentMethod.Rows.Count > 0)
                                                            {
                                                                BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                            }
                                                        }
                                                        int ID = Convert.ToInt32(dtPayment.Rows[i]["ID"].ToString());
                                                        BOLPayment.PayAmount = Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]);
                                                        BOLPayment.Date = DateTime.Now;
                                                        BOLPayment.CreditAmount = null;
                                                        BOLPayment.IsQBSync = 0;
                                                        BOLPayment.PayPalID = null;
                                                        BALPAYMENT.Insert(BOLPayment);

                                                        BOLCashAppMaster.ID = ID;
                                                        transaction_amount = transaction_amount - Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]);
                                                        BOLCashAppMaster.Amount = transaction_amount;
                                                        BALCashAppMaster.UpdateAmount(BOLCashAppMaster);


                                                        objBOLInvoice.ID = Convert.ToInt32(dtinvoiceNO.Rows[J]["ID"]);
                                                        objBOLInvoice.PaidInvoice = 2;
                                                        objBOLInvoice.AppliedAmount = (Convert.ToDecimal(dtinvoiceNO.Rows[J]["AppliedAmount"].ToString()) + Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]));
                                                        objBOLInvoice.BalanceDue = Convert.ToDecimal("0.00");
                                                        objBALInvoice.UpdatePaidInvoice(objBOLInvoice);

                                                        //Console.WriteLine("CashApp Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "");
                                                        ClsCommon.WritePaymentErrorLogs("CashApp Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "");
                                                        DisplayMessage("CashApp Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "", "I");

                                                    }
                                                    else if (transaction_amount != 0 && transaction_amount < Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]))
                                                    {
                                                        decimal Paymentamount = transaction_amount;
                                                        BOLPayment.InvoiceID = Convert.ToInt32(dtinvoiceNO.Rows[J]["ID"]);
                                                        DataTable dtPaymentMethod = new DataTable();
                                                        dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                        if (dtPaymentMethod.Rows.Count > 0)
                                                        {
                                                            if (dtPaymentMethod.Rows[0]["IsActive"].ToString() == "0")
                                                            {
                                                                dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                                if (dtPaymentMethod.Rows.Count > 0)
                                                                {
                                                                    BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                            if (dtPaymentMethod.Rows.Count > 0)
                                                            {
                                                                BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                            }
                                                        }
                                                        int ID = Convert.ToInt32(dtPayment.Rows[i]["ID"].ToString());
                                                        BOLPayment.PayAmount = transaction_amount;
                                                        BOLPayment.Date = DateTime.Now;
                                                        BOLPayment.CreditAmount = null;
                                                        BOLPayment.IsQBSync = 0;
                                                        BOLPayment.PayPalID = null;
                                                        BALPAYMENT.Insert(BOLPayment);

                                                        BOLCashAppMaster.ID = ID;
                                                        transaction_amount = Convert.ToDecimal("0.00");
                                                        BOLCashAppMaster.Amount = transaction_amount;
                                                        BALCashAppMaster.UpdateAmount(BOLCashAppMaster);


                                                        objBOLInvoice.ID = Convert.ToInt32(dtinvoiceNO.Rows[J]["ID"]);
                                                        objBOLInvoice.PaidInvoice = 1;
                                                        objBOLInvoice.AppliedAmount = (Convert.ToDecimal(dtinvoiceNO.Rows[J]["AppliedAmount"].ToString()) + Paymentamount);
                                                        objBOLInvoice.BalanceDue = Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]) - Paymentamount;
                                                        objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                                                        //Console.WriteLine("CashApp Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "");
                                                        ClsCommon.WritePaymentErrorLogs("CashApp Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "");
                                                        DisplayMessage("CashApp Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "", "I");
                                                    }
                                                    else if (transaction_amount != 0 && transaction_amount == Convert.ToDecimal(dtinvoiceNO.Rows[J]["BalanceDue"]))
                                                    {
                                                        decimal Paymentamount = transaction_amount;
                                                        BOLPayment.InvoiceID = Convert.ToInt32(dtinvoiceNO.Rows[J]["ID"]);
                                                        DataTable dtPaymentMethod = new DataTable();
                                                        dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                        if (dtPaymentMethod.Rows.Count > 0)
                                                        {
                                                            if (dtPaymentMethod.Rows[0]["IsActive"].ToString() == "0")
                                                            {
                                                                dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                                if (dtPaymentMethod.Rows.Count > 0)
                                                                {
                                                                    BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            dtPaymentMethod = new BALAuthorizeKEY().SelectPaymentMethodType(new BOLAuthorizePayment() { accountType = "Credit Card" });
                                                            if (dtPaymentMethod.Rows.Count > 0)
                                                            {
                                                                BOLPayment.PaymentMethodID = Convert.ToInt32(dtPaymentMethod.Rows[0]["ID"]);
                                                            }
                                                        }
                                                        int ID = Convert.ToInt32(dtPayment.Rows[i]["ID"].ToString());
                                                        BOLPayment.PayAmount = transaction_amount;
                                                        BOLPayment.Date = DateTime.Now;
                                                        BOLPayment.CreditAmount = null;
                                                        BOLPayment.IsQBSync = 0;
                                                        BOLPayment.PayPalID = null;
                                                        BALPAYMENT.Insert(BOLPayment);

                                                        BOLCashAppMaster.ID = ID;
                                                        transaction_amount = Convert.ToDecimal("0.00");
                                                        BOLCashAppMaster.Amount = transaction_amount;
                                                        BALCashAppMaster.UpdateAmount(BOLCashAppMaster);


                                                        objBOLInvoice.ID = Convert.ToInt32(dtinvoiceNO.Rows[J]["ID"]);
                                                        objBOLInvoice.PaidInvoice = 2;
                                                        objBOLInvoice.AppliedAmount = (Convert.ToDecimal(dtinvoiceNO.Rows[J]["AppliedAmount"].ToString()) + Paymentamount);
                                                        objBOLInvoice.BalanceDue = Convert.ToDecimal("0.00");
                                                        objBALInvoice.UpdatePaidInvoice(objBOLInvoice);
                                                        //Console.WriteLine("CashApp Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "");
                                                        ClsCommon.WritePaymentErrorLogs("CashApp Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "");
                                                        DisplayMessage("CashApp Payment Successfully InvoiceNo:" + dtinvoiceNO.Rows[J]["RefNumber"].ToString() + "", "I");
                                                    }

                                                }
                                            }
                                            else
                                            {
                                                //Console.WriteLine("No Invoice Found");
                                                ClsCommon.WritePaymentErrorLogs("No Invoice Found");
                                                DisplayMessage("No Invoice Found", "I");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    //Console.WriteLine("No Customer Found " + dtPayment.Rows[i]["CashAppName"].ToString() + "");
                                    ClsCommon.WritePaymentErrorLogs("No Customer Found " + dtPayment.Rows[i]["CashAppName"].ToString() + "");
                                    DisplayMessage("No Customer Found " + dtPayment.Rows[i]["CashAppName"].ToString() + "", "I");
                                }
                            }
                            else
                            {
                                //Console.WriteLine("CashApp:-CashAppName is Blank");
                                ClsCommon.WritePaymentErrorLogs("CashApp:-CashAppName is Blank");
                                DisplayMessage("CashApp:-CashAppName is Blank", "I");
                            }
                        }
                        catch (Exception ex)
                        {
                            //Console.WriteLine("Message" + ex.Message, "E");
                            ClsCommon.WritePaymentErrorLogs("Message" + ex.Message + "E");
                            DisplayMessage("Message" + ex.Message + "", "E");

                        }
                    }
                }
                else
                {
                    //Console.WriteLine("CashApp Invoice Payment No Found");
                    ClsCommon.WritePaymentErrorLogs("CashApp Invoice Payment No Found");
                    DisplayMessage("CashApp Invoice Payment No Found", "I");
                }
                IsCashApp = true;
            }
            catch (Exception EX)
            {
                //Console.WriteLine("Class:AuthorizeToDB,FucationName:CashAppInvoicePayment, Message:" + EX.Message, "E");
                ClsCommon.WritePaymentErrorLogs("Class:FrmPaymentAll,FucationName:CashAppInvoicePayment, Message:" + EX.Message + "");
                DisplayMessage("Class:FrmPaymentAll,FucationName:CashAppInvoicePayment, Message:" + EX.Message + "", "E");
            }
        }
        public  void MoveExcel(string sourceFile)
        {
            try
            {
                if (Validations())
                {
                    string filename = Path.GetFileNameWithoutExtension(sourceFile);
                    string Date = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
                    string destinationFile = AppDomain.CurrentDomain.BaseDirectory + @"\Process\" + filename + " " + Date + ".xlsx";
                    int count = 1;
                    while (File.Exists(destinationFile))
                    {
                        string tempFileName = string.Format("{0}({1})", filename + " " + Date, count++);
                        destinationFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Process\", tempFileName + ".xlsx");
                    }
                    System.IO.File.Move(sourceFile, destinationFile);
                    //Console.WriteLine("Move File SuccessFully:" + sourceFile + " To " + destinationFile + "");
                    ClsCommon.WritePaymentErrorLogs("Move File SuccessFully:" + sourceFile + " To " + destinationFile + "");
                    DisplayMessage("Move File SuccessFully:" + sourceFile + " To " + destinationFile + "", "I");
                    DisplayMessage("Payment Successfully", "I");

                }
            }
            catch (Exception EX)
            {
                //Console.WriteLine("Class:AuthorizeToDB,FucationName:MoveExcel, Message:" + EX.Message, "E");
                ClsCommon.WritePaymentErrorLogs("Class:FrmPaymentAll,FucationName:MoveExcel, Message:" + EX.Message + "");
                DisplayMessage("Class:FrmPaymentAll,FucationName:MoveExcel, Message:" + EX.Message + "", "E");
            }
        }

        private void DisplayMessage(string Text, string Mode)
        {
            switch (Mode)
            {
                case "W":
                    lblErrorMsg.StateCommon.TextColor = Color.FromArgb(16, 6, 244);
                    lblErrorMsg.StateNormal.TextColor = Color.FromArgb(16, 6, 244);
                    lblErrorMsg.Text = Text;
                    break;
                case "I":
                    lblErrorMsg.StateCommon.TextColor = Color.DarkGreen;
                    lblErrorMsg.StateNormal.TextColor = Color.DarkGreen;
                    lblErrorMsg.Text = Text;
                    break;
                case "E":
                    lblErrorMsg.StateCommon.TextColor = Color.DarkRed;
                    lblErrorMsg.StateNormal.TextColor = Color.DarkRed;
                    lblErrorMsg.Text = "Error: " + Text;
                    break;
            }
        }

        private void FrmPaymentAll_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {


                lblErrorMsg.Text = "";
                txtFilePath.Clear();
                e.Cancel = true;
                this.Hide();
                this.Parent = null;
            }
            catch(Exception ex)
            {
                ClsCommon.WritePaymentErrorLogs("Class:FrmPaymentAll,FucationName:FrmPaymentAll_FormClosing, Message:" + ex.Message + "");
                DisplayMessage("Class:FrmPaymentAll,FucationName:FrmPaymentAll_FormClosing, Message:" + ex.Message + "", "E");
            }
      

        }
    }
}