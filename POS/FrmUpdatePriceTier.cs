using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;

namespace POS
{
    public partial class FrmUpdatePriceTier : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtAllInvoice = new DataTable();
        Boolean x = true;
        public FrmUpdatePriceTier() 
        {
            InitializeComponent();
        }

       public void LoadData()
       {
            try
            {
                dtAllInvoice = new DataTable();
                if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                else
                    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });

                dgvInvoiceList.Rows.Clear();
                if (dtAllInvoice.Rows.Count > 0)
                {
                    int j = 0;

                    for (int i = 0; i < dtAllInvoice.Rows.Count; i++)
                    {
                        try
                        {
                            dgvInvoiceList.Rows.Add();
                            dgvInvoiceList.Rows[j].Cells[0].Value = dtAllInvoice.Rows[i]["ID"].ToString();
                            dgvInvoiceList.Rows[j].Cells[1].Value = dtAllInvoice.Rows[i]["Customer"].ToString();
                            if (dtAllInvoice.Rows[i]["Num"].ToString() != "")
                            {
                                dgvInvoiceList.Rows[j].Cells[2].Value = Convert.ToInt32(dtAllInvoice.Rows[i]["Num"].ToString());
                            }
                            if (dtAllInvoice.Rows[i]["Date"].ToString() != "")
                            {
                                DateTime date = Convert.ToDateTime(dtAllInvoice.Rows[i]["Date"].ToString());
                                dgvInvoiceList.Rows[j].Cells[3].Value = date.ToShortDateString();
                            }

                            dgvInvoiceList.Rows[j].Cells[4].Value = dtAllInvoice.Rows[i]["SalesRep"].ToString();

                            if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "0")
                            {
                                dgvInvoiceList.Rows[j].Cells[5].Value = "Unpaid";
                            }
                            else if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "1")
                            {
                                dgvInvoiceList.Rows[j].Cells[5].Value = "Partially Paid";
                            }
                            else if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "2")
                            {
                                dgvInvoiceList.Rows[j].Cells[5].Value = "Paid";
                            }
                            j++;
                        }
                        catch (Exception ex)
                        {
                            ClsCommon.WriteErrorLogs("Form:FrmUpdatePriceTier, Function :LoadData. Message:" + ex.Message);
                            MessageBox.Show("Error:" + ex.Message);
                        }

                    }

                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUpdatePriceTier, Function :LoadData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
         
       }

        public void Clear()
        {
            txtSearch.Text = "";
            cmbInvoiceDate.SelectedIndex = 0;
            LoadData();
        }

        private void dgvInvoiceList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("InvUpdate", "CustomerCenter"))
                {
                    ClsCommon.ObjInvoiceMaster.LoadTable();
                    ClsCommon.ObjInvoiceMaster.MdiParent = this.MdiParent;
                    ClsCommon.ObjInvoiceMaster.EditableField();
                    
                    ClsCommon.ObjInvoiceMaster.Show();
                    ClsCommon.ObjInvoiceMaster.LoadData(dgvInvoiceList.CurrentRow.Cells["InvoiceID"].Value.ToString());
                    // ClsCommon.ObjInvoiceMaster.DisplayNotes();
                    x = false;
                    //ClsCommon.ObjCustomerCenter.LoadCustomerData(Convert.ToInt16(dgvInvoiceList.CurrentRow.Cells["InvoiceID"].Value.ToString()));
                    ClsCommon.ObjInvoiceMaster.EnableField();
                    x = true;
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUpdatePriceTier,Function :dgvInvoiceList_CellDoubleClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void FrmUpdatePriceTier_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.Parent = null;
        }

        private void cmbInvoiceDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
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

                dgvInvoiceList.Rows.Clear();
                if (dtAllInvoice.Rows.Count > 0)
                {
                    int j = 0;

                    for (int i = 0; i < dtAllInvoice.Rows.Count; i++)
                    {
                        try
                        {
                            dgvInvoiceList.Rows.Add();
                            dgvInvoiceList.Rows[j].Cells[0].Value = dtAllInvoice.Rows[i]["ID"].ToString();
                            dgvInvoiceList.Rows[j].Cells[1].Value = dtAllInvoice.Rows[i]["Customer"].ToString();
                            if (dtAllInvoice.Rows[i]["Num"].ToString() != "")
                            {
                                dgvInvoiceList.Rows[j].Cells[2].Value = Convert.ToInt32(dtAllInvoice.Rows[i]["Num"].ToString());
                            }
                            if (dtAllInvoice.Rows[i]["Date"].ToString() != "")
                            {
                                DateTime date = Convert.ToDateTime(dtAllInvoice.Rows[i]["Date"].ToString());
                                dgvInvoiceList.Rows[j].Cells[3].Value = date.ToShortDateString();
                            }

                            dgvInvoiceList.Rows[j].Cells[4].Value = dtAllInvoice.Rows[i]["SalesRep"].ToString();

                            if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "0")
                            {
                                dgvInvoiceList.Rows[j].Cells[5].Value = "Unpaid";
                            }
                            else if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "1")
                            {
                                dgvInvoiceList.Rows[j].Cells[5].Value = "Partially Paid";
                            }
                            else if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "2")
                            {
                                dgvInvoiceList.Rows[j].Cells[5].Value = "Paid";
                            }
                            j++;
                        }
                        catch (Exception ex)
                        {
                            ClsCommon.WriteErrorLogs("Form:FrmUpdatePriceTier, Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                            MessageBox.Show("Error:" + ex.Message);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUpdatePriceTier, Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnSe_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text != "")
                {
                    dtAllInvoice = new DataTable();
                    if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                        dtAllInvoice = new BALInvoiceMaster().SelectSearchInvoice(new BOLInvoiceMaster() { SalesRepID = 0, RefNumber = txtSearch.Text, CustomerName = txtSearch.Text });
                    else
                        dtAllInvoice = new BALInvoiceMaster().SelectSearchInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, RefNumber = txtSearch.Text, CustomerName = txtSearch.Text });


                    dgvInvoiceList.Rows.Clear();
                    if (dtAllInvoice.Rows.Count > 0)
                    {
                        int j = 0;

                        for (int i = 0; i < dtAllInvoice.Rows.Count; i++)
                        {
                            try
                            {
                                dgvInvoiceList.Rows.Add();
                                dgvInvoiceList.Rows[j].Cells[0].Value = dtAllInvoice.Rows[i]["ID"].ToString();
                                dgvInvoiceList.Rows[j].Cells[1].Value = dtAllInvoice.Rows[i]["Customer"].ToString();
                                if (dtAllInvoice.Rows[i]["Num"].ToString() != "")
                                {
                                    dgvInvoiceList.Rows[j].Cells[2].Value = Convert.ToInt32(dtAllInvoice.Rows[i]["Num"].ToString());
                                }
                                if (dtAllInvoice.Rows[i]["Date"].ToString() != "")
                                {
                                    DateTime date = Convert.ToDateTime(dtAllInvoice.Rows[i]["Date"].ToString());
                                    dgvInvoiceList.Rows[j].Cells[3].Value = date.ToShortDateString();
                                }

                                dgvInvoiceList.Rows[j].Cells[4].Value = dtAllInvoice.Rows[i]["SalesRep"].ToString();

                                if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "0")
                                {
                                    dgvInvoiceList.Rows[j].Cells[5].Value = "Unpaid";
                                }
                                else if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "1")
                                {
                                    dgvInvoiceList.Rows[j].Cells[5].Value = "Partially Paid";
                                }
                                else if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "2")
                                {
                                    dgvInvoiceList.Rows[j].Cells[5].Value = "Paid";
                                }
                                j++;
                            }
                            catch (Exception ex)
                            {
                                ClsCommon.WriteErrorLogs("Form:FrmUpdatePriceTier, Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                                MessageBox.Show("Error:" + ex.Message);
                            }

                        }

                    }
                }
                else
                {
                    dgvInvoiceList.Rows.Clear();
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUpdatePriceTier,Function :btnSe_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void FrmUpdatePriceTier_Load(object sender, EventArgs e)
        {
            Clear();
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

                dgvInvoiceList.Rows.Clear();
                if (dtAllInvoice.Rows.Count > 0)
                {
                    int j = 0;

                    for (int i = 0; i < dtAllInvoice.Rows.Count; i++)
                    {
                        try
                        {
                            dgvInvoiceList.Rows.Add();
                            dgvInvoiceList.Rows[j].Cells[0].Value = dtAllInvoice.Rows[i]["ID"].ToString();
                            dgvInvoiceList.Rows[j].Cells[1].Value = dtAllInvoice.Rows[i]["Customer"].ToString();
                            if (dtAllInvoice.Rows[i]["Num"].ToString() != "")
                            {
                                dgvInvoiceList.Rows[j].Cells[2].Value = Convert.ToInt32(dtAllInvoice.Rows[i]["Num"].ToString());
                            }
                            if (dtAllInvoice.Rows[i]["Date"].ToString() != "")
                            {
                                DateTime date = Convert.ToDateTime(dtAllInvoice.Rows[i]["Date"].ToString());
                                dgvInvoiceList.Rows[j].Cells[3].Value = date.ToShortDateString();
                            }

                            dgvInvoiceList.Rows[j].Cells[4].Value = dtAllInvoice.Rows[i]["SalesRep"].ToString();

                            if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "0")
                            {
                                dgvInvoiceList.Rows[j].Cells[5].Value = "Unpaid";
                            }
                            else if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "1")
                            {
                                dgvInvoiceList.Rows[j].Cells[5].Value = "Partially Paid";
                            }
                            else if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "2")
                            {
                                dgvInvoiceList.Rows[j].Cells[5].Value = "Paid";
                            }
                            j++;
                        }
                        catch (Exception ex)
                        {
                            ClsCommon.WriteErrorLogs("Form:FrmUpdatePriceTier, Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                            MessageBox.Show("Error:" + ex.Message);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUpdatePriceTier,Function :dtTo_Leave. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbInvoiceDate.SelectedIndex = 0;
                //LoadData();
                txtSearch.Text = "";
            
        }
    }
}