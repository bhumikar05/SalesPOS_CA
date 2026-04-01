using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmEmailFormatList : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dt = new DataTable();
        BALEmailTemplate objEmailBAL = new BALEmailTemplate();
        BOLEmailTemplate objEmailBOL = new BOLEmailTemplate();

        public FrmEmailFormatList()
        {
            try
            {
                InitializeComponent();
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(0, 0);
                LoadEmailTemplate();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmEmailFormatList, Function :FrmEmailFormatList. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void LoadFunction()
        {
            LoadEmailTemplate();
        }

        private void FrmEmailTemplateList_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvEmailFormatList.DefaultCellStyle.Font = new Font("", 10);
                dgvEmailFormatList.RowTemplate.Height = 24;
                dgvEmailFormatList.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvEmailFormatList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                dgvEmailFormatList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                dgvEmailFormatList.EnableHeadersVisualStyles = false;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmEmailFormatList, Function :FrmEmailTemplateList_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void LoadEmailTemplate()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                dt = new DataTable();
                dt = new BALEmailTemplate().Select(new BOLEmailTemplate() { });
                if (dt.Rows.Count > 0)
                {
                    int j = 0;
                    dgvEmailFormatList.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvEmailFormatList.Rows.Add();
                        dgvEmailFormatList.Rows[j].Cells[0].Value = dt.Rows[i]["ID"].ToString();
                        dgvEmailFormatList.Rows[j].Cells[1].Value = dt.Rows[i]["TemplateType"].ToString();
                        dgvEmailFormatList.Rows[j].Cells[2].Value = dt.Rows[i]["TemplateName"].ToString();
                        dgvEmailFormatList.Rows[j].Cells[3].Value = dt.Rows[i]["Subject"].ToString();
                        j++;
                    }
                }
                else
                {
                    dgvEmailFormatList.Rows.Clear();
                }
                Cursor.Current = Cursors.Default;
                lblTotal.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmEmailFormatList, Function :LoadEmailTemplate. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTemplateName.Text != "")
                {
                    txtTemplateName.Text = "";
                    LoadEmailTemplate();
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmEmailFormatList, Function :btnReset_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
          
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtTemplateName.Text != "")
                {
                    DataRow[] row = dt.Select("TemplateName like '%" + txtTemplateName.Text + "%'");
                    if (row.Length > 0)
                    {
                        DataTable dtNew = row.CopyToDataTable();

                        int j = 0;
                        dgvEmailFormatList.Rows.Clear();
                        for (int i = 0; i < dtNew.Rows.Count; i++)
                        {
                            dgvEmailFormatList.Rows.Add();
                            dgvEmailFormatList.Rows[j].Cells[0].Value = dtNew.Rows[i]["ID"].ToString();
                            dgvEmailFormatList.Rows[j].Cells[1].Value = dtNew.Rows[i]["TemplateType"].ToString();
                            dgvEmailFormatList.Rows[j].Cells[2].Value = dtNew.Rows[i]["TemplateName"].ToString();
                            dgvEmailFormatList.Rows[j].Cells[3].Value = dtNew.Rows[i]["Subject"].ToString();
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
                ClsCommon.WriteErrorLogs("Form:FrmEmailFormatList,Function :btnSearch_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("Insert", "EmailTemplate"))
                {
                    FrmEmailFormat obj = new FrmEmailFormat();
                    obj.Mode = "insert";
                    obj.ShowDialog();
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
               
                ClsCommon.WriteErrorLogs("Form:FrmEmailFormatList,Function :btnAddNew_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvEmailFormatList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    if (ClsCommon.FunctionVisibility("Update", "EmailTemplate"))
                    {
                        FrmEmailFormat obj = new FrmEmailFormat();
                        obj.LoadData(dgvEmailFormatList.CurrentRow.Cells["ID"].Value.ToString());
                        obj.ShowDialog();
                        LoadEmailTemplate();
                    }
                    else
                        MessageBox.Show("You can not access");
                }
                else if (e.ColumnIndex == 5)
                {
                    if (ClsCommon.FunctionVisibility("Delete", "EmailTemplate"))
                    {
                        DialogResult result = MessageBox.Show("Are you sure to delete this record?", "Confirmation", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            objEmailBOL.ID = Convert.ToInt32(dgvEmailFormatList.CurrentRow.Cells["ID"].Value.ToString());
                            objEmailBAL.Delete(objEmailBOL);
                            MessageBox.Show("Record delete successfully");
                            LoadEmailTemplate();
                        }
                    }
                    else
                        MessageBox.Show("You can not access");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmEmailFormatList,Function :dgvEmailFormatList_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void FrmEmailTemplateList_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ClsCommon.ObjEmailFormatList.Hide();
                ClsCommon.ObjEmailFormatList.Parent = null;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmEmailFormatList,Function :FrmEmailTemplateList_FormClosing. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }
    }
}