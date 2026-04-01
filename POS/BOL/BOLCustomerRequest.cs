using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLCustomerRequest
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
        public string InvoiceNumber
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
        public int? ItemID
        {
            get;
            set;
        }
        public string AdminMessage
        {
            get;
            set;
        }
        public decimal LowestPrice
        {
            get;
            set;
        }
        public int? AllowesNo
        {
            get;
            set;
        }
        public int? NoOFDays
        {
            get;
            set;
        }
        public int? CurrentInvoice
        {
            get;
            set;
        }
        public int? UseAllowesNo
        {
            get;
            set;
        }
        public int? UseNoOFDays
        {
            get;
            set;
        }
        public int? UseCurrentInvoice
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
        public int? IsRead
        {
            get;
            set;
        }
        public int? IsActive
        {
            get;
            set;
        }
        //Hiren
        public string StartDate
        {
            get;
            set;
        }
        public string EndDate
        {
            get;
            set;
        }
    }
}
