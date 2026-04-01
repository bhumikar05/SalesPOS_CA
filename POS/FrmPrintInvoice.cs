using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.Report;

namespace POS
{
    public partial class FrmPrintInvoice : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtInvoice = new DataTable();
        DataTable dtCustomer = new DataTable();
        string BillAdd = ""; string ShipAddress = "";
     
        BALAddressMaster ObjAddressBAL = new BALAddressMaster();

        PageSettings oPage = new PageSettings();
        public FrmPrintInvoice() 
        {
            InitializeComponent();
        }
  
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            GetCustomer();
            LoadFilter();
            
        }
        public void Clear()
        {
            dgvInvoiceList.Rows.Clear();
            chkAll.Checked = false;
            cmbCustomer.SelectedIndex = 0;
            cmbFilter.SelectedIndex = 0;
            txtRefNo.Text = "";
            btnPrint.Enabled = false;
            cmbCustomer.Enabled = false;
            txtRefNo.Enabled = false;
            lblErrorMsg.Text = "";
        }

        private void LoadFilter()
        {
            DataTable dtFilter = new DataTable();
            dtFilter.Columns.Add("Name", typeof(string));
            dtFilter.Columns.Add("Value", typeof(string));

            DataRow dr = dtFilter.NewRow();
            dtFilter.Rows.Add("Select Filter", "0");
            dtFilter.Rows.Add("Customer", "1");
            dtFilter.Rows.Add("RefNumber", "2");

            cmbFilter.DataSource = dtFilter;
            cmbFilter.DisplayMember = "Name";
            cmbFilter.ValueMember = "Value";
            cmbFilter.SelectedIndex = 0;
        }

        public void GetCustomer()
        {
            try
            {
                if (ClsCommon.FunctionVisibility("CustomerNumberOnly", "CustomerCenter"))
                {
                    dtCustomer = new DataTable();
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = 0,IsCustomerNumber=0 });
                    else
                        dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = ClsCommon.UserID, IsCustomerNumber = 1 });
                }
                else
                {
                    dtCustomer = new DataTable();
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = 0, IsCustomerNumber = 0 });
                    else
                        dtCustomer = new BALCustomerMaster().SelectActiveCustomer(new BOLCustomerMaster() { SalesRepID = ClsCommon.UserID, IsCustomerNumber = 0 });
                }
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

        private void DisplayMessage(string Text, string Mode)
        {
            try
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
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Function :IssueReceiptDisplayMsg. Message:" + ex.Message);
            }
        }

        private Boolean CheckValidation()
        {
            Boolean ISValid = true;
            try
            {
                if (cmbFilter.SelectedIndex == 0)
                {
                    ISValid = false;
                    DisplayMessage("Please select Filter Tpye", "E");
                    cmbFilter.Focus();
                }
                else if (cmbFilter.SelectedIndex == 1 && cmbCustomer.SelectedIndex == 0)
                {
                    ISValid = false;
                    DisplayMessage("Please select Customer", "E");
                    cmbCustomer.Focus();
                }
                else if (cmbFilter.SelectedIndex == 2 && txtRefNo.Text == "")
                {
                    ISValid = false;
                    DisplayMessage("Please Enter InvNo", "E");
                    txtRefNo.Focus();
                }
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Function :CheckValidation. Message:" + ex.Message);
                return ISValid;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {                
                if(CheckValidation())
                {
                    dtInvoice = new DataTable();
                    int Type = Convert.ToInt16(cmbFilter.SelectedValue);

                    if (Type == 1)
                    {
                        if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                            dtInvoice = new BALInvoiceMaster().SelectAllInvForPrintByCustomer(new BOLInvoiceMaster() { SalesRepID = 0, CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                        else
                            dtInvoice = new BALInvoiceMaster().SelectAllInvForPrintByCustomer(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue) });
                    }

                    else if (Type == 2)
                    {
                        if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                            dtInvoice = new BALInvoiceMaster().SelectAllInvForPrintByRefNo(new BOLInvoiceMaster() { SalesRepID = 0, RefNumber=txtRefNo.Text });
                        else
                            dtInvoice = new BALInvoiceMaster().SelectAllInvForPrintByRefNo(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, RefNumber = txtRefNo.Text });
                    }
                    if (dtInvoice.Rows.Count > 0)
                    {
                            int j = 0;
                            dgvInvoiceList.Rows.Clear();
                            for (int i = 0; i < dtInvoice.Rows.Count; i++)
                            {
                                dgvInvoiceList.Rows.Add();
                                dgvInvoiceList.Rows[j].Cells[0].Value = dtInvoice.Rows[i]["ID"].ToString();
                                dgvInvoiceList.Rows[j].Cells[2].Value = dtInvoice.Rows[i]["CustomerName"].ToString();
                                dgvInvoiceList.Rows[j].Cells[3].Value = dtInvoice.Rows[i]["RefNumber"].ToString();
                                dgvInvoiceList.Rows[j].Cells[4].Value = Convert.ToDateTime(dtInvoice.Rows[i]["TxnDate"].ToString()).ToString("MM-dd-yyyy");
                                dgvInvoiceList.Rows[j].Cells[5].Value = dtInvoice.Rows[i]["SalesRepName"].ToString();
                                dgvInvoiceList.Rows[j].Cells[6].Value = dtInvoice.Rows[i]["Total"].ToString();
                                j++;
                            }
                    }
                    else
                    {
                        dgvInvoiceList.Rows.Clear();
                    }
                    
                }
                  
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPrintInvoice, Function :btnLoad_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void FrmPrintInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            Clear();
            e.Cancel = true;
            this.Hide();
            this.Parent = null;
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbFilter.SelectedIndex != 0)
                {
                    cmbCustomer.Enabled = (cmbFilter.SelectedIndex == 1);
                    txtRefNo.Enabled = (cmbFilter.SelectedIndex == 2);
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPrintInvoice, Function :cmbFilter_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnPrinterSettings_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                btnPrint.Enabled = true;
            }
            else
            {
                btnPrint.Enabled = false;
            }
        }

        public void LoadAddress(Int32 CustomerID)
        {
            try
            {
                // CustomerData
                DataTable dt = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = CustomerID });
                if (dt.Rows.Count > 0)
                {
                    BillAdd = "";
                    if (dt.Rows[0]["Address1"].ToString() != "")
                        BillAdd = dt.Rows[0]["Address1"].ToString();
                    if (dt.Rows[0]["Address2"].ToString() != "")
                        BillAdd = BillAdd + "\r\n" + dt.Rows[0]["Address2"].ToString();
                    if (dt.Rows[0]["Address3"].ToString() != "")
                        BillAdd = BillAdd + "\r\n" + dt.Rows[0]["Address3"].ToString();

                    if (dt.Rows[0]["City"].ToString() != "" && dt.Rows[0]["State"].ToString() != "")
                        BillAdd = BillAdd + "\r\n" + dt.Rows[0]["City"].ToString() + "," + dt.Rows[0]["State"].ToString();
                    else if (dt.Rows[0]["City"].ToString() != "" && dt.Rows[0]["State"].ToString() != "")
                        BillAdd = BillAdd + "\r\n" + dt.Rows[0]["City"].ToString();
                    else if (dt.Rows[0]["City"].ToString() == "" && dt.Rows[0]["State"].ToString() != "")
                        BillAdd = BillAdd + "\r\n" + dt.Rows[0]["State"].ToString();

                    if (dt.Rows[0]["PostalCode"].ToString() != "" && dt.Rows[0]["Country"].ToString() != "")
                        BillAdd = BillAdd + "\r\n" + dt.Rows[0]["PostalCode"].ToString() + "," + dt.Rows[0]["Country"].ToString();
                    else if (dt.Rows[0]["Country"].ToString() != "" && dt.Rows[0]["PostalCode"].ToString() == "")
                        BillAdd = BillAdd + "\r\n" + dt.Rows[0]["Country"].ToString();
                    else if (dt.Rows[0]["Country"].ToString() == "" && dt.Rows[0]["PostalCode"].ToString() != "")
                        BillAdd = BillAdd + "\r\n" + dt.Rows[0]["PostalCode"].ToString();

                }


            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerCenter, Function :LoadAddress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtDetail = new DataTable();
                dtDetail.Columns.Add("Quantity", typeof(decimal));
                dtDetail.Columns.Add("ItemCode", typeof(string));
                dtDetail.Columns.Add("Description", typeof(string));
                dtDetail.Columns.Add("PriceEach", typeof(string));
                dtDetail.Columns.Add("Amount", typeof(decimal));
                //Hiren
                dtDetail.Columns.Add("WebPrice", typeof(decimal));
                for (int i = 0; i < dgvInvoiceList.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvInvoiceList.Rows[i].Cells[1].Value) == true)
                    {
                        int id = Convert.ToInt32(dgvInvoiceList.Rows[i].Cells[0].Value);
                        ClsCommon.INVID = id;
                        DataTable dt = new BALInvoiceMaster().SelectByID(new BOLInvoiceMaster() { ID = Convert.ToInt32(id) });
                        if (dt.Rows.Count > 0)
                        {
                            int CusID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());
                            LoadAddress(CusID);

                            if (dt.Rows[0]["ShipAddressID"].ToString() != "")
                            {
                                DataTable dt2 = ObjAddressBAL.SelectByID(dt.Rows[0]["ShipAddressID"].ToString());
                                if (dt2.Rows.Count > 0)
                                {
                                    if (dt2.Rows[0]["Address1"].ToString() != "")
                                        ShipAddress = dt2.Rows[0]["Address1"].ToString();
                                    if (dt2.Rows[0]["Address2"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dt2.Rows[0]["Address2"].ToString();
                                    if (dt2.Rows[0]["Address3"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dt2.Rows[0]["Address3"].ToString();

                                    if (dt2.Rows[0]["City"].ToString() != "" && dt2.Rows[0]["State"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dt2.Rows[0]["City"].ToString() + "," + dt2.Rows[0]["State"].ToString();
                                    else if (dt2.Rows[0]["City"].ToString() != "" && dt2.Rows[0]["State"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dt2.Rows[0]["City"].ToString();
                                    else if (dt2.Rows[0]["City"].ToString() == "" && dt2.Rows[0]["State"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dt2.Rows[0]["State"].ToString();

                                    if (dt2.Rows[0]["PostalCode"].ToString() != "" && dt2.Rows[0]["Country"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dt2.Rows[0]["PostalCode"].ToString() + "," + dt2.Rows[0]["Country"].ToString();
                                    else if (dt2.Rows[0]["Country"].ToString() != "" && dt2.Rows[0]["PostalCode"].ToString() == "")
                                        ShipAddress = ShipAddress + "\r\n" + dt2.Rows[0]["Country"].ToString();
                                    else if (dt2.Rows[0]["Country"].ToString() == "" && dt2.Rows[0]["PostalCode"].ToString() != "")
                                        ShipAddress = ShipAddress + "\r\n" + dt2.Rows[0]["PostalCode"].ToString();

                                }

                            }

                            dtDetail.Rows.Clear();
                            DataTable dt1 = new BALInvoiceDetails().SelectByID(new BOLInvoiceDetails() { InvoiceID = Convert.ToInt32(id) });
                            if (dt1.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt1.Rows)
                                {
                                    if (dr["ItemFullName"].ToString() != null)
                                    {
                                        DataRow dr1 = dtDetail.NewRow();
                                        dr1["Quantity"] = dr["Quantity"].ToString();
                                        dr1["ItemCode"] = dr["ItemFullName"].ToString();
                                        dr1["Description"] = dr["Decs"].ToString();
                                        if (dr["Rate"].ToString() == null)
                                            dr1["PriceEach"] = "";
                                        else
                                            dr1["PriceEach"] = dr["Rate"].ToString();
                                        dr1["WebPrice"] = dr["WebPrice"].ToString();

                                        dr1["Amount"] = dr["Amount"].ToString();
                                        dtDetail.Rows.Add(dr1);
                                    }
                                }
                            }


                            rptInvoiceReport cryRptInvoiceReport = new rptInvoiceReport();
                            cryRptInvoiceReport.SetDataSource(dtDetail);
                            cryRptInvoiceReport.SetParameterValue("TxnDate", dt.Rows[0]["TxnDate"].ToString());
                            cryRptInvoiceReport.SetParameterValue("InvoiceNo", dt.Rows[0]["RefNumber"].ToString());
                            cryRptInvoiceReport.SetParameterValue("PONumber", dt.Rows[0]["PONumber"].ToString());
                            cryRptInvoiceReport.SetParameterValue("Terms", dt.Rows[0]["TermName"].ToString() == "" ? "" : dt.Rows[0]["TermName"].ToString());
                            cryRptInvoiceReport.SetParameterValue("Rep", dt.Rows[0]["salesName"].ToString() == "" ? "" : dt.Rows[0]["salesName"].ToString());
                            cryRptInvoiceReport.SetParameterValue("ShipDate", dt.Rows[0]["ShipDate"].ToString());
                            cryRptInvoiceReport.SetParameterValue("Via", dt.Rows[0]["ShipMethod"].ToString() == "" ? "" : dt.Rows[0]["CreatedName"].ToString());
                            cryRptInvoiceReport.SetParameterValue("CustomerName", dt.Rows[0]["CustomerFullName"].ToString());
                            cryRptInvoiceReport.SetParameterValue("BillAddress", BillAdd);
                            cryRptInvoiceReport.SetParameterValue("ShipAddress", ShipAddress);
                            //princy

                            cryRptInvoiceReport.SetParameterValue("CustomerMessage", dt.Rows[0]["LogName"].ToString());
                            cryRptInvoiceReport.SetParameterValue("AppliedAmount", dt.Rows[0]["AppliedAmount"].ToString());
                            cryRptInvoiceReport.SetParameterValue("BalanceDue", dt.Rows[0]["BalanceDue"].ToString());
                            //
                            cryRptInvoiceReport.SetParameterValue("Memo", dt.Rows[0]["Memo"].ToString());
                            cryRptInvoiceReport.SetParameterValue("TagName", "Invoice");
                            cryRptInvoiceReport.SetParameterValue("NumberName", "Invoice #");
                            if (dt.Rows[0]["TaxAmount"].ToString() != "")
                            {
                                cryRptInvoiceReport.ReportDefinition.ReportObjects["Text2"].ObjectFormat.EnableSuppress = false;
                                cryRptInvoiceReport.ReportDefinition.ReportObjects["Text12"].ObjectFormat.EnableSuppress = false;
                                cryRptInvoiceReport.SetParameterValue("TaxAmount", dt.Rows[0]["TaxAmount"].ToString());
                            }
                            else
                            {
                                cryRptInvoiceReport.ReportDefinition.ReportObjects["Text2"].ObjectFormat.EnableSuppress = true;
                                cryRptInvoiceReport.ReportDefinition.ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
                                cryRptInvoiceReport.SetParameterValue("TaxAmount", "0.00");
                            }
                            if (dt.Rows[0]["TaxPercent"].ToString() != "")
                            {
                                cryRptInvoiceReport.SetParameterValue("TaxPercent", dt.Rows[0]["TaxPercent"].ToString());
                            }
                            else
                            {
                                cryRptInvoiceReport.SetParameterValue("TaxPercent", "0.0");
                            }
                            if (dt.Rows[0]["TaxName"].ToString() != "")
                            {
                                cryRptInvoiceReport.SetParameterValue("TaxName", dt.Rows[0]["TaxName"].ToString());
                            }
                            else
                            {
                                cryRptInvoiceReport.SetParameterValue("TaxName", "");
                            }

                            oPage = printDialog1.PrinterSettings.DefaultPageSettings;
                            cryRptInvoiceReport.PrintToPrinter(printDialog1.PrinterSettings, oPage, false);

                            ClsCommon.ObjInvoiceMaster.InvoicePrintHistory(ClsCommon.INVID);
                            DisplayMessage("Invoice Print Successfully : "+ dgvInvoiceList.Rows[i].Cells[3].Value, "I");

                        }

                    }

                }

              
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPrintInvoice, Function :btnPrint_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
           
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked == true)
                {
                    for (int i = 0; i < dgvInvoiceList.Rows.Count; i++)
                    {
                        dgvInvoiceList.Rows[i].Cells[1].Value = true;
                    }
                }
                else
                {
                    for (int i = 0; i < dgvInvoiceList.Rows.Count; i++)
                    {
                        dgvInvoiceList.Rows[i].Cells[1].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPrintInvocie,Function :chkAll_CheckedChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }
    }
}
