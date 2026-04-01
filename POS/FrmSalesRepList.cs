using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmSalesRepList : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dt = new DataTable();
        BALSalesRepMaster ObjUserBAL = new BALSalesRepMaster();
        BOLSalesRepMaster ObjUserBOL = new BOLSalesRepMaster();
        BALAddressMaster ObjAddressBAL = new BALAddressMaster();
        BOLAddressMaster ObjAddressBOL = new BOLAddressMaster();
        BALPriceTier ObjPriceBAL = new BALPriceTier();
        BOLPriceTire ObjPriceBOL = new BOLPriceTire();

        public FrmSalesRepList()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 50);
            LoadSalesRep();
        }

        public void LoadFunction()
        {
            LoadSalesRep();
        }

        private void FrmSalesRepList_Load(object sender, EventArgs e)
        {
            this.dgvSalesRep.DefaultCellStyle.Font = new Font("", 10);
            dgvSalesRep.RowTemplate.Height = 24;
            dgvSalesRep.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvSalesRep.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            dgvSalesRep.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvSalesRep.EnableHeadersVisualStyles = false;
        }

        public void LoadSalesRep()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                txtSalesRepName.Text = "";
                DataTable dtActive = new BALSalesRepMaster().SelectInActiveUser(new BOLSalesRepMaster() { });
                if (dtActive.Rows.Count == 0)
                    chkActive.Enabled = false;
                else
                    chkActive.Enabled = true;

                if (chkActive.Checked == true)
                {
                    dt = new BALSalesRepMaster().Select(new BOLSalesRepMaster() { });
                    if (dt.Rows.Count > 0)
                    {
                        int j = 0;
                        dgvSalesRep.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dgvSalesRep.Rows.Add();
                            dgvSalesRep.Rows[j].Cells[0].Value = dt.Rows[i]["ID"].ToString();
                            if (dt.Rows[i]["IsActive"].ToString() == "0")
                                dgvSalesRep.Rows[j].Cells[1].Value = "X";
                            else
                                dgvSalesRep.Rows[j].Cells[1].Value = "";
                            dgvSalesRep.Rows[j].Cells[2].Value = dt.Rows[i]["Name"].ToString();
                            dgvSalesRep.Rows[j].Cells[3].Value = dt.Rows[i]["UserName"].ToString();
                            dgvSalesRep.Rows[j].Cells[4].Value = dt.Rows[i]["CompanyName"].ToString();
                            dgvSalesRep.Rows[j].Cells[5].Value = dt.Rows[i]["Phone"].ToString();
                            dgvSalesRep.Rows[j].Cells[6].Value = dt.Rows[i]["Email"].ToString();
                            dgvSalesRep.Rows[j].Cells[7].Value = dt.Rows[i]["UserType"].ToString();
                            if(dt.Rows[i]["LowestPriceAllow"].ToString() == "1")
                            {
                                dgvSalesRep.Rows[j].Cells[10].Value = true;
                            }                  
                            j++;
                        }
                    }
                    else
                    {
                        dgvSalesRep.Rows.Clear();
                    }
                }
                else
                {
                    dt = new BALSalesRepMaster().SelectActiveUser(new BOLSalesRepMaster() { });
                    if (dt.Rows.Count > 0)
                    {
                        int j = 0;
                        dgvSalesRep.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dgvSalesRep.Rows.Add();
                            dgvSalesRep.Rows[j].Cells[0].Value = dt.Rows[i]["ID"].ToString();
                            if (dt.Rows[i]["IsActive"].ToString() == "0")
                                dgvSalesRep.Rows[j].Cells[1].Value = "X";
                            else
                                dgvSalesRep.Rows[j].Cells[1].Value = "";
                            dgvSalesRep.Rows[j].Cells[2].Value = dt.Rows[i]["Name"].ToString();
                            dgvSalesRep.Rows[j].Cells[3].Value = dt.Rows[i]["UserName"].ToString();
                            dgvSalesRep.Rows[j].Cells[4].Value = dt.Rows[i]["CompanyName"].ToString();
                            dgvSalesRep.Rows[j].Cells[5].Value = dt.Rows[i]["Phone"].ToString();
                            dgvSalesRep.Rows[j].Cells[6].Value = dt.Rows[i]["Email"].ToString();
                            dgvSalesRep.Rows[j].Cells[7].Value = dt.Rows[i]["UserType"].ToString();
                            if (dt.Rows[i]["LowestPriceAllow"].ToString() == "1")
                            {
                                dgvSalesRep.Rows[j].Cells[10].Value = true;
                            }
                            j++;
                        }
                    }
                    else
                    {
                        dgvSalesRep.Rows.Clear();
                    }
                }
                Cursor.Current = Cursors.Default;
                lblTotal.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ClsCommon.WriteErrorLogs("Form:FrmSalesRepList, Function :LoadSalesRep. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (txtSalesRepName.Text != "")
            {
                LoadSalesRep();
                txtSalesRepName.Text = "";
            }
        }

        private void txtSalesRepName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSalesRepName.Text != "")
                {
                    DataRow[] row = dt.Select("Name like '%" + txtSalesRepName.Text + "%'");
                    if (row.Length > 0)
                    {
                        DataTable dtNew = row.CopyToDataTable();

                        int j = 0;
                        dgvSalesRep.Rows.Clear();
                        for (int i = 0; i < dtNew.Rows.Count; i++)
                        {
                            dgvSalesRep.Rows.Add();
                            dgvSalesRep.Rows[j].Cells[0].Value = dtNew.Rows[i]["ID"].ToString();
                            if (dt.Rows[i]["IsActive"].ToString() == "0")
                                dgvSalesRep.Rows[j].Cells[1].Value = "X";
                            else
                                dgvSalesRep.Rows[j].Cells[1].Value = "";
                            dgvSalesRep.Rows[j].Cells[2].Value = dtNew.Rows[i]["Name"].ToString();
                            dgvSalesRep.Rows[j].Cells[3].Value = dtNew.Rows[i]["UserName"].ToString();
                            dgvSalesRep.Rows[j].Cells[4].Value = dtNew.Rows[i]["CompanyName"].ToString();
                            dgvSalesRep.Rows[j].Cells[5].Value = dtNew.Rows[i]["Phone"].ToString();
                            dgvSalesRep.Rows[j].Cells[6].Value = dtNew.Rows[i]["Email"].ToString();
                            dgvSalesRep.Rows[j].Cells[7].Value = dtNew.Rows[i]["UserType"].ToString();
                            j++;
                        }
                        lblTotal.Text = dtNew.Rows.Count.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmSalesRepList,Function :txtSalesRepName_TextChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (ClsCommon.FunctionVisibility("Insert", "SalesRepList"))
            {
                ClsCommon.ObjSalesRepMaster.Show();
                ClsCommon.ObjSalesRepMaster.GetUserType();
            }
            else
                MessageBox.Show("You can not access");
        }

        private void btmClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSalesRep_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 8)
                {
                    if (ClsCommon.FunctionVisibility("Update", "SalesRepList"))
                    {
                        ClsCommon.ObjSalesRepMaster.LoadData(dgvSalesRep.CurrentRow.Cells["ID"].Value.ToString());
                        ClsCommon.ObjSalesRepMaster.Show();
                        LoadSalesRep();
                    }
                    else
                        MessageBox.Show("You can not access");
                }

                else if(e.ColumnIndex == 9)
                {
                    FrmPriceTier f2 = new FrmPriceTier();
                    f2.SalesRepID = dgvSalesRep.CurrentRow.Cells[0].Value.ToString();
                    f2.SalesRepName = dgvSalesRep.CurrentRow.Cells[2].Value.ToString();
                    dt = ObjPriceBAL.SelectByRepID(Convert.ToInt32(dgvSalesRep.CurrentRow.Cells[0].Value.ToString()));
                    if(dt.Rows.Count > 0)
                    {
                        f2.Display(dt);
                    }
                    f2.Show();
                }
                //else if (e.ColumnIndex == 9)
                //{
                //    DialogResult result = MessageBox.Show("Are you sure to delete this record?", "Confirmation", MessageBoxButtons.YesNo);
                //    if (result == DialogResult.Yes)
                //    {
                //        ObjUserBOL.ID = Convert.ToInt32(dgvSalesRep.CurrentRow.Cells["ID"].Value.ToString());
                //        ObjAddressBOL.ReferenceID = Convert.ToInt32(dgvSalesRep.CurrentRow.Cells["ID"].Value.ToString());
                //        ObjUserBAL.Delete(ObjUserBOL);
                //        ObjAddressBAL.SalesRepDelete(ObjAddressBOL);
                //        MessageBox.Show("Record delete successfully");
                //        StartProcess();
                //    }
                //}
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmSalesRepList,Function :dgvSalesRep_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadSalesRep();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmSalesRepList,Function :chkActive_CheckedChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void dgvSalesRep_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void FrmSalesRepList_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClsCommon.ObjSalesRepList.Hide();
            ClsCommon.ObjSalesRepList.Parent = null;
            e.Cancel = true;
        }

      
    }
}