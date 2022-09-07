using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.SpaceMan
{
    public class ShelfList
    {
        public string storeNo { set; get; }
        public string shelfCode { set; get; }
        public string subCode { set; get; }
        public string shelfName { set; get; }
        public string img_root { set; get; } 
        public string imgID { set; get; }
        public string img_link { set; get; } = "/Content/images/bg-01.jpg";
        public string createdBy { set; get; }
        public string createdDate { set; get; }
        public string imgStatus { set; get; }
        public string imgStatusName { set; get; }
        public string Division { set; get; }
        public string Category { set; get; }
        public string Group_Name { set; get; }
        public string Function { set; get; }
        public string description { set; get; }
    }
}