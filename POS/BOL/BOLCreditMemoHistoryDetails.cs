using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLCreditMemoHistoryDetails
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
        public int? CreditMemoHistoryID
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
