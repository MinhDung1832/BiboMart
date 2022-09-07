using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ManageSales
{
    public class AddhisTDH
    {      
            public string MaHang { set; get; }
            public string TDHDeXuat { set; get; }
            public string PTTDH { set; get; }
            public string NgayBatDau { set; get; }
            public string NgayKetThuc { set; get; }
            public string TDHDuyet { set; get; }
            public string PTTDHDuyet { set; get; }
            public int type { set; get; }
            public int status { set; get; }

        }
    public class AddhisTDHAdj
    {
        public string MaHang { set; get; }
        public string TDHDeXuatAdj { set; get; }
        public string PTTDHAdj { set; get; }
        public string NgayBatDauAdj { set; get; }
        public string NgayKetThucAdj { set; get; }
        public string TDHDuyetAdj { set; get; }
        public string PTTDHDuyetAdj { set; get; }

    }

}