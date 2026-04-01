using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLFedExUPSHistory
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
        public int? TrackingID
        {
            get;
            set;
        }
        public string Postage
        {
            get;
            set;
        }
        public string Time
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
    }
}
