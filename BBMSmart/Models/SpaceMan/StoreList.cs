using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.SpaceMan
{
    public class StoreList
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public string provinceCode { set; get; }
        public string provinceName { set; get; }
        public string total_Shelf { set; get; }
        public int totalFloor { set; get; }
    }
}