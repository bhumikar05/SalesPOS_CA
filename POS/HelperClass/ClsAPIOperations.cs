using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace POS.HelperClass
{
    class ClsAPIOperations
    {
        public static string ApiToken = "";
        public static int Retry = 0;
        public static string apiResponse = "";

        public static string PostToken(string Data, string type)
        {
            apiResponse = "";
        ReCheck:
            string apiUrl = "";
            HttpWebRequest oRequest = null;
            HttpWebResponse oResponse = null;
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                if (type == "login")
                    oRequest = WebRequest.Create("https://admin.txparts.com/api/login") as HttpWebRequest;
                //oRequest = WebRequest.Create("https://admin-testing.txparts.com/api/login") as HttpWebRequest;

                else if (type == "order")
                    oRequest = WebRequest.Create("https://admin.txparts.com/api/order-status-update") as HttpWebRequest;
                //oRequest = WebRequest.Create("https://admin-testing.txparts.com/api/order-status-update") as HttpWebRequest;

                else if (type == "shipment-void")
                    oRequest = WebRequest.Create("https://admin.txparts.com/api/shipment-void") as HttpWebRequest;
                //oRequest = WebRequest.Create("https://admin-testing.txparts.com/api/shipment-void") as HttpWebRequest;


                if (!string.IsNullOrEmpty(ApiToken))
                {
                    oRequest.Headers.Add("Authorization", "Bearer " + ApiToken);
                }

                oRequest.Method = WebRequestMethods.Http.Post;
                oRequest.ContentType = "application/json";
                oRequest.Accept = "application/json";

                byte[] byte1 = Encoding.ASCII.GetBytes(Data);
                oRequest.ContentLength = byte1.Length;

                using (Stream newStream = oRequest.GetRequestStream())
                {
                    newStream.Write(byte1, 0, byte1.Length);
                }

                using (HttpWebResponse response = (HttpWebResponse)oRequest.GetResponse())
                using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
                {
                    apiResponse = rdr.ReadToEnd();
                    if (type == "login")
                    {
                        ResponseExtract(apiResponse, type);
                    }
                }
            }
            catch (WebException ex)
            {
                using (WebResponse response = ex.Response)
                {
                    var httpResponse = (HttpWebResponse)response;
                    using (Stream data = response.GetResponseStream())
                    using (StreamReader sr2 = new StreamReader(data))
                    {
                        apiResponse = "Error:" + sr2.ReadToEnd();
                        ClsCommon.WriteErrorLogs(apiResponse);
                        ClsCommon.WriteErrorLogs(ex.Message.ToString());

                        if (apiResponse.Contains("INVALID_TOKEN") && type == "order")
                        {
                            string loginJson = "{ \"email\":\"qb@txparts.com\", \"password\":\"12345678\", \"source\":\"1\" }";
                            PostToken(loginJson, "login");
                            goto ReCheck;
                        }
                        else if (ex.Message.Contains("(304) Not Modified"))
                        {
                            apiResponse = "There is no data this modified date";
                            goto Final;
                        }
                    }
                }

                if (Retry < 3)
                {
                    Retry += 1;
                    System.Threading.Thread.Sleep(6000);
                    goto ReCheck;
                }
            }
            finally
            {
                oRequest = null;
                oResponse = null;
            }

        Final:
            return apiResponse;
        }

        public static void ResponseExtract(string Response, string type)
        {
            try
            {
                ApiToken = "";
                if (type == "login")
                {
                    JToken token = JToken.Parse(Response);
                    if (token != null)
                    {
                        JObject objRow = JObject.Parse(token.ToString());
                        if (objRow["error"].ToString() == "False")
                        {
                            JToken token1 = JToken.Parse(token["data"].ToString());
                            JObject objRow1 = JObject.Parse(token1.ToString());
                            ApiToken = (objRow1["token"] == null ? "" : objRow1["token"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
