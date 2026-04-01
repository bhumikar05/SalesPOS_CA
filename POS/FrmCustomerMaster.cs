using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using Interop.QBFC13;
using Newtonsoft.Json;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using SalesPOS.QBClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Telerik.WinControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using DataTable = System.Data.DataTable;

namespace POS
{
    public partial class FrmCustomerMaster : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtLoadData = new DataTable();
        DataTable dtBillAddress = new DataTable();
        DataTable dtShipAddress = new DataTable();
        DataTable dtCreditCardDetails = new DataTable();
        public bool IsAddress = true;

        static BALCustomerRequest objCusReqBAL = new BALCustomerRequest();
        static BOLCustomerRequest objCusReqBOL = new BOLCustomerRequest();
        BALNewCustomerHistory objnewBAL = new BALNewCustomerHistory();
        BOLNewCustomerHistory objnewBOL = new BOLNewCustomerHistory();
        BALCustomerMaster ObjCustomerBAL = new BALCustomerMaster();
        BOLCustomerMaster ObjCustomerBOL = new BOLCustomerMaster();
        BALAddressMaster ObjAddressBAL = new BALAddressMaster();
        BOLAddressMaster ObjAddressBOL = new BOLAddressMaster();

        BALInvoiceMaster objInvBAL = new BALInvoiceMaster();
        BOLInvoiceMaster objInvBOL = new BOLInvoiceMaster();
        BOLCustomerMaster_Update objBOLLog = new BOLCustomerMaster_Update();
        BALCustomerMaster_Update objBALLog = new BALCustomerMaster_Update();



        BOLCreditCardDetails BOLCreditCardDetails = new BOLCreditCardDetails();
        BALCreditCardDetails BALCreditCardDetails = new BALCreditCardDetails();

        public string Mode = "insert";
        public string BillAddress { get; set; }
        public string ShipAddress { get; set; }
        public string ShipAddressName = "";
        string EditShipAddress = "";
        int CusID = 0;
        public static string[] key = { "YzJsaWJHa3RjR2xyYVc1cA==", "Y21GcVlYSmhibU5vYUc5aw==", "VTJoeVpXVkxjbWx6YUc1aA==" };
        //princy Add
        public delegate void CustomerNameUpdatedHandler(string customerName);
        public event CustomerNameUpdatedHandler CustomerNameUpdated;
        public string CustomerName
        {
            get { return txtCustomerName.Text; }
            set { txtCustomerName.Text = value; }
        }

