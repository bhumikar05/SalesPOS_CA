using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace POS.BOL
{
    class BOLAccessUPSSettings
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
        public int? NegotiatedRate
        {
            get;
            set;
        }
        public int? DeliveryConfirmation
        {
            get;
            set;
        }
        public int? COD
        {
            get;
            set;
        }
        public int? OtherService
        {
            get;
            set;
        }
        public string PrinterName
        {
            get;
            set;
        }
        public string Copies
        {
            get;
            set;
        }
        public string Landscape
        {
            get;
            set;
        }
        public string Margins
        {
            get;
            set;
        }
        public string PaperSize
        {
            get;
            set;
        }
        public string PaperSource
        {
            get;
            set;
        }
        public string PrinterResolution
        {
            get;
            set;
        }
    }
}
