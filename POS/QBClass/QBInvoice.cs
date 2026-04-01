
using POS.HelperClass;
using POS.QBClass;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Xml;

namespace SalesPOS.QBClass
{
    public static class QBInvoice
    {
        static NameValueCollection dicResult = new NameValueCollection();
        static string QBRequest = "";
        static string QBResponse = "";
        static string Message = "";

        public static void ClearVariables()
        {
            QBRequest = "";
            QBResponse = "";
            Message = "";
        }

        public static NameValueCollection Retrieve_QBInvoice_Full(NameValueCollection InvoiceData)
        {
            ClearVariables();
            try
            {
                QBRequest = GenerateXmlRequest_RetrieveEstimate_Full(InvoiceData);
                QBResponse = QBConnection.Process_QBRequest(QBRequest);
                Message = ClsCommon.CheckQBResponse_Error(QBResponse, "QBXML//QBXMLMsgsRs//InvoiceQueryRs");
                dicResult.Clear();
                if (Message.Contains("Error:") == false)
                {
                    dicResult = ExtractQBResponse_Full(QBResponse, "InvoiceQueryRs", "");
                }
                else
                {
                    dicResult.Add("Status", Message);
                }
            }
            catch (Exception ex)
            {
                dicResult.Add("Status", "Error :" + ex.Message);
            }
            return dicResult;
        }

        private static string GenerateXmlRequest_RetrieveEstimate_Full(NameValueCollection InvoiceData)
        {
            StringBuilder sbRequest = new StringBuilder();
            sbRequest.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            sbRequest.Append("<?qbxml version=\"" + ClsCommon.QBVersion + "\"?>");
            sbRequest.Append("<QBXML>");
            sbRequest.Append("<QBXMLMsgsRq onError=\"continueOnError\">");
            sbRequest.Append("<InvoiceQueryRq requestID = \"0\">");
            if (InvoiceData["FromModifiedDate"] != null)
            {
                sbRequest.Append("<ModifiedDateRangeFilter>");
                if (InvoiceData["FromModifiedDate"] != null)
                    sbRequest.Append("<FromModifiedDate>" + InvoiceData["FromModifiedDate"] + "</FromModifiedDate>");
                if (InvoiceData["ToModifiedDate"] != null)
                    sbRequest.Append("<ToModifiedDate>" + InvoiceData["ToModifiedDate"] + "</ToModifiedDate>");

                sbRequest.Append("</ModifiedDateRangeFilter>");
            }
            sbRequest.Append("<IncludeLineItems>1</IncludeLineItems>");
            sbRequest.Append("<IncludeLinkedTxns>1</IncludeLinkedTxns>");
            sbRequest.Append("<OwnerID>0</OwnerID>");
            sbRequest.Append("</InvoiceQueryRq>");
            sbRequest.Append("</QBXMLMsgsRq>");
            sbRequest.Append("</QBXML>");
            return sbRequest.ToString();
        }

