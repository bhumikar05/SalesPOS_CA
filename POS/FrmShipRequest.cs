using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace POS
{
    public partial class FrmShipRequest : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public static int UserID = 0;
        public static int InvoiceID = 0;
        BALShipRequest BALShipRequest = new BALShipRequest();
        BOLShipRequest BOLShipRequest = new BOLShipRequest();

        public FrmShipRequest()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable Ship1 = new BALShipRequest().SELECTBYAllowed(new BOLShipRequest() { InvoiceID = InvoiceID, UserID = ClsCommon.UserID });
            {
                if (Ship1.Rows.Count > 0)
                {
                    BOLShipRequest.ID = Convert.ToInt32(Ship1.Rows[0]["ID"].ToString());
                    BOLShipRequest.Reason = txtReason.Text;
                    BOLShipRequest.Allow = 0;
                    BOLShipRequest.Date=DateTime.Now;
                    BALShipRequest.Update(BOLShipRequest);
                    MessageBox.Show("Request Update");
                }
                else
                {
                    BOLShipRequest.InvoiceID = InvoiceID;
                    BOLShipRequest.UserID = UserID;
                    BOLShipRequest.Reason = txtReason.Text;
                    BOLShipRequest.Date = DateTime.Now;
                    BOLShipRequest.Allow = 0;
                    BALShipRequest.Insert(BOLShipRequest);
                    MessageBox.Show("Request Save");
                }
                this.Close();
            }
            
        }

        private void FrmShipRequest_Load(object sender, EventArgs e)
        {
            DataTable Ship1 = new BALShipRequest().SELECTBYID(new BOLShipRequest() { InvoiceID = InvoiceID, UserID = ClsCommon.UserID });
            if (Ship1.Rows.Count > 0)
            {
                txtReason.Text = Ship1.Rows[0]["Reason"].ToString();
            }
        }
    }
}