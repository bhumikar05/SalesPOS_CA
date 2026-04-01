using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClosedXML.Excel;
using ComponentFactory.Krypton.Toolkit;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Font = System.Drawing.Font;
using System.Windows.Media;
using Color = System.Drawing.Color;
using System.Text.RegularExpressions;
using static Telerik.WinControls.VirtualKeyboard.VirtualKeyboardNativeMethods;

namespace POS
{
    public partial class FrmInvoiceProfitMaster : ComponentFactory.Krypton.Toolkit.KryptonForm
    {

        DataTable dtAllInvoice = new DataTable();
        BALItemMaster ObjItemBAL = new BALItemMaster();
        BOLItemMaster ObjItemBOL = new BOLItemMaster();
        Boolean CustomerNumberOnly = false;

        public FrmInvoiceProfitMaster()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

            this.dgvAllInvoiceList.DefaultCellStyle.Font = new Font("", 10);
            dgvAllInvoiceList.RowTemplate.Height = 30;
            dgvAllInvoiceList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAllInvoiceList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvAllInvoiceList.EnableHeadersVisualStyles = false;

            this.dgInvDetail.DefaultCellStyle.Font = new Font("", 10);
            dgInvDetail.RowTemplate.Height = 23;
            dgInvDetail.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgInvDetail.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8F, FontStyle.Regular);
            dgInvDetail.EnableHeadersVisualStyles = false;

            this.dgInvDetail.Columns["Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgInvDetail.Columns["Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgInvDetail.Columns["Amt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgInvDetail.Columns["Cost"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgInvDetail.Columns["Profit1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            Clear();
        }

        public void display()
        {
            try
            {

                if (ClsCommon.FunctionVisibility("CustomerNumberOnly", "CustomerCenter"))
                {
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                    {
                        CustomerNumberOnly = false;
                    }
                    else
                    {
                        CustomerNumberOnly = true;

                    }
                }
                else
                {
                    CustomerNumberOnly = false;
                }
                lblFrom.Visible = false; lblTo.Visible = false; dtFrom.Visible = false; dtTo.Visible = false;

                dtAllInvoice = new DataTable();
                //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                //else
                //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });

                dgvAllInvoiceList.Rows.Clear();
                if (dtAllInvoice.Rows.Count > 0)
                {
                    int j = 0;

                    for (int i = 0; i < dtAllInvoice.Rows.Count; i++)
                    {
                        try
                        {
                            dgvAllInvoiceList.Rows.Add();

                            dgvAllInvoiceList.Rows[j].Cells[0].Value = dtAllInvoice.Rows[i]["ID"].ToString();
                            if (CustomerNumberOnly == true)
                            {
                                dgvAllInvoiceList.Rows[j].Cells[1].Value = dtAllInvoice.Rows[i]["CustomerNumber"].ToString();
                            }
                            else
                            {
                                dgvAllInvoiceList.Rows[j].Cells[1].Value = dtAllInvoice.Rows[i]["Customer"].ToString();
                            }
                            //dgvAllInvoiceList.Rows[j].Cells[1].Value = dtAllInvoice.Rows[i]["Customer"].ToString();
                            if (dtAllInvoice.Rows[i]["Num"].ToString() != "")
                            {
                                dgvAllInvoiceList.Rows[j].Cells[2].Value = dtAllInvoice.Rows[i]["Num"].ToString();
                            }
                            if (dtAllInvoice.Rows[i]["Date"].ToString() != "")
                            {
                                DateTime date = Convert.ToDateTime(dtAllInvoice.Rows[i]["Date"].ToString());
                                dgvAllInvoiceList.Rows[j].Cells[3].Value = date.ToShortDateString();
                            }

                            if (dtAllInvoice.Rows[i]["Amount"].ToString() != "")
                            {
                                dgvAllInvoiceList.Rows[j].Cells[4].Value = Convert.ToDecimal(dtAllInvoice.Rows[i]["Amount"].ToString());
                            }

                            dgvAllInvoiceList.Rows[j].Cells[5].Value = dtAllInvoice.Rows[i]["SalesRep"].ToString();


                            int INVID = Convert.ToInt32(dtAllInvoice.Rows[i]["ID"].ToString());
                            decimal Total = 0;
                            DataTable dt = new BALInvoiceDetails().SelectByInvID(new BOLInvoiceDetails() { InvoiceID = INVID });
                            if (dt.Rows.Count > 0)
                            {

                                foreach (DataRow dr in dt.Rows)
                                {
                                    if (dr["Cost"].ToString() == "")
                                    {
                                        dr["Cost"] = 0.00;
                                    }
                                    if (dr["Cost"].ToString() != "0.00")
                                    {
                                        Total += Convert.ToDecimal(dr["Quantity"].ToString()) * (Convert.ToDecimal(dr["Rate"].ToString()) - Convert.ToDecimal(dr["Cost"].ToString()));
                                    }
                                    if (dr["Cost"].ToString() == "0.00")
                                    {
                                        dgvAllInvoiceList.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 110, 74);
                                    }
                                }
                            }
                            dgvAllInvoiceList.Rows[j].Cells[6].Value = decimal.Round(Total, 2);
                            if (dtAllInvoice.Rows[i]["Amount"].ToString() != "0.00")
                            {
                                dgvAllInvoiceList.Rows[j].Cells[7].Value = string.Concat(decimal.Round((Convert.ToDecimal(Total) / Convert.ToDecimal(dtAllInvoice.Rows[i]["Amount"].ToString())) * 100, 2), '%');
                            }
                            else
                            {
                                dgvAllInvoiceList.Rows[j].Cells[7].Value = 0 + '%';
                            }
                            j++;
                        }
                        catch (Exception ex)
                        {
                            ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster, Function :display. Message:" + ex.Message);
                            MessageBox.Show("Error:" + ex.Message);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster, Function :display. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        public void Clear()
        {
            txtSearch.Text = "";
            cmbInvoiceDate.SelectedIndex = 0;
            display();
        }
        private void cmbInvoiceDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (ClsCommon.FunctionVisibility("CustomerNumberOnly", "CustomerCenter"))
                {
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                    {
                        CustomerNumberOnly = false;
                    }
                    else
                    {
                        CustomerNumberOnly = true;

                    }
                }
                else
                {
                    CustomerNumberOnly = false;
                }
                lblFrom.Visible = false; lblTo.Visible = false; dtFrom.Visible = false; dtTo.Visible = false;

                if (cmbInvoiceDate.SelectedIndex == 0)
                {
                    //today
                    dtAllInvoice = new DataTable();
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                }
                else if (cmbInvoiceDate.SelectedIndex == 1)
                {
                    //yesterday
                    dtAllInvoice = new DataTable();
                    DateTime dt1 = DateTime.Now.AddDays(-1);
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 2)
                {
                    //this month
                    dtAllInvoice = new DataTable();
                    DateTime dt = DateTime.Now;
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 3)
                {
                    //this week
                    dtAllInvoice = new DataTable();
                    DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
                    DateTime dt1 = dt.AddDays(6);
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 4)
                {
                    //last month
                    dtAllInvoice = new DataTable();
                    DateTime dt = DateTime.Now.AddMonths(-1);
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 5)
                {
                    //this ficsal year
                    dtAllInvoice = new DataTable();
                    int year = DateTime.Now.Year;
                    DateTime firstDay = Convert.ToDateTime(year + "-" + "01" + "-" + "01");
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = firstDay.ToString("yyyy-MM-dd"), EndDate = firstDay.AddYears(1).AddDays(-1).ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = firstDay.ToString("yyyy-MM-dd"), EndDate = firstDay.AddYears(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 6)
                {
                    //all
                    dtAllInvoice = new DataTable();
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = null, EndDate = null });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = null, EndDate = null });
                }

                else if (cmbInvoiceDate.SelectedIndex == 7)
                {
                    //custom
                    dtAllInvoice = new DataTable();
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });

                    lblFrom.Visible = true; lblTo.Visible = true; dtFrom.Visible = true; dtTo.Visible = true;
                }

