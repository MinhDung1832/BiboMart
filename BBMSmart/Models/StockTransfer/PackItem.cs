using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.StockTransfer
{
    public class ReportTransfer
    {
        public string StoreTo { get; set; } = "";
        public string StoreFrom { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class StockTransferPackItem
    {
        public string Code { get; set; }
        public string transFrom { get; set; }
        public string transTo { get; set; }
        public string createdBy { get; set; }
        public string itemNo { get; set; }
        public int qtyPerPack { get; set; }
        public decimal Price { get; set; }
        public string flag { get; set; }
    }

    public class bonus
    {
        public decimal Amount { get; set; }
    }
    public class PackItem
    {
        public string Code { set; get; } = "";
        public string transFrom { set; get; }
        public string transFromName { set; get; }
        public string transFrom_Router { set; get; }
        public string transFrom_stt { set; get; }
        public string transTo { set; get; }
        public string transToName { set; get; }
        public string transTo_Router { set; get; }
        public string transTo_stt { set; get; }
        public string warehouse { set; get; }
        public string transType { set; get; }
        public string transTypeName { set; get; }
        public string Group { set; get; }
        public decimal weight { set; get; }
        public string boxType { set; get; } = "";
        public int boxQuantity { set; get; }
        public int boxLength { set; get; }
        public int boxWidth { set; get; }
        public int boxDepth { set; get; }
        public decimal volume { set; get; }
        public string createdBy { set; get; }
        public string createdDate { set; get; }
        public string transBy { set; get; }
        public string transDate { set; get; }
        public string receiverBy { set; get; }
        public string receiverDate { set; get; }
        public bool isOn { set; get; } = false;
        public string assignFor { set; get; } = "";
        public int status { set; get; }
        public string StatusERP { set; get; }
    }

    public class PackItemBarcode
    {
        public string Code { set; get; } = "";
        public string transFrom { set; get; }    
    }

    public class DeclareStatusGoodsinfo
    {
        public int ID { set; get; }
        public string BarCode { set; get; }
        public string MaCH { set; get; }
        public string TenCH { set; get; }
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string TinhTrang { set; get; }
        public string NgaySX { set; get; }
        public string NgayHetHan { set; get; }       
        public string HanSD { set; get; }
        public string NgayBaoDate { set; get; }
        public string SoLuong { set; get; }
        public string TemPhu { set; get; }
        public string Mota { set; get; }
        public string Themelink { set; get; }
        public int status { set; get; }
        public string ModifyDate { set; get; }
        public string ModifyBy { set; get; }

    }

    public class HisDeclareStatusGoodsinfo
    {
        public string TenHang { set; get; }
        public string TinhTrang { set; get; }
        public string SoLuong { set; get; }
        public string Mota { set; get; }
        public string ModifyDate { set; get; }
    }
}