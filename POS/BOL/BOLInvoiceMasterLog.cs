using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLInvoiceMasterLog
    {
        public int ID { get; set; }

        public int InvoiceID { get; set; }
        public int? EditCount { get; set; }

        public string NewRefNumber { get; set; }

        public string NewCustomerID { get; set; }
        public string OldCustomerID { get; set; }


        public string NewPONumber { get; set; }
        public string OldPONumber { get; set; }

        public string NewTermsID { get; set; }
        public string OldTermsID { get; set; }

        public string NewDueDate { get; set; }
        public string OldDueDate { get; set; }

        public string NewSalesRepId { get; set; }
        public string OldSalesRepId { get; set; }

        public string NewShipDate { get; set; }
        public string OldShipDate { get; set; }

        public string NewShipMethodID { get; set; }
        public string OldShipMethodID { get; set; }

        public string NewTotal { get; set; }
        public string OldTotal { get; set; }

        public string NewAppliedAmount { get; set; }
        public string OldAppliedAmount { get; set; }

        public string NewBalanceDue { get; set; }
        public string OldBalanceDue { get; set; }

        public string NewMemo { get; set; }
        public string OldMemo { get; set; }

        public DateTime UpdateDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }


     

    }
}
