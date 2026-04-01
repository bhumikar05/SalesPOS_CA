using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALItemMaster
    {
        public DataTable Select(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectItemByDate(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectItemByDate");
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectInvItem(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectInvItem");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectItemForRead()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectItemForRead");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectItemByLowestPrice()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectItemByLowestPrice");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByPurchaseCost()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByPurchaseCost");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectBy()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByName");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectAllItem(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectAllItem");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectInventoryItem(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectInventoryItem");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByParentID(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByParentID");
            cmd.Parameters.AddWithValue("@ParentID", obj.ParentID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectItem(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectItem");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectInActiveItemName(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectInActiveItemName");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }
        public DataTable SelectActiveItemName(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectActiveItemName");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByID(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByID");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByItemName(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByItemName");
            cmd.Parameters.AddWithValue("@FullName", obj.FullName);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public int Insert(BOLItemMaster obj)
        {
            int ID = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@ItemName", obj.ItemName);
            cmd.Parameters.AddWithValue("@FullName", obj.FullName);
            cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
            cmd.Parameters.AddWithValue("@ItemType", obj.ItemType);
            cmd.Parameters.AddWithValue("@ParentID", obj.ParentID);
            cmd.Parameters.AddWithValue("@SalesDesc", obj.SalesDesc);
            cmd.Parameters.AddWithValue("@SalesPrice", obj.SalesPrice);
            cmd.Parameters.AddWithValue("@IncomeAccountID", obj.IncomeAccountID);
            cmd.Parameters.AddWithValue("@PurchaseDesc", obj.PurchaseDesc);
            cmd.Parameters.AddWithValue("@PurchaseCost", obj.PurchaseCost);
            cmd.Parameters.AddWithValue("@ExpenseAccountID", obj.ExpenseAccountID);
            cmd.Parameters.AddWithValue("@ManufacturePartNumber", obj.ManufacturePartNumber);
            cmd.Parameters.AddWithValue("@VendorID", obj.VendorID);
            cmd.Parameters.AddWithValue("@CogsAccountID", obj.CogsAccountID);
            cmd.Parameters.AddWithValue("@AssetAccountID", obj.AssetAccountID);
            cmd.Parameters.AddWithValue("@ReorderPointMin", obj.ReorderPointMin);
            cmd.Parameters.AddWithValue("@ReorderPointMax", obj.ReorderPointMax);
            cmd.Parameters.AddWithValue("@QtyOnHand", obj.QtyOnHand);
            cmd.Parameters.AddWithValue("@TotalValue", obj.TotalValue);
            cmd.Parameters.AddWithValue("@InventoryDate", obj.InventoryDate);
            cmd.Parameters.AddWithValue("@PrintGroupItem", obj.PrintGroupItem);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            cmd.Parameters.AddWithValue("@FilterID", obj.FilterID);
            //Bhumika
            cmd.Parameters.AddWithValue("@SalesTaxPercentage", obj.SalesTaxPercentage);
            //
            cmd.Parameters.AddWithValue("@IsSync", obj.IsSync);
            cmd.Parameters.AddWithValue("@TaxCode", obj.TaxCode);
            DAL DAL = new DAL();
            ID = DAL.Insert_Update_Del(cmd);
            return ID;
        }
        public void UpdateItem(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdateItem");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }

        public void UpdateInactive(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdateInactive");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public void UpdatePrice(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdatePrice");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@FullName", obj.FullName);
            cmd.Parameters.AddWithValue("@SalesDesc", obj.SalesDesc);
            cmd.Parameters.AddWithValue("@SalesPrice", obj.SalesPrice);
            cmd.Parameters.AddWithValue("@PurchaseDesc", obj.PurchaseDesc);
            cmd.Parameters.AddWithValue("@PurchaseCost", obj.PurchaseCost);
            cmd.Parameters.AddWithValue("@QtyOnHand", obj.QtyOnHand);
            cmd.Parameters.AddWithValue("@PriceTier1", obj.PriceTier1);
            cmd.Parameters.AddWithValue("@PriceTier2", obj.PriceTier2);
            cmd.Parameters.AddWithValue("@PriceTier3", obj.PriceTier3);
            cmd.Parameters.AddWithValue("@FilterID", obj.FilterID);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public int Update(BOLItemMaster obj)
        {
            int ID = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@ItemName", obj.ItemName);
            cmd.Parameters.AddWithValue("@FullName", obj.FullName);
            cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
            cmd.Parameters.AddWithValue("@ItemType", obj.ItemType);
            cmd.Parameters.AddWithValue("@ParentID", obj.ParentID);
            cmd.Parameters.AddWithValue("@SalesDesc", obj.SalesDesc);
            cmd.Parameters.AddWithValue("@SalesPrice", obj.SalesPrice);
            cmd.Parameters.AddWithValue("@IncomeAccountID", obj.IncomeAccountID);
            cmd.Parameters.AddWithValue("@PurchaseDesc", obj.PurchaseDesc);
            cmd.Parameters.AddWithValue("@PurchaseCost", obj.PurchaseCost);
            cmd.Parameters.AddWithValue("@ExpenseAccountID", obj.ExpenseAccountID);
            cmd.Parameters.AddWithValue("@ManufacturePartNumber", obj.ManufacturePartNumber);
            cmd.Parameters.AddWithValue("@VendorID", obj.VendorID);
            cmd.Parameters.AddWithValue("@CogsAccountID", obj.CogsAccountID);
            cmd.Parameters.AddWithValue("@AssetAccountID", obj.AssetAccountID);
            cmd.Parameters.AddWithValue("@ReorderPointMin", obj.ReorderPointMin);
            cmd.Parameters.AddWithValue("@ReorderPointMax", obj.ReorderPointMax);
            cmd.Parameters.AddWithValue("@QtyOnHand", obj.QtyOnHand);
            cmd.Parameters.AddWithValue("@TotalValue", obj.TotalValue);
            cmd.Parameters.AddWithValue("@InventoryDate", obj.InventoryDate);
            cmd.Parameters.AddWithValue("@PrintGroupItem", obj.PrintGroupItem);
            cmd.Parameters.AddWithValue("@ModifiedID", obj.ModifiedID);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            cmd.Parameters.AddWithValue("@FilterID", obj.FilterID);
            //Bhumika
            cmd.Parameters.AddWithValue("@SalesTaxPercentage", obj.SalesTaxPercentage);
            //
            cmd.Parameters.AddWithValue("@IsSync", obj.IsSync);
            //Hiren
            cmd.Parameters.AddWithValue("@TaxCode", obj.TaxCode);
            DAL DAL = new DAL();
            ID = DAL.Insert_Update_Del(cmd);
            return ID;
        }

        public int NewUpdate(BOLItemMaster obj)
        {
            int ID = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPNewItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@PosID", obj.PosID);
            cmd.Parameters.AddWithValue("@ItemName", obj.ItemName);
            cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
            cmd.Parameters.AddWithValue("@ItemType", obj.ItemType);
            cmd.Parameters.AddWithValue("@SalesDesc", obj.SalesDesc);
            cmd.Parameters.AddWithValue("@SalesPrice", obj.SalesPrice);
            cmd.Parameters.AddWithValue("@PurchaseDesc", obj.PurchaseDesc);
            cmd.Parameters.AddWithValue("@PurchaseCost", obj.PurchaseCost);
            cmd.Parameters.AddWithValue("@IncomeAccountID", obj.IncomeAccountID);
            cmd.Parameters.AddWithValue("@ExpenseAccountID", obj.ExpenseAccountID);
            cmd.Parameters.AddWithValue("@ManufacturePartNumber", obj.ManufacturePartNumber);
            cmd.Parameters.AddWithValue("@CogsAccountID", obj.CogsAccountID);
            cmd.Parameters.AddWithValue("@AssetAccountID", obj.AssetAccountID);
            cmd.Parameters.AddWithValue("@QtyOnHand", obj.QtyOnHand);
            cmd.Parameters.AddWithValue("@TotalValue", obj.TotalValue);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            cmd.Parameters.AddWithValue("@IsSync", obj.IsSync);
            cmd.Parameters.AddWithValue("@TaxCode", obj.TaxCode);
            DAL DAL = new DAL();
            ID = DAL.Insert_Update_Del(cmd);
            return ID;
        }
        public int NewInsert(BOLItemMaster obj)
        {
            int ID = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPNewItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@PosID", obj.PosID);
            cmd.Parameters.AddWithValue("@ItemName", obj.ItemName);
            cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
            cmd.Parameters.AddWithValue("@ItemType", obj.ItemType);
            cmd.Parameters.AddWithValue("@SalesDesc", obj.SalesDesc);
            cmd.Parameters.AddWithValue("@SalesPrice", obj.SalesPrice);
            cmd.Parameters.AddWithValue("@PurchaseDesc", obj.PurchaseDesc);
            cmd.Parameters.AddWithValue("@PurchaseCost", obj.PurchaseCost);
            cmd.Parameters.AddWithValue("@IncomeAccountID", obj.IncomeAccountID);
            cmd.Parameters.AddWithValue("@ExpenseAccountID", obj.ExpenseAccountID);
            cmd.Parameters.AddWithValue("@ManufacturePartNumber", obj.ManufacturePartNumber);
            cmd.Parameters.AddWithValue("@CogsAccountID", obj.CogsAccountID);
            cmd.Parameters.AddWithValue("@AssetAccountID", obj.AssetAccountID);
            cmd.Parameters.AddWithValue("@QtyOnHand", obj.QtyOnHand);
            cmd.Parameters.AddWithValue("@TotalValue", obj.TotalValue);
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            cmd.Parameters.AddWithValue("@IsSync", obj.IsSync);
            cmd.Parameters.AddWithValue("@TaxCode", obj.TaxCode);
            DAL DAL = new DAL();
            ID = DAL.Insert_Update_Del(cmd);
            return ID;
        }

        public void UpdateFullName(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdateFullName");
            cmd.Parameters.AddWithValue("@ParentID", obj.ParentID);
            cmd.Parameters.AddWithValue("@FullName", obj.FullName);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public void UpdateLowestPrice(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdateLowestPrice");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@LowestPrice", obj.LowestPrice);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public void UpdatePurchaseCost(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdatePurchaseCost");
            cmd.Parameters.AddWithValue("@FullName", obj.FullName);
            cmd.Parameters.AddWithValue("@PurchaseCost", obj.PurchaseCost);
            //if (obj.FilterID != 0)
            //{
            //    cmd.Parameters.AddWithValue("@FilterID", obj.FilterID);
            //}

            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public DataTable SelectByQtyOnHand()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByQtyOnHand");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void UpdateQtyOnHand(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdateQtyOnHand");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@QtyOnHand", obj.QtyOnHand);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public DataTable SelectBySalesPrice()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectBySalesPrice");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void UpdateSalesPrice(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdateSalesPrice");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@SalesPrice", obj.SalesPrice);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public DataTable SelectByComparativePrice()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByComparativePrice");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void UpdateComparativePrice(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdateComparativePrice");
            cmd.Parameters.AddWithValue("@ItemName", obj.ItemName);
            cmd.Parameters.AddWithValue("@ComparativePrice1", obj.ComparativePrice1);
            cmd.Parameters.AddWithValue("@ComparativePrice2", obj.ComparativePrice2);
            cmd.Parameters.AddWithValue("@ComparativePrice3", obj.ComparativePrice3);
            cmd.Parameters.AddWithValue("@ComparativePrice4", obj.ComparativePrice4);
            cmd.Parameters.AddWithValue("@ComparativePrice5", obj.ComparativePrice5);
            //cmd.Parameters.AddWithValue("@FilterID", obj.FilterID);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public DataTable SelectByPriceTier()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByPriceTier");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void UpdatePriceTier(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdatePriceTier");
            //cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@FullName", obj.FullName);
            cmd.Parameters.AddWithValue("@PriceTier1", obj.PriceTier1);
            cmd.Parameters.AddWithValue("@PriceTier2", obj.PriceTier2);
            cmd.Parameters.AddWithValue("@PriceTier3", obj.PriceTier3);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public DataTable ItemSummaryList(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "ItemSummaryList");
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Delete(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "Delete");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
        public DataTable GetWeight()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "GetWeight");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void UpdateWebPrice(BOLItemMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdateWebPrice");
            cmd.Parameters.AddWithValue("@FullName", obj.FullName);
            cmd.Parameters.AddWithValue("@WebPrice", obj.WebPrice);
            //if (obj.FilterID != 0)
            //{
            //    cmd.Parameters.AddWithValue("@FilterID", obj.FilterID);
            //}

            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public DataTable SelectByWebPrice()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByWebPrice");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        //princy
        public DataTable ItemID_Last()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemMaster";
            cmd.Parameters.AddWithValue("@Spara", "Item_LastID");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
    }
}
