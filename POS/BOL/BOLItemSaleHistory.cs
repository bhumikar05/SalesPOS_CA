using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLItemSaleHistory
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
        public int? ItemID
        {
            get;
            set;
        }
        public int? InvoiceID
        {
            get;
            set;
        }
        public int? CustomerID
        {
            get;
            set;
        }
        public decimal SalePrice
        {
            get;
            set;
        }
        public DateTime LastSaleDate
        {
            get;
            set;
        }
        public int? ShippingMethodID
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
        public DateTime FromDate
        {
            get;
            set;
        }
        public DateTime ToDate
        {
            get;
            set;
        }
    }
}
