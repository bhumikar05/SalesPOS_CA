using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace POS
{
    public partial class FrmLogDetail : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALCusCallLog ObjCusBAL = new BALCusCallLog();
       // BOLCusCallLog ObjCusBOL = new BOLCusCallLog();
        public FrmLogDetail()
        {
            InitializeComponent();
        }
        private void DisplayMessage(string Text, string Mode)
        {
            switch (Mode)
            {
                case "W":
                    lblErrorMsg.StateCommon.TextColor = Color.FromArgb(16, 6, 244);
                    lblErrorMsg.StateNormal.TextColor = Color.FromArgb(16, 6, 244);
                    lblErrorMsg.Text = Text;
                    break;
                case "I":
                    lblErrorMsg.StateCommon.TextColor = Color.DarkGreen;
                    lblErrorMsg.StateNormal.TextColor = Color.DarkGreen;
                    lblErrorMsg.Text = Text;
                    break;
                case "E":
                    lblErrorMsg.StateCommon.TextColor = Color.DarkRed;
                    lblErrorMsg.StateNormal.TextColor = Color.DarkRed;
                    lblErrorMsg.Text = "Error: " + Text;
                    break;
            }
        }
        private void FrmLogDetail_Load(object sender, EventArgs e)
        {
            this.dgInvDetail.DefaultCellStyle.Font = new Font("", 10);
            dgInvDetail.RowTemplate.Height = 23;
            dgInvDetail.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgInvDetail.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8F, FontStyle.Regular);
            dgInvDetail.EnableHeadersVisualStyles = false;
        }
        public void Display(string ID)
        {
            try
            {
                dgInvDetail.Rows.Clear();
                DataTable dt = ObjCusBAL.SelectByCusID(Convert.ToInt32(ID));
                if (dt.Rows.Count > 0)
                {
                    int iRow = 0;
                    foreach (DataRow item in dt.Rows)
                    {                       
                        dgInvDetail.Rows.Add();
                        dgInvDetail[0, iRow].Value = item["ID"].ToString();
                        dgInvDetail[1, iRow].Value = item["LogName"].ToString();
                        iRow++;                    
                    }
                }
                else
                {
                    DisplayMessage("No Log Found", "E");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmLogDetail,Function :Display. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {          
            this.Close();
        }
    }
}