        private static NameValueCollection ExtractQBResponse_Full(string QbResponse, string Path, string InvoiceID)
        {
            try
            {
                ClsCommon.Clear_Intialize_Table("INVOICE");
                XmlDocument oDoc = new XmlDocument();
                oDoc.LoadXml(QBResponse);

                XmlNodeList oList = oDoc.SelectNodes("QBXML//QBXMLMsgsRs//" + Path + "//InvoiceRet");
                if (oList.Count > 0)
                {
                    for (int i = 0; i < oList.Count; i++)
                    {
                        XmlNode oNode = oList[i];
                        XmlNodeList oInnerList = oNode.SelectNodes("InvoiceLineRet");
                        foreach (XmlNode oInner in oInnerList)
                        {
                            DataRow dr = ClsCommon.dtInvoice.NewRow();
                            dr["TxnID"] = (oNode["TxnID"] == null ? "" : oNode["TxnID"].InnerXml);
                            dr["TxnNumber"] = (oNode["TxnNumber"] == null ? "" : oNode["TxnNumber"].InnerXml);
                            if (oNode["CustomerRef"] != null)
                            {
                                //dr["CustomerListID"] = (oNode["CustomerRef"].SelectSingleNode("ListID") == null ? "" : oNode["CustomerRef"].SelectSingleNode("ListID").InnerXml);
                                dr["CustomerRefFullName"] = (oNode["CustomerRef"].SelectSingleNode("FullName") == null ? "" : oNode["CustomerRef"].SelectSingleNode("FullName").InnerXml);
                            }
                            if (oNode["ClassRef"] != null)
                            {
                                //dr["ClassListID"] = (oNode["ClassRef"].SelectSingleNode("ListID") == null ? "" : oNode["ClassRef"].SelectSingleNode("ListID").InnerXml);
                                dr["ClassRefFullName"] = (oNode["ClassRef"].SelectSingleNode("FullName") == null ? "" : oNode["ClassRef"].SelectSingleNode("FullName").InnerXml);
                            }
                            if (oNode["ARAccountRef"] != null)
                            {
                                //dr["ARAccountListID"] = (oNode["ARAccountRef"].SelectSingleNode("ListID") == null ? "" : oNode["ARAccountRef"].SelectSingleNode("ListID").InnerXml);
                                dr["ARAccountRefFullName"] = (oNode["ARAccountRef"].SelectSingleNode("FullName") == null ? "" : oNode["ARAccountRef"].SelectSingleNode("FullName").InnerXml);
                            }

                            if (oNode["TemplateRef"] != null)
                            {
                                //dr["TemplateListID"] = (oNode["TemplateRef"].SelectSingleNode("ListID") == null ? "" : oNode["TemplateRef"].SelectSingleNode("ListID").InnerXml);
                                dr["TemplateRefFullName"] = (oNode["TemplateRef"].SelectSingleNode("FullName") == null ? "" : oNode["TemplateRef"].SelectSingleNode("FullName").InnerXml);
                            }
                            dr["TxnDate"] = (oNode["TxnDate"] == null ? "" : oNode["TxnDate"].InnerXml);
                            dr["RefNumber"] = (oNode["RefNumber"] == null ? "" : oNode["RefNumber"].InnerXml);
                            if (oNode["BillAddress"] != null)
                            {
                                XmlNode oBill = oNode["BillAddress"];

                                dr["Addr1"] = (oBill["Addr1"] == null ? "" : oBill["Addr1"].InnerXml.ToString().Replace("&amp;", "&").Replace("&apos;", "'"));
                                dr["Addr2"] = (oBill["Addr2"] == null ? "" : oBill["Addr2"].InnerXml.ToString().Replace("&amp;", "&").Replace("&apos;", "'"));
                                dr["Addr3"] = (oBill["Addr3"] == null ? "" : oBill["Addr3"].InnerXml.ToString().Replace("&amp;", "&").Replace("&apos;", "'"));
                                dr["Addr4"] = (oBill["Addr4"] == null ? "" : oBill["Addr4"].InnerXml.ToString().Replace("&amp;", "&").Replace("&apos;", "'"));
                                dr["Addr5"] = (oBill["Addr5"] == null ? "" : oBill["Addr5"].InnerXml.ToString().Replace("&amp;", "&").Replace("&apos;", "'"));
                                dr["City"] = (oBill["City"] == null ? "" : oBill["City"].InnerXml.ToString().Replace("&amp;", "&").Replace("&apos;", "'"));
                                dr["State"] = (oBill["State"] == null ? "" : oBill["State"].InnerXml.ToString().Replace("&amp;", "&").Replace("&apos;", "'"));
                                dr["PostalCode"] = (oBill["PostalCode"] == null ? "" : oBill["PostalCode"].InnerXml);
                                dr["Country"] = (oBill["Country"] == null ? "" : oBill["Country"].InnerXml.ToString().Replace("&amp;", "&").Replace("&apos;", "'"));
                            }
                            if (oNode["ShipAddress"] != null)
                            {
                                XmlNode oBill = oNode["ShipAddress"];

                                dr["ShipAddr1"] = (oBill["Addr1"] == null ? "" : oBill["Addr1"].InnerXml.ToString().Replace("&amp;", "&").Replace("&apos;", "'"));
                                dr["ShipAddr2"] = (oBill["Addr2"] == null ? "" : oBill["Addr2"].InnerXml.ToString().Replace("&amp;", "&").Replace("&apos;", "'"));
                                dr["ShipAddr3"] = (oBill["Addr3"] == null ? "" : oBill["Addr3"].InnerXml.ToString().Replace("&amp;", "&").Replace("&apos;", "'"));
                                dr["ShipAddr4"] = (oBill["Addr4"] == null ? "" : oBill["Addr4"].InnerXml.ToString().Replace("&amp;", "&").Replace("&apos;", "'"));
                                dr["ShipAddr5"] = (oBill["Addr5"] == null ? "" : oBill["Addr5"].InnerXml.ToString().Replace("&amp;", "&").Replace("&apos;", "'"));
                                dr["ShipCity"] = (oBill["City"] == null ? "" : oBill["City"].InnerXml.ToString().Replace("&amp;", "&").Replace("&apos;", "'"));
                                dr["ShipState"] = (oBill["State"] == null ? "" : oBill["State"].InnerXml.ToString().Replace("&amp;", "&").Replace("&apos;", "'"));
                                dr["ShipPostalCode"] = (oBill["PostalCode"] == null ? "" : oBill["PostalCode"].InnerXml);
                                dr["ShipCountry"] = (oBill["Country"] == null ? "" : oBill["Country"].InnerXml.ToString().Replace("&amp;", "&").Replace("&apos;", "'"));
                            }
                            dr["IsPending"] = (oNode["IsPending"] == null ? "" : oNode["IsPending"].InnerXml);
                            dr["IsFinanceCharge"] = (oNode["IsFinanceCharge"] == null ? "" : oNode["IsFinanceCharge"].InnerXml);
                            dr["PONumber"] = (oNode["PONumber"] == null ? "" : oNode["PONumber"].InnerXml);
                            if (oNode["TermsRef"] != null)
                            {
                                //dr["TermsListID"] = (oNode["TermsRef"].SelectSingleNode("ListID") == null ? "" : oNode["TermsRef"].SelectSingleNode("ListID").InnerXml);
                                dr["TermsFullName"] = (oNode["TermsRef"].SelectSingleNode("FullName") == null ? "" : oNode["TermsRef"].SelectSingleNode("FullName").InnerXml);
                            }
                            dr["DueDate"] = (oNode["DueDate"] == null ? "" : oNode["DueDate"].InnerXml);
                            if (oNode["SalesRepRef"] != null)
                            {
                                //dr["SalesRepID"] = (oNode["SalesRepRef"].SelectSingleNode("ListID") == null ? "" : oNode["SalesRepRef"].SelectSingleNode("ListID").InnerXml);
                                dr["SalesRepFullName"] = (oNode["SalesRepRef"].SelectSingleNode("FullName") == null ? "" : oNode["SalesRepRef"].SelectSingleNode("FullName").InnerXml);
                            }
                            dr["FOB"] = (oNode["FOB"] == null ? "" : oNode["FOB"].InnerXml);
                            dr["shipDate"] = (oNode["ShipDate"] == null ? "" : oNode["ShipDate"].InnerXml);
                            if (oNode["ShipMethodRef"] != null)
                            {
                                //dr["ShipMethodID"] = (oNode["ShipMethodRef"].SelectSingleNode("ListID") == null ? "" : oNode["ShipMethodRef"].SelectSingleNode("ListID").InnerXml);
                                dr["ShipMethodFullName"] = (oNode["ShipMethodRef"].SelectSingleNode("FullName") == null ? "" : oNode["ShipMethodRef"].SelectSingleNode("FullName").InnerXml);
                            }
                            dr["Memo"] = (oNode["Memo"] == null ? "" : oNode["Memo"].InnerXml);
                            if (oNode["ItemSalesTaxRef"] != null)
                            {
                                //dr["ItemSalesTaxID"] = (oNode["ItemSalesTaxRef"].SelectSingleNode("ListID") == null ? "" : oNode["ItemSalesTaxRef"].SelectSingleNode("ListID").InnerXml);
                                dr["ItemSalesTaxFullName"] = (oNode["ItemSalesTaxRef"].SelectSingleNode("FullName") == null ? "" : oNode["ItemSalesTaxRef"].SelectSingleNode("FullName").InnerXml);
                            }
                            dr["SalesTaxPercentage"] = (oNode["SalesTaxPercentage"] == null ? "0.00" : oNode["SalesTaxPercentage"].InnerXml);
                            dr["AppliedAmount"] = (oNode["AppliedAmount"] == null ? "0" : oNode["AppliedAmount"].InnerXml);
                            dr["BalanceRemaining"] = (oNode["BalanceRemaining"] == null ? "0" : oNode["BalanceRemaining"].InnerXml);
                            if (oNode["CurrencyRef"] != null)
                            {
                                //dr["ARAccountListID"] = (oNode["ARAccountRef"].SelectSingleNode("ListID") == null ? "" : oNode["ARAccountRef"].SelectSingleNode("ListID").InnerXml);
                                dr["CurrencyFullName"] = (oNode["CurrencyRef"].SelectSingleNode("FullName") == null ? "" : oNode["CurrencyRef"].SelectSingleNode("FullName").InnerXml);
                            }
                            dr["ExchangeRate"] = (oNode["ExchangeRate"] == null ? "" : oNode["ExchangeRate"].InnerXml);
                            dr["BalanceRemainingInHomeCurrency"] = (oNode["BalanceRemainingInHomeCurrency"] == null ? "" : oNode["BalanceRemainingInHomeCurrency"].InnerXml);
                            dr["IsPaid"] = (oNode["IsPaid"] == null ? "" : oNode["IsPaid"].InnerXml);
                            if (oNode["CustomerMsgRef"] != null)
                            {
                                //dr["CustomerMsgID"] = (oNode["CustomerMsgRef"].SelectSingleNode("ListID") == null ? "" : oNode["CustomerMsgRef"].SelectSingleNode("ListID").InnerXml);
                                dr["CustomerMsgFullName"] = (oNode["CustomerMsgRef"].SelectSingleNode("FullName") == null ? "" : oNode["CustomerMsgRef"].SelectSingleNode("FullName").InnerXml);
                            }
                            dr["IsToBePrinted"] = (oNode["IsToBePrinted"] == null ? "" : oNode["IsToBePrinted"].InnerXml);
                            dr["IsToBeEmailed"] = (oNode["IsToBeEmailed"] == null ? "" : oNode["IsToBeEmailed"].InnerXml);
                            if (oNode["CustomerSalesTaxCodeRef"] != null)
                            {
                                //dr["CustomerSalesTaxCodeID"] = (oNode["CustomerSalesTaxCodeRef"].SelectSingleNode("ListID") == null ? "" : oNode["CustomerSalesTaxCodeRef"].SelectSingleNode("ListID").InnerXml);
                                dr["CustomerSalesTaxcodeFullName"] = (oNode["CustomerSalesTaxCodeRef"].SelectSingleNode("FullName") == null ? "" : oNode["CustomerSalesTaxCodeRef"].SelectSingleNode("FullName").InnerXml);
                            }
                            dr["SuggestedDiscountAmount"] = (oNode["SuggestedDiscountAmount"] == null ? "0" : oNode["SuggestedDiscountAmount"].InnerXml);
                            dr["SuggestedDiscountDate"] = (oNode["SuggestedDiscountDate"] == null ? "0" : oNode["SuggestedDiscountDate"].InnerXml);

                            if (oNode["LinkedTxn"] != null)
                            {
                                //dr["CustomerSalesTaxCodeID"] = (oNode["CustomerSalesTaxCodeRef"].SelectSingleNode("ListID") == null ? "" : oNode["CustomerSalesTaxCodeRef"].SelectSingleNode("ListID").InnerXml);
                                dr["LinkedTxnID"] = (oNode["LinkedTxn"].SelectSingleNode("TxnID") == null ? "" : oNode["LinkedTxn"].SelectSingleNode("TxnID").InnerXml);
                            }


                            //DataRow drInner = ClsCommon.dtInvoice.NewRow();
                            //drInner["TxnID"] = (oNode["TxnID"] == null ? "" : oNode["TxnID"].InnerXml);
                            dr["TxnLineID"] = (oInner["TxnLineID"] == null ? "" : oInner["TxnLineID"].InnerXml);
                            if (oInner["ItemRef"] != null)
                            {
                                //drInner["ItemListID"] = (oInner["ItemRef"].SelectSingleNode("ListID") == null ? "" : oInner["ItemRef"].SelectSingleNode("ListID").InnerXml);
                                dr["ItemRefFullName"] = (oInner["ItemRef"].SelectSingleNode("FullName") == null ? "" : oInner["ItemRef"].SelectSingleNode("FullName").InnerXml);
                            }
                            dr["Desc"] = (oInner["Desc"] == null ? "" : oInner["Desc"].InnerXml);
                            dr["Quantity"] = (oInner["Quantity"] == null ? "0" : oInner["Quantity"].InnerXml);
                            dr["UOM"] = (oInner["UnitOfMeasure"] == null ? "" : oInner["UnitOfMeasure"].InnerXml);
                            if (oInner["OverrideUOMSetRef"] != null)
                            {
                                dr["OverrideUOMFullName"] = (oInner["OverrideUOMSetRef"].SelectSingleNode("FullName") == null ? "" : oInner["OverrideUOMSetRef"].SelectSingleNode("FullName").InnerXml);
                            }
                            dr["Rate"] = (oInner["Rate"] == null ? "0.00" : oInner["Rate"].InnerXml);
                            if (oInner["ClassRef"] != null)
                            {
                                //drInner["ClassListID"] = (oInner["ClassRef"].SelectSingleNode("ListID") == null ? "0" : oInner["ClassRef"].SelectSingleNode("ListID").InnerXml);
                                dr["LineClassRefFullName"] = (oInner["ClassRef"].SelectSingleNode("FullName") == null ? "" : oInner["ClassRef"].SelectSingleNode("FullName").InnerXml);
                            }
                            dr["Amount"] = (oInner["Amount"] == null ? "0.00" : oInner["Amount"].InnerXml);
                            if (oInner["InventorySiteRef"] != null)
                            {
                                //drInner["SiteID"] = (oInner["InventorySiteRef"].SelectSingleNode("ListID") == null ? "0.00" : oInner["InventorySiteRef"].SelectSingleNode("ListID").InnerXml);
                                dr["InventorySiteRefFullName"] = (oInner["InventorySiteRef"].SelectSingleNode("FullName") == null ? "" : oInner["InventorySiteRef"].SelectSingleNode("FullName").InnerXml);
                            }
                            dr["SerialNumber"] = (oInner["SerialNumber"] == null ? "" : oInner["SerialNumber"].InnerXml);
                            dr["LotNumber"] = (oInner["LotNumber"] == null ? "" : oInner["LotNumber"].InnerXml);
                            dr["ServiceDate"] = (oInner["ServiceDate"] == null ? "" : oInner["ServiceDate"].InnerXml);
                            if (oInner["SalesTaxCodeRef"] != null)
                            {
                                dr["SalesTaxCodeFullName"] = (oInner["SalesTaxCodeRef"].SelectSingleNode("FullName") == null ? "" : oInner["SalesTaxCodeRef"].SelectSingleNode("FullName").InnerXml);
                            }
                            dr["Other1"] = (oInner["Other1"] == null ? "" : oInner["Other1"].InnerXml);
                            dr["Other2"] = (oInner["Other2"] == null ? "" : oInner["Other2"].InnerXml);
                            //ClsCommon.dtInvoice.Rows.Add(drInner);
                            ClsCommon.dtInvoice.Rows.Add(dr);

                        }

                        //XmlNodeList oInnerList1 = oNode.SelectNodes("InvoiceLineGroupRet");
                        //foreach (XmlNode oInner in oInnerList1)
                        //{
                        //    DataRow drInner = ClsCommon.dtInvoice.NewRow();
                        //    //drInner["TxnID"] = (oNode["TxnID"] == null ? "" : oNode["TxnID"].InnerXml);
                        //    drInner["GroupTxnLineID"] = (oNode["TxnLineID"] == null ? "" : oNode["TxnLineID"].InnerXml);
                        //    if (oInner["ItemGroupRef"] != null)
                        //    {
                        //        //drInner["ItemListID"] = (oInner["ItemRef"].SelectSingleNode("ListID") == null ? "" : oInner["ItemRef"].SelectSingleNode("ListID").InnerXml);
                        //        drInner["GroupItemFullName"] = (oInner["ItemGroupRef"].SelectSingleNode("FullName") == null ? "" : oInner["ItemGroupRef"].SelectSingleNode("FullName").InnerXml);
                        //    }
                        //    drInner["GroupDesc"] = (oInner["Desc"] == null ? "" : oInner["Desc"].InnerXml);
                        //    drInner["GroupQuantity"] = (oInner["Quantity"] == null ? "0" : oInner["Quantity"].InnerXml);
                        //    drInner["GroupUOM"] = (oInner["UnitOfMeasure"] == null ? "" : oInner["UnitOfMeasure"].InnerXml);
                        //    drInner["IsPrintItemsInGroup"] = (oInner["IsPrintItemsInGroup"] == null ? "" : oInner["IsPrintItemsInGroup"].InnerXml);
                        //    if (oInner["InvoiceLineRet"] != null)
                        //    {
                        //        drInner["GroupLineTxnLineID"] = (oInner["InvoiceLineRet"].SelectSingleNode("TxnLineID") == null ? "" : oInner["InvoiceLineRet"].SelectSingleNode("TxnLineID").InnerXml);
                        //        if (oInner["ItemRef"] != null)
                        //        {
                        //            drInner["GroupLineItemFullName"] = (oInner["ItemRef"].SelectSingleNode("FullName") == null ? "" : oInner["ItemRef"].SelectSingleNode("FullName").InnerXml);
                        //        }
                        //    }
                        //    drInner["GroupLineDesc"] = (oInner["Desc"] == null ? "" : oInner["Desc"].InnerXml);
                        //    drInner["GroupLineQuantity"] = (oInner["Quantity"] == null ? "" : oInner["Quantity"].InnerXml);
                        //    drInner["GroupLineUOM"] = (oInner["UnitOfMeasure"] == null ? "" : oInner["UnitOfMeasure"].InnerXml);
                        //    if (oInner["OverrideUOMSetRef"] != null)
                        //    {
                        //        drInner["GroupLineOverrideUOM"] = (oInner["OverrideUOMSetRef"].SelectSingleNode("FullName") == null ? "" : oInner["OverrideUOMSetRef"].SelectSingleNode("FullName").InnerXml);
                        //    }
                        //    if (oInner["ClassRef"] != null)
                        //    {
                        //        //drInner["ClassListID"] = (oInner["ClassRef"].SelectSingleNode("ListID") == null ? "0" : oInner["ClassRef"].SelectSingleNode("ListID").InnerXml);
                        //        drInner["GroupLineClassRefFullName"] = (oInner["ClassRef"].SelectSingleNode("FullName") == null ? "" : oInner["ClassRef"].SelectSingleNode("FullName").InnerXml);
                        //    }
                        //    drInner["GroupLineRate"] = (oInner["Rate"] == null ? "0.00" : oInner["Rate"].InnerXml);
                        //    drInner["GroupLineAmount"] = (oInner["Amount"] == null ? "0.00" : oInner["Amount"].InnerXml);
                        //    drInner["GroupLineServiceDate"] = (oInner["ServiceDate"] == null ? "" : oInner["ServiceDate"].InnerXml);
                        //    if (oInner["SalesTaxCodeRef"] != null)
                        //    {
                        //        drInner["GroupLineSalesTaxCodeFullName"] = (oInner["SalesTaxCodeRef"].SelectSingleNode("FullName") == null ? "" : oInner["SalesTaxCodeRef"].SelectSingleNode("FullName").InnerXml);
                        //    }
                        //    ClsCommon.dtInvoice.Rows.Add(drInner);
                        //}

                    }
                    dicResult.Add("Status", "Find Invoice");
                }
                else
                {
                    dicResult.Add("Status", "Error: No Invoice Found");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Class:QBInvoice,Function :ExtractQBResponse_Full. Message:" + ex.Message);
                Console.WriteLine("Error:" + ex.Message);
            }
            return dicResult;
        }


    }
}
