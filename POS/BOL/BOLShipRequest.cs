using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    public class BOLShipRequest
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
        public int? UserID
        {
            get;
            set;
        }
        public int? InvoiceID
        {
            get;
            set;
        }
        public string Reason
        {
            get;
            set;
        }
        public DateTime Date
        {
            get;
            set;
        }
        public int? Allow
        {
            get;
            set;
        }

    }
}
