using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;

namespace POS
{
    public partial class FrmTrackingInfoMaster : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dt = new DataTable(); DataTable dtAllInvoice = new DataTable();
        BALHistoryMaster BALHistory = new BALHistoryMaster();
      
        public FrmTrackingInfoMaster()
        {
            InitializeComponent();
           
        }

        private void FrmTrackingInfoMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.Parent = null;
        }

        public void displaydata()
        {
            
            dtAllInvoice = new DataTable();
            try
            {
                dgUser.Rows.Clear();
                if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                    dtAllInvoice = new BALInvoiceMaster().SelectUnship(new BOLInvoiceMaster() { SalesRepID=0 ,StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                else
                    dtAllInvoice = new BALInvoiceMaster().SelectUnship(new BOLInvoiceMaster() { SalesRepID=ClsCommon.UserID ,StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                int iRow = 0;
                if(dtAllInvoice.Rows.Count > 0)
                {
                    foreach (DataRow item in dtAllInvoice.Rows)
                    {
                        dgUser.Rows.Add();
                        dgUser[0, iRow].Value = item["ID"].ToString();
                        dgUser[1, iRow].Value = item["RefNumber"].ToString();
                        if (item["TxnDate"].ToString() != "")
                        {
                            DateTime date = Convert.ToDateTime(item["TxnDate"].ToString());
                            dgUser[2, iRow].Value = date.ToString("dd/MM/yyyy");
                        }
                        dgUser[3, iRow].Value = item["CustomerName"].ToString();
                        dgUser[4, iRow].Value = item["Total"].ToString();

                        int INVID = Convert.ToInt32(item["ID"].ToString());
                        DataTable dt = BALHistory.Select(INVID);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["IsPrintDate"].ToString() != "" && dt.Rows[0]["IsUpdateDate"].ToString() != "")
                            {
                                if (Convert.ToDateTime(dt.Rows[0]["IsUpdateDate"]) > Convert.ToDateTime(dt.Rows[0]["IsPrintDate"]))
                                {
                                    dgUser.Rows[iRow].DefaultCellStyle.BackColor = Color.Orange;
                                }
                                else if (Convert.ToDateTime(dt.Rows[0]["IsPrintDate"]) > Convert.ToDateTime(dt.Rows[0]["IsUpdateDate"]))
                                {
                                    dgUser.Rows[iRow].DefaultCellStyle.BackColor = Color.LightSeaGreen;
                                }
                            }
                            else if (dt.Rows[0]["IsPrintDate"].ToString() == "" && dt.Rows[0]["IsUpdateDate"].ToString() != "")
                            {
                                dgUser.Rows[iRow].DefaultCellStyle.BackColor = Color.Orange;
                            }


                        }
                        iRow++;
                    }
                }             
                
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmTrackingInfoMaster,Function :displaydata. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void FrmTrackingMaster_Load(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            lblFrom.Visible = false; lblTo.Visible = false; dtFrom.Visible = false; dtTo.Visible = false;
            cmbInvoiceDate.SelectedIndex = 0;
            txtSearch.Text = "";
            displaydata();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lblFrom.Visible = false; lblTo.Visible = false; dtFrom.Visible = false; dtTo.Visible = false;
            cmbInvoiceDate.SelectedIndex = 0;
            txtSearch.Text = "";
        }

        public void CheckInvoice(string ID)
        {
            try
            {
                if(ID != "")
                {               
                    DataTable dtInvoice = new BALInvoiceMaster().SelectByID(new BOLInvoiceMaster() { ID = Convert.ToInt32(ID) });
                    if (dtInvoice.Rows.Count > 0)
                    {
                        if (dtInvoice.Rows[0]["IsShipping"].ToString() == "1")
                        {
                            foreach (DataGridViewRow item in dgUser.Rows)
                            {
                                if (item.Cells[0].Value.ToString() == dtInvoice.Rows[0]["ID"].ToString())
                                {
                                    dgUser.Rows.Remove(item);
                                }
                            }
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmTrackingInfoMaster,Function :CheckInvoice. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgTracking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    DataTable dtInvDetail = new BALInvoiceDetails().SelectByID(new BOLInvoiceDetails() { InvoiceID = Convert.ToInt32(dgUser.CurrentRow.Cells[0].Value) });
                    if (dtInvDetail.Rows.Count > 0)
                    {
                        dgInvDetail.Rows.Clear();
                        int iRow = 0;
                        foreach (DataRow dr in dtInvDetail.Rows)
                        {
                            dgInvDetail.Rows.Add();
                            dgInvDetail[0, iRow].Value = dr["ID"].ToString();
                            dgInvDetail[1, iRow].Value = dr["ItemFullName"].ToString();
                            dgInvDetail[2, iRow].Value = dr["Quantity"].ToString();
                            dgInvDetail[3, iRow].Value = dr["Rate"].ToString();
                            dgInvDetail[4, iRow].Value = dr["Amount"].ToString();
                            iRow++;
                        }
                    }
                    pnlInvDetails.Visible = true;
                }

                if (e.ColumnIndex == 6)
                {
                    try
                    {
                      
                        int ID1 = Convert.ToInt32(dgUser.CurrentRow.Cells[0].Value);
                        ClsCommon.ObjCustomerCenter.PrintINV(ref ID1);
                        ClsCommon.INVID = ID1;
                        ClsCommon.ObjInvoiceMaster.InvoicePrintHistory(ClsCommon.INVID);                
                        ClsCommon.ObjInvoiceMaster.PrintSave(ClsCommon.INVID);
                       
                        MessageBox.Show("Invoice Print Successfully");

                    }
                    catch (Exception ex)
                    {
                        ClsCommon.WriteErrorLogs("Form:FrmCustomerCenter,Function :dgvInvoiceList_CellContentClick. Message:" + ex.Message);
                        MessageBox.Show("Error:" + ex.Message);
                    }
                }

                if (e.ColumnIndex == 7)
                {
                    ClsCommon.objTracking.LoadData(dgUser.CurrentRow.Cells[0].Value.ToString());
                    ClsCommon.objTracking.MdiParent = ClsCommon.objMDIParent;
                    panel1.Controls.Add(ClsCommon.objTracking);
                    ClsCommon.objTracking.Show();
                    ClsCommon.objTracking.BringToFront();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmTrackingInfoMaster,Function :dgTracking_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            pnlInvDetails.Visible = false;
        }

        private void cmbInvoiceDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            dtAllInvoice = new DataTable();
            try
            {
                lblFrom.Visible = false; lblTo.Visible = false; dtFrom.Visible = false; dtTo.Visible = false;
                if (cmbInvoiceDate.SelectedIndex == 0)
                {
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectUnship(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                    else
                        dtAllInvoice = new BALInvoiceMaster().SelectUnship(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                }
                else if (cmbInvoiceDate.SelectedIndex == 1)
                {
                    //yesterday
                    DateTime dt1 = DateTime.Now.AddDays(-1);
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectUnship(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                    else
                        dtAllInvoice = new BALInvoiceMaster().SelectUnship(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }
                
                else if (cmbInvoiceDate.SelectedIndex == 2)
                {
                    //this month
                  
                    DateTime dt = DateTime.Now;
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectUnship(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                    else
                        dtAllInvoice = new BALInvoiceMaster().SelectUnship(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });

                }
                else if (cmbInvoiceDate.SelectedIndex == 3)
                {
                    //this week
                   
                    DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
                    DateTime dt1 = dt.AddDays(6);
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectUnship(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                    else
                        dtAllInvoice = new BALInvoiceMaster().SelectUnship(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });

                }
                else if (cmbInvoiceDate.SelectedIndex == 4)
                {
                    //last month
                   
                    DateTime dt = DateTime.Now.AddMonths(-1);
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectUnship(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                    else
                        dtAllInvoice = new BALInvoiceMaster().SelectUnship(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });

                }
                else if (cmbInvoiceDate.SelectedIndex == 5)
                {
                    //this ficsal year
                    
                    int year = DateTime.Now.Year;
                    DateTime firstDay = Convert.ToDateTime(year + "-" + "01" + "-" + "01");
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectUnship(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = firstDay.ToString("yyyy-MM-dd"), EndDate = firstDay.AddYears(1).AddDays(-1).ToString("yyyy-MM-dd") });
                    else
                        dtAllInvoice = new BALInvoiceMaster().SelectUnship(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = firstDay.ToString("yyyy-MM-dd"), EndDate = firstDay.AddYears(1).AddDays(-1).ToString("yyyy-MM-dd") });

                }
                else if (cmbInvoiceDate.SelectedIndex == 6)
                {
                    //all
                    dtAllInvoice = new DataTable();
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectUnship(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = null, EndDate = null });
                    else
                        dtAllInvoice = new BALInvoiceMaster().SelectUnship(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = null, EndDate = null });

                }
                else if (cmbInvoiceDate.SelectedIndex == 7)
                {
                    //custom
                   
                    dtAllInvoice = new BALInvoiceMaster().SelectUnship(new BOLInvoiceMaster() { StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
                    lblFrom.Visible = true; lblTo.Visible = true; dtFrom.Visible = true; dtTo.Visible = true;
                }
                dgUser.Rows.Clear();
                if (dtAllInvoice.Rows.Count > 0)
                {
                  
                    int iRow = 0;
                    foreach (DataRow item in dtAllInvoice.Rows)
                    {
                        dgUser.Rows.Add();
                        dgUser[0, iRow].Value = item["ID"].ToString();
                        dgUser[1, iRow].Value = item["RefNumber"].ToString();
                        if (item["TxnDate"].ToString() != "")
                        {
                            DateTime date = Convert.ToDateTime(item["TxnDate"].ToString());
                            dgUser[2, iRow].Value = date.ToString("dd/MM/yyyy");
                        }
                        dgUser[3, iRow].Value = item["CustomerName"].ToString();
                        dgUser[4, iRow].Value = item["Total"].ToString();

                        int INVID = Convert.ToInt32(item["ID"].ToString());
                        DataTable dt = BALHistory.Select(INVID);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["IsPrintDate"].ToString() != "" && dt.Rows[0]["IsUpdateDate"].ToString() != "")
                            {
                                if (Convert.ToDateTime(dt.Rows[0]["IsUpdateDate"]) > Convert.ToDateTime(dt.Rows[0]["IsPrintDate"]))
                                {
                                    dgUser.Rows[iRow].DefaultCellStyle.BackColor = Color.Orange;
                                }
                                else if (Convert.ToDateTime(dt.Rows[0]["IsPrintDate"]) > Convert.ToDateTime(dt.Rows[0]["IsUpdateDate"]))
                                {
                                    dgUser.Rows[iRow].DefaultCellStyle.BackColor = Color.LightSeaGreen;
                                }
                            }
                            else if (dt.Rows[0]["IsPrintDate"].ToString() == "" && dt.Rows[0]["IsUpdateDate"].ToString() != "")
                            {
                                dgUser.Rows[iRow].DefaultCellStyle.BackColor = Color.Orange;
                            }


                        }
                        iRow++;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmTrackingInfoMaster,Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dtTo_Leave(object sender, EventArgs e)
        {
            try
            {
                dgUser.Rows.Clear();
                dtAllInvoice = new DataTable();
                if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                    dtAllInvoice = new BALInvoiceMaster().SelectUnship(new BOLInvoiceMaster() { SalesRepID=0,StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
                else
                    dtAllInvoice = new BALInvoiceMaster().SelectUnship(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
                if (dtAllInvoice.Rows.Count > 0)
                {
                    int iRow = 0;
                    foreach (DataRow item in dtAllInvoice.Rows)
                    {
                        dgUser.Rows.Add();
                        dgUser[0, iRow].Value = item["ID"].ToString();
                        dgUser[1, iRow].Value = item["RefNumber"].ToString();
                        if (item["TxnDate"].ToString() != "")
                        {
                            DateTime date = Convert.ToDateTime(item["TxnDate"].ToString());
                            dgUser[2, iRow].Value = date.ToString("dd/MM/yyyy");
                        }
                        dgUser[3, iRow].Value = item["CustomerName"].ToString();
                        dgUser[4, iRow].Value = item["Total"].ToString();

                        int INVID = Convert.ToInt32(item["ID"].ToString());
                        DataTable dt = BALHistory.Select(INVID);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["IsPrintDate"].ToString() != "" && dt.Rows[0]["IsUpdateDate"].ToString() != "")
                            {
                                if (Convert.ToDateTime(dt.Rows[0]["IsUpdateDate"]) > Convert.ToDateTime(dt.Rows[0]["IsPrintDate"]))
                                {
                                    dgUser.Rows[iRow].DefaultCellStyle.BackColor = Color.Orange;
                                }
                                else if (Convert.ToDateTime(dt.Rows[0]["IsPrintDate"]) > Convert.ToDateTime(dt.Rows[0]["IsUpdateDate"]))
                                {
                                    dgUser.Rows[iRow].DefaultCellStyle.BackColor = Color.LightSeaGreen;
                                }
                            }
                            else if (dt.Rows[0]["IsPrintDate"].ToString() == "" && dt.Rows[0]["IsUpdateDate"].ToString() != "")
                            {
                                dgUser.Rows[iRow].DefaultCellStyle.BackColor = Color.Orange;
                            }


                        }
                        iRow++;
                    }
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmTrackingInfoMaster,Function :dtTo_Leave. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnSe_Click(object sender, EventArgs e)
        {
            try
            {
                dgUser.Rows.Clear();
                if (txtSearch.Text != "")
                {
                    dtAllInvoice = new DataTable();
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SearchUnshipInvoice(new BOLInvoiceMaster() { SalesRepID=0,RefNumber = txtSearch.Text, CustomerName = txtSearch.Text });
                    else
                        dtAllInvoice = new BALInvoiceMaster().SearchUnshipInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, RefNumber = txtSearch.Text, CustomerName = txtSearch.Text });
                    if (dtAllInvoice.Rows.Count > 0)
                    {
                        int iRow = 0;
                        foreach (DataRow item in dtAllInvoice.Rows)
                        {
                            dgUser.Rows.Add();
                            dgUser[0, iRow].Value = item["ID"].ToString();
                            dgUser[1, iRow].Value = item["RefNumber"].ToString();
                            if (item["TxnDate"].ToString() != "")
                            {
                                DateTime date = Convert.ToDateTime(item["TxnDate"].ToString());
                                dgUser[2, iRow].Value = date.ToString("dd/MM/yyyy");
                            }
                            dgUser[3, iRow].Value = item["CustomerName"].ToString();
                            dgUser[4, iRow].Value = item["Total"].ToString();

                            int INVID = Convert.ToInt32(item["ID"].ToString());
                            DataTable dt = BALHistory.Select(INVID);
                            if (dt.Rows.Count > 0)
                            {
                                if (dt.Rows[0]["IsPrintDate"].ToString() != "" && dt.Rows[0]["IsUpdateDate"].ToString() != "")
                                {
                                    if (Convert.ToDateTime(dt.Rows[0]["IsUpdateDate"]) > Convert.ToDateTime(dt.Rows[0]["IsPrintDate"]))
                                    {
                                        dgUser.Rows[iRow].DefaultCellStyle.BackColor = Color.Orange;
                                    }
                                    else if (Convert.ToDateTime(dt.Rows[0]["IsPrintDate"]) > Convert.ToDateTime(dt.Rows[0]["IsUpdateDate"]))
                                    {
                                        dgUser.Rows[iRow].DefaultCellStyle.BackColor = Color.LightSeaGreen;
                                    }
                                }
                                else if (dt.Rows[0]["IsPrintDate"].ToString() == "" && dt.Rows[0]["IsUpdateDate"].ToString() != "")
                                {
                                    dgUser.Rows[iRow].DefaultCellStyle.BackColor = Color.Orange;
                                }


                            }
                            iRow++;
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmTrackingInfoMaster,Function :btnSe_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}