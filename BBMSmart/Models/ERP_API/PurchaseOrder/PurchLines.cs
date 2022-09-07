using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ERP_API.PurchaseOrder
{
    public class PurchLines
    {
        public string ItemNo { set; get; }
        public decimal Quantity { set; get; }
        public string Unit_of_Measure_Code { set; get; }
        public decimal Direct_Unit_Cost { set; get; }
        public decimal Line_Discount_Percent { set; get; }
    }
}
