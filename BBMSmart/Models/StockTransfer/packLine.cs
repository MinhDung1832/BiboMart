using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.StockTransfer
{
    public class packLine
    {
        public string headerCode { set; get; }
        public string itemNo { set; get; }
        public string itemName { set; get; }
        public int qtyPerPack { set; get; }
        public int totalQty { set; get; }
        public string Flag { set; get; }
        public string Type { set; get; }

    }
}