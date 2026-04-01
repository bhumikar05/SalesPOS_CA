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
    public partial class FrmTrackingMaster : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALInvoiceMaster BALInvoiceMaster = new BALInvoiceMaster();
        BOLInvoiceMaster BOLInvoiceMaster = new BOLInvoiceMaster();

        BALItemMaster BALItem = new BALItemMaster();
        BOLItemMaster BOLItem = new BOLItemMaster();

        BALInvoiceDetails BALInvoiceDetails = new BALInvoiceDetails();
        BOLInvoiceDetails BOLInvoiceDetails = new BOLInvoiceDetails();

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        public FrmTrackingMaster()
        {
            InitializeComponent();        
        }   
        public void LoadData(string ID)
        {
            txtID.Text = ID;
            LoadUPSService();
            GetShipMethod();
        }
        private void LoadUPSService()
        {
            try
            {
                DataTable dtService = new DataTable();

                dtService.Columns.Add(new DataColumn("Code"));
                dtService.Columns.Add(new DataColumn("Description"));
                dtService.Rows.Add("0", "Select Service");
                dtService.Rows.Add("03", "UPS Ground");
                dtService.Rows.Add("13", "UPS Next Day Air Saver");
                dtService.Rows.Add("02", "UPS 2nd Day Air");
                dtService.Rows.Add("12", "UPS 3 Day Select");
                dtService.Rows.Add("01", "UPS Next Day Air");
                //dtService.Rows.Add("00", "Select Service");
                //dtService.Rows.Add("03", "UPS Ground");
                //dtService.Rows.Add("12", "UPS 3 Day Select");
                //dtService.Rows.Add("02", "UPS 2nd Day Air");
                //dtService.Rows.Add("59", "UPS  2nd Day Air AM");
                //dtService.Rows.Add("13", "UPS Next Day Air Saver");
                //dtService.Rows.Add("01", "UPS Next Day Air");
                //dtService.Rows.Add("14", "UPS Next Day Air Early A.M.");

                cmbService.DataSource = dtService;
                cmbService.DisplayMember = "Description";
                cmbService.ValueMember = "Code";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :LoadUPSService. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void GetShipMethod()
        {
            try
            {
                DataTable dtShipMethod = new BALShipMethod().SelectShipMethodAll(new BOLShipMethod() { });
                DataRow dr = dtShipMethod.NewRow();
                dr["Name"] = "--Select--";
                dr["ID"] = "0";
                dtShipMethod.Rows.InsertAt(dr, 0);
                cmbShippingMethod.DataSource = dtShipMethod;
                cmbShippingMethod.DisplayMember = "Name";
                cmbShippingMethod.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmInvoiceMaster,Function :GetShipMethod. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private Boolean CheckValidation()
        {
            Boolean ISValid = false;
            try
            {
                if (txtDesc.Text == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter Description");
                    txtDesc.Focus();
                    goto Final;
                }
                if (cmbService.SelectedIndex == 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select Service");
                    cmbService.Focus();
                    goto Final;
                }
                if (cmbShippingMethod.SelectedIndex == 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select ShippingMethod");
                    cmbShippingMethod.Focus();
                    goto Final;
                }
                else
                    ISValid = true;

                Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmTrackingMaster,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
               if(CheckValidation())
               {
                    new BALInvoiceMaster().UpdateIsSync(txtID.Text);

                    BOLInvoiceMaster.ID =Convert.ToInt32(txtID.Text);
                    if (cmbService.SelectedIndex > 0)
                    {
                        BOLInvoiceMaster.ServiceID = Convert.ToInt32(cmbService.SelectedValue);
                    } 
                    if(cmbShippingMethod.SelectedIndex > 0)
                    {
                        BOLInvoiceMaster.ShipMethodID = Convert.ToInt32(cmbShippingMethod.SelectedValue);
                    }         
                    
                    BALInvoiceMaster.UpdateIsShipping(BOLInvoiceMaster);

                    dt = new BALItemMaster().SelectBy();
                    if(dt.Rows.Count > 0)
                    {
                        BOLInvoiceDetails.InvoiceID = Convert.ToInt32(txtID.Text);
                        BOLInvoiceDetails.ItemID = Convert.ToInt32(dt.Rows[0]["ID"]);
                        BOLInvoiceDetails.Decs = txtDesc.Text;
                        BOLInvoiceDetails.Quantity = 1;
                        BOLInvoiceDetails.Rate = 0;
                        BOLInvoiceDetails.Amount = 0;
                        BOLInvoiceDetails.ItemType= dt.Rows[0]["ItemType"].ToString();
                        BOLInvoiceDetails.CreatedTime = DateTime.Now;

                        dt1 = BALInvoiceDetails.SelectByID(BOLInvoiceDetails);
                        if(dt1.Rows.Count > 0)
                        {
                            decimal Max = Convert.ToDecimal(dt1.Compute("Max([SrNo])", string.Empty));
                            BOLInvoiceDetails.SrNo = Convert.ToInt32(Max + 1);
                        }
                        BALInvoiceDetails.InvoiceDetailsInsert(BOLInvoiceDetails);

                        int NewInvoiceID = new BALInvoiceMaster().GetInvoiceID(Convert.ToInt32(txtID.Text));
                        BOLInvoiceDetails.InvoiceID = NewInvoiceID;
                        BALInvoiceDetails.NewInvoiceDetailsInsert(BOLInvoiceDetails);

                        MessageBox.Show("Record Update Successfully");
                        txtDesc.Text = "";
                        cmbShippingMethod.SelectedIndex = 0;
                        cmbService.SelectedIndex = 0;

                        ClsCommon.objTracking.Hide();
                        ClsCommon.objTrack.CheckInvoice(txtID.Text);

                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmTrackingMaster,Function :btnAdd_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClsCommon.objTracking.Hide();
        }

        private void FrmTrackingMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.Parent = null;            
        }
    }
}