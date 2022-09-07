using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.comparePrice
{
    public class RP_Accept_Item
    {
        public string lineNo { set; get; }
        public string compareCode { set; get; }
        public string compareName { set; get; }
        public string sku { set; get; } = "";
        public string url { set; get; }
        public string name { set; get; }
        public string brand { set; get; }
        public string XepHang { set; get; }
        public string bb_price { set; get; }
        public string GiaMuaNet { set; get; }
        public string comparePrice { set; get; }
        public string compareLink { set; get; }
        public string subName { set; get; }
        public string modifyDate { set; get; }
        public string promo { set; get; }
        public string DivisionCode { set; get; } = "";
        public string DivisionName { set; get; }
        public string CategoryCode { set; get; } = "";
        public string CategoryName { set; get; }
        public string GroupCode { set; get; } = "";
        public string GroupName { set; get; }
        public string FunctionCode { set; get; } = "";
        public string FunctionName { set; get; }
        public string VendorNo { set; get; } = "";
        public string VendorName { set; get; }
        public string BrandCode { set; get; } = "";
        public string BrandName { set; get; }
        public int ActionId { set; get; }
        public int salesPrice { set; get; }
        public decimal GL_D { set; get; }
        public int accept_salesPrice { set; get; }
        public decimal GL_A { set; get; }
        public string CP_Name { set; get; }
        public int status_Acc { set; get; }
    }
}