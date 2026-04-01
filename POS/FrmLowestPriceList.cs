using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmLowestPriceList : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dt = new DataTable();
        BALCustomerRequest objBALCus = new BALCustomerRequest();
        BOLCustomerRequest objBOLCus = new BOLCustomerRequest();

        public FrmLowestPriceList()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            lblTotal.Text = "0";
            LoadData();
        }

        public void LoadFunction()
        {
            LoadData();
        }

        private void FrmAdminRequestList_Load(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Text = "";

                //View Button
                //DataGridViewLinkColumn ViewButton = new DataGridViewLinkColumn();
                //ViewButton.UseColumnTextForLinkValue = true;
                //ViewButton.HeaderText = "View";
                //ViewButton.DataPropertyName = "View";
                //ViewButton.Text = "View";
                //dgvRequestList.Columns.Add(ViewButton);
                //dgvRequestList.Columns[10].Width = 100;

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

        public void LoadData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                dt = new BALCustomerRequest().SelectByRefnumber();
                if (dt.Rows.Count > 0)
                {
                    int j = 0;
                    dgvRequestList.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvRequestList.Rows.Add();
                        dgvRequestList.Rows[j].Cells[0].Value = dt.Rows[i]["ID"].ToString();
                        //dgvRequestList.Rows[j].Cells[1].Value = dt.Rows[i]["InvoiceID"].ToString();
                        dgvRequestList.Rows[j].Cells[1].Value = dt.Rows[i]["CustomerFullName"].ToString();
                        dgvRequestList.Rows[j].Cells[2].Value = dt.Rows[i]["RefNumber"].ToString();
                        //dgvRequestList.Rows[j].Cells[4].Value = dt.Rows[i]["ItemFullName"].ToString();
                        //dgvRequestList.Rows[j].Cells[5].Value = dt.Rows[i]["SalesRepName"].ToString();
                        //dgvRequestList.Rows[j].Cells[6].Value = dt.Rows[i]["SalesPrice"].ToString();
                        //dgvRequestList.Rows[j].Cells[7].Value = dt.Rows[i]["ItemLowestPrice"].ToString();
                        //dgvRequestList.Rows[j].Cells[8].Value = dt.Rows[i]["LowestPrice"].ToString();
                        //if (dt.Rows[i]["Status"].ToString() == "0")
                        //{
                        //    dgvRequestList.Rows[j].Cells[9].Style.ForeColor = Color.Red;
                        //    dgvRequestList.Rows[j].Cells[9].Value = "Pending";
                        //}
                        //else if (dt.Rows[i]["Status"].ToString() == "1")
                        //    dgvRequestList.Rows[j].Cells[9].Value = "Approved";
                        //else if (dt.Rows[i]["Status"].ToString() == "2")
                        //{
                        //    dgvRequestList.Rows[j].Cells[9].Style.ForeColor = Color.Red;
                        //    dgvRequestList.Rows[j].Cells[9].Value = "Rejected";
                        //}
                        j++;
                    }
                }
                else
                    dgvRequestList.Rows.Clear();
                lblTotal.Text = dt.Rows.Count.ToString();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmAdminRequestList, Function :LoadData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text != "")
                {
                    txtSearch.Text = "";
                    LoadData();
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmAdminRequestList, Function :btnReset_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
          
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text != "")
                {
                    DataRow[] row = dt.Select("CustomerFullName like '%" + txtSearch.Text + "%' or RefNumber like '%" + txtSearch.Text + "%'");
                    if (row.Length > 0)
                    {
                        DataTable dtNew = row.CopyToDataTable();

                        int j = 0;
                        dgvRequestList.Rows.Clear();
                        for (int i = 0; i < dtNew.Rows.Count; i++)
                        {
                            dgvRequestList.Rows.Add();
                            dgvRequestList.Rows[j].Cells[0].Value = dtNew.Rows[i]["ID"].ToString();
                            dgvRequestList.Rows[j].Cells[1].Value = dtNew.Rows[i]["CustomerFullName"].ToString();
                            dgvRequestList.Rows[j].Cells[2].Value = dtNew.Rows[i]["RefNumber"].ToString();
                            //dgvRequestList.Rows[j].Cells[3].Value = dtNew.Rows[i]["ItemFullName"].ToString();
                            //dgvRequestList.Rows[j].Cells[4].Value = dtNew.Rows[i]["SalesRepName"].ToString();
                            //dgvRequestList.Rows[j].Cells[5].Value = dt.Rows[i]["SalesPrice"].ToString();
                            //dgvRequestList.Rows[j].Cells[6].Value = dt.Rows[i]["ItemLowestPrice"].ToString();
                            //dgvRequestList.Rows[j].Cells[7].Value = dt.Rows[i]["LowestPrice"].ToString();
                            //if (dtNew.Rows[i]["Status"].ToString() == "0")
                            //{
                            //    dgvRequestList.Rows[j].Cells[8].Style.ForeColor = Color.Red;
                            //    dgvRequestList.Rows[j].Cells[8].Value = "Pending";
                            //}
                            //else if (dtNew.Rows[i]["Status"].ToString() == "1")
                            //    dgvRequestList.Rows[j].Cells[8].Value = "Approved";
                            //else if (dtNew.Rows[i]["Status"].ToString() == "2")
                            //{
                            //    dgvRequestList.Rows[j].Cells[9].Style.ForeColor = Color.Red;
                            //    dgvRequestList.Rows[j].Cells[9].Value = "Rejected";
                            //}
                            j++;
                        }
                        lblTotal.Text = dtNew.Rows.Count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmAdminRequestList,Function :btnSearch_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btmClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRequestList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    DataTable datatable=new DataTable();
                    if (dgvRequestList.CurrentRow.Cells["ID"].Value.ToString() != "")
                    {
                        
                        datatable = new BALCustomerRequest().Select(new BOLCustomerRequest());

                        DataRow[] row = datatable.Select("InvoiceID='" + dgvRequestList.CurrentRow.Cells["ID"].Value.ToString().Replace("'", "''") + "'");
                        if (row.Length > 0)
                        {
                            for (int i = 0;i < row.Length;i++)
                            {
                                DataRow dr = row[i];
                                objBOLCus.ID = Convert.ToInt32(dr["ID"]);
                                objBOLCus.AllowesNo = 0;
                                objBOLCus.UseAllowesNo = 0;
                                objBOLCus.NoOFDays = 0;
                                objBOLCus.UseNoOFDays = 0;
                                objBOLCus.CurrentInvoice = 0;
                                objBOLCus.UseCurrentInvoice = 0;
                                objBOLCus.Status = 1 ;
                                objBOLCus.ModifiedTime = DateTime.Now;
                                objBOLCus.ModifiedID = ClsCommon.UserID;
                                objBALCus.UpdateStatus(objBOLCus);
                                MessageBox.Show("Remove Successfully");
                            }
                        }
                    }
                    LoadData();
                }
                //if (e.ColumnIndex == 9)
                //{
                //    if (ClsCommon.FunctionVisibility("Approve", "AdminRequestList"))
                //    {
                //        FrmAdminApprove obj = new FrmAdminApprove();
                //        obj.RequestID = dgvRequestList.CurrentRow.Cells["ID"].Value.ToString();
                //        obj.Show();
                //        LoadData();
                //    }
                //    else
                //        MessageBox.Show("You can not access");
                //}
                //else if (e.ColumnIndex == 10)
                //{
                //    if (ClsCommon.FunctionVisibility("Reject", "AdminRequestList"))
                //    {
                //        objBOLCus.ID = Convert.ToInt32(dgvRequestList.CurrentRow.Cells["ID"].Value.ToString());
                //        objBOLCus.Status = 2;
                //        objBOLCus.IsActive = 0;
                //        objBOLCus.ModifiedTime = DateTime.Now;
                //        objBOLCus.ModifiedID = ClsCommon.UserID;
                //        objBALCus.UpdateRejectStatus(objBOLCus);
                //        LoadData();
                //    }
                //    else
                //        MessageBox.Show("You can not access");
                //}
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerRequest,Function :dgvRequestList_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
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
                ClsCommon.objLowestPriceList.Hide();
                ClsCommon.objLowestPriceList.Parent = null;
                e.Cancel = true;
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerRequest,Function :FrmAdminRequestList_FormClosing. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
          
        }

        private void PnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvRequestList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ClsCommon.FunctionVisibility("InvUpdate", "CustomerCenter"))
            {
                ClsCommon.ObjInvoiceMaster.LoadTable();
                ClsCommon.ObjInvoiceMaster.EditableField();
                ClsCommon.ObjInvoiceMaster.Show();
                //ClsCommon.ObjInvoiceMaster.RequestID = Convert.ToInt32(dgvRequestList.CurrentRow.Cells["ID"].Value);
                ClsCommon.ObjInvoiceMaster.LoadData(dgvRequestList.CurrentRow.Cells["ID"].Value.ToString());
                ClsCommon.ObjInvoiceMaster.AllowLowestPrice();
                ClsCommon.ObjInvoiceMaster.CheckDate();
                ClsCommon.ObjInvoiceMaster.DisplayLowestItemList();
                ClsCommon.ObjInvoiceMaster.AllowLowestPrice();
                //ClsCommon.ObjInvoiceMaster.DisplayNotes();
            }
            else
                MessageBox.Show("You can not access");
        }
    }
}