using DocumentFormat.OpenXml.Wordprocessing;
using Interop.QBFC13;
using Newtonsoft.Json.Linq;
using POS.BAL;
using POS.BOL;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static Telerik.WinControls.UI.DateInput;

namespace POS.HelperClass
{
    public static class clsOnline
    {
        public static DataTable dtMaster = new DataTable();
        public static DataTable dtChild = new DataTable();
        public static DataTable dtRates = new DataTable();
        public static DataTable dtTime = new DataTable();
        public static DataTable dtFedx = new DataTable();

        public static Boolean RefreshToken;
        public static string ApiToken;

        public static void InitilizeTablesColumns(string Mode)
        {
            //dtMaster = new DataTable();
            switch (Mode.ToUpper())
            {
                case "TRA":
                    dtMaster = new DataTable();
                    dtMaster.Columns.Add(new DataColumn("paypal_account_id"));
                    dtMaster.Columns.Add(new DataColumn("transaction_id"));
                    dtMaster.Columns.Add(new DataColumn("transaction_event_code"));
                    dtMaster.Columns.Add(new DataColumn("transaction_initiation_date"));
                    dtMaster.Columns.Add(new DataColumn("transaction_updated_date"));
                    dtMaster.Columns.Add(new DataColumn("currency_code"));
                    dtMaster.Columns.Add(new DataColumn("transaction_value"));
                    dtMaster.Columns.Add(new DataColumn("fee_amount_value"));
                    dtMaster.Columns.Add(new DataColumn("transaction_status"));
                    dtMaster.Columns.Add(new DataColumn("invoice_id"));
                    dtMaster.Columns.Add(new DataColumn("protection_eligibility"));
                    break;

                case "RT":
                    dtRates = new DataTable();
                    dtRates.Columns.Add(new DataColumn("BillingUOM"));
                    dtRates.Columns.Add(new DataColumn("BillingWeight"));
                    dtRates.Columns.Add(new DataColumn("TransportationCharges"));
                    dtRates.Columns.Add(new DataColumn("ServiceOptionsCharges"));
                    dtRates.Columns.Add(new DataColumn("TotalCharges"));
                    dtRates.Columns.Add(new DataColumn("GuaranteedDaysToDelivery"));
                    dtRates.Columns.Add(new DataColumn("NegotiatedRates"));
                    dtRates.Columns.Add(new DataColumn("CurrencyCode"));
                    break;

                case "TIME":
                    dtTime = new DataTable();
                    dtTime.Columns.Add(new DataColumn("Service"));
                    dtTime.Columns.Add(new DataColumn("BusDays"));
                    dtTime.Columns.Add(new DataColumn("EstimatedDelivery"));
                    dtTime.Columns.Add(new DataColumn("Date"));
                    dtTime.Columns.Add(new DataColumn("DayOfWeek"));
                    dtTime.Columns.Add(new DataColumn("Guaranteed"));
                    dtTime.Columns.Add(new DataColumn("RateEstimate"));
                    break;

                case "FEDX":
                    dtFedx = new DataTable();
                    dtFedx.Columns.Add(new DataColumn("transactionId"));
                    dtFedx.Columns.Add(new DataColumn("masterTrackingNumber"));
                    dtFedx.Columns.Add(new DataColumn("serviceType"));
                    dtFedx.Columns.Add(new DataColumn("shipDatestamp"));
                    dtFedx.Columns.Add(new DataColumn("serviceName"));
                    dtFedx.Columns.Add(new DataColumn("deliveryDatestamp"));
                    dtFedx.Columns.Add(new DataColumn("trackingNumber"));
                    dtFedx.Columns.Add(new DataColumn("additionalChargesDiscount"));
                    dtFedx.Columns.Add(new DataColumn("netRateAmount"));
                    dtFedx.Columns.Add(new DataColumn("netChargeAmount"));
                    dtFedx.Columns.Add(new DataColumn("netDiscountAmount"));
                    dtFedx.Columns.Add(new DataColumn("encodedLabel"));
                    dtFedx.Columns.Add(new DataColumn("docType"));
                    dtFedx.Columns.Add(new DataColumn("Weight"));
                    dtFedx.Columns.Add(new DataColumn("TotalCharges"));
                    dtFedx.Columns.Add(new DataColumn("ServiceOptionsCharges"));

                    break;
            }
        }
        public static string ExtractResponse_POST_JSON(string jsonResult, string Mode)
        {
            string ID = "0";
            try
            {
                var root = Newtonsoft.Json.Linq.JObject.Parse(jsonResult);

                switch (Mode)
                {
                    case "UPSRATES":
                        if (root["RateResponse"] != null)
                        {
                            string status = (string)root["RateResponse"]["Response"]?["ResponseStatus"]?["Description"];
                            if (status == "Failure")
                            {
                                ID = "Error:" + ((string)root["RateResponse"]["Response"]?["Error"]?["ErrorDescription"] ?? "Unknown error");
                            }
                            else
                            {
                                if (root["RateResponse"]["RatedShipment"] != null)
                                    ID = "Success";
                            }
                        }
                        break;
                    case "UPS":
                        if (root["ShipmentResponse"] != null)
                        {
                            string status = (string)root["ShipmentResponse"]["Response"]?["ResponseStatus"]?["Description"];
                            if (status == "Failure")
                            {
                                ID = "Error:" + ((string)root["ShipmentResponse"]["Response"]?["Error"]?["ErrorDescription"] ?? "Unknown error");
                            }
                            else
                            {
                                // ShipmentIdentificationNumber
                                if (root["ShipmentResponse"]["ShipmentResults"]?["ShipmentIdentificationNumber"] != null)
                                    ID = (string)root["ShipmentResponse"]["ShipmentResults"]["ShipmentIdentificationNumber"];

                                // Charges
                                var charges = root["ShipmentResponse"]["ShipmentResults"]?["ShipmentCharges"];
                                if (charges != null)
                                {
                                    string transportation = (string)charges["TransportationCharges"]?["MonetaryValue"] ?? "0";
                                    string serviceOptions = (string)charges["ServiceOptionsCharges"]?["MonetaryValue"] ?? "0";
                                    string total = (string)charges["TotalCharges"]?["MonetaryValue"] ?? "0";
                                    string currency = (string)charges["TotalCharges"]?["CurrencyCode"] ?? "";

                                    Console.WriteLine($"Charges: {transportation}, {serviceOptions}, {total} {currency}");
                                }

                                // Negotiated Rate
                                var negotiated = root["ShipmentResponse"]["ShipmentResults"]?["NegotiatedRates"]?["NetSummaryCharges"]?["GrandTotal"];
                                if (negotiated != null)
                                {
                                    Console.WriteLine($"Negotiated: {negotiated["MonetaryValue"]} {negotiated["CurrencyCode"]}");
                                }

                                // Weight
                                var weight = root["ShipmentResponse"]["ShipmentResults"]?["BillingWeight"]?["Weight"];
                                if (weight != null)
                                {
                                    Console.WriteLine($"Weight: {weight}");
                                }

                                // PackageResults → Tracking + Label
                                var packages = root["ShipmentResponse"]?["ShipmentResults"]?["PackageResults"];

                                if (packages != null)
                                {
                                    if (packages is JArray)
                                    {
                                        foreach (var pkgToken in packages)
                                        {
                                            var pkg = pkgToken as JObject;
                                            if (pkg == null) continue;

                                            string tracking = (string)pkg["TrackingNumber"];
                                            string label = (string)pkg["ShippingLabel"]?["GraphicImage"];
                                            string charge = (string)pkg["ServiceOptionsCharges"]?["MonetaryValue"];

                                            Console.WriteLine($"Package Tracking: {tracking}");
                                            Console.WriteLine($"Service Charges: {charge}");
                                            if (!string.IsNullOrEmpty(label))
                                                Console.WriteLine("Label received (Base64).");
                                        }
                                    }
                                    else if (packages is JObject)
                                    {
                                        var pkg = packages as JObject;
                                        string tracking = (string)pkg["TrackingNumber"];
                                        string label = (string)pkg["ShippingLabel"]?["GraphicImage"];
                                        string charge = (string)pkg["ServiceOptionsCharges"]?["MonetaryValue"];

                                        Console.WriteLine($"Package Tracking: {tracking}");
                                        Console.WriteLine($"Service Charges: {charge}");
                                        if (!string.IsNullOrEmpty(label))
                                            Console.WriteLine("Label received (Base64).");
                                    }
                                }
                            }
                        }
                        break;
                    case "UPS_VOID":
                        if (root["VoidShipmentResponse"] != null)
                        {
                            string status = (string)root["VoidShipmentResponse"]["Response"]?["ResponseStatus"]?["Description"];
                            if (status == "Failure")
                            {
                                ID = "Error:" + ((string)root["VoidShipmentResponse"]["Response"]?["Error"]?["ErrorDescription"] ?? "Unknown error");
                            }
                            else
                            {
                                ID = "Success";
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("POST JSON Response Extract. Mode:" + Mode + ". Message:" + ex.Message);
            }
            return ID;
        }
        public static string ExtractResponse_POST(string Response, string Mode)
        {
            string ID = "0";
            try
            {
                XmlDocument oDoc = new XmlDocument();
                oDoc.LoadXml(Response);

                switch (Mode)
                {
                    case "UPSRATES":
                        XmlNodeList oListUPSRATE = oDoc.GetElementsByTagName("RatingServiceSelectionResponse");
                        foreach (XmlNode oNode in oListUPSRATE)
                        {
                            if (oNode["Response"]["ResponseStatusDescription"].InnerXml == "Failure")
                            {
                                if (oNode["Response"]["Error"]["ErrorDescription"] != null)
                                    ID = "Error:" + oNode["Response"]["Error"]["ErrorDescription"].InnerXml;
                            }
                            else
                            {
                                if (oNode["RatedShipment"] != null)
                                {
                                    ID = "Success";
                                    break;
                                }
                            }
                        }
                        break;
                    case "UPS":
                        XmlNodeList oListAcceptUPS = oDoc.GetElementsByTagName("ShipmentConfirmResponse");
                        foreach (XmlNode oNode in oListAcceptUPS)
                        {
                            if (oNode["Response"]["ResponseStatusDescription"].InnerXml == "Failure")
                            {
                                if (oNode["Response"]["Error"]["ErrorDescription"] != null)
                                    ID = "Error:" + oNode["Response"]["Error"]["ErrorDescription"].InnerXml;
                            }
                            else
                            {
                                if (oNode["ShipmentDigest"] != null)
                                {
                                    ID = oNode["ShipmentDigest"].InnerXml;
                                    break;
                                }
                            }
                        }
                        XmlNodeList oListAcceptUPS1 = oDoc.GetElementsByTagName("TimeInTransitResponse");
                        foreach (XmlNode oNode in oListAcceptUPS1)
                        {
                            if (oNode["Response"]["ResponseStatusDescription"].InnerXml == "Failure")
                            {
                                if (oNode["Response"]["Error"]["ErrorDescription"] != null)
                                    ID = "Error:" + oNode["Response"]["Error"]["ErrorDescription"].InnerXml;
                            }
                            else
                            {
                                if (oNode["ShipmentDigest"] != null)
                                {
                                    ID = oNode["ShipmentDigest"].InnerXml;
                                    break;
                                }
                            }
                        }
                        break;
                    case "UPS_VOID":
                        XmlNodeList oListUPSVoid = oDoc.GetElementsByTagName("VoidShipmentResponse");
                        foreach (XmlNode oNode in oListUPSVoid)
                        {
                            if (oNode["Response"]["ResponseStatusDescription"].InnerXml == "Failure")
                            {
                                if (oNode["Response"]["Error"]["ErrorDescription"] != null)
                                    ID = "Error:" + oNode["Response"]["Error"]["ErrorDescription"].InnerXml;
                            }
                            else
                            {
                                ID = "Success";
                                break;
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("POST Response Extract. Mode:" + Mode + ". Message:" + ex.Message);
            }
            return ID;
        }

        public static void ExtractResponse_POST(string Results)
        {
            try
            {
                dtMaster = new DataTable();
                dtChild = new DataTable();

                dtMaster.Columns.Add(new DataColumn("TransportationCharges"));
                dtMaster.Columns.Add(new DataColumn("ServiceOptionsCharges"));
                dtMaster.Columns.Add(new DataColumn("TotalCharges"));
                dtMaster.Columns.Add(new DataColumn("ShipmentIdentificationNumber"));
                dtMaster.Columns.Add(new DataColumn("Weight"));
                dtMaster.Columns.Add(new DataColumn("NegotiatedRate"));
                dtMaster.Columns.Add(new DataColumn("Currancycode"));



                dtChild.Columns.Add(new DataColumn("TrackingNumber"));
                dtChild.Columns.Add(new DataColumn("GraphicImage"));

                XmlDocument oDoc = new XmlDocument();
                oDoc.LoadXml(Results);

                XmlNodeList oListUSPS = oDoc.GetElementsByTagName("ShipmentAcceptResponse");
                foreach (XmlNode oNode in oListUSPS)
                {
                    DataRow drMaster = dtMaster.NewRow();
                    if (oNode["ShipmentResults"] != null)
                    {
                        if (oNode["ShipmentResults"]["ShipmentCharges"] != null)
                        {
                            if (oNode["ShipmentResults"]["ShipmentCharges"]["TransportationCharges"] != null)
                                drMaster["TransportationCharges"] = oNode["ShipmentResults"]["ShipmentCharges"]["TransportationCharges"]["MonetaryValue"].InnerXml;

                            if (oNode["ShipmentResults"]["ShipmentCharges"]["TransportationCharges"] != null)
                                drMaster["Currancycode"] = oNode["ShipmentResults"]["ShipmentCharges"]["TransportationCharges"]["CurrencyCode"].InnerXml;

                            if (oNode["ShipmentResults"]["ShipmentCharges"]["ServiceOptionsCharges"] != null)
                                drMaster["ServiceOptionsCharges"] = oNode["ShipmentResults"]["ShipmentCharges"]["ServiceOptionsCharges"]["MonetaryValue"].InnerXml;

                            if (oNode["ShipmentResults"]["ShipmentCharges"]["TotalCharges"] != null)
                                drMaster["TotalCharges"] = oNode["ShipmentResults"]["ShipmentCharges"]["TotalCharges"]["MonetaryValue"].InnerXml;

                            if (oNode["ShipmentResults"]["NegotiatedRates"] != null)
                            {
                                if (oNode["ShipmentResults"]["NegotiatedRates"]["NetSummaryCharges"]["GrandTotal"]["MonetaryValue"] != null)
                                    drMaster["NegotiatedRate"] = oNode["ShipmentResults"]["NegotiatedRates"]["NetSummaryCharges"]["GrandTotal"]["MonetaryValue"].InnerXml;
                            }

                        }
                        if (oNode["ShipmentResults"]["BillingWeight"] != null)
                            drMaster["Weight"] = oNode["ShipmentResults"]["BillingWeight"]["Weight"].InnerXml;
                        if (oNode["ShipmentResults"]["ShipmentIdentificationNumber"] != null)
                            drMaster["ShipmentIdentificationNumber"] = oNode["ShipmentResults"]["ShipmentIdentificationNumber"].InnerXml;

                        XmlNodeList oInnerList = oNode.SelectNodes("ShipmentResults//PackageResults");
                        foreach (XmlNode oInner in oInnerList)
                        {
                            DataRow drChild = dtChild.NewRow();
                            drChild["TrackingNumber"] = oInner["TrackingNumber"].InnerXml;
                            if (oInner["LabelImage"] != null)
                                drChild["GraphicImage"] = oInner["LabelImage"]["GraphicImage"].InnerXml;

                            dtChild.Rows.Add(drChild);
                        }

                        dtMaster.Rows.Add(drMaster);
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("POST Response Extract" + ". Message:" + ex.Message);
            }
        }
        public static void ExtractResponse_POST_JSON(string jsonResult)
        {
            try
            {
                dtMaster = new DataTable();
                dtChild = new DataTable();

                dtMaster.Columns.Add(new DataColumn("TransportationCharges"));
                dtMaster.Columns.Add(new DataColumn("ServiceOptionsCharges"));
                dtMaster.Columns.Add(new DataColumn("TotalCharges"));
                dtMaster.Columns.Add(new DataColumn("ShipmentIdentificationNumber"));
                dtMaster.Columns.Add(new DataColumn("Weight"));
                dtMaster.Columns.Add(new DataColumn("NegotiatedRate"));
                dtMaster.Columns.Add(new DataColumn("Currancycode"));

                dtChild.Columns.Add(new DataColumn("TrackingNumber"));
                dtChild.Columns.Add(new DataColumn("GraphicImage"));

                // JSON parse
                var root = Newtonsoft.Json.Linq.JObject.Parse(jsonResult);

                var shipmentResponse = root["ShipmentResponse"];
                if (shipmentResponse != null)
                {
                    var shipmentResults = shipmentResponse["ShipmentResults"];
                    if (shipmentResults != null)
                    {
                        DataRow drMaster = dtMaster.NewRow();

                        // Charges
                        var charges = shipmentResults["ShipmentCharges"];
                        if (charges != null)
                        {
                            drMaster["TransportationCharges"] = (string)charges["TransportationCharges"]?["MonetaryValue"];
                            drMaster["Currancycode"] = (string)charges["TransportationCharges"]?["CurrencyCode"];
                            drMaster["ServiceOptionsCharges"] = (string)charges["ServiceOptionsCharges"]?["MonetaryValue"];
                            drMaster["TotalCharges"] = (string)charges["TotalCharges"]?["MonetaryValue"];
                        }

                        // Negotiated Rate
                        var negotiated = shipmentResults["NegotiatedRates"]?["NetSummaryCharges"]?["GrandTotal"];
                        if (negotiated != null)
                        {
                            drMaster["NegotiatedRate"] = (string)negotiated["MonetaryValue"];
                        }

                        // Weight
                        drMaster["Weight"] = (string)shipmentResults["BillingWeight"]?["Weight"];

                        // ShipmentIdentificationNumber
                        drMaster["ShipmentIdentificationNumber"] = (string)shipmentResults["ShipmentIdentificationNumber"];

                        // ✅ PackageResults handling (Array ya Object dono case)
                        var packages = shipmentResults["PackageResults"];
                        if (packages != null)
                        {
                            if (packages is JArray)   // multiple packages
                            {
                                foreach (var pkg in packages)
                                {
                                    DataRow drChild = dtChild.NewRow();
                                    drChild["TrackingNumber"] = (string)pkg["TrackingNumber"];
                                    drChild["GraphicImage"] = (string)pkg["ShippingLabel"]?["GraphicImage"];
                                    dtChild.Rows.Add(drChild);
                                }
                            }
                            else if (packages is JObject)   // single package
                            {
                                DataRow drChild = dtChild.NewRow();
                                drChild["TrackingNumber"] = (string)packages["TrackingNumber"];
                                drChild["GraphicImage"] = (string)packages["ShippingLabel"]?["GraphicImage"];
                                dtChild.Rows.Add(drChild);
                            }
                        }

                        dtMaster.Rows.Add(drMaster);
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("POST JSON Response Extract. Message:" + ex.Message);
            }
        }

        public static DataTable ExtractRateResponse_POST(string results)
        {
            InitilizeTablesColumns("RT");

            var root = JObject.Parse(results);
            var ratedShipmentsToken = root["RateResponse"]?["RatedShipment"];
            if (ratedShipmentsToken == null) return dtRates;

            // UPS can return either a single object or an array
            var ratedShipments = ratedShipmentsToken is JArray arr
                ? arr
                : new JArray(ratedShipmentsToken);

            //foreach (var rs in ratedShipments)
            //{
            //    DataRow dr = dtRates.NewRow();
            //    dr["BillingUOM"] = rs["BillingWeight"]?["UnitOfMeasurement"]?["Code"]?.ToString();
            //    dr["BillingWeight"] = rs["BillingWeight"]?["Weight"]?.ToString();
            //    dr["TransportationCharges"] = rs["TransportationCharges"]?["MonetaryValue"]?.ToString();
            //    dr["ServiceOptionsCharges"] = rs["ServiceOptionsCharges"]?["MonetaryValue"]?.ToString();
            //    dr["TotalCharges"] = rs["TotalCharges"]?["MonetaryValue"]?.ToString() ?? "0.00";
            //    dr["GuaranteedDaysToDelivery"] = rs["GuaranteedDelivery"]?["BusinessDaysInTransit"]?.ToString();
            //    dr["NegotiatedRates"] = rs["NegotiatedRates"]?["NetSummaryCharges"]?["GrandTotal"]?["MonetaryValue"]?.ToString();
            //    dr["CurrencyCode"] = rs["TotalCharges"]?["CurrencyCode"]?.ToString();

            //    dtRates.Rows.Add(dr);
            //}
            foreach (var rs in ratedShipments)
            {
                DataRow dr = dtRates.NewRow();

                dr["BillingUOM"] = rs["BillingWeight"]?["UnitOfMeasurement"]?["Code"]?.ToString();
                dr["BillingWeight"] = rs["BillingWeight"]?["Weight"]?.ToString();
                dr["TransportationCharges"] = rs["TransportationCharges"]?["MonetaryValue"]?.ToString();
                dr["ServiceOptionsCharges"] = rs["ServiceOptionsCharges"]?["MonetaryValue"]?.ToString();
                dr["TotalCharges"] = rs["TotalCharges"]?["MonetaryValue"]?.ToString() ?? "0.00";
                dr["GuaranteedDaysToDelivery"] = rs["GuaranteedDelivery"]?["BusinessDaysInTransit"]?.ToString();

                // ✔ Correct Negotiated Rate Charge
                dr["NegotiatedRates"] = rs["NegotiatedRateCharges"]?["TotalCharge"]?["MonetaryValue"]?.ToString() ?? "0.00";

                dr["CurrencyCode"] = rs["TotalCharges"]?["CurrencyCode"]?.ToString();

                dtRates.Rows.Add(dr);
            }

            return dtRates;
        }

        public static string UpdateInInvoice(string EntityId, string TrackingNumber, string _Email)
        {

            BALInvoiceMaster ObjInvoiceBAL = new BALInvoiceMaster();
            BOLInvoiceMaster ObjInvoiceBOL = new BOLInvoiceMaster();
            string Id = "";
            DataTable dtInvoice = new BALInvoiceMaster().SelectOrder(new BOLInvoiceMaster() { RefNumber = EntityId });
            if (dtInvoice.Rows.Count > 0)
            {
                Id = EntityId;
                ObjInvoiceBOL.ID = Convert.ToInt32(dtInvoice.Rows[0]["ID"].ToString());
                //  ObjInvoiceBOL.TrackingNumber = TrackingNumber;
                ObjInvoiceBOL.IsShipping = 1;
                ObjInvoiceBAL.UpdateTrackingNumber(ObjInvoiceBOL);

                DataTable dtItem = new BALItemMaster().SelectAllItem(new BOLItemMaster() { });
                DataRow[] dr = dtItem.Select("[FullName] like '%tracking%'");
                if (dr.Length > 0)
                {
                    BALInvoiceDetails objDetailsBAL = new BALInvoiceDetails();
                    BOLInvoiceDetails objDetailsBOL = new BOLInvoiceDetails();

                    objDetailsBOL.InvoiceID = Convert.ToInt32(dtInvoice.Rows[0]["ID"].ToString());
                    DataTable dtchk1 = new BALInvoiceDetails().SelectByID(objDetailsBOL);

                    if (dtchk1.Rows.Count > 0)
                    {
                        DataTable dt1 = dr.CopyToDataTable();
                        objDetailsBAL = new BALInvoiceDetails();
                        objDetailsBOL = new BOLInvoiceDetails();

                        objDetailsBOL.SrNo = (Convert.ToInt32(dtchk1.Rows[dtchk1.Rows.Count - 1]["SrNo"].ToString()) + 1);
                        objDetailsBOL.InvoiceID = Convert.ToInt32(dtInvoice.Rows[0]["ID"].ToString());
                        objDetailsBOL.ItemID = Convert.ToInt32(dt1.Rows[0]["ID"].ToString());
                        objDetailsBOL.Decs = TrackingNumber;
                        objDetailsBOL.Quantity = 0;
                        objDetailsBOL.Rate = 0;
                        objDetailsBOL.Amount = 0;
                        objDetailsBOL.ItemType = dt1.Rows[0]["ItemType"].ToString();
                        objDetailsBOL.CreatedTime = DateTime.Now;
                        objDetailsBOL.CreatedID = ClsCommon.UserID;
                        objDetailsBAL.InvoiceDetailsInsert(objDetailsBOL);


                        int NewInvoiceID = new BALInvoiceMaster().GetInvoiceID(Convert.ToInt32(dtInvoice.Rows[0]["ID"].ToString()));
                        objDetailsBOL.InvoiceID = NewInvoiceID;
                        objDetailsBAL.NewInvoiceDetailsInsert(objDetailsBOL);

                        new BALInvoiceMaster().UpdateIsSync(dtInvoice.Rows[0]["ID"].ToString());
                    }
                }
            }
            return Id;

        }


        public static void ExtractToken(string Results, string Type)
        {
            string ApiToken = "";

            try
            {
                JToken token = JToken.Parse(Results);
                if (token != null)
                {
                    JObject objRow = JObject.Parse(token.ToString());
                    ApiToken = (objRow["access_token"] == null ? "" : objRow["access_token"].ToString());
                    new BALUPSSettings().UPDATEToken(ApiToken, Type);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static string ExtractToken(string Results)
        {
            ApiToken = "";

            try
            {
                JToken token = JToken.Parse(Results);
                if (token != null)
                {


                    JObject objRow = JObject.Parse(token.ToString());
                    ApiToken = (objRow["access_token"] == null ? "" : objRow["access_token"].ToString());

                }


            }
            catch (Exception ex)
            {

            }
            return ApiToken;
        }

        public static void ExtractFedxResponse(string Results)
        {
            try
            {
                dtFedx = new DataTable();
                clsOnline.InitilizeTablesColumns("FEDX");
                JToken token = JToken.Parse(Results);
                if (token != null)
                {
                    JObject objRow = JObject.Parse(token.ToString());
                    DataRow dr = dtFedx.NewRow();
                    dr["transactionId"] = (objRow["transactionId"] == null ? "" : objRow["transactionId"].ToString());


                    JToken token1 = JToken.Parse(token["output"]["transactionShipments"].ToString());
                    JObject objRow1 = JObject.Parse(token1[0].ToString());

                    dr["masterTrackingNumber"] = (objRow1["masterTrackingNumber"] == null ? "" : objRow1["masterTrackingNumber"].ToString());
                    dr["serviceType"] = (objRow1["serviceType"] == null ? "" : objRow1["serviceType"].ToString());
                    dr["shipDatestamp"] = (objRow1["shipDatestamp"] == null ? "" : objRow1["shipDatestamp"].ToString());
                    dr["serviceName"] = (objRow1["serviceName"] == null ? "" : objRow1["serviceName"].ToString());



                    JArray Receipt = (JArray)objRow1["pieceResponses"];
                    JObject objRow2 = JObject.Parse(Receipt[0].ToString());


                    dr["deliveryDatestamp"] = (objRow2["deliveryDatestamp"] == null ? "" : objRow2["deliveryDatestamp"].ToString());
                    dr["trackingNumber"] = (objRow2["trackingNumber"] == null ? "" : objRow2["trackingNumber"].ToString());
                    dr["additionalChargesDiscount"] = (objRow2["additionalChargesDiscount"] == null ? "" : objRow2["additionalChargesDiscount"].ToString());
                    dr["netRateAmount"] = (objRow2["netRateAmount"] == null ? "" : objRow2["netRateAmount"].ToString());
                    dr["netChargeAmount"] = (objRow2["netChargeAmount"] == null ? "" : objRow2["netChargeAmount"].ToString());
                    dr["netDiscountAmount"] = (objRow2["netDiscountAmount"] == null ? "" : objRow2["netDiscountAmount"].ToString());


                    JArray Receipt1 = (JArray)objRow2["packageDocuments"];
                    JObject objRow3 = JObject.Parse(Receipt1[0].ToString());

                    dr["encodedLabel"] = (objRow3["encodedLabel"] == null ? "" : objRow3["encodedLabel"].ToString());
                    dr["docType"] = (objRow3["docType"] == null ? "" : objRow3["docType"].ToString());




                    JToken Receipt2 = JToken.Parse(token["output"]["transactionShipments"].ToString());
                    JObject objRow4 = JObject.Parse(Receipt2[0].ToString());


                    JToken Receipt3 = JToken.Parse(objRow4["completedShipmentDetail"].ToString());
                    JObject objRow5 = JObject.Parse(Receipt3.ToString());

                    JToken Receipt4 = JToken.Parse(objRow5["shipmentRating"].ToString());
                    JObject objRow6 = JObject.Parse(Receipt4.ToString());

                    JToken Receipt5 = JToken.Parse(objRow6["shipmentRateDetails"].ToString());
                    JObject objRow7 = JObject.Parse(Receipt5[0].ToString());



                    JToken Receipt6 = JToken.Parse(objRow7["totalBillingWeight"].ToString());


                    dr["Weight"] = (Receipt6["value"] == null ? "" : ((double)Receipt6["value"]).ToString("0.0"));
                    dr["TotalCharges"] = (objRow7["totalNetCharge"] == null ? "" : objRow7["totalNetCharge"].ToString());
                    dr["ServiceOptionsCharges"] = (objRow7["totalBaseCharge"] == null ? "" : objRow7["totalBaseCharge"].ToString());
                    dtFedx.Rows.Add(dr);

                }


            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("POST Response Rate Extract" + ". Message:" + ex.Message);
            }
        }

        public static void ExtractFedxRateResponse(string Results)
        {
            try
            {
                dtFedx = new DataTable();
                clsOnline.InitilizeTablesColumns("FEDX");
                JToken token = JToken.Parse(Results);
                if (token != null)
                {
                    JObject objRow = JObject.Parse(token.ToString());
                    DataRow dr = dtFedx.NewRow();
                    dr["transactionId"] = (objRow["transactionId"] == null ? "" : objRow["transactionId"].ToString());


                    JToken token1 = JToken.Parse(token["output"]["rateReplyDetails"].ToString());
                    JObject objRow1 = JObject.Parse(token1[0].ToString());

                    dr["serviceType"] = (objRow1["serviceType"] == null ? "" : objRow1["serviceType"].ToString());
                    dr["serviceName"] = (objRow1["serviceName"] == null ? "" : objRow1["serviceName"].ToString());


                    JArray Receipt = (JArray)objRow1["ratedShipmentDetails"];
                    JObject objRow2 = JObject.Parse(Receipt[0].ToString());

                    dr["TotalCharges"] = (objRow2["totalNetCharge"] == null ? "" : objRow2["totalNetCharge"].ToString());
                    dr["ServiceOptionsCharges"] = (objRow2["totalBaseCharge"] == null ? "" : objRow2["totalBaseCharge"].ToString());

                    dtFedx.Rows.Add(dr);


                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("POST Response Rate Extract" + ". Message:" + ex.Message);
            }

        }

    }
}
