using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLCreditMemoPayment
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
        public int? CreditMemoID
        {
            get;
            set;
        }
        public DateTime Date
        {
            get;
            set;
        }
        public decimal? PayAmount
        {
            get;
            set;
        }
        public int? IsQBSync
        {
            get;
            set;
        }


    }
}
