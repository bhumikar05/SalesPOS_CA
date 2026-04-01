using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmCustomerAssignedList : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtCustomer = new DataTable();
        DataTable dtSalesRep = new DataTable();
        BALCustomerMaster objBAlCustomer = new BALCustomerMaster();
        BOLCustomerMaster objBOLCustomer = new BOLCustomerMaster();

        public FrmCustomerAssignedList()
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


                //DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
                //checkboxColumn.Width = 30;
                //checkboxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgvCustomer.Columns.Insert(0, checkboxColumn);

                //// add checkbox header
                //Rectangle rect = dgvCustomer.GetCellDisplayRectangle(0, -1, true);

                //// set checkbox header to center of header cell. +1 pixel to position correctly.
                //rect.X = rect.Location.X + 8;
                //rect.Y = rect.Location.Y + 10;
                //rect.Width = rect.Size.Width;
                //rect.Height = rect.Size.Height;

                //CheckBox checkboxHeader = new CheckBox();
                //checkboxHeader.Name = "checkboxHeader";
                //checkboxHeader.Size = new Size(15, 15);
                //checkboxHeader.Location = rect.Location;
                //checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);

                //dgvCustomer.Controls.Add(checkboxHeader);
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedList,Function :FrmCustomerAssignedList_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        //private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        //{
        //    dgvCustomer.EndEdit();

        //    ////Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
        //    foreach (DataGridViewRow row in dgvCustomer.Rows)
        //    {
        //        if (Convert.ToBoolean(row.Cells["checkboxHeader"].EditedFormattedValue) == false)
        //        {
        //            //isChecked = false;
        //            break;
        //        }
        //    }
        //}

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
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedList,Function :GetAllSalesRep. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void GetUnAssignedCustomer()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                dtCustomer = new BALCustomerMaster().SelectUnAssignedCustomerList(new BOLCustomerMaster() { });
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
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedList,Function :GetUnAssignedCustomer. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void GetAssignedCustomer()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                dtCustomer = new BALCustomerMaster().SelectAssignedCustomerList(new BOLCustomerMaster() { SalesRepID = Convert.ToInt32(cmbSalesRepName.SelectedValue) });
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
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedList,Function :GetAssignedCustomer. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private Boolean CheckValidation()
        {
            Boolean ISValid = false;
            try
            {
                if (cmbSalesRepName.SelectedIndex < 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select SalesRepName");
                    cmbSalesRepName.Focus();
                    goto Final;
                }
                else if (rdbPullOut.Checked == true && rdbPullIn.Checked == true)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select PullOut Or PullIn");
                    rdbPullOut.Focus();
                    goto Final;
                }
                else
                    ISValid = true;

                Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedList,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }

        private void rdbPullOut_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbPullOut.Checked == true)
                {
                    GetUnAssignedCustomer();
                    btnPullOut.Enabled = true;
                    btnPullIn.Enabled = false;
                }
                else
                    dgvCustomer.Rows.Clear();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedList,Function :rdbPullOut_CheckedChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void rdbPullIn_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbPullIn.Checked == true && cmbSalesRepName.SelectedIndex > 0)
                {
                    GetAssignedCustomer();
                    btnPullOut.Enabled = false;
                    btnPullIn.Enabled = true;
                }
                else
                    dgvCustomer.Rows.Clear();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedList,Function :rdbPullIn_CheckedChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgvCustomer_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void btnPullOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("PullOut", "AssignedCustomerList"))
                {
                    if (CheckValidation())
                    {
                        for (int j = 0; j < dgvCustomer.Rows.Count; j++)
                        {
                            DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dgvCustomer.Rows[j].Cells["ChkSelect"];
                            if (checkCell.Value != null)
                            {
                                if (checkCell.Value.ToString().ToLower() == "true")
                                {
                                    DataTable dtCus = new BALCustomerMaster().SelectParentAndChildCustomer(new BOLCustomerMaster() { ID = Convert.ToInt32(dgvCustomer.Rows[j].Cells["ID"].Value.ToString()) });
                                    if (dtCus.Rows.Count > 0)
                                    {
                                        for (int i = 0; i < dtCus.Rows.Count; i++)
                                        {
                                            objBOLCustomer.ID = Convert.ToInt32(dtCus.Rows[i]["ID"].ToString());
                                            objBOLCustomer.SalesRepID = Convert.ToInt32(cmbSalesRepName.SelectedValue);
                                            objBAlCustomer.UpdateSalesRepID(objBOLCustomer);
                                        }
                                    }
                                }
                            }
                        }
                        chkAll.Checked = false;
                        MessageBox.Show("Customer assigned successfully");
                        GetUnAssignedCustomer();
                    }
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedList,Function :btnPullOut_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnPullIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("PullIn", "AssignedCustomerList"))
                {
                    if (CheckValidation())
                    {
                        for (int j = 0; j < dgvCustomer.Rows.Count; j++)
                        {
                            DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dgvCustomer.Rows[j].Cells["ChkSelect"];
                            if (checkCell.Value != null)
                            {
                                if (checkCell.Value.ToString() == "True")
                                {
                                    DataTable dtCus = new BALCustomerMaster().SelectParentAndChildCustomer(new BOLCustomerMaster() { ID = Convert.ToInt32(dgvCustomer.Rows[j].Cells["ID"].Value.ToString()) });
                                    if (dtCus.Rows.Count > 0)
                                    {
                                        for (int i = 0; i < dtCus.Rows.Count; i++)
                                        {
                                            objBOLCustomer.ID = Convert.ToInt32(dtCus.Rows[i]["ID"].ToString());
                                            objBOLCustomer.SalesRepID = 0;
                                            objBAlCustomer.UpdateSalesRepID(objBOLCustomer);
                                        }
                                    }
                                }
                            }
                        }
                        chkAll.Checked = false;
                        MessageBox.Show("Customer Unassigned successfully");
                        GetAssignedCustomer();
                    }
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedList,Function :btnPullIn_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void cmbSalesRepName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSalesRepName.SelectedIndex > 0)
                {
                    if (rdbPullIn.Checked == true)
                        GetAssignedCustomer();
                    else if (rdbPullOut.Checked == true)
                        GetUnAssignedCustomer();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmCustomerAssignedList,Function :cmbSalesRepName_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
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
                        j++;
                    }
                }
                else
                {
                    dgvCustomer.Rows.Clear();
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
    }
}