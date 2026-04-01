using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmResultUPS : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALUPS_FedExHistory objBAL = new BALUPS_FedExHistory();
        BOLUPS_FedExHistory objBOL = new BOLUPS_FedExHistory();

        string _Email = "";
        string _EntityId = "";
        string _CustomerName = "";
        string _OrderID = "";
        string _Status = "";
        string _TrackingNumber = "";

        public FrmResultUPS()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 50);
        }

        private void FrmResultUPS_Load(object sender, EventArgs e)
        {
        }

        public void LoadResultUPS(DataTable dtMaster, string entityId, string CustomerName, string OrderID, DataTable dtChild, string Email)
        {
            try
            {
                dgTrackingCodes.Rows.Clear();
                for (int i = 0; i < dtChild.Rows.Count; i++)
                {
                    dgTrackingCodes.Rows.Add();
                    dgTrackingCodes.Rows[i].Cells[0].Value = true;
                    dgTrackingCodes.Rows[i].Cells[1].Value = dtChild.Rows[i]["TrackingNumber"].ToString();
                }
                if (dtMaster.Rows.Count > 0)
                {
                    foreach (DataColumn dc in dtMaster.Columns)
                    {
                        if (dc.ColumnName == "TransportationCharges")
                            lblTransaportationCharge.Text = dtMaster.Rows[0]["TransportationCharges"].ToString();
                        else if (dc.ColumnName == "ServiceOptionsCharges")
                            lblServiceOptionCharge.Text = dtMaster.Rows[0]["ServiceOptionsCharges"].ToString();
                        else if (dc.ColumnName == "TotalCharges")
                            lblTotalCharge.Text = dtMaster.Rows[0]["TotalCharges"].ToString();
                        else if (dc.ColumnName == "ShipmentIdentificationNumber")
                            _TrackingNumber = dtMaster.Rows[0]["ShipmentIdentificationNumber"].ToString();
                    }
                    _Status = "Success";
                }
                _EntityId = entityId;
                _CustomerName = CustomerName;
                _OrderID = OrderID;
                _Email = Email;



                UpdateInDB();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmResultUPS,Function :LoadResultUPS. Message:" + ex.Message);
                MessageBox.Show(" Message:" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateInDB()
        {
            try
            {
                string _TrakcingCodes = "";
                GetTrackingInfo(ref _TrakcingCodes);
                if (_TrakcingCodes != "")
                {
                    if (_EntityId != "")
                    {
                        try
                        {
                            string Id = clsOnline.UpdateInInvoice(_EntityId, _TrakcingCodes, _Email);
                            //ClsCommon.ObjUnShippedInvList.LoadUnShippedInvoice();
                            if (Id == "")
                            {
                                MessageBox.Show("Issue During Update Tracking Code to QuickBooks");
                            }
                            //Insert History
                            objBOL.Type = "UPS";
                            objBOL.OrderID = _OrderID;
                            objBOL.TrackingID = _TrakcingCodes;
                            objBOL.Time = DateTime.Now;
                            objBOL.Status = _Status;
                            objBOL.CreatedBy = ClsCommon.UserID;
                            objBAL.UPS_FedExHistoryInsert(objBOL);

                           

                            // Mail send
                            //Commented by urvashi(19-10-2022).....

                            //FrmEmailTemplateList obj = new FrmEmailTemplateList();
                            //if (_EntityId != "")
                            //{
                            //    DataTable dtInvoice = new BALInvoiceMaster().SelectOrder(new BOLInvoiceMaster() { RefNumber = _EntityId });
                            //    if (dtInvoice.Rows.Count > 0)
                            //    {
                            //        DataTable dtCus = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(dtInvoice.Rows[0]["CustomerID"].ToString()) });
                            //        if (dtCus.Rows.Count > 0)
                            //        {
                            //            obj.EmialLoadDataTracking("Tracking", dtCus.Rows[0]["FullName"].ToString(), dtCus.Rows[0]["FirstName"].ToString(), dtCus.Rows[0]["LastName"].ToString(), _EntityId, dtCus.Rows[0]["CompanyName"].ToString(), dtCus.Rows[0]["Email"].ToString(), RetrieveShippingCodes_URL("UPS", _TrakcingCodes), _TrakcingCodes, "UPS", dtCus.Rows[0]["ID"].ToString());
                            //        }
                            //        obj.ShowDialog();
                            //    }
                            //}
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No any EntityID Found");
                    }
                    btnUpdateInDB.Enabled = false;
                }
                else
                {
                    
                    MessageBox.Show("Please Select Atleast one UPS Code");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmResultUPS,Function :UpdateInDB. Message:" + ex.Message);
                MessageBox.Show("Update Tracking Code. Message:" + ex.Message);
            }
        }

        private void btnUpdateInInvoice_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string _TrakcingCodes = "";
            //    GetTrackingInfo(ref _TrakcingCodes);
            //    if (_TrakcingCodes != "")
            //    {
            //        if (_EntityId != "")
            //        {
            //            try
            //            {
            //                string Id = clsOnline.UpdateInInvoice(_EntityId, _TrakcingCodes, _Email);
            //                ClsCommon.ObjUnShippedInvList.LoadUnShippedInvoice();
            //                if (Id == "")
            //                {
            //                    MessageBox.Show("Issue During Update Tracking Code to QuickBooks");
            //                }
            //                //Insert History
            //                objBOL.Type = "UPS";
            //                objBOL.OrderID = _OrderID;
            //                objBOL.TrackingID = _TrakcingCodes;
            //                objBOL.Time = DateTime.Now;
            //                objBOL.Status = _Status;
            //                objBOL.CreatedBy = ClsCommon.UserID;
            //                objBAL.UPS_FedExHistoryInsert(objBOL);

            //                //string Message = Program.mySetting.TrackingMessage;
            //                //Message = Message.Replace("{CUSTOMERNAME}", _CustomerName);
            //                //Message = Message.Replace("{URL}", RetrieveShippingCodes_URL("UPS", _TrakcingCodes));
            //                //Message = Message.Replace("{TRACKINGNUMBER}", _TrakcingCodes);
            //                //Message = Message.Replace("{SHIPCOMPANY}", "UPS");

            //                // Mail send
            //                FrmEmailTemplateList obj = new FrmEmailTemplateList();
            //                if (_EntityId != "")
            //                {
            //                    DataTable dtInvoice = new BALInvoiceMaster().SelectOrder(new BOLInvoiceMaster() { RefNumber = _EntityId });
            //                    if (dtInvoice.Rows.Count > 0)
            //                    {
            //                        DataTable dtCus = new BALCustomerMaster().SelectByID(new BOLCustomerMaster() { ID = Convert.ToInt32(dtInvoice.Rows[0]["CustomerID"].ToString()) });
            //                        if (dtCus.Rows.Count > 0)
            //                        {
            //                            obj.EmialLoadDataTracking("Tracking", dtCus.Rows[0]["FullName"].ToString(), dtCus.Rows[0]["FirstName"].ToString(), dtCus.Rows[0]["LastName"].ToString(), _EntityId, dtCus.Rows[0]["CompanyName"].ToString(), dtCus.Rows[0]["Email"].ToString(), RetrieveShippingCodes_URL("UPS", _TrakcingCodes), _TrakcingCodes, "UPS");
            //                        }
            //                        obj.ShowDialog();
            //                    }
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show(ex.Message);
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("No any EntityID Found");
            //        }
            //        btnUpdateInDB.Enabled = false;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please Select Atleast one UPS Code");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Update Tracking Code. Message:" + ex.Message);
            //}
        }

        private void GetTrackingInfo(ref string TrackingCode)
        {

            for (int i = 0; i < dgTrackingCodes.Rows.Count; i++)
            {
                if (dgTrackingCodes.Rows[i].Cells[0].EditedFormattedValue.ToString().ToLower() == "true")
                {
                    if (TrackingCode == "")
                        TrackingCode = dgTrackingCodes.Rows[i].Cells[1].EditedFormattedValue.ToString();
                    else
                        TrackingCode = TrackingCode + "," + dgTrackingCodes.Rows[i].Cells[1].EditedFormattedValue.ToString();
                }
            }
        }

        private string RetrieveShippingCodes_URL(string Code, string TracingNumber)
        {
            string NewURL = "";
            string Codes = "";
            try
            {
                foreach (string str in Program.mySetting.lstShippingCodes)
                {
                    string[] Code1 = str.Split('^');
                    if (Code1[0].ToString() == Code)
                    {
                        Codes = Code1[1].ToString();
                        break;
                    }
                }

                if (TracingNumber.Contains(","))
                {
                    string[] TCode = TracingNumber.Split(',');
                    NewURL = Codes.Replace("{TRACKINGNUMBER}", TCode[0].ToString());
                }
                else
                    NewURL = Codes.Replace("{TRACKINGNUMBER}", TracingNumber);
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmResultUPS,Function :RetrieveShippingCodes_URL. Message:" + ex.Message);
                MessageBox.Show("Update Tracking Code. Message:" + ex.Message);
            }
            return NewURL;

        }

        private void dgTrackingCodes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    if (File.Exists(Application.StartupPath + "\\Shipment\\" + dgTrackingCodes.Rows[e.RowIndex].Cells[1].Value.ToString() + ".bat"))
                        File.Delete(Application.StartupPath + "\\Shipment\\" + dgTrackingCodes.Rows[e.RowIndex].Cells[1].Value.ToString() + ".bat");

                    StreamWriter oWriter = new StreamWriter(Application.StartupPath + "\\Shipment\\" + dgTrackingCodes.Rows[e.RowIndex].Cells[1].Value.ToString() + ".bat");
                    oWriter.WriteLine("C:");
                    oWriter.WriteLine("CD " + ConfigurationManager.AppSettings["PicTools"].ToString());
                    oWriter.WriteLine("ois.exe \"" + Application.StartupPath + "\\Shipment\\" + dgTrackingCodes.Rows[e.RowIndex].Cells[1].Value.ToString() + ".gif" + "\"");

                    oWriter.Close();

                    Process proc = new Process();
                    proc.StartInfo.FileName = Application.StartupPath + "\\Shipment\\" + dgTrackingCodes.Rows[e.RowIndex].Cells[1].Value.ToString() + ".bat";
                    proc.Start();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmResultUPS,Function :dgTrackingCodes_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Update Tracking Code. Message:" + ex.Message);
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