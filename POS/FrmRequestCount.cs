using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmRequestCount : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dt = new DataTable();
        BALCustomerRequest objBALCus = new BALCustomerRequest();
        BOLCustomerRequest objBOLCus = new BOLCustomerRequest();

        public FrmRequestCount()
        {
            InitializeComponent();
            LoadData();
        }

        private void FrmAdminRequestList_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvRequestList.DefaultCellStyle.Font = new Font("", 10);
                dgvRequestList.RowTemplate.Height = 24;
                dgvRequestList.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvRequestList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                dgvRequestList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                dgvRequestList.EnableHeadersVisualStyles = false;

                LoadData();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmRequestCount, Function :FrmAdminRequestList_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void LoadData()
        {
            try
            {
                if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                {
                    dt = new DataTable();
                    dt = new BALCustomerRequest().SelectAdminPendingRequest(new BOLCustomerRequest() { });
                    if (dt.Rows.Count > 0)
                    {
                        int j = 0;
                        dgvRequestList.Rows.Clear();
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dgvRequestList.Rows.Add();
                            dgvRequestList.Rows[j].Cells[0].Value = dt.Rows[i]["ID"].ToString();
                            dgvRequestList.Rows[j].Cells[1].Value = dt.Rows[i]["InvoiceNumber"].ToString();
                            dgvRequestList.Rows[j].Cells[2].Value = dt.Rows[i]["SalesRepName"].ToString();
                            if(dt.Rows[i]["CreatedTime"].ToString() != "")
                            {
                                dgvRequestList.Rows[j].Cells[4].Value = Convert.ToDateTime(dt.Rows[i]["CreatedTime"].ToString()).ToString("MM-dd-yyyy");
                            }
                            
                            //if (ClsCommon.UserID != null)
                            //{
                            //    DataTable dtname = new BALSalesRepMaster().SelectByID(new BOLSalesRepMaster() { ID = Convert.ToInt32(ClsCommon.UserID)});
                            //    if(dtname.Rows.Count > 0)
                            //        dgvRequestList.Rows[j].Cells[3].Value = dtname.Rows[0]["Name"].ToString();
                            //}
                            if (dt.Rows[i]["Status"].ToString() == "0")
                            {
                                dgvRequestList.Rows[j].Cells[3].Style.ForeColor = Color.Red;
                                dgvRequestList.Rows[j].Cells[3].Value = "Pending";
                            }
                            else if (dt.Rows[i]["Status"].ToString() == "1")
                            {
                                dgvRequestList.Rows[j].Cells[3].Value = "Approved";
                            }
                            else if (dt.Rows[i]["Status"].ToString() == "2")
                            {
                                dgvRequestList.Rows[j].Cells[3].Style.ForeColor = Color.Red;
                                dgvRequestList.Rows[j].Cells[3].Value = "Rejected";
                            }
                            else if (dt.Rows[i]["Status"].ToString() == "3")
                            {
                                dgvRequestList.Rows[j].Cells[3].Style.ForeColor = Color.Green;
                                dgvRequestList.Rows[j].Cells[3].Value = "PendingCreateInvoice";
                            }
                            dgvRequestList.Rows[j].Cells[5].Value = dt.Rows[i]["ItemName"].ToString();
                            dgvRequestList.Rows[j].Cells[6].Value = dt.Rows[i]["CustomerName"].ToString();
                            j++;
                        }
                    }
                    else
                        dgvRequestList.Rows.Clear();
                }
                else
                {
                    dt = new DataTable();
                    dt = new BALCustomerRequest().SelectBySalesRepID(new BOLCustomerRequest() { SalesRepID = ClsCommon.UserID });
                    if (dt.Rows.Count > 0)
                    {
                        int j = 0;
                        dgvRequestList.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dgvRequestList.Rows.Add();
                            dgvRequestList.Rows[j].Cells[0].Value = dt.Rows[i]["ID"].ToString();
                            dgvRequestList.Rows[j].Cells[1].Value = dt.Rows[i]["InvoiceNumber"].ToString();
                            dgvRequestList.Rows[j].Cells[2].Value = dt.Rows[i]["SalesRepName"].ToString();
                            if(dt.Rows[i]["CreatedTime"].ToString() != "")
                            {
                                dgvRequestList.Rows[j].Cells[4].Value = Convert.ToDateTime(dt.Rows[i]["CreatedTime"].ToString()).ToString("MM-dd-yyyy");
                            }
                            
                            //if (dt.Rows[i]["ModifiedID"].ToString() != null && dt.Rows[i]["ModifiedID"].ToString() != "")
                            //{
                            //    DataTable dtname = new BALSalesRepMaster().SelectByID(new BOLSalesRepMaster() { ID = Convert.ToInt32(dt.Rows[i]["ModifiedID"].ToString()) });
                            //    if (dtname.Rows.Count > 0)
                            //        dgvRequestList.Rows[j].Cells[2].Value = dtname.Rows[0]["Name"].ToString();
                            //}
                            if (dt.Rows[i]["Status"].ToString() == "0")
                            {
                                dgvRequestList.Rows[j].Cells[3].Style.ForeColor = Color.Red;
                                dgvRequestList.Rows[j].Cells[3].Value = "Pending";
                            }
                            else if (dt.Rows[i]["Status"].ToString() == "1")
                            {
                                dgvRequestList.Rows[j].Cells[3].Value = "Approved";
                            }
                            else if (dt.Rows[i]["Status"].ToString() == "2")
                            {
                                dgvRequestList.Rows[j].Cells[3].Style.ForeColor = Color.Red;
                                dgvRequestList.Rows[j].Cells[3].Value = "Rejected";
                            }
                            else if (dt.Rows[i]["Status"].ToString() == "3")
                            {
                                dgvRequestList.Rows[j].Cells[3].Style.ForeColor = Color.Green;
                                dgvRequestList.Rows[j].Cells[3].Value = "PendingCreateInvoice";
                            }
                            dgvRequestList.Rows[j].Cells[5].Value = dt.Rows[i]["ItemName"].ToString();
                            dgvRequestList.Rows[j].Cells[6].Value = dt.Rows[i]["CustomerName"].ToString();
                            j++;
                        }
                    }
                    else
                        dgvRequestList.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmRequestCount, Function :LoadData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void FrmRequestCount_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClsCommon.Flag = 0;
            ClsCommon.objRequestCount.Hide();
            ClsCommon.objRequestCount.Parent = null;
            e.Cancel = true;
        }
    }
}