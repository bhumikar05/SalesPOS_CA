using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLInvoiceHistoryMaster
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
        public int? SalesRepID
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
        public int? AccountID
        {
            get;
            set;
        }
        public decimal Total
        {
            get;
            set;
        }
        public DateTime Time
        {
            get;
            set;
        }
        public DateTime StartDate
        {
            get;
            set;
        }
        public DateTime EndDate
        {
            get;
            set;
        }
        public string Mode
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
    }
}
