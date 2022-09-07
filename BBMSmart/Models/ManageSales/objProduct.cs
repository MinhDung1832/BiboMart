using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ManageSales
{
    public class objProduct
    {
        public string itemNo { set; get; }
        public string storeNo { set; get; }
    }
    public class SumManageSales
    {
        public decimal salesTangKHMoi { set; get; }
        public decimal salesLostLoyalty { set; get; }
        public decimal salesLostOSS { set; get; }
    }
}