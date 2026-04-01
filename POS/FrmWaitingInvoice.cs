using ClosedXML;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Wordprocessing;
using Interop.QBFC13;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.Report;
using POS.VoidReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Xml;
using Color = System.Drawing.Color;
using DataTable = System.Data.DataTable;
using Font = System.Drawing.Font;

namespace POS
{
    public partial class FrmWaitingInvoice : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtAllInvoice = new DataTable();
        DataTable dtcustomer = new DataTable();
        DataTable dtshipping = new DataTable();
        BALUPS_FedExHistory BALFedEx = new BALUPS_FedExHistory();
        string BillAdd = "";
        string ShipAddress = "";
        BALAddressMaster ObjAddressBAL = new BALAddressMaster();
        BALInvoiceMaster objBALInvoice = new BALInvoiceMaster();

        public FrmWaitingInvoice()
        {
            InitializeComponent();
        }
        public void LoadAllInvoices()
        {
            dtAllInvoice = new DataTable();
            try
            {
                dtAllInvoice = new DataTable();
                DateTime dt1 = DateTime.Now.AddDays(-30);
                if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                {
                    dtAllInvoice = new BALInvoiceMaster().SelectWaitingInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                }
                else
                {
                    dtAllInvoice = new BALInvoiceMaster().SelectWaitingInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });

                }
                if (dtAllInvoice.Rows.Count > 0)
                {
                    int j = 0;
                    dgvAllInvoiceList.DataSource = null;
                    dgvAllInvoiceList.Rows.Clear();
                    for (int i = 0; i < dtAllInvoice.Rows.Count; i++)
                    {
                        try
                        {
                            dgvAllInvoiceList.Rows.Add();

                            if (dtAllInvoice.Rows[i]["Num"].ToString() != "")
                            {
                                dtshipping = BALFedEx.SelectByRefNo(dtAllInvoice.Rows[i]["Num"].ToString());
                                if (dtshipping.Rows.Count > 0)
                                {
                                    int LastRow = dtshipping.Rows.Count - 1;
                                    if (dtshipping.Rows[LastRow]["TotalCost"].ToString() != "")
                                    {
                                        dgvAllInvoiceList.Rows[j].Cells["ShipCharges"].Value = "Shipped " + dtshipping.Rows[LastRow]["TotalCost"].ToString();
                                    }
                                    else
                                    {
                                        dgvAllInvoiceList.Rows[j].Cells["ShipCharges"].Value = "Shipped";
                                    }
                                    dgvAllInvoiceList.Rows[j].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#b7a591");
                                    dgvAllInvoiceList.Rows[j].Cells["ShipStatus"].Value = "SHIPPED";
                                }
                                else
                                {
                                    if (dtAllInvoice.Rows[i]["ShipStatus"].ToString() != "")
                                    {
                                        dgvAllInvoiceList.Rows[j].Cells["ShipStatus"].Value = dtAllInvoice.Rows[i]["ShipStatus"].ToString();
                                    }
                                }
                                //Hiren
                                if (dtAllInvoice.Rows[i]["Num"].ToString().StartsWith("20000"))
                                {
                                    dgvAllInvoiceList.Rows[j].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF7F7F");
                                }

                            }
                            DataTable dtInvoice = new BALInvoiceDetails().SelectByID(new BOLInvoiceDetails() { InvoiceID = Convert.ToInt32(dtAllInvoice.Rows[i]["ID"].ToString()) });
                            if (dtInvoice.Rows.Count > 0)
                            {
                                DataRow[] drShipping = dtInvoice.Select("[ItemFullName]='shipping'");
                                {
                                    if (drShipping.Length > 0)
                                    {
                                        DataTable dtShipping = drShipping.CopyToDataTable();
                                        dgvAllInvoiceList.Rows[j].Cells["ShippingCost"].Value = "$" + dtShipping.Rows[0]["Rate"].ToString();
                                    }
                                    else
                                    {
                                        dgvAllInvoiceList.Rows[j].Cells["ShippingCost"].Value = "$0.00";
                                    }
                                }
                                DataRow[] drNote = dtInvoice.Select("[ItemFullName]='NOTES'");
                                {
                                    if (drNote.Length > 0)
                                    {
                                        dgvAllInvoiceList.Rows[j].DefaultCellStyle.BackColor = Color.SkyBlue;
                                    }
                                }
                            }
                            decimal TotalDetails = 0;
                            DataTable newDetails = new BALInvoiceDetails().SelectByInvID(new BOLInvoiceDetails() { InvoiceID = Convert.ToInt32(dtAllInvoice.Rows[i]["ID"].ToString()) });
                            if (newDetails.Rows.Count > 0)
                            {
                                foreach (DataRow dr in newDetails.Rows)
                                {
                                    if (dr["Cost"].ToString() == "")
                                    {
                                        dr["Cost"] = 0.00;
                                    }
                                    if (dr["Cost"].ToString() != "0.00")
                                    {
                                        TotalDetails += Convert.ToDecimal(dr["Quantity"].ToString()) * (Convert.ToDecimal(dr["Rate"].ToString()) - Convert.ToDecimal(dr["Cost"].ToString()));
                                    }
                                }
                            }
                            dgvAllInvoiceList.Rows[j].Cells["Profit"].Value = string.Concat(decimal.Round(TotalDetails, 2));
                            if (dtAllInvoice.Rows[i]["Amount"].ToString() != "0.00")
                            {
                                dgvAllInvoiceList.Rows[j].Cells["ProfitPercentage"].Value = string.Concat(decimal.Round((Convert.ToDecimal(TotalDetails) / Convert.ToDecimal(dtAllInvoice.Rows[i]["Amount"].ToString())) * 100, 2), '%');
                            }
                            else
                            {
                                dgvAllInvoiceList.Rows[j].Cells["ProfitPercentage"].Value = "0%";
                            }
                            dtcustomer = new BALInvoiceMaster().SelectByCusID(new BOLInvoiceMaster() { CustomerID = Convert.ToInt32(dtAllInvoice.Rows[i]["CustomerID"].ToString()) });
                            int Count = 0;
                            Count = dtcustomer.Rows.Count;
                            if (Count == 1)
                            {
                                dgvAllInvoiceList.Rows[j].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#EF6262");
                            }
                            dgvAllInvoiceList.Rows[j].Cells["NoOfInvoice"].Value = Count;
                            if (dtAllInvoice.Rows[i]["OpenBalance"].ToString() != "")
                            {
                                dgvAllInvoiceList.Rows[j].Cells["OpenBalance"].Value = Convert.ToDecimal(dtAllInvoice.Rows[i]["OpenBalance"].ToString());
                            }
                            DataTable dtInvoiceNumber = new BALInvoiceMaster().SelectByRefNumber(new BOLInvoiceMaster() { RefNumber = dtAllInvoice.Rows[i]["Num"].ToString() });
                            if (dtInvoiceNumber.Rows.Count > 0)
                            {
                                dgvAllInvoiceList.Rows[j].Cells["VIA_Services"].Value = dtInvoiceNumber.Rows[0]["ShipmethodName"].ToString();
                            }
                            if (dtAllInvoice.Rows[i]["PandingInvoice"].ToString() == "0")
                            {
                                dgvAllInvoiceList.Rows[j].Cells["PendingInvoice"].Value = "Panding";
                            }
                            if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "0")
                            {
                                dgvAllInvoiceList.Rows[j].Cells["PaidStatus"].Value = "Unpaid";
                            }
                            else if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "1")
                            {
                                dgvAllInvoiceList.Rows[j].Cells["PaidStatus"].Value = "Partially Paid";
                                dgvAllInvoiceList.Rows[j].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#90EE90");
                                //Hiren
                                //dgvAllInvoiceList.Rows[j].DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                            }
                            else if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "2")
                            {
                                dgvAllInvoiceList.Rows[j].Cells["PaidStatus"].Value = "Paid";
                                dgvAllInvoiceList.Rows[j].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#228B22");
                                //Hiren
                                //dgvAllInvoiceList.Rows[j].DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                            }
                            if (dtAllInvoice.Rows[i]["Amount"].ToString() != "")
                            {
                                dgvAllInvoiceList.Rows[j].Cells["InvoiceAmount"].Value = Convert.ToDecimal(dtAllInvoice.Rows[i]["Amount"].ToString());
                            }




                            dgvAllInvoiceList.Rows[j].Cells["InvID"].Value = dtAllInvoice.Rows[i]["ID"].ToString();
                            //if (dtAllInvoice.Rows[i]["ShipStatus"].ToString() != "")
                            //{
                            //    dgvAllInvoiceList.Rows[j].Cells["ShipStatus"].Value = dtAllInvoice.Rows[i]["ShipStatus"].ToString();
                            //}
                            dgvAllInvoiceList.Rows[j].Cells["CustomerID"].Value = dtAllInvoice.Rows[i]["CustomerID"].ToString();

                            dgvAllInvoiceList.Rows[j].Cells["CustomerNm"].Value = dtAllInvoice.Rows[i]["Customer"].ToString();

                            if (dtAllInvoice.Rows[i]["Num"].ToString() != "")
                            {
                                //dgvAllInvoiceList.Rows[j].Cells[4].Value = Convert.ToInt32(dtAllInvoice.Rows[i]["Num"].ToString());
                                dgvAllInvoiceList.Rows[j].Cells["InvoiceNum"].Value = dtAllInvoice.Rows[i]["Num"].ToString();
                            }
                            if (dtAllInvoice.Rows[i]["ModifiedTime"].ToString() != "")
                            {
                                DateTime date = Convert.ToDateTime(dtAllInvoice.Rows[i]["ModifiedTime"].ToString());
                                dgvAllInvoiceList.Rows[j].Cells["InvoiceDate"].Value = date;

                                // CreateTime Replace modified //Bhumika 
                                dgvAllInvoiceList.Rows[j].Cells["TIME"].Value = date.ToString("HH:mm:ss");
                            }
                            if (dtAllInvoice.Rows[i]["DueDate"].ToString() != "")
                            {
                                DateTime date = Convert.ToDateTime(dtAllInvoice.Rows[i]["DueDate"].ToString());
                                dgvAllInvoiceList.Rows[j].Cells["DueDate"].Value = date.ToShortDateString();
                            }
                            dgvAllInvoiceList.Rows[j].Cells["Term"].Value = dtAllInvoice.Rows[i]["Terms"].ToString();

                            dgvAllInvoiceList.Rows[j].Cells["Rep"].Value = dtAllInvoice.Rows[i]["SalesRep"].ToString();
                            dgvAllInvoiceList.Rows[j].Cells["CountEdit"].Value = dtAllInvoice.Rows[i]["InvoiceEdit"].ToString();

                            if (dtAllInvoice.Rows[i]["ErrorLog"].ToString() != "")
                            {
                                dgvAllInvoiceList.Rows[j].Cells["Error"].Value = "ViewError";
                            }
                            j++;
                        }
                        catch (Exception ex)
                        {
                            ClsCommon.WriteErrorLogs("Form:FrmCustomerCenter, Function :LoadAllInvoices. Message:" + ex.Message);
                            MessageBox.Show("Error:" + ex.Message);
                        }
                    }
                    dgvAllInvoiceList.Sort(dgvAllInvoiceList.Columns["NoOfInvoice"], ListSortDirection.Ascending);


                }
                else
                {
                    dgvAllInvoiceList.Rows.Clear();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmCustomerCenter, Function :LoadAllInvoices. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        private void FrmWaitingInvoice_Load(object sender, EventArgs e)
        {
            LoadShipStatus();
            LoadAllInvoices();
            if (ClsCommon.UserType == "Admin")
            {
                dgvAllInvoiceList.Columns["Profit"].Visible = true;
                dgvAllInvoiceList.Columns["ProfitPercentage"].Visible = true;
            }
            else
            {
                dgvAllInvoiceList.Columns["Profit"].Visible = false;
                dgvAllInvoiceList.Columns["ProfitPercentage"].Visible = false;
            }
        }
        //Hiren
        public void LoadShipStatus()
        {
            try
            {
                DataTable dtShipStatus = new BALShipStatus().Select(new BOLShipStatus());
                if (dtShipStatus.Rows.Count > 0)
                {
                    DataRow[] dr = dtShipStatus.Select();
                    if (dr.Length > 0)
                    {
                        DataTable dtIncome = dr.CopyToDataTable();
                        if (dtIncome.Rows.Count > 0)
                        {
                            ShipStatus.DataSource = dtIncome;
                            ShipStatus.DisplayMember = "ShipStatus";
                            ShipStatus.ValueMember = "ShipStatus";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmWaitingInvoice,Function :LoadShipStatus. Message:" + ex.Message);
            }
        }
        private void dgvAllInvoiceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    dgvAllInvoiceList.Sort(dgvAllInvoiceList.Columns[e.ColumnIndex], ListSortDirection.Ascending);
                }
                else if (e.RowIndex > -1)
                {
                    if (e.ColumnIndex == 17)
                    {
                        int ID1 = Convert.ToInt32(dgvAllInvoiceList.CurrentRow.Cells["InvID"].Value);
                        PrintINV(ref ID1);
                        ClsCommon.INVID = ID1;
                        ClsCommon.ObjInvoiceMaster.InvoicePrintHistory(ClsCommon.INVID);
                        ClsCommon.ObjInvoiceMaster.PrintSave(ClsCommon.INVID);
                    }
                    else if (e.ColumnIndex == 18)
                    {
                        FrmPaymentDetail frm = new FrmPaymentDetail();
                        frm.Show();
                        frm.loadData(Convert.ToInt32(dgvAllInvoiceList.CurrentRow.Cells["InvID"].Value.ToString()));
                        frm.CheckEnable();
                        frm.BringToFront();
                    }
                    else if (e.ColumnIndex == 22)
                    {
                        {
                            dtshipping = BALFedEx.SelectByRefNo(dgvAllInvoiceList.CurrentRow.Cells["InvoiceNum"].Value.ToString());
                            if (dtshipping.Rows.Count > 0)
                            {
                                int LastRow = dtshipping.Rows.Count - 1;
                                if (dtshipping.Rows[LastRow]["TotalCost"].ToString() != "")
                                {
                                    dgvAllInvoiceList.CurrentRow.Cells["ShipCharges"].Value = "Shipped " + dtshipping.Rows[LastRow]["TotalCost"].ToString();
                                }
                                else
                                {
                                    dgvAllInvoiceList.CurrentRow.Cells["ShipCharges"].Value = "Shipped";
                                }
                                dgvAllInvoiceList.CurrentRow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B7A591");
                                dgvAllInvoiceList.CurrentRow.Cells["ShipStatus"].Value = "SHIPPED";
                            }
                            ClsCommon.objUPS.BringToFront();
                            ClsCommon.objUPS.StartPosition = FormStartPosition.Manual;
                            DataTable DT = new DataTable();
                            DT = new BALInvoiceMaster().SelectByID(new BOLInvoiceMaster() { ID = Convert.ToInt32(dgvAllInvoiceList.CurrentRow.Cells["InvID"].Value.ToString()) });
                            if (DT.Rows.Count > 0)
                            {
                                if (DT.Rows[0]["TermName"].ToString() == "COD")
                                {
                                    ClsCommon.COD = true;
                                    ClsCommon.CODAmount = DT.Rows[0]["Total"].ToString();
                                }
                                else
                                {
                                    ClsCommon.COD = false;
                                }
                                ClsCommon.Weight = 0;
                                DataTable dt2 = new BALItemMaster().GetWeight();
                                DataView dv = null;
                                dv = dt2.DefaultView;
                                DataTable dt1 = new BALInvoiceDetails().SelectByID(new BOLInvoiceDetails() { InvoiceID = Convert.ToInt32(dgvAllInvoiceList.CurrentRow.Cells["InvID"].Value.ToString()) });
                                for (int n = 0; n < dt1.Rows.Count; n++)
                                {
                                    dv.RowFilter = "ItemName='" + dt1.Rows[n]["ItemFullName"].ToString() + "'";
                                    if (dv.Count > 0)
                                    {
                                        if (dv.ToTable().Rows[0]["Weight"].ToString() != "")
                                        {
                                            decimal TotalWeight = 0;
                                            if (dv.ToTable().Rows[0]["Weight"].ToString() != "" && dt1.Rows[n]["Quantity"].ToString() != "")
                                            {
                                                TotalWeight = Math.Round(Convert.ToDecimal(dv.ToTable().Rows[0]["Weight"].ToString()) * Convert.ToDecimal(dt1.Rows[n]["Quantity"].ToString()), 2);
                                            }
                                            if (TotalWeight != 0)
                                            {
                                                ClsCommon.Weight += TotalWeight;
                                            }
                                            else
                                            {
                                                ClsCommon.Weight += Convert.ToDecimal(dv.ToTable().Rows[0]["Weight"].ToString());
                                            }
                                        }
                                    }
                                }
                                ClsCommon.RefNumber = DT.Rows[0]["RefNumber"].ToString();
                                ClsCommon.ShipMethod = DT.Rows[0]["ShipMethod"].ToString();
                                ClsCommon.objUPS.Total = dgvAllInvoiceList.CurrentRow.Cells["InvoiceAmount"].Value.ToString();
                                ClsCommon.objUPS.Location = new Point(230, 80);
                                ClsCommon.objUPS.Clear1();
                                ClsCommon.objUPS.ShowDialog();
                                dtshipping = BALFedEx.SelectByRefNo(dgvAllInvoiceList.CurrentRow.Cells["InvoiceNum"].Value.ToString());
                                if (dtshipping.Rows.Count > 0)
                                {
                                    int LastRow = dtshipping.Rows.Count - 1;
                                    if (dtshipping.Rows[LastRow]["TotalCost"].ToString() != "")
                                    {
                                        dgvAllInvoiceList.CurrentRow.Cells["ShipCharges"].Value = "Shipped " + dtshipping.Rows[LastRow]["TotalCost"].ToString();
                                    }
                                    else
                                    {
                                        dgvAllInvoiceList.CurrentRow.Cells["ShipCharges"].Value = "Shipped";
                                    }
                                    dgvAllInvoiceList.CurrentRow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B7A591");
                                    dgvAllInvoiceList.CurrentRow.Cells["ShipStatus"].Value = "SHIPPED";
                                }
                            }
                            else
                            {
                                MessageBox.Show("Credit Memo Not Allow Ship it");
                            }
                        }
                    }
                    else if (e.ColumnIndex == 25)
                    {
                        if (dgvAllInvoiceList.CurrentRow.Cells["ShipStatus"].Value != null)
                        {
                            int ID = Convert.ToInt32(dgvAllInvoiceList.CurrentRow.Cells["InvID"].Value.ToString());
                            objBALInvoice.UpdateShipStatus(ID, Convert.ToString(dgvAllInvoiceList.CurrentRow.Cells["ShipStatus"].Value));
                        }
                        else
                        {
                            int ID = Convert.ToInt32(dgvAllInvoiceList.CurrentRow.Cells["InvID"].Value.ToString());
                            objBALInvoice.UpdateShipStatus(ID, Convert.ToString(dgvAllInvoiceList.CurrentRow.Cells["ShipStatus"].Value));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmWaitingInvoice,Function :dgvAllInvoiceList_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void PrintINV(ref int ID)
        {
            try
            {
                //Invoice
                DataTable dtDetail = new DataTable();
                dtDetail.Columns.Add("Quantity", typeof(decimal));
                dtDetail.Columns.Add("ItemCode", typeof(string));
                dtDetail.Columns.Add("Description", typeof(string));
                dtDetail.Columns.Add("PriceEach", typeof(string));
                dtDetail.Columns.Add("Amount", typeof(decimal));
                //Hiren
                dtDetail.Columns.Add("WebPrice", typeof(decimal));
                int id = Convert.ToInt32(ID);
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
                                dr1["Amount"] = dr["Amount"].ToString();
                                dr1["WebPrice"] = dr["WebPrice"].ToString();

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
                    FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                    crViewer.Text = "Invoice Report";
                    crViewer.crystalReportViewer.ReportSource = cryRptInvoiceReport;
                    crViewer.btnPrint.Visible = true;
                    crViewer.crystalReportViewer.ShowPrintButton = false;
                    crViewer.crystalReportViewer.ShowPrintButton = false;
                    crViewer.Visible = false;
                    crViewer.crystalReportViewer.PrintReport();
                    //IMEI
                    DataTable IMEI = new DataTable();
                    IMEI.Columns.Add("IMEINumber", typeof(string));
                    IMEI.Columns.Add("ITEMName", typeof(string));
                    IMEI.Columns.Add("Reason", typeof(string));
                    foreach (DataRow dr in dt1.Rows)
                    {
                        if (dr["ItemFullName"].ToString() != null)
                        {
                            string[] str = dr["IMEINumber"].ToString().Split(',');
                            for (int S = 0; S < str.Length; S++)
                            {
                                if (str[S].ToString() != "")
                                {
                                    DataRow dr2 = IMEI.NewRow();
                                    dr2["ITEMName"] = dr["ItemFullName"].ToString();
                                    dr2["Reason"] = dr["Reason"].ToString();
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
                        cryRptIMEIReport.SetParameterValue("TxnDate", dt.Rows[0]["TxnDate"].ToString());
                        cryRptIMEIReport.SetParameterValue("InvoiceNo", dt.Rows[0]["RefNumber"].ToString());
                        cryRptIMEIReport.SetParameterValue("PONumber", dt.Rows[0]["PONumber"].ToString());
                        cryRptIMEIReport.SetParameterValue("Terms", dt.Rows[0]["TermName"].ToString() == "" ? "" : dt.Rows[0]["TermName"].ToString());
                        cryRptIMEIReport.SetParameterValue("Rep", dt.Rows[0]["salesName"].ToString() == "" ? "" : dt.Rows[0]["salesName"].ToString());
                        cryRptIMEIReport.SetParameterValue("ShipDate", dt.Rows[0]["ShipDate"].ToString());
                        cryRptIMEIReport.SetParameterValue("Via", dt.Rows[0]["ShipMethod"].ToString() == "" ? "" : dt.Rows[0]["CreatedName"].ToString());
                        cryRptIMEIReport.SetParameterValue("CustomerName", dt.Rows[0]["CustomerFullName"].ToString());
                        cryRptIMEIReport.SetParameterValue("BillAddress", BillAdd);
                        cryRptIMEIReport.SetParameterValue("ShipAddress", ShipAddress);
                        cryRptIMEIReport.SetParameterValue("Memo", dt.Rows[0]["Memo"].ToString());
                        //PRINCY
                        cryRptIMEIReport.SetParameterValue("AppliedAmount", dt.Rows[0]["AppliedAmount"].ToString());
                        cryRptIMEIReport.SetParameterValue("BalanceDue", dt.Rows[0]["BalanceDue"].ToString());
                        cryRptIMEIReport.SetParameterValue("TagName", "Invoice");
                        cryRptIMEIReport.SetParameterValue("NumberName", "Invoice #");
                        FrmCrystalReportViewer crViewer1 = new FrmCrystalReportViewer();
                        crViewer1.Text = "Invoice Report";
                        crViewer1.crystalReportViewer.ReportSource = cryRptIMEIReport;
                        crViewer1.btnPrint.Visible = true;
                        crViewer1.crystalReportViewer.ShowPrintButton = false;
                        crViewer1.crystalReportViewer.ShowPrintButton = false;
                        crViewer1.Visible = false;
                        crViewer1.crystalReportViewer.PrintReport();
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmWaitingInvoice,Function :PrintINV. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
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
        private void dgvAllInvoiceList_DoubleClick(object sender, EventArgs e)
        {
            if (ClsCommon.FunctionVisibility("InvUpdate", "CustomerCenter"))
            {


                ClsCommon.ObjInvoiceMaster.LoadTable();
                ClsCommon.ObjInvoiceMaster.EditableField();
                ClsCommon.ObjInvoiceMaster.Show();
                ClsCommon.ObjInvoiceMaster.LoadData(dgvAllInvoiceList.CurrentRow.Cells["InvID"].Value.ToString());
                ClsCommon.ObjInvoiceMaster.AllowLowestPrice();
                ClsCommon.ObjInvoiceMaster.CheckDate();
                //ClsCommon.ObjInvoiceMaster.DisplayNotes();
                //}
            }
            else
                MessageBox.Show("You can not access");
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn column in dgvAllInvoiceList.Columns)
                {
                    if (column.Index != 0 && column.Index != 1 && column.Index != 17 && column.Index != 18 && column.Index != 22 && column.Index != 25)
                    {
                        bool hasData = false;
                        foreach (DataGridViewRow row in dgvAllInvoiceList.Rows)
                        {
                            if (row.Cells[column.Index].Value != null && !string.IsNullOrEmpty(row.Cells[column.Index].Value.ToString()))
                            {
                                hasData = true;
                                break;
                            }
                        }
                        if (hasData)
                        {
                            dt.Columns.Add(column.HeaderText);
                        }
                    }
                }
                foreach (DataGridViewRow row in dgvAllInvoiceList.Rows)
                {
                    DataRow dataRow = dt.NewRow();
                    int dtColumnIndex = 0;

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.ColumnIndex != 0 && cell.ColumnIndex != 1 && cell.ColumnIndex != 17 && cell.ColumnIndex != 18 && cell.ColumnIndex != 22 && cell.ColumnIndex != 25 && cell.Value != null)
                        {
                            if (dtColumnIndex < dt.Columns.Count)
                            {
                                dataRow[dtColumnIndex] = cell.Value.ToString();
                                dtColumnIndex++;
                            }
                        }
                    }
                    dt.Rows.Add(dataRow);
                }
                if (dt.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                        FilterIndex = 1,
                        RestoreDirectory = true,
                        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                    };

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "Sheet1");
                            wb.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Export Successful!");

                        var app = new Microsoft.Office.Interop.Excel.Application();
                        app.Visible = true;
                        app.Workbooks.Open(sfd.FileName, ReadOnly: false);
                    }
                }
                else
                {
                    MessageBox.Show("No data available to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmWaitingInvoice, Function:btnExport_Click. Message:" + ex.Message);
                MessageBox.Show("Error during export: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}