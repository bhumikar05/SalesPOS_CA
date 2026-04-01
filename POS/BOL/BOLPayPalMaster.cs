using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLPayPalMaster
    {
        public string MODE
        {
            get;
            set;
        }
        public int? ID
        {
            get;
            set;
        }
        public string transaction_id
        {
            get;
            set;
        }
        public string transaction_updated_date
        {
            get;
            set;

        }
        public decimal? transaction_amount
        {
            get;
            set;
        }
        public string currency_code
        {
            get;
            set;
        }
        public string email_address
        {
            get;
            set;
        }
        public string payer_name
        {
            get;
            set;
        }
        public string country_code
        {
            get;
            set;
        }
        public int? IsUpdate
        {
            get;
            set;
        }
        public decimal? Transaction_Balance
        {
            get;
            set;
        }
    }
}
