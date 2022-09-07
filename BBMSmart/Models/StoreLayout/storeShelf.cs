using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.StoreLayout
{
    public class storeShelf
    {
        public int id { set; get; }
        public string storeNo { set; get; }
        public string shelfNo { set; get; }
        public string sub_id { set; get; }
        public string shelfName { set; get; }
        public string catNo { set; get; } = "";
        public string catName { set; get; }
        public string img_link { set; get; }
        public int status { set; get; }
        public string createdBy { set; get; }
        public string modifyBy { set; get; }
        public string createdDate { set; get; }
        public string modifyDate { set; get; }
        public string comment { set; get; }
    }
}