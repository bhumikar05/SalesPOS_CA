using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmInvoicePrintHistory : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public Int32 InvoiceId = 0;

        public FrmInvoicePrintHistory()
        {
            InitializeComponent();
        }

        private void FrmInvoicePrintHistory_Load(object sender, EventArgs e)
        {
            try
            {
                InvoicePrintHistory();
                dgvInvoicePrint.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvInvoicePrint.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                dgvInvoicePrint.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8F, FontStyle.Regular);
                dgvInvoicePrint.EnableHeadersVisualStyles = false;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoicePrintHistory,Function :FrmInvoicePrintHistory_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

        public void InvoicePrintHistory()
        {
            try
            {
                DataTable dtHistory = new BALInvoiceMaster().SelectByInvoicePrintHistory(new BOLInvoiceMaster() { ID = InvoiceId });
                if (dtHistory.Rows.Count > 0)
                {
                    int j = 0;
                    dgvInvoicePrint.Rows.Clear();
                    for (int i = 0; i < dtHistory.Rows.Count; i++)
                    {
                        dgvInvoicePrint.Rows.Add();
                        dgvInvoicePrint.Rows[j].Cells[0].Value = dtHistory.Rows[i]["RefNumber"].ToString();
                        dgvInvoicePrint.Rows[j].Cells[1].Value = dtHistory.Rows[i]["SalesRepName"].ToString();
                        dgvInvoicePrint.Rows[j].Cells[2].Value = dtHistory.Rows[i]["InvoiceCount"].ToString();
                        j++;
                    }
                }
                else
                {
                    dgvInvoicePrint.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoicePrintHistory,Function :InvoicePrintHistory. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void dgvInvoicePrint_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}