using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.Report;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls.VirtualKeyboard;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;

namespace POS
{
    public partial class FrmCreditMemo : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALAssignPriceTier bALAssignPriceTier = new BALAssignPriceTier();
        BOLAssignPriceTier bOLAssignPriceTier = new BOLAssignPriceTier();
        ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
        DataTable dt1 = new DataTable(); string InvoiceID2 = ""; Thread oThread;
        DataTable dtLoadData = new DataTable(); string Inv = "";
        DataTable dtItem = new DataTable(); DataTable dtItem1 = new DataTable();
        DataTable dtCustomer = new DataTable();
        //princy
        DataTable dtCustomermessage = new DataTable();
        //BALInvoiceMaster objBALInvoice = new BALInvoiceMaster();
        //BOLInvoiceMaster objBOLInvoice = new BOLInvoiceMaster();
        BALCreditMemo objBALInvoice = new BALCreditMemo();
        BOLCreditMemo objBOLInvoice = new BOLCreditMemo();
        BALItemMaster objBALItem = new BALItemMaster();
        BOLItemMaster objBOLItem = new BOLItemMaster();
        BALCreditMemoDetails objBALInvDetails = new BALCreditMemoDetails();
        BOLCreditMemoDetails objBOLInvDetails = new BOLCreditMemoDetails();
        //BALInvoiceDetails objBALInvDetails = new BALInvoiceDetails();
        //BOLInvoiceDetails objBOLInvDetails = new BOLInvoiceDetails();
        BALItemSaleHistory objBALItemSale = new BALItemSaleHistory();
        BOLItemSaleHistory objBOLItemSale = new BOLItemSaleHistory();
        BALCustomerMaster objBALCustomer = new BALCustomerMaster();
        BOLCustomerMaster objBOLCustomer = new BOLCustomerMaster();
        //BOLCustomerRequest objBOLCusReq = new BOLCustomerRequest();
        //BALCustomerRequest objBALCusReq = new BALCustomerRequest();
        BOLCreditMemoRequest objBOLCreditMemo = new BOLCreditMemoRequest();
        BALCreditMemoRequest objBALCreditMemo = new BALCreditMemoRequest();
        //BALInvoicePrintCount objBALInvCount = new BALInvoicePrintCount();
        //BOLInvoicePrintCount objBOLInvCount = new BOLInvoicePrintCount();
        //BALInvoiceHistoryMaster objBALInvHistoryMaster = new BALInvoiceHistoryMaster();
        //BOLInvoiceHistoryMaster objBOLInvHistoryMaster = new BOLInvoiceHistoryMaster();
        //BALInvoiceHistoryDetails objBALInvHistoryDetails = new BALInvoiceHistoryDetails();
        //BOLInvoiceHistoryDetails objBOLInvHistoryDetails = new BOLInvoiceHistoryDetails();
        //BALInvoicePrintHistory objBALInvPrint = new BALInvoicePrintHistory();
        //BOLInvoicePrintHistory objBOLInvPrint = new BOLInvoicePrintHistory();
        //BALInvoiceAuditLogMaster objInvBAL = new BALInvoiceAuditLogMaster();
        //BOLInvoiceAuditLogMaster objInvBOL = new BOLInvoiceAuditLogMaster();
        //BALInvoiceAuditLogDetail objInvDetailBAL = new BALInvoiceAuditLogDetail();
        //BOLInvoiceAuditLogDetail objInvDetailBOL = new BOLInvoiceAuditLogDetail();
        //BALInvoiceLineItemLog objItemLogBAL = new BALInvoiceLineItemLog();
        //BOLInvoiceLineItemLog objItemLogBOL = new BOLInvoiceLineItemLog();
        BALCreditMemoPrintCount objBALInvCount = new BALCreditMemoPrintCount();
        BOLCreditMemoPrintCount objBOLInvCount = new BOLCreditMemoPrintCount();
        BALCreditMemoHistoryMaster objBALInvHistoryMaster = new BALCreditMemoHistoryMaster();
        BOLCreditMemoHistoryMaster objBOLInvHistoryMaster = new BOLCreditMemoHistoryMaster();
        BALCreditMemoHistoryDetails objBALInvHistoryDetails = new BALCreditMemoHistoryDetails();
        BOLCreditMemoHistoryDetails objBOLInvHistoryDetails = new BOLCreditMemoHistoryDetails();
        BALCreditMemoPrintHistory objBALInvPrint = new BALCreditMemoPrintHistory();
        BOLCreditMemoPrintHistory objBOLInvPrint = new BOLCreditMemoPrintHistory();
        BALCreditMemoAuditLogMaster objInvBAL = new BALCreditMemoAuditLogMaster();
        BOLCreditMemoAuditLogMaster objInvBOL = new BOLCreditMemoAuditLogMaster();
        BALCreditMemoAuditLogDetail objInvDetailBAL = new BALCreditMemoAuditLogDetail();
        BOLCreditMemoAuditLogDetail objInvDetailBOL = new BOLCreditMemoAuditLogDetail();
        BALCreditMemoLineItemLog objItemLogBAL = new BALCreditMemoLineItemLog();
        BOLCreditMemoLineItemLog objItemLogBOL = new BOLCreditMemoLineItemLog();
        BALHistoryMaster BALHistory = new BALHistoryMaster();
        BOLHistoryMaster BOLHistory = new BOLHistoryMaster();
        BALPriceTier ObjPriceBAL = new BALPriceTier();
        BALNoteMaster ObjNoteBAL = new BALNoteMaster();
        BALPrintDateMaster objPrintBAL = new BALPrintDateMaster();
        static BOLPrintDateMaster objPrintBOL = new BOLPrintDateMaster();
        DataTable dtShipAddress = new DataTable();
        public Boolean IsClose = false;
        public Boolean PrintCount = false;
        public string Mode = "insert";
        public Int32 InvoiceID = 0;
        public Int32 RequestID = 0;
        string BillAddress = ""; string ShipAddress = "";
        Decimal TotalBalance = 0;
        DataTable dtGridItem = new DataTable();
        public int Count = 0;
        int Allow = 0;

