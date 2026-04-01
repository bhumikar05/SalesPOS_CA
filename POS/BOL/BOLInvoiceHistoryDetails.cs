using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLInvoiceHistoryDetails
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
        public int? InvoiceHistoryID
        {
            get;
            set;
        }
        public int? ItemID
        {
            get;
            set;
        }
        public decimal Qty
        {
            get;
            set;
        }
        public decimal Rate
        {
            get;
            set;
        }
        public decimal Amount
        {
            get;
            set;
        }
    }
}
