using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmShippingAddress : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public DataTable dtAddress = new DataTable();
        BALSalesRepMaster ObjUserBAL = new BALSalesRepMaster();
        BOLSalesRepMaster ObjUserBOL = new BOLSalesRepMaster();
        public string CustomerName = "";
        public string ShipAddressName = "";
        public string Mode = "";
        public string ID = "";
        public bool Isclose=false;
        public bool isOk=false;

        public FrmShippingAddress()
        {
            InitializeComponent();
        }

        private void FrmShippingAddress_Load(object sender, EventArgs e)
        {
            
            lblName.Text = CustomerName;
            txtAddressName.Text = ShipAddressName;
        }

        private void pnlShippingAddress_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pnlShippingAddress.ClientRectangle, Color.Gainsboro, ButtonBorderStyle.Solid);
        }

        private Boolean CheckValidation()
        {
            Boolean ISValid = false;
            try
            {
                if (txtAddressName.Text == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter AddressName");
                    txtAddressName.Focus();
                    goto Final;
                }
                else if (lblName.Text == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter Name");
                    lblName.Focus();
                    goto Final;
                }
                else if (txtAddress.Text == "" && txtCity.Text == "" && txtState.Text == "" && txtZipCode.Text == "" && txtCountry.Text == "" && txtNote.Text == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Add Address Details");
                    txtAddress.Focus();
                    goto Final;
                }
                else
                    ISValid = true;

                Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmShippingAddress,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }

        public void LoadAddress()
        {
            try
            {
                
                if (dtAddress.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtAddress.Rows)
                    {
                        if ((dr["ID"].ToString() == ID || ID == "0") && ShipAddressName == dr["AddressName"].ToString())
                        {
                            txtAddress.Text = ""; txtCity.Text = ""; txtState.Text = ""; txtZipCode.Text = ""; txtCountry.Text = ""; txtNote.Text = "";
                            txtID.Text = dr["ID"].ToString();
                            if (dr["Address1"].ToString() != "")
                                txtAddress.Text = dr["Address1"].ToString();
                            if (dr["Address2"].ToString() != "")
                                txtAddress.Text = dr["Address2"].ToString();
                            if (dr["Address1"].ToString() != "" && dr["Address2"].ToString() != "")
                                txtAddress.Text = dr["Address1"].ToString() + "\r\n" + dr["Address2"].ToString();
                            if (dr["Address1"].ToString() != "" && dr["Address2"].ToString() != "" && dr["Address3"].ToString() != "")
                                txtAddress.Text = dr["Address1"].ToString() + "\r\n" + dr["Address2"].ToString() + "\r\n" + dr["Address3"].ToString();
                            if (dr["City"].ToString() != "")
                                txtCity.Text = dr["City"].ToString();
                            if (dr["State"].ToString() != "")
                                txtState.Text = dr["State"].ToString();
                            if (dr["ZipCode"].ToString() != "")
                                txtZipCode.Text = dr["ZipCode"].ToString();
                            if (dr["Country"].ToString() != "")
                                txtCountry.Text = dr["Country"].ToString();
                            if (dr["Note"].ToString() != "")
                                txtNote.Text = dr["Note"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmShippingAddress, Function: LoadAddress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void LoadAddr()
        {
            try
            {
                if (Mode == "Copy")
                {
                    // Copy Address
                    if (dtAddress.Rows.Count > 0)
                    {
                        foreach (DataRow drCopy in dtAddress.Rows)
                        {
                            if (drCopy["AddressName"].ToString() == null || drCopy["AddressName"].ToString() == "")
                            {
                                drCopy["AddressName"] = txtAddressName.Text.Trim();
                                string[] str = txtAddress.Text.Split('\n');
                                if (str.Length == 1)
                                {
                                    drCopy["Address1"] = str[0].ToString().Replace("\r", "");
                                    drCopy["Address2"] = "";
                                    drCopy["Address3"] = "";
                                }
                                else if (str.Length == 2)
                                {
                                    drCopy["Address1"] = str[0].ToString().Replace("\r", "");
                                    drCopy["Address2"] = str[1].ToString().Replace("\r", "");
                                    drCopy["Address3"] = "";
                                }
                                else if (str.Length == 3)
                                {
                                    drCopy["Address1"] = str[0].ToString().Replace("\r", "");
                                    drCopy["Address2"] = str[1].ToString().Replace("\r", "");
                                    drCopy["Address3"] = str[2].ToString().Replace("\r", "");
                                }
                                else if (str.Length == 4)
                                {
                                    drCopy["Address1"] = str[0].ToString().Replace("\r", "");
                                    drCopy["Address2"] = str[1].ToString().Replace("\r", "");
                                    drCopy["Address3"] = str[2].ToString().Replace("\r", "") + "," + str[3].ToString().Replace("\r", "");
                                }
                                else if (str.Length == 5)
                                {
                                    drCopy["Address1"] = str[0].ToString().Replace("\r", "");
                                    drCopy["Address2"] = str[1].ToString().Replace("\r", "");
                                    drCopy["Address3"] = str[2].ToString().Replace("\r", "") + "," + str[3].ToString().Replace("\r", "") + "," + str[4].ToString().Replace("\r", "");
                                }
                                drCopy["City"] = txtCity.Text;
                                drCopy["State"] = txtState.Text;
                                drCopy["ZipCode"] = txtZipCode.Text;
                                drCopy["Country"] = txtCountry.Text;
                                drCopy["Note"] = txtNote.Text;
                            }
                            this.Close();
                        }
                    }
                }
                else if (Mode == "update")
                {
                    ClsCommon.ObjCustomerMaster.IsAddress = false;

                    // Update Address
                    DataRow[] row = dtAddress.Select("AddressName = '" + txtAddressName.Text.Trim() + "'");
                    if (row.Length > 0)
                    {
                        foreach (DataRow dr in row)
                        {
                            if (dr["ID"].ToString() != ID)
                            {
                                MessageBox.Show("Ship Address Name is already being Used. Please use a different Ship Address Name", "Ship To Address Name Conflict");
                                txtAddressName.Focus();
                            }
                            else
                            {
                                if (dtAddress.Rows.Count > 0)
                                {
                                    foreach (DataRow drCopy in dtAddress.Rows)
                                    {
                                        if (drCopy["ID"].ToString() == ID && drCopy["AddressName"].ToString() == txtAddressName.Text)
                                        {
                                            drCopy["AddressName"] = txtAddressName.Text.Trim();
                                            string[] str = txtAddress.Text.Split('\n');
                                            if (str.Length == 1)
                                            {
                                                drCopy["Address1"] = str[0].ToString().Replace("\r", "");
                                                drCopy["Address2"] = "";
                                                drCopy["Address3"] = "";
                                            }
                                            else if (str.Length == 2)
                                            {
                                                drCopy["Address1"] = str[0].ToString().Replace("\r", "");
                                                drCopy["Address2"] = str[1].ToString().Replace("\r", "");
                                                drCopy["Address3"] = "";
                                            }
                                            else if (str.Length == 3)
                                            {
                                                drCopy["Address1"] = str[0].ToString().Replace("\r", "");
                                                drCopy["Address2"] = str[1].ToString().Replace("\r", "");
                                                drCopy["Address3"] = str[2].ToString().Replace("\r", "");
                                            }
                                            else if (str.Length == 4)
                                            {
                                                drCopy["Address1"] = str[0].ToString().Replace("\r", "");
                                                drCopy["Address2"] = str[1].ToString().Replace("\r", "");
                                                drCopy["Address3"] = str[2].ToString().Replace("\r", "") + "," + str[3].ToString().Replace("\r", "");
                                            }
                                            else if (str.Length == 5)
                                            {
                                                drCopy["Address1"] = str[0].ToString().Replace("\r", "");
                                                drCopy["Address2"] = str[1].ToString().Replace("\r", "");
                                                drCopy["Address3"] = str[2].ToString().Replace("\r", "") + "," + str[3].ToString().Replace("\r", "") + "," + str[4].ToString().Replace("\r", "");
                                            }
                                            drCopy["City"] = txtCity.Text;
                                            drCopy["State"] = txtState.Text;
                                            drCopy["ZipCode"] = txtZipCode.Text;
                                            drCopy["Country"] = txtCountry.Text;
                                            drCopy["Note"] = txtNote.Text;

                                            this.Close();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (dtAddress.Rows.Count > 0)
                        {
                            foreach (DataRow drCopy in dtAddress.Rows)
                            {
                                if (drCopy["ID"].ToString() == ID)
                                {
                                    drCopy["AddressName"] = txtAddressName.Text.Trim();
                                    string[] str = txtAddress.Text.Split('\n');
                                    if (str.Length == 1)
                                    {
                                        drCopy["Address1"] = str[0].ToString().Replace("\r", "");
                                        drCopy["Address2"] = "";
                                        drCopy["Address3"] = "";
                                    }
                                    else if (str.Length == 2)
                                    {
                                        drCopy["Address1"] = str[0].ToString().Replace("\r", "");
                                        drCopy["Address2"] = str[1].ToString().Replace("\r", "");
                                        drCopy["Address3"] = "";
                                    }
                                    else if (str.Length == 3)
                                    {
                                        drCopy["Address1"] = str[0].ToString().Replace("\r", "");
                                        drCopy["Address2"] = str[1].ToString().Replace("\r", "");
                                        drCopy["Address3"] = str[2].ToString().Replace("\r", "");
                                    }
                                    else if (str.Length == 4)
                                    {
                                        drCopy["Address1"] = str[0].ToString().Replace("\r", "");
                                        drCopy["Address2"] = str[1].ToString().Replace("\r", "");
                                        drCopy["Address3"] = str[2].ToString().Replace("\r", "") + "," + str[3].ToString().Replace("\r", "");
                                    }
                                    else if (str.Length == 5)
                                    {
                                        drCopy["Address1"] = str[0].ToString().Replace("\r", "");
                                        drCopy["Address2"] = str[1].ToString().Replace("\r", "");
                                        drCopy["Address3"] = str[2].ToString().Replace("\r", "") + "," + str[3].ToString().Replace("\r", "") + "," + str[4].ToString().Replace("\r", "");
                                    }
                                    drCopy["City"] = txtCity.Text;
                                    drCopy["State"] = txtState.Text;
                                    drCopy["ZipCode"] = txtZipCode.Text;
                                    drCopy["Country"] = txtCountry.Text;
                                    drCopy["Note"] = txtNote.Text;

                                    this.Close();
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (Isclose != true)
                    {
                        // New Address
                        DataRow[] row = dtAddress.Select("AddressName = '" + txtAddressName.Text.Trim() + "'");
                        if (row.Length == 0)
                        {
                            DataRow dr1 = dtAddress.NewRow();
                            dr1["ID"] = txtID.Text;
                            dr1["AddressName"] = txtAddressName.Text.Trim();
                            string[] str1 = txtAddress.Text.Split('\n');
                            if (str1.Length == 1)
                            {
                                dr1["Address1"] = str1[0].ToString().Replace("\r", "");
                                dr1["Address2"] = "";
                                dr1["Address3"] = "";
                            }
                            else if (str1.Length == 2)
                            {
                                dr1["Address1"] = str1[0].ToString().Replace("\r", "");
                                dr1["Address2"] = str1[1].ToString().Replace("\r", "");
                                dr1["Address3"] = "";
                            }
                            else if (str1.Length == 3)
                            {
                                dr1["Address1"] = str1[0].ToString().Replace("\r", "");
                                dr1["Address2"] = str1[1].ToString().Replace("\r", "");
                                dr1["Address3"] = str1[2].ToString().Replace("\r", "");
                            }
                            else if (str1.Length == 4)
                            {
                                dr1["Address1"] = str1[0].ToString().Replace("\r", "");
                                dr1["Address2"] = str1[1].ToString().Replace("\r", "");
                                dr1["Address3"] = str1[2].ToString().Replace("\r", "") + "," + str1[3].ToString().Replace("\r", "");
                            }
                            else if (str1.Length == 5)
                            {
                                dr1["Address1"] = str1[0].ToString().Replace("\r", "");
                                dr1["Address2"] = str1[1].ToString().Replace("\r", "");
                                dr1["Address3"] = str1[2].ToString().Replace("\r", "") + "," + str1[3].ToString().Replace("\r", "") + "," + str1[4].ToString().Replace("\r", "");
                            }
                            dr1["City"] = txtCity.Text;
                            dr1["State"] = txtState.Text;
                            dr1["ZipCode"] = txtZipCode.Text;
                            dr1["Country"] = txtCountry.Text;
                            dr1["Note"] = txtNote.Text;
                            dtAddress.Rows.Add(dr1);
                            this.Close();
                        }
                        else
                            MessageBox.Show("Ship Address Name is already being Used. Please use a different Ship Address Name", "Ship To Address Name Conflict", MessageBoxButtons.YesNo);
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmShippingAddress, Function: LoadAddr. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                isOk = true;
                if (CheckValidation())
                    LoadAddr();
                ClsCommon.ObjCustomerMaster.ShipAddressName = ShipAddressName;
                ClsCommon.ObjCustomerMaster.ShipAddrress();
                ClsCommon.ObjCustomerMaster.GetShipName();
                txtID.Text = "0";
                
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmShippingAddress, Function: btnOk_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Isclose=true; 
            //LoadAddr();
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void txtZipCode_KeyPress(object sender, KeyPressEventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmShippingAddress,Function :txtZipCode_KeyPress. Message:" + ex.Message);
            }
        }

        private void FrmShippingAddress_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(isOk==true)
            {
                Isclose = false;
                ShipAddressName=txtAddressName.Text;
            }
            else
            {
                Isclose = true;
            }
            //e.Cancel = true;
            //this.Hide();
            //this.Parent = null;
        }
    }
}