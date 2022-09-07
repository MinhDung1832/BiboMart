using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ERP_API.PurchaseOrder
{
    public class PurchaseOrder_Item
    {
        public string ERP_Account { set; get; }
        public string Buy_from_Vendor_No { set; get; }
        public string Location_Code { set; get; }
        public string Vendor_Order_No { set; get; }
        public string Store_No { set; get; }
        public string Expected_Receipt_Date { set; get; }
       // public List<PurchLines> PurchLine { set; get; } 
        public PurchLines[] PurchLines;
    }

    public class Purchase_Item_change
    {
        public string PoNo { set; get; } = "";
        public PurchLines[] PurchLines { set; get; }
    }

    public class Purchase_Item_removeoutstanding
    {
        public string PoNo { set; get; } = "";
        public string RemoveBy { set; get; }
    }
    public class obj_SourcePrice
    {
        public string ID { set; get; }
        public string sldat { set; get; }
        public string tt { set; get; }

    }

}