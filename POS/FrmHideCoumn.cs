using DocumentFormat.OpenXml.Drawing.Diagrams;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmHideColumn : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BOLInvoiceLogHideColumn objBOLInvoiceLogHideColumn = new BOLInvoiceLogHideColumn();
        BALInvoiceLogHideColumn objBALInvoiceLogHideColumn = new BALInvoiceLogHideColumn();
        BOLHideColumn objBOLHideColumn = new BOLHideColumn();
        BALHideColumn objBALHideColumn = new BALHideColumn();
        BOLCustomerLogHideColumn objBOLCustomerLogHideColumn = new BOLCustomerLogHideColumn();
        BALCustomerLogHideColumn objBALCustomerLogHideColumn = new BALCustomerLogHideColumn();
        public FrmHideColumn()
        {
            InitializeComponent();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new DataTable();
                dataTable = new BALHideColumn().Select(new BOLHideColumn() { UserID = ClsCommon.UserID });
                if (dataTable.Rows.Count == 0)
                {
                    objBOLHideColumn.UserID = ClsCommon.UserID;

                    //Transctions vise

                    if (chkMultiplePrint.Checked == true)
                    {
                        objBOLHideColumn.MultiplePrint = 1;
                    }
                    else
                    {
                        objBOLHideColumn.MultiplePrint = 0;
                    }
                    if (chkNoOfInvoice.Checked == true)
                    {
                        objBOLHideColumn.NoOfInvoice = 1;
                    }
                    else
                    {
                        objBOLHideColumn.NoOfInvoice = 0;
                    }
                    if (chkNoOfTimesEdit.Checked == true)
                    {
                        objBOLHideColumn.NoOfTimesEdit = 1;
                    }
                    else
                    {
                        objBOLHideColumn.NoOfTimesEdit = 0;
                    }
                    if (chkOPENBALANCE.Checked == true)
                    {
                        objBOLHideColumn.OPENBALANCE = 1;
                    }
                    else
                    {
                        objBOLHideColumn.OPENBALANCE = 0;
                    }
                    if (chkProfit.Checked == true)
                    {
                        objBOLHideColumn.Profit = 1;
                    }
                    else
                    {
                        objBOLHideColumn.Profit = 0;
                    }
                    //CreatedDATE
                    if (chkDATE.Checked == true)
                    {
                        objBOLHideColumn.DATE = 1;
                    }
                    else
                    {
                        objBOLHideColumn.DATE = 0;
                    }
                    // CreatedTIME
                    if (chkTIME.Checked == true)
                    {
                        objBOLHideColumn.TIME = 1;
                    }
                    else
                    {
                        objBOLHideColumn.TIME = 0;
                    }
                    //UpdateDATE

                    if (chkUPDATEDATE.Checked == true)
                    {
                        objBOLHideColumn.UPDATEDATE = 1;
                    }
                    else
                    {
                        objBOLHideColumn.UPDATEDATE = 0;
                    }
                    //UpdateTime
                    if (chkUPADTETIME.Checked == true)
                    {
                        objBOLHideColumn.UPDATETIME = 1;
                    }
                    else
                    {
                        objBOLHideColumn.UPDATETIME = 0;
                    }
                    if (chkCUSTOMER.Checked == true)
                    {
                        objBOLHideColumn.CUSTOMER = 1;
                    }
                    else
                    {
                        objBOLHideColumn.CUSTOMER = 0;
                    }
                    if (chkNUM.Checked == true)
                    {
                        objBOLHideColumn.NUM = 1;
                    }
                    else
                    {
                        objBOLHideColumn.NUM = 0;
                    }
                    if (chkDUEDATE.Checked == true)
                    {
                        objBOLHideColumn.DUEDATE = 1;
                    }
                    else
                    {
                        objBOLHideColumn.DUEDATE = 0;
                    }
                    if (chkTERMS.Checked == true)
                    {
                        objBOLHideColumn.TERMS = 1;
                    }
                    else
                    {
                        objBOLHideColumn.TERMS = 0;
                    }
                    if (chkSalesRep.Checked == true)
                    {
                        objBOLHideColumn.SalesRep = 1;
                    }
                    else
                    {
                        objBOLHideColumn.SalesRep = 0;
                    }
                    if (chkVIA_Services.Checked == true)
                    {
                        objBOLHideColumn.VIA_Services = 1;
                    }
                    else
                    {
                        objBOLHideColumn.VIA_Services = 0;
                    }
                    if (chkErrorLog.Checked == true)
                    {
                        objBOLHideColumn.ErrorLog = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ErrorLog = 0;
                    }
                    if (chkPaidStatus.Checked == true)
                    {
                        objBOLHideColumn.PaidStatus = 1;
                    }
                    else
                    {
                        objBOLHideColumn.PaidStatus = 0;
                    }
                    if (chkPendingInvoice.Checked == true)
                    {
                        objBOLHideColumn.PendingInvoice = 1;
                    }
                    else
                    {
                        objBOLHideColumn.PendingInvoice = 0;
                    }
                    if (chkPrint.Checked == true)
                    {
                        objBOLHideColumn.Print1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.Print1 = 0;
                    }
                    if (chkPayit.Checked == true)
                    {
                        objBOLHideColumn.Payit = 1;
                    }
                    else
                    {
                        objBOLHideColumn.Payit = 0;
                    }
                    if (chkAMOUNT.Checked == true)
                    {
                        objBOLHideColumn.AMOUNT = 1;
                    }
                    else
                    {
                        objBOLHideColumn.AMOUNT = 0;
                    }
                    if (chkShippingCost.Checked == true)
                    {
                        objBOLHideColumn.ShippingCost = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ShippingCost = 0;
                    }
                    if (chkProfitPercentage.Checked == true)
                    {
                        objBOLHideColumn.ProfitPercentage = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ProfitPercentage = 0;
                    }
                    if (chkShipit.Checked == true)
                    {
                        objBOLHideColumn.Shipit = 1;
                    }
                    else
                    {
                        objBOLHideColumn.Shipit = 0;
                    }
                    if (chkShipCharges.Checked == true)
                    {
                        objBOLHideColumn.ShipCharges = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ShipCharges = 0;
                    }
                    if (chkShipStatus.Checked == true)
                    {
                        objBOLHideColumn.ShipStatus = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ShipStatus = 0;
                    }
                    if (chkAddButton.Checked == true)
                    {
                        objBOLHideColumn.AddButton = 1;
                    }
                    else
                    {
                        objBOLHideColumn.AddButton = 0;
                    }

                    //CustomerWise Invoice
                    if (chkTYPE.Checked == true)
                    {
                        objBOLHideColumn.TYPE = 1;
                    }
                    else
                    {
                        objBOLHideColumn.TYPE = 0;
                    }
                    if (chkNoOfTimesEdit1.Checked == true)
                    {
                        objBOLHideColumn.NoOfTimesEdit1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.NoOfTimesEdit1 = 0;
                    }
                    if (chkProfit1.Checked == true)
                    {
                        objBOLHideColumn.Profit1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.Profit1 = 0;
                    }
                    if (chkProfitPercentage1.Checked == true)
                    {
                        objBOLHideColumn.ProfitPercentage1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ProfitPercentage1 = 0;
                    }
                    //CreatedDATE1
                    if (chkDATE1.Checked == true)
                    {
                        objBOLHideColumn.DATE1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.DATE1 = 0;
                    }
                    //CreatedTIME1
                    if (chkTIME1.Checked == true)
                    {
                        objBOLHideColumn.TIME1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.TIME1 = 0;
                    }
                    //UpdateDATE1
                    if (chkUPDATEDATE1.Checked == true)
                    {
                        objBOLHideColumn.UPDATEDATE1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.UPDATEDATE1 = 0;
                    }
                    //UpdateTime1
                    if (chkUPDATETIME1.Checked == true)
                    {
                        objBOLHideColumn.UPDATETIME1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.UPDATETIME1 = 0;
                    }

                    if (chkNUM1.Checked == true)
                    {
                        objBOLHideColumn.NUM1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.NUM1 = 0;
                    }
                    if (chkACCOUNT.Checked == true)
                    {
                        objBOLHideColumn.ACCOUNT = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ACCOUNT = 0;
                    }
                    if (chkTERMS1.Checked == true)
                    {
                        objBOLHideColumn.TERMS1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.TERMS1 = 0;
                    }
                    if (chkSalesRep1.Checked == true)
                    {
                        objBOLHideColumn.SalesRep1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.SalesRep1 = 0;
                    }
                    if (chkVIA_Service1.Checked == true)
                    {
                        objBOLHideColumn.VIA_Service1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.VIA_Service1 = 0;
                    }
                    if (chkErrorLog1.Checked == true)
                    {
                        objBOLHideColumn.ErrorLog1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ErrorLog1 = 0;
                    }
                    if (chkPaidStatus1.Checked == true)
                    {
                        objBOLHideColumn.PaidStatus1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.PaidStatus1 = 0;
                    }
                    if (chkPrint1.Checked == true)
                    {
                        objBOLHideColumn.Print2 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.Print2 = 0;
                    }
                    if (chkPayit1.Checked == true)
                    {
                        objBOLHideColumn.Payit2 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.Payit2 = 0;
                    }
                    if (chkAMOUNT1.Checked == true)
                    {
                        objBOLHideColumn.AMOUNT1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.AMOUNT1 = 0;
                    }
                    if (chkShippingCost1.Checked == true)
                    {
                        objBOLHideColumn.ShippingCost1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ShippingCost1 = 0;
                    }
                    if (chkShipit1.Checked == true)
                    {
                        objBOLHideColumn.Shipit2 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.Shipit2 = 0;
                    }
                    if (chkShipCharges1.Checked == true)
                    {
                        objBOLHideColumn.ShipCharges1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ShipCharges1 = 0;
                    }
                    if (chkShipStatus1.Checked == true)
                    {
                        objBOLHideColumn.ShipStatus2 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ShipStatus2 = 0;
                    }
                    if (chkAddButton1.Checked == true)
                    {
                        objBOLHideColumn.AddButton1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.AddButton1 = 0;
                    }

                    //
                    ClsCommon.WriteErrorLogs("FrmHideColumn.,Insert, Message:-Set All value");
                    objBALHideColumn.Insert(objBOLHideColumn);
                    MessageBox.Show("Hide Column SuccessFully");
                    ClsCommon.WriteErrorLogs("Hide Column SuccessFully");
                }
                else
                {
                    objBOLHideColumn.UserID = ClsCommon.UserID;
                    //Transctions vise
                    if (chkMultiplePrint.Checked == true)
                    {
                        objBOLHideColumn.MultiplePrint = 1;
                    }
                    else
                    {
                        objBOLHideColumn.MultiplePrint = 0;
                    }
                    if (chkNoOfInvoice.Checked == true)
                    {
                        objBOLHideColumn.NoOfInvoice = 1;
                    }
                    else
                    {
                        objBOLHideColumn.NoOfInvoice = 0;
                    }
                    if (chkNoOfTimesEdit.Checked == true)
                    {
                        objBOLHideColumn.NoOfTimesEdit = 1;
                    }
                    else
                    {
                        objBOLHideColumn.NoOfTimesEdit = 0;
                    }
                    if (chkOPENBALANCE.Checked == true)
                    {
                        objBOLHideColumn.OPENBALANCE = 1;
                    }
                    else
                    {
                        objBOLHideColumn.OPENBALANCE = 0;
                    }
                    if (chkProfit.Checked == true)
                    {
                        objBOLHideColumn.Profit = 1;
                    }
                    else
                    {
                        objBOLHideColumn.Profit = 0;
                    }
                    //CreatedDATE
                    if (chkDATE.Checked == true)
                    {
                        objBOLHideColumn.DATE = 1;
                    }
                    else
                    {
                        objBOLHideColumn.DATE = 0;
                    }
                    // CreatedTIME
                    if (chkTIME.Checked == true)
                    {
                        objBOLHideColumn.TIME = 1;
                    }
                    else
                    {
                        objBOLHideColumn.TIME = 0;
                    }
                    //UpdateDATE

                    if (chkUPDATEDATE.Checked == true)
                    {
                        objBOLHideColumn.UPDATEDATE = 1;
                    }
                    else
                    {
                        objBOLHideColumn.UPDATEDATE = 0;
                    }
                    //UpdateTime
                    if (chkUPADTETIME.Checked == true)
                    {
                        objBOLHideColumn.UPDATETIME = 1;
                    }
                    else
                    {
                        objBOLHideColumn.UPDATETIME = 0;
                    }
                    if (chkCUSTOMER.Checked == true)
                    {
                        objBOLHideColumn.CUSTOMER = 1;
                    }
                    else
                    {
                        objBOLHideColumn.CUSTOMER = 0;
                    }
                    if (chkNUM.Checked == true)
                    {
                        objBOLHideColumn.NUM = 1;
                    }
                    else
                    {
                        objBOLHideColumn.NUM = 0;
                    }
                    if (chkDUEDATE.Checked == true)
                    {
                        objBOLHideColumn.DUEDATE = 1;
                    }
                    else
                    {
                        objBOLHideColumn.DUEDATE = 0;
                    }
                    if (chkTERMS.Checked == true)
                    {
                        objBOLHideColumn.TERMS = 1;
                    }
                    else
                    {
                        objBOLHideColumn.TERMS = 0;
                    }
                    if (chkSalesRep.Checked == true)
                    {
                        objBOLHideColumn.SalesRep = 1;
                    }
                    else
                    {
                        objBOLHideColumn.SalesRep = 0;
                    }
                    if (chkVIA_Services.Checked == true)
                    {
                        objBOLHideColumn.VIA_Services = 1;
                    }
                    else
                    {
                        objBOLHideColumn.VIA_Services = 0;
                    }
                    if (chkErrorLog.Checked == true)
                    {
                        objBOLHideColumn.ErrorLog = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ErrorLog = 0;
                    }
                    if (chkPaidStatus.Checked == true)
                    {
                        objBOLHideColumn.PaidStatus = 1;
                    }
                    else
                    {
                        objBOLHideColumn.PaidStatus = 0;
                    }
                    if (chkPendingInvoice.Checked == true)
                    {
                        objBOLHideColumn.PendingInvoice = 1;
                    }
                    else
                    {
                        objBOLHideColumn.PendingInvoice = 0;
                    }
                    if (chkPrint.Checked == true)
                    {
                        objBOLHideColumn.Print1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.Print1 = 0;
                    }
                    if (chkPayit.Checked == true)
                    {
                        objBOLHideColumn.Payit = 1;
                    }
                    else
                    {
                        objBOLHideColumn.Payit = 0;
                    }
                    if (chkAMOUNT.Checked == true)
                    {
                        objBOLHideColumn.AMOUNT = 1;
                    }
                    else
                    {
                        objBOLHideColumn.AMOUNT = 0;
                    }
                    if (chkShippingCost.Checked == true)
                    {
                        objBOLHideColumn.ShippingCost = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ShippingCost = 0;
                    }
                    if (chkProfitPercentage.Checked == true)
                    {
                        objBOLHideColumn.ProfitPercentage = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ProfitPercentage = 0;
                    }
                    if (chkShipit.Checked == true)
                    {
                        objBOLHideColumn.Shipit = 1;
                    }
                    else
                    {
                        objBOLHideColumn.Shipit = 0;
                    }
                    if (chkShipCharges.Checked == true)
                    {
                        objBOLHideColumn.ShipCharges = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ShipCharges = 0;
                    }
                    if (chkShipStatus.Checked == true)
                    {
                        objBOLHideColumn.ShipStatus = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ShipStatus = 0;
                    }
                    if (chkAddButton.Checked == true)
                    {
                        objBOLHideColumn.AddButton = 1;
                    }
                    else
                    {
                        objBOLHideColumn.AddButton = 0;
                    }

                    //CustomerWise Invoice

                    if (chkTYPE.Checked == true)
                    {
                        objBOLHideColumn.TYPE = 1;
                    }
                    else
                    {
                        objBOLHideColumn.TYPE = 0;
                    }
                    if (chkNoOfTimesEdit1.Checked == true)
                    {
                        objBOLHideColumn.NoOfTimesEdit1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.NoOfTimesEdit1 = 0;
                    }
                    if (chkProfit1.Checked == true)
                    {
                        objBOLHideColumn.Profit1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.Profit1 = 0;
                    }
                    if (chkProfitPercentage1.Checked == true)
                    {
                        objBOLHideColumn.ProfitPercentage1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ProfitPercentage1 = 0;
                    }
                    //CreatedDATE1
                    if (chkDATE1.Checked == true)
                    {
                        objBOLHideColumn.DATE1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.DATE1 = 0;
                    }
                    //CreatedTIME1
                    if (chkTIME1.Checked == true)
                    {
                        objBOLHideColumn.TIME1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.TIME1 = 0;
                    }
                    //UpdateDATE1
                    if (chkUPDATEDATE1.Checked == true)
                    {
                        objBOLHideColumn.UPDATEDATE1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.UPDATEDATE1 = 0;
                    }
                    //UpdateTime1
                    if (chkUPDATETIME1.Checked == true)
                    {
                        objBOLHideColumn.UPDATETIME1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.UPDATETIME1 = 0;
                    }

                    if (chkNUM1.Checked == true)
                    {
                        objBOLHideColumn.NUM1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.NUM1 = 0;
                    }
                    if (chkACCOUNT.Checked == true)
                    {
                        objBOLHideColumn.ACCOUNT = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ACCOUNT = 0;
                    }
                    if (chkTERMS1.Checked == true)
                    {
                        objBOLHideColumn.TERMS1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.TERMS1 = 0;
                    }
                    if (chkSalesRep1.Checked == true)
                    {
                        objBOLHideColumn.SalesRep1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.SalesRep1 = 0;
                    }
                    if (chkVIA_Service1.Checked == true)
                    {
                        objBOLHideColumn.VIA_Service1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.VIA_Service1 = 0;
                    }
                    if (chkErrorLog1.Checked == true)
                    {
                        objBOLHideColumn.ErrorLog1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ErrorLog1 = 0;
                    }
                    if (chkPaidStatus1.Checked == true)
                    {
                        objBOLHideColumn.PaidStatus1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.PaidStatus1 = 0;
                    }
                    if (chkPrint1.Checked == true)
                    {
                        objBOLHideColumn.Print2 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.Print2 = 0;
                    }
                    if (chkPayit1.Checked == true)
                    {
                        objBOLHideColumn.Payit2 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.Payit2 = 0;
                    }
                    if (chkAMOUNT1.Checked == true)
                    {
                        objBOLHideColumn.AMOUNT1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.AMOUNT1 = 0;
                    }
                    if (chkShippingCost1.Checked == true)
                    {
                        objBOLHideColumn.ShippingCost1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ShippingCost1 = 0;
                    }
                    if (chkShipit1.Checked == true)
                    {
                        objBOLHideColumn.Shipit2 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.Shipit2 = 0;
                    }
                    if (chkShipCharges1.Checked == true)
                    {
                        objBOLHideColumn.ShipCharges1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ShipCharges1 = 0;
                    }
                    if (chkShipStatus1.Checked == true)
                    {
                        objBOLHideColumn.ShipStatus2 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.ShipStatus2 = 0;
                    }
                    if (chkAddButton1.Checked == true)
                    {
                        objBOLHideColumn.AddButton1 = 1;
                    }
                    else
                    {
                        objBOLHideColumn.AddButton1 = 0;
                    }

                    //

                    ClsCommon.WriteErrorLogs("FrmHideColumn.,Update, Message:-Set All value");
                    objBALHideColumn.Update(objBOLHideColumn);
                    MessageBox.Show("Hide Column SuccessFully");

                    //FrmCustomerCenter.ReferenceEquals(this, objBOLHideColumn);
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmHideColumn,Function :btnHide_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void FrmHideColumn_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                this.Hide();
                this.Parent = null;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmHideColumn,Function :FrmHideColumn_FormClosing. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void FrmHideColumn_Load(object sender, EventArgs e)
        {
            TransctionsLoadData();
            CustomerLogs();
            InvoiceLogs();
        }
        private void btnCustomerLogs_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new DataTable();
                dataTable = new BALCustomerLogHideColumn().Select(new BOLCustomerLogHideColumn() { UserID = ClsCommon.UserID });
                if (dataTable.Rows.Count == 0)
                {
                    objBOLCustomerLogHideColumn.UserID = ClsCommon.UserID;
                    if (chkNewCustomerName.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.NewCustomerName = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.NewCustomerName = 0;
                    }

                    if (chkOldCustomerName.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.OldCustomerName = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.OldCustomerName = 0;
                    }
                    if (chkNewSalutation.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.NewSalutation = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.NewSalutation = 0;
                    }
                    if (chkOldSalutation.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.OldSalutation = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.OldSalutation = 0;
                    }

                    if (chkNewFirstName.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.NewFirstName = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.NewFirstName = 0;
                    }
                    if (chkOldFirstName.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.OldFirstName = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.OldFirstName = 0;
                    }
                    if (chkNewMiddleName.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.NewMiddleName = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.NewMiddleName = 0;
                    }
                    if (chkOldMiddleName.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.OldMiddleName = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.OldMiddleName = 0;
                    }
                    if (chkNewLastName.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.NewLastName = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.NewLastName = 0;
                    }
                    if (chkOldLastName.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.OldLastName = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.OldLastName = 0;
                    }
                    if (chkEditCount.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.EditCount = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.EditCount = 0;
                    }
                    if (chkUpdateDate2.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.UpdateDate = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.UpdateDate = 0;
                    }
                    ClsCommon.WriteErrorLogs("FrmCustomerLogHideColumn.,Insert, Message:-Set All value");
                    objBALCustomerLogHideColumn.Insert(objBOLCustomerLogHideColumn);
                    MessageBox.Show("Hide Column SuccessFully");
                    ClsCommon.WriteErrorLogs("Hide Column SuccessFully");
                }
                else
                {
                    objBOLCustomerLogHideColumn.UserID = ClsCommon.UserID;

                    if (chkNewCustomerName.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.NewCustomerName = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.NewCustomerName = 0;
                    }

                    if (chkOldCustomerName.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.OldCustomerName = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.OldCustomerName = 0;
                    }

                    if (chkNewSalutation.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.NewSalutation = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.NewSalutation = 0;
                    }
                    if (chkOldSalutation.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.OldSalutation = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.OldSalutation = 0;
                    }

                    if (chkNewFirstName.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.NewFirstName = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.NewFirstName = 0;
                    }
                    if (chkOldFirstName.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.OldFirstName = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.OldFirstName = 0;
                    }
                    if (chkNewMiddleName.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.NewMiddleName = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.NewMiddleName = 0;
                    }
                    if (chkOldMiddleName.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.OldMiddleName = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.OldMiddleName = 0;
                    }
                    if (chkNewLastName.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.NewLastName = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.NewLastName = 0;
                    }
                    if (chkOldLastName.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.OldLastName = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.OldLastName = 0;
                    }
                    if (chkEditCount.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.EditCount = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.EditCount = 0;
                    }
                    if (chkUpdateDate2.Checked == true)
                    {
                        objBOLCustomerLogHideColumn.UpdateDate = 1;
                    }
                    else
                    {
                        objBOLCustomerLogHideColumn.UpdateDate = 0;
                    }

                    ClsCommon.WriteErrorLogs("FrmCustomerLogHideColumn.,Update, Message:-Set All value");
                    objBALCustomerLogHideColumn.Update(objBOLCustomerLogHideColumn);
                    MessageBox.Show("Hide Column SuccessFully");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerLogHideColumn,Function :btnCutomerHideColumn_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void btnInvoiceLogs_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new DataTable();
                dataTable = new BALInvoiceLogHideColumn().Select(new BOLInvoiceLogHideColumn() { InvoiceID = ClsCommon.UserID });
                if (dataTable.Rows.Count == 0)
                {
                    objBOLInvoiceLogHideColumn.InvoiceID = ClsCommon.UserID;
                    if (chkNewRefNumber.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewRefNumber = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewRefNumber = 0;
                    }

                    if (chkNewCustomerName1.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewCustomerName = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewCustomerName = 0;
                    }

                    if (OldCustomerName.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldCustomerName = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldCustomerName = 0;
                    }
                    if (chkNewPONumber.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewPONumber = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewPONumber = 0;
                    }

                    if (chkOldPONumber.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldPONumber = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldPONumber = 0;
                    }
                    if (chkNewTermsName.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewTermsName = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewTermsName = 0;
                    }
                    if (chkOldTermsName.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldTermsName = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldTermsName = 0;
                    }
                    if (chkNewDueDate.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewDueDate = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewDueDate = 0;
                    }
                    if (chkOldDueDate.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldDueDate = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldDueDate = 0;
                    }
                    if (chkNewSalesRepName.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewSalesRepName = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewSalesRepName = 0;
                    }
                    if (chkOldSalesRepName.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldSalesRepName = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldSalesRepName = 0;
                    }
                    if (chkNewshipDate.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewshipDate = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewshipDate = 0;
                    }
                    if (chkOldShipDate.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldShipDate = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldShipDate = 0;
                    }
                    if (chkNewShipping.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewShipping = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewShipping = 0;
                    }
                    if (chkOldShipping.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldShipping = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldShipping = 0;
                    }
                    if (chkNewTotal.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewTotal = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewTotal = 0;
                    }
                    if (chkOldTotal.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldTotal = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldTotal = 0;
                    }
                    if (chkNewAppliedAmount.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewAppliedAmount = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewAppliedAmount = 0;
                    }
                    if (chkOldAppliedAmount.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldAppliedAmount = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldAppliedAmount = 0;
                    }
                    if (chkNewBalanceDue.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewBalanceDue = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewBalanceDue = 0;
                    }
                    if (chkOldBalanceDue.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldBalanceDue = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldBalanceDue = 0;
                    }
                    if (chkNewMemo.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewMemo = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewMemo = 0;
                    }
                    if (chkOldMemo.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldMemo = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldMemo = 0;
                    }
                    if (chkEditCount1.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.EditCount = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.EditCount = 0;
                    }
                    if (chkUpdateDate3.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.UpdateDate = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.UpdateDate = 0;
                    }
                    ClsCommon.WriteErrorLogs("FrmInvoiceLogHideColumn.,Insert, Message:-Set All value");
                    objBALInvoiceLogHideColumn.Insert(objBOLInvoiceLogHideColumn);
                    MessageBox.Show("Hide Column SuccessFully");
                    ClsCommon.WriteErrorLogs("Hide Column SuccessFully");
                }
                else
                {
                    objBOLInvoiceLogHideColumn.InvoiceID = ClsCommon.UserID;

                    if (chkNewRefNumber.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewRefNumber = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewRefNumber = 0;
                    }
                    if (chkNewCustomerName1.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewCustomerName = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewCustomerName = 0;
                    }
                    if (OldCustomerName.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldCustomerName = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldCustomerName = 0;
                    }
                    if (chkNewPONumber.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewPONumber = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewPONumber = 0;
                    }
                    if (chkOldPONumber.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldPONumber = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldPONumber = 0;
                    }
                    if (chkNewTermsName.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewTermsName = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewTermsName = 0;
                    }
                    if (chkOldTermsName.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldTermsName = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldTermsName = 0;
                    }
                    if (chkNewDueDate.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewDueDate = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewDueDate = 0;
                    }
                    if (chkOldDueDate.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldDueDate = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldDueDate = 0;
                    }
                    if (chkNewSalesRepName.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewSalesRepName = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewSalesRepName = 0;
                    }
                    if (chkOldSalesRepName.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldSalesRepName = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldSalesRepName = 0;
                    }
                    if (chkNewshipDate.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewshipDate = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewshipDate = 0;
                    }
                    if (chkOldShipDate.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldShipDate = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldShipDate = 0;
                    }
                    if (chkNewShipping.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewShipping = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewShipping = 0;
                    }
                    if (chkOldShipping.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldShipping = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldShipping = 0;
                    }
                    if (chkNewTotal.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewTotal = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewTotal = 0;
                    }
                    if (chkOldTotal.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldTotal = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldTotal = 0;
                    }
                    if (chkNewAppliedAmount.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewAppliedAmount = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewAppliedAmount = 0;
                    }
                    if (chkOldAppliedAmount.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldAppliedAmount = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldAppliedAmount = 0;
                    }
                    if (chkNewBalanceDue.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewBalanceDue = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewBalanceDue = 0;
                    }
                    if (chkOldBalanceDue.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldBalanceDue = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldBalanceDue = 0;
                    }
                    if (chkNewMemo.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.NewMemo = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.NewMemo = 0;
                    }
                    if (chkOldMemo.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.OldMemo = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.OldMemo = 0;
                    }
                    if (chkEditCount1.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.EditCount = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.EditCount = 0;
                    }
                    if (chkUpdateDate3.Checked == true)
                    {
                        objBOLInvoiceLogHideColumn.UpdateDate = 1;
                    }
                    else
                    {
                        objBOLInvoiceLogHideColumn.UpdateDate = 0;
                    }
                    ClsCommon.WriteErrorLogs("FrmInvoiceLogHideColumn.,Update, Message:-Set All value");
                    objBALInvoiceLogHideColumn.Update(objBOLInvoiceLogHideColumn);
                    MessageBox.Show("Hide Column SuccessFully");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceLogHideColumn,Function :btnInvoiceLogHideColumn_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void TransctionsLoadData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = new BALHideColumn().Select(new BOLHideColumn() { UserID = ClsCommon.UserID });
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["NoOfInvoice"].ToString() == "1")
                    {
                        chkNoOfInvoice.Checked = true;
                    }
                    else
                    {
                        chkNoOfInvoice.Checked = false;
                    }
                    if (dt.Rows[0]["CUSTOMER"].ToString() == "1")
                    {
                        chkCUSTOMER.Checked = true;
                    }
                    else
                    {
                        chkCUSTOMER.Checked = false;
                    }
                    if (dt.Rows[0]["NUM"].ToString() == "1")
                    {
                        chkNUM.Checked = true;
                    }
                    else
                    {
                        chkNUM.Checked = false;
                    }

                    if (dt.Rows[0]["DUEDATE"].ToString() == "1")
                    {
                        chkDUEDATE.Checked = true;
                    }
                    else
                    {
                        chkDUEDATE.Checked = false;
                    }
                    if (dt.Rows[0]["TERMS"].ToString() == "1")
                    {
                        chkTERMS.Checked = true;
                    }
                    else
                    {
                        chkTERMS.Checked = false;
                    }
                    if (dt.Rows[0]["AMOUNT"].ToString() == "1")
                    {
                        chkAMOUNT.Checked = true;
                    }
                    else
                    {
                        chkAMOUNT.Checked = false;
                    }
                    if (dt.Rows[0]["OPENBALANCE"].ToString() == "1")
                    {
                        chkOPENBALANCE.Checked = true;
                    }
                    else
                    {
                        chkOPENBALANCE.Checked = false;
                    }
                    if (dt.Rows[0]["SalesRep"].ToString() == "1")
                    {
                        chkSalesRep.Checked = true;
                    }
                    else
                    {
                        chkSalesRep.Checked = false;
                    }
                    if (dt.Rows[0]["NoOfTimesEdit"].ToString() == "1")
                    {
                        chkNoOfTimesEdit.Checked = true;
                    }
                    else
                    {
                        chkNoOfTimesEdit.Checked = false;
                    }
                    if (dt.Rows[0]["VIA_Services"].ToString() == "1")
                    {
                        chkVIA_Services.Checked = true;
                    }
                    else
                    {
                        chkVIA_Services.Checked = false;
                    }
                    if (dt.Rows[0]["ErrorLog"].ToString() == "1")
                    {
                        chkErrorLog.Checked = true;
                    }
                    else
                    {
                        chkErrorLog.Checked = false;
                    }
                    if (dt.Rows[0]["PaidStatus"].ToString() == "1")
                    {
                        chkPaidStatus.Checked = true;
                    }
                    else
                    {
                        chkPaidStatus.Checked = false;
                    }
                    if (dt.Rows[0]["PendingInvoice"].ToString() == "1")
                    {
                        chkPendingInvoice.Checked = true;
                    }
                    else
                    {
                        chkPendingInvoice.Checked = false;
                    }
                    if (dt.Rows[0]["Print1"].ToString() == "1")
                    {
                        chkPrint.Checked = true;
                    }
                    else
                    {
                        chkPrint.Checked = false;
                    }
                    if (dt.Rows[0]["Payit"].ToString() == "1")
                    {
                        chkPayit.Checked = true;
                    }
                    else
                    {
                        chkPayit.Checked = false;
                    }
                    if (dt.Rows[0]["Shipit"].ToString() == "1")
                    {
                        chkShipit.Checked = true;
                    }
                    else
                    {
                        chkShipit.Checked = false;
                    }
                    if (dt.Rows[0]["ShipStatus"].ToString() == "1")
                    {
                        chkShipStatus.Checked = true;
                    }
                    else
                    {
                        chkShipStatus.Checked = false;
                    }
                    if (dt.Rows[0]["TYPE"].ToString() == "1")
                    {
                        chkTYPE.Checked = true;
                    }
                    else
                    {
                        chkTYPE.Checked = false;
                    }
                    if (dt.Rows[0]["NUM1"].ToString() == "1")
                    {
                        chkNUM1.Checked = true;
                    }
                    else
                    {
                        chkNUM1.Checked = false;
                    }

                    if (dt.Rows[0]["ACCOUNT"].ToString() == "1")
                    {
                        chkACCOUNT.Checked = true;
                    }
                    else
                    {
                        chkACCOUNT.Checked = false;
                    }
                    if (dt.Rows[0]["TERMS1"].ToString() == "1")
                    {
                        chkTERMS1.Checked = true;
                    }
                    else
                    {
                        chkTERMS1.Checked = false;
                    }
                    if (dt.Rows[0]["AMOUNT1"].ToString() == "1")
                    {
                        chkAMOUNT1.Checked = true;
                    }
                    else
                    {
                        chkAMOUNT1.Checked = false;
                    }
                    if (dt.Rows[0]["SalesRep1"].ToString() == "1")
                    {
                        chkSalesRep1.Checked = true;
                    }
                    else
                    {
                        chkSalesRep1.Checked = false;
                    }
                    if (dt.Rows[0]["NoOfTimesEdit1"].ToString() == "1")
                    {
                        chkNoOfTimesEdit1.Checked = true;
                    }
                    else
                    {
                        chkNoOfTimesEdit1.Checked = false;
                    }
                    if (dt.Rows[0]["VIA_Service1"].ToString() == "1")
                    {
                        chkVIA_Service1.Checked = true;
                    }
                    else
                    {
                        chkVIA_Service1.Checked = false;
                    }
                    if (dt.Rows[0]["ErrorLog1"].ToString() == "1")
                    {
                        chkErrorLog1.Checked = true;
                    }
                    else
                    {
                        chkErrorLog1.Checked = false;
                    }
                    if (dt.Rows[0]["PaidStatus1"].ToString() == "1")
                    {
                        chkPaidStatus1.Checked = true;
                    }
                    else
                    {
                        chkPaidStatus1.Checked = false;
                    }
                    if (dt.Rows[0]["Print2"].ToString() == "1")
                    {
                        chkPrint1.Checked = true;
                    }
                    else
                    {
                        chkPrint1.Checked = false;
                    }
                    if (dt.Rows[0]["Payit2"].ToString() == "1")
                    {
                        chkPayit1.Checked = true;
                    }
                    else
                    {
                        chkPayit1.Checked = false;
                    }
                    if (dt.Rows[0]["Shipit2"].ToString() == "1")
                    {
                        chkShipit1.Checked = true;
                    }
                    else
                    {
                        chkShipit1.Checked = false;
                    }
                    if (dt.Rows[0]["ShipStatus2"].ToString() == "1")
                    {
                        chkShipStatus1.Checked = true;
                    }
                    else
                    {
                        chkShipStatus1.Checked = false;
                    }

                    if (dt.Rows[0]["AddButton"].ToString() == "1")
                    {
                        chkAddButton.Checked = true;
                    }
                    else
                    {
                        chkAddButton.Checked = false;
                    }
                    if (dt.Rows[0]["AddButton1"].ToString() == "1")
                    {
                        chkAddButton1.Checked = true;
                    }
                    else
                    {
                        chkAddButton1.Checked = false;
                    }
                    if (dt.Rows[0]["ShippingCost"].ToString() == "1")
                    {
                        chkShippingCost.Checked = true;
                    }
                    else
                    {
                        chkShippingCost.Checked = false;
                    }
                    if (dt.Rows[0]["ShippingCost1"].ToString() == "1")
                    {
                        chkShippingCost1.Checked = true;
                    }
                    else
                    {
                        chkShippingCost1.Checked = false;
                    }


                    if (dt.Rows[0]["Profit"].ToString() == "1")
                    {
                        chkProfit.Checked = true;
                    }
                    else
                    {
                        chkProfit.Checked = false;
                    }
                    if (dt.Rows[0]["ProfitPercentage"].ToString() == "1")
                    {
                        chkProfitPercentage.Checked = true;
                    }
                    else
                    {
                        chkProfitPercentage.Checked = false;
                    }

                    if (dt.Rows[0]["Profit1"].ToString() == "1")
                    {
                        chkProfit1.Checked = true;
                    }
                    else
                    {
                        chkProfit1.Checked = false;
                    }
                    if (dt.Rows[0]["ProfitPercentage1"].ToString() == "1")
                    {
                        chkProfitPercentage1.Checked = true;
                    }
                    else
                    {
                        chkProfitPercentage1.Checked = false;
                    }
                    if (dt.Rows[0]["MultiplePrint"].ToString() == "1")
                    {
                        chkMultiplePrint.Checked = true;
                    }
                    else
                    {
                        chkMultiplePrint.Checked = false;
                    }
                    if (dt.Rows[0]["ShipCharges"].ToString() == "1")
                    {
                        chkShipCharges.Checked = true;
                    }
                    else
                    {
                        chkShipCharges.Checked = false;
                    }
                    if (dt.Rows[0]["ShipCharges1"].ToString() == "1")
                    {
                        chkShipCharges1.Checked = true;
                    }
                    else
                    {
                        chkShipCharges1.Checked = false;
                    }


                    //Princi
                    if (dt.Rows[0]["DATE"].ToString() == "1")
                    {
                        chkDATE.Checked = true;
                    }
                    else
                    {
                        chkDATE.Checked = false;
                    }
                    if (dt.Rows[0]["DATE1"].ToString() == "1")
                    {
                        chkDATE1.Checked = true;
                    }
                    else
                    {
                        chkDATE1.Checked = false;
                    }
                    if (dt.Rows[0]["TIME"].ToString() == "1")
                    {
                        chkTIME.Checked = true;
                    }
                    else
                    {
                        chkTIME.Checked = false;
                    }
                    if (dt.Rows[0]["TIME1"].ToString() == "1")
                    {
                        chkTIME1.Checked = true;
                    }
                    else
                    {
                        chkTIME1.Checked = false;
                    }

                    if (dt.Rows[0]["UPDATEDATE"].ToString() == "1")
                    {
                        chkUPDATEDATE.Checked = true;
                    }
                    else
                    {
                        chkUPDATEDATE1.Checked = false;
                    }
                    if (dt.Rows[0]["UPDATEDATE1"].ToString() == "1")
                    {
                        chkUPDATEDATE1.Checked = true;
                    }
                    else
                    {
                        chkUPDATEDATE1.Checked = false;
                    }
                    if (dt.Rows[0]["UPDATETIME"].ToString() == "1")
                    {
                        chkUPADTETIME.Checked = true;
                    }
                    else
                    {
                        chkUPADTETIME.Checked = false;
                    }
                    if (dt.Rows[0]["UPDATETIME1"].ToString() == "1")
                    {
                        chkUPDATETIME1.Checked = true;
                    }
                    else
                    {
                        chkUPDATETIME1.Checked = false;
                    }
                    //
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmHideColumn,Function :TransctionsLoadData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void CustomerLogs()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = new BALCustomerLogHideColumn().Select(new BOLCustomerLogHideColumn() { UserID = ClsCommon.UserID });
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["NewCustomerName"].ToString() == "1")
                    {
                        chkNewCustomerName.Checked = true;
                    }
                    else
                    {
                        chkNewCustomerName.Checked = false;
                    }
                    if (dt.Rows[0]["OldCustomerName"].ToString() == "1")
                    {
                        chkOldCustomerName.Checked = true;
                    }
                    else
                    {
                        chkOldCustomerName.Checked = false;
                    }
                    if (dt.Rows[0]["NewSalutation"].ToString() == "1")
                    {
                        chkNewSalutation.Checked = true;
                    }
                    else
                    {
                        chkNewSalutation.Checked = false;
                    }
                    if (dt.Rows[0]["OldSalutation"].ToString() == "1")
                    {
                        chkOldSalutation.Checked = true;
                    }
                    else
                    {
                        chkOldSalutation.Checked = false;
                    }
                    if (dt.Rows[0]["NewFirstName"].ToString() == "1")
                    {
                        chkNewFirstName.Checked = true;
                    }
                    else
                    {
                        chkNewFirstName.Checked = false;
                    }
                    if (dt.Rows[0]["OldFirstName"].ToString() == "1")
                    {
                        chkOldFirstName.Checked = true;
                    }
                    else
                    {
                        chkOldFirstName.Checked = false;
                    }
                    if (dt.Rows[0]["NewMiddleName"].ToString() == "1")
                    {
                        chkNewMiddleName.Checked = true;
                    }
                    else
                    {
                        chkNewMiddleName.Checked = false;
                    }
                    if (dt.Rows[0]["OldMiddleName"].ToString() == "1")
                    {
                        chkOldMiddleName.Checked = true;
                    }
                    else
                    {
                        chkOldMiddleName.Checked = false;
                    }
                    if (dt.Rows[0]["NewLastName"].ToString() == "1")
                    {
                        chkNewLastName.Checked = true;
                    }
                    else
                    {
                        chkNewLastName.Checked = false;
                    }
                    if (dt.Rows[0]["OldLastName"].ToString() == "1")
                    {
                        chkOldLastName.Checked = true;
                    }
                    else
                    {
                        chkOldLastName.Checked = false;
                    }
                    if (dt.Rows[0]["EditCount"].ToString() == "1")
                    {
                        chkEditCount.Checked = true;
                    }
                    else
                    {
                        chkEditCount.Checked = false;
                    }
                    if (dt.Rows[0]["UpdateDate"].ToString() == "1")
                    {
                        chkUpdateDate2.Checked = true;
                    }
                    else
                    {
                        chkUpdateDate2.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCutomerLogHideColumn,Function :CustomerLogs. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void InvoiceLogs()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = new BALInvoiceLogHideColumn().Select(new BOLInvoiceLogHideColumn() { InvoiceID = ClsCommon.UserID });
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["NewRefNumber"].ToString() == "1")
                    {
                        chkNewRefNumber.Checked = true;
                    }
                    else
                    {
                        chkNewRefNumber.Checked = false;
                    }
                    if (dt.Rows[0]["NewCustomerName"].ToString() == "1")
                    {
                        chkNewCustomerName1.Checked = true;
                    }
                    else
                    {
                        chkNewCustomerName1.Checked = false;
                    }
                    if (dt.Rows[0]["OldCustomerName"].ToString() == "1")
                    {
                        OldCustomerName.Checked = true;
                    }
                    else
                    {
                        OldCustomerName.Checked = false;
                    }
                    if (dt.Rows[0]["NewPONumber"].ToString() == "1")
                    {
                        chkNewPONumber.Checked = true;
                    }
                    else
                    {
                        chkNewPONumber.Checked = false;
                    }
                    if (dt.Rows[0]["OldPONumber"].ToString() == "1")
                    {
                        chkOldPONumber.Checked = true;
                    }
                    else
                    {
                        chkOldPONumber.Checked = false;
                    }
                    if (dt.Rows[0]["NewTermsName"].ToString() == "1")
                    {
                        chkNewTermsName.Checked = true;
                    }
                    else
                    {
                        chkNewTermsName.Checked = false;
                    }
                    if (dt.Rows[0]["OldTermsName"].ToString() == "1")
                    {
                        chkOldTermsName.Checked = true;
                    }
                    else
                    {
                        chkOldTermsName.Checked = false;
                    }
                    if (dt.Rows[0]["NewDueDate"].ToString() == "1")
                    {
                        chkNewDueDate.Checked = true;
                    }
                    else
                    {
                        chkNewDueDate.Checked = false;
                    }
                    if (dt.Rows[0]["OldDueDate"].ToString() == "1")
                    {
                        chkOldDueDate.Checked = true;
                    }
                    else
                    {
                        chkOldDueDate.Checked = false;
                    }
                    if (dt.Rows[0]["NewSalesRepName"].ToString() == "1")
                    {
                        chkNewSalesRepName.Checked = true;
                    }
                    else
                    {
                        chkNewSalesRepName.Checked = false;
                    }
                    if (dt.Rows[0]["OldSalesRepName"].ToString() == "1")
                    {
                        chkOldSalesRepName.Checked = true;
                    }
                    else
                    {
                        chkOldSalesRepName.Checked = false;
                    }
                    if (dt.Rows[0]["NewshipDate"].ToString() == "1")
                    {
                        chkNewshipDate.Checked = true;
                    }
                    else
                    {
                        chkNewshipDate.Checked = false;
                    }
                    if (dt.Rows[0]["OldShipDate"].ToString() == "1")
                    {
                        chkOldShipDate.Checked = true;
                    }
                    else
                    {
                        chkOldShipDate.Checked = false;
                    }
                    if (dt.Rows[0]["NewShipping"].ToString() == "1")
                    {
                        chkNewShipping.Checked = true;
                    }
                    else
                    {
                        chkNewShipping.Checked = false;
                    }
                    if (dt.Rows[0]["OldShipping"].ToString() == "1")
                    {
                        chkOldShipping.Checked = true;
                    }
                    else
                    {
                        chkOldShipping.Checked = false;
                    }
                    if (dt.Rows[0]["NewTotal"].ToString() == "1")
                    {
                        chkNewTotal.Checked = true;
                    }
                    else
                    {
                        chkNewTotal.Checked = false;
                    }
                    if (dt.Rows[0]["OldTotal"].ToString() == "1")
                    {
                        chkOldTotal.Checked = true;
                    }
                    else
                    {
                        chkOldTotal.Checked = false;
                    }
                    if (dt.Rows[0]["NewAppliedAmount"].ToString() == "1")
                    {
                        chkNewAppliedAmount.Checked = true;
                    }
                    else
                    {
                        chkNewAppliedAmount.Checked = false;
                    }
                    if (dt.Rows[0]["OldAppliedAmount"].ToString() == "1")
                    {
                        chkOldAppliedAmount.Checked = true;
                    }
                    else
                    {
                        chkOldAppliedAmount.Checked = false;
                    }
                    if (dt.Rows[0]["NewBalanceDue"].ToString() == "1")
                    {
                        chkNewBalanceDue.Checked = true;
                    }
                    else
                    {
                        chkNewBalanceDue.Checked = false;
                    }
                    if (dt.Rows[0]["OldBalanceDue"].ToString() == "1")
                    {
                        chkOldBalanceDue.Checked = true;
                    }
                    else
                    {
                        chkOldBalanceDue.Checked = false;
                    }
                    if (dt.Rows[0]["NewMemo"].ToString() == "1")
                    {
                        chkNewMemo.Checked = true;
                    }
                    else
                    {
                        chkNewMemo.Checked = false;
                    }
                    if (dt.Rows[0]["OldMemo"].ToString() == "1")
                    {
                        chkOldMemo.Checked = true;
                    }
                    else
                    {
                        chkOldMemo.Checked = false;
                    }
                    if (dt.Rows[0]["EditCount"].ToString() == "1")
                    {
                        chkEditCount1.Checked = true;
                    }
                    else
                    {
                        chkEditCount1.Checked = false;
                    }
                    if (dt.Rows[0]["UpdateDate"].ToString() == "1")
                    {
                        chkUpdateDate3.Checked = true;
                    }
                    else
                    {
                        chkUpdateDate3.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCutomerLogHideColumn,Function :InvoiceLogs. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}