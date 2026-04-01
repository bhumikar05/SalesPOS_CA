using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLZelleMaster
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
        public string ZelleName
        {
            get;
            set;
        }
        public DateTime Date
        {
            get;
            set;
        }
        public decimal? Amount
        {
            get;
            set;
        }
        public decimal? TotalAmount
        {
            get;
            set;
        }
    }
}
