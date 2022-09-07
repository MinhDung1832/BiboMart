using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ManageUse
{
    public class Premission
    {
            public string fname_L1 { set; get; }
            public string fname { set; get; }
            public string paname { set; get; }
            public int flevel { set; get; }
            public string parentcode { set; get; }
            public string action { set; get; }
            public string controller { set; get; }
            public int vcount { set; get; } = 0;
            public string reportpath { set; get; }
            public string menu { set; get; }
            public string Code { set; get; }
            public string EN_Name { set; get; }
            public string MenuCode { set; get; }
        

    }
}