using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ERP_API.SalesOrder
{
    public class SalesLine
    {
        public string item_No { set; get; }
        public decimal quantity { set; get; }
    }
}