using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLCustomerTransferList
    {
        public string Mode
        {
            get;
            set;
        }
        public int? ID
        {
            get;
            set;
        }
        public int? CusID
        {
            get;
            set;
        }
        public int? OldSalesRep
        {
            get;
            set;
        }
        public int? NewSalesRep
        {
            get;
            set;
        }
        public DateTime ? Date
        {
            get;
            set;
        }

    }
}
