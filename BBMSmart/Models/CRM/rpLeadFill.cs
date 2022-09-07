using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.CRM
{
    public class rpLeadFill
    {
        public string Resource { set; get; }
        public string Phone { set; get; }
        public string Province { set; get; }
        public string Suggestion { set; get; }
        public string fromDate { set; get; }
        public string toDate { set; get; }
        public int isReceived { set; get; }
        public int isUsed { set; get; }
        public int isAppNoti { set; get; }
        public int isEmail { set; get; }
        public int isSMS { set; get; }
    }
}