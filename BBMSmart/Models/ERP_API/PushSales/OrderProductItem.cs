using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ERP_API.PushSales
{
    public class OrderProductItem
    {
        public string No { set; get; }
        public int Quantity { set; get; }
        public string Unit_Price { set; get; }
        public string Line_Discount_Percent { set; get; }
    }
}
