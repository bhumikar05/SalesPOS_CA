using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLInvoiceMaster
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
        public int? CustomerID
        {
            get;
            set;
        }

        public int? ARAccountID
        {
            get;
            set;
        }
        public DateTime TxnDate
        {
            get;
            set;
        }
        public string RefNumber
        {
            get;
            set;
        }
        public string PONumber
        {
            get;
            set;
        }
        public int? TermsID
        {
            get;
            set;
        }
        public DateTime DueDate
        {
            get;
            set;
        }
        public int? SalesRepID
        {
            get;
            set;
        }
        public DateTime ShipDate
        {
            get;
            set;
        }
        public int? ShipMethodID
        {
            get;
            set;
        }
        public int? ServiceID
        {
            get;
            set;
        }
        public decimal Total
        {
            get;
            set;
        }
        public decimal TaxAmount
        {
            get;
            set;
        }
        public decimal TaxPercent
        {
            get;
            set;
        }
        public decimal TaxID
        {
            get;
            set;
        }
        public string TaxRef
        {
            get;
            set;
        }
        public string NonTaxRef
        {
            get;
            set;
        }
        public string Type
        {
            get;
            set;
        }

        public decimal AppliedAmount
        {
            get;
            set;
        }
        public decimal BalanceDue
        {
            get;
            set;
        }
        public string Memo
        {
            get;
            set;
        }
        public int? ShipAddressID
        {
            get;
            set;
        }
        public int? PaidInvoice
        {
            get;
            set;
        }
        public int? PandingInvoice
        {
            get;
            set;
        }
        public int? IsSync
        {
            get;
            set;
        }
        public int? IsShipping
        {
            get;
            set;
        }
        public string TrackingNumber
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
        public DateTime ShippingDate
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
        public DateTime FromDate
        {
            get;
            set;
        }
        public DateTime ToDate
        {
            get;
            set;
        }
        public string ShipAdd1
        {
            get;
            set;
        }
        public string ShipAdd2
        {
            get;
            set;
        }
        public string ShipAdd3
        {
            get;
            set;
        }
        public string ShipCity
        {
            get;
            set;
        }
        public string ShipState
        {
            get;
            set;
        }
        public string ShipPostalCode
        {
            get;
            set;
        }
        public string ShipCountry
        {
            get;
            set;
        }
        public string CustomerName
        {
            get;
            set;
        }
        public string PriceTier
        {
            get;
            set;
        }
        public int ? IsPrint
        {
            get;
            set;
        }
        public int? OldCustomerID
        {
            get;
            set;
        }
        public int? COUNT
        {
            get;
            set;
        }
        public int? IsCustomerNumber
        {
            get;
            set;
        }
        public int? PosID
        {
            get; 
            set;
        }
        //princy
        public int CustomerMessage
        {
            get;
            set;
        }
    }
}
