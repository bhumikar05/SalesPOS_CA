using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLInvoiceDetailsLog
    {
        public int ID { get; set; }
        public int InvoiceID { get; set; }
        //Details

        public int MasterLogID { get; set; }
        public string EditMode { get; set; }
        public string ItemID { get; set; }
        public string OldItemID { get; set; }
        public string Description { get; set; }
        public string OldDescription { get; set; }
        public string Qty { get; set; }
        public string OldQty { get; set; }
        public string PriceEach { get; set; }
        public string OldPriceEach { get; set; }
        public string Amount { get; set; }
        public string OldAmount { get; set; }

    }
}
