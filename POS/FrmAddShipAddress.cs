using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmAddShipAddress : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public DataTable dtAddress = new DataTable();
        BALAddressMaster ObjAddBAL = new BALAddressMaster();
        BOLAddressMaster ObjAddBOL = new BOLAddressMaster();

        public string Address = "";
        public String Type = "";
        public string CustomerName = "";
        string AddName = "";

        public FrmAddShipAddress()
        {
            InitializeComponent();
        }

        private void FrmAddressMaster_Load(object sender, EventArgs e)
        {
            try
            {
                lblName.Text = CustomerName;
                DataTable dt = new BALAddressMaster().SelectByCusID(Convert.ToInt32(txtID.Text));
                if (dt.Rows.Count > 0)
                {
                    for (int I = 0; I < dt.Rows.Count; I++)
                    {
                        if (dt.Rows[I]["AddressName"].ToString().Contains("Ship To ") == true)
                        {
                            if (dt.Rows[I]["AddressType"].ToString() == "S")
                            {
                                //int i = (dtShipAddress.Rows.Count - 1);
                                int Count = Convert.ToInt32(RemoveDigits(dt.Rows[I]["AddressName"].ToString()));
                                AddName = "Ship To " + Convert.ToInt32(Count + 1);
                            }
                        }
                    }
                    if (AddName == "")
                    {
                        AddName = "Ship To 1";
                    }

                    //AddName = dt.Rows[dt.Rows.Count - 1]["AddressName"].ToString();
                    //string[] data = AddName.Split(' ');

                    //AddName = data[data.Length - 1].ToString();
                    //AddName = (AddName == "" ? "0" : AddName); 
                    //AddName = "Ship To " + (Convert.ToInt32(AddName) +1).ToString();
                }
                else
                {
                    AddName = "Ship To 1";
                }
                txtAddressName.Text = AddName;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmAddressMaster, Function: FrmAddressMaster_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void pnlAddress_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pnlAddress.ClientRectangle, Color.Gainsboro, ButtonBorderStyle.Solid);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmAddressMaster, Function: btnCancel_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidation())
                {
                    if (txtAddressName.Text != "")
                    {
                        ObjAddBOL.ReferenceID = Convert.ToInt32(txtID.Text);
                        ObjAddBOL.ReferenceType = "Customer";
                        ObjAddBOL.AddressType = "S";
                        ObjAddBOL.AddressName = txtAddressName.Text;
                        ObjAddBOL.Address1 = txtAdd1.Text;
                        ObjAddBOL.Address2 = txtAdd2.Text;
                        ObjAddBOL.Address3 = txtAdd3.Text;
                        ObjAddBOL.City = txtCity.Text;
                        ObjAddBOL.State = txtState.Text;
                        ObjAddBOL.PostalCode = txtZipCode.Text;
                        ObjAddBOL.Country = txtCountry.Text;
                        ObjAddBOL.Note = txtNote.Text;
                        ObjAddBOL.DefaultShipping = 0;
                        ObjAddBOL.CreatedID = ClsCommon.UserID;
                        ObjAddBOL.ModifiedID = ClsCommon.UserID;
                        ObjAddBOL.CreatedTime = DateTime.Now;
                        ObjAddBOL.ModifiedTime = DateTime.Now;
                        ObjAddBAL.CustomerShipAddressInsert(ObjAddBOL);
                    }
                    else
                    {
                        MessageBox.Show("Please Enter AddressName");
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmAddressMaster, Function: btnOK_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public static string RemoveDigits(string key)
        {
            return Regex.Replace(key, @"\D", "");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }


        private void FrmAddShipAddress_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ClsCommon.ObjInvoiceMaster.GetShipAddress(Convert.ToInt32(txtID.Text));
                ClsCommon.ObjCreditMemo.GetShipAddress(Convert.ToInt32(txtID.Text));
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmAddressMaster,Function :FrmAddShipAddress_FormClosing. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

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
                else if (txtAdd1.Text == "" && txtAdd2.Text == "" && txtAdd3.Text == "" && txtCity.Text == "" && txtState.Text == "" && txtZipCode.Text == "" && txtCountry.Text == "" && txtNote.Text == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Add Address Details");
                    txtAdd1.Focus();
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
    }
}