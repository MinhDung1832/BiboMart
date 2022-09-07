using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ERP_API
{
    public class packToERP_Item
    {
        public string transFrom { set; get; }
        public string From_PostCode { set; get; }
        public string transTo { set; get; }
        public string To_PostCode { set; get; }
        public string itemNo { set; get; }
        public int total { set; get; }
    }
}