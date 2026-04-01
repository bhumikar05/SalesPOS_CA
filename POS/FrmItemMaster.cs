using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmItemMaster : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtLoadData = new DataTable();
        DataTable dtItem = new DataTable();
        DataTable dt = new DataTable();
        BALInvoiceDetails objInvBAL = new BALInvoiceDetails();
        BOLInvoiceDetails objInvBOL = new BOLInvoiceDetails();
        BALItemMaster ObjItemBAL = new BALItemMaster();
        BOLItemMaster ObjItemBOL = new BOLItemMaster();
        BALGroupSubItem ObjGroupSubItemBAL = new BALGroupSubItem();
        BOLGroupSubItem ObjGroupSubItemBOL = new BOLGroupSubItem();
        public string Mode = "insert";
        String Type = "";
        public FrmItemMaster()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 50);
            cmbSubItem.Enabled = false;
            grpPurchaseInfo.Visible = false;
            grpSalesInfo.Visible = false;
            pnlDiscount.Visible = false;
            grpInventoryInformation.Visible = false;
            cmbCOGSAccount.Visible = false;
            ItemTypeVisibility();
            FormResize();
            GetItem();
            GetIncomeAccount();
            GetExpenseAccount();
            GetCOGSAccount();
            GetAssetAccount();
            GetVendor();
            GetFilterName();

        }
        //princy Add
        public delegate void CustomerNameUpdatedHandler(string customerName);
        public event CustomerNameUpdatedHandler ItemNameUpdated;
        public string ItemNames
        {
            get { return txtItemName.Text; }
            set { txtItemName.Text = value; }
        }
        //
        private void FrmItemMaster_Load(object sender, EventArgs e)
        {
            try
            {
                if (Mode == "insert")
                {
                    this.Text = "New Item";
                    cmbItemType.Enabled = true;
                    cmbItemType.SelectedIndex = 0;
                    cmbTaxCode.SelectedIndex = 0;

                    if (!string.IsNullOrEmpty(ItemNames))
                    {
                        txtItemName.Text = ItemNames;
                    }
                    GetItem();
                    GetIncomeAccount();
                    GetExpenseAccount();
                    GetCOGSAccount();
                    GetAssetAccount();
                    GetVendor();
                    GetFilterName();
                    this.dgvGroupItem.DefaultCellStyle.Font = new Font("", 10);
                    dgvGroupItem.RowTemplate.Height = 25;
                    dtpInventoryDate.Format = DateTimePickerFormat.Custom;
                    dtpInventoryDate.CustomFormat = "MM/dd/yyyy";
                    cmbItemType.Text = "Inventory";
                    cmbCOGSAccount.Text = "Cost of Goods Sold";
                    cmbIncomeAccount.Text = "Sales";
                    cmbAssestAccount.Text = "Inventory Asset";
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmNewItemService,Function :FrmItemMaster_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        public void GetFilterName()
        {
            try
            {
                DataTable dtOtherItem = new BALFilterMater().Select(new BOLFilterMater());
                if (dtOtherItem.Rows.Count > 0)
                {
                    DataRow drAdd = dtOtherItem.NewRow();
                    drAdd["FilterName"] = "--Select--";
                    drAdd["ID"] = "0";
                    dtOtherItem.Rows.InsertAt(drAdd, 0);
                    cmbFilterName.DataSource = dtOtherItem;
                    cmbFilterName.DisplayMember = "FilterName";
                    cmbFilterName.ValueMember = "ID";
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :GetFilterName. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void LoadFunction()
        {
            try
            {
                cmbSubItem.Enabled = false;
                grpPurchaseInfo.Visible = false;
                grpSalesInfo.Visible = false;
                pnlDiscount.Visible = false;
                grpInventoryInformation.Visible = false;
                cmbCOGSAccount.Visible = false;
                ItemTypeVisibility();
                FormResize();
                GetItem();
                GetIncomeAccount();
                GetExpenseAccount();
                GetCOGSAccount();
                GetAssetAccount();
                GetVendor();
                GetFilterName();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmNewItemService,Function :LoadFunction. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void pnlSalesRep_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pnlSales.ClientRectangle, Color.Gainsboro, ButtonBorderStyle.Solid);
        }
        private void pnlDiscount_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pnlDiscount.ClientRectangle, Color.Gainsboro, ButtonBorderStyle.Solid);
        }
        private Boolean CheckValidation()
        {
            Boolean ISValid = false;
            try
            {
                if (txtItemName.Text == "")
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter ItemName");
                    txtItemName.Focus();
                    goto Final;
                }
                else if (cmbItemType.SelectedIndex == 1 && cmbIncomeAccount.SelectedIndex == 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select IncomeAccount");
                    cmbIncomeAccount.Focus();
                    goto Final;
                }
                else if (cmbItemType.SelectedIndex == 1 && cmbCOGSAccount.SelectedIndex == 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select COGSAccount");
                    cmbCOGSAccount.Focus();
                    goto Final;
                }
                else if (cmbItemType.SelectedIndex == 1 && cmbAssestAccount.SelectedIndex == 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select AssetAccount");
                    cmbAssestAccount.Focus();
                    goto Final;
                }
                else if (chkSubItem.Checked == true && cmbSubItem.SelectedIndex == 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select SubItemName");
                    cmbSubItem.Focus();
                    goto Final;
                }
                else if (chkSalesOrPurchase.Checked == false && cmbAccount.SelectedIndex == 0 && cmbItemType.SelectedIndex != 4 && cmbItemType.SelectedIndex != 6)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select AccountName");
                    cmbAccount.Focus();
                    goto Final;
                }
                else if (chkSalesOrPurchase.Checked == true && cmbIncomeAccount.SelectedIndex == 0 && cmbItemType.SelectedIndex != 4 && cmbItemType.SelectedIndex != 6)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select IncomeAccountName");
                    cmbIncomeAccount.Focus();
                    goto Final;
                }
                else if (chkSalesOrPurchase.Checked == true && cmbExpenseAccount.SelectedIndex == 0 && cmbItemType.SelectedIndex != 2 && cmbItemType.SelectedIndex != 6)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select ExpenseAccountName");
                    cmbExpenseAccount.Focus();
                    goto Final;
                }
                else if (cmbItemType.SelectedIndex == 5 && cmbDiscountAccount.SelectedIndex == 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select AccountName");
                    cmbDiscountAccount.Focus();
                    goto Final;
                }
                else if (cmbItemType.SelectedIndex == 4 && dgvGroupItem.Rows.Count <= 1)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select at least one Item");
                    dgvGroupItem.Focus();
                    goto Final;
                }
                else if (cmbItemType.SelectedIndex == 6 && (txtTaxPercentage.Text == "" || txtTaxPercentage.Text == "0.0%"))
                {
                    ISValid = false;
                    MessageBox.Show("Please Enter Tax Rate (%)");
                    txtTaxPercentage.Focus();
                    goto Final;
                }
                else if (cmbItemType.SelectedIndex == 6 && cmbVendor.SelectedIndex == 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select Vendor");
                    cmbVendor.Focus();
                    goto Final;
                }
                else if (cmbFilterName.SelectedIndex == 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select FilterName");
                    cmbFilterName.Focus();
                    goto Final;
                }
                else
                    ISValid = true;

                Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmNewItemService,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }

        private void GetItem()
        {
            try
            {
                cmbSubItem.DataSource = null;
                DataTable dtSubItem = new BALItemMaster().SelectItem(new BOLItemMaster() { });
                if (dtSubItem.Rows.Count > 0)
                {
                    if (cmbItemType.SelectedIndex == 0)
                    {
                        cmbSubItem.Items.Clear();
                        // Service Item
                        DataRow[] dr = dtSubItem.Select("ItemType='ItemService'");
                        if (dr.Length > 0)
                        {
                            DataTable dtService = dr.CopyToDataTable();
                            if (dtService.Rows.Count > 0)
                            {
                                DataRow drAdd = dtService.NewRow();
                                drAdd["FullName"] = "--Select--";
                                drAdd["ID"] = "0";
                                drAdd["ItemType"] = "";
                                dtService.Rows.InsertAt(drAdd, 0);
                                cmbSubItem.DataSource = dtService;
                                cmbSubItem.DisplayMember = "FullName";
                                cmbSubItem.ValueMember = "ID";
                            }
                        }
                        else
                            cmbSubItem.Items.Insert(0, "--Select--");
                    }
                    if (cmbItemType.SelectedIndex == 1)
                    {
                        cmbSubItem.Items.Clear();
                        // Invetory Part Item
                        DataRow[] dr = dtSubItem.Select("ItemType='ItemInventory'");
                        if (dr.Length > 0)
                        {
                            DataTable dtInventory = dr.CopyToDataTable();
                            if (dtInventory.Rows.Count > 0)
                            {
                                DataRow drAdd = dtInventory.NewRow();
                                drAdd["FullName"] = "--Select--";
                                drAdd["ID"] = "0";
                                drAdd["ItemType"] = "";
                                dtInventory.Rows.InsertAt(drAdd, 0);
                                cmbSubItem.DataSource = dtInventory;
                                cmbSubItem.DisplayMember = "FullName";
                                cmbSubItem.ValueMember = "ID";
                            }
                        }
                        else
                            cmbSubItem.Items.Insert(0, "--Select--");
                    }
                    else if (cmbItemType.SelectedIndex == 2)
                    {
                        cmbSubItem.Items.Clear();
                        // NonInvItem Item
                        DataRow[] dr = dtSubItem.Select("ItemType='ItemNonInventory'");
                        if (dr.Length > 0)
                        {
                            DataTable dtNonInvItem = dr.CopyToDataTable();
                            if (dtNonInvItem.Rows.Count > 0)
                            {
                                DataRow drAdd = dtNonInvItem.NewRow();
                                drAdd["FullName"] = "--Select--";
                                drAdd["ID"] = "0";
                                drAdd["ItemType"] = "";
                                dtNonInvItem.Rows.InsertAt(drAdd, 0);
                                cmbSubItem.DataSource = dtNonInvItem;
                                cmbSubItem.DisplayMember = "FullName";
                                cmbSubItem.ValueMember = "ID";
                            }
                        }
                        else
                            cmbSubItem.Items.Insert(0, "--Select--");
                    }
                    else if (cmbItemType.SelectedIndex == 3)
                    {
                        cmbSubItem.Items.Clear();
                        // Other Charges Item
                        DataRow[] dr = dtSubItem.Select("ItemType='ItemOtherCharge'");
                        if (dr.Length > 0)
                        {
                            DataTable dtOtherItem = dr.CopyToDataTable();
                            if (dtOtherItem.Rows.Count > 0)
                            {
                                DataRow drAdd = dtOtherItem.NewRow();
                                drAdd["FullName"] = "--Select--";
                                drAdd["ID"] = "0";
                                drAdd["ItemType"] = "";
                                dtOtherItem.Rows.InsertAt(drAdd, 0);
                                cmbSubItem.DataSource = dtOtherItem;
                                cmbSubItem.DisplayMember = "FullName";
                                cmbSubItem.ValueMember = "ID";
                            }
                        }
                        else
                            cmbSubItem.Items.Insert(0, "--Select--");
                    }
                    else if (cmbItemType.SelectedIndex == 5)
                    {
                        cmbSubItem.Items.Clear();
                        // Discount Item
                        DataRow[] dr = dtSubItem.Select("ItemType='ItemDiscount'");
                        if (dr.Length > 0)
                        {
                            DataTable dtDiscount = dr.CopyToDataTable();
                            if (dtDiscount.Rows.Count > 0)
                            {
                                DataRow drAdd = dtDiscount.NewRow();
                                drAdd["FullName"] = "--Select--";
                                drAdd["ID"] = "0";
                                drAdd["ItemType"] = "";
                                dtDiscount.Rows.InsertAt(drAdd, 0);
                                cmbSubItem.DataSource = dtDiscount;
                                cmbSubItem.DisplayMember = "FullName";
                                cmbSubItem.ValueMember = "ID";
                            }
                        }
                        else
                            cmbSubItem.Items.Insert(0, "--Select--");
                    }
                    else if (cmbItemType.SelectedIndex == 4)
                        cmbSubItem.Items.Insert(0, "--Select--");
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :GetItem. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void GetIncomeAccount()
        {
            try
            {
                DataTable dtIncomeAcc = new BALAccount().SelectIncomeAccount(new BOLAccount() { });
                DataRow dr = dtIncomeAcc.NewRow();
                dr["FullName"] = "--Select--";
                dr["ID"] = "0";
                dr["AccountType"] = "";
                dtIncomeAcc.Rows.InsertAt(dr, 0);
                cmbIncomeAccount.DataSource = dtIncomeAcc;
                cmbIncomeAccount.DisplayMember = "FullName";
                cmbIncomeAccount.ValueMember = "ID";

                cmbAccount.DataSource = dtIncomeAcc;
                cmbAccount.DisplayMember = "FullName";
                cmbAccount.ValueMember = "ID";

                cmbDiscountAccount.DataSource = dtIncomeAcc;
                cmbDiscountAccount.DisplayMember = "FullName";
                cmbDiscountAccount.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :GetIncomeAccount. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void GetExpenseAccount()
        {
            try
            {
                DataTable dtExpenseAcc = new BALAccount().SelectExpenseAccount(new BOLAccount() { });
                DataRow dr = dtExpenseAcc.NewRow();
                dr["FullName"] = "--Select--";
                dr["ID"] = "0";
                dr["AccountType"] = "0";
                dtExpenseAcc.Rows.InsertAt(dr, 0);
                cmbExpenseAccount.DataSource = dtExpenseAcc;
                cmbExpenseAccount.DisplayMember = "FullName";
                cmbExpenseAccount.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :GetExpenseAccount. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void GetCOGSAccount()
        {
            try
            {
                DataTable dtCOGSAcc = new BALAccount().SelectCOGSAccount(new BOLAccount() { });
                DataRow dr = dtCOGSAcc.NewRow();
                dr["FullName"] = "--Select--";
                dr["ID"] = "0";
                dr["AccountType"] = "0";
                dtCOGSAcc.Rows.InsertAt(dr, 0);
                cmbCOGSAccount.DataSource = dtCOGSAcc;
                cmbCOGSAccount.DisplayMember = "FullName";
                cmbCOGSAccount.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :GetCOGSAccount. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void GetAssetAccount()
        {
            try
            {
                DataTable dtAssetAcc = new BALAccount().SelectAssetAccount(new BOLAccount() { });
                DataRow dr = dtAssetAcc.NewRow();
                dr["FullName"] = "--Select--";
                dr["ID"] = "0";
                dr["AccountType"] = "0";
                dtAssetAcc.Rows.InsertAt(dr, 0);
                cmbAssestAccount.DataSource = dtAssetAcc;
                cmbAssestAccount.DisplayMember = "FullName";
                cmbAssestAccount.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :GetAssetAccount. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        private void GetVendor()
        {
            try
            {
                DataTable dtVendor = new BALVendorMaster().Select(new BOLVendorMaster() { });
                DataRow dr = dtVendor.NewRow();
                dr["VendorName"] = "--Select--";
                dr["ID"] = "0";
                dr["IsActive"] = "0";
                dtVendor.Rows.InsertAt(dr, 0);
                cmbVendor.DataSource = dtVendor;
                cmbVendor.DisplayMember = "VendorName";
                cmbVendor.ValueMember = "ID";


                cmbTaxAgency.DataSource = dtVendor;
                cmbTaxAgency.DisplayMember = "VendorName";
                cmbTaxAgency.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :GetVendor. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void GetAllItem()
        {
            try
            {
                dgvGroupItem.Columns[2].ReadOnly = true;
                dtItem = new BALItemMaster().Select(new BOLItemMaster() { });
                if (dtItem.Rows.Count > 0)
                {
                    foreach (DataRow row in dtItem.Rows)
                        ItemName.Items.Add(row["FullName"].ToString());
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :GetAllItem. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void Clear()
        {
            txtItemName.Text = "";
            txtManufacturerPartNumber.Text = "";
            txtDescription.Text = "";
            txtRate.Text = "0.00";
            txtGroupDesc.Text = "";
            txtSalesDesc.Text = "";
            txtPurchaseDes.Text = "";
            txtDiscountDesc.Text = "";
            txtDiscountAmount.Text = "0.00";
            txtSalesPrice.Text = "0.00";
            txtPurchaseCost.Text = "0.00";
            txtReorderPointMax.Text = "";
            txtreorderPointMin.Text = "";
            txtQtyOnHand.Text = "0.00";
            txtTotalValue.Text = "0.00";
            txtTaxPercentage.Text = "0.0%";
            dtpInventoryDate.Value = DateTime.Now;
            chkSalesOrPurchase.Checked = false;
            chkSubItem.Checked = false;
            chkPrintItemInGroup.Checked = false;
            chkIsActive.Checked = false;
            cmbAccount.SelectedIndex = 0;
            cmbIncomeAccount.SelectedIndex = 0;
            cmbExpenseAccount.SelectedIndex = 0;
            cmbAssestAccount.SelectedIndex = 0;
            cmbCOGSAccount.SelectedIndex = 0;
            cmbDiscountAccount.SelectedIndex = 0;
            if (cmbSubItem.SelectedIndex != -1)
            {
                cmbSubItem.SelectedIndex = 0;
            }

            cmbVendor.SelectedIndex = 0;
            dgvGroupItem.Rows.Clear();
        }
        public void ShowType(string Item)
        {
            Type = Item;
        }
        public void LoadData(string ID)
        {
            try
            {
                Mode = "update";
                dtLoadData = new DataTable();
                dtLoadData = new BALItemMaster().SelectByID(new BOLItemMaster() { ID = Convert.ToInt32(ID) });
                if (dtLoadData.Rows.Count > 0)
                {
                    this.Text = "Edit Item";
                    txtID.Text = dtLoadData.Rows[0]["ID"].ToString();
                    if (dtLoadData.Rows[0]["ItemType"].ToString().Trim() == "ItemService")
                        cmbItemType.SelectedIndex = 0;
                    else if (dtLoadData.Rows[0]["ItemType"].ToString().Trim() == "ItemInventory")
                        cmbItemType.SelectedIndex = 1;
                    else if (dtLoadData.Rows[0]["ItemType"].ToString().Trim() == "ItemNonInventory")
                    {
                        cmbItemType.SelectedIndex = 2;
                        txtManufacturerPartNumber.Text = dtLoadData.Rows[0]["ManufacturePartNumber"].ToString();
                    }
                    else if (dtLoadData.Rows[0]["ItemType"].ToString().Trim() == "ItemOtherCharge")
                        cmbItemType.SelectedIndex = 3;
                    else if (dtLoadData.Rows[0]["ItemType"].ToString().Trim() == "GroupItem")
                        cmbItemType.SelectedIndex = 4;
                    else if (dtLoadData.Rows[0]["ItemType"].ToString().Trim() == "ItemDiscount")
                        cmbItemType.SelectedIndex = 5;
                    else if (dtLoadData.Rows[0]["ItemType"].ToString().Trim() == "SalesTaxItem")
                        cmbItemType.SelectedIndex = 6;
                    if (dtLoadData.Rows[0]["FilterID"].ToString() != "")
                    {
                        cmbFilterName.SelectedValue = dtLoadData.Rows[0]["FilterID"].ToString();
                    }
                    cmbItemType.Enabled = false;
                    GetItem();
                    txtItemName.Text = dtLoadData.Rows[0]["ItemName"].ToString();
                    if (dtLoadData.Rows[0]["ParentID"].ToString() != "" && dtLoadData.Rows[0]["ParentID"].ToString() != "0")
                    {
                        chkSubItem.Checked = true;
                        cmbSubItem.Enabled = true;
                        if (dtLoadData.Rows[0]["ParentID"].ToString() != "")
                            cmbSubItem.SelectedValue = dtLoadData.Rows[0]["ParentID"].ToString();
                    }
                    else
                    {
                        chkSubItem.Checked = false;
                        cmbSubItem.Enabled = false;
                        if (cmbItemType.SelectedIndex != 6)
                        {
                            cmbSubItem.SelectedIndex = 0;
                        }
                    }
                    if (cmbItemType.SelectedIndex == 5)
                    {
                        //Discount Item
                        chkSalesOrPurchase.Checked = false;
                        txtDiscountDesc.Text = dtLoadData.Rows[0]["SalesDesc"].ToString();
                        txtDiscountAmount.Text = dtLoadData.Rows[0]["SalesPrice"].ToString().Replace("-", "");
                        if (dtLoadData.Rows[0]["IncomeAccountID"].ToString() != "")
                            cmbDiscountAccount.SelectedValue = dtLoadData.Rows[0]["IncomeAccountID"].ToString();
                        //Hiren
                        cmbTaxCode.Text = dtLoadData.Rows[0]["TaxCode"].ToString();
                    }
                    else if (cmbItemType.SelectedIndex == 1)
                    {
                        //Inventory Part
                        txtManufacturerPartNumber.Text = dtLoadData.Rows[0]["ManufacturePartNumber"].ToString();
                        txtPurchaseDes.Text = dtLoadData.Rows[0]["PurchaseDesc"].ToString();
                        txtPurchaseCost.Text = dtLoadData.Rows[0]["PurchaseCost"].ToString();
                        if (dtLoadData.Rows[0]["CogsAccountID"].ToString() != "")
                            cmbCOGSAccount.SelectedValue = dtLoadData.Rows[0]["CogsAccountID"].ToString();
                        if (dtLoadData.Rows[0]["VendorID"].ToString() != "")
                            cmbVendor.SelectedValue = dtLoadData.Rows[0]["VendorID"].ToString();
                        txtSalesDesc.Text = dtLoadData.Rows[0]["SalesDesc"].ToString();
                        txtSalesPrice.Text = dtLoadData.Rows[0]["SalesPrice"].ToString();
                        if (dtLoadData.Rows[0]["IncomeAccountID"].ToString() != "")
                            cmbIncomeAccount.SelectedValue = dtLoadData.Rows[0]["IncomeAccountID"].ToString();
                        if (dtLoadData.Rows[0]["AssetAccountID"].ToString() != "")
                            cmbAssestAccount.SelectedValue = dtLoadData.Rows[0]["AssetAccountID"].ToString();
                        txtreorderPointMin.Text = dtLoadData.Rows[0]["ReorderPointMin"].ToString();
                        txtReorderPointMax.Text = dtLoadData.Rows[0]["ReorderPointMax"].ToString();
                        txtQtyOnHand.Text = dtLoadData.Rows[0]["QtyOnHand"].ToString();
                        txtTotalValue.Text = dtLoadData.Rows[0]["TotalValue"].ToString();
                        if (dtLoadData.Rows[0]["InventoryDate"].ToString() == null || dtLoadData.Rows[0]["InventoryDate"].ToString() == "")
                            dtpInventoryDate.Value = DateTime.Now;
                        else
                            dtpInventoryDate.Value = Convert.ToDateTime(dtLoadData.Rows[0]["InventoryDate"].ToString());
                        //Hiren
                        cmbTaxCode.Text = dtLoadData.Rows[0]["TaxCode"].ToString();
                    }
                    else if (cmbItemType.SelectedIndex == 4)
                    {
                        // Group Item
                        txtGroupDesc.Text = dtLoadData.Rows[0]["SalesDesc"].ToString();
                        DataTable dtGroupItem = new BALGroupSubItem().SelectByGroupID(new BOLGroupSubItem() { GroupItemID = Convert.ToInt32(txtID.Text) });
                        if (dtGroupItem.Rows.Count > 0)
                        {
                            dgvGroupItem.Rows.Clear();
                            for (int i = 0; i <= dtGroupItem.Rows.Count - 1; i++)
                            {
                                dgvGroupItem.Rows.Add();
                                int j = dgvGroupItem.Rows.Count - 2;
                                dgvGroupItem.Rows[j].Cells["ID"].Value = Convert.ToInt32(dtGroupItem.Rows[i]["ItemID"].ToString());
                                dgvGroupItem.Rows[j].Cells["ItemName"].Value = dtGroupItem.Rows[i]["FullName"].ToString();
                                dgvGroupItem.Rows[j].Cells["Description"].Value = dtGroupItem.Rows[i]["Description"].ToString();
                                dgvGroupItem.Rows[j].Cells["Qty"].Value = Convert.ToDecimal(dtGroupItem.Rows[i]["Qty"].ToString());
                            }
                        }
                    }
                    else if (cmbItemType.SelectedIndex == 6)
                    {
                        txtTaxDescription.Text = dtLoadData.Rows[0]["SalesDesc"].ToString();
                        txtTaxPercentage.Text = dtLoadData.Rows[0]["SalesTaxPercentage"].ToString() + "%";
                        if (dtLoadData.Rows[0]["VendorID"].ToString() != "")
                            cmbVendor.SelectedValue = dtLoadData.Rows[0]["VendorID"].ToString();
                    }
                    else
                    {
                        if (dtLoadData.Rows[0]["ExpenseAccountID"].ToString() != "" && dtLoadData.Rows[0]["ExpenseAccountID"].ToString() != "0")
                        {
                            chkSalesOrPurchase.Checked = true;
                            txtPurchaseDes.Text = dtLoadData.Rows[0]["PurchaseDesc"].ToString();
                            txtPurchaseCost.Text = dtLoadData.Rows[0]["PurchaseCost"].ToString();
                            if (dtLoadData.Rows[0]["ExpenseAccountID"].ToString() != "")
                                cmbExpenseAccount.SelectedValue = dtLoadData.Rows[0]["ExpenseAccountID"].ToString();
                            if (dtLoadData.Rows[0]["VendorID"].ToString() != "")
                                cmbVendor.SelectedValue = dtLoadData.Rows[0]["VendorID"].ToString();
                            txtSalesDesc.Text = dtLoadData.Rows[0]["SalesDesc"].ToString();
                            txtSalesPrice.Text = dtLoadData.Rows[0]["SalesPrice"].ToString();
                            if (dtLoadData.Rows[0]["IncomeAccountID"].ToString() != "")
                                cmbIncomeAccount.SelectedValue = dtLoadData.Rows[0]["IncomeAccountID"].ToString();
                            txtDescription.Text = dtLoadData.Rows[0]["SalesDesc"].ToString();
                            txtRate.Text = dtLoadData.Rows[0]["SalesPrice"].ToString();
                            if (dtLoadData.Rows[0]["IncomeAccountID"].ToString() != "")
                                cmbAccount.SelectedValue = dtLoadData.Rows[0]["IncomeAccountID"].ToString();
                            //Hiren
                            cmbTaxCode.Text = dtLoadData.Rows[0]["TaxCode"].ToString();
                        }
                        else
                        {
                            chkSalesOrPurchase.Checked = false;
                            txtDescription.Text = dtLoadData.Rows[0]["SalesDesc"].ToString();
                            txtRate.Text = dtLoadData.Rows[0]["SalesPrice"].ToString();
                            if (dtLoadData.Rows[0]["IncomeAccountID"].ToString() != "")
                                cmbAccount.SelectedValue = dtLoadData.Rows[0]["IncomeAccountID"].ToString();
                            txtSalesDesc.Text = dtLoadData.Rows[0]["SalesDesc"].ToString();
                            txtSalesPrice.Text = dtLoadData.Rows[0]["SalesPrice"].ToString();
                            if (dtLoadData.Rows[0]["IncomeAccountID"].ToString() != "")
                                cmbIncomeAccount.SelectedValue = dtLoadData.Rows[0]["IncomeAccountID"].ToString();
                            //Hiren
                            cmbTaxCode.Text = dtLoadData.Rows[0]["TaxCode"].ToString();
                        }
                    }
                    if (dtLoadData.Rows[0]["IsActive"].ToString() == "1")
                        chkIsActive.Checked = false;
                    else
                        chkIsActive.Checked = true;

                    FormResize();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :LoadData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void chkSubItem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSubItem.Checked == true)
                    cmbSubItem.Enabled = true;
                else
                {
                    cmbSubItem.Enabled = false;
                    cmbSubItem.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :chkSubItem_CheckedChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void SalesOrPurchase()
        {
            try
            {
                if (chkSalesOrPurchase.Checked == true)
                {
                    grpPurchaseInfo.Visible = true;
                    grpSalesInfo.Visible = true;
                    pnlSales.Visible = false;
                }
                else if (chkSalesOrPurchase.Checked == false && (cmbItemType.SelectedIndex == 4 || cmbItemType.SelectedIndex == 5))
                {
                    grpPurchaseInfo.Visible = false;
                    grpSalesInfo.Visible = false;
                    pnlSales.Visible = false;
                }
                else
                {
                    grpPurchaseInfo.Visible = false;
                    grpSalesInfo.Visible = false;
                    pnlSales.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :SalesOrPurchase. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void chkSalesOrPurchase_CheckedChanged(object sender, EventArgs e)
        {
            SalesOrPurchase();
            FormResize();
        }

        private Boolean SaveData()
        {
            ObjItemBOL = new BOLItemMaster();
            Boolean ISValid = false;
            try
            {
                if (CheckValidation())
                {
                    if (Mode == "insert")
                    {
                        if (chkSalesOrPurchase.Checked == false)
                        {
                            if (cmbItemType.SelectedIndex == 4)
                            {
                                DataTable dt = new BALItemMaster().SelectByItemName(new BOLItemMaster() { FullName = txtItemName.Text });
                                if (dt.Rows.Count == 0)
                                {

                                    //Insert Group Item
                                    ObjItemBOL.ItemName = txtItemName.Text.Trim();
                                    ObjItemBOL.ItemType = "GroupItem";
                                    ObjItemBOL.FullName = txtItemName.Text.Trim();
                                    ObjItemBOL.ParentID = 0;
                                    ObjItemBOL.SalesDesc = txtGroupDesc.Text.Trim();
                                    if (chkPrintItemInGroup.Checked == true)
                                        ObjItemBOL.PrintGroupItem = 1;
                                    else
                                        ObjItemBOL.PrintGroupItem = 0;

                                    ObjItemBOL.CreatedID = ClsCommon.UserID;

                                    ObjItemBOL.CreatedTime = DateTime.Now;
                                    ObjItemBOL.ModifiedTime = DateTime.Now;
                                    ObjItemBOL.IsSync = 0;
                                    if (chkIsActive.Checked == false)
                                        ObjItemBOL.IsActive = 1;
                                    else
                                        ObjItemBOL.IsActive = 0;


                                    ObjItemBOL.FilterID = Convert.ToInt32(cmbFilterName.SelectedValue);


                                    int ItemID = ObjItemBAL.Insert(ObjItemBOL);

                                    //new add insert Item

                                    ObjItemBOL.PosID = ItemID;
                                    ObjItemBAL.NewInsert(ObjItemBOL);



                                    //Insert GroupSubItem
                                    for (int i = 0; i < dgvGroupItem.Rows.Count - 1; i++)
                                    {
                                        ObjGroupSubItemBOL.GroupItemID = ItemID;
                                        ObjGroupSubItemBOL.ItemID = Convert.ToInt32(dgvGroupItem.Rows[i].Cells["ID"].Value.ToString());
                                        ObjGroupSubItemBOL.Description = dgvGroupItem.Rows[i].Cells["Description"].Value.ToString();
                                        ObjGroupSubItemBOL.Qty = Convert.ToDecimal(dgvGroupItem.Rows[i].Cells["Qty"].Value);
                                        ObjGroupSubItemBOL.CreatedTime = DateTime.Now;
                                        ObjGroupSubItemBOL.CreatedID = ClsCommon.UserID;

                                        ObjGroupSubItemBAL.GroupSubItemInsert(ObjGroupSubItemBOL);
                                    }
                                    ISValid = true;
                                    MessageBox.Show("Record save successfully");
                                }
                                else
                                {
                                    ISValid = false;
                                    MessageBox.Show("Duplicate name not allow");
                                }
                            }
                            else
                            {
                                ObjItemBOL.ItemName = txtItemName.Text.Trim();
                                if (cmbItemType.SelectedIndex == 0)
                                    ObjItemBOL.ItemType = "ItemService";
                                else if (cmbItemType.SelectedIndex == 1)
                                    ObjItemBOL.ItemType = "ItemInventory";
                                else if (cmbItemType.SelectedIndex == 2)
                                    ObjItemBOL.ItemType = "ItemNonInventory";
                                else if (cmbItemType.SelectedIndex == 3)
                                    ObjItemBOL.ItemType = "ItemOtherCharge";
                                else if (cmbItemType.SelectedIndex == 4)
                                    ObjItemBOL.ItemType = "GroupItem";
                                else if (cmbItemType.SelectedIndex == 5)
                                    ObjItemBOL.ItemType = "ItemDiscount";
                                else if (cmbItemType.SelectedIndex == 6)
                                    ObjItemBOL.ItemType = "SalesTaxItem";
                                if (chkSubItem.Checked == true)
                                {
                                    ObjItemBOL.FullName = cmbSubItem.Text.Trim() + ":" + txtItemName.Text.Trim();
                                    ObjItemBOL.ParentID = Convert.ToInt32(cmbSubItem.SelectedValue);
                                }
                                else
                                {
                                    ObjItemBOL.FullName = txtItemName.Text.Trim();
                                    ObjItemBOL.ParentID = 0;
                                }
                                DataTable dt = new BALItemMaster().SelectByItemName(new BOLItemMaster() { FullName = ObjItemBOL.FullName });
                                if (dt.Rows.Count == 0)
                                {
                                    if (cmbItemType.SelectedIndex == 2)//Non-Inventory Item
                                        ObjItemBOL.ManufacturePartNumber = txtManufacturerPartNumber.Text.Trim();
                                    if (cmbItemType.SelectedIndex == 5) //Discount Item
                                    {
                                        ObjItemBOL.SalesDesc = txtDiscountDesc.Text.Trim();
                                        if (txtDiscountAmount.Text != "")
                                            ObjItemBOL.SalesPrice = -(Convert.ToDecimal(txtDiscountAmount.Text));
                                        else
                                            ObjItemBOL.SalesPrice = 0;
                                        ObjItemBOL.IncomeAccountID = Convert.ToInt32(cmbDiscountAccount.SelectedValue);
                                    }
                                    else if (cmbItemType.SelectedIndex == 1) //Inventory Part Item
                                    {
                                        ObjItemBOL.ManufacturePartNumber = txtManufacturerPartNumber.Text.Trim();
                                        ObjItemBOL.SalesDesc = txtSalesDesc.Text.Trim();
                                        if (txtSalesPrice.Text != "")
                                            ObjItemBOL.SalesPrice = Convert.ToDecimal(txtSalesPrice.Text);
                                        else
                                            ObjItemBOL.SalesPrice = 0;
                                        ObjItemBOL.IncomeAccountID = Convert.ToInt32(cmbIncomeAccount.SelectedValue);
                                        ObjItemBOL.PurchaseDesc = txtPurchaseDes.Text.Trim();
                                        if (txtPurchaseCost.Text != "")
                                            ObjItemBOL.PurchaseCost = Convert.ToDecimal(txtPurchaseCost.Text);
                                        else
                                            ObjItemBOL.PurchaseCost = 0;
                                        ObjItemBOL.CogsAccountID = Convert.ToInt32(cmbCOGSAccount.SelectedValue);
                                        ObjItemBOL.AssetAccountID = Convert.ToInt32(cmbAssestAccount.SelectedValue);
                                        ObjItemBOL.VendorID = Convert.ToInt32(cmbVendor.SelectedValue);
                                        ObjItemBOL.ReorderPointMin = txtreorderPointMin.Text;
                                        ObjItemBOL.ReorderPointMax = txtReorderPointMax.Text;
                                        if (txtQtyOnHand.Text == "")
                                            ObjItemBOL.QtyOnHand = 0;
                                        else
                                            ObjItemBOL.QtyOnHand = Convert.ToDecimal(txtQtyOnHand.Text);
                                        if (txtTotalValue.Text != "")
                                            ObjItemBOL.TotalValue = Convert.ToDecimal(txtTotalValue.Text);
                                        else
                                            ObjItemBOL.TotalValue = 0;
                                        ObjItemBOL.InventoryDate = Convert.ToString(dtpInventoryDate.Value);
                                    }
                                    else if (cmbItemType.SelectedIndex == 6)
                                    {
                                        ObjItemBOL.VendorID = Convert.ToInt32(cmbVendor.SelectedValue);
                                        if (txtTaxPercentage.Text != "0.0%" && txtTaxPercentage.Text != "")
                                        {
                                            ObjItemBOL.SalesTaxPercentage = Convert.ToDecimal(txtTaxPercentage.Text.Replace("%", ""));
                                        }
                                        ObjItemBOL.SalesDesc = txtTaxDescription.Text;
                                    }
                                    else
                                    {
                                        ObjItemBOL.SalesDesc = txtDescription.Text.Trim();
                                        if (txtRate.Text != "")
                                            ObjItemBOL.SalesPrice = Convert.ToDecimal(txtRate.Text);
                                        else
                                            ObjItemBOL.SalesPrice = 0;
                                        ObjItemBOL.IncomeAccountID = Convert.ToInt32(cmbAccount.SelectedValue);
                                    }
                                    ObjItemBOL.CreatedID = ClsCommon.UserID;
                                    ObjItemBOL.CreatedTime = DateTime.Now;
                                    ObjItemBOL.ModifiedTime = DateTime.Now;
                                    ObjItemBOL.IsSync = 0;

                                    if (chkIsActive.Checked == false)
                                        ObjItemBOL.IsActive = 1;
                                    else
                                        ObjItemBOL.IsActive = 0;

                                    ObjItemBOL.FilterID = Convert.ToInt32(cmbFilterName.SelectedValue);
                                    //Hiren
                                    if (cmbTaxCode.SelectedIndex == 0)
                                    {
                                        ObjItemBOL.TaxCode = "Tax";
                                    }
                                    else
                                    {
                                        ObjItemBOL.TaxCode = "Non";
                                    }

                                    int ItemID = ObjItemBAL.Insert(ObjItemBOL);

                                    //new add insert Item
                                    //ObjItemBOL.IncomeAccount =cmbIncomeAccount.Text;
                                    //ObjItemBOL.CogsAccount = cmbCOGSAccount.Text;
                                    //ObjItemBOL.AssetAccount = cmbAssestAccount.Text;
                                    ObjItemBOL.PosID = ItemID;
                                    ObjItemBAL.NewInsert(ObjItemBOL);

                                    ISValid = true;
                                    MessageBox.Show("Record save successfully");
                                    //ClsCommon.ObjInvoiceMaster.isItemLoad = true;
                                    ClsCommon.ObjInvoiceMaster.GetAllItem();
                                    //princy 08-04-2025
                                    ClsCommon.ObjCreditMemo.GetAllItem();

                                }
                                else
                                {
                                    ISValid = false;
                                    MessageBox.Show("Duplicate name not allow");
                                }
                            }
                        }
                        else
                        {
                            ObjItemBOL.ItemName = txtItemName.Text.Trim();
                            if (cmbItemType.SelectedIndex == 0)
                                ObjItemBOL.ItemType = "ItemService";
                            else if (cmbItemType.SelectedIndex == 1)
                                ObjItemBOL.ItemType = "ItemInventory";
                            else if (cmbItemType.SelectedIndex == 2)
                                ObjItemBOL.ItemType = "ItemNonInventory";
                            else if (cmbItemType.SelectedIndex == 3)
                                ObjItemBOL.ItemType = "ItemOtherCharge";
                            else if (cmbItemType.SelectedIndex == 4)
                                ObjItemBOL.ItemType = "GroupItem";
                            else if (cmbItemType.SelectedIndex == 5)
                                ObjItemBOL.ItemType = "ItemDiscount";
                            else if (cmbItemType.SelectedIndex == 6)
                                ObjItemBOL.ItemType = "SalesTaxItem";
                            if (chkSubItem.Checked == true)
                            {
                                ObjItemBOL.FullName = cmbSubItem.Text.Trim() + ":" + txtItemName.Text.Trim();
                                ObjItemBOL.ParentID = Convert.ToInt32(cmbSubItem.SelectedValue);
                            }
                            else
                            {
                                ObjItemBOL.FullName = txtItemName.Text.Trim();
                                ObjItemBOL.ParentID = 0;
                            }
                            DataTable dt = new BALItemMaster().SelectByItemName(new BOLItemMaster() { FullName = ObjItemBOL.FullName });
                            if (dt.Rows.Count == 0)
                            {
                                if (cmbItemType.SelectedIndex == 2)//Non-Inventory Item
                                    ObjItemBOL.ManufacturePartNumber = txtManufacturerPartNumber.Text.Trim();

                                ObjItemBOL.SalesDesc = txtSalesDesc.Text.Trim();
                                if (txtSalesPrice.Text != "")
                                    ObjItemBOL.SalesPrice = Convert.ToDecimal(txtSalesPrice.Text);
                                else
                                    ObjItemBOL.SalesPrice = 0;
                                ObjItemBOL.IncomeAccountID = Convert.ToInt32(cmbIncomeAccount.SelectedValue);
                                ObjItemBOL.PurchaseDesc = txtPurchaseDes.Text.Trim();
                                if (txtPurchaseCost.Text != "")
                                    ObjItemBOL.PurchaseCost = Convert.ToDecimal(txtPurchaseCost.Text);
                                else
                                    ObjItemBOL.PurchaseCost = 0;
                                if (cmbItemType.SelectedIndex == 6)//SalesTaxItem
                                {
                                    if (txtTaxPercentage.Text != "0.0%" && txtTaxPercentage.Text != "")
                                        ObjItemBOL.SalesTaxPercentage = Convert.ToDecimal(txtTaxPercentage.Text.Replace("%", ""));
                                    else
                                        ObjItemBOL.SalesTaxPercentage = 0;
                                    ObjItemBOL.SalesDesc = txtTaxDescription.Text;

                                }
                                ObjItemBOL.ExpenseAccountID = Convert.ToInt32(cmbExpenseAccount.SelectedValue);
                                ObjItemBOL.VendorID = Convert.ToInt32(cmbVendor.SelectedValue);
                                ObjItemBOL.CreatedID = ClsCommon.UserID;
                                ObjItemBOL.CreatedTime = DateTime.Now;
                                ObjItemBOL.ModifiedTime = DateTime.Now;
                                ObjItemBOL.IsSync = 0;

                                if (chkIsActive.Checked == false)
                                    ObjItemBOL.IsActive = 1;
                                else
                                    ObjItemBOL.IsActive = 0;

                                ObjItemBOL.FilterID = Convert.ToInt32(cmbFilterName.SelectedValue);

                                int ItemID = ObjItemBAL.Insert(ObjItemBOL);

                                //new add insert Item
                                //ObjItemBOL.ExpenseAccount =cmbExpenseAccount.Text;
                                //ObjItemBOL.IncomeAccount = cmbIncomeAccount.Text;
                                //ObjItemBOL.CogsAccount = cmbCOGSAccount.Text;
                                //ObjItemBOL.AssetAccount = cmbAssestAccount.Text;
                                ObjItemBOL.PosID = ItemID;
                                ObjItemBAL.NewInsert(ObjItemBOL);

                                MessageBox.Show("Record save successfully");
                                ISValid = true;
                            }
                            else
                            {
                                ISValid = false;
                                MessageBox.Show("Duplicate name not allow");
                            }
                        }
                    }
                    else
                    {
                        dt = new DataTable();
                        if (cmbSubItem.SelectedIndex == 0)
                            dt = new BALItemMaster().SelectByItemName(new BOLItemMaster() { FullName = txtItemName.Text.Trim() });
                        else
                            dt = new BALItemMaster().SelectByItemName(new BOLItemMaster() { FullName = cmbSubItem.Text.Trim() + ":" + txtItemName.Text.Trim() });
                        if (dt.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(dt.Rows[0]["ID"]) != Convert.ToInt32(txtID.Text))
                            {
                                if (dt.Rows[0]["ItemType"].ToString() == Type)
                                {
                                    var dialogResult = MessageBox.Show("The name is already being used.whould you like to merge them?", "Confirm!!", MessageBoxButtons.YesNo);
                                    if (dialogResult == DialogResult.Yes)
                                    {

                                        objInvBOL = new BOLInvoiceDetails();
                                        objInvBOL.ItemID = Convert.ToInt32(txtID.Text);
                                        objInvBOL.OldItemID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                                        objInvBAL.UpdateItem(objInvBOL);

                                        ObjItemBAL.UpdateItem(Convert.ToInt32(txtID.Text));
                                        ClsCommon.ObjItemList.LoadItem();
                                        Clear();
                                        this.Close();

                                    }
                                    else
                                    {
                                        txtItemName.Focus();
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("You can not merge item because their types are incompatible");
                                }
                            }
                            else
                            {
                                if (UpdateData())
                                {
                                    ClsCommon.ObjItemList.LoadItem();
                                    Clear();
                                    this.Close();
                                }
                            }
                        }
                        else
                        {
                            if (UpdateData())
                            {
                                ClsCommon.ObjItemList.LoadItem();
                                Clear();
                                this.Close();
                            }
                        }
                    }
                }
                else
                {
                    ISValid = false;
                    ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :SaveData. Message: Error Create Customer Data");
                }
            }
            catch (Exception ex)
            {
                ISValid = false;
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :SaveData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
            return ISValid;
        }

        private Boolean UpdateData()
        {
            Boolean ISValid = false;
            try
            {
                // Update Item
                if (chkSalesOrPurchase.Checked == false)
                {
                    if (cmbItemType.SelectedIndex == 4)
                    {
                        // Update Group Item
                        ObjItemBOL.ID = Convert.ToInt32(txtID.Text);
                        ObjItemBOL.ItemName = txtItemName.Text.Trim();
                        ObjItemBOL.ItemType = "GroupItem";
                        ObjItemBOL.FullName = txtItemName.Text.Trim();
                        ObjItemBOL.ParentID = 0;
                        ObjItemBOL.SalesDesc = txtGroupDesc.Text.Trim();
                        if (chkPrintItemInGroup.Checked == true)
                            ObjItemBOL.PrintGroupItem = 1;
                        else
                            ObjItemBOL.PrintGroupItem = 0;

                        ObjItemBOL.ModifiedID = ClsCommon.UserID;
                        ObjItemBOL.ModifiedTime = DateTime.Now;
                        ObjItemBOL.IsSync = 0;
                        if (chkIsActive.Checked == false)
                            ObjItemBOL.IsActive = 1;
                        else
                            ObjItemBOL.IsActive = 0;

                        ObjItemBOL.FilterID = Convert.ToInt32(cmbFilterName.SelectedValue);

                        int ItemID = ObjItemBAL.Update(ObjItemBOL);

                        //New Update Item

                        ObjItemBOL.PosID = ItemID;
                        ObjItemBAL.NewUpdate(ObjItemBOL);




                        //Delete GroupSubItem
                        ObjGroupSubItemBOL.GroupItemID = Convert.ToInt32(txtID.Text);
                        ObjGroupSubItemBAL.DeleteByGroupID(ObjGroupSubItemBOL);
                        //Insert GroupSubItem
                        for (int i = 0; i < dgvGroupItem.Rows.Count - 1; i++)
                        {
                            ObjGroupSubItemBOL.GroupItemID = ItemID;
                            ObjGroupSubItemBOL.ItemID = Convert.ToInt32(dgvGroupItem.Rows[i].Cells["ID"].Value.ToString());
                            ObjGroupSubItemBOL.Description = dgvGroupItem.Rows[i].Cells["Description"].Value.ToString();
                            if (dgvGroupItem.Rows[i].Cells["Qty"].Value == null)
                                ObjGroupSubItemBOL.Qty = 0;
                            else
                                ObjGroupSubItemBOL.Qty = Convert.ToDecimal(dgvGroupItem.Rows[i].Cells["Qty"].Value);
                            ObjGroupSubItemBOL.CreatedTime = DateTime.Now;
                            ObjGroupSubItemBOL.CreatedID = ClsCommon.UserID;

                            ObjGroupSubItemBAL.GroupSubItemInsert(ObjGroupSubItemBOL);
                        }
                        ISValid = true;
                    }
                    else
                    {
                        ObjItemBOL.ID = Convert.ToInt32(txtID.Text);
                        ObjItemBOL.ItemName = txtItemName.Text.Trim();
                        if (cmbItemType.SelectedIndex == 0)
                            ObjItemBOL.ItemType = "ItemService";
                        else if (cmbItemType.SelectedIndex == 1)
                            ObjItemBOL.ItemType = "ItemInventory";
                        else if (cmbItemType.SelectedIndex == 2)
                            ObjItemBOL.ItemType = "ItemNonInventory";
                        else if (cmbItemType.SelectedIndex == 3)
                            ObjItemBOL.ItemType = "ItemOtherCharge";
                        else if (cmbItemType.SelectedIndex == 4)
                            ObjItemBOL.ItemType = "GroupItem";
                        else if (cmbItemType.SelectedIndex == 5)
                            ObjItemBOL.ItemType = "ItemDiscount";
                        else if (cmbItemType.SelectedIndex == 6)
                            ObjItemBOL.ItemType = "SalesTaxItem";
                        if (chkSubItem.Checked == true)
                        {
                            ObjItemBOL.FullName = cmbSubItem.Text.Trim() + ":" + txtItemName.Text.Trim();
                            ObjItemBOL.ParentID = Convert.ToInt32(cmbSubItem.SelectedValue);
                        }
                        else
                        {
                            ObjItemBOL.FullName = txtItemName.Text.Trim();
                            ObjItemBOL.ParentID = 0;
                        }
                        if (cmbItemType.SelectedIndex == 2)//Non-Inventory Item
                            ObjItemBOL.ManufacturePartNumber = txtManufacturerPartNumber.Text.Trim();
                        if (cmbItemType.SelectedIndex == 5) //Discount Item
                        {
                            ObjItemBOL.SalesDesc = txtDiscountDesc.Text.Trim();
                            if (txtDiscountAmount.Text != "")
                                ObjItemBOL.SalesPrice = -(Convert.ToDecimal(txtDiscountAmount.Text));
                            else
                                ObjItemBOL.SalesPrice = 0;
                            ObjItemBOL.IncomeAccountID = Convert.ToInt32(cmbDiscountAccount.SelectedValue);
                        }
                        else if (cmbItemType.SelectedIndex == 1) //Inventory Part Item
                        {
                            ObjItemBOL.ManufacturePartNumber = txtManufacturerPartNumber.Text.Trim();
                            ObjItemBOL.SalesDesc = txtSalesDesc.Text.Trim();
                            if (txtSalesPrice.Text != "")
                                ObjItemBOL.SalesPrice = Convert.ToDecimal(txtSalesPrice.Text);
                            else
                                ObjItemBOL.SalesPrice = 0;
                            ObjItemBOL.IncomeAccountID = Convert.ToInt32(cmbIncomeAccount.SelectedValue);
                            ObjItemBOL.PurchaseDesc = txtPurchaseDes.Text.Trim();
                            if (txtPurchaseCost.Text != "")
                                ObjItemBOL.PurchaseCost = Convert.ToDecimal(txtPurchaseCost.Text);
                            else
                                ObjItemBOL.PurchaseCost = 0;
                            ObjItemBOL.CogsAccountID = Convert.ToInt32(cmbCOGSAccount.SelectedValue);
                            ObjItemBOL.AssetAccountID = Convert.ToInt32(cmbAssestAccount.SelectedValue);
                            ObjItemBOL.VendorID = Convert.ToInt32(cmbVendor.SelectedValue);
                            ObjItemBOL.ReorderPointMin = txtreorderPointMin.Text;
                            ObjItemBOL.ReorderPointMax = txtReorderPointMax.Text;
                            if (txtQtyOnHand.Text == "")
                                ObjItemBOL.QtyOnHand = 0;
                            else
                                ObjItemBOL.QtyOnHand = Convert.ToDecimal(txtQtyOnHand.Text);
                            if (txtTotalValue.Text != "")
                                ObjItemBOL.TotalValue = Convert.ToDecimal(txtTotalValue.Text);
                            else
                                ObjItemBOL.TotalValue = 0;
                            ObjItemBOL.InventoryDate = Convert.ToString(dtpInventoryDate.Value.ToString());

                            //new add update
                            //ObjItemBOL.CogsAccount = cmbCOGSAccount.Text;
                            //ObjItemBOL.AssetAccount = cmbAssestAccount.Text;
                        }
                        else if (cmbItemType.SelectedIndex == 6)
                        {
                            ObjItemBOL.VendorID = Convert.ToInt32(cmbVendor.SelectedValue);
                            if (txtTaxPercentage.Text != "0.0%" && txtTaxPercentage.Text != "")
                            {
                                ObjItemBOL.SalesTaxPercentage = Convert.ToDecimal(txtTaxPercentage.Text.Replace("%", ""));
                            }
                            ObjItemBOL.SalesDesc = txtTaxDescription.Text;

                        }
                        else
                        {
                            ObjItemBOL.SalesDesc = txtDescription.Text.Trim();
                            if (txtRate.Text != "")
                                ObjItemBOL.SalesPrice = Convert.ToDecimal(txtRate.Text);
                            else
                                ObjItemBOL.SalesPrice = 0;
                            ObjItemBOL.IncomeAccountID = Convert.ToInt32(cmbAccount.SelectedValue);
                            ObjItemBOL.PurchaseDesc = "";
                            ObjItemBOL.PurchaseCost = 0;
                            ObjItemBOL.ExpenseAccountID = null;

                            //new add update
                            //ObjItemBOL.IncomeAccount = cmbIncomeAccount.Text;
                            //ObjItemBOL.ExpenseAccount = null;

                        }
                        ObjItemBOL.ModifiedID = ClsCommon.UserID;
                        ObjItemBOL.ModifiedTime = DateTime.Now;
                        ObjItemBOL.IsSync = 0;

                        if (chkIsActive.Checked == false)
                            ObjItemBOL.IsActive = 1;
                        else
                            ObjItemBOL.IsActive = 0;

                        ObjItemBOL.FilterID = Convert.ToInt32(cmbFilterName.SelectedValue);
                        //Hiren
                        if (cmbTaxCode.SelectedIndex == 0)
                        {
                            ObjItemBOL.TaxCode = "Tax";
                        }
                        else
                        {
                            ObjItemBOL.TaxCode = "Non";
                        }
                        int ItemID = ObjItemBAL.Update(ObjItemBOL);


                        //new update item 

                        ObjItemBOL.PosID = ItemID;
                        ObjItemBAL.NewUpdate(ObjItemBOL);




                        ISValid = true;
                    }
                }
                else
                {
                    ObjItemBOL.ID = Convert.ToInt32(txtID.Text);
                    ObjItemBOL.ItemName = txtItemName.Text.Trim();
                    if (cmbItemType.SelectedIndex == 0)
                        ObjItemBOL.ItemType = "ItemService";
                    else if (cmbItemType.SelectedIndex == 1)
                        ObjItemBOL.ItemType = "ItemInventory";
                    else if (cmbItemType.SelectedIndex == 2)
                        ObjItemBOL.ItemType = "ItemNonInventory";
                    else if (cmbItemType.SelectedIndex == 3)
                        ObjItemBOL.ItemType = "ItemOtherCharge";
                    else if (cmbItemType.SelectedIndex == 4)
                        ObjItemBOL.ItemType = "GroupItem";
                    else if (cmbItemType.SelectedIndex == 5)
                        ObjItemBOL.ItemType = "ItemDiscount";
                    else if (cmbItemType.SelectedIndex == 6)
                        ObjItemBOL.ItemType = "SalesTaxItem";
                    if (chkSubItem.Checked == true)
                    {
                        ObjItemBOL.FullName = cmbSubItem.Text.Trim() + ":" + txtItemName.Text.Trim();
                        ObjItemBOL.ParentID = Convert.ToInt32(cmbSubItem.SelectedValue);
                    }
                    else
                    {
                        ObjItemBOL.FullName = txtItemName.Text.Trim();
                        ObjItemBOL.ParentID = 0;
                    }
                    if (cmbItemType.SelectedIndex == 2)//Non-Inventory Item
                        ObjItemBOL.ManufacturePartNumber = txtManufacturerPartNumber.Text.Trim();

                    if (cmbItemType.SelectedIndex == 6)//SalesTaxItem
                    {
                        if (txtTaxPercentage.Text != "0.0%" && txtTaxPercentage.Text != "")
                            ObjItemBOL.SalesTaxPercentage = Convert.ToDecimal(txtTaxPercentage.Text.Replace("%", ""));
                        else
                            ObjItemBOL.SalesTaxPercentage = 0;
                        ObjItemBOL.SalesDesc = txtTaxDescription.Text;
                    }
                    ObjItemBOL.SalesDesc = txtSalesDesc.Text.Trim();
                    if (txtSalesPrice.Text != "")
                        ObjItemBOL.SalesPrice = Convert.ToDecimal(txtSalesPrice.Text);
                    else
                        ObjItemBOL.SalesPrice = 0;
                    ObjItemBOL.IncomeAccountID = Convert.ToInt32(cmbIncomeAccount.SelectedValue);
                    ObjItemBOL.PurchaseDesc = txtPurchaseDes.Text.Trim();
                    if (txtPurchaseCost.Text != "")
                        ObjItemBOL.PurchaseCost = Convert.ToDecimal(txtPurchaseCost.Text);
                    else
                        ObjItemBOL.PurchaseCost = 0;
                    ObjItemBOL.ExpenseAccountID = Convert.ToInt32(cmbExpenseAccount.SelectedValue);
                    ObjItemBOL.VendorID = Convert.ToInt32(cmbVendor.SelectedValue);
                    ObjItemBOL.ModifiedID = ClsCommon.UserID;
                    ObjItemBOL.ModifiedTime = DateTime.Now;
                    ObjItemBOL.IsSync = 0;

                    if (chkIsActive.Checked == false)
                        ObjItemBOL.IsActive = 1;
                    else
                        ObjItemBOL.IsActive = 0;

                    ObjItemBOL.FilterID = Convert.ToInt32(cmbFilterName.SelectedValue);
                    int ItemID = ObjItemBAL.Update(ObjItemBOL);
                }
                // ItemName Update
                DataTable dtItem = new BALItemMaster().SelectByParentID(new BOLItemMaster() { ParentID = Convert.ToInt32(txtID.Text) });
                if (dtItem.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtItem.Rows)
                    {
                        ObjItemBOL.ParentID = Convert.ToInt32(txtID.Text);
                        ObjItemBOL.FullName = txtItemName.Text.Trim() + ":" + dr["ItemName"].ToString();
                        ObjItemBAL.UpdateFullName(ObjItemBOL);
                    }
                }
                MessageBox.Show("Record Update successfully");
                ISValid = true;
            }
            catch (Exception ex)
            {
                ISValid = false;
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :SaveData. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
            return ISValid;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    //princy add
                    if (ItemNameUpdated != null)
                    {
                        ItemNameUpdated(txtItemName.Text);
                    }
                    //
                    Clear();
                    this.Close();
                    ClsCommon.ObjItemList.LoadItem();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :btnOk_Click. Message:  " + ex.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            if (txtItemName.Text == "" || txtItemName.Text != "")
            {
                ClsCommon.ObjInvoiceMaster.GetAllItem();
                ClsCommon.ObjCreditMemo.GetAllItem();

            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Clear();
            }
        }
        private void ItemTypeVisibility()
        {
            try
            {
                if (cmbItemType.SelectedIndex == 0)//Service Item
                {
                    lblItemName.Text = "Item Name/Number";
                    lblExpenseAccount.Text = "Expense Account";
                    cmbExpenseAccount.Visible = true;
                    cmbCOGSAccount.Visible = false;
                    chkSubItem.Visible = true;
                    cmbSubItem.Visible = true;
                    lblManufacturePartNumber.Visible = false;
                    txtManufacturerPartNumber.Visible = false;
                    pnlDiscount.Visible = false;
                    pnlGroupItemList.Visible = false;
                    pnlSales.Visible = true;
                    pnlGroupDesc.Visible = false;
                    grpInventoryInformation.Visible = false;
                    chkSalesOrPurchase.Visible = true;
                    chkSalesOrPurchase.Checked = false;
                    pnlSalesTaxItem.Visible = false;
                    SalesOrPurchase();
                    //Hiren
                    cmbTaxCode.SelectedIndex = 0;
                    cmbTaxCode.Visible = true;
                    lblTaxCode.Visible = true;
                }
                else if (cmbItemType.SelectedIndex == 1)//Invetory Part Item
                {
                    lblItemName.Text = "Item Name/Number";
                    lblExpenseAccount.Text = "COGS Account";
                    cmbCOGSAccount.Visible = true;
                    cmbExpenseAccount.Visible = false;
                    lblTypeDesc.Text = "Use for goods you purchase, track as inventory, and resell.";
                    chkSubItem.Visible = true;
                    cmbSubItem.Visible = true;
                    lblManufacturePartNumber.Visible = true;
                    txtManufacturerPartNumber.Visible = true;
                    chkSalesOrPurchase.Visible = false;
                    chkSalesOrPurchase.Checked = false;
                    pnlGroupItemList.Visible = false;
                    pnlDiscount.Visible = false;
                    pnlSales.Visible = false;
                    pnlGroupDesc.Visible = false;
                    grpInventoryInformation.Visible = true;
                    grpSalesInfo.Visible = true;
                    grpPurchaseInfo.Visible = true;
                    pnlSalesTaxItem.Visible = false;

                    chkSalesOrPurchase.Text = "This item is used in assemblies or is purchased for a specific customer:job";
                    //Hiren
                    cmbTaxCode.SelectedIndex = 0;
                    cmbTaxCode.Visible = true;
                    lblTaxCode.Visible = true;
                }
                else if (cmbItemType.SelectedIndex == 2)//Non-Inventroy Item
                {
                    lblTypeDesc.Text = "Use for goods you but don't track. like office \r\n" +
                        "supplies, or materiales for a Specific job that you \r\n" +
                        "Charge back to the customer.";
                    lblItemName.Text = "Item Name/Number";
                    lblExpenseAccount.Text = "Expense Account";
                    cmbExpenseAccount.Visible = true;
                    cmbCOGSAccount.Visible = false;
                    chkSubItem.Visible = true;
                    cmbSubItem.Visible = true;
                    cmbCOGSAccount.Visible = false;
                    lblManufacturePartNumber.Visible = true;
                    txtManufacturerPartNumber.Visible = true;
                    chkSalesOrPurchase.Visible = true;
                    chkSalesOrPurchase.Checked = false;
                    pnlGroupItemList.Visible = false;
                    pnlDiscount.Visible = false;
                    pnlGroupDesc.Visible = false;
                    pnlSales.Visible = true;
                    grpInventoryInformation.Visible = false;
                    pnlSalesTaxItem.Visible = false;

                    SalesOrPurchase();
                    chkSalesOrPurchase.Text = "This item is used in assemblies or is purchased for a specific customer:job";
                    //Hiren
                    cmbTaxCode.SelectedIndex = 0;
                    cmbTaxCode.Visible = true;
                    lblTaxCode.Visible = true;
                }
                else if (cmbItemType.SelectedIndex == 3)//Other Charges Item
                {
                    lblTypeDesc.Text = "Use for miscellaneous labor, material, or part \r\n" +
                        "charges, such as delivery charges, setup fees, and \r\n" +
                        "service charges.";
                    lblItemName.Text = "Item Name/Number";
                    lblExpenseAccount.Text = "Expense Account";
                    cmbExpenseAccount.Visible = true;
                    cmbCOGSAccount.Visible = false;
                    chkSubItem.Visible = true;
                    cmbSubItem.Visible = true;
                    lblManufacturePartNumber.Visible = false;
                    txtManufacturerPartNumber.Visible = false;
                    pnlGroupItemList.Visible = false;
                    pnlDiscount.Visible = false;
                    pnlGroupDesc.Visible = false;
                    pnlSales.Visible = true;
                    grpInventoryInformation.Visible = false;
                    chkSalesOrPurchase.Visible = true;
                    chkSalesOrPurchase.Checked = false;
                    pnlSalesTaxItem.Visible = false;

                    SalesOrPurchase();
                    chkSalesOrPurchase.Text = "This item is used in assemblies or is a reimbursable charge";
                    //Hiren
                    cmbTaxCode.SelectedIndex = 0;
                    cmbTaxCode.Visible = true;
                    lblTaxCode.Visible = true;
                }
                else if (cmbItemType.SelectedIndex == 5)//Discount Item
                {
                    lblTypeDesc.Text = "Use to subtract a percentage or fixed amount from a \r\n" +
                        "total or subtotal. Do not use this item type for an early \r\n" +
                        "Payment dicount.";
                    lblItemName.Text = "Item Name/Number";
                    chkSubItem.Visible = true;
                    cmbSubItem.Visible = true;
                    lblManufacturePartNumber.Visible = false;
                    txtManufacturerPartNumber.Visible = false;
                    pnlGroupItemList.Visible = false;
                    pnlSales.Visible = false;
                    pnlGroupDesc.Visible = false;
                    grpPurchaseInfo.Visible = false;
                    grpSalesInfo.Visible = false;
                    grpInventoryInformation.Visible = false;
                    pnlDiscount.Visible = true;
                    chkSalesOrPurchase.Visible = false;
                    chkSalesOrPurchase.Checked = false;
                    pnlSalesTaxItem.Visible = false;
                    //Hiren
                    cmbTaxCode.SelectedIndex = 0;
                    cmbTaxCode.Visible = true;
                    lblTaxCode.Visible = true;
                }
                else if (cmbItemType.SelectedIndex == 4)//Group Item
                {
                    lblTypeDesc.Text = "Use to quickly enter a group of individual items on an \r\n" +
                        "invoice. \r\n";
                    lblItemName.Text = "Group Name/Number";
                    pnlGroupDesc.Visible = true;
                    pnlGroupItemList.Visible = true;
                    chkSubItem.Visible = false;
                    cmbSubItem.Visible = false;
                    lblManufacturePartNumber.Visible = false;
                    txtManufacturerPartNumber.Visible = false;
                    pnlDiscount.Visible = false;
                    grpInventoryInformation.Visible = false;
                    chkSalesOrPurchase.Visible = false;
                    chkSalesOrPurchase.Checked = false;
                    pnlSalesTaxItem.Visible = false;
                    SalesOrPurchase();
                    GetAllItem();
                    //Hiren
                    //cmbTaxCode.SelectedIndex = 0;
                    cmbTaxCode.Visible = false;
                    lblTaxCode.Visible = false;
                }
                else if (cmbItemType.SelectedIndex == 6)//Group Item
                {
                    lblItemName.Text = "Sales Tax Name";
                    lblTypeDesc.Text = "Use to calculate a single sales tax at a specific rate\r\n" +
                                        "that you pay to a single tax agency.\r\n";
                    chkSubItem.Visible = false;
                    cmbSubItem.Visible = false;
                    lblManufacturePartNumber.Visible = false;
                    txtManufacturerPartNumber.Visible = false;
                    pnlGroupItemList.Visible = false;
                    pnlSales.Visible = false;
                    pnlGroupDesc.Visible = false;
                    grpPurchaseInfo.Visible = false;
                    grpSalesInfo.Visible = false;
                    grpInventoryInformation.Visible = false;
                    pnlDiscount.Visible = false;
                    chkSalesOrPurchase.Visible = false;
                    chkSalesOrPurchase.Checked = false;
                    cmbDiscountAccount.Visible = false;
                    pnlSalesTaxItem.Visible = true;
                    //SalesOrPurchase();
                    //GetAllItem();
                    //Hiren
                    //cmbTaxCode.SelectedIndex = 0;
                    cmbTaxCode.Visible = false;
                    lblTaxCode.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :ItemTypeVisibility. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void cmbItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetItem();
                ItemTypeVisibility();
                FormResize();
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :cmbItemType_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void FormResize()
        {
            try
            {
                if (cmbItemType.SelectedIndex == 0 || cmbItemType.SelectedIndex == 2 || cmbItemType.SelectedIndex == 3)
                {
                    if (chkSalesOrPurchase.Checked == false)
                        ClsCommon.ObjItemMaster.Height = 380;
                    else
                        ClsCommon.ObjItemMaster.Height = 480;
                }
                else if (cmbItemType.SelectedIndex == 1)
                    ClsCommon.ObjItemMaster.Height = 580;
                else if (cmbItemType.SelectedIndex == 4)
                    ClsCommon.ObjItemMaster.Height = 520;
                else if (cmbItemType.SelectedIndex == 5)
                    ClsCommon.ObjItemMaster.Height = 360;
                else if (cmbItemType.SelectedIndex == 6)
                    ClsCommon.ObjItemMaster.Height = 320;

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :FormResize. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void FrmItemMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClsCommon.ObjItemMaster.Hide();
            ClsCommon.ObjItemMaster.Parent = null;
            ClsCommon.ObjItemMaster.Mode = "insert";
            ClsCommon.ObjItemMaster.Clear();
            e.Cancel = true;
            cmbItemType.Enabled = true;
            cmbItemType.SelectedIndex = 0;
            
        }

        private void dgvGroupItem_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgvGroupItem.CurrentCell.ColumnIndex == 1 && e.Control is ComboBox)
                {
                    ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                    ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                    ((ComboBox)e.Control).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    ((ComboBox)e.Control).DropDownWidth = 300;
                    ComboBox comboBox = e.Control as ComboBox;
                    if (comboBox != null)
                    {
                        comboBox.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                        comboBox.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
                    }
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :dgvGroupItem_EditingControlShowing. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (((ComboBox)sender).SelectedIndex != -1)
                {
                    DataTable dt = new BALItemMaster().Select(new BOLItemMaster() { });
                    if (dt.Rows.Count > 0)
                    {
                        DataRow[] row = dt.Select("FullName = '" + ((ComboBox)sender).SelectedItem.ToString() + "'");
                        if (row.Length == 1)
                        {
                            foreach (DataRow dr in row)
                            {
                                dgvGroupItem.CurrentRow.Cells["ID"].Value = dr["ID"].ToString();
                                dgvGroupItem.CurrentRow.Cells["Description"].Value = dr["SalesDesc"].ToString();
                            }
                        }
                    }
                    //string Desc = ((ComboBox)sender).SelectedItem.ToString();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :ComboBox_SelectedIndexChanged. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void dgvGroupItem_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void txtQtyOnHand_KeyPress(object sender, KeyPressEventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :txtQtyOnHand_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void txtTotalValue_KeyPress(object sender, KeyPressEventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :txtTotalValue_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void txtDiscountAmount_KeyPress(object sender, KeyPressEventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :txtDiscountAmount_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void txtPurchaseCost_KeyPress(object sender, KeyPressEventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :txtPurchaseCost_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :txtRate_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void txtSalesPrice_KeyPress(object sender, KeyPressEventArgs e)
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
                ClsCommon.WriteErrorLogs("Form:FrmItemMaster,Function :txtSalesPrice_KeyPress. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void txtItemName_Leave(object sender, EventArgs e)
        {
            if (cmbItemType.SelectedIndex == 6)
            {
                if (ClsCommon.ObjItemMaster.Mode == "insert" && txtTaxDescription.Text == "")
                {
                    txtTaxDescription.Text = "Sales Tax";
                }
            }
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsControl(e.KeyChar))
                return;

            ComboBox comboBox = sender as ComboBox;


            string newText = txtItemName.Text.Insert(txtItemName.SelectionStart, e.KeyChar.ToString());


            if (IsOnlyDigits(newText) || StartsWithDigit(newText))
            {
                e.Handled = true;
            }
        }
        private bool IsOnlyDigits(string input)
        {
            return input.All(char.IsDigit);
        }

        private bool StartsWithDigit(string input)
        {
            return input.Length > 0 && char.IsDigit(input[0]);
        }


    }
}