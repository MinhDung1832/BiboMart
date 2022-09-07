using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.comparePrice
{
    public class compareAction
    {
        public int id { set; get; } = 0;
        public string sku { set; get; }
        public string compare_LineID { set; get; }
        public string corePrice { set; get; }
        public string salesPrice { set; get; }
    }
}