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
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;

namespace POS
{
    public partial class FrmItemSummaryReport : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtDetail = new DataTable();
        Decimal Total = 0; decimal Qty = 0;

        public FrmItemSummaryReport()
        {
            InitializeComponent();
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(0, 0);
        }

        private void FrmItemSummaryReport_Load(object sender, EventArgs e)
        {
            try
            {
                dtpFromDate.Format = DateTimePickerFormat.Custom;
                dtpFromDate.CustomFormat = "MM/dd/yyyy";

                dtpToDate.Format = DateTimePickerFormat.Custom;
                dtpToDate.CustomFormat = "MM/dd/yyyy";
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemSummaryReport,Function :FrmItemSummaryReport_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
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
                ClsCommon.WriteErrorLogs("Form:FrmItemSummaryReport,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("Print", "ItemSummary"))
                {
                    if (CheckValidation())
                    {
                        string Date = "";
                        string ToDate = "";
                        string FinalDate = "";
                        dtDetail = new DataTable();
                        dtDetail = new BALItemMaster().ItemSummaryList(new BOLItemMaster() { StartDate = dtpFromDate.Value, EndDate = dtpToDate.Value });
                        if (dtDetail.Rows.Count > 0)
                        {
                            Date = dtpFromDate.Value.ToString("MMMM d, yyyy");
                            ToDate = dtpToDate.Value.ToString("MMMM d, yyyy");
                            if (Date == ToDate)
                            {
                                FinalDate = ToDate;
                            }
                            else if (Date.Split(' ').Last() == ToDate.Split(' ').Last() && Date.Split(' ').First() == ToDate.Split(' ').First())
                            {
                                FinalDate = Date.Replace(Date.Split(' ').Last(), "").Replace(",", "") + "-" + ToDate.Replace(ToDate.Split(' ').First().TrimEnd(), "");
                                //var secondWord = FinalDate.Split(' ').Skip(3).FirstOrDefault();

                            }
                            else if (Date.Split(' ').Last() == ToDate.Split(' ').Last())
                            {
                                FinalDate = Date.Replace(Date.Split(' ').Last(), "").Replace(",", "") + "- " + ToDate;
                            }
                            else
                            {
                                FinalDate = Date + " - " + ToDate;
                            }
                            rptItemSummaryReport cryRptItemSummaryReport = new rptItemSummaryReport();
                            cryRptItemSummaryReport.Database.Tables[0].SetDataSource(dtDetail);
                            cryRptItemSummaryReport.SetParameterValue("Date", FinalDate);

                            FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                            crViewer.Text = "Item Summary Report";
                            crViewer.crystalReportViewer.ReportSource = cryRptItemSummaryReport;
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
                ClsCommon.WriteErrorLogs("Form:FrmItemSummaryReport,Function :btnPrint_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("Export", "ItemSummary"))
                {
                    if (CheckValidation())
                    {
                        string Date = "";
                        string ToDate = "";
                        string FinalDate = "";
                        Date = dtpFromDate.Value.ToString("MMMM d, yyyy");
                        ToDate = dtpToDate.Value.ToString("MMMM d, yyyy");
                        if (Date == ToDate)
                        {
                            FinalDate = ToDate;
                        }
                        else if (Date.Split(' ').Last() == ToDate.Split(' ').Last() && Date.Split(' ').First() == ToDate.Split(' ').First())
                        {
                            FinalDate = Date.Replace(Date.Split(' ').Last(), "").Replace(",", "") + "-" + ToDate.Replace(ToDate.Split(' ').First().TrimEnd(),"");
                            //var secondWord = FinalDate.Split(' ').Skip(3).FirstOrDefault();

                        }
                        else if(Date.Split(' ').Last() == ToDate.Split(' ').Last())
                        {
                            FinalDate = Date.Replace(Date.Split(' ').Last(), "").Replace(",", "") + "- " + ToDate;
                            //var secondWord = FinalDate.Split(' ').Skip(3).FirstOrDefault();

                        }
                        else
                        {
                            FinalDate = Date + " - " + ToDate;

                        }


                        DataTable dtNew = new DataTable();
                        dtNew.Columns.Add("Name", typeof(string));
                        dtNew.Columns.Add("Qty", typeof(decimal));
                        dtNew.Columns.Add("Amount", typeof(decimal));
                        dtNew.Columns.Add("Average Amount", typeof(string));
                        dtNew.Columns.Add("Type", typeof(string));

                        dtDetail = new DataTable();
                        dtDetail = new BALItemMaster().ItemSummaryList(new BOLItemMaster() { StartDate = dtpFromDate.Value, EndDate = dtpToDate.Value });
                        if (dtDetail.Rows.Count > 0)
                        {
                            Total = 0; Qty = 0; int i = 1;
                            foreach (DataRow dr in dtDetail.Rows)
                            {
                                DataRow dr1 = dtNew.NewRow();
                                dr1["Name"] = dr["ItemName"].ToString();
                                dr1["Qty"] = dr["Qty"].ToString();
                                dr1["Amount"] = dr["Amt"].ToString();
                                dr1["Average Amount"] = dr["Average"].ToString();
                                dr1["Type"] = dr["ItemType"].ToString();
                                Total += Convert.ToDecimal(dr["Amt"].ToString());
                                Qty += Convert.ToDecimal(dr["Qty"].ToString());
                                dtNew.Rows.Add(dr1);
                                i++;
                            }
                            DataRow dr2 = dtNew.NewRow();
                            dr2["Name"] = "TOTAL";
                            dr2["Qty"] = Qty;
                            dr2["Amount"] = Total;
                            dr2["Average Amount"] = "";
                            dr2["Type"] = "";
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

                                //int p = 0;
                                for (int x = 0; x < n; x++)
                                {
                                    //if (p == 0)
                                    //    strArr[x] = "";
                                    //else
                                    strArr[x] = dtNew.Columns[x].ColumnName.ToString().Trim();
                                    //p++;
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

                                sXLWorksheet.Cells[1, 1] = "Sales by Item Summary";
                                sXLWorksheet.get_Range("A1", "E1").Font.Bold = true;
                                sXLWorksheet.get_Range("A1", "E1").HorizontalAlignment =
                                    Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                                sXLWorksheet.get_Range("A1", "E1").MergeCells =
                                 Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                                sXLWorksheet.get_Range("A1", "E1").Font.Size = 16;

                                sXLWorksheet.Cells[2, 2] =  "'" + FinalDate.ToString();
                                sXLWorksheet.get_Range("A2", "E2").Font.Bold = true;
                                sXLWorksheet.get_Range("A2", "E2").Font.Bold = true;
                                sXLWorksheet.get_Range("A2", "E2").HorizontalAlignment =
                                    Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                                sXLWorksheet.get_Range("A2", "E2").MergeCells =
                                 Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;


                                sXLWorksheet.Cells[3, 3] = "All Transactions";
                                sXLWorksheet.get_Range("A3", "E3").Font.Bold = true;
                                sXLWorksheet.get_Range("A3", "E3").HorizontalAlignment =
                                    Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                                sXLWorksheet.get_Range("A3", "E3").MergeCells =
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

                                sXLApp.Columns.EntireColumn.AutoFit();
                                sXLApp.Columns.EntireRow.AutoFit();

                                sXLBook.SaveAs(NewFileName, objValue, objValue, objValue, objValue, objValue,
                                                    Excel.XlSaveAsAccessMode.xlNoChange, objValue, objValue, objValue, objValue, objValue);
                                sXLBook.Close(false, objValue, objValue);

                                sXLApp.Quit();
                                Cursor.Current = Cursors.Default;
                                //Email Send
                                SendEmail(ConfigurationManager.AppSettings["Email"].ToString(), "Item Summary", "Sales by Item Summary", NewFileName);
                                MessageBox.Show("Export Successfully");
                                //FileInfo fi = new FileInfo("C:\\Desktop\\4.xlsx");
                                //if (fi.Exists)
                                //{
                                //    System.Diagnostics.Process.Start(@"C:\test\report.xlsx");
                                //}
                                //else
                                //{
                                //    //file doesn't exist
                                //}
                                var app = new Microsoft.Office.Interop.Excel.Application();
                                app.Visible = true;
                                app.Workbooks.Open(sfd.FileName, ReadOnly: false);
                            }
                            //var excelApp = new Excel.Application();
                            //excelApp.Workbooks.Open(sfd.FileName, ReadOnly: false);
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
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemSummaryReport,Function :btnExport_Click. Message:" + ex.Message);
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
                ClsCommon.WriteErrorLogs("Form:FrmItemSummaryReport,Function :SendEmail. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}