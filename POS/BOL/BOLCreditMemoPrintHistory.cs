using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLCreditMemoPrintHistory
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
        public int? CreditMemoID
        {
            get;
            set;
        }
        public int? SalesRepID
        {
            get;
            set;
        }
        public DateTime PrintDate
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
    }
}
