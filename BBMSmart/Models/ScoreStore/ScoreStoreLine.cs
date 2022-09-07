using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ScoreStore
{
    public class ScoreStoreLine
    {
        public string requirementCode { set; get; }
        public string storeNo { set; get; }
        public int type { set; get; }
        public string imageSource { set; get; }
        public string description { set; get; }
    }
}