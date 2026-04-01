using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    public class BOLCustomerLogHideColumn
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

        public int? UserID
        {
            get;
            set;
        }

        public int? NewCustomerName
        {
            get;
            set;
        }
        public int? OldCustomerName
        {
            get;
            set;
        }
        public int? NewSalutation
        {
            get;
            set;
        }
        public int? OldSalutation
        {
            get;
            set;
        }
        public int? NewFirstName
        {
            get;
            set;
        }
        public int? OldFirstName
        {
            get;
            set;
        }
        public int? NewMiddleName
        {
            get;
            set;
        }
        public int? OldMiddleName
        {
            get;
            set;
        }
        public int? NewLastName
        {
            get;
            set;
        }
        public int? OldLastName
        {
            get;
            set;
        }
        public int? EditCount
        {
            get;
            set;
        }
        public int? UpdateDate
        {
            get;
            set;
        }
    }
}
