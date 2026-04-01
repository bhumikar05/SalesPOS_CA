using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmUserType : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtLoadFile = new DataTable();
        BALUserType ObjUserBAL = new BALUserType();
        BOLUserType ObjUserBOL = new BOLUserType();
        public string Mode = "insert";

        public FrmUserType()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 50);
        }   

        private void FrmUserType_Load(object sender, EventArgs e)
        {

        }

        public void LoadData(string ID)
        {
            try
            {
                Mode = "update";
                btnSave.Text = "Update";
                dtLoadFile = new DataTable();
                dtLoadFile = new BALUserType().SelectByID(new BOLUserType() { ID = Convert.ToInt32(ID) });
                if (dtLoadFile.Rows.Count > 0)
                {
                    txtID.Text = dtLoadFile.Rows[0]["ID"].ToString();
                    txtUserType.Text = dtLoadFile.Rows[0]["UserType"].ToString();
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUserType,Function :LoadData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private Boolean CheckValidation()
        {
            Boolean ISValid = false;
            try
            {
                if (txtUserType.Text == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter UserType");
                    txtUserType.Focus();
                    goto Final;
                }
                else
                    ISValid = true;

                Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUserType,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }

        private void Clear()
        {
            txtUserType.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidation())
                {

                    if (Mode == "insert")
                    {
                        DataTable dt = new BALUserType().SelectByName(new BOLUserType() { UserType = txtUserType.Text.Trim() });
                        if (dt.Rows.Count == 0)
                        {
                            ObjUserBOL.UserType = txtUserType.Text;

                            ObjUserBAL.Insert(ObjUserBOL);
                            MessageBox.Show("Record save successfully");
                        }
                        else
                        {
                            MessageBox.Show("Duplicate name not allow");
                        }
                    }
                    else
                    {
                        ObjUserBOL.ID = Convert.ToInt32(txtID.Text);
                        ObjUserBOL.UserType = txtUserType.Text;
                        ObjUserBAL.Update(ObjUserBOL);

                        MessageBox.Show("Record update successfully");
                    }
                    btnSave.Text = "Save";
                    ClsCommon.ObjUserTypeList.LoadUser();
                    Clear();
                    this.Close();
                }
                else
                {
                    ClsCommon.WriteErrorLogs("Form:FrmUserType,Function :btnSave_Click. Message: Error Create UserType");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUserType,Function :btnSave_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void txtUserType_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if ((Char.IsDigit(e.KeyChar)))
                {
                    MessageBox.Show("please enter string only");
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUserType,Function :txtUserType_KeyPress. Message:" + ex.Message);
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