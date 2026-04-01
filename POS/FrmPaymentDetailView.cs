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

namespace POS
{
    public partial class FrmPaymentList : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        
        DataTable dt = new DataTable();
        DataTable dtAllInvoice = new DataTable();
        public FrmPaymentList() 
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtSearch.Text = "";
            cmbInvoiceDate.SelectedIndex = 0;
            display();
        }

        public void display()
        {
            try
            {
                lblFrom.Visible = false; lblTo.Visible = false; dtFrom.Visible = false; dtTo.Visible = false;

                dtAllInvoice = new DataTable();
                if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = 0, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                else
                    dtAllInvoice = new BALInvoiceMaster().SelectAllInvoice(new BOLInvoiceMaster() { SalesRepID = ClsCommon.UserID, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });

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
                            dgvAllInvoiceList.Rows[j].Cells[1].Value = dtAllInvoice.Rows[i]["Customer"].ToString();
                            if (dtAllInvoice.Rows[i]["Num"].ToString() != "")
                            {
                                dgvAllInvoiceList.Rows[j].Cells[2].Value = Convert.ToInt32(dtAllInvoice.Rows[i]["Num"].ToString());
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
                            if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "0")
                            {
                                dgvAllInvoiceList.Rows[j].Cells[6].Value = "Unpaid";
                            }
                            else if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "1")
                            {
                                dgvAllInvoiceList.Rows[j].Cells[6].Value = "Partially Paid";
                            }
                            else if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "2")
                            {
                                dgvAllInvoiceList.Rows[j].Cells[6].Value = "Paid";
                            }


                            int INVID = Convert.ToInt32(dtAllInvoice.Rows[i]["ID"].ToString());
                            string Method = "";
                            DataTable dt = new BALPayment().SelectByInvID(INVID);
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    if (Method == "")
                                    {
                                        if (dr["CreditAmount"].ToString() != "")
                                        {
                                            Method += dr["Name"].ToString() + '=' + '$' + dr["CreditAmount"].ToString();
                                        }
                                        else
                                        {
                                            Method += dr["Name"].ToString() + '=' + '$' + dr["PayAmount"].ToString();
                                        }


                                    }
                                    else
                                    {
                                        if (dr["CreditAmount"].ToString() != "")
                                        {
                                            Method += ',' + dr["Name"].ToString() + '=' + '$' + dr["CreditAmount"].ToString();
                                        }
                                        else
                                        {
                                            Method += ',' + dr["Name"].ToString() + '=' + '$' + dr["PayAmount"].ToString();
                                        }

                                    }



                                }
                            }
                            dgvAllInvoiceList.Rows[j].Cells[7].Value = Method;
                            dgvAllInvoiceList.Rows[j].Cells[8].Value = Convert.ToDecimal(dtAllInvoice.Rows[i]["Amount"].ToString()) - Convert.ToDecimal(dtAllInvoice.Rows[i]["OpenBalance"].ToString());

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
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster, Function :display. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

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
                            dgvAllInvoiceList.Rows[j].Cells[1].Value = dtAllInvoice.Rows[i]["Customer"].ToString();
                            if (dtAllInvoice.Rows[i]["Num"].ToString() != "")
                            {
                                dgvAllInvoiceList.Rows[j].Cells[2].Value = Convert.ToInt32(dtAllInvoice.Rows[i]["Num"].ToString());
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
                            if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "0")
                            {
                                dgvAllInvoiceList.Rows[j].Cells[6].Value = "Unpaid";
                            }
                            else if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "1")
                            {
                                dgvAllInvoiceList.Rows[j].Cells[6].Value = "Partially Paid";
                            }
                            else if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "2")
                            {
                                dgvAllInvoiceList.Rows[j].Cells[6].Value = "Paid";
                            }


                            int INVID = Convert.ToInt32(dtAllInvoice.Rows[i]["ID"].ToString());
                            string Method = "";
                            DataTable dt = new BALPayment().SelectByInvID(INVID);
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    if (Method == "")
                                    {
                                        if (dr["CreditAmount"].ToString() != "")
                                        {
                                            Method += dr["Name"].ToString() + '=' + '$' + dr["CreditAmount"].ToString();
                                        }
                                        else
                                        {
                                            Method += dr["Name"].ToString() + '=' + '$' + dr["PayAmount"].ToString();
                                        }


                                    }
                                    else
                                    {
                                        if (dr["CreditAmount"].ToString() != "")
                                        {
                                            Method += ',' + dr["Name"].ToString() + '=' + '$' + dr["CreditAmount"].ToString();
                                        }
                                        else
                                        {
                                            Method += ',' + dr["Name"].ToString() + '=' + '$' + dr["PayAmount"].ToString();
                                        }

                                    }


                                }
                            }
                            dgvAllInvoiceList.Rows[j].Cells[7].Value = Method;
                            dgvAllInvoiceList.Rows[j].Cells[8].Value = Convert.ToDecimal(dtAllInvoice.Rows[i]["Amount"].ToString()) - Convert.ToDecimal(dtAllInvoice.Rows[i]["OpenBalance"].ToString());

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

        private void FrmPaymentList_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.Parent = null;
        }

        private void FrmPaymentList_Load(object sender, EventArgs e)
        {
            dgvAllInvoiceList.RowTemplate.Height = 25;
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
                                dgvAllInvoiceList.Rows[j].Cells[1].Value = dtAllInvoice.Rows[i]["Customer"].ToString();
                                if (dtAllInvoice.Rows[i]["Num"].ToString() != "")
                                {
                                    dgvAllInvoiceList.Rows[j].Cells[2].Value = Convert.ToInt32(dtAllInvoice.Rows[i]["Num"].ToString());
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
                                if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "0")
                                {
                                    dgvAllInvoiceList.Rows[j].Cells[6].Value = "Unpaid";
                                }
                                else if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "1")
                                {
                                    dgvAllInvoiceList.Rows[j].Cells[6].Value = "Partially Paid";
                                }
                                else if (dtAllInvoice.Rows[i]["PaidInvoice"].ToString() == "2")
                                {
                                    dgvAllInvoiceList.Rows[j].Cells[6].Value = "Paid";
                                }


                                int INVID = Convert.ToInt32(dtAllInvoice.Rows[i]["ID"].ToString());
                                string Method = "";
                                DataTable dt = new BALPayment().SelectByInvID(INVID);
                                if (dt.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        if (Method == "")
                                        {
                                            if (dr["CreditAmount"].ToString() != "")
                                            {
                                                Method +=  dr["Name"].ToString() + '=' + '$' + dr["CreditAmount"].ToString();
                                            }
                                            else
                                            {
                                                Method += dr["Name"].ToString() + '=' + '$' + dr["PayAmount"].ToString();
                                            }


                                        }
                                        else
                                        {
                                            if (dr["CreditAmount"].ToString() != "")
                                            {
                                                Method += ',' + dr["Name"].ToString() + '=' + '$' + dr["CreditAmount"].ToString();
                                            }
                                            else
                                            {
                                                Method += ',' +  dr["Name"].ToString() + '=' + '$' + dr["PayAmount"].ToString();
                                            }

                                        }


                                    }
                                }
                                dgvAllInvoiceList.Rows[j].Cells[7].Value = Method;
                                dgvAllInvoiceList.Rows[j].Cells[8].Value = Convert.ToDecimal(dtAllInvoice.Rows[i]["Amount"].ToString()) - Convert.ToDecimal(dtAllInvoice.Rows[i]["OpenBalance"].ToString());

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
                DataTable dt = new DataTable();

                foreach (DataGridViewColumn column in dgvAllInvoiceList.Columns)
                {
                    dt.Columns.Add(column.HeaderText);
                }

                foreach (DataGridViewRow row in dgvAllInvoiceList.Rows)
                {
                    dt.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value.ToString() != null)
                        {
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                        }

                    }
                }
                if (dt.Rows.Count > 0)
                {

                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    sfd.RestoreDirectory = true;
                    sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "Sheet1");
                            wb.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Export Successfully");
                    }

                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceProfitMaster,Function :btnExport_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgvAllInvoiceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}