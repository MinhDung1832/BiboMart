using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ERP_API.Marcom
{
    public class ObjAppNotify
    {
        public string title { set; get; }
        public string description { set; get; }
        public string published { set; get; }
        public string cover { set; get; }
        public string type { set; get; }
        public string receivers { set; get; }
        public string kind { set; get; }
        public string content { set; get; }
        public string specialTime { set; get; }

    }
    public class ObjSMS
    {
        public string to { set; get; }
        public int type { set; get; } //CSKH
        public string from { get; } = "BIBOMART";
        public string scheduled { set; get; } = "";
        public string message { set; get; }

    }
    public class ObjSMS_KM
    {
        public string[] to { set; get; }
        public int type { set; get; } = 2; //KM
        public string from { get; } = "BIBOMART";
        public string scheduled { set; get; } = "";
        public string message { set; get; }

    }
}