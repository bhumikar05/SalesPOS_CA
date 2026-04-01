using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLPaypalPaymentVerifaction
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
        public int? BankAccID
        {
            get;
            set;
        }
        public int? IsQBSync
        {
            get;
            set;
        }
        public string PaypalAccountID
        {
            get;
            set;
        }
        public string TransactionID
        {
            get;
            set;
        }
        public DateTime TransactionInitiationDate
        {
            get;
            set;
        }
        public DateTime TransactionUpdatedDate
        {
            get;
            set;
        }
        public string CurrencyCode
        {
            get;
            set;
        }
        public decimal Amount
        {
            get;
            set;
        }
        public decimal FeeAmount
        {
            get;
            set;
        }
        public decimal TotalAmount
        {
            get;
            set;
        }
        public decimal DueAmount
        {
            get;
            set;
        }
        public string TransactionStatus
        {
            get;
            set;
        }
        public string InvoiceNumber
        {
            get;
            set;
        }
        public int? InvoiceID
        {
            get;
            set;
        }
        public int? PaymentStatus
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
    }
}