                dgvAllInvoiceList.Rows.Clear();
                if (dtAllInvoice.Rows.Count > 0)
                {
                    int j = 0;

                    for (int i = 0; i < dtAllInvoice.Rows.Count; i++)
                    {
                        try
                        {
                            dgvAllInvoiceList.Rows.Add();
                            dgvAllInvoiceList.Rows[j].Cells[0].Value = dtAllInvoice.Rows[i]["ID"].ToString();
                            if (CustomerNumberOnly == true)
                            {
                                dgvAllInvoiceList.Rows[j].Cells[1].Value = dtAllInvoice.Rows[i]["CustomerNumber"].ToString();
                            }
                            else
                            {
                                dgvAllInvoiceList.Rows[j].Cells[1].Value = dtAllInvoice.Rows[i]["Customer"].ToString();
                            }
                            if (dtAllInvoice.Rows[i]["Num"].ToString() != "")
                            {
                                dgvAllInvoiceList.Rows[j].Cells[2].Value = dtAllInvoice.Rows[i]["Num"].ToString();
                            }
                            if (dtAllInvoice.Rows[i]["Date"].ToString() != "")
                            {
                                DateTime date = Convert.ToDateTime(dtAllInvoice.Rows[i]["Date"].ToString());
                                dgvAllInvoiceList.Rows[j].Cells[3].Value = date.ToShortDateString();
                            }
                            if (dtAllInvoice.Rows[i]["Amount"].ToString() != "")
                            {
                                dgvAllInvoiceList.Rows[j].Cells[4].Value = Convert.ToDecimal(dtAllInvoice.Rows[i]["Amount"].ToString());
                            }
                            dgvAllInvoiceList.Rows[j].Cells[5].Value = dtAllInvoice.Rows[i]["SalesRep"].ToString();

                            int INVID = Convert.ToInt32(dtAllInvoice.Rows[i]["ID"].ToString());
                            decimal Total = 0;
                            DataTable dt = new BALInvoiceDetails().SelectByInvID(new BOLInvoiceDetails() { InvoiceID = INVID });
                            if (dt.Rows.Count > 0)
                            {

                                foreach (DataRow dr in dt.Rows)
                                {
                                    if (dr["Cost"].ToString() == "")
                                    {
                                        dr["Cost"] = 0.00;
                                    }
                                    if (dr["Cost"].ToString() != "0.00")
                                    {
                                        Total += Convert.ToDecimal(dr["Quantity"].ToString()) * (Convert.ToDecimal(dr["Rate"].ToString()) - Convert.ToDecimal(dr["Cost"].ToString()));
                                    }
                                    if (dr["Cost"].ToString() == "0.00")
                                    {
                                        dgvAllInvoiceList.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 110, 74);
                                    }
                                }
                            }
                            dgvAllInvoiceList.Rows[j].Cells[6].Value = decimal.Round(Total, 2);

                            if (dtAllInvoice.Rows[i]["Amount"].ToString() != "0.00")
                            {
                                dgvAllInvoiceList.Rows[j].Cells[7].Value = string.Concat(decimal.Round((Convert.ToDecimal(Total) / Convert.ToDecimal(dtAllInvoice.Rows[i]["Amount"].ToString())) * 100, 2), '%');
                            }
                            else
                            {
                                dgvAllInvoiceList.Rows[j].Cells[7].Value = "0%";
                            }
                            j++;
                        }
                        catch (Exception ex)
                        {
                            ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster, Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                            MessageBox.Show("Error:" + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster,Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void FrmInvoiceProfitMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.Parent = null;
        }
        private void dgvAllInvoiceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 8)
                {
                    decimal Total = 0;
                    int INVID = Convert.ToInt32(dgvAllInvoiceList.CurrentRow.Cells[0].Value);
                    lblRefno.Text = dgvAllInvoiceList.CurrentRow.Cells[2].Value.ToString();
                    DataTable dt = new BALInvoiceDetails().SelectByInvID(new BOLInvoiceDetails() { InvoiceID = INVID });
                    if (dt.Rows.Count > 0)
                    {
                        dgInvDetail.Rows.Clear();
                        int iRow = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            dgInvDetail.Rows.Add();
                            dgInvDetail["ID", iRow].Value = dr["ID"].ToString();
                            dgInvDetail["ItemName", iRow].Value = dr["ItemName"].ToString();
                            dgInvDetail["ComparativePrice1", iRow].Value = dr["ComparativePrice1"].ToString();
                            dgInvDetail["ComparativePrice2", iRow].Value = dr["ComparativePrice2"].ToString();
                            dgInvDetail["ComparativePrice3", iRow].Value = dr["ComparativePrice3"].ToString();
                            dgInvDetail["ComparativePrice4", iRow].Value = dr["ComparativePrice4"].ToString();
                            dgInvDetail["ComparativePrice5", iRow].Value = dr["ComparativePrice5"].ToString();
                            dgInvDetail["Qty", iRow].Value = dr["Quantity"].ToString();
                            dgInvDetail["Rate", iRow].Value = dr["Rate"].ToString();
                            dgInvDetail["LowestPrice", iRow].Value = dr["LowestPrice"].ToString();
                            dgInvDetail["Amt", iRow].Value = dr["Amount"].ToString();
                            if (dr["Cost"].ToString() == "0.00")
                            {
                                dgInvDetail.Rows[iRow].DefaultCellStyle.BackColor = Color.FromArgb(255, 110, 74);
                            }
                            dgInvDetail["Cost", iRow].Value = dr["Cost"].ToString();
                            if (dr["Cost"].ToString() == "0.00" || dr["Cost"].ToString() == "")
                            {
                                dgInvDetail["Profit1", iRow].Value = 0;
                            }
                            else
                            {
                                dgInvDetail["Profit1", iRow].Value = decimal.Round(Convert.ToDecimal(dr["Quantity"].ToString()) * (Convert.ToDecimal(dr["Rate"].ToString()) - Convert.ToDecimal(dr["Cost"].ToString())), 2);
                            }
                            if (dr["Cost"].ToString() == "0.00" || dr["Cost"].ToString() == "")
                            {
                                dgInvDetail["ProfitPerPiece", iRow].Value = 0;
                            }
                            else
                            {
                                dgInvDetail["ProfitPerPiece", iRow].Value = decimal.Round(Convert.ToDecimal(dr["Rate"].ToString()) - (Convert.ToDecimal(dr["Cost"].ToString())), 2);
                            }
                            if (dr["Cost"].ToString() == "0.00"|| dr["Cost"].ToString() == "")
                            {
                                dgInvDetail["ProfitPercentage", iRow].Value = 0;
                            }
                            else
                            {
                                if (dgInvDetail["Profit1", iRow].Value.ToString() == "0.00")
                                {
                                    dgInvDetail["ProfitPercentage", iRow].Value = 0.00;
                                }
                                else
                                {
                                    if (dr["Amount"].ToString() != "0.00")
                                    {
                                        dgInvDetail["ProfitPercentage", iRow].Value = string.Concat(decimal.Round((Convert.ToDecimal(dgInvDetail["Profit1", iRow].Value) / (Convert.ToDecimal(dr["Amount"].ToString())) * 100), 2), '%');
                                    }
                                    else
                                    {
                                        dgInvDetail["ProfitPercentage", iRow].Value = 0.00;
                                    }
                                }
                            }

                            Total += Convert.ToDecimal(dgInvDetail["Profit1", iRow].Value);
                            iRow++;
                        }
                        lblTotalProfit.Text = decimal.Round(Total, 2).ToString();
                    }
                    pnlInvDetails.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster,Function :dgvAllInvoiceList_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            pnlInvDetails.Visible = false;
        }
        private void dtTo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("CustomerNumberOnly", "CustomerCenter"))
                {
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                    {
                        CustomerNumberOnly = false;
                    }
                    else
                    {
                        CustomerNumberOnly = true;

                    }
                }
                else
                {
                    CustomerNumberOnly = false;
                }
                dtAllInvoice = new DataTable();
                //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
                //else
                //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });

                dgvAllInvoiceList.Rows.Clear();
                if (dtAllInvoice.Rows.Count > 0)
                {
                    int j = 0;
                    for (int i = 0; i < dtAllInvoice.Rows.Count; i++)
                    {
                        try
                        {
                            dgvAllInvoiceList.Rows.Add();
                            dgvAllInvoiceList.Rows[j].Cells[0].Value = dtAllInvoice.Rows[i]["ID"].ToString();
                            if (CustomerNumberOnly == true)
                            {
                                dgvAllInvoiceList.Rows[j].Cells[1].Value = dtAllInvoice.Rows[i]["CustomerNumber"].ToString();
                            }
                            else
                            {
                                dgvAllInvoiceList.Rows[j].Cells[1].Value = dtAllInvoice.Rows[i]["Customer"].ToString();
                            }
                            if (dtAllInvoice.Rows[i]["Num"].ToString() != "")
                            {
                                dgvAllInvoiceList.Rows[j].Cells[2].Value = dtAllInvoice.Rows[i]["Num"].ToString();
                            }
                            if (dtAllInvoice.Rows[i]["Date"].ToString() != "")
                            {
                                DateTime date = Convert.ToDateTime(dtAllInvoice.Rows[i]["Date"].ToString());
                                dgvAllInvoiceList.Rows[j].Cells[3].Value = date.ToShortDateString();
                            }
                            if (dtAllInvoice.Rows[i]["Amount"].ToString() != "")
                            {
                                dgvAllInvoiceList.Rows[j].Cells[4].Value = Convert.ToDecimal(dtAllInvoice.Rows[i]["Amount"].ToString());
                            }
                            dgvAllInvoiceList.Rows[j].Cells[5].Value = dtAllInvoice.Rows[i]["SalesRep"].ToString();

                            int INVID = Convert.ToInt32(dtAllInvoice.Rows[i]["ID"].ToString());
                            decimal Total = 0;
                            DataTable dt = new BALInvoiceDetails().SelectByInvID(new BOLInvoiceDetails() { InvoiceID = INVID });
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    if (dr["Cost"].ToString() == "")
                                    {
                                        dr["Cost"] = 0.00;
                                    }
                                    if (dr["Cost"].ToString() != "0.00")
                                    {
                                        Total += Convert.ToDecimal(dr["Quantity"].ToString()) * (Convert.ToDecimal(dr["Rate"].ToString()) - Convert.ToDecimal(dr["Cost"].ToString()));
                                    }
                                    if (dr["Cost"].ToString() == "0.00")
                                    {
                                        dgvAllInvoiceList.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 110, 74);
                                    }
                                }
                            }
                            dgvAllInvoiceList.Rows[j].Cells[6].Value = decimal.Round(Total, 2);

                            if (dtAllInvoice.Rows[i]["Amount"].ToString() != "0.00")
                            {
                                dgvAllInvoiceList.Rows[j].Cells[7].Value = string.Concat(decimal.Round((Convert.ToDecimal(Total) / Convert.ToDecimal(dtAllInvoice.Rows[i]["Amount"].ToString())) * 100, 2), '%');
                            }
                            else
                            {
                                dgvAllInvoiceList.Rows[j].Cells[7].Value = 0 + '%';
                            }

                            j++;
                        }
                        catch (Exception ex)
                        {
                            ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster, Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                            MessageBox.Show("Error:" + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster,Function :dtTo_Leave. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void btnSe_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("CustomerNumberOnly", "CustomerCenter"))
                {
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                    {
                        CustomerNumberOnly = false;
                    }
                    else
                    {
                        CustomerNumberOnly = true;

                    }
                }
                else
                {
                    CustomerNumberOnly = false;
                }
                if (txtSearch.Text != "")
                {
                    dtAllInvoice = new DataTable();
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectSearchInvoice(new BOLInvoiceMaster() { SalesRepID = 0, RefNumber = txtSearch.Text, CustomerName = txtSearch.Text });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectSearchInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, RefNumber = txtSearch.Text, CustomerName = txtSearch.Text });

                    dgvAllInvoiceList.Rows.Clear();
                    if (dtAllInvoice.Rows.Count > 0)
                    {
                        int j = 0;
                        for (int i = 0; i < dtAllInvoice.Rows.Count; i++)
                        {
                            try
                            {
                                dgvAllInvoiceList.Rows.Add();
                                dgvAllInvoiceList.Rows[j].Cells[0].Value = dtAllInvoice.Rows[i]["ID"].ToString();
                                if (CustomerNumberOnly == true)
                                {
                                    dgvAllInvoiceList.Rows[j].Cells[1].Value = dtAllInvoice.Rows[i]["CustomerNumber"].ToString();
                                }
                                else
                                {
                                    dgvAllInvoiceList.Rows[j].Cells[1].Value = dtAllInvoice.Rows[i]["Customer"].ToString();
                                }
                                if (dtAllInvoice.Rows[i]["Num"].ToString() != "")
                                {
                                    dgvAllInvoiceList.Rows[j].Cells[2].Value = dtAllInvoice.Rows[i]["Num"].ToString();
                                }
                                if (dtAllInvoice.Rows[i]["Date"].ToString() != "")
                                {
                                    DateTime date = Convert.ToDateTime(dtAllInvoice.Rows[i]["Date"].ToString());
                                    dgvAllInvoiceList.Rows[j].Cells[3].Value = date.ToShortDateString();
                                }

                                if (dtAllInvoice.Rows[i]["Amount"].ToString() != "")
                                {
                                    dgvAllInvoiceList.Rows[j].Cells[4].Value = Convert.ToDecimal(dtAllInvoice.Rows[i]["Amount"].ToString());
                                }

                                dgvAllInvoiceList.Rows[j].Cells[5].Value = dtAllInvoice.Rows[i]["SalesRep"].ToString();


                                int INVID = Convert.ToInt32(dtAllInvoice.Rows[i]["ID"].ToString());
                                decimal Total = 0;
                                DataTable dt = new BALInvoiceDetails().SelectByInvID(new BOLInvoiceDetails() { InvoiceID = INVID });
                                if (dt.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        if (dr["Cost"].ToString() == "")
                                        {
                                            dr["Cost"] = 0.00;
                                        }
                                        if (dr["Cost"].ToString() != "0.00")
                                        {
                                            Total += Convert.ToDecimal(dr["Quantity"].ToString()) * (Convert.ToDecimal(dr["Rate"].ToString()) - Convert.ToDecimal(dr["Cost"].ToString()));
                                        }
                                        if (dr["Cost"].ToString() == "0.00")
                                        {
                                            dgvAllInvoiceList.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 110, 74);
                                        }
                                    }
                                }
                                dgvAllInvoiceList.Rows[j].Cells[6].Value = decimal.Round(Total, 2);
                                if (dtAllInvoice.Rows[i]["Amount"].ToString() != "0.00")
                                {
                                    dgvAllInvoiceList.Rows[j].Cells[7].Value = string.Concat(decimal.Round((Convert.ToDecimal(Total) / Convert.ToDecimal(dtAllInvoice.Rows[i]["Amount"].ToString())) * 100, 2), '%');
                                }
                                else
                                {
                                    dgvAllInvoiceList.Rows[j].Cells[7].Value = 0 + '%';
                                }
                                j++;
                            }
                            catch (Exception ex)
                            {
                                ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster, Function :btnSe_Click. Message:" + ex.Message);
                                MessageBox.Show("Error:" + ex.Message);
                            }

                        }

                    }
                }
                else
                {
                    dgvAllInvoiceList.Rows.Clear();
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster,Function :btnSe_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("CustomerNumberOnly", "CustomerCenter"))
                {
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                    {
                        CustomerNumberOnly = false;
                    }
                    else
                    {
                        CustomerNumberOnly = true;

                    }
                }
                else
                {
                    CustomerNumberOnly = false;
                }

                DataTable DATA = new DataTable();
                DATA.Columns.Add("FilterName");
                DATA.Columns.Add("CustomerName");
                DATA.Columns.Add("InvoiceNumber");
                DATA.Columns.Add("Date");
                DATA.Columns.Add("SalesRep");
                DATA.Columns.Add("ItemName");
                DATA.Columns.Add("Ms");
                DATA.Columns.Add("P4s");
                DATA.Columns.Add("Gf");
                DATA.Columns.Add("XCELL");
                DATA.Columns.Add("P4s-D");
                DATA.Columns.Add("Qty");
                DATA.Columns.Add("Rate");
                DATA.Columns.Add("LowestPrice");
                DATA.Columns.Add("Amount");
                DATA.Columns.Add("Cost");
                DATA.Columns.Add("Profit");
                DATA.Columns.Add("ProfitPerPiece");
                DATA.Columns.Add("Profit%");

                lblFrom.Visible = false; lblTo.Visible = false; dtFrom.Visible = false; dtTo.Visible = false;

                if (cmbInvoiceDate.SelectedIndex == 0)
                {
                    //today
                    dtAllInvoice = new DataTable();
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                }
                else if (cmbInvoiceDate.SelectedIndex == 1)
                {
                    //yesterday
                    dtAllInvoice = new DataTable();
                    DateTime dt1 = DateTime.Now.AddDays(-1);
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 2)
                {
                    //this month
                    dtAllInvoice = new DataTable();
                    DateTime dt = DateTime.Now;
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 3)
                {
                    //this week
                    dtAllInvoice = new DataTable();
                    DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
                    DateTime dt1 = dt.AddDays(6);
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 4)
                {
                    //last month
                    dtAllInvoice = new DataTable();
                    DateTime dt = DateTime.Now.AddMonths(-1);
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 5)
                {
                    //this ficsal year
                    dtAllInvoice = new DataTable();
                    int year = DateTime.Now.Year;
                    DateTime firstDay = Convert.ToDateTime(year + "-" + "01" + "-" + "01");
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = firstDay.ToString("yyyy-MM-dd"), EndDate = firstDay.AddYears(1).AddDays(-1).ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = firstDay.ToString("yyyy-MM-dd"), EndDate = firstDay.AddYears(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 6)
                {
                    //all
                    dtAllInvoice = new DataTable();
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = null, EndDate = null });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = null, EndDate = null });
                }

                else if (cmbInvoiceDate.SelectedIndex == 7)
                {
                    //custom
                    dtAllInvoice = new DataTable();
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });

                    lblFrom.Visible = true; lblTo.Visible = true; dtFrom.Visible = true; dtTo.Visible = true;
                }

                DATA.Rows.Clear();
                if (dtAllInvoice.Rows.Count > 0)
                {
                    int j = 0;

                    for (int i = 0; i < dtAllInvoice.Rows.Count; i++)
                    {
                        try
                        {
                            DATA.NewRow();
                            DATA.Rows.Add();
                            //DATA.Rows[j].Cells[0].Value = dtAllInvoice.Rows[i]["ID"].ToString();
                            int INVID = Convert.ToInt32(dtAllInvoice.Rows[i]["ID"].ToString());
                            decimal Total = 0;
                            DataTable dt = new BALInvoiceDetails().SelectByInvID(new BOLInvoiceDetails() { InvoiceID = INVID });
                            if (dt.Rows.Count > 0)
                            {
                                //int iRow = 0;
                                foreach (DataRow dr in dt.Rows)
                                {

                                    if (CustomerNumberOnly == true)
                                    {
                                        DATA.Rows[j]["CustomerName"] = dtAllInvoice.Rows[i]["CustomerNumber"].ToString();
                                    }
                                    else
                                    {
                                        DATA.Rows[j]["CustomerName"] = dtAllInvoice.Rows[i]["Customer"].ToString();
                                    }
                                    if (dtAllInvoice.Rows[i]["Num"].ToString() != "")
                                    {
                                        DATA.Rows[j]["InvoiceNumber"] = dtAllInvoice.Rows[i]["Num"].ToString();
                                    }
                                    DateTime date = Convert.ToDateTime(dtAllInvoice.Rows[i]["Date"].ToString());
                                    DATA.Rows[j]["Date"] = date.ToShortDateString();
                                    //if (DATA.Rows[j]["InvoiceNumber"].ToString() == "")
                                    //{
                                    //    DATA.NewRow();
                                    //    DATA.Rows.Add();
                                    //}
                                    DATA.Rows[j]["FilterName"] = dr["FilterName"].ToString();
                                    DATA.Rows[j]["SalesRep"] = dtAllInvoice.Rows[i]["SalesRep"].ToString();
                                    DATA.Rows[j]["ItemName"] = dr["ItemName"].ToString();
                                    DATA.Rows[j]["Ms"] = dr["ComparativePrice1"].ToString();
                                    DATA.Rows[j]["P4s"] = dr["ComparativePrice2"].ToString();
                                    DATA.Rows[j]["Gf"] = dr["ComparativePrice3"].ToString();
                                    DATA.Rows[j]["XCELL"] = dr["ComparativePrice4"].ToString();
                                    DATA.Rows[j]["P4s-D"] = dr["ComparativePrice5"].ToString();
                                    DATA.Rows[j]["Qty"] = dr["Quantity"].ToString();
                                    DATA.Rows[j]["Rate"] = dr["Rate"].ToString();
                                    DATA.Rows[j]["LowestPrice"] = dr["LowestPrice"].ToString();
                                    DATA.Rows[j]["Amount"] = dr["Amount"].ToString();

                                    DATA.Rows[j]["Cost"] = dr["Cost"].ToString();
                                    if (dr["Cost"].ToString() == "0.00" || dr["Cost"].ToString() == "")
                                    {
                                        DATA.Rows[j]["Profit"] = 0;
                                    }
                                    else
                                    {
                                        DATA.Rows[j]["Profit"] = decimal.Round(Convert.ToDecimal(dr["Quantity"].ToString()) * (Convert.ToDecimal(dr["Rate"].ToString()) - Convert.ToDecimal(dr["Cost"].ToString())), 2);
                                    }
                                    if (dr["Cost"].ToString() == "0.00" || dr["Cost"].ToString() == "")
                                    {
                                        DATA.Rows[j]["ProfitPerPiece"] = 0;
                                    }
                                    else
                                    {
                                        DATA.Rows[j]["ProfitPerPiece"] = decimal.Round(Convert.ToDecimal(dr["Rate"].ToString()) - (Convert.ToDecimal(dr["Cost"].ToString())), 2);
                                    }
                                    if (dr["Cost"].ToString() == "0.00" || dr["Cost"].ToString() == "")
                                    {
                                        DATA.Rows[j]["Profit%"] = 0;
                                    }
                                    else
                                    {
                                        if (DATA.Rows[j]["Profit"].ToString() == "0.00")
                                        {
                                            DATA.Rows[j]["Profit%"] = 0.00;
                                        }
                                        else
                                        {
                                            if (dr["Amount"].ToString() != "0.00")
                                            {
                                                DATA.Rows[j]["Profit%"] = string.Concat(decimal.Round((Convert.ToDecimal(DATA.Rows[j]["Profit"]) / (Convert.ToDecimal(dr["Amount"].ToString())) * 100), 2), '%');
                                            }
                                            else
                                            {
                                                DATA.Rows[j]["Profit%"] = 0.00;
                                            }
                                        }
                                    }
                                    DATA.NewRow();
                                    DATA.Rows.Add();
                                    Total += Convert.ToDecimal(DATA.Rows[j]["Profit"]);
                                    //iRow++;
                                    j++;
                                }
                                // DATA.Rows.Add();
                                //DATA.Rows[iRow]["Profit"] = Total;
                                DATA.Rows[j]["Profit"] = Total;
                            }
                            j++;
                        }
                        catch (Exception ex)
                        {
                            ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster, Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                            MessageBox.Show("Error:" + ex.Message);
                        }
                    }
                }
                if (DATA.Rows.Count > 0)
                {
                    //SaveFileDialog sfd = new SaveFileDialog();
                    //sfd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    //sfd.FilterIndex = 1;
                    //sfd.RestoreDirectory = true;
                    //sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    //if (sfd.ShowDialog() == DialogResult.OK)
                    //{
                    //    Cursor.Current = Cursors.WaitCursor;
                    //using (XLWorkbook wb = new XLWorkbook())
                    //{
                    //    wb.Worksheets.Add(DATA, "Sheet1");
                    //    wb.SaveAs(sfd.FileName);

                    //}
                    //MessageBox.Show("Export Successfully");
                    //}
                    //var app = new Microsoft.Office.Interop.Excel.Application();
                    //app.Visible = true;
                    //app.Workbooks.Open(sfd.FileName, ReadOnly: false);
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    sfd.RestoreDirectory = true;
                    sfd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "Excel//Book1.xlsx";

                    //if (sfd.ShowDialog() == DialogResult.OK)
                    //{
                    Cursor.Current = Cursors.WaitCursor;
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(DATA, "Sheet1");
                        wb.SaveAs(sfd.InitialDirectory);
                    }
                    //MessageBox.Show("Export Successfully");
                    //}
                    var app = new Microsoft.Office.Interop.Excel.Application();
                    app.Visible = true;
                    app.Workbooks.Open(sfd.InitialDirectory, ReadOnly: false);

                }
                else
                {
                    MessageBox.Show("No Data Found");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster, Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void btnExportCPrice_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DATA = new DataTable();
                //
                //
                DATA.Columns.Add("FilterName");
                //DATA.Columns.Add("ID");
                DATA.Columns.Add("ItemName");
                DATA.Columns.Add("Ms");
                DATA.Columns.Add("P4s");
                DATA.Columns.Add("Gf");
                DATA.Columns.Add("XCELL");
                DATA.Columns.Add("P4s-D");
                //DATA.Columns.Add("InvoiceNumber");
                //DATA.Columns.Add("CustomerName");
                //DATA.Columns.Add("Qty");
                //DATA.Columns.Add("Rate");
                //DATA.Columns.Add("Amount");
                //DATA.Columns.Add("Cost");
                //DATA.Columns.Add("Profit");
                //DATA.Columns.Add("ProfitPerPiece");
                //DATA.Columns.Add("Profit%");

                lblFrom.Visible = false; lblTo.Visible = false; dtFrom.Visible = false; dtTo.Visible = false;

                if (cmbInvoiceDate.SelectedIndex == 0)
                {
                    //today
                    dtAllInvoice = new DataTable();
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                }
                else if (cmbInvoiceDate.SelectedIndex == 1)
                {
                    //yesterday
                    dtAllInvoice = new DataTable();
                    DateTime dt1 = DateTime.Now.AddDays(-1);
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 2)
                {
                    //this month
                    dtAllInvoice = new DataTable();
                    DateTime dt = DateTime.Now;
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 3)
                {
                    //this week
                    dtAllInvoice = new DataTable();
                    DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
                    DateTime dt1 = dt.AddDays(6);
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 4)
                {
                    //last month
                    dtAllInvoice = new DataTable();
                    DateTime dt = DateTime.Now.AddMonths(-1);
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 5)
                {
                    //this ficsal year
                    dtAllInvoice = new DataTable();
                    int year = DateTime.Now.Year;
                    DateTime firstDay = Convert.ToDateTime(year + "-" + "01" + "-" + "01");
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = firstDay.ToString("yyyy-MM-dd"), EndDate = firstDay.AddYears(1).AddDays(-1).ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = firstDay.ToString("yyyy-MM-dd"), EndDate = firstDay.AddYears(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 6)
                {
                    //all
                    dtAllInvoice = new DataTable();
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = null, EndDate = null });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = null, EndDate = null });
                }

                else if (cmbInvoiceDate.SelectedIndex == 7)
                {
                    //custom
                    dtAllInvoice = new DataTable();
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });

                    lblFrom.Visible = true; lblTo.Visible = true; dtFrom.Visible = true; dtTo.Visible = true;
                }

                DATA.Rows.Clear();
                if (dtAllInvoice.Rows.Count > 0)
                {
                    int j = 0;

                    for (int i = 0; i < dtAllInvoice.Rows.Count; i++)
                    {
                        try
                        {
                            DATA.NewRow();
                            DATA.Rows.Add();
                            //DATA.Rows[j].Cells[0].Value = dtAllInvoice.Rows[i]["ID"].ToString();
                            int INVID = Convert.ToInt32(dtAllInvoice.Rows[i]["ID"].ToString());
                            decimal Total = 0;
                            DataTable dt = new BALInvoiceDetails().SelectByInvID(new BOLInvoiceDetails() { InvoiceID = INVID });
                            if (dt.Rows.Count > 0)
                            {
                                //int iRow = 0;
                                foreach (DataRow dr in dt.Rows)
                                {

                                    // DATA.Rows[j]["ID"] = dr["ItemID"].ToString();
                                    //string[] str = dr["ItemName"].ToString().Split(' ');
                                    //DATA.Rows[j]["FilterName"] = str[0];
                                    DATA.Rows[j]["FilterName"] = dr["FilterName"].ToString();
                                    DATA.Rows[j]["ItemName"] = dr["ItemName"].ToString();
                                    DATA.Rows[j]["Ms"] = dr["ComparativePrice1"].ToString();
                                    DATA.Rows[j]["P4s"] = dr["ComparativePrice2"].ToString();
                                    DATA.Rows[j]["Gf"] = dr["ComparativePrice3"].ToString();
                                    DATA.Rows[j]["XCELL"] = dr["ComparativePrice4"].ToString();
                                    DATA.Rows[j]["P4s-D"] = dr["ComparativePrice5"].ToString();

                                    DATA.NewRow();
                                    DATA.Rows.Add();
                                    //Total += Convert.ToDecimal(DATA.Rows[j]["Profit"]);
                                    //iRow++;
                                    j++;
                                }
                                // DATA.Rows.Add();
                                //DATA.Rows[iRow]["Profit"] = Total;
                                //DATA.Rows[j]["Profit"] = Total;
                            }
                            j++;
                        }
                        catch (Exception ex)
                        {
                            ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster, Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                            MessageBox.Show("Error:" + ex.Message);
                        }
                    }
                }
                Top:
                for (int i = 0; i < DATA.Rows.Count; i++)
                {
                    {
                        if (DATA.Rows[i][1] == DBNull.Value || DATA.Rows[i][1].ToString()=="")
                        {
                            DATA.Rows[i].Delete();
                            goto Top;
                        }
                    }
                }
          

                //DataView dv = DATA.DefaultView;
                //dv.Sort = "FilterName";
                //DATA = dv.ToTable();

                if (DATA.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    sfd.RestoreDirectory = true;
                    sfd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "Excel//Book1.xlsx";

                    //if (sfd.ShowDialog() == DialogResult.OK)
                    //{
                    Cursor.Current = Cursors.WaitCursor;
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(DATA, "Sheet1");
                        wb.SaveAs(sfd.InitialDirectory);
                    }
                    //MessageBox.Show("Export Successfully");
                    //}
                    var app = new Microsoft.Office.Interop.Excel.Application();
                    app.Visible = true;
                    app.Workbooks.Open(sfd.InitialDirectory, ReadOnly: false);

                }
                else
                {
                    MessageBox.Show("No Data Found");
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster, Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void btnImportCPrice_Click(object sender, EventArgs e)
        {
            try
            {
                string FilePath = "";
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FilePath = openFileDialog1.FileName;
                    DataTable dt = new DataTable();
                    using (XLWorkbook workbook = new XLWorkbook(FilePath))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        bool FirstRow = true;
                        string readRange = "1:1";
                        foreach (IXLRow row in worksheet.RowsUsed())
                        {
                            if (FirstRow)
                            {
                                readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    dt.Columns.Add(cell.Value.ToString());
                                }
                                FirstRow = false;
                            }
                            else
                            {
                                dt.Rows.Add();
                                int cellIndex = 0;
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    dt.Rows[dt.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                            }
                        }
                        if (FirstRow)
                        {
                            MessageBox.Show("Empty Excel File!");
                        }
                    }

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            ObjItemBOL = new BOLItemMaster();
                            ObjItemBOL.ItemName = dr["ItemName"].ToString();
                            //if (dt.Columns.Contains("FilterName") == true)
                            //{
                            //    if (dr["FilterName"].ToString() != "")
                            //    {
                            //        DataTable dtFilterName = new BALFilterMater().SelectByName(new BOLFilterMater() { FilterName = dr["FilterName"].ToString() });
                            //        if (dtFilterName.Rows.Count > 0)
                            //        {
                            //            ObjItemBOL.FilterID = Convert.ToInt32(dtFilterName.Rows[0]["ID"].ToString());
                            //        }
                            //        else
                            //        {
                            //            ObjItemBOL.FilterID = 0;
                            //        }
                            //    }
                            //    else
                            //    {
                            //        ObjItemBOL.FilterID = 0;
                            //    }
                            //}
                            if (dt.Columns.Contains("Ms") == true)
                            {
                                if (dr["Ms"].ToString() != "")
                                ObjItemBOL.ComparativePrice1 = Convert.ToDecimal(dr["Ms"].ToString());
                            }
                            if (dt.Columns.Contains("P4s") == true)
                            {
                                if (dr["P4s"].ToString() != "")
                                    ObjItemBOL.ComparativePrice2 = Convert.ToDecimal(dr["P4s"].ToString());
                            }
                            if (dt.Columns.Contains("Gf") == true)
                            {
                                if (dr["Gf"].ToString() != "")
                                    ObjItemBOL.ComparativePrice3 = Convert.ToDecimal(dr["Gf"].ToString());
                            }
                            if (dt.Columns.Contains("XCELL") == true)
                            {
                                if (dr["XCELL"].ToString() != "")
                                    ObjItemBOL.ComparativePrice4 = Convert.ToDecimal(dr["XCELL"].ToString());
                            }
                            if (dt.Columns.Contains("P4s-D") == true)
                            {
                                if (dr["P4s-D"].ToString() != "")
                                    ObjItemBOL.ComparativePrice5 = Convert.ToDecimal(dr["P4s-D"].ToString());
                            }
                            ObjItemBAL.UpdateComparativePrice(ObjItemBOL);
                        }
                        MessageBox.Show("File Read Successfully");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Excel File");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemList,Function :btnImport_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void dgvAllInvoiceList_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {

            try
            {
                if (e.Column.Index == 7 || e.Column.Index == 2 || e.Column.Index == 4 || e.Column.Index == 6)
                {
                    //e.SortResult = Compare(e.CellValue1.ToString().Replace("%", ""), e.CellValue2.ToString().Replace("%", ""));

                    e.SortResult = decimal.Parse(e.CellValue1.ToString().Replace("%", "")).CompareTo(decimal.Parse(e.CellValue2.ToString().Replace("%", "")));
                    e.Handled = true;
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitReport,Function :dgvAllInvoiceList_SortCompare. Message:" + ex.Message);
            }
        }
        private void btnExportWithCustomerNumberOnly_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataTable DATA = new DataTable();
                DATA.Columns.Add("FilterName");
                DATA.Columns.Add("CustomerName");
                DATA.Columns.Add("InvoiceNumber");
                DATA.Columns.Add("Date");
                DATA.Columns.Add("SalesRep");
                DATA.Columns.Add("ItemName");
                DATA.Columns.Add("Ms");
                DATA.Columns.Add("P4s");
                DATA.Columns.Add("Gf");
                DATA.Columns.Add("XCELL");
                DATA.Columns.Add("P4s-D");
                DATA.Columns.Add("Qty");
                DATA.Columns.Add("Rate");
                DATA.Columns.Add("LowestPrice");
                DATA.Columns.Add("Amount");
                DATA.Columns.Add("Cost");
                DATA.Columns.Add("Profit");
                DATA.Columns.Add("ProfitPerPiece");
                DATA.Columns.Add("Profit%");

                lblFrom.Visible = false; lblTo.Visible = false; dtFrom.Visible = false; dtTo.Visible = false;

                if (cmbInvoiceDate.SelectedIndex == 0)
                {
                    //today
                    dtAllInvoice = new DataTable();
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                }
                else if (cmbInvoiceDate.SelectedIndex == 1)
                {
                    //yesterday
                    dtAllInvoice = new DataTable();
                    DateTime dt1 = DateTime.Now.AddDays(-1);
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 2)
                {
                    //this month
                    dtAllInvoice = new DataTable();
                    DateTime dt = DateTime.Now;
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 3)
                {
                    //this week
                    dtAllInvoice = new DataTable();
                    DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
                    DateTime dt1 = dt.AddDays(6);
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 4)
                {
                    //last month
                    dtAllInvoice = new DataTable();
                    DateTime dt = DateTime.Now.AddMonths(-1);
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 5)
                {
                    //this ficsal year
                    dtAllInvoice = new DataTable();
                    int year = DateTime.Now.Year;
                    DateTime firstDay = Convert.ToDateTime(year + "-" + "01" + "-" + "01");
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = firstDay.ToString("yyyy-MM-dd"), EndDate = firstDay.AddYears(1).AddDays(-1).ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = firstDay.ToString("yyyy-MM-dd"), EndDate = firstDay.AddYears(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 6)
                {
                    //all
                    dtAllInvoice = new DataTable();
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = null, EndDate = null });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = null, EndDate = null });
                }

                else if (cmbInvoiceDate.SelectedIndex == 7)
                {
                    //custom
                    dtAllInvoice = new DataTable();
                    //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
                    //else
                    //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });

                    lblFrom.Visible = true; lblTo.Visible = true; dtFrom.Visible = true; dtTo.Visible = true;
                }

                DATA.Rows.Clear();
                if (dtAllInvoice.Rows.Count > 0)
                {
                    int j = 0;

                    for (int i = 0; i < dtAllInvoice.Rows.Count; i++)
                    {
                        try
                        {
                            DATA.NewRow();
                            DATA.Rows.Add();
                            //DATA.Rows[j].Cells[0].Value = dtAllInvoice.Rows[i]["ID"].ToString();



                            int INVID = Convert.ToInt32(dtAllInvoice.Rows[i]["ID"].ToString());
                            decimal Total = 0;
                            DataTable dt = new BALInvoiceDetails().SelectByInvID(new BOLInvoiceDetails() { InvoiceID = INVID });
                            if (dt.Rows.Count > 0)
                            {
                                //int iRow = 0;
                                foreach (DataRow dr in dt.Rows)
                                {
                                    string result = Regex.Replace(dtAllInvoice.Rows[i]["Customer"].ToString(), @"[^\d]", "");
                                    if (result == "")
                                    {
                                        DATA.Rows[j]["CustomerName"] = dtAllInvoice.Rows[i]["Customer"].ToString();
                                    }
                                    else
                                    {
                                        DATA.Rows[j]["CustomerName"] = result;
                                    }

                                    if (dtAllInvoice.Rows[i]["Num"].ToString() != "")
                                    {
                                        DATA.Rows[j]["InvoiceNumber"] = dtAllInvoice.Rows[i]["Num"].ToString();
                                    }
                                    DateTime date = Convert.ToDateTime(dtAllInvoice.Rows[i]["Date"].ToString());
                                    DATA.Rows[j]["Date"] = date.ToShortDateString();
                                    //if (DATA.Rows[j]["InvoiceNumber"].ToString() == "")
                                    //{
                                    //    DATA.NewRow();
                                    //    DATA.Rows.Add();
                                    //}
                                    DATA.Rows[j]["FilterName"] = dr["FilterName"].ToString();
                                    DATA.Rows[j]["SalesRep"] = dtAllInvoice.Rows[i]["SalesRep"].ToString();
                                    DATA.Rows[j]["ItemName"] = dr["ItemName"].ToString();
                                    DATA.Rows[j]["Ms"] = dr["ComparativePrice1"].ToString();
                                    DATA.Rows[j]["P4s"] = dr["ComparativePrice2"].ToString();
                                    DATA.Rows[j]["Gf"] = dr["ComparativePrice3"].ToString();
                                    DATA.Rows[j]["XCELL"] = dr["ComparativePrice4"].ToString();
                                    DATA.Rows[j]["P4s-D"] = dr["ComparativePrice5"].ToString();
                                    DATA.Rows[j]["Qty"] = dr["Quantity"].ToString();
                                    DATA.Rows[j]["Rate"] = dr["Rate"].ToString();
                                    DATA.Rows[j]["LowestPrice"] = dr["LowestPrice"].ToString();
                                    DATA.Rows[j]["Amount"] = dr["Amount"].ToString();

                                    DATA.Rows[j]["Cost"] = dr["Cost"].ToString();
                                    if (dr["Cost"].ToString() == "0.00" || dr["Cost"].ToString() == "")
                                    {
                                        DATA.Rows[j]["Profit"] = 0;
                                    }
                                    else
                                    {
                                        DATA.Rows[j]["Profit"] = decimal.Round(Convert.ToDecimal(dr["Quantity"].ToString()) * (Convert.ToDecimal(dr["Rate"].ToString()) - Convert.ToDecimal(dr["Cost"].ToString())), 2);
                                    }
                                    if (dr["Cost"].ToString() == "0.00" || dr["Cost"].ToString() == "")
                                    {
                                        DATA.Rows[j]["ProfitPerPiece"] = 0;
                                    }
                                    else
                                    {
                                        DATA.Rows[j]["ProfitPerPiece"] = decimal.Round(Convert.ToDecimal(dr["Rate"].ToString()) - (Convert.ToDecimal(dr["Cost"].ToString())), 2);
                                    }
                                    if (dr["Cost"].ToString() == "0.00" || dr["Cost"].ToString() == "")
                                    {
                                        DATA.Rows[j]["Profit%"] = 0;
                                    }
                                    else
                                    {
                                        if (DATA.Rows[j]["Profit"].ToString() == "0.00")
                                        {
                                            DATA.Rows[j]["Profit%"] = 0.00;
                                        }
                                        else
                                        {
                                            if (dr["Amount"].ToString() != "0.00")
                                            {
                                                DATA.Rows[j]["Profit%"] = string.Concat(decimal.Round((Convert.ToDecimal(DATA.Rows[j]["Profit"]) / (Convert.ToDecimal(dr["Amount"].ToString())) * 100), 2), '%');
                                            }
                                            else
                                            {
                                                DATA.Rows[j]["Profit%"] = 0.00;
                                            }
                                        }
                                    }
                                    DATA.NewRow();
                                    DATA.Rows.Add();
                                    Total += Convert.ToDecimal(DATA.Rows[j]["Profit"]);
                                    //iRow++;
                                    j++;
                                }
                                // DATA.Rows.Add();
                                //DATA.Rows[iRow]["Profit"] = Total;
                                DATA.Rows[j]["Profit"] = Total;
                            }
                            j++;
                        }
                        catch (Exception ex)
                        {
                            ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster, Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                            MessageBox.Show("Error:" + ex.Message);
                        }
                    }
                }
                if (DATA.Rows.Count > 0)
                {
                    //SaveFileDialog sfd = new SaveFileDialog();
                    //sfd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    //sfd.FilterIndex = 1;
                    //sfd.RestoreDirectory = true;
                    //sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    //if (sfd.ShowDialog() == DialogResult.OK)
                    //{
                    //    Cursor.Current = Cursors.WaitCursor;
                    //using (XLWorkbook wb = new XLWorkbook())
                    //{
                    //    wb.Worksheets.Add(DATA, "Sheet1");
                    //    wb.SaveAs(sfd.FileName);

                    //}
                    //MessageBox.Show("Export Successfully");
                    //}
                    //var app = new Microsoft.Office.Interop.Excel.Application();
                    //app.Visible = true;
                    //app.Workbooks.Open(sfd.FileName, ReadOnly: false);
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    sfd.RestoreDirectory = true;
                    sfd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "Excel//Book1.xlsx";

                    //if (sfd.ShowDialog() == DialogResult.OK)
                    //{
                    Cursor.Current = Cursors.WaitCursor;
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(DATA, "Sheet1");
                        wb.SaveAs(sfd.InitialDirectory);
                    }
                    //MessageBox.Show("Export Successfully");
                    //}
                    var app = new Microsoft.Office.Interop.Excel.Application();
                    app.Visible = true;
                    app.Workbooks.Open(sfd.InitialDirectory, ReadOnly: false);

                }
                else
                {
                    MessageBox.Show("No Data Found");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster, Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        private void dgInvDetail_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            e.SortResult = decimal.Parse(e.CellValue1.ToString().Replace("%", "")).CompareTo(decimal.Parse(e.CellValue2.ToString().Replace("%", "")));
            e.Handled = true;
        }
        private void dtFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("CustomerNumberOnly", "CustomerCenter"))
                {
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                    {
                        CustomerNumberOnly = false;
                    }
                    else
                    {
                        CustomerNumberOnly = true;

                    }
                }
                else
                {
                    CustomerNumberOnly = false;
                }

                dtAllInvoice = new DataTable();
                //if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
                //else
                //    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });

                dgvAllInvoiceList.Rows.Clear();
                if (dtAllInvoice.Rows.Count > 0)
                {
                    int j = 0;
                    for (int i = 0; i < dtAllInvoice.Rows.Count; i++)
                    {
                        try
                        {
                            dgvAllInvoiceList.Rows.Add();
                            dgvAllInvoiceList.Rows[j].Cells[0].Value = dtAllInvoice.Rows[i]["ID"].ToString();
                            if (CustomerNumberOnly == true)
                            {
                                dgvAllInvoiceList.Rows[j].Cells[1].Value = dtAllInvoice.Rows[i]["CustomerNumber"].ToString();
                            }
                            else
                            {
                                dgvAllInvoiceList.Rows[j].Cells[1].Value = dtAllInvoice.Rows[i]["Customer"].ToString();
                            }
                            if (dtAllInvoice.Rows[i]["Num"].ToString() != "")                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
                            {
                                dgvAllInvoiceList.Rows[j].Cells[2].Value = dtAllInvoice.Rows[i]["Num"].ToString();
                            }
                            if (dtAllInvoice.Rows[i]["Date"].ToString() != "")
                            {
                                DateTime date = Convert.ToDateTime(dtAllInvoice.Rows[i]["Date"].ToString());
                                dgvAllInvoiceList.Rows[j].Cells[3].Value = date.ToShortDateString();
                            }
                            if (dtAllInvoice.Rows[i]["Amount"].ToString() != "")
                            {
                                dgvAllInvoiceList.Rows[j].Cells[4].Value = Convert.ToDecimal(dtAllInvoice.Rows[i]["Amount"].ToString());
                            }
                            dgvAllInvoiceList.Rows[j].Cells[5].Value = dtAllInvoice.Rows[i]["SalesRep"].ToString();

                            int INVID = Convert.ToInt32(dtAllInvoice.Rows[i]["ID"].ToString());
                            decimal Total = 0;
                            DataTable dt = new BALInvoiceDetails().SelectByInvID(new BOLInvoiceDetails() { InvoiceID = INVID });
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    if (dr["Cost"].ToString() == "")
                                    {
                                        dr["Cost"] = 0.00;
                                    }
                                    if (dr["Cost"].ToString() != "0.00")
                                    {
                                        Total += Convert.ToDecimal(dr["Quantity"].ToString()) * (Convert.ToDecimal(dr["Rate"].ToString()) - Convert.ToDecimal(dr["Cost"].ToString()));
                                    }
                                    if (dr["Cost"].ToString() == "0.00")
                                    {
                                        dgvAllInvoiceList.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 110, 74);
                                    }
                                }
                            }
                            dgvAllInvoiceList.Rows[j].Cells[6].Value = decimal.Round(Total, 2);

                            if (dtAllInvoice.Rows[i]["Amount"].ToString() != "0.00")
                            {
                                dgvAllInvoiceList.Rows[j].Cells[7].Value = string.Concat(decimal.Round((Convert.ToDecimal(Total) / Convert.ToDecimal(dtAllInvoice.Rows[i]["Amount"].ToString())) * 100, 2), '%');
                            }
                            else
                            {
                                dgvAllInvoiceList.Rows[j].Cells[7].Value = 0 + '%';
                            }

                            j++;
                        }
                        catch (Exception ex)
                        {
                            ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster, Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                            MessageBox.Show("Error:" + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster,Function :dtTo_Leave. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}