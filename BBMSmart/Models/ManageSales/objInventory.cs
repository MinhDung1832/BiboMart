using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ManageSales
{
    public class objInventory
    {
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string MaCH { set; get; }
        public string TenCH { set; get; }
        public decimal DSD30 { set; get; }
        public decimal PS { set; get; }
        public decimal SLTon { set; get; }
        public int SoNgayOOS { set; get; }
        public string SaleLost { set; get; }
        public decimal SaleLost_N { set; get; }
    }
}