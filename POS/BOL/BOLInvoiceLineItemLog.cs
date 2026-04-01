using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLInvoiceLineItemLog
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
        public int? InvoiceID
        {
            get;
            set;
        }
        public int? ItemID
        {
            get;
            set;
        }
        public int? EditCount
        {
            get;
            set;
        }
        public string EditMode
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public decimal ? Qty
        {
            get;
            set;
        }
        public decimal? PriceEach
        {
            get;
            set;
        }
        public decimal? Amount
        {
            get;
            set;
        }
        public int ? IsPrint
        {
            get;
            set;
        }

        public decimal? OldQty
        {
            get;
            set;
        }

    }
}
