using Newtonsoft.Json.Linq;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace POS
{
    public static class ClsPaypal
    {
        public static string apiResponse = "";
        static BALPaypalConfig objBALPaypalConfig = new BALPaypalConfig();
        static BOLPaypalConfig objBOlPaypalConfig = new BOLPaypalConfig();

        public static string GetPaypalAuthToken(string ClientID,string ClientSecret,DateTime Modfied)
        {
            apiResponse = "";
            try
            {
                var client1 = new RestClient(ConfigurationManager.AppSettings["PaypalLink"].ToString() + "/v1/oauth2/token");
                var request1 = new RestRequest(Method.POST);
                client1.Authenticator = new HttpBasicAuthenticator(ClientID, ClientSecret);
                request1.AddParameter("application/x-www-form-urlencoded", $"grant_type=client_credentials", ParameterType.RequestBody);

                IRestResponse response1 = client1.Execute(request1);
                apiResponse = response1.Content;
                if (apiResponse.Contains("error") == false)
                {
                    string[] data = apiResponse.Split(',');
                    if (data.Length > 1)
                    {
                        foreach (string Str in data)
                        {
                            string[] data1 = Str.Split(':');
                            if (data1.Length > 1)
                            {
                                if (data1[0].Contains("access_token"))
                                {
                                    DataTable dtPaypalToken = new BALPaypalConfig().Select(new BOLPaypalConfig() { });
                                    if (dtPaypalToken.Rows.Count == 0)
                                    {
                                        objBOlPaypalConfig.PaypalAuthToken = data1[1].Replace("\"", "");
                                        objBOlPaypalConfig.ModifiedTime = Modfied;
                                        objBALPaypalConfig.Insert(objBOlPaypalConfig);                                      
                                        break;
                                    }
                                    else if (dtPaypalToken.Rows.Count == 1)
                                    {
                                        objBOlPaypalConfig.ID = Convert.ToInt32(dtPaypalToken.Rows[0]["ID"].ToString());
                                        objBOlPaypalConfig.PaypalAuthToken = data1[1].Replace("\"", "");
                                        objBOlPaypalConfig.ModifiedTime = Modfied;
                                        objBALPaypalConfig.Update(objBOlPaypalConfig);                                       
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Class:ClsPaypal, Function: GetPaypalAuthToken, Error: " + ex.Message);
                Console.WriteLine("Error:" + ex.Message, "E");
            }
            return apiResponse;
        }



    }
}
