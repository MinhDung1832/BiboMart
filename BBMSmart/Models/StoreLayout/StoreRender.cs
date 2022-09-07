using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.StoreLayout
{
    public class StoreRender
    {
        public string id { set; get; }
        public string storeNo { set; get; }
        public string name { set; get; }
        public string linkImage { set; get; }
        public int status { set; get; }
        public string createdBy{set;get;}
        public string createdDate { set; get; }
        public string modifyBy { set; get; }
        public string modifyDate { set; get; }
    }
}