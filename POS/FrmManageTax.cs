using ClosedXML;
using ClosedXML.Excel;
using CrystalDecisions.CrystalReports.Engine;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
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
    public partial class FrmManageTax : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtAllInvoice = new DataTable();
        BALInvoiceMaster objBALInvoice = new BALInvoiceMaster();
        BOLInvoiceMaster objBOLInvoice = new BOLInvoiceMaster();
        FrmCustomerCenter objCustomerCenter = new FrmCustomerCenter();
        BALAddressMaster ObjAddressBAL = new BALAddressMaster();
        string ShipAddress = "";
        string BillAdd = "";
        public FrmManageTax()
        {
            InitializeComponent();
            try
            {
                cmbInvoiceDate.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmManageTax, Function :FrmManageTax. Message:" + ex.Message);
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }
        public void LoadAllInvoices()
        {
            try
            {
                txtSearch.Text = "";
                lblFrom.Visible = false; lblTo.Visible = false; dtFrom.Visible = false; dtTo.Visible = false;
                if (cmbInvoiceDate.SelectedIndex == 0)
                {
                    //today
                    dtAllInvoice = new DataTable();
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                    else
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                }
                else if (cmbInvoiceDate.SelectedIndex == 1)
                {
                    //yesterday
                    dtAllInvoice = new DataTable();
                    DateTime dt1 = DateTime.Now.AddDays(-1);
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                    else
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 2)
                {
                    //this month
                    dtAllInvoice = new DataTable();
                    DateTime dt = DateTime.Now;
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                    else
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 3)
                {
                    //this week
                    dtAllInvoice = new DataTable();
                    DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
                    DateTime dt1 = dt.AddDays(6);
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                    else
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 4)
                {
                    //last month
                    dtAllInvoice = new DataTable();
                    DateTime dt = DateTime.Now.AddMonths(-1);
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                    else
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 5)
                {
                    //this ficsal year
                    dtAllInvoice = new DataTable();
                    int year = DateTime.Now.Year;
                    DateTime firstDay = Convert.ToDateTime(year + "-" + "01" + "-" + "01");
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = firstDay.ToString("yyyy-MM-dd"), EndDate = firstDay.AddYears(1).AddDays(-1).ToString("yyyy-MM-dd") });
                    else
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = firstDay.ToString("yyyy-MM-dd"), EndDate = firstDay.AddYears(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 6)
                {
                    //all
                    dtAllInvoice = new DataTable();
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = null, EndDate = null });
                    else
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = null, EndDate = null });
                }

                else if (cmbInvoiceDate.SelectedIndex == 7)
                {
                    //custom
                    dtAllInvoice = new DataTable();
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
                    else
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });

                    lblFrom.Visible = true; lblTo.Visible = true; dtFrom.Visible = true; dtTo.Visible = true;
                }
                dgvAllInvoiceList.Rows.Clear();
                if (dtAllInvoice.Rows.Count > 0)
                {
                    int j = 0;
                    for (int i = 0; i < dtAllInvoice.Rows.Count; i++)
                    {
                        dgvAllInvoiceList.Rows.Add();
                        if (dtAllInvoice.Rows[j]["TaxID"].ToString() != "" && dtAllInvoice.Rows[j]["TaxID"].ToString() != "0")
                        {
                            dgvAllInvoiceList.Rows[j].Cells["X"].Value = "Tax";
                        }
                        else
                        {
                            dgvAllInvoiceList.Rows[j].Cells["X"].Value = "Non";
                        }
                        dgvAllInvoiceList.Rows[j].Cells["CustomerName"].Value = dtAllInvoice.Rows[i]["Customer"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["InvID"].Value = dtAllInvoice.Rows[i]["ID"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["RefNumber"].Value = dtAllInvoice.Rows[i]["Num"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["Total"].Value = dtAllInvoice.Rows[i]["Amount"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["TaxPer"].Value = dtAllInvoice.Rows[i]["TaxPercent"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["TotalTax"].Value = dtAllInvoice.Rows[i]["TaxAmount"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["PayAmount"].Value = dtAllInvoice.Rows[i]["AppliedAmount"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["DueBalance"].Value = dtAllInvoice.Rows[i]["OpenBalance"].ToString();
                        j++;
                    }
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmManageTax, Function :LoadAllInvoices. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);

            }
        }
        private void dgvAllInvoiceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    dgvAllInvoiceList.Sort(dgvAllInvoiceList.Columns[e.ColumnIndex], ListSortDirection.Descending);
                }
                else if (e.ColumnIndex == 9)
                {
                    string x = dgvAllInvoiceList.Rows[e.RowIndex].Cells["X"].Value?.ToString();
                    decimal OldTotal = 0;
                    decimal OldTaxPer = 0;
                    decimal OldTotalTax = 0;
                    decimal OldPayAmount = 0;
                    decimal OldDueBalance = 0;
                    decimal NewTotal = 0;
                    decimal NewTaxPer = 0;
                    decimal NewTotalTax = 0;
                    decimal NewDueBalance = 0;
                    DataTable  dt = new BALInvoiceMaster().SelectByID(new BOLInvoiceMaster() { ID = Convert.ToInt32(dgvAllInvoiceList.CurrentRow.Cells["InvID"].Value.ToString()) });
                    if (dt.Rows.Count > 0)
                    {
                        if (dgvAllInvoiceList.CurrentRow.Cells["Total"].Value.ToString() != "" && dgvAllInvoiceList.CurrentRow.Cells["Total"].Value.ToString() != "0")
                        {
                            OldTotal = Convert.ToDecimal(dgvAllInvoiceList.CurrentRow.Cells["Total"].Value.ToString());
                        }

                        if (dgvAllInvoiceList.CurrentRow.Cells["TaxPer"].Value.ToString() != "" && dgvAllInvoiceList.CurrentRow.Cells["TaxPer"].Value.ToString() != "0")
                        {
                            OldTaxPer = Convert.ToDecimal(dgvAllInvoiceList.CurrentRow.Cells["TaxPer"].Value.ToString());
                        }

                        if (dgvAllInvoiceList.CurrentRow.Cells["TotalTax"].Value.ToString() != "" && dgvAllInvoiceList.CurrentRow.Cells["TotalTax"].Value.ToString() != "0")
                        {
                            OldTotalTax = Convert.ToDecimal(dgvAllInvoiceList.CurrentRow.Cells["TotalTax"].Value.ToString());
                        }

                        if (dgvAllInvoiceList.CurrentRow.Cells["PayAmount"].Value.ToString() != "" && dgvAllInvoiceList.CurrentRow.Cells["PayAmount"].Value.ToString() != "0")
                        {
                            OldPayAmount = Convert.ToDecimal(dgvAllInvoiceList.CurrentRow.Cells["PayAmount"].Value.ToString());
                        }

                        if (dgvAllInvoiceList.CurrentRow.Cells["DueBalance"].Value.ToString() != "" && dgvAllInvoiceList.CurrentRow.Cells["DueBalance"].Value.ToString() != "0")
                        {
                            OldDueBalance = Convert.ToDecimal(dgvAllInvoiceList.CurrentRow.Cells["DueBalance"].Value.ToString());
                        }

                        if (x == "Non")
                        {
                        
                                if (dt.Rows[0]["SalesTaxPercentage"].ToString() != "" && dt.Rows[0]["SalesTaxPercentage"].ToString() != "0.00")
                                {
                                    NewTaxPer = Convert.ToDecimal(dt.Rows[0]["SalesTaxPercentage"].ToString());
                                    OldTotal = Convert.ToDecimal(dt.Rows[0]["Total"].ToString());
                                    OldDueBalance = Convert.ToDecimal(dt.Rows[0]["BalanceDue"].ToString());
                                    NewTotalTax = OldTotal * NewTaxPer / 100;
                                    NewTotal = OldTotal + NewTotalTax;
                                    NewDueBalance = OldDueBalance + NewTotalTax;
                                    objBOLInvoice.ID = Convert.ToInt32(dgvAllInvoiceList.CurrentRow.Cells["InvID"].Value.ToString());
                                    objBOLInvoice.TaxID = Convert.ToInt32(dt.Rows[0]["SalesTaxID"].ToString());
                                    objBOLInvoice.Total =decimal.Round(NewTotal,2);
                                    objBOLInvoice.TaxPercent = decimal.Round(NewTaxPer,2);
                                    objBOLInvoice.BalanceDue = decimal.Round(NewDueBalance,2);
                                    objBOLInvoice.TaxAmount = decimal.Round(NewTotalTax,2);
                                }
                                else
                                {
                                    DialogResult result = MessageBox.Show("First select customer in Tax");
                                }
                            
                        }
                        else
                        {
                            NewTotal = OldTotal - OldTotalTax;
                            OldTaxPer = 0;
                            NewDueBalance = OldDueBalance - OldTotalTax;

                            objBOLInvoice.ID = Convert.ToInt32(dgvAllInvoiceList.Rows[e.RowIndex].Cells["InvID"].Value.ToString());
                            objBOLInvoice.Total = NewTotal;
                            objBOLInvoice.TaxPercent = 0;
                            objBOLInvoice.BalanceDue = NewDueBalance;
                            objBOLInvoice.TaxAmount = 0;
                            objBOLInvoice.TaxID = 0;
                        }
                        objBALInvoice.ConvertTax(objBOLInvoice);
                        LoadAllInvoices();
                    }
                }
                //else if(e.ColumnIndex == 10)
                //{
                //    int InvID = Convert.ToInt32(dgvAllInvoiceList.CurrentRow.Cells["InvID"].Value);
                //    objCustomerCenter.PrintINV(ref InvID);
                //}
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmManageTax, Function :dgvAllInvoiceList_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void FrmManageTax_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                cmbInvoiceDate.SelectedIndex = 0;
                ClsCommon.ObjManageTax.Hide();
                ClsCommon.ObjManageTax.Parent = null;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmManageTax, Function :FrmManageTax_FormClosing. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void cmbInvoiceDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadAllInvoices();
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmManageTax, Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void FrmManageTax_Load(object sender, EventArgs e)
        {
            try
            {
                cmbInvoiceDate.SelectedIndex = 0;
                LoadAllInvoices();
                txtSearch.Text = "";
            }

            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmManageTax, Function :FrmManageTax_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        
        }
        private void dtFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                dtAllInvoice = new DataTable();
                if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
                else
                    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
                dgvAllInvoiceList.Rows.Clear();
                if (dtAllInvoice.Rows.Count > 0)
                {
                    int j = 0;
                    for (int i = 0; i < dtAllInvoice.Rows.Count; i++)
                    {
                        dgvAllInvoiceList.Rows.Add();
                        if (dtAllInvoice.Rows[j]["TaxID"].ToString() != "" && dtAllInvoice.Rows[j]["TaxID"].ToString() != "0")
                        {
                            dgvAllInvoiceList.Rows[j].Cells["X"].Value = "Tax";
                        }
                        else
                        {
                            dgvAllInvoiceList.Rows[j].Cells["X"].Value = "Non";
                        }
                        dgvAllInvoiceList.Rows[j].Cells["CustomerName"].Value = dtAllInvoice.Rows[i]["Customer"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["InvID"].Value = dtAllInvoice.Rows[i]["ID"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["RefNumber"].Value = dtAllInvoice.Rows[i]["Num"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["Total"].Value = dtAllInvoice.Rows[i]["Amount"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["TaxPer"].Value = dtAllInvoice.Rows[i]["TaxPercent"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["TotalTax"].Value = dtAllInvoice.Rows[i]["TaxAmount"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["PayAmount"].Value = dtAllInvoice.Rows[i]["AppliedAmount"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["DueBalance"].Value = dtAllInvoice.Rows[i]["OpenBalance"].ToString();
                        j++;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmManageTax, Function :dtFrom_Leave. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void dtTo_Leave(object sender, EventArgs e)
        {
            try
            {

                dtAllInvoice = new DataTable();
                if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
                else
                    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
                dgvAllInvoiceList.Rows.Clear();
                if (dtAllInvoice.Rows.Count > 0)
                {
                    int j = 0;
                    for (int i = 0; i < dtAllInvoice.Rows.Count; i++)
                    {
                        dgvAllInvoiceList.Rows.Add();
                        if (dtAllInvoice.Rows[j]["TaxID"].ToString() != "" && dtAllInvoice.Rows[j]["TaxID"].ToString() != "0")
                        {
                            dgvAllInvoiceList.Rows[j].Cells["X"].Value = "Tax";
                        }
                        else
                        {
                            dgvAllInvoiceList.Rows[j].Cells["X"].Value = "Non";
                        }
                        dgvAllInvoiceList.Rows[j].Cells["CustomerName"].Value = dtAllInvoice.Rows[i]["Customer"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["InvID"].Value = dtAllInvoice.Rows[i]["ID"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["RefNumber"].Value = dtAllInvoice.Rows[i]["Num"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["Total"].Value = dtAllInvoice.Rows[i]["Amount"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["TaxPer"].Value = dtAllInvoice.Rows[i]["TaxPercent"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["TotalTax"].Value = dtAllInvoice.Rows[i]["TaxAmount"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["PayAmount"].Value = dtAllInvoice.Rows[i]["AppliedAmount"].ToString();
                        dgvAllInvoiceList.Rows[j].Cells["DueBalance"].Value = dtAllInvoice.Rows[i]["OpenBalance"].ToString();
                        j++;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmManageTax, Function :dtTo_Leave. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text != "")
                {
                    string searchText = txtSearch.Text.Replace("'", "''");

                    string query;
                    if (searchText.Equals("Tax", StringComparison.OrdinalIgnoreCase))
                    {
                        // Filter for Tax records
                        query = "Convert(TaxID, 'System.String') <> ''";
                    }
                    else if (searchText.Equals("Non", StringComparison.OrdinalIgnoreCase))
                    {
                        // Filter for Non-Tax records
                        query = "Convert(TaxID, 'System.String') is null";
                    }
                    else
                    {
                        // General search across all columns
                        query = $"[Customer] LIKE '%{searchText}%' " +
                                $"OR Convert(Num, 'System.String') LIKE '%{searchText}%' " +
                                $"OR Convert(Amount, 'System.String') LIKE '%{searchText}%' " +
                                $"OR Convert(TaxPercent, 'System.String') LIKE '%{searchText}%' " +
                                $"OR Convert(TaxAmount, 'System.String') LIKE '%{searchText}%' " +
                                $"OR Convert(AppliedAmount, 'System.String') LIKE '%{searchText}%' " +
                                $"OR Convert(OpenBalance, 'System.String') LIKE '%{searchText}%'";
                    }
                    DataRow[] row = dtAllInvoice.Select(query);
                    if (row.Length > 0)
                    {
                        DataTable dtNew = row.CopyToDataTable();

                        int j = 0;
                        dgvAllInvoiceList.Rows.Clear();
                        for (int i = 0; i < dtNew.Rows.Count; i++)
                        {
                            dgvAllInvoiceList.Rows.Add();
                            if (dtNew.Rows[j]["TaxAmount"].ToString() != "" && dtNew.Rows[j]["TaxAmount"].ToString() != "0.00")
                            {
                                dgvAllInvoiceList.Rows[j].Cells["X"].Value = "Tax";
                            }
                            else
                            {
                                dgvAllInvoiceList.Rows[j].Cells["X"].Value = "Non";
                            }
                            dgvAllInvoiceList.Rows[j].Cells["CustomerName"].Value = dtNew.Rows[i]["Customer"].ToString();
                            dgvAllInvoiceList.Rows[j].Cells["InvID"].Value = dtNew.Rows[i]["ID"].ToString();
                            dgvAllInvoiceList.Rows[j].Cells["RefNumber"].Value = dtNew.Rows[i]["Num"].ToString();
                            dgvAllInvoiceList.Rows[j].Cells["Total"].Value = dtNew.Rows[i]["Amount"].ToString();
                            dgvAllInvoiceList.Rows[j].Cells["TaxPer"].Value = dtNew.Rows[i]["TaxPercent"].ToString();
                            dgvAllInvoiceList.Rows[j].Cells["TotalTax"].Value = dtNew.Rows[i]["TaxAmount"].ToString();
                            dgvAllInvoiceList.Rows[j].Cells["PayAmount"].Value = dtNew.Rows[i]["AppliedAmount"].ToString();
                            dgvAllInvoiceList.Rows[j].Cells["DueBalance"].Value = dtNew.Rows[i]["OpenBalance"].ToString();
                            j++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmManageTaxNonTax, Function :btnSe_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvAllInvoiceList.Rows.Clear();
            if (dtAllInvoice.Rows.Count > 0)
            {
                int j = 0;
                for (int i = 0; i < dtAllInvoice.Rows.Count; i++)
                {
                    dgvAllInvoiceList.Rows.Add();
                    if (dtAllInvoice.Rows[j]["TaxID"].ToString() != "" && dtAllInvoice.Rows[j]["TaxID"].ToString() != "0")
                    {
                        dgvAllInvoiceList.Rows[j].Cells["X"].Value = "Tax";
                    }
                    else
                    {
                        dgvAllInvoiceList.Rows[j].Cells["X"].Value = "Non";
                    }
                    dgvAllInvoiceList.Rows[j].Cells["CustomerName"].Value = dtAllInvoice.Rows[i]["Customer"].ToString();
                    dgvAllInvoiceList.Rows[j].Cells["InvID"].Value = dtAllInvoice.Rows[i]["ID"].ToString();
                    dgvAllInvoiceList.Rows[j].Cells["RefNumber"].Value = dtAllInvoice.Rows[i]["Num"].ToString();
                    dgvAllInvoiceList.Rows[j].Cells["Total"].Value = dtAllInvoice.Rows[i]["Amount"].ToString();
                    dgvAllInvoiceList.Rows[j].Cells["TaxPer"].Value = dtAllInvoice.Rows[i]["TaxPercent"].ToString();
                    dgvAllInvoiceList.Rows[j].Cells["TotalTax"].Value = dtAllInvoice.Rows[i]["TaxAmount"].ToString();
                    dgvAllInvoiceList.Rows[j].Cells["PayAmount"].Value = dtAllInvoice.Rows[i]["AppliedAmount"].ToString();
                    dgvAllInvoiceList.Rows[j].Cells["DueBalance"].Value = dtAllInvoice.Rows[i]["OpenBalance"].ToString();
                    j++;
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                bool isAnyCheckboxChecked = false;
                foreach (DataGridViewRow row in dgvAllInvoiceList.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Print"].Value) == true)
                    {
                        isAnyCheckboxChecked = true;
                        break;
                    }
                }
                if (!isAnyCheckboxChecked)
                {
                    MessageBox.Show("Please select at least one record to print.");
                    return;
                }
                string pdfPath = "";
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                bool IsFirst = false;
                if (dgvAllInvoiceList.Rows.Count > 0)
                {
                    if (printDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (string.IsNullOrEmpty(pdfPath))
                        {
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                pdfPath = saveFileDialog.FileName;
                            }
                        }
                    }
                    for (int i = 0; i < dgvAllInvoiceList.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgvAllInvoiceList.Rows[i].Cells["Print"].Value) == true)
                        {
                            int ID1 = Convert.ToInt32(dgvAllInvoiceList.Rows[i].Cells["InvID"].Value);
                            ClsCommon.INVID = ID1;
                            ClsCommon.ObjInvoiceMaster.InvoicePrintHistory(ClsCommon.INVID);
                            ClsCommon.ObjInvoiceMaster.PrintSave(ClsCommon.INVID);
                            try
                            {
                                DataTable dtDetail = new DataTable();
                                dtDetail.Columns.Add("Quantity", typeof(decimal));
                                dtDetail.Columns.Add("ItemCode", typeof(string));
                                dtDetail.Columns.Add("Description", typeof(string));
                                dtDetail.Columns.Add("PriceEach", typeof(string));
                                dtDetail.Columns.Add("Amount", typeof(decimal));
                                dtDetail.Columns.Add("WebPrice", typeof(decimal));
                                DataTable dt = new BALInvoiceMaster().SelectByID(new BOLInvoiceMaster() { ID = Convert.ToInt32(ID1) });
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
                                    DataTable dt1 = new BALInvoiceDetails().SelectByID(new BOLInvoiceDetails() { InvoiceID = Convert.ToInt32(ID1) });
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
                                    ReportDocument reportDocument = new ReportDocument();
                                    reportDocument.Load(Application.StartupPath + "\\Report\\rptInvoiceReport.rpt");
                                    reportDocument.SetDataSource(dtDetail);
                                    reportDocument.SetParameterValue("TxnDate", dt.Rows[0]["TxnDate"].ToString());
                                    reportDocument.SetParameterValue("InvoiceNo", dt.Rows[0]["RefNumber"].ToString());
                                    reportDocument.SetParameterValue("PONumber", dt.Rows[0]["PONumber"].ToString());
                                    reportDocument.SetParameterValue("Terms", dt.Rows[0]["TermName"].ToString() == "" ? "" : dt.Rows[0]["TermName"].ToString());
                                    reportDocument.SetParameterValue("Rep", dt.Rows[0]["salesName"].ToString() == "" ? "" : dt.Rows[0]["salesName"].ToString());
                                    reportDocument.SetParameterValue("ShipDate", dt.Rows[0]["ShipDate"].ToString());
                                    reportDocument.SetParameterValue("Via", dt.Rows[0]["ShipMethod"].ToString() == "" ? "" : dt.Rows[0]["CreatedName"].ToString());
                                    reportDocument.SetParameterValue("CustomerName", dt.Rows[0]["CustomerFullName"].ToString());
                                    reportDocument.SetParameterValue("BillAddress", BillAdd);
                                    reportDocument.SetParameterValue("ShipAddress", ShipAddress);
                                    reportDocument.SetParameterValue("Memo", dt.Rows[0]["Memo"].ToString());
                                    reportDocument.SetParameterValue("TagName", "Invoice");
                                    reportDocument.SetParameterValue("NumberName", "Invoice #");

                                    if (dt.Rows[0]["TaxAmount"].ToString() != "")
                                    {
                                        reportDocument.ReportDefinition.ReportObjects["Text2"].ObjectFormat.EnableSuppress = false;
                                        reportDocument.ReportDefinition.ReportObjects["Text12"].ObjectFormat.EnableSuppress = false;
                                        reportDocument.SetParameterValue("TaxAmount", dt.Rows[0]["TaxAmount"].ToString());
                                    }
                                    else
                                    {
                                        reportDocument.ReportDefinition.ReportObjects["Text2"].ObjectFormat.EnableSuppress = true;
                                        reportDocument.ReportDefinition.ReportObjects["Text12"].ObjectFormat.EnableSuppress = true;
                                        reportDocument.SetParameterValue("TaxAmount", "0.00");
                                    }
                                    if (dt.Rows[0]["TaxPercent"].ToString() != "")
                                    {
                                        reportDocument.SetParameterValue("TaxPercent", dt.Rows[0]["TaxPercent"].ToString());
                                    }
                                    else
                                    {
                                        reportDocument.SetParameterValue("TaxPercent", "0.0");
                                    }
                                    if (dt.Rows[0]["TaxName"].ToString() != "")
                                    {
                                        reportDocument.SetParameterValue("TaxName", dt.Rows[0]["TaxName"].ToString());
                                    }
                                    else
                                    {
                                        reportDocument.SetParameterValue("TaxName", "");
                                    }
                                    reportDocument.PrintOptions.PrinterName = printDialog1.PrinterSettings.PrinterName;
                                    if (printDialog1.PrinterSettings.PrinterName == "Microsoft Print to PDF")
                                    {
                                        if (IsFirst == false)
                                        {
                                            pdfPath = saveFileDialog.FileName + ".pdf";
                                            reportDocument.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, pdfPath);
                                            IsFirst = true;
                                        }
                                        else
                                        {
                                            string FileName = dt.Rows[0]["RefNumber"].ToString() + ".pdf";
                                            pdfPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(saveFileDialog.FileName), FileName);
                                            reportDocument.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, pdfPath);
                                        }
                                    }
                                    else
                                    {
                                        reportDocument.PrintOptions.PrinterName = printDialog1.PrinterSettings.PrinterName;
                                        reportDocument.PrintToPrinter(printDialog1.PrinterSettings.Copies, true, 0, 0);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                ClsCommon.WriteErrorLogs("Form:FrmCustomerCenter,Function :PrintINV. Message:" + ex.Message);
                                MessageBox.Show("Error:" + ex.Message);
                            }
                        }
                    }
                }
                checkSelectAll.Checked = false;
                MessageBox.Show("Print Successfully done");
                for (int i = 0; i < dgvAllInvoiceList.Rows.Count; i++)
                {
                    dgvAllInvoiceList.Rows[i].Cells["Print"].Value = false;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmManageTaxNonTax,Function :btnPrint_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void checkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkSelectAll.Checked == true)
                {
                    for (int i = 0; i < dgvAllInvoiceList.Rows.Count; i++)
                    {
                        dgvAllInvoiceList.Rows[i].Cells["Print"].Value = true;
                    }
                }
                else
                {
                    for (int i = 0; i < dgvAllInvoiceList.Rows.Count; i++)
                    {
                        dgvAllInvoiceList.Rows[i].Cells["Print"].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmManageTaxNonTax,Function :checkSelectAll_CheckedChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}