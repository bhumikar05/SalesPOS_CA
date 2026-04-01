using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmChat : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALChatMaster ObjChatBAL = new BALChatMaster();
        BOLChatMaster ObjChatBOL = new BOLChatMaster();
        Boolean IsOpen = false;
        string Count = "";
        DataTable dtUser = new DataTable();

        public FrmChat()
        {
            InitializeComponent();
        }

        private void FrmChatApp_Load(object sender, EventArgs e)
        {
            try
            {
                dgvSalesRepList.DefaultCellStyle.BackColor = Color.Gray;
                dgvSalesRepList.DefaultCellStyle.ForeColor = Color.White;
                dgvSalesRepList.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                dgvSalesRepList.EnableHeadersVisualStyles = false;

                dgvListMessage.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.dgvListMessage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvListMessage.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmChat, Method: FrmChatApp_Load. Message" + ex.Message);
                MessageBox.Show("Message: " + ex.Message);
            }
           
        }

        public void LoadFunction()
        {
            try
            {
                IsOpen = false;
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(0, 50);
                this.Width = 290;
                LoadUserName();
                lblLoginUserName.Text = ClsCommon.Name;
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmChat, Method: LoadFunction. Message" + ex.Message);
                MessageBox.Show("Message: " + ex.Message);
            }
           
        }

        public void LoadData(Int32 ReceiverID, string ReceiverName)
        {
            try
            {
                txtGroupStatus.Text = "0";
                //IsOpen = true;
                this.Width = 960;
                LoadUserName();
                lblLoginUserName.Text = ClsCommon.Name;
                txtReceiverID.Text = ReceiverID.ToString();
                lblReceiverName.Text = ReceiverName;
                if (ReceiverID.ToString() != "")
                {
                    //Update IsRead
                    DataTable dtRead = new BALChatMaster().SelectUnReadMessageByID(new BOLChatMaster() { ReceiverID = ClsCommon.UserID, SenderID = ReceiverID });
                    if (dtRead.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtRead.Rows)
                        {
                            ObjChatBOL.ID = Convert.ToInt32(dr["ID"].ToString());
                            ObjChatBOL.IsRead = 1;
                            ObjChatBAL.UpdateIsRead(ObjChatBOL);
                        }
                    }
                }
                LoadAllMessage();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmChat, Method: LoadData. Message" + ex.Message);
                MessageBox.Show("Message: " + ex.Message);
            }
        }

        public void LoadGroupMessage(Int32 ReceiverID, string ReceiverName)
        {
            try
            {
                txtGroupStatus.Text = "1";
                this.Width = 960;
                pnlMessageList.Controls.Remove(dgvListMessage);
                pnlMessageList.Controls.Remove(pnlMessage);
                dgvListMessage.SendToBack();
                pnlMessage.SendToBack();
                dgvListMessage.Visible = false;
                pnlMessage.Visible = false;
                pnlMessageList.Controls.Add(pnlGroupAnnounncementMessage);
                pnlGroupAnnounncementMessage.BringToFront();
                pnlGroupAnnounncementMessage.Visible = true;
                txtGroupAnnounncementMessage.ReadOnly = true;

                lblLoginUserName.Text = ClsCommon.Name;
                txtReceiverID.Text = ReceiverID.ToString();
                lblReceiverName.Text = ClsCommon.Name + ": Announcement";
                if (ReceiverID.ToString() != "")
                {
                    //Update IsRead
                    DataTable dtRead = new BALChatMaster().SelectUnReadGroupMessageByID(new BOLChatMaster() { ReceiverID = ClsCommon.UserID, SenderID = ReceiverID });
                    if (dtRead.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtRead.Rows)
                        {
                            ObjChatBOL.ID = Convert.ToInt32(dr["ID"].ToString());
                            ObjChatBOL.IsRead = 1;
                            ObjChatBAL.UpdateIsRead(ObjChatBOL);
                            txtGroupAnnounncementMessage.Text = dr["Message"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmChat, Method: LoadGroupMessage. Message" + ex.Message);
                MessageBox.Show("Message: " + ex.Message);
            }
        }

        public void LoadUserName()
        {
            try
            {
                dtUser = new DataTable();
                dtUser = new BALSalesRepMaster().SelectLoginUser(new BOLSalesRepMaster() { });
                if (dtUser.Rows.Count > 0)
                {
                    int j = 0;
                    dgvSalesRepList.Rows.Clear();
                    for (int i = 0; i < dtUser.Rows.Count; i++)
                    {
                        dgvSalesRepList.Rows.Add();
                        dgvSalesRepList.Rows[j].Cells[0].Value = dtUser.Rows[i]["ID"].ToString();
                        dgvSalesRepList.Rows[j].Cells[1].Value = dtUser.Rows[i]["Name"].ToString();
                        dgvSalesRepList.Rows[j].Cells[2].Value = dtUser.Rows[i]["UserType"].ToString();
                        j++;
                    }
                }
                else
                    dgvSalesRepList.Rows.Clear();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmChat, Method: LoadUserName. Message" + ex.Message);
                MessageBox.Show("Message: " + ex.Message);
            }
        }

        public void LoadAllMessage()
        {
            try
            {
                if (txtReceiverID.Text != "")
                {
                    // Message ListView add
                    dgvListMessage.Rows.Clear();
                    if (dgvSalesRepList.Rows.Count > 0)
                    {
                        DataTable dtMessege = new BALChatMaster().SelectByID(new BOLChatMaster() { SenderID = ClsCommon.UserID, ReceiverID = Convert.ToInt32(txtReceiverID.Text) });
                        if (dtMessege.Rows.Count > 0)
                        {
                            int j = 0;
                            dgvListMessage.Rows.Clear();
                            for (int i = 0; i < dtMessege.Rows.Count; i++)
                            {
                                if (dtMessege.Rows[i]["GroupMessage"].ToString() != "1")
                                {
                                    dgvListMessage.Rows.Add();
                                    if (Convert.ToInt32(dtMessege.Rows[i]["SenderID"].ToString()) == ClsCommon.UserID && Convert.ToInt32(dtMessege.Rows[i]["ReceiverID"].ToString()) == Convert.ToInt32(txtReceiverID.Text))
                                    {
                                        dgvListMessage.Rows[j].Cells[0].Value = "";
                                        dgvListMessage.Rows[j].Cells[1].Value = dtMessege.Rows[i]["SenderName"].ToString() + "  " + Convert.ToDateTime(dtMessege.Rows[i]["Time"].ToString()).ToString("HH:mm") + Environment.NewLine + dtMessege.Rows[i]["Message"].ToString();
                                    }
                                    else if (Convert.ToInt32(dtMessege.Rows[i]["SenderID"].ToString()) == Convert.ToInt32(txtReceiverID.Text) && Convert.ToInt32(dtMessege.Rows[i]["ReceiverID"].ToString()) == ClsCommon.UserID)
                                    {
                                        dgvListMessage.Rows[j].Cells[0].Value = dtMessege.Rows[i]["SenderName"].ToString() + "  " + Convert.ToDateTime(dtMessege.Rows[i]["Time"].ToString()).ToString("HH:mm") + Environment.NewLine + dtMessege.Rows[i]["Message"].ToString();
                                        dgvListMessage.Rows[j].Cells[1].Value = "";
                                    }
                                    j++;
                                }
                            }
                            //foreach (DataRow dr in dtMessege.Rows)
                            //{
                            //    if (dr["GroupMessage"].ToString() != "1")
                            //        ListMessage.Items.Add(dr["SenderName"].ToString() + "  " + Convert.ToDateTime(dr["Time"]).ToString("HH:mm") + " : " + dr["Message"].ToString());
                            //}
                        }
                    }
                }
                if (txtReceiverID.Text != "" && lblReceiverName.Text != "")
                {
                    if (txtGroupStatus.Text == "0")
                    {
                        //Update IsRead
                        DataTable dtRead = new BALChatMaster().SelectUnReadMessageByID(new BOLChatMaster() { ReceiverID = ClsCommon.UserID, SenderID = Convert.ToInt32(txtReceiverID.Text) });
                        if (dtRead.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtRead.Rows)
                            {
                                ObjChatBOL.ID = Convert.ToInt32(dr["ID"].ToString());
                                ObjChatBOL.IsRead = 1;
                                ObjChatBAL.UpdateIsRead(ObjChatBOL);
                            }
                        }
                    }
                }
                dgvListMessage.FirstDisplayedCell = dgvListMessage.Rows[dgvListMessage.Rows.Count - 1].Cells[0];
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmChat, Method: LoadAllMessage. Message" + ex.Message);
                MessageBox.Show("Message: " + ex.Message);
            }
        }

        public string MessageCount()
        {
            try
            {
                Count = "";
                DataTable dtChatCount = new BALChatMaster().SelectTotalMessageByID(new BOLChatMaster() { ReceiverID = ClsCommon.UserID });
                if (dtChatCount.Rows.Count > 0)
                {
                    Count = dtChatCount.Rows.Count.ToString();
                }
                else
                    Count = "0";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmChat,Function :MessageCount. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
            return Count;
        }

        private void LoadUnReadmessage()
        {
            try
            {
                DataTable dtSalesRep = new BALSalesRepMaster().SelectByID(new BOLSalesRepMaster() { ID = Convert.ToInt32(dgvSalesRepList.CurrentRow.Cells["ID"].Value) });
                if (dtSalesRep.Rows.Count > 0)
                {
                    this.Width = 960;
                    txtReceiverID.Text = dtSalesRep.Rows[0]["ID"].ToString();
                    lblReceiverName.Text = dtSalesRep.Rows[0]["Name"].ToString();
                    LoadAllMessage();
                    txtMessage.Focus();
                }
                //Update IsRead By ID
                DataTable dtRead = new BALChatMaster().SelectUnReadMessageByID(new BOLChatMaster() { ReceiverID = ClsCommon.UserID, SenderID = Convert.ToInt32(dgvSalesRepList.CurrentRow.Cells["ID"].Value) });
                if (dtRead.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtRead.Rows)
                    {
                        ObjChatBOL.ID = Convert.ToInt32(dr["ID"].ToString());
                        ObjChatBOL.IsRead = 1;
                        ObjChatBAL.UpdateIsRead(ObjChatBOL);
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmChat, Method: LoadUnReadmessage. Message" + ex.Message);
                MessageBox.Show("Message: " + ex.Message);
            }
        }

        public void ListMessageVisibility()
        {
            try
            {
                pnlMessageList.Controls.Add(dgvListMessage);
                pnlMessageList.Controls.Add(pnlMessage);
                dgvListMessage.BringToFront();
                pnlMessage.BringToFront();
                dgvListMessage.Visible = true;
                pnlMessage.Visible = true;
                pnlMessageList.Controls.Remove(pnlGroupAnnounncementMessage);
                pnlGroupAnnounncementMessage.SendToBack();
                pnlGroupAnnounncementMessage.Visible = false;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmChat, Method: ListMessageVisibility. Message" + ex.Message);
                MessageBox.Show("Message: " + ex.Message);
            }
        }

        private void dgvSalesRepList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                pnlMessageList.Controls.Add(dgvListMessage);
                pnlMessageList.Controls.Add(pnlMessage);
                dgvListMessage.BringToFront();
                pnlMessage.BringToFront();
                dgvListMessage.Visible = true;
                pnlMessage.Visible = true;
                pnlMessageList.Controls.Remove(pnlGroupAnnounncementMessage);
                pnlGroupAnnounncementMessage.SendToBack();
                pnlGroupAnnounncementMessage.Visible = false;

                LoadUnReadmessage();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmChat, Method: dgvSalesRepList_CellContentDoubleClick. Message" + ex.Message);
                MessageBox.Show("Message: " + ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtReceiverID.Text != "" && txtMessage.Text.Trim() != "")
                {
                    ObjChatBOL.SenderID = ClsCommon.UserID;
                    ObjChatBOL.ReceiverID = Convert.ToInt32(txtReceiverID.Text);
                    ObjChatBOL.Message = txtMessage.Text;
                    ObjChatBOL.Date = DateTime.Now;
                    ObjChatBOL.Time = DateTime.Now.ToString("HH:mm");
                    ObjChatBOL.CreatedID = ClsCommon.UserID;
                    if (IsOpen == true)
                        ObjChatBOL.IsRead = 1;
                    else
                        ObjChatBOL.IsRead = 0;
                    ObjChatBOL.GroupMessage = 0;
                    ObjChatBAL.Insert(ObjChatBOL);

                    Int32 j = dgvListMessage.Rows.Count - 1;
                    dgvListMessage.Rows[j].Cells[0].Value = "";
                    dgvListMessage.Rows[j].Cells[1].Value = lblLoginUserName.Text + "  " + DateTime.Now.ToString("HH:mm") + Environment.NewLine + txtMessage.Text;
                    //ListMessage.Items.Add(lblLoginUserName.Text + "  " + DateTime.Now.ToString("HH:mm") + " : " + txtMessage.Text);
                    txtMessage.Text = ""; txtMessage.Focus();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmChat, Method: btnSend_Click. Message" + ex.Message);
                MessageBox.Show("Message: " + ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                LoadUserName();
                LoadAllMessage();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmChat, Method: timer_Tick. Message" + ex.Message);
                MessageBox.Show("Message: " + ex.Message);
            }
        }

        private void FrmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                txtReceiverID.Text = "";
                lblReceiverName.Text = "";
                ClsCommon.objChat.Hide();
                ClsCommon.objChat.Parent = null;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form: FrmChat, Method: FrmChat_FormClosing. Message" + ex.Message);
                MessageBox.Show("Message: " + ex.Message);
            }

        }

        private void dgvSalesRepList_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (dgvSalesRepList.Rows.Count > 0)
                {
                    if (dgvSalesRepList.CurrentRow.Cells[2].Value.ToString() == "Admin" || dgvSalesRepList.CurrentRow.Cells[2].Value.ToString() == "admin")
                    {
                        int Row = dgvSalesRepList.CurrentRow.Index;
                        if (e.Button == MouseButtons.Right)
                        {
                            ContextMenuStrip contexMenu = new ContextMenuStrip();

                            contexMenu.Items.Add("Group Announcement");
                            //contexMenu.Show(this, btnMessageCount.Location, ToolStripDropDownDirection.AboveRight);
                            var pos = ((DataGridView)sender).GetCellDisplayRectangle(1, Row, false).Location;
                            pos.X = e.X;
                            pos.Y = e.Y;
                            contexMenu.Show((DataGridView)sender, pos);
                            contexMenu.ItemClicked += new ToolStripItemClickedEventHandler(
                                contexMenu_ItemClicked);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmChat,Function :dgvSalesRepList_MouseClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void contexMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem.Text != "")
                {
                    this.Width = 960;
                    txtGroupAnnounncementMessage.Text = "";
                    pnlMessageList.Controls.Remove(dgvListMessage);
                    pnlMessageList.Controls.Remove(pnlMessage);
                    dgvListMessage.SendToBack();
                    pnlMessage.SendToBack();
                    dgvListMessage.Visible = false;
                    pnlMessage.Visible = false;
                    pnlMessageList.Controls.Add(pnlGroupAnnounncementMessage);
                    pnlGroupAnnounncementMessage.BringToFront();
                    pnlGroupAnnounncementMessage.Visible = true;
                    txtGroupAnnounncementMessage.ReadOnly = false;
                    lblReceiverName.Text = "To: Admin";
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmChat,Function :contexMenu_ItemClicked. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void txtGroupAnnounncementMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (txtGroupAnnounncementMessage.Text.Trim() != "")
                    {
                        DataTable dt = new BALSalesRepMaster().Select(new BOLSalesRepMaster() { });
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr["UserType"].ToString() != "Admin" && dr["UserType"].ToString() != "admin")
                                {
                                    ObjChatBOL.SenderID = ClsCommon.UserID;
                                    ObjChatBOL.ReceiverID = Convert.ToInt32(dr["ID"].ToString());
                                    ObjChatBOL.Message = txtGroupAnnounncementMessage.Text.Trim();
                                    ObjChatBOL.Date = DateTime.Now;
                                    ObjChatBOL.Time = DateTime.Now.ToString("HH:mm");
                                    ObjChatBOL.CreatedID = ClsCommon.UserID;
                                    ObjChatBOL.IsRead = 0;
                                    ObjChatBOL.GroupMessage = 1;
                                    ObjChatBAL.Insert(ObjChatBOL);
                                }
                            }
                            this.Width = 290;
                            //txtGroupAnnounncementMessage.Text = "";
                            //txtGroupAnnounncementMessage.Focus();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmChat,Function :txtGroupAnnounncementMessage_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
          
        }
    }
}