using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPOS.BOL
{
    class BOLManuallyEmail
    {
        public string MODE
        {
            get;
            set;
        }
        public int? ID
        {
            get;
            set;
        }
        public string ConsolePath
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
        public string DailyShipTo
        {
            get;
            set;
        }
        public string DailyShipCC
        {
            get;
            set;
        }
        public int? DailyShipMail
        {
            get;
            set;
        }
        public string ItemCodesTo
        {
            get;
            set;
        }
        public string ItemCodesCC
        {
            get;
            set;
        }
        public int? ItemCodesMail
        {
            get;
            set;
        }
        public string ProfitReportTo
        {
            get;
            set;
        }
        public string ProfitReportCC
        {
            get;
            set;
        }
        public int? ProfitReportMail
        {
            get;
            set;
        }
        public string PaymentsAndCreditMemoTo
        {
            get;
            set;
        }
        public string PaymentsAndCreditMemoCC
        {
            get;
            set;
        }
        public int? PaymentsAndCreditMemoMail
        {
            get;
            set;
        }
        public string SummaryReportTo
        {
            get;
            set;
        }
        public string SummaryReportCC
        {
            get;
            set;
        }
        public int? SummaryReportMail
        {
            get;
            set;
        }
    }
}
