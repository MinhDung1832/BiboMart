using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.StoreLayout
{
    public class MagentoCategory
    {
        public string id { set; get; }
        public int level { set; get; }
        public string parent_id { set; get; }
        public string name { set; get; }
        public string patch { set; get; }
        public int product_count { set; get; }

    }
}