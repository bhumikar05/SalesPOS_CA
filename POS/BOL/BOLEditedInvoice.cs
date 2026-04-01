using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    public class BOLEditedInvoice
    {
        public string MODE
        {
            get; set;
        }
        public int? ID
        {
            get; set;
        }
        public int? UserID
        {
            get; set;
        }
        public int? InvoiceID
        {
            get; set;
        }
        public DateTime? Date
        {
            get; set;
        }
        public int? Showing
        {
            get; set;
        }
        public decimal? OldTotal
        {
            get; set;
        }
        public decimal? NewTotal
        {
            get; set;
        }
    }
}
