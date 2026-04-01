using ClosedXML.Excel;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.QBClass;
using SalesPOS.QBClass;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace POS
{
    public partial class FrmRetriveData : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALInvoiceMaster BALInvoiceMaster = new BALInvoiceMaster();
        public FrmRetriveData()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dtInvoice = new DataTable();
            if (chkDateRange.Checked == true)
            {
                dtInvoice = new BALInvoiceMaster().ExportData(new BOLInvoiceMaster() { StartDate = dtpFromDate.Value.ToString("yyyy-MM-dd"), EndDate = dtpToDate.Value.ToString("yyyy-MM-dd") });
            }
            else
            {
                dtInvoice = new BALInvoiceMaster().ExportData(new BOLInvoiceMaster() { StartDate = "", EndDate = "" });
            }
            if (dtInvoice.Rows.Count > 0)
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
                    wb.Worksheets.Add(dtInvoice, "Sheet1");
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
    }
}