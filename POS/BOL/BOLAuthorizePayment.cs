using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLAuthorizePayment
    {
        public string mode
        {
            get;
            set;
        }
        public int ID
        {
            get;
            set;
        }
        public string transId
        {
            get;
            set;
        }
        public string invoiceNumber
        {
            get;
            set;
        }
        public string firstName
        {
            get;
            set;
        }
        public string lastName
        {
            get;
            set;
        }
        public string accountType
        {
            get;
            set;
        }
        public decimal settleAmount
        {
            get;
            set;
        }
        public DateTime submitTimeUTC
        {
            get;
            set;
        }
        public string transactionStatus
        {
            get;
            set;
        }
        public int? IsUpdate
        {
            get;
            set;
        }


    }
}
