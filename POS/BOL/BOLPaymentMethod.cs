using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLPaymentMethod
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
        public string Name
        {
            get;
            set;
        }
        public int? IsActive
        {
            get;
            set;
        }
        public string PaymentMethodType
        {
            get;
            set;
        }
    }
}
