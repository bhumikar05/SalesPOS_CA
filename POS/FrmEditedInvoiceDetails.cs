using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace POS
{
    public partial class FrmEditedInvoiceDetails : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALEditedInvoice BALEditedInvoice = new BALEditedInvoice();
        BOLEditedInvoice BOLEditedInvoice = new BOLEditedInvoice();
        public FrmEditedInvoiceDetails()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            DataTable Ship = new BALEditedInvoice().SELECT(new BOLEditedInvoice() { Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()) });
            if (Ship.Rows.Count > 0)
            {
                int j = 0;
                dgvRequestList.Rows.Clear();
                for (int i = 0; i < Ship.Rows.Count; i++)
                {
                    dgvRequestList.Rows.Add();
                    dgvRequestList.Rows[j].Cells["ID"].Value = Ship.Rows[i]["ID"].ToString();

                    DataTable InvoiceDetails = new BALInvoiceMaster().SelectByID(new BOLInvoiceMaster() { ID = Convert.ToInt32(Ship.Rows[i]["InvoiceID"].ToString()) });
                    if (InvoiceDetails.Rows.Count > 0)
                    {
                        dgvRequestList.Rows[j].Cells["CustomerName"].Value = InvoiceDetails.Rows[0]["CustomerFullName"].ToString();
                        dgvRequestList.Rows[j].Cells["InvoiceNo"].Value = InvoiceDetails.Rows[0]["RefNumber"].ToString();
                    }
                    dgvRequestList.Rows[j].Cells["Date"].Value = Convert.ToDateTime(Ship.Rows[i]["Date"].ToString()).ToShortDateString();
                    dgvRequestList.Rows[j].Cells["SalesRep"].Value = Ship.Rows[i]["Name"].ToString();
                    dgvRequestList.Rows[j].Cells["OldTotal"].Value = Ship.Rows[i]["OldTotal"].ToString();
                    dgvRequestList.Rows[j].Cells["NewTotal"].Value = Ship.Rows[i]["NewTotal"].ToString();
                    j++;
                }
            }
            else
                dgvRequestList.Rows.Clear();
            
            Cursor.Current = Cursors.Default;

        }

        private void FrmEditedInvoiceDetails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvRequestList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==7)
            {
                BOLEditedInvoice.ID = Convert.ToInt32(dgvRequestList.CurrentRow.Cells["ID"].Value);
                BALEditedInvoice.Update(BOLEditedInvoice);
                LoadData();
            }
        }

        private void FrmEditedInvoiceDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Close();
            ClsCommon.Flag = 0;
            ClsCommon.objEditedInvoiceDetails.Hide();
            ClsCommon.objEditedInvoiceDetails.Parent = null;
            e.Cancel = true;
        }
    }
}