using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLInvoiceDetails
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
        public int? SrNo
        {
            get;
            set;
        }
        public int? InvoiceID
        {
            get;
            set;
        }
        public int? ItemID
        {
            get;
            set;
        }
        public string Decs
        {
            get;
            set;
        }
        public decimal? Quantity
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
        public string ItemType
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
        public int? OldItemID
        {
            get;
            set;
        }
        public string ItemName
        {
            get;
            set;
        }
        public string IMEINumber
        {
            get;
            set;
        }
        public string Reason
        {
            get;
            set;
        }

        public string GRADING
        {
            get;
            set;
        }
        //Hiren
        public string Tax
        {
            get;
            set;
        }

    }
}
