using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ERP_API.PushSales
{
    public class TransferOrder
    {
        public List<TransferLine> TransferLines { get; set; }
        public string ERP_Account { get; set; }
        public string Transfer_from_Code { get; set; }
        public string Transfer_to_Code { get; set; }
    }

    public class TransferLine
    {
        public string Item_No { get; set; }
        public int Quantity { get; set; }
    }

    public class StockOrder
    {
        public string Location_Code { set; get; }
        public string Ship_to_Code { set; get; }
        public List<SalesLines> SalesLines;
    }

    public class SalesLines
    {
        public string No { set; get; }
        public int Quantity { set; get; }
    }

    public class ItemBarcode
    {
        public string Item_No { set; get; }
        public string Store_No { set; get; }
        public string Barcode_No { set; get; }
        //public bool Show_for_Item { set; get; } //false
        public string Unit_of_Measure_Code { set; get; } // đơn vị
        public string Variant_Code { set; get; }
        public string Description { set; get; }
        //public DateTime Last_Date_Modified { set; get; }
        public string Discount_Percent { set; get; }
    }

    public class objBonus
    {
        public string emp_code { set; get; }
        public string date { set; get; }
        public string doc_no { set; get; }
        public string work_order_no { set; get; }
        public string bonus { set; get; }
        public string bonus_desc { set; get; }
        public string bonus_type_code { set; get; }
        public string bonus_type_name { set; get; }
        public string state { set; get; }
        public string status { set; get; }
        public string source { set; get; }
        public string descr { set; get; }
        public string create_by { set; get; }
        public string modify_by { set; get; }
    }

    public class PushSalesOrder_Item
    {
        public string Receipt_No { set; get; }
        public string Sell_to_Customer_No { set; get; }
        public string Member_Card_No { set; get; }
        public string Customer_Phone { set; get; }
        public string Customer_Name { set; get; } = "";
        public int Status { set; get; }
        public string Region { set; get; }
        public string Location_Code { set; get; }
        public string Sales_Type { set; get; }
        public string Delivery_Comments { set; get; }
        public string Sell_to_Address { set; get; }
        public string Sell_to_Address_2 { set; get; }
        public string Ship_To_Telephone { set; get; }
        public string Payment_Method { set; get; } = "";
        //public SalesLines[] SalesLines;
        public List<OrderProductItem> SalesLines { set; get; }
    }
}