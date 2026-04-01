using POS.HelperClass;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Xml;

namespace POS.QBClass
{
    public static class QBCompany
    {
        static NameValueCollection dicResult = new NameValueCollection();
        static string QBRequest = "";
        static string QBResponse = "";
        static string Message = "";

        private static void ClearVariables()
        {
            dicResult.Clear();
            QBRequest = "";
            QBResponse = "";
            Message = "";
        }

        public static NameValueCollection Get_QBCompany()
        {
            ClearVariables();
            try
            {
                QBRequest = GenerateXmlRequest_GetAccounts();
                QBResponse = QBConnection.Process_QBRequest(QBRequest);
                Message = ClsCommon.CheckQBResponse_Error(QBResponse, "QBXML//QBXMLMsgsRs//CompanyQueryRs");
                if (Message.Contains("Error:") == false)
                {
                    dicResult = ExtractQBResponse_Full(QBResponse, "CompanyQueryRs");
                }
                else
                    dicResult.Add("Status", Message);
            }
            catch (Exception ex)
            {
                dicResult.Add("Status", "Error :" + ex.Message);
            }
            return dicResult;
        }

        private static string GenerateXmlRequest_GetAccounts()
        {
            StringBuilder sbRequest = new StringBuilder();
            sbRequest.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            sbRequest.Append("<?qbxml version=\"" + "13.0" + "\"?>");
            sbRequest.Append("<QBXML>");
            sbRequest.Append("<QBXMLMsgsRq onError=\"continueOnError\">");
            sbRequest.Append("<CompanyQueryRq requestID = \"0\"/>");
            sbRequest.Append("</QBXMLMsgsRq>");
            sbRequest.Append("</QBXML>");
            return sbRequest.ToString();
        }

        private static NameValueCollection ExtractQBResponse_Full(string QBResponse, string Path)
        {
            ClsCommon.Clear_Intialize_Table("COM");

            XmlDocument oDoc = new XmlDocument();
            oDoc.LoadXml(QBResponse);

            XmlNodeList oList = oDoc.SelectNodes("QBXML//QBXMLMsgsRs//" + Path + "//CompanyRet");
            if (oList.Count > 0)
            {
                dicResult.Clear();
                dicResult.Add("Status", "Get Company");
                try
                {
                    for (int i = 0; i < oList.Count; i++)
                    {
                        try
                        {
                            XmlNode oNode = oList[i];
                            DataRow dr = ClsCommon.dtQBMaster.NewRow();
                            dr["Name"] = (oNode["CompanyName"] == null ? "" : oNode["CompanyName"].InnerXml);
                            if (oNode["AddressBlock"] != null)
                            {
                                string Addr = "";
                                XmlNode oBill = oNode["AddressBlock"];
                                Addr = (oBill["Addr1"] == null ? "" : oBill["Addr1"].InnerXml);
                                Addr += (oBill["Addr2"] == null ? "" : (" "+oBill["Addr2"].InnerXml));
                                Addr += (oBill["Addr3"] == null ? "" : (" " + oBill["Addr3"].InnerXml));
                                Addr += (oBill["Addr4"] == null ? "" : (" " + oBill["Addr4"].InnerXml));
                                Addr += (oBill["Addr5"] == null ? "" : (" " + oBill["Addr5"].InnerXml));                            
                                dr["Address"] = Addr.Replace("&apos;","'").Replace("&amp;","&");
                            }
                            ClsCommon.dtQBMaster.Rows.Add(dr);
                        }
                        catch (Exception ex)
                        {
                            ClsCommon.WriteErrorLogs("Form:QBConfig,Get Company;Message:" + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ClsCommon.WriteErrorLogs("Form:QBConfig,Get Company Count;Message:" + ex.Message);
                }
            }
            else
            {
                dicResult.Add("Status", "Error: No Accounts Found");
            }
            return dicResult;
        }
    }
}
