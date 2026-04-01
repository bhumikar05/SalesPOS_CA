using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLNewCustomerHistory
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
        public int? ToSalesRepID
        {
            get;
            set;
        }
        public int? CustomerID
        {
            get;
            set;
        }
        public DateTime? Date
        {
            get;
            set;
        }
        public DateTime? StartDate
        {
            get;
            set;
        }
        public DateTime? EndDate
        {
            get;
            set;
        }
    }
}
