using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.StockTransfer
{
    public class ItemKBLoiHong
    {
        public string MaCH { set; get; }
        public string TenCH { set; get; }
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string TinhTrang { set; get; }
        public string NgaySX { set; get; }
        public string NgayHetHan { set; get; }
        public string NgayBaoDate { set; get; }
        public string HanSD { set; get; }
        public string TemPhu { set; get; }
        public string SoLuong { set; get; }
        public string Themelink { set; get; }
        public string MoTa { set; get; }
        public string CreatedDate { set; get; }     
    }

    public class FillterItem
    {
        public string barcode { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public string ThongTinTemPhu { set; get; }
        public string NBD { set; get; }
        public int quantityRequired { set; get; }
        public decimal volume { set; get; }

    }
    public class Fillter
    {
        public string functionCode { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }      

    }
}