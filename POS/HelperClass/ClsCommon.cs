using Interop.QBFC13;
using POS.BAL;
using POS.BOL;
using POS.Properties;
using POS.QBClass;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace POS.HelperClass
{
    public static class ClsCommon
    {

        public static QBSessionManager oSession = null;
        public static FrmRemainderInvoiceReport objInvRemainder = new FrmRemainderInvoiceReport();
        public static FrmInvoiceReport objInv = new FrmInvoiceReport();
        public static FrmUpdatePriceTier objPriceTier = new FrmUpdatePriceTier();
        public static FrmCusLogCall objCus = new FrmCusLogCall();
        public static FrmLogDetail objlog = new FrmLogDetail();
        public static FrmResetPassword objPassword = new FrmResetPassword();
        public static MDIParent objMDIParent = new MDIParent();
        public static FrmInvoiceProfitMaster objInvoiceProfit = new FrmInvoiceProfitMaster();
        public static FrmTrackingMaster objTracking = new FrmTrackingMaster();
        public static FrmTrackingInfoMaster objTrack = new FrmTrackingInfoMaster();
        public static NameValueCollection retMessage = new NameValueCollection();
        public static FrmSalesRepList ObjSalesRepList = new FrmSalesRepList();
        public static FrmSalesRepMaster ObjSalesRepMaster = new FrmSalesRepMaster();
        public static FrmUserTypeList ObjUserTypeList = new FrmUserTypeList();
        public static FrmLowestPriceItemList ObjLowestPriceItemList = new FrmLowestPriceItemList();
        public static FrmPurchaseCostUpdate ObjPurchaseCostUpdate = new FrmPurchaseCostUpdate();
        public static FrmWebPriceUpdate ObjWebPriceUpdate = new FrmWebPriceUpdate();
        public static FrmAgingSummary ObjAgingSummary = new FrmAgingSummary();
        public static FrmCustomerLogs ObjCustomerLogs = new FrmCustomerLogs();
        public static FrmInvoiceLogs ObjInvoiceLogs = new FrmInvoiceLogs();
        public static FrmManageTax ObjManageTax = new FrmManageTax();
        public static FrmSalesPriceUpdate ObjSalesPriceUpdate = new FrmSalesPriceUpdate();
        public static FrmQtyOnHandUpdate ObjQtyOnHandUpdate = new FrmQtyOnHandUpdate();
        public static FrmPriceTierUpdate ObjPriceTierUpdate = new FrmPriceTierUpdate();
        public static FrmComparativePrice ObjComparativePrice = new FrmComparativePrice();
        public static FrmAdminRequestList ObjAdminRequestList = new FrmAdminRequestList();
        public static FrmShippingOptions objShippingOptions = new FrmShippingOptions();
        public static FrmFromShippingAddress objFromShipping = new FrmFromShippingAddress();        
        public static FrmChat objChat = new FrmChat();        
        public static FrmTodayUnprintedInvoiceList objTodayInvoice = new FrmTodayUnprintedInvoiceList();
        public static FrmRequestCount objRequestCount = new FrmRequestCount();
        public static FrmCreditMemoRequest objCreditMemoRequest = new FrmCreditMemoRequest();
        public static FrmItemList ObjItemList = new FrmItemList();
        public static FrmItemMaster ObjItemMaster = new FrmItemMaster();
        public static FrmCustomerMaster ObjCustomerMaster = new FrmCustomerMaster();
        public static FrmCustomerCenter ObjCustomerCenter = new FrmCustomerCenter();
        public static FrmInvoiceMaster ObjInvoiceMaster = new FrmInvoiceMaster();
        public static FrmCreditMemo ObjCreditMemo = new FrmCreditMemo();
        public static FrmSearchInvoices ObjSearchInvoices = new FrmSearchInvoices();
        public static FrmUnShippedInvoiceList ObjUnShippedInvList = new FrmUnShippedInvoiceList();
        public static FrmEmailFormatList ObjEmailFormatList = new FrmEmailFormatList();
        public static FrmFedEx_UPSSettings objFedEx_UPSSettings = new FrmFedEx_UPSSettings();
        public static FrmFedExUPSShippingManager objUPS = new FrmFedExUPSShippingManager();
        public static FrmFedExShippingManager objFedEx = new FrmFedExShippingManager();
        public static FrmPaymentDetail objPayment = new FrmPaymentDetail();
        public static FrmReceivePayment objPaymentMaster = new FrmReceivePayment();
        public static FrmPrintInvoice objPrintInvoice = new FrmPrintInvoice();
        public static FrmPaymentList objViewDetail = new FrmPaymentList();
        public static FrmPrinterSetting objPrinterSetting = new FrmPrinterSetting();
        public static FrmPayPalDetails frmPayPalDetails = new FrmPayPalDetails();
        public static FrmPayPalMaster FrmPayPalMaster = new FrmPayPalMaster();
        public static FrmPayPalHistoryMaster FrmPayPalHistoryMaster = new FrmPayPalHistoryMaster();
        public static FrmPaymentAll FrmPaymentAll = new FrmPaymentAll();
        public static FrmPaymentMethod FrmPaymentMethod = new FrmPaymentMethod();
        public static FrmUPSSettings FrmUPSSettings = new FrmUPSSettings();
        public static FrmManuallySyncPrint FrmManuallySyncPrint = new FrmManuallySyncPrint();
        public static FrmLowestPriceList objLowestPriceList = new FrmLowestPriceList();
        public static FrmShipRequestPermission objShipRequestPermission = new FrmShipRequestPermission();
        public static FrmEditedInvoiceDetails objEditedInvoiceDetails = new FrmEditedInvoiceDetails();
        public static FrmApplyCreditToInvoice objApplyCreditToInvoice = new FrmApplyCreditToInvoice();
        public static FrmCreditCard objCreditCard = new FrmCreditCard();

        //princy
        public static FrmCustomerMessage objCustomerMessage = new FrmCustomerMessage();

        public static string TaxWithoutTax = "";
        public static string QBVersion = "";
        public static string QBCompanyFile = "";
        public static string Variable = "";
        public static int Flag = 0;
        public static int UserID = 0;
        public static string UserTypeID = "";
        public static string UserName = "";
        public static string Password = "";
        public static string UserType = "";
        public static string Name = "";
        public static int INVID = 0;
        public static int Retry = 0;
        public static string ActiveForm = "";
        public static DataTable dtQBMaster = new DataTable();
        public static string RefNumber = "";
        public static string ShipMethod = "";
        public static string CODAmount = "";
        public static decimal Weight = 0;
        public static Boolean COD = false;
        public static decimal OldQty =0;
        public static string InvoiceLogID ="";
        public static NameValueCollection retDates = new NameValueCollection();
        public static DataTable dtpayment = new DataTable();
        public static DataTable dtGetBatchID = new DataTable();
        public static DataTable dtGetTransactionID = new DataTable();
        public static DataTable dtAuthorizePayment = new DataTable();
        public static DataTable dtPayPalPayment = new DataTable();
        public static DataTable dtZellePayment = new DataTable();
        public static DataTable dtCashAppPayment = new DataTable();
        public static DataTable dtInvoice = new DataTable();


        public static string TrakingNo = "";

        public static string ShippingAddressNote = "";

        public static void WriteErrorLogs(string Message)
        {
            try
            {
                string Date = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
                StreamWriter sw = File.AppendText(Application.StartupPath + @"\Logs\" + Date + "-Log.txt");
                sw.WriteLine(DateTime.Now + "  " + Message);
                sw.Close();
                sw.Dispose();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Class:ClsCommon,Function :WriteErrorLogs. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public static void CloseQBSession()
        {
            try
            {
                if (ClsCommon.oSession != null)
                {
                    ClsCommon.retMessage = QBConnection.Close_QBConnection();
                    if (ClsCommon.retMessage["Status"].Contains("Error:"))
                        Console.WriteLine("Close QuickBook Session Error:" + ClsCommon.retMessage["Status"].ToString());
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Error: Close QuickBook Session. Message:" + ex.Message);
                Console.WriteLine("Error:" + ex.Message);
            }
        }
        public static void WritePaymentErrorLogs(string Message)
        {
            try
            {
                string Date = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
                StreamWriter sw = File.AppendText(Application.StartupPath + @"\PaymentLog\" + Date + "-Log.txt");
                sw.WriteLine(DateTime.Now + "  " + Message);
                sw.Close();
                sw.Dispose();
            }
            catch (Exception ex)
            {
                ClsCommon.WritePaymentErrorLogs("Class:ClsCommon,Function :WriteErrorLogs. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
        public static string ConvertDate_PaypalFormat(string Date)
        {
            string strDate = "";
            try
            {
                DateTime dt = Convert.ToDateTime(Date);
                //strDate = dt.Year.ToString() + "-" + (dt.Month.ToString().Length == 1 ? "0" + dt.Month.ToString() : dt.Month.ToString()) + "-" + (dt.Day.ToString().Length == 1 ? "0" + dt.Day.ToString() : dt.Day.ToString()) + "T" + (dt.Hour.ToString().Length == 1 ? "0" + dt.Hour.ToString() : dt.Hour.ToString()) + ":" + (dt.Minute.ToString().Length == 1 ? "0" + dt.Minute.ToString() : dt.Minute.ToString()) + ":" + (dt.Second.ToString().Length == 1 ? "0" + dt.Second.ToString() : dt.Second.ToString()) + "-0000";
                strDate = dt.Year.ToString() + "-" + (dt.Month.ToString().Length == 1 ? "0" + dt.Month.ToString() : dt.Month.ToString()) + "-" + (dt.Day.ToString().Length == 1 ? "0" + dt.Day.ToString() : dt.Day.ToString()) + "T00:00:00-0000";
            }
            catch (Exception ex)
            {
                string[] Data = Date.Split('-');
                strDate = Data[2].ToString() + "-" + Data[0].ToString() + "-" + Data[1].ToString();

            }
            return strDate;
        }

        public static void SetPaypalAuthTokenBook(string PaypalAuthTokenBook)
        {
            Program.mySetting.PaypalAuthToken = PaypalAuthTokenBook;
            Program.mySetting.Save();
        }

        public static string GetPaypalAuthTokenBook()
        {
            return Program.mySetting.PaypalAuthToken;
        }

        public static Boolean FunctionVisibility(string SubMenuName, string MenuName)
        {
            Boolean IsValid = false;
            try
            {
                if (ClsCommon.UserType != "Admin" && ClsCommon.UserType != "admin")
                {
                    DataTable dtUserAccess = new BALUserSubMenuAccess().SelectByMenuName(new BOLUserSubMenuAccess() { UserID = ClsCommon.UserID, MenuName = MenuName });
                    if (dtUserAccess.Rows.Count > 0)
                    {
                        DataRow[] row = dtUserAccess.Select("SubMenuName='" + SubMenuName + "'");
                        if (row.Length > 0)
                            IsValid = true;
                        else
                            IsValid = false;
                    }
                    else
                        IsValid = false;
                }
                else
                    IsValid = true;
            }
            catch (Exception ex)
            {
                IsValid = false;
                ClsCommon.WriteErrorLogs("Class:ClsCommon,Function :FunctionVisibility. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
            return IsValid;
        }

        public static string CheckQBResponse_Error(string QBResponse, string XPath)
        {
            string strMesage = "";
            try
            {
                XmlDocument oDoc = new XmlDocument();
                oDoc.LoadXml(QBResponse);
                XmlNodeList oNode = oDoc.SelectNodes(XPath);//"QBXML//QBXMLMsgsRs//BillAddRs");
                XmlAttributeCollection oAttribute = oNode[0].Attributes;
                if (oAttribute["statusSeverity"].Value == "Error")
                {
                    strMesage = " Quick Book Error:" + oAttribute["statusMessage"].Value;
                }
            }
            catch (Exception ex)
            {
                strMesage = "Error:" + ex.Message;
            }
            return strMesage;
        }
        public static string ConvertOnlyDate_QBFormat(string Date)

        {
            string strDate = "";
            try
            {
                //DateTime dt = Convert.ToDateTime(Date.ToString());
                //strDate = dt.Year.ToString() + "-" + (dt.Month.ToString().Length == 1 ? "0" + dt.Month.ToString() : dt.Month.ToString()) + "-" + (dt.Day.ToString().Length == 1 ? "0" + dt.Day.ToString() : dt.Day.ToString()) + "T" + (dt.Hour.ToString().Length == 1 ? "0" + dt.Hour.ToString() : dt.Hour.ToString()) + ":" + (dt.Minute.ToString().Length == 1 ? "0" + dt.Minute.ToString() : dt.Minute.ToString()) + ":" + (dt.Second.ToString().Length == 1 ? "0" + dt.Second.ToString() : dt.Second.ToString());

                DateTime dt = Convert.ToDateTime(Date);
                strDate = dt.Year.ToString() + "-" + (dt.Month.ToString().Length == 1 ? "0" + dt.Month.ToString() : dt.Month.ToString()) + "-" + (dt.Day.ToString().Length == 1 ? "0" + dt.Day.ToString() : dt.Day.ToString());


                //2019 - 03 - 27T15: 28:32 + 05:30
                // 2019 - 04 - 28T15: 10:19 + 05:30
                //27T15: 30:04 + 05:30
            }
            catch (Exception ex)
            {
                string[] Data = Date.Split('/');
                //strDate = Data[2].ToString() + "-" + Data[0].ToString() + "-" + Data[1].ToString();
                strDate = Data[2].ToString() + "-" + (Data[0].ToString().Length == 1 ? "0" + Data[0].ToString() : Data[0].ToString()) + "-" + (Data[1].ToString().Length == 1 ? "0" + Data[1].ToString() : Data[1].ToString());

                //strDate = Data[1].ToString() + "-" + Data[0].ToString() + "-" + Data[2].ToString();
            }
            return strDate;
        }

        public static void Clear_Intialize_Table(string Type)
        {


            switch (Type)
            {
                case "COM":
                    dtQBMaster = new DataTable();                    
                    dtQBMaster.Columns.Add(new DataColumn("Name"));
                    dtQBMaster.Columns.Add(new DataColumn("Address"));                    
                    break;
                case "INVOICE":
                    dtInvoice = new DataTable();
                    dtInvoice.Columns.Add(new DataColumn("TxnID"));
                    dtInvoice.Columns.Add(new DataColumn("TxnNumber"));
                    dtInvoice.Columns.Add(new DataColumn("CustomerRefFullName"));
                    dtInvoice.Columns.Add(new DataColumn("ClassRefFullName"));
                    dtInvoice.Columns.Add(new DataColumn("ARAccountRefFullName"));
                    dtInvoice.Columns.Add(new DataColumn("TemplateRefFullName"));
                    dtInvoice.Columns.Add(new DataColumn("TxnDate"));
                    dtInvoice.Columns.Add(new DataColumn("RefNumber"));
                    dtInvoice.Columns.Add(new DataColumn("Addr1"));
                    dtInvoice.Columns.Add(new DataColumn("Addr2"));
                    dtInvoice.Columns.Add(new DataColumn("Addr3"));
                    dtInvoice.Columns.Add(new DataColumn("Addr4"));
                    dtInvoice.Columns.Add(new DataColumn("Addr5"));
                    dtInvoice.Columns.Add(new DataColumn("City"));
                    dtInvoice.Columns.Add(new DataColumn("State"));
                    dtInvoice.Columns.Add(new DataColumn("PostalCode"));
                    dtInvoice.Columns.Add(new DataColumn("Country"));
                    dtInvoice.Columns.Add(new DataColumn("ShipAddr1"));
                    dtInvoice.Columns.Add(new DataColumn("ShipAddr2"));
                    dtInvoice.Columns.Add(new DataColumn("ShipAddr3"));
                    dtInvoice.Columns.Add(new DataColumn("ShipAddr4"));
                    dtInvoice.Columns.Add(new DataColumn("ShipAddr5"));
                    dtInvoice.Columns.Add(new DataColumn("ShipCity"));
                    dtInvoice.Columns.Add(new DataColumn("ShipState"));
                    dtInvoice.Columns.Add(new DataColumn("ShipPostalCode"));
                    dtInvoice.Columns.Add(new DataColumn("ShipCountry"));
                    dtInvoice.Columns.Add(new DataColumn("IsPending"));
                    dtInvoice.Columns.Add(new DataColumn("IsFinanceCharge"));
                    dtInvoice.Columns.Add(new DataColumn("PONumber"));
                    dtInvoice.Columns.Add(new DataColumn("TermsFullName"));
                    dtInvoice.Columns.Add(new DataColumn("DueDate"));
                    dtInvoice.Columns.Add(new DataColumn("SalesRepFullName"));
                    dtInvoice.Columns.Add(new DataColumn("FOB"));
                    dtInvoice.Columns.Add(new DataColumn("shipDate"));
                    dtInvoice.Columns.Add(new DataColumn("ShipMethodFullName"));
                    dtInvoice.Columns.Add(new DataColumn("Memo"));
                    dtInvoice.Columns.Add(new DataColumn("ItemSalesTaxFullName"));
                    dtInvoice.Columns.Add(new DataColumn("SalesTaxPercentage"));
                    dtInvoice.Columns.Add(new DataColumn("AppliedAmount"));
                    dtInvoice.Columns.Add(new DataColumn("BalanceRemaining"));
                    dtInvoice.Columns.Add(new DataColumn("CurrencyFullName"));
                    dtInvoice.Columns.Add(new DataColumn("ExchangeRate"));
                    dtInvoice.Columns.Add(new DataColumn("BalanceRemainingInHomeCurrency"));
                    dtInvoice.Columns.Add(new DataColumn("IsPaid"));
                    dtInvoice.Columns.Add(new DataColumn("CustomerMsgFullName"));
                    dtInvoice.Columns.Add(new DataColumn("IsToBePrinted"));
                    dtInvoice.Columns.Add(new DataColumn("IsToBeEmailed"));
                    dtInvoice.Columns.Add(new DataColumn("IsTaxIncluded"));
                    dtInvoice.Columns.Add(new DataColumn("CustomerSalesTaxcodeFullName"));
                    dtInvoice.Columns.Add(new DataColumn("SuggestedDiscountAmount"));
                    dtInvoice.Columns.Add(new DataColumn("SuggestedDiscountDate"));
                    dtInvoice.Columns.Add(new DataColumn("LinkedTxnID"));
                    dtInvoice.Columns.Add(new DataColumn("TxnLineID"));
                    dtInvoice.Columns.Add(new DataColumn("ItemRefFullName"));
                    dtInvoice.Columns.Add(new DataColumn("Desc"));
                    dtInvoice.Columns.Add(new DataColumn("Quantity"));
                    dtInvoice.Columns.Add(new DataColumn("UOM"));
                    dtInvoice.Columns.Add(new DataColumn("OverrideUOMFullName"));
                    dtInvoice.Columns.Add(new DataColumn("Rate"));
                    dtInvoice.Columns.Add(new DataColumn("LineClassRefFullName"));
                    dtInvoice.Columns.Add(new DataColumn("Amount"));
                    dtInvoice.Columns.Add(new DataColumn("InventorySiteRefFullName"));
                    dtInvoice.Columns.Add(new DataColumn("SerialNumber"));
                    dtInvoice.Columns.Add(new DataColumn("LotNumber"));
                    dtInvoice.Columns.Add(new DataColumn("ServiceDate"));
                    dtInvoice.Columns.Add(new DataColumn("SalesTaxCodeFullName"));
                    dtInvoice.Columns.Add(new DataColumn("Other"));
                    dtInvoice.Columns.Add(new DataColumn("Other1"));
                    dtInvoice.Columns.Add(new DataColumn("Other2"));
                    dtInvoice.Columns.Add(new DataColumn("GroupTxnLineID"));
                    dtInvoice.Columns.Add(new DataColumn("GroupItemFullName"));
                    dtInvoice.Columns.Add(new DataColumn("GroupDesc"));
                    dtInvoice.Columns.Add(new DataColumn("GroupQuantity"));
                    dtInvoice.Columns.Add(new DataColumn("GroupLineUOM"));
                    dtInvoice.Columns.Add(new DataColumn("GroupLineOverrideUOM"));
                    dtInvoice.Columns.Add(new DataColumn("GroupLineClassRefFullName"));
                    dtInvoice.Columns.Add(new DataColumn("GroupLineRate"));
                    dtInvoice.Columns.Add(new DataColumn("GroupLineAmount"));
                    dtInvoice.Columns.Add(new DataColumn("GroupLineServiceDate"));
                    dtInvoice.Columns.Add(new DataColumn("GroupLineSalesTaxCodeFullName"));
                    break;
            }
        }
    }
}
