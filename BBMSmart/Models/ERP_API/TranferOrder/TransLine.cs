using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ERP_API.TranferOrder
{
    public class TransLine
    {
        public string Item_No { set; get; }
        public decimal Quantity { set; get; }
    }
}