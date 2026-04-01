using DocumentFormat.OpenXml.Drawing.Charts;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using DataTable = System.Data.DataTable;

namespace POS
{
    public partial class FrmShipRequestPermission : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BOLShipRequest BOLShipRequest =new BOLShipRequest();
        BALShipRequest BALShipRequest=new BALShipRequest();
        public FrmShipRequestPermission()
        {
            InitializeComponent();
        }

        private void FrmShipRequestPermission_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            DataTable Ship = new BALShipRequest().SELECTBYDate(new BOLShipRequest() { Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()) });
            if (Ship.Rows.Count > 0)
            {
                int j = 0;
                dgvRequestList.Rows.Clear();
                for (int i = 0; i < Ship.Rows.Count; i++)
                {
                    dgvRequestList.Rows.Add();
                    dgvRequestList.Rows[j].Cells["ID"].Value = Ship.Rows[i]["ID"].ToString();

                    DataTable InvoiceDetails = new BALInvoiceMaster().SelectByID(new BOLInvoiceMaster() {ID= Convert.ToInt32(Ship.Rows[i]["InvoiceID"].ToString()) });
                    if(InvoiceDetails.Rows.Count > 0)
                    {
                        dgvRequestList.Rows[j].Cells["CustomerName"].Value = InvoiceDetails.Rows[0]["CustomerFullName"].ToString();
                        dgvRequestList.Rows[j].Cells["InvoiceNo"].Value = InvoiceDetails.Rows[0]["RefNumber"].ToString();
                    }
                    dgvRequestList.Rows[j].Cells["Date"].Value = Convert.ToDateTime(Ship.Rows[i]["Date"].ToString()).ToShortDateString();
                    dgvRequestList.Rows[j].Cells["SalesRep"].Value = Ship.Rows[i]["Name"].ToString();
                    dgvRequestList.Rows[j].Cells["Reason"].Value = Ship.Rows[i]["Reason"].ToString();
                    j++;
                }
            }
            else
                dgvRequestList.Rows.Clear();
            lblTotal.Text = Ship.Rows.Count.ToString(); 
            Cursor.Current = Cursors.Default;

        }

        private void dgvRequestList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    BOLShipRequest.ID = Convert.ToInt32(dgvRequestList.CurrentRow.Cells["ID"].Value);
                    BOLShipRequest.Allow = 1;
                    BALShipRequest.UpdateOnlyAllow(BOLShipRequest);
                    LoadData();
                }
                else if (e.ColumnIndex == 7)
                {
                    BOLShipRequest.ID = Convert.ToInt32(dgvRequestList.CurrentRow.Cells["ID"].Value);
                    BALShipRequest.Delete(BOLShipRequest);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmShipRequestPermission,Function :dgvRequestList_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

        private void btmClose_Click(object sender, EventArgs e)
        {
            ClsCommon.objShipRequestPermission.Hide();
            //this.Close();
        }

        private void FrmShipRequestPermission_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClsCommon.Flag = 0;
            ClsCommon.objShipRequestPermission.Hide();
            ClsCommon.objShipRequestPermission.Parent = null;
            e.Cancel = true;
        }
    }
}