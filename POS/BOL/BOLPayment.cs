using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLPayment
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
        public int ? PaymentMethodID
        {
            get;
            set;
        }
        public decimal? PayAmount
        {
            get;
            set;
        }
        public decimal? CreditAmount
        {
            get;
            set;
        }
        public DateTime ? Date
        {
            get;
            set;
        }
        public string TransactionID
        {
            get;
            set;
        }
        public int? PayPalID
        {
            get;
            set;
        }
        public int? IsQBSync
        {
            get;
            set;
        }
        //Hiren
        public string Reference
        {
            get;
            set;
        }
    }
}
