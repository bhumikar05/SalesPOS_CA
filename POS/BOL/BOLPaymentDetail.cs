using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLPaymentDetail
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
        public int ? PaymentStatus
        {
            get;
            set;
        }
        public decimal ? DueAmount
        {
            get;
            set;
        }
       
        public int? InvoiceID
        {
            get;
            set;
        }
        public decimal? PaidAmount
        {
            get;
            set;
        }
        public decimal? CreditAmount
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
        public int? PaymentMethodID
        {
            get;
            set;
        }
        public int? CustomerID
        {
            get;
            set;
        }
        public int? CreatedID
        {
            get;
            set;
        }
        public int? SalesRepID
        {
            get;
            set;
        }
        public string RefNumber
        {
            get;
            set;
        }
        public string FullName
        {
            get;
            set;
        }
        public int? IsCustomerNumber
        {
            get;
            set;
        }
    }
}
