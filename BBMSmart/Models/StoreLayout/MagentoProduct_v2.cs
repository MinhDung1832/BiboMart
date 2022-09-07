using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.StoreLayout
{
    public class MagentoProduct_v2
    {
        public string id { set; get; }
        public string sku { set; get; }
        public string catID { set; get; }
        public string name { set; get; }
        public string price { set; get; }
        public string image_link { set; get; }
        public decimal height { set; get; }
        public decimal width { set; get; }
        public int z_index { set; get; }
        public decimal display { set; get; }
        public int qty { set; get; }
    }
}