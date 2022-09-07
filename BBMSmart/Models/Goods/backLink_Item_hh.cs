using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.Goods
{
    public class backLink_Item_hh
    {
        public string CodeEmp { set; get; }
        public string E_SECTION { set; get; }
        public string E_SECTION_CODE { set; get; }
        public string Level { set; get; }
        public string backName { set; get; }
        public string backLink { set; get; }
        public int isMobile { set; get; }
    }

    public class TOSOitem
    {
        public int RecordID { set; get; }
        public string DocumentNo { set; get; }
        public string ItemNo { set; get; }
        public decimal QuantityTT { set; get; }
        public string Remark { set; get; }
        public string CameraLink { set; get; }
        public string Status { set; get; }
        public string Note { set; get; }
        public string TransferfromCode { set; get; }
        public string TransfertoCode { set; get; }
        public decimal QuantityShipped { set; get; }
        public string ShipmentDate { set; get; }
    }
}