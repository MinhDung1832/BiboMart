using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ManageSales
{
    public class objItemDC
    {
        public string StoreDC { set; get; }
        public string MaHang { set; get; }
        public string StoreReceiveCode { set; get; }
    }

    public class ItemTraHangNCC
    {
        public string StoreCode { set; get; }
        public string MaHang { set; get; }
        public string VendorNo { set; get; }
        public string SoLuong { set; get; }
        public string Flag { set; get; }
        public string ResID { set; get; }
    }

}