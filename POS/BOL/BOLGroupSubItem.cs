using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLGroupSubItem
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
        public int? GroupItemID
        {
            get;
            set;
        }
        public int? ItemID
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public decimal Qty
        {
            get;
            set;
        }
        public DateTime CreatedTime
        {
            get;
            set;
        }
        public int? CreatedID
        {
            get;
            set;
        }
    }
}
