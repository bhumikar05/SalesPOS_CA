using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLUPS_FedExHistory
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
        public string Type
        {
            get;
            set;
        }
        public string OrderID
        {
            get;
            set;
        }
        public string TrackingID
        {
            get;
            set;
        }
        public DateTime Time
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
        public int? CreatedBy
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
        public string Service
        {
            get;
            set;
        }
        public string Weight
        {
            get;
            set;
        }
        public string COD
        {
            get;
            set;
        }
        public string Charges
        {
            get;
            set;
        }
        public string TotalCost
        {
            get;
            set;
        }
    }
}
