using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.StockTransfer
{


    public class GoodsTransferItem
    {
        public string StoreRecieve { set; get; }
        public string StoreName { set; get; }
        public decimal Quantity { set; get; }
        public decimal M3 { set; get; }
        public string Flag { set; get; }
    }

    public class StockItem
    {
        public string transFromCode { set; get; }
        public string transFromName { set; get; }
        public string transToCode { set; get; }
        public string transToName { set; get; }
        public string transTypeCode { set; get; }
        public string transTypeName { set; get; }
        public string groupCode { set; get; }
        public string groupName { set; get; }
        public string itemCode { set; get; }
        public string itemName { set; get; }
        public decimal volume { set; get; } = 0;
        public int quantityRequired { set; get; }
        public int qtyPerPack { set; get; } = 0;
        public int totalQtyPerPack {set; get;}
        public bool isOn { set; get; } = false;
        public decimal Transferfee { set; get; }
        public string RequestDate { set; get; }
        public string Flag { set; get; }
        public string Type { set; get; }
        public decimal Amount { set; get; }
    }

    public class objTongHopDC
    {
        public string transFromCode { set; get; }
        public string transFromName { set; get; }
        public string transToCode { set; get; }
        public string transToName { set; get; }
        public string transTypeCode { set; get; }
        public string transTypeName { set; get; }
        public string groupCode { set; get; }
        public string groupName { set; get; }
        public string itemCode { set; get; }
        public string itemName { set; get; }
        public decimal volume { set; get; } = 0;
        public int quantityRequired { set; get; } = 0;
        public int qtyPerPack { set; get; } = 0;
        public bool isOn { set; get; } = false;
    }
}