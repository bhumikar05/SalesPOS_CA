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
    public partial class FrmNoteDetail : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public string CustomerID = "";
        BALNoteMaster ObjNoteBAL = new BALNoteMaster();
        BOLNoteMaster ObjNoteBOL = new BOLNoteMaster();
        public FrmNoteDetail()
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

        public void Display()
        {
            try
            {
                dgInvDetail.Rows.Clear();
                DataTable dt = ObjNoteBAL.SelectByCusID(Convert.ToInt32(CustomerID));
                if (dt.Rows.Count > 0)
                {    
                    int iRow = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        if(item["UseOneTime"].ToString() != "")
                        {
                            dgInvDetail.Rows.Add();
                            dgInvDetail[0, iRow].Value = item["ID"].ToString();
                            dgInvDetail[1, iRow].Value = item["CusID"].ToString();
                            dgInvDetail[2, iRow].Value = item["Note"].ToString();
                            dgInvDetail[3, iRow].Value = true;                        
                            iRow++;
                        }                 
                        else if (item["UseEveryTime"].ToString() != "")
                        {
                            dgInvDetail.Rows.Add();
                            dgInvDetail[0, iRow].Value = item["ID"].ToString();
                            dgInvDetail[1, iRow].Value = item["CusID"].ToString();
                            dgInvDetail[2, iRow].Value = item["Note"].ToString();
                            dgInvDetail[4, iRow].Value = true;                       
                            iRow++;
                        }
                        
                    }
                }
                else
                {
                   DisplayMessage("No Notes Found","E");
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmNoteDetail,Function :Display. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgInvDetail.Rows.Count > 0)
                {
                    for (int i = 0; i < dgInvDetail.Rows.Count; i++)
                    {
                        if (dgInvDetail.Rows[i].Cells[3].Value != null)
                        {
                            if (dgInvDetail.Rows[i].Cells[3].Value.ToString() == "True")
                            {
                                int id = Convert.ToInt32(dgInvDetail.Rows[i].Cells[0].Value.ToString());
                                ObjNoteBAL.Delete(id);
                            }
                        }
                        
                            
                        
                    }
                  
                }
                this.Close();
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmNoteDetail,Function :btnClose_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
           
         
        }

        private void FrmNoteDetail_Load(object sender, EventArgs e)
        {
            this.dgInvDetail.DefaultCellStyle.Font = new Font("", 10);
            dgInvDetail.RowTemplate.Height = 23;
            dgInvDetail.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgInvDetail.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8F, FontStyle.Regular);
            dgInvDetail.EnableHeadersVisualStyles = false;
        }
    }
}
