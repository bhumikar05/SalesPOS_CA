using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLCreditMemoAuditLogMaster
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
        public DateTime ? Datetime
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
    }
}
