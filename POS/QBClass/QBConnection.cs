using Interop.QBFC13;
using POS.HelperClass;
using System;
using System.Collections.Specialized;

namespace POS.QBClass
{
    public static class QBConnection
    {
        static NameValueCollection dicResult = new NameValueCollection();
        public static NameValueCollection retMessage = new NameValueCollection();

        public static NameValueCollection OpenConnection_anyMode()
        {
            dicResult.Clear();
            if (ClsCommon.oSession == null)
            {
                try
                {
                    QBSessionManager oSession = new QBSessionManager();
                    oSession.OpenConnection("", "QuickBooks Syncronization v1.2");
                    oSession.BeginSession(ClsCommon.QBCompanyFile, ENOpenMode.omDontCare);
                    ClsCommon.oSession = oSession;
                    dicResult.Add("Status", "Session Created");

                }
                catch (Exception ex)
                {
                    dicResult.Add("Status", "Error:" + ex.Message);
                }
            }
            return dicResult;
        }

        //QBCompanyInfo
        public static NameValueCollection GetCompanyInfo(string QBVersion)
        {

            dicResult.Clear();
            //ClsCommon.QBCompanyFile = ClsCommon.oSession.GetCurrentCompanyFileName();
            //ClsCommon.QBVersion = QBVersion.ToString();
            dicResult.Add("Path", ClsCommon.oSession.GetCurrentCompanyFileName());
            dicResult.Add("Version", QBVersion.ToString());


            return dicResult;
        }

        public static NameValueCollection Close_QBConnection()
        {
            dicResult.Clear();
            try
            {
                if (ClsCommon.oSession != null)
                {
                    ClsCommon.oSession.CloseConnection();
                    ClsCommon.oSession = null;
                    dicResult.Add("Status", "Session Destroed");
                }
            }
            catch (Exception ex)
            {
                dicResult.Add("Status", "Error:" + ex.Message);
            }
            return dicResult;
        }

        public static string Process_QBRequest(string QBRequest)
        {
            dicResult.Clear();
            string QbResponse = "";
            try
            {
                IMsgSetResponse oResponse;
                oResponse = ClsCommon.oSession.DoRequestsFromXMLString(QBRequest);
                QbResponse = oResponse.ToXMLString();
                ClsCommon.WriteErrorLogs("Success");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs(ex.Message);
                throw ex;
            }
            return QbResponse;
        }
    }
}
