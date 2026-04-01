using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmEmailFormat : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BOLEmailTemplate objBOLEmail = new BOLEmailTemplate();
        BALEmailTemplate objBALEmail = new BALEmailTemplate();
        DataTable dtLoadData = new DataTable();
        public string Mode = "insert";

        public FrmEmailFormat()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 50);
        }

        private void FrmEmailFormat_Load(object sender, EventArgs e)
        {
            try
            {
                if (Mode == "insert")
                {
                    txtSubject.Text = "{InvoiceNumber}";
                    cmbTemplateType.SelectedIndex = 0;
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmEmailFormate, Function: FrmEmailFormat_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
          
        }

        public void LoadData(string ID)
        {
            try
            {
                Clear();
                Mode = "update";
                dtLoadData = new DataTable();
                dtLoadData = new BALEmailTemplate().SelectByID(new BOLEmailTemplate() { ID = Convert.ToInt32(ID) });
                if (dtLoadData.Rows.Count > 0)
                {

                    txtID.Text = dtLoadData.Rows[0]["ID"].ToString();
                    if (dtLoadData.Rows[0]["TemplateType"].ToString() == "Invoice Create")
                    {
                        cmbTemplateType.SelectedIndex = 0;

                    }
                    else if (dtLoadData.Rows[0]["TemplateType"].ToString() == "Invoice Edit")
                    {
                        cmbTemplateType.SelectedIndex = 1;

                    }
                    else if (dtLoadData.Rows[0]["TemplateType"].ToString() == "Tracking")
                    {
                        cmbTemplateType.SelectedIndex = 2;

                    }
                    else if (dtLoadData.Rows[0]["TemplateType"].ToString() == "Payment Verifaction")
                    {
                        cmbTemplateType.SelectedIndex = 3;


                    }
                    else if (dtLoadData.Rows[0]["TemplateType"].ToString() == "Customer Statement")
                    {
                        cmbTemplateType.SelectedIndex = 4;

                    }

                    //cmbTemplateType.Text = dtLoadData.Rows[0]["TemplateType"].ToString();

                    txtTemplateName.Text = dtLoadData.Rows[0]["TemplateName"].ToString();
                    txtSubject.Text = dtLoadData.Rows[0]["Subject"].ToString();
                    txtBody.Text = dtLoadData.Rows[0]["Body"].ToString();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmEmailFormate, Function: LoadData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private Boolean CheckValidation()
        {
            Boolean ISValid = false;
            try
            {
                if (cmbTemplateType.SelectedIndex < 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select TemplateType");
                    cmbTemplateType.Focus();
                    goto Final;
                }
                else if (txtTemplateName.Text == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter Template Name");
                    txtTemplateName.Focus();
                    goto Final;
                }
                else if (txtSubject.Text == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter Subject Name");
                    txtSubject.Focus();
                    goto Final;
                }
                else
                    ISValid = true;

                Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmEmailFormat,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }

        private void Clear()
        {
            cmbTemplateType.SelectedIndex = 0;
            txtTemplateName.Text = "";
            txtBody.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Mode == "insert")
                {
                    if (CheckValidation())
                    {
                        DataTable dtName = new BALEmailTemplate().SelectByTemplateName(new BOLEmailTemplate() { TemplateName = txtTemplateName.Text.Trim() });
                        if (dtName.Rows.Count == 0)
                        {
                            objBOLEmail.TemplateType = cmbTemplateType.Text.Trim();
                            objBOLEmail.TemplateName = txtTemplateName.Text.Trim();
                            objBOLEmail.Subject = txtSubject.Text.Trim();
                            objBOLEmail.Body = txtBody.Text.Trim();
                            objBALEmail.Insert(objBOLEmail);
                            MessageBox.Show("Email Template Save Successfully");
                            Clear();
                            ClsCommon.ObjEmailFormatList.LoadEmailTemplate();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Duplicate template name not allow");
                        }
                    }
                }
                else
                {
                    if (CheckValidation())
                    {
                        DataTable dtName = new BALEmailTemplate().SelectByTemplateNameUpdate(new BOLEmailTemplate() { TemplateName = txtTemplateName.Text.Trim(), ID = Convert.ToInt32(txtID.Text) });
                        if (dtName.Rows.Count == 0)
                        {
                            objBOLEmail.ID = Convert.ToInt32(txtID.Text);
                            objBOLEmail.TemplateType = cmbTemplateType.Text.Trim();
                            objBOLEmail.TemplateName = txtTemplateName.Text.Trim();
                            objBOLEmail.Subject = txtSubject.Text.Trim();
                            objBOLEmail.Body = txtBody.Text.Trim();
                            objBALEmail.Update(objBOLEmail);
                            MessageBox.Show("Email Template Update Successfully");
                            Clear();
                            ClsCommon.ObjEmailFormatList.LoadEmailTemplate();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Duplicate template name not allow");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmEmailFormat,Function :btnSave_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            try
            {
                for (int x = 0; x < lstFieldName.Items.Count; x++)
                {
                    // Determine if the item is selected.
                    if (lstFieldName.GetSelected(x) == true)
                    {
                        txtBody.Text += lstFieldName.Items[x].ToString();
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmEmailFormat,Function :btnMove_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}