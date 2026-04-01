using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BOL
{
    class BOLEmailTemplate
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
        public string TemplateType
        {
            get;
            set;
        }
        public string TemplateName
        {
            get;
            set;
        }
        public string Body
        {
            get;
            set;
        }
        public string Subject
        {
            get;
            set;
        }
    }
}
