using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace POS
{
    public partial class FrmCrystalReportViewer : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public DataTable dtExport = new DataTable();
        
        BALHistoryMaster BALHistory = new BALHistoryMaster();
        BOLHistoryMaster BOLHistory = new BOLHistoryMaster();

        public FrmCrystalReportViewer()
        {
            InitializeComponent();
        }

        private void FrmCrystalReportViewer_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                crystalReportViewer.PrintReport();
                ClsCommon.ObjInvoiceMaster.InvoicePrintHistory(ClsCommon.INVID);
                ClsCommon.ObjInvoiceMaster.PrintSave(ClsCommon.INVID);               
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCrystalreportViewer,Function :btnPrint_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtExport != null)
                {
                    if (dtExport.Rows.Count > 0)
                    {
                        if (dtExport.Columns.Contains("ID") == true)
                            dtExport.Columns.Remove("ID");
                        if (dtExport.Columns.Contains("FullName") == true)
                            dtExport.Columns["FullName"].ColumnName = "CustomerName";
                        if (dtExport.Columns.Contains("InvoiceNumber") == true)
                            dtExport.Columns["InvoiceNumber"].ColumnName = "Last Invoice Number";
                        if (dtExport.Columns.Contains("InvoiceDate") == true)
                            dtExport.Columns["InvoiceDate"].ColumnName = "Last Invoice Date";

                        dtExport.AcceptChanges();

                        dtExport.Columns["CustomerName"].SetOrdinal(0);
                        dtExport.Columns["SalesRep"].SetOrdinal(1);
                        dtExport.Columns["Last Invoice Number"].SetOrdinal(2);
                        dtExport.Columns["Last Invoice Date"].SetOrdinal(3);
                        dtExport.Columns["BalanceTotal"].SetOrdinal(4);


                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                        sfd.FilterIndex = 1;
                        sfd.RestoreDirectory = true;
                        sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            string NewFileName = sfd.FileName;


                            int n = dtExport.Columns.Count;
                            string[] strArr = new string[n];
                            object objValue = System.Reflection.Missing.Value;
                            Excel.Application sXLApp = new Excel.Application();
                            Excel.Workbooks sXLBooks = (Excel.Workbooks)sXLApp.Workbooks;
                            Excel._Workbook sXLBook = (Excel._Workbook)(sXLBooks.Add(objValue));
                            Excel.Sheets sXLSheets = (Excel.Sheets)sXLBook.Worksheets;
                            Excel._Worksheet sXLWorksheet = (Excel._Worksheet)(sXLSheets.get_Item(1));

                            for (int x = 0; x < n; x++)
                            {
                                strArr[x] = dtExport.Columns[x].ColumnName.ToString().Trim();
                            }
                            object objHeaders = (object)strArr;
                            Excel.Range sXLRange = sXLWorksheet.get_Range("A1", "IV1");
                            sXLRange.set_Value(objValue, objHeaders);
                            Excel.Font sXLFont = sXLRange.Font;

                            // To Assign Empty Column Header is null
                            for (int y = n + 1; y <= sXLRange.Count; y++)
                            {
                                sXLRange[1, y] = null;
                            }

                            sXLFont.Bold = true;

                            object[,] objData = new object[dtExport.Rows.Count, dtExport.Columns.Count];

                            for (int nRow = 0; nRow < dtExport.Rows.Count; nRow++)
                            {
                                for (int nCol = 0; nCol < dtExport.Columns.Count; nCol++)
                                {
                                    objData[nRow, nCol] = dtExport.Rows[nRow][nCol].ToString().Trim();
                                }
                            }
                            sXLRange = sXLWorksheet.get_Range("A2", objValue);
                            sXLRange = sXLRange.get_Resize(dtExport.Rows.Count, dtExport.Columns.Count);
                            sXLRange.set_Value(objValue, objData);

                            Excel.Range BorderRAnge1;
                            BorderRAnge1 = sXLWorksheet.get_Range("A1", "E1");
                            BorderRAnge1.Font.Bold = true;

                            BorderRAnge1.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                            
                            sXLApp.Columns.EntireColumn.AutoFit();
                            sXLApp.Columns.EntireRow.AutoFit();

                            sXLBook.SaveAs(NewFileName, objValue, objValue, objValue, objValue, objValue,
                                                Excel.XlSaveAsAccessMode.xlNoChange, objValue, objValue, objValue, objValue, objValue);
                            sXLBook.Close(false, objValue, objValue);
                            sXLApp.Quit();
                            MessageBox.Show("Export Successfully");

                            var app = new Microsoft.Office.Interop.Excel.Application();
                            app.Visible = true;
                            app.Workbooks.Open(sfd.FileName, ReadOnly: false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCrystalReportViewer,Function :btnExport_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        
    }
}
