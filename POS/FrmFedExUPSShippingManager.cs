using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Application = System.Windows.Forms.Application;
using DataTable = System.Data.DataTable;
using DateTime = System.DateTime;
using Exception = System.Exception;
using Formatting = Newtonsoft.Json.Formatting;
using ImageFormat = System.Drawing.Imaging.ImageFormat;
using Message = System.Windows.Forms.Message;
using PaperSource = System.Drawing.Printing.PaperSource;
using Point = System.Drawing.Point;

namespace POS
{
    public partial class FrmFedExUPSShippingManager : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALUPS_FedExHistory objBAL = new BALUPS_FedExHistory();
        BOLUPS_FedExHistory objBOL = new BOLUPS_FedExHistory();
        DataTable dtAccessUPS = new DataTable();
        string _Status = "";
        public string ID = "";
        public string RefNumber = "";
        public string ServiceID = "";
        public string Carrier = "";
        public static DataTable dtUPS = new DataTable();
        public static DataTable dtFedEx = new DataTable();
        public string Total = "";
        //princy
        public static string jsonInput = "";
        public static string apiResponse = "";
        public static string type = "";

        public FrmFedExUPSShippingManager()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.Location = new Point(0, 50);
            lblCost.Visible = false;
            dtUPS = new BALUPSSettings().SelectByType("UPS");
            dtFedEx = new BALUPSSettings().SelectByType("FedX");
        }

        private static string NormalizePostalCode(string postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode))
                return string.Empty;

            // Canadian postal codes are alphanumeric and commonly formatted like "K1A 0B1".
            // Normalize by removing spaces/hyphens before sending to carrier APIs.
            return postalCode.Trim().ToUpperInvariant().Replace(" ", "").Replace("-", "");
        }

        private static string NormalizeCountryCode(string countryCode)
        {
            if (string.IsNullOrWhiteSpace(countryCode))
                return "CA";

            var upper = countryCode.Trim().ToUpperInvariant();
            if (upper == "CA" || upper == "CANADA")
                return "CA";

            // This project is Canada-focused; if US variants show up, map them to CA.
            if (upper == "US" || upper == "USA" || upper.Contains("UNITED STATES"))
                return "CA";

            return upper.Length >= 2 ? upper.Substring(0, 2) : upper;
        }

        public void LoadFunction()
        {
            try
            {
                dtUPS = new BALUPSSettings().SelectByType("UPS");
                dtFedEx = new BALUPSSettings().SelectByType("FedX");
                lblCost.Visible = false;
                Clear();
                LoadShippingAddress();
                LoadFromUser("UPS");
                LoadUPSService();
                rdbUPS.Checked = true;
                if (cmbFrom.Items.Count > 1)
                    cmbFrom.SelectedIndex = 1;
                dgvPackage.Rows.Add("Delete", 5, txtLength.Text.ToString(), txtWidth.Text.ToString(), txtHeight.Text.ToString());
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: LoadFunction, Message:" + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        private void FrmUPSShippingManager_Load(object sender, EventArgs e)
        {
            try
            {
                txtToCompany.Text = "";
                txtToName.Text = "";
                txtToPhone.Text = "";
                txtToAddress1.Text = "";
                txtToAddress2.Text = "";
                txtToCity.Text = "";
                txtToState.Text = "";
                txtToZip.Text = "";
                txtToCountry.Text = "";
                txtToEmail.Text = "";
                //Hiren 
                ClsCommon.ShippingAddressNote = "";

                dtUPS = new BALUPSSettings().SelectByType("UPS");
                dtFedEx = new BALUPSSettings().SelectByType("FedX");
                txtWeight.Text = "";
                LoadDeliveryConfirmation();
                LoadCOD();
                //btnShip.Enabled = false;
                LoadShippingAddress();
                if (cmbFrom.Items.Count > 1)
                    cmbFrom.SelectedIndex = 1;
                cmbPackaging.SelectedIndex = 0;
                cmbPayment.SelectedIndex = 0;
                txtDeclaredValue.Text = "";
                lblCost.Visible = false;
                dgvPackage.Rows.Add("Delete", 5, txtLength.Text.ToString(), txtWidth.Text.ToString(), txtHeight.Text.ToString());

                chkSaturdayDelivery.Checked = false;
                chkSaturdayPickup.Checked = false;
                chkDirectDeliveryOnly.Checked = false;
                chkCOD.Checked = false;
                txtCODAmount.Clear();
                cmbCOD.SelectedIndex = 0;
                lblamount.Enabled = false;
                lbldoller.Enabled = false;
                txtCODAmount.Enabled = false;
                cmbCOD.Enabled = false;
                lblFunds.Enabled = false;
                dtAccessUPS = new BALAccessUPSSettings().Select(Convert.ToInt32(ClsCommon.UserID));
                if (dtAccessUPS.Rows.Count > 0)
                {
                    if (dtAccessUPS.Rows[0]["DeliveryConfirmation"].ToString() == "1")
                    {
                        cmbConfirmation.Enabled = true;
                    }
                    else
                    {
                        cmbConfirmation.Enabled = false;
                    }
                    if (dtAccessUPS.Rows[0]["COD"].ToString() == "1")
                    {
                        chkCOD.Enabled = true;
                        cmbCOD.SelectedValue = "8";
                    }
                    else
                    {
                        chkCOD.Enabled = false;
                    }
                    if (dtAccessUPS.Rows[0]["OtherService"].ToString() == "1")
                    {
                        chkSaturdayDelivery.Enabled = true;
                        chkSaturdayPickup.Enabled = true;
                        chkDirectDeliveryOnly.Enabled = true;
                    }
                    else
                    {
                        chkSaturdayDelivery.Enabled = false;
                        chkSaturdayPickup.Enabled = false;
                        chkDirectDeliveryOnly.Enabled = false;
                    }
                }
                else
                {
                    chkSaturdayDelivery.Enabled = false;
                    cmbConfirmation.Enabled = false;
                    chkCOD.Enabled = false;
                    chkSaturdayPickup.Enabled = false;
                    chkDirectDeliveryOnly.Enabled = false;
                }
                if (ClsCommon.COD == true)
                {
                    chkCOD.Checked = true;
                    txtCODAmount.Text = ClsCommon.CODAmount;
                    chkCOD.Enabled = true;
                    cmbCOD.SelectedValue = "8";
                }
                if (ClsCommon.ShipMethod == "UPS SATURDAY")
                {
                    chkSaturdayDelivery.Checked = true;
                    cmbService.Text = "UPS Next Day Air";
                }
                //Hiren
                if (ClsCommon.ShipMethod == "FEDEX SATURDAY")
                {
                    chkSaturdayDelivery.Checked = true;
                    cmbService.Text = "FedEx Priority Overnight®";
                }
                //
                //txtRefNumber.Text= "Invoice #"+ClsCommon.RefNumber;
                txtRefNumber.Text = ClsCommon.RefNumber;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: FrmUPSShippingManager_Load, Message:" + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void Clear()
        {
            //rdbFedEx.Checked = false;
            //rdbUPS.Checked = false;
            cmbFrom.DataSource = null;
            lblAddress1.Text = "";
            lblAddress2.Text = "";
            lblCity.Text = "";
            lblCompanyName.Text = "";
            lblCountry.Text = "";
            lblName.Text = "";
            lblPhone.Text = "";
            lblState.Text = "";
            lblUPSID.Text = "";
            lblZip.Text = "";
            lblTotalCost.Visible = false;
            txtTotalCost.Visible = false;
            txtDeclaredValue.Text = "";
            txtLength.Text = "0";
            txtWidth.Text = "0";
            txtHeight.Text = "0";

            //txtToCompany.Text = "";
            //txtToName.Text = "";
            //txtToPhone.Text = "";
            //txtToAddress1.Text = "";
            //txtToAddress2.Text = "";
            //txtToCity.Text = "";
            //txtToState.Text = "";
            //txtToZip.Text = "";
            //txtToCountry.Text = "";
            //txtToEmail.Text = "";
        }

        // Get From Address
        private void LoadFromUser(string ShippingName)
        {
            try
            {
                DataTable dt = new BALFromShipping().SelectUPS(new BOLFromShipping() { FromAddress = ShippingName });
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[1] = "--Select From Address--";
                    dt.Rows.InsertAt(dr, 0);
                    cmbFrom.DataSource = dt;
                    cmbFrom.DisplayMember = "CompanyName";
                    cmbFrom.ValueMember = "ID";
                }
                else
                {
                    cmbFrom.DataSource = null;
                    cmbFrom.Items.Add("NO Any From Address");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: LoadFromUser, Message:" + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //Get Services
        public void LoadUPSService()
        {
            try
            {
                DataTable dtService = new DataTable();

                dtService.Columns.Add(new DataColumn("Code"));
                dtService.Columns.Add(new DataColumn("Description"));
                dtService.Rows.Add("0", "Select Service");
                dtService.Rows.Add("03", "UPS Ground");
                dtService.Rows.Add("13", "UPS Next Day Air Saver");
                dtService.Rows.Add("02", "UPS 2nd Day Air");
                dtService.Rows.Add("12", "UPS 3 Day Select");
                dtService.Rows.Add("01", "UPS Next Day Air");

                //dtService.Rows.Add("0", "Select Service");
                //dtService.Rows.Add("3", "UPS Ground");
                //dtService.Rows.Add("12", "UPS 3 Day Select");
                //dtService.Rows.Add("2", "UPS 2nd Day Air");
                //dtService.Rows.Add("59", "UPS  2nd Day Air AM");
                //dtService.Rows.Add("13", "UPS Next Day Air Saver");
                //dtService.Rows.Add("1", "UPS Next Day Air");
                //dtService.Rows.Add("14", "UPS Next Day Air Early A.M.");

                cmbService.DataSource = dtService;
                cmbService.DisplayMember = "Description";
                cmbService.ValueMember = "Code";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: LoadUPSService, Message:" + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void LoadCOD()
        {
            try
            {
                DataTable dtService = new DataTable();

                dtService.Columns.Add(new DataColumn("Code"));
                dtService.Columns.Add(new DataColumn("Description"));
                dtService.Rows.Add("0", "Select Service");
                dtService.Rows.Add("9", "All Funds");
                dtService.Rows.Add("8", "Cashier Check or Money Order");
                cmbCOD.DataSource = dtService;
                cmbCOD.DisplayMember = "Description";
                cmbCOD.ValueMember = "Code";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: LoadCOD, Message:" + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void LoadDeliveryConfirmation()
        {
            try
            {
                DataTable dtService = new DataTable();

                dtService.Columns.Add(new DataColumn("Code"));
                dtService.Columns.Add(new DataColumn("Description"));
                dtService.Rows.Add("0", "Select Service");
                //dtService.Rows.Add("1", "None");
                //dtService.Rows.Add("2", "Delivery Confirmation");
                dtService.Rows.Add("2", "Signature Requird");
                dtService.Rows.Add("3", "Adult Signature Requird");
                cmbConfirmation.DataSource = dtService;
                cmbConfirmation.DisplayMember = "Description";
                cmbConfirmation.ValueMember = "Code";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: LoadCOD, Message:" + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadFedExService()
        {
            try
            {
                DataTable dtService = new DataTable();

                dtService.Columns.Add(new DataColumn("ENUM"));
                dtService.Columns.Add(new DataColumn("Description"));

                dtService.Rows.Add("00", "Select Service");
                //dtService.Rows.Add("FEDEX_GROUND", "FedEx Ground.");
                //dtService.Rows.Add("GROUND_HOME_DELIVERY", "FedEx Home Delivery®");
                //dtService.Rows.Add("FEDEX_EXPRESS_SAVER", "FedEx Express Saver®");
                //dtService.Rows.Add("FEDEX_2_DAY", "FedEx 2Day®");
                //dtService.Rows.Add("STANDARD_OVERNIGHT", "FedEx Standard Overnight®");
                //dtService.Rows.Add("PRIORITY_OVERNIGHT", "FedEx Priority Overnight®");
                dtService.Rows.Add("FIRST_OVERNIGHT", "FedEx First Overnight®");
                dtService.Rows.Add("PRIORITY_OVERNIGHT", "FedEx Priority Overnight®");
                dtService.Rows.Add("STANDARD_OVERNIGHT", "FedEx Standard Overnight®");
                dtService.Rows.Add("FEDEX_2_DAY_AM", "FedEx 2Day® A.M.");
                dtService.Rows.Add("FEDEX_2_DAY", "FedEx 2Day®");
                dtService.Rows.Add("FEDEX_EXPRESS_SAVER", "FedEx Express Saver®");
                dtService.Rows.Add("GROUND_HOME_DELIVERY", "FedEx Home Delivery®");
                dtService.Rows.Add("FEDEX_GROUND", "FedEx Ground.");


                //dtService.Rows.Add("02", "fedex_2_day_am");
                //dtService.Rows.Add("03", "fedex_2_day_am_one_rate");
                //dtService.Rows.Add("04", "fedex_2_day_one_rate");
                //dtService.Rows.Add("05", "fedex_distance_deferred");
                //dtService.Rows.Add("06", "fedex_europe_first_international_priority");
                //dtService.Rows.Add("07", "fedex_express_saver");
                //dtService.Rows.Add("08", "fedex_express_saver_one_rate");
                //dtService.Rows.Add("09", "fedex_first_overnight");
                //dtService.Rows.Add("10", "fedex_first_overnight_one_rate");
                //dtService.Rows.Add("11", "fedex_ground");
                //dtService.Rows.Add("12", "fedex_ground_home_delivery");
                //dtService.Rows.Add("13", "fedex_international_economy");
                //dtService.Rows.Add("14", "fedex_international_first");
                //dtService.Rows.Add("15", "fedex_international_priority");
                //dtService.Rows.Add("16", "fedex_next_day_afternoon");
                //dtService.Rows.Add("17", "fedex_next_day_early_morning");
                //dtService.Rows.Add("18", "fedex_next_day_end_of_day");
                //dtService.Rows.Add("19", "fedex_next_day_mid_morning");
                //dtService.Rows.Add("20", "fedex_priority_overnight");
                //dtService.Rows.Add("21", "fedex_priority_overnight_one_rate");
                //dtService.Rows.Add("22", "fedex_same_day");
                //dtService.Rows.Add("23", "fedex_same_day_city");
                //dtService.Rows.Add("24", "fedex_standard_overnight");
                //dtService.Rows.Add("25", "fedex_standard_overnight_one_rate");
                cmbService.DataSource = dtService;
                cmbService.DisplayMember = "Description";
                cmbService.ValueMember = "ENUM";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: LoadFedExService, Message:" + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadFedExPackage()
        {
            DataTable dtPackage = new DataTable();

            dtPackage.Columns.Add(new DataColumn("Code"));
            dtPackage.Columns.Add(new DataColumn("Description"));

            //dtPackage.Rows.Add("00", "Select Service");
            //dtPackage.Rows.Add("01", "custom");
            //dtPackage.Rows.Add("02", "fedex_10kg_box");
            //dtPackage.Rows.Add("03", "fedex_25kg_box");
            //dtPackage.Rows.Add("04", "fedex_box");
            //dtPackage.Rows.Add("05", "fedex_envelope");
            //dtPackage.Rows.Add("06", "fedex_extra_large_box");
            //dtPackage.Rows.Add("07", "fedex_large_box");
            //dtPackage.Rows.Add("08", "fedex_medium_box");
            //dtPackage.Rows.Add("09", "fedex_pak");
            //dtPackage.Rows.Add("10", "fedex_small_box");
            //dtPackage.Rows.Add("11", "fedex_tube");

            //dtPackage.Rows.Add("00", "Box/Other Packaging");
            dtPackage.Rows.Add("FEDEX_LARGE_BOX", "FedEx® Large Box");
            dtPackage.Rows.Add("FEDEX_MEDIUM_BOX", "FedEx® Medium Box");
            dtPackage.Rows.Add("FEDEX_SMALL_BOX", "FedEx® Small Box");
            dtPackage.Rows.Add("FEDEX_EXTRA_LARGE_BOX", "FedEx® Extra Large Box");
            dtPackage.Rows.Add("FEDEX_ENVELOPE", "FedEx® Envelope");
            dtPackage.Rows.Add("FEDEX_PAK", "FedEx® Pak");
            dtPackage.Rows.Add("FEDEX_BOX", "FedEx® Box");
            dtPackage.Rows.Add("FEDEX_TUBE", "FedEx® Tube");
            dtPackage.Rows.Add("YOUR_PACKAGING", "Box/Other Packaging"); // Repeated like in your image

            cmbPackaging.DataSource = dtPackage;
            cmbPackaging.DisplayMember = "Description";
            cmbPackaging.ValueMember = "Code";
        }
        private void LoadUPSPackage()
        {
            DataTable dtPackage = new DataTable();

            dtPackage.Columns.Add(new DataColumn("Code"));
            dtPackage.Columns.Add(new DataColumn("Description"));

            //dtPackage.Rows.Add("00", "Select Service");
            //dtPackage.Rows.Add("01", "custom");
            //dtPackage.Rows.Add("02", "fedex_10kg_box");
            //dtPackage.Rows.Add("03", "fedex_25kg_box");
            //dtPackage.Rows.Add("04", "fedex_box");
            //dtPackage.Rows.Add("05", "fedex_envelope");
            //dtPackage.Rows.Add("06", "fedex_extra_large_box");
            //dtPackage.Rows.Add("07", "fedex_large_box");
            //dtPackage.Rows.Add("08", "fedex_medium_box");
            //dtPackage.Rows.Add("09", "fedex_pak");
            //dtPackage.Rows.Add("10", "fedex_small_box");
            //dtPackage.Rows.Add("11", "fedex_tube");

            dtPackage.Rows.Add("00", "Customer Packaging");
            dtPackage.Rows.Add("01", "UPS Letter");
            dtPackage.Rows.Add("02", "UPS Express Box");
            dtPackage.Rows.Add("03", "UPS 10kg Box");
            dtPackage.Rows.Add("04", "UPS 25kg Box");
            dtPackage.Rows.Add("05", "UPS Tube");
            dtPackage.Rows.Add("06", "UPS Pak");
            dtPackage.Rows.Add("07", "UPS Express Envelope");
            dtPackage.Rows.Add("08", "UPS Worldwide Express Box");
            dtPackage.Rows.Add("09", "Other Packaging");

            cmbPackaging.DataSource = dtPackage;
            cmbPackaging.DisplayMember = "Description";
            cmbPackaging.ValueMember = "Code";
        }
        //FedEx
        private void rdbFedEx_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbFedEx.Checked == true)
                {
                    Clear();
                    LoadFromUser("FedEx");
                    LoadFedExService();
                    LoadFedExPackage();
                    if (ServiceID != "")
                    {
                        if (ServiceID.ToString().Length <= 1)
                            cmbService.SelectedValue = "0" + ServiceID;
                        else
                            cmbService.SelectedValue = Convert.ToInt32(ServiceID);
                    }
                    if (cmbFrom.Items.Count > 1)
                        cmbFrom.SelectedIndex = 1;
                    //FedXGenerateToken();
                }
                else
                {
                    Clear();
                    LoadFromUser("UPS");
                    LoadUPSService();
                    LoadUPSPackage();
                    if (ServiceID != "")
                    {
                        if (ServiceID.ToString().Length <= 1)
                            cmbService.SelectedValue = "0" + ServiceID;
                        else
                            cmbService.SelectedValue = Convert.ToInt32(ServiceID);
                    }
                    //LoadUPSService();
                    if (cmbFrom.Items.Count > 1)
                        cmbFrom.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: rdbFedEx_CheckedChanged, Message:" + ex.Message);
            }
        }
        //UPS
        private void rdbUPS_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbUPS.Checked == true)
                {
                    Clear();
                    LoadFromUser("UPS");
                    LoadUPSService();
                    LoadUPSPackage();
                    if (ServiceID != "")
                    {
                        if (ServiceID.ToString().Length <= 1)
                            cmbService.SelectedValue = "0" + ServiceID;
                        else
                            cmbService.SelectedValue = Convert.ToInt32(ServiceID);
                    }
                    if (cmbFrom.Items.Count > 1)
                        cmbFrom.SelectedIndex = 1;
                    lblCost.Visible = false;

                }
                else
                {
                    Clear();
                    LoadFromUser("FedEx");
                    LoadFedExService();
                    LoadFedExPackage();
                    if (ServiceID != "")
                    {
                        if (ServiceID.ToString().Length <= 1)
                            cmbService.SelectedValue = "0" + ServiceID;
                        else
                            cmbService.SelectedValue = Convert.ToInt32(ServiceID);
                    }
                    if (cmbFrom.Items.Count > 1)
                        cmbFrom.SelectedIndex = 1;
                    lblCost.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: rdbUPS_CheckedChanged, Message:" + ex.Message);
            }
        }
        //Shipping Address
        private void LoadShippingAddress()
        {
            Clear();
            try
            {
                //nIDHI
                if (ClsCommon.ShipMethod.ToLower().Contains("fedex"))
                {

                    rdbFedEx.Checked = true;
                    rdbUPS.Checked = false;
                    LoadFromUser("FedEx");
                    LoadFedExService();
                    LoadFedExPackage();
                }
                else if (ClsCommon.ShipMethod.Contains("UPS"))
                {
                    rdbFedEx.Checked = false;
                    rdbUPS.Checked = true;
                    LoadFromUser("UPS");
                    LoadUPSService();
                    LoadUPSPackage();
                }
                else
                {
                    rdbFedEx.Checked = true;
                    LoadFromUser("FedEx");
                    LoadFedExService();
                    LoadFedExPackage();
                }

                dgvPackage.Rows.Clear();
                //cmbService.SelectedIndex = 0;
                if (ClsCommon.Weight != 0)
                {
                    txtWeight.Text = ClsCommon.Weight.ToString();
                }
                else
                {
                    txtWeight.Text = "";
                }
                RefNumber = ClsCommon.RefNumber;
                DataTable dtOrder = new BALInvoiceMaster().SelectOrder(new BOLInvoiceMaster() { RefNumber = RefNumber });
                if (dtOrder.Rows.Count > 0)
                {
                    if (ClsCommon.ShipMethod == "UPSNextDayAirS")
                    {
                        cmbService.Text = "UPS Next Day Air Saver";
                    }
                    else if (ClsCommon.ShipMethod == "UPS 3 DaySelect")
                    {
                        cmbService.Text = "UPS 3 Day Select";
                    }
                    else if (ClsCommon.ShipMethod == "UPS Next DayAir")
                    {
                        cmbService.Text = "UPS Next Day Air";
                    }
                    else if (ClsCommon.ShipMethod == "FEDEX STANDARD")
                    {
                        cmbService.Text = "FedEx Standard Overnight®";
                    }
                    else if (ClsCommon.ShipMethod == "FedEx Ground")
                    {
                        cmbService.Text = "FedEx Ground.";
                    }
                    else if (ClsCommon.ShipMethod == "FedexPriority")
                    {
                        cmbService.Text = "FedEx Priority Overnight®";
                    }
                    else if (ClsCommon.ShipMethod == "FedEx 2nd Day")
                    {
                        cmbService.Text = "FedEx 2Day®";
                    }
                    else if (ClsCommon.ShipMethod == "FedExFirstNight")
                    {
                        cmbService.Text = "FedEx First Overnight®";
                    }
                    else if (ClsCommon.ShipMethod == "FedEx2ndDayAM")
                    {
                        cmbService.Text = "FedEx 2Day® A.M.";
                    }
                    else
                    {
                        cmbService.Text = ClsCommon.ShipMethod;
                    }
                    txtToCompany.Text = dtOrder.Rows[0]["CompanyName"].ToString();
                    //if (dtOrder.Rows[0]["CompanyName"].ToString() != dtOrder.Rows[0]["CustomerName"].ToString())
                    //{
                    //    txtToName.Text = dtOrder.Rows[0]["CustomerName"].ToString();
                    //}
                    //else
                    //{
                    //    txtToName.Text = "";
                    //}
                    //if (dtOrder.Rows[0]["CompanyName"].ToString().ToLower() != dtOrder.Rows[0]["CustomerName"].ToString() && dtOrder.Rows[0]["CompanyName"].ToString()!="")
                    //{
                    //    txtToName.Text = "";
                    //}
                    if (dtOrder.Rows[0]["AddressName"].ToString().Contains("Ship To") == false)
                    {
                        txtToName.Text = dtOrder.Rows[0]["AddressName"].ToString();
                    }
                    else if(dtOrder.Rows[0]["AddressName"].ToString()==""&& dtOrder.Rows[0]["CustomerName"].ToString()!="")
                    {
                        txtToName.Text = dtOrder.Rows[0]["CustomerName"].ToString();
                    }
                    else
                    {
                        txtToName.Text = "";
                    }
                    if (dtOrder.Rows[0]["Add1"].ToString().Contains(txtToCompany.Text) == true && dtOrder.Rows[0]["Add1"].ToString().Replace(" ","").Replace(",","")!= txtToCompany.Text.Replace(" ", ""))
                    {
                        if (dtOrder.Rows[0]["Add1"].ToString() != "")
                        {
                            if (txtToCompany.Text != "")
                            {
                                txtToAddress1.Text = dtOrder.Rows[0]["Add1"].ToString().Replace(txtToCompany.Text, "").TrimStart(',');
                            }
                            else
                            {
                                txtToAddress1.Text = dtOrder.Rows[0]["Add1"].ToString().TrimStart(',');
                            }

                        }
                    }
                    //else if(dtOrder.Rows[0]["Add1"].ToString().Contains(",")==true)
                    //{
                    //    string[] str= dtOrder.Rows[0]["Add1"].ToString().Split(',');
                    //    txtToAddress1.Text = str.Last();
                    //    if(str.Last()=="")
                    //    {
                    //        txtToAddress1.Text = str.First();
                    //    }
                    //    else if(str.Last().Length< str.First().Length)
                    //    {
                    //        txtToAddress1.Text = str.First();
                    //    }

                    //}
                    else
                    {

                        txtToAddress1.Text = "";
                    }
                    if (dtOrder.Rows[0]["Add2"].ToString().Contains(txtToAddress1.Text) == true || txtToAddress1.Text == "")
                    {
                        if (txtToAddress1.Text == "")
                        {
                            txtToAddress1.Text = dtOrder.Rows[0]["Add2"].ToString();
                        }
                        else if (dtOrder.Rows[0]["Add2"].ToString() != "")
                        {
                            txtToAddress2.Text = dtOrder.Rows[0]["Add2"].ToString().Replace(txtToAddress1.Text, "").TrimStart(',');
                        }
                    }
                    else if (dtOrder.Rows[0]["Add2"].ToString() == txtToAddress1.Text)
                    {
                        txtToAddress2.Text = "";
                    }
                    else if (txtToAddress1.Text.Contains(dtOrder.Rows[0]["Add2"].ToString()) == true)
                    {
                        txtToAddress2.Text = "";
                    }
                    else
                    {
                        txtToAddress2.Text = dtOrder.Rows[0]["Add2"].ToString();

                    }
                    if (dtOrder.Rows[0]["Add3"].ToString() != "")
                    {
                        if (txtToAddress2.Text == "")
                        {
                            txtToAddress2.Text = dtOrder.Rows[0]["Add3"].ToString();
                        }
                        else
                        {
                            txtToAddress2.Text += "," + dtOrder.Rows[0]["Add3"].ToString();
                        }
                    }
                    string cityRaw = dtOrder.Rows[0]["City"].ToString();
                    string stateRaw = dtOrder.Rows[0]["State"].ToString();
                    txtToCity.Text = cityRaw;                
                    Dictionary<string, string> canadaProvinces = new Dictionary<string, string>()
                    {
                        {"ALBERTA", "AB"},
                        {"BRITISHCOLUMBIA", "BC"},
                        {"MANITOBA", "MB"},
                        {"NEWBRUNSWICK", "NB"},
                        {"NEWFOUNDLANDANDLABRADOR", "NL"},
                        {"NORTHWESTTERRITORIES", "NT"},
                        {"NOVASCOTIA", "NS"},
                        {"NUNAVUT", "NU"},
                        {"ONTARIO", "ON"},
                        {"PRINCEEDWARDISLAND", "PE"},
                        {"QUEBEC", "QC"},
                        {"SASKATCHEWAN", "SK"},
                        {"SASKATCHWEN", "SK"}, // common misspelling found in data
                        {"SASKATCHWAN", "SK"},
                        {"YUKON", "YT"}
                    };
                    string NormalizeProvinceKey(string s)
                    {
                        if (string.IsNullOrWhiteSpace(s))
                            return string.Empty;
                        return s.Trim().ToUpperInvariant().Replace(" ", "").Replace("-", "");
                    }

                    // If State is blank but City contains "City, Province" (example: "SASKATOON, SASKATCHWEN"),
                    // split and extract the province.
                    string provinceCandidate = stateRaw;
                    if (string.IsNullOrWhiteSpace(stateRaw) && cityRaw != null && cityRaw.Contains(","))
                    {
                        string[] parts = cityRaw.Split(',');
                        if (parts.Length > 0)
                            txtToCity.Text = parts[0].Trim();
                        if (parts.Length > 1)
                            provinceCandidate = parts[1].Trim();
                    }

                    if (!string.IsNullOrWhiteSpace(provinceCandidate))
                    {
                        string key = NormalizeProvinceKey(provinceCandidate);
                        if (canadaProvinces.ContainsKey(key))
                            txtToState.Text = canadaProvinces[key];
                        else if (provinceCandidate.Trim().Length == 2 && char.IsLetter(provinceCandidate.Trim()[0]) && char.IsLetter(provinceCandidate.Trim()[1]))
                            txtToState.Text = provinceCandidate.Trim().ToUpperInvariant();
                        else
                            txtToState.Text = provinceCandidate.Trim();
                    }

                    // Postal code can be stored in different columns depending on the order source.
                    string postal = dtOrder.Rows[0]["PostalCode"].ToString();
                    if (string.IsNullOrWhiteSpace(postal) && dtOrder.Columns.Contains("ZipCode"))
                        postal = dtOrder.Rows[0]["ZipCode"].ToString();
                    if (string.IsNullOrWhiteSpace(postal) && dtOrder.Columns.Contains("Zip"))
                        postal = dtOrder.Rows[0]["Zip"].ToString();

                    txtToZip.Text = postal;
                    string country = dtOrder.Rows[0]["Country"].ToString().Trim();

                    if (string.IsNullOrEmpty(country))
                    {
                        txtToCountry.Text = "CA";
                    }
                    else
                    {
                        string normalizedCountry = country.Trim().ToUpper();

                        if (normalizedCountry == "CANADA"
                            || normalizedCountry == "CA"
                            || normalizedCountry == "C.A")
                        {
                            txtToCountry.Text = "CA";
                        }
                        else
                        {
                            txtToCountry.Text = country;
                        }
                    }
                    txtToEmail.Text = dtOrder.Rows[0]["Email"].ToString();
                    txtToPhone.Text = dtOrder.Rows[0]["Phone"].ToString();
                    RefNumber = dtOrder.Rows[0]["RefNumber"].ToString();
                    if (txtToEmail.Text != null)
                        chkNotification.Checked = true;
                    else
                        chkNotification.Checked = false;
                    ////Hiren 
                    //if (dtOrder.Rows[0]["Note"].ToString() != "")
                    //{
                    //    ClsCommon.ShippingAddressNote = dtOrder.Rows[0]["Note"].ToString();
                    //}
                }
                else
                {
                    MessageBox.Show("Provided Order Number not Found in Store. Please check Order Number");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: rdbUPS_CheckedChanged, Message:" + ex.Message);
            }
        }
        private Boolean CheckValidation()
        {
            Boolean IsValid = false;
            if (cmbFrom.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select From Address");
                cmbFrom.Focus();
                IsValid = false;
            }
            else if (txtToCompany.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter To CompanyName");
                txtToCompany.Focus();
                IsValid = false;
            }
            //else if (txtToName.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please Enter To Name");
            //    txtToName.Focus();
            //    IsValid = false;
            //}
            //else if (txtToPhone.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please Enter To Phone");
            //    txtToPhone.Focus();
            //    IsValid = false;
            //}
            else if (txtToAddress1.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter To Address");
                txtToAddress1.Focus();
                IsValid = false;
            }
            else if (txtToCity.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter To City");
                txtToCity.Focus();
                IsValid = false;
            }
            else if (txtToState.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter To State");
                txtToState.Focus();
                IsValid = false;
            }
            else if (txtToZip.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter To Postal Code");
                txtToZip.Focus();
                IsValid = false;
            }
            else if (txtToCountry.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter To Country");
                txtToCountry.Focus();
                IsValid = false;
            }
            else if (dgvPackage.Rows.Count == 0)
            {
                MessageBox.Show("Please Enter To atleast one Box Info");
                cmbPackaging.Focus();
                IsValid = false;
            }
            else if (cmbService.SelectedIndex == 0)
            {
                MessageBox.Show("Please Enter Service for Ship");
                cmbService.Focus();
                IsValid = false;
            }
            else if (chkCOD.Checked == true && txtCODAmount.Text == "")
            {
                MessageBox.Show("Please Enter COD Amount");
                txtCODAmount.Focus();
                IsValid = false;
            }
            else if (txtRefNumber.Text == "")
            {
                MessageBox.Show("Please Enter Reference,Check this Order is Sync with QuickBooks or not.");
                txtRefNumber.Focus();
                IsValid = false;
            }
            else if (rdbFedEx.Checked == true && chkCOD.Checked == true)
            {
                MessageBox.Show("FedEx does not allow Label creation or rate calculation when COD (Cash on Delivery) is selected. Please uncheck COD to proceed.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkCOD.Focus();
                IsValid = false;
            }
            else
                IsValid = true;
            return IsValid;
        }
        public void Clear1()
        {
            grpTrack.Visible = false;
            PictureBox1.Visible = false;
            //btnPrint.Visible = false;
            lblTotalCost.Visible = false;
            txtTotalCost.Visible = false;
        }
        private void btnShip_Click(object sender, EventArgs e)
        {
            dtUPS = new BALUPSSettings().SelectByType("UPS");
            dtFedEx = new BALUPSSettings().SelectByType("FedX");
            try
            {
                if (rdbUPS.Checked == true)
                {
                    // UPS Process
                    try
                    {

                        if (dtUPS.Rows.Count > 0)
                        {
                            if (CheckValidation())
                            {
                            Top:
                                try
                                {

                                    grpTrack.Text = "UPS Tracking Info";
                                    HttpWebRequest WebRequestObject = null;
                                    HttpWebResponse WebResponseObject = null;
                                    StreamReader sr = null;
                                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                                    string post = GetUPSJSON();
                                    WebRequestObject = (HttpWebRequest)WebRequest.Create("https://onlinetools.ups.com/api/shipments/v1/ship");
                                    WebRequestObject.Method = "POST";
                                    byte[] byteArray = Encoding.UTF8.GetBytes(post);
                                    //WebRequestObject.ContentType = "application/x-www-form-urlencoded";
                                    WebRequestObject.ContentType = "application/json";

                                    WebRequestObject.Headers.Add("Authorization", "Bearer " + dtUPS.Rows[0]["AccessToken"].ToString());

                                    WebRequestObject.ContentLength = byteArray.Length;

                                    Stream dataStream = WebRequestObject.GetRequestStream();

                                    dataStream.Write(byteArray, 0, byteArray.Length);
                                    dataStream.Close();

                                    WebRequestObject.AllowAutoRedirect = false;

                                    WebResponseObject = (HttpWebResponse)WebRequestObject.GetResponse();
                                    sr = new StreamReader(WebResponseObject.GetResponseStream());
                                    string Results = sr.ReadToEnd();

                                    string ShipmentDigest = clsOnline.ExtractResponse_POST_JSON(Results, "UPS");

                                    if (ShipmentDigest.Contains("Error"))
                                    {
                                        if (ShipmentDigest.Contains("Error:Invalid bearer Token"))
                                        {
                                            UPSGenerateToken();
                                            goto Top;
                                        }
                                        MessageBox.Show(ShipmentDigest);
                                        ClsCommon.WriteErrorLogs("responseBody :-" + ShipmentDigest);
                                    }
                                    else
                                    {
                                        //ReportDocument cryRptInvoiceReport = new ReportDocument();
                                        AcceptShipmentRequest(Results);
                                        for (int b = 0; b < clsOnline.dtChild.Rows.Count; b++)
                                        {
                                            ShipNotification(clsOnline.dtChild.Rows[b]["TrackingNumber"].ToString(), b + 1);
                                        }
                                        if (dtAccessUPS.Rows.Count > 0)
                                        {
                                            Boolean Landscape = false;
                                            System.Drawing.Printing.PrintDocument pd =
                                                new System.Drawing.Printing.PrintDocument();
                                            pd.PrinterSettings.PrinterName = dtAccessUPS.Rows[0]["PrinterName"].ToString();
                                            if (dtAccessUPS.Rows[0]["Copies"].ToString() != "")
                                            {
                                                pd.PrinterSettings.Copies = Convert.ToInt16(dtAccessUPS.Rows[0]["Copies"].ToString());
                                            }
                                            if (dtAccessUPS.Rows[0]["Landscape"].ToString() != "")
                                            {
                                                if (dtAccessUPS.Rows[0]["Landscape"].ToString() == "True")
                                                {
                                                    Landscape = true;
                                                }
                                                pd.PrinterSettings.DefaultPageSettings.Landscape = Landscape;
                                            }
                                            //if (dtAccessUPS.Rows[0]["Margins"].ToString() != "")
                                            //{
                                            //    string[] str = dtAccessUPS.Rows[0]["Margins"].ToString().Split(' ');
                                            //    string[] str1 = str[1].Split('=');
                                            //    string[] str2 = str[2].Split('=');
                                            //    string[] str3 = str[3].Split('=');
                                            //    string[] str4 = str[4].Split('=');
                                            //    pd.PrinterSettings.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(Convert.ToInt32(str1[1]), Convert.ToInt32(str2[1]), Convert.ToInt32(str3[1]), Convert.ToInt32(str4[1].Replace("]", "")));
                                            //}
                                            pd.OriginAtMargins = true;
                                            pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                                            pd.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                                            if (dtAccessUPS.Rows[0]["PaperSize"].ToString() != "")
                                            {
                                                string[] strA = dtAccessUPS.Rows[0]["PaperSize"].ToString().Split('=');
                                                string[] str5 = strA[1].Split(' ');
                                                string[] str6 = strA[2].Split(' ');
                                                pd.PrinterSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize(str5[0], Convert.ToInt32(str6[0]), Convert.ToInt32(strA[3].Replace("]", "")));
                                            }
                                            pd.PrinterSettings.DefaultPageSettings.PaperSource = new PaperSource() { RawKind = (int)PaperSourceKind.AutomaticFeed };

                                            pd.DocumentName = lblTracking.Text + ".gif";
                                            pd.PrinterSettings.PrintToFile = true;

                                            for (int b = 0; b < clsOnline.dtChild.Rows.Count; b++)
                                            {
                                                var files = Directory.GetFiles(Application.StartupPath + "\\Shipment\\", clsOnline.dtChild.Rows[b]["TrackingNumber"].ToString() + ".gif");
                                                pd.PrintController = new StandardPrintController();
                                                foreach (var i in files)
                                                {
                                                    pd.PrintPage += (obj, eve) =>
                                                    {
                                                        System.Drawing.Image img = System.Drawing.Image.FromFile(i);
                                                        double cmToUnits = 88 / 2.54;
                                                        eve.Graphics.DrawImage(img, 10, 15, (float)(12 * cmToUnits), (float)(18 * cmToUnits));
                                                    };
                                                }
                                                pd.Print();
                                            }

                                            if (txtDeclaredValue.Text != "")
                                            {
                                                DialogResult dialog = MessageBox.Show("Want to print Insurance Receipt?", "Permission", MessageBoxButtons.YesNo);
                                                if (dialog == DialogResult.Yes)
                                                {

                                                    DataTable dtDetail = new DataTable();
                                                    dtDetail.Columns.Add("TRACKING", typeof(string));
                                                    dtDetail.Columns.Add("PACKAGE ID", typeof(string));
                                                    dtDetail.Columns.Add("DECLAREDVALUE", typeof(string));
                                                    dtDetail.Columns.Add("Date", typeof(string));
                                                    dtDetail.Columns.Add("FullDate", typeof(string));
                                                    dtDetail.Columns.Add("REFERENCE NUMBER", typeof(string));
                                                    dtDetail.Columns.Add("CURRENCY", typeof(string));
                                                    dtDetail.Columns.Add("Count", typeof(string));

                                                    InsuranceSignatureReport cryRptInsuranceSignature = new InsuranceSignatureReport();
                                                    int j = 0;
                                                    for (int b = 0; b < clsOnline.dtChild.Rows.Count; b++)
                                                    {

                                                        dtDetail.Rows.Add();
                                                        dtDetail.Rows[j]["TRACKING"] = clsOnline.dtChild.Rows[b]["TrackingNumber"].ToString();
                                                        string v = clsOnline.dtChild.Rows[b]["TrackingNumber"].ToString();
                                                        string J = "";
                                                        for (int I = 10; I < v.Length; I++)
                                                        {
                                                            J += v[I];
                                                            if (J.Length == 7)
                                                            {
                                                                break;
                                                            }
                                                        }
                                                        dtDetail.Rows[j]["PACKAGE ID"] = J.ToString();
                                                        dtDetail.Rows[j]["DECLAREDVALUE"] = txtDeclaredValue.Text;
                                                        dtDetail.Rows[j]["Date"] = DateTime.Now.ToString("MM/dd/yyyy, HH:mm tt");
                                                        dtDetail.Rows[j]["FullDate"] = DateTime.Now.ToString("MMM dd yyyy");
                                                        if (RefNumber != "")
                                                        {
                                                            dtDetail.Rows[j]["REFERENCE NUMBER"] = "#" + RefNumber.ToString();
                                                        }
                                                        dtDetail.Rows[j]["CURRENCY"] = clsOnline.dtMaster.Rows[0]["Currancycode"].ToString();
                                                        dtDetail.Rows[j]["Count"] = clsOnline.dtChild.Rows.Count;
                                                        j++;
                                                    }
                                                    cryRptInsuranceSignature.SetDataSource(dtDetail);

                                                    printDialog1.PrinterSettings.DefaultPageSettings.Landscape = true;
                                                    printDialog1.PrinterSettings.Copies = 2;
                                                    if (printDialog1.ShowDialog() == DialogResult.OK)
                                                    {
                                                        ReportDocument reportDocument = new ReportDocument();
                                                        ClsCommon.WriteErrorLogs("Insuarance Report Path" + cryRptInsuranceSignature.FileName.Replace("rassdk://", ""));
                                                        reportDocument.Load(cryRptInsuranceSignature.FileName.Replace("rassdk://", ""));
                                                        reportDocument.SetDataSource(dtDetail);
                                                        reportDocument.PrintOptions.PrinterName = printDialog1.PrinterSettings.PrinterName;
                                                        reportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                                                        reportDocument.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                                                        reportDocument.PrintToPrinter(printDialog1.PrinterSettings.Copies, true, 0, 0);

                                                        //Bhumika19
                                                        reportDocument.Dispose();
                                                    }
                                                }
                                            }
                                            this.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Select Printer Option From UPSSetting");
                                        }
                                    }
                                }
                                catch (WebException ex)
                                {
                                    if (ex.Response is HttpWebResponse errorResponse && errorResponse.StatusCode == HttpStatusCode.Unauthorized)
                                    {
                                        UPSGenerateToken();
                                        goto Top;
                                    }
                                    else
                                    {

                                        using (var respStream = ex.Response?.GetResponseStream())
                                        using (var reader = new StreamReader(respStream ?? Stream.Null))
                                        {
                                            string errorDetails = reader.ReadToEnd();
                                            ClsCommon.WriteErrorLogs("UPS Error Details: " + errorDetails);
                                            try
                                            {
                                                var json = JObject.Parse(errorDetails);
                                                string message = json["response"]?["errors"]?[0]?["message"]?.ToString();
                                                MessageBox.Show(message ?? "Unknown error");
                                                //MessageBox.Show("UPS Request Failed: " + errorDetails);
                                            }
                                            catch (Exception ex1)
                                            {
                                                MessageBox.Show("UPS Request Failed: " + errorDetails);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error: UPS settings are blank");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: btnShip_Click, Message:" + ex.Message);
                    }
                }
                else if (rdbFedEx.Checked == true)
                {
                    ClsCommon.WriteErrorLogs("FedEx shipping option selected. Starting FedEx shipping process.");

                    try
                    {
                        ClsCommon.WriteErrorLogs($"Checking if FedEx token exists. dtFedEx.Rows.Count = {dtFedEx.Rows.Count}");

                        grpTrack.Text = "FedEx Tracking Info";

                        if (dtFedEx.Rows.Count == 0)
                        {
                            ClsCommon.WriteErrorLogs("ERROR: No FedEx token found in database.");
                            MessageBox.Show("FedEx credentials not found. Please configure FedEx settings.");
                            return;
                        }

                        ClsCommon.WriteErrorLogs("FedEx token found. Proceeding with validation.");

                        if (!CheckValidation())
                        {
                            ClsCommon.WriteErrorLogs("Validation failed. Stopping FedEx shipping process.");
                            return;
                        }

                        ClsCommon.WriteErrorLogs("Validation passed. Starting FedEx shipment creation.");
                        int retryCount = 0;
                        const int maxRetries = 2;

                        while (retryCount <= maxRetries)
                        {
                            try
                            {
                                ClsCommon.WriteErrorLogs($"Attempt {retryCount + 1} of {maxRetries + 1} to create FedEx shipment.");

                                // Create HTTP client
                                ClsCommon.WriteErrorLogs("Creating HttpClient instance.");
                                var client = new HttpClient(
                                    new HttpClientHandler
                                    {
                                        AutomaticDecompression =
                                            DecompressionMethods.GZip | DecompressionMethods.Deflate
                                    }
                                );


                                // Set timeout 
                                ClsCommon.WriteErrorLogs("Setting HttpClient timeout to 5 minutes.");
                                client.Timeout = TimeSpan.FromMinutes(5);

                                // Prepare URL
                                var url = "https://apis.fedex.com/ship/v1/shipments";
                                ClsCommon.WriteErrorLogs($"Target API URL: {url}");

                                // Generate JSON payload
                                ClsCommon.WriteErrorLogs("Generating FedEx JSON payload.");
                                var JsonFedx = GetFedXJson();

                                if (string.IsNullOrEmpty(JsonFedx))
                                {
                                    ClsCommon.WriteErrorLogs("ERROR: Generated JSON payload is empty or null.");
                                    MessageBox.Show("Failed to generate shipment data.");
                                    return;
                                }

                                ClsCommon.WriteErrorLogs($"JSON payload generated successfully. Length: {JsonFedx.Length} characters.");

                                // Get access token
                                string accessToken = dtFedEx.Rows[0]["AccessToken"].ToString();
                                ClsCommon.WriteErrorLogs($"Access token retrieved. Length: {accessToken.Length} characters.");

                                // Prepare request
                                ClsCommon.WriteErrorLogs("Preparing HTTP request.");
                                var request = new HttpRequestMessage(HttpMethod.Post, url);
                                request.Headers.Add("Authorization", $"Bearer {accessToken}");
                                request.Content = new StringContent(JsonFedx, Encoding.UTF8, "application/json");

                                ClsCommon.WriteErrorLogs("Sending HTTP request to FedEx API.");
                                var response = client.SendAsync(request).Result;
                                ClsCommon.WriteErrorLogs($"Response received. Status Code: {(int)response.StatusCode} ({response.StatusCode})");

                                // Read response content
                                ClsCommon.WriteErrorLogs("Reading response content.");


                                var responseBody = response.Content.ReadAsStringAsync().Result;
                                ClsCommon.WriteErrorLogs($"Response body length: {responseBody.Length} characters");

                                // Handle different response status codes
                                if (response.IsSuccessStatusCode)
                                {
                                    ClsCommon.WriteErrorLogs("FedEx API call successful. Processing response.");

                                    if (response.ReasonPhrase == "OK")
                                    {
                                       
                                        ClsCommon.WriteErrorLogs("Response ReasonPhrase is OK. Processing shipment data.");
                                        // Process FedEx response
                                        clsOnline.ExtractFedxResponse(responseBody);
                                        ClsCommon.WriteErrorLogs("FedEx response extracted successfully.");

                                        if (clsOnline.dtFedx.Rows.Count == 0)
                                        {
                                            ClsCommon.WriteErrorLogs("ERROR: No data found in FedEx response.");
                                            MessageBox.Show("FedEx shipment created but no tracking data received.");
                                            return;
                                        }

                                        ClsCommon.WriteErrorLogs($"FedEx response contains {clsOnline.dtFedx.Rows.Count} rows of data.");

                                        // Get tracking number from first row
                                        string masterTrackingNumber = clsOnline.dtFedx.Rows[0]["masterTrackingNumber"].ToString();
                                        ClsCommon.WriteErrorLogs($"Master Tracking Number: {masterTrackingNumber}");

                                        // Update UI with tracking number
                                        lblTracking.Text = masterTrackingNumber;
                                        ClsCommon.WriteErrorLogs("Tracking number updated in UI.");

                                        // Update database
                                        ClsCommon.WriteErrorLogs("Updating database with shipment information.");
                                        UpdateInDB(
                                            RefNumber,
                                            clsOnline.dtFedx.Rows[0]["Weight"].ToString(),
                                            clsOnline.dtFedx.Rows[0]["ServiceOptionsCharges"].ToString(),
                                            clsOnline.dtFedx.Rows[0]["TotalCharges"].ToString()
                                        );
                                        ClsCommon.WriteErrorLogs("Database updated successfully.");
                                        //Tracking Number POST Txparts
                                        //int OrderId = 0;
                                        //DataTable dtOrderid = new BALInvoiceMaster().GetOrderId(ClsCommon.RefNumber);
                                        //if (dtOrderid.Rows.Count > 0)
                                        //{
                                        //    if (dtOrderid.Rows[0]["TxPartsId"].ToString() != "")
                                        //    {
                                        //        OrderId = Convert.ToInt32(dtOrderid.Rows[0]["TxPartsId"]);
                                        //        string trackingnumber = clsOnline.dtFedx.Rows[0]["masterTrackingNumber"].ToString();
                                        //        getOrderIDToken(trackingnumber, OrderId);
                                        //    }
                                        //}
                                        // Process each label
                                        ClsCommon.WriteErrorLogs($"Processing {clsOnline.dtFedx.Rows.Count} label(s).");
                                        List<string> generatedLabelFiles = new List<string>();


                                        lblService.Text = clsOnline.dtFedx.Rows[0]["ServiceOptionsCharges"].ToString();
                                        lblTransport.Text = clsOnline.dtFedx.Rows[0]["totalNetFreight"].ToString();
                                        lblTotal.Text = clsOnline.dtFedx.Rows[0]["TotalCharges"].ToString();

                                        for (int b = 0; b < clsOnline.dtFedx.Rows.Count; b++)
                                        {
                                            try
                                            {
                                                string trackingNumber = clsOnline.dtFedx.Rows[b]["masterTrackingNumber"].ToString();
                                                string encodedLabel = clsOnline.dtFedx.Rows[b]["encodedLabel"].ToString();

                                                if (string.IsNullOrWhiteSpace(encodedLabel))
                                                    continue;

                                                // -----------------------------
                                                // BASE64 → ZPL
                                                // -----------------------------
                                                string zplContent = Encoding.UTF8.GetString(Convert.FromBase64String(encodedLabel));
                                                zplContent = AddDeliveryInstructionToZpl(
                                                    zplContent,
                                                    ClsCommon.ShippingAddressNote
                                                );
                                                byte[] zplBytes = Encoding.UTF8.GetBytes(zplContent);

                                                // -----------------------------
                                                // ZPL → IMAGE (Labelary)
                                                // -----------------------------
                                                var request1 = (HttpWebRequest)WebRequest.Create(
                                                    "http://api.labelary.com/v1/printers/12dpmm/labels/3x5/0/"
                                                );
                                                request1.Method = "POST";
                                                request1.ContentType = "application/x-www-form-urlencoded";
                                                request1.ContentLength = zplBytes.Length;

                                                using (var reqStream = request1.GetRequestStream())
                                                {
                                                    reqStream.Write(zplBytes, 0, zplBytes.Length);
                                                }

                                                using (var response1 = (HttpWebResponse)request1.GetResponse())
                                                using (var responseStream = response1.GetResponseStream())
                                                using (var image = System.Drawing.Image.FromStream(responseStream))
                                                {
                                                    // -----------------------------
                                                    // ROTATE IMAGE (OLD METHOD)
                                                    // -----------------------------
                                                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);

                                                    // -----------------------------
                                                    // SAVE PNG (AUTO – NO DIALOG)
                                                    // -----------------------------
                                                    string fedxDir = Path.Combine(Application.StartupPath, "Fedx");
                                                    if (!Directory.Exists(fedxDir))
                                                        Directory.CreateDirectory(fedxDir);

                                                    string pngFileName = $"{trackingNumber}_Package_{b + 1}.png";
                                                    string pngPath = Path.Combine(fedxDir, pngFileName);
                                                    if (File.Exists(pngPath))
                                                        File.Delete(pngPath);

                                                    image.Save(pngPath, System.Drawing.Imaging.ImageFormat.Png);


                                                    // -----------------------------
                                                    // DISPLAY IMAGE (UI)
                                                    // -----------------------------
                                                    grpTrack.Visible = true;
                                                    PictureBox1.Visible = true;

                                                    PictureBox1.Image?.Dispose();
                                                    PictureBox1.Image = new Bitmap(pngPath);
                                                    PictureBox1.Refresh();



                                                    //PrinterCode

                                                    Boolean Landscape = false;
                                                    System.Drawing.Printing.PrintDocument pd =
                                                        new System.Drawing.Printing.PrintDocument();
                                                    pd.PrinterSettings.PrinterName = dtAccessUPS.Rows[0]["PrinterName"].ToString();
                                                    if (dtAccessUPS.Rows[0]["Copies"].ToString() != "")
                                                    {
                                                        pd.PrinterSettings.Copies = Convert.ToInt16(dtAccessUPS.Rows[0]["Copies"].ToString());
                                                    }
                                                    if (dtAccessUPS.Rows[0]["Landscape"].ToString() != "")
                                                    {
                                                        if (dtAccessUPS.Rows[0]["Landscape"].ToString() == "True")
                                                        {
                                                            Landscape = true;
                                                        }
                                                        pd.PrinterSettings.DefaultPageSettings.Landscape = Landscape;
                                                    }
                                                    //if (dtAccessUPS.Rows[0]["Margins"].ToString() != "")
                                                    //{
                                                    //    string[] str = dtAccessUPS.Rows[0]["Margins"].ToString().Split(' ');
                                                    //    string[] str1 = str[1].Split('=');
                                                    //    string[] str2 = str[2].Split('=');
                                                    //    string[] str3 = str[3].Split('=');
                                                    //    string[] str4 = str[4].Split('=');
                                                    //    pd.PrinterSettings.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(Convert.ToInt32(str1[1]), Convert.ToInt32(str2[1]), Convert.ToInt32(str3[1]), Convert.ToInt32(str4[1].Replace("]", "")));
                                                    //}
                                                    pd.OriginAtMargins = true;
                                                    pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                                                    pd.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                                                    if (dtAccessUPS.Rows[0]["PaperSize"].ToString() != "")
                                                    {
                                                        string[] strA = dtAccessUPS.Rows[0]["PaperSize"].ToString().Split('=');
                                                        string[] str5 = strA[1].Split(' ');
                                                        string[] str6 = strA[2].Split(' ');
                                                        pd.PrinterSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize(str5[0], Convert.ToInt32(str6[0]), Convert.ToInt32(strA[3].Replace("]", "")));
                                                    }
                                                    pd.PrinterSettings.DefaultPageSettings.PaperSource = new PaperSource() { RawKind = (int)PaperSourceKind.AutomaticFeed };

                                                    pd.DocumentName = lblTracking.Text + ".gif";
                                                    pd.PrinterSettings.PrintToFile = true;

                                                    var files = Directory.GetFiles(Application.StartupPath + "\\Fedx\\", pngFileName);
                                                    pd.PrintController = new StandardPrintController();
                                                    foreach (var i in files)
                                                    {
                                                        pd.PrintPage += (obj, eve) =>
                                                        {
                                                            System.Drawing.Image img = System.Drawing.Image.FromFile(i);
                                                            double cmToUnits = 88 / 2.54;
                                                            eve.Graphics.DrawImage(img, 10, 15, (float)(12 * cmToUnits), (float)(18 * cmToUnits));
                                                        };
                                                    }
                                                    pd.Print();
                                                }

                                                // -----------------------------
                                                // EMAIL NOTIFICATION
                                                // -----------------------------
                                                ShipFedExNotification(trackingNumber, b + 1);
                                            }
                                            catch (Exception ex)
                                            {
                                                ClsCommon.WriteErrorLogs("Label Error: " + ex.Message);
                                                MessageBox.Show(ex.Message); // 
                                            }
                                        }

                                        // Update order tracking
                                        ClsCommon.WriteErrorLogs("Updating order tracking information.");
                                        break; // Exit retry loop on success
                                    }
                                    else
                                    {
                                        ClsCommon.WriteErrorLogs($"WARNING: Success status but ReasonPhrase is not OK: {response.ReasonPhrase}");
                                        ClsCommon.WriteErrorLogs($"Response Body: {responseBody}");
                                        MessageBox.Show($"FedEx API returned: {response.ReasonPhrase}");
                                        break;
                                    }
                                }
                                else
                                {
                                    // Handle error responses
                                    ClsCommon.WriteErrorLogs($"ERROR: FedEx API returned error status: {(int)response.StatusCode}");

                                    switch ((int)response.StatusCode)
                                    {
                                        case 400:
                                            ClsCommon.WriteErrorLogs($"Bad Request (400) error. Response: {responseBody}");
                                            string error = ExtractErrorMessage(responseBody);
                                            if (cmbService.SelectedValue == "FEDEX_GROUND")
                                            {
                                                MessageBox.Show("Please set residential false to continue.");

                                            }
                                            else if (error.Contains("This special service type is not allowed for the origin/destination pair. Please update and try again"))
                                            {
                                                MessageBox.Show("Saturday Delivery is not allowed for this shipment based on the origin and destination you selected.Remove SATURDAY_DELIVERY or choose a different service and try again.");
                                            }
                                            return; // Don't retry on bad request

                                        case 401:
                                            ClsCommon.WriteErrorLogs("Unauthorized (401) error. Token may have expired.");
                                            if (retryCount < maxRetries)
                                            {
                                                ClsCommon.WriteErrorLogs("Attempting to refresh token and retry.");
                                                FedXGenerateToken();
                                                retryCount++;
                                                continue; // Retry with new token
                                            }
                                            else
                                            {
                                                MessageBox.Show("Authentication failed after multiple attempts. Please check your credentials.");
                                                return;
                                            }

                                        case 403:
                                            ClsCommon.WriteErrorLogs($"Forbidden (403) error. Response: {responseBody}");
                                            MessageBox.Show("Access forbidden. Please check your API permissions.");
                                            return;

                                        case 404:
                                            ClsCommon.WriteErrorLogs($"Not Found (404) error. Response: {responseBody}");
                                            MessageBox.Show("API endpoint not found.");
                                            return;

                                        case 409:
                                            ClsCommon.WriteErrorLogs($"Conflict (409) error. Response: {responseBody}");
                                            MessageBox.Show("Shipment conflict. This shipment may already exist.");
                                            return;

                                        case 422:
                                            ClsCommon.WriteErrorLogs($"Unprocessable Entity (422) error. Response: {responseBody}");
                                            string errorMessage = ExtractErrorMessage(responseBody);
                                            ClsCommon.WriteErrorLogs($"Validation errors: {errorMessage}");
                                            MessageBox.Show($"Validation error: {errorMessage}");
                                            return; // Don't retry on validation errors

                                        case 429:
                                            ClsCommon.WriteErrorLogs("Too Many Requests (429) error. Rate limiting.");
                                            if (retryCount < maxRetries)
                                            {
                                                ClsCommon.WriteErrorLogs($"Rate limited. Waiting 2 seconds before retry {retryCount + 1}");
                                                Thread.Sleep(2000);
                                                retryCount++;
                                                continue;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Too many requests. Please try again later.");
                                                return;
                                            }

                                        case 500:
                                        case 502:
                                        case 503:
                                        case 504:
                                            ClsCommon.WriteErrorLogs($"Server error ({(int)response.StatusCode}). Response: {responseBody}");
                                            if (retryCount < maxRetries)
                                            {
                                                ClsCommon.WriteErrorLogs($"Server error. Waiting 3 seconds before retry {retryCount + 1}");
                                                Thread.Sleep(3000);
                                                retryCount++;
                                                continue;
                                            }
                                            else
                                            {
                                                MessageBox.Show("FedEx server is experiencing issues. Please try again later.");
                                                return;
                                            }

                                        default:
                                            ClsCommon.WriteErrorLogs($"Unexpected error ({(int)response.StatusCode}): {responseBody}");
                                            MessageBox.Show($"FedEx API error: {response.StatusCode}. Please try again.");
                                            return;
                                    }
                                }
                            }
                            catch (AggregateException aex)
                            {
                                ClsCommon.WriteErrorLogs($"AggregateException in FedEx process: {aex.Message}");
                                foreach (var innerEx in aex.InnerExceptions)
                                {
                                    ClsCommon.WriteErrorLogs($"Inner Exception: {innerEx.Message}");
                                }

                                if (retryCount < maxRetries)
                                {
                                    ClsCommon.WriteErrorLogs($"Retrying after AggregateException. Attempt {retryCount + 1}");
                                    retryCount++;
                                    continue;
                                }
                                else
                                {
                                    MessageBox.Show($"Failed to create shipment after {maxRetries} attempts: {aex.Message}");
                                    return;
                                }
                            }
                            catch (HttpRequestException hrex)
                            {
                                ClsCommon.WriteErrorLogs($"HttpRequestException: {hrex.Message}");

                                if (hrex.Message.Contains("401") && retryCount < maxRetries)
                                {
                                    ClsCommon.WriteErrorLogs("401 Unauthorized detected. Refreshing token.");
                                    FedXGenerateToken();
                                    retryCount++;
                                    continue;
                                }

                                MessageBox.Show($"Network error: {hrex.Message}");
                                return;
                            }
                            catch (Exception ex)
                            {
                                ClsCommon.WriteErrorLogs($"Unexpected error in FedEx process: {ex.Message}");
                                ClsCommon.WriteErrorLogs($"Stack Trace: {ex.StackTrace}");
                                MessageBox.Show($"Error: {ex.Message}");
                                return;
                            }
                        }
                        ClsCommon.ShippingAddressNote = "";
                        ClsCommon.WriteErrorLogs("FedEx shipping process completed successfully.");
                    }
                    catch (Exception ex)
                    {
                        ClsCommon.WriteErrorLogs($"CRITICAL ERROR in FedEx shipping: {ex.Message}");
                        ClsCommon.WriteErrorLogs($"Stack Trace: {ex.StackTrace}");
                        MessageBox.Show($"Critical error: {ex.Message}");
                    }
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("General Exception = " + ex.Message, "E");
                using (WebResponse response = ex.Response)
                {
                    var httpResponse = (HttpWebResponse)response;

                    using (Stream data = response.GetResponseStream())
                    {
                        StreamReader sr2 = new StreamReader(data);
                        string Results = "Error:" + sr2.ReadToEnd();
                        //clsCommonHelper.WriteErrorLog("ShippingMethod:" + apiResponse, "I");  
                    }
                }
            }
        }
        private string AddDeliveryInstructionToZpl(string zpl, string instruction)
        {
            if (string.IsNullOrWhiteSpace(zpl) || string.IsNullOrWhiteSpace(instruction))
                return zpl;

            // Clean unsafe ZPL characters
            instruction = instruction.Replace("^", "").Replace("~", "");

            int fontSize = instruction.Length > 60 ? 22 : 26;

            string zplBlock =
                $"^FO60,1250^A0N,50,50" +
                "^FB700,10,5,L,0" +
                "^FDNOTE: " + instruction +
                "^FS" +
                $"^FO61,1251^A0N,50,50" +
                "^FB700,10,5,L,0" +
                "^FDNOTE: " + instruction +
                "^FS";


            int pos = zpl.LastIndexOf("^XZ");
            if (pos > -1)
            {
                zpl = zpl.Insert(pos, zplBlock);
            }

            return zpl;
        }
        // Helper method to update order tracking
        private string ShowSaveLabelDialog(string defaultFileName)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Save FedEx Label";
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.DefaultExt = "pdf";
                sfd.FileName = defaultFileName;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    return sfd.FileName;
                }
            }
            return "";
        }
        private string ExtractErrorMessage(string responseBody)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(responseBody))
                    return "Unknown error occurred.";

                var json = JObject.Parse(responseBody);

                if (json["errors"] != null && json["errors"].HasValues)
                {
                    return json["errors"][0]["message"]?.ToString() ?? "Request failed.";
                }

                if (json["message"] != null)
                {
                    return json["message"].ToString();
                }

                return "Request failed. Please check shipment data.";
            }
            catch
            {
                return "Request failed. Please verify shipment details.";
            }
        }
        public void ShipNotification(string TrackingNumber, int package)
        {
            try
            {
                DateTime d = new DateTime();
                DataTable DATA = new DataTable();
                //TimeTrackCode();
                string CustomerNameInShip = "";
                string addressInShip = "";
                string CityStateCodeInShip = "";
                string CountryInShip = "";
                string UPSServiceInShip = "";
                string labelPackagesInShip = "";
                string labelWeightInShip = "";
                string DeliveryDateInShip = "";
                string InvoiceNumberInShip = "";
                string DayWithDateInShip = "";
                if (File.Exists(Application.StartupPath + @"\HTMLPage\" + "Ship.html"))
                {
                    string html = File.ReadAllText(Application.StartupPath + @"\HTMLPage\" + "Ship.html");
                    if (txtToName.Text != "")
                    {
                        CustomerNameInShip = txtToName.Text;
                    }
                    else
                    {
                        CustomerNameInShip = txtToAddress1.Text;
                        addressInShip = txtToAddress2.Text;
                    }
                    if (addressInShip == "")
                    {
                        addressInShip = txtToAddress1.Text + " " + txtToAddress2.Text;
                    }
                    CityStateCodeInShip = txtToCity.Text + "," + txtToState.Text + " " + txtToZip.Text;
                    CountryInShip = txtToCountry.Text;
                    UPSServiceInShip = cmbService.Text;
                    labelPackagesInShip = package.ToString();
                    labelWeightInShip = clsOnline.dtMaster.Rows[0]["Weight"].ToString() + " LBS";
                    if (clsOnline.dtTime.Rows.Count > 0)
                    {
                        DataView dv = null;
                        dv = clsOnline.dtTime.DefaultView;
                        dv.RowFilter = "[ServiceDescription] = '" + cmbService.Text + "'";
                        DATA = dv.ToTable();
                    }
                    //if (DATA.Rows.Count > 0)
                    //{
                    //    if (DATA.Rows[0]["Date"].ToString() != "")
                    //    {
                    //        d = Convert.ToDateTime(DATA.Rows[0]["Date"].ToString());
                    //    }
                    //    DeliveryDateInShip = d.ToString("MM/dd/yyyy");


                    //    DayWithDateInShip = d.ToString("dddd") + ", " + d.ToString("MM/dd/yyyy");

                    //}
                    InvoiceNumberInShip = txtRefNumber.Text;

                    string newFile = html.Replace("CustomerNameInShip", CustomerNameInShip).Replace("addressInShip", addressInShip).Replace("CityStateCodeInShip", CityStateCodeInShip).Replace("CountryInShip", CountryInShip)
                     .Replace("UPSServiceInShip", UPSServiceInShip).Replace("labelPackagesInShip", labelPackagesInShip).Replace("labelWeightInShip", labelWeightInShip).Replace("DeliveryDateInShip", DeliveryDateInShip)
                     .Replace("InvoiceNumberInShip", InvoiceNumberInShip).Replace("DayWithDateInShip", DayWithDateInShip).Replace("TrackingNumberInShip", TrackingNumber);

                    if (chkNotification.Checked == true)
                    {
                        if (txtToEmail.Text != "")
                        {
                            MailMessage msg = new MailMessage();
                            msg.From = new MailAddress("txpartspay@gmail.com");
                            msg.To.Add(txtToEmail.Text);
                            msg.Subject = "UPS Ship Notification, Tracking Number " + TrackingNumber + "";

                            string date = DateTime.Now.ToString("dddd, MMMM dd, yyyy hh:MM tt");

                            msg.Body = "<b>From: </b> <span style=color:black> UPS txpartspay@gmail.com</span><br />" + "<b>Sent: </b>" + date + "<br />" + "<b>To: </b>" + txtToEmail.Text + "<br />" + "<b>Subject: </b> UPS Ship Notification, Tracking Number " + TrackingNumber + "<br />" + newFile;

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
                                    ClsCommon.WriteErrorLogs("Error in ShipNotification Email" + ex.Message);
                                    MessageBox.Show("Error:" + ex.Message);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: ShipNotification, Message:" + ex.Message);
            }
        }
        public void ShipFedExNotification(string TrackingNumber, int package)
        {
            try
            {
                string htmlPath = Application.StartupPath + @"\HTMLPage\fedex-ship.html";
                if (!File.Exists(htmlPath))
                {
                    MessageBox.Show("FedEx HTML template not found.");
                    return;
                }

                string html = File.ReadAllText(htmlPath);

                // ✅ SAFE DATA BINDING
                string CustomerNameInShip = !string.IsNullOrWhiteSpace(txtToName.Text)
                                                ? txtToName.Text
                                                : txtToAddress1.Text;

                string addressInShip = !string.IsNullOrWhiteSpace(txtToAddress2.Text)
                                                ? txtToAddress1.Text + " " + txtToAddress2.Text
                                                : txtToAddress1.Text;

                string CityStateCodeInShip = $"{txtToCity.Text}, {txtToState.Text} {txtToZip.Text}";
                string CountryInShip = txtToCountry.Text;
                string FedExServiceInShip = cmbService.Text;
                string labelPackagesInShip = package.ToString();
                //string labelWeightInShip = clsOnline.dtMaster.Rows.Count > 0
                //                            ? clsOnline.dtMaster.Rows[0]["Weight"].ToString() + " LBS"
                //                            : "0 LBS";
                string labelWeightInShip = dgvPackage.CurrentRow.Cells["Weight"].Value?.ToString() ?? "0";

                string InvoiceNumberInShip = txtRefNumber.Text;
                string DayWithDateInShip = DateTime.Now.ToString("dddd, MM/dd/yyyy");
                string DeliveryDateInShip = ""; // Optional if FedEx API gives ETA later

                // ✅ BIND TEMPLATE VALUES
                string newFile = html
                    .Replace("CustomerNameInShip", CustomerNameInShip)
                    .Replace("addressInShip", addressInShip)
                    .Replace("CityStateCodeInShip", CityStateCodeInShip)
                    .Replace("CountryInShip", CountryInShip)
                    .Replace("FedExServiceInShip", FedExServiceInShip)
                    .Replace("labelPackagesInShip", labelPackagesInShip)
                    .Replace("labelWeightInShip", labelWeightInShip)
                    .Replace("DeliveryDateInShip", DeliveryDateInShip)
                    .Replace("InvoiceNumberInShip", InvoiceNumberInShip)
                    .Replace("DayWithDateInShip", DayWithDateInShip)
                    .Replace("TrackingNumberInShip", TrackingNumber);

                // ✅ SEND EMAIL ONLY IF ENABLED
                if (chkNotification.Checked && !string.IsNullOrWhiteSpace(txtToEmail.Text))
                {
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("txpartspay@gmail.com");
                    msg.To.Add(txtToEmail.Text);
                    msg.Subject = "FedEx Shipment Notification - Tracking " + TrackingNumber;

                    string date = DateTime.Now.ToString("dddd, MMMM dd, yyyy hh:mm tt");

                    msg.Body = "<b>From:</b> <span style='color:black'>FedEx txpartspay@gmail.com</span><br/>"
                             + "<b>Sent:</b> " + date + "<br/>"
                             + "<b>To:</b> " + txtToEmail.Text + "<br/>"
                             + "<b>Subject:</b> FedEx Shipment Notification - Tracking " + TrackingNumber + "<br/><br/>"
                             + newFile;

                    msg.IsBodyHtml = true;

                    using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                    {
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(
                            "txpartspay@gmail.com",
                            "newqwzinxyjxiybr"  // ✅ App password
                        );

                        client.Send(msg);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ClsCommon.WriteErrorLogs("ShipFedExNotification Error: " + ex.Message);
            }
        }
        public System.Drawing.Image ResizeAcordingToImage(System.Drawing.Image Source, int boxWidth, int boxHeight)
        {
            System.Drawing.Image resizedImage;
            double dbl = (double)Source.Width / (double)Source.Height;
            //set height of image to boxHeight and check if resulting width is less than boxWidth, 
            //else set width of image to boxWidth and calculate new height
            if ((int)((double)boxHeight * dbl) <= boxWidth)
            {
                resizedImage = new Bitmap(Source, (int)((double)boxHeight * dbl), boxHeight);
            }
            else
            {
                resizedImage = new Bitmap(Source, boxWidth, (int)((double)boxWidth / dbl));
            }

            return resizedImage;

        }
        // UPS Process
        private void AcceptShipmentRequest(string ShipmentDigest)
        {
            if (dtUPS.Rows.Count > 0)
            {
                try
                {

                    clsOnline.ExtractResponse_POST_JSON(ShipmentDigest);

                    string TrackingNumber = "";
                    string TotalCost = "";
                    if (clsOnline.dtMaster.Rows.Count > 0 && clsOnline.dtChild.Rows.Count > 0)
                    {
                        for (int i = 0; i < clsOnline.dtChild.Rows.Count; i++)
                        {
                            if (TrackingNumber == "")
                                TrackingNumber = clsOnline.dtChild.Rows[i]["TrackingNumber"].ToString();

                            var base64EncodedBytes = System.Convert.FromBase64String(clsOnline.dtChild.Rows[i]["GraphicImage"].ToString());
                            using (var imageFile = new FileStream(Application.StartupPath + "\\Shipment\\" + clsOnline.dtChild.Rows[i]["TrackingNumber"].ToString() + ".gif", FileMode.Create))
                            {
                                imageFile.Write(base64EncodedBytes, 0, base64EncodedBytes.Length);
                                imageFile.Flush();
                            }
                        }
                        grpTrack.Visible = true;
                        PictureBox1.Visible = true;
                        //btnPrint.Visible = true;
                        for (int i = 0; i < clsOnline.dtChild.Rows.Count; i++)
                        {
                            TrackingNumber = clsOnline.dtChild.Rows[i]["TrackingNumber"].ToString();
                            Bitmap bitmap1 = (Bitmap)Bitmap.FromFile(Application.StartupPath + "\\Shipment\\" + clsOnline.dtChild.Rows[i]["TrackingNumber"].ToString() + ".gif");
                            bitmap1.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            PictureBox1.Image = bitmap1;
                            bitmap1 = null;
                            File.Delete(Application.StartupPath + "\\Shipment\\" + clsOnline.dtChild.Rows[i]["TrackingNumber"].ToString() + ".gif");
                            PictureBox1.Image.Save(Application.StartupPath + "\\Shipment\\" + clsOnline.dtChild.Rows[i]["TrackingNumber"].ToString() + ".gif", ImageFormat.Jpeg);
                        }
                        lblTransport.Text = clsOnline.dtMaster.Rows[0]["TransportationCharges"].ToString();
                        lblService.Text = clsOnline.dtMaster.Rows[0]["ServiceOptionsCharges"].ToString();
                        lblTotal.Text = clsOnline.dtMaster.Rows[0]["TotalCharges"].ToString();
                        lblTracking.Text = TrackingNumber;
                        if (clsOnline.dtMaster.Rows[0]["NegotiatedRate"].ToString() != "")
                        {
                            TotalCost = clsOnline.dtMaster.Rows[0]["NegotiatedRate"].ToString();
                        }
                        else
                        {
                            TotalCost = clsOnline.dtMaster.Rows[0]["TotalCharges"].ToString();
                        }
                        UpdateInDB(RefNumber, clsOnline.dtMaster.Rows[0]["Weight"].ToString(), lblService.Text, TotalCost);


                    }
                }
                catch (Exception ex)
                {
                    ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: AcceptShipmentRequest, Message:" + ex.Message);
                    //MessageBox.Show("General Exception = " + ex.Message, "E");
                }
            }
        }
        private void UpdateInDB(string _EntityId, string WEIGHT, string Charges, string TotalCost)
        {
            try
            {
                _Status = "Success";
                string Id = clsOnline.UpdateInInvoice(_EntityId, lblTracking.Text, txtToEmail.Text);
                if (Id == "")
                {
                    MessageBox.Show("Issue During Update Tracking Code to QuickBooks");
                }
                if (rdbFedEx.Checked == true)
                {
                    objBOL.Type = "FedEx";
                }
                else if (rdbUPS.Checked == true)
                {
                    objBOL.Type = "UPS";
                }
                objBOL.OrderID = _EntityId;
                objBOL.TrackingID = lblTracking.Text;
                objBOL.Time = DateTime.Now;
                objBOL.Status = _Status;
                objBOL.CreatedBy = ClsCommon.UserID;
                if (txtCODAmount.Text != "")
                {
                    objBOL.COD = txtCODAmount.Text;
                }
                else
                {
                    objBOL.COD = "0";
                }
                if (cmbService.Text != "" || cmbService.Text != "Select Service")
                {
                    objBOL.Service = cmbService.Text;
                }
                objBOL.Weight = WEIGHT;
                if (Charges != "")
                {
                    objBOL.Charges = Charges;
                }
                if (TotalCost != "")
                {
                    objBOL.TotalCost = TotalCost;
                }
                else
                {
                    objBOL.TotalCost = "0";
                }

                objBAL.UPS_FedExHistoryInsert(objBOL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private string GetAcceptXML(string ShipmentDigest)
        {
            string XML = "";
            try
            {

                XML += " <?xml version=\"1.0\"?> ";
                XML += "   <ShipmentAcceptRequest>";
                XML += "  <Request>";
                XML += "  <TransactionReference></TransactionReference>";
                XML += "  <RequestAction>ShipAccept</RequestAction>";
                XML += "  </Request>";
                XML += "  <ShipmentDigest>" + ShipmentDigest + "</ShipmentDigest>";
                XML += "  </ShipmentAcceptRequest>";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: GetAcceptXML, Message:" + ex.Message);
                MessageBox.Show("General Exception = " + ex.Message, "E");
            }
            return XML;
        }
        private string GetUPSXML()
        {
            string XML = "";
            try
            {

                XML += " <?xml version=\"1.0\"?> ";
                XML += " <ShipmentConfirmRequest>";
                XML += "  <Request>";
                XML += "  <RequestAction>ShipConfirm</RequestAction> ";
                XML += " <RequestOption>nonvalidate</RequestOption> ";
                XML += " </Request>";
                XML += "  <Shipment> ";
                XML += "  <Shipper>";
                XML += " <Name>" + lblName.Text.ToString() + "</Name>";
                XML += " <AttentionName>" + lblCompanyName.Text.ToString() + "</AttentionName>";
                XML += " <PhoneNumber>" + lblPhone.Text.ToString() + "</PhoneNumber>";
                XML += " <ShipperNumber>4E9A02</ShipperNumber>";
                String[] addressLine = { lblAddress1.Text.ToString(), lblAddress2.Text == null ? "" : lblAddress2.Text.ToString() };
                XML += " <Address>";
                XML += " <AddressLine1>" + addressLine[0].ToString() + "</AddressLine1> ";
                if (addressLine.Length > 1)
                {
                    XML += " <AddressLine2>" + addressLine[1].ToString() + "</AddressLine2> ";
                }
                XML += " <City>" + lblCity.Text.ToString() + "</City> ";
                XML += " <StateProvinceCode>" + lblState.Text.ToString() + "</StateProvinceCode>";
                XML += " <PostalCode>" + NormalizePostalCode(lblZip.Text) + "</PostalCode> ";
                XML += " <CountryCode>" + NormalizeCountryCode(lblCountry.Text) + "</CountryCode> ";
                XML += " </Address>";
                XML += " </Shipper>";
                XML += " <ShipTo>";
                XML += " <AttentionName>" + txtToName.Text.ToString() + "</AttentionName> ";
                XML += " <PhoneNumber>" + txtToPhone.Text.ToString() + "</PhoneNumber> ";
                if (txtToCompany.Text.ToString().Trim() != txtToName.Text.ToString().Trim())
                    XML += " <CompanyName>" + txtToCompany.Text.ToString().Replace("&", "and") + "</CompanyName> ";
                String[] addressLine1 = { txtToAddress1.Text.ToString(), txtToAddress2.Text == null ? "" : txtToAddress2.Text.ToString() };
                XML += " <Address> <AddressLine1>" + addressLine1[0].ToString() + "</AddressLine1>";
                if (addressLine1.Length > 1)
                {
                    XML += " <AddressLine2>" + addressLine1[1].ToString() + "</AddressLine2> ";
                }
                XML += " <City>" + txtToCity.Text.ToString() + "</City> ";
                XML += " <StateProvinceCode>" + txtToState.Text.ToString().ToUpper().Replace("texas", "TX").Replace("Texas", "TX").Replace("Oklahoma", "OK") + "</StateProvinceCode>";
                XML += " <PostalCode>" + NormalizePostalCode(txtToZip.Text) + "</PostalCode> ";
                XML += " <CountryCode>" + NormalizeCountryCode(txtToCountry.Text) + "</CountryCode> ";
                XML += " </Address> ";
                XML += " </ShipTo> ";



                if (chkSaturdayDelivery.Checked == true)
                {
                    XML += " <ShipmentServiceOptions>";
                    XML += " <SaturdayDelivery/>";
                    XML += " </ShipmentServiceOptions>";
                }
                if (chkDirectDeliveryOnly.Checked == true)
                {
                    XML += " <ShipmentServiceOptions>";
                    XML += "  <DirectDeliveryOnlyIndicator>yes</DirectDeliveryOnlyIndicator> ";
                    XML += " </ShipmentServiceOptions>";
                }
                if (chkSaturdayPickup.Checked == true)
                {
                    XML += " <ShipmentServiceOptions>";
                    XML += "  <SaturdayPickupIndicator>yes</SaturdayPickupIndicator> ";
                    XML += " </ShipmentServiceOptions>";
                }
                XML += "  <Service> <Code>" + cmbService.SelectedValue.ToString() + "</Code> </Service> ";
                XML += " <PaymentInformation> ";
                XML += " <Prepaid>";
                XML += "  <BillShipper>";
                XML += "  <AccountNumber>4E9A02</AccountNumber> ";
                XML += " </BillShipper> ";
                XML += " </Prepaid> ";
                XML += " </PaymentInformation>";
                if (dgvPackage.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvPackage.Rows.Count; i++)
                    {
                        XML += "<Package>";
                        XML += "<PackageServiceOptions>";
                        if (cmbConfirmation.SelectedValue.ToString() != "0")
                        {
                            if (chkCOD.Checked == true)
                            {
                                XML += "<DeliveryConfirmation>";
                                XML += "<DCISType>3</DCISType>";
                                XML += "</DeliveryConfirmation>";
                            }
                            else
                            {
                                XML += "<DeliveryConfirmation>";
                                XML += "<DCISType>" + cmbConfirmation.SelectedValue + "</DCISType>";
                                XML += "</DeliveryConfirmation>";
                            }
                        }
                        if (chkCOD.Checked == true)
                        {
                            XML += "<COD>";
                            XML += "<CODCode>3</CODCode>";
                            XML += "<CODFundsCode>" + cmbCOD.SelectedValue + "</CODFundsCode>";
                            XML += "<CODAmount>";
                            XML += "<CurrencyCode>USD</CurrencyCode>";
                            XML += "<MonetaryValue>" + Convert.ToDecimal(txtCODAmount.Text) + "</MonetaryValue>";
                            XML += "</CODAmount>";
                            XML += "</COD>";
                        }
                        if (txtDeclaredValue.Text != "")
                        {
                            XML += "<InsuredValue>";
                            XML += "<CurrencyCode>USD</CurrencyCode>";
                            XML += "<MonetaryValue>" + Convert.ToDecimal(txtDeclaredValue.Text) + "</MonetaryValue>";
                            XML += "</InsuredValue>";
                        }
                        XML += "</PackageServiceOptions>";
                        XML += "  <PackagingType> ";
                        XML += "<Code>" + cmbPackaging.SelectedValue + "</Code>";
                        XML += "<Description>" + cmbPackaging.Text + "</Description>";
                        XML += "  </PackagingType>";
                        if (txtWeight.Text != "")
                        {
                            XML += " <Dimensions> ";
                            XML += " <UnitOfMeasurement> ";
                            XML += " <Code>IN</Code> ";
                            XML += " </UnitOfMeasurement>";
                            XML += "  <Length>" + txtLength.Text + "</Length> ";
                            XML += "  <Width>" + txtWidth.Text + "</Width>";
                            XML += "  <Height>" + txtHeight.Text + "</Height>";
                            XML += "  </Dimensions> ";

                            XML += " <PackageWeight>";
                            XML += " <Weight>" + txtWeight.Text + "</Weight> ";
                        }
                        else
                        {
                            XML += " <Dimensions> ";
                            XML += " <UnitOfMeasurement> ";
                            XML += " <Code>IN</Code> ";
                            XML += " </UnitOfMeasurement>";
                            XML += "  <Length>" + dgvPackage.Rows[i].Cells["Length"].Value.ToString() + "</Length> ";
                            XML += "  <Width>" + dgvPackage.Rows[i].Cells["Width"].Value.ToString() + "</Width>";
                            XML += "  <Height>" + dgvPackage.Rows[i].Cells["Height"].Value.ToString() + "</Height>";
                            XML += "  </Dimensions> ";

                            XML += " <PackageWeight>";
                            XML += " <Weight>" + dgvPackage.Rows[i].Cells["Weight"].Value.ToString() + "</Weight> ";
                        }
                        XML += " </PackageWeight> ";

                        XML += " <ReferenceNumber>";
                        XML += " <Code>IK</Code>";
                        XML += " <Value>#" + txtRefNumber.Text + "</Value>";
                        XML += " </ReferenceNumber>";
                        XML += " </Package>";
                    }
                }
                if (dtAccessUPS.Rows.Count > 0)
                {
                    if (dtAccessUPS.Rows[0]["NegotiatedRate"].ToString() == "1")
                    {
                        XML += "<RateInformation> ";
                        XML += "<NegotiatedRatesIndicator/> ";
                        XML += "</RateInformation> ";
                    }
                }
                XML += "  </Shipment>";
                XML += "  <LabelSpecification> ";
                XML += " <LabelPrintMethod>";
                XML += "  <Code>GIF</Code> ";
                XML += " </LabelPrintMethod>";
                XML += "  <LabelImageFormat> ";
                XML += " <Code>GIF</Code> ";
                XML += " </LabelImageFormat>";
                XML += "  </LabelSpecification>";
                XML += "  </ShipmentConfirmRequest> ";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: GetUPSXML, Message:" + ex.Message);
                MessageBox.Show("General Exception = " + ex.Message, "E");
            }
            return XML;
        }
        private string GetUPSJSON()
        {
            string json = "";
            try
            {
                var shipmentRequest = new
                {
                    ShipmentRequest = new
                    {
                        Request = new
                        {
                            TransactionReference = new
                            {
                                CustomerContext = "ShipConfirm"
                            }
                        },
                        Shipment = new
                        {
                            Shipper = new
                            {
                                Name = lblName.Text,
                                AttentionName = lblCompanyName.Text,
                                Phone = new { Number = lblPhone.Text },
                                ShipperNumber = "4E9A02",
                                Address = new
                                {
                                    AddressLine = new List<string>
                            {
                                lblAddress1.Text,
                                string.IsNullOrEmpty(lblAddress2.Text) ? "" : lblAddress2.Text
                            },
                                    City = lblCity.Text,
                                    StateProvinceCode = lblState.Text,
                                    PostalCode = NormalizePostalCode(lblZip.Text),
                                    CountryCode = NormalizeCountryCode(lblCountry.Text)
                                }
                            },
                            ShipTo = new
                            {
                                Name = txtToName.Text,
                                AttentionName = txtToCompany.Text,
                                Phone = new { Number = txtToPhone.Text },
                                Address = new
                                {
                                    AddressLine = new List<string>
                            {
                                txtToAddress1.Text,
                                string.IsNullOrEmpty(txtToAddress2.Text) ? "" : txtToAddress2.Text
                            },
                                    City = txtToCity.Text,
                                    StateProvinceCode = txtToState.Text.ToUpper(),
                                    PostalCode = NormalizePostalCode(txtToZip.Text),
                                    CountryCode = NormalizeCountryCode(txtToCountry.Text)
                                }
                            },
                            Service = new
                            {
                                Code = cmbService.SelectedValue.ToString()
                            },
                            PaymentInformation = new
                            {
                                ShipmentCharge = new
                                {
                                    Type = "01",
                                    BillShipper = new { AccountNumber = "4E9A02" }
                                }
                            },
                            Package = dgvPackage.Rows.Cast<DataGridViewRow>()
                                .Where(r => !r.IsNewRow)
                                .Select(r => new
                                {
                                    Packaging = new
                                    {
                                        Code = cmbPackaging.SelectedValue.ToString()
                                    },
                                    Dimensions = new
                                    {
                                        UnitOfMeasurement = new { Code = "IN" },
                                        //Length = string.IsNullOrEmpty(txtLength.Text) ? r.Cells["Length"].Value.ToString() : txtLength.Text,
                                        //Width = string.IsNullOrEmpty(txtWidth.Text) ? r.Cells["Width"].Value.ToString() : txtWidth.Text,
                                        //Height = string.IsNullOrEmpty(txtHeight.Text) ? r.Cells["Height"].Value.ToString() : txtHeight.Text
                                        Length = (string.IsNullOrEmpty(txtLength.Text) || txtLength.Text == "0") ? ((r.Cells["Length"].Value == null || r.Cells["Length"].Value.ToString() == "0") ? "1" : r.Cells["Length"].Value.ToString()) : txtLength.Text,

                                        Width = (string.IsNullOrEmpty(txtWidth.Text) || txtWidth.Text == "0") ? ((r.Cells["Width"].Value == null || r.Cells["Width"].Value.ToString() == "0") ? "1" : r.Cells["Width"].Value.ToString()) : txtWidth.Text,

                                        Height = (string.IsNullOrEmpty(txtHeight.Text) || txtHeight.Text == "0") ? ((r.Cells["Height"].Value == null || r.Cells["Height"].Value.ToString() == "0") ? "1" : r.Cells["Height"].Value.ToString()) : txtHeight.Text
                                    },
                                    PackageWeight = new
                                    {
                                        UnitOfMeasurement = new { Code = "LBS" },
                                        Weight = string.IsNullOrEmpty(txtWeight.Text) ? r.Cells["Weight"].Value.ToString() : txtWeight.Text
                                    },
                                    ReferenceNumber = new
                                    {
                                        Value = "#" + txtRefNumber.Text
                                    },
                                    PackageServiceOptions = new
                                    {
                                        COD = chkCOD.Checked
                                            ? new
                                            {
                                                CODFundsCode = cmbCOD.SelectedValue.ToString(),
                                                CODAmount = new
                                                {
                                                    CurrencyCode = "USD",
                                                    MonetaryValue = Convert.ToDecimal(txtCODAmount.Text).ToString("F2")
                                                }
                                            }
                                            : null,
                                        DeclaredValue = !string.IsNullOrEmpty(txtDeclaredValue.Text)
                                            ? new
                                            {
                                                CurrencyCode = "USD",
                                                MonetaryValue = Convert.ToDecimal(txtDeclaredValue.Text).ToString("F2")
                                            }
                                            : null
                                    }
                                }).ToList(),
                            ShipmentServiceOptions = new
                            {
                                SaturdayDeliveryIndicator = chkSaturdayDelivery.Checked ? new { } : null,
                                DirectDeliveryOnlyIndicator = chkDirectDeliveryOnly.Checked ? new { } : null,
                                SaturdayPickupIndicator = chkSaturdayPickup.Checked ? new { } : null
                            },
                            RateInformation = (dtAccessUPS.Rows.Count > 0 && dtAccessUPS.Rows[0]["NegotiatedRate"].ToString() == "1")
                                ? new { NegotiatedRatesIndicator = new { } }
                                : null
                        },
                        LabelSpecification = new
                        {
                            LabelImageFormat = new { Code = "GIF" },
                            LabelStockSize = new { Width = "4", Height = "6" }
                        }
                    }
                };

                json = Newtonsoft.Json.JsonConvert.SerializeObject(shipmentRequest,
                    Newtonsoft.Json.Formatting.None,
                    new Newtonsoft.Json.JsonSerializerSettings
                    {
                        NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
                    });
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: GetUPSJSON, Message:" + ex.Message);
                MessageBox.Show("General Exception = " + ex.Message, "E");
            }
            return json;
        }
        public string GetUSPSRateXML()
        {
            string XML = "";
            try
            {
                dtUPS = new DataTable();
                XML = " <?xml version=\"1.0\"?> <AccessRequest xml:lang=\"en-US\">";
                XML += "<AccessLicenseNumber>0DC4652BAD18B0C0 </AccessLicenseNumber><UserId>TPARTS786</UserId><Password>Txparts43918$</Password></AccessRequest> ";
                //XML += "<?xml version=\"1.0\"?>";
                XML += "<RatingServiceSelectionRequest xml:lang=\"en-US\">";

                XML += "<Request>";
                //XML += "<TransactionReference>";
                //XML += "<CustomerContext>Rate</CustomerContext>";
                //XML += "</TransactionReference>";
                XML += "<RequestAction>Rate</RequestAction>";
                XML += "<RequestOption>Rate</RequestOption>";
                //XML += "<SubVersion>1801</SubVersion>";
                XML += "</Request>";

                //XML += "<PickupType>";
                //XML += "<Code>" + cmbService.SelectedValue.ToString() + "</Code>";
                //XML += "</PickupType>";

                //XML += "<CustomerClassification>";
                //XML += "<Code>" + cmbService.SelectedValue.ToString() + "</Code>";
                //XML += "</CustomerClassification>";

                XML += "<Shipment>";
                //XML += "<OriginRecordTransactionTimestamp>" + cmbService.SelectedValue.ToString() + "</OriginRecordTransactionTimestamp>";
                XML += "<Shipper>";
                XML += "<Name>" + lblName.Text.ToString() + "</Name>";
                XML += "<AttentionName>" + lblCompanyName.Text.ToString() + "</AttentionName>";
                XML += "<PhoneNumber>" + lblPhone.Text.ToString() + "</PhoneNumber>";
                XML += "<ShipperNumber>4E9A02</ShipperNumber>";
                String[] addressLine = { lblAddress1.Text.ToString(), lblAddress2.Text == null ? "" : lblAddress2.Text.ToString() };
                XML += "<Address>";
                XML += "<AddressLine1>" + addressLine[0].ToString() + "</AddressLine1>";
                if (addressLine.Length > 1)
                {
                    XML += "<AddressLine2>" + addressLine[1].ToString() + "</AddressLine2>";
                }
                XML += "<City>" + lblCity.Text.ToString() + "</City> ";
                XML += "<StateProvinceCode>" + lblState.Text.ToString() + "</StateProvinceCode>";
                XML += "<PostalCode>" + NormalizePostalCode(lblZip.Text) + "</PostalCode>";
                XML += "<CountryCode>" + NormalizeCountryCode(lblCountry.Text) + "</CountryCode>";
                XML += "</Address>";
                XML += "</Shipper>";

                XML += "<ShipTo>";
                XML += "<CompanyName>" + txtToCompany.Text.ToString() + "</CompanyName>";
                XML += "<PhoneNumber>" + txtToPhone.Text.ToString() + "</PhoneNumber>";
                XML += "<AttentionName>" + txtToName.Text.ToString() + "</AttentionName>";
                String[] addressLine1 = { txtToAddress1.Text.ToString(), txtToAddress2.Text == null ? "" : txtToAddress2.Text.ToString() };
                XML += "<Address> <AddressLine1>" + addressLine1[0].ToString() + "</AddressLine1>";
                if (addressLine1.Length > 1)
                {
                    XML += "<AddressLine2>" + addressLine1[1].ToString() + "</AddressLine2>";
                }
                XML += "<City>" + txtToCity.Text.ToString() + "</City>";
                XML += "<StateProvinceCode>" + txtToState.Text.ToString().ToUpper().Replace("texas", "TX").Replace("Texas", "TX").Replace("Oklahoma", "OK") + "</StateProvinceCode>";
                XML += "<PostalCode>" + NormalizePostalCode(txtToZip.Text) + "</PostalCode>";
                XML += "<CountryCode>" + NormalizeCountryCode(txtToCountry.Text) + "</CountryCode>";
                XML += "</Address> ";
                XML += "</ShipTo> ";

                XML += "<Service> <Code>" + cmbService.SelectedValue.ToString() + "</Code> </Service>";


                if (chkSaturdayDelivery.Checked == true)
                {
                    XML += " <ShipmentServiceOptions>";
                    XML += " <SaturdayDelivery/>";
                    XML += " </ShipmentServiceOptions>";
                }
                if (chkDirectDeliveryOnly.Checked == true)
                {
                    XML += " <ShipmentServiceOptions>";
                    XML += "  <DirectDeliveryOnlyIndicator>yes</DirectDeliveryOnlyIndicator> ";
                    XML += " </ShipmentServiceOptions>";
                }
                if (chkSaturdayPickup.Checked == true)
                {
                    XML += " <ShipmentServiceOptions>";
                    XML += "  <SaturdayPickupIndicator>yes</SaturdayPickupIndicator> ";
                    XML += " </ShipmentServiceOptions>";
                }
                //XML += "<ShipmentServiceOptions>";
                //XML += "<COD>";
                //XML += "<CODCode>" + "COD" + "</CODCode>";
                //XML += "<CODFundsCode>" + "5" + "</CODFundsCode>";
                //XML += "<CODAmount>";
                //XML += "<CurrencyCode> " + "US" + "</CurrencyCode>";
                //XML += "<MonetaryValue> " + "12" + "</MonetaryValue>";
                //XML += "</CODAmount>";
                //XML += "</COD>";
                //XML += "</ShipmentServiceOptions>";
                //XML += "<ShipmentTotalWeight>";
                //XML += "<UnitOfMeasurement>";
                //XML += "<Code>KGS</Code>";
                //XML += "<Description>UOM in KG</Description>";
                //XML += "</UnitOfMeasurement>";
                //XML += "<Weight>2</Weight>";    
                //XML += "</ShipmentTotalWeight>";

                if (dgvPackage.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvPackage.Rows.Count; i++)
                    {
                        XML += "<Package>";
                        XML += "<PackageServiceOptions>";
                        if (chkCOD.Checked == true)
                        {
                            XML += "<COD>";
                            XML += "<CODCode>3</CODCode>";
                            XML += "<CODFundsCode>" + cmbCOD.SelectedValue + "</CODFundsCode>";
                            XML += "<CODAmount>";
                            XML += "<CurrencyCode>USD</CurrencyCode>";
                            XML += "<MonetaryValue>" + Convert.ToDecimal(txtCODAmount.Text) + "</MonetaryValue>";
                            XML += "</CODAmount>";
                            XML += "</COD>";
                        }
                        XML += "</PackageServiceOptions>";
                        XML += "<PackagingType>";
                        XML += "<Code>02</Code>";
                        XML += "<Description>UPS Package</Description>";
                        XML += "</PackagingType>";
                        XML += "<Dimensions>";
                        XML += "<UnitOfMeasurement>";
                        XML += "<Code>IN</Code>";
                        XML += "</UnitOfMeasurement>";
                        XML += "<Length>" + "1" + "</Length>";
                        XML += "<Width>" + "1" + "</Width>";
                        XML += "<Height>" + "1" + "</Height>";
                        XML += "</Dimensions> ";
                        XML += " <PackageWeight>";
                        XML += " <UnitOfMeasurement>";
                        XML += " <Code>LBS</Code> ";
                        XML += " </UnitOfMeasurement>";
                        if (txtWeight.Text != "")
                        {
                            XML += " <Weight>" + txtWeight.Text + "</Weight> ";
                        }
                        else
                        {
                            XML += " <Weight>" + dgvPackage.Rows[i].Cells[1].Value.ToString() + "</Weight> ";
                        }
                        XML += " </PackageWeight> ";
                        XML += " </Package>";
                    }
                }
                if (dtAccessUPS.Rows.Count > 0)
                {
                    if (dtAccessUPS.Rows[0]["NegotiatedRate"].ToString() == "1")
                    {
                        XML += "<RateInformation> ";
                        XML += "<NegotiatedRatesIndicator/> ";
                        XML += "</RateInformation> ";

                    }
                }
                //XML += "<InvoiceLineTotal>";
                //XML += "<CurrencyCode>US</CurrencyCode>";
                //XML += "<MonetaryValue>200</MonetaryValue>";
                //XML += "</InvoiceLineTotal>";
                //XML += "<DeliveryTimeInformation>";
                //XML += "<PackageBillType>07</PackageBillType>";
                //XML += "</DeliveryTimeInformation>";

                XML += "</Shipment>";
                XML += "</RatingServiceSelectionRequest>";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: GetUSPSRateXML, Message:" + ex.Message);
                MessageBox.Show("General Exception = " + ex.Message, "E");
            }
            return XML;
        }
        private string GetUPSRateJSON(bool singleService)
        {
            string upsAccount = "4E9A02";  // MUST BE VALID NUMERIC ACCOUNT

            var shipment = new
            {
                Shipper = new
                {
                    Name = lblName.Text,
                    ShipperNumber = upsAccount,
                    Address = new
                    {
                        AddressLine = new List<string>
                {
                    lblAddress1.Text
                }.Where(x => !string.IsNullOrWhiteSpace(x)).ToList(),
                        City = lblCity.Text,
                        StateProvinceCode = lblState.Text,
                        PostalCode = NormalizePostalCode(lblZip.Text),
                        CountryCode = NormalizeCountryCode(lblCountry.Text)
                    }
                },

                ShipTo = new
                {
                    Name = txtToName.Text,
                    Address = new
                    {
                        AddressLine = new List<string>
                {
                    txtToAddress1.Text,
                    txtToAddress2.Text
                }.Where(x => !string.IsNullOrWhiteSpace(x)).ToList(),
                        City = txtToCity.Text,
                        StateProvinceCode = txtToState.Text.ToUpper(),
                        PostalCode = NormalizePostalCode(txtToZip.Text),
                        CountryCode = NormalizeCountryCode(txtToCountry.Text)
                    }
                },

                ShipFrom = new
                {
                    Name = lblName.Text,
                    Address = new
                    {
                        AddressLine = new List<string>
                {
                    lblAddress1.Text
                }.Where(x => !string.IsNullOrWhiteSpace(x)).ToList(),
                        City = lblCity.Text,
                        StateProvinceCode = lblState.Text,
                        PostalCode = NormalizePostalCode(lblZip.Text),
                        CountryCode = NormalizeCountryCode(lblCountry.Text)
                    }
                },

                // REQUIRED for NEGOTIATED RATES
                ShipmentRatingOptions = new
                {
                    NegotiatedRatesIndicator = "Y"
                },

                PaymentInformation = new
                {
                    ShipmentCharge = new[]
                    {
                new
                {
                    Type = "01",
                    BillShipper = new
                    {
                        AccountNumber = upsAccount
                    }
                }
            }
                },

                // Only for single service rate request
                Service = singleService ? new { Code = cmbService.SelectedValue.ToString() } : null,

                NumOfPieces = dgvPackage.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow).ToString(),

                Package = dgvPackage.Rows.Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow)
                    .Select(r => new
                    {
                        PackagingType = new { Code = "02", Description = "Package" },
                        Dimensions = new
                        {
                            UnitOfMeasurement = new { Code = "IN" },
                            Length = r.Cells["Length"].Value?.ToString() ?? "0",
                            Width = r.Cells["Width"].Value?.ToString() ?? "0",
                            Height = r.Cells["Height"].Value?.ToString() ?? "0"
                        },
                        PackageWeight = new
                        {
                            UnitOfMeasurement = new { Code = "LBS" },
                            Weight = r.Cells["Weight"].Value?.ToString() ?? "0"
                        }
                    }).ToList()
            };

            var rateRequest = new
            {
                RateRequest = new
                {
                    Request = new
                    {
                        TransactionReference = new { CustomerContext = "Rate" }
                    },
                    Shipment = shipment
                }
            };

            return Newtonsoft.Json.JsonConvert.SerializeObject(
                rateRequest,
                Newtonsoft.Json.Formatting.None,
                new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore }
            );
        }

        private Boolean CheckPackageValidtion()
        {
            Boolean isvalid = false;

            if (txtWeight.Text.Trim() == "")
            {
                isvalid = false;
                txtWeight.Focus();
                MessageBox.Show("Please Enter Weight Value");
            }
            //else if (txtLength.Text.Trim() == "")
            //{
            //    isvalid = false;
            //    txtLength.Focus();
            //    MessageBox.Show("Please Enter Length Value");
            //}
            //else if (txtWidth.Text.Trim() == "")
            //{
            //    isvalid = false;
            //    txtWidth.Focus();
            //    MessageBox.Show("Please Enter Width Value");
            //}
            //else if (txtHeight.Text.Trim() == "")
            //{
            //    isvalid = false;
            //    txtHeight.Focus();
            //    MessageBox.Show("Please Enter Height Value");
            //}
            else
                isvalid = true;
            return isvalid;
        }
        private void btnAddPackage_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckPackageValidtion())
                {
                    dgvPackage.Rows.Add("Delete", txtWeight.Text.ToString(), txtLength.Text.ToString(), txtWidth.Text.ToString(), txtHeight.Text.ToString());
                    MessageBox.Show("Package Info Addedd in List");
                    txtWeight.Text = "";
                    txtLength.Text = "0";
                    txtWidth.Text = "0";
                    txtHeight.Text = "0";
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: btnAddPackage_Click, Message:" + ex.Message);
                MessageBox.Show("General Exception = " + ex.Message, "E");
            }

        }
        private void dgvPackage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPackage.Columns[e.ColumnIndex].Name == "Delete")
                {
                    dgvPackage.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: dgvPackage_CellContentClick, Message:" + ex.Message);
                MessageBox.Show("General Exception = " + ex.Message, "E");
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }
        private void FrmUPSShippingManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (ID != "")
                {
                    ClsCommon.ObjUnShippedInvList.GetInvoiceByID(ID);
                }
                ClsCommon.objUPS.Hide();
                ClsCommon.objUPS.Parent = null;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: FrmUPSShippingManager_FormClosing, Message:" + ex.Message);
                MessageBox.Show("General Exception = " + ex.Message, "E");
            }

        }
        // Cost Calculation
        private void btnRate_Click(object sender, EventArgs e)
        {
            dtUPS = new BALUPSSettings().SelectByType("UPS");
            dtFedEx = new BALUPSSettings().SelectByType("FedX");
            try
            {
                if (rdbUPS.Checked == true)
                {
                    // UPS Process
                    try
                    {
                        if (CheckValidation())
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            dtAccessUPS = new BALAccessUPSSettings().Select(Convert.ToInt32(ClsCommon.UserID));
                            if (dtUPS.Rows.Count > 0)
                            {
                                string Rate = "";
                                StreamReader sr = null;
                                string results = "";
                                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                            Top:
                                try
                                {

                                    string post = GetUPSRateJSON(singleService: true); // see function below
                                    string url = "https://onlinetools.ups.com/api/rating/v1/Rate"; // or v2403 per UPS docs

                                    var req = (HttpWebRequest)WebRequest.Create(url);
                                    req.Method = "POST";
                                    req.ContentType = "application/json";
                                    req.Headers.Add("Authorization", "Bearer " + dtUPS.Rows[0]["AccessToken"]);
                                    req.Headers.Add("transId", txtRefNumber.Text);
                                    req.Headers.Add("transactionSrc", "Qbis");

                                    byte[] body = Encoding.UTF8.GetBytes(post);
                                    req.ContentLength = body.Length;
                                    using (var s = req.GetRequestStream()) s.Write(body, 0, body.Length);

                                    var resp = (HttpWebResponse)req.GetResponse();
                                    sr = new StreamReader(resp.GetResponseStream());
                                    results = sr.ReadToEnd();

                                }
                                catch (WebException ex)
                                {
                                    if (ex.Response is HttpWebResponse errorResponse && errorResponse.StatusCode == HttpStatusCode.Unauthorized)
                                    {
                                        UPSGenerateToken();
                                        goto Top;
                                    }
                                    else
                                    {
                                        using (var respStream = ex.Response?.GetResponseStream())
                                        using (var reader = new StreamReader(respStream ?? Stream.Null))
                                        {
                                            string errorDetails = reader.ReadToEnd();
                                            Rate = "Error " + reader.ReadToEnd();
                                            //MessageBox.Show(errorDetails);
                                            ClsCommon.WriteErrorLogs("UPS Error Details: " + errorDetails);
                                            try
                                            {
                                                var json = JObject.Parse(errorDetails);
                                                string message = json["response"]?["errors"]?[0]?["message"]?.ToString();
                                                MessageBox.Show(message ?? "Unknown error");
                                                //MessageBox.Show("UPS Request Failed: " + errorDetails);
                                            }
                                            catch (Exception ex1)
                                            {
                                                MessageBox.Show("UPS Error Details: " + errorDetails);
                                            }
                                        }
                                    }
                                }
                                if (Rate.Contains("Error") == false)
                                    Rate = clsOnline.ExtractResponse_POST_JSON(results, "UPSRATES");

                                if (Rate.Contains("Error") || Rate.Contains("0"))
                                {
                                    //skip
                                }
                                else
                                {
                                    clsOnline.ExtractRateResponse_POST(results);
                                    if (clsOnline.dtRates.Rows.Count > 0)
                                    {
                                        lblTotalCost.Visible = true;
                                        txtTotalCost.Visible = true;
                                        lblCost.Visible = true;
                                        if (clsOnline.dtRates.Rows[0]["NegotiatedRates"].ToString() == "" || clsOnline.dtRates.Rows[0]["NegotiatedRates"].ToString()=="0.00")
                                        {
                                            txtTotalCost.Text = clsOnline.dtRates.Rows[0]["TotalCharges"].ToString();
                                        }
                                        else
                                        {
                                            txtTotalCost.Text = clsOnline.dtRates.Rows[0]["NegotiatedRates"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        lblCost.Visible = false;
                                    }
                                }
                            }
                            else
                            {
                                Cursor.Current = Cursors.Default;
                                MessageBox.Show("Error: UPS settings are blank");
                            }
                            Cursor.Current = Cursors.Default;
                        }
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
                else if (rdbFedEx.Checked == true)
                {

                    if (dtFedEx.Rows.Count > 0)
                    {
                        // Fedx Process
                        try
                        {
                            if (CheckValidation())
                            {
                            Top:
                                var client = new HttpClient();
                                var url = "https://apis.fedex.com/rate/v1/rates/quotes";

                                // Json content string
                                var JsonFedx = GetFedXRateJson();

                                // Prepare the request headers and content
                                var request = new HttpRequestMessage(HttpMethod.Post, url);
                                request.Headers.Add("Authorization", "Bearer " + dtFedEx.Rows[0]["AccessToken"].ToString() + "");
                                request.Content = new StringContent(JsonFedx, Encoding.UTF8, "application/json");

                                // Send the request asynchronously
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
                                        responseBody = responseBodyTask.Result; // Get the result of the task synchronously
                                        clsOnline.ExtractFedxRateResponse(responseBody);

                                        if (clsOnline.dtFedx.Rows.Count > 0)
                                        {
                                            lblTotalCost.Visible = true;
                                            txtTotalCost.Visible = true;
                                            lblCost.Visible = true;

                                            txtTotalCost.Text = clsOnline.dtFedx.Rows[0]["TotalCharges"].ToString();

                                        }
                                        else
                                        {
                                            lblCost.Visible = false;
                                        }
                                    }
                                    Cursor.Current = Cursors.Default;
                                }
                                catch (Exception ex)
                                {
                                    if (ex.Message.Contains(" 401 (Unauthorized)") == true)
                                    {
                                        FedXGenerateToken();
                                        goto Top;
                                    }
                                    else
                                    {
                                        MessageBox.Show(ex.Message);

                                    }
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            Cursor.Current = Cursors.Default;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not Found Token");
                    }
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("General Exception = " + ex.Message, "E");
                using (WebResponse response = ex.Response)
                {
                    var httpResponse = (HttpWebResponse)response;

                    using (Stream data = response.GetResponseStream())
                    {
                        StreamReader sr2 = new StreamReader(data);
                        string Results = "Error:" + sr2.ReadToEnd();
                        //clsCommonHelper.WriteErrorLog("ShippingMethod:" + apiResponse, "I");  
                    }
                }
            }
            finally
            {
            }
        }
        public string GetAvaialbleUSPSRateXML(string Services)
        {
            string XML = "";
            try
            {
                //XML += "<?xml version=\"1.0\"?>";
                XML += "<RatingServiceSelectionRequest xml:lang=\"en-US\">";
                XML += "<Request>";
                XML += "<RequestAction>Rate</RequestAction>";
                XML += "<RequestOption>Rate</RequestOption>";
                XML += "</Request>";
                XML += "<Shipment>";
                XML += "<Shipper>";
                XML += "<Name>" + lblName.Text.ToString() + "</Name>";
                XML += "<AttentionName>" + lblCompanyName.Text.ToString() + "</AttentionName>";
                XML += "<PhoneNumber>" + lblPhone.Text.ToString() + "</PhoneNumber>";
                XML += "<ShipperNumber>4E9A02</ShipperNumber>";
                String[] addressLine = { lblAddress1.Text.ToString(), lblAddress2.Text == null ? "" : lblAddress2.Text.ToString() };
                XML += "<Address>";
                XML += "<AddressLine1>" + addressLine[0].ToString() + "</AddressLine1>";
                if (addressLine.Length > 1)
                {
                    XML += "<AddressLine2>" + addressLine[1].ToString() + "</AddressLine2>";
                }
                XML += "<City>" + lblCity.Text.ToString() + "</City> ";
                XML += "<StateProvinceCode>" + lblState.Text.ToString() + "</StateProvinceCode>";
                XML += "<PostalCode>" + NormalizePostalCode(lblZip.Text) + "</PostalCode>";
                XML += "<CountryCode>" + NormalizeCountryCode(lblCountry.Text) + "</CountryCode>";
                XML += "</Address>";
                XML += "</Shipper>";

                XML += "<ShipTo>";
                XML += "<CompanyName>" + txtToCompany.Text.ToString() + "</CompanyName>";
                XML += "<PhoneNumber>" + txtToPhone.Text.ToString() + "</PhoneNumber>";
                XML += "<AttentionName>" + txtToName.Text.ToString() + "</AttentionName>";
                String[] addressLine1 = { txtToAddress1.Text.ToString(), txtToAddress2.Text == null ? "" : txtToAddress2.Text.ToString() };
                XML += "<Address> <AddressLine1>" + addressLine1[0].ToString() + "</AddressLine1>";
                if (addressLine1.Length > 1)
                {
                    XML += "<AddressLine2>" + addressLine1[1].ToString() + "</AddressLine2>";
                }
                XML += "<City>" + txtToCity.Text.ToString() + "</City>";
                XML += "<StateProvinceCode>" + txtToState.Text.ToString().ToUpper().Replace("texas", "TX").Replace("Texas", "TX").Replace("Oklahoma", "OK") + "</StateProvinceCode>";
                XML += "<PostalCode>" + NormalizePostalCode(txtToZip.Text) + "</PostalCode>";
                XML += "<CountryCode>" + NormalizeCountryCode(txtToCountry.Text) + "</CountryCode>";
                XML += "</Address> ";
                XML += "</ShipTo> ";

                XML += "<Service> <Code>" + Services + "</Code> </Service>";


                if (chkSaturdayDelivery.Checked == true)
                {
                    XML += " <ShipmentServiceOptions>";
                    XML += " <SaturdayDelivery/>";
                    XML += " </ShipmentServiceOptions>";
                }
                if (chkDirectDeliveryOnly.Checked == true)
                {
                    XML += " <ShipmentServiceOptions>";
                    XML += "  <DirectDeliveryOnlyIndicator>yes</DirectDeliveryOnlyIndicator> ";
                    XML += " </ShipmentServiceOptions>";
                }
                if (chkSaturdayPickup.Checked == true)
                {
                    XML += " <ShipmentServiceOptions>";
                    XML += "  <SaturdayPickupIndicator>yes</SaturdayPickupIndicator> ";
                    XML += " </ShipmentServiceOptions>";
                }


                if (dgvPackage.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvPackage.Rows.Count; i++)
                    {
                        XML += "<Package>";
                        XML += "<PackageServiceOptions>";
                        if (chkCOD.Checked == true)
                        {
                            XML += "<COD>";
                            XML += "<CODCode>3</CODCode>";
                            XML += "<CODFundsCode>" + cmbCOD.SelectedValue + "</CODFundsCode>";
                            XML += "<CODAmount>";
                            XML += "<CurrencyCode>USD</CurrencyCode>";
                            XML += "<MonetaryValue>" + Convert.ToDecimal(txtCODAmount.Text) + "</MonetaryValue>";
                            XML += "</CODAmount>";
                            XML += "</COD>";
                        }
                        XML += "</PackageServiceOptions>";
                        XML += "<PackagingType>";
                        XML += "<Code>02</Code>";
                        XML += "<Description>UPS Package</Description>";
                        XML += "</PackagingType>";
                        XML += "<Dimensions>";
                        XML += "<UnitOfMeasurement>";
                        XML += "<Code>IN</Code>";
                        XML += "</UnitOfMeasurement>";
                        XML += "<Length>" + "1" + "</Length>";
                        XML += "<Width>" + "1" + "</Width>";
                        XML += "<Height>" + "1" + "</Height>";
                        XML += "</Dimensions> ";
                        XML += " <PackageWeight>";
                        XML += " <UnitOfMeasurement>";
                        XML += " <Code>LBS</Code> ";
                        XML += " </UnitOfMeasurement>";
                        if (txtWeight.Text != "")
                        {
                            XML += " <Weight>" + txtWeight.Text + "</Weight> ";
                        }
                        else
                        {
                            XML += " <Weight>" + dgvPackage.Rows[i].Cells[1].Value.ToString() + "</Weight> ";
                        }
                        XML += " </PackageWeight> ";
                        XML += " </Package>";
                    }
                }
                if (dtAccessUPS.Rows.Count > 0)
                {
                    if (dtAccessUPS.Rows[0]["NegotiatedRate"].ToString() == "1")
                    {
                        XML += "<RateInformation> ";
                        XML += "<NegotiatedRatesIndicator/> ";
                        XML += "</RateInformation> ";

                    }
                }
                XML += "</Shipment>";
                XML += "</RatingServiceSelectionRequest>";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: GetUSPSRateXML, Message:" + ex.Message);
                MessageBox.Show("General Exception = " + ex.Message, "E");
            }
            return XML;
        }
        private void Collapse_Click(object sender, EventArgs e)
        {
            Expand.Visible = true;
            Collapse.Hide();
            groupBox1.Show();
            splitContainer1.Panel1Collapsed = false;
        }
        private void Expand_Click_1(object sender, EventArgs e)
        {
            Collapse.Visible = true;
            Expand.Hide();
            groupBox1.Hide();
            splitContainer1.Panel1Collapsed = true;
        }
        private void cmbFrom_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (rdbUPS.Checked == true)
                {
                    if (cmbFrom.SelectedIndex > 0)
                    {
                        DataTable dt = new BALFromShipping().SelectByID(new BOLFromShipping() { ID = Convert.ToInt32(cmbFrom.SelectedValue.ToString()) });
                        if (dt.Rows.Count > 0)
                        {
                            lblUPSID.Text = "TPARTS786";
                            lblCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                            lblName.Text = dt.Rows[0]["Name"].ToString();
                            lblAddress1.Text = dt.Rows[0]["Address1"].ToString();
                            lblAddress2.Text = dt.Rows[0]["Address2"].ToString();
                            lblPhone.Text = dt.Rows[0]["Phone"].ToString();
                            lblCity.Text = dt.Rows[0]["City"].ToString();
                            lblState.Text = dt.Rows[0]["State"].ToString();
                            lblZip.Text = dt.Rows[0]["Zip"].ToString();
                            if (dt.Rows[0]["Country"].ToString() == "")
                            {
                                lblCountry.Text = "CA";
                            }
                            else if (dt.Rows[0]["Country"].ToString() == "USA")
                            {
                                lblCountry.Text = "CA";
                            }
                            else
                            {
                                lblCountry.Text = dt.Rows[0]["Country"].ToString();
                            }

                        }
                    }
                }
                else if (rdbFedEx.Checked == true)
                {
                    if (cmbFrom.SelectedIndex > 0)
                    {
                        DataTable dt = new BALFromShipping().SelectByID(new BOLFromShipping() { ID = Convert.ToInt32(cmbFrom.SelectedValue.ToString()) });
                        if (dt.Rows.Count > 0)
                        {
                            lblUPSID.Text = "TPARTS786";
                            lblCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                            lblName.Text = dt.Rows[0]["Name"].ToString();
                            lblAddress1.Text = dt.Rows[0]["Address1"].ToString();
                            lblAddress2.Text = dt.Rows[0]["Address2"].ToString();
                            lblPhone.Text = dt.Rows[0]["Phone"].ToString();
                            lblCity.Text = dt.Rows[0]["City"].ToString();
                            lblState.Text = dt.Rows[0]["State"].ToString();
                            lblZip.Text = dt.Rows[0]["Zip"].ToString();
                            if (dt.Rows[0]["Country"].ToString() == "")
                            {
                                lblCountry.Text = "CA";
                            }
                            else if (dt.Rows[0]["Country"].ToString() == "USA")
                            {
                                lblCountry.Text = "CA";
                            }
                            else
                            {
                                lblCountry.Text = dt.Rows[0]["Country"].ToString();
                            }

                        }
                    }

                }


            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: cmbFrom_SelectedIndexChanged, Message:" + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void chkCOD_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCOD.Checked == true)
            {
                lblamount.Enabled = true;
                lbldoller.Enabled = true;
                txtCODAmount.Enabled = true;
                cmbCOD.Enabled = true;
                lblFunds.Enabled = true;
                cmbCOD.SelectedValue = "8";
            }
            else
            {
                txtCODAmount.Clear();
                //cmbCOD.SelectedIndex = 0;
                lblamount.Enabled = false;
                lbldoller.Enabled = false;
                txtCODAmount.Enabled = false;
                cmbCOD.Enabled = false;
                lblFunds.Enabled = false;
                cmbCOD.SelectedValue = "8";
            }
        }
        private void txtCODAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
                {
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFedExUPSShippingManager,Function :txtRate_KeyPress. Message:" + ex.Message);
            }
        }
        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
                {
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFedExUPSShippingManager,Function :txtWeight_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void txtDeclaredValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
                {
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFedExUPSShippingManager,Function :txtDeclaredValue_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void btnAvailableServices_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbUPS.Checked)
                {
                    GetTransitTime();
                }
                else
                {
                    type = "FedExTIME";
                    GetFedExTransitTime();
                }
                if (clsOnline.dtTime.Rows.Count > 0)
                {
                    FrmAvailableService frmAvailableService = new FrmAvailableService();
                    frmAvailableService.ShowDialog();
                }
                type = "";

                //GetTransitTime();
                //if (clsOnline.dtTime.Rows.Count > 0)
                //{
                //    FrmAvailableService frmAvailableService = new FrmAvailableService();
                //    frmAvailableService.ShowDialog();
                //}
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFedExUPSShippingManager,Function :btnAvailableServices_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);

            }
        }
        public void TimeTrackCode()
        {
            try
            {
                if (dtUPS.Rows.Count == 0)
                {
                    MessageBox.Show("Error: UPS settings are blank");
                    return;
                }

                int RETRY = 0;

            Top:
                RETRY++;
                HttpWebRequest request = null;
                HttpWebResponse response = null;

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                string postJson = GetUPSTimeInTransitJSON();
                request = (HttpWebRequest)WebRequest.Create("https://onlinetools.ups.com/rest/TimeInTransit");
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Headers["Authorization"] = "Bearer " + dtUPS.Rows[0]["AccessToken"].ToString();

                byte[] byteArray = Encoding.UTF8.GetBytes(postJson);
                request.ContentLength = byteArray.Length;

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    if (ex.Response is HttpWebResponse errorResponse)
                    {
                        if (errorResponse.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            UPSGenerateToken(); // refresh token
                            goto Top;
                        }
                        else if ((int)errorResponse.StatusCode == 429 && RETRY <= 2) // rate limit
                        {
                            Thread.Sleep(2000);
                            goto Top;
                        }
                        else
                        {
                            using (StreamReader reader = new StreamReader(errorResponse.GetResponseStream()))
                            {
                                string errorText = reader.ReadToEnd();
                                MessageBox.Show(errorText);
                            }
                            return;
                        }
                    }
                }

                if (response != null)
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string results = reader.ReadToEnd();

                        if (results.Contains("Invalid bearer Token"))
                        {
                            UPSGenerateToken(); // refresh token
                            goto Top;

                        }
                        // Process JSON response here
                        ExtractTimeInTransit(results);
                    }
                }
                else
                {
                    MessageBox.Show("No response from UPS");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void ExtractTimeInTransit(string Results)
        {
            try
            {
                clsOnline.dtTime = new DataTable();
                clsOnline.InitilizeTablesColumns("TIME");

                XmlDocument oDoc = new XmlDocument();
                oDoc.LoadXml(Results);

                XmlNodeList oList = oDoc.GetElementsByTagName("TransitResponse");
                XmlNode oList1 = oList[0];
                if (oList.Count > 0)
                {

                    XmlNodeList oListUSPS = oDoc.GetElementsByTagName("ServiceSummary");
                    foreach (XmlNode oNode in oListUSPS)
                    {
                        DataRow drTime = clsOnline.dtTime.NewRow();
                        //if (oList1["ShipmentWeight"]["Weight"] != null)
                        //    drTime["Weight"] = oList1["ShipmentWeight"]["Weight"].InnerXml;
                        //if (oList1["ShipmentWeight"]["UnitOfMeasurement"]["Code"] != null)
                        //    drTime["Code"] = oList1["ShipmentWeight"]["UnitOfMeasurement"]["Code"].InnerXml;
                        if (oNode["Service"]["Description"] != null)
                        {
                            if (oNode["EstimatedArrival"]["Date"] != null)
                                drTime["Date"] = oNode["EstimatedArrival"]["Date"].InnerXml;

                            if (oNode["Service"]["Description"] != null)
                                drTime["Service"] = oNode["Service"]["Description"].InnerXml;

                            if (oNode["Guaranteed"]["Code"] != null)
                                drTime["Guaranteed"] = (oNode["Guaranteed"]["Code"].InnerXml == "Y") ? "YES" : "NO";

                            if (oNode["EstimatedArrival"]["BusinessTransitDays"] != null)
                                drTime["BusDays"] = oNode["EstimatedArrival"]["BusinessTransitDays"].InnerXml;
                            CultureInfo culture = new CultureInfo("en-US");
                            string fullDayName = Array.Find(culture.DateTimeFormat.DayNames, day => day.StartsWith(oNode["EstimatedArrival"]["DayOfWeek"].InnerXml, StringComparison.InvariantCultureIgnoreCase));

                            DateTime date;
                            string formattedDate = "";
                            if (DateTime.TryParse(oNode["EstimatedArrival"]["Date"].InnerXml, out date))
                            {
                                formattedDate = date.ToString("MMMM dd");
                            }
                            string fullDate = fullDayName + ", " + formattedDate + ", " + oNode["EstimatedArrival"]["Time"].InnerXml;
                            if (oNode["EstimatedArrival"]["DayOfWeek"] != null)
                                drTime["EstimatedDelivery"] = fullDate;


                            if (oNode["EstimatedArrival"]["DayOfWeek"] != null)
                                drTime["DayOfWeek"] = oNode["EstimatedArrival"]["DayOfWeek"].InnerXml;

                            //if (oNode["EstimatedArrival"]["CustomerCenterCutoff"] != null)
                            //    drTime["CustomerCenterCutoff"] = oNode["EstimatedArrival"]["CustomerCenterCutoff"].InnerXml;


                            HttpWebRequest WebRequestObject = null;
                            HttpWebResponse WebResponseObject = null;
                            StreamReader sr = null;

                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                            string service = "";
                            if (oNode["Service"]["Description"].InnerXml == "UPS Next Day Air Early")
                            {
                                service = "14";
                            }
                            else if (oNode["Service"]["Description"].InnerXml == "UPS Next Day Air")
                            {
                                service = "01";
                            }
                            else if (oNode["Service"]["Description"].InnerXml == "UPS Ground")
                            {
                                service = "03";
                            }
                            else if (oNode["Service"]["Description"].InnerXml == "UPS Next Day Air Saver")
                            {
                                service = "13";
                            }
                            else if (oNode["Service"]["Description"].InnerXml == "UPS 2nd Day Air Early")
                            {
                                service = "59";
                            }
                            else if (oNode["Service"]["Description"].InnerXml == "UPS 2nd Day Air")
                            {
                                service = "02";
                            }
                            else if (oNode["Service"]["Description"].InnerXml == "UPS 3 Day Select")
                            {
                                service = "12";
                            }
                        Top:
                            try
                            {
                                string post = GetAvaialbleUSPSRateXML(service);
                                WebRequestObject = (HttpWebRequest)WebRequest.Create("https://onlinetools.ups.com/ups.app/xml/Rate");
                                //WebRequestObject = (HttpWebRequest)WebRequest.Create("https://onlinetools.ups.com/ups.app/xml/Rate");

                                WebRequestObject.Method = "POST";
                                byte[] byteArray = Encoding.UTF8.GetBytes(post);
                                WebRequestObject.ContentType = "application/x-www-form-urlencoded";

                                WebRequestObject.ContentLength = byteArray.Length;

                                Stream dataStream = WebRequestObject.GetRequestStream();

                                dataStream.Write(byteArray, 0, byteArray.Length);
                                dataStream.Close();

                                WebRequestObject.AllowAutoRedirect = false;

                                WebResponseObject = (HttpWebResponse)WebRequestObject.GetResponse();
                                sr = new StreamReader(WebResponseObject.GetResponseStream());
                                string Results1 = sr.ReadToEnd();

                                string Rate = clsOnline.ExtractResponse_POST(Results1, "UPSRATES");
                                string EstimateRate = "";
                                if (Rate.Contains("Success"))
                                {
                                    EstimateRate = GetRate(Results1);
                                }
                                drTime["RateEstimate"] = "$" + EstimateRate;
                            }
                            catch (WebException ex)
                            {
                                if (ex.Response is HttpWebResponse errorResponse && errorResponse.StatusCode == HttpStatusCode.Unauthorized)
                                {
                                    UPSGenerateToken();   // 🔹 Refresh token function
                                    goto Top;             // 🔹 Retry request
                                }
                                else
                                {
                                    MessageBox.Show("UPS Rate Request Failed: " + ex.Message);
                                    using (var respStream = ex.Response?.GetResponseStream())
                                    using (var reader = new StreamReader(respStream ?? Stream.Null))
                                    {
                                        string errorDetails = reader.ReadToEnd();
                                        ClsCommon.WriteErrorLogs("UPS Rate Error Details: " + errorDetails);
                                    }
                                }
                            }
                        }
                        clsOnline.dtTime.Rows.Add(drTime);
                    }

                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("POST Response Time Extract" + ". Message:" + ex.Message);
            }
        }
        public static string GetRate(string response)
        {
            string Rate = "";

            XmlDocument oDoc = new XmlDocument();
            oDoc.LoadXml(response);

            XmlNodeList oListUSPS = oDoc.GetElementsByTagName("RatingServiceSelectionResponse");
            foreach (XmlNode oNode in oListUSPS)
            {
                if (oNode["RatedShipment"] != null)
                {
                    if (oNode["RatedShipment"]["BillingWeight"] != null)
                    {

                        if (oNode["RatedShipment"]["NegotiatedRates"] != null)
                        {
                            if (oNode["RatedShipment"]["NegotiatedRates"]["NetSummaryCharges"]["GrandTotal"]["MonetaryValue"] != null)
                                Rate = oNode["RatedShipment"]["NegotiatedRates"]["NetSummaryCharges"]["GrandTotal"]["MonetaryValue"].InnerXml;
                        }
                    }
                }
            }

            return Rate;
        }
        private string GetUPSTimeInTransitJSON()
        {
            string json = "";
            try
            {
                var timeInTransitRequest = new
                {
                    TimeInTransitRequest = new
                    {
                        Request = new
                        {
                            RequestOption = "TNT", // Time in Transit
                            TransactionReference = new
                            {
                                CustomerContext = "Time in Transit",
                                XpciVersion = "1.001"
                            }
                        },
                        TransitFrom = new
                        {
                            AddressArtifactFormat = new
                            {
                                PoliticalDivision2 = string.IsNullOrEmpty(lblAddress2.Text) ? "" : lblAddress2.Text,
                                PoliticalDivision1 = lblAddress1.Text,
                                PostcodePrimaryLow = NormalizePostalCode(lblZip.Text),
                                CountryCode = NormalizeCountryCode(lblCountry.Text)
                            }
                        },
                        TransitTo = new
                        {
                            AddressArtifactFormat = new
                            {
                                PoliticalDivision2 = string.IsNullOrEmpty(txtToAddress2.Text) ? "" : txtToAddress2.Text,
                                PoliticalDivision1 = txtToAddress1.Text,
                                PostcodePrimaryLow = NormalizePostalCode(txtToZip.Text),
                                CountryCode = NormalizeCountryCode(txtToCountry.Text)
                            }
                        },
                        PickupDate = DateTime.Now.ToString("yyyyMMdd"),
                        MaximumListSize = "35",
                        InvoiceLineTotal = new
                        {
                            CurrencyCode = "USD",
                            MonetaryValue = Total
                        },
                        ShipmentWeight = dgvPackage.Rows.Cast<DataGridViewRow>()
                            .Where(r => !r.IsNewRow)
                            .Select(r => new
                            {
                                UnitOfMeasurement = new { Code = "LBS", Description = "Pounds" },
                                Weight = r.Cells[1].Value.ToString()
                            }).ToList()
                    }
                };

                json = Newtonsoft.Json.JsonConvert.SerializeObject(timeInTransitRequest,
                    Newtonsoft.Json.Formatting.None,
                    new Newtonsoft.Json.JsonSerializerSettings
                    {
                        NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
                    });
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: GetUPSTimeInTransitJSON, Message:" + ex.Message);
                MessageBox.Show("General Exception = " + ex.Message, "E");
            }

            return json;
        }

        private string BuildRateEstimateRequest()
        {
            // Ship From (Origin)
            string originCountryCode = NormalizeCountryCode(lblCountry.Text);
            string originStateProvince = string.IsNullOrWhiteSpace(lblState.Text) ? "ON" : lblState.Text;
            string originCityName = string.IsNullOrWhiteSpace(lblCity.Text) ? "TORONTO" : lblCity.Text;
            string originPostalCode = string.IsNullOrWhiteSpace(lblZip.Text) ? "K1A0B1" : NormalizePostalCode(lblZip.Text);

            // Ship To (Destination)
            string destinationCountryCode = NormalizeCountryCode(txtToCountry.Text);
            string destinationStateProvince = string.IsNullOrWhiteSpace(txtToState.Text) ? "ON" : txtToState.Text.ToUpper();
            string destinationCityName = string.IsNullOrWhiteSpace(txtToCity.Text) ? "TORONTO" : txtToCity.Text;
            string destinationPostalCode = string.IsNullOrWhiteSpace(txtToZip.Text) ? "K1A0B1" : NormalizePostalCode(txtToZip.Text);

            // Shipment details
            decimal shipmentWeight = dgvPackage.Rows.Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .Sum(r => decimal.TryParse(r.Cells["Weight"].Value?.ToString(), out var w) ? w : 1); // default 1 LBS

            int totalPackages = Math.Max(1, dgvPackage.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow));

            var rateRequest = new
            {
                RateRequest = new
                {
                    Request = new
                    {
                        TransactionReference = new { CustomerContext = "Get Rate Estimates" }
                    },
                    Shipment = new
                    {
                        //Shipper = new
                        //{
                        //    Address = new
                        //    {
                        //        City = originCityName,
                        //        StateProvinceCode = originStateProvince,
                        //        PostalCode = originPostalCode,
                        //        CountryCode = originCountryCode
                        //    }
                        //},
                        Shipper = new
                        {
                            ShipperNumber = "4E9A02",
                            Address = new
                            {
                                City = originCityName,
                                StateProvinceCode = originStateProvince,
                                PostalCode = originPostalCode,
                                CountryCode = originCountryCode
                            }
                        },
                        ShipTo = new
                        {
                            Address = new
                            {
                                City = destinationCityName,
                                StateProvinceCode = destinationStateProvince,
                                PostalCode = destinationPostalCode,
                                CountryCode = destinationCountryCode,
                                ResidentialAddressIndicator = "" // optional
                            }
                        },
                        ShipFrom = new
                        {
                            Address = new
                            {
                                City = originCityName,
                                StateProvinceCode = originStateProvince,
                                PostalCode = originPostalCode,
                                CountryCode = originCountryCode
                            }
                        },
                        Package = new[]
                        {
                    new {
                        PackagingType = new { Code = "02", Description = "Customer Supplied" },
                        PackageWeight = new {
                            UnitOfMeasurement = new { Code = "LBS" },
                            Weight = shipmentWeight.ToString()
                        }
                    }
                },
                        PaymentInformation = new
                        {
                            ShipmentCharge = new[]
                            {
                        new {
                            Type = "01",
                            BillShipper = new {
                                AccountNumber = "4E9A02"
                            }
                        }
                    }
                        },
                        Service = new { Code = "03", Description = "UPS Ground" }, // leave blank for all services
                        ShipmentRatingOptions = new { NegotiatedRatesIndicator = "Y" }
                    }
                }
            };
            return JsonConvert.SerializeObject(rateRequest, Formatting.None,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        public void GetTransitRate()
        {

            int retry = 0;
            string json = "";
        Retry:
            try
            {
                json = BuildRateEstimateRequest();
                var req = (HttpWebRequest)WebRequest.Create("https://onlinetools.ups.com/api/rating/v2403/Shop");
                //var req = (HttpWebRequest)WebRequest.Create("https://onlinetools.ups.com/api/shipments/v1/transittimes");
                req.Method = "POST";
                req.ContentType = "application/json"; // EXACTLY this, no charset
                req.Headers.Add("Authorization", "Bearer " + dtUPS.Rows[0]["AccessToken"].ToString());
                //req.Headers.Add("transId", string.IsNullOrEmpty(txtRefNumber.Text) ? Guid.NewGuid().ToString() : txtRefNumber.Text);
                req.Headers.Add("transactionSrc", "Qbis");

                byte[] body = Encoding.UTF8.GetBytes(json);
                req.ContentLength = body.Length;

                using (var stream = req.GetRequestStream())
                {
                    stream.Write(body, 0, body.Length);
                }
                using (var resp = (HttpWebResponse)req.GetResponse())
                using (var reader = new StreamReader(resp.GetResponseStream()))
                {
                    string result = reader.ReadToEnd();
                    ExtractRateJSON(result);
                }
            }
            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse resp)
                {
                    if (resp.StatusCode == HttpStatusCode.Unauthorized && retry < 2)
                    {
                        UPSGenerateToken();
                        retry++;
                        goto Retry;
                    }
                    else if ((int)resp.StatusCode == 429 && retry < 2)
                    {
                        System.Threading.Thread.Sleep(2000);
                        retry++;
                        goto Retry;
                    }

                    using (var reader = new StreamReader(resp.GetResponseStream()))
                    {
                        string errorText = reader.ReadToEnd();
                        ClsCommon.WriteErrorLogs("UPS TimeInTransit Error: " + errorText);
                    }
                }

                throw;
            }
        }

        private void ExtractRateJSON(string json)
        {
            clsOnline.InitilizeTablesColumns("RATE");

            var root = JObject.Parse(json);
            var rateResponse = root["RateResponse"];
            if (rateResponse == null) return;

            var shipments = rateResponse["RatedShipment"];
            if (shipments == null) return;

            foreach (var shipment in shipments)
            {
                var dr = clsOnline.dtTime.NewRow();

                // ----------------------------------------------------
                // SERVICE DETAILS
                // ----------------------------------------------------
                var serviceCode = shipment["Service"]?["Code"]?.ToString();
                dr["ServiceCode"] = serviceCode;

                var apiDesc = shipment["Service"]?["Description"]?.ToString();
                if (string.IsNullOrEmpty(apiDesc) && UpsServiceCodes.ContainsKey(serviceCode))
                    dr["ServiceDescription"] = UpsServiceCodes[serviceCode];
                else
                    dr["ServiceDescription"] = apiDesc;

                // ----------------------------------------------------
                // BILLING WEIGHT
                // ----------------------------------------------------
                dr["BillingWeight"] = shipment["BillingWeight"]?["Weight"]?.ToString();
                dr["BillingWeightUOM"] = shipment["BillingWeight"]?["UnitOfMeasurement"]?["Code"]?.ToString();

                // ----------------------------------------------------
                // PUBLISHED (NON-NEGOTIATED) RATES – same as UPS website
                // ----------------------------------------------------
                string publishedTotal = shipment["TotalCharges"]?["MonetaryValue"]?.ToString();
                string publishedTransport = shipment["TransportationCharges"]?["MonetaryValue"]?.ToString();

                dr["TotalCharges"] = publishedTotal;
                dr["TransportationCharges"] = publishedTransport;

                // Keep for backward compatibility
                dr["TransportationCharges"] = publishedTransport;
                dr["TotalCharges"] = publishedTotal;
                dr["Currency"] = shipment["TotalCharges"]?["CurrencyCode"]?.ToString();

                // ----------------------------------------------------
                // NEGOTIATED RATES (Your account discounted rates)
                // ----------------------------------------------------
                var negotiated = shipment["NegotiatedRateCharges"];

                if (negotiated != null)
                {
                    string negoTotal = negotiated["TotalCharge"]?["MonetaryValue"]?.ToString();
                    string negoTransport = negotiated["TransportationCharges"]?["MonetaryValue"]?.ToString();

                    dr["NegotiatedTotalCharges"] = negoTotal;
                    //dr["NegotiatedTransportation"] = negoTransport;

                    // Replace TotalCharges with negotiated for internal use
                    dr["TotalCharges"] = negoTotal;
                }
                else
                {
                    // If no negotiated rate → keep published
                    dr["NegotiatedTotalCharges"] = publishedTotal;
                    //dr["NegotiatedTransportation"] = publishedTransport;
                }

                // ----------------------------------------------------
                // DELIVERY / TRANSIT DETAILS
                // ----------------------------------------------------
                dr["BusinessDaysInTransit"] =
                    shipment["GuaranteedDelivery"]?["BusinessDaysInTransit"]?.ToString();

                dr["DeliveryByTime"] =
                    shipment["GuaranteedDelivery"]?["DeliveryByTime"]?.ToString();

                // ----------------------------------------------------
                // ALERTS
                // ----------------------------------------------------
                var alerts = shipment["RatedShipmentAlert"];
                if (alerts != null)
                {
                    dr["AlertCodes"] = string.Join(";", alerts.Select(a => a["Code"]?.ToString()));
                    dr["AlertDescriptions"] = string.Join(";", alerts.Select(a => a["Description"]?.ToString()));
                }

                // ----------------------------------------------------
                // ITEMIZED CHARGES (Published)
                // ----------------------------------------------------
                var items = shipment["ItemizedCharges"];
                if (items != null)
                {
                    dr["ItemizedCharges"] = string.Join(";",
                        items.Select(i => $"{i["Code"]}:{i["MonetaryValue"]}"));
                }

                // ----------------------------------------------------
                // ITEMIZED CHARGES (Negotiated)
                // ----------------------------------------------------
                var negoItems = negotiated?["ItemizedCharges"];
                //if (negoItems != null)
                //{
                //    dr["NegotiatedItemizedCharges"] = string.Join(";",
                //        negoItems.Select(i => $"{i["Code"]}:{i["MonetaryValue"]}"));
                //}

                clsOnline.dtTime.Rows.Add(dr);
            }
        }

        private void ExtractFedExRateJSON(string json)
        {
            clsOnline.InitilizeTablesColumns("FEDEXRATE");

            var root = JObject.Parse(json);
            var output = root["output"];
            if (output == null) return;

            var rateReplyDetails = output["rateReplyDetails"];
            if (rateReplyDetails == null) return;

            foreach (var rate in rateReplyDetails)
            {
                var dr = clsOnline.dtTime.NewRow();


                dr["ServiceCode"] = rate["serviceType"]?.ToString();
                dr["ServiceDescription"] = rate["serviceName"]?.ToString();


                var rated = rate["ratedShipmentDetails"]
                                ?.FirstOrDefault(r => r["rateType"]?.ToString() == "ACCOUNT");

                if (rated == null) continue;  // skip LIST or unavailable services


                //dr["TransportationCharges"] = rated["totalBaseCharge"]?.ToString();
                //dr["ServiceOptionsCharges"] = rated["shipmentRateDetail"]?["totalSurcharges"]?.ToString();
                //dr["TotalCharges"] = rated["totalNetCharge"]?.ToString();
                decimal serviceOptions = decimal.TryParse(rated["totalBaseCharge"]?.ToString(), out var t) ? t : 0;
                decimal transportation = decimal.TryParse(rated["shipmentRateDetail"]?["totalSurcharges"]?.ToString(), out var s) ? s : 0;

                dr["TransportationCharges"] = transportation;
                dr["ServiceOptionsCharges"] = serviceOptions;
                //dr["TotalCharges"] = (transportation + serviceOptions).ToString("0.00");
                dr["TotalCharges"] = rated["totalNetCharge"]?.ToString();

                dr["Currency"] = rated["shipmentRateDetail"]?["currency"]?.ToString();

                var commit = rate["commit"];
                if (commit != null)
                {
                    dr["BusinessDaysInTransit"] = commit["dateDetail"]?["dayOfWeek"]?.ToString();
                    dr["DeliveryByTime"] = commit["dateDetail"]?["dayFormat"]?.ToString();
                }

                clsOnline.dtTime.Rows.Add(dr);
            }
        }

        private string BuildTransitTimesRequest()
        {
            // Ship From (Origin)
            string originCountryCode = NormalizeCountryCode(lblCountry.Text);
            string originStateProvince = string.IsNullOrWhiteSpace(lblState.Text) ? "ON" : lblState.Text;
            string originCityName = string.IsNullOrWhiteSpace(lblCity.Text) ? "TORONTO" : lblCity.Text;
            string originPostalCode = string.IsNullOrWhiteSpace(lblZip.Text) ? "K1A0B1" : NormalizePostalCode(lblZip.Text);

            // Ship To (Destination)
            string destinationCountryCode = NormalizeCountryCode(txtToCountry.Text);
            string destinationStateProvince = string.IsNullOrWhiteSpace(txtToState.Text) ? "ON" : txtToState.Text.ToUpper();
            string destinationCityName = string.IsNullOrWhiteSpace(txtToCity.Text) ? "TORONTO" : txtToCity.Text;
            string destinationPostalCode = string.IsNullOrWhiteSpace(txtToZip.Text) ? "K1A0B1" : NormalizePostalCode(txtToZip.Text);

            // Shipment details
            decimal shipmentWeight = dgvPackage.Rows.Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .Sum(r => decimal.TryParse(r.Cells["Weight"].Value?.ToString(), out var w) ? w : 1); // default 1 LBS

            int totalPackages = Math.Max(1, dgvPackage.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow));

            // Build request object
            var transitTimesRequest = new
            {
                originCountryCode = originCountryCode,
                originStateProvince = originStateProvince,
                originCityName = originCityName,
                originTownName = "", // you can add a txtOriginTown if needed
                originPostalCode = originPostalCode,

                destinationCountryCode = destinationCountryCode,
                destinationStateProvince = destinationStateProvince,
                destinationCityName = destinationCityName,
                destinationTownName = "", // you can add a txtToTown if needed
                destinationPostalCode = destinationPostalCode,

                weight = shipmentWeight.ToString(),
                weightUnitOfMeasure = "LBS",
                shipmentContentsValue = shipmentWeight.ToString(),
                shipmentContentsCurrencyCode = "USD",
                billType = "03",
                shipDate = DateTime.Now.ToString("yyyy-MM-dd"), // e.g. 2025-09-01
                shipTime = "",
                residentialIndicator = "",
                avvFlag = true,
                numberOfPackages = totalPackages.ToString()
            };

            return JsonConvert.SerializeObject(
                transitTimesRequest,
                Formatting.None,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include }
            );
        }

        public void GetFedExTransitTime()
        {
            int retry = 0;
            string json = "";

            while (true)
            {
                try
                {
                    json = BuildFedExTransitTimesRequest();

                    string url = "https://apis.fedex.com/rate/v1/rates/quotes";
                    Console.WriteLine("URL: " + url);

                    var req = (HttpWebRequest)WebRequest.Create(url);
                    req.Method = "POST";
                    req.ContentType = "application/json";
                    req.Accept = "application/json";

                    string token = dtFedEx.Rows[0]["AccessToken"].ToString();

                    req.Headers.Add("Authorization", "Bearer " + token);
                    Console.WriteLine("Authorization Header Added.");

                    byte[] bodyBytes = Encoding.UTF8.GetBytes(json);
                    req.ContentLength = bodyBytes.Length;

                    using (var stream = req.GetRequestStream())
                    {
                        stream.Write(bodyBytes, 0, bodyBytes.Length);
                    }
                    using (var resp = (HttpWebResponse)req.GetResponse())
                    {
                        using (var reader = new StreamReader(resp.GetResponseStream()))
                        {
                            string result = reader.ReadToEnd();
                            if (type == "FedExTIME")
                            {
                                ExtractFedExTransitTimeJSON(result);
                            }
                            else
                            {
                                ExtractFedExRateJSON(result);
                            }
                        }
                    }
                    break; // success
                }
                catch (WebException ex)
                {
                    if (ex.Response != null)
                    {
                        using (var resp = (HttpWebResponse)ex.Response)
                        {
                            Console.WriteLine("HTTP Status: " + (int)resp.StatusCode + " - " + resp.StatusCode);

                            string errorBody = "";
                            using (var responseStream = resp.GetResponseStream())
                            {
                                Stream decompressedStream = responseStream;

                                // If GZIP or DEFLATE → decompress it
                                if (resp.ContentEncoding?.Contains("gzip") == true)
                                    decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress);
                                else if (resp.ContentEncoding?.Contains("deflate") == true)
                                    decompressedStream = new DeflateStream(responseStream, CompressionMode.Decompress);

                                using (var reader = new StreamReader(decompressedStream))
                                {
                                    errorBody = reader.ReadToEnd();
                                }
                            }

                            // Retry on 401 (Unauthorized)
                            if (resp.StatusCode == HttpStatusCode.Unauthorized && retry < 2)
                            {
                                FedXGenerateToken();
                                retry++;
                                continue;
                            }

                            // Retry on 429 (Too Many Requests)
                            if ((int)resp.StatusCode == 429 && retry < 2)
                            {
                                Thread.Sleep(2000);
                                retry++;
                                continue;
                            }

                            // Parse validation style errors for 400 / 422
                            if (resp.StatusCode == HttpStatusCode.BadRequest || (int)resp.StatusCode == 422)
                            {
                                try
                                {
                                    dynamic err = JsonConvert.DeserializeObject(errorBody);
                                    if (err?.errors != null)
                                    {
                                        foreach (var e in err.errors)
                                        {
                                            Console.WriteLine($"Error Code: {e.code} | Message: {e.message} | Parameter: {e.parameter}");
                                        }
                                    }
                                    // Sometimes FedEx uses 'error' root instead of 'errors'
                                    if (err?.error != null)
                                    {
                                        Console.WriteLine($"Error: {err.error}");
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("RAW 422 ERROR BODY:\n" + errorBody);
                                    // ignore parse failures
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No response received from server.");
                    }

                    throw; // rethrow after handling
                }
            }
        }

        private string BuildFedExTransitTimesRequest()
        {
            string originCountryCode = NormalizeCountryCode(lblCountry.Text);
            string originStateProvince = string.IsNullOrWhiteSpace(lblState.Text) ? "ON" : lblState.Text;
            string originCityName = string.IsNullOrWhiteSpace(lblCity.Text) ? "TORONTO" : lblCity.Text;
            string originPostalCode = string.IsNullOrWhiteSpace(lblZip.Text) ? "K1A0B1" : NormalizePostalCode(lblZip.Text);
            string originStreetLine = string.IsNullOrWhiteSpace(lblAddress1.Text) ? "77477" : lblAddress1.Text;


            // Ship To (Destination)
            string destinationCountryCode = NormalizeCountryCode(txtToCountry.Text);
            string destinationStateProvince = string.IsNullOrWhiteSpace(txtToState.Text) ? "ON" : txtToState.Text.ToUpper();
            string destinationCityName = string.IsNullOrWhiteSpace(txtToCity.Text) ? "TORONTO" : txtToCity.Text;
            string destinationPostalCode = string.IsNullOrWhiteSpace(txtToZip.Text) ? "K1A0B1" : NormalizePostalCode(txtToZip.Text);
            string destinationStreetLine = string.IsNullOrWhiteSpace(txtToAddress1.Text) ? "85031" : txtToAddress1.Text;


            var req = new
            {
                accountNumber = new { value = dtFedEx.Rows[0]["AccountNo"].ToString() },

                rateRequestControlParameters = new
                {
                    returnTransitTimes = true
                },

                carrierCodes = new[] { "FDXG", "FDXE" },

                requestedShipment = new
                {
                    shipDateStamp = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),

                    pickupType = "DROPOFF_AT_FEDEX_LOCATION",

                    packagingType = "YOUR_PACKAGING",

                    rateRequestType = new[] { "ACCOUNT", "LIST" },

                    shipper = new
                    {
                        address = new
                        {
                            streetLines = new[] { originStreetLine },
                            city = originCityName,
                            stateOrProvinceCode = originStateProvince,
                            postalCode = originPostalCode,
                            countryCode = originCountryCode
                        }
                    },

                    recipient = new
                    {
                        address = new
                        {
                            streetLines = new[] { destinationStreetLine },
                            city = destinationCityName,
                            stateOrProvinceCode = destinationStateProvince,
                            postalCode = destinationPostalCode,
                            countryCode = destinationCountryCode,
                            residential = false
                        }
                    },

                    shippingChargesPayment = new
                    {
                        paymentType = "SENDER",
                        payor = new
                        {
                            responsibleParty = new
                            {
                                accountNumber = new { value = dtFedEx.Rows[0]["AccountNo"].ToString() }
                            }
                        }
                    },

                    totalPackageCount = 1,

                    requestedPackageLineItems = new[]
                    {
          new {
              groupPackageCount = 1,
              weight = new { units = "LB", value = 5 },
              dimensions = new { length = 10, width = 8, height = 6, units = "IN" }
          }
      }
                }
            };

            return JsonConvert.SerializeObject(req, Formatting.None);
        }
        public void GetTransitTime()
        {

            int retry = 0;
            string json = "";
        Retry:
            try
            {
                json = BuildTransitTimesRequest();
                //var req = (HttpWebRequest)WebRequest.Create("https://onlinetools.ups.com/api/rating/v2403/Shop");
                var req = (HttpWebRequest)WebRequest.Create("https://onlinetools.ups.com/api/shipments/v1/transittimes");
                req.Method = "POST";
                req.ContentType = "application/json"; // EXACTLY this, no charset
                req.Headers.Add("Authorization", "Bearer " + dtUPS.Rows[0]["AccessToken"].ToString());
                //req.Headers.Add("transId", string.IsNullOrEmpty(txtRefNumber.Text) ? Guid.NewGuid().ToString() : txtRefNumber.Text);
                req.Headers.Add("transactionSrc", "Qbis");

                byte[] body = Encoding.UTF8.GetBytes(json);
                req.ContentLength = body.Length;

                using (var stream = req.GetRequestStream())
                {
                    stream.Write(body, 0, body.Length);
                }
                using (var resp = (HttpWebResponse)req.GetResponse())
                using (var reader = new StreamReader(resp.GetResponseStream()))
                {
                    string result = reader.ReadToEnd();
                    ExtractEMSTimeInTransitJSON(result);
                }
            }
            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse resp)
                {
                    if (resp.StatusCode == HttpStatusCode.Unauthorized && retry < 2)
                    {
                        UPSGenerateToken();
                        retry++;
                        goto Retry;
                    }
                    else if ((int)resp.StatusCode == 429 && retry < 2)
                    {
                        System.Threading.Thread.Sleep(2000);
                        retry++;
                        goto Retry;
                    }

                    using (var reader = new StreamReader(resp.GetResponseStream()))
                    {
                        string errorText = reader.ReadToEnd();
                        ClsCommon.WriteErrorLogs("UPS TimeInTransit Error: " + errorText);
                    }
                }
                throw;
            }
        }

        private void ExtractEMSTimeInTransitJSON(string json)
        {
            clsOnline.InitilizeTablesColumns("TIME");

            var root = JObject.Parse(json);
            var ems = root["emsResponse"];

            var services = ems["services"];
            if (services == null) return;

            foreach (var svc in services)
            {
                var dr = clsOnline.dtTime.NewRow();

                dr["ServiceLevel"] = svc["serviceLevel"]?.ToString();
                dr["ServiceDescription"] = svc["serviceLevelDescription"]?.ToString();

                dr["BusinessDays"] = svc["businessTransitDays"]?.ToString();
                dr["TotalTransitDays"] = svc["totalTransitDays"]?.ToString();

                dr["DeliveryDate"] = svc["deliveryDate"]?.ToString();
                dr["DeliveryTime"] = svc["deliveryTime"]?.ToString();
                dr["DeliveryDayOfWeek"] = svc["deliveryDayOfWeek"]?.ToString();

                dr["Guaranteed"] = svc["guaranteeIndicator"]?.ToString() == "1" ? "YES" : "NO";
                dr["RestDaysCount"] = svc["restDaysCount"]?.ToString();
                dr["HolidayCount"] = svc["holidayCount"]?.ToString();
                dr["DelayCount"] = svc["delayCount"]?.ToString();

                dr["CommitTime"] = svc["commitTime"]?.ToString();
                dr["PickupDate"] = svc["pickupDate"]?.ToString();
                dr["PickupTime"] = svc["pickupTime"]?.ToString();

                dr["CSTCCutoffTime"] = svc["cstccutoffTime"]?.ToString();
                dr["PODDays"] = svc["poddays"]?.ToString();

                clsOnline.dtTime.Rows.Add(dr);
            }
        }
        private void ExtractFedExTransitTimeJSON(string json)
        {
            clsOnline.InitilizeTablesColumns("FedExTIME");

            var root = JObject.Parse(json);
            var output = root["output"];
            if (output == null) return;

            var rateDetails = output["rateReplyDetails"];
            if (rateDetails == null) return;

            foreach (var svc in rateDetails)
            {
                var dr = clsOnline.dtTime.NewRow();

                // Basic service info
                dr["ServiceLevel"] = svc["serviceType"]?.ToString();
                dr["ServiceDescription"] = svc["serviceName"]?.ToString();

                var commit = svc["commit"];
                var dateDetail = commit?["dateDetail"];

                string deliveryDateTime = dateDetail?["dayFormat"]?.ToString();   // "2025-11-26T10:00:00"
                string deliveryDay = dateDetail?["dayOfWeek"]?.ToString();        // "Wed"

                dr["DeliveryDayOfWeek"] = deliveryDay;

                if (!string.IsNullOrWhiteSpace(deliveryDateTime))
                {
                    DateTime dt = DateTime.Parse(deliveryDateTime);
                    dr["DeliveryDate"] = dt.ToString("yyyy-MM-dd");
                    dr["DeliveryTime"] = dt.ToString("HH:mm");

                    // Transit Days
                    dr["TotalTransitDays"] = (dt.Date - DateTime.Now.Date).Days;
                    dr["BusinessDays"] = dr["TotalTransitDays"];
                }
                var operational = svc["operationalDetail"];
                bool ineligible = operational?["ineligibleForMoneyBackGuarantee"]?.ToObject<bool>() ?? true;

                dr["Guaranteed"] = ineligible ? "NO" : "YES";

                clsOnline.dtTime.Rows.Add(dr);
            }
        }

        private static readonly Dictionary<string, string> UpsServiceCodes = new Dictionary<string, string>
        {
            { "01", "UPS Next Day Air" },
            { "02", "UPS Second Day Air" },
            { "03", "UPS Ground" },
            { "07", "UPS Worldwide Express" },
            { "08", "UPS Worldwide Expedited" },
            { "11", "UPS Standard" },
            { "12", "UPS Three-Day Select" },
            { "13", "UPS Next Day Air Saver" },
            { "14", "UPS Next Day Air Early" },   // also called "UPS Next Day Air Early AM"
            { "54", "UPS Worldwide Express Plus" },
            { "59", "UPS Second Day Air A.M." },
            { "65", "UPS Worldwide Saver" }
            // add more if needed
        };
        private string TimeTrack()
        {
            string XML = "";
            XML += "<?xml version=\"1.0\"?>";
            XML += "<TimeInTransitRequest xml:lang=\"en-US\">";
            XML += "<Request>";
            XML += "<TransactionReference>";

            XML += "<CustomerContext>Time in Transit</CustomerContext>";
            XML += "<XpciVersion>1.001</XpciVersion>";
            XML += "</TransactionReference>";
            XML += "<RequestAction>TimeInTransit</RequestAction>";

            XML += "</Request>";
            XML += "<TransitFrom>";
            XML += "<AddressArtifactFormat>";
            String[] addressLine = { lblAddress1.Text.ToString(), lblAddress2.Text == null ? "" : lblAddress2.Text.ToString() };
            XML += "<PoliticalDivision2>" + addressLine[1].ToString() + "</PoliticalDivision2>";
            XML += "<PoliticalDivision1>" + addressLine[0].ToString() + "</PoliticalDivision1>";
            XML += "<PostcodePrimaryLow>" + NormalizePostalCode(lblZip.Text) + "</PostcodePrimaryLow>";
            XML += "<CountryCode>" + NormalizeCountryCode(lblCountry.Text) + "</CountryCode>";
            XML += "</AddressArtifactFormat>";
            XML += "</TransitFrom>";
            XML += "<TransitTo>";
            XML += "<AddressArtifactFormat>";
            String[] addressLine1 = { txtToAddress1.Text.ToString(), txtToAddress2.Text == null ? "" : txtToAddress2.Text.ToString() };
            XML += "<PoliticalDivision2>" + addressLine1[1].ToString() + "</PoliticalDivision2>";
            XML += "<PoliticalDivision1>" + addressLine1[0].ToString() + "</PoliticalDivision1>";
            XML += "<PostcodePrimaryLow>" + NormalizePostalCode(txtToZip.Text) + "</PostcodePrimaryLow>";
            XML += "<CountryCode>" + NormalizeCountryCode(txtToCountry.Text) + "</CountryCode>";
            XML += "</AddressArtifactFormat>";
            XML += "</TransitTo>";
            XML += "<PickupDate>" + DateTime.Now.ToString("yyyyMMdd") + "</PickupDate>";
            XML += "<MaximumListSize>" + "35" + "</MaximumListSize>";
            XML += "<InvoiceLineTotal>";
            XML += " <CurrencyCode>USD</CurrencyCode>";
            XML += "<MonetaryValue>" + Total + "</MonetaryValue>";
            XML += "</InvoiceLineTotal>";
            if (dgvPackage.Rows.Count > 0)
            {
                for (int i = 0; i < dgvPackage.Rows.Count; i++)
                {
                    XML += "<ShipmentWeight>";
                    XML += " <UnitOfMeasurement> ";
                    XML += " <Code>LBS</Code> ";
                    XML += " <Description>USD</Description> ";
                    XML += " </UnitOfMeasurement>";
                    XML += " <Weight>" + dgvPackage.Rows[i].Cells[1].Value.ToString() + "</Weight> ";
                    XML += "</ShipmentWeight>";
                }
            }
            XML += "</TimeInTransitRequest>";
            return XML;
        }
        //private string GetFedXJson()
        //{
        //    string Json = "";
        //    try
        //    {
        //        Json = "{\"mergeLabelDocOption\":\"LABELS_ONLY\",";
        //        Json += "\"requestedShipment\":{\"shipper\":{\"address\":";
        //        Json += "{\"streetLines\":[\"" + lblAddress1.Text.ToString().Replace(":", "") + " " + lblAddress2.Text.ToString().Replace(":", "") + "\"],";
        //        Json += "\"city\":\"" + lblCity.Text.ToString() + "\",";
        //        Json += "\"stateOrProvinceCode\":\"" + lblState.Text.ToString() + "\",";
        //        Json += "\"postalCode\":\"" + lblZip.Text.ToString() + "\",";
        //        Json += "\"countryCode\":\"" + lblCountry.Text.ToString() + "\",";
        //        Json += "\"residential\":false},";
        //        Json += "\"contact\":{";
        //        Json += "\"personName\":\"" + lblName.Text.ToString() + "\",";
        //        Json += "\"emailAddress\":\"txpartspay@gmail.com\",";
        //        Json += "\"phoneExtension\":\"1\",";
        //        Json += "\"phoneNumber\":\"" + lblPhone.Text.ToString() + "\",";
        //        Json += "\"companyName\":\"" + lblCompanyName.Text.ToString() + "\"}},";
        //        Json += "\"recipients\":[{\"address\":{";
        //        Json += "\"streetLines\":[\"" + txtToAddress1.Text.ToString().Replace(":", "") + " " + txtToAddress2.Text.ToString().Replace(":", "") + "\"],";
        //        Json += "\"city\":\"" + txtToCity.Text.ToString() + "\",";
        //        Json += "\"stateOrProvinceCode\":\"" + txtToState.Text.ToString().ToUpper().Replace("texas", "TX").Replace("Texas", "TX").Replace("Oklahoma", "OK") + "\",";
        //        Json += "\"postalCode\":\"" + txtToZip.Text.ToString() + "\",";
        //        Json += "\"countryCode\":\"" + txtToCountry.Text.ToString().Replace("USA", "US").Replace("United States", "US").Replace("UNITED STATES", "US").Replace("usa", "US").Replace("Unites States", "US") + "\",";
        //        if (cmbService.SelectedValue.ToString() == "FEDEX_GROUND")
        //        {
        //            Json += "\"residential\":false},";
        //        }
        //        else
        //        {
        //            Json += "\"residential\":true},";
        //        }
        //        Json += "\"contact\":{";
        //        Json += "\"personName\":\"" + txtToName.Text.ToString() + "\",";
        //        Json += "\"emailAddress\":\"" + txtToEmail.Text.ToString() + "\",";
        //        Json += "\"phoneExtension\":\"1\",";
        //        Json += "\"phoneNumber\":\"" + txtToPhone.Text.ToString() + "\",";
        //        Json += "\"companyName\":\"" + txtToCompany.Text.ToString().Replace("&", "and") + "\"}}],";
        //        Json += "\"pickupType\":\"DROPOFF_AT_FEDEX_LOCATION\",";
        //        Json += "\"serviceType\":\"" + cmbService.SelectedValue.ToString() + "\",";
        //        Json += "\"packagingType\":\"YOUR_PACKAGING\",";
        //        Json += "\"shippingChargesPayment\":{";
        //        Json += "\"paymentType\":\"SENDER\"},";
        //        Json += "\"labelSpecification\":{";
        //        Json += "\"labelFormatType\":\"COMMON2D\",";
        //        Json += "\"labelOrder\":\"SHIPPING_LABEL_FIRST\",";
        //        Json += "\"labelStockType\":\"STOCK_4X675_LEADING_DOC_TAB\",";
        //        Json += "\"imageType\":\"ZPLII\"},";
        //        Json += "\"requestedPackageLineItems\":[{";
        //        Json += "\"sequenceNumber\":\"1\",";
        //        Json += "\"subPackagingType\":\"BOX\",";
        //        Json += "\"customerReferences\":[{";
        //        Json += "\"customerReferenceType\":\"INVOICE_NUMBER\",";
        //        Json += "\"value\":\"" + RefNumber + "\"}],";
        //        //Json += "\"contentRecord\":[{";
        //        //Json += "\"itemNumber\":\"vnvbnvb\",";
        //        //Json += "\"receivedQuantity\":256,";
        //        //Json += "\"description\":\"Description\",";
        //        //Json += "\"partNumber\":\"456\"}],";
        //        if (dgvPackage.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dgvPackage.Rows.Count; i++)
        //            {
        //                Json += "\"weight\":{";
        //                Json += "\"units\":\"LB\",";

        //                if (txtWeight.Text != "")
        //                {
        //                    //Json += "\"value\":" + txtWeight.Text.ToString() + "}";
        //                    //Json += ",\"dimensions\":{";
        //                    //Json += "\"length\":" + txtLength.Text.ToString() + ",";
        //                    //Json += "\"width\":" + txtWidth.Text.ToString() + ",";
        //                    //Json += "\"height\":" + txtHeight.Text.ToString() + ",";
        //                    //Json += "\"units\":\"IN\"}";
        //                    Json += "\"value\":" + txtWeight.Text.ToString() + "}";
        //                    Json += ",\"dimensions\":{";

        //                    Json += "\"length\":" + (txtLength.Text == "0" || txtLength.Text == "" ? "1" : txtLength.Text) + ",";
        //                    Json += "\"width\":" + (txtWidth.Text == "0" || txtWidth.Text == "" ? "1" : txtWidth.Text) + ",";
        //                    Json += "\"height\":" + (txtHeight.Text == "0" || txtHeight.Text == "" ? "1" : txtHeight.Text) + ",";

        //                    Json += "\"units\":\"IN\"}";

        //                }
        //                else
        //                {
        //                    //Json += "\"value\":" + dgvPackage.Rows[i].Cells["Weight"].Value.ToString() + "}";
        //                    //Json += ",\"dimensions\":{";
        //                    //Json += "\"length\":" + dgvPackage.Rows[i].Cells["Length"].Value.ToString() + ",";
        //                    //Json += "\"width\":" + dgvPackage.Rows[i].Cells["Width"].Value.ToString() + ",";
        //                    //Json += "\"height\":" + dgvPackage.Rows[i].Cells["Height"].Value.ToString() + ",";
        //                    //Json += "\"units\":\"IN\"}";
        //                    Json += "\"value\":" +
        //                            (dgvPackage.Rows[i].Cells["Weight"].Value.ToString() == "0" ||
        //                             dgvPackage.Rows[i].Cells["Weight"].Value.ToString() == ""
        //                             ? "1"
        //                             : dgvPackage.Rows[i].Cells["Weight"].Value.ToString()) + "}";

        //                    Json += ",\"dimensions\":{";

        //                    Json += "\"length\":" +
        //                            (dgvPackage.Rows[i].Cells["Length"].Value.ToString() == "0" ||
        //                             dgvPackage.Rows[i].Cells["Length"].Value.ToString() == ""
        //                             ? "1"
        //                             : dgvPackage.Rows[i].Cells["Length"].Value.ToString()) + ",";

        //                    Json += "\"width\":" +
        //                            (dgvPackage.Rows[i].Cells["Width"].Value.ToString() == "0" ||
        //                             dgvPackage.Rows[i].Cells["Width"].Value.ToString() == ""
        //                             ? "1"
        //                             : dgvPackage.Rows[i].Cells["Width"].Value.ToString()) + ",";

        //                    Json += "\"height\":" +
        //                            (dgvPackage.Rows[i].Cells["Height"].Value.ToString() == "0" ||
        //                             dgvPackage.Rows[i].Cells["Height"].Value.ToString() == ""
        //                             ? "1"
        //                             : dgvPackage.Rows[i].Cells["Height"].Value.ToString()) + ",";

        //                    Json += "\"units\":\"IN\"}";

        //                }

        //                if (!string.IsNullOrWhiteSpace(txtDeclaredValue.Text))
        //                {
        //                    Json += ",\"declaredValue\":{";
        //                    Json += "\"amount\":" + Convert.ToDecimal(txtDeclaredValue.Text) + ",";
        //                    Json += "\"currency\":\"USD\"}";
        //                }
        //                if (dgvPackage.Rows.Count != i + 1)
        //                {
        //                    Json += ",";
        //                }
        //            }
        //        }
        //        Json += "}";
        //        Json += "]},";


        //        // ✅ Add Service Options (Saturday Delivery, Direct Delivery Only, Saturday Pickup)
        //        if (chkSaturdayDelivery.Checked == true || chkDirectDeliveryOnly.Checked == true || chkSaturdayPickup.Checked == true)
        //        {
        //            Json += "\"specialServicesRequested\":{";

        //            bool addComma = false;

        //            if (chkSaturdayDelivery.Checked == true)
        //            {
        //                Json += "\"specialServiceTypes\":[\"SATURDAY_DELIVERY\"]";
        //                addComma = true;
        //            }

        //            if (chkDirectDeliveryOnly.Checked == true)
        //            {
        //                if (addComma) Json += ",";
        //                Json += "\"directDeliveryOnly\":true";
        //                addComma = true;
        //            }

        //            if (chkSaturdayPickup.Checked == true)
        //            {
        //                if (addComma) Json += ",";
        //                Json += "\"saturdayPickup\":true";
        //            }

        //            Json += "},";
        //        }



        //        Json += "\"labelResponseOptions\":\"LABEL\",";
        //        if (dtFedEx.Rows.Count > 0)
        //        {
        //            Json += "\"accountNumber\":{\"value\":\"" + dtFedEx.Rows[0]["AccountNo"].ToString() + "\"},";
        //        }
        //        else
        //        {
        //            Json += "\"accountNumber\":{\"value\":\"844084846\"},";


        //        }
        //        Json += "\"shipAction\":\"CONFIRM\",";
        //        Json += "\"oneLabelAtATime\":true}";

        //    }
        //    catch (Exception ex)
        //    {
        //        ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: GetUPSXML, Message:" + ex.Message);
        //        MessageBox.Show("General Exception = " + ex.Message, "E");
        //    }
        //    return Json;
        //}
        private string GetFedXJson()
        {
            try
            {
                StringBuilder json = new StringBuilder();

                string accountNo = dtFedEx.Rows.Count > 0
                    ? dtFedEx.Rows[0]["AccountNo"].ToString()
                    : "844084846";

                bool isResidential = chkResidential.Checked;
                string service = cmbService.SelectedValue.ToString();

                // ================= ROOT =================
                json.Append("{");
                json.Append("\"mergeLabelDocOption\":\"LABELS_ONLY\",");
                json.Append("\"labelResponseOptions\":\"LABEL\",");
                json.Append($"\"accountNumber\":{{\"value\":\"{accountNo}\"}},");

                // ================= REQUESTED SHIPMENT =================
                json.Append("\"requestedShipment\":{");
                json.Append("\"pickupType\":\"DROPOFF_AT_FEDEX_LOCATION\",");
                json.Append($"\"serviceType\":\"{service}\",");
                json.Append("\"packagingType\":\"YOUR_PACKAGING\",");

                // ================= SHIPPER =================
                json.Append("\"shipper\":{");
                json.Append("\"contact\":{");
                json.Append($"\"personName\":\"{lblName.Text}\",");
                json.Append("\"emailAddress\":\"txpartspay@gmail.com\",");
                json.Append($"\"phoneNumber\":\"{lblPhone.Text}\",");
                json.Append($"\"companyName\":\"{lblCompanyName.Text}\"");
                json.Append("},");
                json.Append("\"address\":{");
                json.Append($"\"streetLines\":[\"{lblAddress1.Text} {lblAddress2.Text}\"],");
                json.Append($"\"city\":\"{lblCity.Text}\",");
                json.Append($"\"stateOrProvinceCode\":\"{lblState.Text}\",");
                json.Append($"\"postalCode\":\"{NormalizePostalCode(lblZip.Text)}\",");
                json.Append($"\"countryCode\":\"{NormalizeCountryCode(lblCountry.Text)}\",");
                json.Append("\"residential\":false");
                json.Append("}");
                json.Append("},");

                // ================= RECIPIENT =================
                json.Append("\"recipients\":[{");
                json.Append("\"contact\":{");
                json.Append($"\"personName\":\"{txtToName.Text}\",");
                json.Append($"\"phoneNumber\":\"{txtToPhone.Text}\",");
                json.Append($"\"companyName\":\"{txtToCompany.Text.Replace("&", "and")}\"");
                json.Append("},");
                json.Append("\"address\":{");
                json.Append($"\"streetLines\":[\"{txtToAddress1.Text} {txtToAddress2.Text}\"],");
                json.Append($"\"city\":\"{txtToCity.Text}\",");
                json.Append($"\"stateOrProvinceCode\":\"{txtToState.Text}\",");
                json.Append($"\"postalCode\":\"{NormalizePostalCode(txtToZip.Text)}\",");
                json.Append($"\"countryCode\":\"{NormalizeCountryCode(txtToCountry.Text)}\",");
                json.Append($"\"residential\":{isResidential.ToString().ToLower()}");
                json.Append("}");
                json.Append("}],");

                // ================= PAYMENT =================
                json.Append("\"shippingChargesPayment\":{");
                json.Append("\"paymentType\":\"SENDER\",");
                json.Append($"\"payor\":{{\"responsibleParty\":{{\"accountNumber\":{{\"value\":\"{accountNo}\"}}}}}}");
                json.Append("},");

                // ================= PACKAGES =================
                int packageCount = dgvPackage.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow);
                json.Append($"\"packageCount\":{packageCount},");
                json.Append("\"requestedPackageLineItems\":[");

                int seq = 1;
                foreach (DataGridViewRow row in dgvPackage.Rows)
                {
                    if (row.IsNewRow) continue;

                    decimal weight = Convert.ToDecimal(row.Cells["Weight"].Value);
                    int length = Convert.ToInt32(row.Cells["Length"].Value);
                    int width = Convert.ToInt32(row.Cells["Width"].Value);
                    int height = Convert.ToInt32(row.Cells["Height"].Value);

                    if (weight == 0) weight = 1;
                    if (length == 0) length = 1;
                    if (width == 0) width = 1;
                    if (height == 0) height = 1;

                    json.Append("{");
                    json.Append($"\"sequenceNumber\":{seq++},");

                    // ✅ INVOICE NUMBER (PRINTS ON LABEL)
                    json.Append("\"customerReferences\":[{");
                    json.Append("\"customerReferenceType\":\"INVOICE_NUMBER\",");
                    json.Append($"\"value\":\"{RefNumber}\"");
                    json.Append("}],");

                    json.Append($"\"weight\":{{\"units\":\"LB\",\"value\":{weight}}},");
                    json.Append("\"dimensions\":{");
                    json.Append($"\"length\":{length},");
                    json.Append($"\"width\":{width},");
                    json.Append($"\"height\":{height},");
                    json.Append("\"units\":\"IN\"}");
                    json.Append("},");
                }

                json.Length--; // remove last comma
                json.Append("],");

                // ================= LABEL =================
                json.Append("\"labelSpecification\":{");
                json.Append("\"labelFormatType\":\"COMMON2D\",");
                json.Append("\"imageType\":\"ZPLII\",");
                json.Append("\"labelStockType\":\"STOCK_4X6\"}");

                // ================= SATURDAY DELIVERY =================
                if (chkSaturdayDelivery.Checked && IsSaturdayAllowed(service))
                {
                    json.Append(",\"shipmentSpecialServices\":{");
                    json.Append("\"specialServiceTypes\":[\"SATURDAY_DELIVERY\"]}");
                }

                json.Append("}"); // requestedShipment
                json.Append("}"); // root

                return json.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        bool IsSaturdayAllowed(string service)
        {
            return service == "PRIORITY_OVERNIGHT"
                || service == "STANDARD_OVERNIGHT"
                || service == "FEDEX_2_DAY"
                || service == "FEDEX_2_DAY_AM";
        }
        private string GetFedXRateJson()
        {
            var dateTime = DateTime.Now;
            string formattedDate = dateTime.ToString("yyyy-MM-dd");
            string Json = "";
            try
            {
                Json += "{";
                if (dtFedEx.Rows.Count > 0)
                {
                    Json += "\"accountNumber\":{\"value\":\"" + dtFedEx.Rows[0]["AccountNo"].ToString() + "\"},";
                }
                else
                {
                    Json += "\"accountNumber\":{\"value\":\"844084846\"},";

                }
                Json += "\"rateRequestControlParameters\":{";
                Json += "\"returnTransitTimes\":\"false\",";
                Json += "\"servicesNeededOnRateFailure\":\"true\",";
                Json += "\"variableOptions\":\"FREIGHT_GUARANTEE\",";
                Json += "\"rateSortOrder\":\"SERVICENAMETRADITIONAL\"},";
                Json += "\"requestedShipment\":{\"shipper\":{\"address\":";
                Json += "{\"streetLines\":[\"" + lblAddress1.Text.ToString().Replace(":", "") + " " + lblAddress2.Text.ToString().Replace(":", "") + "\"],";
                Json += "\"city\":\"" + lblCity.Text.ToString() + "\",";
                Json += "\"stateOrProvinceCode\":\"" + lblState.Text.ToString() + "\",";
                Json += "\"postalCode\":\"" + NormalizePostalCode(lblZip.Text) + "\",";
                Json += "\"countryCode\":\"" + NormalizeCountryCode(lblCountry.Text) + "\",";
                Json += "\"residential\":false}";
                Json += "},";
                Json += "\"recipient\":{\"address\":";
                Json += "{\"streetLines\":[\"" + txtToAddress1.Text.ToString().Replace(":", "") + " " + txtToAddress2.Text.ToString().Replace(":", "") + "\"],";
                Json += "\"city\":\"" + txtToCity.Text.ToString() + "\",";
                Json += "\"stateOrProvinceCode\":\"" + txtToState.Text.ToString() + "\",";
                Json += "\"postalCode\":\"" + NormalizePostalCode(txtToZip.Text) + "\",";
                Json += "\"countryCode\":\"" + NormalizeCountryCode(txtToCountry.Text) + "\",";
                Json += "\"residential\":false}";
                Json += "},";
                Json += "\"serviceType\":\"" + cmbService.SelectedValue.ToString() + "\",";
                Json += "\"preferredCurrency\":\"USD\",";
                Json += "\"rateRequestType\":[\"ACCOUNT\",\"LIST\"],";
                Json += "\"shipDateStamp\":\"" + formattedDate + "\",";
                Json += "\"pickupType\":\"DROPOFF_AT_FEDEX_LOCATION\",";
                Json += "\"requestedPackageLineItems\":[{";
                Json += "\"subPackagingType\":\"BOX\",";
                Json += "\"groupPackageCount\":\"1\",";
                if (dgvPackage.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvPackage.Rows.Count; i++)
                    {
                        Json += "\"weight\":{";
                        Json += "\"units\":\"LB\",";
                        if (txtWeight.Text != "")
                        {
                            Json += "\"value\":" + txtWeight.Text.ToString() + "}";
                            Json += ",\"dimensions\":{";
                            Json += "\"length\":" + txtLength.Text + ",";
                            Json += "\"width\":" + txtWidth.Text + ",";
                            Json += "\"height\":" + txtHeight.Text + ",";
                            Json += "\"units\":\"IN\"}";
                        }
                        else
                        {
                            Json += "\"value\":" + dgvPackage.Rows[i].Cells["Weight"].Value.ToString().ToString() + "}";
                            Json += ",\"dimensions\":{";
                            Json += "\"length\":" + dgvPackage.Rows[i].Cells["Length"].Value.ToString() + ",";
                            Json += "\"width\":" + dgvPackage.Rows[i].Cells["Width"].Value.ToString() + ",";
                            Json += "\"height\":" + dgvPackage.Rows[i].Cells["Height"].Value.ToString() + ",";
                            Json += "\"units\":\"IN\"}";
                        }
                        // 🔹 Add Declared Value if entered
                        if (!string.IsNullOrWhiteSpace(txtDeclaredValue.Text))
                        {
                            Json += ",\"declaredValue\":{";
                            Json += "\"amount\":" + Convert.ToDecimal(txtDeclaredValue.Text) + ",";
                            Json += "\"currency\":\"USD\"}";
                        }

                        if (dgvPackage.Rows.Count != i + 1)
                        {
                            Json += ",";
                        }
                    }
                }
                Json += "}";
                Json += "]";

                // ✅ Add Service Options (Saturday Delivery, Direct Delivery Only, Saturday Pickup)
                if (chkSaturdayDelivery.Checked == true || chkDirectDeliveryOnly.Checked == true || chkSaturdayPickup.Checked == true)
                {
                    Json += ",\"serviceOptions\":{";

                    bool addComma = false;

                    if (chkSaturdayDelivery.Checked == true)
                    {
                        Json += "\"saturdayDelivery\":true";
                        addComma = true;
                    }

                    if (chkDirectDeliveryOnly.Checked == true)
                    {
                        if (addComma) Json += ",";
                        Json += "\"directDeliveryOnly\":true";
                        addComma = true;
                    }

                    if (chkSaturdayPickup.Checked == true)
                    {
                        if (addComma) Json += ",";
                        Json += "\"saturdayPickup\":true";
                    }

                    Json += "}";
                }

                Json += "}";
                Json += "}";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmFedExUPSShippingManager, Function: GetFedXRateJson, Message:" + ex.Message);
                MessageBox.Show("General Exception = " + ex.Message, "E");
            }
            return Json;
        }
        private void txtLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
                {
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFedExUPSShippingManager,Function :txtLength_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void txtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
                {
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFedExUPSShippingManager,Function :txtLength_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
                {
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFedExUPSShippingManager,Function :txtLength_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void FedXGenerateToken()
        {
            try
            {
                dtFedEx = new BALUPSSettings().SelectByType("FedX");
                if (dtFedEx.Rows.Count > 0)
                {
                    string post = "grant_type=client_credentials&client_id=" + dtFedEx.Rows[0]["ClientID"].ToString() + "&client_secret=" + dtFedEx.Rows[0]["ClientSecret"].ToString() + "";
                    HttpWebRequest WebRequestObject = null;
                    HttpWebResponse WebResponseObject = null;
                    StreamReader sr = null;

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    //Sample
                    //WebRequestObject = (HttpWebRequest)WebRequest.Create("https://apis-sandbox.fedex.com/oauth/token");
                    //Live
                    WebRequestObject = (HttpWebRequest)WebRequest.Create("https://apis.fedex.com/oauth/token");


                    WebRequestObject.Method = "POST";

                    byte[] byteArray = Encoding.UTF8.GetBytes(post);
                    WebRequestObject.ContentType = "application/x-www-form-urlencoded";

                    WebRequestObject.ContentLength = byteArray.Length;

                    Stream dataStream = WebRequestObject.GetRequestStream();

                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();

                    WebRequestObject.AllowAutoRedirect = false;

                    WebResponseObject = (HttpWebResponse)WebRequestObject.GetResponse();
                    sr = new StreamReader(WebResponseObject.GetResponseStream());
                    string Results = sr.ReadToEnd();

                    if (Results.Contains("Error"))
                        MessageBox.Show(Results);
                    else
                    {
                        clsOnline.ExtractToken(Results, "FedX");
                        dtFedEx = new BALUPSSettings().SelectByType("FedX");
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFedExUPSShippingManager,Function :FedXGenerateToken. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        //my create
        public void UPSGenerateToken()
        {
            try
            {
                if (dtUPS.Rows.Count > 0)
                {
                    var client = new HttpClient();
                    // Create POST request
                    var request = new HttpRequestMessage(HttpMethod.Post, "https://onlinetools.ups.com/security/v1/oauth/token");

                    // Build Basic Auth header
                    string clientId = dtUPS.Rows[0]["ClientID"].ToString();
                    string clientSecret = dtUPS.Rows[0]["ClientSecret"].ToString();
                    string authHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes(clientId + ":" + clientSecret));
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authHeader);

                    // Build body parameters
                    var collection = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("grant_type", "client_credentials"),
                        new KeyValuePair<string, string>("refresh_token", dtUPS.Rows[0]["RefreshToken"].ToString()),
                        new KeyValuePair<string, string>("scope", "ship rate tnt") // important for multiple endpoints
                    };

                    // Encode as x-www-form-urlencoded
                    request.Content = new FormUrlEncodedContent(collection);

                    // Send request synchronously
                    var response = client.SendAsync(request).GetAwaiter().GetResult();
                    response.EnsureSuccessStatusCode();

                    // Read response synchronously
                    string result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    if (result.Contains("Error"))
                        MessageBox.Show(result);
                    else
                    {
                        clsOnline.ExtractToken(result, "UPS");
                        dtUPS = new BALUPSSettings().SelectByType("UPS");
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFedExUPSShippingManager,Function :FedXGenerateToken. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void btnAvailableServiceRates_Click(object sender, EventArgs e)
        {
            if (rdbUPS.Checked)
            {
                GetTransitRate();
            }
            else
            {
                type = "FedExRATE";
                GetFedExTransitTime();
            }
            if (clsOnline.dtTime.Rows.Count > 0)
            {
                FrmAvailableService frmAvailableService = new FrmAvailableService();
                frmAvailableService.ShowDialog();
            }
            type = "";
            //GetTransitRate();
            //if (clsOnline.dtTime.Rows.Count > 0)
            //{
            //    FrmAvailableService frmAvailableService = new FrmAvailableService();
            //    frmAvailableService.ShowDialog();
            //}
        }

    }
}