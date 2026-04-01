using ClosedXML.Excel;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmCreditMemoRequest : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dt = new DataTable();
        BALCreditMemoRequest objBALCreditMemo = new BALCreditMemoRequest();
        BOLCreditMemoRequest objBOLCreditMemo = new BOLCreditMemoRequest();

        public FrmCreditMemoRequest()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
        }

        public void LoadData()
        {
            try
            {
                if (ClsCommon.UserType == "Admin" || ClsCommon.UserType == "admin")
                {
                    dt = new DataTable();
                    dt = new BALCreditMemoRequest().SelectByDate(new BOLCreditMemoRequest() { CreatedTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")) });
                    if (dt.Rows.Count > 0)
                    {
                        int j = 0;
                        dgvRequestList.Rows.Clear();
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            dgvRequestList.Rows.Add();
                            dgvRequestList.Rows[j].Cells["ID"].Value = dt.Rows[i]["ID"].ToString();
                            dgvRequestList.Rows[j].Cells["CustomerName"].Value = dt.Rows[i]["CustomerName"].ToString();
                            dgvRequestList.Rows[j].Cells["CreditNo"].Value = dt.Rows[i]["CreditMemoNumber"].ToString();
                            if (dt.Rows[i]["CreatedTime"].ToString() != "")
                            {
                                dgvRequestList.Rows[j].Cells["Date"].Value = Convert.ToDateTime(dt.Rows[i]["CreatedTime"].ToString()).ToString("MM-dd-yyyy");
                            }
                            if (dt.Rows[i]["ModifiedTime"].ToString() != "")
                            {
                                dgvRequestList.Rows[j].Cells["ModifiedTime"].Value = Convert.ToDateTime(dt.Rows[i]["ModifiedTime"].ToString()).ToString("MM-dd-yyyy");
                            }
                            dgvRequestList.Rows[j].Cells["SalesRepName"].Value = dt.Rows[i]["SalesRepName"].ToString();
                            dgvRequestList.Rows[j].Cells["Total"].Value = dt.Rows[i]["Total"].ToString();
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
        private void FrmAdminRequestList_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                //View Button
                //DataGridViewLinkColumn ViewButton = new DataGridViewLinkColumn();
                //ViewButton.UseColumnTextForLinkValue = true;
                //ViewButton.HeaderText = "View";
                //ViewButton.DataPropertyName = "View";
                //ViewButton.Text = "View";
                //dgvRequestList.Columns.Add(ViewButton);
                //dgvRequestList.Columns[10].Width = 100;


                //DataGridViewLinkColumn Remove = new DataGridViewLinkColumn();
                //ViewButton.UseColumnTextForLinkValue = true;
                //ViewButton.HeaderText = "Remove";
                //ViewButton.DataPropertyName = "Remove";
                //ViewButton.Text = "Remove";
                //dgvRequestList.Columns.Add(Remove);
                //dgvRequestList.Columns[11].Width = 100;



                ////Approve Button
                //DataGridViewLinkColumn ApproveButton = new DataGridViewLinkColumn();
                //ApproveButton.UseColumnTextForLinkValue = true;
                //ApproveButton.HeaderText = "Approve";
                //ApproveButton.DataPropertyName = "Approve";
                //ApproveButton.Text = "Approve";
                //dgvRequestList.Columns.Add(ApproveButton);
                //dgvRequestList.Columns[8].Width = 100;

                ////Reject Button
                //DataGridViewLinkColumn RejectButton = new DataGridViewLinkColumn();
                //RejectButton.UseColumnTextForLinkValue = true;
                //RejectButton.HeaderText = "Reject";
                //RejectButton.DataPropertyName = "Reject";
                //RejectButton.Text = "Reject";
                //dgvRequestList.Columns.Add(RejectButton);
                //dgvRequestList.Columns[9].Width = 100;

                this.dgvRequestList.DefaultCellStyle.Font = new Font("", 10);
                dgvRequestList.RowTemplate.Height = 24;
                dgvRequestList.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvRequestList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                dgvRequestList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                dgvRequestList.EnableHeadersVisualStyles = false;
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmAdminRequestList, Function :FrmAdminRequestList_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void FrmAdminRequestList_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ClsCommon.objCreditMemoRequest.Hide();
                ClsCommon.objCreditMemoRequest.Parent = null;
                e.Cancel = true;
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerRequest,Function :FrmAdminRequestList_FormClosing. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
          
        }

  


    }
}