using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ScoreStore
{
    public class ScoreStoreHeader
    {
        public string departmentCode { set; get; }
        public string departmentName { set; get; }
        public string requirementCode { set; get; }
        public string requirementName { set; get; }
        public string reqImg { set; get; }
        public string points { set; get; }
        public int status { set; get; } = 0;

    }
}