using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.StoreLayout
{
    public class storeShelf_v2
    {
        public string id { set; get; }
        public string storeNo { set; get; }
        public string shelfNo { set; get; }
        public string shelfName { set; get; }
        public string divCode { set; get; }
        public string catCode { set; get; }
        public string groupCode { set; get; }
        public string brandCode { set; get; }
        public string functionCode { set; get; }
        public string img_id { set; get; }
        public string render_list { set; get; }
        public string img_link { set; get; }
        public string createdDate { set; get; }
        public string createdBy { set; get; }
        public string modifyDate { set; get; }
        public string modifyBy { set; get; }
    }
}