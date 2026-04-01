using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLNoteMaster
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
        public int? CusID
        {
            get;
            set;
        }
        public string Note
        {
            get;
            set;
        }
        public int? UseOneTime
        {
            get;
            set;
        }
        public int? UseEveryTime
        {
            get;
            set;
        }
      
    }
}
