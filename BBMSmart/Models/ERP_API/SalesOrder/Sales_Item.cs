using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ERP_API.SalesOrder
{
    public class Sales_Item
    {
        public string locationCode { set; get; }
        public string shipToCode { set; get; }
        public List<SalesLine> salesLines { set; get; }
    }
}