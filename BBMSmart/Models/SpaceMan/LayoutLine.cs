using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.SpaceMan
{
    public class LayoutLine
    {
        public string id { set; get; }
        public string storeNo { set; get; }
        public string type { set; get; }
        public string subType { set; get; } = "";
        public string floorNo { set; get; }
        public string typeCode { set; get; } = "";
        public string imgLink { set; get; } = "/Image/no-image.jpg";
        public string status { set; get; }
        public string description { set; get; }
        public string createdDate { set; get; }
        public string createdBy { set; get; }
        public string modifyDate { set; get; }
        public string modifyBy { set; get; }
    }
}