using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmCustomerAssignedTransfer : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtCustomer = new DataTable();
        DataTable dtSalesRep = new DataTable();
        BALCustomerMaster objBAlCustomer = new BALCustomerMaster();
        BOLCustomerMaster objBOLCustomer = new BOLCustomerMaster();
        DataTable dtChk = new DataTable();
        BALSalesRepMaster objSalesBAL = new BALSalesRepMaster();
        BOLSalesRepMaster objSalesBOL = new BOLSalesRepMaster();
        BALCustomerTransferList objBalList = new BALCustomerTransferList();
        BOLCustomerTransferList objBolList = new BOLCustomerTransferList();

        public FrmCustomerAssignedTransfer()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 50);
        }

        private void FrmCustomerAssignedList_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvCustomer.DefaultCellStyle.Font = new Font("", 10);
                dgvCustomer.RowTemplate.Height = 25;
                dgvCustomer.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvCustomer.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                dgvCustomer.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                dgvCustomer.EnableHeadersVisualStyles = false;

                GetAllSalesRep();
                lblTotal.Text = "0";
                GetTranferList();
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedTransfer,Function :FrmCustomerAssignedList_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        
        }   

        private void GetAllSalesRep()
        {
            try
            {
                dtSalesRep = new BALSalesRepMaster().SelectByUserName(new BOLSalesRepMaster() { });
                DataRow dr = dtSalesRep.NewRow();
                dr["UserName"] = "--Select--";
                dr["ID"] = "0";
                dr["IsActive"] = "0";
                dtSalesRep.Rows.InsertAt(dr, 0);
                cmbSalesRepName.DataSource = dtSalesRep;
                cmbSalesRepName.DisplayMember = "UserName";
                cmbSalesRepName.ValueMember = "ID";
                cmbSalesRepName.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedTransfer,Function :GetAllSalesRep. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void GetAllList()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                dtCustomer = new BALCustomerMaster().SelectAllList();
                if (dtCustomer.Rows.Count > 0)
                {
                    int j = 0;
                    dgvCustomer.Rows.Clear();
                    for (int i = 0; i < dtCustomer.Rows.Count; i++)
                    {
                        dgvCustomer.Rows.Add();
                        dgvCustomer.Rows[j].Cells[0].Value = dtCustomer.Rows[i]["ID"].ToString();
                        dgvCustomer.Rows[j].Cells[2].Value = dtCustomer.Rows[i]["FullName"].ToString();
                        dgvCustomer.Rows[j].Cells[3].Value = dtCustomer.Rows[i]["CompanyName"].ToString();
                        dgvCustomer.Rows[j].Cells[4].Value = dtCustomer.Rows[i]["Phone"].ToString();
                        dgvCustomer.Rows[j].Cells[5].Value = dtCustomer.Rows[i]["Email"].ToString();
                        dgvCustomer.Rows[j].Cells[6].Value = dtCustomer.Rows[i]["SalesRepName"].ToString();
                        if(dtCustomer.Rows[i]["SalesRepAll"].ToString() != "")
                        {
                            dgvCustomer.Rows[j].Cells[6].Value = dtCustomer.Rows[i]["SalesRepAll"].ToString();
                        }
                        j++;
                    }
                }
                else
                    dgvCustomer.Rows.Clear();
                lblTotal.Text = dtCustomer.Rows.Count.ToString();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedTransfer,Function :GetTranferList. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void GetTranferList()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                dtCustomer = new BALCustomerMaster().SelectTransferCustomerList();
                if (dtCustomer.Rows.Count > 0)
                {
                    int j = 0;
                    dgvCustomer.Rows.Clear();
                    for (int i = 0; i < dtCustomer.Rows.Count; i++)
                    {
                        dgvCustomer.Rows.Add();
                        dgvCustomer.Rows[j].Cells[0].Value = dtCustomer.Rows[i]["ID"].ToString();
                        dgvCustomer.Rows[j].Cells[2].Value = dtCustomer.Rows[i]["FullName"].ToString();
                        dgvCustomer.Rows[j].Cells[3].Value = dtCustomer.Rows[i]["CompanyName"].ToString();
                        dgvCustomer.Rows[j].Cells[4].Value = dtCustomer.Rows[i]["Phone"].ToString();
                        dgvCustomer.Rows[j].Cells[5].Value = dtCustomer.Rows[i]["Email"].ToString();
                        if (dtCustomer.Rows[i]["SalesRepName"].ToString() != "")
                        {
                            dgvCustomer.Rows[j].Cells[6].Value = dtCustomer.Rows[i]["SalesRepName"].ToString();
                        }
                        else
                        {
                            dgvCustomer.Rows[j].Cells[6].Value = dtCustomer.Rows[i]["SalesRepAll"].ToString();
                        }

                        j++;
                    }
                }
                else
                    dgvCustomer.Rows.Clear();
                lblTotal.Text = dtCustomer.Rows.Count.ToString();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedTransfer,Function :GetTranferList. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }


        //private Boolean CheckValidation()
        //{
        //    Boolean ISValid = false;
        //    try
        //    {
        //        if (cmbSalesRepName.SelectedIndex < 0)
        //        {
        //            ISValid = false;
        //            MessageBox.Show("Please Select SalesRepName");
        //            cmbSalesRepName.Focus();
        //            goto Final;
        //        }
        //        else if (rdbPullOut.Checked == true && rdbPullIn.Checked == true)
        //        {
        //            ISValid = false;
        //            MessageBox.Show("Please Select PullOut Or PullIn");
        //            rdbPullOut.Focus();
        //            goto Final;
        //        }
        //        else
        //            ISValid = true;

        //        Final:
        //        return ISValid;
        //    }
        //    catch (Exception ex)
        //    {
        //        ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedList,Function :CheckValidation. Message:" + ex.Message);
        //        MessageBox.Show("Error:" + ex.Message);
        //        return ISValid;
        //    }
        //}

        private void dgvCustomer_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }
           
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(rbCommon.Checked == true)
                {
                    DataRow[] row = dtCustomer.Select("FullName like '%" + txtFilter.Text + "%'");
                    if (row.Length > 0)
                    {
                        DataTable dtNew = row.CopyToDataTable();
                        int j = 0;
                        dgvCustomer.Rows.Clear();
                        for (int i = 0; i < dtNew.Rows.Count; i++)
                        {
                            dgvCustomer.Rows.Add();
                            dgvCustomer.Rows[j].Cells[0].Value = dtNew.Rows[i]["ID"].ToString();
                            dgvCustomer.Rows[j].Cells[2].Value = dtNew.Rows[i]["FullName"].ToString();
                            dgvCustomer.Rows[j].Cells[3].Value = dtNew.Rows[i]["CompanyName"].ToString();
                            dgvCustomer.Rows[j].Cells[4].Value = dtNew.Rows[i]["Phone"].ToString();
                            dgvCustomer.Rows[j].Cells[5].Value = dtNew.Rows[i]["Email"].ToString();
                            if (dtNew.Rows[i]["SalesRepName"].ToString() != "")
                            {
                                dgvCustomer.Rows[j].Cells[6].Value = dtNew.Rows[i]["SalesRepName"].ToString();
                            }
                            else if(dtNew.Rows[i]["SalesRepAll"].ToString() != "")
                            {
                                dgvCustomer.Rows[j].Cells[6].Value = dtNew.Rows[i]["SalesRepAll"].ToString();
                            }
                           
                            j++;
                        }
                        lblTotal.Text = dtNew.Rows.Count.ToString();
                    }
                    else
                    {
                        dgvCustomer.Rows.Clear();
                    }
                }
                else
                {
                    DataRow[] row = dtCustomer.Select("FullName like '%" + txtFilter.Text + "%'");
                    if (row.Length > 0)
                    {
                        DataTable dtNew = row.CopyToDataTable();
                        int j = 0;
                        dgvCustomer.Rows.Clear();
                        for (int i = 0; i < dtNew.Rows.Count; i++)
                        {
                            dgvCustomer.Rows.Add();
                            dgvCustomer.Rows[j].Cells[0].Value = dtNew.Rows[i]["ID"].ToString();
                            dgvCustomer.Rows[j].Cells[2].Value = dtNew.Rows[i]["FullName"].ToString();
                            dgvCustomer.Rows[j].Cells[3].Value = dtNew.Rows[i]["CompanyName"].ToString();
                            dgvCustomer.Rows[j].Cells[4].Value = dtNew.Rows[i]["Phone"].ToString();
                            dgvCustomer.Rows[j].Cells[5].Value = dtNew.Rows[i]["Email"].ToString();
                            if (dtNew.Columns.Contains("SalesRepName") == true)
                                dgvCustomer.Rows[j].Cells[6].Value = dtNew.Rows[i]["SalesRepName"].ToString();
                            j++;
                        }
                        lblTotal.Text = dtNew.Rows.Count.ToString();
                    }
                    else
                    {
                        dgvCustomer.Rows.Clear();
                    }
                }
               
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemList,Function :txtFilter_TextChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked == true)
                {
                    for (int i = 0; i < dgvCustomer.Rows.Count; i++)
                    {
                        dgvCustomer.Rows[i].Cells[1].Value = true;
                    }
                }
                else
                {
                    for (int i = 0; i < dgvCustomer.Rows.Count; i++)
                    {
                        dgvCustomer.Rows[i].Cells[1].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemList,Function :chkAll_CheckedChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

        private void txtDays_TextChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedTransfer,Function :txtDays_TextChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

        private void PnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if(rbTransfer.Checked==true)
            {
                cmbSalesRepName.Enabled = true;
                btnTransfer.Text = "Transfer";
                rbAssign.Checked = false;
                rbCommon.Checked = false;
                GetTranferList();
            }
            
        }

        private void rbAssign_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbAssign.Checked == true)
                {
                    cmbSalesRepName.Enabled = true;
                    txtFilter.Text = "";
                    btnTransfer.Text = "Assign";
                    rbTransfer.Checked = false;
                    rbCommon.Checked = false;
                    GetAssignList();
                }
               
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedTransfer,Function :rbAssign_CheckedChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }

        }
        private void rbCommon_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCommon.Checked == true)
            {
                cmbSalesRepName.Enabled = false;
                txtFilter.Text = "";
                btnTransfer.Text = "Transfer";
                rbTransfer.Checked = false;
                rbAssign.Checked = false;
                GetAllList();
            }
        }
        
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {              
                    if (rbTransfer.Checked == true)
                    {
                        if (cmbSalesRepName.SelectedIndex > 0)
                        {
                            if (ClsCommon.FunctionVisibility("Transfer", "AssignedCustomerList"))
                            {
                                for (int i = 0; i < dgvCustomer.Rows.Count; i++)
                                {
                                    if (Convert.ToBoolean(dgvCustomer.Rows[i].Cells[1].Value) == true)
                                    {
                                        objBOLCustomer = new BOLCustomerMaster(); objBAlCustomer = new BALCustomerMaster();
                                        objBOLCustomer.ID = Convert.ToInt32(dgvCustomer.Rows[i].Cells[0].Value.ToString());
                                        objBOLCustomer.SalesRepID = Convert.ToInt32(cmbSalesRepName.SelectedValue.ToString());
                                        objBAlCustomer.UpdateSalesRepID(objBOLCustomer);

                                        DataTable dt = new BALSalesRepMaster().SelectByName(new BOLSalesRepMaster() { Name = dgvCustomer.Rows[i].Cells["SALESREP"].Value.ToString() });
                                        if(dt.Rows.Count > 0)
                                        {
                                           objBolList = new BOLCustomerTransferList();
                                           objBolList.CusID = Convert.ToInt32(dgvCustomer.Rows[i].Cells[0].Value.ToString());
                                           objBolList.OldSalesRep = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                                           objBolList.NewSalesRep = Convert.ToInt32(cmbSalesRepName.SelectedValue.ToString());
                                           objBolList.Date = DateTime.Now;
                                           objBalList.Insert(objBolList);                                          
                                        }

                                        dtChk = new BALNewCustomerHistory().Select(dgvCustomer.Rows[i].Cells[0].Value.ToString(), cmbSalesRepName.SelectedValue.ToString());
                                        if (dtChk.Rows.Count == 0)
                                        {
                                            new BALNewCustomerHistory().Insert(dgvCustomer.Rows[i].Cells[0].Value.ToString(), cmbSalesRepName.SelectedValue.ToString());
                                        }
                                    }
                                }
                                MessageBox.Show("SalesRep transfer successfully in all selected customers");
                                GetTranferList();
                            }
                            else
                            {
                              MessageBox.Show("You can not access");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select SalesRep first");
                        }
                    }

                    else if (rbAssign.Checked == true)
                    {
                        if (cmbSalesRepName.SelectedIndex > 0)
                        {
                           if (ClsCommon.FunctionVisibility("Assign", "AssignedCustomerList"))
                           {
                              for (int i = 0; i < dgvCustomer.Rows.Count; i++)
                              {
                                 if (Convert.ToBoolean(dgvCustomer.Rows[i].Cells[1].Value) == true)
                                 {
                                    objBOLCustomer = new BOLCustomerMaster(); objBAlCustomer = new BALCustomerMaster();
                                    
                                    objBOLCustomer.ID = Convert.ToInt32(dgvCustomer.Rows[i].Cells[0].Value.ToString());
                                    objBOLCustomer.SalesRepID = Convert.ToInt32(cmbSalesRepName.SelectedValue.ToString());
                                    objBOLCustomer.SalesRepAll = null;
                                    objBAlCustomer.UpdateSalesRepID(objBOLCustomer);
                                    
                                    dtChk = new BALNewCustomerHistory().Select(dgvCustomer.Rows[i].Cells[0].Value.ToString(), cmbSalesRepName.SelectedValue.ToString());
                                    if (dtChk.Rows.Count == 0)
                                    {
                                        new BALNewCustomerHistory().Insert(dgvCustomer.Rows[i].Cells[0].Value.ToString(), cmbSalesRepName.SelectedValue.ToString());
                                    }
                                 }
                              }
                              MessageBox.Show("SalesRep Assign successfully in all selected customers");
                              GetAssignList();
                           }
                           else
                           {
                            MessageBox.Show("You can not access");
                           }
                        }
                        else
                        {
                            MessageBox.Show("Please select SalesRep first");
                        }

                    }

                    else
                    {                      
                         if (ClsCommon.FunctionVisibility("CommonForAllSalesRep", "AssignedCustomerList"))
                         {
                                for (int i = 0; i < dgvCustomer.Rows.Count; i++)
                                {
                                    if (Convert.ToBoolean(dgvCustomer.Rows[i].Cells[1].Value) == true)
                                    {
                                        objBOLCustomer = new BOLCustomerMaster(); objBAlCustomer = new BALCustomerMaster();
                                        objBOLCustomer.ID = Convert.ToInt32(dgvCustomer.Rows[i].Cells[0].Value.ToString());
                                        objBOLCustomer.SalesRepID = null;
                                        objBOLCustomer.SalesRepAll = "All";
                                        objBAlCustomer.UpdateSalesRepID(objBOLCustomer);

                                        dtChk = new BALNewCustomerHistory().Select(dgvCustomer.Rows[i].Cells[0].Value.ToString(), cmbSalesRepName.SelectedValue.ToString());
                                        if (dtChk.Rows.Count == 0)
                                        {
                                            new BALNewCustomerHistory().Insert(dgvCustomer.Rows[i].Cells[0].Value.ToString(), cmbSalesRepName.SelectedValue.ToString());
                                        }

                                    }
                                }
                                MessageBox.Show("SalesRep transfer successfully in all selected customers");
                                GetAllList();
                         }
                         else
                         {
                             MessageBox.Show("You can not access");
                         }
                       
                    }
                
                
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedTransfer,Function :btnTransfer_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

        private void GetAssignList()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                dtCustomer = new BALCustomerMaster().SelectAssignCustomer();
                if (dtCustomer.Rows.Count > 0)
                {
                    int j = 0;
                    dgvCustomer.Rows.Clear();
                    for (int i = 0; i < dtCustomer.Rows.Count; i++)
                    {
                        dgvCustomer.Rows.Add();
                        dgvCustomer.Rows[j].Cells[0].Value = dtCustomer.Rows[i]["ID"].ToString();
                        dgvCustomer.Rows[j].Cells[2].Value = dtCustomer.Rows[i]["FullName"].ToString();
                        dgvCustomer.Rows[j].Cells[3].Value = dtCustomer.Rows[i]["CompanyName"].ToString();
                        dgvCustomer.Rows[j].Cells[4].Value = dtCustomer.Rows[i]["Phone"].ToString();
                        dgvCustomer.Rows[j].Cells[5].Value = dtCustomer.Rows[i]["Email"].ToString();
                        dgvCustomer.Rows[j].Cells[6].Value = dtCustomer.Rows[i]["SalesRepAll"].ToString();
                        j++;
                    }
                }
                else
                    dgvCustomer.Rows.Clear();
                lblTotal.Text = dtCustomer.Rows.Count.ToString();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedTransfer,Function :GetTranferList. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtFilter.Text = "";
                txtDays.Text = "";
                if (rbTransfer.Checked == true)
                {
                    GetTranferList();
                }
                else
                {
                    GetAssignList();
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedTransfer,Function :btnReset_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
         
        }

        private void btnDays_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtDays.Text!="")
                {
                    dtpFromDate.Value = DateTime.Now.AddDays(-Convert.ToInt32(txtDays.Text));
                    dtpToDate.Value = DateTime.Now;

                    if (rbTransfer.Checked==true)
                    {
                        GetTranferListByDays();
                    }
                    else if(rbAssign.Checked==true)
                    {
                        GetAssignListByDays();
                    }
                    else
                    {
                        GetAllListByDays();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter days first..!!");
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedTransfer,Function :btnDays_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void GetAllListByDays()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                dtCustomer = new BALCustomerMaster().SelectAllCustomerListByDays(new BOLCustomerMaster() { FromDate = dtpFromDate.Value, ToDate = dtpToDate.Value });
                if (dtCustomer.Rows.Count > 0)
                {
                    int j = 0;
                    dgvCustomer.Rows.Clear();
                    for (int i = 0; i < dtCustomer.Rows.Count; i++)
                    {
                        dgvCustomer.Rows.Add();
                        dgvCustomer.Rows[j].Cells[0].Value = dtCustomer.Rows[i]["ID"].ToString();
                        dgvCustomer.Rows[j].Cells[2].Value = dtCustomer.Rows[i]["FullName"].ToString();
                        dgvCustomer.Rows[j].Cells[3].Value = dtCustomer.Rows[i]["CompanyName"].ToString();
                        dgvCustomer.Rows[j].Cells[4].Value = dtCustomer.Rows[i]["Phone"].ToString();
                        dgvCustomer.Rows[j].Cells[5].Value = dtCustomer.Rows[i]["Email"].ToString();
                        dgvCustomer.Rows[j].Cells[6].Value = dtCustomer.Rows[i]["SalesRepName"].ToString();
                        if (dtCustomer.Rows[i]["SalesRepAll"].ToString() != "")
                        {
                            dgvCustomer.Rows[j].Cells[6].Value = dtCustomer.Rows[i]["SalesRepAll"].ToString();
                        }
                        j++;
                    }
                }
                else
                    dgvCustomer.Rows.Clear();
                lblTotal.Text = dtCustomer.Rows.Count.ToString();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedTransfer,Function :GetTranferList. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void GetTranferListByDays()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                dtCustomer = new BALCustomerMaster().SelectTransferCustomerListByDays(new BOLCustomerMaster() { FromDate = dtpFromDate.Value, ToDate = dtpToDate.Value });
                if (dtCustomer.Rows.Count > 0)
                {
                    int j = 0;
                    dgvCustomer.Rows.Clear();
                    for (int i = 0; i < dtCustomer.Rows.Count; i++)
                    {
                        dgvCustomer.Rows.Add();
                        dgvCustomer.Rows[j].Cells[0].Value = dtCustomer.Rows[i]["ID"].ToString();
                        dgvCustomer.Rows[j].Cells[2].Value = dtCustomer.Rows[i]["FullName"].ToString();
                        dgvCustomer.Rows[j].Cells[3].Value = dtCustomer.Rows[i]["CompanyName"].ToString();
                        dgvCustomer.Rows[j].Cells[4].Value = dtCustomer.Rows[i]["Phone"].ToString();
                        dgvCustomer.Rows[j].Cells[5].Value = dtCustomer.Rows[i]["Email"].ToString();
                        dgvCustomer.Rows[j].Cells[6].Value = dtCustomer.Rows[i]["SalesRepName"].ToString();
                        j++;
                    }
                }
                else
                    dgvCustomer.Rows.Clear();
                lblTotal.Text = dtCustomer.Rows.Count.ToString();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedTransfer,Function :GetTranferList. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void GetAssignListByDays()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                dtCustomer = new BALCustomerMaster().SelectAssignCustomerByDays(new BOLCustomerMaster() { FromDate = dtpFromDate.Value, ToDate = dtpToDate.Value });
                if (dtCustomer.Rows.Count > 0)
                {
                    int j = 0;
                    dgvCustomer.Rows.Clear();
                    for (int i = 0; i < dtCustomer.Rows.Count; i++)
                    {
                        dgvCustomer.Rows.Add();
                        dgvCustomer.Rows[j].Cells[0].Value = dtCustomer.Rows[i]["ID"].ToString();
                        dgvCustomer.Rows[j].Cells[2].Value = dtCustomer.Rows[i]["FullName"].ToString();
                        dgvCustomer.Rows[j].Cells[3].Value = dtCustomer.Rows[i]["CompanyName"].ToString();
                        dgvCustomer.Rows[j].Cells[4].Value = dtCustomer.Rows[i]["Phone"].ToString();
                        dgvCustomer.Rows[j].Cells[5].Value = dtCustomer.Rows[i]["Email"].ToString();                       
                        j++;
                    }
                }
                else
                    dgvCustomer.Rows.Clear();
                lblTotal.Text = dtCustomer.Rows.Count.ToString();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedTransfer,Function :GetTranferList. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

      
    }
}