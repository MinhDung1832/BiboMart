using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.StoreLayout
{
    public class MagentoProduct
    {
        public string id { set; get; }
        public string sku { set; get; }
        public string catID { set; get; }
        public string name { set; get; }
        public string price { set; get; }
        public string image_link { set; get; }
    }
}