using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.StoreLayout
{
    public class scoreItem
    {
        public string id { set; get; }
        public string storeNo { set; get; }
        public string shelfNo { set; get; }

        public string shelfName { set; get; }
        public string catNo { set; get; }
        public string img_link { set; get; }
        public string createdBy { set; get; }
        public string createdDate { set; get; }
        public string acceptBy { set; get; }
        public string acceptDate { set; get; }
        public int points { set; get; }
        public string description { set; get; }
        public string pointBy { set; get; }
        public string pointDate { set; get; }

    }
}