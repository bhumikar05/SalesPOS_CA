using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLChatMaster
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
        public int? SenderID
        {
            get;
            set;
        }
        public int? ReceiverID
        {
            get;
            set;
        }
        public String Message
        {
            get;
            set;
        }
        public DateTime Date
        {
            get;
            set;
        }
        public string Time
        {
            get;
            set;
        }
        public DateTime CreatedTime
        {
            get;
            set;
        }
        public int? CreatedID
        {
            get;
            set;
        }
        public int? IsRead
        {
            get;
            set;
        }
        public int? GroupMessage
        {
            get;
            set;
        }
    }
}