        //princy 03-04-2025
        public Boolean isCustomerMessageFormOpen = false;
        public Boolean isLoad = false;
        public FrmCreditMemo()
        {
            try
            {
                InitializeComponent();
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(5, 50);
                if (Mode == "insert")
                {
                    imgShipped.Visible = false;
                    LoadItem();
                    isLoad = true;
                    LoadCustomermessage();
                    GetAccount();
                    GetCustomer();
                    GetTerms();
                    GetSalesRep();
                    //LoadUPSService1();
                    GetShipMethod();
                    GetReason();
                    GetGRADING();
                    InvoiceNumber(ClsCommon.TaxWithoutTax);
                    GetAllItem();
                    if (ClsCommon.UserType != "admin" && ClsCommon.UserType != "Admin")
                        cmbSalesRep.SelectedValue = ClsCommon.UserID;
                    cmbCustomer.Select();
                    dgvShippingMethod.Rows.Clear();
                    txtLowestPrice.Visible = false;
                    txtCostPrice.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :FrmInvoiceMaster. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        //princy 03-04-2025
        public void LoadCustomermessage()
        {
            if (isLoad == true)
            {
                cmbMsg.DataSource = null;
                dtCustomermessage = new BALInvoiceMessage().SelectAll();
                if (dtCustomermessage.Rows.Count > 0)
                {
                    cmbMsg.Items.Clear();
                    DataRow[] dr = dtCustomermessage.Select();
                    if (dr.Length > 0)
                    {
                        DataTable dtCus = dr.CopyToDataTable();
                        if (dtCus.Rows.Count > 0)
                        {
                            DataRow drAdd = dtCus.NewRow();
                            drAdd["LogName"] = "< new Message >";
                            drAdd["ID"] = "0";
                            dtCus.Rows.InsertAt(drAdd, 0);
                            cmbMsg.DataSource = dtCus;
                            cmbMsg.DisplayMember = "LogName";
                            cmbMsg.ValueMember = "ID";
                            cmbMsg.SelectedIndex = -1;
                        }
                    }
                    else
                        cmbMsg.Items.Insert(0, "< new Message >");
                }
                else
                {
                    cmbMsg.Items.Clear();
                    cmbMsg.Items.Insert(0, "< new Message >");
                }
                //cmbMsg.Items.Insert(0, "< new Message >");
                isLoad = false;
            }

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
        //princy
        public void ItemNameUpdated(string updatedItemName)
        {
            cmbItem.Text = updatedItemName;
        }

        public void LoadFunction()
        {
            try
            {
                pctPaidInvoice.Visible = false;
                imgShipped.Visible = false;
                LoadItem();
                isLoad = true;
                LoadCustomermessage();
                GetAccount();
                GetCustomer();
                GetTerms();
                GetSalesRep();
                //LoadUPSService1();
                GetShipMethod();
                GetReason();
                GetGRADING();
                InvoiceNumber(ClsCommon.TaxWithoutTax);
                GetAllItem();
                if (ClsCommon.UserType != "admin" && ClsCommon.UserType != "Admin")
                    cmbSalesRep.SelectedValue = ClsCommon.UserID;

                cmbCustomer.Select();
                dgvShippingMethod.Rows.Clear();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :LoadFunction. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        public void DisplayPrice()
        {
            try
            {
                btnAdd.Enabled = true;
                DataTable dt = new DataTable();

                DataTable dtStatus = new DataTable();
                dtStatus.Columns.Add("Name", typeof(string));
                dtStatus.Columns.Add("Value", typeof(string));

                dt = ObjPriceBAL.SelectByRepID(Convert.ToInt32(ClsCommon.UserID));
                if (dt.Rows.Count > 0)
                {

                    DataRow dr = dtStatus.NewRow();
                    if (dt.Rows[0]["PriceTier1"].ToString() == "1")
                    {
                        dtStatus.Rows.Add("TierGF");
                    }
                    if (dt.Rows[0]["PriceTier2"].ToString() == "1")
                    {
                        dtStatus.Rows.Add("TierP4C");
                    }
                    if (dt.Rows[0]["PriceTier3"].ToString() == "1")
                    {
                        dtStatus.Rows.Add("TierMS");
                    }
                    if (dt.Rows[0]["Cost"].ToString() == "1")
                    {
                        dtStatus.Rows.Add("Cost");
                    }
                    cmbPrice.DataSource = dtStatus;
                    cmbPrice.DisplayMember = "Name";
                    cmbPrice.ValueMember = "Value";
                    if (cmbPrice.SelectedIndex == -1)
                    {
                        cmbPrice.SelectedIndex = 0;
                    }

                }
                else
                {
                    cmbPrice.ResetText();
                    cmbPrice.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :DisplayPrice. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        private void FrmInvoiceMaster_Load(object sender, EventArgs e)
        {
            try
            {
                isLoad = true;
                LoadCustomermessage();

                //SetApplicationTimeOut SetApplicationTimeOut = new SetApplicationTimeOut();
                //SetApplicationTimeOut.SetTimeOut();
                //SetApplicationTimeOut.Timer.Start();
                this.dgInvDetail.DefaultCellStyle.Font = new Font("", 10);
                dgInvDetail.RowTemplate.Height = 23;
                dgInvDetail.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgInvDetail.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8F, FontStyle.Regular);
                dgInvDetail.EnableHeadersVisualStyles = false;

                this.dgvInvoice1.DefaultCellStyle.Font = new Font("", 10);
                dgvInvoice1.RowTemplate.Height = 24;

                dgvShippingMethod.Rows.Clear();

                dtpInvoiceDate.Format = DateTimePickerFormat.Custom;
                dtpInvoiceDate.CustomFormat = "MM/dd/yyyy";

                dtpDuedate.Format = DateTimePickerFormat.Custom;
                dtpDuedate.CustomFormat = "MM/dd/yyyy";

                dtpShipDate.Format = DateTimePickerFormat.Custom;
                dtpShipDate.CustomFormat = "MM/dd/yyyy";

                imgShipped.Visible = false;
                //txtInvoiceNo.Enabled = false;
                //btnSaveAndEmail.Enabled = true;
                cmbPrice.Enabled = true;

                LoadTable();
                DisplayPrice();
                Display();
                //LoadUPSService1();
                GetShipMethod();
                GetReason();
                GetGRADING();
                //LoadTable();
                GetCustomer();
                //princy
                GetAllItem();

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :FrmInvoiceMaster_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void LoadTable()
        {
            try
            {
                DataRow dr = null;
                dtGridItem = new DataTable();
                dtGridItem.Columns.Add("SrNo", typeof(Int32));
                dtGridItem.Columns.Add("ID", typeof(string));
                dtGridItem.Columns.Add("QTY", typeof(string));
                dtGridItem.Columns.Add("ITEM", typeof(string));
                dtGridItem.Columns.Add("DESCRIPTION", typeof(string));
                //dtGridItem.Columns.Add("QTY", typeof(string));
                dtGridItem.Columns.Add("RATE", typeof(string));
                dtGridItem.Columns.Add("AMOUNT", typeof(string));
                dtGridItem.Columns.Add("LOWESTPRICE", typeof(string));
                dtGridItem.Columns.Add("COSTPRICE", typeof(string));
                dtGridItem.Columns.Add("PRICE1", typeof(string));
                dtGridItem.Columns.Add("PRICE2", typeof(string));
                dtGridItem.Columns.Add("PRICE3", typeof(string));

                //Hiren
                dtGridItem.Columns.Add("WEBPRICE", typeof(string));
                //

                dtGridItem.Columns.Add("Type", typeof(string));
                dtGridItem.Columns.Add("ItemType", typeof(string));
                //IMEI
                dtGridItem.Columns.Add("GRADING", typeof(string));
                //dtGridItem.Columns.Add("Reason", typeof(string));
                dtGridItem.Columns.Add("CARRIERS", typeof(string));
                dtGridItem.Columns.Add("IMEINumber", typeof(string));
                //Hiren
                dtGridItem.Columns.Add("TaxCode", typeof(string));
                if (dgvInvoice1.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvInvoice1.Rows.Count; i++)
                    {
                        dr = dtGridItem.NewRow();
                        dr[0] = dgvInvoice1.Rows[i].Cells[0].EditedFormattedValue.ToString();
                        dr[1] = dgvInvoice1.Rows[i].Cells[1].EditedFormattedValue.ToString();
                        dr[2] = dgvInvoice1.Rows[i].Cells[2].EditedFormattedValue.ToString();
                        dr[3] = dgvInvoice1.Rows[i].Cells[3].EditedFormattedValue.ToString();
                        dr[4] = dgvInvoice1.Rows[i].Cells[4].EditedFormattedValue.ToString();
                        dr[5] = dgvInvoice1.Rows[i].Cells[5].EditedFormattedValue.ToString();
                        dr[6] = dgvInvoice1.Rows[i].Cells[6].EditedFormattedValue.ToString();
                        dr[7] = dgvInvoice1.Rows[i].Cells[7].EditedFormattedValue.ToString();
                        dr[8] = dgvInvoice1.Rows[i].Cells[8].EditedFormattedValue.ToString();
                        dr[9] = dgvInvoice1.Rows[i].Cells[9].EditedFormattedValue.ToString();
                        dr[10] = dgvInvoice1.Rows[i].Cells[10].EditedFormattedValue.ToString();
                        dr[11] = dgvInvoice1.Rows[i].Cells[11].EditedFormattedValue.ToString();
                        //WebPrice
                        dr[12] = dgvInvoice1.Rows[i].Cells[12].EditedFormattedValue.ToString();
                        //
                        dr[13] = dgvInvoice1.Rows[i].Cells[13].EditedFormattedValue.ToString();
                        //IMEI
                        dr[14] = dgvInvoice1.Rows[i].Cells[14].EditedFormattedValue.ToString();
                        dr[15] = dgvInvoice1.Rows[i].Cells[15].EditedFormattedValue.ToString();
                        dr[16] = dgvInvoice1.Rows[i].Cells[16].EditedFormattedValue.ToString();
                        dr[17] = dgvInvoice1.Rows[i].Cells[17].EditedFormattedValue.ToString();
                        //princy
                        dr[18] = dgvInvoice1.Rows[i].Cells[18].EditedFormattedValue.ToString();

                        dtGridItem.Rows.Add(dr);
                    }
                }

                dgvInvoice1.DataSource = dtGridItem;

                //Hiren Tax Column
                foreach (DataGridViewColumn item in dgvInvoice1.Columns)
                {
                    if (item.GetType() == typeof(DataGridViewComboBoxColumn) && item.HeaderText == "Tax")
                    {
                        dgvInvoice1.Columns.Remove("Tax");
                        break;
                    }
                }

                foreach (DataGridViewColumn item in dgvInvoice1.Columns)
                {
                    if (item.GetType() == typeof(DataGridViewLinkColumn) && item.HeaderText == "Delete")
                    {
                        dgvInvoice1.Columns.Remove("Delete");
                        break;
                    }
                }
                foreach (DataGridViewColumn item in dgvInvoice1.Columns)
                {
                    if (item.GetType() == typeof(DataGridViewLinkColumn) && item.HeaderText == "Edit")
                    {
                        dgvInvoice1.Columns.Remove("Edit");
                        break;
                    }
                }

                //Hiren
                DataGridViewComboBoxColumn cmbTaxType = new DataGridViewComboBoxColumn();
                cmbTaxType.HeaderText = "Tax";
                cmbTaxType.DataPropertyName = "Tax";
                cmbTaxType.Name = "Tax";
                cmbTaxType.Items.Add("Tax");
                cmbTaxType.Items.Add("Non");
                dgvInvoice1.Columns.Insert(18, cmbTaxType);
                //

                DataGridViewLinkColumn links1 = new DataGridViewLinkColumn();
                links1.HeaderText = "Edit";
                links1.Name = "Edit";
                links1.UseColumnTextForLinkValue = true;
                links1.Text = "Edit";
                links1.LinkColor = Color.Blue;
                links1.TrackVisitedState = true;
                links1.VisitedLinkColor = Color.YellowGreen;
                dgvInvoice1.Columns.Insert(19, links1);


                DataGridViewLinkColumn links = new DataGridViewLinkColumn();
                links.HeaderText = "Delete";
                links.Name = "Delete";
                links.UseColumnTextForLinkValue = true;
                links.Text = "Delete";
                links.LinkColor = Color.Blue;
                links.TrackVisitedState = true;
                links.VisitedLinkColor = Color.YellowGreen;
                dgvInvoice1.Columns.Insert(20, links);



                dgvInvoice1.Columns["SrNo"].Visible = false;
                dgvInvoice1.Columns["ID"].Visible = false;
                dgvInvoice1.Columns["Type"].Visible = false;
                dgvInvoice1.Columns["ItemType"].Visible = false;

                dgvInvoice1.Columns[0].ReadOnly = true;
                dgvInvoice1.Columns[1].ReadOnly = true;
                dgvInvoice1.Columns[2].ReadOnly = true;
                dgvInvoice1.Columns[3].ReadOnly = true;
                dgvInvoice1.Columns[4].ReadOnly = true;
                dgvInvoice1.Columns[5].ReadOnly = true;
                dgvInvoice1.Columns[6].ReadOnly = true;
                dgvInvoice1.Columns[7].ReadOnly = true;
                dgvInvoice1.Columns[8].ReadOnly = true;
                dgvInvoice1.Columns[9].ReadOnly = true;
                dgvInvoice1.Columns[10].ReadOnly = true;
                dgvInvoice1.Columns[11].ReadOnly = true;
                dgvInvoice1.Columns[12].ReadOnly = true;
                dgvInvoice1.Columns[13].ReadOnly = true;
                //IMEI
                dgvInvoice1.Columns[14].ReadOnly = true;
                dgvInvoice1.Columns[15].ReadOnly = true;
                dgvInvoice1.Columns[16].ReadOnly = true;
                dgvInvoice1.Columns[17].ReadOnly = true;

                //Hiren
                dgvInvoice1.Columns[21].Visible = false;

                if (ClsCommon.UserType == "Admin")
                {
                    dgvInvoice1.Columns[7].Visible = true;
                    dgvInvoice1.Columns[8].Visible = true;
                }
                else
                {
                    dgvInvoice1.Columns[7].Visible = false;
                    dgvInvoice1.Columns[8].Visible = false;
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :LoadTable. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void CustomerNameUpdated(string updatedCustomerName)
        {
            cmbCustomer.Text = updatedCustomerName;
        }
        private Boolean CheckValidation()
        {
            Boolean ISValid = false;
            try
            {
            Top:
                if (cmbCustomer.SelectedValue == null || string.IsNullOrWhiteSpace(cmbCustomer.Text))
                {
                    DialogResult result = MessageBox.Show("Are You Sure Want to Create a New Customer?", "Select Action", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (cmbCustomer.Text == "" || cmbCustomer.SelectedValue == null)
                        {
                            string customerName = cmbCustomer.Text;
                            ClsCommon.ObjCustomerMaster.CustomerName = customerName;
                            ClsCommon.ObjCustomerMaster.CustomerNameUpdated += CustomerNameUpdated;
                            ClsCommon.ObjCustomerMaster.ShowDialog();
                            goto Top;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid customer name.");
                        }

                    }
                    else
                    {
                        ISValid = false;
                        MessageBox.Show("Please Enter CustomerName");
                        cmbCustomer.Focus();
                        goto Final;
                    }
                }
                if (cmbCustomer.SelectedValue == null)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select CustomerName");
                    cmbCustomer.Focus();
                    goto Final;
                }
                else if (cmbCustomer.SelectedIndex == 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select CustomerName");
                    cmbCustomer.Focus();
                    goto Final;
                }
                //else if (cmbAccount.SelectedIndex == 0)
                //{
                //    ISValid = false;
                //    MessageBox.Show("Please Select Account");
                //    cmbAccount.Focus();
                //    goto Final;
                //}
                else if (cmbSalesRep.SelectedIndex == 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select SalesRepName");
                    cmbSalesRep.Focus();
                    goto Final;
                }
                else if (dgvInvoice1.Rows.Count <= 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please fill the InvoiceDetails");
                    dgvInvoice1.Focus();
                    goto Final;
                }
                else
                {
                    ISValid = true;
                }
                //if (txtShipAddress.Text == "")
                //{
                //    DialogResult result = MessageBox.Show("Are you sure save this invoice without ShipAddress ?", "Confirmation", MessageBoxButtons.YesNo);
                //        ISValid = false;
                //        cmbShipAddress.Focus();
                //        MessageBox.Show("Please Select ShipAddress");
                //        goto Final;
                //}
                //if(cmbShippingMethod.SelectedIndex == 0)
                //{
                //    DialogResult result = MessageBox.Show("Are you sure save this CreditMemo without ShippingMethod ?", "Confirmation", MessageBoxButtons.YesNo);

                //        ISValid = false;
                //        cmbShippingMethod.Focus();
                //        MessageBox.Show("Please Select ShippingMethod");
                //        goto Final;

                //}
                if (ClsCommon.TaxWithoutTax == "Yes")
                {
                    if (cmbSalesTax.SelectedIndex == 0)
                    {
                        ISValid = false;
                        MessageBox.Show("Please Select Tax");
                        cmbSalesTax.Focus();
                        goto Final;
                    }
                    if (cmbSalesTax.SelectedValue == null)
                    {
                        ISValid = false;
                        MessageBox.Show("Please Select Tax");
                        cmbSalesTax.Focus();
                        goto Final;
                    }
                }

                //string InvNo = "";
                if (Mode != "update")
                {
                    DataTable dtInvoiceNo = new BALInvoiceMaster().SelectByRefNumber(new BOLInvoiceMaster() { RefNumber = txtInvoiceNo.Text });
                    if (dtInvoiceNo.Rows.Count > 0)
                    {
                        DataTable dt = new DataTable();
                        if (ClsCommon.TaxWithoutTax == "Yes")
                        {
                            dt = new BALInvoiceMaster().CASelectMaxTax("CreditMemo");
                        }
                        else
                        {
                            dt = new BALInvoiceMaster().CASelectMax("CreditMemo");
                        }
                        if (dt.Rows.Count > 0)
                        {
                            int refNumber = Convert.ToInt32(dt.Rows[0]["RefNumber"].ToString());
                            if (ClsCommon.TaxWithoutTax == "Yes")
                            {
                                //if (refNumber == 9000000 || refNumber == 0)
                                //{
                                //    txtInvoiceNo.Text = "9000000CM";
                                //    ClsCommon.WriteErrorLogs("Creditmemo 667 txtInvoiceNo.Text:-" + txtInvoiceNo.Text);
                                //}
                                //else
                                //{
                                txtInvoiceNo.Text = "CN-" + (refNumber + 1).ToString();
                                //    ClsCommon.WriteErrorLogs("Creditmemo 673 txtInvoiceNo.Text:-" + txtInvoiceNo.Text);
                                //}
                            }
                            else
                            {
                                //if (refNumber == 8000000 || refNumber == 0)
                                //{
                                //    txtInvoiceNo.Text = "8000000CM";
                                //    ClsCommon.WriteErrorLogs("Creditmemo 682 txtInvoiceNo.Text:-" + txtInvoiceNo.Text);
                                //}
                                //else
                                //{
                                txtInvoiceNo.Text = "CN-" + (refNumber + 1).ToString();
                                //    ClsCommon.WriteErrorLogs("Creditmemo 689 txtInvoiceNo.Text:-" + txtInvoiceNo.Text);
                                //}
                            }
                        }
                    }
                    //DataTable dtIncoiceNo = new BALInvoiceMaster().SelectMAX(new BOLInvoiceMaster() { });
                    //if (dtIncoiceNo.Rows.Count > 0)
                    //{
                    //    if (dtIncoiceNo.Rows[0]["RefNumber"].ToString() != "")
                    //    {
                    //        InvNo = (Convert.ToInt32(dtIncoiceNo.Rows[0]["RefNumber"].ToString()) + 1).ToString();
                    //    }
                    //}
                    //if (txtInvoiceNo.Text == InvNo)
                    //{
                    //    ISValid = true;
                    //}
                    //else
                    //{
                    //    if (InvNo != "")
                    //    {
                    //        ClsCommon.WriteErrorLogs("Here is conflict the RefNumber,Previous RefNumber:" + txtInvoiceNo.Text);
                    //        txtInvoiceNo.Text = InvNo;
                    //        ClsCommon.WriteErrorLogs("New RefNumber:" + txtInvoiceNo.Text);
                    //    }
                    //}
                }
            Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :CheckValidation. Message:" + ex.Message);
                return ISValid;
            }
        }
        private void GetAccount()
        {
            try
            {
                DataTable dtAccount = new BALAccount().SelectARAccount(new BOLAccount() { });
                DataRow dr = dtAccount.NewRow();
                dr["FullName"] = "--Select--";
                dr["ID"] = "0";
                dr["AccountType"] = "0";
                dtAccount.Rows.InsertAt(dr, 0);
                cmbAccount.DataSource = dtAccount;
                cmbAccount.DisplayMember = "FullName";
                cmbAccount.ValueMember = "ID";
                if (dtAccount.Rows.Count > 1)
                    cmbAccount.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :GetAccount. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void GetCustomer()
        {
            try
            {
                bool ViewAll = false;
                if (ClsCommon.FunctionVisibility("ViewAllInvoice", "CustomerCenter"))
                {
                    ViewAll = true;
                }
                if (ClsCommon.FunctionVisibility("CustomerNumberOnly", "CustomerCenter"))
                {
                    dtCustomer = new DataTable();
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = 0, IsCustomerNumber = 0 });
                    else if (ViewAll == true)
                    {
                        dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = 0, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                    }
                    else
                        dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = ClsCommon.UserID, IsCustomerNumber = 1 });
                }
                else
                {
                    dtCustomer = new DataTable();
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = 0, IsCustomerNumber = 0 });
                    else if (ViewAll == true)
                    {
                        dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = 0, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                    }
                    else
                        dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = ClsCommon.UserID, IsCustomerNumber = 0 });
                }
                //dtCustomer = new BALCustomerMaster().SelectAllCustomer(new BOLCustomerMaster() { });

                //DataRow dr = dtCustomer.NewRow();
                //dr["FullName"] = "--Select--";
                //dr["ID"] = "0";
                //dr["IsActive"] = "0";
                //dtCustomer.Rows.InsertAt(dr, 0);
                //cmbCustomer.DataSource = dtCustomer;
                //cmbCustomer.DisplayMember = "FullName";
                //cmbCustomer.ValueMember = "ID";

                DataRow dr = dtCustomer.NewRow();
                dr["Customer"] = "--Select--";
                dr["ID"] = "0";
                dr["ActiveStatus"] = "0";
                dtCustomer.Rows.InsertAt(dr, 0);
                cmbCustomer.DataSource = dtCustomer;
                cmbCustomer.DisplayMember = "Customer";
                cmbCustomer.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :GetCustomer. Message:" + ex.Message);
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
                cmbTerms.DataSource = dtTerms;
                cmbTerms.DisplayMember = "Name";
                cmbTerms.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :GetTerms. Message:" + ex.Message);
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
                cmbSalesRep.DataSource = dtSalesRep;
                cmbSalesRep.DisplayMember = "Name";
                cmbSalesRep.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :GetSalesRep. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void GetShipMethod()
        {
            try
            {
                DataTable dtShipMethod = new BALShipMethod().SelectShipMethodAll(new BOLShipMethod() { });
                DataRow dr = dtShipMethod.NewRow();
                dr["Name"] = "--Select--";
                dr["ID"] = "0";
                dtShipMethod.Rows.InsertAt(dr, 0);
                cmbShippingMethod.DataSource = dtShipMethod;
                cmbShippingMethod.DisplayMember = "Name";
                cmbShippingMethod.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :GetShipMethod. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        public void GetReason()
        {
            try
            {
                DataTable dtReason = new BALReasonMaster().Select(new BOLReasonMaster() { });
                DataRow dr = dtReason.NewRow();
                dr["ReasonName"] = "--Select--";
                dtReason.Rows.InsertAt(dr, 0);
                cmbCARRIERS.DataSource = dtReason;
                cmbCARRIERS.DisplayMember = "ReasonName";
                cmbCARRIERS.ValueMember = "ReasonName";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function : GetReason(). Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        public void GetGRADING()
        {
            try
            {
                DataTable dtReason = new BALGRADING().Select(new BOLReasonMaster() { });
                DataRow dr = dtReason.NewRow();
                dr["GRADINGName"] = "--Select--";
                dtReason.Rows.InsertAt(dr, 0);
                cmbGRADING.DataSource = dtReason;
                cmbGRADING.DisplayMember = "GRADINGName";
                cmbGRADING.ValueMember = "GRADINGName";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function : GetReason(). Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        public void GetAllItem()
        {
            try
            {
                //cmbMsg.DataSource = null;
                dtItem = new DataTable();
                dgvInvoice1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

                dtItem = new BALItemMaster().SelectAllItem(new BOLItemMaster() { });
                dtItem1 = dtItem.Copy();
                //if (dtItem.Rows.Count > 0)
                //{
                //    dtItem1 = new DataTable();
                //    dtItem1.Columns.Add("ID", typeof(string));
                //    dtItem1.Columns.Add("FullName", typeof(string));
                //    dtItem1.Columns.Add("ItemType", typeof(string));

                //    foreach (DataRow dr1 in dtItem.Rows)
                //    {
                //        DataRow dr2 = dtItem1.NewRow();
                //        dr2["FullName"] = dr1["FullName"].ToString() + "             " + dr1["ItemType"].ToString() + "             " + dr1["SalesDesc"].ToString();
                //        dr2["ID"] = dr1["ID"].ToString();
                //        dr2["ItemType"] = dr1["ItemType"].ToString();
                //        dtItem1.Rows.Add(dr2);
                //    }

                //}
                DataRow dr = dtItem1.NewRow();
                dr["FullName"] = "--Select--";
                dr["ID"] = "0";
                dr["ItemType"] = "0";
                dtItem1.Rows.InsertAt(dr, 0);
                cmbItem.DataSource = dtItem1;
                cmbItem.DisplayMember = "FullName";
                cmbItem.ValueMember = "ID";
                cmbItem.SelectedIndex = 0;

                DataRow dr2 = dtItem1.NewRow();
                dr2["FullName"] = "ADD ITEM";
                dr2["ID"] = "-1";
                dr2["ItemType"] = "0";
                dtItem1.Rows.InsertAt(dr2, 1);
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :GetAllItem. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void GetShipAddress(Int32 CustomerID)
        {
            try
            {
                DataTable dtShipAdd = new BALAddressMaster().SelectAddressName(new BOLAddressMaster() { ReferenceID = CustomerID });
                DataRow dr = dtShipAdd.NewRow();
                dr["AddressName"] = "ADD NEW";
                dr["ID"] = "-1";
                dr["ReferenceID"] = "0";
                dr["ReferenceType"] = "0";
                dtShipAdd.Rows.InsertAt(dr, dtShipAdd.Rows.Count);

                DataRow dr1 = dtShipAdd.NewRow();
                dr1["AddressName"] = "--Select--";
                dr1["ID"] = "0";
                dr1["ReferenceID"] = "0";
                dr1["ReferenceType"] = "0";
                dtShipAdd.Rows.InsertAt(dr1, 0);

                cmbShipAddress.DataSource = dtShipAdd;
                cmbShipAddress.DisplayMember = "AddressName";
                cmbShipAddress.ValueMember = "ID";


                cmbShipAddress.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :GetShipAddress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        //Services
        private void LoadFedExService()
        {
            try
            {
                DataTable dtService = new DataTable();

                dtService.Columns.Add(new DataColumn("Code"));
                dtService.Columns.Add(new DataColumn("Description"));

                dtService.Rows.Add("00", "Select Service");
                dtService.Rows.Add("01", "fedex_2_day");
                dtService.Rows.Add("02", "fedex_2_day_am");
                dtService.Rows.Add("03", "fedex_2_day_am_one_rate");
                dtService.Rows.Add("04", "fedex_2_day_one_rate");
                dtService.Rows.Add("05", "fedex_distance_deferred");
                dtService.Rows.Add("06", "fedex_europe_first_international_priority");
                dtService.Rows.Add("07", "fedex_express_saver");
                dtService.Rows.Add("08", "fedex_express_saver_one_rate");
                dtService.Rows.Add("09", "fedex_first_overnight");
                dtService.Rows.Add("10", "fedex_first_overnight_one_rate");
                dtService.Rows.Add("11", "fedex_ground");
                dtService.Rows.Add("12", "fedex_ground_home_delivery");
                dtService.Rows.Add("13", "fedex_international_economy");
                dtService.Rows.Add("14", "fedex_international_first");
                dtService.Rows.Add("15", "fedex_international_priority");
                dtService.Rows.Add("16", "fedex_next_day_afternoon");
                dtService.Rows.Add("17", "fedex_next_day_early_morning");
                dtService.Rows.Add("18", "fedex_next_day_end_of_day");
                dtService.Rows.Add("19", "fedex_next_day_mid_morning");
                dtService.Rows.Add("20", "fedex_priority_overnight");
                dtService.Rows.Add("21", "fedex_priority_overnight_one_rate");
                dtService.Rows.Add("22", "fedex_same_day");
                dtService.Rows.Add("23", "fedex_same_day_city");
                dtService.Rows.Add("24", "fedex_standard_overnight");
                dtService.Rows.Add("25", "fedex_standard_overnight_one_rate");

                cmbService.DataSource = dtService;
                cmbService.DisplayMember = "Description";
                cmbService.ValueMember = "Code";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :LoadFedExService. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void LoadService()
        {
            try
            {
                if (cmbShippingMethod.SelectedIndex > 0)
                {
                    if (cmbShippingMethod.Text.ToLower().Contains("federal express") == true || cmbShippingMethod.Text.ToLower().Contains("fedex") == true)
                    {
                        LoadFedExService();
                    }
                    else if (cmbShippingMethod.Text.ToLower() == "ups")
                    {
                        //LoadUPSService();
                        GetShipMethod();
                    }
                    else
                        cmbService.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :LoadService. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void cmbShippingMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadService();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :cmbShippingMethod_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void InvoiceNumber(string Tax)
        {
            try
            {
                if (Mode == "insert")
                {
                    txtInvoiceNo.Text = "";
                Top:
                    DataTable dtInvoiceNo;
                    if (Tax == "Yes")
                    {
                        dtInvoiceNo = new BALInvoiceMaster().CASelectMaxTax("CreditMemo");
                    }
                    else
                    {
                        dtInvoiceNo = new BALInvoiceMaster().CASelectMax("CreditMemo");
                    }
                    if (dtInvoiceNo.Rows.Count > 0)
                    {
                        int refNumber = Convert.ToInt32(dtInvoiceNo.Rows[0]["RefNumber"].ToString());

                        if (Tax == "Yes")
                        {
                            //if (refNumber == 9000000 || refNumber == 0)
                            //{
                            //    txtInvoiceNo.Text = "9000000" + "CM";
                            //    ClsCommon.WriteErrorLogs("Creditmemo 1095 txtInvoiceNo.Text:-" + txtInvoiceNo.Text);

                            //}
                            //else
                            //{
                            txtInvoiceNo.Text = "CN-" + (refNumber + 1).ToString();
                            //    ClsCommon.WriteErrorLogs("Creditmemo 1101 txtInvoiceNo.Text:-" + txtInvoiceNo.Text);
                            //}
                        }
                        else
                        {
                            //if (refNumber == 8000000 || refNumber == 0)
                            //{
                            //    txtInvoiceNo.Text = "8000000" + "CM";
                            //    ClsCommon.WriteErrorLogs("Creditmemo 1110 txtInvoiceNo.Text:-" + txtInvoiceNo.Text);
                            //}
                            //else
                            //{
                            txtInvoiceNo.Text = "CN-" + (refNumber + 1).ToString();
                            //    ClsCommon.WriteErrorLogs("Creditmemo 1117 txtInvoiceNo.Text:-" + txtInvoiceNo.Text);
                            //}
                        }
                        DataTable dt = new BALInvoiceMaster().SelectByRefNumber(new BOLInvoiceMaster() { RefNumber = txtInvoiceNo.Text });
                        if (dt.Rows.Count > 0)
                        {
                            goto Top;
                        }
                    }
                    //else
                    //{
                    //    if (Tax == "Yes")
                    //    {
                    //        txtInvoiceNo.Text = "9000000" + "CM";
                    //        ClsCommon.WriteErrorLogs("Creditmemo 1132 txtInvoiceNo.Text:-" + txtInvoiceNo.Text);

                    //    }
                    //    else
                    //    {
                    //        txtInvoiceNo.Text = "8000000" + "CM";
                    //        ClsCommon.WriteErrorLogs("Creditmemo 1138 txtInvoiceNo.Text:-" + txtInvoiceNo.Text);


                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster, Function:InvoiceNumber. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        //public void InvoiceNumber()
        //{
        //    try
        //    {
        //        if (Mode == "insert")
        //        {
        //            txtInvoiceNo.Text = "";


        //            Top:
        //            DataTable dtIncoiceNo = new BALCreditMemo().SelectMAX(new BOLCreditMemo() { });
        //            if (dtIncoiceNo.Rows.Count > 0)
        //            {
        //                if (dtIncoiceNo.Rows[0]["RefNumber"].ToString() != "")
        //                {
        //                    Random rnd = new Random();
        //                    int num = Convert.ToInt32(dtIncoiceNo.Rows[0]["RefNumber"].ToString());
        //                    num += rnd.Next(1,5);
        //                    txtInvoiceNo.Text = num.ToString() + "CM";

        //                    DataTable dt = new BALCreditMemo().SelectByRefNumber(new BOLCreditMemo() { RefNumber = txtInvoiceNo.Text });
        //                    if (dt.Rows.Count > 0)
        //                    {
        //                        goto Top;
        //                    }
        //                }
        //                else
        //                {
        //                    txtInvoiceNo.Text = "1" + "CM";
        //                }
        //            }
        //            else if (dtIncoiceNo.Rows.Count == 0)
        //                txtInvoiceNo.Text = "1" + "CM";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :InvoiceNumber. Message:" + ex.Message);
        //        MessageBox.Show("Error:" + ex.Message);
        //    }
        //}
        private void Clear()
        {
            cmbCustomer.SelectedIndex = 0;
            cmbAccount.SelectedIndex = 0;
            cmbTerms.SelectedIndex = 0;
            cmbSalesRep.SelectedIndex = 0;
            cmbShippingMethod.SelectedIndex = 0;
            cmbService.DataSource = null;
            cmbShipAddress.DataSource = null;
            dtpInvoiceDate.Value = DateTime.Now;
            dtpDuedate.Value = DateTime.Now;
            txtBillAddress.Text = "";
            txtShipAddress.Text = "";
            txtPONumber.Text = "";
            txtInvoiceNo.Text = "";
            dtpShipDate.Value = DateTime.Now;
            txtMemo.Text = "";
            lblTotal.Text = "0.00";
            lblPaymentApplied.Text = "0.00";
            lblBalanceDue.Text = "0.00";
            dgvInvoice1.DataSource = null;
            dgvShippingMethod.Rows.Clear();
            pctPaidInvoice.Visible = false;
            imgShipped.Visible = false;
            btnSaveandClose.Enabled = true;
            btnSaveandNew.Enabled = true;
            //btnSaveAndEmail.Enabled = true;
            txtaddrID.Text = "0";

            cmbItem.SelectedIndex = 0;
            txtDesc.Text = "";
            txtRate.Text = "";
            txtQty.Text = "";
            txtAmount.Text = "";
            txtLowestPrice.Text = "";
            txtCostPrice.Text = "";
            txtPrice1.Text = "";
            txtPrice2.Text = "";
            txtPrice3.Text = "";
            txtType.Text = "";
            txtItemType.Text = "";
            txtItemEdit.Text = "";
            txtIMEINumber.Text = "";
            cmbCARRIERS.SelectedIndex = 0;
            cmbGRADING.SelectedIndex = 0;


            //Hiren
            txtWebPrice.Text = "";
            //Bhumika
            lblTaxPercentage.Text = "(0.0%)";
            lblTaxAmount.Text = "0.00";
            lblSubTotal.Text = "0.00";
            //princy change
            cmbSalesTax.SelectedIndex = 0;
            cmbMsg.SelectedIndex = -1;

        }
        public void test()
        {
            Mode = "insert";
        }
        public void NonEditableField()
        {
            btnSaveandClose.Visible = false;
            btnSaveandNew.Visible = false;
            //btnSaveAndEmail.Visible = false;
            btnClear.Visible = false;
            btnApprove.Visible = true;
            btnReject.Visible = true;
            btnFindInvoice.Enabled = false;
            btnNewInvoice.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnPrint.Enabled = false;
            btnQuickReport.Enabled = false;
            btnTransactionHistory.Enabled = false;
            cmbCustomer.Enabled = false;
            cmbAccount.Enabled = false;
            dtpInvoiceDate.Enabled = false;
            txtInvoiceNo.Enabled = false;
            cmbShipAddress.Enabled = false;
            txtPONumber.Enabled = false;
            cmbTerms.Enabled = false;
            cmbSalesRep.Enabled = false;
            dtpDuedate.Enabled = false;
            dtpShipDate.Enabled = false;
            cmbShippingMethod.Enabled = false;
            cmbService.Enabled = false;
            txtMemo.Enabled = false;
            dgvInvoice1.ReadOnly = false;
        }
        public void EnableField()
        {
            cmbPrice.Enabled = true;
        }
        public void EditableField()
        {

            cmbPrice.Enabled = true;
            //btnSaveAndEmail.Visible = true;
            btnSaveandClose.Visible = true;
            btnSaveandNew.Visible = true;
            btnClear.Visible = true;
            btnApprove.Visible = false;
            btnReject.Visible = false;
            btnFindInvoice.Enabled = true;
            btnNewInvoice.Enabled = true;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnPrint.Enabled = true;
            btnQuickReport.Enabled = true;
            btnTransactionHistory.Enabled = true;
            cmbCustomer.Enabled = true;
            cmbAccount.Enabled = true;
            dtpInvoiceDate.Enabled = true;
            txtInvoiceNo.Enabled = false;
            cmbShipAddress.Enabled = true;
            txtPONumber.Enabled = true;
            cmbTerms.Enabled = true;
            cmbSalesRep.Enabled = true;
            dtpDuedate.Enabled = true;
            dtpShipDate.Enabled = true;
            cmbShippingMethod.Enabled = true;
            cmbService.Enabled = true;
            txtMemo.Enabled = true;
            dgvInvoice1.ReadOnly = false;
            Count = 0;
            Allow = 0;
        }
        public void AllowLowestPrice()
        {
            try
            {
                if (ClsCommon.UserType != "Admin" && ClsCommon.UserType != "admin")
                {
                    DataTable dtcustomer = new DataTable();
                    DataTable dtLoadFile = new DataTable();

                    dtcustomer = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                    if (dtcustomer.Rows.Count > 0)
                    {
                        if (dtcustomer.Rows[0]["AllowLowestPrice"].ToString() == "1")
                        {
                            radLabel22.Visible = false;
                            //txtLowestPrice.Visible = true;
                            txtLowestPrice.Visible = false;
                            label2.Visible = false;
                            txtCostPrice.Visible = false;
                            Allow = 1;
                        }
                        else
                        {
                            radLabel22.Visible = false;
                            txtLowestPrice.Visible = false;
                            label2.Visible = false;
                            txtCostPrice.Visible = false;
                            Allow = 0;
                        }

                    }
                    dtLoadFile = new BALSalesRepMaster().SelectByID(new BOLSalesRepMaster() { ID = Convert.ToInt32(ClsCommon.UserID) });
                    if (dtLoadFile.Rows.Count > 0)
                    {
                        if (dtLoadFile.Rows[0]["LowestPriceAllow"].ToString() == "1")
                        {
                            radLabel22.Visible = true;
                            //txtLowestPrice.Visible = true;
                            txtLowestPrice.Visible = true;
                            label2.Visible = true;
                            txtCostPrice.Visible = true;
                        }
                        else
                        {
                            label2.Visible = false;
                            txtCostPrice.Visible = false;
                            radLabel22.Visible = false;
                            //txtLowestPrice.Visible = false;
                            txtLowestPrice.Visible = false;
                        }
                    }
                }
                else
                {
                    radLabel22.Visible = true;
                    txtLowestPrice.Visible = true;
                    label2.Visible = true;
                    txtCostPrice.Visible = true;
                }
            }

            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :AllowLowestPrice. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        public void CustomerDependTax(DataTable dtData)
        {
            if (ClsCommon.TaxWithoutTax == "Yes" && Mode == "insert")
            {
                cmbSalesTax.Enabled = true;
                DataTable dtCus = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                if (dtCus.Rows.Count > 0)
                {
                    if (dtCus.Rows[0]["SalesTaxID"].ToString() != "")
                    {
                        cmbSalesTax.SelectedValue = dtCus.Rows[0]["SalesTaxID"].ToString();
                    }
                    else
                    {
                        cmbSalesTax.SelectedValue = 0;
                        lblTaxPercentage.Text = "(0.0%)";
                        lblTaxAmount.Text = "0.00";
                    }
                }
                else
                {
                    cmbSalesTax.SelectedValue = 0;
                    lblTaxPercentage.Text = "(0.0%)";
                    lblTaxAmount.Text = "0.00";
                }
            }
            else if (ClsCommon.TaxWithoutTax == "Yes" && Mode == "update")
            {
                if (dtData.Rows.Count > 0)
                {
                    if (dtData.Rows[0]["TaxID"].ToString() != "")
                    {
                        cmbSalesTax.Enabled = true;
                        cmbSalesTax.SelectedValue = dtData.Rows[0]["TaxID"].ToString();
                    }
                }
            }
            else if (ClsCommon.TaxWithoutTax == "No")
            {
                cmbSalesTax.Enabled = false;
            }
            else if (ClsCommon.TaxWithoutTax == "" && Mode == "update")
            {
                if (dtData.Rows.Count > 0)
                {
                    if (dtData.Rows[0]["TaxID"].ToString() != "" && dtData.Rows[0]["TaxID"].ToString() != "0")
                    {
                        cmbSalesTax.Enabled = true;
                        cmbSalesTax.SelectedValue = dtData.Rows[0]["TaxID"].ToString();
                    }
                    else
                    {
                        //cmbSalesTax.Enabled = false;
                        cmbSalesTax.SelectedValue = 0;
                        lblTaxPercentage.Text = "(0.0%)";
                        lblTaxAmount.Text = "0.00";
                    }
                }
            }
        }
        private void LoadInvoiceData()
        {
            try
            {
                Mode = "update";
                dgvInvoice1.DataSource = null;
                LoadTable();
                imgShipped.Visible = false;
                Cursor.Current = Cursors.WaitCursor;
                txtID.Text = ""; cmbService.DataSource = null;
                GetAccount();
                LoadItem();
                isLoad = true;
                LoadCustomermessage();
                GetCustomer();
                GetTerms();
                GetSalesRep();
                //  LoadUPSService1();
                GetShipMethod();
                GetReason();
                GetGRADING();
                InvoiceNumber(ClsCommon.TaxWithoutTax);
                GetAllItem();
                TotalBalance = 0; dtLoadData = new DataTable();
                dtLoadData = new BALCreditMemo().SelectByID(new BOLCreditMemo() { ID = Convert.ToInt32(InvoiceID) });
                if (dtLoadData.Rows.Count > 0)
                {
                    cmbCustomer.SelectedValue = dtLoadData.Rows[0]["CustomerID"].ToString();
                    CustomerDependTax(dtLoadData);

                    if (dtLoadData.Rows[0]["PriceTier"].ToString() != "")
                    {
                        cmbPrice.Text = dtLoadData.Rows[0]["PriceTier"].ToString();
                    }
                    else
                    {
                        cmbPrice.Text = "";
                    }
                    txtID.Text = dtLoadData.Rows[0]["ID"].ToString();

                    if (dtLoadData.Rows[0]["ARAccountID"].ToString() != "")
                    {
                        cmbAccount.SelectedValue = dtLoadData.Rows[0]["ARAccountID"].ToString();
                    }
                    if (dtLoadData.Rows[0]["TxnDate"].ToString() != "")
                        dtpInvoiceDate.Value = Convert.ToDateTime(dtLoadData.Rows[0]["TxnDate"].ToString());
                    txtInvoiceNo.Text = dtLoadData.Rows[0]["RefNumber"].ToString();
                    txtPONumber.Text = dtLoadData.Rows[0]["PONumber"].ToString();
                    if (dtLoadData.Rows[0]["TermsID"].ToString() != "")
                    {
                        cmbTerms.SelectedValue = dtLoadData.Rows[0]["TermsID"].ToString();
                    }
                    if (dtLoadData.Rows[0]["SalesRepID"].ToString() != "")
                    {
                        cmbSalesRep.SelectedValue = dtLoadData.Rows[0]["SalesRepID"].ToString();
                    }
                    //princy 04-04-2025
                    //princy 07-04-2025
                    if (dtLoadData.Rows[0]["CustomerMessage"].ToString() != "")
                    {
                        cmbMsg.SelectedValue = dtLoadData.Rows[0]["CustomerMessage"].ToString();
                    }
                    //DataView dv = dtCustomermessage.DefaultView;
                    //dv.RowFilter = "LogName='" + dtLoadData.Rows[0]["CustomerMessage"].ToString() + "'";
                    //if (dv.Count > 0)
                    //{
                    //    cmbMsg.Text = dtLoadData.Rows[0]["CustomerMessage"].ToString();
                    //}
                    //else
                    //{
                    //    cmbMsg.SelectedValue = -1;
                    //}
                    if (dtLoadData.Rows[0]["ShipDate"].ToString() != "")
                        dtpShipDate.Value = Convert.ToDateTime(dtLoadData.Rows[0]["ShipDate"].ToString());
                    if (dtLoadData.Rows[0]["DueDate"].ToString() != "")
                        dtpDuedate.Value = Convert.ToDateTime(dtLoadData.Rows[0]["DueDate"].ToString());
                    if (dtLoadData.Rows[0]["ShipMethodID"].ToString() != "")
                    {
                        //cmbShippingMethod.SelectedValue = dtLoadData.Rows[0]["ShipMethodID"].ToString();
                        cmbShippingMethod.SelectedValue = dtLoadData.Rows[0]["ShipMethodID"].ToString();
                    }
                    if (dtLoadData.Rows[0]["ServiceID"].ToString() != "")
                    {
                        if (Convert.ToInt32(dtLoadData.Rows[0]["ServiceID"].ToString().Length) <= 1)
                        {
                            cmbService.SelectedValue = "0" + dtLoadData.Rows[0]["ServiceID"].ToString();
                        }
                        else
                        {
                            cmbService.SelectedValue = dtLoadData.Rows[0]["ServiceID"].ToString();
                        }
                    }
                    txtMemo.Text = dtLoadData.Rows[0]["Memo"].ToString();
                    LoadAddressDetails();
                    if (dtLoadData.Rows[0]["ShipAddressID"].ToString() != "")
                    {
                        txtShipAddress.Text = "";
                        cmbShipAddress.SelectedValue = dtLoadData.Rows[0]["ShipAddressID"].ToString();
                        cmbShipAddress_SelectedIndexChanged(null, null);
                    }
                    //Bhumika
                    lblSubTotal.Text = dtLoadData.Rows[0]["Total"].ToString();
                    if (dtLoadData.Rows[0]["TaxAmount"].ToString() != "" && dtLoadData.Rows[0]["TaxAmount"].ToString() != "0.00")
                    {

                        lblTotal.Text = decimal.Round(Convert.ToDecimal(dtLoadData.Rows[0]["Total"].ToString()) - Convert.ToDecimal(dtLoadData.Rows[0]["TaxAmount"].ToString()), 2).ToString();
                        lblTaxAmount.Text = dtLoadData.Rows[0]["TaxAmount"].ToString();
                        lblTaxPercentage.Text = "(" + dtLoadData.Rows[0]["TaxPercent"].ToString() + "%)";
                    }
                    else
                    {
                        lblTotal.Text = dtLoadData.Rows[0]["Total"].ToString();
                        lblTaxAmount.Text = "0.00";
                        lblTaxPercentage.Text = "(0.0%)";
                        //cmbSalesTax.Enabled = false;
                    }

                    if (dtLoadData.Rows[0]["Total"].ToString() != "")
                        TotalBalance = Convert.ToDecimal(dtLoadData.Rows[0]["Total"].ToString());
                    lblPaymentApplied.Text = dtLoadData.Rows[0]["AppliedAmount"].ToString();
                    lblBalanceDue.Text = dtLoadData.Rows[0]["BalanceDue"].ToString();
                    DataTable dtInvoice = new BALCreditMemoDetails().SelectByID(new BOLCreditMemoDetails() { InvoiceID = Convert.ToInt32(txtID.Text) });

                    //LastThree Shipping Method
                    DataTable dtShipping = new BALCreditMemo().SelectLastThreeShippingMethod(new BOLCreditMemo() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                    if (dtShipping.Rows.Count > 0)
                    {
                        int a = 0;
                        dgvShippingMethod.Rows.Clear();
                        for (int b = 0; b < dtShipping.Rows.Count; b++)
                        {
                            dgvShippingMethod.Rows.Add();
                            dgvShippingMethod.Rows[a].Cells[0].Value = dtShipping.Rows[b]["RefNumber"].ToString();
                            dgvShippingMethod.Rows[a].Cells[1].Value = dtShipping.Rows[b]["ShipMethod"].ToString();
                            a++;
                        }
                    }
                    else
                        dgvShippingMethod.Rows.Clear();

                    if (dtInvoice.Rows.Count > 0)
                    {

                        for (int i = 0; i <= dtInvoice.Rows.Count - 1; i++)
                        {
                            if (dtInvoice.Rows[i]["ItemFullName"].ToString().ToLower() != "shipping")
                            {
                                DataTable dtReject = new BALCustomerRequest().SelectForReject(dtLoadData.Rows[0]["RefNumber"].ToString(), dtInvoice.Rows[i]["ItemID"].ToString());
                                DataTable dtRejectChk = new BALCustomerRequest().SelectForRejectCheck(dtLoadData.Rows[0]["RefNumber"].ToString(), dtInvoice.Rows[i]["ItemID"].ToString());


                                DataRow dr = dtGridItem.NewRow();
                                dr["SrNo"] = dtInvoice.Rows[i]["SrNo"].ToString();
                                dr["ID"] = dtInvoice.Rows[i]["ItemID"].ToString();
                                dr["ITEM"] = dtInvoice.Rows[i]["ItemFullName"].ToString();
                                dr["DESCRIPTION"] = dtInvoice.Rows[i]["Decs"].ToString();
                                dr["QTY"] = dtInvoice.Rows[i]["Quantity"].ToString();
                                dr["RATE"] = dtInvoice.Rows[i]["Rate"].ToString();
                                dr["AMOUNT"] = dtInvoice.Rows[i]["Amount"].ToString();
                                dr["LOWESTPRICE"] = dtInvoice.Rows[i]["LowestPrice"].ToString();
                                dr["COSTPRICE"] = dtInvoice.Rows[i]["Cost"].ToString();
                                //Hiren
                                dr["WEBPRICE"] = dtInvoice.Rows[i]["WebPrice"].ToString();

                                dr["Type"] = 1;
                                dr["ItemType"] = dtInvoice.Rows[i]["ItemType"].ToString();
                                dr["IMEINumber"] = dtInvoice.Rows[i]["IMEINumber"].ToString().Replace(",", "\n");
                                dr["CARRIERS"] = dtInvoice.Rows[i]["Reason"].ToString();
                                dr["GRADING"] = dtInvoice.Rows[i]["GRADING"].ToString();
                                dtGridItem.Rows.Add(dr);

                                dgvInvoice1.DataSource = dtGridItem;

                                int j = dgvInvoice1.Rows.Count - 1;

                                DataTable dtSale = new BALItemSaleHistory().SelectLastThreeSale(new BOLItemSaleHistory() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), ItemID = Convert.ToInt32(dgvInvoice1.Rows[j].Cells["ID"].Value) });
                                if (dtSale.Rows.Count > 0)
                                {
                                    for (int k = 0; k < dtSale.Rows.Count; k++)
                                    {
                                        if (k == 0)
                                            dgvInvoice1.Rows[j].Cells["PRICE1"].Value = dtSale.Rows[k]["SalePrice"].ToString();
                                        if (k == 1)
                                            dgvInvoice1.Rows[j].Cells["PRICE2"].Value = dtSale.Rows[k]["SalePrice"].ToString();
                                        if (k == 2)
                                            dgvInvoice1.Rows[j].Cells["PRICE3"].Value = dtSale.Rows[k]["SalePrice"].ToString();
                                    }
                                }

                                //Hiren
                                foreach (DataGridViewRow row in dgvInvoice1.Rows)
                                {
                                    string tax = dtInvoice.Rows[i]["Tax"].ToString();
                                    DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();
                                    if (row.Cells["Tax"].Value == null || string.IsNullOrEmpty(row.Cells["Tax"].Value.ToString()))
                                    {
                                        if (tax == "Tax")
                                        {
                                            comboBoxCell.Items.Add("Tax");
                                            comboBoxCell.Items.Add("Non");
                                            comboBoxCell.Value = "Tax";
                                        }
                                        else
                                        {
                                            comboBoxCell.Items.Add("Non");
                                            comboBoxCell.Items.Add("Tax");
                                            comboBoxCell.Value = "Non";
                                        }
                                        row.Cells[18] = comboBoxCell;
                                    }
                                }

                                if (dtReject.Rows.Count > 0 && dtLoadData.Rows[0]["PandingInvoice"].ToString() == "0" && dtRejectChk.Rows.Count == 0)
                                {
                                    dgvInvoice1.Rows[i].Cells[3].Style.ForeColor = Color.Red;
                                    dgvInvoice1.Rows[i].Cells[4].Style.ForeColor = Color.Red;
                                    dgvInvoice1.Rows[i].Cells[5].Style.ForeColor = Color.Red;
                                    dgvInvoice1.Rows[i].Cells[6].Style.ForeColor = Color.Red;
                                }
                            }
                        }

                        DataRow[] drShipping = dtInvoice.Select("[ItemFullName]='shipping'");
                        if (drShipping.Length > 0)
                        {
                            try
                            {
                                dtShipping = drShipping.CopyToDataTable();

                                DataTable dtReject = new BALCustomerRequest().SelectForReject(dtLoadData.Rows[0]["RefNumber"].ToString(), dtShipping.Rows[0]["ItemID"].ToString());
                                DataTable dtRejectChk = new BALCustomerRequest().SelectForRejectCheck(dtLoadData.Rows[0]["RefNumber"].ToString(), dtShipping.Rows[0]["ItemID"].ToString());


                                DataRow dr = dtGridItem.NewRow();
                                dr["SrNo"] = dtShipping.Rows[0]["SrNo"].ToString();
                                dr["ID"] = dtShipping.Rows[0]["ItemID"].ToString();
                                dr["ITEM"] = dtShipping.Rows[0]["ItemFullName"].ToString();
                                dr["DESCRIPTION"] = dtShipping.Rows[0]["Decs"].ToString();
                                dr["QTY"] = dtShipping.Rows[0]["Quantity"].ToString();
                                dr["RATE"] = dtShipping.Rows[0]["Rate"].ToString();
                                dr["AMOUNT"] = dtShipping.Rows[0]["Amount"].ToString();
                                dr["LOWESTPRICE"] = dtShipping.Rows[0]["LowestPrice"].ToString();
                                dr["Type"] = 1;
                                dr["ItemType"] = dtShipping.Rows[0]["ItemType"].ToString();
                                dr["IMEINumber"] = dtShipping.Rows[0]["IMEINumber"].ToString();
                                dr["CARRIERS"] = dtShipping.Rows[0]["Reason"].ToString();
                                dr["GRADING"] = dtShipping.Rows[0]["GRADING"].ToString();
                                dtGridItem.Rows.Add(dr);

                                dgvInvoice1.DataSource = dtGridItem;

                                int j = dgvInvoice1.Rows.Count - 1;

                                DataTable dtSale = new BALItemSaleHistory().SelectLastThreeSale(new BOLItemSaleHistory() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), ItemID = Convert.ToInt32(dgvInvoice1.Rows[j].Cells["ID"].Value) });
                                if (dtSale.Rows.Count > 0)
                                {
                                    for (int k = 0; k < dtSale.Rows.Count; k++)
                                    {
                                        if (k == 0)
                                            dgvInvoice1.Rows[j].Cells["PRICE1"].Value = dtSale.Rows[k]["SalePrice"].ToString();
                                        if (k == 1)
                                            dgvInvoice1.Rows[j].Cells["PRICE2"].Value = dtSale.Rows[k]["SalePrice"].ToString();
                                        if (k == 2)
                                            dgvInvoice1.Rows[j].Cells["PRICE3"].Value = dtSale.Rows[k]["SalePrice"].ToString();
                                    }
                                }

                                if (dtReject.Rows.Count > 0 && dtLoadData.Rows[0]["PandingInvoice"].ToString() == "0" && dtRejectChk.Rows.Count == 0)
                                {
                                    dgvInvoice1.Rows[dgvInvoice1.Rows.Count - 1].Cells[3].Style.ForeColor = Color.Red;
                                    dgvInvoice1.Rows[dgvInvoice1.Rows.Count - 1].Cells[4].Style.ForeColor = Color.Red;
                                    dgvInvoice1.Rows[dgvInvoice1.Rows.Count - 1].Cells[5].Style.ForeColor = Color.Red;
                                    dgvInvoice1.Rows[dgvInvoice1.Rows.Count - 1].Cells[6].Style.ForeColor = Color.Red;
                                }
                            }
                            catch (Exception ex)
                            {
                                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :LoadInvoiceData. Message:" + ex.Message);
                                MessageBox.Show("Error:" + ex.Message);
                            }
                        }

                        //
                        SUMForEdit();
                        if (dtLoadData.Rows[0]["IsShipping"].ToString() == "1")
                        {
                            imgShipped.Visible = true;
                        }
                        else
                        {
                            imgShipped.Visible = false;
                        }
                    }
                    if (dtLoadData.Rows[0]["PaidInvoice"].ToString() == "2")
                    {
                        pctPaidInvoice.Visible = true;
                    }
                    else
                    {
                        pctPaidInvoice.Visible = false;
                        btnSaveandClose.Enabled = true;
                        btnSaveandNew.Enabled = true;
                        //btnSaveAndEmail.Enabled = true;
                        btnClear.Enabled = true;
                    }
                    if (ClsCommon.UserType.ToLower() != "admin")
                    {
                        if (dtLoadData.Rows[0]["TxnDate"].ToString() != "")
                        {
                            if (DateTime.Now.Date != Convert.ToDateTime(dtLoadData.Rows[0]["TxnDate"].ToString()).Date)
                            {
                                btnSaveandClose.Enabled = false;
                                btnSaveandNew.Enabled = false;
                                btnDelete.Enabled = false;
                                //btnSaveAndEmail.Enabled = false;

                                btnAdd.Enabled = false;
                                btnSave.Enabled = false;
                                dgvInvoice1.Enabled = true;

                                dgvInvoice1.Columns[19].ReadOnly = true;
                                dgvInvoice1.Columns[20].ReadOnly = true;

                                //dgvInvoice1.FirstDisplayedScrollingRowIndex = dgvInvoice1.RowCount - 1;


                                //dgvInvoice1.DefaultCellStyle.BackColor = Color.Black;
                                dgvInvoice1.DefaultCellStyle.ForeColor = Color.Black;


                                MessageBox.Show("You can update and Delete only current day CreditMemo..!!!");
                            }
                            else
                            {
                                btnSaveandClose.Enabled = true;
                                btnSaveandNew.Enabled = true;
                                btnDelete.Enabled = true;
                                //btnSaveAndEmail.Enabled = true;
                                btnSave.Enabled = true;

                                btnAdd.Enabled = true;
                                dgvInvoice1.Enabled = true;
                                dgvInvoice1.DefaultCellStyle.ForeColor = Color.Black;

                            }
                        }
                        else
                        {
                            btnSaveandClose.Enabled = true;
                            btnSaveandNew.Enabled = true;
                            btnDelete.Enabled = true;
                            //btnSaveAndEmail.Enabled = true;
                            btnSave.Enabled = true;

                            btnAdd.Enabled = true;
                            dgvInvoice1.Enabled = true;
                            dgvInvoice1.DefaultCellStyle.ForeColor = Color.Black;

                        }
                    }
                    else
                    {
                        btnAdd.Enabled = true;
                        dgvInvoice1.Columns[19].ReadOnly = false;
                        dgvInvoice1.Columns[20].ReadOnly = false;
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :LoadInvoiceData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                Cursor.Current = Cursors.Default;
            }
        }
        public void LoadData(string ID)
        {
            try
            {
                cmbPrice.Enabled = false;
                DisplayPrice();
                InvoiceID = Convert.ToInt32(ID);
                LoadInvoiceData();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :LoadData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        private void AdminRequestSend(string InvoiceNo)
        {
            try
            {

                DataTable dtApprove = new BALCreditMemoRequest().SelectByID(new BOLCreditMemoRequest() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), CreditMemoNumber = InvoiceNo });
                if (dtApprove.Rows.Count == 0)
                {
                    objBOLCreditMemo.CreditMemoNumber = InvoiceNo;
                    objBOLCreditMemo.SalesRepID = ClsCommon.UserID;
                    objBOLCreditMemo.CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue);
                    objBOLCreditMemo.Status = 0;
                    objBOLCreditMemo.CreatedTime = DateTime.Now;
                    objBOLCreditMemo.ModifiedTime = DateTime.Now;
                    objBOLCreditMemo.IsActive = 1;
                    objBALCreditMemo.Insert(objBOLCreditMemo);
                }
                else
                {
                    objBOLCreditMemo.ID = Convert.ToInt32(dtApprove.Rows[0]["ID"].ToString());
                    objBOLCreditMemo.CreditMemoNumber = InvoiceNo;
                    objBOLCreditMemo.SalesRepID = ClsCommon.UserID;
                    objBOLCreditMemo.CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue);
                    objBOLCreditMemo.Status = 0;
                    objBOLCreditMemo.ModifiedTime = DateTime.Now;
                    objBOLCreditMemo.IsActive = 1;
                    objBALCreditMemo.Update(objBOLCreditMemo);
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :AdminRequestSend. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private Boolean CheckPendingInvoice()
        {
            Boolean ISValid = false;
            try
            {
                if (Mode == "update")
                {
                    // Approve Data Check
                    for (int i = 0; i < dgvInvoice1.Rows.Count; i++)
                    {
                        if (dgvInvoice1.Rows[i].Cells["Item"].Value != null)
                        {
                            if (dgvInvoice1.Rows[i].Cells["ItemType"].Value.ToString() != "GroupItem" && dgvInvoice1.Rows[i].Cells["ItemType"].Value.ToString() != "SubItem" && dgvInvoice1.Rows[i].Cells["ItemType"].Value.ToString() != "GroupTotal")
                            {
                                DataTable dtApprove = new BALCustomerRequest().SelectApprovedStatus(new BOLCustomerRequest() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), ItemID = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["ID"].Value) });
                                if (dtApprove.Rows.Count > 0)
                                {
                                    if (Convert.ToInt32(dtApprove.Rows[0]["UseAllowesNo"].ToString()) > 0 || Convert.ToInt32(dtApprove.Rows[0]["UseCurrentInvoice"].ToString()) > 0)
                                    {
                                        if (dtApprove.Rows[0]["LowestPrice"].ToString() != null && dtApprove.Rows[0]["LowestPrice"].ToString() != "")
                                        {
                                            if (Convert.ToDecimal(dtApprove.Rows[0]["LowestPrice"].ToString()) > Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Rate"].Value))
                                            {
                                                MessageBox.Show("Please Approved price set");
                                                ISValid = false;
                                            }
                                            else
                                                ISValid = true;
                                        }
                                    }
                                    else if (Convert.ToInt16(dtApprove.Rows[0]["UseNoOFDays"].ToString()) > 0)
                                    {
                                        Int16 NoOfDays = Convert.ToInt16(dtApprove.Rows[0]["UseNoOFDays"].ToString());
                                        string Date = DateTime.Now.ToString("MM-dd-yyyy");
                                        if (Convert.ToDateTime(dtApprove.Rows[0]["ModifiedTime"].ToString()).AddDays(NoOfDays - 1) >= Convert.ToDateTime(Date))
                                        {
                                            if (dtApprove.Rows[0]["LowestPrice"].ToString() != null && dtApprove.Rows[0]["LowestPrice"].ToString() != "")
                                            {
                                                if (Convert.ToDecimal(dtApprove.Rows[0]["LowestPrice"].ToString()) == Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Rate"].Value))
                                                {
                                                    ISValid = true;
                                                }
                                                else if (Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["LowestPrice"].Value) <= Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Rate"].Value))
                                                {
                                                    ISValid = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Please Approved price set");
                                                    ISValid = false;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ISValid = false;
                                        MessageBox.Show("Approve limit is over");
                                    }
                                }
                                else
                                {
                                    DataTable dtPending = new BALCustomerRequest().SelectPendingStatus(new BOLCustomerRequest() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), ItemID = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["ID"].Value) });
                                    if (dtPending.Rows.Count > 0)
                                    {
                                        if (dgvInvoice1.Rows[i].Cells[7].Value.ToString() != "" && dgvInvoice1.Rows[i].Cells[5].Value.ToString() != "")
                                        {
                                            if (Convert.ToDecimal(dgvInvoice1.Rows[i].Cells[5].Value.ToString()) >= Convert.ToDecimal(dgvInvoice1.Rows[i].Cells[7].Value))
                                            {
                                                ISValid = true;
                                            }
                                            else
                                            {
                                                ISValid = false;
                                                MessageBox.Show("Request is Pending");
                                                break;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        ISValid = true;
                                    }
                                }
                            }
                            else
                            {
                                ISValid = true;
                            }
                        }
                    }
                }
                else if (Mode == "insert")
                {
                    // Approve Data Check
                    for (int i = 0; i < dgvInvoice1.Rows.Count; i++)
                    {
                        if (dgvInvoice1.Rows[i].Cells["Item"].Value != null)
                        {

                            DataTable dtApprove = new BALCustomerRequest().SelectApprovedStatus(new BOLCustomerRequest() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), ItemID = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["ID"].Value) });
                            if (dtApprove.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(dtApprove.Rows[0]["UseAllowesNo"].ToString()) > 0)
                                {
                                    if (dtApprove.Rows[0]["LowestPrice"].ToString() != null && dtApprove.Rows[0]["LowestPrice"].ToString() != "")
                                    {
                                        if (Convert.ToDecimal(dtApprove.Rows[0]["LowestPrice"].ToString()) > Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Rate"].Value))
                                        {
                                            MessageBox.Show("Please Approved price set");
                                            ISValid = false;
                                        }
                                        else
                                            ISValid = true;
                                    }
                                }
                                else if (Convert.ToInt32(dtApprove.Rows[0]["UseCurrentInvoice"].ToString()) > 0)
                                {
                                    if (dtApprove.Rows[0]["LowestPrice"].ToString() != null && dtApprove.Rows[0]["LowestPrice"].ToString() != "")
                                    {
                                        if (Convert.ToDecimal(dtApprove.Rows[0]["LowestPrice"].ToString()) >= Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Rate"].Value))
                                        {
                                            MessageBox.Show("This Price only Current PandingInvoice used");
                                            ISValid = false;
                                        }
                                        else
                                            ISValid = true;
                                    }
                                }
                                else if (Convert.ToInt16(dtApprove.Rows[0]["UseNoOFDays"].ToString()) > 0)
                                {
                                    Int16 NoOfDays = Convert.ToInt16(dtApprove.Rows[0]["UseNoOFDays"].ToString());
                                    string Date = DateTime.Now.ToString("MM-dd-yyyy");
                                    if (Convert.ToDateTime(dtApprove.Rows[0]["ModifiedTime"].ToString()).AddDays(NoOfDays - 1) >= Convert.ToDateTime(Date))
                                    {
                                        if (dtApprove.Rows[0]["LowestPrice"].ToString() != null && dtApprove.Rows[0]["LowestPrice"].ToString() != "")
                                        {
                                            if (Convert.ToDecimal(dtApprove.Rows[0]["LowestPrice"].ToString()) > Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Rate"].Value))
                                            {
                                                //MessageBox.Show("Please Approved price set");
                                                ISValid = false;
                                            }
                                            else
                                                ISValid = true;
                                        }
                                    }
                                    else
                                    {
                                        ISValid = false;
                                        //objBOLCusReq.ID = Convert.ToInt32(dtApprove.Rows[0]["ID"].ToString());
                                        //objBOLCusReq.UseAllowesNo = 0;
                                        //objBOLCusReq.UseNoOFDays = 0;
                                        //objBOLCusReq.UseCurrentInvoice = 0;
                                        //objBOLCusReq.IsActive = 0;
                                        //objBALCusReq.UpdateUseData(objBOLCusReq);
                                    }
                                }
                                else
                                {
                                    ISValid = true;
                                    //MessageBox.Show("Approve limit is over");
                                }
                            }
                            else
                            {
                                DataTable dtPending = new BALCustomerRequest().SelectPendingStatus(new BOLCustomerRequest() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), ItemID = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["ID"].Value) });
                                if (dtPending.Rows.Count > 0)
                                {
                                    if (dgvInvoice1.Rows[i].Cells[7].Value.ToString() != "" && dgvInvoice1.Rows[i].Cells[5].Value.ToString() != "")
                                    {
                                        if (Convert.ToDecimal(dgvInvoice1.Rows[i].Cells[5].Value.ToString()) >= Convert.ToDecimal(dgvInvoice1.Rows[i].Cells[7].Value))
                                        {
                                            ISValid = true;
                                        }
                                        else
                                        {
                                            ISValid = false;
                                            MessageBox.Show("Request is Pending");
                                            break;
                                        }
                                    }

                                }
                                else
                                {
                                    ISValid = true;

                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ISValid = false;
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :CheckPendingInvoice. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
            return ISValid;
        }
        private Boolean UpdateRequestData()
        {
            Boolean ISValid = false;
            try
            {
                for (int i = 0; i < dgvInvoice1.Rows.Count; i++)
                {
                    if (dgvInvoice1.Rows[i].Cells["Item"].Value != null)
                    {
                        DataTable dtApprove = new BALCustomerRequest().SelectApprovedStatus(new BOLCustomerRequest() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), ItemID = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["ID"].Value) });
                        if (dtApprove.Rows.Count > 0)
                        {
                            //UseAllowesNo
                            if (Convert.ToInt32(dtApprove.Rows[0]["UseAllowesNo"].ToString()) > 0)
                            {
                                if (Convert.ToDecimal(dtApprove.Rows[0]["LowestPrice"].ToString()) == Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Rate"].Value))
                                {
                                    //objBOLCusReq.ID = Convert.ToInt32(dtApprove.Rows[0]["ID"].ToString());
                                    //objBOLCusReq.UseAllowesNo = Convert.ToInt32(Convert.ToInt32(dtApprove.Rows[0]["UseAllowesNo"].ToString()) - 1);
                                    //objBOLCusReq.UseNoOFDays = 0;
                                    //objBOLCusReq.UseCurrentInvoice = 0;
                                    //if (objBOLCusReq.UseAllowesNo == 0)
                                    //    objBOLCusReq.IsActive = 0;
                                    //else
                                    //    objBOLCusReq.IsActive = 1;
                                    //objBALCusReq.UpdateUseData(objBOLCusReq);
                                }
                            }
                            //NoOfDays
                            else if (Convert.ToInt16(dtApprove.Rows[0]["UseNoOFDays"].ToString()) > 0)
                            {
                                string Date = Convert.ToDateTime(dtApprove.Rows[0]["ModifiedTime"].ToString()).ToString("MM-dd-yyyy");
                                Int16 NoOfDays = Convert.ToInt16(dtApprove.Rows[0]["UseNoOFDays"].ToString());
                                DateTime Date1 = Convert.ToDateTime(Date).AddDays(NoOfDays);
                                string Date2 = DateTime.Now.ToString("MM-dd-yyyy");
                                if (Date1 >= Convert.ToDateTime(Date2))
                                {
                                    double Days = (Date1 - Convert.ToDateTime(Date2)).TotalDays;
                                    //objBOLCusReq.ID = Convert.ToInt32(dtApprove.Rows[0]["ID"].ToString());
                                    //objBOLCusReq.UseAllowesNo = 0;
                                    //objBOLCusReq.UseNoOFDays = Convert.ToInt32(Days);
                                    //objBOLCusReq.UseCurrentInvoice = 0;
                                    //if (objBOLCusReq.UseNoOFDays == 0)
                                    //    objBOLCusReq.IsActive = 0;
                                    //else
                                    //    objBOLCusReq.IsActive = 1;
                                    //objBALCusReq.UpdateUseData(objBOLCusReq);
                                }
                            }
                            // Current Invoice
                            else if (Convert.ToInt32(dtApprove.Rows[0]["UseCurrentInvoice"].ToString()) == 1)
                            {
                                if (Convert.ToDecimal(dtApprove.Rows[0]["LowestPrice"].ToString()) == Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Rate"].Value))
                                {
                                    //objBOLCusReq.ID = Convert.ToInt32(dtApprove.Rows[0]["ID"].ToString());
                                    //objBOLCusReq.UseAllowesNo = 0;
                                    //objBOLCusReq.UseNoOFDays = 0;
                                    //objBOLCusReq.UseCurrentInvoice = 0;
                                    //objBOLCusReq.IsActive = 0;
                                    //objBALCusReq.UpdateUseData(objBOLCusReq);
                                }
                            }
                        }
                        ISValid = true;

                    }
                }
            }
            catch (Exception ex)
            {
                ISValid = false;
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :UpdateRequestData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
            return ISValid;
        }
        public void PrintSave(int InvoiceID)
        {
            BOLHistory.IsPrint = 1;
            BOLHistory.IsUpdate = 0;
            BOLHistory.IsPrintDate = DateTime.Now;
            BOLHistory.InvoiceID = InvoiceID;
            BALHistory.UpdatePrint(BOLHistory);
        }
        private Boolean SaveData(ref string InvID)
        {
            Boolean ISValid = false;
            try
            {
                if (CheckValidation())
                {
                    if (Mode == "insert")
                    {
                        //if (CheckPendingInvoice())
                        //{
                        //Top:;
                        //Admin Requset Send
                        if (ClsCommon.UserType != "Admin" && ClsCommon.UserType != "admin")
                        {
                            AdminRequestSend(txtInvoiceNo.Text);
                        }
                        objBOLInvoice = new BOLCreditMemo();
                        DataTable dtRefnuber = new BALCreditMemo().SelectByRefNumber(new BOLCreditMemo() { RefNumber = txtInvoiceNo.Text.Trim() });

                        if (dtRefnuber.Rows.Count == 0)
                        {
                            objBOLInvoice.CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue);
                            //objBOLInvoice.ARAccountID = Convert.ToInt32(cmbAccount.SelectedValue);
                            objBOLInvoice.TxnDate = Convert.ToDateTime(dtpInvoiceDate.Value);
                            objBOLInvoice.RefNumber = txtInvoiceNo.Text.Trim();
                            objBOLInvoice.PONumber = txtPONumber.Text.Trim();
                            objBOLInvoice.TermsID = Convert.ToInt32(cmbTerms.SelectedValue);
                            objBOLInvoice.DueDate = Convert.ToDateTime(dtpDuedate.Value);
                            objBOLInvoice.SalesRepID = Convert.ToInt32(cmbSalesRep.SelectedValue);
                            objBOLInvoice.ShipDate = Convert.ToDateTime(dtpShipDate.Value);
                            objBOLInvoice.ShipMethodID = Convert.ToInt32(cmbShippingMethod.SelectedValue);
                            //princy
                            objBOLInvoice.CustomerMessage = Convert.ToInt32(cmbMsg.SelectedValue);
                            //objBOLInvoice.Total = Convert.ToDecimal(lblTotal.Text);
                            //bHUMIKA
                            objBOLInvoice.Total = Convert.ToDecimal(lblSubTotal.Text);
                            objBOLInvoice.TaxAmount = Convert.ToDecimal(lblTaxAmount.Text);
                            objBOLInvoice.TaxID = Convert.ToInt32(cmbSalesTax.SelectedValue);
                            objBOLInvoice.TaxPercent = Convert.ToDecimal(lblTaxPercentage.Text.Replace("(", "").Replace("%)", ""));
                            //
                            objBOLInvoice.AppliedAmount = Convert.ToDecimal(lblPaymentApplied.Text);
                            objBOLInvoice.BalanceDue = Convert.ToDecimal(lblBalanceDue.Text);
                            objBOLInvoice.Memo = txtMemo.Text.Trim();
                            objBOLInvoice.ShipAddressID = Convert.ToInt32(cmbShipAddress.SelectedValue);
                            objBOLInvoice.ServiceID = Convert.ToInt32(cmbService.SelectedValue);
                            objBOLInvoice.IsPrint = 0;
                            objBOLInvoice.PaidInvoice = 0;
                            objBOLInvoice.IsSync = 0;
                            objBOLInvoice.IsShipping = 0;
                            objBOLInvoice.CreatedID = ClsCommon.UserID;
                            objBOLInvoice.CreatedTime = DateTime.Now;
                            objBOLInvoice.ModifiedTime = DateTime.Now;
                            if (cmbPrice.Text != "")
                            {
                                objBOLInvoice.PriceTier = cmbPrice.Text;
                            }
                            //GetShipAddress...
                            if (cmbShipAddress.SelectedIndex > 0)
                            {
                                DataTable dtAdd = new BALAddressMaster().SelectByID(cmbShipAddress.SelectedValue.ToString());
                                if (dtAdd.Rows.Count > 0)
                                {
                                    objBOLInvoice.ShipAdd1 = dtAdd.Rows[0]["Address1"].ToString();
                                    objBOLInvoice.ShipAdd2 = dtAdd.Rows[0]["Address2"].ToString();
                                    objBOLInvoice.ShipAdd3 = dtAdd.Rows[0]["Address3"].ToString();
                                    objBOLInvoice.ShipCity = dtAdd.Rows[0]["City"].ToString();
                                    objBOLInvoice.ShipPostalCode = dtAdd.Rows[0]["PostalCode"].ToString();
                                    objBOLInvoice.ShipState = dtAdd.Rows[0]["State"].ToString();
                                    objBOLInvoice.ShipCountry = dtAdd.Rows[0]["Country"].ToString();
                                }
                            }
                            //Pending Status
                            for (int i = 0; i < dgvInvoice1.Rows.Count; i++)
                            {
                                DataTable dtPendingStatus = new BALCustomerRequest().SelectPendingStatus(new BOLCustomerRequest() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), ItemID = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["ID"].Value) });
                                if (dtPendingStatus.Rows.Count > 0)
                                {
                                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                                    {
                                        objBOLInvoice.PandingInvoice = 1;
                                    }
                                    else
                                    {
                                        if (Convert.ToDecimal(dgvInvoice1.Rows[i].Cells[5].Value.ToString()) >= Convert.ToDecimal(dgvInvoice1.Rows[i].Cells[7].Value))
                                        {
                                            objBOLInvoice.PandingInvoice = 1;
                                        }
                                        else
                                        {
                                            ClsCommon.Flag = 1;
                                            //objBOLInvoice.PandingInvoice = 0;
                                            objBOLInvoice.PandingInvoice = 1;
                                            //MessageBox.Show("This invoice is pending for finalization");
                                            goto Next;
                                        }
                                    }
                                }
                                else
                                {
                                    // Assigned Customer
                                    if (ClsCommon.UserType != "Admin" && ClsCommon.UserType != "admin")
                                    {
                                        DataTable dtAssigned = new BALCustomerMaster().SelectBySalesRap(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                                        if (dtAssigned.Rows.Count > 0)
                                        {
                                            if (dtAssigned.Rows[0]["SalesRepID"].ToString() == null || dtAssigned.Rows[0]["SalesRepID"].ToString() == "" || dtAssigned.Rows[0]["SalesRepID"].ToString() == "0")
                                            {
                                                objBOLCustomer.ID = Convert.ToInt32(cmbCustomer.SelectedValue);
                                                objBOLCustomer.SalesRepID = ClsCommon.UserID;
                                                objBALCustomer.UpdateSalesRepID(objBOLCustomer);
                                            }
                                        }
                                    }
                                    objBOLInvoice.PandingInvoice = 1;
                                }
                            }
                        Next:;
                            int InvoiceID = objBALInvoice.InvoiceInsert(objBOLInvoice);
                            //RefNumber
                            if (ClsCommon.TaxWithoutTax == "Yes")
                            {
                                objBOLInvoice.Type = "CreditMemo";
                                objBOLInvoice.TaxRef = txtInvoiceNo.Text.Replace("CN-", "").Replace("CM", "").Replace("C", "").Replace("T", "").Replace("N", "").Replace("CN-", "");
                                objBALInvoice.UpdateTax(objBOLInvoice);
                            }
                            else
                            {
                                objBOLInvoice.Type = "CreditMemo";
                                objBOLInvoice.NonTaxRef = txtInvoiceNo.Text.Replace("CN-", "").Replace("CM", "").Replace("C", "").Replace("T", "").Replace("N", "");
                                objBALInvoice.UpdateNonTaxRef(objBOLInvoice);
                            }
                            InvID = InvoiceID.ToString();
                            for (int i = 0; i < dgvInvoice1.Rows.Count; i++)
                            {
                                if (dgvInvoice1.Rows[i].Cells["ItemType"].Value != null)
                                {

                                    //Insert InvoiceDetails
                                    objBOLInvDetails.InvoiceID = InvoiceID;
                                    objBOLInvDetails.SrNo = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["SrNo"].Value.ToString());
                                    if (dgvInvoice1.Rows[i].Cells["ID"].Value == null)
                                        objBOLInvDetails.ItemID = 0;
                                    else
                                        objBOLInvDetails.ItemID = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["ID"].Value.ToString());
                                    if (dgvInvoice1.Rows[i].Cells["Description"].Value == null)
                                        objBOLInvDetails.Decs = "";
                                    else
                                        objBOLInvDetails.Decs = dgvInvoice1.Rows[i].Cells["Description"].Value.ToString();
                                    if (dgvInvoice1.Rows[i].Cells["Qty"].Value == null)
                                        objBOLInvDetails.Quantity = 0;
                                    else
                                        objBOLInvDetails.Quantity = Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Qty"].Value);
                                    if (dgvInvoice1.Rows[i].Cells["Rate"].Value == null)
                                        objBOLInvDetails.Rate = 0;
                                    else
                                        objBOLInvDetails.Rate = Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Rate"].Value);
                                    if (dgvInvoice1.Rows[i].Cells["Amount"].Value == null)
                                        objBOLInvDetails.Amount = 0;
                                    else
                                        objBOLInvDetails.Amount = Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Amount"].Value);
                                    if (dgvInvoice1.Rows[i].Cells["ItemType"].Value == null)
                                        objBOLInvDetails.ItemType = "";
                                    else
                                        objBOLInvDetails.ItemType = dgvInvoice1.Rows[i].Cells["ItemType"].Value.ToString();
                                    objBOLInvDetails.CreatedTime = DateTime.Now;
                                    objBOLInvDetails.CreatedID = ClsCommon.UserID;
                                    if (dgvInvoice1.Rows[i].Cells["IMEINumber"].Value != null)
                                    {
                                        objBOLInvDetails.IMEINumber = dgvInvoice1.Rows[i].Cells["IMEINumber"].Value.ToString();
                                    }
                                    if (dgvInvoice1.Rows[i].Cells["CARRIERS"].Value != null)
                                    {
                                        objBOLInvDetails.Reason = dgvInvoice1.Rows[i].Cells["CARRIERS"].Value.ToString();
                                    }
                                    if (dgvInvoice1.Rows[i].Cells["GRADING"].Value != null)
                                    {
                                        objBOLInvDetails.GRADING = dgvInvoice1.Rows[i].Cells["GRADING"].Value.ToString();
                                    }
                                    //Hiren
                                    if (dgvInvoice1.Rows[i].Cells["Tax"].Value != null)
                                    {
                                        objBOLInvDetails.Tax = dgvInvoice1.Rows[i].Cells["Tax"].Value.ToString();
                                    }

                                    objBALInvDetails.InvoiceDetailsInsert(objBOLInvDetails);

                                    UpdateQtyOnHand();

                                    //Insert InvoiceSaleHistory
                                    objBOLItemSale.InvoiceID = InvoiceID;
                                    objBOLItemSale.ItemID = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["ID"].Value.ToString());
                                    objBOLItemSale.CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue);
                                    objBOLItemSale.SalePrice = Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Rate"].Value);
                                    objBOLItemSale.LastSaleDate = DateTime.Now;
                                    objBOLItemSale.ShippingMethodID = Convert.ToInt32(cmbShippingMethod.SelectedValue);
                                    objBOLItemSale.CreatedID = ClsCommon.UserID;

                                    objBALItemSale.Insert(objBOLItemSale);
                                }
                            }
                            //InvoiceHistory Save
                            InvoiceHistorySave(InvoiceID.ToString());

                            //CustomerBalance Update
                            DataTable dtCusBalance = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                            if (dtCusBalance.Rows.Count == 1)
                            {
                                TotalBalance = 0;
                                if (dtCusBalance.Rows[0]["TotalBalance"].ToString() != null && dtCusBalance.Rows[0]["TotalBalance"].ToString() != "")
                                    TotalBalance = Convert.ToDecimal(dtCusBalance.Rows[0]["TotalBalance"].ToString()) - Convert.ToDecimal(lblTotal.Text);
                                else
                                    TotalBalance = Convert.ToDecimal(lblTotal.Text);
                                objBOLCustomer.ID = Convert.ToInt32(cmbCustomer.SelectedValue);
                                objBOLCustomer.TotalBalance = TotalBalance;
                                objBALCustomer.UpdateCustomerBalance(objBOLCustomer);
                            }

                            // RequestData Update
                            if (UpdateRequestData())
                            {
                                ISValid = true;
                            }
                            //MessageBox.Show("Record save successfully");
                        }
                        //else
                        //{

                        //    if (Mode != "update")
                        //    {
                        //        DataTable dt = new BALCreditMemo().SelectMAX(new BOLCreditMemo() { });
                        //        if (dt.Rows.Count > 0)
                        //        {
                        //            Random rnd = new Random();
                        //            int num = Convert.ToInt32(dt.Rows[0]["RefNumber"].ToString());
                        //            num = num + 1;
                        //            txtInvoiceNo.Text = num.ToString() + "CM";
                        //        }

                        //    }
                        //    goto Top;

                        //}
                    }
                    else
                    {
                        InvID = txtID.Text;

                        // Update
                        DataTable dtRefnuber = new BALCreditMemo().SelectByRefNumber(new BOLCreditMemo() { RefNumber = txtInvoiceNo.Text.Trim() });
                        if (dtRefnuber.Rows.Count > 0)
                        {
                            if (Convert.ToInt32((dtRefnuber.Rows[0]["ID"]).ToString().Replace("CM", "")) != Convert.ToInt32(txtID.Text))
                            {
                                MessageBox.Show("Duplicate Refnumber not allow");

                                txtInvoiceNo.Focus();
                            }
                            else
                            {
                                if (UpdateData())
                                {
                                    if (UpdateRequestData())
                                    {
                                        //MessageBox.Show("Record Update successfully");
                                        ISValid = true;
                                    }
                                }
                            }
                        }
                        else if (dtRefnuber.Rows.Count == 0)
                        {
                            if (UpdateData())
                            {
                                if (UpdateRequestData())
                                {
                                    //MessageBox.Show("Record Update successfully");
                                    ISValid = true;
                                }
                            }
                        }
                    }
                    IsClose = false;

                    UpdatePriceTier(Convert.ToInt32(cmbCustomer.SelectedValue), cmbPrice.Text, ClsCommon.UserID);

                }
                else
                {
                    btnSaveandClose.Enabled = true;
                    btnSaveandNew.Enabled = true;
                    //btnSaveAndEmail.Enabled = true;
                    ISValid = false;
                    ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :SaveData. Message: Error Create Customer Data");
                }

            }
            catch (Exception ex)
            {
                ISValid = false;
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :SaveData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
            return ISValid;
        }
        public void UpdateQtyOnHand()
        {
            try
            {
                for (int i = 0; i < dgvInvoice1.Rows.Count; i++)
                {
                    if (dgvInvoice1.Rows[i].Cells["ItemType"].Value != null)
                    {
                        if (dgvInvoice1.Rows[i].Cells["Qty"].Value != null)
                        {
                            dtLoadData = new BALItemMaster().SelectByID(new BOLItemMaster() { ID = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["ID"].Value) });
                            if (dtLoadData.Rows.Count > 0)
                            {
                                if (txtID.Text == "")
                                {
                                    decimal Qty = Convert.ToDecimal(dtLoadData.Rows[0]["QtyOnHand"].ToString()) - Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Qty"].Value);

                                    int id = Convert.ToInt32(dtLoadData.Rows[0]["ID"].ToString());

                                    objBOLItem = new BOLItemMaster();
                                    objBOLItem.ID = id;
                                    objBOLItem.QtyOnHand = Qty;
                                    objBALItem.UpdateQtyOnHand(objBOLItem);
                                }
                                else
                                {
                                    DataTable dt = new BALCreditMemoDetails().SelectInvID(new BOLCreditMemoDetails() { InvoiceID = Convert.ToInt32(txtID.Text), ItemID = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["ID"].Value) });
                                    if (dt.Rows.Count > 0)
                                    {
                                        if (Convert.ToDecimal(dt.Rows[0]["Quantity"]) > Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Qty"].Value))
                                        {
                                            decimal Qty = Convert.ToDecimal(dt.Rows[0]["Quantity"]) - Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Qty"].Value);
                                            decimal QtyOnHand = Convert.ToDecimal(dtLoadData.Rows[0]["QtyOnHand"].ToString()) + Convert.ToDecimal(Qty);

                                            int id = Convert.ToInt32(dtLoadData.Rows[0]["ID"].ToString());

                                            objBOLItem = new BOLItemMaster();
                                            objBOLItem.ID = id;
                                            objBOLItem.QtyOnHand = QtyOnHand;
                                            objBALItem.UpdateQtyOnHand(objBOLItem);

                                        }
                                        else if (Convert.ToDecimal(dt.Rows[0]["Quantity"]) < Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Qty"].Value))
                                        {
                                            decimal Qty = Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Qty"].Value) - Convert.ToDecimal(dt.Rows[0]["Quantity"]);
                                            decimal QtyOnHand = Convert.ToDecimal(dtLoadData.Rows[0]["QtyOnHand"].ToString()) - Convert.ToDecimal(Qty);

                                            int id = Convert.ToInt32(dtLoadData.Rows[0]["ID"].ToString());

                                            objBOLItem = new BOLItemMaster();
                                            objBOLItem.ID = id;
                                            objBOLItem.QtyOnHand = QtyOnHand;
                                            objBALItem.UpdateQtyOnHand(objBOLItem);
                                        }
                                    }
                                    else
                                    {
                                        decimal Qty = Convert.ToDecimal(dtLoadData.Rows[0]["QtyOnHand"].ToString()) - Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Qty"].Value);
                                        int id = Convert.ToInt32(dtLoadData.Rows[0]["ID"].ToString());
                                        objBOLItem = new BOLItemMaster();
                                        objBOLItem.ID = id;
                                        objBOLItem.QtyOnHand = Qty;
                                        objBALItem.UpdateQtyOnHand(objBOLItem);
                                    }


                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :UpdateQtyOnHand. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void InvoiceAuditLogSave()
        {
            try
            {
                objInvBOL.Datetime = DateTime.Now;
                objInvBOL.CreditMemoID = Convert.ToInt32(txtID.Text);
                objInvBOL.SalesRepID = Convert.ToInt32(cmbSalesRep.SelectedValue);
                int ID = objInvBAL.Insert(objInvBOL);


                for (int i = 0; i < dgvInvoice1.Rows.Count; i++)
                {
                    try
                    {
                        if (dgvInvoice1.Rows[i].Cells["ItemType"].Value != null)
                        {
                            if (dgvInvoice1.Rows[i].Cells["ItemType"].Value.ToString() != "GroupTotal")
                            {
                                //Insert InvoiceDetails
                                objInvDetailBOL.AuditID = ID;

                                objInvDetailBOL.SrNo = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["SrNo"].Value.ToString());
                                if (dgvInvoice1.Rows[i].Cells["ID"].Value == null)
                                    objInvDetailBOL.ItemID = 0;
                                else
                                    objInvDetailBOL.ItemID = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["ID"].Value.ToString());
                                if (dgvInvoice1.Rows[i].Cells["Description"].Value == null)
                                    objInvDetailBOL.Decs = "";
                                else
                                    objInvDetailBOL.Decs = dgvInvoice1.Rows[i].Cells["Description"].Value.ToString();
                                if (dgvInvoice1.Rows[i].Cells["Qty"].Value == null)
                                    objInvDetailBOL.Quantity = 0;
                                else
                                    objInvDetailBOL.Quantity = Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Qty"].Value);
                                if (dgvInvoice1.Rows[i].Cells["Rate"].Value == null)
                                    objInvDetailBOL.Rate = 0;
                                else
                                    objInvDetailBOL.Rate = Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Rate"].Value);
                                if (dgvInvoice1.Rows[i].Cells["Amount"].Value == null)
                                    objInvDetailBOL.Amount = 0;
                                else
                                    objInvDetailBOL.Amount = Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Amount"].Value);
                                if (dgvInvoice1.Rows[i].Cells["ItemType"].Value == null)
                                    objInvDetailBOL.ItemType = "";
                                else
                                    objInvDetailBOL.ItemType = dgvInvoice1.Rows[i].Cells["ItemType"].Value.ToString();


                                objInvDetailBAL.Insert(objInvDetailBOL);

                            }
                            if (dgvInvoice1.Rows[i].Cells["ItemType"].Value.ToString() == "GroupTotal")
                            {
                                //Insert InvoiceDetails
                                objInvDetailBOL.AuditID = ID;

                                objInvDetailBOL.ItemID = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["ID"].Value.ToString());
                                objInvDetailBOL.Decs = "";
                                objInvDetailBOL.Quantity = 0;
                                objInvDetailBOL.Rate = 0;
                                if (dgvInvoice1.Rows[i].Cells["Amount"].Value == null)
                                    objInvDetailBOL.Amount = 0;
                                else
                                    objInvDetailBOL.Amount = Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Amount"].Value);
                                if (dgvInvoice1.Rows[i].Cells["ItemType"].Value == null)
                                    objInvDetailBOL.ItemType = "";
                                else
                                    objInvDetailBOL.ItemType = dgvInvoice1.Rows[i].Cells["ItemType"].Value.ToString();


                                objInvDetailBAL.Insert(objInvDetailBOL);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :InvoiceAuditLogSave. Message:" + ex.Message);
                        MessageBox.Show("Error:" + ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :InvoiceAuditLogSave. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        //For Multiple PrintCount
        private void AddPrintCount()
        {
            try
            {
                DataTable dtInv = new DataTable();
                DataTable dtPrint = objPrintBAL.Select();
                if (dtPrint.Rows.Count > 0)
                {
                    if (dtPrint.Rows[0]["Flag"].ToString() == "True")
                    {
                        if (Count == 1)
                        {
                            SavePrint();
                        }
                        else
                        {
                            dtInv = objBALInvoice.SelectByInvID(Convert.ToInt32(InvoiceID));
                            if (dtInv.Rows[0]["CustomerID"].ToString() != cmbCustomer.SelectedValue.ToString())
                            {
                                SavePrint();
                            }
                            else if (txtaddrID.Text != "")
                            {
                                if (dtInv.Rows[0]["ShipAddressID"].ToString() != txtaddrID.Text)
                                {
                                    SavePrint();
                                }
                            }

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :AddPrintCount. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void SavePrint()
        {
            try
            {

                DataTable dt1 = new DataTable();

                objBOLInvCount = new BOLCreditMemoPrintCount();
                dt1 = objBALInvCount.Select(Convert.ToInt32(InvoiceID));
                if (dt1.Rows.Count > 0)
                {
                    int Max = Convert.ToInt32(dt1.Compute("Max([PrintNo])", string.Empty));
                    objBOLInvCount.PrintNo = Max + 1;
                    objBOLInvCount.CreditMemoID = InvoiceID;
                    objBOLInvCount.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    objBOLInvCount.IsPrint = 1;
                    objBALInvCount.Update(objBOLInvCount);
                }
                else
                {
                    objBOLInvCount.PrintNo = 2;
                    objBOLInvCount.CreditMemoID = InvoiceID;
                    objBOLInvCount.RefNumber = txtInvoiceNo.Text;
                    objBOLInvCount.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    objBOLInvCount.IsPrint = 1;
                    objBALInvCount.Insert(objBOLInvCount);
                }
                Count = 0;
                PrintCount = true;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :SavePrint. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private Boolean UpdateData()
        {
            PrintCount = false;
            Boolean ISValid = false;
            try
            {
                //if (CheckPendingInvoice())
                //{
                // Admin Request Send
                if (ClsCommon.UserType != "Admin" && ClsCommon.UserType != "admin")
                {
                    AdminRequestSend(txtInvoiceNo.Text);
                }

                // Update Invoice
                AddPrintCount();

                objBOLInvoice = new BOLCreditMemo();
                objBOLInvoice.ID = Convert.ToInt32(txtID.Text);
                objBOLInvoice.CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue);
                //objBOLInvoice.ARAccountID = Convert.ToInt32(cmbAccount.SelectedValue);
                objBOLInvoice.TxnDate = Convert.ToDateTime(dtpInvoiceDate.Value);
                objBOLInvoice.RefNumber = (txtInvoiceNo.Text.Trim());
                objBOLInvoice.PONumber = txtPONumber.Text.Trim();
                objBOLInvoice.TermsID = Convert.ToInt32(cmbTerms.SelectedValue);
                objBOLInvoice.DueDate = Convert.ToDateTime(dtpDuedate.Value);
                objBOLInvoice.SalesRepID = Convert.ToInt32(cmbSalesRep.SelectedValue);
                objBOLInvoice.ShipDate = Convert.ToDateTime(dtpShipDate.Value);
                objBOLInvoice.ShipMethodID = Convert.ToInt32(cmbShippingMethod.SelectedValue);
                //princy
                objBOLInvoice.CustomerMessage = Convert.ToInt32(cmbMsg.SelectedValue);

                //objBOLInvoice.Total = Convert.ToDecimal(lblTotal.Text);

                //bHUMIKA
                objBOLInvoice.Total = Convert.ToDecimal(lblSubTotal.Text);
                objBOLInvoice.TaxAmount = Convert.ToDecimal(lblTaxAmount.Text);
                objBOLInvoice.TaxID = Convert.ToInt32(cmbSalesTax.SelectedValue);
                objBOLInvoice.TaxPercent = Convert.ToDecimal(lblTaxPercentage.Text.Replace("(", "").Replace("%)", ""));
                //
                objBOLInvoice.AppliedAmount = Convert.ToDecimal(lblPaymentApplied.Text);
                objBOLInvoice.BalanceDue = Convert.ToDecimal(lblBalanceDue.Text);
                objBOLInvoice.Memo = txtMemo.Text.Trim();

                DataTable dtPrint = objPrintBAL.Select();
                if (dtPrint.Rows.Count > 0)
                {
                    if (dtPrint.Rows[0]["Flag"].ToString() == "True")
                    {
                        if (PrintCount == true)
                            objBOLInvoice.IsPrint = 0;
                        else
                            objBOLInvoice.IsPrint = 1;
                    }
                    else
                        objBOLInvoice.IsPrint = 0;
                }
                else
                    objBOLInvoice.IsPrint = 0;

                objBOLInvoice.ShipAddressID = Convert.ToInt32(cmbShipAddress.SelectedValue);
                objBOLInvoice.ServiceID = Convert.ToInt32(cmbService.SelectedValue);
                if (cmbPrice.Text != "")
                {
                    objBOLInvoice.PriceTier = cmbPrice.Text;
                }
                if (lblPaymentApplied.Text != "" && lblSubTotal.Text != "")
                {
                    if (lblSubTotal.Text == "0")
                    {
                        objBOLInvoice.PaidInvoice = 0;
                    }
                    else
                    {
                        if (Convert.ToDecimal(lblSubTotal.Text) == Convert.ToDecimal(lblPaymentApplied.Text))
                            objBOLInvoice.PaidInvoice = 2;
                        else if (Convert.ToDecimal(lblSubTotal.Text) > Convert.ToDecimal(lblPaymentApplied.Text) && Convert.ToDecimal(lblPaymentApplied.Text) > 0)
                            objBOLInvoice.PaidInvoice = 1;
                        else
                            objBOLInvoice.PaidInvoice = 0;
                    }
                }
                else
                {
                    objBOLInvoice.PaidInvoice = 0;
                }

                // objBOLInvoice.PandingInvoice = 1;
                objBOLInvoice.IsSync = 0;
                objBOLInvoice.IsShipping = 0;
                objBOLInvoice.ModifiedID = ClsCommon.UserID;
                objBOLInvoice.ModifiedTime = DateTime.Now;

                //GetShiAddress...
                if (cmbShipAddress.SelectedIndex > 0)
                {
                    DataTable dtAdd = new BALAddressMaster().SelectByID(cmbShipAddress.SelectedValue.ToString());
                    if (dtAdd.Rows.Count > 0)
                    {
                        objBOLInvoice.ShipAdd1 = dtAdd.Rows[0]["Address1"].ToString();
                        objBOLInvoice.ShipAdd2 = dtAdd.Rows[0]["Address2"].ToString();
                        objBOLInvoice.ShipAdd3 = dtAdd.Rows[0]["Address3"].ToString();
                        objBOLInvoice.ShipCity = dtAdd.Rows[0]["City"].ToString();
                        objBOLInvoice.ShipPostalCode = dtAdd.Rows[0]["PostalCode"].ToString();
                        objBOLInvoice.ShipState = dtAdd.Rows[0]["State"].ToString();
                        objBOLInvoice.ShipCountry = dtAdd.Rows[0]["Country"].ToString();
                    }
                }

                //Pending Status
                for (int i = 0; i < dgvInvoice1.Rows.Count; i++)
                {
                    DataTable dtPendingStatus = new BALCustomerRequest().SelectPendingStatus(new BOLCustomerRequest() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), ItemID = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["ID"].Value) });
                    if (dtPendingStatus.Rows.Count > 0)
                    {
                        if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        {
                            objBOLInvoice.PandingInvoice = 1;
                        }
                        else
                        {
                            if (Convert.ToDecimal(dgvInvoice1.Rows[i].Cells[5].Value.ToString()) >= Convert.ToDecimal(dgvInvoice1.Rows[i].Cells[7].Value))
                            {
                                objBOLInvoice.PandingInvoice = 1;
                            }
                            else
                            {
                                ClsCommon.Flag = 1;
                                //objBOLInvoice.PandingInvoice = 0;
                                objBOLInvoice.PandingInvoice = 1;
                                //MessageBox.Show("This invoice is pending for finalization");
                                goto Next;
                            }
                        }

                    }
                    else
                    {
                        // Assigned Customer
                        if (ClsCommon.UserType != "Admin" && ClsCommon.UserType != "admin")
                        {
                            DataTable dtAssigned = new BALCustomerMaster().SelectBySalesRap(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                            if (dtAssigned.Rows.Count > 0)
                            {
                                if (dtAssigned.Rows[0]["SalesRepID"].ToString() == null || dtAssigned.Rows[0]["SalesRepID"].ToString() == "" || dtAssigned.Rows[0]["SalesRepID"].ToString() == "0")
                                {
                                    objBOLCustomer.ID = Convert.ToInt32(cmbCustomer.SelectedValue);
                                    objBOLCustomer.SalesRepID = ClsCommon.UserID;
                                    objBALCustomer.UpdateSalesRepID(objBOLCustomer);
                                }
                            }
                        }
                        objBOLInvoice.PandingInvoice = 1;
                    }
                }
            Next:;
                int InvoiceID = objBALInvoice.InvoiceUpdate(objBOLInvoice);



                objBOLInvoice.Type = "CreditMemo";
                objBOLInvoice.TaxRef = txtInvoiceNo.Text.Replace("CN-", "").Replace("CM", "").Replace("C", "").Replace("T", "").Replace("N", "").Replace("CN-", "");
                objBALInvoice.UpdateTax(objBOLInvoice);
                objBOLInvoice.Type = "CreditMemo";
                objBOLInvoice.NonTaxRef = txtInvoiceNo.Text.Replace("CN-", "").Replace("CM", "").Replace("C", "").Replace("T", "").Replace("N", "");
                objBALInvoice.UpdateNonTaxRef(objBOLInvoice);


                UpdateQtyOnHand();


                DataTable dt = BALHistory.Select(InvoiceID);
                if (dt.Rows.Count == 0)
                {
                    BOLHistory.IsPrint = 0;
                    BOLHistory.IsUpdate = 1;
                    BOLHistory.IsUpdateDate = DateTime.Now;
                    BOLHistory.InvoiceID = InvoiceID;
                    BALHistory.Insert(BOLHistory);
                }
                else
                {
                    BOLHistory.IsPrint = 0;
                    BOLHistory.IsUpdate = 1;
                    BOLHistory.IsUpdateDate = DateTime.Now;
                    BOLHistory.InvoiceID = InvoiceID;
                    BALHistory.Update(BOLHistory);
                }

                objBALInvPrint.Delete(InvoiceID);
                objBALInvDetails.DeleteByID(InvoiceID);



                //Delete InvoiceDetails and InvoiceSaleHistory
                //objBOLInvDetails.InvoiceID = Convert.ToInt32(txtID.Text);
                //objBALInvDetails.Delete(objBOLInvDetails);

                objBOLItemSale.InvoiceID = Convert.ToInt32(txtID.Text);
                objBALItemSale.Delete(objBOLItemSale);

                for (int i = 0; i < dgvInvoice1.Rows.Count; i++)
                {
                    if (dgvInvoice1.Rows[i].Cells["ItemType"].Value != null)
                    {
                        if (dgvInvoice1.Rows[i].Cells["ItemType"].Value.ToString() != "GroupTotal")
                        {
                            //Insert InvoiceDetails
                            objBOLInvDetails.SrNo = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["SrNo"].Value.ToString());
                            objBOLInvDetails.InvoiceID = InvoiceID;
                            if (dgvInvoice1.Rows[i].Cells["ID"].Value == null)
                                objBOLInvDetails.ItemID = 0;
                            else
                                objBOLInvDetails.ItemID = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["ID"].Value.ToString());
                            if (dgvInvoice1.Rows[i].Cells["Description"].Value == null)
                                objBOLInvDetails.Decs = "";
                            else
                                objBOLInvDetails.Decs = dgvInvoice1.Rows[i].Cells["Description"].Value.ToString();
                            if (dgvInvoice1.Rows[i].Cells["Qty"].Value == null)
                                objBOLInvDetails.Quantity = 0;
                            else
                                objBOLInvDetails.Quantity = Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Qty"].Value);
                            if (dgvInvoice1.Rows[i].Cells["Rate"].Value == null)
                                objBOLInvDetails.Rate = 0;
                            else
                                objBOLInvDetails.Rate = Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Rate"].Value);
                            if (dgvInvoice1.Rows[i].Cells["Amount"].Value == null)
                                objBOLInvDetails.Amount = 0;
                            else
                                objBOLInvDetails.Amount = Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Amount"].Value);
                            if (dgvInvoice1.Rows[i].Cells["ItemType"].Value == null)
                                objBOLInvDetails.ItemType = "";
                            else
                                objBOLInvDetails.ItemType = dgvInvoice1.Rows[i].Cells["ItemType"].Value.ToString();
                            objBOLInvDetails.CreatedTime = DateTime.Now;
                            objBOLInvDetails.CreatedID = ClsCommon.UserID;
                            if (dgvInvoice1.Rows[i].Cells["IMEINumber"].Value != null)
                            {
                                objBOLInvDetails.IMEINumber = dgvInvoice1.Rows[i].Cells["IMEINumber"].Value.ToString();
                            }
                            if (dgvInvoice1.Rows[i].Cells["CARRIERS"].Value != null)
                            {
                                objBOLInvDetails.Reason = dgvInvoice1.Rows[i].Cells["CARRIERS"].Value.ToString();
                            }
                            if (dgvInvoice1.Rows[i].Cells["GRADING"].Value != null)
                            {
                                objBOLInvDetails.GRADING = dgvInvoice1.Rows[i].Cells["GRADING"].Value.ToString();
                            }
                            //Hiren
                            if (dgvInvoice1.Rows[i].Cells["Tax"].Value != null)
                            {
                                objBOLInvDetails.Tax = dgvInvoice1.Rows[i].Cells["Tax"].Value.ToString();
                            }
                            objBALInvDetails.InvoiceDetailsInsert(objBOLInvDetails);



                            if (dgvInvoice1.Rows[i].Cells["ItemType"].Value.ToString() != "GroupItem")
                            {
                                //Insert InvoiceSaleHistory
                                objBOLItemSale.InvoiceID = InvoiceID;
                                objBOLItemSale.ItemID = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["ID"].Value.ToString());
                                objBOLItemSale.CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue);
                                objBOLItemSale.SalePrice = Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Rate"].Value);
                                objBOLItemSale.LastSaleDate = DateTime.Now;
                                objBOLItemSale.ShippingMethodID = Convert.ToInt32(cmbShippingMethod.SelectedValue);
                                objBOLItemSale.CreatedID = ClsCommon.UserID;

                                objBALItemSale.Insert(objBOLItemSale);
                            }
                        }
                        if (dgvInvoice1.Rows[i].Cells["ItemType"].Value.ToString() == "GroupTotal")
                        {
                            //Insert InvoiceDetails
                            objBOLInvDetails.InvoiceID = InvoiceID;
                            objBOLInvDetails.ItemID = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["ID"].Value.ToString());
                            objBOLInvDetails.Decs = "";
                            objBOLInvDetails.Quantity = 0;
                            objBOLInvDetails.Rate = 0;
                            if (dgvInvoice1.Rows[i].Cells["Amount"].Value == null)
                                objBOLInvDetails.Amount = 0;
                            else
                                objBOLInvDetails.Amount = Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Amount"].Value);
                            if (dgvInvoice1.Rows[i].Cells["ItemType"].Value == null)
                                objBOLInvDetails.ItemType = "";
                            else
                                objBOLInvDetails.ItemType = dgvInvoice1.Rows[i].Cells["ItemType"].Value.ToString();
                            objBOLInvDetails.CreatedTime = DateTime.Now;
                            objBOLInvDetails.CreatedID = ClsCommon.UserID;
                            if (dgvInvoice1.Rows[i].Cells["IMEINumber"].Value != null)
                            {
                                objBOLInvDetails.IMEINumber = dgvInvoice1.Rows[i].Cells["IMEINumber"].Value.ToString();
                            }
                            if (dgvInvoice1.Rows[i].Cells["CARRIERS"].Value != null)
                            {
                                objBOLInvDetails.Reason = dgvInvoice1.Rows[i].Cells["CARRIERS"].Value.ToString();
                            }
                            if (dgvInvoice1.Rows[i].Cells["GRADING"].Value != null)
                            {
                                objBOLInvDetails.GRADING = dgvInvoice1.Rows[i].Cells["GRADING"].Value.ToString();
                            }
                            objBALInvDetails.InvoiceDetailsInsert(objBOLInvDetails);
                        }
                    }
                }
                //Invoice History Save
                InvoiceHistorySave(InvoiceID.ToString());



                //CustomerBalance Update
                DataTable dtCusBalance = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                if (dtCusBalance.Rows.Count == 1)
                {
                    TotalBalance = Convert.ToDecimal(dtCusBalance.Rows[0]["TotalBalance"].ToString()) - Convert.ToDecimal(lblSubTotal.Text) - TotalBalance;
                    objBOLCustomer.ID = Convert.ToInt32(cmbCustomer.SelectedValue);
                    objBOLCustomer.TotalBalance = TotalBalance;
                    objBALCustomer.UpdateCustomerBalance(objBOLCustomer);
                }

                //InvoiceAuditLog Save
                InvoiceAuditLogSave();

                ISValid = true;
                txtID.Text = "";
                //}
                //else
                //    ISValid = false;


            }
            catch (Exception ex)
            {
                ISValid = false;
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :UpdateData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
            return ISValid;
        }
        private void InvoiceHistorySave(string InvoiceID)
        {
            try
            {
                // Insert InvoiceHistoryMaster
                objBOLInvHistoryMaster.SalesRepID = Convert.ToInt32(cmbSalesRep.SelectedValue);
                objBOLInvHistoryMaster.CreditMemoID = Convert.ToInt32(InvoiceID);
                objBOLInvHistoryMaster.CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue);
                objBOLInvHistoryMaster.AccountID = Convert.ToInt32(cmbAccount.SelectedValue);
                objBOLInvHistoryMaster.Total = Convert.ToDecimal(lblSubTotal.Text);
                objBOLInvHistoryMaster.Time = DateTime.Now;
                if (Mode == "insert")
                {
                    objBOLInvHistoryMaster.Mode = "insert";
                    objBOLInvHistoryMaster.CreatedID = ClsCommon.UserID;
                    objBOLInvHistoryMaster.ModifiedID = null;
                }
                else
                {
                    objBOLInvHistoryMaster.Mode = "update";
                    objBOLInvHistoryMaster.CreatedID = null;
                    objBOLInvHistoryMaster.ModifiedID = ClsCommon.UserID;
                }
                int InvoiceHistoryID = objBALInvHistoryMaster.Insert(objBOLInvHistoryMaster);

                // Insert InvoiceHistoryDetails

                for (int i = 0; i < dgvInvoice1.Rows.Count; i++)
                {
                    if (dgvInvoice1.Rows[i].Cells["ItemType"].Value != null)
                    {
                        objBOLInvHistoryDetails.CreditMemoHistoryID = InvoiceHistoryID;
                        if (dgvInvoice1.Rows[i].Cells["ID"].Value == null)
                            objBOLInvHistoryDetails.ItemID = 0;
                        else
                            objBOLInvHistoryDetails.ItemID = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["ID"].Value.ToString());
                        if (dgvInvoice1.Rows[i].Cells["Qty"].Value == null)
                            objBOLInvHistoryDetails.Qty = 0;
                        else
                            objBOLInvHistoryDetails.Qty = Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Qty"].Value);
                        if (dgvInvoice1.Rows[i].Cells["Rate"].Value == null)
                            objBOLInvHistoryDetails.Rate = 0;
                        else
                            objBOLInvHistoryDetails.Rate = Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Rate"].Value);
                        if (dgvInvoice1.Rows[i].Cells["Amount"].Value == null)
                            objBOLInvHistoryDetails.Amount = 0;
                        else
                            objBOLInvHistoryDetails.Amount = Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Amount"].Value);
                        objBALInvHistoryDetails.Insert(objBOLInvHistoryDetails);
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :InvoiceHistorySave. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void btnSaveandNew_Click(object sender, EventArgs e)
        {
            try
            {
                string InvID = "";
                if (SaveData(ref InvID))
                {

                    DataTable dtCus = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                    if (dtCus.Rows.Count > 0)
                    {
                        DataTable dtInv1 = new BALCreditMemo().SelectForPrint(new BOLCreditMemo() { ID = Convert.ToInt32(InvID) });
                        if (dtInv1.Rows.Count > 0)
                        {
                            DataTable dtInvDetail = new BALCreditMemoDetails().SelectByID(new BOLCreditMemoDetails() { InvoiceID = Convert.ToInt32(InvID) });

                            dtInv1.Columns.Add("BillAddr", typeof(string));
                            dtInv1.Columns.Add("ShipAddr", typeof(string));

                            #region BillAdd
                            if (dtCus.Rows[0]["Address1"].ToString() != "")
                                BillAddress = dtCus.Rows[0]["Address1"].ToString();
                            if (dtCus.Rows[0]["Address2"].ToString() != "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["Address2"].ToString();
                            if (dtCus.Rows[0]["Address3"].ToString() != "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["Address3"].ToString();

                            if (dtCus.Rows[0]["City"].ToString() != "" && dtCus.Rows[0]["State"].ToString() != "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["City"].ToString() + "," + dtCus.Rows[0]["State"].ToString();
                            else if (dtCus.Rows[0]["City"].ToString() != "" && dtCus.Rows[0]["State"].ToString() == "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["City"].ToString();
                            else if (dtCus.Rows[0]["City"].ToString() == "" && dtCus.Rows[0]["State"].ToString() != "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["State"].ToString();

                            if (dtCus.Rows[0]["PostalCode"].ToString() != "" && dtCus.Rows[0]["Country"].ToString() != "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["PostalCode"].ToString() + "," + dtCus.Rows[0]["Country"].ToString();
                            else if (dtCus.Rows[0]["Country"].ToString() != "" && dtCus.Rows[0]["PostalCode"].ToString() == "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["Country"].ToString();
                            else if (dtCus.Rows[0]["Country"].ToString() == "" && dtCus.Rows[0]["PostalCode"].ToString() != "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["PostalCode"].ToString();
                            #endregion

                            #region ShipAdd
                            if (dtInv1.Rows[0]["ShipAdd1"].ToString() != "")
                                ShipAddress = dtInv1.Rows[0]["ShipAdd1"].ToString();
                            if (dtInv1.Rows[0]["ShipAdd2"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipAdd2"].ToString();
                            if (dtInv1.Rows[0]["ShipAdd3"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipAdd3"].ToString();

                            if (dtInv1.Rows[0]["ShipCity"].ToString() != "" && dtInv1.Rows[0]["ShipState"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipCity"].ToString() + "," + dtInv1.Rows[0]["ShipState"].ToString();
                            else if (dtInv1.Rows[0]["ShipCity"].ToString() != "" && dtInv1.Rows[0]["ShipState"].ToString() == "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipCity"].ToString();
                            else if (dtInv1.Rows[0]["ShipCity"].ToString() == "" && dtInv1.Rows[0]["ShipState"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipState"].ToString();

                            if (dtInv1.Rows[0]["ShipPostalCode"].ToString() != "" && dtInv1.Rows[0]["ShipCountry"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipPostalCode"].ToString() + "," + dtInv1.Rows[0]["ShipCountry"].ToString();
                            else if (dtInv1.Rows[0]["ShipCountry"].ToString() != "" && dtInv1.Rows[0]["ShipPostalCode"].ToString() == "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipCountry"].ToString();
                            else if (dtInv1.Rows[0]["ShipCountry"].ToString() == "" && dtInv1.Rows[0]["ShipPostalCode"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipPostalCode"].ToString();

                            #endregion

                            dtInv1.Rows[0]["BillAddr"] = BillAddress.Replace("\r\n\r\n", "\r\n");
                            dtInv1.Rows[0]["ShipAddr"] = ShipAddress.Replace("\r\n\r\n", "\r\n");
                            BillAddress = ""; ShipAddress = "";

                            rptPrintReport cryRpt = new rptPrintReport();
                            cryRpt.Database.Tables[0].SetDataSource(dtInv1);
                            cryRpt.Database.Tables[1].SetDataSource(dtInvDetail);
                            crystalReportViewer1.ReportSource = cryRpt;
                            cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + @"\PrintReport\" + dtInv1.Rows[0]["RefNumber"].ToString() + "_" + dtInv1.Rows[0]["CustomerID"].ToString() + ".pdf");


                        }
                    }
                    ClsCommon.ObjCustomerCenter.LoadFunction();
                    Clear();
                    InvoiceNumber(ClsCommon.TaxWithoutTax);
                    CheckDate();
                    Mode = "insert";
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :btnSaveandNew_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void btnSaveandClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (Mode == "insert")
                {
                    ConvertTaxToNonTax();
                }
                string InvID = "";
                if (SaveData(ref InvID))
                {
                    Inv = InvID;

                    DataTable dtCus = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                    if (dtCus.Rows.Count > 0)
                    {
                        DataTable dtInv1 = new BALCreditMemo().SelectForPrint(new BOLCreditMemo() { ID = Convert.ToInt32(InvID) });
                        if (dtInv1.Rows.Count > 0)
                        {
                            DataTable dtInvDetail = new BALCreditMemoDetails().SelectByID(new BOLCreditMemoDetails() { InvoiceID = Convert.ToInt32(InvID) });

                            dtInv1.Columns.Add("BillAddr", typeof(string));
                            dtInv1.Columns.Add("ShipAddr", typeof(string));

                            #region BillAdd
                            if (dtCus.Rows[0]["Address1"].ToString() != "")
                                BillAddress = dtCus.Rows[0]["Address1"].ToString();
                            if (dtCus.Rows[0]["Address2"].ToString() != "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["Address2"].ToString();
                            if (dtCus.Rows[0]["Address3"].ToString() != "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["Address3"].ToString();

                            if (dtCus.Rows[0]["City"].ToString() != "" && dtCus.Rows[0]["State"].ToString() != "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["City"].ToString() + "," + dtCus.Rows[0]["State"].ToString();
                            else if (dtCus.Rows[0]["City"].ToString() != "" && dtCus.Rows[0]["State"].ToString() == "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["City"].ToString();
                            else if (dtCus.Rows[0]["City"].ToString() == "" && dtCus.Rows[0]["State"].ToString() != "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["State"].ToString();

                            if (dtCus.Rows[0]["PostalCode"].ToString() != "" && dtCus.Rows[0]["Country"].ToString() != "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["PostalCode"].ToString() + "," + dtCus.Rows[0]["Country"].ToString();
                            else if (dtCus.Rows[0]["Country"].ToString() != "" && dtCus.Rows[0]["PostalCode"].ToString() == "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["Country"].ToString();
                            else if (dtCus.Rows[0]["Country"].ToString() == "" && dtCus.Rows[0]["PostalCode"].ToString() != "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["PostalCode"].ToString();
                            #endregion

                            #region ShipAdd
                            if (dtInv1.Rows[0]["ShipAdd1"].ToString() != "")
                                ShipAddress = dtInv1.Rows[0]["ShipAdd1"].ToString();
                            if (dtInv1.Rows[0]["ShipAdd2"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipAdd2"].ToString();
                            if (dtInv1.Rows[0]["ShipAdd3"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipAdd3"].ToString();

                            if (dtInv1.Rows[0]["ShipCity"].ToString() != "" && dtInv1.Rows[0]["ShipState"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipCity"].ToString() + "," + dtInv1.Rows[0]["ShipState"].ToString();
                            else if (dtInv1.Rows[0]["ShipCity"].ToString() != "" && dtInv1.Rows[0]["ShipState"].ToString() == "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipCity"].ToString();
                            else if (dtInv1.Rows[0]["ShipCity"].ToString() == "" && dtInv1.Rows[0]["ShipState"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipState"].ToString();

                            if (dtInv1.Rows[0]["ShipPostalCode"].ToString() != "" && dtInv1.Rows[0]["ShipCountry"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipPostalCode"].ToString() + "," + dtInv1.Rows[0]["ShipCountry"].ToString();
                            else if (dtInv1.Rows[0]["ShipCountry"].ToString() != "" && dtInv1.Rows[0]["ShipPostalCode"].ToString() == "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipCountry"].ToString();
                            else if (dtInv1.Rows[0]["ShipCountry"].ToString() == "" && dtInv1.Rows[0]["ShipPostalCode"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipPostalCode"].ToString();

                            #endregion

                            dtInv1.Rows[0]["BillAddr"] = BillAddress.Replace("\r\n\r\n", "\r\n");
                            dtInv1.Rows[0]["ShipAddr"] = ShipAddress.Replace("\r\n\r\n", "\r\n");
                            BillAddress = ""; ShipAddress = "";

                            DataTable dtNewdtInvDetail = new DataTable();
                            if (dtInvDetail.Rows.Count > 0)
                            {
                                DataRow[] drcheck = dtInvDetail.Select("[ItemFullName]='shipping'");
                                if (drcheck.Length > 0)
                                {
                                    DataRow[] drcheck1 = dtInvDetail.Select("[ItemFullName]<>'shipping'");
                                    if (drcheck1.Length > 0)
                                    {
                                        DataTable dtTemp1 = drcheck1.CopyToDataTable();
                                        dtNewdtInvDetail = dtTemp1.Copy();
                                    }
                                    DataTable dtTemp2 = drcheck.CopyToDataTable();
                                    dtNewdtInvDetail.Merge(dtTemp2);
                                }
                                else
                                {
                                    dtNewdtInvDetail = dtInvDetail.Copy();
                                }
                            }
                            try
                            {
                                rptPrintReport cryRpt = new rptPrintReport();
                                cryRpt.Database.Tables[0].SetDataSource(dtInv1);
                                cryRpt.Database.Tables[1].SetDataSource(dtNewdtInvDetail);
                                //cryRpt.Subreports[0].SetDataSource(dtInvDetail);
                                crystalReportViewer1.ReportSource = cryRpt;
                                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + @"\PrintReport\" + dtInv1.Rows[0]["RefNumber"].ToString() + "_" + dtInv1.Rows[0]["CustomerID"].ToString() + ".pdf");
                            }
                            catch (Exception ex)
                            {
                                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :btnSaveandClose_Click. Crystal Report Export Message:" + ex.Message);
                            }

                        }
                    }
                    //obj.ShowDialog();
                    //dgvCustomerList.Rows[CustRowIndex].Selected = true;
                    ClsCommon.ObjCustomerCenter.LoadFunc();
                    //ClsCommon.ObjCustomerCenter.LoadCustomerData(Convert.ToInt32(cmbCustomer.SelectedValue.ToString()));
                    Clear();
                    this.Close();
                    Mode = "insert";
                    //DisplayRequest();
                    ClsCommon.objTodayInvoice.LoadInvoice();
                    //ClsCommon.ObjCustomerCenter.loadData();

                    UpdatePriceTier(Convert.ToInt32(cmbCustomer.SelectedValue), cmbPrice.SelectedText, ClsCommon.UserID);

                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :btnSaveandClose_Click. Message:" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        //Hiren
        private void ConvertTaxToNonTax()
        {
            if (ClsCommon.TaxWithoutTax == "Yes")
            {
                DialogResult result = MessageBox.Show("Do you want to create a Tax CreditMemo? Click 'Yes' to proceed or 'No' to create a Non-Tax CreditMemo.",
                                                      "Select Action",
                                                      MessageBoxButtons.YesNoCancel,
                                                      MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    DataTable dtInvoiceNo = new BALInvoiceMaster().CASelectMax("CreditMemo");
                    string refnumber = dtInvoiceNo.Rows[0]["Refnumber"].ToString();
                    txtInvoiceNo.Text = "CN-" + refnumber;
                    ClsCommon.TaxWithoutTax = "No";
                    objBOLInvoice.Total = Convert.ToDecimal(lblSubTotal.Text) - Convert.ToDecimal(lblTaxAmount.Text);
                    objBOLInvoice.BalanceDue = objBOLInvoice.Total;
                    objBOLInvoice.TaxAmount = 0;
                    objBOLInvoice.TaxID = 0;
                    objBOLInvoice.TaxPercent = 0;
                    UpdateInvoiceLabels(refnumber);
                    cmbSalesTax.SelectedIndex = 0;
                }
                else if (result == DialogResult.Yes)
                {
                    ClsCommon.TaxWithoutTax = "Yes";
                    UpdateTaxInvoiceValues();
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to create a Non-Tax CreditMemo? Click 'Yes' to proceed or 'No' to create a Tax CreditMemo.",
                                                      "Select Action",
                                                      MessageBoxButtons.YesNoCancel,
                                                      MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    cmbSalesTax.Enabled = true;
                    int selectedCustomerID = Convert.ToInt32(cmbCustomer.SelectedValue);
                    DataTable dtInvoiceNo = new BALInvoiceMaster().CASelectMaxTax("Invoice");
                    if (dtInvoiceNo.Rows.Count > 0)
                    {

                        string refNumber = dtInvoiceNo.Rows[0]["Refnumber"].ToString();
                        refNumber = "CN-" + refNumber;
                        //string refNumber = dtInvoiceNo.Rows[0]["Refnumber"].ToString();
                        //int newRefNumber = Convert.ToInt32(refNumber) + 1;
                        //refNumber = newRefNumber.ToString().PadLeft(refNumber.Length, '0');

                        DataTable refNumberCheck = new BALInvoiceMaster().SelectByRefNumber(new BOLInvoiceMaster() { RefNumber = refNumber });

                        DataTable dtcus = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = selectedCustomerID });
                        if (dtcus.Rows.Count > 0)
                        {
                            ClsCommon.TaxWithoutTax = "Yes";

                            objBOLInvoice.TaxID = dtcus.Rows[0]["SalesTaxID"] != DBNull.Value ? Convert.ToInt32(dtcus.Rows[0]["SalesTaxID"]) : 0;
                            objBOLInvoice.TaxPercent = dtcus.Rows[0]["SalesTaxPercentage"] != DBNull.Value ? Convert.ToDecimal(dtcus.Rows[0]["SalesTaxPercentage"]) : 0;

                            decimal totalAmount = Convert.ToDecimal(lblTotal.Text);
                            objBOLInvoice.TaxAmount = totalAmount * objBOLInvoice.TaxPercent / 100;
                            objBOLInvoice.Total = totalAmount + objBOLInvoice.TaxAmount;
                            objBOLInvoice.BalanceDue = objBOLInvoice.Total;

                            UpdateInvoiceLabels(refNumber);
                            cmbSalesTax.Text = dtcus.Rows[0]["SalesTaxName"].ToString();
                        }
                    }
                }
                else if (result == DialogResult.Yes)
                {
                    ClsCommon.TaxWithoutTax = "No";
                    UpdateTaxInvoiceValues();
                }
            }
        }
        private void UpdateInvoiceLabels(string refNumber)
        {
            txtInvoiceNo.Text = refNumber;
            lblTotal.Text = objBOLInvoice.Total.ToString("F2");
            lblTaxAmount.Text = objBOLInvoice.TaxAmount.ToString("F2");
            lblSubTotal.Text = objBOLInvoice.Total.ToString("F2");
            lblBalanceDue.Text = objBOLInvoice.BalanceDue.ToString("F2");
            lblTaxPercentage.Text = objBOLInvoice.TaxPercent.ToString("F2");
        }
        private void UpdateTaxInvoiceValues()
        {
            objBOLInvoice.Total = Convert.ToDecimal(lblSubTotal.Text);
            objBOLInvoice.TaxAmount = Convert.ToDecimal(lblTaxAmount.Text);
            objBOLInvoice.TaxID = Convert.ToInt32(cmbSalesTax.SelectedValue);
            objBOLInvoice.TaxPercent = Convert.ToDecimal(lblTaxPercentage.Text.Replace("(", "").Replace("%)", ""));
            objBOLInvoice.BalanceDue = Convert.ToDecimal(lblBalanceDue.Text);
        }
        //
        public void UpdatePriceTier(int CustomerID, string PriceTier, int UserID)
        {
            bOLAssignPriceTier.PriceTier = PriceTier;
            bOLAssignPriceTier.UserID = UserID;
            bOLAssignPriceTier.CustomerID = CustomerID;
            bALAssignPriceTier.InsertUpdate(bOLAssignPriceTier);
        }
        private void DisplayRequest()
        {
            if (ClsCommon.Flag == 1)
            {
                ClsCommon.objRequestCount.LoadData();
                ClsCommon.objRequestCount.Show();
                ClsCommon.objRequestCount.BringToFront();

            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            Clear();
            Mode = "insert";
            cmbCustomer.Focus();
        }
        public void LoadAddressDetails()
        {
            try
            {
                if (cmbCustomer.SelectedIndex > 0)
                {
                    GetShipAddress(Convert.ToInt32(cmbCustomer.SelectedValue));
                    DataTable dtAddress = new BALCustomerMaster().SelectByAddressID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                    if (dtAddress.Rows.Count > 0)
                    {
                        BillAddress = "";
                        //if (dtAddress.Rows[0]["TermsID"].ToString() != null && dtAddress.Rows[0]["TermsID"].ToString() != "")
                        //    cmbTerms.SelectedValue = dtAddress.Rows[0]["TermsID"].ToString();
                        //if (dtAddress.Rows[0]["SalesRepID"].ToString() != null && dtAddress.Rows[0]["SalesRepID"].ToString() != "")
                        //    cmbSalesRep.SelectedValue = dtAddress.Rows[0]["SalesRepID"].ToString();
                        foreach (DataRow dr in dtAddress.Rows)
                        {
                            if (dr["AddressType"].ToString() == "B")
                            {
                                if (dr["Address1"].ToString() != "")
                                    BillAddress = dr["Address1"].ToString();
                                if (dr["Address2"].ToString() != "")
                                    BillAddress = BillAddress + "\r\n" + dr["Address2"].ToString();
                                if (dr["Address3"].ToString() != "")
                                    BillAddress = BillAddress + "\r\n" + dr["Address3"].ToString();

                                if (dr["City"].ToString() != "" && dr["State"].ToString() != "")
                                    BillAddress = BillAddress + "\r\n" + dr["City"].ToString() + "," + dr["State"].ToString();
                                else if (dr["City"].ToString() != "" && dr["State"].ToString() == "")
                                    BillAddress = BillAddress + "\r\n" + dr["City"].ToString();
                                else if (dr["City"].ToString() == "" && dr["State"].ToString() != "")
                                    BillAddress = BillAddress + "\r\n" + dr["State"].ToString();

                                if (dr["PostalCode"].ToString() != "" && dr["Country"].ToString() != "")
                                    BillAddress = BillAddress + "\r\n" + dr["PostalCode"].ToString() + "," + dr["Country"].ToString();
                                else if (dr["Country"].ToString() != "" && dr["PostalCode"].ToString() == "")
                                    BillAddress = BillAddress + "\r\n" + dr["Country"].ToString();
                                else if (dr["Country"].ToString() == "" && dr["PostalCode"].ToString() != "")
                                    BillAddress = BillAddress + "\r\n" + dr["PostalCode"].ToString();

                                if (dr["Note"].ToString() != "")
                                    BillAddress = BillAddress + "\r\n" + dr["Note"].ToString();
                                txtBillAddress.Text = BillAddress.Replace("\r\n\r\n", "\r\n");
                            }
                            else if (dr["AddressType"].ToString() == "S")
                            {
                                if (dr["DefaultShipping"].ToString() == "1")
                                {
                                    cmbShipAddress.SelectedValue = dr["ID"].ToString();
                                    //LoadShipAddress();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :LoadAddressDetails. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void SelectCustomer(Int32 CusID)
        {
            Clear();
            cmbCustomer.SelectedValue = CusID;

            if (ClsCommon.UserType != "admin" && ClsCommon.UserType != "Admin")
                cmbSalesRep.SelectedValue = ClsCommon.UserID;
            this.cmbCustomer.Focus();
            cmbCustomer.Select();
        }
        public void LoadShipAddress()
        {
            try
            {
                if (cmbShipAddress.Text == "ADD NEW")
                {
                    txtShipAddress.Text = "";
                    FrmAddShipAddress obj = new FrmAddShipAddress();
                    obj.txtID.Text = cmbCustomer.SelectedValue.ToString();
                    obj.Show();
                    GetShipAddress(Convert.ToInt32(cmbCustomer.SelectedValue));
                }
                else if (cmbShipAddress.SelectedIndex >= 0)
                {
                    DataTable dtAddress = new BALCustomerMaster().SelectByAddressID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                    if (dtAddress.Rows.Count > 0)
                    {
                        ShipAddress = "";
                        foreach (DataRow dr in dtAddress.Rows)
                        {
                            if (dr["AddressType"].ToString() == "S")
                            {
                                if (cmbShipAddress.SelectedValue.ToString() == dr["ID"].ToString())
                                {
                                    if (dr["Address1"].ToString() != "")
                                        ShipAddress = dr["Address1"].ToString();
                                    if (dr["Address2"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dr["Address2"].ToString();
                                    if (dr["Address3"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dr["Address3"].ToString();

                                    if (dr["City"].ToString() != "" && dr["State"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dr["City"].ToString() + "," + dr["State"].ToString();
                                    else if (dr["City"].ToString() != "" && dr["State"].ToString() == "")
                                        ShipAddress = ShipAddress + "\r\n" + dr["City"].ToString();
                                    else if (dr["City"].ToString() == "" && dr["State"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dr["State"].ToString();

                                    if (dr["PostalCode"].ToString() != "" && dr["Country"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dr["PostalCode"].ToString() + "," + dr["Country"].ToString();
                                    else if (dr["Country"].ToString() != "" && dr["PostalCode"].ToString() == "")
                                        ShipAddress = ShipAddress + "\r\n" + dr["Country"].ToString();
                                    else if (dr["Country"].ToString() == "" && dr["PostalCode"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dr["PostalCode"].ToString();

                                    if (dr["Note"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dr["Note"].ToString();
                                    txtShipAddress.Text = ShipAddress.Replace("\r\n\r\n", "\r\n");
                                    break;
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :LoadShipAddress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void cmbShipAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtShipAddress.Text = "";
                txtaddrID.Text = "0";
                if (cmbShipAddress.Text == "ADD NEW")
                {
                    FrmAddShipAddress obj = new FrmAddShipAddress();
                    obj.txtID.Text = cmbCustomer.SelectedValue.ToString();
                    obj.CustomerName = cmbCustomer.Text;
                    obj.Show();

                }
                else if (cmbShipAddress.SelectedIndex >= 0)
                {
                    DataTable dtAddress = new BALCustomerMaster().SelectByAddressID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                    if (dtAddress.Rows.Count > 0)
                    {
                        ShipAddress = "";
                        foreach (DataRow dr in dtAddress.Rows)
                        {
                            if (dr["AddressType"].ToString() == "S")
                            {
                                if (cmbShipAddress.SelectedValue.ToString() == dr["ID"].ToString())
                                {
                                    txtaddrID.Text = dr["ID"].ToString();
                                    if (dr["Address1"].ToString() != "")
                                        ShipAddress = dr["Address1"].ToString();
                                    if (dr["Address2"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dr["Address2"].ToString();
                                    if (dr["Address3"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dr["Address3"].ToString();

                                    if (dr["City"].ToString() != "" && dr["State"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dr["City"].ToString() + "," + dr["State"].ToString();
                                    else if (dr["City"].ToString() != "" && dr["State"].ToString() == "")
                                        ShipAddress = ShipAddress + "\r\n" + dr["City"].ToString();
                                    else if (dr["City"].ToString() == "" && dr["State"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dr["State"].ToString();

                                    if (dr["PostalCode"].ToString() != "" && dr["Country"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dr["PostalCode"].ToString() + "," + dr["Country"].ToString();
                                    else if (dr["Country"].ToString() != "" && dr["PostalCode"].ToString() == "")
                                        ShipAddress = ShipAddress + "\r\n" + dr["Country"].ToString();
                                    else if (dr["Country"].ToString() == "" && dr["PostalCode"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dr["PostalCode"].ToString();

                                    if (dr["Note"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dr["Note"].ToString();
                                    txtShipAddress.Text = ShipAddress.Replace("\r\n\r\n", "\r\n");
                                }
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :cmbShipAddress_SelectedIndexChanged. Message:" + ex.Message);
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
                        if (cmbShipAddress.SelectedIndex >= 0)
                        {
                            if (dr["ID"].ToString() == cmbShipAddress.SelectedValue.ToString())
                            {
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
                                txtShipAddress.Text = ShipAddress.Replace("\r\n\r\n", "\r\n");
                            }
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
        public static string RemoveDigits(string key)
        {
            return Regex.Replace(key, @"\D", "");
        }
        private void dgvInvoiceTemp_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //try
            //{
            //    if (dgvInvoice.CurrentCell.ColumnIndex == 1 && e.Control is ComboBox)
            //    {
            //        ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
            //        ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
            //        ((ComboBox)e.Control).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //        ((ComboBox)e.Control).DropDownWidth = 300;
            //        ComboBox comboBox = e.Control as ComboBox;
            //        if (comboBox != null)
            //        {
            //            comboBox.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
            //            comboBox.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            //        }
            //    }
            //    if (dgvInvoice.CurrentCell.ColumnIndex == 3 || dgvInvoice.CurrentCell.ColumnIndex == 4 || dgvInvoice.CurrentCell.ColumnIndex == 5)
            //    {
            //        DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
            //        tb.KeyPress += new KeyPressEventHandler(dgvInvoice_KeyPress);
            //        e.Control.KeyPress += new KeyPressEventHandler(dgvInvoice_KeyPress);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :dgvInvoice_EditingControlShowing. Message:" + ex.Message);
            //    MessageBox.Show("Error:" + ex.Message);
            //}
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (((ComboBox)sender).SelectedIndex != -1)
            //{

            //    DataTable dt = new BALItemMaster().Select(new BOLItemMaster() { });
            //    if (dt.Rows.Count > 0)
            //    {
            //        DataRow[] row = dt.Select("FullName = '" + ((ComboBox)sender).Text.ToString() + "'");
            //        if (row.Length == 1)
            //        {
            //            foreach (DataRow dr in row)
            //            {
            //                //Group Item add
            //                if (dr["ItemType"].ToString() == "GroupItem")
            //                {
            //                    dgvInvoice.Rows.Add();
            //                    int i = dgvInvoice.Rows.Count - 2;

            //                    dgvInvoice.Rows[i].Cells["ID"].Value = dr["ID"].ToString();
            //                    dgvInvoice.Rows[i].Cells["Item"].Value = dr["FullName"].ToString();
            //                    dgvInvoice.Rows[i].Cells["Description"].Value = dr["SalesDesc"].ToString();
            //                    dgvInvoice.Rows[i].Cells["Qty"].Value = 1;
            //                    dgvInvoice.Rows[i].Cells["Item"].ReadOnly = true;
            //                    dgvInvoice.Rows[i].Cells["Description"].ReadOnly = true;
            //                    dgvInvoice.Rows[i].Cells["Rate"].ReadOnly = true;
            //                    dgvInvoice.Rows[i].Cells["Amount"].ReadOnly = true;
            //                    dgvInvoice.Rows[i].Cells["Type"].Value = 0;
            //                    dgvInvoice.Rows[i].Cells["ItemType"].Value = dr["ItemType"].ToString();

            //                    DataTable dtGroupItem = new BALGroupSubItem().SelectByGroupID(new BOLGroupSubItem() { GroupItemID = Convert.ToInt32(dr["ID"].ToString()) });
            //                    if (dtGroupItem.Rows.Count > 0)
            //                    {
            //                        Total = 0;
            //                        foreach (DataRow dr1 in dtGroupItem.Rows)
            //                        {
            //                            dgvInvoice.Rows.Add();
            //                            int j = dgvInvoice.Rows.Count - 2;
            //                            dgvInvoice.Rows[j].Cells["ID"].Value = dr1["ItemID"].ToString();
            //                            dgvInvoice.Rows[j].Cells["Item"].Value = dr1["FullName"].ToString();
            //                            dgvInvoice.Rows[j].Cells["Description"].Value = dr1["Description"].ToString();
            //                            if (dr1["Qty"].ToString() == null || dr1["Qty"].ToString() == "")
            //                                dgvInvoice.Rows[j].Cells["Qty"].Value = 0;
            //                            else
            //                                dgvInvoice.Rows[j].Cells["Qty"].Value = dr1["Qty"].ToString();
            //                            if (dr1["SalesPrice"].ToString() == null || dr1["SalesPrice"].ToString() == "")
            //                                dgvInvoice.Rows[j].Cells["Rate"].Value = 0;
            //                            else
            //                                dgvInvoice.Rows[j].Cells["Rate"].Value = dr1["SalesPrice"].ToString();
            //                            dgvInvoice.Rows[j].Cells["Amount"].Value = Convert.ToDecimal(dr1["Qty"].ToString()) * Convert.ToDecimal(dr1["SalesPrice"].ToString());
            //                            Total += Convert.ToDecimal(dgvInvoice.Rows[j].Cells["Amount"].Value);
            //                            dgvInvoice.Rows[j].Cells["Item"].ReadOnly = true;
            //                            dgvInvoice.Rows[j].Cells["Qty"].ReadOnly = true;
            //                            dgvInvoice.Rows[j].Cells["Rate"].ReadOnly = true;
            //                            dgvInvoice.Rows[j].Cells["Amount"].ReadOnly = true;
            //                            dgvInvoice.Rows[j].Cells["Type"].Value = 0;
            //                            dgvInvoice.Rows[j].Cells["ItemType"].Value = "SubItem";
            //                        }
            //                    }
            //                    dgvInvoice.Rows.Add();
            //                    int k = dgvInvoice.Rows.Count - 2;

            //                    dgvInvoice.Rows[k].Cells["ID"].Value = dr["ID"].ToString();
            //                    dgvInvoice.Rows[k].Cells["Item"].ReadOnly = true;
            //                    dgvInvoice.Rows[k].Cells["Description"].ReadOnly = true;
            //                    dgvInvoice.Rows[k].Cells["Qty"].ReadOnly = true;
            //                    dgvInvoice.Rows[k].Cells["Rate"].ReadOnly = true;
            //                    dgvInvoice.Rows[k].Cells["Amount"].ReadOnly = true;
            //                    dgvInvoice.Rows[k].Cells["Amount"].Value = Total;
            //                    dgvInvoice.Rows[k].Cells["Type"].Value = 1;
            //                    dgvInvoice.Rows[k].Cells["ItemType"].Value = "GroupTotal";
            //                }
            //                else
            //                {
            //                    //Regular Item add 
            //                    dgvInvoice.CurrentRow.Cells["ID"].Value = dr["ID"].ToString();
            //                    dgvInvoice.CurrentRow.Cells["Description"].Value = dr["SalesDesc"].ToString();
            //                    dgvInvoice.CurrentRow.Cells["Rate"].Value = dr["SalesPrice"].ToString();
            //                    dgvInvoice.CurrentRow.Cells["LowestPrice"].Value = dr["LowestPrice"].ToString();
            //                    dgvInvoice.CurrentRow.Cells["Type"].Value = 1;
            //                    dgvInvoice.CurrentRow.Cells["ItemType"].Value = dr["ItemType"].ToString();
            //                    dgvInvoice.CurrentRow.Cells["Qty"].Value = 1;
            //                    dgvInvoice.CurrentRow.Cells["Amount"].Value = 1 * Convert.ToDecimal(dr["SalesPrice"].ToString());

            //                    DataTable dtSale = new BALItemSaleHistory().SelectLastThreeSale(new BOLItemSaleHistory() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), ItemID = Convert.ToInt32(dgvInvoice.CurrentRow.Cells["ID"].Value) });
            //                    if (dtSale.Rows.Count > 0)
            //                    {
            //                        for (int i = 0; i < dtSale.Rows.Count; i++)
            //                        {
            //                            if (i == 0)
            //                                dgvInvoice.CurrentRow.Cells["ItemPrice1"].Value = dtSale.Rows[i]["SalePrice"].ToString();
            //                            if (i == 1)
            //                                dgvInvoice.CurrentRow.Cells["ItemPrice2"].Value = dtSale.Rows[i]["SalePrice"].ToString();
            //                            if (i == 2)
            //                                dgvInvoice.CurrentRow.Cells["ItemPrice3"].Value = dtSale.Rows[i]["SalePrice"].ToString();
            //                        }
            //                    }
            //                    else
            //                    {
            //                        dgvInvoice.CurrentRow.Cells["ItemPrice1"].Value = "";
            //                        dgvInvoice.CurrentRow.Cells["ItemPrice2"].Value = "";
            //                        dgvInvoice.CurrentRow.Cells["ItemPrice3"].Value = "";
            //                    }
            //                }
            //            }
            //            // TotalAmount
            //            Total = 0;
            //            for (int i = 0; i < dgvInvoice.Rows.Count; i++)
            //            {
            //                if (dgvInvoice.Rows[i].Cells["Type"].Value != null)
            //                {
            //                    if (dgvInvoice.Rows[i].Cells["Type"].Value.ToString() == "1")
            //                    {
            //                        Total += Convert.ToDecimal(dgvInvoice.Rows[i].Cells["Amount"].Value);
            //                        lblTotal.Text = Total.ToString();
            //                        lblPaymentApplied.Text = "0.0";
            //                        lblBalanceDue.Text = (Convert.ToDecimal(lblTotal.Text) - Convert.ToDecimal(lblPaymentApplied.Text)).ToString();
            //                    }
            //                }
            //            }

            //            //For Paid Invoice Setting...
            //            if (txtID.Text != "")
            //            {
            //                objBOLInvoice.ID = Convert.ToInt32(txtID.Text);
            //                DataTable dtInv = new BALInvoiceMaster().SelectByID(objBOLInvoice);
            //                if (dtInv.Rows.Count > 0)
            //                {
            //                    lblPaymentApplied.Text = dtInv.Rows[0]["AppliedAmount"].ToString();
            //                    lblBalanceDue.Text = (Convert.ToDecimal(lblTotal.Text) - Convert.ToDecimal(lblPaymentApplied.Text)).ToString();
            //                }

            //            }


            //            //Approve Msg
            //            DataTable dtApprove = new BALCustomerRequest().SelectApprovedStatus(new BOLCustomerRequest() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), ItemID = Convert.ToInt32(dgvInvoice.CurrentRow.Cells["ID"].Value) });
            //            if (dtApprove.Rows.Count > 0)
            //            {
            //                if (Convert.ToInt32(dtApprove.Rows[0]["UseAllowesNo"].ToString()) > 0)
            //                {
            //                    MessageBox.Show("You could set this price for " + dtApprove.Rows[0]["UseAllowesNo"].ToString() + " more times");
            //                }
            //                else if (Convert.ToInt32(dtApprove.Rows[0]["UseNoOFDays"].ToString()) > 0)
            //                {
            //                    string Date = Convert.ToDateTime(dtApprove.Rows[0]["ModifiedTime"].ToString()).ToString("MM-dd-yyyy");
            //                    Int16 NoOfDays = Convert.ToInt16(dtApprove.Rows[0]["UseNoOFDays"].ToString());
            //                    DateTime Date1 = Convert.ToDateTime(Date).AddDays(NoOfDays);
            //                    string Date2 = DateTime.Now.ToString("MM-dd-yyyy");
            //                    if (Date1 >= Convert.ToDateTime(Date2))
            //                    {
            //                        double Days = (Date1 - Convert.ToDateTime(Date2)).TotalDays;
            //                        MessageBox.Show("You could set this price till " + Days + " days");
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
        }
        private void dgvInvoiceTemp_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    // Amount Calculation
            //    if (dgvInvoice.CurrentCell.ColumnIndex == 5)
            //    {
            //        if (dgvInvoice.CurrentRow.Cells["Amount"].Value != null && dgvInvoice.CurrentRow.Cells["Qty"].Value != null)
            //            dgvInvoice.CurrentRow.Cells["Rate"].Value = Convert.ToDecimal(dgvInvoice.CurrentRow.Cells["Amount"].Value) / Convert.ToDecimal(dgvInvoice.CurrentRow.Cells["Qty"].Value);
            //    }
            //    if ((dgvInvoice.CurrentCell.ColumnIndex == 3 || dgvInvoice.CurrentCell.ColumnIndex == 4))
            //    {
            //        //Group Item Calculations
            //        if (dgvInvoice.CurrentRow.Cells["ItemType"].Value.ToString() == "GroupItem")
            //        {
            //            if (dgvInvoice.CurrentRow.Cells["Qty"].Value != null && dgvInvoice.CurrentRow.Cells["Qty"].Value.ToString() != "")
            //            {
            //                Int32 GroupItemID = 0; Total = 0; decimal Qty = 0;
            //                Qty = Convert.ToDecimal(dgvInvoice.CurrentRow.Cells["Qty"].Value);
            //                GroupItemID = Convert.ToInt32(dgvInvoice.CurrentRow.Cells["ID"].Value);
            //                foreach (DataGridViewRow row in dgvInvoice.Rows)
            //                {
            //                    if (row.Cells["ItemType"].Value != null && row.Cells["ItemType"].Value.ToString() != "")
            //                    {
            //                        if (row.Cells["ItemType"].Value.ToString() == "SubItem")
            //                        {
            //                            DataTable dtGroupItem = new BALGroupSubItem().SelectByGroupID(new BOLGroupSubItem() { GroupItemID = GroupItemID });
            //                            if (dtGroupItem.Rows.Count > 0)
            //                            {
            //                                DataRow[] grow = dtGroupItem.Select("ItemID = '" + row.Cells["ID"].Value + "'");
            //                                if (grow.Length == 1)
            //                                {
            //                                    foreach (DataRow dr in grow)
            //                                    {
            //                                        row.Cells["Qty"].Value = Qty * Convert.ToDecimal(dr["Qty"]);
            //                                        row.Cells["Amount"].Value = Convert.ToDecimal(dr["SalesPrice"]) * Convert.ToDecimal(row.Cells["Qty"].Value);
            //                                        Total += Convert.ToDecimal(row.Cells["Amount"].Value);
            //                                    }
            //                                }
            //                            }
            //                        }
            //                        if (row.Cells["ItemType"].Value.ToString() == "GroupTotal" && row.Cells["ID"].Value.ToString() == GroupItemID.ToString())
            //                        {
            //                            row.Cells["Amount"].Value = Total;
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (dgvInvoice.CurrentRow.Cells["Qty"].Value != null && dgvInvoice.CurrentRow.Cells["Rate"].Value != null)
            //                dgvInvoice.CurrentRow.Cells["Amount"].Value = Convert.ToDecimal(dgvInvoice.CurrentRow.Cells["Qty"].Value) * Convert.ToDecimal(dgvInvoice.CurrentRow.Cells["Rate"].Value);
            //            else if (dgvInvoice.CurrentRow.Cells["Qty"].Value != null && dgvInvoice.CurrentRow.Cells["Rate"].Value == null)
            //                dgvInvoice.CurrentRow.Cells["Amount"].Value = "0.00";
            //            else if (dgvInvoice.CurrentRow.Cells["Qty"].Value == null && dgvInvoice.CurrentRow.Cells["Rate"].Value != null)
            //                dgvInvoice.CurrentRow.Cells["Amount"].Value = dgvInvoice.CurrentRow.Cells["Rate"].Value.ToString();
            //            lblTotal.Text = dgvInvoice.CurrentRow.Cells["Amount"].Value.ToString();
            //            lblBalanceDue.Text = dgvInvoice.CurrentRow.Cells["Amount"].Value.ToString();
            //        }
            //    }
            //    // TotalAmount
            //    Total = 0;
            //    foreach (DataGridViewRow row in dgvInvoice.Rows)
            //    {
            //        if (row.Cells["Type"].Value != null)
            //        {
            //            if (row.Cells["Type"].Value.ToString() == "1")
            //            {
            //                Total += Convert.ToDecimal(row.Cells["Amount"].Value);
            //                lblTotal.Text = Total.ToString();
            //                lblPaymentApplied.Text = "0.0";
            //                lblBalanceDue.Text = (Convert.ToDecimal(lblTotal.Text) - Convert.ToDecimal(lblPaymentApplied.Text)).ToString();
            //            }
            //        }
            //    }

            //    //For Paid Invoice Setting...
            //    if (txtID.Text != "")
            //    {
            //        objBOLInvoice.ID = Convert.ToInt32(txtID.Text);
            //        DataTable dtInv = new BALInvoiceMaster().SelectByID(objBOLInvoice);
            //        if (dtInv.Rows.Count > 0)
            //        {
            //            lblPaymentApplied.Text = dtInv.Rows[0]["AppliedAmount"].ToString();
            //            lblBalanceDue.Text = (Convert.ToDecimal(lblTotal.Text) - Convert.ToDecimal(lblPaymentApplied.Text)).ToString();
            //        }

            //    }


            //}
            //catch (Exception ex)
            //{
            //    ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :dgvInvoice_CellEndEdit. Message:" + ex.Message);
            //    MessageBox.Show("Error:" + ex.Message);
            //}
        }
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Escape) this.Close();
        //    bool res = base.ProcessCmdKey(ref msg, keyData);

        //    return res;
        //}
        private void btnNewInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                btnAdd.Enabled = true;
                if (ClsCommon.FunctionVisibility("CreditMemoInsert", "CustomerCenter"))
                {
                    txtID.Text = "";
                    Mode = "insert";
                    dgvInvoice1.DataSource = "";
                    Clear();
                    CheckDate();


                    DataTable dtIncoiceNo = new DataTable();
                    if (ClsCommon.TaxWithoutTax == "Yes")
                    {
                        dtIncoiceNo = new BALInvoiceMaster().CASelectMaxTax("CreditMemo");
                    }
                    else
                    {
                        dtIncoiceNo = new BALInvoiceMaster().CASelectMax("CreditMemo");
                    }
                    if (dtIncoiceNo.Rows.Count > 0)
                    {
                        int refNumber = Convert.ToInt32(dtIncoiceNo.Rows[0]["RefNumber"].ToString());
                        if (ClsCommon.TaxWithoutTax == "Yes")
                        {
                            //if (refNumber == 9000000 || refNumber == 0)
                            //{
                            //    txtInvoiceNo.Text = "9000000CM";
                            //    ClsCommon.WriteErrorLogs("Creditmemo 4065 txtInvoiceNo.Text:-" + txtInvoiceNo.Text);

                            //}
                            //else
                            //{
                            txtInvoiceNo.Text = "CN-" + (refNumber + 1).ToString();
                            //    ClsCommon.WriteErrorLogs("Creditmemo 4071 txtInvoiceNo.Text:-" + txtInvoiceNo.Text);

                            //}
                        }
                        else
                        {
                            //if (refNumber == 8000000 || refNumber == 0)
                            //{
                            //    txtInvoiceNo.Text = "8000000CM";
                            //    ClsCommon.WriteErrorLogs("Creditmemo 4080 txtInvoiceNo.Text:-" + txtInvoiceNo.Text);

                            //}
                            //else
                            //{
                            txtInvoiceNo.Text = "CN-" + (refNumber + 1).ToString();
                            //    ClsCommon.WriteErrorLogs("Creditmemo 4087 txtInvoiceNo.Text:-" + txtInvoiceNo.Text);
                            //}
                        }
                    }


                    //DataTable dtIncoiceNo = new BALInvoiceMaster().SelectByRefNumber(new BOLInvoiceMaster() { RefNumber = txtInvoiceNo.Text });
                    //if (dtIncoiceNo.Rows.Count > 0)
                    //{
                    //    if (dtIncoiceNo.Rows[0]["RefNumber"].ToString() != "")
                    //    {
                    //        Random rnd = new Random();
                    //        int num = Convert.ToInt32(dtIncoiceNo.Rows[0]["RefNumber"].ToString());
                    //        num = rnd.Next(num, num + 5);
                    //        txtInvoiceNo.Text = num.ToString();
                    //    }
                    //}
                }

                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :btnNewInvoice_Click. Message:" + ex.Message);
                MessageBox.Show(ex.Message);
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
                contextMenuStrip1.Items.Clear();
                contextMenuStrip1.Items.Add("Save CreditMemo");
                //contextMenuStrip1.Items.Add("Save AS PDF");
                contextMenuStrip1.Show(btnSave, new Point(0, btnSave.Height));
                contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenuStrip1_btnSaveClicked);
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :btnSave_Click. Message:" + ex.Message);
                MessageBox.Show(ex.Message);
            }

        }
        private void contextMenuStrip1_btnSaveClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem.Text == "Save CreditMemo")
                {
                    if (ClsCommon.FunctionVisibility("CreditMemoInsert", "CustomerCenter"))
                    {
                        string InvID = "";
                        if (SaveData(ref InvID))
                        {
                            FrmEmailTemplateList obj = new FrmEmailTemplateList();
                            DataTable dtCus = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                            if (dtCus.Rows.Count > 0)
                            {

                                DataTable dtInv1 = new BALCreditMemo().SelectForPrint(new BOLCreditMemo() { ID = Convert.ToInt32(InvID) });
                                if (dtInv1.Rows.Count > 0)
                                {
                                    DataTable dtInvDetail = new BALCreditMemoDetails().SelectByID(new BOLCreditMemoDetails() { InvoiceID = Convert.ToInt32(InvID) });

                                    dtInv1.Columns.Add("BillAddr", typeof(string));
                                    dtInv1.Columns.Add("ShipAddr", typeof(string));

                                    #region BillAdd
                                    if (dtCus.Rows[0]["Address1"].ToString() != "")
                                        BillAddress = dtCus.Rows[0]["Address1"].ToString();
                                    if (dtCus.Rows[0]["Address2"].ToString() != "")
                                        BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["Address2"].ToString();
                                    if (dtCus.Rows[0]["Address3"].ToString() != "")
                                        BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["Address3"].ToString();

                                    if (dtCus.Rows[0]["City"].ToString() != "" && dtCus.Rows[0]["State"].ToString() != "")
                                        BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["City"].ToString() + "," + dtCus.Rows[0]["State"].ToString();
                                    else if (dtCus.Rows[0]["City"].ToString() != "" && dtCus.Rows[0]["State"].ToString() == "")
                                        BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["City"].ToString();
                                    else if (dtCus.Rows[0]["City"].ToString() == "" && dtCus.Rows[0]["State"].ToString() != "")
                                        BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["State"].ToString();

                                    if (dtCus.Rows[0]["PostalCode"].ToString() != "" && dtCus.Rows[0]["Country"].ToString() != "")
                                        BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["PostalCode"].ToString() + "," + dtCus.Rows[0]["Country"].ToString();
                                    else if (dtCus.Rows[0]["Country"].ToString() != "" && dtCus.Rows[0]["PostalCode"].ToString() == "")
                                        BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["Country"].ToString();
                                    else if (dtCus.Rows[0]["Country"].ToString() == "" && dtCus.Rows[0]["PostalCode"].ToString() != "")
                                        BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["PostalCode"].ToString();
                                    #endregion

                                    #region ShipAdd
                                    if (dtInv1.Rows[0]["ShipAdd1"].ToString() != "")
                                        ShipAddress = dtInv1.Rows[0]["ShipAdd1"].ToString();
                                    if (dtInv1.Rows[0]["ShipAdd2"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipAdd2"].ToString();
                                    if (dtInv1.Rows[0]["ShipAdd3"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipAdd3"].ToString();

                                    if (dtInv1.Rows[0]["ShipCity"].ToString() != "" && dtInv1.Rows[0]["ShipState"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipCity"].ToString() + "," + dtInv1.Rows[0]["ShipState"].ToString();
                                    else if (dtInv1.Rows[0]["ShipCity"].ToString() != "" && dtInv1.Rows[0]["ShipState"].ToString() == "")
                                        ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipCity"].ToString();
                                    else if (dtInv1.Rows[0]["ShipCity"].ToString() == "" && dtInv1.Rows[0]["ShipState"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipState"].ToString();

                                    if (dtInv1.Rows[0]["ShipPostalCode"].ToString() != "" && dtInv1.Rows[0]["ShipCountry"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipPostalCode"].ToString() + "," + dtInv1.Rows[0]["ShipCountry"].ToString();
                                    else if (dtInv1.Rows[0]["ShipCountry"].ToString() != "" && dtInv1.Rows[0]["ShipPostalCode"].ToString() == "")
                                        ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipCountry"].ToString();
                                    else if (dtInv1.Rows[0]["ShipCountry"].ToString() == "" && dtInv1.Rows[0]["ShipPostalCode"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipPostalCode"].ToString();

                                    #endregion

                                    dtInv1.Rows[0]["BillAddr"] = BillAddress.Replace("\r\n\r\n", "\r\n");
                                    dtInv1.Rows[0]["ShipAddr"] = ShipAddress.Replace("\r\n\r\n", "\r\n");
                                    BillAddress = ""; ShipAddress = "";

                                    rptPrintReport cryRpt = new rptPrintReport();
                                    cryRpt.Database.Tables[0].SetDataSource(dtInv1);
                                    cryRpt.Database.Tables[1].SetDataSource(dtInvDetail);
                                    //cryRpt.Subreports[0].SetDataSource(dtInvDetail);
                                    crystalReportViewer1.ReportSource = cryRpt;
                                    cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + @"\PrintReport\" + dtInv1.Rows[0]["RefNumber"].ToString() + "_" + dtInv1.Rows[0]["CustomerID"].ToString() + ".pdf");



                                    if (Mode == "insert")
                                        obj.EmialLoadData("Invoice Create", dtCus.Rows[0]["FullName"].ToString(), dtCus.Rows[0]["FirstName"].ToString(), dtCus.Rows[0]["LastName"].ToString(), txtInvoiceNo.Text, Convert.ToDecimal(lblSubTotal.Text), dtCus.Rows[0]["CompanyName"].ToString(), dtpInvoiceDate.Value.ToShortDateString(), dtpShipDate.Value.ToShortDateString(), dtpDuedate.Value.ToShortDateString(), dtCus.Rows[0]["Email"].ToString(), Application.StartupPath + @"\PrintReport\" + dtInv1.Rows[0]["RefNumber"].ToString() + "_" + dtInv1.Rows[0]["CustomerID"].ToString() + ".pdf", dtCus.Rows[0]["ID"].ToString());
                                    else
                                        obj.EmialLoadData("Invoice Edit", dtCus.Rows[0]["FullName"].ToString(), dtCus.Rows[0]["FirstName"].ToString(), dtCus.Rows[0]["LastName"].ToString(), txtInvoiceNo.Text, Convert.ToDecimal(lblSubTotal.Text), dtCus.Rows[0]["CompanyName"].ToString(), dtpInvoiceDate.Value.ToShortDateString(), dtpShipDate.Value.ToShortDateString(), dtpDuedate.Value.ToShortDateString(), dtCus.Rows[0]["Email"].ToString(), Application.StartupPath + @"\PrintReport\" + dtInv1.Rows[0]["RefNumber"].ToString() + "_" + dtInv1.Rows[0]["CustomerID"].ToString() + ".pdf", dtCus.Rows[0]["ID"].ToString());
                                }
                            }
                            obj.ShowDialog();

                            ClsCommon.ObjCustomerCenter.LoadFunction();
                            Clear();
                            this.Close();
                            Mode = "insert";
                            InvoiceNumber(ClsCommon.TaxWithoutTax);
                        }
                    }
                    else
                        MessageBox.Show("You can not access");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :contextMenuStrip1_btnSaveClicked. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("CreditMemoDelete", "CustomerCenter"))
                {
                    DialogResult result = MessageBox.Show("Are you sure to delete this record?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (txtID.Text != "")
                        {
                            for (int i = 0; i < dgvInvoice1.Rows.Count; i++)
                            {
                                int ItemID = Convert.ToInt32(dgvInvoice1.Rows[i].Cells["ID"].Value.ToString());
                                dt1 = new BALItemMaster().SelectByID(new BOLItemMaster() { ID = Convert.ToInt32(ItemID) });
                                if (dt1.Rows.Count > 0)
                                {
                                    decimal QtyOnHand = Convert.ToDecimal(dgvInvoice1.CurrentRow.Cells["Qty"].Value) + Convert.ToDecimal(dt1.Rows[0]["QtyOnHand"].ToString());
                                    objBOLItem = new BOLItemMaster();
                                    objBOLItem.ID = ItemID;
                                    objBOLItem.QtyOnHand = QtyOnHand;
                                    objBALItem.UpdateQtyOnHand(objBOLItem);
                                }

                            }

                            BOLHistory.InvoiceID = Convert.ToInt32(txtID.Text);
                            objBOLInvoice.ID = Convert.ToInt32(txtID.Text);
                            objBOLInvDetails.InvoiceID = Convert.ToInt32(txtID.Text);
                            objBOLItemSale.InvoiceID = Convert.ToInt32(txtID.Text);
                            objBALInvoice.Delete(objBOLInvoice);
                            objBALInvDetails.Delete(objBOLInvDetails);
                            objBALItemSale.Delete(objBOLItemSale);
                            //objBOLCusReq.InvoiceNumber = txtInvoiceNo.Text;
                            //objBALCusReq.Delete(objBOLCusReq);
                            BALHistory.Delete(BOLHistory);

                            MessageBox.Show("Record delete successfully");

                            //CustomerBalance Update
                            DataTable dtCusBalance = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                            if (dtCusBalance.Rows.Count == 1)
                            {
                                TotalBalance = 0;
                                if (dtCusBalance.Rows[0]["TotalBalance"].ToString() != null && dtCusBalance.Rows[0]["TotalBalance"].ToString() != "")
                                    TotalBalance = Convert.ToDecimal(dtCusBalance.Rows[0]["TotalBalance"].ToString()) + Convert.ToDecimal(lblSubTotal.Text);
                                objBOLCustomer.ID = Convert.ToInt32(cmbCustomer.SelectedValue);
                                objBOLCustomer.TotalBalance = TotalBalance;
                                objBALCustomer.UpdateCustomerBalance(objBOLCustomer);
                            }
                            Clear();
                            Mode = "insert";
                            InvoiceNumber(ClsCommon.TaxWithoutTax);
                            ClsCommon.ObjCustomerCenter.LoadFunction();
                            LoadTable();
                        }

                    }
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :btnDelete_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void cmbCustomer_Leave(object sender, EventArgs e)
        {
            Boolean ISCustomerValid = false;
            try
            {
                if (cmbCustomer.SelectedIndex != 0)
                {
                Top:
                    if (cmbCustomer.SelectedValue == null || string.IsNullOrWhiteSpace(cmbCustomer.Text))
                    {
                        DialogResult result = MessageBox.Show("Are You Sure Want to Create a New Customer?", "Select Action", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //if (cmbCustomer.Text == "" || cmbCustomer.SelectedValue == null)
                            {
                                string customerName = cmbCustomer.Text;
                                ClsCommon.ObjCustomerMaster.CustomerName = customerName;
                                ClsCommon.ObjCustomerMaster.CustomerNameUpdated += CustomerNameUpdated;
                                ClsCommon.ObjCustomerMaster.ShowDialog();
                                goto Top;
                            }
                            //else
                            //{
                            //    MessageBox.Show("Please enter a valid Customer name.");
                            //}
                        }
                        else
                        {
                            ISCustomerValid = false;
                            //MessageBox.Show("Please Enter Item");
                            cmbCustomer.SelectedIndex = 0;
                            cmbCustomer.Focus();
                        }
                    }
                    else if (cmbCustomer.SelectedIndex <= 0)
                    {
                        //ISItemValid = false;
                        MessageBox.Show("Please select Customer first..!!");
                        cmbCustomer.SelectedIndex = 0;
                        cmbCustomer.Focus();

                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :CheckValidationForItem. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTable();
                InvoiceNumber(ClsCommon.TaxWithoutTax);
                if (cmbCustomer.SelectedIndex != 0 && cmbCustomer.SelectedIndex != -1)
                {
                    CustomerDependTax(dtLoadData);

                    txtBillAddress.Text = "";
                    cmbShipAddress.DataSource = null;
                    txtShipAddress.Text = "";

                    LoadAddressDetails();
                    ShippingMethod();
                    Display();
                    LoadTerms();

                    DataTable dtAssign = bALAssignPriceTier.SelectByCustomerAndID(Convert.ToInt32(cmbCustomer.SelectedValue), ClsCommon.UserID);
                    if (dtAssign.Rows.Count > 0)
                    {
                        cmbPrice.SelectedText = "";
                        cmbPrice.Text = dtAssign.Rows[0]["PriceTier"].ToString();
                        //Hiren
                        if (cmbPrice.Text == "")
                        {
                            cmbPrice.SelectedIndex = 0;
                        }
                    }

                    foreach (DataGridViewRow row in dgvInvoice1.Rows)
                    {
                        if (row.Cells["ITEM"].Value != null)
                        {
                            string itemName = row.Cells["ITEM"].Value.ToString().ToLower();

                            DataGridViewComboBoxCell cmbTaxType = new DataGridViewComboBoxCell();

                            string tax = row.Cells["TaxCode"].Value.ToString();

                            if (!string.IsNullOrEmpty(tax))
                            {
                                if (tax == "Tax")
                                {
                                    cmbTaxType.Items.Add("Tax");
                                    cmbTaxType.Items.Add("Non");
                                    cmbTaxType.Value = "Tax";
                                }
                                else
                                {
                                    cmbTaxType.Items.Add("Non");
                                    cmbTaxType.Items.Add("Tax");
                                    cmbTaxType.Value = "Non";
                                }

                                if (row.Cells.Count > 18)
                                {
                                    row.Cells[18] = cmbTaxType;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :cmbCustomer_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void LoadTerms()
        {
            try
            {
                if (Mode == "insert")
                {
                    if (cmbCustomer.SelectedIndex > 0)
                    {
                        DataTable dtCus = new DataTable();
                        DataTable dt = new DataTable();
                        dt = objBALInvoice.SelectLastCusInv(Convert.ToInt32(cmbCustomer.SelectedValue));
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["TermsID"].ToString() != "" && dt.Rows[0]["TermsID"].ToString() != "0")
                            {
                                cmbTerms.SelectedValue = dt.Rows[0]["TermsID"].ToString();
                            }
                            else
                            {
                                dtCus = objBALCustomer.SelectByTerms(Convert.ToInt32(cmbCustomer.SelectedValue));
                                if (dtCus.Rows.Count > 0)
                                {
                                    if (dtCus.Rows[0]["TermsID"].ToString() != "" && dtCus.Rows[0]["TermsID"].ToString() != "0")
                                    {
                                        cmbTerms.SelectedValue = dtCus.Rows[0]["TermsID"].ToString();
                                    }
                                }
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :LoadTerms. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        // Last Three ShippingMethod
        private void ShippingMethod()
        {
            try
            {
                DataTable dtShipping = new BALCreditMemo().SelectLastThreeShippingMethod(new BOLCreditMemo() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                if (dtShipping.Rows.Count > 0)
                {
                    int j = 0;
                    dgvShippingMethod.Rows.Clear();
                    for (int i = 0; i < dtShipping.Rows.Count; i++)
                    {
                        dgvShippingMethod.Rows.Add();
                        dgvShippingMethod.Rows[j].Cells[0].Value = dtShipping.Rows[i]["RefNumber"].ToString();
                        dgvShippingMethod.Rows[j].Cells[1].Value = dtShipping.Rows[i]["ShipMethod"].ToString();
                        j++;
                    }
                }
                else
                {
                    dgvShippingMethod.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :ShippingMethod. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        //Search Invoices
        private void btnFindInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                ClsCommon.ObjSearchInvoices.LoadFunction();
                ClsCommon.ObjSearchInvoices.Show();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFindInvoices,Function :btnFindInvoice_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void FrmInvoiceMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsClose == false)
            {
                //btnSaveandClose_Click(sender, e);
                Clear();
                ClsCommon.ObjCreditMemo.Hide();
                ClsCommon.ObjCreditMemo.EditableField();
                ClsCommon.ObjCreditMemo.Parent = null;
                ClsCommon.ObjCreditMemo.Mode = "insert";
                if (cmbPrice.SelectedIndex != -1)
                {
                    cmbPrice.SelectedIndex = 0;
                }
                e.Cancel = true;
                txtID.Text = "";
            }
            else
            {
                switch (e.CloseReason)
                {
                    case CloseReason.UserClosing:
                        e.Cancel = true;
                        break;
                }
                MessageBox.Show("Please Click On Button Save&close");
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                contextMenuStrip1 = new ContextMenuStrip();
                contextMenuStrip1.Items.Clear();
                contextMenuStrip1.Items.Add("Preview");
                contextMenuStrip1.Items.Add("Print");
                contextMenuStrip1.Show(btnPrint, new Point(0, btnPrint.Height));
                contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenuStrip1_btnPrintClicked);

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFindInvoices,Function :btnPrint_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        private void contextMenuStrip1_btnPrintClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("CreditMemoPrint", "CustomerCenter"))
                {
                    if (e.ClickedItem.Text == "Preview")
                    {
                        if (txtID.Text != "")
                        {
                            DataTable dtDetail = new DataTable();
                            dtDetail.Columns.Add("Quantity", typeof(decimal));
                            dtDetail.Columns.Add("ItemCode", typeof(string));
                            dtDetail.Columns.Add("Description", typeof(string));
                            dtDetail.Columns.Add("PriceEach", typeof(string));
                            dtDetail.Columns.Add("Amount", typeof(decimal));
                            //Hiren
                            dtDetail.Columns.Add("WebPrice", typeof(decimal));

                            foreach (DataGridViewRow dr in dgvInvoice1.Rows)
                            {
                                if (dr.Cells["Item"].Value != null)
                                {
                                    DataRow dr1 = dtDetail.NewRow();
                                    dr1["Quantity"] = dr.Cells["Qty"].Value;
                                    dr1["ItemCode"] = dr.Cells["Item"].Value;
                                    dr1["Description"] = dr.Cells["Description"].Value;
                                    if (dr.Cells["Rate"].Value == null)
                                        dr1["PriceEach"] = "";
                                    else
                                        dr1["PriceEach"] = dr.Cells["Rate"].Value;
                                    dr1["Amount"] = dr.Cells["Amount"].Value;
                                    dr1["WebPrice"] = dr.Cells["WebPrice"].Value;
                                    dtDetail.Rows.Add(dr1);
                                }
                            }

                            ClsCommon.INVID = Convert.ToInt32(txtID.Text);

                            rptInvoiceReport cryRptInvoiceReport = new rptInvoiceReport();
                            cryRptInvoiceReport.SetDataSource(dtDetail);
                            cryRptInvoiceReport.SetParameterValue("TxnDate", dtpInvoiceDate.Value);
                            cryRptInvoiceReport.SetParameterValue("InvoiceNo", txtInvoiceNo.Text);
                            cryRptInvoiceReport.SetParameterValue("PONumber", txtPONumber.Text);
                            cryRptInvoiceReport.SetParameterValue("Terms", cmbTerms.SelectedIndex == 0 ? "" : cmbTerms.Text);
                            cryRptInvoiceReport.SetParameterValue("Rep", cmbSalesRep.SelectedIndex == 0 ? "" : cmbSalesRep.Text);
                            cryRptInvoiceReport.SetParameterValue("ShipDate", dtpShipDate.Value);
                            cryRptInvoiceReport.SetParameterValue("Via", cmbShippingMethod.SelectedIndex == 0 ? "" : cmbSalesRep.Text);
                            cryRptInvoiceReport.SetParameterValue("CustomerName", cmbCustomer.Text);
                            cryRptInvoiceReport.SetParameterValue("BillAddress", txtBillAddress.Text);
                            cryRptInvoiceReport.SetParameterValue("ShipAddress", txtShipAddress.Text);
                            cryRptInvoiceReport.SetParameterValue("Memo", txtMemo.Text);

                            //princy

                            cryRptInvoiceReport.SetParameterValue("CustomerMessage", cmbMsg.SelectedIndex == 0 ? "" : cmbMsg.Text);
                            cryRptInvoiceReport.SetParameterValue("AppliedAmount", lblPaymentApplied.Text);
                            cryRptInvoiceReport.SetParameterValue("BalanceDue", lblBalanceDue.Text);
                            //
                            cryRptInvoiceReport.SetParameterValue("TagName", "Credit Memo");
                            cryRptInvoiceReport.SetParameterValue("NumberName", "CreditMemo #");
                            cryRptInvoiceReport.SetParameterValue("TaxAmount", lblTaxAmount.Text);
                            cryRptInvoiceReport.SetParameterValue("AppliedAmount", lblPaymentApplied.Text);
                            cryRptInvoiceReport.SetParameterValue("BalanceDue", lblBalanceDue.Text);
                            cryRptInvoiceReport.SetParameterValue("TaxPercent", lblTaxPercentage.Text.Replace("(", "").Replace("%)", ""));
                            if (cmbSalesTax.SelectedIndex != 0)
                            {
                                cryRptInvoiceReport.ReportDefinition.ReportObjects["Text2"].ObjectFormat.EnableSuppress = false;
                                cryRptInvoiceReport.ReportDefinition.ReportObjects["Text12"].ObjectFormat.EnableSuppress = false;
                                cryRptInvoiceReport.SetParameterValue("TaxName", cmbSalesTax.Text);
                            }
                            else
                            {
                                cryRptInvoiceReport.ReportDefinition.ReportObjects["Text2"].ObjectFormat.EnableSuppress = true;
                                cryRptInvoiceReport.ReportDefinition.ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
                                cryRptInvoiceReport.SetParameterValue("TaxName", "");
                            }
                            string customerName = cmbCustomer.Text.Trim();
                            string shippAddress = txtShipAddress.Text.Trim();
                            if (!shippAddress.Contains(customerName))
                            {
                                shippAddress = customerName + Environment.NewLine + shippAddress;
                            }
                            string billAddress = txtBillAddress.Text.Trim();
                            if (!billAddress.Contains(customerName))
                            {
                                billAddress = customerName + Environment.NewLine + billAddress;
                            }
                            cryRptInvoiceReport.SetParameterValue("BillAddress", billAddress);
                            cryRptInvoiceReport.SetParameterValue("ShipAddress", shippAddress);
                            FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                            crViewer.Text = "Invoice Report";
                            crViewer.crystalReportViewer.ReportSource = cryRptInvoiceReport;
                            if (Mode == "update")
                            {
                                crViewer.btnPrint.Visible = true;
                                crViewer.crystalReportViewer.ShowPrintButton = false;
                            }
                            else
                            {
                                crViewer.crystalReportViewer.ShowPrintButton = false;
                            }
                            crViewer.Show();
                        }
                        else
                        {
                            DataTable dtDetail = new DataTable();
                            dtDetail.Columns.Add("Quantity", typeof(decimal));
                            dtDetail.Columns.Add("ItemCode", typeof(string));
                            dtDetail.Columns.Add("Description", typeof(string));
                            dtDetail.Columns.Add("PriceEach", typeof(string));
                            dtDetail.Columns.Add("Amount", typeof(decimal));
                            //Hiren
                            dtDetail.Columns.Add("WebPrice", typeof(decimal));

                            foreach (DataGridViewRow dr in dgvInvoice1.Rows)
                            {
                                if (dr.Cells["Item"].Value != null)
                                {
                                    DataRow dr1 = dtDetail.NewRow();
                                    dr1["Quantity"] = dr.Cells["Qty"].Value;
                                    dr1["ItemCode"] = dr.Cells["Item"].Value;
                                    dr1["Description"] = dr.Cells["Description"].Value;
                                    if (dr.Cells["Rate"].Value == null)
                                        dr1["PriceEach"] = "";
                                    else
                                        dr1["PriceEach"] = dr.Cells["Rate"].Value;
                                    dr1["Amount"] = dr.Cells["Amount"].Value;
                                    dr1["WebPrice"] = dr.Cells["WebPrice"].Value;
                                    dtDetail.Rows.Add(dr1);
                                }
                            }

                            rptInvoiceReport cryRptInvoiceReport = new rptInvoiceReport();
                            cryRptInvoiceReport.SetDataSource(dtDetail);
                            cryRptInvoiceReport.SetParameterValue("TxnDate", dtpInvoiceDate.Value);
                            cryRptInvoiceReport.SetParameterValue("InvoiceNo", txtInvoiceNo.Text);
                            cryRptInvoiceReport.SetParameterValue("PONumber", txtPONumber.Text);
                            cryRptInvoiceReport.SetParameterValue("Terms", cmbTerms.SelectedIndex == 0 ? "" : cmbTerms.Text);
                            cryRptInvoiceReport.SetParameterValue("Rep", cmbSalesRep.SelectedIndex == 0 ? "" : cmbSalesRep.Text);
                            cryRptInvoiceReport.SetParameterValue("ShipDate", dtpShipDate.Value);
                            cryRptInvoiceReport.SetParameterValue("Via", cmbShippingMethod.SelectedIndex == 0 ? "" : cmbSalesRep.Text);
                            cryRptInvoiceReport.SetParameterValue("CustomerName", cmbCustomer.Text);
                            cryRptInvoiceReport.SetParameterValue("BillAddress", txtBillAddress.Text);
                            cryRptInvoiceReport.SetParameterValue("ShipAddress", txtShipAddress.Text);
                            cryRptInvoiceReport.SetParameterValue("Memo", txtMemo.Text);

                            //princy

                            cryRptInvoiceReport.SetParameterValue("CustomerMessage", cmbMsg.SelectedIndex == 0 ? "" : cmbMsg.Text);
                            cryRptInvoiceReport.SetParameterValue("AppliedAmount", lblPaymentApplied.Text);
                            cryRptInvoiceReport.SetParameterValue("BalanceDue", lblBalanceDue.Text);
                            //
                            cryRptInvoiceReport.SetParameterValue("TagName", "Credit Memo");
                            cryRptInvoiceReport.SetParameterValue("NumberName", "CreditMemo #");
                            cryRptInvoiceReport.SetParameterValue("TaxAmount", lblTaxAmount.Text);
                            cryRptInvoiceReport.SetParameterValue("TaxPercent", lblTaxPercentage.Text.Replace("(", "").Replace("%)", ""));
                            if (cmbSalesTax.SelectedIndex != 0)
                            {
                                cryRptInvoiceReport.ReportDefinition.ReportObjects["Text2"].ObjectFormat.EnableSuppress = false;
                                cryRptInvoiceReport.ReportDefinition.ReportObjects["Text12"].ObjectFormat.EnableSuppress = false;
                                cryRptInvoiceReport.SetParameterValue("TaxName", cmbSalesTax.Text);
                            }
                            else
                            {
                                cryRptInvoiceReport.ReportDefinition.ReportObjects["Text2"].ObjectFormat.EnableSuppress = true;
                                cryRptInvoiceReport.ReportDefinition.ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
                                cryRptInvoiceReport.SetParameterValue("TaxName", "");
                            }
                            string customerName = cmbCustomer.Text.Trim();
                            string shippAddress = txtShipAddress.Text.Trim();
                            if (!shippAddress.Contains(customerName))
                            {
                                shippAddress = customerName + Environment.NewLine + shippAddress;
                            }
                            string billAddress = txtBillAddress.Text.Trim();
                            if (!billAddress.Contains(customerName))
                            {
                                billAddress = customerName + Environment.NewLine + billAddress;
                            }
                            cryRptInvoiceReport.SetParameterValue("BillAddress", billAddress);
                            cryRptInvoiceReport.SetParameterValue("ShipAddress", shippAddress);
                            FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                            crViewer.Text = "Invoice Report";
                            crViewer.crystalReportViewer.ReportSource = cryRptInvoiceReport;
                            if (Mode == "update")
                            {
                                crViewer.btnPrint.Visible = true;
                                crViewer.crystalReportViewer.ShowPrintButton = false;
                            }
                            else
                            {
                                crViewer.crystalReportViewer.ShowPrintButton = false;
                            }
                            crViewer.Show();
                        }

                    }
                    else if (e.ClickedItem.Text == "Print")
                    {

                        contextMenuStrip1.Hide();
                        if (txtID.Text != "")
                        {
                            DataTable dtDetail = new DataTable();
                            dtDetail.Columns.Add("Quantity", typeof(decimal));
                            dtDetail.Columns.Add("ItemCode", typeof(string));
                            dtDetail.Columns.Add("Description", typeof(string));
                            dtDetail.Columns.Add("PriceEach", typeof(string));
                            dtDetail.Columns.Add("Amount", typeof(decimal));
                            //Hiren
                            dtDetail.Columns.Add("WebPrice", typeof(decimal));
                            foreach (DataGridViewRow dr in dgvInvoice1.Rows)
                            {
                                if (dr.Cells["Item"].Value != null)
                                {
                                    DataRow dr1 = dtDetail.NewRow();
                                    dr1["Quantity"] = dr.Cells["Qty"].Value;
                                    dr1["ItemCode"] = dr.Cells["Item"].Value;
                                    dr1["Description"] = dr.Cells["Description"].Value;
                                    if (dr.Cells["Rate"].Value == null)
                                        dr1["PriceEach"] = "";
                                    else
                                        dr1["PriceEach"] = dr.Cells["Rate"].Value;
                                    dr1["Amount"] = dr.Cells["Amount"].Value;
                                    //Hiren
                                    dr1["WebPrice"] = dr.Cells["WebPrice"].Value;
                                    dtDetail.Rows.Add(dr1);
                                }
                            }

                            ClsCommon.INVID = Convert.ToInt32(txtID.Text);
                            rptInvoiceReport cryRptInvoiceReport = new rptInvoiceReport();
                            cryRptInvoiceReport.SetDataSource(dtDetail);
                            cryRptInvoiceReport.SetParameterValue("TxnDate", dtpInvoiceDate.Value);
                            cryRptInvoiceReport.SetParameterValue("InvoiceNo", txtInvoiceNo.Text);
                            cryRptInvoiceReport.SetParameterValue("PONumber", txtPONumber.Text);
                            cryRptInvoiceReport.SetParameterValue("Terms", cmbTerms.SelectedIndex == 0 ? "" : cmbTerms.Text);
                            cryRptInvoiceReport.SetParameterValue("Rep", cmbSalesRep.SelectedIndex == 0 ? "" : cmbSalesRep.Text);
                            cryRptInvoiceReport.SetParameterValue("ShipDate", dtpShipDate.Value);
                            cryRptInvoiceReport.SetParameterValue("Via", cmbShippingMethod.SelectedIndex == 0 ? "" : cmbSalesRep.Text);
                            cryRptInvoiceReport.SetParameterValue("CustomerName", cmbCustomer.Text);
                            cryRptInvoiceReport.SetParameterValue("BillAddress", txtBillAddress.Text);
                            cryRptInvoiceReport.SetParameterValue("ShipAddress", txtShipAddress.Text);
                            cryRptInvoiceReport.SetParameterValue("Memo", txtMemo.Text);
                            //princy
                            cryRptInvoiceReport.SetParameterValue("AppliedAmount", lblPaymentApplied.Text);
                            cryRptInvoiceReport.SetParameterValue("BalanceDue", lblBalanceDue.Text);
                            cryRptInvoiceReport.SetParameterValue("TagName", "Credit Memo");
                            cryRptInvoiceReport.SetParameterValue("NumberName", "CreditMemo #");
                            cryRptInvoiceReport.SetParameterValue("CustomerMessage", cmbMsg.SelectedIndex == 0 ? "" : cmbMsg.Text);

                            cryRptInvoiceReport.SetParameterValue("TaxAmount", lblTaxAmount.Text);
                            cryRptInvoiceReport.SetParameterValue("TaxPercent", lblTaxPercentage.Text.Replace("(", "").Replace("%)", ""));
                            if (cmbSalesTax.SelectedIndex != 0)
                            {
                                cryRptInvoiceReport.ReportDefinition.ReportObjects["Text2"].ObjectFormat.EnableSuppress = false;
                                cryRptInvoiceReport.ReportDefinition.ReportObjects["Text12"].ObjectFormat.EnableSuppress = false;
                                cryRptInvoiceReport.SetParameterValue("TaxName", cmbSalesTax.Text);
                            }
                            else
                            {
                                cryRptInvoiceReport.ReportDefinition.ReportObjects["Text2"].ObjectFormat.EnableSuppress = true;
                                cryRptInvoiceReport.ReportDefinition.ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
                                cryRptInvoiceReport.SetParameterValue("TaxName", "");
                            }
                            FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                            crViewer.Text = "Invoice Report";
                            crViewer.crystalReportViewer.ReportSource = cryRptInvoiceReport;
                            if (Mode == "update")
                            {
                                crViewer.btnPrint.Visible = true;
                                crViewer.crystalReportViewer.ShowPrintButton = false;
                            }
                            else
                            {
                                crViewer.crystalReportViewer.ShowPrintButton = false;
                            }
                            crViewer.Visible = false;
                            crViewer.crystalReportViewer.PrintReport();
                            ClsCommon.ObjCreditMemo.InvoicePrintHistory(ClsCommon.INVID);
                            ClsCommon.ObjCreditMemo.PrintSave(ClsCommon.INVID);




                            //IMEI
                            DataTable IMEI = new DataTable();
                            IMEI.Columns.Add("IMEINumber", typeof(string));
                            IMEI.Columns.Add("ITEMName", typeof(string));
                            IMEI.Columns.Add("Reason", typeof(string));
                            IMEI.Columns.Add("GRADING", typeof(string));

                            foreach (DataGridViewRow dr in dgvInvoice1.Rows)
                            {
                                if (dr.Cells["Item"].Value != null)
                                {
                                    string[] str = dr.Cells["IMEINumber"].Value.ToString().Split('\n');

                                    for (int S = 0; S < str.Length; S++)
                                    {
                                        if (str[S].ToString() != "")
                                        {
                                            DataRow dr2 = IMEI.NewRow();
                                            dr2["ITEMName"] = dr.Cells["ITEM"].Value.ToString();
                                            dr2["Reason"] = dr.Cells["CARRIERS"].Value.ToString();
                                            dr2["GRADING"] = dr.Cells["GRADING"].Value.ToString();
                                            dr2["IMEINumber"] = str[S];
                                            IMEI.Rows.Add(dr2);
                                        }
                                    }

                                }
                            }
                            if (IMEI.Rows.Count > 0)
                            {
                                rptIMEIDetails cryRptIMEIReport = new rptIMEIDetails();
                                cryRptIMEIReport.SetDataSource(IMEI);
                                cryRptIMEIReport.SetParameterValue("TxnDate", dtpInvoiceDate.Value);
                                cryRptIMEIReport.SetParameterValue("InvoiceNo", txtInvoiceNo.Text);
                                cryRptIMEIReport.SetParameterValue("PONumber", txtPONumber.Text);
                                cryRptIMEIReport.SetParameterValue("Terms", cmbTerms.SelectedIndex == 0 ? "" : cmbTerms.Text);
                                cryRptIMEIReport.SetParameterValue("Rep", cmbSalesRep.SelectedIndex == 0 ? "" : cmbSalesRep.Text);
                                cryRptIMEIReport.SetParameterValue("ShipDate", dtpShipDate.Value);
                                cryRptIMEIReport.SetParameterValue("Via", cmbShippingMethod.SelectedIndex == 0 ? "" : cmbSalesRep.Text);
                                cryRptIMEIReport.SetParameterValue("CustomerName", cmbCustomer.Text);
                                cryRptIMEIReport.SetParameterValue("BillAddress", txtBillAddress.Text);
                                cryRptIMEIReport.SetParameterValue("ShipAddress", txtShipAddress.Text);
                                cryRptIMEIReport.SetParameterValue("Memo", txtMemo.Text);
                                //PRINCY
                                cryRptIMEIReport.SetParameterValue("AppliedAmount", lblPaymentApplied.Text);
                                cryRptIMEIReport.SetParameterValue("BalanceDue", lblBalanceDue.Text);
                                cryRptIMEIReport.SetParameterValue("TagName", "Credit Memo");
                                cryRptIMEIReport.SetParameterValue("NumberName", "CreditMemo #");
                                FrmCrystalReportViewer crViewer1 = new FrmCrystalReportViewer();
                                crViewer1.Text = "Invoice Report";
                                crViewer1.crystalReportViewer.ReportSource = cryRptIMEIReport;
                                crViewer1.btnPrint.Visible = true;
                                crViewer1.crystalReportViewer.ShowPrintButton = false;
                                crViewer1.Visible = false;
                                crViewer1.crystalReportViewer.PrintReport();
                            }
                            ////

                        }

                    }
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :contextMenuStrip1_btnPrintClicked. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void dgvInvoiceTemp_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        private void dgvInvoiceTemp_KeyPress(object sender, KeyPressEventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :dgvInvoiceTemp_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        //Invoice QuickReport
        private void btnQuickReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("CreditMemoQuickReport", "CustomerCenter"))
                {
                    if (cmbCustomer.SelectedIndex > 0)
                    {
                        FrmCustomerQuickReport objCustomer = new FrmCustomerQuickReport();
                        objCustomer.CustomerID = cmbCustomer.SelectedValue.ToString();
                        objCustomer.Show();
                    }
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster, Function :btnQuickReport_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        //Transaction History Report
        private void btnTransactionHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("CreditMemoTranReport", "CustomerCenter"))
                {
                    if (txtID.Text != "")
                    {
                        DataTable dtPayment = new BALCreditMemo().SelectPaidAndPartialPaidInvoice(new BOLCreditMemo() { ID = Convert.ToInt32(txtID.Text) });
                        if (dtPayment.Rows.Count > 0)
                        {
                            FrmTransactionHistory objTransaction = new FrmTransactionHistory();
                            objTransaction.InvoiceID = txtID.Text;
                            objTransaction.Show();
                        }
                        else
                            MessageBox.Show("There are no payments for this invoice.", "Warning");
                    }
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster, Function :btnTransactionHistory_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void txtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        public void InvoicePrintHistory(int ID)
        {
            try
            {
                if (txtID.Text != "")
                {
                    objBOLInvPrint.CreditMemoID = Convert.ToInt32(txtID.Text);
                    objBOLInvPrint.SalesRepID = ClsCommon.UserID;
                    objBOLInvPrint.CreatedTime = DateTime.Now;
                    objBALInvPrint.Insert(objBOLInvPrint);
                    ClsCommon.objTodayInvoice.LoadFunction();
                }
                else if (ID != 0)
                {
                    objBOLInvPrint.CreditMemoID = Convert.ToInt32(ID);
                    objBOLInvPrint.SalesRepID = ClsCommon.UserID;
                    objBOLInvPrint.CreatedTime = DateTime.Now;
                    objBALInvPrint.Insert(objBOLInvPrint);
                    ClsCommon.objTodayInvoice.LoadFunction();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCrystalreportViewer,Function :InvoicePrintHistory. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        //Approve InvoiceRequest
        private void btnApprove_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    string InvID = "";
            //    if (SaveData(ref InvID))
            //    {
            //        Inv = InvID;

            //        DataTable dtCus = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
            //        if (dtCus.Rows.Count > 0)
            //        {
            //            DataTable dtInv1 = new BALInvoiceMaster().SelectForPrint(new BOLInvoiceMaster() { ID = Convert.ToInt32(InvID) });
            //            if (dtInv1.Rows.Count > 0)
            //            {
            //                DataTable dtInvDetail = new BALInvoiceDetails().SelectByID(new BOLInvoiceDetails() { InvoiceID = Convert.ToInt32(InvID) });

            //                dtInv1.Columns.Add("BillAddr", typeof(string));
            //                dtInv1.Columns.Add("ShipAddr", typeof(string));

            //                #region BillAdd
            //                if (dtCus.Rows[0]["Address1"].ToString() != "")
            //                    BillAddress = dtCus.Rows[0]["Address1"].ToString();
            //                if (dtCus.Rows[0]["Address2"].ToString() != "")
            //                    BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["Address2"].ToString();
            //                if (dtCus.Rows[0]["Address3"].ToString() != "")
            //                    BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["Address3"].ToString();

            //                if (dtCus.Rows[0]["City"].ToString() != "" && dtCus.Rows[0]["State"].ToString() != "")
            //                    BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["City"].ToString() + "," + dtCus.Rows[0]["State"].ToString();
            //                else if (dtCus.Rows[0]["City"].ToString() != "" && dtCus.Rows[0]["State"].ToString() == "")
            //                    BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["City"].ToString();
            //                else if (dtCus.Rows[0]["City"].ToString() == "" && dtCus.Rows[0]["State"].ToString() != "")
            //                    BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["State"].ToString();

            //                if (dtCus.Rows[0]["PostalCode"].ToString() != "" && dtCus.Rows[0]["Country"].ToString() != "")
            //                    BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["PostalCode"].ToString() + "," + dtCus.Rows[0]["Country"].ToString();
            //                else if (dtCus.Rows[0]["Country"].ToString() != "" && dtCus.Rows[0]["PostalCode"].ToString() == "")
            //                    BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["Country"].ToString();
            //                else if (dtCus.Rows[0]["Country"].ToString() == "" && dtCus.Rows[0]["PostalCode"].ToString() != "")
            //                    BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["PostalCode"].ToString();
            //                #endregion

            //                #region ShipAdd
            //                if (dtInv1.Rows[0]["ShipAdd1"].ToString() != "")
            //                    ShipAddress = dtInv1.Rows[0]["ShipAdd1"].ToString();
            //                if (dtInv1.Rows[0]["ShipAdd2"].ToString() != "")
            //                    ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipAdd2"].ToString();
            //                if (dtInv1.Rows[0]["ShipAdd3"].ToString() != "")
            //                    ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipAdd3"].ToString();

            //                if (dtInv1.Rows[0]["ShipCity"].ToString() != "" && dtInv1.Rows[0]["ShipState"].ToString() != "")
            //                    ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipCity"].ToString() + "," + dtInv1.Rows[0]["ShipState"].ToString();
            //                else if (dtInv1.Rows[0]["ShipCity"].ToString() != "" && dtInv1.Rows[0]["ShipState"].ToString() == "")
            //                    ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipCity"].ToString();
            //                else if (dtInv1.Rows[0]["ShipCity"].ToString() == "" && dtInv1.Rows[0]["ShipState"].ToString() != "")
            //                    ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipState"].ToString();

            //                if (dtInv1.Rows[0]["ShipPostalCode"].ToString() != "" && dtInv1.Rows[0]["ShipCountry"].ToString() != "")
            //                    ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipPostalCode"].ToString() + "," + dtInv1.Rows[0]["ShipCountry"].ToString();
            //                else if (dtInv1.Rows[0]["ShipCountry"].ToString() != "" && dtInv1.Rows[0]["ShipPostalCode"].ToString() == "")
            //                    ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipCountry"].ToString();
            //                else if (dtInv1.Rows[0]["ShipCountry"].ToString() == "" && dtInv1.Rows[0]["ShipPostalCode"].ToString() != "")
            //                    ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipPostalCode"].ToString();

            //                #endregion

            //                dtInv1.Rows[0]["BillAddr"] = BillAddress.Replace("\r\n\r\n", "\r\n");
            //                dtInv1.Rows[0]["ShipAddr"] = ShipAddress.Replace("\r\n\r\n", "\r\n");
            //                BillAddress = ""; ShipAddress = "";

            //                DataTable dtNewdtInvDetail = new DataTable();
            //                if (dtInvDetail.Rows.Count > 0)
            //                {
            //                    DataRow[] drcheck = dtInvDetail.Select("[ItemFullName]='shipping'");
            //                    if (drcheck.Length > 0)
            //                    {
            //                        DataRow[] drcheck1 = dtInvDetail.Select("[ItemFullName]<>'shipping'");
            //                        if (drcheck1.Length > 0)
            //                        {
            //                            DataTable dtTemp1 = drcheck1.CopyToDataTable();
            //                            dtNewdtInvDetail = dtTemp1.Copy();
            //                        }
            //                        DataTable dtTemp2 = drcheck.CopyToDataTable();
            //                        dtNewdtInvDetail.Merge(dtTemp2);
            //                    }
            //                    else
            //                    {
            //                        dtNewdtInvDetail = dtInvDetail.Copy();
            //                    }
            //                }
            //                try
            //                {
            //                    rptPrintReport cryRpt = new rptPrintReport();
            //                    cryRpt.Database.Tables[0].SetDataSource(dtInv1);
            //                    cryRpt.Database.Tables[1].SetDataSource(dtNewdtInvDetail);
            //                    //cryRpt.Subreports[0].SetDataSource(dtInvDetail);
            //                    crystalReportViewer1.ReportSource = cryRpt;
            //                    cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + @"\PrintReport\" + dtInv1.Rows[0]["RefNumber"].ToString() + "_" + dtInv1.Rows[0]["CustomerID"].ToString() + ".pdf");
            //                }
            //                catch (Exception ex)
            //                {
            //                    ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :btnSaveandClose_Click. Crystal Report Export Message:" + ex.Message);
            //                }

            //            }
            //        }
            //        //obj.ShowDialog();
            //        //dgvCustomerList.Rows[CustRowIndex].Selected = true;
            //        ClsCommon.ObjCustomerCenter.LoadFunc();
            //        ClsCommon.ObjCustomerCenter.LoadCustomerData(Convert.ToInt32(cmbCustomer.SelectedValue.ToString()));
            //        Clear();
            //        this.Close();
            //        Mode = "insert";
            //        DisplayRequest();
            //        ClsCommon.objTodayInvoice.LoadInvoice();
            //        //ClsCommon.ObjCustomerCenter.loadData();

            //    }
            //}
            //catch (Exception ex)
            //{
            //    ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :btnSaveandClose_Click. Message:" + ex.Message);
            //    MessageBox.Show(ex.Message);
            //}
            try
            {
                if (ClsCommon.FunctionVisibility("Approve", "AdminRequestList"))
                {
                    FrmAdminApprove obj = new FrmAdminApprove();
                    obj.RequestID = RequestID.ToString();
                    obj.Show();
                    ClsCommon.ObjAdminRequestList.DateWiseInvoiceLoad();
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster, Function :btnApprove_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        //Reject InvoiceRequest
        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                BALCustomerRequest objBALCus = new BALCustomerRequest();
                BOLCustomerRequest objBOLCus = new BOLCustomerRequest();
                if (ClsCommon.FunctionVisibility("Reject", "AdminRequestList"))
                {
                    objBOLCus.ID = RequestID;
                    objBOLCus.Status = 2;
                    objBOLCus.IsActive = 0;
                    objBOLCus.ModifiedTime = DateTime.Now;
                    objBOLCus.ModifiedID = ClsCommon.UserID;
                    objBALCus.UpdateRejectStatus(objBOLCus);
                    ClsCommon.ObjAdminRequestList.DateWiseInvoiceLoad();
                    this.Close();
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster, Function :btnReject_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void pnlgrid_Paint(object sender, PaintEventArgs e)
        {

        }
        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                txtQty.ReadOnly = false;
                if (cmbItem.SelectedIndex > 0)
                {
                    if (cmbItem.SelectedIndex == 1)
                    //if (cmbItem.SelectedValue.ToString() == "-1")
                    {
                        //princy
                        cmbItem.SelectedIndex = 0;
                        //cmbItem.SelectedValue = 0;
                        //
                        ClsCommon.ObjItemMaster.Mode = "insert";
                        ClsCommon.ObjItemMaster.Text = "New Item";
                        ClsCommon.ObjItemMaster.ItemNameUpdated += ItemNameUpdated;
                        ClsCommon.ObjItemMaster.ShowDialog();

                        ClsCommon.ObjItemMaster.ItemNameUpdated -= ItemNameUpdated;
                    }
                    DataTable dt = new BALItemMaster().Select(new BOLItemMaster() { });
                    if (dt.Rows.Count > 0)
                    {
                        DataRow[] row = dt.Select("FullName='" + cmbItem.Text.ToString().Replace("'", "''") + "'");
                        if (row.Length == 1)
                        {
                            foreach (DataRow dr in row)
                            {
                                //Regular Item add                            
                                txtDesc.Text = dr["SalesDesc"].ToString();
                                //txtQty.Text = "1";

                                if (cmbPrice.Text.ToString() == "Cost")
                                {
                                    if (dr["PurchaseCost"].ToString() != "")
                                    {
                                        txtRate.Text = dr["PurchaseCost"].ToString();
                                    }
                                    else
                                    {
                                        txtRate.Text = "0.00";
                                    }
                                }

                                else if (cmbPrice.Text.ToString() == "TierGF")
                                {
                                    if (dr["PriceTier1"].ToString() != "")
                                    {
                                        txtRate.Text = dr["PriceTier1"].ToString();
                                    }
                                    else
                                    {
                                        txtRate.Text = "0.00";
                                    }

                                }

                                else if (cmbPrice.Text.ToString() == "TierP4C")
                                {
                                    if (dr["PriceTier2"].ToString() != "")
                                    {
                                        txtRate.Text = dr["PriceTier2"].ToString();
                                    }
                                    else
                                    {
                                        txtRate.Text = "0.00";
                                    }
                                }

                                else if (cmbPrice.Text.ToString() == "TierMS")
                                {
                                    if (dr["PriceTier3"].ToString() != "")
                                    {
                                        txtRate.Text = dr["PriceTier3"].ToString();
                                    }
                                    else
                                    {
                                        txtRate.Text = "0.00";
                                    }
                                }

                                else
                                {
                                    txtRate.Text = "0.00";
                                }

                                if (dr["ItemType"].ToString() == "ItemDiscount")
                                {
                                    txtQty.Text = "1";
                                    txtQty.ReadOnly = true;
                                }
                                else
                                {
                                    txtQty.ReadOnly = false;
                                }
                                if (txtQty.Text != "")
                                {
                                    txtAmount.Text = (Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text)).ToString();
                                }
                                else
                                {
                                    txtAmount.Text = (1 * Convert.ToDecimal(txtRate.Text)).ToString();
                                }
                                txtType.Text = "1";
                                txtItemType.Text = dr["ItemType"].ToString();
                                txtLowestPrice.Text = dr["LowestPrice"].ToString();
                                txtCostPrice.Text = dr["PurchaseCost"].ToString();
                                // Hiren
                                txtWebPrice.Text = dr["WebPrice"].ToString();

                                DataTable dtSale = new BALItemSaleHistory().SelectLastThreeSale(new BOLItemSaleHistory() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), ItemID = Convert.ToInt32(cmbItem.SelectedValue.ToString()) });
                                if (dtSale.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dtSale.Rows.Count; i++)
                                    {
                                        if (i == 0)
                                            txtPrice1.Text = dtSale.Rows[i]["SalePrice"].ToString();
                                        if (i == 1)
                                            txtPrice2.Text = dtSale.Rows[i]["SalePrice"].ToString();
                                        if (i == 2)
                                            txtPrice3.Text = dtSale.Rows[i]["SalePrice"].ToString();
                                    }
                                }
                                else
                                {
                                    txtPrice1.Text = "";
                                    txtPrice2.Text = "";
                                    txtPrice3.Text = "";
                                }

                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :cmbItem_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Amount Calculation
                if (txtQty.Text != "" && txtRate.Text != "")
                {
                    txtAmount.Text = (Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text)).ToString();
                }
                //if ((dgvInvoice.CurrentCell.ColumnIndex == 3 || dgvInvoice.CurrentCell.ColumnIndex == 4))
                //{

                //        if (dgvInvoice.CurrentRow.Cells["Qty"].Value != null && dgvInvoice.CurrentRow.Cells["Rate"].Value != null)
                //            dgvInvoice.CurrentRow.Cells["Amount"].Value = Convert.ToDecimal(dgvInvoice.CurrentRow.Cells["Qty"].Value) * Convert.ToDecimal(dgvInvoice.CurrentRow.Cells["Rate"].Value);
                //        else if (dgvInvoice.CurrentRow.Cells["Qty"].Value != null && dgvInvoice.CurrentRow.Cells["Rate"].Value == null)
                //            dgvInvoice.CurrentRow.Cells["Amount"].Value = "0.00";
                //        else if (dgvInvoice.CurrentRow.Cells["Qty"].Value == null && dgvInvoice.CurrentRow.Cells["Rate"].Value != null)
                //            dgvInvoice.CurrentRow.Cells["Amount"].Value = dgvInvoice.CurrentRow.Cells["Rate"].Value.ToString();
                //        lblTotal.Text = dgvInvoice.CurrentRow.Cells["Amount"].Value.ToString();
                //        lblBalanceDue.Text = dgvInvoice.CurrentRow.Cells["Amount"].Value.ToString();

                //}
                //// TotalAmount
                //Total = 0;
                //foreach (DataGridViewRow row in dgvInvoice.Rows)
                //{
                //    if (row.Cells["Type"].Value != null)
                //    {
                //        if (row.Cells["Type"].Value.ToString() == "1")
                //        {
                //            Total += Convert.ToDecimal(row.Cells["Amount"].Value);
                //            lblTotal.Text = Total.ToString();
                //            lblPaymentApplied.Text = "0.0";
                //            lblBalanceDue.Text = (Convert.ToDecimal(lblTotal.Text) - Convert.ToDecimal(lblPaymentApplied.Text)).ToString();
                //        }
                //    }
                //}

                ////For Paid Invoice Setting...
                //if (txtID.Text != "")
                //{
                //    objBOLInvoice.ID = Convert.ToInt32(txtID.Text);
                //    DataTable dtInv = new BALInvoiceMaster().SelectByID(objBOLInvoice);
                //    if (dtInv.Rows.Count > 0)
                //    {
                //        lblPaymentApplied.Text = dtInv.Rows[0]["AppliedAmount"].ToString();
                //        lblBalanceDue.Text = (Convert.ToDecimal(lblTotal.Text) - Convert.ToDecimal(lblPaymentApplied.Text)).ToString();
                //    }

                //}


            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :txtQty_TextChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtQty.Text != "" && txtRate.Text != "")
                {
                    txtAmount.Text = (Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :txtRate_TextChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :txtQty_KeyPress. Message:" + ex.Message);
            }
        }
        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :txtRate_KeyPress. Message:" + ex.Message);
            }
        }
        public void CheckDate()
        {
            try
            {
                DataTable dtPrint = objPrintBAL.Select();
                if (dtPrint.Rows.Count > 0)
                {
                    if (dtPrint.Rows[0]["Date"].ToString() != "")
                    {
                        DateTime Curr1 = Convert.ToDateTime(dtPrint.Rows[0]["Date"].ToString());
                        if (Curr1.Date != DateTime.Now.Date)
                        {
                            objPrintBOL = new BOLPrintDateMaster();
                            objPrintBOL.ID = Convert.ToInt32(dtPrint.Rows[0]["ID"].ToString());
                            objPrintBOL.Flag = "False";
                            objPrintBAL.UpdateFlag(objPrintBOL);
                        }

                    }
                    else
                    {
                        objPrintBOL = new BOLPrintDateMaster();
                        objPrintBOL.ID = Convert.ToInt32(dtPrint.Rows[0]["ID"].ToString());
                        objPrintBOL.Date = DateTime.Now;
                        objPrintBOL.Flag = "False";
                        objPrintBAL.UpdatePrint(objPrintBOL);
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :CheckDate. Message:" + ex.Message);
            }
        }
        private void UpdateLineDetail(String Mode)
        {
            try
            {

                DataTable dtPrint = objPrintBAL.Select();

                if (dtPrint.Rows.Count > 0)
                {
                    if (dtPrint.Rows[0]["Flag"].ToString() == "True")
                    {

                        objItemLogBOL = new BOLCreditMemoLineItemLog();
                        objBOLInvCount = new BOLCreditMemoPrintCount();
                        DataTable dtCount = new DataTable();
                        dtCount = objBALInvCount.Select(Convert.ToInt32(InvoiceID));
                        if (dtCount.Rows.Count > 0)
                        {
                            int Max = Convert.ToInt32(dtCount.Compute("Max([PrintNo])", string.Empty));
                            objItemLogBOL.EditCount = Max + 1;
                        }
                        else
                        {
                            objItemLogBOL.EditCount = 2;
                        }

                        objItemLogBOL.CreditMemoID = Convert.ToInt32(txtID.Text);
                        objItemLogBOL.ItemID = Convert.ToInt32(cmbItem.SelectedValue);
                        objItemLogBOL.Description = txtDesc.Text;
                        objItemLogBOL.Qty = Convert.ToDecimal(txtQty.Text);
                        objItemLogBOL.PriceEach = Convert.ToDecimal(txtRate.Text);
                        objItemLogBOL.Amount = Convert.ToDecimal(txtAmount.Text);
                        objItemLogBOL.IsPrint = 0;
                        objItemLogBOL.EditMode = Mode;

                        if (Mode == "UPDATE")
                        {
                            objItemLogBOL.OldQty = ClsCommon.OldQty;
                        }

                        objItemLogBAL.Insert(objItemLogBOL);
                        Count = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :UpdateRow. Message:" + ex.Message);
            }
        }
        private void UpdateRow()
        {
            try
            {
                dt1 = new BALItemMaster().SelectByID(new BOLItemMaster() { ID = Convert.ToInt32(cmbItem.SelectedValue) });
                if (txtItemEdit.Text != "")
                {
                    //Update

                    foreach (DataRow dr in dtGridItem.Rows)
                    {
                        if (dr["SrNo"].ToString() == txtItemEdit.Text)
                        {
                            if (txtID.Text != "")
                            {
                                if (cmbItem.Text != dr["ITEM"].ToString() || txtDesc.Text != dr["DESCRIPTION"].ToString() || txtQty.Text != dr["QTY"].ToString() || txtRate.Text != dr["RATE"].ToString())
                                {
                                    UpdateLineDetail("UPDATE");
                                }
                            }


                            dr["ID"] = cmbItem.SelectedValue.ToString();
                            dr["ITEM"] = cmbItem.Text;
                            dr["DESCRIPTION"] = txtDesc.Text;
                            dr["QTY"] = txtQty.Text;
                            if (dt1.Rows[0]["ItemType"].ToString() == "ItemDiscount")
                            {
                                if (!txtRate.Text.Contains("-"))
                                {
                                    dr["RATE"] = "-" + txtRate.Text;
                                    dr["AMOUNT"] = "-" + txtAmount.Text;
                                }
                                else
                                {
                                    dr["RATE"] = txtRate.Text;
                                    dr["AMOUNT"] = txtAmount.Text;
                                }
                            }
                            else
                            {
                                dr["RATE"] = txtRate.Text;
                                dr["AMOUNT"] = txtAmount.Text;
                            }

                            dr["LOWESTPRICE"] = txtLowestPrice.Text;
                            dr["COSTPRICE"] = txtCostPrice.Text;



                            dr["PRICE1"] = txtPrice1.Text;
                            dr["PRICE2"] = txtPrice2.Text;
                            dr["PRICE3"] = txtPrice3.Text;

                            //Hiren
                            dr["WEBPRICE"] = txtWebPrice.Text;

                            dr["Type"] = txtType.Text;
                            dr["ItemType"] = txtItemType.Text;
                            //IMEI NUMBER
                            dr["IMEINumber"] = txtIMEINumber.Text;
                            if (cmbCARRIERS.SelectedIndex != 0)
                            {
                                dr["CARRIERS"] = cmbCARRIERS.Text;
                            }
                            else
                            {
                                dr["CARRIERS"] = "";
                            }
                            if (cmbGRADING.SelectedIndex != 0)
                            {
                                dr["GRADING"] = cmbGRADING.Text;
                            }
                            else
                            {
                                dr["GRADING"] = "";
                            }

                            txtItemEdit.Text = "";
                            cmbPrice.Enabled = false;
                            break;
                        }
                    }

                    for (int k = 0; k < dtGridItem.Rows.Count; k++)
                    {
                        if (dtGridItem.Rows[k]["ITEM"].ToString().ToLower() == "notes" || dtGridItem.Rows[k]["ITEM"].ToString().ToLower() == "shipping")
                        {
                            dtGridItem.ImportRow(dtGridItem.Rows[k]);
                            dtGridItem.Rows.RemoveAt(k);
                            dtGridItem.AcceptChanges();
                        }
                    }

                    if (dtGridItem.Rows.Count > 0)
                    {
                        for (int k = 0; k < dtGridItem.Rows.Count; k++)
                        {
                            dtGridItem.Rows[k]["SrNo"] = k + 1;
                        }
                    }
                }



                else
                {
                    //Create

                    DataRow dr = dtGridItem.NewRow();

                    //if (dtGridItem.Rows.Count > 0)
                    //{
                    //    decimal Max = Convert.ToDecimal(dtGridItem.Compute("Max([SrNo])", string.Empty));
                    //    dr["SrNo"] = Max + 1;
                    //}
                    //else
                    //{
                    //    dr["SrNo"] = dgvInvoice1.Rows.Count + 1;
                    //}

                    dr["ID"] = cmbItem.SelectedValue.ToString();
                    dr["ITEM"] = cmbItem.Text;
                    dr["DESCRIPTION"] = txtDesc.Text;
                    dr["QTY"] = txtQty.Text;
                    if (dt1.Rows[0]["ItemType"].ToString() == "ItemDiscount")
                    {
                        if (!txtRate.Text.Contains("-"))
                        {
                            dr["RATE"] = "-" + txtRate.Text;
                            dr["AMOUNT"] = "-" + txtAmount.Text;
                        }
                        else
                        {
                            dr["RATE"] = txtRate.Text;
                            dr["AMOUNT"] = txtAmount.Text;
                        }

                    }
                    else
                    {
                        dr["RATE"] = txtRate.Text;
                        dr["AMOUNT"] = txtAmount.Text;
                    }

                    dr["LOWESTPRICE"] = txtLowestPrice.Text;
                    dr["COSTPRICE"] = txtCostPrice.Text;

                    dr["PRICE1"] = txtPrice1.Text;
                    dr["PRICE2"] = txtPrice2.Text;
                    dr["PRICE3"] = txtPrice3.Text;

                    //Hiren
                    dr["WEBPRICE"] = txtWebPrice.Text;

                    dr["Type"] = txtType.Text;
                    dr["ItemType"] = txtItemType.Text;

                    dr["IMEINumber"] = txtIMEINumber.Text;
                    if (cmbCARRIERS.SelectedIndex != 0)
                    {
                        dr["CARRIERS"] = cmbCARRIERS.Text;
                    }
                    else
                    {
                        dr["CARRIERS"] = "";
                    }
                    if (cmbGRADING.SelectedIndex != 0)
                    {
                        dr["GRADING"] = cmbGRADING.Text;
                    }
                    else
                    {
                        dr["GRADING"] = "";
                    }
                    Boolean i = false;
                    if (dtGridItem.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtGridItem.Rows.Count; j++)
                        {

                            if (dtGridItem.Rows[j]["ITEM"].ToString().ToLower() == "notes" || dtGridItem.Rows[j]["ITEM"].ToString().ToLower() == "shipping")
                            {
                                i = true;
                                dtGridItem.Rows.InsertAt(dr, j);
                                break;
                            }
                        }
                        if (i == false)
                        {
                            dtGridItem.Rows.Add(dr);
                        }
                    }
                    else
                    {
                        dtGridItem.Rows.Add(dr);
                    }

                    if (dtGridItem.Rows.Count > 0)
                    {
                        for (int k = 0; k < dtGridItem.Rows.Count; k++)
                        {
                            dtGridItem.Rows[k]["SrNo"] = k + 1;
                        }
                    }
                    //Hiren
                    foreach (DataGridViewRow row in dgvInvoice1.Rows)
                    {
                        if (row.Cells["ITEM"].Value != null)
                        {
                            string itemName = row.Cells["ITEM"].Value.ToString().ToLower();
                            string tax = dt1.Rows[0]["TaxCode"].ToString();
                            DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();
                            if (row.Cells["Tax"].Value == null || string.IsNullOrEmpty(row.Cells["Tax"].Value.ToString()))
                            {
                                if (tax == "Tax")
                                {
                                    comboBoxCell.Items.Add("Tax");
                                    comboBoxCell.Items.Add("Non");
                                    comboBoxCell.Value = "Tax";
                                }
                                else
                                {
                                    comboBoxCell.Items.Add("Non");
                                    comboBoxCell.Items.Add("Tax");
                                    comboBoxCell.Value = "Non";
                                }
                                row.Cells[18] = comboBoxCell;
                                dr["TaxCode"] = comboBoxCell.Value;
                            }
                        }
                    }

                    cmbPrice.Enabled = false;

                    if (txtID.Text != "")
                    {
                        UpdateLineDetail("INSERT");
                    }

                }

                dgvInvoice1.DataSource = dtGridItem;
                if (dgvInvoice1.RowCount > 0)
                {
                    dgvInvoice1.FirstDisplayedScrollingRowIndex = dgvInvoice1.RowCount - 1;
                }
                SUM();
                ResetData();

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :UpdateRow. Message:" + ex.Message);
            }

        }
        private Boolean CheckValidationForItem()
        {
            Boolean X = true;
            try
            {
                if (cmbItem.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select Item first..!!");
                    cmbItem.Focus();
                    X = false;
                }
                else if (txtQty.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity..!!");
                    txtQty.Focus();
                    X = false;
                }
                else if (txtRate.Text == "")
                {
                    MessageBox.Show("Please Enter Rate..!!");
                    txtRate.Focus();
                    X = false;
                }
                else if (txtRate.Text == "0.00" || txtRate.Text == "0")
                {
                    MessageBox.Show("Please Enter Rate Greater Than Zero..!!");
                    txtRate.Focus();
                    X = false;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :CheckValidationForItem. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
            return X;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidationForItem())
                {
                    dt1 = new BALItemMaster().SelectByID(new BOLItemMaster() { ID = Convert.ToInt32(cmbItem.SelectedValue) });

                    if (txtLowestPrice.Text != "")
                    {
                        if ((ClsCommon.UserType != "Admin" && ClsCommon.UserType != "admin") && (Convert.ToDecimal(txtRate.Text) < Convert.ToDecimal(txtLowestPrice.Text)))
                        {
                            //if (txtLowestPrice.Visible == false)
                            //{
                            //    MessageBox.Show("You can not add item beyond lowest Price");
                            //    txtRate.Focus();
                            //}
                            DataTable dtcustomer = new DataTable();
                            dtcustomer = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                            if (dtcustomer.Rows.Count > 0)
                            {
                                if (dtcustomer.Rows[0]["AllowLowestPrice"].ToString() == "1")
                                {
                                    Allow = 1;
                                }
                            }
                            if (Allow == 0)
                            {
                                MessageBox.Show("You can not add item beyond lowest Price");
                                txtRate.Focus();
                            }
                            else if (Allow == 1)
                            {
                                DialogResult result1 = MessageBox.Show("Are you sure you want to go beyond lowest price?", "Are you sure?", MessageBoxButtons.YesNo);

                                if (result1 == DialogResult.Yes)
                                {
                                    UpdateRow();
                                }
                            }
                            else
                            {
                                DialogResult result1 = MessageBox.Show("Are you sure you want to go beyond lowest price?", "Are you sure?", MessageBoxButtons.YesNo);

                                if (result1 == DialogResult.Yes)
                                {
                                    UpdateRow();
                                }
                            }
                        }
                        else
                        {
                            UpdateRow();
                        }
                    }
                    else
                    {
                        UpdateRow();
                    }

                    //For Paid Invoice Setting...
                    if (txtID.Text != "")
                    {
                        objBOLInvoice.ID = Convert.ToInt32(txtID.Text);
                        DataTable dtInv = new BALCreditMemo().SelectByID(objBOLInvoice);
                        if (dtInv.Rows.Count > 0)
                        {
                            lblPaymentApplied.Text = dtInv.Rows[0]["AppliedAmount"].ToString();
                            lblBalanceDue.Text = (Convert.ToDecimal(lblSubTotal.Text) - Convert.ToDecimal(lblPaymentApplied.Text)).ToString();
                        }

                    }
                    TaxCalculations();

                    //Approve Msg
                    //if (dtGridItem.Rows.Count > 0)
                    //{
                    //    DataTable dtApprove = new BALCustomerRequest().SelectApprovedStatus(new BOLCustomerRequest() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), ItemID = Convert.ToInt32(dtGridItem.Rows[dtGridItem.Rows.Count - 1]["ID"].ToString()) });
                    //    if (dtApprove.Rows.Count > 0)
                    //    {
                    //        if (Convert.ToInt32(dtApprove.Rows[0]["UseAllowesNo"].ToString()) > 0)
                    //        {
                    //            MessageBox.Show("You could set this price for " + dtApprove.Rows[0]["UseAllowesNo"].ToString() + " more times");
                    //        }
                    //        else if (Convert.ToInt32(dtApprove.Rows[0]["UseNoOFDays"].ToString()) > 0)
                    //        {
                    //            string Date = Convert.ToDateTime(dtApprove.Rows[0]["ModifiedTime"].ToString()).ToString("MM-dd-yyyy");
                    //            Int16 NoOfDays = Convert.ToInt16(dtApprove.Rows[0]["UseNoOFDays"].ToString());
                    //            DateTime Date1 = Convert.ToDateTime(Date).AddDays(NoOfDays);
                    //            string Date2 = DateTime.Now.ToString("MM-dd-yyyy");
                    //            if (Date1 >= Convert.ToDateTime(Date2))
                    //            {
                    //                double Days = (Date1 - Convert.ToDateTime(Date2)).TotalDays;
                    //                MessageBox.Show("You could set this price till " + Days + " days");
                    //            }
                    //        }
                    //    }
                    //}
                    txtQty.Focus();

                }
                //LoadTable();

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :btnAdd_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void cmbPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvInvoice1.Rows.Count == 0)
                {
                    if (cmbItem.SelectedIndex > 0)
                    {
                        DataTable dt = new BALItemMaster().Select(new BOLItemMaster() { });
                        if (dt.Rows.Count > 0)
                        {
                            DataRow[] row = dt.Select("FullName='" + cmbItem.Text.ToString().Replace("'", "''") + "'");
                            if (row.Length == 1)
                            {
                                foreach (DataRow dr in row)
                                {
                                    //Regular Item add                            
                                    txtDesc.Text = dr["SalesDesc"].ToString();
                                    //txtQty.Text = "1";

                                    if (cmbPrice.Text.ToString() == "Cost")
                                    {
                                        if (dr["PurchaseCost"].ToString() != "")
                                        {
                                            txtRate.Text = dr["PurchaseCost"].ToString();
                                        }
                                        else
                                        {
                                            txtRate.Text = "0.00";
                                        }

                                    }
                                    else if (cmbPrice.Text.ToString() == "TierGF")
                                    {
                                        if (dr["PriceTier1"].ToString() != "")
                                        {
                                            txtRate.Text = dr["PriceTier1"].ToString();
                                        }
                                        else
                                        {
                                            txtRate.Text = "0.00";
                                        }

                                    }
                                    else if (cmbPrice.Text.ToString() == "TierP4C")
                                    {
                                        if (dr["PriceTier2"].ToString() != "")
                                        {
                                            txtRate.Text = dr["PriceTier2"].ToString();
                                        }
                                        else
                                        {
                                            txtRate.Text = "0.00";
                                        }
                                    }
                                    else if (cmbPrice.Text.ToString() == "TierMS")
                                    {
                                        if (dr["PriceTier3"].ToString() != "")
                                        {
                                            txtRate.Text = dr["PriceTier3"].ToString();
                                        }
                                        else
                                        {
                                            txtRate.Text = "0.00";
                                        }
                                    }
                                    else
                                    {
                                        txtRate.Text = "0.00";
                                    }


                                    if (dr["ItemType"].ToString() == "ItemDiscount")
                                    {
                                        txtQty.Text = "1";
                                        txtQty.ReadOnly = true;
                                    }
                                    else
                                    {
                                        txtQty.ReadOnly = false;
                                    }
                                    if (txtQty.Text != "")
                                    {
                                        txtAmount.Text = (Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text)).ToString();
                                    }
                                    else
                                    {
                                        txtAmount.Text = (1 * Convert.ToDecimal(txtRate.Text)).ToString();
                                    }
                                    txtType.Text = "1";
                                    txtItemType.Text = dr["ItemType"].ToString();
                                    txtLowestPrice.Text = dr["LowestPrice"].ToString();
                                    txtCostPrice.Text = dr["PurchaseCost"].ToString();


                                    DataTable dtSale = new BALItemSaleHistory().SelectLastThreeSale(new BOLItemSaleHistory() { CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue), ItemID = Convert.ToInt32(cmbItem.SelectedValue.ToString()) });
                                    if (dtSale.Rows.Count > 0)
                                    {
                                        for (int i = 0; i < dtSale.Rows.Count; i++)
                                        {
                                            if (i == 0)
                                                txtPrice1.Text = dtSale.Rows[i]["SalePrice"].ToString();
                                            if (i == 1)
                                                txtPrice2.Text = dtSale.Rows[i]["SalePrice"].ToString();
                                            if (i == 2)
                                                txtPrice3.Text = dtSale.Rows[i]["SalePrice"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        txtPrice1.Text = "";
                                        txtPrice2.Text = "";
                                        txtPrice3.Text = "";
                                    }

                                }

                            }
                        }
                    }
                }
                else
                {
                    DataTable dt = new BALItemMaster().Select(new BOLItemMaster() { });
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow dr1 in dgvInvoice1.Rows)
                        {
                            DataRow[] row = dt.Select("FullName='" + dr1.Cells["ITEM"].Value.ToString().Replace("'", "''") + "'");
                            if (row.Length == 1)
                            {
                                foreach (DataRow dr in row)
                                {
                                    if (cmbPrice.Text.ToString() == "Cost")
                                    {
                                        if (dr["PurchaseCost"].ToString() != "")
                                        {
                                            dr1.Cells["RATE"].Value = dr["PurchaseCost"].ToString();
                                        }
                                        else
                                        {
                                            dr1.Cells["RATE"].Value = "0.00";
                                        }
                                    }

                                    else if (cmbPrice.Text.ToString() == "TierGF")
                                    {
                                        if (dr["PriceTier1"].ToString() != "")
                                        {
                                            dr1.Cells["RATE"].Value = dr["PriceTier1"].ToString();
                                        }
                                        else
                                        {
                                            dr1.Cells["RATE"].Value = "0.00";
                                        }

                                    }

                                    else if (cmbPrice.Text.ToString() == "TierP4C")
                                    {
                                        if (dr["PriceTier2"].ToString() != "")
                                        {
                                            dr1.Cells["RATE"].Value = dr["PriceTier2"].ToString();
                                        }
                                        else
                                        {
                                            dr1.Cells["RATE"].Value = "0.00";
                                        }
                                    }

                                    else if (cmbPrice.Text.ToString() == "TierMS")
                                    {
                                        if (dr["PriceTier3"].ToString() != "")
                                        {
                                            dr1.Cells["RATE"].Value = dr["PriceTier3"].ToString();
                                        }
                                        else
                                        {
                                            dr1.Cells["RATE"].Value = "0.00";
                                        }
                                    }

                                    else
                                    {
                                        dr1.Cells["RATE"].Value = "0.00";
                                    }

                                    dr1.Cells["AMOUNT"].Value = Convert.ToDecimal(dr1.Cells["QTY"].Value) * Convert.ToDecimal(dr1.Cells["RATE"].Value);
                                }
                            }
                        }
                        SUM();
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :cmbPrice_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void SUM()
        {
            try
            {

                decimal Total = 0;
                for (int i = 0; i < dgvInvoice1.Rows.Count; i++)
                {
                    if (dgvInvoice1.Rows[i].Cells["Amount"].Value != null)
                    {
                        if (dgvInvoice1.Rows[i].Cells["Amount"].Value.ToString() != "")
                        {
                            Total += Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Amount"].Value.ToString());
                        }
                    }
                }
                lblTotal.Text = Total.ToString("N2");

                //if (txtType.Text == "1")
                //{
                lblPaymentApplied.Text = "0.0";
                lblBalanceDue.Text = (Convert.ToDecimal(lblTotal.Text) - Convert.ToDecimal(lblPaymentApplied.Text)).ToString();
                //}
                TaxCalculations();

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :SUM. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void ResetData()
        {
            cmbItem.SelectedIndex = 0;
            txtDesc.Text = "";
            txtQty.Text = "";
            txtRate.Text = "";
            txtAmount.Text = "";
            txtLowestPrice.Text = "";
            txtCostPrice.Text = "";

            txtPrice1.Text = "";
            txtPrice2.Text = "";
            txtPrice3.Text = "";
            txtType.Text = "";
            txtItemType.Text = "";
            txtIMEINumber.Text = "";
            cmbCARRIERS.SelectedIndex = 0;
            cmbGRADING.SelectedIndex = 0;
            txtWebPrice.Text = "";

        }
        private void dgvInvoice1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 20)
                {
                    if (dgvInvoice1.Columns[20].ReadOnly == true)
                    {
                        MessageBox.Show("You do not have access to delete this item");
                    }
                    else
                    {
                        int ItemID = Convert.ToInt32(dgvInvoice1.CurrentRow.Cells["ID"].Value.ToString());
                        if (txtID.Text != "")
                        {
                            DataTable dt = new BALCreditMemoDetails().SelectInvID(new BOLCreditMemoDetails() { InvoiceID = Convert.ToInt32(txtID.Text), ItemID = ItemID });
                            if (dt.Rows.Count > 0)
                            {
                                DataTable dtPrint = objPrintBAL.Select();
                                if (dtPrint.Rows.Count > 0)
                                {
                                    if (dtPrint.Rows[0]["Flag"].ToString() == "True")
                                    {

                                        objItemLogBOL = new BOLCreditMemoLineItemLog();
                                        objBOLInvCount = new BOLCreditMemoPrintCount();
                                        dt1 = objBALInvCount.Select(Convert.ToInt32(InvoiceID));
                                        if (dt1.Rows.Count > 0)
                                        {
                                            int Max = Convert.ToInt32(dt1.Compute("Max([PrintNo])", string.Empty));
                                            objItemLogBOL.EditCount = Max + 1;
                                        }
                                        else
                                        {
                                            objItemLogBOL.EditCount = 2;
                                        }

                                        objItemLogBOL.CreditMemoID = Convert.ToInt32(txtID.Text);
                                        objItemLogBOL.ItemID = Convert.ToInt32(ItemID);
                                        objItemLogBOL.Description = dgvInvoice1.CurrentRow.Cells["Description"].Value.ToString();
                                        objItemLogBOL.Qty = Convert.ToDecimal(dgvInvoice1.CurrentRow.Cells["Qty"].Value);
                                        objItemLogBOL.PriceEach = Convert.ToDecimal(dgvInvoice1.CurrentRow.Cells["RATE"].Value);
                                        objItemLogBOL.Amount = Convert.ToDecimal(dgvInvoice1.CurrentRow.Cells["Amount"].Value);
                                        objItemLogBOL.IsPrint = 0;
                                        objItemLogBOL.EditMode = "DELETE";
                                        objItemLogBAL.Insert(objItemLogBOL);
                                        Count = 1;
                                    }
                                }
                                objBOLInvDetails.InvoiceID = Convert.ToInt32(txtID.Text);
                                objBOLInvDetails.ItemID = ItemID;
                                objBALInvDetails.DeleteByItemID(objBOLInvDetails);

                                IsClose = true;

                                dt1 = new BALItemMaster().SelectByID(new BOLItemMaster() { ID = Convert.ToInt32(ItemID) });
                                if (dt1.Rows.Count > 0)
                                {
                                    decimal QtyOnHand = Convert.ToDecimal(dgvInvoice1.CurrentRow.Cells["Qty"].Value) + Convert.ToDecimal(dt1.Rows[0]["QtyOnHand"].ToString());
                                    objBOLItem = new BOLItemMaster();
                                    objBOLItem.ID = ItemID;
                                    objBOLItem.QtyOnHand = QtyOnHand;
                                    objBALItem.UpdateQtyOnHand(objBOLItem);
                                }

                            }

                        }

                        string SrNo = dgvInvoice1.CurrentRow.Cells[0].Value.ToString();
                        dgvInvoice1.Rows.RemoveAt(this.dgvInvoice1.CurrentRow.Index);
                        dtGridItem.AcceptChanges();

                        foreach (DataRow dr in dtGridItem.Rows)
                        {

                            if (dr["SrNo"].ToString() == SrNo)
                            {
                                txtType.Text = dr["Type"].ToString();
                                dr.Delete();
                                break;
                            }
                        }
                        dgvInvoice1.DataSource = dtGridItem;
                        if (Mode == "insert")
                            SUM();
                        else
                            SUMForEdit();

                        //Hiren
                        foreach (DataGridViewRow row in dgvInvoice1.Rows)
                        {
                            if (row.Cells["ITEM"].Value != null)
                            {
                                string itemName = row.Cells["ITEM"].Value.ToString().ToLower();

                                DataGridViewComboBoxCell cmbTaxType = new DataGridViewComboBoxCell();

                                string tax = row.Cells["TaxCode"].Value.ToString();

                                if (!string.IsNullOrEmpty(tax))
                                {
                                    if (tax == "Tax")
                                    {
                                        cmbTaxType.Items.Add("Tax");
                                        cmbTaxType.Items.Add("Non");
                                        cmbTaxType.Value = "Tax";
                                    }
                                    else
                                    {
                                        cmbTaxType.Items.Add("Non");
                                        cmbTaxType.Items.Add("Tax");
                                        cmbTaxType.Value = "Non";
                                    }

                                    if (row.Cells.Count > 18)
                                    {
                                        row.Cells[18] = cmbTaxType;
                                    }
                                }
                            }
                        }

                        if (dgvInvoice1.Rows.Count == 0)
                        {
                            cmbPrice.Enabled = true;
                        }
                    }

                }

                else if (e.ColumnIndex == 19)
                {
                    if (dgvInvoice1.Columns[19].ReadOnly == true)
                    {
                        MessageBox.Show("You do not have access to Edit this item");
                    }
                    else
                    {
                        string SrNo = dgvInvoice1.CurrentRow.Cells[0].Value.ToString();
                        foreach (DataRow dr in dtGridItem.Rows)
                        {
                            if (dr["SrNo"].ToString() == SrNo)
                            {

                                txtItemEdit.Text = dr["SrNo"].ToString();
                                cmbItem.SelectedValue = dr["ID"].ToString();
                                txtDesc.Text = dr["DESCRIPTION"].ToString();
                                txtQty.Text = dr["QTY"].ToString();
                                ClsCommon.OldQty = Convert.ToDecimal(dr["QTY"]);
                                if (dr["ItemType"].ToString() == "ItemDiscount")
                                {
                                    txtRate.Text = dr["RATE"].ToString().Replace("-", "");
                                    txtAmount.Text = dr["AMOUNT"].ToString().Replace("-", "");
                                }
                                else
                                {
                                    txtRate.Text = dr["RATE"].ToString();
                                    txtAmount.Text = dr["AMOUNT"].ToString();
                                }
                                txtLowestPrice.Text = dr["LOWESTPRICE"].ToString();
                                txtCostPrice.Text = dr["COSTPRICE"].ToString();

                                txtPrice1.Text = dr["PRICE1"].ToString();
                                txtPrice2.Text = dr["PRICE2"].ToString();
                                txtPrice3.Text = dr["PRICE3"].ToString();
                                txtType.Text = dr["Type"].ToString();

                                txtItemType.Text = dr["ItemType"].ToString();
                                txtIMEINumber.Text = dr["IMEINumber"].ToString();

                                if (dr["CARRIERS"].ToString() != "")
                                {
                                    cmbCARRIERS.Text = dr["CARRIERS"].ToString();
                                }
                                else
                                {
                                    cmbCARRIERS.SelectedIndex = 0;
                                }
                                if (dr["GRADING"].ToString() != "")
                                {
                                    cmbGRADING.Text = dr["GRADING"].ToString();
                                }
                                else
                                {
                                    cmbGRADING.SelectedIndex = 0;

                                }

                                break;
                            }
                        }
                    }
                }
                TaxCalculations();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :dgvInvoice1_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void SUMForEdit()
        {
            try
            {

                decimal Total = 0;
                for (int i = 0; i < dgvInvoice1.Rows.Count; i++)
                {
                    if (dgvInvoice1.Rows[i].Cells["Amount"].Value != null)
                    {
                        if (dgvInvoice1.Rows[i].Cells["Amount"].Value.ToString() != "")
                        {
                            Total += Convert.ToDecimal(dgvInvoice1.Rows[i].Cells["Amount"].Value.ToString());
                        }
                    }
                }

                lblTotal.Text = Total.ToString("N2");

                if (dtLoadData.Rows.Count > 0)
                {
                    lblPaymentApplied.Text = dtLoadData.Rows[0]["AppliedAmount"].ToString();
                    lblBalanceDue.Text = (Convert.ToDecimal(lblTotal.Text) - Convert.ToDecimal(dtLoadData.Rows[0]["AppliedAmount"].ToString())).ToString();
                }
                TaxCalculations();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :SUMForEdit. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void btnEmail_Click(object sender, EventArgs e)
        {
            try
            {
                ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
                contextMenuStrip1.Items.Clear();
                contextMenuStrip1.Items.Add("Default Email");
                contextMenuStrip1.Items.Add("Other Email");
                contextMenuStrip1.Show(btnPrint, new Point(0, btnPrint.Height));
                contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenuStrip1_btnEmailClicked);
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :btnEmail_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        private void contextMenuStrip1_btnEmailClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("CreditMemoEmail", "CustomerCenter"))
                {
                    if (e.ClickedItem.Text == "Other Email")
                    {
                        if (txtID.Text != "")
                        {
                            if (cmbCustomer.SelectedIndex > 0)
                            {
                                DataTable dtCus = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                                if (dtCus.Rows.Count > 0)
                                {
                                    DataTable dtInv1 = new BALCreditMemo().SelectForPrint(new BOLCreditMemo() { ID = Convert.ToInt32(InvoiceID) });
                                    if (dtInv1.Rows.Count > 0)
                                    {
                                        string FileName = Application.StartupPath + @"\PrintReport\" + dtInv1.Rows[0]["RefNumber"].ToString() + "_" + dtInv1.Rows[0]["CustomerID"].ToString() + ".pdf";
                                        if (FileName != "")
                                        {
                                            if (!File.Exists(FileName))
                                            {
                                                SendPDF();
                                            }
                                            else
                                            {
                                                File.Delete(FileName);
                                                SendPDF();
                                            }
                                        }
                                        FrmEmailTemplateList obj = new FrmEmailTemplateList();
                                        obj.EmialLoadData("Invoice Edit", dtCus.Rows[0]["FullName"].ToString(), dtCus.Rows[0]["FirstName"].ToString(), dtCus.Rows[0]["LastName"].ToString(), txtInvoiceNo.Text, Convert.ToDecimal(lblSubTotal.Text), dtCus.Rows[0]["CompanyName"].ToString(), dtpInvoiceDate.Value.ToShortDateString(), dtpShipDate.Value.ToShortDateString(), dtpDuedate.Value.ToShortDateString(), dtCus.Rows[0]["Email"].ToString(), Application.StartupPath + @"\PrintReport\" + dtInv1.Rows[0]["RefNumber"].ToString() + "_" + dtInv1.Rows[0]["CustomerID"].ToString() + ".pdf", dtCus.Rows[0]["ID"].ToString());
                                        obj.ShowDialog();
                                    }
                                }
                            }
                        }

                    }

                    else if (e.ClickedItem.Text == "Default Email")
                    {
                        if (txtID.Text != "")
                        {
                            if (cmbCustomer.SelectedIndex > 0)
                            {
                                DataTable dtCus = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                                if (dtCus.Rows.Count > 0)
                                {
                                    DataTable dtInv1 = new BALCreditMemo().SelectForPrint(new BOLCreditMemo() { ID = Convert.ToInt32(InvoiceID) });
                                    if (dtInv1.Rows.Count > 0)
                                    {
                                        string FileName = Application.StartupPath + @"\PrintReport\" + dtInv1.Rows[0]["RefNumber"].ToString() + "_" + dtInv1.Rows[0]["CustomerID"].ToString() + ".pdf";
                                        if (FileName != "")
                                        {
                                            if (!File.Exists(FileName))
                                            {
                                                SendPDF();
                                            }
                                            else
                                            {
                                                File.Delete(FileName);
                                                SendPDF();
                                            }
                                        }
                                        FrmEmailTemplateList obj = new FrmEmailTemplateList();
                                        obj.EmialLoadData("Invoice Edit", dtCus.Rows[0]["FullName"].ToString(), dtCus.Rows[0]["FirstName"].ToString(), dtCus.Rows[0]["LastName"].ToString(), txtInvoiceNo.Text, Convert.ToDecimal(lblSubTotal.Text), dtCus.Rows[0]["CompanyName"].ToString(), dtpInvoiceDate.Value.ToShortDateString(), dtpShipDate.Value.ToShortDateString(), dtpDuedate.Value.ToShortDateString(), dtCus.Rows[0]["Email"].ToString(), Application.StartupPath + @"\PrintReport\" + dtInv1.Rows[0]["RefNumber"].ToString() + "_" + dtInv1.Rows[0]["CustomerID"].ToString() + ".pdf", dtCus.Rows[0]["ID"].ToString());
                                        obj.EmailSend();
                                    }
                                }
                            }
                        }

                    }
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :contextMenuStrip1_btnPrintClicked. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void SendPDF()
        {
            try
            {
                if (txtID.Text != "")
                {
                    DataTable dtDetail = new DataTable();
                    dtDetail.Columns.Add("Quantity", typeof(decimal));
                    dtDetail.Columns.Add("ItemCode", typeof(string));
                    dtDetail.Columns.Add("Description", typeof(string));
                    dtDetail.Columns.Add("PriceEach", typeof(string));
                    dtDetail.Columns.Add("Amount", typeof(decimal));
                    //Hiren
                    dtDetail.Columns.Add("WebPrice", typeof(decimal));

                    foreach (DataGridViewRow dr in dgvInvoice1.Rows)
                    {
                        if (dr.Cells["Item"].Value != null)
                        {
                            DataRow dr1 = dtDetail.NewRow();
                            dr1["Quantity"] = dr.Cells["Qty"].Value;
                            dr1["ItemCode"] = dr.Cells["Item"].Value;
                            dr1["Description"] = dr.Cells["Description"].Value;
                            if (dr.Cells["Rate"].Value == null)
                                dr1["PriceEach"] = "";
                            else
                                dr1["PriceEach"] = dr.Cells["Rate"].Value;
                            dr1["Amount"] = dr.Cells["Amount"].Value;
                            dr1["WebPrice"] = dr.Cells["WebPrice"].Value;
                            dtDetail.Rows.Add(dr1);
                        }
                    }

                    ClsCommon.INVID = Convert.ToInt32(txtID.Text);

                    rptInvoiceReport cryRptInvoiceReport = new rptInvoiceReport();
                    cryRptInvoiceReport.SetDataSource(dtDetail);
                    cryRptInvoiceReport.SetParameterValue("TxnDate", dtpInvoiceDate.Value);
                    cryRptInvoiceReport.SetParameterValue("InvoiceNo", txtInvoiceNo.Text);
                    cryRptInvoiceReport.SetParameterValue("PONumber", txtPONumber.Text);
                    cryRptInvoiceReport.SetParameterValue("Terms", cmbTerms.SelectedIndex == 0 ? "" : cmbTerms.Text);
                    cryRptInvoiceReport.SetParameterValue("Rep", cmbSalesRep.SelectedIndex == 0 ? "" : cmbSalesRep.Text);
                    cryRptInvoiceReport.SetParameterValue("ShipDate", dtpShipDate.Value);
                    cryRptInvoiceReport.SetParameterValue("Via", cmbShippingMethod.SelectedIndex == 0 ? "" : cmbSalesRep.Text);
                    cryRptInvoiceReport.SetParameterValue("CustomerName", cmbCustomer.Text);
                    //cryRptInvoiceReport.SetParameterValue("Total", lblTotal.Text == "" ? "0" : lblTotal.Text);
                    cryRptInvoiceReport.SetParameterValue("BillAddress", txtBillAddress.Text);
                    cryRptInvoiceReport.SetParameterValue("ShipAddress", txtShipAddress.Text);
                    cryRptInvoiceReport.SetParameterValue("Memo", txtMemo.Text);
                    cryRptInvoiceReport.SetParameterValue("CustomerMessage", cmbMsg.SelectedIndex == 0 ? "" : cmbMsg.Text);
                    //princy
                    cryRptInvoiceReport.SetParameterValue("AppliedAmount", lblPaymentApplied.Text);
                    cryRptInvoiceReport.SetParameterValue("BalanceDue", lblBalanceDue.Text);
                    cryRptInvoiceReport.SetParameterValue("TagName", "Credit Memo");
                    cryRptInvoiceReport.SetParameterValue("NumberName", "CreditMemo #");
                    cryRptInvoiceReport.SetParameterValue("TaxAmount", lblTaxAmount.Text);
                    cryRptInvoiceReport.SetParameterValue("TaxPercent", lblTaxPercentage.Text.Replace("(", "").Replace("%)", ""));
                    if (cmbSalesTax.SelectedIndex != 0)
                    {
                        cryRptInvoiceReport.ReportDefinition.ReportObjects["Text2"].ObjectFormat.EnableSuppress = false;
                        cryRptInvoiceReport.ReportDefinition.ReportObjects["Text12"].ObjectFormat.EnableSuppress = false;
                        cryRptInvoiceReport.SetParameterValue("TaxName", cmbSalesTax.Text);
                    }
                    else
                    {
                        cryRptInvoiceReport.ReportDefinition.ReportObjects["Text2"].ObjectFormat.EnableSuppress = true;
                        cryRptInvoiceReport.ReportDefinition.ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
                        cryRptInvoiceReport.SetParameterValue("TaxName", "");
                    }

                    crystalReportViewer1.ReportSource = cryRptInvoiceReport;
                    cryRptInvoiceReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + @"\PrintReport\" + txtInvoiceNo.Text + "_" + cmbCustomer.SelectedValue.ToString() + ".pdf");




                }

            }

            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :SendPDF. Crystal Report Export Message:" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        private void pnlEntry_Paint(object sender, PaintEventArgs e)
        {
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void cmbService_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cmbService_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void txtBillAddress_TextChanged(object sender, EventArgs e)
        {

        }
        private void cmbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Escape)
            {
                var confirmResult = MessageBox.Show("Are you sure You want to leave this Page??", "Confirm Leave!!", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    this.Close();
                    return true;
                }
                else
                {
                    return true;
                }

            }
            return base.ProcessCmdKey(ref msg, keyData);

        }
        private void Start()
        {
            try
            {
                Inv = InvoiceID2;
                FrmEmailTemplateList obj = new FrmEmailTemplateList();
                DataTable dtCus = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                if (dtCus.Rows.Count > 0)
                {
                    DataTable dtInv1 = new BALCreditMemo().SelectForPrint(new BOLCreditMemo() { ID = Convert.ToInt32(InvoiceID2) });
                    if (dtInv1.Rows.Count > 0)
                    {
                        DataTable dtInvDetail = new BALCreditMemoDetails().SelectByID(new BOLCreditMemoDetails() { InvoiceID = Convert.ToInt32(InvoiceID2) });

                        dtInv1.Columns.Add("BillAddr", typeof(string));
                        dtInv1.Columns.Add("ShipAddr", typeof(string));

                        #region BillAdd
                        if (dtCus.Rows[0]["Address1"].ToString() != "")
                            BillAddress = dtCus.Rows[0]["Address1"].ToString();
                        if (dtCus.Rows[0]["Address2"].ToString() != "")
                            BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["Address2"].ToString();
                        if (dtCus.Rows[0]["Address3"].ToString() != "")
                            BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["Address3"].ToString();

                        if (dtCus.Rows[0]["City"].ToString() != "" && dtCus.Rows[0]["State"].ToString() != "")
                            BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["City"].ToString() + "," + dtCus.Rows[0]["State"].ToString();
                        else if (dtCus.Rows[0]["City"].ToString() != "" && dtCus.Rows[0]["State"].ToString() == "")
                            BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["City"].ToString();
                        else if (dtCus.Rows[0]["City"].ToString() == "" && dtCus.Rows[0]["State"].ToString() != "")
                            BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["State"].ToString();

                        if (dtCus.Rows[0]["PostalCode"].ToString() != "" && dtCus.Rows[0]["Country"].ToString() != "")
                            BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["PostalCode"].ToString() + "," + dtCus.Rows[0]["Country"].ToString();
                        else if (dtCus.Rows[0]["Country"].ToString() != "" && dtCus.Rows[0]["PostalCode"].ToString() == "")
                            BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["Country"].ToString();
                        else if (dtCus.Rows[0]["Country"].ToString() == "" && dtCus.Rows[0]["PostalCode"].ToString() != "")
                            BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["PostalCode"].ToString();
                        #endregion

                        #region ShipAdd
                        if (dtInv1.Rows[0]["ShipAdd1"].ToString() != "")
                            ShipAddress = dtInv1.Rows[0]["ShipAdd1"].ToString();
                        if (dtInv1.Rows[0]["ShipAdd2"].ToString() != "")
                            ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipAdd2"].ToString();
                        if (dtInv1.Rows[0]["ShipAdd3"].ToString() != "")
                            ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipAdd3"].ToString();

                        if (dtInv1.Rows[0]["ShipCity"].ToString() != "" && dtInv1.Rows[0]["ShipState"].ToString() != "")
                            ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipCity"].ToString() + "," + dtInv1.Rows[0]["ShipState"].ToString();
                        else if (dtInv1.Rows[0]["ShipCity"].ToString() != "" && dtInv1.Rows[0]["ShipState"].ToString() == "")
                            ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipCity"].ToString();
                        else if (dtInv1.Rows[0]["ShipCity"].ToString() == "" && dtInv1.Rows[0]["ShipState"].ToString() != "")
                            ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipState"].ToString();

                        if (dtInv1.Rows[0]["ShipPostalCode"].ToString() != "" && dtInv1.Rows[0]["ShipCountry"].ToString() != "")
                            ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipPostalCode"].ToString() + "," + dtInv1.Rows[0]["ShipCountry"].ToString();
                        else if (dtInv1.Rows[0]["ShipCountry"].ToString() != "" && dtInv1.Rows[0]["ShipPostalCode"].ToString() == "")
                            ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipCountry"].ToString();
                        else if (dtInv1.Rows[0]["ShipCountry"].ToString() == "" && dtInv1.Rows[0]["ShipPostalCode"].ToString() != "")
                            ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipPostalCode"].ToString();

                        #endregion

                        dtInv1.Rows[0]["BillAddr"] = BillAddress.Replace("\r\n\r\n", "\r\n");
                        dtInv1.Rows[0]["ShipAddr"] = ShipAddress.Replace("\r\n\r\n", "\r\n");
                        BillAddress = ""; ShipAddress = "";

                        DataTable dtNewdtInvDetail = new DataTable();
                        if (dtInvDetail.Rows.Count > 0)
                        {
                            DataRow[] drcheck = dtInvDetail.Select("[ItemFullName]='shipping'");
                            if (drcheck.Length > 0)
                            {
                                DataRow[] drcheck1 = dtInvDetail.Select("[ItemFullName]<>'shipping'");
                                if (drcheck1.Length > 0)
                                {
                                    DataTable dtTemp1 = drcheck1.CopyToDataTable();
                                    dtNewdtInvDetail = dtTemp1.Copy();
                                }
                                DataTable dtTemp2 = drcheck.CopyToDataTable();
                                dtNewdtInvDetail.Merge(dtTemp2);
                            }
                            else
                            {
                                dtNewdtInvDetail = dtInvDetail.Copy();
                            }
                        }
                        try
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                rptPrintReport cryRpt = new rptPrintReport();
                                cryRpt.Database.Tables[0].SetDataSource(dtInv1);
                                cryRpt.Database.Tables[1].SetDataSource(dtNewdtInvDetail);
                                crystalReportViewer1.ReportSource = cryRpt;
                                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + @"\PrintReport\" + dtInv1.Rows[0]["RefNumber"].ToString() + "_" + dtInv1.Rows[0]["CustomerID"].ToString() + ".pdf");
                            });

                        }
                        catch (Exception ex)
                        {
                            ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :btnSaveandClose_Click. Crystal Report Export Message:" + ex.Message);
                        }


                    }
                }
                pctLoader.Visible = false;

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :btnSaveandClose_Click. Message:" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        //private void btnSaveAndEmail_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        InvoiceID2 = "";
        //        if (SaveData(ref InvoiceID2))
        //        {
        //            oThread = new Thread(new ThreadStart(Start));
        //            oThread.SetApartmentState(ApartmentState.STA);
        //            CheckForIllegalCrossThreadCalls = false;
        //            oThread.Start();
        //            pctLoader.Visible = true;

        //            FrmEmailTemplateList obj = new FrmEmailTemplateList();
        //            DataTable dtCus = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
        //            if (dtCus.Rows.Count > 0)
        //            {
        //                DataTable dtInv1 = new BALCreditMemo().SelectForPrint(new BOLCreditMemo() { ID = Convert.ToInt32(InvoiceID2) });
        //                if (dtInv1.Rows.Count > 0)
        //                {
        //                    if (Mode == "insert")
        //                        obj.EmialLoadData("Invoice Create", dtCus.Rows[0]["FullName"].ToString(), dtCus.Rows[0]["FirstName"].ToString(), dtCus.Rows[0]["LastName"].ToString(), txtInvoiceNo.Text, Convert.ToDecimal(lblSubTotal.Text), dtCus.Rows[0]["CompanyName"].ToString(), dtpInvoiceDate.Value.ToShortDateString(), dtpShipDate.Value.ToShortDateString(), dtpDuedate.Value.ToShortDateString(), dtCus.Rows[0]["Email"].ToString(), Application.StartupPath + @"\PrintReport\" + dtInv1.Rows[0]["RefNumber"].ToString() + "_" + dtInv1.Rows[0]["CustomerID"].ToString() + ".pdf", dtCus.Rows[0]["ID"].ToString());
        //                    else
        //                        obj.EmialLoadData("Invoice Edit", dtCus.Rows[0]["FullName"].ToString(), dtCus.Rows[0]["FirstName"].ToString(), dtCus.Rows[0]["LastName"].ToString(), txtInvoiceNo.Text, Convert.ToDecimal(lblSubTotal.Text), dtCus.Rows[0]["CompanyName"].ToString(), dtpInvoiceDate.Value.ToShortDateString(), dtpShipDate.Value.ToShortDateString(), dtpDuedate.Value.ToShortDateString(), dtCus.Rows[0]["Email"].ToString(), Application.StartupPath + @"\PrintReport\" + dtInv1.Rows[0]["RefNumber"].ToString() + "_" + dtInv1.Rows[0]["CustomerID"].ToString() + ".pdf", dtCus.Rows[0]["ID"].ToString());
        //                }
        //            }
        //            obj.ShowDialog();
        //            ClsCommon.ObjCustomerCenter.LoadFunc();
        //            ClsCommon.ObjCustomerCenter.LoadCustomerData(Convert.ToInt32(cmbCustomer.SelectedValue.ToString()));
        //            Clear();
        //            this.Close();
        //            Mode = "insert";
        //            //DisplayRequest();
        //            ClsCommon.objTodayInvoice.LoadInvoice();

        //            UpdatePriceTier(Convert.ToInt32(cmbCustomer.SelectedValue), cmbPrice.SelectedText, ClsCommon.UserID);

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :btnSaveandClose_Click. Message:" + ex.Message);
        //        MessageBox.Show(ex.Message);
        //    }

        //}

        public void readfiles()
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(Application.StartupPath + @"\Export\");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                readfiles();
                DataTable dtCus = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                if (dtCus.Rows.Count > 0)
                {
                    if (txtID.Text != "")
                    {
                        DataTable dtInv1 = new BALCreditMemo().SelectForPrint(new BOLCreditMemo() { ID = Convert.ToInt32(txtID.Text) });
                        if (dtInv1.Rows.Count > 0)
                        {
                            DataTable dtInvDetail = new BALCreditMemoDetails().SelectByID(new BOLCreditMemoDetails() { InvoiceID = Convert.ToInt32(txtID.Text) });

                            dtInv1.Columns.Add("BillAddr", typeof(string));
                            dtInv1.Columns.Add("ShipAddr", typeof(string));

                            #region BillAdd
                            if (dtCus.Rows[0]["Address1"].ToString() != "")
                                BillAddress = dtCus.Rows[0]["Address1"].ToString();
                            if (dtCus.Rows[0]["Address2"].ToString() != "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["Address2"].ToString();
                            if (dtCus.Rows[0]["Address3"].ToString() != "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["Address3"].ToString();

                            if (dtCus.Rows[0]["City"].ToString() != "" && dtCus.Rows[0]["State"].ToString() != "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["City"].ToString() + "," + dtCus.Rows[0]["State"].ToString();
                            else if (dtCus.Rows[0]["City"].ToString() != "" && dtCus.Rows[0]["State"].ToString() == "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["City"].ToString();
                            else if (dtCus.Rows[0]["City"].ToString() == "" && dtCus.Rows[0]["State"].ToString() != "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["State"].ToString();

                            if (dtCus.Rows[0]["PostalCode"].ToString() != "" && dtCus.Rows[0]["Country"].ToString() != "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["PostalCode"].ToString() + "," + dtCus.Rows[0]["Country"].ToString();
                            else if (dtCus.Rows[0]["Country"].ToString() != "" && dtCus.Rows[0]["PostalCode"].ToString() == "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["Country"].ToString();
                            else if (dtCus.Rows[0]["Country"].ToString() == "" && dtCus.Rows[0]["PostalCode"].ToString() != "")
                                BillAddress = BillAddress + "\r\n" + dtCus.Rows[0]["PostalCode"].ToString();
                            #endregion

                            #region ShipAdd
                            if (dtInv1.Rows[0]["ShipAdd1"].ToString() != "")
                                ShipAddress = dtInv1.Rows[0]["ShipAdd1"].ToString();
                            if (dtInv1.Rows[0]["ShipAdd2"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipAdd2"].ToString();
                            if (dtInv1.Rows[0]["ShipAdd3"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipAdd3"].ToString();

                            if (dtInv1.Rows[0]["ShipCity"].ToString() != "" && dtInv1.Rows[0]["ShipState"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipCity"].ToString() + "," + dtInv1.Rows[0]["ShipState"].ToString();
                            else if (dtInv1.Rows[0]["ShipCity"].ToString() != "" && dtInv1.Rows[0]["ShipState"].ToString() == "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipCity"].ToString();
                            else if (dtInv1.Rows[0]["ShipCity"].ToString() == "" && dtInv1.Rows[0]["ShipState"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipState"].ToString();

                            if (dtInv1.Rows[0]["ShipPostalCode"].ToString() != "" && dtInv1.Rows[0]["ShipCountry"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipPostalCode"].ToString() + "," + dtInv1.Rows[0]["ShipCountry"].ToString();
                            else if (dtInv1.Rows[0]["ShipCountry"].ToString() != "" && dtInv1.Rows[0]["ShipPostalCode"].ToString() == "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipCountry"].ToString();
                            else if (dtInv1.Rows[0]["ShipCountry"].ToString() == "" && dtInv1.Rows[0]["ShipPostalCode"].ToString() != "")
                                ShipAddress = ShipAddress + "\r\n" + dtInv1.Rows[0]["ShipPostalCode"].ToString();

                            #endregion

                            dtInv1.Rows[0]["BillAddr"] = BillAddress.Replace("\r\n\r\n", "\r\n");
                            dtInv1.Rows[0]["ShipAddr"] = ShipAddress.Replace("\r\n\r\n", "\r\n");
                            BillAddress = ""; ShipAddress = "";

                            DataTable dtNewdtInvDetail = new DataTable();
                            if (dtInvDetail.Rows.Count > 0)
                            {
                                DataRow[] drcheck = dtInvDetail.Select("[ItemFullName]='shipping'");
                                if (drcheck.Length > 0)
                                {
                                    DataRow[] drcheck1 = dtInvDetail.Select("[ItemFullName]<>'shipping'");
                                    if (drcheck1.Length > 0)
                                    {
                                        DataTable dtTemp1 = drcheck1.CopyToDataTable();
                                        dtNewdtInvDetail = dtTemp1.Copy();
                                    }
                                    DataTable dtTemp2 = drcheck.CopyToDataTable();
                                    dtNewdtInvDetail.Merge(dtTemp2);
                                }
                                else
                                {
                                    dtNewdtInvDetail = dtInvDetail.Copy();
                                }
                            }
                            try
                            {
                                rptPrintReport cryRpt = new rptPrintReport();
                                cryRpt.Database.Tables[0].SetDataSource(dtInv1);
                                cryRpt.Database.Tables[1].SetDataSource(dtNewdtInvDetail);
                                crystalReportViewer1.ReportSource = cryRpt;
                                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + @"\Export\" + dtInv1.Rows[0]["RefNumber"].ToString() + "_" + dtInv1.Rows[0]["CustomerID"].ToString() + ".pdf");

                                OpenFileDialog ofd = new OpenFileDialog();
                                ofd.InitialDirectory = Application.StartupPath + @"\Export\";
                                ofd.ShowDialog();
                            }
                            catch (Exception ex)
                            {
                                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :btnSaveandClose_Click. Crystal Report Export Message:" + ex.Message);
                            }

                        }
                    }

                }
            }

            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :btnExport_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void ViewCusLog_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex > 0)
            {
                FrmLogDetail f1 = new FrmLogDetail();
                f1.Display(cmbCustomer.SelectedValue.ToString());
                f1.Show();
            }
            else
            {
                MessageBox.Show("No CustomerLog Found");
            }

        }
        private void DisplayMessage(string Text, string Mode)
        {
            switch (Mode)
            {
                case "W":
                    lblErrorMsg.StateCommon.TextColor = Color.FromArgb(16, 6, 244);
                    lblErrorMsg.StateNormal.TextColor = Color.FromArgb(16, 6, 244);
                    lblErrorMsg.Text = Text;
                    break;
                case "I":
                    lblErrorMsg.StateCommon.TextColor = Color.DarkGreen;
                    lblErrorMsg.StateNormal.TextColor = Color.DarkGreen;
                    lblErrorMsg.Text = Text;
                    break;
                case "E":
                    lblErrorMsg.StateCommon.TextColor = Color.DarkRed;
                    lblErrorMsg.StateNormal.TextColor = Color.DarkRed;
                    lblErrorMsg.Text = "Error: " + Text;
                    break;
            }
        }
        public void Display()
        {
            try
            {
                lblErrorMsg.Text = "";
                if (cmbCustomer.SelectedIndex > 0)
                {

                    dgInvDetail.Rows.Clear();
                    DataTable dt = ObjNoteBAL.SelectByCusID(Convert.ToInt32(cmbCustomer.SelectedValue));
                    if (dt.Rows.Count > 0)
                    {
                        pnlnoteDetails.Visible = true;
                        int iRow = 0;
                        foreach (DataRow item in dt.Rows)
                        {
                            if (item["UseOneTime"].ToString() != "")
                            {
                                dgInvDetail.Rows.Add();
                                dgInvDetail[0, iRow].Value = item["ID"].ToString();
                                dgInvDetail[1, iRow].Value = item["CusID"].ToString();
                                dgInvDetail[2, iRow].Value = item["Note"].ToString();
                                dgInvDetail[3, iRow].Value = true;
                                iRow++;
                            }
                            else if (item["UseEveryTime"].ToString() != "")
                            {
                                dgInvDetail.Rows.Add();
                                dgInvDetail[0, iRow].Value = item["ID"].ToString();
                                dgInvDetail[1, iRow].Value = item["CusID"].ToString();
                                dgInvDetail[2, iRow].Value = item["Note"].ToString();
                                dgInvDetail[4, iRow].Value = true;
                                iRow++;
                            }

                        }
                    }
                    else
                    {
                        DisplayMessage("No Notes Found", "E");
                    }
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmNoteDetail,Function :Display. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgInvDetail.Rows.Count > 0)
                {
                    for (int i = 0; i < dgInvDetail.Rows.Count; i++)
                    {
                        if (dgInvDetail.Rows[i].Cells[3].Value != null)
                        {
                            if (dgInvDetail.Rows[i].Cells[3].Value.ToString() == "True")
                            {
                                int id = Convert.ToInt32(dgInvDetail.Rows[i].Cells[0].Value.ToString());
                                ObjNoteBAL.Delete(id);
                            }
                        }
                    }
                }
                pnlnoteDetails.Visible = false;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmNoteDetail,Function :btnClose_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }


        }
        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (dgvInvoice1.Rows.Count > 0)
            {
                for (int i = 0; i < dgvInvoice1.Rows.Count; i++)
                {
                    if (dgvInvoice1.Rows[i].Cells[2].Value != null)
                    {
                        dgvInvoice1.Rows[i].Cells[2].Value = 0;
                        dgvInvoice1.Rows[i].Cells[6].Value = 0;
                    }
                }
                lblTotal.Text = "0";
                lblSubTotal.Text = "0";
                lblTaxPercentage.Text = "(0.0%)";
                lblTaxAmount.Text = "0.00";

                lblPaymentApplied.Text = "0";
                lblBalanceDue.Text = "0";
            }
        }
        private void cmbCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (Mode == "update")
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to change the customer?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        //princy
                        cmbCustomer.SelectedIndex = -1;
                        ((ComboBox)sender).DroppedDown = true;
                    }
                    else
                    {
                        cmbCustomer.Enabled = false;
                    }
                }
                else
                {
                    ((ComboBox)sender).DroppedDown = true;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :cmbCustomer_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void cmbSalesTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaxCalculations();
        }
        //public void TaxCalculations()
        //{
        //    try
        //    {
        //        if (cmbSalesTax.SelectedIndex > 0)
        //        {
        //            DataTable dtItemLoadData = new BALItemMaster().SelectByID(new BOLItemMaster() { ID = Convert.ToInt32(cmbSalesTax.SelectedValue) });
        //            if (dtItemLoadData.Rows.Count > 0)
        //            {
        //                decimal TaxPercentage = Convert.ToDecimal(dtItemLoadData.Rows[0]["SalesTaxPercentage"].ToString());
        //                decimal Total = Convert.ToDecimal(lblTotal.Text);
        //                decimal TaxAmount = 0;
        //                decimal SubTotal = 0;
        //                decimal AppliedBalance = Convert.ToDecimal(lblPaymentApplied.Text);

        //                lblTaxPercentage.Text = "(" + TaxPercentage + "%)";
        //                TaxAmount = Total * TaxPercentage / 100;
        //                lblTaxAmount.Text = decimal.Round(TaxAmount, 2).ToString();
        //                SubTotal = Total + TaxAmount;
        //                lblSubTotal.Text = decimal.Round(SubTotal, 2).ToString();
        //                lblBalanceDue.Text = decimal.Round(SubTotal - AppliedBalance, 2).ToString();
        //            }
        //            else
        //            {
        //                lblBalanceDue.Text = (decimal.Round(Convert.ToDecimal(lblBalanceDue.Text) - Convert.ToDecimal(lblTaxAmount.Text), 2)).ToString();
        //                lblSubTotal.Text = lblTotal.Text;
        //                lblTaxPercentage.Text = "(0.0%)";
        //                lblTaxAmount.Text = "0.00";
        //            }
        //        }
        //        else
        //        {
        //            lblBalanceDue.Text = (decimal.Round(Convert.ToDecimal(lblBalanceDue.Text) - Convert.ToDecimal(lblTaxAmount.Text), 2)).ToString();
        //            lblSubTotal.Text = lblTotal.Text;
        //            lblTaxPercentage.Text = "(0.0%)";
        //            lblTaxAmount.Text = "0.00";
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :TaxCalculations. Message:" + ex.Message);
        //        MessageBox.Show("Error:" + ex.Message);
        //    }
        //}
        public void TaxCalculations()
        {
            try
            {
                decimal Total = 0;
                decimal TaxAmount = 0;
                decimal SubTotal = 0;
                decimal AppliedBalance = Convert.ToDecimal(lblPaymentApplied.Text);
                decimal TaxPercentage = 0;

                if (cmbSalesTax.SelectedIndex > 0)
                {
                    DataTable dtItemLoadData = new BALItemMaster().SelectByID(new BOLItemMaster() { ID = Convert.ToInt32(cmbSalesTax.SelectedValue) });
                    if (dtItemLoadData.Rows.Count > 0)
                    {
                        TaxPercentage = Convert.ToDecimal(dtItemLoadData.Rows[0]["SalesTaxPercentage"].ToString());
                    }
                }

                foreach (DataGridViewRow row in dgvInvoice1.Rows)
                {
                    if (row.Cells["Amount"].Value != null)
                    {
                        decimal itemAmount = Convert.ToDecimal(row.Cells["Amount"].Value);

                        if (row.Cells["Tax"].Value != null && row.Cells["Tax"].Value.ToString() == "Tax")
                        {
                            TaxAmount += (itemAmount * TaxPercentage / 100);
                        }

                        Total += itemAmount;
                    }
                }

                SubTotal = Total + TaxAmount;
                lblTaxPercentage.Text = "(" + TaxPercentage + "%)";
                lblTaxAmount.Text = decimal.Round(TaxAmount, 2).ToString();
                lblSubTotal.Text = decimal.Round(SubTotal, 2).ToString();
                lblBalanceDue.Text = decimal.Round(SubTotal - AppliedBalance, 2).ToString();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster, Function: TaxCalculations. Message: " + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvInvoice1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TaxCalculations();
        }
        private void dgvInvoice1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if the user is leaving the first column (Column Index 0)
                if (e.ColumnIndex == 0)
                {
                    // Skip executing if editing the first column
                    return;
                }

                dgvInvoice1.EndEdit();

                foreach (DataGridViewRow dr in dgvInvoice1.Rows)
                {
                    if (dr.Cells["Tax"]?.Value != null)
                    {
                        // Only update if value has actually changed
                        string currentValue = dr.Cells["TaxCode"]?.Value?.ToString();
                        string newValue = dr.Cells["Tax"].Value.ToString();

                        if (currentValue != newValue)
                        {
                            dr.Cells["TaxCode"].Value = newValue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Optional: Log exception
            }
        }

        private void cmbMsg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //princy 03-04-2025
        private void cmbMsg_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (isLoad == false)
            {
                if (cmbMsg.Text != "" && cmbMsg.Text != "System.Data.DataRowView")
                {

                    if (cmbMsg.Text == "< new Message >")
                    {
                        FrmCustomerMessage CusMSG = new FrmCustomerMessage();
                        CusMSG.ShowDialog();
                        if (ClsCommon.ObjInvoiceMaster.isCustomerMessageFormOpen == true)
                        {
                            isLoad = true;
                            LoadCustomermessage();
                            isLoad = false;
                            if (ClsCommon.ObjInvoiceMaster.LastEditedID != 0)
                            {
                                cmbMsg.SelectedValue = ClsCommon.ObjInvoiceMaster.LastEditedID;
                            }
                            else

                            {
                                DataTable dtMSG = new BALInvoiceMessage().Customermessage_Last();
                                if (dtMSG.Rows.Count > 0)
                                {
                                    cmbMsg.SelectedValue = dtMSG.Rows[0]["ID"].ToString();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void cmbItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;
            ComboBox comboBox = sender as ComboBox;
            string newText = comboBox.Text.Insert(comboBox.SelectionStart, e.KeyChar.ToString());

            if (IsOnlyDigits(newText) || StartsWithDigit(newText))
            {
                e.Handled = true;
            }
        }
        private bool IsOnlyDigits(string input)
        {
            return input.All(char.IsDigit);
        }
        private bool StartsWithDigit(string input)
        {
            return input.Length > 0 && char.IsDigit(input[0]);
        }
        private void cmbItem_Leave(object sender, EventArgs e)
        {
            Boolean ISItemValid = false;
            try
            {
                if (cmbItem.SelectedIndex != 0)
                {
                Top:
                    if (cmbItem.SelectedValue == null || string.IsNullOrWhiteSpace(cmbItem.Text))
                    {
                        DialogResult result = MessageBox.Show("Are You Sure Want to Create a New Item?", "Select Action", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (cmbItem.Text == "" || cmbItem.SelectedValue == null)
                            {
                                string customerName = cmbItem.Text;
                                ClsCommon.ObjItemMaster.ItemNames = customerName;
                                ClsCommon.ObjItemMaster.ItemNameUpdated += ItemNameUpdated;
                                ClsCommon.ObjItemMaster.ShowDialog();
                                goto Top;
                            }
                            else
                            {
                                MessageBox.Show("Please enter a valid Item name.");
                            }
                        }
                        else
                        {
                            ISItemValid = false;
                            //MessageBox.Show("Please Enter Item");
                            cmbItem.SelectedIndex = 0;
                            cmbItem.Focus();
                        }
                    }
                    else if (cmbItem.SelectedIndex <= 0)
                    {
                        //ISItemValid = false;
                        MessageBox.Show("Please select Item first..!!");
                        cmbItem.SelectedIndex = 0;
                        cmbItem.Focus();

                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :CheckValidationForItem. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void cmbItem_Click(object sender, EventArgs e)
        {
            ((ComboBox)sender).DroppedDown = true;
        }
    }

}