        //
        public FrmCustomerMaster()
        {
            try
            {
                InitializeComponent();
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(0, 50);
                tabCustomer.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
                lblParentCustomer.Visible = false;
                cmbParentCustomer.Visible = false;
                dgvCreditCard.DataSource = null;

                GetTable();
                GetTerms();
                GetPaymentMethod();
                GetSalesRep();
                GetShipName();
                GetParentCustomer();
                CustomerSalesRep();
                LoadItem();
                GetYear();
                GetMonth();
                ResetCreditCardDetails();
                cmbSalesrep.Enabled = true;

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :FrmCustomerMaster. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void tabControl1_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                Brush _textBrush;

                // Get the item from the collection.
                TabPage _tabPage = tabCustomer.TabPages[e.Index];

                // Get the real bounds for the tab rectangle.
                Rectangle _tabBounds = tabCustomer.GetTabRect(e.Index);
                if (e.State == DrawItemState.Selected)
                {

                    // Draw a different background color, and don't paint a focus rectangle.
                    _textBrush = new SolidBrush(Color.Black);
                    g.FillRectangle(Brushes.LightGray, e.Bounds);

                }
                else
                {
                    _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                    e.DrawBackground();
                }

                // Use our own font.
                Font _tabFont = new Font("Arial", 12.0f, FontStyle.Regular, GraphicsUnit.Pixel);

                // Draw string. Center the text.
                StringFormat _stringFlags = new StringFormat();
                _stringFlags.Alignment = StringAlignment.Center;
                _stringFlags.LineAlignment = StringAlignment.Center;
                g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :tabControl1_DrawItem. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        public void CustomerSalesRep()
        {
            if (ClsCommon.UserName == null)
            {
                cmbSalesrep.Enabled = true;

            }
            else if (ClsCommon.UserName.ToString() == "Admin")
            {
                cmbSalesrep.Enabled = true;
            }
            else
            {
                cmbSalesrep.Enabled = false;
                cmbSalesrep.SelectedValue = ClsCommon.UserID;
            }

            //cmbSalesrep.SelectedValue = ClsCommon.UserID;
            //if (cmbSalesrep.SelectedValue.ToString() == "1")
            //{
            //    cmbSalesrep.Enabled = true;
            //    cmbSalesrep.SelectedValue = ClsCommon.UserID;
            //}
            ////else if(ClsCommon.UserID.ToString()=="1")
            ////{
            ////    cmbSalesrep.Enabled = false;
            ////    cmbSalesrep.SelectedValue = ClsCommon.UserID;
            ////}
            //else
            //{
            //    cmbSalesrep.Enabled = false;
            //    cmbSalesrep.SelectedValue = ClsCommon.UserID;
            //}
        }

        private void FrmCustomerMaster_Load(object sender, EventArgs e)
        {
            try
            {
                ResetCreditCardDetails();
                CustomerSalesRep();
                dtpCreateDate.Format = DateTimePickerFormat.Custom;
                dtpCreateDate.CustomFormat = "MM/dd/yyyy";

                if (Mode == "insert" || Mode == "insert Job")
                    txtOpeningBalance.ReadOnly = false;
                else
                    txtOpeningBalance.ReadOnly = true;


                //princy

                if (!string.IsNullOrEmpty(CustomerName))
                {
                    txtCustomerName.Text = CustomerName;
                }


                //txtSaluation.Text = "Mr./Ms./..";
                //txtFirstName.Text = "First";
                //txtMiddleName.Text = "M.I.";
                //txtLastName.Text = "Last";
                //txtSaluation.Enabled = true;
                //txtFirstName.Enabled = true;
                //txtMiddleName.Enabled = true;
                //txtLastName.Enabled = true;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :FrmCustomerMaster_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void LoadFunc()
        {
            txtSaluation.Text = "Mr./Ms./..";
            txtSaluation.ForeColor = Color.Gray;
            txtFirstName.Text = "First";
            txtFirstName.ForeColor = Color.Gray;
            txtMiddleName.Text = "M.I.";
            txtMiddleName.ForeColor = Color.Gray;
            txtLastName.Text = "Last";
            txtLastName.ForeColor = Color.Gray;
            txtSaluation.Enabled = true;
            txtFirstName.Enabled = true;
            txtMiddleName.Enabled = true;
            txtLastName.Enabled = true;
        }
        public void LoadItem()
        {
            cmbSalesTax.DataSource = null;
            DataTable dtSubItem = new BALItemMaster().SelectItem(new BOLItemMaster() { });
            if (dtSubItem.Rows.Count > 0)
            {
              
                    cmbSalesTax.Items.Clear();
                    // Service Item
                    DataRow[] dr = dtSubItem.Select("ItemType='SalesTaxItem'");
                    if (dr.Length > 0)
                    {
                        DataTable dtService = dr.CopyToDataTable();
                        if (dtService.Rows.Count > 0)
                        {
                            DataRow drAdd = dtService.NewRow();
                            drAdd["FullName"] = "--Select--";
                            drAdd["ID"] = "0";
                            drAdd["ItemType"] = "";
                            dtService.Rows.InsertAt(drAdd, 0);
                            cmbSalesTax.DataSource = dtService;
                            cmbSalesTax.DisplayMember = "FullName";
                            cmbSalesTax.ValueMember = "ID";
                        }
                    }
                    else
                        cmbSalesTax.Items.Insert(0, "--Select--");
                
            }
        }
        public void LoadFunction()
        {
            try
            {
                lblParentCustomer.Visible = false;
                cmbParentCustomer.Visible = false;
                dgvCreditCard.DataSource = null;
                GetTable();
                GetTerms();
                GetPaymentMethod();
                GetSalesRep();
                GetShipName();
                GetParentCustomer();
                LoadItem();
                GetYear();
                GetMonth();
                tabCustomer.SelectedTab = tabAddressInfo;
                if (Mode == "insert" || Mode == "insert Job")
                    txtOpeningBalance.ReadOnly = false;
                else
                    txtOpeningBalance.ReadOnly = true;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :LoadFunction. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void GetTable()
        {
            DataRow dr = null;
            dtCreditCardDetails = new DataTable();
            dtCreditCardDetails.Columns.Add("SrNo", typeof(Int32));//0
            dtCreditCardDetails.Columns.Add("CustomerID", typeof(Int32));//1
            dtCreditCardDetails.Columns.Add("CardType", typeof(string));//2
            dtCreditCardDetails.Columns.Add("FirstName", typeof(string));//3
            dtCreditCardDetails.Columns.Add("LastName", typeof(string));//4
            dtCreditCardDetails.Columns.Add("CardNumber", typeof(string));//5
            dtCreditCardDetails.Columns.Add("Year", typeof(string));//6
            dtCreditCardDetails.Columns.Add("Month", typeof(string));//7
            dtCreditCardDetails.Columns.Add("CVV", typeof(string));//8
            dtCreditCardDetails.Columns.Add("Address", typeof(string));//9
            dtCreditCardDetails.Columns.Add("City", typeof(string));//10
            dtCreditCardDetails.Columns.Add("State", typeof(string));//11
            dtCreditCardDetails.Columns.Add("ZipCode", typeof(string));//12
            dtCreditCardDetails.Columns.Add("Country", typeof(string));//13

            if (dgvCreditCard.Rows.Count > 0)
            {
                for (int i = 0; i < dgvCreditCard.Rows.Count; i++)
                {
                    dr = dtCreditCardDetails.NewRow();
                    dr[0] = dgvCreditCard.Rows[i].Cells[0].EditedFormattedValue.ToString();
                    dr[1] = dgvCreditCard.Rows[i].Cells[1].EditedFormattedValue.ToString();
                    dr[2] = dgvCreditCard.Rows[i].Cells[2].EditedFormattedValue.ToString();
                    dr[3] = dgvCreditCard.Rows[i].Cells[3].EditedFormattedValue.ToString();
                    dr[4] = dgvCreditCard.Rows[i].Cells[4].EditedFormattedValue.ToString();
                    dr[5] = dgvCreditCard.Rows[i].Cells[5].EditedFormattedValue.ToString();
                    dr[6] = dgvCreditCard.Rows[i].Cells[6].EditedFormattedValue.ToString();
                    dr[7] = dgvCreditCard.Rows[i].Cells[7].EditedFormattedValue.ToString();
                    dr[8] = dgvCreditCard.Rows[i].Cells[8].EditedFormattedValue.ToString();
                    dr[9] = dgvCreditCard.Rows[i].Cells[9].EditedFormattedValue.ToString();
                    dr[10] = dgvCreditCard.Rows[i].Cells[10].EditedFormattedValue.ToString();
                    dr[11] = dgvCreditCard.Rows[i].Cells[11].EditedFormattedValue.ToString();
                    dr[12] = dgvCreditCard.Rows[i].Cells[12].EditedFormattedValue.ToString();
                    dr[13] = dgvCreditCard.Rows[i].Cells[13].EditedFormattedValue.ToString();
                    dtCreditCardDetails.Rows.Add(dr);
                }
            }

            dgvCreditCard.DataSource = dtCreditCardDetails;

            foreach (DataGridViewColumn item in dgvCreditCard.Columns)
            {
                if (item.GetType() == typeof(DataGridViewLinkColumn) && item.HeaderText == "Delete")
                {
                    dgvCreditCard.Columns.Remove("Delete");
                    break;
                }
            }
            foreach (DataGridViewColumn item in dgvCreditCard.Columns)
            {
                if (item.GetType() == typeof(DataGridViewLinkColumn) && item.HeaderText == "Edit")
                {
                    dgvCreditCard.Columns.Remove("Edit");
                    break;
                }
            }
            // Add "Edit" link column

            DataGridViewLinkColumn links1 = new DataGridViewLinkColumn();
            links1.HeaderText = "Edit";
            links1.Name = "Edit";
            links1.UseColumnTextForLinkValue = true;
            links1.Text = "Edit";
            links1.LinkColor = Color.Blue;
            links1.TrackVisitedState = true;
            links1.VisitedLinkColor = Color.YellowGreen;
            dgvCreditCard.Columns.Insert(14, links1);

            // Add "Delete" link column

            DataGridViewLinkColumn links = new DataGridViewLinkColumn();
            links.HeaderText = "Delete";
            links.Name = "Delete";
            links.UseColumnTextForLinkValue = true;
            links.Text = "Delete";
            links.LinkColor = Color.Blue;
            links.TrackVisitedState = true;
            links.VisitedLinkColor = Color.YellowGreen;
            dgvCreditCard.Columns.Insert(15, links);

            // Optionally, set read-only properties and visibility
            dgvCreditCard.Columns["SrNo"].Visible = false;
            // dgvCreditCard.Columns[0].ReadOnly = true;
            // dgvCreditCard.Columns[1].ReadOnly = true;
            // dgvCreditCard.Columns[2].ReadOnly = true;
        }
        private void GetYear()
        {
            try
            {
                DataTable dtYear = new DataTable();
                int currentYear = DateTime.Now.Year;
                dtYear.Columns.Add(new DataColumn("Year"));
                for (int i = 0; i <= 50; i++)
                {
                    dtYear.Rows.Add(currentYear + i);
                }
                cmbYear.DataSource = dtYear;
                cmbYear.DisplayMember = "Year";
                cmbYear.ValueMember = "Year";

                cmbYear.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :GetTerms. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        private void GetMonth()
        {
            try
            {
                DataTable monthsTable = new DataTable("Months");

                // Add columns to the DataTable
                monthsTable.Columns.Add("MonthIndex", typeof(string));
                monthsTable.Columns.Add("MonthName", typeof(string));

                // Populate the DataTable with month index and names
                for (int i = 1; i <= 12; i++)
                {
                    string month= i.ToString();
                    DataRow row = monthsTable.NewRow();
                    if(i.ToString().Length==1)
                    {
                        month = "0" + i;
                    }
                    row["MonthIndex"] = month;
                    row["MonthName"] = DateTimeFormatInfo.CurrentInfo.GetMonthName(i);
                    monthsTable.Rows.Add(row);
                }

                cmbMonth.DataSource = monthsTable;
                cmbMonth.DisplayMember = "MonthIndex";
                cmbMonth.ValueMember = "MonthIndex";

                cmbMonth.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :GetTerms. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        private void BillAddressColumn()
        {
            try
            {
                if (dtBillAddress.Columns.Contains("ID") == false)
                    dtBillAddress.Columns.Add("ID");
                if (dtBillAddress.Columns.Contains("AddressName") == false)
                    dtBillAddress.Columns.Add("AddressName");
                if (dtBillAddress.Columns.Contains("Address1") == false)
                    dtBillAddress.Columns.Add("Address1");
                if (dtBillAddress.Columns.Contains("Address2") == false)
                    dtBillAddress.Columns.Add("Address2");
                if (dtBillAddress.Columns.Contains("Address3") == false)
                    dtBillAddress.Columns.Add("Address3");
                if (dtBillAddress.Columns.Contains("City") == false)
                    dtBillAddress.Columns.Add("City");
                if (dtBillAddress.Columns.Contains("State") == false)
                    dtBillAddress.Columns.Add("State");
                if (dtBillAddress.Columns.Contains("ZipCode") == false)
                    dtBillAddress.Columns.Add("ZipCode");
                if (dtBillAddress.Columns.Contains("Country") == false)
                    dtBillAddress.Columns.Add("Country");
                if (dtBillAddress.Columns.Contains("Note") == false)
                    dtBillAddress.Columns.Add("Note");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :BillAddressColumn. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void ShipAddressColumn()
        {
            try
            {
                if (dtShipAddress.Columns.Contains("ID") == false)
                    dtShipAddress.Columns.Add(new DataColumn("ID"));
                if (dtShipAddress.Columns.Contains("AddressName") == false)
                    dtShipAddress.Columns.Add("AddressName");
                if (dtShipAddress.Columns.Contains("Address1") == false)
                    dtShipAddress.Columns.Add("Address1");
                if (dtShipAddress.Columns.Contains("Address2") == false)
                    dtShipAddress.Columns.Add("Address2");
                if (dtShipAddress.Columns.Contains("Address3") == false)
                    dtShipAddress.Columns.Add("Address3");
                if (dtShipAddress.Columns.Contains("City") == false)
                    dtShipAddress.Columns.Add("City");
                if (dtShipAddress.Columns.Contains("State") == false)
                    dtShipAddress.Columns.Add("State");
                if (dtShipAddress.Columns.Contains("ZipCode") == false)
                    dtShipAddress.Columns.Add("ZipCode");
                if (dtShipAddress.Columns.Contains("Country") == false)
                    dtShipAddress.Columns.Add("Country");
                if (dtShipAddress.Columns.Contains("Note") == false)
                    dtShipAddress.Columns.Add("Note");
                if (dtShipAddress.Columns.Contains("DefaultShipping") == false)
                    dtShipAddress.Columns.Add("DefaultShipping");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :ShipAddressColumn. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void GetTerms()
        {
            try
            {
                DataTable dtTerms = new BALTerms().Select(new BOLTerms() { });
                DataRow dr = dtTerms.NewRow();
                dr["Name"] = "--Select--";
                dr["ID"] = "0";
                dr["IsActive"] = "0";
                dtTerms.Rows.InsertAt(dr, 0);
                cmbPaymentTerms.DataSource = dtTerms;
                cmbPaymentTerms.DisplayMember = "Name";
                cmbPaymentTerms.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :GetTerms. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        private void GetPaymentMethod()
        {
            try
            {
                DataTable dtPaymentMethod = new BALPaymentMethod().Select(new BOLPaymentMethod() { });
                DataRow dr = dtPaymentMethod.NewRow();
                dr["Name"] = "--Select--";
                dr["ID"] = "0";
                dr["IsActive"] = "0";
                dtPaymentMethod.Rows.InsertAt(dr, 0);
                cmbPaymentMethod.DataSource = dtPaymentMethod;
                cmbPaymentMethod.DisplayMember = "Name";
                cmbPaymentMethod.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :GetPaymentMethod. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void GetSalesRep()
        {
            try
            {
                DataTable dtSalesRep = new BALSalesRepMaster().SelectUser(new BOLSalesRepMaster() { });
                DataRow dr = dtSalesRep.NewRow();
                dr["Name"] = "--Select--";
                dr["ID"] = "0";
                dtSalesRep.Rows.InsertAt(dr, 0);
                cmbSalesrep.DataSource = dtSalesRep;
                cmbSalesrep.DisplayMember = "Name";
                cmbSalesrep.ValueMember = "ID";
                cmbSalesrep.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :GetSalesRep. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void GetParentCustomer()
        {
            try
            {
                DataTable dtCustomer = new BALCustomerMaster().SelectCustomer(new BOLCustomerMaster() { });
                DataRow dr = dtCustomer.NewRow();
                dr["FullName"] = "--Select--";
                dr["ID"] = "0";
                dr["IsActive"] = "0";
                dtCustomer.Rows.InsertAt(dr, 0);
                cmbParentCustomer.DataSource = dtCustomer;
                cmbParentCustomer.DisplayMember = "FullName";
                cmbParentCustomer.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :GetParentCustomer. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private Boolean CheckValidation()
        {
            string email = txtMainEmail.Text;
            string ccemail = txtCCEmail.Text;
            Boolean ISValid = true;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(txtMainEmail.Text);
            Regex regex1 = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match1 = regex1.Match(txtCCEmail.Text);
            string webUrl = txtWebsite.Text;

            try
            {
                if (txtCustomerName.Text == "")
                {
                    ISValid = false;
                    if (lblCustomerName.Text == "JOB NAME")
                    {
                        MessageBox.Show("Please Enter Job Name");
                    }
                    else
                    {
                        MessageBox.Show("Please Enter CustomerName");
                    }
                    txtCustomerName.Focus();
                    goto Final;
                }
                if (cmbSalesrep.SelectedIndex == 0 || cmbSalesrep.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select SalesRep");
                    ISValid = false;
                    cmbSalesrep.Focus();
                    goto Final;
                }
                else if (txtMainPhone.Text != "" && txtMainPhone.TextLength < 10)
                {
                    MessageBox.Show("Please enter 10 digit number");
                    ISValid = false;
                    txtMainPhone.Focus();
                }
                else if (txtWorkPhone.Text != "" && txtWorkPhone.TextLength < 10)
                {
                    MessageBox.Show("Please enter 10 digit number");
                    ISValid = false;
                    txtWorkPhone.Focus();
                }
                else if (txtMobile.Text != "" && txtMobile.TextLength < 10)
                {
                    MessageBox.Show("Please enter 10 digit number");
                    ISValid = false;
                    txtMobile.Focus();
                }
                //if(txtMainEmail.Text != "")
                //{
                //    if (!match.Success)
                //    {
                //        MessageBox.Show("Enter ValidEmail");
                //        txtMainEmail.Clear();
                //        ISValid = false;
                //        txtMainEmail.Focus();
                //    }

                //}
                //if (txtCCEmail.Text != "")
                //{
                //    if (!match1.Success)
                //    {
                //        MessageBox.Show("Enter ValidEmail");
                //        txtCCEmail.Clear();
                //        ISValid = false;
                //        txtCCEmail.Focus();
                //    }

                //}
                else if (txtMainEmail.Text != "" && !match.Success)
                {
                    MessageBox.Show("Enter valid Email");
                    txtMainEmail.Clear();
                    ISValid = false;
                    txtMainEmail.Focus();
                }
                else if (txtCCEmail.Text != "" && !match1.Success)
                {
                    MessageBox.Show("Enter valid Email");
                    txtCCEmail.Clear();
                    ISValid = false;
                    txtCCEmail.Focus();
                }
                if (webUrl != "" && (Regex.IsMatch(webUrl, @"(http|https)://(([www\.])?|([\da-z-\.]+))\.([a-z\.]{2,3})$") == false))
                {
                    MessageBox.Show("Enter valid Website");
                    txtWebsite.Clear();
                    ISValid = false;
                    txtWebsite.Focus();
                }

            Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ISValid = false;
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }

        private Boolean CheckValidationForCreditCardDetails()
        {

            Boolean ISValid = true;

            try
            {

                if (cmbCardType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Card Type in CreditCard details");
                    ISValid = false;
                    cmbCardType.Focus();
                    goto Final;
                }
                else if (txtCardFirstName.Text == "")
                {
                    MessageBox.Show("Please Enter FirstName in CreditCard details");
                    ISValid = false;
                    txtCardFirstName.Focus();
                    goto Final;
                }
                else if (txtCardLastName.Text == "")
                {
                    MessageBox.Show("Please Enter LastName in CreditCard details");
                    ISValid = false;
                    txtCardLastName.Focus();
                    goto Final;
                }
                else if (txtCardNumber.Text == "")
                {
                    MessageBox.Show("Please Enter Card Number in CreditCard details");
                    ISValid = false;
                    txtCardNumber.Focus();
                    goto Final;
                }
                else if (cmbYear.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select year in CreditCard details");
                    ISValid = false;
                    cmbYear.Focus();
                    goto Final;
                }
                else if (cmbMonth.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Month in CreditCard details");
                    ISValid = false;
                    cmbMonth.Focus();
                    goto Final;
                }
                else if (txtCVV.Text == "")
                {
                    MessageBox.Show("Please Enter CVV in CreditCard details");
                    ISValid = false;
                    txtCVV.Focus();
                    goto Final;
                }
                else if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please Enter Address in CreditCard details");
                    ISValid = false;
                    txtAddress.Focus();
                    goto Final;
                }
                else if (txtCity.Text == "")
                {
                    MessageBox.Show("Please Enter City in CreditCard details");
                    ISValid = false;
                    txtCity.Focus();
                    goto Final;
                }
                else if (txtState.Text == "")
                {
                    MessageBox.Show("Please Enter State in CreditCard details");
                    ISValid = false;
                    txtState.Focus();
                    goto Final;
                }
                else if (txtZipCode.Text == "")
                {
                    MessageBox.Show("Please Enter ZipCode in CreditCard details");
                    ISValid = false;
                    txtZipCode.Focus();
                    goto Final;
                }
                else if (txtCountry.Text == "")
                {
                    MessageBox.Show("Please Enter Country in CreditCard details");
                    ISValid = false;
                    txtCountry.Focus();
                    goto Final;
                }
              
            Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ISValid = false;
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :CheckValidationForCreditCardDetails. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }

        public void Clear()
        {
            dtBillAddress = new DataTable();
            dtShipAddress = new DataTable();
            BillAddress = "";
            ShipAddress = "";
            GetShipName();
            txtCustomerName.Text = "";
            txtOpeningBalance.Text = "";
            dtpCreateDate.Value = DateTime.Now;
            txtCompanyName.Text = "";
            txtSaluation.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMiddleName.Text = "";
            txtJobTitle.Text = "";
            txtMainPhone.Text = "";
            txtWorkPhone.Text = "";
            txtMobile.Text = "";
            txtFax.Text = "";
            txtMainEmail.Text = "";
            txtCCEmail.Text = "";
            txtWebsite.Text = "";
            txtOther.Text = "";
            txtBillAddress.Text = "";
            txtShipAddress.Text = "";
            txtAccountNo.Text = "";
            cmbPaymentTerms.SelectedIndex = 0;
            cmbPaymentMethod.SelectedIndex = 0;
            chkIsActive.Checked = false;
            chkDefaultShippingAddress.Checked = false;
            txtRem.Text = "";
            txtPayPalName.Text = "";
            txtPayPalEmail.Text = "";

            txtSalesRepCode.Text = "";

        }

        public void LoadData(string ID)
        {
            try
            {
                ResetCreditCardDetails();
                Clear();
                Mode = "update";
                txtOpeningBalance.ReadOnly = true;
                dtLoadData = new DataTable();
                dtLoadData = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(ID) });
                if (dtLoadData.Rows.Count > 0)
                {
                    txtID.Text = dtLoadData.Rows[0]["ID"].ToString();
                    txtCustomerName.Text = dtLoadData.Rows[0]["CustomerName"].ToString();
                    if (dtLoadData.Rows[0]["ParentID"].ToString() != "" && dtLoadData.Rows[0]["ParentID"].ToString() != "0")
                    {
                        lblParentCustomer.Visible = true;
                        cmbParentCustomer.Visible = true;
                        lblCustomerName.Text = "JOB NAME";
                        cmbParentCustomer.SelectedValue = dtLoadData.Rows[0]["ParentID"].ToString();
                    }
                    txtOpeningBalance.Text = dtLoadData.Rows[0]["TotalBalance"].ToString();
                    if (dtLoadData.Rows[0]["CustomerDate"].ToString() != null && dtLoadData.Rows[0]["CustomerDate"].ToString() != "")
                        dtpCreateDate.Value = Convert.ToDateTime(dtLoadData.Rows[0]["CustomerDate"].ToString());
                    else
                        dtpCreateDate.Value = DateTime.Now;
                    txtCompanyName.Text = dtLoadData.Rows[0]["CompanyName"].ToString();
                    txtSaluation.Text = dtLoadData.Rows[0]["Salutation"].ToString();
                    if (dtLoadData.Rows[0]["Salutation"].ToString() != "")
                        txtSaluation.ForeColor = Color.Black;
                    txtFirstName.Text = dtLoadData.Rows[0]["FirstName"].ToString();
                    if (dtLoadData.Rows[0]["FirstName"].ToString() != "")
                        txtFirstName.ForeColor = Color.Black;
                    txtMiddleName.Text = dtLoadData.Rows[0]["MiddleName"].ToString();
                    if (dtLoadData.Rows[0]["MiddleName"].ToString() != "")
                        txtMiddleName.ForeColor = Color.Black;
                    txtLastName.Text = dtLoadData.Rows[0]["LastName"].ToString();
                    if (dtLoadData.Rows[0]["LastName"].ToString() != "")
                        txtLastName.ForeColor = Color.Black;
                    txtJobTitle.Text = dtLoadData.Rows[0]["JobTitle"].ToString();
                    txtMainPhone.Text = dtLoadData.Rows[0]["Phone"].ToString();
                    txtWorkPhone.Text = dtLoadData.Rows[0]["WorkPhone"].ToString();
                    txtMobile.Text = dtLoadData.Rows[0]["Mobile"].ToString();
                    txtFax.Text = dtLoadData.Rows[0]["Fax"].ToString();
                    txtPayPalEmail.Text = dtLoadData.Rows[0]["PayPalEmail"].ToString();
                    txtPayPalName.Text = dtLoadData.Rows[0]["PayPalName"].ToString();
                    txtRem.Text = dtLoadData.Rows[0]["Remainderday"].ToString();
                    txtMainEmail.Text = dtLoadData.Rows[0]["Email"].ToString();
                    txtCCEmail.Text = dtLoadData.Rows[0]["CcEmail"].ToString();
                    txtWebsite.Text = dtLoadData.Rows[0]["WebSite"].ToString();
                    txtOther.Text = dtLoadData.Rows[0]["Other"].ToString();
                    txtAccountNo.Text = dtLoadData.Rows[0]["AccountNumber"].ToString();
                    if (dtLoadData.Rows[0]["TermsID"].ToString() != null && dtLoadData.Rows[0]["TermsID"].ToString() != "")
                        cmbPaymentTerms.SelectedValue = dtLoadData.Rows[0]["TermsID"].ToString();
                    if (dtLoadData.Rows[0]["PaymentMethodID"].ToString() != null && dtLoadData.Rows[0]["PaymentMethodID"].ToString() != "")
                        cmbPaymentMethod.SelectedValue = dtLoadData.Rows[0]["PaymentMethodID"].ToString();
                    if (dtLoadData.Rows[0]["SalesRepID"].ToString() != null && dtLoadData.Rows[0]["SalesRepID"].ToString() != "")
                        cmbSalesrep.SelectedValue = dtLoadData.Rows[0]["SalesRepID"].ToString();
                    if (dtLoadData.Rows[0]["IsActive"].ToString() == "1")
                        chkIsActive.Checked = false;
                    else
                        chkIsActive.Checked = true;

                    if (dtLoadData.Rows[0]["SalesTaxID"].ToString() != null && dtLoadData.Rows[0]["SalesTaxID"].ToString() != "")
                        cmbSalesTax.SelectedValue = dtLoadData.Rows[0]["SalesTaxID"].ToString();
                    //princy
                    txtSalesRepCode.Text = dtLoadData.Rows[0]["SalesRepCode"].ToString();
                    //

                   

                    DataTable dtAddress = new DataTable();
                    dtAddress = new BALCustomerMaster().SelectByAddressID(new BOLCustomerMaster() { ID = Convert.ToInt32(ID) });
                    if (dtAddress.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtAddress.Rows)
                        {
                            if (dr["AddressType"].ToString() == "B")
                            {
                                if (dtBillAddress.Rows.Count == 0)
                                    BillAddressColumn();
                                DataRow dr1 = dtBillAddress.NewRow();
                                dr1["ID"] = dr["ID"].ToString();

                                if (dr["Address1"].ToString() != null && dr["Address1"].ToString() != "")
                                    dr1["Address1"] = dr["Address1"].ToString();
                                if (dr["Address2"].ToString() != null && dr["Address2"].ToString() != "")
                                    dr1["Address2"] = dr["Address2"].ToString();
                                if (dr["Address3"].ToString() != null && dr["Address3"].ToString() != "")
                                    dr1["Address3"] = dr["Address3"].ToString();
                                if (dr["City"].ToString() != null && dr["City"].ToString() != "")
                                    dr1["City"] = dr["City"].ToString();
                                if (dr["State"].ToString() != null && dr["State"].ToString() != "")
                                    dr1["State"] = dr["State"].ToString();
                                if (dr["PostalCode"].ToString() != null && dr["PostalCode"].ToString() != "")
                                    dr1["ZipCode"] = dr["PostalCode"].ToString();
                                if (dr["Country"].ToString() != null && dr["Country"].ToString() != "")
                                    dr1["Country"] = dr["Country"].ToString();
                                if (dr["Note"].ToString() != null && dr["Note"].ToString() != "")
                                    dr1["Note"] = dr["Note"].ToString();
                                dtBillAddress.Rows.Add(dr1);

                                LoadBillAddrees();
                            }
                            else if (dr["AddressType"].ToString() == "S")
                            {
                                if (dtShipAddress.Rows.Count == 0)
                                    ShipAddressColumn();

                                DataRow dr1 = dtShipAddress.NewRow();
                                dr1["ID"] = dr["ID"].ToString();
                                dr1["AddressName"] = dr["AddressName"].ToString();
                                dr1["DefaultShipping"] = dr["DefaultShipping"].ToString();
                                if (dr["Address1"].ToString() != null && dr["Address1"].ToString() != "")
                                    dr1["Address1"] = dr["Address1"].ToString();
                                if (dr["Address2"].ToString() != null && dr["Address2"].ToString() != "")
                                    dr1["Address2"] = dr["Address2"].ToString();
                                if (dr["Address3"].ToString() != null && dr["Address3"].ToString() != "")
                                    dr1["Address3"] = dr["Address3"].ToString();
                                if (dr["City"].ToString() != null && dr["City"].ToString() != "")
                                    dr1["City"] = dr["City"].ToString();
                                if (dr["State"].ToString() != null && dr["State"].ToString() != "")
                                    dr1["State"] = dr["State"].ToString();
                                if (dr["PostalCode"].ToString() != null && dr["PostalCode"].ToString() != "")
                                    dr1["ZipCode"] = dr["PostalCode"].ToString();
                                if (dr["Country"].ToString() != null && dr["Country"].ToString() != "")
                                    dr1["Country"] = dr["Country"].ToString();
                                if (dr["Note"].ToString() != null && dr["Note"].ToString() != "")
                                    dr1["Note"] = dr["Note"].ToString();
                                dtShipAddress.Rows.Add(dr1);

                            }
                        }
                        GetShipName();
                        ShipAddrress();
                        if (dtShipAddress.Rows.Count > 0)
                        {
                            foreach (DataRow dr3 in dtShipAddress.Rows)
                            {
                                if (dr3["DefaultShipping"].ToString() == "1")
                                {
                                    cmbShipTo.Text = dr3["AddressName"].ToString();
                                    chkDefaultShippingAddress.Checked = true;
                                }
                            }
                        }
                    }

                    DataTable dtCredit = new BALCreditCardDetails().SelectByCustomerID(Convert.ToInt32(txtID.Text));
                    if (dtCredit.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dtCredit.Rows.Count - 1; i++)
                        {
                            DataRow dr = dtCreditCardDetails.NewRow();
                            dr["SrNo"] = dtCredit.Rows[i]["SrNo"].ToString();
                            dr["CustomerID"] = dtCredit.Rows[i]["CustomerID"].ToString();
                            dr["CardType"] = dtCredit.Rows[i]["CardType"].ToString();
                            dr["FirstName"] = dtCredit.Rows[i]["FirstName"].ToString();
                            dr["LastName"] = dtCredit.Rows[i]["LastName"].ToString();
                            dr["CardNumber"] = dtCredit.Rows[i]["CardNumber"].ToString();
                            dr["Year"] = Decrypt(dtCredit.Rows[i]["Year"].ToString());
                            dr["Month"] = Decrypt(dtCredit.Rows[i]["Month"].ToString());
                            dr["CVV"] = Decrypt(dtCredit.Rows[i]["CVV"].ToString());
                            dr["Address"] = dtCredit.Rows[i]["Address"].ToString();
                            dr["City"] = dtCredit.Rows[i]["City"].ToString();
                            dr["State"] = dtCredit.Rows[i]["State"].ToString();
                            dr["ZipCode"] = dtCredit.Rows[i]["ZipCode"].ToString();
                            dr["Country"] = dtCredit.Rows[i]["Country"].ToString();
                            dtCreditCardDetails.Rows.Add(dr);
                        }
                        dgvCreditCard.DataSource = dtCreditCardDetails;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :LoadData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void LoadJobDetails(string ID)
        {
            try
            {
                ResetCreditCardDetails();
                lblParentCustomer.Visible = true;
                cmbParentCustomer.Visible = true;
                lblCustomerName.Text = "JOB NAME";
                GetParentCustomer();
                dtLoadData = new DataTable();
                dtLoadData = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(ID) });
                if (dtLoadData.Rows.Count > 0)
                {
                    txtID.Text = dtLoadData.Rows[0]["ID"].ToString();
                    if (dtLoadData.Rows[0]["CustomerName"].ToString() != "")
                        cmbParentCustomer.SelectedValue = dtLoadData.Rows[0]["ID"].ToString();
                    txtCompanyName.Text = dtLoadData.Rows[0]["CompanyName"].ToString();
                    txtSaluation.Text = dtLoadData.Rows[0]["Salutation"].ToString();
                    if (dtLoadData.Rows[0]["Salutation"].ToString() != "")
                        txtSaluation.ForeColor = Color.Black;
                    txtFirstName.Text = dtLoadData.Rows[0]["FirstName"].ToString();
                    if (dtLoadData.Rows[0]["FirstName"].ToString() != "")
                        txtFirstName.ForeColor = Color.Black;
                    txtMiddleName.Text = dtLoadData.Rows[0]["MiddleName"].ToString();
                    if (dtLoadData.Rows[0]["MiddleName"].ToString() != "")
                        txtMiddleName.ForeColor = Color.Black;
                    txtLastName.Text = dtLoadData.Rows[0]["LastName"].ToString();
                    if (dtLoadData.Rows[0]["LastName"].ToString() != "")
                        txtLastName.ForeColor = Color.Black;
                    txtJobTitle.Text = dtLoadData.Rows[0]["JobTitle"].ToString();
                    txtMainPhone.Text = dtLoadData.Rows[0]["Phone"].ToString();
                    txtWorkPhone.Text = dtLoadData.Rows[0]["WorkPhone"].ToString();
                    txtMobile.Text = dtLoadData.Rows[0]["Mobile"].ToString();
                    txtFax.Text = dtLoadData.Rows[0]["Fax"].ToString();
                    txtMainEmail.Text = dtLoadData.Rows[0]["Email"].ToString();
                    txtCCEmail.Text = dtLoadData.Rows[0]["CcEmail"].ToString();
                    txtWebsite.Text = dtLoadData.Rows[0]["WebSite"].ToString();
                    txtOther.Text = dtLoadData.Rows[0]["Other"].ToString();
                    txtAccountNo.Text = dtLoadData.Rows[0]["AccountNumber"].ToString();
                    if (dtLoadData.Rows[0]["TermsID"].ToString() != null && dtLoadData.Rows[0]["TermsID"].ToString() != "")
                        cmbPaymentTerms.SelectedValue = dtLoadData.Rows[0]["TermsID"].ToString();
                    if (dtLoadData.Rows[0]["PaymentMethodID"].ToString() != null && dtLoadData.Rows[0]["PaymentMethodID"].ToString() != "")
                        cmbPaymentMethod.SelectedValue = dtLoadData.Rows[0]["PaymentMethodID"].ToString();
                    if (dtLoadData.Rows[0]["SalesRepID"].ToString() != null && dtLoadData.Rows[0]["SalesRepID"].ToString() != "")
                        cmbSalesrep.SelectedValue = dtLoadData.Rows[0]["SalesRepID"].ToString();
                    //princy
                    txtSalesRepCode.Text = dtLoadData.Rows[0]["SalesRepCode"].ToString();
                    //
                    DataTable dtAddress = new DataTable();
                    dtAddress = new BALCustomerMaster().SelectByAddressID(new BOLCustomerMaster() { ID = Convert.ToInt32(ID) });
                    if (dtAddress.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtAddress.Rows)
                        {
                            if (dr["AddressType"].ToString() == "B")
                            {
                                if (dtBillAddress.Rows.Count == 0)
                                    BillAddressColumn();
                                DataRow dr1 = dtBillAddress.NewRow();
                                dr1["ID"] = dtBillAddress.Rows.Count + 1;

                                if (dr["Address1"].ToString() != null && dr["Address1"].ToString() != "")
                                    dr1["Address1"] = dr["Address1"].ToString();
                                if (dr["Address2"].ToString() != null && dr["Address2"].ToString() != "")
                                    dr1["Address2"] = dr["Address2"].ToString();
                                if (dr["Address3"].ToString() != null && dr["Address3"].ToString() != "")
                                    dr1["Address3"] = dr["Address3"].ToString();
                                if (dr["City"].ToString() != null && dr["City"].ToString() != "")
                                    dr1["City"] = dr["City"].ToString();
                                if (dr["State"].ToString() != null && dr["State"].ToString() != "")
                                    dr1["State"] = dr["State"].ToString();
                                if (dr["PostalCode"].ToString() != null && dr["PostalCode"].ToString() != "")
                                    dr1["ZipCode"] = dr["PostalCode"].ToString();
                                if (dr["Country"].ToString() != null && dr["Country"].ToString() != "")
                                    dr1["Country"] = dr["Country"].ToString();
                                if (dr["Note"].ToString() != null && dr["Note"].ToString() != "")
                                    dr1["Note"] = dr["Note"].ToString();
                                dtBillAddress.Rows.Add(dr1);

                                LoadBillAddrees();
                            }
                            else if (dr["AddressType"].ToString() == "S")
                            {
                                if (dtShipAddress.Rows.Count == 0)
                                    ShipAddressColumn();
                                DataRow dr1 = dtShipAddress.NewRow();
                                dr1["ID"] = dtShipAddress.Rows.Count + 1;
                                dr1["AddressName"] = dr["AddressName"].ToString();
                                dr1["DefaultShipping"] = dr["DefaultShipping"].ToString();
                                if (dr["Address1"].ToString() != null && dr["Address1"].ToString() != "")
                                    dr1["Address1"] = dr["Address1"].ToString();
                                if (dr["Address2"].ToString() != null && dr["Address2"].ToString() != "")
                                    dr1["Address2"] = dr["Address2"].ToString();
                                if (dr["Address3"].ToString() != null && dr["Address3"].ToString() != "")
                                    dr1["Address3"] = dr["Address3"].ToString();
                                if (dr["City"].ToString() != null && dr["City"].ToString() != "")
                                    dr1["City"] = dr["City"].ToString();
                                if (dr["State"].ToString() != null && dr["State"].ToString() != "")
                                    dr1["State"] = dr["State"].ToString();
                                if (dr["PostalCode"].ToString() != null && dr["PostalCode"].ToString() != "")
                                    dr1["ZipCode"] = dr["PostalCode"].ToString();
                                if (dr["Country"].ToString() != null && dr["Country"].ToString() != "")
                                    dr1["Country"] = dr["Country"].ToString();
                                if (dr["Note"].ToString() != null && dr["Note"].ToString() != "")
                                    dr1["Note"] = dr["Note"].ToString();
                                dtShipAddress.Rows.Add(dr1);
                                GetShipName();
                                ShipAddrress();
                            }
                        }
                    }
                    cmbShipTo.SelectedIndex = -1;
                    txtShipAddress.Text = ""; txtShipAddress.ReadOnly = true;
                    btnEditShippingAdd.Enabled = false;
                    btnDeletShippingAdd.Enabled = false;
                    chkDefaultShippingAddress.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :LoadJobDetails. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void SaveAddress(int CusID)
        {
            try
            {
                // BillAddress
                if (dtBillAddress.Rows.Count > 0)
                {
                    foreach (DataRow dr1 in dtBillAddress.Rows)
                    {
                        ObjAddressBOL.ID = Convert.ToInt32(dr1["ID"].ToString());
                        ObjAddressBOL.ReferenceID = CusID;
                        ObjAddressBOL.ReferenceType = "Customer";
                        ObjAddressBOL.AddressType = "B";
                        ObjAddressBOL.Address1 = dr1["Address1"].ToString();
                        ObjAddressBOL.Address2 = dr1["Address2"].ToString();
                        ObjAddressBOL.Address3 = dr1["Address3"].ToString();
                        ObjAddressBOL.City = dr1["City"].ToString();
                        ObjAddressBOL.State = dr1["State"].ToString();
                        ObjAddressBOL.PostalCode = dr1["ZipCode"].ToString();
                        ObjAddressBOL.Country = dr1["Country"].ToString();
                        ObjAddressBOL.Note = dr1["Note"].ToString();
                        ObjAddressBOL.CreatedTime = DateTime.Now;
                        ObjAddressBOL.ModifiedTime = DateTime.Now;
                        ObjAddressBOL.CreatedID = ClsCommon.UserID;

                        ObjAddressBAL.CustomerBillAddressInsert(ObjAddressBOL);
                    }
                }

                // Ship Address
                if (dtShipAddress.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtShipAddress.Rows)
                    {
                        ObjAddressBOL.ID = Convert.ToInt32(dr["ID"].ToString());
                        ObjAddressBOL.ReferenceID = CusID;
                        ObjAddressBOL.ReferenceType = "Customer";
                        ObjAddressBOL.AddressType = "S";
                        ObjAddressBOL.AddressName = dr["AddressName"].ToString();
                        ObjAddressBOL.Address1 = dr["Address1"].ToString();
                        ObjAddressBOL.Address2 = dr["Address2"].ToString();
                        ObjAddressBOL.Address3 = dr["Address3"].ToString();
                        ObjAddressBOL.City = dr["City"].ToString();
                        ObjAddressBOL.State = dr["State"].ToString();
                        ObjAddressBOL.PostalCode = dr["ZipCode"].ToString();
                        ObjAddressBOL.Country = dr["Country"].ToString();
                        ObjAddressBOL.Note = dr["Note"].ToString();
                        if (dr["DefaultShipping"].ToString() == "")
                            ObjAddressBOL.DefaultShipping = 0;
                        else
                            ObjAddressBOL.DefaultShipping = Convert.ToInt32(dr["DefaultShipping"].ToString());
                        ObjAddressBOL.CreatedTime = DateTime.Now;
                        ObjAddressBOL.ModifiedTime = DateTime.Now;
                        ObjAddressBOL.CreatedID = ClsCommon.UserID;

                        ObjAddressBAL.CustomerShipAddressInsert(ObjAddressBOL);
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :SaveAddress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataTable dtCus = new DataTable();
            try
            {
                CusID = 0;
                if (CheckValidation())
                {
                    if (Mode == "insert")
                    {
                        DataTable dt = new BALCustomerMaster().SelectByFullName(new BOLCustomerMaster() { FullName = txtCustomerName.Text.Trim() });
                        if (dt.Rows.Count == 0)
                        {
                            ObjCustomerBOL = new BOLCustomerMaster();
                            ObjCustomerBOL.CustomerName = txtCustomerName.Text;
                            ObjCustomerBOL.FullName = txtCustomerName.Text;
                            ObjCustomerBOL.ParentID = 0;
                            ObjCustomerBOL.CompanyName = txtCompanyName.Text;
                            ObjCustomerBOL.CustomerDate = dtpCreateDate.Value;
                            if (txtSaluation.Text != "Mr./Ms./..")
                                ObjCustomerBOL.Salutation = txtSaluation.Text;
                            if (txtFirstName.Text != "First")
                                ObjCustomerBOL.FirstName = txtFirstName.Text;
                            if (txtMiddleName.Text != "M.I.")
                                ObjCustomerBOL.MiddleName = txtMiddleName.Text;
                            if (txtLastName.Text != "Last")
                                ObjCustomerBOL.LastName = txtLastName.Text;
                            ObjCustomerBOL.JobTitle = txtJobTitle.Text;
                            ObjCustomerBOL.Phone = txtMainPhone.Text;
                            ObjCustomerBOL.Mobile = txtMobile.Text;
                            ObjCustomerBOL.Fax = txtFax.Text;
                            ObjCustomerBOL.Email = txtMainEmail.Text;
                            ObjCustomerBOL.CcEmail = txtCCEmail.Text;
                            ObjCustomerBOL.Other = txtOther.Text;
                            ObjCustomerBOL.WorkPhone = txtWorkPhone.Text;
                            ObjCustomerBOL.WebSite = txtWebsite.Text;
                            if (txtRem.Text != "")
                            {
                                ObjCustomerBOL.Remainderday = Convert.ToInt32(txtRem.Text);
                            }

                            if (txtOpeningBalance.Text != "")
                            {
                                ObjCustomerBOL.Balance = Convert.ToDecimal(txtOpeningBalance.Text);
                                ObjCustomerBOL.TotalBalance = Convert.ToDecimal(txtOpeningBalance.Text);
                            }
                            else
                            {
                                ObjCustomerBOL.Balance = 0;
                                ObjCustomerBOL.TotalBalance = 0;
                            }
                            ObjCustomerBOL.AccountNumber = txtAccountNo.Text;
                            ObjCustomerBOL.TermsID = Convert.ToInt32(cmbPaymentTerms.SelectedValue);
                            ObjCustomerBOL.PaymentMethodID = Convert.ToInt32(cmbPaymentMethod.SelectedValue);
                            ObjCustomerBOL.SalesRepID = Convert.ToInt32(cmbSalesrep.SelectedValue);
                            ObjCustomerBOL.CreatedID = ClsCommon.UserID;
                            ObjCustomerBOL.CreatedTime = DateTime.Now;
                            ObjCustomerBOL.ModifiedTime = DateTime.Now;
                            ObjCustomerBOL.IsSync = 0;
                            ObjCustomerBOL.PayPalEmail = txtPayPalEmail.Text;
                            ObjCustomerBOL.PayPalName = txtPayPalName.Text;
                            ObjCustomerBOL.AllowLowestPrice = 1;
                            //princy add

                            ObjCustomerBOL.SalesRepCode = txtSalesRepCode.Text;

                            //
                            if (chkIsActive.Checked == false)
                                ObjCustomerBOL.IsActive = 1;
                            else
                                ObjCustomerBOL.IsActive = 0;


                            // Hiren
                            ObjCustomerBOL.SalesTaxID = Convert.ToInt32(cmbSalesTax.SelectedValue);
                            //

                            CusID = ObjCustomerBAL.Insert(ObjCustomerBOL);

                            for (int i = 0; i < dgvCreditCard.Rows.Count; i++)
                            {
                                try
                                {

                                    BOLCreditCardDetails.CustomerID = CusID;
                                    BOLCreditCardDetails.SrNo = Convert.ToInt32(dgvCreditCard.Rows[i].Cells["SrNo"].Value.ToString());
                                    BOLCreditCardDetails.CardType = dgvCreditCard.Rows[i].Cells["CardType"].Value.ToString();
                                    BOLCreditCardDetails.FirstName = dgvCreditCard.Rows[i].Cells["FirstName"].Value.ToString();
                                    BOLCreditCardDetails.LastName = dgvCreditCard.Rows[i].Cells["LastName"].Value.ToString();
                                    BOLCreditCardDetails.CardNumber = dgvCreditCard.Rows[i].Cells["CardNumber"].Value.ToString();
                                    BOLCreditCardDetails.Year = Encrypt(dgvCreditCard.Rows[i].Cells["Year"].Value.ToString());
                                    BOLCreditCardDetails.Month = Encrypt(dgvCreditCard.Rows[i].Cells["Month"].Value.ToString());
                                    BOLCreditCardDetails.CVV = Encrypt(dgvCreditCard.Rows[i].Cells["CVV"].Value.ToString());
                                    BOLCreditCardDetails.Address = dgvCreditCard.Rows[i].Cells["Address"].Value.ToString();
                                    BOLCreditCardDetails.City = dgvCreditCard.Rows[i].Cells["City"].Value.ToString();
                                    BOLCreditCardDetails.State = dgvCreditCard.Rows[i].Cells["State"].Value.ToString();
                                    BOLCreditCardDetails.ZipCode = dgvCreditCard.Rows[i].Cells["ZipCode"].Value.ToString();
                                    BOLCreditCardDetails.Country = dgvCreditCard.Rows[i].Cells["Country"].Value.ToString();
                                    BALCreditCardDetails.Insert(BOLCreditCardDetails);
                                }
                                catch (Exception ex)
                                {
                                    ClsCommon.WriteErrorLogs("Error In Insert CreditData :-" + ex.Message);
                                }
                            }



                            //new add customer
                            string result = Regex.Replace(txtCustomerName.Text, @"[^\d]", "");
                            if (result == "")
                            {
                                ObjCustomerBOL.CustomerName = txtCustomerName.Text;
                            }
                            else
                            {
                                ObjCustomerBOL.CustomerName = result;
                            }
                            ObjCustomerBOL.PosID = CusID;
                            ObjCustomerBAL.NewInsert(ObjCustomerBOL);
                            SaveAddress(CusID);
                            MessageBox.Show("Record save successfully");
                            this.Close();
                            ClsCommon.ObjCustomerCenter.LoadCustomer();
                            //int id1 = Convert.ToInt32(CusID);
                            //ClsCommon.ObjCustomerCenter.LoadCustomerData(id1);
                            ClsCommon.ObjInvoiceMaster.GetCustomer();
                            //princy 08-04-2025
                            ClsCommon.ObjCreditMemo.GetCustomer();

                            //princy add
                            if (CustomerNameUpdated != null)
                            {
                                CustomerNameUpdated(txtCustomerName.Text); 
                            }
                            //
                            Clear();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Duplicate name not allow");
                        }
                    }

                    else if (Mode == "insert Job")
                    {
                        DataTable dt = new BALCustomerMaster().SelectByFullName(new BOLCustomerMaster() { FullName = cmbParentCustomer.Text.Trim() + ":" + txtCustomerName.Text.Trim() });
                        if (dt.Rows.Count == 0)
                        {
                            if (cmbParentCustomer.SelectedIndex != 0)
                            {
                                ObjCustomerBOL = new BOLCustomerMaster();
                                ObjCustomerBOL.CustomerName = txtCustomerName.Text.Trim();
                                ObjCustomerBOL.FullName = cmbParentCustomer.Text.Trim() + ":" + txtCustomerName.Text.Trim();
                                ObjCustomerBOL.ParentID = Convert.ToInt32(cmbParentCustomer.SelectedValue);
                                ObjCustomerBOL.CompanyName = txtCompanyName.Text;
                                ObjCustomerBOL.CustomerDate = dtpCreateDate.Value;
                                if (txtSaluation.Text != "Mr./Ms./..")
                                    ObjCustomerBOL.Salutation = txtSaluation.Text;
                                if (txtFirstName.Text != "First")
                                    ObjCustomerBOL.FirstName = txtFirstName.Text;
                                if (txtMiddleName.Text != "M.I.")
                                    ObjCustomerBOL.MiddleName = txtMiddleName.Text;
                                if (txtLastName.Text != "Last")
                                    ObjCustomerBOL.LastName = txtLastName.Text;
                                ObjCustomerBOL.JobTitle = txtJobTitle.Text;
                                ObjCustomerBOL.Phone = txtMainPhone.Text;
                                ObjCustomerBOL.Mobile = txtMobile.Text;
                                ObjCustomerBOL.Fax = txtFax.Text;
                                ObjCustomerBOL.Email = txtMainEmail.Text;
                                ObjCustomerBOL.CcEmail = txtCCEmail.Text;
                                ObjCustomerBOL.Other = txtOther.Text;
                                ObjCustomerBOL.WorkPhone = txtWorkPhone.Text;
                                ObjCustomerBOL.WebSite = txtWebsite.Text;
                                ObjCustomerBOL.PayPalEmail = txtPayPalEmail.Text;
                                ObjCustomerBOL.PayPalName = txtPayPalName.Text;
                                if (txtRem.Text != "")
                                {
                                    ObjCustomerBOL.Remainderday = Convert.ToInt32(txtRem.Text);
                                }
                                if (txtOpeningBalance.Text != "")
                                {
                                    ObjCustomerBOL.Balance = Convert.ToDecimal(txtOpeningBalance.Text);
                                    ObjCustomerBOL.TotalBalance = Convert.ToDecimal(txtOpeningBalance.Text);
                                }
                                else
                                {
                                    ObjCustomerBOL.Balance = 0;
                                    ObjCustomerBOL.TotalBalance = 0;
                                }
                                ObjCustomerBOL.AccountNumber = txtAccountNo.Text;
                                ObjCustomerBOL.TermsID = Convert.ToInt32(cmbPaymentTerms.SelectedValue);
                                ObjCustomerBOL.PaymentMethodID = Convert.ToInt32(cmbPaymentMethod.SelectedValue);
                                ObjCustomerBOL.SalesRepID = Convert.ToInt32(cmbSalesrep.SelectedValue);
                                ObjCustomerBOL.CreatedID = ClsCommon.UserID;
                                ObjCustomerBOL.CreatedTime = DateTime.Now;
                                ObjCustomerBOL.ModifiedTime = DateTime.Now;
                                ObjCustomerBOL.IsSync = 0;
                                ObjCustomerBOL.AllowLowestPrice = 1;
                                //princy add
                                ObjCustomerBOL.SalesRepCode = txtSalesRepCode.Text;
                                //                                                                           
                                if (chkIsActive.Checked == false)
                                    ObjCustomerBOL.IsActive = 1;
                                else
                                    ObjCustomerBOL.IsActive = 0;

                                CusID = ObjCustomerBAL.Insert(ObjCustomerBOL);

                                for (int i = 0; i < dgvCreditCard.Rows.Count; i++)
                                {
                                    try
                                    {
                                        BOLCreditCardDetails.CustomerID = CusID;
                                        BOLCreditCardDetails.SrNo = Convert.ToInt32(dgvCreditCard.Rows[i].Cells["SrNo"].Value.ToString());
                                        BOLCreditCardDetails.CardType = dgvCreditCard.Rows[i].Cells["CardType"].Value.ToString();
                                        BOLCreditCardDetails.FirstName = dgvCreditCard.Rows[i].Cells["FirstName"].Value.ToString();
                                        BOLCreditCardDetails.LastName = dgvCreditCard.Rows[i].Cells["LastName"].Value.ToString();
                                        BOLCreditCardDetails.CardNumber = dgvCreditCard.Rows[i].Cells["CardNumber"].Value.ToString();
                                        BOLCreditCardDetails.Year = Encrypt(dgvCreditCard.Rows[i].Cells["Year"].Value.ToString());
                                        BOLCreditCardDetails.Month = Encrypt(dgvCreditCard.Rows[i].Cells["Month"].Value.ToString());
                                        BOLCreditCardDetails.CVV = Encrypt(dgvCreditCard.Rows[i].Cells["CVV"].Value.ToString());
                                        BOLCreditCardDetails.Address = dgvCreditCard.Rows[i].Cells["Address"].Value.ToString();
                                        BOLCreditCardDetails.City = dgvCreditCard.Rows[i].Cells["City"].Value.ToString();
                                        BOLCreditCardDetails.State = dgvCreditCard.Rows[i].Cells["State"].Value.ToString();
                                        BOLCreditCardDetails.ZipCode = dgvCreditCard.Rows[i].Cells["ZipCode"].Value.ToString();
                                        BOLCreditCardDetails.Country = dgvCreditCard.Rows[i].Cells["Country"].Value.ToString();
                                        BALCreditCardDetails.Insert(BOLCreditCardDetails);
                                    }
                                    catch (Exception ex)
                                    {
                                        ClsCommon.WriteErrorLogs("Error In Insert CreditData :-" + ex.Message);
                                    }
                                }



                                //new add customer
                                string result = Regex.Replace(txtCustomerName.Text, @"[^\d]", "");
                                if (result == "")
                                {
                                    ObjCustomerBOL.CustomerName = txtCustomerName.Text;
                                }
                                else
                                {
                                    ObjCustomerBOL.CustomerName = result;
                                }
                                ObjCustomerBOL.PosID = CusID;
                                ObjCustomerBAL.NewInsert(ObjCustomerBOL);



                                SaveAddress(CusID);
                                //Child Customer Assign
                                DataTable dtCusAssign = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbParentCustomer.SelectedValue) });
                                if (dtCusAssign.Rows.Count > 0)
                                {
                                    ObjCustomerBOL.ID = CusID;
                                    ObjCustomerBOL.SalesRepID = Convert.ToInt32(dtCusAssign.Rows[0]["SalesRepID"].ToString());
                                    ObjCustomerBAL.UpdateSalesRepID(ObjCustomerBOL);
                                }
                                MessageBox.Show("Record save successfully");
                                ClsCommon.ObjCustomerCenter.LoadFunction();
                                ClsCommon.ObjInvoiceMaster.GetCustomer();
                               //princyb 08-04-2025
                                ClsCommon.ObjCreditMemo.GetCustomer();

                                ClsCommon.ObjCustomerCenter.LoadCustomer();
                                this.Close();
                                Clear();
                            }
                            else
                                MessageBox.Show("Please Select ParentCustomer");
                        }
                        else
                        {
                            MessageBox.Show("Duplicate name not allow");
                        }
                    }

                    else
                    {

                        // Update Customer
                        ObjCustomerBOL = new BOLCustomerMaster();
                        ObjCustomerBOL.ID = Convert.ToInt32(txtID.Text);
                        ObjCustomerBOL.CustomerName = txtCustomerName.Text;
                        if (cmbParentCustomer.SelectedIndex != 0)
                        {
                            ObjCustomerBOL.FullName = cmbParentCustomer.Text.Trim() + ":" + txtCustomerName.Text.Trim();
                            ObjCustomerBOL.ParentID = Convert.ToInt32(cmbParentCustomer.SelectedValue);
                        }
                        else
                        {
                            ObjCustomerBOL.FullName = txtCustomerName.Text;
                            ObjCustomerBOL.ParentID = 0;
                        }

                        DataTable dt = new BALCustomerMaster().SelectByFullName(new BOLCustomerMaster() { FullName = txtCustomerName.Text.Trim() });
                        if (dt.Rows.Count > 1)
                        {
                            FrmMergeCustomer f1 = new FrmMergeCustomer();
                            f1.CustomerID = Convert.ToInt32(txtID.Text);
                            f1.display(dt);
                            f1.Show();
                        }
                        else if (dt.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(dt.Rows[0]["ID"]) != Convert.ToInt32(txtID.Text))
                            {

                                var dialogResult = MessageBox.Show("The name is already being used.whould you like to merge them?", "Confirm!!", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {

                                    objInvBOL = new BOLInvoiceMaster();
                                    objInvBOL.CustomerID = Convert.ToInt32(txtID.Text);
                                    objInvBOL.OldCustomerID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                                    objInvBAL.UpdateCustomer(objInvBOL);

                                    BOLCreditMemo ObjCreditmemo = new BOLCreditMemo();
                                    BALCreditMemo ObjCreditmemoBal = new BALCreditMemo();
                                    ObjCreditmemo.CustomerID = Convert.ToInt32(txtID.Text);
                                    ObjCreditmemo.OldCustomerID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                                    ObjCreditmemoBal.UpdateCustomer(ObjCreditmemo);


                                    ObjCustomerBAL.UpdateCustomer(Convert.ToInt32(txtID.Text));
                                    ClsCommon.ObjCustomerCenter.LoadCustomer();
                                    this.Close();
                                }
                                else
                                {
                                    txtCustomerName.Focus();
                                }

                            }
                            else
                            {
                                UpdateCustomer();
                            }
                        }
                        else
                        {
                            UpdateCustomer();
                        }
                    }
                    //ClsCommon.ObjCustomerCenter.LoadCustomer();
                }
                else
                {
                    ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :btnOK_Click. Message: Error Create Customer Data");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :btnOK_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public static string HashPassword(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        public static string Encrypt(string data)
        {
            try
            {
                for (int i = 0; i < key.Length; i++)
                {
                    using (Aes aesAlg = Aes.Create())
                    {
                        aesAlg.Key = Encoding.UTF8.GetBytes(DecodeFrom64(key[i]).PadRight(32));
                        aesAlg.IV = new byte[16]; // Assuming initialization vector is not included in the encrypted text and is all zeros
                        aesAlg.Mode = CipherMode.CBC; // Using Cipher Block Chaining (CBC) mode
                        aesAlg.Padding = PaddingMode.PKCS7; // Using PKCS7 padding
                        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                        byte[] encryptedBytes = encryptor.TransformFinalBlock(dataBytes, 0, dataBytes.Length);
                        data = Convert.ToBase64String(encryptedBytes);
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public static string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new System.String(decoded_char);
            return result;
        }
        public static string Decrypt(string encryptedText)
        {
            try
            {
                for (int i = key.Length - 1; i >= 0; i--)
                {
                    byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                    using (Aes aesAlg = Aes.Create())
                    {
                        aesAlg.Key = Encoding.UTF8.GetBytes(DecodeFrom64(key[i]).PadRight(32));
                        aesAlg.IV = new byte[16]; // Assuming initialization vector is not included in the encrypted text and is all zeros
                        aesAlg.Mode = CipherMode.CBC; // Using Cipher Block Chaining (CBC) mode
                        aesAlg.Padding = PaddingMode.PKCS7; // Using PKCS7 padding
                        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                        byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                        encryptedText = Encoding.UTF8.GetString(decryptedBytes).Trim('"');
                    }
                }
                return encryptedText;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public void UpdatesLogs()
        {
            objBOLLog = new BOLCustomerMaster_Update();
            {
                DataTable dtNewCus = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(txtID.Text) });
                if (dtNewCus.Rows.Count > 0)
                {
                    if (txtFirstName.Text == "First")
                    {
                        txtFirstName.Text = "";
                    }
                    if (txtMiddleName.Text == "M.I.")
                    {
                        txtMiddleName.Text = "";
                    }
                    if (txtLastName.Text == "Last")
                    {
                        txtLastName.Text = "";
                    }
                    if (txtSaluation.Text == "Mr./Ms./..")
                    {
                        txtSaluation.Text = "";
                    }
                    objBOLLog.OldCustomerName = dtNewCus.Rows[0]["CustomerName"].ToString();
                    objBOLLog.NewCustomerName = objBOLLog.OldCustomerName != txtCustomerName.Text ? txtCustomerName.Text : null;

                    //objBOLLog.OldFullName = dtNewCus.Rows[0]["FullName"].ToString();
                    //objBOLLog.NewFullName = objBOLLog.OldFullName != txtCustomerName.Text ? txtCustomerName.Text : null;

                    objBOLLog.OldSalutation = dtNewCus.Rows[0]["Salutation"].ToString();
                    objBOLLog.NewSalutation = objBOLLog.OldSalutation != txtSaluation.Text ? txtSaluation.Text : null;

                    objBOLLog.OldFirstName = dtNewCus.Rows[0]["FirstName"].ToString();


                    objBOLLog.NewFirstName = objBOLLog.OldFirstName != txtFirstName.Text ? txtFirstName.Text : null;

                    objBOLLog.OldMiddleName = dtNewCus.Rows[0]["MiddleName"].ToString();
                    objBOLLog.NewMiddleName = objBOLLog.OldMiddleName != txtMiddleName.Text ? txtMiddleName.Text : null;

                    objBOLLog.OldLastName = dtNewCus.Rows[0]["LastName"].ToString();
                    objBOLLog.NewLastName = objBOLLog.OldLastName != txtLastName.Text ? txtLastName.Text : null;



                    if (objBOLLog.NewCustomerName == null && objBOLLog.OldCustomerName == txtCustomerName.Text)
                        objBOLLog.OldCustomerName = null;

                    if (objBOLLog.NewSalutation == null && objBOLLog.OldSalutation == txtSaluation.Text)
                        objBOLLog.OldSalutation = null;

                    if (objBOLLog.NewFirstName == null && objBOLLog.OldFirstName == txtFirstName.Text)
                        objBOLLog.OldFirstName = null;

                    if (objBOLLog.NewMiddleName == null && objBOLLog.OldMiddleName == txtMiddleName.Text)
                        objBOLLog.OldMiddleName = null;

                    if (objBOLLog.NewLastName == null && objBOLLog.OldLastName == txtLastName.Text)
                        objBOLLog.OldLastName = null;


                    //if ((objBOLLog.NewCustomerName != null && objBOLLog.NewCustomerName != "") || (objBOLLog.NewSalutation != null && objBOLLog.NewSalutation != "") || (objBOLLog.NewFirstName != null && objBOLLog.NewFirstName != "") || (objBOLLog.NewMiddleName != null && objBOLLog.NewMiddleName != "") || (objBOLLog.NewLastName != null && objBOLLog.NewLastName != ""))
                    //{
                    //    objBOLLog.NewCustomerName = txtCustomerName.Text;
                    //    objBOLLog.CustomerID = Convert.ToInt32(txtID.Text);
                    //    objBOLLog.UpdateDate = DateTime.Now.ToString();
                    //    objBALLog.Insert(objBOLLog);
                    //}
                    if (objBOLLog.NewCustomerName != null || objBOLLog.NewSalutation != null || objBOLLog.NewFirstName != null || objBOLLog.NewMiddleName != null || objBOLLog.NewLastName != null)
                    {
                        objBOLLog.NewCustomerName = txtCustomerName.Text;
                        objBOLLog.CustomerID = Convert.ToInt32(txtID.Text);
                        objBOLLog.UpdateDate = DateTime.Now.ToString();
                        objBALLog.Insert(objBOLLog);
                    }
                }
            }
        }


        private void UpdateCustomer()
        {
            DataTable dtCus = new DataTable();
            try
            {
                UpdatesLogs();
                ObjCustomerBOL.CompanyName = txtCompanyName.Text;
                ObjCustomerBOL.CustomerDate = dtpCreateDate.Value;
                if (txtSaluation.Text != "Mr./Ms./..")
                    ObjCustomerBOL.Salutation = txtSaluation.Text;
                if (txtFirstName.Text != "First")
                    ObjCustomerBOL.FirstName = txtFirstName.Text;
                if (txtMiddleName.Text != "M.I.")
                    ObjCustomerBOL.MiddleName = txtMiddleName.Text;
                if (txtLastName.Text != "Last")
                    ObjCustomerBOL.LastName = txtLastName.Text;
                ObjCustomerBOL.JobTitle = txtJobTitle.Text;
                ObjCustomerBOL.Phone = txtMainPhone.Text;
                ObjCustomerBOL.Mobile = txtMobile.Text;
                ObjCustomerBOL.Fax = txtFax.Text;
                ObjCustomerBOL.Email = txtMainEmail.Text;
                ObjCustomerBOL.CcEmail = txtCCEmail.Text;
                ObjCustomerBOL.Other = txtOther.Text;
                ObjCustomerBOL.WorkPhone = txtWorkPhone.Text;
                ObjCustomerBOL.WebSite = txtWebsite.Text;
                ObjCustomerBOL.AccountNumber = txtAccountNo.Text;
                ObjCustomerBOL.TermsID = Convert.ToInt32(cmbPaymentTerms.SelectedValue);
                ObjCustomerBOL.PaymentMethodID = Convert.ToInt32(cmbPaymentMethod.SelectedValue);
                ObjCustomerBOL.SalesRepID = Convert.ToInt32(cmbSalesrep.SelectedValue);
                ObjCustomerBOL.ModifiedID = ClsCommon.UserID;
                ObjCustomerBOL.ModifiedTime = DateTime.Now;
                ObjCustomerBOL.PayPalEmail = txtPayPalEmail.Text;
                ObjCustomerBOL.PayPalName = txtPayPalName.Text;
                if (txtRem.Text != "")
                {
                    ObjCustomerBOL.Remainderday = Convert.ToInt32(txtRem.Text);
                }
                //princy add
                ObjCustomerBOL.SalesRepCode = txtSalesRepCode.Text;
                //  
                ObjCustomerBOL.IsSync = 0;

                if (chkIsActive.Checked == false)
                    ObjCustomerBOL.IsActive = 1;
                else
                    ObjCustomerBOL.IsActive = 0;

                // Hiren
                ObjCustomerBOL.SalesTaxID = Convert.ToInt32(cmbSalesTax.SelectedValue);
                //

                CusID = ObjCustomerBAL.Update(ObjCustomerBOL);


                for (int i = 0; i < dgvCreditCard.Rows.Count; i++)
                {
                    try
                    {
                        BOLCreditCardDetails.CustomerID = CusID;
                        BOLCreditCardDetails.SrNo = Convert.ToInt32(dgvCreditCard.Rows[i].Cells["SrNo"].Value.ToString());
                        BOLCreditCardDetails.CardType = dgvCreditCard.Rows[i].Cells["CardType"].Value.ToString();
                        BOLCreditCardDetails.FirstName = dgvCreditCard.Rows[i].Cells["FirstName"].Value.ToString();
                        BOLCreditCardDetails.LastName = dgvCreditCard.Rows[i].Cells["LastName"].Value.ToString();
                        BOLCreditCardDetails.CardNumber = dgvCreditCard.Rows[i].Cells["CardNumber"].Value.ToString();
                        BOLCreditCardDetails.Year = Encrypt(dgvCreditCard.Rows[i].Cells["Year"].Value.ToString());
                        BOLCreditCardDetails.Month = Encrypt(dgvCreditCard.Rows[i].Cells["Month"].Value.ToString());
                        BOLCreditCardDetails.CVV = Encrypt(dgvCreditCard.Rows[i].Cells["CVV"].Value.ToString());
                        BOLCreditCardDetails.Address = dgvCreditCard.Rows[i].Cells["Address"].Value.ToString();
                        BOLCreditCardDetails.City = dgvCreditCard.Rows[i].Cells["City"].Value.ToString();
                        BOLCreditCardDetails.State = dgvCreditCard.Rows[i].Cells["State"].Value.ToString();
                        BOLCreditCardDetails.ZipCode = dgvCreditCard.Rows[i].Cells["ZipCode"].Value.ToString();
                        BOLCreditCardDetails.Country = dgvCreditCard.Rows[i].Cells["Country"].Value.ToString();
                        BALCreditCardDetails.Insert(BOLCreditCardDetails);
                    }
                    catch (Exception ex)
                    {
                        ClsCommon.WriteErrorLogs("Error In Insert CreditData :-" + ex.Message);
                    }
                }




                //new customer update
                string result = Regex.Replace(txtCustomerName.Text, @"[^\d]", "");
                if (result == "")
                {
                    ObjCustomerBOL.CustomerName = txtCustomerName.Text;
                }
                else
                {
                    ObjCustomerBOL.CustomerName = result;
                }
                ObjCustomerBOL.PosID = CusID;
                ObjCustomerBAL.NewUpdate(ObjCustomerBOL);


                if (txtRem.Text == "" || txtRem.Text == "0")
                {
                    dtCus = objCusReqBAL.SelectByCusID(CusID.ToString());
                    if (dtCus.Rows.Count > 0)
                    {
                        objCusReqBAL.DeleteRequest(CusID.ToString());
                    }

                }


                //Delete BillAddress
                ObjAddressBOL.ReferenceID = Convert.ToInt32(txtID.Text);

                SaveAddress(CusID);
                // CustomerName Update
                DataTable dtCustomer = new BALCustomerMaster().SelectByParentID(new BOLCustomerMaster() { ParentID = Convert.ToInt32(txtID.Text) });
                if (dtCustomer.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtCustomer.Rows)
                    {
                        ObjCustomerBOL.ParentID = Convert.ToInt32(txtID.Text);
                        ObjCustomerBOL.FullName = txtCustomerName.Text.Trim() + ":" + dr["CustomerName"].ToString();
                        ObjCustomerBAL.UpdateFullName(ObjCustomerBOL);
                    }
                }
                int id1 = Convert.ToInt32(txtID.Text);
                MessageBox.Show("Record Update successfully");
                ClsCommon.ObjCustomerCenter.LoadCustomerData(id1);
                this.Close();
                Clear();


            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :UpdateCustomer. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadBillAddrees()
        {
            try
            {
                if (dtBillAddress.Rows.Count > 0)
                {
                    if (dtBillAddress.Rows[0]["Address1"].ToString() != "")
                        BillAddress = dtBillAddress.Rows[0]["Address1"].ToString();
                    if (dtBillAddress.Rows[0]["Address2"].ToString() != "")
                        BillAddress = BillAddress + "\r\n" + dtBillAddress.Rows[0]["Address2"].ToString();
                    if (dtBillAddress.Rows[0]["Address3"].ToString() != "")
                        BillAddress = BillAddress + "\r\n" + dtBillAddress.Rows[0]["Address3"].ToString();
                    if (dtBillAddress.Rows[0]["City"].ToString() != "" && dtBillAddress.Rows[0]["State"].ToString() == "")
                        BillAddress = BillAddress + "\r\n" + dtBillAddress.Rows[0]["City"].ToString();
                    else if (dtBillAddress.Rows[0]["State"].ToString() != "" && dtBillAddress.Rows[0]["City"].ToString() == "")
                        BillAddress = BillAddress + "\r\n" + dtBillAddress.Rows[0]["State"].ToString();
                    else if (dtBillAddress.Rows[0]["City"].ToString() != "" && dtBillAddress.Rows[0]["State"].ToString() != "")
                        BillAddress = BillAddress + "\r\n" + dtBillAddress.Rows[0]["City"].ToString() + "," + dtBillAddress.Rows[0]["State"].ToString();
                    if (dtBillAddress.Rows[0]["Country"].ToString() != "" && dtBillAddress.Rows[0]["ZipCode"].ToString() == "")
                        BillAddress = BillAddress + "\r\n" + dtBillAddress.Rows[0]["Country"].ToString();
                    else if (dtBillAddress.Rows[0]["ZipCode"].ToString() != "" && dtBillAddress.Rows[0]["Country"].ToString() == "")
                        BillAddress = BillAddress + "\r\n" + dtBillAddress.Rows[0]["ZipCode"].ToString();
                    else if (dtBillAddress.Rows[0]["ZipCode"].ToString() != "" && dtBillAddress.Rows[0]["Country"].ToString() != "")
                        BillAddress = BillAddress + "\r\n" + dtBillAddress.Rows[0]["Country"].ToString() + "," + dtBillAddress.Rows[0]["ZipCode"].ToString();
                    if (dtBillAddress.Rows[0]["Note"].ToString() != "")
                        BillAddress = BillAddress + "\r\n" + dtBillAddress.Rows[0]["Note"].ToString();
                }
                else if (dtBillAddress.Rows.Count == 0)
                {
                    DataRow dr = dtBillAddress.NewRow();
                    dr["ID"] = "0";
                    string[] str = txtBillAddress.Text.Split('\n');
                    if (str.Length == 1)
                        dr["Address1"] = str[0].ToString().Replace("\r", "");
                    else if (str.Length == 2)
                    {
                        dr["Address1"] = str[0].ToString().Replace("\r", "");
                        dr["Address2"] = str[1].ToString().Replace("\r", "");
                    }
                    else if (str.Length == 3)
                    {
                        dr["Address1"] = str[0].ToString().Replace("\r", "");
                        dr["Address2"] = str[1].ToString().Replace("\r", "");
                        dr["Address3"] = str[2].ToString().Replace("\r", "");
                    }
                    dtBillAddress.Rows.Add(dr);
                }
                if (BillAddress == null)
                    txtBillAddress.Text = "";
                else
                    txtBillAddress.Text = BillAddress.Replace("\r\n\r\n", "\r\n");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :LoadBilAddrees. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void CopyBillAddress()
        {
            try
            {
                if (dtShipAddress.Rows.Count == 0)
                {
                    if (dtBillAddress.Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in dtBillAddress.Rows)
                        {
                            DataRow dr = dtShipAddress.NewRow();
                            dr["ID"] = "0";
                            dr["DefaultShipping"] = 1;
                            //dr["Name"] = txtCustomerName.Text;
                            if (ShipAddressName != "")
                                dr["AddressName"] = ShipAddressName;
                            //if (cmbShipTo.Text!= "")
                            //    dr["AddressName"] = dr1["Address1"].ToString();
                            //Hiren
                            //if (dr["Name"].ToString() != "")
                            //    ShipAddress = dr["Name"].ToString();
                            //else
                            //    ShipAddress = txtCustomerName.Text;
                            //if (dr1["Address1"].ToString() != "")
                            //    dr["Address1"] = dr1["Address1"].ToString();
                            //if (dr1["Address2"].ToString() != "")
                            //    dr["Address2"] = dr1["Address2"].ToString();
                            //if (dr1["Address3"].ToString() != "")
                            //    dr["Address3"] = dr1["Address3"].ToString();
                            //if (dr1["City"].ToString() != "")
                            //    dr["City"] = dr1["City"].ToString();
                            //if (dr1["State"].ToString() != "")
                            //    dr["State"] = dr1["State"].ToString();
                            //if (dr1["Country"].ToString() != "")
                            //    dr["Country"] = dr1["Country"].ToString();
                            //if (dr1["ZipCode"].ToString() != "")
                            //    dr["ZipCode"] = dr1["ZipCode"].ToString();
                            //if (dr1["Note"].ToString() != "")
                            //    dr["Note"] = dr1["Note"].ToString();
                            //dtShipAddress.Rows.Add(dr);
                            if (dr1["Address1"].ToString() != "")
                                dr["Address1"] = dr1["Address1"].ToString();
                            if (dr1["Address2"].ToString() != "")
                                dr["Address2"] = dr1["Address2"].ToString();
                            if (dr1["Address3"].ToString() != "")
                                dr["Address3"] = dr1["Address3"].ToString();
                            if (dr1["City"].ToString() != "")
                                dr["City"] = dr1["City"].ToString();
                            if (dr1["State"].ToString() != "")
                                dr["State"] = dr1["State"].ToString();
                            if (dr1["Country"].ToString() != "")
                                dr["Country"] = dr1["Country"].ToString();
                            if (dr1["ZipCode"].ToString() != "")
                                dr["ZipCode"] = dr1["ZipCode"].ToString();
                            if (dr1["Note"].ToString() != "")
                                dr["Note"] = dr1["Note"].ToString();
                            dtShipAddress.Rows.Add(dr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :CopyBillAddress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnBillAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtBillAddress.Rows.Count == 0)
                    BillAddressColumn();
                LoadBillAddrees();
                FrmAddressMaster objBill = new FrmAddressMaster();
                objBill.dtAddress = dtBillAddress;
                objBill.Type = "Customer";
                objBill.LoadAddress();
                objBill.Show();
                LoadBillAddrees();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :btnBillAddress_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public static string RemoveDigits(string key)
        {
            return Regex.Replace(key, @"\D", "");
        }
        private void pctAddShippingAddress_Click(object sender, EventArgs e)
        {
            try
            {
                ClsCommon.Name = "";
                if (dtShipAddress.Rows.Count == 0)
                    ShipAddressColumn();
                FrmShippingAddress objShip = new FrmShippingAddress();
                objShip.dtAddress = dtShipAddress;
                objShip.CustomerName = txtCustomerName.Text;
                //objShip.ShipAddressName = "Ship To " + Convert.ToInt16(dtShipAddress.Rows.Count + 1);
                if (dtShipAddress.Rows.Count == 0)
                {
                    objShip.ShipAddressName = "Ship To 1";
                }
                else
                {
                    for (int I = 0; I < dtShipAddress.Rows.Count; I++)
                    {

                        if (dtShipAddress.Rows[I]["AddressName"].ToString().Contains("Ship To ") == true)
                        {
                            //int i = (dtShipAddress.Rows.Count - 1);
                            int Count = Convert.ToInt32(RemoveDigits(dtShipAddress.Rows[I]["AddressName"].ToString()));
                            objShip.ShipAddressName = "Ship To " + Convert.ToInt32(Count + 1);
                        }
                    }
                }
                if (objShip.ShipAddressName == "")
                {
                    objShip.ShipAddressName = "Ship To 1";
                }
                objShip.ShowDialog();
                if (objShip.Isclose == true)
                {
                    ShipAddressName = "";
                }
                else
                {
                    ShipAddressName = objShip.ShipAddressName;
                }
                if (ShipAddress != "")
                    cmbShipTo.Text = ShipAddressName.Trim();
                GetShipName();
                ShipAddrress();
                objShip.Isclose = false;
                objShip.isOk = false;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :pctAddShippingAddress_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void BillAddrress()
        {
            try
            {
                if (Mode == "insert")
                {
                    BillAddress = "";
                    if (txtCompanyName.Text != "")
                        BillAddress = txtCompanyName.Text;
                    if (txtLastName.Text != "" && txtLastName.Text != "Last")
                    {
                        if (txtCompanyName.Text != "")
                        {
                            BillAddress = txtCompanyName.Text;
                            if (txtFirstName.Text != "" && txtFirstName.Text != "First")
                                BillAddress = BillAddress + "\r\n" + txtFirstName.Text;
                            if (txtMiddleName.Text != "" && txtMiddleName.Text != "M.I.")
                                BillAddress = BillAddress + " " + txtMiddleName.Text;
                            if (txtLastName.Text != "" && txtLastName.Text != "Last")
                                BillAddress = BillAddress + " " + txtLastName.Text;
                        }
                        else
                        {
                            if (txtFirstName.Text != "" && txtFirstName.Text != "First")
                                BillAddress = txtFirstName.Text;
                            if (txtMiddleName.Text != "" && txtMiddleName.Text != "M.I.")
                                BillAddress = BillAddress + " " + txtMiddleName.Text;
                            if (txtLastName.Text != "" && txtLastName.Text != "Last")
                                BillAddress = BillAddress + " " + txtLastName.Text;
                        }
                    }
                    txtBillAddress.Text = BillAddress.Trim();
                    if (txtBillAddress.Text == "")
                        btnCopy.Enabled = false;
                    else
                        btnCopy.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :BillAddrress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void txtCompanyName_Leave(object sender, EventArgs e)
        {
            try
            {
                BillAddrress();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :txtCompanyName_Leave. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtLastName.Text == "")
                {
                    txtLastName.Text = "Last";
                    txtLastName.ForeColor = Color.Gray;
                }
                else
                    txtLastName.ForeColor = Color.Black;
                BillAddrress();
                if (txtBillAddress.Text != "")
                {
                    BillAddressColumn();
                    LoadBillAddrees();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :txtCompanyName_Leave. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void ShipAddrress()
        {
            try
            {
                if (dtShipAddress.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtShipAddress.Rows)
                    {
                        if (cmbShipTo.SelectedIndex >= 0)
                        {
                            if (dr["ID"].ToString() == cmbShipTo.SelectedValue.ToString() && dr["AddressName"].ToString() == cmbShipTo.Text.ToString())
                            {
                                //Hiren
                                cmbShipTo.Text = dr["AddressName"].ToString().Trim();
                                //if (dr["Name"].ToString() != "")
                                //    ShipAddress = dr["Name"].ToString();
                                //else
                                //    ShipAddress = txtCustomerName.Text;
                                //
                                if (dr["Address1"].ToString() != "")
                                    ShipAddress = dr["Address1"].ToString();
                                if (dr["Address2"].ToString() != "")
                                    ShipAddress = ShipAddress + "\r\n" + dr["Address2"].ToString();
                                if (dr["Address3"].ToString() != "")
                                    ShipAddress = ShipAddress + "\r\n" + dr["Address3"].ToString();
                                if (dr["City"].ToString() != "" && dr["State"].ToString() == "")
                                    ShipAddress = ShipAddress + "\r\n" + dr["City"].ToString();
                                else if (dr["State"].ToString() != "" && dr["City"].ToString() == "")
                                    ShipAddress = ShipAddress + "\r\n" + dr["State"].ToString();
                                else if (dr["City"].ToString() != "" && dr["State"].ToString() != "")
                                    ShipAddress = ShipAddress + "\r\n" + dr["City"].ToString() + "," + dr["State"].ToString();
                                if (dr["Country"].ToString() != "" && dr["ZipCode"].ToString() == "")
                                    ShipAddress = ShipAddress + "\r\n" + dr["Country"].ToString();
                                else if (dr["ZipCode"].ToString() != "" && dr["Country"].ToString() == "")
                                    ShipAddress = ShipAddress + "\r\n" + dr["ZipCode"].ToString();
                                else if (dr["ZipCode"].ToString() != "" && dr["Country"].ToString() != "")
                                    ShipAddress = ShipAddress + "\r\n" + dr["Country"].ToString() + "," + dr["ZipCode"].ToString();
                                if (dr["Note"].ToString() != "")
                                    ShipAddress = ShipAddress + "\r\n" + dr["Note"].ToString();
                                //ClsCommon.Name = dr["Name"].ToString();
                            }
                        }
                    }
                }
                if (ShipAddress == null)
                    txtShipAddress.Text = "";
                else
                    txtShipAddress.Text = ShipAddress.Replace("\r\n\r\n", "\r\n");
                if (Mode != "update")
                {
                    if (dtShipAddress.Rows.Count == 1)
                    {
                        foreach (DataRow dr in dtShipAddress.Rows)
                        {
                            dr["DefaultShipping"] = "1";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :ShipAddrress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void GetShipName()

        {
            try
            {
                if (dtShipAddress.Rows.Count > 0)
                {
                    btnEditShippingAdd.Enabled = true;
                    btnDeletShippingAdd.Enabled = true;
                    chkDefaultShippingAddress.Enabled = true;
                    cmbShipTo.DataSource = dtShipAddress;
                    cmbShipTo.DisplayMember = "AddressName";
                    cmbShipTo.ValueMember = "ID";
                    SelectShipTo();
                }
                else
                {
                    cmbShipTo.DataSource = null;
                    btnEditShippingAdd.Enabled = false;
                    btnDeletShippingAdd.Enabled = false;
                    chkDefaultShippingAddress.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :GetShipName. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbShipTo.SelectedIndex == -1)
                {
                    if (dtShipAddress.Rows.Count == 0)
                        ShipAddressColumn();
                    //ShipAddrress();
                    FrmShippingAddress objShip = new FrmShippingAddress();

                    if (dtShipAddress.Rows.Count > 0)
                    {
                        for (int I = 0; I < dtShipAddress.Rows.Count; I++)
                        {
                            if (dtShipAddress.Rows[I]["AddressName"].ToString().Contains("Ship To ") == true)
                            {
                                //if (dtShipAddress.Rows[I]["AddressType"].ToString() == "S")
                                //{
                                int Count = Convert.ToInt32(RemoveDigits(dtShipAddress.Rows[I]["AddressName"].ToString()));
                                objShip.ShipAddressName = "Ship To " + Convert.ToInt32(Count + 1);
                                //}
                            }
                        }
                        if (objShip.ShipAddressName == "")
                        {
                            objShip.ShipAddressName = "Ship To 1";
                        }
                    }
                    else
                    {
                        objShip.ShipAddressName = "Ship To 1";
                    }
                    ShipAddressName = objShip.ShipAddressName;
                    //objShip.ShipAddressName = "Ship To " + Convert.ToInt16(dtShipAddress.Rows.Count + 1);
                    CopyBillAddress();
                    objShip.dtAddress = dtShipAddress;
                    objShip.CustomerName = txtCustomerName.Text;
                    objShip.Mode = "Copy";
                    objShip.ID = "0";
                    objShip.LoadAddress();
                    objShip.ShowDialog();
                    ShipAddressName = objShip.ShipAddressName;
                    ShipAddrress();
                    if (ShipAddress != "")
                        //cmbShipTo.Text = ShipAddressName;
                        cmbShipTo.Text = ShipAddressName.Trim();
                    GetShipName();
                }
                else
                {
                    MessageBox.Show("The Ship To Adddress Already contains Information.",
                        "Copy Bill To Address");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :btnCopy_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void pctEditShippingAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtShipAddress.Rows.Count == 0)
                    ShipAddressColumn();
                if (cmbShipTo.Text != "")
                {
                    ShipAddrress();
                    FrmShippingAddress objShip = new FrmShippingAddress();
                    objShip.dtAddress = dtShipAddress;
                    objShip.ShipAddressName = cmbShipTo.Text;
                    objShip.CustomerName = txtCustomerName.Text;
                    objShip.Mode = "update";
                    //if(cmbShipTo.SelectedValue ==null)
                    //{
                    //    cmbShipTo.SelectedValue = "0";
                    //}
                    objShip.ID = cmbShipTo.SelectedValue.ToString();
                    objShip.LoadAddress();
                    objShip.ShowDialog();
                    ShipAddressName = objShip.ShipAddressName;
                    txtShipAddress.Text = ShipAddress.Replace("\r\n\r\n", "\r\n");
                    ShipAddrress();
                    if (ShipAddress != "")
                        cmbShipTo.Text = ShipAddressName.Trim();
                    GetShipName();
                }
                else
                {
                    MessageBox.Show("Please select ShipTo");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :pctEditShippingAddress_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void SelectShipTo()
        {
            try
            {
                if (dtShipAddress.Rows.Count > 0)
                {
                    DataRow[] row = dtShipAddress.Select("ID = '" + cmbShipTo.SelectedValue + "'");
                    //DataRow[] row = dtShipAddress.Select("AddressName = '" + cmbShipTo.SelectedValue.Trim().Replace("'", "''") + "'");
                    if (row.Length == 1)
                    {
                        foreach (DataRow drShip in row)
                        {
                            cmbShipTo.Text = drShip["AddressName"].ToString().Trim();
                            if (drShip["DefaultShipping"].ToString() == "1")
                            {
                                chkDefaultShippingAddress.Checked = true;
                            }
                            else
                            {
                                chkDefaultShippingAddress.Checked = false;
                            }
                            ShipAddress = "";
                            if (drShip["Address1"].ToString() != "")
                                ShipAddress = drShip["Address1"].ToString();
                            if (drShip["Address2"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + drShip["Address2"].ToString();
                            if (drShip["Address3"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + drShip["Address3"].ToString();
                            if (drShip["City"].ToString() != "" && drShip["State"].ToString() == "")
                                ShipAddress = ShipAddress + "\r\n" + drShip["City"].ToString();
                            else if (drShip["State"].ToString() != "" && drShip["City"].ToString() == "")
                                ShipAddress = ShipAddress + "\r\n" + drShip["State"].ToString();
                            else if (drShip["City"].ToString() != "" && drShip["State"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + drShip["City"].ToString() + "," + drShip["State"].ToString();
                            if (drShip["Country"].ToString() != "" && drShip["ZipCode"].ToString() == "")
                                ShipAddress = ShipAddress + "\r\n" + drShip["Country"].ToString();
                            else if (drShip["ZipCode"].ToString() != "" && drShip["Country"].ToString() == "")
                                ShipAddress = ShipAddress + "\r\n" + drShip["ZipCode"].ToString();
                            else if (drShip["ZipCode"].ToString() != "" && drShip["Country"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + drShip["Country"].ToString() + "," + drShip["ZipCode"].ToString();
                            if (drShip["Note"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + drShip["Note"].ToString();
                            txtShipAddress.Text = ShipAddress.Replace("\r\n\r\n", "\r\n");
                        }
                    }
                    else if (cmbShipTo.SelectedValue == null && dtShipAddress.Rows.Count > 0)
                    {
                        foreach (DataRow drShip in dtShipAddress.Rows)
                        {
                            if (drShip["DefaultShipping"].ToString() == "1")
                            {
                                cmbShipTo.Text = drShip["AddressName"].ToString().Trim();
                                chkDefaultShippingAddress.Checked = true;
                                ShipAddress = "";
                                if (drShip["Address1"].ToString() != "")
                                    ShipAddress = drShip["Address1"].ToString();
                                if (drShip["Address2"].ToString() != "")
                                    ShipAddress = ShipAddress + "\r\n" + drShip["Address2"].ToString();
                                if (drShip["Address3"].ToString() != "")
                                    ShipAddress = ShipAddress + "\r\n" + drShip["Address3"].ToString();
                                if (drShip["City"].ToString() != "" && drShip["State"].ToString() == "")
                                    ShipAddress = ShipAddress + "\r\n" + drShip["City"].ToString();
                                else if (drShip["State"].ToString() != "" && drShip["City"].ToString() == "")
                                    ShipAddress = ShipAddress + "\r\n" + drShip["State"].ToString();
                                else if (drShip["City"].ToString() != "" && drShip["State"].ToString() != "")
                                    ShipAddress = ShipAddress + "\r\n" + drShip["City"].ToString() + "," + drShip["State"].ToString();
                                if (drShip["Country"].ToString() != "" && drShip["ZipCode"].ToString() == "")
                                    ShipAddress = ShipAddress + "\r\n" + drShip["Country"].ToString();
                                else if (drShip["ZipCode"].ToString() != "" && drShip["Country"].ToString() == "")
                                    ShipAddress = ShipAddress + "\r\n" + drShip["ZipCode"].ToString();
                                else if (drShip["ZipCode"].ToString() != "" && drShip["Country"].ToString() != "")
                                    ShipAddress = ShipAddress + "\r\n" + drShip["Country"].ToString() + "," + drShip["ZipCode"].ToString();
                                if (drShip["Note"].ToString() != "")
                                    ShipAddress = ShipAddress + "\r\n" + drShip["Note"].ToString();
                                txtShipAddress.Text = ShipAddress.Replace("\r\n\r\n", "\r\n");

                            }
                        }
                    }
                    else if (cmbShipTo.SelectedValue.ToString() == "0" && cmbShipTo.Text != "" && dtShipAddress.Rows.Count > 0)
                    {

                        DataRow[] row1 = dtShipAddress.Select("AddressName = '" + cmbShipTo.Text + "'");
                        if (row1.Length == 1)
                        {
                            foreach (DataRow drShip in row1)
                            {
                                cmbShipTo.Text = drShip["AddressName"].ToString().Trim();
                                if (drShip["DefaultShipping"].ToString() == "1")
                                {
                                    chkDefaultShippingAddress.Checked = true;
                                }
                                else
                                {
                                    chkDefaultShippingAddress.Checked = false;
                                }
                                ShipAddress = "";
                                if (drShip["Address1"].ToString() != "")
                                    ShipAddress = drShip["Address1"].ToString();
                                if (drShip["Address2"].ToString() != "")
                                    ShipAddress = ShipAddress + "\r\n" + drShip["Address2"].ToString();
                                if (drShip["Address3"].ToString() != "")
                                    ShipAddress = ShipAddress + "\r\n" + drShip["Address3"].ToString();
                                if (drShip["City"].ToString() != "" && drShip["State"].ToString() == "")
                                    ShipAddress = ShipAddress + "\r\n" + drShip["City"].ToString();
                                else if (drShip["State"].ToString() != "" && drShip["City"].ToString() == "")
                                    ShipAddress = ShipAddress + "\r\n" + drShip["State"].ToString();
                                else if (drShip["City"].ToString() != "" && drShip["State"].ToString() != "")
                                    ShipAddress = ShipAddress + "\r\n" + drShip["City"].ToString() + "," + drShip["State"].ToString();
                                if (drShip["Country"].ToString() != "" && drShip["ZipCode"].ToString() == "")
                                    ShipAddress = ShipAddress + "\r\n" + drShip["Country"].ToString();
                                else if (drShip["ZipCode"].ToString() != "" && drShip["Country"].ToString() == "")
                                    ShipAddress = ShipAddress + "\r\n" + drShip["ZipCode"].ToString();
                                else if (drShip["ZipCode"].ToString() != "" && drShip["Country"].ToString() != "")
                                    ShipAddress = ShipAddress + "\r\n" + drShip["Country"].ToString() + "," + drShip["ZipCode"].ToString();
                                if (drShip["Note"].ToString() != "")
                                    ShipAddress = ShipAddress + "\r\n" + drShip["Note"].ToString();
                                txtShipAddress.Text = ShipAddress.Replace("\r\n\r\n", "\r\n");
                            }
                        }

                    }
                    else if (cmbShipTo.SelectedValue.ToString() == "0" && cmbShipTo.Text == "" && dtShipAddress.Rows.Count > 0)
                    {


                        foreach (DataRow drShip in dtShipAddress.Rows)
                        {
                            cmbShipTo.Text = drShip["AddressName"].ToString().Trim();
                            if (drShip["DefaultShipping"].ToString() == "1")
                            {
                                chkDefaultShippingAddress.Checked = true;
                            }
                            else
                            {
                                chkDefaultShippingAddress.Checked = false;
                            }
                            ShipAddress = "";
                            if (drShip["Address1"].ToString() != "")
                                ShipAddress = drShip["Address1"].ToString();
                            if (drShip["Address2"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + drShip["Address2"].ToString();
                            if (drShip["Address3"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + drShip["Address3"].ToString();
                            if (drShip["City"].ToString() != "" && drShip["State"].ToString() == "")
                                ShipAddress = ShipAddress + "\r\n" + drShip["City"].ToString();
                            else if (drShip["State"].ToString() != "" && drShip["City"].ToString() == "")
                                ShipAddress = ShipAddress + "\r\n" + drShip["State"].ToString();
                            else if (drShip["City"].ToString() != "" && drShip["State"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + drShip["City"].ToString() + "," + drShip["State"].ToString();
                            if (drShip["Country"].ToString() != "" && drShip["ZipCode"].ToString() == "")
                                ShipAddress = ShipAddress + "\r\n" + drShip["Country"].ToString();
                            else if (drShip["ZipCode"].ToString() != "" && drShip["Country"].ToString() == "")
                                ShipAddress = ShipAddress + "\r\n" + drShip["ZipCode"].ToString();
                            else if (drShip["ZipCode"].ToString() != "" && drShip["Country"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + drShip["Country"].ToString() + "," + drShip["ZipCode"].ToString();
                            if (drShip["Note"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + drShip["Note"].ToString();
                            txtShipAddress.Text = ShipAddress.Replace("\r\n\r\n", "\r\n");
                            break;
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :SelectShipTo. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void cmbShipTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsAddress == true)
                {
                    btnEditShippingAdd.Enabled = true;
                    btnDeletShippingAdd.Enabled = true;
                    chkDefaultShippingAddress.Enabled = true;
                    SelectShipTo();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :cmbShipTo_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void pctDeleteShippingAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtShipAddress.Rows.Count > 0)
                {
                    if (chkDefaultShippingAddress.Checked == false)
                    {

                        EditShipAddress = "";
                        EditShipAddress = cmbShipTo.Text.Trim();

                        for (int i = dtShipAddress.Rows.Count - 1; i >= 0; i--)
                        {

                            if (dtShipAddress.Rows[i]["AddressName"].ToString() == EditShipAddress)
                            {

                                ObjAddressBAL.DeleteAddress(Convert.ToInt32(dtShipAddress.Rows[i]["ID"]));
                                ShipAddress = "";
                                txtShipAddress.Text = "";
                                if (i == 0 && dtShipAddress.Rows.Count == 1)
                                {
                                    dtShipAddress.Rows.Clear();
                                }
                                else
                                {
                                    dtShipAddress.Rows.RemoveAt(i);

                                }
                                dtShipAddress.AcceptChanges();
                            }
                        }
                        dtShipAddress.AcceptChanges();
                        btnDeletShippingAdd.Enabled = false;
                        btnDeletShippingAdd.Enabled = false;
                        chkDefaultShippingAddress.Enabled = false;
                        txtShipAddress.Text = "";
                        cmbShipTo.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("You cannot delete Default Shipping address. First Change Default Address and then try to Delete.");
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :pctDeleteShippingAddress_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void chkDefaultShippingAddress_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ShipAddressName = "";
                //dtShipAddress.AcceptChanges();
                if (dtShipAddress.Rows.Count > 0)
                {

                    ShipAddressName = cmbShipTo.Text.Trim();
                    foreach (DataRow dr in dtShipAddress.Rows)
                    {
                        dr.BeginEdit();
                        if (dr["AddressName"].ToString() != "")
                        {
                            if (dr["AddressName"].ToString() == ShipAddressName && chkDefaultShippingAddress.Checked == true)
                                dr["DefaultShipping"] = "1";
                            else if (dr["AddressName"].ToString() != ShipAddressName && chkDefaultShippingAddress.Checked == true)
                                dr["DefaultShipping"] = "0";
                            else if (dr["AddressName"].ToString() == ShipAddressName && chkDefaultShippingAddress.Checked == false)
                                dr["DefaultShipping"] = "0";
                        }

                    }
                }
                if (dtShipAddress.Rows.Count == 0)
                    chkDefaultShippingAddress.Checked = false;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :chkDefaultShippingAddress_CheckedChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void txtSaluation_Enter(object sender, EventArgs e)
        {
            if (txtSaluation.Text == "Mr./Ms./..")
            {
                txtSaluation.Text = "";
                txtSaluation.ForeColor = Color.Black;
            }
        }

        private void txtFirstName_Enter(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "First")
            {
                txtFirstName.Text = "";
                txtFirstName.ForeColor = Color.Black;
            }
        }

        private void txtMiddleName_Enter(object sender, EventArgs e)
        {
            if (txtMiddleName.Text == "M.I.")
            {
                txtMiddleName.Text = "";
                txtMiddleName.ForeColor = Color.Black;
            }
        }

        private void txtLastName_Enter(object sender, EventArgs e)
        {
            if (txtLastName.Text == "Last")
            {
                txtLastName.Text = "";
                txtLastName.ForeColor = Color.Black;
            }
        }

        private void txtSaluation_Leave(object sender, EventArgs e)
        {
            if (txtSaluation.Text == "")
            {
                txtSaluation.Text = "Mr./Ms./..";
                txtSaluation.ForeColor = Color.Gray;
            }
            else
                txtSaluation.ForeColor = Color.Black;
        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                txtFirstName.Text = "First";
                txtFirstName.ForeColor = Color.Gray;
            }
            else
                txtFirstName.ForeColor = Color.Black;
        }

        private void txtMiddleName_Leave(object sender, EventArgs e)
        {
            if (txtMiddleName.Text == "")
            {
                txtMiddleName.Text = "M.I.";
                txtMiddleName.ForeColor = Color.Gray;
            }
            else
                txtMiddleName.ForeColor = Color.Black;
        }

        private void txtOpeningBalance_KeyPress(object sender, KeyPressEventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :txtOpeningBalance_KeyPress. Message:" + ex.Message);
            }
        }

        private void txtMainPhone_KeyPress(object sender, KeyPressEventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :txtMainPhone_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void txtWorkPhone_KeyPress(object sender, KeyPressEventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :txtWorkPhone_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :txtMobile_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void FrmCustomerMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ClsCommon.ObjCustomerMaster.Hide();
                ClsCommon.ObjCustomerMaster.Parent = null;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :FrmCustomerMaster_FormClosing. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void cmbParentCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void dgvCreditCard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.ColumnIndex == dgvCreditCard.Columns["Delete"].Index)
                {
                    int CreditCustomerID = Convert.ToInt32(dgvCreditCard.CurrentRow.Cells["CustomerID"].Value.ToString());
                    int SrNo = Convert.ToInt32(dgvCreditCard.CurrentRow.Cells["SrNo"].Value.ToString());
                    if (CreditCustomerID != 0)
                    {
                        DataTable dt = new BALCreditCardDetails().SelectByCustomerSrNo(new BOLCreditCardDetails() { CustomerID = CreditCustomerID, SrNo = SrNo });
                        if (dt.Rows.Count > 0)
                        {
                            BOLCreditCardDetails.CustomerID = CreditCustomerID;
                            BOLCreditCardDetails.SrNo = SrNo;
                            BALCreditCardDetails.DeleteByID(BOLCreditCardDetails);
                        }
                    }
                    dgvCreditCard.Rows.RemoveAt(this.dgvCreditCard.CurrentRow.Index);
                    dtCreditCardDetails.AcceptChanges();
                    foreach (DataRow dr in dtCreditCardDetails.Rows)
                    {
                        if (dr["SrNo"].ToString() == SrNo.ToString())
                        {
                            dr.Delete();
                            break;
                        }
                    }
                    dgvCreditCard.DataSource = dtCreditCardDetails;
                    txtSrNo.Text = "";
                }

                else if (e.ColumnIndex == dgvCreditCard.Columns["Edit"].Index)
                {

                    int SrNo = Convert.ToInt32(dgvCreditCard.CurrentRow.Cells["SrNo"].Value.ToString());
                    foreach (DataRow dr in dtCreditCardDetails.Rows)
                    {
                        if (dr["SrNo"].ToString() == SrNo.ToString())
                        {
                            txtSrNo.Text = dr["SrNo"].ToString();
                            cmbCardType.Text = dr["CardType"].ToString();
                            txtCardFirstName.Text = dr["FirstName"].ToString();
                            txtCardLastName.Text = dr["LastName"].ToString();
                            txtCardNumber.Text = dr["CardNumber"].ToString();
                            cmbYear.Text = dr["Year"].ToString();
                            cmbMonth.SelectedValue = dr["Month"].ToString();
                            txtCVV.Text = dr["CVV"].ToString();
                            txtAddress.Text = dr["Address"].ToString();
                            txtCity.Text = dr["City"].ToString();
                            txtState.Text = dr["State"].ToString();
                            txtZipCode.Text = dr["ZipCode"].ToString();
                            txtCountry.Text = dr["Country"].ToString();
                            break;
                        }
                    }

                }
            }
        }

        private void txtCardNumber_KeyPress(object sender, KeyPressEventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :txtCardNumber_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void txtCVV_KeyPress(object sender, KeyPressEventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmCustomerMaster,Function :txtCVV_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            if (CheckValidationForCreditCardDetails())
            {
                if (txtSrNo.Text != "")
                {
                    //Update
                    foreach (DataRow dr in dtCreditCardDetails.Rows)
                    {
                        if (dr["SrNo"].ToString() == txtSrNo.Text)
                        {
                            dr["CustomerID"] = txtID.Text;
                            dr["CardType"] = cmbCardType.Text;
                            dr["FirstName"] = txtCardFirstName.Text;
                            dr["LastName"] = txtCardLastName.Text;
                            dr["CardNumber"] = txtCardNumber.Text;
                            dr["Year"] = cmbYear.Text;
                            dr["Month"] = cmbMonth.Text;
                            dr["CVV"] = txtCVV.Text;
                            dr["Address"] = txtAddress.Text;
                            dr["City"] = txtCity.Text;
                            dr["State"] = txtState.Text;
                            dr["ZipCode"] = txtZipCode.Text;
                            dr["Country"] = txtCountry.Text;

                            break;
                        }
                    }
                    if (dgvCreditCard.Rows.Count > 0)
                    {
                        for (int k = 0; k < dtCreditCardDetails.Rows.Count; k++)
                        {
                            dtCreditCardDetails.Rows[k]["SrNo"] = k + 1;
                        }
                    }

                }
                else
                {
                    //Insert

                    DataRow dr = dtCreditCardDetails.NewRow();
                    dr["CustomerID"] = txtID.Text;
                    dr["CardType"] = cmbCardType.Text;
                    dr["FirstName"] = txtCardFirstName.Text;
                    dr["LastName"] = txtCardLastName.Text;
                    dr["CardNumber"] = txtCardNumber.Text;
                    dr["Year"] = cmbYear.Text;
                    dr["Month"] = cmbMonth.Text;
                    dr["CVV"] = txtCVV.Text;
                    dr["Address"] = txtAddress.Text;
                    dr["City"] = txtCity.Text;
                    dr["State"] = txtState.Text;
                    dr["ZipCode"] = txtZipCode.Text;
                    dr["Country"] = txtCountry.Text;
                    dtCreditCardDetails.Rows.Add(dr);


                    if (dtCreditCardDetails.Rows.Count > 0)
                    {
                        for (int k = 0; k < dtCreditCardDetails.Rows.Count; k++)
                        {
                            dtCreditCardDetails.Rows[k]["SrNo"] = k + 1;
                        }
                    }

                }

                if (dgvCreditCard.RowCount > 0)
                {
                    dgvCreditCard.FirstDisplayedScrollingRowIndex = dgvCreditCard.RowCount - 1;
                }
                dgvCreditCard.DataSource = dtCreditCardDetails;

                ResetCreditCardDetails();
            }
        }


        public void ResetCreditCardDetails()
        {
            txtSrNo.Text = "";
            cmbCardType.SelectedIndex = -1;
            txtCardFirstName.Text = "";
            txtCardLastName.Text = "";
            txtCardNumber.Text = "";
            cmbYear.SelectedIndex = -1;
            cmbMonth.SelectedIndex = -1;
            txtCVV.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZipCode.Text = "";
            txtCountry.Text = "";
        }
    }
}