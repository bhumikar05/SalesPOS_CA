using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmUnShippedInvoiceList : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtInvoice = new DataTable();
        BALHistoryMaster BALHistory = new BALHistoryMaster();
        string ServiceID = "";
        DataTable dtShipInvoice = new DataTable();

        public FrmUnShippedInvoiceList()
        {
            InitializeComponent();
            lblFrom.Visible = false; lblto.Visible = false; dtTranFrom.Visible = false; dtTranTo.Visible = false;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            lblTotal.Text = "0";
            //LoadUnShippedInvoice();
            //LoadShippedInvoice();
            //DateWiseInvoiceLoad();
        }

        private void FrmUnShippedInvoiceReport_Load(object sender, EventArgs e)
        {
            try
            {
                cmbTransactionsFilterDate.SelectedIndex = 0;
                DateWiseInvoiceLoad();
                this.dgvUnShippiedInvoiceList.DefaultCellStyle.Font = new Font("", 10);
                dgvUnShippiedInvoiceList.RowTemplate.Height = 25;
                dgvUnShippiedInvoiceList.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvUnShippiedInvoiceList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                dgvUnShippiedInvoiceList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                dgvUnShippiedInvoiceList.EnableHeadersVisualStyles = false;

                //Shipped Button
                DataGridViewLinkColumn ShippedButton = new DataGridViewLinkColumn();
                ShippedButton.UseColumnTextForLinkValue = true;
                ShippedButton.HeaderText = "Shipped";
                ShippedButton.DataPropertyName = "Shipped";
                ShippedButton.Text = "Shipped";
                dgvUnShippiedInvoiceList.Columns.Add(ShippedButton);
                dgvUnShippiedInvoiceList.Columns[8].Width = 100;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUnShippedInvoiceList, Function :FrmUnShippedInvoiceReport_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void GetInvoiceByID(string ID)
        {
            try
            {
                DataTable dtInvoice = new BALInvoiceMaster().SelectByID(new BOLInvoiceMaster() { ID = Convert.ToInt32(ID) });
                if (dtInvoice.Rows.Count > 0)
                {
                    if (dtInvoice.Rows[0]["IsShipping"].ToString() == "1")
                    {
                        foreach (DataGridViewRow item in dgvUnShippiedInvoiceList.Rows)
                        {
                            if (item.Cells["ID"].Value.ToString() == dtInvoice.Rows[0]["ID"].ToString())
                            {
                                dgvUnShippiedInvoiceList.Rows.Remove(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPaymentMaster,Function :GetInvoice. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        //public void LoadUnShippedInvoice()
        //{
        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;
        //        txtInvoiceNo.Text = "";
        //        dtInvoice = new DataTable();
        //        dtInvoice = new BALInvoiceMaster().SelectUnShippedInvoice(new BOLInvoiceMaster() { });
        //        if (dtInvoice.Rows.Count > 0)
        //        {
        //            int j = 0;
        //            dgvUnShippiedInvoiceList.Rows.Clear();
        //            for (int i = 0; i < dtInvoice.Rows.Count; i++)
        //            {
        //                dgvUnShippiedInvoiceList.Rows.Add();
        //                ServiceID = dtInvoice.Rows[i]["ServiceID"].ToString();
        //                dgvUnShippiedInvoiceList.Rows[j].Cells[0].Value = dtInvoice.Rows[i]["ID"].ToString();
        //                dgvUnShippiedInvoiceList.Rows[j].Cells[1].Value = dtInvoice.Rows[i]["CustomerName"].ToString();
        //                dgvUnShippiedInvoiceList.Rows[j].Cells[2].Value = dtInvoice.Rows[i]["AccountName"].ToString();
        //                dgvUnShippiedInvoiceList.Rows[j].Cells[3].Value = dtInvoice.Rows[i]["RefNumber"].ToString();
        //                dgvUnShippiedInvoiceList.Rows[j].Cells[4].Value = dtInvoice.Rows[i]["ShipMethod"].ToString();
        //                dgvUnShippiedInvoiceList.Rows[j].Cells[5].Value = Convert.ToDateTime(dtInvoice.Rows[i]["TxnDate"].ToString()).ToString("MM-dd-yyyy");
        //                dgvUnShippiedInvoiceList.Rows[j].Cells[6].Value = Convert.ToDateTime(dtInvoice.Rows[i]["ShipDate"].ToString()).ToString("MM-dd-yyyy");
        //                dgvUnShippiedInvoiceList.Rows[j].Cells[7].Value = dtInvoice.Rows[i]["Total"].ToString();


        //                int INVID = Convert.ToInt32(dtInvoice.Rows[i]["ID"].ToString());
        //                DataTable dt = BALHistory.Select(INVID);
        //                if (dt.Rows.Count > 0)
        //                {
        //                    if (dt.Rows[0]["IsPrintDate"].ToString() != "" && dt.Rows[0]["IsUpdateDate"].ToString() != "")
        //                    {
        //                        if (Convert.ToDateTime(dt.Rows[0]["IsUpdateDate"]) > Convert.ToDateTime(dt.Rows[0]["IsPrintDate"]))
        //                        {
        //                            dgvUnShippiedInvoiceList.Rows[j].DefaultCellStyle.BackColor = Color.Orange;
        //                        }
        //                        else if (Convert.ToDateTime(dt.Rows[0]["IsPrintDate"]) > Convert.ToDateTime(dt.Rows[0]["IsUpdateDate"]))
        //                        {
        //                            dgvUnShippiedInvoiceList.Rows[j].DefaultCellStyle.BackColor = Color.LightSeaGreen;
        //                        }
        //                    }
        //                    else if (dt.Rows[0]["IsPrintDate"].ToString() == "" && dt.Rows[0]["IsUpdateDate"].ToString() != "")
        //                    {
        //                        dgvUnShippiedInvoiceList.Rows[j].DefaultCellStyle.BackColor = Color.Orange;
        //                    }

        //                }
        //                j++;
        //            }
        //        }
        //        else
        //        {
        //            dgvUnShippiedInvoiceList.Rows.Clear();
        //        }
        //        Cursor.Current = Cursors.WaitCursor;
        //        lblTotal.Text = dtInvoice.Rows.Count.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        Cursor.Current = Cursors.WaitCursor;
        //        ClsCommon.WriteErrorLogs("Form:FrmUnShippedInvoiceList, Function :LoadUnShippedInvoice. Message:" + ex.Message);
        //        MessageBox.Show("Error:" + ex.Message);
        //    }
        //}

        private void btmClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtInvoiceNo.Text = "";
            //LoadUnShippedInvoice();
            DateWiseInvoiceLoad();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtInvoiceNo.Text != "")
                {
                    //DataRow[] row = dtInvoice.Select("RefNumber like '%" + txtInvoiceNo.Text + "%' OR TrackingID like '%" + txtInvoiceNo.Text + "%' OR CustomerName like '%" + txtInvoiceNo.Text + "%' OR COD like '%" + txtInvoiceNo.Text + "%' OR Service like '%" + txtInvoiceNo.Text + "%' OR Weight like '%" + txtInvoiceNo.Text + "%' OR Charges like '%" + txtInvoiceNo.Text + "%'");
                    DataRow[] row = dtInvoice.Select("RefNumber like '%" + txtInvoiceNo.Text + "%' OR CustomerName like '%" + txtInvoiceNo.Text + "%' OR AccountName like '%" + txtInvoiceNo.Text + "%' OR  ShipMethod like '%" + txtInvoiceNo.Text + "%' OR Total like '%" + txtInvoiceNo.Text + "%'");
                    if (row.Length > 0)
                    {
                        DataTable dtNew = row.CopyToDataTable();

                        int j = 0;
                        dgvUnShippiedInvoiceList.Rows.Clear();
                        for (int i = 0; i < dtNew.Rows.Count; i++)
                        {
                            dgvUnShippiedInvoiceList.Rows.Add();
                            dgvUnShippiedInvoiceList.Rows[j].Cells[0].Value = dtNew.Rows[i]["ID"].ToString();
                            dgvUnShippiedInvoiceList.Rows[j].Cells[1].Value = dtNew.Rows[i]["CustomerName"].ToString();
                            dgvUnShippiedInvoiceList.Rows[j].Cells[2].Value = dtNew.Rows[i]["AccountName"].ToString();
                            dgvUnShippiedInvoiceList.Rows[j].Cells[3].Value = dtNew.Rows[i]["RefNumber"].ToString();
                            dgvUnShippiedInvoiceList.Rows[j].Cells[4].Value = dtNew.Rows[i]["ShipMethod"].ToString();
                            dgvUnShippiedInvoiceList.Rows[j].Cells[5].Value = Convert.ToDateTime(dtNew.Rows[i]["TxnDate"].ToString()).ToString("MM-dd-yyyy");
                            dgvUnShippiedInvoiceList.Rows[j].Cells[6].Value = Convert.ToDateTime(dtNew.Rows[i]["ShipDate"].ToString()).ToString("MM-dd-yyyy");
                            dgvUnShippiedInvoiceList.Rows[j].Cells[7].Value = dtNew.Rows[i]["Total"].ToString();
                            //dgvUnShippiedInvoiceList.Rows[j].Cells[7].Value = dtNew.Rows[i]["TrackingNumber"].ToString();
                            j++;
                        }
                        lblTotal.Text = dtNew.Rows.Count.ToString();
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmUnShippedInvoiceList,Function :btnSearch_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

       
        private void dgvUnShippiedInvoiceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 8)
                {
                    if (ClsCommon.FunctionVisibility("Shipping", "UnShippedInvoiceHistory"))
                    {
                        ClsCommon.objUPS.Clear1();
                        ClsCommon.objUPS.LoadUPSService();
                        ClsCommon.objUPS.ID = dgvUnShippiedInvoiceList.CurrentRow.Cells[0].Value.ToString();
                        ClsCommon.objUPS.RefNumber = dgvUnShippiedInvoiceList.CurrentRow.Cells[3].Value.ToString();
                        ClsCommon.objUPS.Carrier = dgvUnShippiedInvoiceList.CurrentRow.Cells[4].Value.ToString();
                        if (ServiceID != "")
                            ClsCommon.objUPS.ServiceID = ServiceID;
                        ClsCommon.RefNumber = dgvUnShippiedInvoiceList.CurrentRow.Cells[3].Value.ToString();
                        ClsCommon.objUPS.LoadFunction();
                        ClsCommon.objUPS.Show();

                    }
                    else
                        MessageBox.Show("You can not access");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUnShippedInvoiceReport,Function :dgvUnShippiedInvoiceList_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

        private void FrmUnShippedInvoiceList_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClsCommon.ObjUnShippedInvList.Hide();
            ClsCommon.ObjUnShippedInvList.Parent = null;
            e.Cancel = true;
        }

        private void PnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbTransactionsFilterDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTransactionsFilterDate.SelectedIndex >= 0)
            {
                DateWiseInvoiceLoad();
            }
        }
        public void DateWiseInvoiceLoad()
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;
                lblFrom.Visible = false; lblto.Visible = false; dtTranFrom.Visible = false; dtTranTo.Visible = false;
                //All Invoices

                if (cmbTransactionsFilterDate.SelectedIndex == 0)
                {
                    //Today
                    dtShipInvoice = new DataTable();
                    dtShipInvoice = new BALInvoiceMaster().SelectByFilter(new BOLInvoiceMaster() { StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                    //dtShipInvoice = new BALInvoiceMaster().SelectByCustomerWiseInvoices(new BOLInvoiceMaster() { CustomerID = CusID, StartDate = DateTime.Now.ToString("yyyy-MM-dd"), EndDate = DateTime.Now.ToString("yyyy-MM-dd") });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 1)
                {
                    //yesterday
                    dtShipInvoice = new DataTable();
                    DateTime dt1 = DateTime.Now.AddDays(-1);
                    dtShipInvoice = new BALInvoiceMaster().SelectByFilter(new BOLInvoiceMaster() { StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 2)
                {
                    //this month
                    dtShipInvoice = new DataTable();
                    DateTime dt = DateTime.Now;
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    dtShipInvoice = new BALInvoiceMaster().SelectByFilter(new BOLInvoiceMaster() { StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 3)
                {
                    //this week
                    dtShipInvoice = new DataTable();
                    DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
                    DateTime dt1 = dt.AddDays(6);
                    dtShipInvoice = new BALInvoiceMaster().SelectByFilter(new BOLInvoiceMaster() { StartDate = dt.ToString("yyyy-MM-dd"), EndDate = dt1.ToString("yyyy-MM-dd") });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 4)
                {
                    //last month
                    dtShipInvoice = new DataTable();
                    DateTime dt = DateTime.Now.AddMonths(-1);
                    DateTime dt1 = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
                    dtShipInvoice = new BALInvoiceMaster().SelectByFilter(new BOLInvoiceMaster() { StartDate = dt1.ToString("yyyy-MM-dd"), EndDate = dt1.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 5)
                {
                    //this ficsal year
                    dtShipInvoice = new DataTable();
                    int year = DateTime.Now.Year;
                    DateTime firstDay = Convert.ToDateTime(year + "-" + "01" + "-" + "01");
                    dtShipInvoice = new BALInvoiceMaster().SelectByFilter(new BOLInvoiceMaster() { StartDate = firstDay.ToString("yyyy-MM-dd"), EndDate = firstDay.AddYears(1).AddDays(-1).ToString("yyyy-MM-dd") });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 6)
                {
                    //All
                    dtShipInvoice = new DataTable();
                    dtShipInvoice = new BALInvoiceMaster().SelectByFilter(new BOLInvoiceMaster() { StartDate = null, EndDate = null });
                }
                else if (cmbTransactionsFilterDate.SelectedIndex == 7)
                {
                    //Custom
                    dtShipInvoice = new DataTable();
                    lblFrom.Visible = true; lblto.Visible = true; dtTranFrom.Visible = true; dtTranTo.Visible = true;

                }
                Cursor.Current = Cursors.WaitCursor;
                txtInvoiceNo.Text = "";
                if (dtShipInvoice.Rows.Count > 0)
                {
                    int j = 0;
                    dgvUnShippiedInvoiceList.Rows.Clear();
                    for (int i = 0; i < dtShipInvoice.Rows.Count; i++)
                    {
                        dgvUnShippiedInvoiceList.Rows.Add();
                        ServiceID = dtShipInvoice.Rows[i]["ServiceID"].ToString();
                        dgvUnShippiedInvoiceList.Rows[j].Cells[0].Value = dtShipInvoice.Rows[i]["ID"].ToString();
                        dgvUnShippiedInvoiceList.Rows[j].Cells[1].Value = dtShipInvoice.Rows[i]["CustomerName"].ToString();
                        dgvUnShippiedInvoiceList.Rows[j].Cells[2].Value = dtShipInvoice.Rows[i]["AccountName"].ToString();
                        dgvUnShippiedInvoiceList.Rows[j].Cells[3].Value = dtShipInvoice.Rows[i]["RefNumber"].ToString();
                        dgvUnShippiedInvoiceList.Rows[j].Cells[4].Value = dtShipInvoice.Rows[i]["ShipMethod"].ToString();
                        dgvUnShippiedInvoiceList.Rows[j].Cells[5].Value = Convert.ToDateTime(dtShipInvoice.Rows[i]["TxnDate"].ToString()).ToString("MM-dd-yyyy");
                        dgvUnShippiedInvoiceList.Rows[j].Cells[6].Value = Convert.ToDateTime(dtShipInvoice.Rows[i]["ShipDate"].ToString()).ToString("MM-dd-yyyy");
                        dgvUnShippiedInvoiceList.Rows[j].Cells[7].Value = dtShipInvoice.Rows[i]["Total"].ToString();


                        int INVID = Convert.ToInt32(dtShipInvoice.Rows[i]["ID"].ToString());
                        DataTable dt = BALHistory.Select(INVID);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["IsPrintDate"].ToString() != "" && dt.Rows[0]["IsUpdateDate"].ToString() != "")
                            {
                                if (Convert.ToDateTime(dt.Rows[0]["IsUpdateDate"]) > Convert.ToDateTime(dt.Rows[0]["IsPrintDate"]))
                                {
                                    dgvUnShippiedInvoiceList.Rows[j].DefaultCellStyle.BackColor = Color.Orange;
                                }
                                else if (Convert.ToDateTime(dt.Rows[0]["IsPrintDate"]) > Convert.ToDateTime(dt.Rows[0]["IsUpdateDate"]))
                                {
                                    dgvUnShippiedInvoiceList.Rows[j].DefaultCellStyle.BackColor = Color.LightSeaGreen;
                                }
                            }
                            else if (dt.Rows[0]["IsPrintDate"].ToString() == "" && dt.Rows[0]["IsUpdateDate"].ToString() != "")
                            {
                                dgvUnShippiedInvoiceList.Rows[j].DefaultCellStyle.BackColor = Color.Orange;
                            }

                        }
                        j++;
                    }
                }
                else
                {
                    dgvUnShippiedInvoiceList.Rows.Clear();
                }
                Cursor.Current = Cursors.WaitCursor;
                lblTotal.Text = dtShipInvoice.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmCustomerCenter,Function :CustomerWiseInvoiceLoad. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void dtTranTo_Leave(object sender, EventArgs e)
        {
            dtShipInvoice = new DataTable();
            dtShipInvoice = new BALInvoiceMaster().SelectByFilter(new BOLInvoiceMaster() { StartDate = dtTranFrom.Value.ToString("yyyy-MM-dd"), EndDate = dtTranTo.Value.ToString("yyyy-MM-dd") });
            if (dtShipInvoice.Rows.Count > 0)
            {
                int j = 0;
                dgvUnShippiedInvoiceList.Rows.Clear();
                for (int i = 0; i < dtShipInvoice.Rows.Count; i++)
                {
                    dgvUnShippiedInvoiceList.Rows.Add();
                    ServiceID = dtShipInvoice.Rows[i]["ServiceID"].ToString();
                    dgvUnShippiedInvoiceList.Rows[j].Cells[0].Value = dtShipInvoice.Rows[i]["ID"].ToString();
                    dgvUnShippiedInvoiceList.Rows[j].Cells[1].Value = dtShipInvoice.Rows[i]["CustomerName"].ToString();
                    dgvUnShippiedInvoiceList.Rows[j].Cells[2].Value = dtShipInvoice.Rows[i]["AccountName"].ToString();
                    dgvUnShippiedInvoiceList.Rows[j].Cells[3].Value = dtShipInvoice.Rows[i]["RefNumber"].ToString();
                    dgvUnShippiedInvoiceList.Rows[j].Cells[4].Value = dtShipInvoice.Rows[i]["ShipMethod"].ToString();
                    dgvUnShippiedInvoiceList.Rows[j].Cells[5].Value = Convert.ToDateTime(dtShipInvoice.Rows[i]["TxnDate"].ToString()).ToString("MM-dd-yyyy");
                    dgvUnShippiedInvoiceList.Rows[j].Cells[6].Value = Convert.ToDateTime(dtShipInvoice.Rows[i]["ShipDate"].ToString()).ToString("MM-dd-yyyy");
                    dgvUnShippiedInvoiceList.Rows[j].Cells[7].Value = dtShipInvoice.Rows[i]["Total"].ToString();


                    int INVID = Convert.ToInt32(dtShipInvoice.Rows[i]["ID"].ToString());
                    DataTable dt = BALHistory.Select(INVID);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["IsPrintDate"].ToString() != "" && dt.Rows[0]["IsUpdateDate"].ToString() != "")
                        {
                            if (Convert.ToDateTime(dt.Rows[0]["IsUpdateDate"]) > Convert.ToDateTime(dt.Rows[0]["IsPrintDate"]))
                            {
                                dgvUnShippiedInvoiceList.Rows[j].DefaultCellStyle.BackColor = Color.Orange;
                            }
                            else if (Convert.ToDateTime(dt.Rows[0]["IsPrintDate"]) > Convert.ToDateTime(dt.Rows[0]["IsUpdateDate"]))
                            {
                                dgvUnShippiedInvoiceList.Rows[j].DefaultCellStyle.BackColor = Color.LightSeaGreen;
                            }
                        }
                        else if (dt.Rows[0]["IsPrintDate"].ToString() == "" && dt.Rows[0]["IsUpdateDate"].ToString() != "")
                        {
                            dgvUnShippiedInvoiceList.Rows[j].DefaultCellStyle.BackColor = Color.Orange;
                        }

                    }
                    j++;
                }
            }
            else
            {
                dgvUnShippiedInvoiceList.Rows.Clear();
                //lblCusWiseTotal.Text = "0.00";
            }
            Cursor.Current = Cursors.WaitCursor;
            lblTotal.Text = dtShipInvoice.Rows.Count.ToString();
        }
    }
}