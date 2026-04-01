using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLAccount
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
        public string FullName
        {
            get;
            set;
        }
        public int? IsActive
        {
            get;
            set;
        }
        public string AccountType
        {
            get;
            set;
        }
        public int? ParentID
        {
            get;
            set;
        }
    }
}
