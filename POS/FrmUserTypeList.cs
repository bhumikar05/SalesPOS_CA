using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmUserTypeList : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dt = new DataTable();
        BALUserType ObjUserBAL = new BALUserType();
        BOLUserType ObjUserBOL = new BOLUserType();
        public FrmUserTypeList()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
        }
        public void LoadUser()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                dt = new DataTable();
                dt = new BALUserType().Select(new BOLUserType() { });
                if (dt.Rows.Count > 0)
                {
                    int j = 0;
                    dgvUserType.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvUserType.Rows.Add();
                        dgvUserType.Rows[j].Cells[0].Value = dt.Rows[i]["ID"].ToString();
                        dgvUserType.Rows[j].Cells[1].Value = dt.Rows[i]["UserType"].ToString();
                        j++;
                    }
                }
                else
                {
                    dgvUserType.Rows.Clear();
                }
                lblTotal.Text = dt.Rows.Count.ToString();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmUserTypeList,Function :LoadUser. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void FrmUserTypeList_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClsCommon.ObjUserTypeList.Hide();
            ClsCommon.ObjUserTypeList.Parent = null;
            e.Cancel = true;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("Insert", "UserTypeList"))
                {
                    FrmUserType fUserType = new FrmUserType();
                    fUserType.Show();
                    LoadUser();
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUserTypeList,Function :btnAddNew_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void FrmUserTypeList_Load(object sender, EventArgs e)
        {
            try
            {
                dgvUserType.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvUserType.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                dgvUserType.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8F, FontStyle.Regular);
                dgvUserType.EnableHeadersVisualStyles = false;

                LoadUser();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUserTypeList,Function :FrmUserTypeList_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgvUserType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    if (ClsCommon.FunctionVisibility("Update", "UserTypeList"))
                    {
                        FrmUserType View = new FrmUserType();
                        View.LoadData(dgvUserType.CurrentRow.Cells["ID"].Value.ToString());
                        View.Show();
                        LoadUser();
                    }
                    else
                        MessageBox.Show("You can not access");
                }
                else if (e.ColumnIndex == 3)
                {
                    if (ClsCommon.FunctionVisibility("Delete", "UserTypeList"))
                    {
                        DialogResult result = MessageBox.Show("Are you sure to delete this record?", "Confirmation", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            DataTable dt = new BALSalesRepMaster().SelectByUserTypeID(new BOLSalesRepMaster() { UserTypeID = Convert.ToInt32(dgvUserType.CurrentRow.Cells["ID"].Value.ToString()) });
                            if (dt.Rows.Count == 0)
                            {
                                ObjUserBOL.ID = Convert.ToInt32(dgvUserType.CurrentRow.Cells["ID"].Value.ToString());
                                ObjUserBAL.Delete(ObjUserBOL);
                                MessageBox.Show("Record delete successfully");
                                LoadUser();
                            }
                            else
                            {
                                MessageBox.Show("UserType already use, so first delete salesrep", "Warning");
                            }
                        }
                    }
                    else
                        MessageBox.Show("You can not access");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUserType,Function :dgvUserType_CellContentDoubleClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}