using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;


namespace POS
{
    public partial class MDIParent : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALSalesRepMaster ObjUserBAL = new BALSalesRepMaster();
        BOLSalesRepMaster ObjUserBOL = new BOLSalesRepMaster();

        DataTable dt = new DataTable();
        public MDIParent()
        {
            InitializeComponent();
        }
        public void CloseOpenForm()
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Hide();
            }
            this.Text = "SalesPOS";
        }
        private void VisibilityFalse()
        {
            //toolStripMenuItem1.Visible = false;
            paymentAllToolStripMenuItem.Visible = false;
            inActiveCustomerToolStripMenuItem.Visible = false;
            consolePrinterSettingToolStripMenuItem.Visible = false;
            remainderInvoiceReportToolStripMenuItem.Visible = false;
            updatePriceTierToolStripMenuItem.Visible = false;
            customerLogCallToolStripMenuItem1.Visible = false;
            viewInvoiceReportToolStripMenuItem.Visible = false;
            viewPaymentDetailToolStripMenuItem.Visible = false;
            newItemsReportToolStripMenuItem.Visible = false;
            userToolStripMenuItem.Visible = false;
            userTypeListToolStripMenuItem.Visible = false;
            salesRepListToolStripMenuItem.Visible = false;
            invoiceProfitReportToolStripMenuItem.Visible = false;
            //resetPasswordToolStripMenuItem.Visible = false;

            multipleInvoicePrintToolStripMenuItem.Visible = false;
            accessToolStripMenuItem.Visible = false;
            userMenuAccessToolStripMenuItem.Visible = false;
            allUserMenuAccessToolStripMenuItem.Visible = false;
            addNewUserAccessToolStripMenuItem.Visible = false;

            lowestPriceAllowToolStripMenuItem.Visible = false;

            quickbooksToolStripMenuItem.Visible = false;
            qBConfigurationToolStripMenuItem.Visible = false;
            //retriveDataToolStripMenuItem.Visible = false;

            //quickbooksToolStripMenuItem.Visible = false;
            //qBConfigurationToolStripMenuItem.Visible = false;

            AssignedCustomerToolStripMenuItem.Visible = false;
            AssignedcustomerListToolStripMenuItem.Visible = false;

            itemToolStripMenuItem.Visible = false;
            itemListToolStripMenuItem.Visible = false;
            setLowestPriceToolStripMenuItem.Visible = false;
            itemInventoryListToolStripMenuItem.Visible = false;

            customerToolStripMenuItem.Visible = false;
            customerCenterToolStripMenuItem.Visible = false;
            customerCenterToolStripMenuItem.Visible = false;
            UserRequestListToolStripMenuItem.Visible = false;
            adminRequestListToolStripMenuItem.Visible = false;



            invoiceToolStripMenuItem.Visible = false;
            todayUnPrintedInvoiceListToolStripMenuItem.Visible = false;
            invoicePrintHistoryListToolStripMenuItem.Visible = false;
            unShippedInvoiceListToolStripMenuItem1.Visible = false;
            shippedInvoiceListToolStripMenuItem1.Visible = false;
            paypalPaymentListToolStripMenuItem.Visible = false;
            paymentMasterToolStripMenuItem.Visible = false;

            reportToolStripMenuItem.Visible = false;
            itemSaleHistoryToolStripMenuItem.Visible = false;
            customerSaleHistoryToolStripMenuItem.Visible = false;
            paidInvoiceHistoryToolStripMenuItem.Visible = false;
            customerSummaryReportToolStripMenuItem.Visible = false;
            itemSummaryToolStripMenuItem1.Visible = false;
            salesRepSummaryToolStripMenuItem.Visible = false;
            invoiceAuditReportToolStripMenuItem.Visible = false;

            shippingToolStripMenuItem.Visible = false;
            shippingSettingsToolStripMenuItem.Visible = false;

            emailTemplateToolStripMenuItem.Visible = false;
            manualSyncToolStripMenuItem.Visible = false;

            newCustomersToolStripMenuItem.Visible = false;
            manuallySyncPrintToolStripMenuItem.Visible = false;
            qtyOnHandUpdaToolStripMenuItem.Visible = false;
            purchaseCostUpdateToolStripMenuItem.Visible = false;
            salesPriceUpdateToolStripMenuItem.Visible = false;
            priceTierUpdateToolStripMenuItem.Visible = false;
            invoiceProfitDetailsReportToolStripMenuItem.Visible = false;
            comparativePriceUPDATToolStripMenuItem.Visible = false;
            lowestPriceListToolStripMenuItem.Visible = false;
            manualToolStripMenuItem.Visible = false;
            accessTransferToolStripMenuItem.Visible = false;
            creditMemoReportToolStripMenuItem.Visible = false;
            salesRepToolStripMenuItem.Visible = false;
            invoiceEditPermissionToolStripMenuItem.Visible = false;
            //receivePaymentsToolStripMenuItem.Visible = false;
            //createCreditMemoToolStripMenuItem.Visible = false;
            //createInvoiceToolStripMenuItem.Visible = false;
            inActiveCustomersToolStripMenuItem.Visible = false;
            notesReportToolStripMenuItem.Visible = false;
            invoiceIMEINumberToolStripMenuItem.Visible = false;
            customerStatementToolStripMenuItem.Visible = false;
            customerAgingSummaryToolStripMenuItem.Visible = false;
            convertTaxNonTaxInvoiceToolStripMenuItem.Visible = false;
            invoiceUpdateLogsToolStripMenuItem.Visible = false;
            customerLogsToolStripMenuItem.Visible = false;
            createMessageToolStripMenuItem.Visible = false;
        }
        private void VisibilityTrue()
        {
            //toolStripMenuItem1.Visible = true;
            paymentAllToolStripMenuItem.Visible = true;
            inActiveCustomerToolStripMenuItem.Visible = true;
            lowestPriceAllowToolStripMenuItem.Visible = true;
            consolePrinterSettingToolStripMenuItem.Visible = true;
            remainderInvoiceReportToolStripMenuItem.Visible = true;
            updatePriceTierToolStripMenuItem.Visible = true;
            customerLogCallToolStripMenuItem1.Visible = true;
            viewInvoiceReportToolStripMenuItem.Visible = true;
            viewPaymentDetailToolStripMenuItem.Visible = true;
            newItemsReportToolStripMenuItem.Visible = true;
            userToolStripMenuItem.Visible = true;
            userTypeListToolStripMenuItem.Visible = true;
            salesRepListToolStripMenuItem.Visible = true;
            invoiceProfitReportToolStripMenuItem.Visible = true;
            multipleInvoicePrintToolStripMenuItem.Visible = true;
            accessToolStripMenuItem.Visible = true;
            userMenuAccessToolStripMenuItem.Visible = true;
            allUserMenuAccessToolStripMenuItem.Visible = true;
            addNewUserAccessToolStripMenuItem.Visible = true;
            resetPasswordToolStripMenuItem.Visible = true;
            AssignedCustomerToolStripMenuItem.Visible = true;
            AssignedcustomerListToolStripMenuItem.Visible = true;
            quickbooksToolStripMenuItem.Visible = true;
            qBConfigurationToolStripMenuItem.Visible = true;
            //retriveDataToolStripMenuItem.Visible= true;
            AssignedCustomerToolStripMenuItem.Visible = true;
            AssignedcustomerListToolStripMenuItem.Visible = true;
            itemToolStripMenuItem.Visible = true;
            itemListToolStripMenuItem.Visible = true;
            setLowestPriceToolStripMenuItem.Visible = true;
            itemInventoryListToolStripMenuItem.Visible = true;
            customerToolStripMenuItem.Visible = true;
            customerCenterToolStripMenuItem.Visible = true;
            UserRequestListToolStripMenuItem.Visible = true;
            adminRequestListToolStripMenuItem.Visible = true;
            invoiceToolStripMenuItem.Visible = true;
            todayUnPrintedInvoiceListToolStripMenuItem.Visible = true;
            invoicePrintHistoryListToolStripMenuItem.Visible = true;
            unShippedInvoiceListToolStripMenuItem1.Visible = true;
            shippedInvoiceListToolStripMenuItem1.Visible = true;
            paypalPaymentListToolStripMenuItem.Visible = true;
            paymentMasterToolStripMenuItem.Visible = true;
            reportToolStripMenuItem.Visible = true;
            itemSaleHistoryToolStripMenuItem.Visible = true;
            customerSaleHistoryToolStripMenuItem.Visible = true;
            paidInvoiceHistoryToolStripMenuItem.Visible = true;
            customerSummaryReportToolStripMenuItem.Visible = true;
            itemSummaryToolStripMenuItem1.Visible = true;
            salesRepSummaryToolStripMenuItem.Visible = true;
            invoiceAuditReportToolStripMenuItem.Visible = true;
            shippingToolStripMenuItem.Visible = true;
            shippingSettingsToolStripMenuItem.Visible = true;
            emailTemplateToolStripMenuItem.Visible = true;
            manualSyncToolStripMenuItem.Visible = true;
            newCustomersToolStripMenuItem.Visible = true;
            manuallySyncPrintToolStripMenuItem.Visible = true;
            qtyOnHandUpdaToolStripMenuItem.Visible = true;
            purchaseCostUpdateToolStripMenuItem.Visible = true;
            salesPriceUpdateToolStripMenuItem.Visible = true;
            priceTierUpdateToolStripMenuItem.Visible = true;
            invoiceProfitDetailsReportToolStripMenuItem.Visible = true;
            comparativePriceUPDATToolStripMenuItem.Visible = true;
            lowestPriceListToolStripMenuItem.Visible = true;
            manualToolStripMenuItem.Visible = true;
            accessTransferToolStripMenuItem.Visible = true;
            creditMemoReportToolStripMenuItem.Visible = true;
            salesRepToolStripMenuItem.Visible = true;
            invoiceEditPermissionToolStripMenuItem.Visible = true;
            receivePaymentsToolStripMenuItem.Visible = true;
            createInvoiceToolStripMenuItem.Visible = true;
            createCreditMemoToolStripMenuItem.Visible = true;
            inActiveCustomersToolStripMenuItem.Visible = true;
            notesReportToolStripMenuItem.Visible = true;
            invoiceIMEINumberToolStripMenuItem.Visible = true;
            customerStatementToolStripMenuItem.Visible = true;
            customerAgingSummaryToolStripMenuItem.Visible = true;
            convertTaxNonTaxInvoiceToolStripMenuItem.Visible = true;
            invoiceUpdateLogsToolStripMenuItem.Visible = true;
            customerLogsToolStripMenuItem.Visible = true;
            createMessageToolStripMenuItem.Visible = true;
        }
        private void MDIParent_Load(object sender, EventArgs e)
        {
            try
            {
                Timer MyTimer = new Timer();
                // MyTimer.Interval = (45 * 60 * 1000); // 45 mins
                MyTimer.Interval = (45 * 60 * 5); // 45 mins
                MyTimer.Tick += new EventHandler(MyTimer_Tick);
                MyTimer.Start();

                this.Text = "SalesPOS";

                lblReminders.Visible = false;
                btnMessage.FlatStyle = FlatStyle.Flat;
                btnMessage.FlatAppearance.BorderSize = 0;

                btnMessageCount.Visible = false;
                this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                btnMessageCount.Location = new Point(Size.Width - 95, Size.Height - 150);
                btnMessage.Location = new Point(Size.Width - 120, Size.Height - 140);
                lblReminders.Location = new Point(Size.Width - 60, 1);
                btnMessageCount.Width = 35;
                btnMessageCount.Height = 35;
                GraphicsPath p = new GraphicsPath();
                p.AddEllipse(4, 4, btnMessageCount.Width - 8, btnMessageCount.Height - 8);
                btnMessageCount.Region = new Region(p);

                foreach (Control control in this.Controls)
                {
                    MdiClient client = control as MdiClient;
                    if (!(client == null))
                    {
                        client.BackColor = System.Drawing.Color.White;
                        break;
                    }
                }
                VisibilityFalse();
                //ClsCommon.UserType = "Admin";

                FrmLogin oLogin = new FrmLogin();
                oLogin.ShowDialog();

                lblReminders.Visible = true;
                btnMessageCount.Visible = true;
                btnMessage.Visible = true;
                if (ClsCommon.UserType == "Admin")
                {
                    RequestCount();
                    if (ClsCommon.objChat != null)
                    {
                        btnMessageCount.Text = ClsCommon.objChat.MessageCount();
                    }
                    else
                        btnMessageCount.Text = "0";
                    VisibilityTrue();
                    FrmLastWeekSalesData obj = new FrmLastWeekSalesData();
                    obj.MdiParent = this;
                    panel1.Controls.Add(obj);
                    obj.Show();

                    dt = new BALCustomerRequest().SelectByDate(new BOLCustomerRequest() { CreatedTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")) });
                    if (dt.Rows.Count > 0)
                    {
                        ClsCommon.objRequestCount.MdiParent = this;
                        panel1.Controls.Add(ClsCommon.objRequestCount);
                        ClsCommon.objRequestCount.Show();
                        ClsCommon.objRequestCount.BringToFront();
                        ClsCommon.objRequestCount.LoadData();
                    }

                    DataTable dtCreditMemo = new DataTable();
                    dtCreditMemo = new BALCreditMemoRequest().SelectByDate(new BOLCreditMemoRequest() { CreatedTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")) });
                    if (dtCreditMemo.Rows.Count > 0)
                    {
                        ClsCommon.objCreditMemoRequest.MdiParent = this;
                        panel1.Controls.Add(ClsCommon.objCreditMemoRequest);
                        ClsCommon.objCreditMemoRequest.Show();
                        ClsCommon.objCreditMemoRequest.BringToFront();
                        //ClsCommon.objCreditMemoRequest.LoadData();
                    }
                    //DataTable EditedInvoice = new BALEditedInvoice().SELECT(new BOLEditedInvoice() { Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()) });
                    //if(EditedInvoice.Rows.Count > 0)
                    //{
                    //    ClsCommon.objEditedInvoiceDetails.MdiParent = this;
                    //    panel1.Controls.Add(ClsCommon.objEditedInvoiceDetails);
                    //    ClsCommon.objEditedInvoiceDetails.Show();
                    //    ClsCommon.objEditedInvoiceDetails.BringToFront();
                    //}
                    //DataTable Ship = new BALShipRequest().SELECTBYDate(new BOLShipRequest() { Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()) });
                    //if (Ship.Rows.Count > 0)
                    //{
                    //    ClsCommon.objShipRequestPermission.MdiParent = this;
                    //    panel1.Controls.Add(ClsCommon.objShipRequestPermission);
                    //    ClsCommon.objShipRequestPermission.Show();
                    //    ClsCommon.objShipRequestPermission.BringToFront();
                    //}
                }
                else if (ClsCommon.UserType != "")
                    GetAccess();

                this.Text = "SalesPOS - " + ClsCommon.UserName;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:MDIParent,Function :MDIParent_Load. Message:" + ex.Message);
            }
        }
        private void MyTimer_Tick(object sender, EventArgs e)
        {
            if (ClsCommon.UserType == "Admin")
            {
                ShowsForm();
            }
        }
        private void GetAccess()
        {
            try
            {
                RequestCount(); btnMessageCount.Text = ClsCommon.objChat.MessageCount();
                VisibilityFalse();
                DataTable dtAccess = new BALUserMenuAccess().SelectForAccess(new BOLUserMenuAccess() { UserID = Convert.ToInt32(ClsCommon.UserID) });

                if (dtAccess.Rows.Count > 0)
                {
                    for (int i = 0; i < dtAccess.Rows.Count; i++)
                    {
                        switch (Convert.ToString(dtAccess.Rows[i]["MenuName"].ToString()))
                        {
                            case "UserProfitReport":
                                reportToolStripMenuItem.Visible = true;
                                invoiceProfitReportToolStripMenuItem.Visible = true;
                                break;

                            case "inActiveCustomers":
                                reportToolStripMenuItem.Visible = true;
                                inActiveCustomersToolStripMenuItem.Visible = true;
                                break;

                            case "customerStatement":
                                reportToolStripMenuItem.Visible = true;
                                customerStatementToolStripMenuItem.Visible = true;
                                break;

                            case "notesReport":
                                reportToolStripMenuItem.Visible = true;
                                notesReportToolStripMenuItem.Visible = true;
                                break;

                            case "invoiceIMEINumber":
                                reportToolStripMenuItem.Visible = true;
                                invoiceIMEINumberToolStripMenuItem.Visible = true;
                                break;

                            case "UserTypeList":
                                userToolStripMenuItem.Visible = true;
                                userTypeListToolStripMenuItem.Visible = true;
                                break;


                            case "Remainder Invoice Report":
                                reportToolStripMenuItem.Visible = true;
                                remainderInvoiceReportToolStripMenuItem.Visible = true;
                                break;

                            case "ViewInActiveCustomer":
                                inActiveCustomerToolStripMenuItem.Visible = true;
                                customerToolStripMenuItem.Visible = true;
                                break;

                            case "UpdatePriceTier":
                                updatePriceTierToolStripMenuItem.Visible = true;
                                break;

                            case "View Invoice Report":
                                reportToolStripMenuItem.Visible = true;
                                viewInvoiceReportToolStripMenuItem.Visible = true;
                                break;

                            case "Add Log":
                                customerLogCallToolStripMenuItem1.Visible = true;
                                break;

                            case "View Payment Detail":
                                invoiceToolStripMenuItem.Visible = true;
                                viewPaymentDetailToolStripMenuItem.Visible = true;
                                break;

                            case "MultipleInvoicePrint":
                                invoiceToolStripMenuItem.Visible = true;
                                multipleInvoicePrintToolStripMenuItem.Visible = true;
                                break;

                            case "SalesRepList":
                                userToolStripMenuItem.Visible = true;
                                salesRepListToolStripMenuItem.Visible = true;
                                break;

                            case "AllUserAccess":
                                accessToolStripMenuItem.Visible = true;
                                userMenuAccessToolStripMenuItem.Visible = true;
                                allUserMenuAccessToolStripMenuItem.Visible = true;
                                break;

                            case "AddNewUserAccess":
                                accessToolStripMenuItem.Visible = true;
                                userMenuAccessToolStripMenuItem.Visible = true;
                                addNewUserAccessToolStripMenuItem.Visible = true;
                                break;

                            case "AssignedCustomerList":
                                AssignedCustomerToolStripMenuItem.Visible = true;
                                AssignedcustomerListToolStripMenuItem.Visible = true;
                                break;

                            case "ItemList":
                                itemToolStripMenuItem.Visible = true;
                                itemListToolStripMenuItem.Visible = true;
                                break;

                            case "SetLowestPrice":
                                itemToolStripMenuItem.Visible = true;
                                setLowestPriceToolStripMenuItem.Visible = true;
                                break;

                            case "CustomerCenter":
                                customerToolStripMenuItem.Visible = true;
                                customerCenterToolStripMenuItem.Visible = true;
                                break;

                            case "Receive Payment":
                                invoiceToolStripMenuItem.Visible = true;
                                paymentMasterToolStripMenuItem.Visible = true;
                                break;

                            case "UserRequestlist":
                                customerToolStripMenuItem.Visible = true;
                                UserRequestListToolStripMenuItem.Visible = true;
                                break;

                            case "AdminRequestList":
                                customerToolStripMenuItem.Visible = true;
                                adminRequestListToolStripMenuItem.Visible = true;
                                break;

                            //case "QBConfiguration":
                            //    quickbooksToolStripMenuItem.Visible = false;
                            //    qBConfigurationToolStripMenuItem.Visible = false;
                            //    break;

                            case "QBConfiguration":
                                quickbooksToolStripMenuItem.Visible = true;
                                qBConfigurationToolStripMenuItem.Visible = true;
                                break;

                            //case "GetQBData":
                            //    quickbooksToolStripMenuItem.Visible = true;
                            //    retriveDataToolStripMenuItem.Visible = true;
                            //    break;

                            case "ItemSaleHistory":
                                reportToolStripMenuItem.Visible = true;
                                itemSaleHistoryToolStripMenuItem.Visible = true;
                                break;

                            case "CustomerSaleHistory":
                                reportToolStripMenuItem.Visible = true;
                                customerSaleHistoryToolStripMenuItem.Visible = true;
                                break;

                            case "UnShippedInvoiceHistory":
                                shippingToolStripMenuItem.Visible = true;
                                unShippedInvoiceListToolStripMenuItem1.Visible = true;
                                break;

                            case "ShippedInvoiceHistory":
                                shippingToolStripMenuItem.Visible = true;
                                shippedInvoiceListToolStripMenuItem1.Visible = true;
                                break;

                            case "FedExAndUPSShipping":
                                shippingToolStripMenuItem.Visible = true;
                                shippingSettingsToolStripMenuItem.Visible = true;
                                break;

                            case "TrackingInfoMaster":
                                shippingToolStripMenuItem.Visible = true;
                                salesRepListToolStripMenuItem.Visible = true;
                                break;

                            case "ItemInventoryList":
                                itemToolStripMenuItem.Visible = true;
                                itemInventoryListToolStripMenuItem.Visible = true;
                                break;

                            case "PaidInvoiceHistory":
                                reportToolStripMenuItem.Visible = true;
                                paidInvoiceHistoryToolStripMenuItem.Visible = true;
                                break;

                            case "CustomerSummary":
                                reportToolStripMenuItem.Visible = true;
                                customerSummaryReportToolStripMenuItem.Visible = true;
                                break;

                            case "ItemSummary":
                                itemToolStripMenuItem.Visible = true;
                                itemSummaryToolStripMenuItem1.Visible = true;
                                break;

                            case "SalesRepSummary":
                                reportToolStripMenuItem.Visible = true;
                                salesRepSummaryToolStripMenuItem.Visible = true;
                                break;

                            case "InvoiceEditHistory":
                                reportToolStripMenuItem.Visible = true;
                                invoiceAuditReportToolStripMenuItem.Visible = true;
                                break;

                            case "TodayUnPrintedInvoiceList":
                                invoiceToolStripMenuItem.Visible = true;
                                todayUnPrintedInvoiceListToolStripMenuItem.Visible = true;
                                break;

                            case "PaypalPaymentList":
                                invoiceToolStripMenuItem.Visible = true;
                                paypalPaymentListToolStripMenuItem.Visible = true;
                                break;

                            case "InvoicePrintHistory":
                                invoiceToolStripMenuItem.Visible = true;
                                invoicePrintHistoryListToolStripMenuItem.Visible = true;
                                break;

                            case "EmailTemplate":
                                emailTemplateToolStripMenuItem.Visible = true;
                                break;

                            case "NewCustomers":
                                reportToolStripMenuItem.Visible = true;
                                newCustomersToolStripMenuItem.Visible = true;
                                break;

                            case "NewItems":
                                itemToolStripMenuItem.Visible = true;
                                newItemsReportToolStripMenuItem.Visible = true;
                                break;
                            case "PaymentAll":
                                invoiceToolStripMenuItem.Visible = true;
                                paymentAllToolStripMenuItem.Visible = true;
                                break;
                            case "QtyOnHandList":
                                itemToolStripMenuItem.Visible = true;
                                qtyOnHandUpdaToolStripMenuItem.Visible = true;
                                break;
                            case "PurchaseCostList":
                                itemToolStripMenuItem.Visible = true;
                                purchaseCostUpdateToolStripMenuItem.Visible = true;
                                break;
                            case "SalesPriceList":
                                itemToolStripMenuItem.Visible = true;
                                salesPriceUpdateToolStripMenuItem.Visible = true;
                                break;
                            case "PriceTierList":
                                itemToolStripMenuItem.Visible = true;
                                priceTierUpdateToolStripMenuItem.Visible = true;
                                break;
                            case "InvoiceProfitDetailsReport":
                                reportToolStripMenuItem.Visible = true;
                                invoiceProfitDetailsReportToolStripMenuItem.Visible = true;
                                break;
                            case "ComparativePrice":
                                itemToolStripMenuItem.Visible = true;
                                comparativePriceUPDATToolStripMenuItem.Visible = true;
                                break;
                            case "LowestPriceListRequest":
                                customerToolStripMenuItem.Visible = true;
                                lowestPriceListToolStripMenuItem.Visible = true;
                                break;
                            case "ManualSync":
                                manualToolStripMenuItem.Visible = true;
                                manualSyncToolStripMenuItem.Visible = true;
                                break;
                            case "ManuallySyncPrint":
                                manualToolStripMenuItem.Visible = true;
                                manuallySyncPrintToolStripMenuItem.Visible = true;
                                break;
                            case "AccessTransfer":
                                accessToolStripMenuItem.Visible = true;
                                userMenuAccessToolStripMenuItem.Visible = true;
                                accessTransferToolStripMenuItem.Visible = true;
                                break;
                            case "CreditMemoAuditReport":
                                reportToolStripMenuItem.Visible = true;
                                creditMemoReportToolStripMenuItem.Visible = true;
                                break;
                            case "SalesRepSummaryCreditMemo":
                                reportToolStripMenuItem.Visible = true;
                                salesRepToolStripMenuItem.Visible = true;
                                break;
                            case "CusCenCreateInvoice":
                                customerToolStripMenuItem.Visible = true;
                                customerCenterToolStripMenuItem.Visible = true;
                                createInvoiceToolStripMenuItem.Visible = true;
                                break;
                            case "CusCenCreateCreditMemo":
                                customerToolStripMenuItem.Visible = true;
                                customerCenterToolStripMenuItem.Visible = true;
                                createCreditMemoToolStripMenuItem.Visible = true;
                                break;

                            case "ReceivePayments":
                                customerToolStripMenuItem.Visible = true;
                                customerCenterToolStripMenuItem.Visible = true;
                                receivePaymentsToolStripMenuItem.Visible = true;
                                break;

                            case "AgingReport":
                                reportToolStripMenuItem.Visible = true;
                                customerAgingSummaryToolStripMenuItem.Visible = true;
                                break;
                            case "Tax-NonTax":
                                invoiceToolStripMenuItem.Visible = true;
                                convertTaxNonTaxInvoiceToolStripMenuItem.Visible = true;
                                break;
                            case "CustomerLogsReports":
                                reportToolStripMenuItem.Visible = true;
                                customerLogsToolStripMenuItem.Visible = true;
                                break;

                            case "InvoiceLogsReports":
                                reportToolStripMenuItem.Visible = true;
                                invoiceUpdateLogsToolStripMenuItem.Visible = true;
                                break;

                            case "CustomerMessage":
                                customerToolStripMenuItem.Visible = true;
                                createMessageToolStripMenuItem.Visible = true;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:MDIParent,Function :GetAccess. Message:" + ex.Message);
            }
        }
        //User TypeList
        private void UserTypeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.ObjUserTypeList.MdiParent = this;
            panel1.Controls.Add(ClsCommon.ObjUserTypeList);
            ClsCommon.ObjUserTypeList.Show();
            ClsCommon.ObjUserTypeList.BringToFront();
        }
        //SalesRep List
        private void SalesRepListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.ObjSalesRepList.MdiParent = this;
            panel1.Controls.Add(ClsCommon.ObjSalesRepList);
            ClsCommon.ObjSalesRepList.Show();
            ClsCommon.ObjSalesRepList.LoadFunction();
            ClsCommon.ObjSalesRepList.BringToFront();
        }
        //UserAccess List
        private void allUserMenuAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserMenuAccessList Obj = new FrmUserMenuAccessList();
            Obj.MdiParent = this;
            panel1.Controls.Add(Obj);
            Obj.Show();
            Obj.BringToFront();
        }
        // New UserAccess Add
        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserAccess Obj = new FrmUserAccess();
            Obj.MdiParent = this;
            panel1.Controls.Add(Obj);
            Obj.Show();
            Obj.BringToFront();
        }
        // Customer Assigned List
        private void customerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCustomerAssignedTransfer Obj = new FrmCustomerAssignedTransfer();
            Obj.MdiParent = this;
            panel1.Controls.Add(Obj);
            Obj.Show();
            Obj.BringToFront();
        }
        //Item List
        private void itemListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.ObjItemList.MdiParent = this;
            panel1.Controls.Add(ClsCommon.ObjItemList);
            ClsCommon.ObjItemList.Show();
            ClsCommon.ObjItemList.BringToFront();
            ClsCommon.ObjItemList.LoadItem();

        }
        //Customer Center
        private void customerCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.ObjCustomerCenter.MdiParent = this;
            panel1.Controls.Add(ClsCommon.ObjCustomerCenter);
            ClsCommon.ObjCustomerCenter.Show();
            ClsCommon.ObjCustomerCenter.LoadFunction();
            ClsCommon.ObjCustomerCenter.BringToFront();
            ClsCommon.ObjInvoiceMaster.LoadFunction();
            ClsCommon.ObjCustomerCenter.Clear();
        }
        //Lowest Price List
        private void setLowestPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.ObjLowestPriceItemList.MdiParent = this;
            panel1.Controls.Add(ClsCommon.ObjLowestPriceItemList);
            ClsCommon.ObjLowestPriceItemList.Show();
            ClsCommon.ObjLowestPriceItemList.BringToFront();
        }
        //Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Update IsLogin in SalesRepMaster
            ObjUserBOL.ID = ClsCommon.UserID;
            ObjUserBOL.IsLogin = 0;
            ObjUserBAL.UpdateIsLogin(ObjUserBOL);

            Environment.Exit(0);
            //Application.Exit();
        }
        //User Request List
        private void requestListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCustomerRequestList Obj = new FrmCustomerRequestList();
            Obj.MdiParent = this;
            panel1.Controls.Add(Obj);
            Obj.Show();
            Obj.BringToFront();
        }
        //Admin Request List
        private void adminRequestListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.ObjAdminRequestList.MdiParent = this;
            panel1.Controls.Add(ClsCommon.ObjAdminRequestList);
            ClsCommon.ObjAdminRequestList.Show();
            ClsCommon.ObjAdminRequestList.LoadFunction();
            ClsCommon.ObjAdminRequestList.BringToFront();
        }
        // QB Configuration
        private void qBConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQBConfiguration Obj = new FrmQBConfiguration();
            Obj.MdiParent = this;
            panel1.Controls.Add(Obj);
            Obj.Show();
            Obj.BringToFront();
        }
        //Request Count
        private void lblReminders_Click(object sender, EventArgs e)
        {
            ClsCommon.objRequestCount.MdiParent = this;
            panel1.Controls.Add(ClsCommon.objRequestCount);
            ClsCommon.objRequestCount.Show();
            ClsCommon.objRequestCount.BringToFront();
            ClsCommon.objRequestCount.LoadData();

        }
        //ItemSale History
        private void itemSaleHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmItemSaleHistoryReport obj = new FrmItemSaleHistoryReport();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        //Customer Sale History
        private void customerSaleHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCustomerNotBoughtReport obj = new FrmCustomerNotBoughtReport();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        //Item Inventory List
        private void itemInventoryListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmItemInventoryList obj = new FrmItemInventoryList();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        //Shipping Settings
        private void shippingSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.objShippingOptions.MdiParent = this;
            panel1.Controls.Add(ClsCommon.objShippingOptions);
            ClsCommon.objShippingOptions.Show();
            ClsCommon.objShippingOptions.BringToFront();
        }
        //PaidInvoice History
        private void paidInvoiceHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPaidInvoiceReport obj = new FrmPaidInvoiceReport();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        //Customer Summary
        private void customerSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCustomerSummaryReport obj = new FrmCustomerSummaryReport();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        //Item Summary
        private void itemSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmItemSummaryReport obj = new FrmItemSummaryReport();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        // SalesRep Summary
        private void salesRepSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSalesRepSummaryReport obj = new FrmSalesRepSummaryReport();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        //Invoice Audit
        private void invoiceAuditReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInvoiceAuditReport obj = new FrmInvoiceAuditReport();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        //Today UnPrinted Invoice List
        private void todayUnPrintedInvoiceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.objTodayInvoice.MdiParent = this;
            panel1.Controls.Add(ClsCommon.objTodayInvoice);
            ClsCommon.objTodayInvoice.Show();
            ClsCommon.objTodayInvoice.BringToFront();
            ClsCommon.objTodayInvoice.LoadFunction();

        }
        //Invoice Print history List
        private void invoicePrintHistoryListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInvoicePrintHistoryList obj = new FrmInvoicePrintHistoryList();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        //Email template
        private void emailTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.ObjEmailFormatList.MdiParent = this;
            panel1.Controls.Add(ClsCommon.ObjEmailFormatList);
            ClsCommon.ObjEmailFormatList.Show();
            ClsCommon.ObjEmailFormatList.BringToFront();
            ClsCommon.ObjEmailFormatList.LoadFunction();
        }
        private void RequestCount()
        {
            try
            {
                if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                {
                    DataTable dtPending = new BALCustomerRequest().SelectAdminPendingRequestCount(new BOLCustomerRequest() { });
                    if (dtPending.Rows.Count > 0)
                        lblReminders.Text = dtPending.Rows.Count.ToString();
                    else
                        lblReminders.Text = "0";
                }
                else
                {
                    DataTable dtApproved = new BALCustomerRequest().SelectByApproveCount(new BOLCustomerRequest() { SalesRepID = ClsCommon.UserID });
                    if (dtApproved.Rows.Count > 0)
                        lblReminders.Text = dtApproved.Rows.Count.ToString();
                    else
                        lblReminders.Text = "0";
                }
                ClsCommon.objRequestCount.LoadData();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmMDIParent, Function :RequestCount. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            // Update IsLogin in SalesRepMaster
            ObjUserBOL.ID = ClsCommon.UserID;
            ObjUserBOL.IsLogin = 0;
            ObjUserBAL.UpdateIsLogin(ObjUserBOL);

            ClsCommon.UserID = 0;
            ClsCommon.UserType = "";
            ClsCommon.UserName = "";
            VisibilityFalse();
            CloseOpenForm();
            FrmLogin oLogin = new FrmLogin();
            oLogin.ShowDialog();
            if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
            {
                VisibilityTrue();
                FrmLastWeekSalesData obj = new FrmLastWeekSalesData();
                obj.MdiParent = this;
                panel1.Controls.Add(obj);
                obj.Show();

                dt = new BALCustomerRequest().SelectByDate(new BOLCustomerRequest() { CreatedTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")) });
                if (dt.Rows.Count > 0)
                {
                    ClsCommon.objRequestCount.MdiParent = this;
                    panel1.Controls.Add(ClsCommon.objRequestCount);
                    ClsCommon.objRequestCount.Show();
                    ClsCommon.objRequestCount.BringToFront();
                    ClsCommon.objRequestCount.LoadData();
                }
                DataTable dtCreditMemo = new DataTable();
                dtCreditMemo = new BALCreditMemoRequest().SelectByDate(new BOLCreditMemoRequest() { CreatedTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")) });
                if (dtCreditMemo.Rows.Count > 0)
                {
                    ClsCommon.objCreditMemoRequest.MdiParent = this;
                    panel1.Controls.Add(ClsCommon.objCreditMemoRequest);
                    ClsCommon.objCreditMemoRequest.Show();
                    ClsCommon.objCreditMemoRequest.BringToFront();
                    //ClsCommon.objCreditMemoRequest.LoadData();
                }
                //DataTable EditedInvoice = new BALEditedInvoice().SELECT(new BOLEditedInvoice() { Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()) });
                //if (EditedInvoice.Rows.Count > 0)
                //{
                //    ClsCommon.objEditedInvoiceDetails.MdiParent = this;
                //    panel1.Controls.Add(ClsCommon.objEditedInvoiceDetails);
                //    ClsCommon.objEditedInvoiceDetails.Show();
                //    ClsCommon.objEditedInvoiceDetails.BringToFront();
                //}
                //DataTable Ship = new BALShipRequest().SELECTBYDate(new BOLShipRequest() { Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()) });
                //if (Ship.Rows.Count > 0)
                //{
                //    ClsCommon.objShipRequestPermission.MdiParent = this;
                //    panel1.Controls.Add(ClsCommon.objShipRequestPermission);
                //    ClsCommon.objShipRequestPermission.Show();
                //    ClsCommon.objShipRequestPermission.BringToFront();
                //}
            }
            else if (ClsCommon.UserType != "")
                GetAccess();

            this.Text = "SalesPOS - " + ClsCommon.UserName;
            RequestCount();
            btnMessageCount.Text = ClsCommon.objChat.MessageCount();
        }
        private void btnMessage_Click(object sender, EventArgs e)
        {
            panel1.Controls.Add(ClsCommon.objChat);
            ClsCommon.objChat.Show();
            ClsCommon.objChat.LoadFunction();
        }
        private void contextMenuStrip1_btnMessageClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem.Text != "")
                {
                    if (e.ClickedItem.Text == "Group Announcement")
                    {
                        DataTable dt = new BALChatMaster().SelectGroupMessage(new BOLChatMaster() { ReceiverID = ClsCommon.UserID });
                        if (dt.Rows.Count > 0)
                        {
                            ClsCommon.objChat.StartPosition = FormStartPosition.CenterScreen;
                            ClsCommon.objChat.LoadGroupMessage(Convert.ToInt32(dt.Rows[0]["SenderID"].ToString()), dt.Rows[0]["SalesRepName"].ToString());
                            panel1.Controls.Add(ClsCommon.objChat);
                            ClsCommon.objChat.Show();
                            btnMessageCount.Text = ClsCommon.objChat.MessageCount();
                        }
                    }
                    else
                    {
                        DataTable dt = new BALSalesRepMaster().SelectByName(new BOLSalesRepMaster() { Name = e.ClickedItem.Text.Trim() });
                        if (dt.Rows.Count > 0)
                        {
                            ClsCommon.objChat.StartPosition = FormStartPosition.CenterScreen;
                            ClsCommon.objChat.ListMessageVisibility();
                            ClsCommon.objChat.LoadData(Convert.ToInt32(dt.Rows[0]["ID"].ToString()), e.ClickedItem.Text.Trim());
                            panel1.Controls.Add(ClsCommon.objChat);
                            ClsCommon.objChat.Show();
                            btnMessageCount.Text = ClsCommon.objChat.MessageCount();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmMDIParent,Function :contextMenuStrip1_btnMessageClicked. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.objChat != null)
                {
                    btnMessageCount.Text = ClsCommon.objChat.MessageCount();
                    if (Convert.ToInt64(btnMessageCount.Text) > 0)
                    {
                        if (btnMessageCount.BackColor == Color.Red)
                            btnMessageCount.BackColor = Color.Black;
                        else if (btnMessageCount.BackColor == Color.Black)
                            btnMessageCount.BackColor = Color.Red;
                    }
                    else
                        btnMessageCount.BackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: MDIParent, Method: timer_Tick. Message" + ex.Message);
                MessageBox.Show("Message: " + ex.Message);
            }
        }
        private void btnMessageCount_Click(object sender, EventArgs e)
        {
            try
            {
                ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
                contextMenuStrip1.Items.Clear();
                DataTable dtChat = new BALChatMaster().SelectTotalMessageByName(new BOLChatMaster() { ReceiverID = ClsCommon.UserID });
                if (dtChat.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtChat.Rows)
                    {
                        if (dr["GroupMessage"].ToString() == "1")
                        {
                            contextMenuStrip1.Items.Add("Group Announcement");
                            //if (Convert.ToInt32(dr["Count"].ToString()) > 1)
                            //{
                            //    for(int i = 0; i < Convert.ToInt32(dr["Count"].ToString()); i++)
                            //    {
                            //        contextMenuStrip1.Items.Add("Group Announcement");
                            //    }
                            //}
                        }
                        else
                            contextMenuStrip1.Items.Add(dr["SenderName"].ToString());
                    }
                }
                //contextMenuStrip1.Show(btnMessage, new Point(0, btnMessage.Left));
                contextMenuStrip1.Show(this, btnMessageCount.Location, ToolStripDropDownDirection.AboveRight);
                contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenuStrip1_btnMessageClicked);
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: MDIParent, Method: btnMessageCount_Click. Message" + ex.Message);
                MessageBox.Show("Message: " + ex.Message);
            }
        }
        private void MDIParent_FormClosing(object sender, FormClosingEventArgs e)
        {
            ObjUserBOL.ID = ClsCommon.UserID;
            ObjUserBOL.IsLogin = 0;
            ObjUserBAL.UpdateIsLogin(ObjUserBOL);
        }
        //UnShipped Invoice History
        //private void unShippedInvoiceListToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    ClsCommon.ObjUnShippedInvList.MdiParent = this;
        //    panel1.Controls.Add(ClsCommon.ObjUnShippedInvList);
        //    ClsCommon.ObjUnShippedInvList.Show();
        //    ClsCommon.ObjUnShippedInvList.BringToFront();
        //    ClsCommon.ObjUnShippedInvList.LoadUnShippedInvoice();
        //}

        //private void shippedInvoiceListToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    FrmShippedInvoiceList obj = new FrmShippedInvoiceList();
        //    obj.MdiParent = this;
        //    panel1.Controls.Add(obj);
        //    obj.Show();
        //    obj.BringToFront();
        //}

        //Paypal Payment List
        private void paypalPaymentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.FrmPayPalHistoryMaster.Show();
            ClsCommon.FrmPayPalHistoryMaster.BringToFront();
            ClsCommon.FrmPayPalHistoryMaster.visiblefalse();
            //FrmPaypalPaymentList obj = new FrmPaypalPaymentList();
            //obj.MdiParent = this;
            //panel1.Controls.Add(obj);
            //obj.Show();
            //obj.BringToFront();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                RequestCount();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: MDIParent, Method: timer2_Tick. Message" + ex.Message);
                MessageBox.Show("Message: " + ex.Message);
            }
        }
        //private void manualSyncToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    DataTable dt = new BALUserRequest().Select();
        //    if (dt.Rows.Count == 0)
        //    {
        //        new BALUserRequest().Insert(ClsCommon.UserID);
        //        MessageBox.Show("Request Create successfully..!!");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Already one request in pending...!!");
        //    }
        //}
        private void inActiveCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInActiveCustomerReport obj = new FrmInActiveCustomerReport();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        private void paypalConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmPaypalConfig obj = new FrmPaypalConfig();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        private void newCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewCustomerReport obj = new FrmNewCustomerReport();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        private void trackingInfoMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ClsCommon.objTrack.displaydata();
            ClsCommon.objTrack.MdiParent = this;
            panel1.Controls.Add(ClsCommon.objTrack);
            ClsCommon.objTrack.Show();
            ClsCommon.objTrack.BringToFront();
            ClsCommon.objTrack.Clear();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void resetPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.objPassword.Show();
            ClsCommon.objPassword.BringToFront();
            ClsCommon.objPassword.LoadData();
        }
        private void userMenuAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void paymentMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.objPaymentMaster.MdiParent = this;
            panel1.Controls.Add(ClsCommon.objPaymentMaster);
            ClsCommon.objPaymentMaster.Show();
            ClsCommon.objPaymentMaster.BringToFront();
        }
        private void invoiceProfitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.objInvoiceProfit.MdiParent = this;
            panel1.Controls.Add(ClsCommon.objInvoiceProfit);
            ClsCommon.objInvoiceProfit.Show();
            ClsCommon.objInvoiceProfit.BringToFront();
            ClsCommon.objInvoiceProfit.Clear();
        }
        private void multipleInvoicePrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.objPrintInvoice.MdiParent = this;
            panel1.Controls.Add(ClsCommon.objPrintInvoice);
            ClsCommon.objPrintInvoice.Show();
            ClsCommon.objPrintInvoice.BringToFront();
            ClsCommon.objPrintInvoice.Clear();
        }
        private void itemItemsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewItemReport obj = new FrmNewItemReport();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        private void viewPaymentDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.objViewDetail.MdiParent = this;
            panel1.Controls.Add(ClsCommon.objViewDetail);
            ClsCommon.objViewDetail.Show();
            ClsCommon.objViewDetail.BringToFront();
            ClsCommon.objViewDetail.Clear();
        }
        private void customerLogCallToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClsCommon.objCus.MdiParent = this;
            panel1.Controls.Add(ClsCommon.objCus);
            ClsCommon.objCus.GetCustomer();
            ClsCommon.objCus.displaydata();
            ClsCommon.objCus.ResetData();
            ClsCommon.objCus.Show();
            ClsCommon.objCus.BringToFront();
        }
        private void viewInvoiceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.objInv.MdiParent = this;
            panel1.Controls.Add(ClsCommon.objInv);
            ClsCommon.objInv.display();
            ClsCommon.objInv.Reset();
            ClsCommon.objInv.Show();
            ClsCommon.objInv.BringToFront();
        }
        private void updatePriceTierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.objPriceTier.MdiParent = this;
            panel1.Controls.Add(ClsCommon.objPriceTier);
            ClsCommon.objPriceTier.Show();
            ClsCommon.objPriceTier.BringToFront();
            ClsCommon.objPriceTier.Clear();
        }
        private void remainderInvoiceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.objInvRemainder.MdiParent = this;
            panel1.Controls.Add(ClsCommon.objInvRemainder);
            ClsCommon.objInvRemainder.Show();
            ClsCommon.objInvRemainder.BringToFront();
        }
        private void consolePrinterSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.objPrinterSetting.MdiParent = this;
            panel1.Controls.Add(ClsCommon.objPrinterSetting);
            ClsCommon.objPrinterSetting.Show();
            ClsCommon.objPrinterSetting.BringToFront();
            ClsCommon.objPrinterSetting.Display();
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void createSalesRepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "SalesRep_Add.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            //Process.Start(Application.StartupPath + @"\Video\SalesRep_Add.webm");
        }
        private void resetPasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "ResetPassword.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            //Process.Start(Application.StartupPath + @"\Video\ResetPassword.webm");
        }
        private void createUserTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "AddUserType.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            //Process.Start(Application.StartupPath + @"\Video\AddUserType.webm");
        }
        private void accessUserMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "Access_UserMenu.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            //Process.Start(Application.StartupPath + @"\Video\Access_UserMenu.webm");
        }
        private void qBConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "QBConnection.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            //Process.Start(Application.StartupPath + @"\Video\QBConnection.webm");
        }
        private void assignCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "Customer_Assign.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            //Process.Start(Application.StartupPath + @"\Video\Customer_Assign.webm");
        }
        private void createCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "Customer_AddUpdate.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            //Process.Start(Application.StartupPath + @"\Video\Customer_AddUpdate.webm");
        }
        private void createItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "ddUpdateItem.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            //Process.Start(Application.StartupPath + @"\Video\AddUpdateItem.webm");
        }
        private void createAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "AddJob.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            //Process.Start(Application.StartupPath + @"\Video\AddJob.webm");
        }
        private void updateItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "UpdateLowestPriceItem.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            //Process.Start(Application.StartupPath + @"\Video\UpdateLowestPriceItem.webm");
        }
        private void addNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "AddNotes.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            //Process.Start(Application.StartupPath + @"\Video\AddNotes.webm");
        }
        private void addCustomerCallLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "Add_CustomerCallLog.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            //Process.Start(Application.StartupPath + @"\Video\Add_CustomerCallLog.webm");
        }
        private void addInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "Invoice_AddUpdate.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            //Process.Start(Application.StartupPath + @"\Video\Invoice_AddUpdate.webm");
        }
        private void invoicePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "InvoicePayment.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            // Process.Start(Application.StartupPath + @"\Video\InvoicePayment.webm");
        }
        private void emailInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "InvoiceEmail.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            // Process.Start(Application.StartupPath + @"\Video\InvoiceEmail.webm");
        }
        private void multipleInvoicePrintToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "MultipleInvoicePrint.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            //  Process.Start(Application.StartupPath + @"\Video\MultipleInvoicePrint.webm");
        }
        private void searchInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "Search_Invoice.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            // Process.Start(Application.StartupPath + @"\Video\Search_Invoice.webm");
        }
        private void lowestPriceApprovelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "LowestPrice_Approvel.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            // Process.Start(Application.StartupPath + @"\Video\LowestPrice_Approvel.webm");
        }
        private void addTrackingItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "AddTrackingItem.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            // Process.Start(Application.StartupPath + @"\Video\AddTrackingItem.webm");
        }
        private void uPSShippingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "UPS_Shipping.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            // Process.Start(Application.StartupPath + @"\Video\UPS_Shipping.webm");
        }
        private void emailTemplateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "EmailTemplate.webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            // Process.Start(Application.StartupPath + @"\Video\EmailTemplate.webm");
        }
        private void itemSalesHistoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "ItemSalesHistory(Report).webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            // Process.Start(Application.StartupPath + @"\Video\ItemSalesHistory(Report).webm");
        }
        private void customerSalesHistoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "CustomerSalesHistory(Report).webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            // Process.Start(Application.StartupPath + @"\Video\CustomerSalesHistory(Report).webm");
        }
        private void paidInvoiceHistoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "PaidInvoiceHistory(Report).webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            // Process.Start(Application.StartupPath + @"\Video\PaidInvoiceHistory(Report).webm");
        }
        private void customerSummeryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "CustomerSummary(Report).webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            //  Process.Start(Application.StartupPath + @"\Video\CustomerSummary(Report).webm");
        }
        private void itemSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "ItemSummary(Report).webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            // Process.Start(Application.StartupPath + @"\Video\ItemSummary(Report).webm");
        }
        private void salesRepSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "SalesRepSummary(Report).webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            // Process.Start(Application.StartupPath + @"\Video\SalesRepSummary(Report).webm");
        }
        private void invoiceAuditReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "InvoiceAudit(Report).webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            // Process.Start(Application.StartupPath + @"\Video\InvoiceAudit(Report).webm");
        }
        private void newCustomerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "NewCustomer(Report).webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            //  Process.Start(Application.StartupPath + @"\Video\NewCustomer(Report).webm");
        }
        private void newItemReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "NewItem(Report).webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            //  Process.Start(Application.StartupPath + @"\Video\NewItem(Report).webm");
        }
        private void remainderInvoiceReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClsCommon.Variable = "RemainderInvoice(Report).webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            // Process.Start(Application.StartupPath + @"\Video\RemainderInvoice(Report).webm");
        }
        private void viewInvoiceReportToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            ClsCommon.Variable = "ViewInvoice(Report).webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            // Process.Start(Application.StartupPath + @"\Video\ViewInvoice(Report).webm");
        }
        private void invoiceProfitReportToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            ClsCommon.Variable = "InvoiceProfit(Report).webm";
            FrmHelperVideo HelperVideo = new FrmHelperVideo();
            HelperVideo.ShowDialog();
            //Process.Start(Application.StartupPath + @"\Video\InvoiceProfit(Report).webm");
        }
        private void customerStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCustomerStatement Statement = new FrmCustomerStatement();
            Statement.ShowDialog();
        }
        private void inActiveCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInActiveCustomer Statement = new FrmInActiveCustomer();
            Statement.ShowDialog();
        }
        private void itemInventoryStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmItemInventoryStock obj = new FrmItemInventoryStock();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        private void lowestPriceAllowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAllowLowestPriceCustomer Statement = new FrmAllowLowestPriceCustomer();
            Statement.ShowDialog();
        }
        private void payPalPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {


            ClsCommon.FrmPayPalMaster.Show();
            //ClsCommon.objRequestCount.MdiParent = this;
            //panel1.Controls.Add(ClsCommon.objRequestCount);
            //ClsCommon.objRequestCount.Show();
            ClsCommon.FrmPayPalMaster.BringToFront();
            //ClsCommon.FrmPayPalMaster.LoadData();
            //FrmPayPalMaster PaypalMaster = new FrmPayPalMaster();
            //PaypalMaster.ShowDialog();
        }
        private void paymentAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.FrmPaymentAll.Show();
            ClsCommon.FrmPaymentAll.BringToFront();
        }
        private void addPaymentMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.FrmPaymentMethod.Show();
            ClsCommon.FrmPaymentMethod.BringToFront();
        }
        //UnShipped Invoice History
        private void shippedInvoiceListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmShippedInvoiceList obj = new FrmShippedInvoiceList();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();

        }
        private void unShippedInvoiceListToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            ClsCommon.ObjUnShippedInvList.MdiParent = this;
            panel1.Controls.Add(ClsCommon.ObjUnShippedInvList);
            ClsCommon.ObjUnShippedInvList.Show();
            ClsCommon.ObjUnShippedInvList.BringToFront();
            //ClsCommon.ObjUnShippedInvList.LoadUnShippedInvoice();
        }
        //private void manuallySyncPrintToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    //ClsCommon.FrmManuallySyncPrint.MdiParent = this;
        //    //ClsCommon.FrmManuallySyncPrint.BringToFront();
        //    //ClsCommon.FrmManuallySyncPrint.StartPosition = FormStartPosition.CenterParent;
        //    //panel1.Controls.Add(ClsCommon.FrmManuallySyncPrint);
        //    //ClsCommon.FrmManuallySyncPrint.Show();
        //    FrmManuallySyncPrint obj = new FrmManuallySyncPrint();
        //    obj.MdiParent = this;
        //    panel1.Controls.Add(obj);
        //    obj.StartPosition = FormStartPosition.CenterParent;
        //    obj.Show();
        //    obj.BringToFront();

        //}
        private void hideColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHideColumn obj = new FrmHideColumn();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.StartPosition = FormStartPosition.CenterParent;
            obj.Show();
            obj.BringToFront();
        }
        private void purchaseCostUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.ObjPurchaseCostUpdate.MdiParent = this;
            panel1.Controls.Add(ClsCommon.ObjPurchaseCostUpdate);
            ClsCommon.ObjPurchaseCostUpdate.Show();
            ClsCommon.ObjPurchaseCostUpdate.BringToFront();
        }
        private void salesPriceUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.ObjSalesPriceUpdate.MdiParent = this;
            panel1.Controls.Add(ClsCommon.ObjSalesPriceUpdate);
            ClsCommon.ObjSalesPriceUpdate.Show();
            ClsCommon.ObjSalesPriceUpdate.BringToFront();
        }
        private void qtyOnHandUpdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.ObjQtyOnHandUpdate.MdiParent = this;
            panel1.Controls.Add(ClsCommon.ObjQtyOnHandUpdate);
            ClsCommon.ObjQtyOnHandUpdate.Show();
            ClsCommon.ObjQtyOnHandUpdate.BringToFront();
        }
        private void priceTierUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.ObjPriceTierUpdate.MdiParent = this;
            panel1.Controls.Add(ClsCommon.ObjPriceTierUpdate);
            ClsCommon.ObjPriceTierUpdate.Show();
            ClsCommon.ObjPriceTierUpdate.LoadItem();
            ClsCommon.ObjPriceTierUpdate.BringToFront();
        }
        private void invoiceProfitDetailsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FrmInvoiceAuditReport
            FrmInvoiceProfitDetailsReport obj = new FrmInvoiceProfitDetailsReport();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        private void comparativePriceUPDATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.ObjComparativePrice.MdiParent = this;
            panel1.Controls.Add(ClsCommon.ObjComparativePrice);
            ClsCommon.ObjComparativePrice.Show();
            ClsCommon.ObjComparativePrice.LoadItem();
            ClsCommon.ObjComparativePrice.BringToFront();
        }
        private void lowestPriceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.objLowestPriceList.MdiParent = this;
            panel1.Controls.Add(ClsCommon.objLowestPriceList);
            ClsCommon.objLowestPriceList.Show();
            ClsCommon.objLowestPriceList.LoadFunction();
            ClsCommon.objLowestPriceList.BringToFront();
        }
        private void manualSyncToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DataTable dt = new BALUserRequest().Select();
            if (dt.Rows.Count == 0)
            {
                new BALUserRequest().Insert(ClsCommon.UserID);
                MessageBox.Show("Request Create successfully..!!");
            }
            else
            {
                MessageBox.Show("Already one request in pending...!!");
            }
        }
        private void manuallySyncPrintToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //ClsCommon.FrmManuallySyncPrint.MdiParent = this;
            //ClsCommon.FrmManuallySyncPrint.BringToFront();
            //ClsCommon.FrmManuallySyncPrint.StartPosition = FormStartPosition.CenterParent;
            //panel1.Controls.Add(ClsCommon.FrmManuallySyncPrint);
            //ClsCommon.FrmManuallySyncPrint.Show();
            FrmManuallySyncPrint obj = new FrmManuallySyncPrint();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.StartPosition = FormStartPosition.CenterParent;
            obj.Show();
            obj.BringToFront();
        }
        private void accessTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserAccessTransfer Obj = new FrmUserAccessTransfer();
            Obj.MdiParent = this;
            panel1.Controls.Add(Obj);
            Obj.Show();
            Obj.BringToFront();
        }
        private void creditMemoReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCreditMemoReport obj = new FrmCreditMemoReport();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        private void salesRepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSalesRepSummaryCreditMemoReport obj = new FrmSalesRepSummaryCreditMemoReport();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        private void invoiceEditPermissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmShipRequestPermission obj = new FrmShipRequestPermission();
            //obj.MdiParent = this;
            //panel1.Controls.Add(obj);
            //obj.Show();
            //obj.BringToFront();

            ClsCommon.objShipRequestPermission.MdiParent = this;
            panel1.Controls.Add(ClsCommon.objShipRequestPermission);
            ClsCommon.objShipRequestPermission.Show();
            ClsCommon.objShipRequestPermission.BringToFront();
        }
        private void shipedEditedInvoiceDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmEditedInvoiceDetails obj = new FrmEditedInvoiceDetails();
            //obj.MdiParent = this;
            //panel1.Controls.Add(obj);
            //obj.Show();
            //obj.BringToFront();
            ClsCommon.objEditedInvoiceDetails.MdiParent = this;
            panel1.Controls.Add(ClsCommon.objEditedInvoiceDetails);
            ClsCommon.objEditedInvoiceDetails.Show();
            ClsCommon.objEditedInvoiceDetails.BringToFront();
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            //ShowsForm();
        }
        public void ShowsForm()
        {
            if (ClsCommon.UserType == "Admin")
            {
                DataTable EditedInvoice = new BALEditedInvoice().SELECT(new BOLEditedInvoice() { Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()) });
                if (EditedInvoice.Rows.Count > 0)
                {
                    ClsCommon.objEditedInvoiceDetails.MdiParent = this;
                    panel1.Controls.Add(ClsCommon.objEditedInvoiceDetails);
                    ClsCommon.objEditedInvoiceDetails.Show();
                    ClsCommon.objEditedInvoiceDetails.BringToFront();
                }
                DataTable Ship = new BALShipRequest().SELECTBYDate(new BOLShipRequest() { Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()) });
                if (Ship.Rows.Count > 0)
                {
                    ClsCommon.objShipRequestPermission.MdiParent = this;
                    panel1.Controls.Add(ClsCommon.objShipRequestPermission);
                    ClsCommon.objShipRequestPermission.Show();
                    ClsCommon.objShipRequestPermission.BringToFront();
                }
            }
        }
        private void retriveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRetriveData Obj = new FrmRetriveData();
            Obj.MdiParent = this;
            panel1.Controls.Add(Obj);
            Obj.Show();
            Obj.BringToFront();
        }
        private void createInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClsCommon.FunctionVisibility("InvInsert", "CustomerCenter"))
            {
                DialogResult result = MessageBox.Show("Are You Sure Want Create Invoice With TAX?:", "Select Action", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
             
                    ClsCommon.ObjInvoiceMaster.test();
                    ClsCommon.ObjInvoiceMaster.InvoiceNumber("Yes");
                    ClsCommon.TaxWithoutTax = "Yes";
                    ClsCommon.ObjInvoiceMaster.EditableField();
                    ClsCommon.ObjInvoiceMaster.DisplayPrice();
                    ClsCommon.ObjInvoiceMaster.LoadTable();
                    ClsCommon.ObjInvoiceMaster.AllowLowestPrice();
                    ClsCommon.ObjInvoiceMaster.CheckDate();
                    ClsCommon.ObjInvoiceMaster.isLoad = true;
                    ClsCommon.ObjInvoiceMaster.LoadCustomermessage();
                    ClsCommon.ObjInvoiceMaster.Show();
                    ClsCommon.ObjInvoiceMaster.AllowLowestPrice();
                }
                else if (result == DialogResult.No)
                {
                     ClsCommon.ObjInvoiceMaster.test();
                    ClsCommon.ObjInvoiceMaster.InvoiceNumber("No");
                    ClsCommon.TaxWithoutTax = "No";
                    ClsCommon.ObjInvoiceMaster.EditableField();
                    ClsCommon.ObjInvoiceMaster.DisplayPrice();
                    ClsCommon.ObjInvoiceMaster.LoadTable();
                    ClsCommon.ObjInvoiceMaster.AllowLowestPrice();
                    ClsCommon.ObjInvoiceMaster.CheckDate();
                    ClsCommon.ObjInvoiceMaster.isLoad = true;
                    ClsCommon.ObjInvoiceMaster.LoadCustomermessage();
                    ClsCommon.ObjInvoiceMaster.Show();
                    ClsCommon.ObjInvoiceMaster.AllowLowestPrice();
                    
                    
                }
                else if (result == DialogResult.Cancel)
                {
                }
            }
            else
                MessageBox.Show("You can not access");
        }
        private void createCreditMemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClsCommon.FunctionVisibility("CreditMemoInsert", "CustomerCenter"))
            {
                    DialogResult result = MessageBox.Show("Are You Sure Want Create Credit Memo With TAX?:", "Select Action", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        ClsCommon.ObjCreditMemo.test();
                        ClsCommon.ObjCreditMemo.InvoiceNumber("Yes");
                        ClsCommon.TaxWithoutTax = "Yes";
                        ClsCommon.ObjCreditMemo.EditableField();
                        ClsCommon.ObjCreditMemo.DisplayPrice();
                        ClsCommon.ObjCreditMemo.LoadTable();
                        ClsCommon.ObjCreditMemo.AllowLowestPrice();
                        ClsCommon.ObjCreditMemo.CheckDate();
                    ClsCommon.ObjCreditMemo.isLoad = true;
                    ClsCommon.ObjCreditMemo.LoadCustomermessage();
                    ClsCommon.ObjCreditMemo.Show();
                        ClsCommon.ObjCreditMemo.AllowLowestPrice();
                    }
                    else if (result == DialogResult.No)
                    {
                        ClsCommon.ObjCreditMemo.test();
                        ClsCommon.ObjCreditMemo.InvoiceNumber("No");
                        ClsCommon.TaxWithoutTax = "No";
                        ClsCommon.ObjCreditMemo.EditableField();
                        ClsCommon.ObjCreditMemo.DisplayPrice();
                        ClsCommon.ObjCreditMemo.LoadTable();
                        ClsCommon.ObjCreditMemo.AllowLowestPrice();
                        ClsCommon.ObjCreditMemo.CheckDate();
                    ClsCommon.ObjCreditMemo.isLoad = true;
                    ClsCommon.ObjCreditMemo.LoadCustomermessage();
                    ClsCommon.ObjCreditMemo.Show();
                        ClsCommon.ObjCreditMemo.AllowLowestPrice();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                    }
               
            }
        }
        private void addFilterFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFilter Obj = new FrmFilter();
            //Obj.MdiParent = this;
            //panel1.Controls.Add(Obj);
            Obj.Show();
            Obj.BringToFront();
        }
        private void receivePaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Nidhi Change
            //FrmPaymentDetail Obj = new FrmPaymentDetail();
            //ClsCommon.objPayment.MdiParent = this;
            //panel1.Controls.Add(ClsCommon.objPayment);
            //ClsCommon.objPayment.Show();
            //ClsCommon.objPayment.BringToFront();
            if (ClsCommon.FunctionVisibility("ReceivePayments", "CustomerCenter"))
            {
                FrmPaymentDetail Obj = new FrmPaymentDetail();
                Obj.Show();
                Obj.BringToFront();
            }
            else
                MessageBox.Show("You can not access");
        }
        private void manuallyEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManuallyEmail Obj = new FrmManuallyEmail();
            //Obj.MdiParent = this;
            //panel1.Controls.Add(Obj);
            Obj.Show();
            Obj.BringToFront();
        }
        private void addShipStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShipStatus Obj = new FrmShipStatus();
            //Obj.MdiParent = this;
            //panel1.Controls.Add(Obj);
            Obj.Show();
            Obj.BringToFront();
        }
        private void notesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNoteReport obj = new FrmNoteReport();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();

        }
        private void addIMEIReasonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReason obj = new FrmReason();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        private void invoiceIMEINumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIMEIDetailsReport obj = new FrmIMEIDetailsReport();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        private void invoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClsCommon.objRequestCount.MdiParent = this;
            panel1.Controls.Add(ClsCommon.objRequestCount);
            ClsCommon.objRequestCount.Show();
            ClsCommon.objRequestCount.BringToFront();
            ClsCommon.objRequestCount.LoadData();

        }
        private void creditMemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.objCreditMemoRequest.MdiParent = this;
            panel1.Controls.Add(ClsCommon.objCreditMemoRequest);
            ClsCommon.objCreditMemoRequest.Show();
            ClsCommon.objCreditMemoRequest.BringToFront();
        }
        private void itemSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmItemSummaryReport obj = new FrmItemSummaryReport();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        private void newItemsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewItemReport obj = new FrmNewItemReport();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        private void addIMEICARRIERSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGRADING obj = new FrmGRADING();
            obj.MdiParent = this;
            panel1.Controls.Add(obj);
            obj.Show();
            obj.BringToFront();
        }
        private void webPriceUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.ObjWebPriceUpdate.MdiParent = this;
            panel1.Controls.Add(ClsCommon.ObjWebPriceUpdate);
            ClsCommon.ObjWebPriceUpdate.Show();
            ClsCommon.ObjWebPriceUpdate.BringToFront();
        }
        private void customerAgingSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.ObjAgingSummary.MdiParent = this;
            panel1.Controls.Add(ClsCommon.ObjAgingSummary);
            ClsCommon.ObjAgingSummary.Show();
            ClsCommon.ObjAgingSummary.LoadData();
            ClsCommon.ObjAgingSummary.BringToFront();
        }
        private void customerLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.ObjCustomerLogs.MdiParent = this;
            panel1.Controls.Add(ClsCommon.ObjCustomerLogs);
            ClsCommon.ObjCustomerLogs.Show();
            ClsCommon.ObjCustomerLogs.Display();
            ClsCommon.ObjCustomerLogs.BringToFront();
        }
        private void invoiceUpdateLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.ObjInvoiceLogs.MdiParent = this;
            panel1.Controls.Add(ClsCommon.ObjInvoiceLogs);
            ClsCommon.ObjInvoiceLogs.Show();
            ClsCommon.ObjInvoiceLogs.Display();
            ClsCommon.ObjInvoiceLogs.BringToFront();
        }
        private void convertTaxNonTaxInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ClsCommon.ObjManageTax.MdiParent = this;
                panel1.Controls.Add(ClsCommon.ObjManageTax);
                ClsCommon.ObjManageTax.Show();
                ClsCommon.ObjManageTax.LoadAllInvoices();
                ClsCommon.ObjManageTax.BringToFront();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:MDIParent,Function :taxNonTaxToolStripMenuItem_Click. Message:" + ex.Message);
                MessageBox.Show(ex.Message);
            }

        }
        private void createMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsCommon.objCustomerMessage.MdiParent = this;
            panel1.Controls.Add(ClsCommon.objCustomerMessage);
            ClsCommon.objCustomerMessage.Show();
            ClsCommon.objCustomerMessage.BringToFront();
            ClsCommon.objCustomerMessage.displaydata();
        }
    }
}