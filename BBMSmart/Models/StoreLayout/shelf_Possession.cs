using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.StoreLayout
{
    public class shelf_Possession
    {
        public string shelfNo { set; get; }
        public string shelfName { set; get; }
        public decimal height { set; get; }
        public decimal width { set; get; }
        public decimal depth { set; get; }
        public int level { set; get; }
        public decimal P_height { set; get; }

    }
}