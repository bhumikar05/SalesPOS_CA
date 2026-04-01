using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;

namespace POS
{
    public partial class FrmNoteMaster : ComponentFactory.Krypton.Toolkit.KryptonForm
    {

        BALCustomerMaster ObjCustomerBAL = new BALCustomerMaster();
        BOLCustomerMaster ObjCustomerBOL = new BOLCustomerMaster();

        BALNoteMaster ObjNoteBAL = new BALNoteMaster();
        BOLNoteMaster ObjNoteBOL = new BOLNoteMaster();

        public string CustomerID = "";

        public FrmNoteMaster() 
        {
            InitializeComponent();
        }
        private Boolean CheckValidation()
        {
            Boolean ISValid = true;
            try
            {
                if(txtNotes.Text == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter Notes");
                    txtNotes.Focus();
                }
                else if(rdbCurrentInvoice.Checked != true && rdbNumberOfDays.Checked != true)
                {
                    ISValid = false;
                    MessageBox.Show("Please select any one radiobutton");
                    rdbNumberOfDays.Focus();
                }      
              
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmNoteMaster,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
            return ISValid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(CheckValidation())
                {
                    ObjCustomerBOL = new BOLCustomerMaster();
                    ObjNoteBOL = new BOLNoteMaster();
                    if (txtid.Text == "")
                    {
                       
                        ObjNoteBOL.CusID = Convert.ToInt32(CustomerID);                  
                        ObjNoteBOL.Note = txtNotes.Text;
                        if (rdbNumberOfDays.Checked == true)
                        {
                            ObjNoteBOL.UseEveryTime = 1;                        
                        }
                        else if (rdbCurrentInvoice.Checked == true)
                        {
                            ObjNoteBOL.UseOneTime = 1;        
                        }
                        ObjNoteBAL.Insert(ObjNoteBOL);
                       
                        txtid.Text = "";
                        txtNotes.Text = "";
                        rdbNumberOfDays.Checked = true;
                        ClsCommon.ObjCustomerCenter.DisplayNotes(0);
                    }
                    else
                    {
                        ObjNoteBOL.ID = Convert.ToInt32(txtid.Text);
                        ObjNoteBOL.CusID = Convert.ToInt32(CustomerID);
                      
                        ObjNoteBOL.Note = txtNotes.Text;
                        if (rdbNumberOfDays.Checked == true)
                        {
                            ObjNoteBOL.UseEveryTime = 1;                       
                        }
                        else if (rdbCurrentInvoice.Checked == true)
                        {
                            ObjNoteBOL.UseOneTime = 1;        
                        }
                        ObjNoteBAL.Update(ObjNoteBOL);
                       
                        txtid.Text = "";
                        txtNotes.Text = "";
                        rdbNumberOfDays.Checked = true;
                        ClsCommon.ObjCustomerCenter.DisplayNotes(0);
                    }
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmNoteMaster, Function :btnSave_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void Showdata(Int32 ID)
        {
            try
            {
                DataTable dt = ObjNoteBAL.SelectByID(ID);
                if (dt.Rows.Count > 0)
                {
                    txtid.Text = dt.Rows[0]["ID"].ToString();
                    txtNotes.Text = dt.Rows[0]["Note"].ToString();
                    if (dt.Rows[0]["UseEveryTime"].ToString() == "1")
                    {
                        rdbNumberOfDays.Checked = true;
                    }
                    else if (dt.Rows[0]["UseOneTime"].ToString() == "1")
                    {
                        rdbCurrentInvoice.Checked = true;
                    }
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmNoteMaster, Function :Showdata. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
          
        }
    }
}