using DocumentFormat.OpenXml.Office2010.Excel;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.Collections.Generic;
using Telerik.WinControls.UI;
using Color = System.Drawing.Color;

namespace POS
{
    public partial class FrmUserAccess : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALUserMenuAccess ObjRoleBAL = new BALUserMenuAccess();
        BOLUserMenuAccess ObjRoleBOL = new BOLUserMenuAccess();
        BALUserSubMenuAccess ObjSubRoleBAL = new BALUserSubMenuAccess();
        BOLUserSubMenuAccess ObjSubRoleBOL = new BOLUserSubMenuAccess();
        Boolean IsValid = false;
        DataTable dtLoadFile = new DataTable();

        public FrmUserAccess()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            btnUpdate.Visible = false;
            btnClose.Visible = false;
            btnReset.Visible = false;
            btnSave.Location = new Point(329, 309);
        }

        private void FrmUserMenuAccess_Load(object sender, EventArgs e)
        {
            this.treeMenu.Font = new Font("", 10);

            if (IsValid == false)
            {
                GetUser();
                LoadData();
            }
            treeMenu.ExpandAll();
        }
        public void GetUser()
        {
            DataTable dtUser = new BALSalesRepMaster().SelectByUserName(new BOLSalesRepMaster() { });
            DataRow dr = dtUser.NewRow();
            dr["UserName"] = "--Select--";
            dr["ID"] = "0";
            dr["IsActive"] = "0";
            dtUser.Rows.InsertAt(dr, 0);
            cmbUserName.DataSource = dtUser;
            cmbUserName.DisplayMember = "UserName";
            cmbUserName.ValueMember = "ID";
            cmbUserName.SelectedIndex = 0;
        }

        private void LoadData()
        {
            try
            {
                DataTable dtMenu = new BALMenuMaster().Select(new BOLMenuMaster() { });
                if (dtMenu.Rows.Count > 0)
                {
                    DataView view = new DataView(dtMenu);
                    DataTable distinctValues = view.ToTable(true, "MenuParent");

                    int i = 0;
                    foreach (DataRow dr1 in distinctValues.Rows)
                    {
                        treeMenu.Nodes.Add(dr1["MenuParent"].ToString());

                        DataRow[] dr2 = dtMenu.Select("MenuParent='" + dr1["MenuParent"].ToString() + "'");
                        if (dr2.Length > 0)
                        {
                            int j = 0;
                            DataTable dtChild = dr2.CopyToDataTable();
                            foreach (DataRow dr3 in dtChild.Rows)
                            {
                                treeMenu.Nodes[i].Nodes.Add(dr3["ID"].ToString(), dr3["MenuName"].ToString());

                                DataTable dtSubMenu = new BALSubMenuMaster().SelectByMenuID(new BOLSubMenuMaster() { MenuID = Convert.ToInt32(dr3["ID"].ToString()) });
                                if (dtSubMenu.Rows.Count > 0)
                                {
                                    foreach (DataRow drSubChild in dtSubMenu.Rows)
                                    {
                                        treeMenu.Nodes[i].Nodes[j].Nodes.Add(drSubChild["ID"].ToString(), drSubChild["SubMenuName"].ToString());
                                    }
                                }
                                j++;
                            }
                        }
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUserAccess,Function :LoadData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void treeMenu_DrawNode(object sender, System.Windows.Forms.DrawTreeNodeEventArgs e)
        {
            try
            {
                if (e.Node.Parent == null)
                {
                    int d = (int)(0.2 * e.Bounds.Height);
                    Rectangle rect = new Rectangle(d + treeMenu.Margin.Left, d + e.Bounds.Top, e.Bounds.Height - d * 2, e.Bounds.Height - d * 2);
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.Control)), rect);
                    e.Graphics.DrawRectangle(Pens.Silver, rect);
                    StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
                    e.Graphics.DrawString(e.Node.IsExpanded ? "-" : "+", treeMenu.Font, new SolidBrush(Color.Blue), rect, sf);
                    //Draw the dotted line connecting the expanding/collapsing button and the node Text
                    using (Pen dotted = new Pen(Color.Black) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot })
                    {
                        e.Graphics.DrawLine(dotted, new Point(rect.Right + 1, rect.Top + rect.Height / 2), new Point(rect.Right + 4, rect.Top + rect.Height / 2));
                    }
                    //Draw text
                    sf.Alignment = StringAlignment.Near;
                    Rectangle textRect = new Rectangle(e.Bounds.Left + rect.Right + 4, e.Bounds.Top, e.Bounds.Width - rect.Right - 4, e.Bounds.Height);
                    if (e.Node.IsSelected)
                    {
                        SizeF textSize = e.Graphics.MeasureString(e.Node.Text, treeMenu.Font);
                        e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), new RectangleF(textRect.Left, textRect.Top, textSize.Width, textRect.Height));
                    }
                    e.Graphics.DrawString(e.Node.Text, treeMenu.Font, new SolidBrush(treeMenu.ForeColor), textRect, sf);
                }
                else e.DrawDefault = true;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUserAccess,Function :treeMenu_DrawNode. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private Boolean CheckValidation()
        {
            Boolean ISValid = true;
            try
            {
                if (cmbUserName.SelectedIndex == 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select User");
                    cmbUserName.Focus();
                    goto Final;
                }

            //TreeNodeCollection nodes = treeMenu.Nodes;
            //foreach (TreeNode node in nodes)
            //{
            //    foreach (TreeNode childNode in node.Nodes)
            //    {
            //        if (childNode.Checked == true)
            //        {
            //            foreach (TreeNode SubchildNode in childNode.Nodes)
            //            {
            //                if (SubchildNode.Checked == true)
            //                {
            //                    ISValid = true;
            //                }
            //            }
            //        }
            //        else if (childNode.Checked == false)
            //        {
            //            foreach (TreeNode SubchildNode in childNode.Nodes)
            //            {
            //                if (SubchildNode.Checked == true)
            //                {
            //                    MessageBox.Show("Please Select Proper Data");
            //                    ISValid = false;
            //                    goto Final;
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Please select Data");
            //                    ISValid = false;
            //                    goto Final;
            //                }
            //            }
            //        }
            //        ISValid = true;
            //    }
            //}
            Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUserAccess,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }

        private void Reset()
        {
            cmbUserName.SelectedIndex = 0;

            TreeNodeCollection nodes = treeMenu.Nodes;
            foreach (TreeNode node in nodes)
            {
                node.Checked = false;
                CheckChildren(node, false);
            }
        }

        private void CheckChildren(TreeNode rootNode, bool isChecked)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                CheckChildren(node, isChecked);
                node.Checked = isChecked;
            }
        }

        public Boolean SaveData()
        {
            Boolean ISValid = false;
            try
            {
                if (CheckValidation())
                {
                    DataTable dtChk = new BALUserMenuAccess().SelectForSave(new BOLUserMenuAccess() { UserID = Convert.ToInt32(cmbUserName.SelectedValue) });
                    if (dtChk.Rows.Count == 0)
                    {
                        TreeNodeCollection nodes = treeMenu.Nodes;
                        foreach (TreeNode node in nodes)
                        {
                            foreach (TreeNode childNode in node.Nodes)
                            {
                                if (childNode.Checked == true)
                                {
                                    ObjRoleBOL.UserID = Convert.ToInt32(cmbUserName.SelectedValue);
                                    ObjRoleBOL.MenuID = Convert.ToInt32(childNode.Name);
                                    ObjRoleBAL.Insert(ObjRoleBOL);

                                    if (childNode.Nodes.Count > 0)
                                    {
                                        foreach (TreeNode SubchildNode in childNode.Nodes)
                                        {
                                            if (SubchildNode.Checked == true)
                                            {
                                                ObjSubRoleBOL.UserID = Convert.ToInt32(cmbUserName.SelectedValue);
                                                ObjSubRoleBOL.MenuID = Convert.ToInt32(childNode.Name);
                                                ObjSubRoleBOL.SubMenuID = Convert.ToInt32(SubchildNode.Name);
                                                ObjSubRoleBAL.Insert(ObjSubRoleBOL);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        MessageBox.Show("Record save successfully");
                        ISValid = true;
                        Reset();
                    }
                    else
                    {
                        ISValid = false;
                        MessageBox.Show("This Role is already exists");
                    }
                }
                else
                {
                    ISValid = false;
                }
            }
            catch (Exception ex)
            {
                ISValid = false;
                ClsCommon.WriteErrorLogs("Form:FrmUserAccess,Function :SaveData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        Final:
            return ISValid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("Insert", "AddNewUserAccess"))
                {
                    if (SaveData())
                    {
                        Reset();
                        cmbUserName.Focus();
                    }
                    else
                    {
                        ClsCommon.WriteErrorLogs("Form:FrmUserAccess,Function :btnSave_Click. Message: Error Create UserMenuAccess Data");
                    }
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUserMenuAccessAdd,Function :btnSave_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidation())
                {
                    ObjRoleBOL.UserID = Convert.ToInt32(cmbUserName.SelectedValue);
                    ObjRoleBAL.Delete(ObjRoleBOL);
                    ObjSubRoleBOL.UserID = Convert.ToInt32(cmbUserName.SelectedValue);
                    ObjSubRoleBAL.Delete(ObjSubRoleBOL);

                    TreeNodeCollection nodes = treeMenu.Nodes;
                    foreach (TreeNode node in nodes)
                    {
                        foreach (TreeNode childNode in node.Nodes)
                        {
                            if (childNode.Checked == true)
                            {
                                ObjRoleBOL.UserID = Convert.ToInt32(cmbUserName.SelectedValue);
                                ObjRoleBOL.MenuID = Convert.ToInt32(childNode.Name);
                                ObjRoleBAL.Insert(ObjRoleBOL);

                                if (childNode.Nodes.Count > 0)
                                {
                                    foreach (TreeNode SubchildNode in childNode.Nodes)
                                    {
                                        if (SubchildNode.Checked == true)
                                        {
                                            ObjSubRoleBOL.UserID = Convert.ToInt32(cmbUserName.SelectedValue);
                                            ObjSubRoleBOL.MenuID = Convert.ToInt32(childNode.Name);
                                            ObjSubRoleBOL.SubMenuID = Convert.ToInt32(SubchildNode.Name);
                                            ObjSubRoleBAL.Insert(ObjSubRoleBOL);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    MessageBox.Show("Record update successfully");
                    Reset();
                    btnUpdate.Enabled = false;
                    btnSave.Enabled = true;
                    cmbUserName.Enabled = true;

                    treeMenu.Nodes.Clear();
                    LoadData();
                    treeMenu.ExpandAll();
                }

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUserAccess,Function :btnUpdate_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            treeMenu.Nodes.Clear();
            LoadData();
            treeMenu.ExpandAll();
            Reset();
            cmbUserName.Enabled = true;
        }

        public void ShowFile(string ID)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnUpdate.Visible = true;
                btnClose.Visible = true;
                btnReset.Visible = true;
                btnSave.Visible = false;

                DataTable dtShowFile = new DataTable();
                dtShowFile = new BALUserMenuAccess().SelectByUserID(new BOLUserMenuAccess() { UserID = Convert.ToInt32(ID) });
                if (dtShowFile.Rows.Count > 0)
                {
                    GetUser();
                    LoadData(); IsValid = true;
                    txtID.Text = dtShowFile.Rows[0]["ID"].ToString();
                    cmbUserName.SelectedValue = dtShowFile.Rows[0]["UserID"].ToString();

                    foreach (DataRow dr in dtShowFile.Rows)
                    {
                        TreeNodeCollection nodes = treeMenu.Nodes;
                        foreach (TreeNode node in nodes)
                        {
                            foreach (TreeNode childNode in node.Nodes)
                            {
                                if (childNode.Text == dr["MenuName"].ToString())
                                    childNode.Checked = true;
                                if (childNode.Nodes.Count > 0)
                                {
                                    DataTable dt = new BALUserSubMenuAccess().SelectByUserID(new BOLUserSubMenuAccess() { UserID = Convert.ToInt32(ID), MenuID = Convert.ToInt32(dr["MenuID"].ToString()), MenuName = childNode.Text });
                                    if (dt.Rows.Count > 0)
                                    {
                                        foreach (TreeNode SubchildNode in childNode.Nodes)
                                        {
                                            DataRow[] dr1 = dt.Select("SubMenuName='" + SubchildNode.Text + "'");
                                            if (dr1.Length > 0)
                                            {
                                                SubchildNode.Checked = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        treeMenu.ExpandAll();
                    }
                   
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = true;
                    cmbUserName.Enabled = false;
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUserAccess,Function :ShowFile. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void cmbUserName_Leave(object sender, EventArgs e)
        {

            ShowFile1(cmbUserName.SelectedValue.ToString());
        }
        public void ShowFile1(string ID)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnUpdate.Visible = true;
                btnClose.Visible = true;
                btnReset.Visible = true;
                btnSave.Visible = false;

                DataTable dtShowFile = new DataTable();
                dtShowFile = new BALUserMenuAccess().SelectByUserID(new BOLUserMenuAccess() { UserID = Convert.ToInt32(ID) });
                if (dtShowFile.Rows.Count > 0)
                {
                    IsValid = true;
                    txtID.Text = dtShowFile.Rows[0]["ID"].ToString();
                    cmbUserName.SelectedValue = dtShowFile.Rows[0]["UserID"].ToString();

                    foreach (DataRow dr in dtShowFile.Rows)
                    {
                        TreeNodeCollection nodes = treeMenu.Nodes;
                        foreach (TreeNode node in nodes)
                        {
                            foreach (TreeNode childNode in node.Nodes)
                            {
                                if (childNode.Text == dr["MenuName"].ToString())
                                    childNode.Checked = true;
                                if (childNode.Nodes.Count > 0)
                                {
                                    DataTable dt = new BALUserSubMenuAccess().SelectByUserID(new BOLUserSubMenuAccess() { UserID = Convert.ToInt32(ID), MenuID = Convert.ToInt32(dr["MenuID"].ToString()), MenuName = childNode.Text });
                                    if (dt.Rows.Count > 0)
                                    {
                                        foreach (TreeNode SubchildNode in childNode.Nodes)
                                        {
                                            DataRow[] dr1 = dt.Select("SubMenuName='" + SubchildNode.Text + "'");
                                            if (dr1.Length > 0)
                                            {
                                                SubchildNode.Checked = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        treeMenu.ExpandAll();
                    }
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = true;
                    cmbUserName.Enabled = false;
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUserAccess,Function :ShowFile. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void cmbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtLoadFile = new DataTable();
            if (cmbUserName.SelectedIndex != 0)
            {
                //LoadData();
                dtLoadFile = new BALSalesRepMaster().SelectByID(new BOLSalesRepMaster() { ID = Convert.ToInt32(cmbUserName.SelectedValue) });
                if (dtLoadFile.Rows[0]["AssistantAdminID"].ToString() != "" && dtLoadFile.Rows[0]["AssistantAdminID"].ToString() != "0")
                {
                    treeMenu.Nodes.Clear();
                    //DataTable dtMenu = new BALMenuMaster().Select(new BOLMenuMaster() { });
                    DataTable dtMenu  = new BALUserMenuAccess().SelectByUserID(new BOLUserMenuAccess() { UserID = Convert.ToInt32(dtLoadFile.Rows[0]["AssistantAdminID"].ToString()) });
                    if (dtMenu.Rows.Count > 0)
                    {
                        DataView view = new DataView(dtMenu);
                        DataTable distinctValues = view.ToTable(true, "MenuParent");

                        int i = 0;
                        foreach (DataRow dr1 in distinctValues.Rows)
                        {
                            treeMenu.Nodes.Add(dr1["MenuParent"].ToString());

                            DataRow[] dr2 = dtMenu.Select("MenuParent='" + dr1["MenuParent"].ToString() + "'");
                            if (dr2.Length > 0)
                            {
                                int j = 0;
                                DataTable dtChild = dr2.CopyToDataTable();
                                foreach (DataRow dr3 in dtChild.Rows)
                                {
                                    treeMenu.Nodes[i].Nodes.Add(dr3["MenuID"].ToString(), dr3["MenuName"].ToString());
                                    DataTable dtSubMenu = new BALUserSubMenuAccess().SelectByUserID(new BOLUserSubMenuAccess() { UserID = Convert.ToInt32(dtLoadFile.Rows[0]["AssistantAdminID"].ToString()), MenuID = Convert.ToInt32(dr3["MenuID"].ToString()) , MenuName = dr3["MenuName"].ToString() });
                                    //DataTable dtSubMenu = new BALSubMenuMaster().SelectByMenuID(new BOLSubMenuMaster() { MenuID = Convert.ToInt32(dr3["MenuID"].ToString()) });
                                    if (dtSubMenu.Rows.Count > 0)
                                    {
                                        foreach (DataRow drSubChild in dtSubMenu.Rows)
                                        {
                                            treeMenu.Nodes[i].Nodes[j].Nodes.Add(drSubChild["SubMenuID"].ToString(), drSubChild["SubMenuName"].ToString());
                                        }
                                    }
                                    j++;
                                }
                            }
                            i++;
                        }
                    }
                    treeMenu.ExpandAll();

                }
                else
                {
                    treeMenu.Nodes.Clear();
                    LoadData();
                    treeMenu.ExpandAll();
                }
              
            }
        }
        
    }
}