using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLHistoryMaster
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
        public int? IsPrint
        {
            get;
            set;
        }
        public int? IsUpdate
        {
            get;
            set;
        }
        public DateTime ? IsPrintDate
        {
            get;
            set;
        }
        public DateTime ? IsUpdateDate
        {
            get;
            set;
        }
        public int? InvoiceID
        {
            get;
            set;
        }
    }
}
