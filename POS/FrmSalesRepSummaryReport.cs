using DocumentFormat.OpenXml.Spreadsheet;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.Report;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace POS
{
    public partial class FrmSalesRepSummaryReport : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtDetail = new DataTable();
        decimal Total = 0;

        BALSalesRepMaster objBal = new BALSalesRepMaster();
        BOLSalesRepMaster objBol = new BOLSalesRepMaster();

        public FrmSalesRepSummaryReport()
        {
            InitializeComponent();
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(0, 0);
        }

        private void FrmSalesRepSummaryReport_Load(object sender, EventArgs e)
        {
            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.CustomFormat = "MM/dd/yyyy";

            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.CustomFormat = "MM/dd/yyyy";

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
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
                ClsCommon.WriteErrorLogs("Form:FrmSalesRepSummaryReport,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("Print", "SalesRepSummary"))
                {
                    if (CheckValidation())
                    {
                        dtDetail = new DataTable();
                        dtDetail = new BALSalesRepMaster().SalesRepSummaryList(new BOLSalesRepMaster() { StartDate = dtpFromDate.Value, EndDate = dtpToDate.Value });
                        if (dtDetail.Rows.Count > 0)
                        {
                            dtDetail.Columns.Add("Percentage");
                            foreach(DataRow dr in dtDetail.Rows)
                            {
                                DataTable dt = objBal.SelectBySalesRepID(new BOLSalesRepMaster() { ID = Convert.ToInt32(dr["SalesRepID"].ToString()), StartDate = dtpFromDate.Value, EndDate = dtpToDate.Value });
                                if(dt.Rows.Count > 0)
                                {
                                    if(dt.Rows[0]["Cost"].ToString() != "")
                                    {
                                        if(dt.Rows[0]["Cost"].ToString() != "0.00")
                                        {
                                            dr["Percentage"] = decimal.Round((Convert.ToDecimal(dr["Total"].ToString()) / Convert.ToDecimal(dt.Rows[0]["Cost"].ToString())) * 100, 2);
                                        }
                                        else
                                        {
                                            dr["Percentage"] = "0.00";
                                        }
                                        
                                    }
                                    
                                }
                            } 
                            rptSalesRepSummaryReport cryRptSalesRepSummaryReport = new rptSalesRepSummaryReport();
                            cryRptSalesRepSummaryReport.Database.Tables[0].SetDataSource(dtDetail);

                            FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                            crViewer.Text = "SalesRep Summary Report";
                            crViewer.crystalReportViewer.ReportSource = cryRptSalesRepSummaryReport;
                            crViewer.Show();
                        }
                        else
                        {
                            MessageBox.Show("No records found");
                        }
                    }
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmSalesRepSummaryReport,Function :btnPrint_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("Export", "SalesRepSummary"))
                {
                    if (CheckValidation())
                    {
                        DataTable dtNew = new DataTable();
                        dtNew.Columns.Add("Sr.No", typeof(string));
                        dtNew.Columns.Add("SalesRepName", typeof(string));
                        dtNew.Columns.Add("Total", typeof(string));
                        dtNew.Columns.Add("Percentage", typeof(string));

                        dtDetail = new DataTable();
                        dtDetail = new BALSalesRepMaster().SalesRepSummaryList(new BOLSalesRepMaster() { StartDate = dtpFromDate.Value, EndDate = dtpToDate.Value });
                        if (dtDetail.Rows.Count > 0)
                        {
                            Total = 0; int i = 1;
                            dtDetail.Columns.Add("Percentage");
                            foreach (DataRow dr in dtDetail.Rows)
                            {
                                DataTable dt = objBal.SelectBySalesRepID(new BOLSalesRepMaster() { ID = Convert.ToInt32(dr["SalesRepID"].ToString()), StartDate = dtpFromDate.Value, EndDate = dtpToDate.Value });
                                if (dt.Rows.Count > 0)
                                {
                                    if (dt.Rows[0]["Cost"].ToString() != "")
                                    {
                                        if (dt.Rows[0]["Cost"].ToString() != "0.00")
                                        {
                                            dr["Percentage"] = decimal.Round((Convert.ToDecimal(dr["Total"].ToString()) / Convert.ToDecimal(dt.Rows[0]["Cost"].ToString())) * 100, 2);
                                        }
                                        else
                                        {
                                            dr["Percentage"] = "0.00";
                                        }
                                    }
                                }
                                DataRow dr1 = dtNew.NewRow();
                                dr1["Sr.No"] = i;
                                dr1["SalesRepName"] = dr["SalesRepName"].ToString();
                                dr1["Total"] = dr["Total"].ToString();
                                if(dr["Percentage"].ToString() != "")
                                {                                 
                                     dr1["Percentage"] = dr["Percentage"].ToString();                                   
                                }                            
                                Total += Convert.ToDecimal(dr["Total"].ToString());
                                dtNew.Rows.Add(dr1);
                                i++;
                            }
                            DataRow dr2 = dtNew.NewRow();
                            dr2["Sr.No"] = "";
                            dr2["SalesRepName"] = "TOTAL";
                            dr2["Total"] = Total;
                            dtNew.Rows.Add(dr2);

                            SaveFileDialog sfd = new SaveFileDialog();
                            sfd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                            sfd.FilterIndex = 1;
                            sfd.RestoreDirectory = true;
                            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                string NewFileName = sfd.FileName;
                                int n = dtNew.Columns.Count;
                                string[] strArr = new string[n];
                                object objValue = System.Reflection.Missing.Value;
                                Excel.Application sXLApp = new Excel.Application();
                                Excel.Workbooks sXLBooks = (Excel.Workbooks)sXLApp.Workbooks;
                                Excel._Workbook sXLBook = (Excel._Workbook)(sXLBooks.Add(objValue));
                                Excel.Sheets sXLSheets = (Excel.Sheets)sXLBook.Worksheets;
                                Excel._Worksheet sXLWorksheet = (Excel._Worksheet)(sXLSheets.get_Item(1));

                                int p = 0;
                                for (int x = 0; x < n; x++)
                                {
                                    if (p == 0)
                                        strArr[x] = "";
                                    else
                                        strArr[x] = dtNew.Columns[p].ColumnName.ToString().Trim();
                                    p++;
                                }
                                object objHeaders = (object)strArr;
                                Excel.Range sXLRange = sXLWorksheet.get_Range("A5", "IV5");
                                sXLRange.set_Value(objValue, objHeaders);
                                Excel.Font sXLFont = sXLRange.Font;

                                // To Assign Empty Column Header is null
                                for (int y = n + 1; y <= sXLRange.Count; y++)
                                {
                                    sXLRange[1, y] = null;
                                }
                                sXLFont.Bold = true;

                                object[,] objData = new object[dtNew.Rows.Count, dtNew.Columns.Count];

                                for (int nRow = 0; nRow < dtNew.Rows.Count; nRow++)
                                {
                                    for (int nCol = 0; nCol < dtNew.Columns.Count; nCol++)
                                    {
                                        objData[nRow, nCol] = dtNew.Rows[nRow][nCol].ToString().Trim();
                                    }
                                }

                                sXLRange = sXLWorksheet.get_Range("A6", objValue);
                                sXLRange = sXLRange.get_Resize(dtNew.Rows.Count, dtNew.Columns.Count);
                                sXLRange.set_Value(objValue, objData);

                                sXLWorksheet.Cells[1, 1] = "Sales by SalesRep InvoiceSummary";
                                sXLWorksheet.get_Range("A1", "C1").Font.Bold = true;
                                sXLWorksheet.get_Range("A1", "C1").HorizontalAlignment =
                                    Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                                sXLWorksheet.get_Range("A1", "C1").MergeCells =
                                 Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                                sXLWorksheet.get_Range("A1", "C1").Font.Size = 16;
                                //((Excel.Range)sXLWorksheet.Cells[1, 3]).EntireColumn.ColumnWidth = 200;
                                //sXLWorksheet.Columns.AutoFit();
                                //sXLWorksheet.Cells.Style.EntireColumn.AutoFit();
                                //sXLWorksheet.get_Range("A1", "C1").set.Width = 50;

                                sXLWorksheet.Cells[3, 3] = "All Transactions";
                                sXLWorksheet.get_Range("A3", "C3").Font.Bold = true;
                                sXLWorksheet.get_Range("A3", "C3").HorizontalAlignment =
                                    Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                                sXLWorksheet.get_Range("A3", "C3").MergeCells =
                                 Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                                //Excel.Range BorderRAnge1;
                                //BorderRAnge1 = sXLWorksheet.get_Range("B5", "C5");
                                //BorderRAnge1.Font.Bold = true;
                                //BorderRAnge1.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                                for (int nRow = 0; nRow < dtNew.Rows.Count; nRow++)
                                {
                                    if (nRow == dtNew.Rows.Count - 1)
                                    {
                                        Excel.Range BorderRAnge2;
                                        BorderRAnge2 = sXLWorksheet.get_Range("A" + Convert.ToInt32(dtNew.Rows.Count + 5), "C" + Convert.ToInt32(dtNew.Rows.Count + 5));
                                        BorderRAnge2.Font.Bold = true;
                                    }
                                }

                                //If you need Apply the color into Excel Cell based on Grid Cell     
                                for (int c = 1; c < dtNew.Columns.Count; c++)
                                {
                                    // To get the Excel Cell Name     
                                    string sCell = GetExcelCell(c + 1);

                                    for (int r = 0; r < dtNew.Rows.Count; r++)
                                    {
                                        sXLRange = sXLWorksheet.get_Range(sCell + (r + 2), sCell + (r + 2));
                                    }
                                }

                                //sXLApp.Columns.EntireColumn.AutoFit();
                                //sXLApp.Columns.EntireRow.AutoFit();
                                sXLWorksheet.Columns[2].ColumnWidth = 40;

                                sXLBook.SaveAs(NewFileName, objValue, objValue, objValue, objValue, objValue,
                                                    Excel.XlSaveAsAccessMode.xlNoChange, objValue, objValue, objValue, objValue, objValue);
                                sXLBook.Close(false, objValue, objValue);
                                sXLApp.Quit();
                                Cursor.Current = Cursors.Default;
                                //Email Send
                                //SendEmail(ConfigurationManager.AppSettings["Email"].ToString(), "Sales Rep Summary", "Sales by Rep Summary", NewFileName);
                                MessageBox.Show("Export Successfully");
                                var app = new Microsoft.Office.Interop.Excel.Application();
                                app.Visible = true;
                                app.Workbooks.Open(sfd.FileName, ReadOnly: false);


                            }
                        }
                        else
                        {
                            MessageBox.Show("No Record Found");
                        }
                    }
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmSalesRepSummaryReport,Function :btnExport_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private string GetExcelCell(int nID)
        {
            string sCell = string.Empty;
            if (nID < 27)
            {
                switch (nID)
                {
                    case 0:
                        sCell = "z";
                        break;
                    case 1:
                        sCell = "A";
                        break;
                    case 2:
                        sCell = "B";
                        break;
                    case 3:
                        sCell = "C";
                        break;
                    case 4:
                        sCell = "D";
                        break;
                    case 5:
                        sCell = "E";
                        break;
                    case 6:
                        sCell = "F";
                        break;
                    case 7:
                        sCell = "G";
                        break;
                    case 8:
                        sCell = "H";
                        break;

                    case 9:
                        sCell = "I";
                        break;
                    case 10:
                        sCell = "J";
                        break;
                    case 11:
                        sCell = "K";
                        break;
                    case 12:
                        sCell = "L";
                        break;
                    case 13:
                        sCell = "M";
                        break;
                    case 14:
                        sCell = "N";
                        break;
                    case 15:
                        sCell = "O";
                        break;
                    case 16:
                        sCell = "P";
                        break;
                    case 17:
                        sCell = "Q";
                        break;
                    case 18:
                        sCell = "R";
                        break;
                    case 19:
                        sCell = "S";
                        break;
                    case 20:
                        sCell = "T";
                        break;
                    case 21:
                        sCell = "U";
                        break;
                    case 22:
                        sCell = "V";
                        break;
                    default:
                        sCell = String.Empty;
                        break;
                }
                return sCell;
            }
            else
            {
                int nDiv = nID / 26;
                int nMod = nID % 26;
                if (nMod.Equals(0))
                {
                    nDiv = nDiv - 1;
                }
                sCell = GetExcelCell(nDiv);
                sCell = sCell + GetExcelCell(nMod);
                return sCell;
            }
        }

        private void SendEmail(string ToEmail, string Subject, string BodyText, string FileName)
        {
            try
            {
                string Email = ConfigurationManager.AppSettings["Email"].ToString();
                string Password = ConfigurationManager.AppSettings["Password"].ToString();
                string Port = ConfigurationManager.AppSettings["Port"].ToString();
                string Smtp = ConfigurationManager.AppSettings["Smtp"].ToString();
                string IsEnable = ConfigurationManager.AppSettings["IsEnable"].ToString();
                string BCC = ConfigurationManager.AppSettings["BCC"].ToString();

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(Smtp.ToString());
                mail.Sender = new MailAddress(Email);
                mail.From = new MailAddress(Email); //you have to provide your gmail address as from address
                mail.To.Add(ToEmail);
                mail.Subject = Subject;
                mail.Body = BodyText;
                mail.Attachments.Add(new Attachment(FileName));
                mail.IsBodyHtml = true;
                MailAddress bcc = new MailAddress(BCC);
                mail.Bcc.Add(bcc);
                SmtpServer.UseDefaultCredentials = true;
                SmtpServer.Port = Convert.ToInt32(Port.ToString());
                SmtpServer.Credentials = new System.Net.NetworkCredential(Email.ToString(), Password.ToString()); //you have to provide you gamil username and password
                SmtpServer.EnableSsl = Convert.ToBoolean(IsEnable.ToString());
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmSalesRepSummaryReport,Function :SendEmail. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}