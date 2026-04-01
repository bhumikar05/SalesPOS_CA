using Newtonsoft.Json;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.VoidReference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Color = System.Drawing.Color;
using DataTable = System.Data.DataTable;
using Font = System.Drawing.Font;
using Formatting = System.Xml.Formatting;

namespace POS
{
    public partial class FrmShippedInvoiceList : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALHistoryMaster BALHistory = new BALHistoryMaster();
        BALUPS_FedExHistory BALFedEx = new BALUPS_FedExHistory();
        DataTable dtShipInvoice = new DataTable();
        DataTable dtInvoice = new DataTable();
        public static FrmFedExUPSShippingManager fdex = new FrmFedExUPSShippingManager();
        DataTable dtFedxRes = new DataTable();

        public FrmShippedInvoiceList()
        {

            InitializeComponent();
            lblFrom.Visible = false; lblto.Visible = false; dtTranFrom.Visible = false; dtTranTo.Visible = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 50);
            lblTotal.Text = "0";
            //LoadShippedInvoice();
            DateWiseInvoiceLoad();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // LoadShippedInvoice();
            DateWiseInvoiceLoad();
            cmbTransactionsFilterDate.SelectedIndex = 0;

        }
        private void FrmShippedInvoiceReport_Load(object sender, EventArgs e)
        {
            try
            {
                dgvShippiedInvoiceList.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvShippiedInvoiceList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                dgvShippiedInvoiceList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8F, FontStyle.Regular);
                dgvShippiedInvoiceList.EnableHeadersVisualStyles = false;
                cmbTransactionsFilterDate.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmTransactionHistory,Function :FrmShippedInvoiceReport_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        public void LoadShippedInvoice()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                txtInvoiceNo.Text = "";
                dtInvoice = new DataTable();
                //  dtInvoice = new BALInvoiceMaster().SelectShippedInvoice(new BOLInvoiceMaster() { });
                dtInvoice = BALFedEx.Select();

                if (dtInvoice.Rows.Count > 0)
                {
                    int j = 0;
                    dgvShippiedInvoiceList.Rows.Clear();
                    for (int i = 0; i < dtInvoice.Rows.Count; i++)
                    {
                        dgvShippiedInvoiceList.Rows.Add();
                        dgvShippiedInvoiceList.Rows[j].Cells["ID"].Value = dtInvoice.Rows[i]["ID"].ToString();
                        dgvShippiedInvoiceList.Rows[j].Cells["CustomerName"].Value = dtInvoice.Rows[i]["CustomerName"].ToString();
                        dgvShippiedInvoiceList.Rows[j].Cells["InvoiceNo"].Value = dtInvoice.Rows[i]["RefNumber"].ToString();
                        //dgvShippiedInvoiceList.Rows[j].Cells[3].Value = dtInvoice.Rows[i]["RefNumber"].ToString();
                        if (dtInvoice.Rows[i]["Time"].ToString() != "")
                            dgvShippiedInvoiceList.Rows[j].Cells["TxnDate"].Value = Convert.ToDateTime(dtInvoice.Rows[i]["Time"].ToString()).ToString("HH:mm:ss");
                        dgvShippiedInvoiceList.Rows[j].Cells["TrackingNumber"].Value = dtInvoice.Rows[i]["TrackingID"].ToString();
                        if (dtInvoice.Rows[i]["Time"].ToString() != "")
                            dgvShippiedInvoiceList.Rows[j].Cells["ShipDate"].Value = Convert.ToDateTime(dtInvoice.Rows[i]["Time"].ToString()).ToString("MM-dd-yyyy");
                        if (dtInvoice.Rows[i]["Weight"].ToString() != "")
                            dgvShippiedInvoiceList.Rows[j].Cells["Weight"].Value = dtInvoice.Rows[i]["Weight"].ToString();
                        if (dtInvoice.Rows[i]["Service"].ToString() != "")
                            dgvShippiedInvoiceList.Rows[j].Cells["Services"].Value = dtInvoice.Rows[i]["Service"].ToString();
                        if (dtInvoice.Rows[i]["Charges"].ToString() != "")
                            dgvShippiedInvoiceList.Rows[j].Cells["ESTCharges"].Value = dtInvoice.Rows[i]["TotalCost"].ToString();
                        if (dtInvoice.Rows[i]["COD"].ToString() != "")
                        {
                            dgvShippiedInvoiceList.Rows[j].Cells["COD"].Value = dtInvoice.Rows[i]["COD"].ToString();
                        }
                        else
                        {
                            dgvShippiedInvoiceList.Rows[j].Cells["COD"].Value = "0";
                        }
                        dgvShippiedInvoiceList.Rows[j].Cells["ID1"].Value = dtInvoice.Rows[i]["ID1"].ToString();

                        j++;
                    }
                }
                else
                {
                    dgvShippiedInvoiceList.Rows.Clear();
                }
                Cursor.Current = Cursors.WaitCursor;
                lblTotal.Text = dtInvoice.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.WaitCursor;
                ClsCommon.WriteErrorLogs("Form:FrmShippedInvoiceList, Function :LoadUnShippedInvoice. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void btmClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtInvoiceNo.Text = "";
            //LoadShippedInvoice();
            if (lblFrom.Visible == true)
            {
                this.dtTranTo.Click += new System.EventHandler(this.dtTranTo_Leave);
            }
            DateWiseInvoiceLoad();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtInvoiceNo.Text != "")
                {
                    //dtInvoice = dtShipInvoice;
                    //dtInvoice = BALFedEx.Select();
                    if (dtInvoice.Rows.Count > 0)
                    {
                        DataRow[] row = dtInvoice.Select("RefNumber like '%" + txtInvoiceNo.Text + "%' OR TrackingID like '%" + txtInvoiceNo.Text + "%' OR CustomerName like '%" + txtInvoiceNo.Text + "%' OR COD like '%" + txtInvoiceNo.Text + "%' OR Service like '%" + txtInvoiceNo.Text + "%' OR Weight like '%" + txtInvoiceNo.Text + "%' OR Charges like '%" + txtInvoiceNo.Text + "%'");
                        // DataRow[] row = dt.Select("CustomerFullName like '%" + txtSearch.Text + "%' OR ItemFullName like '%" + txtSearch.Text + "%' OR SalesRepName like '%" + txtSearch.Text + "%'");
                        if (row.Length > 0)
                        {
                            DataTable dtNew = row.CopyToDataTable();

                            int j = 0;
                            dgvShippiedInvoiceList.Rows.Clear();
                            for (int i = 0; i < dtNew.Rows.Count; i++)
                            {
                                dgvShippiedInvoiceList.Rows.Add();
                                dgvShippiedInvoiceList.Rows[j].Cells["ID"].Value = dtNew.Rows[i]["ID"].ToString();
                                dgvShippiedInvoiceList.Rows[j].Cells["CustomerName"].Value = dtNew.Rows[i]["CustomerName"].ToString();
                                dgvShippiedInvoiceList.Rows[j].Cells["InvoiceNo"].Value = dtNew.Rows[i]["RefNumber"].ToString();
                                if (dtNew.Rows[i]["Time"].ToString() != "")
                                    dgvShippiedInvoiceList.Rows[j].Cells["TxnDate"].Value = Convert.ToDateTime(dtNew.Rows[i]["Time"].ToString()).ToString("HH:mm:ss");
                                dgvShippiedInvoiceList.Rows[j].Cells["TrackingNumber"].Value = dtNew.Rows[i]["TrackingID"].ToString();
                                if (dtNew.Rows[i]["Time"].ToString() != "")
                                    dgvShippiedInvoiceList.Rows[j].Cells["ShipDate"].Value = Convert.ToDateTime(dtNew.Rows[i]["Time"].ToString()).ToString("MM-dd-yyyy");

                                if (dtNew.Rows[i]["Weight"].ToString() != "")
                                    dgvShippiedInvoiceList.Rows[j].Cells["Weight"].Value = dtNew.Rows[i]["Weight"].ToString();
                                if (dtNew.Rows[i]["Service"].ToString() != "")
                                    dgvShippiedInvoiceList.Rows[j].Cells["Services"].Value = dtNew.Rows[i]["Service"].ToString();
                                if (dtNew.Rows[i]["Charges"].ToString() != "")
                                    dgvShippiedInvoiceList.Rows[j].Cells["ESTCharges"].Value = dtNew.Rows[i]["TotalCost"].ToString();
                                if (dtNew.Rows[i]["COD"].ToString() != "")
                                {
                                    dgvShippiedInvoiceList.Rows[j].Cells["COD"].Value = dtNew.Rows[i]["COD"].ToString();
                                }
                                else
                                {
                                    dgvShippiedInvoiceList.Rows[j].Cells["COD"].Value = "0";
                                }
                                //dgvShippiedInvoiceList.Rows[j].Cells[6].Value = dtNew.Rows[i]["Total"].ToString();
                                //if (dtNew.Rows[i]["ShippingDate"].ToString() != "")
                                //    dgvShippiedInvoiceList.Rows[j].Cells[8].Value = Convert.ToDateTime(dtNew.Rows[i]["ShippingDate"].ToString()).ToString("MM-dd-yyyy");
                                //else
                                //    dgvShippiedInvoiceList.Rows[j].Cells[8].Value = "";
                                dgvShippiedInvoiceList.Rows[j].Cells["ID1"].Value = dtNew.Rows[i]["ID1"].ToString();
                                j++;
                            }
                            lblTotal.Text = dtNew.Rows.Count.ToString();
                        }
                        else
                        {
                            dgvShippiedInvoiceList.Rows.Clear();
                        }
                    }
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    DateWiseInvoiceLoad();
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmShippedInvoiceList,Function :btnSearch_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }
        public static string BuildAccessKey()
        {
            string sXML = "";
            StringWriter strWriter = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(strWriter);

            xw.Formatting = Formatting.Indented;
            xw.Indentation = 3;

            xw.WriteStartDocument();

            //--------------------------------------------            
            // Agreement Request

            //DataTable dtUPS = new DataTable();
            //dtUPS = new BALUPSSettings().Select(new BOLUPSSettings() { });
            xw.WriteStartElement("AccessRequest");

            //xw.WriteElementString("AccessLicenseNumber", dtUPS.Rows[0]["UPSAccessLicenseKey"].ToString());
            //xw.WriteElementString("UserId", dtUPS.Rows[0]["UPSUserName"].ToString());
            //xw.WriteElementString("Password", dtUPS.Rows[0]["UPSPassword"].ToString());

            xw.WriteEndElement();
            // End Agreement Request
            //--------------------------------------------

            xw.WriteEndDocument();
            xw.Flush();
            xw.Close();

            sXML = strWriter.GetStringBuilder().ToString();

            xw = null;

            //HttpContext.Current.Trace.Write("AccessRequest=" & sXML)

            return sXML;
        }
        private string BuildVoidShipRequest(ref VoidShipmentRequest req)
        {

            StringWriter strWriter = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(strWriter);

            xw.Formatting = Formatting.Indented;
            xw.Indentation = 3;

            xw.WriteStartDocument();

            //--------------------------------------------            
            // Start Void Shipment Request
            xw.WriteStartElement("VoidShipmentRequest");

            //--------------------------------------------
            // Request
            xw.WriteStartElement("Request");
            //--------------------------------------------
            // TransactionReference
            xw.WriteStartElement("TransactionReference");
            xw.WriteElementString("CustomerContext", "Void Shipment Request");
            xw.WriteElementString("XpciVersion", "1.0001");
            xw.WriteEndElement();
            // End TransactionReference
            //--------------------------------------------
            xw.WriteElementString("RequestAction", "1");
            //xw.WriteElementString("RequestOption", "Shoptimeintransit");
            xw.WriteElementString("RequestOption", "");
            xw.WriteEndElement();
            // End Request
            //--------------------------------------------

            xw.WriteElementString("ShipmentIdentificationNumber", dgvShippiedInvoiceList.CurrentRow.Cells[3].Value.ToString());

            xw.WriteEndElement();
            // End Void Shipment Request
            //--------------------------------------------

            xw.WriteEndDocument();
            xw.Flush();
            xw.Close();


            // Output Xml As String with Access Key
            string sXML = strWriter.GetStringBuilder().ToString();
            //sXML = BuildAccessKey();
            //sXML += "\n";
            //sXML += strWriter.GetStringBuilder().ToString();

            return sXML;
        }

        private string GetVoidShipmentJSON(string trackingNumber)
        {
            string json = "";
            try
            {
                var voidShipmentRequest = new
                {
                    VoidShipmentRequest = new
                    {
                        Request = new
                        {
                            TransactionReference = new
                            {
                                CustomerContext = "Void Shipment Request",
                                XpciVersion = "1.0001"
                            },
                            RequestAction = "1",
                            RequestOption = ""
                        },
                        ShipmentIdentificationNumber = trackingNumber
                    }
                };

                json = Newtonsoft.Json.JsonConvert.SerializeObject(voidShipmentRequest,
                    Newtonsoft.Json.Formatting.None,
                    new Newtonsoft.Json.JsonSerializerSettings
                    {
                        NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
                    });
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: GetVoidShipmentJSON, Message:" + ex.Message);
                MessageBox.Show("General Exception = " + ex.Message, "E");
            }
            return json;
        }
        public static string ReadHtmlPage_POST(string trackingNumber, string InvoiceNo)
        {
            HttpResponseMessage response = null;
            string result = string.Empty;

        Top:
            try
            {
                using (var client = new HttpClient())
                {
                    // UPS required headers
                    client.DefaultRequestHeaders.Add("transId", InvoiceNo); // unique transaction ID
                    client.DefaultRequestHeaders.Add("transactionSrc", "Qbis"); // your source identifier
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + FrmFedExUPSShippingManager.dtUPS.Rows[0]["AccessToken"].ToString()); // replace with OAuth2 token

                    string shipmentIdentificationNumber = trackingNumber; // e.g. 1Z12345E0291980793

                    // Build API URL
                    string url = $"https://onlinetools.ups.com/api/shipments/v1/void/cancel/{shipmentIdentificationNumber}";

                    response = client.DeleteAsync(url).GetAwaiter().GetResult();
                    result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    if (result.Contains("Invalid Authentication Information") == true)
                    {
                        fdex.UPSGenerateToken();
                        goto Top;
                    }

                    Console.WriteLine("Response from UPS API:");
                    Console.WriteLine(response);
                }
            }
            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse errorResponse && errorResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    fdex.UPSGenerateToken();
                    goto Top;
                }
                else
                {
                    using (var respStream = ex.Response?.GetResponseStream())
                    using (var reader = new StreamReader(respStream ?? Stream.Null))
                    {
                        string errorDetails = reader.ReadToEnd();
                        ClsCommon.WriteErrorLogs("UPS Error Details: " + errorDetails);
                    }
                    throw;
                }
            }
            if (result.Contains("Invalid bearer Token"))
            {
                fdex.UPSGenerateToken();
                goto Top;
            }

            return result;
        }
        private static bool ParseVoidShipmentResponse(string json)
        {
            try
            {
                dynamic response = JsonConvert.DeserializeObject<dynamic>(json);

                string code = response?["VoidShipmentResponse"]?["Response"]?["ResponseStatus"]?["Code"];

                if (json.Contains("The Shipment has already been voided"))
                {
                    return true; // Success
                }
                else
                {
                    string errorMsg = response?["response"]?["errors"]?[0]?["message"]?.ToString() ?? "Unknown Error";
                    ClsCommon.WriteErrorLogs("Error:- " + errorMsg);
                    MessageBox.Show("Error:- " + errorMsg);
                    return false;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Parsing Exception: " + ex.Message);
                return false;
            }
        }

        private void dgvShippiedInvoiceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    if (dgvShippiedInvoiceList.CurrentRow.Cells["Services"].Value.ToString().Contains("FedEx") == true)
                    {
                        ProcessStartInfo sInfo = new ProcessStartInfo("https://www.fedex.com/fedextrack/?trknbr=" + dgvShippiedInvoiceList.CurrentRow.Cells[3].Value + "&trkqual=2460508000~" + dgvShippiedInvoiceList.CurrentRow.Cells[3].Value + "~FX");
                        Process.Start(sInfo);
                    }
                    else
                    {
                        ProcessStartInfo sInfo = new ProcessStartInfo("https://www.ups.com/track?loc=en_US&Requester=NES&tracknum=" + dgvShippiedInvoiceList.CurrentRow.Cells[3].Value.ToString() + "&%0DAgreeToTermsAndConditions=yes&WT.z_eCTAid=ct1_eml_Tracking__ct1_eml_qvn_eml_resi_5shp&WT.z_edatesent=03292024/trackdetails");
                        Process.Start(sInfo);
                    }
                }
                else if (e.ColumnIndex == 10)
                {
                    try
                    {
                        if (dtShipInvoice.Rows.Count > 0)
                        {
                            if (dtShipInvoice.Rows[0]["Type"].ToString() == "UPS")
                            {
                                string trackingNumber = dgvShippiedInvoiceList.CurrentRow.Cells[3].Value.ToString();
                                string InvoiceNo = dgvShippiedInvoiceList.CurrentRow.Cells[2].Value.ToString();
                                string Response = string.Empty;
                                Response = ReadHtmlPage_POST(trackingNumber, InvoiceNo);
                                // Parse Response
                                if (ParseVoidShipmentResponse(Response))
                                {
                                    DataTable dtUps = new DataTable();
                                    dtUps = new BALUPS_FedExHistory().SelectByTrackingID(new BOLUPS_FedExHistory() { TrackingID = dgvShippiedInvoiceList.CurrentRow.Cells[3].Value.ToString() });
                                    if (dtUps.Rows.Count > 0)
                                    {
                                        DataTable dtInvoice = new DataTable();
                                        dtInvoice = new BALInvoiceMaster().SelectByRefNumber(new BOLInvoiceMaster() { RefNumber = dtUps.Rows[0]["RefNumber"].ToString() });
                                        if (dtInvoice.Rows.Count > 0)
                                        {
                                            new BALInvoiceDetails().DeleteByItemName(new BOLInvoiceDetails() { InvoiceID = Convert.ToInt32(dtInvoice.Rows[0]["ID"]), ItemName = "Tracking" });
                                            new BALUPS_FedExHistory().DeleteByID(Convert.ToInt32(dtUps.Rows[0]["ID"].ToString()));
                                        }
                                        DateWiseInvoiceLoad();
                                        DataTable dtOrder = new BALInvoiceMaster().SelectOrder(new BOLInvoiceMaster() { RefNumber = dtUps.Rows[0]["RefNumber"].ToString() });
                                        if (dtOrder.Rows.Count > 0 && dtInvoice.Rows.Count > 0)
                                        {
                                            string html = "";
                                            string CustomerNameinVoid = "";
                                            string Address1InVoid = "";
                                            string Address2InVoid = "";
                                            string CityStatecodeInVoid = "";
                                            string CountryInVoid = "";
                                            string NumberofPackagesInVoid = "";
                                            string UPSServiceInVoid = "";
                                            string WeightInVoid = "";
                                            string TrackingNumberInVoid = "";
                                            string ReferenceNumber2InVoid = "";
                                            if (dtOrder.Rows[0]["Email"].ToString() != "")
                                            {
                                                CustomerNameinVoid = dtOrder.Rows[0]["CustomerName"].ToString();
                                                if (dtOrder.Rows[0]["AddressName"].ToString().ToLower().Contains("ship") == false && dtOrder.Rows[0]["AddressName"].ToString() != "" && dtOrder.Rows[0]["CustomerName"].ToString() != dtOrder.Rows[0]["AddressName"].ToString())
                                                {
                                                    Address1InVoid = dtOrder.Rows[0]["AddressName"].ToString();
                                                }
                                                else
                                                {
                                                    Address1InVoid = dtOrder.Rows[0]["Add1"].ToString();
                                                }
                                                if (Address1InVoid == "")
                                                {
                                                    Address1InVoid = dtOrder.Rows[0]["Add2"].ToString();
                                                    Address2InVoid = dtOrder.Rows[0]["Add3"].ToString();
                                                }
                                                else if (Address1InVoid != dtOrder.Rows[0]["Add1"].ToString())
                                                {
                                                    Address2InVoid = dtOrder.Rows[0]["Add1"].ToString() + " " + dtOrder.Rows[0]["Add2"].ToString() + " " + dtOrder.Rows[0]["Add3"].ToString();
                                                }
                                                else if (Address1InVoid == dtOrder.Rows[0]["Add1"].ToString())
                                                {
                                                    Address2InVoid = dtOrder.Rows[0]["Add2"].ToString() + " " + dtOrder.Rows[0]["Add3"].ToString();
                                                }
                                                CityStatecodeInVoid = dtOrder.Rows[0]["City"].ToString() + "," + dtOrder.Rows[0]["State"].ToString() + " " + dtOrder.Rows[0]["PostalCode"].ToString();
                                                CountryInVoid = dtOrder.Rows[0]["Country"].ToString();
                                                NumberofPackagesInVoid = "1";
                                                UPSServiceInVoid = dtUps.Rows[0]["Service"].ToString();
                                                WeightInVoid = dtUps.Rows[0]["Weight"].ToString() + " LBS"; ;
                                                TrackingNumberInVoid = dtUps.Rows[0]["TrackingID"].ToString();
                                                ReferenceNumber2InVoid = dtUps.Rows[0]["RefNumber"].ToString();

                                                if (File.Exists(Application.StartupPath + @"\HTMLPage\" + "Void.html"))
                                                {
                                                    html = File.ReadAllText(Application.StartupPath + @"\HTMLPage\" + "Void.html");
                                                }

                                                string newFile = html.Replace("CustomerNameinVoid", CustomerNameinVoid).Replace("Address1InVoid", Address1InVoid).Replace("Address2InVoid", Address2InVoid).Replace("CityStatecodeInVoid", CityStatecodeInVoid)
                                 .Replace("CountryInVoid", CountryInVoid).Replace("NumberofPackagesInVoid", NumberofPackagesInVoid).Replace("UPSServiceInVoid", UPSServiceInVoid).Replace("WeightInVoid", WeightInVoid)
                                 .Replace("TrackingNumberInVoid", TrackingNumberInVoid).Replace("ReferenceNumber2InVoid", ReferenceNumber2InVoid);


                                                MailMessage msg = new MailMessage();
                                                msg.From = new MailAddress("txpartspay@gmail.com");
                                                msg.To.Add(dtOrder.Rows[0]["Email"].ToString());
                                                msg.Subject = "UPS Ship Cancellation, Tracking Number " + TrackingNumberInVoid + "";
                                                //string FilePath = System.IO.Path.Combine(Application.StartupPath + @"\HTMLSave\" + TrackingNumber + ".html");
                                                //if (File.Exists(FilePath))
                                                //{
                                                //string html1 = File.ReadAllText(FilePath);
                                                string date = DateTime.Now.ToString("dddd, MMMM dd, yyyy hh:MM tt");

                                                msg.Body = "<b>From: </b> <span style=color:black> UPS txpartspay@gmail.com</span><br />" + "<b>Sent: </b>" + date + "<br />" + "<b>To: </b>" + dtOrder.Rows[0]["Email"].ToString() + "<br />" + "<b>Subject: </b> UPS Ship Cancellation, Tracking Number " + TrackingNumberInVoid + "<br />" + newFile;

                                                //msg.Attachments.Add(new Attachment(html1));
                                                msg.IsBodyHtml = true;
                                                using (SmtpClient client = new SmtpClient())
                                                {
                                                    try
                                                    {
                                                        client.Host = "smtp.gmail.com";
                                                        client.EnableSsl = true;
                                                        NetworkCredential netcr = new NetworkCredential("txpartspay@gmail.com", "newqwzinxyjxiybr");
                                                        client.UseDefaultCredentials = false;
                                                        client.Credentials = netcr;
                                                        client.Port = 587;
                                                        client.Send(msg);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        ClsCommon.WriteErrorLogs("Error in VoidNotification Email" + ex.Message);
                                                        MessageBox.Show("Error:" + ex.Message);
                                                    }
                                                }
                                            }
                                        }

                                        ClsCommon.WriteErrorLogs("Ship Invoice Void Successfully");
                                        MessageBox.Show("Ship Invoice Void Successfully");
                                        //cmbTransactionsFilterDate.SelectedIndex = 0;
                                    }
                                }
                            }
                            else if (dtShipInvoice.Rows[0]["Type"].ToString() == "FedEx")
                            {
                                dtFedxRes = new BALUPS_FedExHistory().SelectByTrackingID(new BOLUPS_FedExHistory() { TrackingID = dgvShippiedInvoiceList.CurrentRow.Cells[3].Value.ToString() });
                                if (dtFedxRes.Rows.Count > 0)
                                {
                                    DataTable dtInvoice = new DataTable();
                                    dtInvoice = new BALInvoiceMaster().SelectByRefNumber(new BOLInvoiceMaster() { RefNumber = dtFedxRes.Rows[0]["RefNumber"].ToString() });
                                    ClsCommon.TrakingNo = dtFedxRes.Rows[0]["TrackingID"].ToString();
                                    string Status = CancelShipmentRequest();
                                    if (Status == "OK")
                                    {
                                        SendFedExVoidNotification(dtFedxRes);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ClsCommon.WriteErrorLogs("Form:FrmShippedInvoiceList,Function :dgvShippiedInvoiceList_CellContentClick. Message:" + ex.Message);
                        MessageBox.Show("Error:" + ex.Message);
                    }
                }
                else if (e.ColumnIndex == 12)
                {
                    //PrintDocument pd = new PrintDocument();

                    //var file = Array.Empty<string>(); // Initializes an empty string array

                    //if (dgvShippiedInvoiceList.CurrentRow.Cells["Services"].Value.ToString().Contains("FedEx") == true)
                    //{
                    //    var files = Directory.GetFiles(Application.StartupPath + "\\Fedx\\", dgvShippiedInvoiceList.CurrentRow.Cells["TrackingNumber"].Value + ".png");
                    //    //filePath = Directory.GetFiles(Application.StartupPath + "\\Fedx\\", dgvShippiedInvoiceList.CurrentRow.Cells["TrackingNumber"].Value + ".png");
                    //    file = files;
                    //}
                    //else
                    //{
                    //    var files = Directory.GetFiles(Application.StartupPath + "\\Shipment\\", dgvShippiedInvoiceList.CurrentRow.Cells["TrackingNumber"].Value + ".gif");
                    //    file = files;
                    //}
                    ////PrintDialog pdi = new PrintDialog();
                    //printDialog1.Document = pd;
                    //pd.DocumentName = dgvShippiedInvoiceList.CurrentRow.Cells["TrackingNumber"].Value + ".gif";
                    //foreach (var i in file)
                    //{
                    //    pd.PrintPage += (obj, eve) =>
                    //    {
                    //        System.Drawing.Image img = System.Drawing.Image.FromFile(i);
                    //        double cmToUnits = 88 / 2.54;
                    //        eve.Graphics.DrawImage(img, 10, 15, (float)(11.5 * cmToUnits), (float)(18 * cmToUnits));
                    //    };
                    //}
                    //if (printDialog1.ShowDialog() == DialogResult.OK)
                    //{
                    //    pd.Print();
                    //    MessageBox.Show("Print Successfully");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Print Cancelled");
                    //}                
                    PrintDocument pd = new PrintDocument();
                    List<string> filesToPrint = new List<string>();

                    string trackingNumber = dgvShippiedInvoiceList.CurrentRow.Cells["TrackingNumber"].Value.ToString();
                    string service = dgvShippiedInvoiceList.CurrentRow.Cells["Services"].Value.ToString();

                    // -----------------------------
                    // FEDEX PRINT (MULTI-PACKAGE)
                    // -----------------------------
                    if (service.Contains("FedEx"))
                    {
                        string fedxDir = Path.Combine(Application.StartupPath, "Fedx");

                        if (!Directory.Exists(fedxDir))
                        {
                            MessageBox.Show("FedEx label folder not found.");
                            return;
                        }

                        // Get ALL package images
                        var files = Directory.GetFiles(
                            fedxDir,
                            $"{trackingNumber}_Package_*.png"
                        );

                        if (files.Length == 0)
                        {
                            MessageBox.Show("FedEx label files are missing or deleted.");
                            return;
                        }

                        // Validate missing packages
                        int expectedPackage = 1;
                        foreach (var file in files.OrderBy(f => f))
                        {
                            if (!File.Exists(file))
                            {
                                MessageBox.Show($"Label file missing:\n{Path.GetFileName(file)}");
                                return;
                            }
                            filesToPrint.Add(file);
                            expectedPackage++;
                        }
                    }
                    // -----------------------------
                    // UPS PRINT (OLD LOGIC – SAFE)
                    // -----------------------------
                    else
                    {
                        string upsDir = Path.Combine(Application.StartupPath, "Shipment");

                        if (!Directory.Exists(upsDir))
                        {
                            MessageBox.Show("UPS label folder not found.");
                            return;
                        }

                        var files = Directory.GetFiles(
                            upsDir,
                            trackingNumber + ".gif"
                        );

                        if (files.Length == 0)
                        {
                            MessageBox.Show("UPS label file is missing or deleted.");
                            return;
                        }

                        filesToPrint.AddRange(files);
                    }

                    // -----------------------------
                    // PRINT LOGIC (MULTI-PAGE)
                    // -----------------------------
                    int currentPrintIndex = 0;

                    pd.PrintPage += (senders, ev) =>
                    {
                        using (Image img = Image.FromFile(filesToPrint[currentPrintIndex]))
                        {
                            double cmToUnits = 88 / 2.54;
                            ev.Graphics.DrawImage(
                                img,
                                10,
                                15,
                                (float)(11.5 * cmToUnits),
                                (float)(18 * cmToUnits)
                            );
                        }

                        currentPrintIndex++;
                        ev.HasMorePages = currentPrintIndex < filesToPrint.Count;
                    };

                    printDialog1.Document = pd;
                    pd.DocumentName = trackingNumber;

                    if (printDialog1.ShowDialog() == DialogResult.OK)
                    {
                        pd.Print();
                        MessageBox.Show("Print Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Print Cancelled");
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmShippedInvoiceList,Function :dgvShippiedInvoiceList_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void SendFedExVoidNotification(DataTable dtFedxRes)
        {
            try
            {
                string htmlPath = Application.StartupPath + @"\HTMLPage\fedex-cancelled.html";
                if (!File.Exists(htmlPath))
                {
                    MessageBox.Show("FedEx Void HTML template not found.");
                    return;
                }

                string html = File.ReadAllText(htmlPath);
                string labelWeightInShipB = dtFedxRes.Rows[0]["Weight"].ToString() + " LBS";
                string TrackingNumberInShip = dtFedxRes.Rows[0]["TrackingID"].ToString();
                string Email = dtFedxRes.Rows[0]["Email"].ToString();

                string newFile = html
                    .Replace("labelWeightInShipB", labelWeightInShipB)
                    .Replace("TrackingNumberInShip", TrackingNumberInShip);
                if (Email != "")
                {
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("txpartspay@gmail.com");
                    msg.To.Add(Email);
                    msg.Subject = "FedEx Shipment Cancellation - Tracking " + TrackingNumberInShip;

                    string date = DateTime.Now.ToString("dddd, MMMM dd, yyyy hh:mm tt");

                    msg.Body =
                        "<b>From:</b> FedEx txpartspay@gmail.com<br/>" +
                        "<b>Sent:</b> " + date + "<br/>" +
                        "<b>To:</b> " + Email + "<br/>" +
                        "<b>Subject:</b> FedEx Shipment Cancellation - Tracking " + TrackingNumberInShip + "<br/><br/>" +
                        newFile;

                    msg.IsBodyHtml = true;

                    using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                    {
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(
                            "txpartspay@gmail.com",
                            "newqwzinxyjxiybr"
                        );

                        client.Send(msg);
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("FedEx Void Notification Error: " + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        public void getOrderIDToken(int OrderId)
        {
            string jsonInput = "";
            string apiResponse = "";
            try
            {
                jsonInput = "";
                jsonInput += "{";
                jsonInput += "\"email\":\"" + "qb@txparts.com" + "\",";
                jsonInput += "\"password\":\"" + "12345678" + "\",";
                jsonInput += "\"source\":\"" + "1" + "\"";
                jsonInput += "}";
                ClsAPIOperations.PostToken(jsonInput, "login");
                if (ClsAPIOperations.ApiToken != "")
                {
                    if (OrderId != 0)
                    {
                        jsonInput = "";
                        jsonInput = "{";
                        jsonInput += "\"order_id\":\"" + OrderId.ToString() + "\",";
                        jsonInput += "\"source\":\"1\"";
                        jsonInput += "}";
                        apiResponse = ClsAPIOperations.PostToken(jsonInput, "shipment-void");
                        ClsCommon.WriteErrorLogs("Shipment txparts response :- " + apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Class:Program,Function :Main. Message:" + ex.Message);
                ClsCommon.WriteErrorLogs("Class:Program,Function :Main. Message:" + ex.Message);
            }
        }
        public string CancelShipmentRequest()
        {
            string Status = "";
            if (FrmFedExUPSShippingManager.dtFedEx.Rows.Count > 0)
            {
                try
                {

                Top:
                    var client = new HttpClient();
                    var url = "https://apis.fedex.com/ship/v1/shipments/cancel";
                    var JsonFedx = CancelShipFedex();
                    var request = new HttpRequestMessage(HttpMethod.Put, url);
                    request.Headers.Add("Authorization", "Bearer " + FrmFedExUPSShippingManager.dtFedEx.Rows[0]["AccessToken"].ToString() + "");
                    request.Content = new StringContent(JsonFedx, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = null;
                    try
                    {
                        var task = client.SendAsync(request);
                        task.Wait(); // Wait for the task to complete synchronously

                        response = task.Result; // Get the result of the task

                        response.EnsureSuccessStatusCode();

                        // Read the response content synchronously
                        var responseBodyTask = response.Content.ReadAsStringAsync();
                        var responseBody = "";
                        if (response.ReasonPhrase == "OK")
                        {
                            Status = "OK";
                            responseBody = responseBodyTask.Result;
                            if (dtInvoice.Rows.Count > 0)
                            {
                                new BALInvoiceDetails().DeleteByItemName(new BOLInvoiceDetails() { InvoiceID = Convert.ToInt32(dtInvoice.Rows[0]["ID"]), ItemName = "Tracking" });
                                new BALUPS_FedExHistory().DeleteByID(Convert.ToInt32(dtFedxRes.Rows[0]["ID"].ToString()));
                            }
                            DateWiseInvoiceLoad();

                            ClsCommon.WriteErrorLogs("Ship Invoice Void Successfully");
                            MessageBox.Show("Ship Invoice Void Successfully");
                            //clsOnline.ExtractFedxResponse(responseBody);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains(" 401 (Unauthorized)") == true)
                        {
                            fdex.FedXGenerateToken();
                            goto Top;
                        }
                        else
                        {
                            MessageBox.Show(ex.Message);

                        }
                    }

                }
                catch (Exception ex)
                {
                    ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: AcceptShipmentRequest, Message:" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Not Found Token");
            }
            return Status;
        }
        public string CancelShipFedex()
        {

            var dateTime = DateTime.Now;
            string formattedDate = dateTime.ToString("yyyy-MM-dd");
            string Json = "";
            try
            {


                Json += "{";
                if (FrmFedExUPSShippingManager.dtFedEx.Rows.Count > 0)
                {
                    Json += "\"accountNumber\":{\"value\":\"" + FrmFedExUPSShippingManager.dtFedEx.Rows[0]["AccountNo"].ToString() + "\"},";
                }
                else
                {
                    Json += "\"accountNumber\":{\"value\":\"844084846\"},";

                }
                Json += "\"emailShipment\":\"false\",";
                Json += "\"senderCountryCode\":\"US\",";
                Json += "\"deletionControl\":\"DELETE_ALL_PACKAGES\",";
                Json += "\"trackingNumber\":\"" + ClsCommon.TrakingNo + "\"";
                Json += "}";

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: CancelShipFedex, Message:" + ex.Message);
                MessageBox.Show("General Exception = " + ex.Message, "E");
            }
            return Json;
        }
        public void DateWiseInvoiceLoad()
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;
                lblFrom.Visible = false; lblto.Visible = false; dtTranFrom.Visible = false; dtTranTo.Visible = false;
                //All Invoices

                if (cmbTransactionsFilterDate.SelectedIndex == 0)
                {
                    //Today
                    dtShipInvoice = new DataTable();
                    dtShipInvoice = new BALUPS_FedExHistory().SelectByFilter(new BOLUPS_FedExHistory() { StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                    //dtShipInvoice = new BALInvoiceMaster().SelectByCustomerWiseInvoices(new BOLInvoiceMaster() { CustomerID = CusID, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 1)
                {
                    //yesterday
                    dtShipInvoice = new DataTable();
                    DateTime dt1 = DateTime.Now.AddDays(-1);
                    dtShipInvoice = new BALUPS_FedExHistory().SelectByFilter(new BOLUPS_FedExHistory() { StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 2)
                {
                    //this month
                    dtShipInvoice = new DataTable();
                    DateTime dt = DateTime.Now;
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    dtShipInvoice = new BALUPS_FedExHistory().SelectByFilter(new BOLUPS_FedExHistory() { StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 3)
                {
                    //this week
                    dtShipInvoice = new DataTable();
                    DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
                    DateTime dt1 = dt.AddDays(6);
                    dtShipInvoice = new BALUPS_FedExHistory().SelectByFilter(new BOLUPS_FedExHistory() { StartDate = dt.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 4)
                {
                    //last month
                    dtShipInvoice = new DataTable();
                    DateTime dt = DateTime.Now.AddMonths(-1);
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    dtShipInvoice = new BALUPS_FedExHistory().SelectByFilter(new BOLUPS_FedExHistory() { StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 5)
                {
                    //this ficsal year
                    dtShipInvoice = new DataTable();
                    int year = DateTime.Now.Year;
                    DateTime firstDay = Convert.ToDateTime(year + "-" + "01" + "-" + "01");
                    dtShipInvoice = new BALUPS_FedExHistory().SelectByFilter(new BOLUPS_FedExHistory() { StartDate = firstDay.ToString("yyyy-MM-dd"), EndDate = firstDay.AddYears(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 6)
                {
                    //All
                    dtShipInvoice = new DataTable();
                    dtShipInvoice = new BALUPS_FedExHistory().SelectByFilter(new BOLUPS_FedExHistory() { StartDate = null, EndDate = null });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 7)
                {
                    //Custom
                    dtShipInvoice = new DataTable();
                    lblFrom.Visible = true; lblto.Visible = true; dtTranFrom.Visible = true; dtTranTo.Visible = true;

                }
                if (dtShipInvoice.Rows.Count > 0)
                {

                    dtInvoice = dtShipInvoice;
                    int j = 0;
                    dgvShippiedInvoiceList.Rows.Clear();
                    for (int i = 0; i < dtShipInvoice.Rows.Count; i++)
                    {
                        dgvShippiedInvoiceList.Rows.Add();
                        dgvShippiedInvoiceList.Rows[j].Cells["ID"].Value = dtShipInvoice.Rows[i]["ID"].ToString();
                        dgvShippiedInvoiceList.Rows[j].Cells["CustomerName"].Value = dtShipInvoice.Rows[i]["CustomerName"].ToString();
                        dgvShippiedInvoiceList.Rows[j].Cells["InvoiceNo"].Value = dtShipInvoice.Rows[i]["RefNumber"].ToString();
                        //dgvShippiedInvoiceList.Rows[j].Cells[3].Value = dtInvoice.Rows[i]["RefNumber"].ToString();
                        if (dtShipInvoice.Rows[i]["Time"].ToString() != "")
                            dgvShippiedInvoiceList.Rows[j].Cells["TxnDate"].Value = Convert.ToDateTime(dtShipInvoice.Rows[i]["Time"].ToString()).ToString("HH:mm:ss");
                        dgvShippiedInvoiceList.Rows[j].Cells["TrackingNumber"].Value = dtShipInvoice.Rows[i]["TrackingID"].ToString();
                        if (dtShipInvoice.Rows[i]["Time"].ToString() != "")
                            dgvShippiedInvoiceList.Rows[j].Cells["ShipDate"].Value = Convert.ToDateTime(dtShipInvoice.Rows[i]["Time"].ToString()).ToString("MM-dd-yyyy");
                        if (dtShipInvoice.Rows[i]["Weight"].ToString() != "")
                            dgvShippiedInvoiceList.Rows[j].Cells["Weight"].Value = dtShipInvoice.Rows[i]["Weight"].ToString();
                        if (dtShipInvoice.Rows[i]["Service"].ToString() != "")
                            dgvShippiedInvoiceList.Rows[j].Cells["Services"].Value = dtShipInvoice.Rows[i]["Service"].ToString();
                        if (dtShipInvoice.Rows[i]["Charges"].ToString() != "")
                            dgvShippiedInvoiceList.Rows[j].Cells["ESTCharges"].Value = dtShipInvoice.Rows[i]["TotalCost"].ToString();
                        if (dtShipInvoice.Rows[i]["COD"].ToString() != "")
                        {
                            dgvShippiedInvoiceList.Rows[j].Cells["COD"].Value = dtShipInvoice.Rows[i]["COD"].ToString();
                        }
                        else
                        {
                            dgvShippiedInvoiceList.Rows[j].Cells["COD"].Value = "0";
                        }
                        dgvShippiedInvoiceList.Rows[j].Cells["ID1"].Value = dtShipInvoice.Rows[i]["ID1"].ToString();

                        j++;
                    }
                }
                else
                {
                    dgvShippiedInvoiceList.Rows.Clear();
                    //lblCusWiseTotal.Text = "0.00";
                }
                Cursor.Current = Cursors.Default;
                lblTotal.Text = dtShipInvoice.Rows.Count.ToString();


            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmCustomerCenter,Function :CustomerWiseInvoiceLoad. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void cmbTransactionsFilterDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTransactionsFilterDate.SelectedIndex >= 0)
            {
                DateWiseInvoiceLoad();
            }
        }
        private void dtTranTo_Leave(object sender, EventArgs e)
        {
            dtShipInvoice = new DataTable();
            dtShipInvoice = new BALUPS_FedExHistory().SelectByFilter(new BOLUPS_FedExHistory() { StartDate = dtTranFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTranTo.Value.ToString("yyyy-MM-dd") });
            if (dtShipInvoice.Rows.Count > 0)
            {
                dtInvoice = dtShipInvoice;
                int j = 0;
                dgvShippiedInvoiceList.Rows.Clear();
                for (int i = 0; i < dtShipInvoice.Rows.Count; i++)
                {
                    dgvShippiedInvoiceList.Rows.Add();
                    dgvShippiedInvoiceList.Rows[j].Cells["ID"].Value = dtShipInvoice.Rows[i]["ID"].ToString();
                    dgvShippiedInvoiceList.Rows[j].Cells["CustomerName"].Value = dtShipInvoice.Rows[i]["CustomerName"].ToString();
                    dgvShippiedInvoiceList.Rows[j].Cells["InvoiceNo"].Value = dtShipInvoice.Rows[i]["RefNumber"].ToString();
                    //dgvShippiedInvoiceList.Rows[j].Cells[3].Value = dtInvoice.Rows[i]["RefNumber"].ToString();
                    if (dtShipInvoice.Rows[i]["Time"].ToString() != "")
                        dgvShippiedInvoiceList.Rows[j].Cells["TxnDate"].Value = Convert.ToDateTime(dtShipInvoice.Rows[i]["Time"].ToString()).ToString("HH:mm:ss");
                    dgvShippiedInvoiceList.Rows[j].Cells["TrackingNumber"].Value = dtShipInvoice.Rows[i]["TrackingID"].ToString();
                    if (dtShipInvoice.Rows[i]["Time"].ToString() != "")
                        dgvShippiedInvoiceList.Rows[j].Cells["ShipDate"].Value = Convert.ToDateTime(dtShipInvoice.Rows[i]["Time"].ToString()).ToString("MM-dd-yyyy");
                    if (dtShipInvoice.Rows[i]["Weight"].ToString() != "")
                        dgvShippiedInvoiceList.Rows[j].Cells["Weight"].Value = dtShipInvoice.Rows[i]["Weight"].ToString();
                    if (dtShipInvoice.Rows[i]["Service"].ToString() != "")
                        dgvShippiedInvoiceList.Rows[j].Cells["Services"].Value = dtShipInvoice.Rows[i]["Service"].ToString();
                    if (dtShipInvoice.Rows[i]["Charges"].ToString() != "")
                        dgvShippiedInvoiceList.Rows[j].Cells["ESTCharges"].Value = dtShipInvoice.Rows[i]["TotalCost"].ToString();
                    if (dtShipInvoice.Rows[i]["COD"].ToString() != "")
                    {
                        dgvShippiedInvoiceList.Rows[j].Cells["COD"].Value = dtShipInvoice.Rows[i]["COD"].ToString();
                    }
                    else
                    {
                        dgvShippiedInvoiceList.Rows[j].Cells["COD"].Value = "0";
                    }
                    dgvShippiedInvoiceList.Rows[j].Cells["ID1"].Value = dtShipInvoice.Rows[i]["ID1"].ToString();

                    j++;
                }
            }
            else
            {
                dgvShippiedInvoiceList.Rows.Clear();
                //lblCusWiseTotal.Text = "0.00";
            }

        }
        private void dgvShippiedInvoiceList_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip contexMenu = new ContextMenuStrip();
                contexMenu.Items.Add("Copy");
                contexMenu.Items.Add("Copy Tracking Number");
                contexMenu.Show();
                contexMenu.Show(dgvShippiedInvoiceList, new Point(e.X, e.Y));
                contexMenu.ItemClicked += new ToolStripItemClickedEventHandler(
                       contexMenu_ItemClicked);
            }
        }
        void contexMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            // Refresh the DataGridView to ensure selections are up-to-date
            dgvShippiedInvoiceList.Refresh();
            DataObject d = dgvShippiedInvoiceList.GetClipboardContent();

            if (e.ClickedItem.Text == "Copy Tracking Number")
            {
                StringBuilder clipboardBuilder = new StringBuilder();

                // Ensure that there are selected rows before proceeding
                if (dgvShippiedInvoiceList.SelectedRows.Count > 0)
                {
                    // Iterate over the selected rows
                    foreach (DataGridViewRow row in dgvShippiedInvoiceList.SelectedRows)
                    {
                        // Ensure the cell index 3 (tracking number) exists
                        if (row.Cells.Count > 3)
                        {
                            // Get the tracking number from cell index 3
                            string trackingNumber = row.Cells[3].FormattedValue.ToString();

                            // Debug: Log the tracking number to ensure correct values are being processed
                            Console.WriteLine("Tracking Number: " + trackingNumber);

                            // Append only unique tracking numbers
                            if (!clipboardBuilder.ToString().Contains(trackingNumber))
                            {
                                clipboardBuilder.AppendLine(trackingNumber);
                            }
                        }
                        else
                        {
                            // Log if the row does not have enough cells
                            Console.WriteLine("Row does not have enough cells.");
                        }
                    }

                    // Set the clipboard content with unique tracking numbers
                    Clipboard.SetText(clipboardBuilder.ToString().Trim());
                }
                else
                {
                    // Log if no rows are selected
                    Console.WriteLine("No rows selected.");
                }
            }
            else if (e.ClickedItem.Text == "Copy")
            {
                if (d != null)
                {
                    Clipboard.SetDataObject(d);
                }
            }
        }
    }
}