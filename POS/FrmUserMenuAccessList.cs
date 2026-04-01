using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmUserMenuAccessList : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dt = new DataTable();
        BALUserMenuAccess ObjUserBAL = new BALUserMenuAccess();
        BOLUserMenuAccess ObjUserBOL = new BOLUserMenuAccess();
        BALUserSubMenuAccess ObjSubRoleBAL = new BALUserSubMenuAccess();
        BOLUserSubMenuAccess ObjSubRoleBOL = new BOLUserSubMenuAccess();

        public FrmUserMenuAccessList()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
        }

        private void FrmUserMenuAccessList_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgUserAccess.DefaultCellStyle.Font = new Font("", 10);
                dgUserAccess.RowTemplate.Height = 24;
                //dgUserAccess.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                //dgUserAccess.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                //dgUserAccess.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                //dgUserAccess.EnableHeadersVisualStyles = false;
                LoadUserAccess();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUserMenuAccessList,Function :FrmUserMenuAccessList_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void LoadUserAccess()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataTable dtUser = new BALUserMenuAccess().Select(new BOLUserMenuAccess() { });
                DataView view = new DataView(dtUser);
                dt = view.ToTable(true, "UserName", "UserID");
                if (dt.Rows.Count > 0)
                {
                    int j = 0;
                    dgUserAccess.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgUserAccess.Rows.Add();
                        dgUserAccess.Rows[j].Cells[0].Value = dt.Rows[i]["UserID"].ToString();
                        dgUserAccess.Rows[j].Cells[1].Value = dt.Rows[i]["UserName"].ToString();

                        j++;
                    }
                }
                else
                {
                    dgUserAccess.Rows.Clear();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmUserMenuAccessList,Function :LoadUserAccess. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                LoadUserAccess();
                txtSearch.Text = "";
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow[] row = dt.Select("UserName like '%" + txtSearch.Text + "%'");
                dgUserAccess.Rows.Clear();
                if (row.Length > 0)
                {
                    DataTable dtNew = row.CopyToDataTable();

                    int j = 0;
                 
                    for (int i = 0; i < dtNew.Rows.Count; i++)
                    {
                        dgUserAccess.Rows.Add();
                        dgUserAccess.Rows[j].Cells[0].Value = dtNew.Rows[i]["UserID"].ToString();
                        dgUserAccess.Rows[j].Cells[1].Value = dtNew.Rows[i]["UserName"].ToString();

                        j++;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUserMenuAccessList,Function :txtSearch_TextChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

        private void dgUserAccess_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    if (ClsCommon.FunctionVisibility("Update", "AllUserAccess"))
                    {
                        FrmUserAccess View = new FrmUserAccess();
                        View.Location = new Point(0, 50);
                        View.ShowFile(dgUserAccess.CurrentRow.Cells[0].Value.ToString());
                        View.Show();
                    }
                    else
                        MessageBox.Show("You can not access");
                }
                else if (e.ColumnIndex == 3)
                {
                    if (ClsCommon.FunctionVisibility("Delete", "AllUserAccess"))
                    {
                        DialogResult result = MessageBox.Show("Are you sure to delete this record?", "Confirmation", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            ObjUserBOL.UserID = Convert.ToInt32(dgUserAccess.CurrentRow.Cells[0].Value.ToString());
                            ObjUserBAL.Delete(ObjUserBOL);
                            ObjSubRoleBOL.UserID = Convert.ToInt32(dgUserAccess.CurrentRow.Cells[0].Value.ToString());
                            ObjSubRoleBAL.Delete(ObjSubRoleBOL);
                            MessageBox.Show("Record delete successfully");
                            LoadUserAccess();
                        }
                    }
                    else
                        MessageBox.Show("You can not access");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUserMenuAccessList,Function :dgUserAccess_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

       
    }
}