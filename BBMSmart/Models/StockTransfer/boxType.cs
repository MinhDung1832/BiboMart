
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.StockTransfer
{
    public class boxType:FillterItem
    {
        public int Length { set; get; }
        public int Width { set; get; }
        public int Depth { set; get; }
        public string BarcodeNo { set; get; }
    }
}