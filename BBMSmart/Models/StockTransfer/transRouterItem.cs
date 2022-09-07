using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.StockTransfer
{
    public class transRouterItem
    {
        public string transFrom { set; get; }
        public string transTo { set; get; }
        public string transToName { set; get; }
        public string codeRouter { set; get; }
        public string transRouter { set; get; }
        public string level { set; get; }
    }
}