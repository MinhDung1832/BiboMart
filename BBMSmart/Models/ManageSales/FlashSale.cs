using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ManageSales
{
    public class CampaignFlashSale
    {
        public string SourceHeader { set; get; }
        public string SourceLine { set; get; }
    }
    public class CampaignFlashSale_Header
    {
        public string ID { set; get; }
        public string MaChienDich { set; get; }
        public string TenChienDich { set; get; }
        public string TrangThai { set; get; }
        public string TuNgay { set; get; }
        public string TimeHourTuNgay { set; get; }
        public string DenNgay { set; get; }
        public string TimeHourDenNgay { set; get; }
        public string CreateBy { set; get; }
        public string CreateDate { set; get; }
        public string ModifyBy { set; get; }
        public string ModifyDate { set; get; }
        public string StatusDuyet { set; get; }

    }
    public class CampaignFlashSale_Line
    {
        public string ID { set; get; }
        public string MaChienDich { set; get; }
        public string ItemNo { set; get; }
        public string NamePro { set; get; }
        public string Price { set; get; }
        public string Images { set; get; }
        public string PriceFlashSale { set; get; }
        public string SLFlashSale { set; get; }
        public string SLBan { set; get; }
        public string SLBanChayHang { set; get; }
        public string SLBaThucTe { set; get; }
        public string TrangThai { set; get; }
        public string CreateBy { set; get; }
        public string CreateDate { set; get; }
        public string ModifyBy { set; get; }
        public string ModifyDate { set; get; }

    }
    public class objFlashSale
    {
        public string arrItem { get; set; }

    }
    public class API_Produtcs
    {
        public string item { get; set; }
        public string store { get; set; }
    }
    public class CampaignFlashSale_ERP
    {
        public List<API_Produtcs> ListItemStores { get; set; }
        public string Type { get; set; }
    }



}