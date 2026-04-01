using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLAssignPriceTier
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
        public int? CustomerID
        {
            get;
            set;
        }
        public string PriceTier
        {
            get;
            set;
        }
        public int? UserID
        {
            get;
            set;
        }
    }
}
