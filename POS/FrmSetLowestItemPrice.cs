using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmSetLowestItemPrice : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        BALItemMaster objBALItem = new BALItemMaster();
        BOLItemMaster objBOLItem = new BOLItemMaster();
        Int32 ID = 0;

        public FrmSetLowestItemPrice()
        {
            InitializeComponent();
            GetItem();
        }

        private void FrmSetLowestItemPrice_Load(object sender, EventArgs e)
        {
           
            GetSalePrice();
            //cmbItemName.SelectedIndex = 0;
        }

        private void pnlItemPrice_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pnlItemPrice.ClientRectangle, Color.Gainsboro, ButtonBorderStyle.Solid);
        }

        private void GetItem()
        {
            try
            {
                DataTable dtItem = new BALItemMaster().SelectAllItem(new BOLItemMaster() { });
                DataRow dr = dtItem.NewRow();
                dr["FullName"] = "--Select--";
                dr["ID"] = "0";
                dr["ItemType"] = "";
                dr["QtyOnHand"] = 0;
                dtItem.Rows.InsertAt(dr, 0);
                cmbItemName.DataSource = dtItem;
                cmbItemName.DisplayMember = "FullName";
                cmbItemName.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmSetLowestPrice,Function :GetItem. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void GetSalePrice()
        {
            try
            {
                DataTable dtPrice = new BALItemMaster().SelectByID(new BOLItemMaster() { ID = Convert.ToInt32(cmbItemName.SelectedValue) });
                if (dtPrice.Rows.Count > 0)
                {
                    ID = Convert.ToInt32(cmbItemName.SelectedValue);
                    if (dtPrice.Rows[0]["SalesPrice"].ToString() != "")
                        txtSalesPrice.Text = dtPrice.Rows[0]["SalesPrice"].ToString();
                    else
                        txtSalesPrice.Text = "0.00";

                    if (dtPrice.Rows[0]["LowestPrice"].ToString() != "")
                        txtLowestPrice.Text = dtPrice.Rows[0]["LowestPrice"].ToString();
                    else
                        txtLowestPrice.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmSetLowestPrice,Function :GetSalePrice. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void LoadItem(Int32 ItemID)
        {
            try
            {
                ID = ItemID;
                cmbItemName.SelectedValue = ItemID;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmSetLowestItemPrice,Function :LoadItem. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void Clear()
        {
            cmbItemName.SelectedIndex = 0;
            txtLowestPrice.Text = "0.00";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                objBOLItem.ID = Convert.ToInt32(cmbItemName.SelectedValue);
                objBOLItem.LowestPrice = Convert.ToDecimal(txtLowestPrice.Text);

                objBALItem.UpdateLowestPrice(objBOLItem);
                ClsCommon.ObjLowestPriceItemList.LoadItem();
                Clear();
                this.Close();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmSetLowestItemPrice,Function :btnSave_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void txtLowestPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
                {
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmSetLowestItemPrice,Function :txtLowestPrice_KeyPress. Message:" + ex.Message);
            }
        }

        private void cmbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ID > 0)
                {
                    GetSalePrice();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmSetLowestItemPrice,Function :cmbItemName_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}