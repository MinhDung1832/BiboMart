using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ManageSales
{
    public class filterMarcom
    {
        public string BrandCode { set; get; }
        public string BrandName { set; get; }
        public string FunctionCode { set; get; }
        public string FunctionName { set; get; }
        public string MaCH { set; get; }
        public string TenCH { set; get; }
        public string MaTinh { set; get; }
        public string TenTinh { set; get; }
        public string NhomKH { set; get; }

    }

    public class filterMarcomProvinStore
    {
        public string MaCH { set; get; }
        public string TenCH { set; get; }
        public string MaTinh { set; get; }
        public string TenTinh { set; get; }
        public string NhomKH { set; get; }

    }
}