using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.SpaceMan
{
    public class RateNew
    {
        public string storeNo { set; get; }
        public string provinceCode { set; get; }
        public int total_new { set; get; }
        public int total_accept { set; get; }
        public decimal rate { set; get; }
    }
}