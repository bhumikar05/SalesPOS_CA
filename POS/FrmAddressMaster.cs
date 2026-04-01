using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmAddressMaster : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public DataTable dtAddress = new DataTable();
        BALSalesRepMaster ObjUserBAL = new BALSalesRepMaster();
        BOLSalesRepMaster ObjUserBOL = new BOLSalesRepMaster();
        public string Address = "";
        public String Type = "";

        public FrmAddressMaster()
        {
            InitializeComponent();
        }

        private void FrmAddressMaster_Load(object sender, EventArgs e)
        {

        }

        private void pnlAddress_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pnlAddress.ClientRectangle, Color.Gainsboro, ButtonBorderStyle.Solid);
        }

        public void LoadAddress()
        {
            try
            {
                if (dtAddress.Rows.Count > 0)
                {
                    txtID.Text = dtAddress.Rows[0]["ID"].ToString();
                    if (dtAddress.Rows[0]["Address1"].ToString() != "")
                        txtAddress.Text = dtAddress.Rows[0]["Address1"].ToString();
                    if (dtAddress.Rows[0]["Address2"].ToString() != "")
                        txtAddress.Text = dtAddress.Rows[0]["Address2"].ToString();
                    if (dtAddress.Rows[0]["Address1"].ToString() != "" && dtAddress.Rows[0]["Address2"].ToString() != "")
                        txtAddress.Text = dtAddress.Rows[0]["Address1"].ToString() + "\r\n" + dtAddress.Rows[0]["Address2"].ToString();
                    if (dtAddress.Rows[0]["Address1"].ToString() != "" && dtAddress.Rows[0]["Address2"].ToString() != "" && dtAddress.Rows[0]["Address3"].ToString() != "")
                        txtAddress.Text = dtAddress.Rows[0]["Address1"].ToString() + "\r\n" + dtAddress.Rows[0]["Address2"].ToString() + "\r\n" + dtAddress.Rows[0]["Address3"].ToString();
                    if (dtAddress.Rows[0]["City"].ToString() != "")
                        txtCity.Text = dtAddress.Rows[0]["City"].ToString();
                    if (dtAddress.Rows[0]["State"].ToString() != "")
                        txtState.Text = dtAddress.Rows[0]["State"].ToString();
                    if (dtAddress.Rows[0]["ZipCode"].ToString() != "")
                        txtZipCode.Text = dtAddress.Rows[0]["ZipCode"].ToString();
                    if (dtAddress.Rows[0]["Country"].ToString() != "")
                        txtCountry.Text = dtAddress.Rows[0]["Country"].ToString();
                    if (dtAddress.Rows[0]["Note"].ToString() != "")
                        txtNote.Text = dtAddress.Rows[0]["Note"].ToString();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmAddressMaster, Function: LoadAddress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void LoadAddr()
        {
            try
            {
                Address = "";
                dtAddress.Rows.Clear();
                DataRow dr = dtAddress.NewRow();
                dr["ID"] = txtID.Text;
                string[] str = txtAddress.Text.Split('\n');
                if (str.Length == 1)
                    dr["Address1"] = str[0].ToString().Replace("\r", "");
                else if (str.Length == 2)
                {
                    dr["Address1"] = str[0].ToString().Replace("\r", "");
                    dr["Address2"] = str[1].ToString().Replace("\r", "");
                }
                else if (str.Length == 3)
                {
                    dr["Address1"] = str[0].ToString().Replace("\r", "");
                    dr["Address2"] = str[1].ToString().Replace("\r", "");
                    dr["Address3"] = str[2].ToString().Replace("\r", "");
                }
                else if (str.Length == 4)
                {
                    dr["Address1"] = str[0].ToString().Replace("\r", "");
                    dr["Address2"] = str[1].ToString().Replace("\r", "");
                    dr["Address3"] = str[2].ToString().Replace("\r", "") + "," + str[3].ToString().Replace("\r", "");
                }
                else if (str.Length == 5)
                {
                    dr["Address1"] = str[0].ToString().Replace("\r", "");
                    dr["Address2"] = str[1].ToString().Replace("\r", "");
                    dr["Address3"] = str[2].ToString().Replace("\r", "") + "," + str[3].ToString().Replace("\r", "") + "," + str[4].ToString().Replace("\r", "");
                }
                dr["City"] = txtCity.Text;
                dr["State"] = txtState.Text;
                dr["ZipCode"] = txtZipCode.Text;
                dr["Country"] = txtCountry.Text;
                dr["Note"] = txtNote.Text;
                dtAddress.Rows.Add(dr);
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmAddressMaster, Function: LoadAddr. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                LoadAddr();
                if (Type == "SalesRep")
                    ClsCommon.ObjSalesRepMaster.LoadAddrees();
                else if (Type == "Customer")
                    ClsCommon.ObjCustomerMaster.LoadBillAddrees();
                this.Close();
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmAddressMaster, Function: btnCancel_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
          
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                LoadAddr();
                if (Type == "SalesRep")
                    ClsCommon.ObjSalesRepMaster.LoadAddrees();
                else if (Type == "Customer")
                    ClsCommon.ObjCustomerMaster.LoadBillAddrees();
                txtID.Text = "0";
                this.Close();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmAddressMaster, Function: btnOK_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        
    }
}