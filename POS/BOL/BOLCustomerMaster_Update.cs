using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLCustomerMaster_Update
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int? EditCount { get; set; }
        public string OldCustomerName { get; set; } 
        public string NewCustomerName { get; set; } 
        public string OldFullName { get; set; } 
        public string NewFullName { get; set; } 
        public string OldSalutation { get; set; }
        public string NewSalutation { get; set; } 
        public string OldFirstName { get; set; }
        public string NewFirstName { get; set; } 
        public string OldMiddleName { get; set; }
        public string NewMiddleName { get; set; } 
        public string OldLastName { get; set; } 
        public string NewLastName { get; set; } 
        public string UpdateDate { get; set; } 
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
