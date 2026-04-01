using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLCusCallLog
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
        public int? UserID
        {
            get;
            set;
        }
        public string LogName
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public DateTime UpdatedDate
        {
            get;
            set;
        }
    }
}
