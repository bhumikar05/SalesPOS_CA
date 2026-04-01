using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    public class BOLCreditMemoRequest
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
        public string CreditMemoNumber
        {
            get;
            set;
        }
        public int? SalesRepID
        {
            get;
            set;
        }
        public int? CustomerID
        {
            get;
            set;
        }
        public int? Status
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
        public int? IsActive
        {
            get;
            set;
        }
    }
}
