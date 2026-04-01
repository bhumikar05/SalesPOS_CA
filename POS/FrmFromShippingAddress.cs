using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmFromShippingAddress : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtLoadData = new DataTable();
        BALFromShipping ObjShippingBAL = new BALFromShipping();
        BOLFromShipping ObjShippingBOL = new BOLFromShipping();
        public string Mode = "insert";

        public FrmFromShippingAddress()
        {
            InitializeComponent();
        }

        private void FrmFromShipping_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFromShipping();

                ////Edit Button
                //DataGridViewLinkColumn EditLink = new DataGridViewLinkColumn();
                //EditLink.UseColumnTextForLinkValue = true;
                //EditLink.HeaderText = "Edit";
                //EditLink.DataPropertyName = "Edit";
                //EditLink.Text = "Edit";
                //dgvFromShipping.Columns.Add(EditLink);


                ////Delete Button
                //DataGridViewLinkColumn DeleteLink = new DataGridViewLinkColumn();
                //EditLink.UseColumnTextForLinkValue = true;
                //EditLink.HeaderText = "Delete";
                //EditLink.DataPropertyName = "Delete";
                //EditLink.Text = "Delete";
                //dgvFromShipping.Columns.Add(DeleteLink);

                // Edit Button
                DataGridViewLinkColumn EditLink = new DataGridViewLinkColumn();
                EditLink.Name = "Edit";                 // ⭐ important
                EditLink.HeaderText = "Edit";
                EditLink.DataPropertyName = "Edit";
                EditLink.Text = "Edit";
                EditLink.UseColumnTextForLinkValue = true;
                dgvFromShipping.Columns.Add(EditLink);

                // Delete Button
                DataGridViewLinkColumn DeleteLink = new DataGridViewLinkColumn();
                DeleteLink.Name = "Delete";             // ⭐ important
                DeleteLink.DataPropertyName = "Delete";
                DeleteLink.HeaderText = "Delete";
                DeleteLink.Text = "Delete";
                DeleteLink.UseColumnTextForLinkValue = true;
                dgvFromShipping.Columns.Add(DeleteLink);

                this.dgvFromShipping.DefaultCellStyle.Font = new Font("", 10);
                dgvFromShipping.RowTemplate.Height = 25;
                dgvFromShipping.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvFromShipping.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                dgvFromShipping.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                dgvFromShipping.EnableHeadersVisualStyles = false;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFromShippingAdddress,Function :FrmFromShipping_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        public void LoadFunction()
        {
            try
            {
                Clear();
                LoadFromShipping();
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFromShippingAdddress,Function :LoadFunction. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void Clear()
        {
            try
            {


                txtCompanyName.Text = "";
                txtName.Text = "";
                txtAddress1.Text = "";
                txtAddress2.Text = "";
                txtCity.Text = "";
                txtState.Text = "";
                txtZip.Text = "";
                txtCountry.Text = "";
                txtPhone.Text = "";
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFromShippingAdddress,Function :Clear. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private Boolean CheckValidation()
        {
           
            Boolean ISValid = false;
            try
            {
                if (rdbFedEx.Checked == false && rdbUPS.Checked == false)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select FedEx or UPS UserID", "W");
                    rdbFedEx.Focus();
                }
                else if (txtCompanyName.Text.Trim() == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter Company Name");
                    txtCompanyName.Focus();
                    goto Final;
                }
                else if (txtName.Text.Trim() == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter Name");
                    txtName.Focus();
                    goto Final;
                }
                else if (txtAddress1.Text.Trim() == "")
                {
                    ISValid = false;
                    txtAddress1.Focus();
                    MessageBox.Show("Please Enter Address");
                }
                else if (txtCity.Text.Trim() == "")
                {
                    ISValid = false;
                    txtCity.Focus();
                    MessageBox.Show("Please Enter City");
                }
                else if (txtState.Text.Trim() == "")
                {
                    ISValid = false;
                    txtState.Focus();
                    MessageBox.Show("Please Enter State");
                }
                else if (txtZip.Text.Trim() == "")
                {
                    ISValid = false;
                    txtZip.Focus();
                    MessageBox.Show("Please Enter Postal Code");
                }
                else if (txtPhone.Text.Trim() == "")
                {
                    ISValid = false;
                    txtPhone.Focus();
                    MessageBox.Show("Please Enter PhoneNo");
                }
                else if (txtPhone.Text != "" && txtPhone.TextLength < 10)
                {
                    MessageBox.Show("Please enter 10 digit number");
                    ISValid = false;
                    txtPhone.Focus();
                }
                else if (txtCountry.Text.Trim() == "")
                {
                    ISValid = false;
                    txtCountry.Focus();
                    MessageBox.Show("Please Enter Country");
                }
                else
                    ISValid = true;

                Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFromShippingAddress,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }

        public void LoadData(string ID)
        {
            try
            {
                Mode = "update";
                dtLoadData = new DataTable();
                dtLoadData = new BALFromShipping().SelectByID(new BOLFromShipping() { ID = Convert.ToInt32(ID) });
                if (dtLoadData.Rows.Count > 0)
                {
                    txtID.Text = dtLoadData.Rows[0]["ID"].ToString();
                    if (dtLoadData.Rows[0]["FromAddress"].ToString() == "FedEx")
                        rdbFedEx.Checked = true;
                    else
                        rdbUPS.Checked = true;
                    txtCompanyName.Text = dtLoadData.Rows[0]["CompanyName"].ToString();
                    txtName.Text = dtLoadData.Rows[0]["Name"].ToString();
                    txtAddress1.Text = dtLoadData.Rows[0]["Address1"].ToString();
                    txtAddress2.Text = dtLoadData.Rows[0]["Address2"].ToString();
                    txtCity.Text = dtLoadData.Rows[0]["City"].ToString();
                    txtState.Text = dtLoadData.Rows[0]["State"].ToString();
                    txtZip.Text = dtLoadData.Rows[0]["Zip"].ToString();
                    txtPhone.Text = dtLoadData.Rows[0]["Phone"].ToString();
                    txtCountry.Text = dtLoadData.Rows[0]["Country"].ToString();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFromShippingAdddress,Function :LoadData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void LoadFromShipping()
        {
            try
            {
                DataTable dt = new BALFromShipping().Select(new BOLFromShipping() { });
                if (dt.Rows.Count > 0)
                {
                    int j = 0;
                    dgvFromShipping.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvFromShipping.Rows.Add();
                        dgvFromShipping.Rows[j].Cells[0].Value = dt.Rows[i]["ID"].ToString();
                        dgvFromShipping.Rows[j].Cells[1].Value = dt.Rows[i]["FromAddress"].ToString();
                        dgvFromShipping.Rows[j].Cells[2].Value = dt.Rows[i]["CompanyName"].ToString();
                        dgvFromShipping.Rows[j].Cells[3].Value = dt.Rows[i]["Name"].ToString();
                        dgvFromShipping.Rows[j].Cells[4].Value = dt.Rows[i]["Phone"].ToString();
                        dgvFromShipping.Rows[j].Cells[5].Value = dt.Rows[i]["Address"].ToString();
                        dgvFromShipping.Rows[j].Cells[6].Value = dt.Rows[i]["City"].ToString();
                        dgvFromShipping.Rows[j].Cells[7].Value = dt.Rows[i]["State"].ToString();
                        dgvFromShipping.Rows[j].Cells[8].Value = dt.Rows[i]["Zip"].ToString();
                        dgvFromShipping.Rows[j].Cells[9].Value = dt.Rows[i]["Country"].ToString();
                        j++;
                    }
                    Clear();
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFromShippingAddress,Function :LoadFromShipping. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidation())
                {
                    if (Mode == "insert")
                    {
                        // Insert
                        if (rdbFedEx.Checked == true)
                            ObjShippingBOL.FromAddress = "FedEx";
                        else
                            ObjShippingBOL.FromAddress = "UPS";
                        ObjShippingBOL.CompanyName = txtCompanyName.Text;
                        ObjShippingBOL.Name = txtName.Text;
                        ObjShippingBOL.Address1 = txtAddress1.Text;
                        ObjShippingBOL.Address2 = txtAddress2.Text;
                        ObjShippingBOL.City = txtCity.Text;
                        ObjShippingBOL.State = txtState.Text;
                        ObjShippingBOL.Zip = txtZip.Text;
                        ObjShippingBOL.Phone = txtPhone.Text;
                        ObjShippingBOL.Country = txtCountry.Text;
                        ObjShippingBOL.CreatedID = ClsCommon.UserID;
                        ObjShippingBAL.Insert(ObjShippingBOL);

                        MessageBox.Show("Record save successfully");
                        Clear();
                        LoadFromShipping();
                    }
                    else
                    {
                        //Update
                        ObjShippingBOL.ID = Convert.ToInt32(txtID.Text);
                        if (rdbFedEx.Checked == true)
                            ObjShippingBOL.FromAddress = "FedEx";
                        else
                            ObjShippingBOL.FromAddress = "UPS";
                        ObjShippingBOL.CompanyName = txtCompanyName.Text;
                        ObjShippingBOL.Name = txtName.Text;
                        ObjShippingBOL.Address1 = txtAddress1.Text;
                        ObjShippingBOL.Address2 = txtAddress2.Text;
                        ObjShippingBOL.City = txtCity.Text;
                        ObjShippingBOL.State = txtState.Text;
                        ObjShippingBOL.Zip = txtZip.Text;
                        ObjShippingBOL.Phone = txtPhone.Text;
                        ObjShippingBOL.Country = txtCountry.Text;
                        ObjShippingBOL.ModifiedID = ClsCommon.UserID;
                        ObjShippingBAL.Update(ObjShippingBOL);

                        MessageBox.Show("Record Update successfully");
                        Clear();
                        LoadFromShipping();
                        Mode = "insert";
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFromShippingAddress,Function :btnSave_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgvFromShipping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 10)
                {
                    LoadData(dgvFromShipping.CurrentRow.Cells["ID"].Value.ToString());
                }
                else if (e.ColumnIndex == 11)
                {
                    DialogResult result = MessageBox.Show("Are you sure to delete this record?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        new BALFromShipping().Delete(Convert.ToInt32(dgvFromShipping.CurrentRow.Cells["ID"].Value.ToString()));
                        MessageBox.Show("Record delete successfully");

                        //LoadData(dgvFromShipping.CurrentRow.Cells["ID"].Value.ToString());
                        LoadFromShipping();
                        Clear();
                        txtID.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFromShippingAddress,Function :dgvFromShipping_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void txtZip_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char c = e.KeyChar;

                // Allow letters/digits for Canadian postal codes (e.g., "K1A 0B1")
                // Also allow space/hyphen for common formatting.
                if (char.IsControl(c))
                    return;

                if (char.IsLetterOrDigit(c) || c == ' ' || c == '-')
                    return;

                e.Handled = true;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFromShippingAddress,Function :txtZip_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void FrmFromShippingAddress_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ClsCommon.objFromShipping.Hide();
                ClsCommon.objFromShipping.Parent = null;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmFromShippingAddress,Function :FrmFromShippingAddress_FormClosing. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}