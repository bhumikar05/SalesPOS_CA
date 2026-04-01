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
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;

namespace POS
{
    public partial class FrmNoteReport : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtDetail = new DataTable();
        Decimal Total = 0; decimal Qty = 0;

        public FrmNoteReport()
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
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ClsCommon.FunctionVisibility("Export", "ItemSummary"))
                //{
                if (CheckValidation())
                {
                    dtDetail = new DataTable();
                    dtDetail = new BALInvoiceMaster().SelectNotes(new BOLInvoiceMaster() { StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
                    if (dtDetail.Rows.Count > 0)
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
                                wb.Worksheets.Add(dtDetail, "Sheet1");
                                wb.SaveAs(sfd.FileName);
                            }
                            MessageBox.Show("Export Successfully");
                        }
                        var app = new Microsoft.Office.Interop.Excel.Application();
                        app.Visible = true;
                        app.Workbooks.Open(sfd.FileName, ReadOnly: false);
                    }
                    else
                    {
                        MessageBox.Show("No records found");
                    }
                }
                //}
                //else
                //    MessageBox.Show("You can not access");
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
    }
}