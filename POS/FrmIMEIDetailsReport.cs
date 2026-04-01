using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.Report;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;

namespace POS
{
    public partial class FrmIMEIDetailsReport : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtDetail = new DataTable();
        DataTable dtAllInvoice=new DataTable();
        public FrmIMEIDetailsReport()
        {
            InitializeComponent();
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(0, 0);
        }
        private void FrmInvoiceAuditReport_Load(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Text = "";
                dtpFromDate.Format = DateTimePickerFormat.Custom;
                dtpFromDate.CustomFormat = "MM/dd/yyyy";

                dtpToDate.Format = DateTimePickerFormat.Custom;
                dtpToDate.CustomFormat = "MM/dd/yyyy";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceAuditReport,Function :FrmInvoiceAuditReport_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private Boolean CheckValidation()
        {
            Boolean ISValid = false;
            try
            {
                if (Convert.ToDateTime(dtpToDate.Value).Date < Convert.ToDateTime(dtpFromDate.Value).Date)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select Correct Date");
                    dtpToDate.Focus();
                    goto Final;
                }
                else
                    ISValid = true;

                Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceAuditReport,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
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
                if (CheckValidation())
                {
                    DataTable combine = new DataTable();
                    DataTable DATA = new DataTable();
                    DATA.Columns.Add("CustomerName");
                    DATA.Columns.Add("RefNumber");
                    DATA.Columns.Add("DATE");
                    DATA.Columns.Add("ItemName");
                    DATA.Columns.Add("Description");
                    DATA.Columns.Add("CARRIERS");
                    DATA.Columns.Add("GRADING");
                    DATA.Columns.Add("IMEINumber");

                    dtDetail = new DataTable();
                    dtDetail = new BALInvoiceDetails().SelectIEMINumber(new BOLInvoiceMaster() { StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });

                    foreach (DataRow dr in dtDetail.Rows)
                    {
                        string[] str = dr["IMEINumber"].ToString().Split(',');
                        for (int S = 0; S < str.Length; S++)
                        {
                            if (str[S].ToString() != "")
                            {
                                DataRow dr2 = DATA.NewRow();
                                dr2["CustomerName"] = dr["CustomerName"].ToString();
                                dr2["RefNumber"] = dr["RefNumber"].ToString();
                                dr2["ItemName"] = dr["ItemName"].ToString();
                                dr2["Description"] = dr["Description"].ToString();
                                dr2["CARRIERS"] = dr["CARRIERS"].ToString();
                                dr2["GRADING"] = dr["GRADING"].ToString();
                                dr2["DATE"] =Convert.ToDateTime(dr["DATE"].ToString()).ToShortDateString();
                                dr2["IMEINumber"] = str[S];
                                DATA.Rows.Add(dr2);
                            }
                        }
                    }

                    combine.Merge(DATA);

                    DATA.Rows.Clear();
                    dtDetail = new DataTable();
                    dtDetail = new BALCreditMemoDetails().SelectIEMINumber(new BOLCreditMemo() { StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                    foreach (DataRow dr in dtDetail.Rows)
                    {
                        string[] str = dr["IMEINumber"].ToString().Split(',');
                        for (int S = 0; S < str.Length; S++)
                        {
                            if (str[S].ToString() != "")
                            {
                                DataRow dr2 = DATA.NewRow();
                                dr2["CustomerName"] = dr["CustomerName"].ToString();
                                dr2["RefNumber"] = dr["RefNumber"].ToString();
                                dr2["ItemName"] = dr["ItemName"].ToString();
                                dr2["Description"] = dr["Description"].ToString();
                                dr2["CARRIERS"] = dr["CARRIERS"].ToString();
                                dr2["GRADING"] = dr["GRADING"].ToString();
                                dr2["DATE"] = Convert.ToDateTime(dr["DATE"].ToString()).ToShortDateString();
                                dr2["IMEINumber"] = str[S];
                                DATA.Rows.Add(dr2);
                            }
                        }
                    }
                    combine.Merge(DATA);

                    DataView view = combine.DefaultView;
                    view.Sort = "DATE ASC";
                    combine = view.ToTable();


                    if (combine.Rows.Count > 0)
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
                            wb.Worksheets.Add(combine, "Sheet1");
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
                        MessageBox.Show("No records found");
                    }
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceAuditReport,Function :btnPrint_Click. Message:" + ex.Message);

            }
        }
        private void btnExport1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable Fullcombine = new DataTable();
                DataTable combine = new DataTable();
                if (txtSearch.Text!="")
                {
                    DataTable DATA = new DataTable();
                    DATA.Columns.Add("CustomerName");
                    DATA.Columns.Add("RefNumber");
                    DATA.Columns.Add("DATE");
                    DATA.Columns.Add("ItemName");
                    DATA.Columns.Add("Description");
                    DATA.Columns.Add("CARRIERS");
                    DATA.Columns.Add("GRADING");
                    DATA.Columns.Add("IMEINumber");

                    string[] strSearch = txtSearch.Text.Split('\n');

                    for (int i = 0; strSearch != null && i < strSearch.Length; i++)
                    {
                        if (strSearch[i].ToString() != "")
                        {
                            DATA.Rows.Clear();
                            combine = new DataTable();
                            dtDetail = new DataTable();
                            dtDetail = new BALInvoiceDetails().SearchIEMINumber(new BOLInvoiceDetails() { IMEINumber = strSearch[i].Replace("\r", "") });
                            foreach (DataRow dr in dtDetail.Rows)
                            {
                                string[] str = dr["IMEINumber"].ToString().Split(',');
                                for (int S = 0; S < str.Length; S++)
                                {
                                    if (str[S].ToString() != "")
                                    {
                                        if (str[S].ToString().Contains(strSearch[i].Replace("\r", "")) == true)
                                        {
                                            DataRow dr2 = DATA.NewRow();
                                            dr2["CustomerName"] = dr["CustomerName"].ToString();
                                            dr2["RefNumber"] = dr["RefNumber"].ToString();
                                            dr2["ItemName"] = dr["ItemName"].ToString();
                                            dr2["Description"] = dr["Description"].ToString();
                                            dr2["CARRIERS"] = dr["CARRIERS"].ToString();
                                            dr2["GRADING"] = dr["GRADING"].ToString();
                                            dr2["DATE"] = Convert.ToDateTime(dr["DATE"].ToString()).ToShortDateString();
                                            dr2["IMEINumber"] = str[S];
                                            DATA.Rows.Add(dr2);
                                        }
                                    }
                                }
                            }
                            combine.Merge(DATA);
                            DATA.Rows.Clear();
                            dtDetail = new DataTable();
                            dtDetail = new BALCreditMemoDetails().SearchIEMINumber(new BOLCreditMemoDetails() { IMEINumber = strSearch[i].Replace("\r", "") });
                            foreach (DataRow dr in dtDetail.Rows)
                            {
                                string[] str = dr["IMEINumber"].ToString().Split(',');
                                for (int S = 0; S < str.Length; S++)
                                {
                                    if (str[S].ToString() != "")
                                    {
                                        if (str[S].ToString().Contains(strSearch[i].Replace("\r", "")) == true)
                                        {
                                            DataRow dr2 = DATA.NewRow();
                                            dr2["CustomerName"] = dr["CustomerName"].ToString();
                                            dr2["RefNumber"] = dr["RefNumber"].ToString();
                                            dr2["ItemName"] = dr["ItemName"].ToString();
                                            dr2["Description"] = dr["Description"].ToString();
                                            dr2["CARRIERS"] = dr["CARRIERS"].ToString();
                                            dr2["GRADING"] = dr["GRADING"].ToString();
                                            dr2["DATE"] = Convert.ToDateTime(dr["DATE"].ToString()).ToShortDateString();
                                            dr2["IMEINumber"] = str[S];
                                            DATA.Rows.Add(dr2);
                                        }
                                    }
                                }
                            }
                            combine.Merge(DATA);
                            Fullcombine.Merge(combine);
                        }

                    }
                    DataView view = Fullcombine.DefaultView;
                    view.Sort = "DATE ASC";
                    Fullcombine = view.ToTable();
                    if (Fullcombine.Rows.Count > 0)
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
                            wb.Worksheets.Add(Fullcombine, "Sheet1");
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
                        MessageBox.Show("No records found");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter IMEI Number");
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceAuditReport,Function :btnPrint_Click. Message:" + ex.Message);

            }
        }
        private void btnPrint1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable Fullcombine = new DataTable();
                DataTable combine = new DataTable();
                if (txtSearch.Text != "")
                {
                    DataTable DATA = new DataTable();
                    DATA.Columns.Add("CustomerName");
                    DATA.Columns.Add("RefNumber");
                    DATA.Columns.Add("DATE");
                    DATA.Columns.Add("ItemName");
                    DATA.Columns.Add("Description");
                    DATA.Columns.Add("CARRIERS");
                    DATA.Columns.Add("GRADING");
                    DATA.Columns.Add("IMEINumber");

                    string[] strSearch = txtSearch.Text.Split('\n');

                    for (int i = 0; strSearch != null && i < strSearch.Length; i++)
                    {
                        if (strSearch[i].ToString() != "")
                        {
                            DATA.Rows.Clear();
                            combine = new DataTable();
                            dtDetail = new DataTable();
                            dtDetail = new BALInvoiceDetails().SearchIEMINumber(new BOLInvoiceDetails() { IMEINumber = strSearch[i].Replace("\r", "") });
                            foreach (DataRow dr in dtDetail.Rows)
                            {
                                string[] str = dr["IMEINumber"].ToString().Split(',');
                                for (int S = 0; S < str.Length; S++)
                                {
                                    if (str[S].ToString() != "")
                                    {
                                        if (str[S].ToString().Contains(strSearch[i].Replace("\r", "")) == true)
                                        {
                                            DataRow dr2 = DATA.NewRow();
                                            dr2["CustomerName"] = dr["CustomerName"].ToString();
                                            dr2["RefNumber"] = dr["RefNumber"].ToString();
                                            dr2["ItemName"] = dr["ItemName"].ToString();
                                            dr2["Description"] = dr["Description"].ToString();
                                            dr2["CARRIERS"] = dr["CARRIERS"].ToString();
                                            dr2["GRADING"] = dr["GRADING"].ToString();
                                            dr2["DATE"] = Convert.ToDateTime(dr["DATE"].ToString()).ToShortDateString();
                                            dr2["IMEINumber"] = str[S];
                                            DATA.Rows.Add(dr2);
                                        }
                                    }
                                }
                            }
                            combine.Merge(DATA);
                            DATA.Rows.Clear();
                            dtDetail = new DataTable();
                            dtDetail = new BALCreditMemoDetails().SearchIEMINumber(new BOLCreditMemoDetails() { IMEINumber = strSearch[i].Replace("\r", "") });
                            foreach (DataRow dr in dtDetail.Rows)
                            {
                                string[] str = dr["IMEINumber"].ToString().Split(',');
                                for (int S = 0; S < str.Length; S++)
                                {
                                    if (str[S].ToString() != "")
                                    {
                                        if (str[S].ToString().Contains(strSearch[i].Replace("\r", "")) == true)
                                        {
                                            DataRow dr2 = DATA.NewRow();
                                            dr2["CustomerName"] = dr["CustomerName"].ToString();
                                            dr2["RefNumber"] = dr["RefNumber"].ToString();
                                            dr2["ItemName"] = dr["ItemName"].ToString();
                                            dr2["Description"] = dr["Description"].ToString();
                                            dr2["CARRIERS"] = dr["CARRIERS"].ToString();
                                            dr2["GRADING"] = dr["GRADING"].ToString();
                                            dr2["DATE"] = Convert.ToDateTime(dr["DATE"].ToString()).ToShortDateString();
                                            dr2["IMEINumber"] = str[S];
                                            DATA.Rows.Add(dr2);
                                        }
                                    }
                                }
                            }
                            combine.Merge(DATA);
                            Fullcombine.Merge(combine);
                        }

                    }
                    DataView view = Fullcombine.DefaultView;
                    view.Sort = "DATE ASC";
                    Fullcombine = view.ToTable();
                    if (Fullcombine.Rows.Count > 0)
                    {

                        rptIMEIReport rptIMEIReport = new rptIMEIReport();
                        rptIMEIReport.Database.Tables[0].SetDataSource(Fullcombine);
                        FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                        crViewer.Text = "IMEI Report";
                        crViewer.crystalReportViewer.ReportSource = rptIMEIReport;
                        crViewer.Show();

                    }
                    else
                    {
                        MessageBox.Show("No records found");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter IMEI Number");
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceAuditReport,Function :btnPrint_Click. Message:" + ex.Message);
            }
         
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidation())
                {
                    DataTable combine = new DataTable();

                    DataTable DATA = new DataTable();
                    DATA.Columns.Add("CustomerName");
                    DATA.Columns.Add("RefNumber");
                    DATA.Columns.Add("DATE");
                    DATA.Columns.Add("ItemName");
                    DATA.Columns.Add("Description");
                    DATA.Columns.Add("CARRIERS");
                    DATA.Columns.Add("GRADING");
                    DATA.Columns.Add("IMEINumber");

                    dtDetail = new DataTable();
                    dtDetail = new BALInvoiceDetails().SelectIEMINumber(new BOLInvoiceMaster() { StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });

                    foreach (DataRow dr in dtDetail.Rows)
                    {
                        string[] str = dr["IMEINumber"].ToString().Split(',');
                        for (int S = 0; S < str.Length; S++)
                        {
                            if (str[S].ToString() != "")
                            {
                                DataRow dr2 = DATA.NewRow();
                                dr2["CustomerName"] = dr["CustomerName"].ToString();
                                dr2["RefNumber"] = dr["RefNumber"].ToString();
                                dr2["ItemName"] = dr["ItemName"].ToString();
                                dr2["Description"] = dr["Description"].ToString();
                                dr2["CARRIERS"] = dr["CARRIERS"].ToString();
                                dr2["GRADING"] = dr["GRADING"].ToString();
                                dr2["DATE"] = Convert.ToDateTime(dr["DATE"].ToString()).ToShortDateString();
                                dr2["IMEINumber"] = str[S];
                                DATA.Rows.Add(dr2);
                            }
                        }
                    }

                    combine.Merge(DATA);

                    DATA.Rows.Clear();
                    dtDetail = new DataTable();
                    dtDetail = new BALCreditMemoDetails().SelectIEMINumber(new BOLCreditMemo() { StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                    foreach (DataRow dr in dtDetail.Rows)
                    {
                        string[] str = dr["IMEINumber"].ToString().Split(',');
                        for (int S = 0; S < str.Length; S++)
                        {
                            if (str[S].ToString() != "")
                            {
                                DataRow dr2 = DATA.NewRow();
                                dr2["CustomerName"] = dr["CustomerName"].ToString();
                                dr2["RefNumber"] = dr["RefNumber"].ToString();
                                dr2["ItemName"] = dr["ItemName"].ToString();
                                dr2["Description"] = dr["Description"].ToString();
                                dr2["CARRIERS"] = dr["CARRIERS"].ToString();
                                dr2["GRADING"] = dr["GRADING"].ToString();
                                dr2["DATE"] = Convert.ToDateTime(dr["DATE"].ToString()).ToShortDateString();
                                dr2["IMEINumber"] = str[S];
                                DATA.Rows.Add(dr2);
                            }
                        }
                    }
                    combine.Merge(DATA);

                    DataView view = combine.DefaultView;
                    view.Sort = "DATE ASC";
                    combine = view.ToTable();


                    if (combine.Rows.Count > 0)
                    {
                        //rptIMEIDetails cryRptInvoiceAuditReport = new rptIMEIDetails();
                        //cryRptInvoiceAuditReport.Database.Tables[0].SetDataSource(combine);
                        //FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                        //crViewer.crystalReportViewer.ReportSource = cryRptInvoiceAuditReport;
                        //crViewer.Show();



                        rptIMEIReport rptIMEIReport = new rptIMEIReport();
                        rptIMEIReport.Database.Tables[0].SetDataSource(combine);
                        FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                        crViewer.Text = "IMEI Report";
                        crViewer.crystalReportViewer.ReportSource = rptIMEIReport;
                        crViewer.Show();

                    }
                    else
                    {
                        MessageBox.Show("No records found");
                    }
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:btnPrint1_Click,Function :btnPrint_Click. Message:" + ex.Message);

            }
        }
    }
}