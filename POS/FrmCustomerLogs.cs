using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Office.Interop.Excel;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.Report;
using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;

namespace POS
{
    public partial class FrmCustomerLogs : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BOLCustomerMaster_Update objBOLCustomerUpdateLog = new BOLCustomerMaster_Update();
        BALCustomerMaster_Update objBALCustomerUpdateLog = new BALCustomerMaster_Update();
        DataTable dtAllCustomer = new DataTable(); 
        public FrmCustomerLogs()
        {
            InitializeComponent();
            cmbInvoiceDate.SelectedIndex = 0;
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(0, 0);

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn column in dgvAllCustomerList.Columns)
                {
                    dt.Columns.Add(column.HeaderText);
                }
                foreach (DataGridViewRow row in dgvAllCustomerList.Rows)
                {
                    dt.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                        {
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                        }
                    }
                }
                // dt = new BALItemMaster().SelectByQtyOnHand();
                if (dt.Rows.Count > 0)
                {
                    dt.Columns.Remove("No");
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
                        wb.Worksheets.Add(dt, "Sheet1");
                        wb.SaveAs(sfd.InitialDirectory);
                    }
                    //MessageBox.Show("Export Successfully");
                    //}
                    var app = new Microsoft.Office.Interop.Excel.Application();
                    app.Visible = true;
                    app.Workbooks.Open(sfd.InitialDirectory, ReadOnly: false);
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerLogs,Function :btnExport_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void cmbInvoiceDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Display();
        }
        public void Display()
        {
            try
            {
                lblFrom.Visible = false; lblTo.Visible = false; dtFrom.Visible = false; dtTo.Visible = false;

                if (cmbInvoiceDate.SelectedIndex == 0)
                {
                    //today
                    dtAllCustomer = new DataTable();
                    dtAllCustomer = new BALCustomerMaster_Update().SelectByDate(new BOLCustomerMaster_Update() { StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                }
                else if (cmbInvoiceDate.SelectedIndex == 1)
                {
                    //yesterday
                    dtAllCustomer = new DataTable();
                    DateTime dt1 = DateTime.Now.AddDays(-1);
                    dtAllCustomer = new BALCustomerMaster_Update().SelectByDate(new BOLCustomerMaster_Update() { StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 2)
                {
                    //this month
                    dtAllCustomer = new DataTable();
                    DateTime dt = DateTime.Now;
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    dtAllCustomer = new BALCustomerMaster_Update().SelectByDate(new BOLCustomerMaster_Update() { StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 3)
                {
                    //this week
                    dtAllCustomer = new DataTable();
                    DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
                    DateTime dt1 = dt.AddDays(6);

                    dtAllCustomer = new BALCustomerMaster_Update().SelectByDate(new BOLCustomerMaster_Update() { StartDate = dt.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }
                else if (cmbInvoiceDate.SelectedIndex == 4)
                {
                    //last month
                    dtAllCustomer = new DataTable();
                    DateTime dt = DateTime.Now.AddMonths(-1);
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    dtAllCustomer = new BALCustomerMaster_Update().SelectByDate(new BOLCustomerMaster_Update() { StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });

                }
                else if (cmbInvoiceDate.SelectedIndex == 5)
                {
                    //this ficsal year
                    dtAllCustomer = new DataTable();
                    int year = DateTime.Now.Year;
                    DateTime firstDay = Convert.ToDateTime(year + "-" + "01" + "-" + "01");
                    dtAllCustomer = new BALCustomerMaster_Update().SelectByDate(new BOLCustomerMaster_Update() { StartDate = firstDay.ToString("yyyy-MM-dd"), EndDate = firstDay.AddYears(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }

                else if (cmbInvoiceDate.SelectedIndex == 6)
                {
                    //all
                    dtAllCustomer = new DataTable();
                    dtAllCustomer = new BALCustomerMaster_Update().SelectByDate(new BOLCustomerMaster_Update() { StartDate = null, EndDate = null });
                }

                else if (cmbInvoiceDate.SelectedIndex == 7)
                {
                    //custom
                    dtAllCustomer = new DataTable();
                    dtAllCustomer = new BALCustomerMaster_Update().SelectByDate(new BOLCustomerMaster_Update() { StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
                    lblFrom.Visible = true; lblTo.Visible = true; dtFrom.Visible = true; dtTo.Visible = true;
                }

                dgvAllCustomerList.Rows.Clear();
                if (dtAllCustomer.Rows.Count > 0)
                {
                    int j = 0;
                    for (int i = 0; i < dtAllCustomer.Rows.Count; i++)
                    {
                        dgvAllCustomerList.Rows.Add();
                        dgvAllCustomerList.Rows[j].Cells[0].Value = dtAllCustomer.Rows[i]["ID"].ToString();
                        dgvAllCustomerList.Rows[j].Cells[1].Value = dtAllCustomer.Rows[i]["NewCustomerName"].ToString();
                        dgvAllCustomerList.Rows[j].Cells[2].Value = dtAllCustomer.Rows[i]["OldCustomerName"].ToString();
                        dgvAllCustomerList.Rows[j].Cells[3].Value = dtAllCustomer.Rows[i]["NewSalutation"].ToString();
                        dgvAllCustomerList.Rows[j].Cells[4].Value = dtAllCustomer.Rows[i]["OldSalutation"].ToString();
                        dgvAllCustomerList.Rows[j].Cells[5].Value = dtAllCustomer.Rows[i]["NewFirstName"].ToString();
                        dgvAllCustomerList.Rows[j].Cells[6].Value = dtAllCustomer.Rows[i]["OldFirstName"].ToString();
                        dgvAllCustomerList.Rows[j].Cells[7].Value = dtAllCustomer.Rows[i]["NewMiddleName"].ToString();
                        dgvAllCustomerList.Rows[j].Cells[8].Value = dtAllCustomer.Rows[i]["OldMiddleName"].ToString();
                        dgvAllCustomerList.Rows[j].Cells[9].Value = dtAllCustomer.Rows[i]["NewLastName"].ToString();
                        dgvAllCustomerList.Rows[j].Cells[10].Value = dtAllCustomer.Rows[i]["OldLastName"].ToString();
                        dgvAllCustomerList.Rows[j].Cells[11].Value = dtAllCustomer.Rows[i]["EditCount"].ToString();
                        dgvAllCustomerList.Rows[j].Cells[12].Value = Convert.ToDateTime(dtAllCustomer.Rows[i]["UpdateDate"].ToString()).ToShortDateString();
                        j++;
                    }
                }
                HideColumn();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerLogs,Function :cmbInvoiceDate_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void HideColumn()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = new BALCustomerLogHideColumn().Select(new BOLCustomerLogHideColumn() { UserID = ClsCommon.UserID });
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["NewCustomerName"].ToString() == "1")
                    {
                        dgvAllCustomerList.Columns["NewCustomerName"].Visible = false;
                    }
                    else
                    {
                        dgvAllCustomerList.Columns["NewCustomerName"].Visible = true;
                    }


                    if (dt.Rows[0]["OldCustomerName"].ToString() == "1")
                    {
                        dgvAllCustomerList.Columns["OldCustomerName"].Visible = false;
                    }
                    else
                    {
                        dgvAllCustomerList.Columns["OldCustomerName"].Visible = true;
                    }
                    if (dt.Rows[0]["NewSalutation"].ToString() == "1")
                    {
                        dgvAllCustomerList.Columns["NewSalutation"].Visible = false;
                    }
                    else
                    {
                        dgvAllCustomerList.Columns["NewSalutation"].Visible = true;
                    }
                    if (dt.Rows[0]["OldSalutation"].ToString() == "1")
                    {
                        dgvAllCustomerList.Columns["OldSalutation"].Visible = false;
                    }
                    else
                    {
                        dgvAllCustomerList.Columns["OldSalutation"].Visible = true;
                    }
                    if (dt.Rows[0]["NewFirstName"].ToString() == "1")
                    {
                        dgvAllCustomerList.Columns["NewFirstName"].Visible = false;
                    }
                    else
                    {
                        dgvAllCustomerList.Columns["NewFirstName"].Visible = true;
                    }
                    if (dt.Rows[0]["OldFirstName"].ToString() == "1")
                    {
                        dgvAllCustomerList.Columns["OldFirstName"].Visible = false;
                    }
                    else
                    {
                        dgvAllCustomerList.Columns["OldFirstName"].Visible = true;
                    }
                    if (dt.Rows[0]["NewMiddleName"].ToString() == "1")
                    {
                        dgvAllCustomerList.Columns["NewMiddleName"].Visible = false;
                    }
                    else
                    {
                        dgvAllCustomerList.Columns["NewMiddleName"].Visible = true;
                    }
                    if (dt.Rows[0]["OldMiddleName"].ToString() == "1")
                    {
                        dgvAllCustomerList.Columns["OldMiddleName"].Visible = false;
                    }
                    else
                    {
                        dgvAllCustomerList.Columns["OldMiddleName"].Visible = true;
                    }
                    if (dt.Rows[0]["NewLastName"].ToString() == "1")
                    {
                        dgvAllCustomerList.Columns["NewLastName"].Visible = false;
                    }
                    else
                    {
                        dgvAllCustomerList.Columns["NewLastName"].Visible = true;
                    }
                    if (dt.Rows[0]["OldLastName"].ToString() == "1")
                    {
                        dgvAllCustomerList.Columns["OldLastName"].Visible = false;
                    }
                    else
                    {
                        dgvAllCustomerList.Columns["OldLastName"].Visible = true;
                    }
                    if (dt.Rows[0]["EditCount"].ToString() == "1")
                    {
                        dgvAllCustomerList.Columns["EditCount"].Visible = false;
                    }
                    else
                    {
                        dgvAllCustomerList.Columns["EditCount"].Visible = true;
                    }
                    if (dt.Rows[0]["UpdateDate"].ToString() == "1")
                    {
                        dgvAllCustomerList.Columns["UpdateDate"].Visible = false;
                    }
                    else
                    {
                        dgvAllCustomerList.Columns["UpdateDate"].Visible = true;
                    }

                }
                else
                {
                    ClsCommon.WriteErrorLogs("Form:FrmCustomerLogs,Function :HideColumn. Table Not Count");

                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerLogs,Function :HideColumn. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void dtFrom_Leave(object sender, EventArgs e)
        {
            dtAllCustomer = new DataTable();
            dtAllCustomer = new BALCustomerMaster_Update().SelectByDate(new BOLCustomerMaster_Update() { StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
            dgvAllCustomerList.Rows.Clear();
            if (dtAllCustomer.Rows.Count > 0)
            {
                int j = 0;

                for (int i = 0; i < dtAllCustomer.Rows.Count; i++)
                {
                    dgvAllCustomerList.Rows.Add();
                    dgvAllCustomerList.Rows[j].Cells[0].Value = dtAllCustomer.Rows[i]["ID"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[1].Value = dtAllCustomer.Rows[i]["NewCustomerName"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[2].Value = dtAllCustomer.Rows[i]["OldCustomerName"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[3].Value = dtAllCustomer.Rows[i]["NewSalutation"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[4].Value = dtAllCustomer.Rows[i]["OldSalutation"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[5].Value = dtAllCustomer.Rows[i]["NewFirstName"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[6].Value = dtAllCustomer.Rows[i]["OldFirstName"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[7].Value = dtAllCustomer.Rows[i]["NewMiddleName"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[8].Value = dtAllCustomer.Rows[i]["OldMiddleName"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[9].Value = dtAllCustomer.Rows[i]["NewLastName"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[10].Value = dtAllCustomer.Rows[i]["OldLastName"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[11].Value = dtAllCustomer.Rows[i]["EditCount"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[12].Value = Convert.ToDateTime(dtAllCustomer.Rows[i]["UpdateDate"].ToString()).ToShortDateString();

                    j++;
                }
            }
        }
        private void dtTo_Leave(object sender, EventArgs e)
        {
            dtAllCustomer = new DataTable();
            dtAllCustomer = new BALCustomerMaster_Update().SelectByDate(new BOLCustomerMaster_Update() { StartDate = dtFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTo.Value.ToString("yyyy-MM-dd") });
            dgvAllCustomerList.Rows.Clear();
            if (dtAllCustomer.Rows.Count > 0)
            {
                int j = 0;

                for (int i = 0; i < dtAllCustomer.Rows.Count; i++)
                {
                    dgvAllCustomerList.Rows.Add();
                    dgvAllCustomerList.Rows[j].Cells[0].Value = dtAllCustomer.Rows[i]["ID"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[1].Value = dtAllCustomer.Rows[i]["NewCustomerName"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[2].Value = dtAllCustomer.Rows[i]["OldCustomerName"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[3].Value = dtAllCustomer.Rows[i]["NewSalutation"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[4].Value = dtAllCustomer.Rows[i]["OldSalutation"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[5].Value = dtAllCustomer.Rows[i]["NewFirstName"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[6].Value = dtAllCustomer.Rows[i]["OldFirstName"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[7].Value = dtAllCustomer.Rows[i]["NewMiddleName"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[8].Value = dtAllCustomer.Rows[i]["OldMiddleName"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[9].Value = dtAllCustomer.Rows[i]["NewLastName"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[10].Value = dtAllCustomer.Rows[i]["OldLastName"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[11].Value = dtAllCustomer.Rows[i]["EditCount"].ToString();
                    dgvAllCustomerList.Rows[j].Cells[12].Value = Convert.ToDateTime(dtAllCustomer.Rows[i]["UpdateDate"].ToString()).ToShortDateString();
                    j++;
                }
            }
        }
        private void FrmCustomerLogs_Load(object sender, EventArgs e)
        {
            cmbInvoiceDate.SelectedIndex = 0;
            Display();
            HideColumn();
        }
        private void FrmCustomerLogs_FormClosing(object sender, FormClosingEventArgs e)
        {
            cmbInvoiceDate.SelectedIndex = 0;
            ClsCommon.ObjCustomerLogs.Hide();
            ClsCommon.ObjCustomerLogs.Parent = null;
            e.Cancel = true;
        }

        private void dgvAllCustomerList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                DialogResult result = MessageBox.Show("Are you sure to delete this record?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int ID = Convert.ToInt32(dgvAllCustomerList.CurrentRow.Cells["No"].Value.ToString());
                    objBOLCustomerUpdateLog.ID = ID;
                    objBALCustomerUpdateLog.Delete(objBOLCustomerUpdateLog);
                    MessageBox.Show("Record delete successfully");
                }
            }
            Display();
        }
    }
}