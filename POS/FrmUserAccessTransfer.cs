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
    public partial class FrmUserAccessTransfer : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALUserMenuAccess ObjBALUserMenu = new BALUserMenuAccess();
        BOLUserMenuAccess ObjBOLUserMenu = new BOLUserMenuAccess();

        BALUserSubMenuAccess ObjBALUserSubMenu = new BALUserSubMenuAccess();
        BOLUserSubMenuAccess ObjBOLUserSubMenu =new BOLUserSubMenuAccess();
        public FrmUserAccessTransfer()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.Location = new Point(0, 0);
        }

        private void FrmUserMenuAccess_Load(object sender, EventArgs e)
        {
            GetFromUser();
            GetToUser();
        }
        public void GetFromUser()
        {
            DataTable dtUser = new BALSalesRepMaster().SelectByTransferAccess(new BOLSalesRepMaster() { });
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
        public void GetToUser()
        {
            DataTable dtUser = new BALSalesRepMaster().SelectByTransferAccess(new BOLSalesRepMaster() { });
            DataRow dr = dtUser.NewRow();
            dr["UserName"] = "--Select--";
            dr["ID"] = "0";
            dr["IsActive"] = "0";
            dtUser.Rows.InsertAt(dr, 0);
            cmbToUserName.DataSource = dtUser;
            cmbToUserName.DisplayMember = "UserName";
            cmbToUserName.ValueMember = "ID";
            cmbToUserName.SelectedIndex = 0;
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if(cmbUserName.SelectedIndex !=0 &&  cmbToUserName.SelectedIndex !=0)
                {
                    int UserID =0;
                    UserID = Convert.ToInt32(cmbToUserName.SelectedValue);
                    ObjBOLUserMenu.UserID = UserID;
                    ObjBALUserMenu.DeleteAccess(ObjBOLUserMenu);
                    DataTable dt = new DataTable();
                    dt = new BALUserMenuAccess().SelectForSave(new BOLUserMenuAccess() { UserID = Convert.ToInt32(cmbUserName.SelectedValue)});
                    if(dt.Rows.Count > 0)
                    {
                        for(int i =0;i<dt.Rows.Count;i++)
                        {

                            ObjBOLUserMenu.UserID = UserID;
                            ObjBOLUserMenu.MenuID = Convert.ToInt32(dt.Rows[i]["MenuID"].ToString());
                            ObjBALUserMenu.Insert(ObjBOLUserMenu);
                        }
                    }
                    DataTable dt1 = new DataTable();
                    dt1 = new BALUserSubMenuAccess().Select(new BOLUserSubMenuAccess() { UserID = Convert.ToInt32(cmbUserName.SelectedValue) });
                    if( dt1.Rows.Count > 0 )
                    {
                        for(int I=0;I<dt1.Rows.Count;I++)
                        {
                            ObjBOLUserSubMenu.UserID = UserID;
                            ObjBOLUserSubMenu.MenuID= Convert.ToInt32(dt1.Rows[I]["MenuID"].ToString());
                            ObjBOLUserSubMenu.SubMenuID = Convert.ToInt32(dt1.Rows[I]["SubMenuID"].ToString());
                            ObjBALUserSubMenu.Insert(ObjBOLUserSubMenu);
                        }
                    }
                    MessageBox.Show("Access Transfer Successfully");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmUserAccessTransfer,Function :btnTransfer_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        
    }
}