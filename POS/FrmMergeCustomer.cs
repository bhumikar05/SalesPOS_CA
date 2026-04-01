using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DocumentFormat.OpenXml.Wordprocessing;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;

namespace POS
{
    public partial class FrmMergeCustomer : ComponentFactory.Krypton.Toolkit.KryptonForm
    {     
        public int CustomerID = 0;

        BOLInvoiceMaster objInvBOL = new BOLInvoiceMaster();
        BALInvoiceMaster objInvBAL = new BALInvoiceMaster();
        BALCustomerMaster ObjCustomerBAL = new BALCustomerMaster();
        public FrmMergeCustomer()
        {
            InitializeComponent();
        }

        public void display(DataTable dt)
        {
            try
            {
                dgCustomer.Rows.Clear();
                int iRow = 0;
                foreach (DataRow item in dt.Rows)
                {
                    dgCustomer.Rows.Add();
                    dgCustomer[0, iRow].Value = item["ID"].ToString();
                    dgCustomer[1, iRow].Value = item["CustomerName"].ToString();
                    dgCustomer[2, iRow].Value = item["CompanyName"].ToString();
                    dgCustomer[3, iRow].Value = item["Email"].ToString();
                    dgCustomer[4, iRow].Value = item["Phone"].ToString();
                    dgCustomer[5, iRow].Value = item["Address1"].ToString();
                    dgCustomer[6, iRow].Value = item["Address2"].ToString();
                    dgCustomer[7, iRow].Value = item["Address3"].ToString();
                    dgCustomer[8, iRow].Value = item["City"].ToString();
                    dgCustomer[9, iRow].Value = item["State"].ToString();
                    dgCustomer[10, iRow].Value = item["PostalCode"].ToString();
                    dgCustomer[11, iRow].Value = item["Country"].ToString();
                    iRow++;
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmMergeCustomer,Function :display. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
           
        }

        private void FrmMergeCustomer_Load(object sender, EventArgs e)
        {

        }

        private void dgCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 12)
                {
                    
                    var dialogResult = MessageBox.Show("The name is already being used.whould you like to merge them?", "Confirm!!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (dgCustomer.CurrentRow.Cells[0].Value.ToString() != CustomerID.ToString())
                        {
                            int id = Convert.ToInt32(dgCustomer.CurrentRow.Cells[0].Value.ToString());
                            objInvBOL = new BOLInvoiceMaster();
                            objInvBOL.CustomerID = CustomerID;
                            objInvBOL.OldCustomerID = id;
                            objInvBAL.UpdateCustomer(objInvBOL);


                            BOLCreditMemo ObjCreditmemo = new BOLCreditMemo();
                            BALCreditMemo ObjCreditmemoBal = new BALCreditMemo();
                            ObjCreditmemo.CustomerID = CustomerID;
                            ObjCreditmemo.OldCustomerID = id;
                            ObjCreditmemoBal.UpdateCustomer(ObjCreditmemo);

                            ObjCustomerBAL.UpdateCustomer(CustomerID);
                            ClsCommon.ObjCustomerCenter.LoadCustomer();
                            MessageBox.Show("Customer Merge Successfully");
                            this.Close();
                            ClsCommon.ObjCustomerMaster.Close();
                        }
                        else
                        {
                            MessageBox.Show("Customer Merge Successfully");
                            this.Close();
                            ClsCommon.ObjCustomerMaster.Close();
                        }
                        
                    }
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmMergeCustomer,Function :dgCustomer_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}