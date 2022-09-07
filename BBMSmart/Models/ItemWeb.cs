using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models
{
    public class ItemWeb
    {
        public string sku { set; get; }
        public string name { set; get; }
        public string price { set; get; }
        public string url { set; get; }
        public string image_link { set; get; }
        public string ManufacturerCode { set; get; }
        public string DivisionCode { set; get; }
        public string CategoryCode { set; get; }
        public string GroupCode { set; get; }
    }
}