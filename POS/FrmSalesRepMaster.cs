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
    public partial class FrmSalesRepMaster : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtLoadFile = new DataTable();
        DataTable dtAddress = new DataTable();
        BALSalesRepMaster ObjUserBAL = new BALSalesRepMaster();
        BOLSalesRepMaster ObjUserBOL = new BOLSalesRepMaster();
        BALAddressMaster ObjAddressBAL = new BALAddressMaster();
        BOLAddressMaster ObjAddressBOL = new BOLAddressMaster();
        BALSalesRepMaster ObjSalesBAL = new BALSalesRepMaster();

        public string Mode = "insert";
        public string SalesRepAddress { get; set; }

        public FrmSalesRepMaster()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 50);
            GetUserType();
            txtAddress.Text = SalesRepAddress;
        }

        private void pnlSalesRep_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pnlSalesRep.ClientRectangle, Color.Gainsboro, ButtonBorderStyle.Solid);
        }

        private void FrmNewSalesRep_Load(object sender, EventArgs e)
        {
            cmbAssistant.Visible = false;
            lblAssistant.Visible = false;
            GetUserType();
            btnOk.Enabled = true;
        }

        private void AddressColumn()
        {
            try
            {
                dtAddress.Columns.Add("ID");
                dtAddress.Columns.Add("AddressName");
                dtAddress.Columns.Add("Address1");
                dtAddress.Columns.Add("Address2");
                dtAddress.Columns.Add("Address3");
                dtAddress.Columns.Add("City");
                dtAddress.Columns.Add("State");
                dtAddress.Columns.Add("ZipCode");
                dtAddress.Columns.Add("Country");
                dtAddress.Columns.Add("Note");
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmNewSalesRep,Function :AddressColumn. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
           
        }

        private Boolean CheckValidation()
        {
            Boolean ISValid = true;
            string email = txtEmail.Text;
            string fax = txtFax.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            var reg = new Regex("^\\+[0-9]{1,3}-[0-9]{3}-[0-9]{7}$");
            Match M1 = reg.Match(fax);

            try
            {
                if (txtName.Text == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter Name");
                    txtName.Focus();
                    goto Final;
                }
                else if (txtUserName.Text == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter UserName");
                    txtUserName.Focus();
                    goto Final;
                }
                else if (txtPassword.Text == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter Password");
                    txtPassword.Focus();
                    goto Final;
                }
                else if (cmbUserType.SelectedIndex == 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select UserType");
                    cmbUserType.Focus();
                    goto Final;
                }
                else if (txtContact.Text != "" && txtContact.TextLength < 10)
                {
                    MessageBox.Show("Please enter 10 digit number");
                    ISValid = false;
                    txtContact.Focus();
                }
                else if (txtPhone.Text != "" && txtPhone.TextLength < 10)
                {
                    MessageBox.Show("Please enter 10 digit number");
                    ISValid = false;
                    txtPhone.Focus();
                }
                else if (txtEmail.Text != "" && !match.Success)
                {
                    MessageBox.Show("Enter valid Email");
                    txtEmail.Clear();
                    ISValid = false;
                    txtEmail.Focus();
                }
                else if (txtFax.Text != "" && !M1.Success)
                {
                    MessageBox.Show("Enter valid Fax");
                    txtFax.Clear();
                    ISValid = false;
                    txtEmail.Focus();
                }
                else if (cmbUserType.Text == "Assistant" && cmbAssistant.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Assistant's admin");
                    ISValid = false;
                    cmbAssistant.Focus();
                }
                Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUserAdd,Function :CheckValidation. Message:" + ex.Message);
                return ISValid;
            }
        }

        public void GetUserType()
        {
            try
            {
                DataTable dtUserType = new BALUserType().Select(new BOLUserType() { });
                DataRow dr = dtUserType.NewRow();
                dr["UserType"] = "--Select--";
                dr["ID"] = "0";
                dtUserType.Rows.InsertAt(dr, 0);
                cmbUserType.DataSource = dtUserType;
                cmbUserType.DisplayMember = "UserType";
                cmbUserType.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmNewSalesRep,Function :GetUserType. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void Clear()
        {
            dtAddress = new DataTable();
            txtName.Text = "";
            txtCompanyName.Text = "";
            txtSaluation.Text = "";
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtPhone.Text = "";
            txtFax.Text = "";
            txtAltPhone.Text = "";
            txtAltContact.Text = "";
            txtEmail.Text = "";
            txtAccountNo.Text = "";
            cmbUserType.SelectedIndex = 0;
            chkActive.Checked = false;
            SalesRepAddress = "";
            rdbYes.Checked = false;
            rdbNo.Checked = false;
        }

        public void LoadData(string ID)
        {
            try
            {
                Clear();
                GetUserType();
                GetUser();
                Mode = "update";
                dtLoadFile = new DataTable();
                dtLoadFile = new BALSalesRepMaster().SelectByID(new BOLSalesRepMaster() { ID = Convert.ToInt32(ID) });
                if (dtLoadFile.Rows.Count > 0)
                {
                    txtID.Text = dtLoadFile.Rows[0]["ID"].ToString();
                    txtName.Text = dtLoadFile.Rows[0]["Name"].ToString();
                    txtCompanyName.Text = dtLoadFile.Rows[0]["CompanyName"].ToString();
                    txtSaluation.Text = dtLoadFile.Rows[0]["Saluation"].ToString();
                    txtFirstName.Text = dtLoadFile.Rows[0]["FirstName"].ToString();
                    txtMiddleName.Text = dtLoadFile.Rows[0]["MiddleName"].ToString();
                    txtLastName.Text = dtLoadFile.Rows[0]["LastName"].ToString();
                    txtUserName.Text = dtLoadFile.Rows[0]["UserName"].ToString();
                    txtPassword.Text = dtLoadFile.Rows[0]["Password"].ToString();
                    txtContact.Text = dtLoadFile.Rows[0]["Contact"].ToString();
                    txtPhone.Text = dtLoadFile.Rows[0]["Phone"].ToString();
                    txtFax.Text = dtLoadFile.Rows[0]["Fax"].ToString();
                    txtAltPhone.Text = dtLoadFile.Rows[0]["AltPhone"].ToString();
                    txtAltContact.Text = dtLoadFile.Rows[0]["AltContact"].ToString();
                    txtEmail.Text = dtLoadFile.Rows[0]["Email"].ToString();
                    txtAccountNo.Text = dtLoadFile.Rows[0]["AccountNo"].ToString();
                    cmbUserType.SelectedValue = dtLoadFile.Rows[0]["UserTypeID"].ToString();
                    if (dtLoadFile.Rows[0]["AssistantAdminID"].ToString() != "")
                    {
                        cmbAssistant.SelectedValue = dtLoadFile.Rows[0]["AssistantAdminID"].ToString();
                    }

                    if(dtLoadFile.Rows[0]["LowestPriceAllow"].ToString() == "1")
                    {
                        rdbYes.Checked = true;
                    }
                    else if(dtLoadFile.Rows[0]["LowestPriceAllow"].ToString() == "0")
                    {
                        rdbNo.Checked = true;
                    }

                    if (dtAddress.Rows.Count == 0)
                        AddressColumn();
                    DataRow dr = dtAddress.NewRow();
                    dr["ID"] = dtAddress.Rows.Count + 1;

                    if (dtLoadFile.Rows[0]["Address1"].ToString() != null && dtLoadFile.Rows[0]["Address1"].ToString() != "")
                        dr["Address1"] = dtLoadFile.Rows[0]["Address1"].ToString();
                    if (dtLoadFile.Rows[0]["Address2"].ToString() != null && dtLoadFile.Rows[0]["Address2"].ToString() != "")
                        dr["Address2"] = dtLoadFile.Rows[0]["Address2"].ToString();
                    if (dtLoadFile.Rows[0]["Address3"].ToString() != null && dtLoadFile.Rows[0]["Address3"].ToString() != "")
                        dr["Address3"] = dtLoadFile.Rows[0]["Address3"].ToString();
                    if (dtLoadFile.Rows[0]["City"].ToString() != null && dtLoadFile.Rows[0]["City"].ToString() != "")
                        dr["City"] = dtLoadFile.Rows[0]["City"].ToString();
                    if (dtLoadFile.Rows[0]["State"].ToString() != null && dtLoadFile.Rows[0]["State"].ToString() != "")
                        dr["State"] = dtLoadFile.Rows[0]["State"].ToString();
                    if (dtLoadFile.Rows[0]["PostalCode"].ToString() != null && dtLoadFile.Rows[0]["PostalCode"].ToString() != "")
                        dr["ZipCode"] = dtLoadFile.Rows[0]["PostalCode"].ToString();
                    if (dtLoadFile.Rows[0]["Country"].ToString() != null && dtLoadFile.Rows[0]["Country"].ToString() != "")
                        dr["Country"] = dtLoadFile.Rows[0]["Country"].ToString();
                    if (dtLoadFile.Rows[0]["Note"].ToString() != null && dtLoadFile.Rows[0]["Note"].ToString() != "")
                        dr["Note"] = dtLoadFile.Rows[0]["Note"].ToString();
                    dtAddress.Rows.Add(dr);

                    LoadAddrees();

                    if (dtLoadFile.Rows[0]["IsActive"].ToString() == "1")
                        chkActive.Checked = false;
                    else
                        chkActive.Checked = true;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmNewSalesRep, Function: LoadData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void LoadAddrees()
        {
            try
            {
                if (dtAddress.Rows.Count > 0)
                {
                    if (dtAddress.Rows[0]["Address1"].ToString() != "")
                        SalesRepAddress = dtAddress.Rows[0]["Address1"].ToString();
                    if (dtAddress.Rows[0]["Address2"].ToString() != "")
                        SalesRepAddress = SalesRepAddress + "\r\n" + dtAddress.Rows[0]["Address2"].ToString();
                    if (dtAddress.Rows[0]["Address3"].ToString() != "")
                        SalesRepAddress = SalesRepAddress + "\r\n" + dtAddress.Rows[0]["Address3"].ToString();
                    if (dtAddress.Rows[0]["City"].ToString() != "" && dtAddress.Rows[0]["State"].ToString() == "")
                        SalesRepAddress = SalesRepAddress + "\r\n" + dtAddress.Rows[0]["City"].ToString();
                    else if (dtAddress.Rows[0]["State"].ToString() != "" && dtAddress.Rows[0]["City"].ToString() == "")
                        SalesRepAddress = SalesRepAddress + "\r\n" + dtAddress.Rows[0]["State"].ToString();
                    else if (dtAddress.Rows[0]["City"].ToString() != "" && dtAddress.Rows[0]["State"].ToString() != "")
                        SalesRepAddress = SalesRepAddress + "\r\n" + dtAddress.Rows[0]["City"].ToString() + "," + dtAddress.Rows[0]["State"].ToString();
                    if (dtAddress.Rows[0]["Country"].ToString() != "" && dtAddress.Rows[0]["ZipCode"].ToString() == "")
                        SalesRepAddress = SalesRepAddress + "\r\n" + dtAddress.Rows[0]["Country"].ToString();
                    else if (dtAddress.Rows[0]["ZipCode"].ToString() != "" && dtAddress.Rows[0]["Country"].ToString() == "")
                        SalesRepAddress = SalesRepAddress + "\r\n" + dtAddress.Rows[0]["ZipCode"].ToString();
                    else if (dtAddress.Rows[0]["ZipCode"].ToString() != "" && dtAddress.Rows[0]["Country"].ToString() != "")
                        SalesRepAddress = SalesRepAddress + "\r\n" + dtAddress.Rows[0]["Country"].ToString() + "," + dtAddress.Rows[0]["ZipCode"].ToString();
                    if (dtAddress.Rows[0]["Note"].ToString() != "")
                        SalesRepAddress = SalesRepAddress + "\r\n" + dtAddress.Rows[0]["Note"].ToString();
                }
                else if (dtAddress.Rows.Count == 0)
                {
                    DataRow dr = dtAddress.NewRow();
                    dr["ID"] = dtAddress.Rows.Count + 1;
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
                    dtAddress.Rows.Add(dr);
                }
                if (SalesRepAddress == null)
                    txtAddress.Text = "";
                else
                    txtAddress.Text = SalesRepAddress.Replace("\r\n\r\n", "\r\n");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmNewSalesRep,Function :LoadAddrees. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void GenerateCode(ref string Initial)
        {
            try
            {
                Initial = "";
                string[] output = txtName.Text.Split(' ');
                foreach (string s in output)
                {
                    Initial += s[0];
                }

                if (Initial.Length > 5)
                    Initial = Initial.Substring(0, 5);

                if(ObjSalesBAL.SelectByInitial(Initial) == 1)
                {
                    Initial = "";
                    foreach (string s in output)
                    {             
                        if(s.Length > 1)
                        {
                            Initial += string.Concat(s[0],s[1]);
                        }
                        else
                        {
                            Initial += s[0];
                        }
                                    
                    }
                    if (Initial.Length > 5)
                        Initial = Initial.Substring(0, 5);

                    if (ObjSalesBAL.SelectByInitial(Initial) == 1)
                    {
                        Initial = "";
                        foreach (string s in output)
                        {
                            if (s.Length > 2)
                            {
                                Initial += string.Concat(s[0], s[2]);
                            }
                            else
                            {
                                Initial += s[0];
                            }

                        }
                        if (Initial.Length > 5)
                            Initial = Initial.Substring(0, 5);
                    }
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmNewSalesRep,Function :GenerateCode. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string Initial = "";
                if (CheckValidation())
                {
                    if (Mode == "insert")
                    {
                        DataTable dt = new BALOtherMaster().SelectByName(new BOLOtherMaster() { Name = txtName.Text.Trim() });
                        if (dt.Rows.Count == 0)
                        {
                            DataTable dtCustomer = new BALCustomerMaster().SelectByFullName(new BOLCustomerMaster() { FullName = txtName.Text.Trim() });
                            if (dtCustomer.Rows.Count == 0)
                            {
                                DataTable dtVendor = new BALVendorMaster().SelectByName(new BOLVendorMaster() { VendorName = txtName.Text.Trim() });
                                if (dtVendor.Rows.Count == 0)
                                {
                                    DataTable dtEmployee = new BALEmployeeMaster().SelectByName(new BOLEmployeeMaster() { Name = txtName.Text.Trim() });
                                    if (dtEmployee.Rows.Count == 0)
                                    {
                                        DataTable dtSalesrep = new BALSalesRepMaster().SelectByName(new BOLSalesRepMaster() { Name = txtName.Text.Trim() });
                                        if (dtSalesrep.Rows.Count == 0)
                                        {
                                            DataTable dtUserName = new BALSalesRepMaster().SelectByUser(new BOLSalesRepMaster() { UserName = txtUserName.Text.Trim() });
                                            if (dtUserName.Rows.Count == 0)
                                            {

                                                ObjUserBOL.Name = txtName.Text;
                                                ObjUserBOL.CompanyName = txtCompanyName.Text;
                                                ObjUserBOL.Saluation = txtSaluation.Text;
                                                ObjUserBOL.FirstName = txtFirstName.Text;
                                                ObjUserBOL.MiddleName = txtMiddleName.Text;
                                                ObjUserBOL.LastName = txtLastName.Text;
                                                ObjUserBOL.UserName = txtUserName.Text;
                                                ObjUserBOL.Password = txtPassword.Text;
                                                ObjUserBOL.Contact = txtContact.Text;
                                                ObjUserBOL.Phone = txtPhone.Text;
                                                ObjUserBOL.Fax = txtFax.Text;
                                                ObjUserBOL.AltPhone = txtAltPhone.Text;
                                                ObjUserBOL.AltContact = txtAltContact.Text;
                                                ObjUserBOL.Email = txtEmail.Text;
                                                ObjUserBOL.AccountNo = txtAccountNo.Text;
                                                ObjUserBOL.UserTypeID = Convert.ToInt16(cmbUserType.SelectedValue);
                                                ObjUserBOL.SalesRepType = "OtherName";

                                                GenerateCode(ref Initial);

                                                ObjUserBOL.Initial = Initial;
                                                ObjUserBOL.CreatedID = ClsCommon.UserID;
                                                ObjUserBOL.CreatedTime = DateTime.Now;
                                                ObjUserBOL.ModifiedTime = DateTime.Now;
                                                ObjUserBOL.IsSync = 0;
                                                ObjUserBOL.IsLogin = 0;
                                                if(rdbYes.Checked == true)
                                                {
                                                    ObjUserBOL.LowestPriceAllow = 1;
                                                }
                                                else if(rdbNo.Checked == true)
                                                {
                                                    ObjUserBOL.LowestPriceAllow = 0;
                                                }

                                                if (chkActive.Checked == false)
                                                    ObjUserBOL.IsActive = 1;
                                                else
                                                    ObjUserBOL.IsActive = 0;
                                                if (cmbAssistant.SelectedValue != null)
                                                {
                                                    if (cmbAssistant.SelectedValue.ToString() != "")
                                                    {
                                                        ObjUserBOL.AssistantAdminID = Convert.ToInt32(cmbAssistant.SelectedValue);
                                                    }
                                                }
                                                int SalesID = ObjUserBAL.Insert(ObjUserBOL);

                                                if (dtAddress.Rows.Count > 0)
                                                {
                                                    ObjAddressBOL.ReferenceID = SalesID;
                                                    ObjAddressBOL.ReferenceType = "SalesRep";
                                                    ObjAddressBOL.AddressType = "S";
                                                    if (dtAddress.Rows[0]["Address1"].ToString() != "")
                                                        ObjAddressBOL.Address1 = dtAddress.Rows[0]["Address1"].ToString();
                                                    if (dtAddress.Rows[0]["Address2"].ToString() != "")
                                                        ObjAddressBOL.Address2 = dtAddress.Rows[0]["Address2"].ToString();
                                                    if (dtAddress.Rows[0]["Address3"].ToString() != "")
                                                        ObjAddressBOL.Address3 = dtAddress.Rows[0]["Address3"].ToString();
                                                    if (dtAddress.Rows[0]["City"].ToString() != "")
                                                        ObjAddressBOL.City = dtAddress.Rows[0]["City"].ToString();
                                                    if (dtAddress.Rows[0]["State"].ToString() != "")
                                                        ObjAddressBOL.State = dtAddress.Rows[0]["State"].ToString();
                                                    if (dtAddress.Rows[0]["ZipCode"].ToString() != "")
                                                        ObjAddressBOL.PostalCode = dtAddress.Rows[0]["ZipCode"].ToString();
                                                    if (dtAddress.Rows[0]["Country"].ToString() != "")
                                                        ObjAddressBOL.Country = dtAddress.Rows[0]["Country"].ToString();
                                                    if (dtAddress.Rows[0]["Note"].ToString() != "")
                                                        ObjAddressBOL.Note = dtAddress.Rows[0]["Note"].ToString();
                                                    ObjAddressBOL.CreatedTime = DateTime.Now;
                                                    ObjAddressBOL.ModifiedTime = DateTime.Now;
                                                    ObjAddressBOL.CreatedID = ClsCommon.UserID;

                                                    ObjAddressBAL.SalesRepAddressInsert(ObjAddressBOL);
                                                }
                                                MessageBox.Show("Record save successfully");
                                                Clear();
                                                this.Close();
                                            }
                                            else
                                                MessageBox.Show("UserName duplicate not allow");
                                        }
                                        else
                                            MessageBox.Show("This name is already in use in the SalesRep List. Please Enter Other Name");
                                    }
                                    else
                                        MessageBox.Show("This name is already in use in the Employee List. Please Enter Other Name");
                                }
                                else
                                    MessageBox.Show("This name is already in use in the Vendor List. Please Enter Other Name");
                            }
                            else
                                MessageBox.Show("This name is already in use in the Customer List. Please Enter Other Name");
                        }
                        else
                            MessageBox.Show("This name is already in use in the Other List. Please Enter Other Name");
                    }
                    else
                    {
                        //Upadte
                        //DataTable dt = new BALOtherMaster().SelectByName(new BOLOtherMaster() { Name = txtName.Text.Trim()});
                        //if (dt.Rows.Count == 0)
                        //{
                        //    DataTable dtCustomer = new BALCustomerMaster().SelectByFullName(new BOLCustomerMaster() { FullName = txtName.Text.Trim()});
                        //    if (dtCustomer.Rows.Count == 0)
                        //    {
                        //        DataTable dtVendor = new BALVendorMaster().SelectByName(new BOLVendorMaster() { VendorName = txtName.Text.Trim()});
                        //        if (dtVendor.Rows.Count == 0)
                        //        {
                        //            DataTable dtEmployee = new BALEmployeeMaster().SelectByName(new BOLEmployeeMaster() { Name = txtName.Text.Trim() });
                        //            if (dtEmployee.Rows.Count == 0)
                        //            {
                        DataTable dtSalesrep = new BALSalesRepMaster().SelectByUpdateName(new BOLSalesRepMaster() { Name = txtName.Text.Trim(), ID = Convert.ToInt32(txtID.Text) });
                        if (dtSalesrep.Rows.Count == 0)
                        {
                            DataTable dtUserName = new BALSalesRepMaster().SelectByUpdateUser(new BOLSalesRepMaster() { UserName = txtUserName.Text.Trim(), ID = Convert.ToInt32(txtID.Text) });
                            if (dtUserName.Rows.Count == 0)
                            {
                                if (UpdateSalesRep())
                                {
                                    MessageBox.Show("Record update successfully");
                                    Clear();
                                    this.Close();
                                }
                            }
                            else
                                MessageBox.Show("Duplicate name not allow");
                        }
                        else
                            MessageBox.Show("This name is already in use in the SalesRep List. Please Enter Other Name");
                        //            }
                        //            else
                        //                MessageBox.Show("This name is already in use in the Employee List. Please Enter Other Name");
                        //        }
                        //        else
                        //            MessageBox.Show("This name is already in use in the Vendor List. Please Enter Other Name");
                        //    }
                        //    else
                        //        MessageBox.Show("This name is already in use in the Customer List. Please Enter Other Name");
                        //}
                        //else
                        //    MessageBox.Show("This name is already in use in the Other List. Please Enter Other Name");
                    }
                    ClsCommon.ObjSalesRepList.LoadSalesRep();
                }
                else
                    ClsCommon.WriteErrorLogs("Form:FrmNewSalesRep, Function :btnOk_Click. Message: Error Create SalesRep");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmNewSalesRep,Function :btnOk_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }


        private Boolean UpdateSalesRep()
        {
            Boolean IsValid = false;
            try
            {
                // Update 
                ObjUserBOL.ID = Convert.ToInt32(txtID.Text);
                ObjUserBOL.Name = txtName.Text;
                ObjUserBOL.CompanyName = txtCompanyName.Text;
                ObjUserBOL.Saluation = txtSaluation.Text;
                ObjUserBOL.FirstName = txtFirstName.Text;
                ObjUserBOL.MiddleName = txtMiddleName.Text;
                ObjUserBOL.LastName = txtLastName.Text;
                ObjUserBOL.UserName = txtUserName.Text;
                ObjUserBOL.Password = txtPassword.Text;
                ObjUserBOL.Contact = txtContact.Text;
                ObjUserBOL.Phone = txtPhone.Text;
                ObjUserBOL.Fax = txtFax.Text;
                ObjUserBOL.AltPhone = txtAltPhone.Text;
                ObjUserBOL.AltContact = txtAltContact.Text;
                ObjUserBOL.Email = txtEmail.Text;
                ObjUserBOL.AccountNo = txtAccountNo.Text;
                ObjUserBOL.UserTypeID = Convert.ToInt16(cmbUserType.SelectedValue);
                ObjUserBOL.ModifiedID = ClsCommon.UserID;
                ObjUserBOL.ModifiedTime = DateTime.Now;
                ObjUserBOL.IsSync = 0;
                ObjUserBOL.IsLogin = 0;
                if (rdbYes.Checked == true)
                {
                    ObjUserBOL.LowestPriceAllow = 1;
                }
                else if(rdbNo.Checked == true)
                {
                    ObjUserBOL.LowestPriceAllow = 0;
                }

                if (chkActive.Checked == false)
                    ObjUserBOL.IsActive = 1;
                else
                    ObjUserBOL.IsActive = 0;
                if (cmbAssistant.SelectedValue != null)
                {
                    if (cmbAssistant.SelectedValue.ToString() != "")
                    {
                        ObjUserBOL.AssistantAdminID = Convert.ToInt32(cmbAssistant.SelectedValue);
                    }
                }
                int SalesID = ObjUserBAL.Update(ObjUserBOL);

                //Delete SalesRepAddress
                ObjAddressBOL.ReferenceID = Convert.ToInt32(txtID.Text);
                ObjAddressBAL.SalesRepDelete(ObjAddressBOL);

                if (dtAddress.Rows.Count > 0)
                {
                    ObjAddressBOL.ReferenceID = SalesID;
                    ObjAddressBOL.ReferenceType = "SalesRep";
                    ObjAddressBOL.AddressType = "S";
                    if (dtAddress.Rows[0]["Address1"].ToString() != "")
                        ObjAddressBOL.Address1 = dtAddress.Rows[0]["Address1"].ToString();
                    if (dtAddress.Rows[0]["Address2"].ToString() != "")
                        ObjAddressBOL.Address2 = dtAddress.Rows[0]["Address2"].ToString();
                    if (dtAddress.Rows[0]["Address3"].ToString() != "")
                        ObjAddressBOL.Address3 = dtAddress.Rows[0]["Address3"].ToString();
                    if (dtAddress.Rows[0]["City"].ToString() != "")
                        ObjAddressBOL.City = dtAddress.Rows[0]["City"].ToString();
                    if (dtAddress.Rows[0]["State"].ToString() != "")
                        ObjAddressBOL.State = dtAddress.Rows[0]["State"].ToString();
                    if (dtAddress.Rows[0]["ZipCode"].ToString() != "")
                        ObjAddressBOL.PostalCode = dtAddress.Rows[0]["ZipCode"].ToString();
                    if (dtAddress.Rows[0]["Country"].ToString() != "")
                        ObjAddressBOL.Country = dtAddress.Rows[0]["Country"].ToString();
                    if (dtAddress.Rows[0]["Note"].ToString() != "")
                        ObjAddressBOL.Note = dtAddress.Rows[0]["Note"].ToString();
                    ObjAddressBOL.CreatedTime = DateTime.Now;
                    ObjAddressBOL.ModifiedTime = DateTime.Now;
                    ObjAddressBOL.CreatedID = ClsCommon.UserID;

                    ObjAddressBAL.SalesRepAddressInsert(ObjAddressBOL);
                }
                IsValid = true;
            }
            catch (Exception ex)
            {
                IsValid = false;
                ClsCommon.WriteErrorLogs("Form:FrmNewSalesRep,Function :UpdateSalesRep. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
            return IsValid;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddressDetail_Click(object sender, EventArgs e)
        {
            if (dtAddress.Rows.Count == 0)
                AddressColumn();
            LoadAddrees();
            FrmAddressMaster fSalesRepAdd = new FrmAddressMaster();
            fSalesRepAdd.dtAddress = dtAddress;
            fSalesRepAdd.Type = "SalesRep";
            fSalesRepAdd.LoadAddress();
            fSalesRepAdd.ShowDialog();
            //LoadAddrees();
        }

        private void BillAddrress()
        {
            if (Mode == "insert")
            {
                SalesRepAddress = "";
                if (txtCompanyName.Text != "")
                    SalesRepAddress = txtCompanyName.Text;
                if (txtLastName.Text != "")
                {
                    if (txtCompanyName.Text != "")
                    {
                        SalesRepAddress = txtCompanyName.Text;
                        if (txtFirstName.Text != "")
                            SalesRepAddress = SalesRepAddress + "\r\n" + txtFirstName.Text;
                        if (txtMiddleName.Text != "")
                            SalesRepAddress = SalesRepAddress + " " + txtMiddleName.Text;
                        if (txtLastName.Text != "")
                            SalesRepAddress = SalesRepAddress + " " + txtLastName.Text;
                    }
                    else
                    {
                        if (txtFirstName.Text != "")
                            SalesRepAddress = txtFirstName.Text;
                        if (txtMiddleName.Text != "")
                            SalesRepAddress = SalesRepAddress + " " + txtMiddleName.Text;
                        if (txtLastName.Text != "")
                            SalesRepAddress = SalesRepAddress + " " + txtLastName.Text;
                    }
                }
                txtAddress.Text = SalesRepAddress.Trim();
            }
        }

        private void txtCompanyName_Leave(object sender, EventArgs e)
        {
            BillAddrress();
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            BillAddrress();
        }

        private void chkPswShow_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(chkPswShow.Checked == true)
                    txtPassword.UseSystemPasswordChar = false;
                else
                    txtPassword.UseSystemPasswordChar = true;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmSalesRepMaster,Function :chkPswShow_CheckedChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void FrmSalesRepMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClsCommon.ObjSalesRepMaster.Hide();
            ClsCommon.ObjSalesRepMaster.Parent = null;
            ClsCommon.ObjSalesRepMaster.Mode = "insert";
            e.Cancel = true;
            Clear();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("Enter Correct Mobile Number");
                }
                //if (Regex.IsMatch(txtPhone.Text, @"^[- +()0-9]+$") == false)
                //{
                //    MessageBox.Show("Plese enter valid PhoneNumber");
                //}
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmSalesRepMaster,Function :txtPhone_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Enter Correct Mobile Number");
            }
        }
        public void GetUser()
        {
            DataTable dtUser = new BALSalesRepMaster().SelectByUserName(new BOLSalesRepMaster() { });
            DataRow dr = dtUser.NewRow();
            dr["UserName"] = "--Select--";
            dr["ID"] = "0";
            dr["IsActive"] = "0";
            dtUser.Rows.InsertAt(dr, 0);
            cmbAssistant.DataSource = dtUser; ;
            cmbAssistant.DisplayMember = "UserName";
            cmbAssistant.ValueMember = "ID";
            cmbAssistant.SelectedIndex = 0;

        }

        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbUserType.Text== "Assistant")
            {
                cmbAssistant.Visible = true;
                lblAssistant.Visible = true;
                GetUser();
            }
            else
            {
                cmbAssistant.Visible = false;
                lblAssistant.Visible = false;
            }
        
        }
    }
}