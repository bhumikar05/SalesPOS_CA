using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLInvoiceAuditLogDetail
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
        public int? AuditID
        {
            get;
            set;
        }

        public int? SrNo
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
        public decimal Quantity
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
    }
}
