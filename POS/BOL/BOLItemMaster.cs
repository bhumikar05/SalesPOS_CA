using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLItemMaster
    {
        public string Spara
        {
            get;
            set;
        }
        public int? ID
        {
            get;
            set;
        }
        public string ItemName
        {
            get;
            set;
        }
        public string FullName
        {
            get;
            set;
        }
        public int? IsActive
        {
            get;
            set;
        }
        public int? ParentID
        {
            get;
            set;
        }
        public string ItemType
        {
            get;
            set;
        }
        public string SalesDesc
        {
            get;
            set;
        }
        public decimal SalesPrice
        {
            get;
            set;
        }
        public int? IncomeAccountID
        {
            get;
            set;
        }
        public string PurchaseDesc
        {
            get;
            set;
        }
        public decimal PurchaseCost
        {
            get;
            set;
        }
        public DateTime PCDate
        {
            get;
            set;
        }
        public int? ExpenseAccountID
        {
            get;
            set;
        }
        public int? VendorID
        {
            get;
            set;
        }
        public string ManufacturePartNumber
        {
            get;
            set;
        }
        public int? CogsAccountID
        {
            get;
            set;
        }
        public int? AssetAccountID
        {
            get;
            set;
        }
        public string ReorderPointMin
        {
            get;
            set;
        }
        public string ReorderPointMax
        {
            get;
            set;
        }
        public decimal QtyOnHand
        {
            get;
            set;
        }
        public decimal TotalValue
        {
            get;
            set;
        }
        public decimal PriceTier1
        {
            get;
            set;
        }
        public decimal PriceTier2
        {
            get;
            set;
        }
        public decimal PriceTier3
        {
            get;
            set;
        }
        public string InventoryDate
        {
            get;
            set;
        }
        public int? PrintGroupItem
        {
            get;
            set;
        }
        public decimal LowestPrice
        {
            get;
            set;
        }
        public string ItemCode
        {
            get;
            set;
        }
        public DateTime CreatedTime
        {
            get;
            set;
        }
        public DateTime ModifiedTime
        {
            get;
            set;
        }
        public int? CreatedID
        {
            get;
            set;
        }
        public int? ModifiedID
        {
            get;
            set;
        }
        public int? IsSync
        {
            get;
            set;
        }
        public DateTime StartDate
        {
            get;
            set;
        }
        public DateTime EndDate
        {
            get;
            set;
        }
        public decimal ComparativePrice1
        {
            get;
            set;
        }
        public DateTime C1Date
        {
            get;
            set;
        }
        public decimal ComparativePrice2
        {
            get;
            set;
        }
        public DateTime C2Date
        {
            get;
            set;
        }
        public decimal ComparativePrice3
        {
            get;
            set;
        }
        public DateTime C3Date
        {
            get;
            set;
        }
        public decimal ComparativePrice4
        {
            get;
            set;
        }
        public DateTime C4Date
        {
            get;
            set;
        }
        public decimal ComparativePrice5
        {
            get;
            set;
        }
        public DateTime C5Date
        {
            get;
            set;
        }
        public string FilterName
        {
            get;
            set;
        }
        public int? PosID
        {
            get;
            set;

        }

        public int? FilterID
        {
            get;
            set;

        }

        public decimal WebPrice
        {
            get;
            set;
        }
        public decimal SalesTaxPercentage
        {
            get;
            set;
        }
        public DateTime WPDate
        {
            get;
            set;
        }
        //Hiren
        public string TaxCode
        {
            get;
            set;
        }
        //public string IncomeAccount
        //{
        //    get;
        //    set;
        //}

        //public string ExpenseAccount
        //{
        //    get;
        //    set;
        //}

        //public string CogsAccount
        //{
        //    get;
        //    set;
        //}

        //public string AssetAccount
        //{
        //    get;
        //    set;
        //}

    }
}
