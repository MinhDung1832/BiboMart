using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.Po2
{
    public class ArAutoAdd
    {
        public string khochiacode { get; set; }
        public string khochianame { get; set; }
        public string vendorcode { get; set; }
        public string vendorname { get; set; }
        public string brand { get; set; }
        public string chtsf { get; set; }
        public string mien { get; set; }
        public string tinh { get; set; }
        public string storecode { get; set; }
        public string storename { get; set; }
        public string itemcode { get; set; }
        public string itemname { get; set; }
        public string pserp { get; set; }
        public string dserp { get; set; }
        public string minpsf { get; set; }
        public string slton { get; set; }
        public string slband30 { get; set; }
        public string stockday { get; set; }
        public string slgoiy { get; set; }
        public string sldexuat { get; set; }
        public string RNtopsalefunct { get; set; }
        
    }
    public class ArAutoAccept
    {
     
        public string ID { get; set; }
        public string slduyet { get; set; }

    }
    public class AddLyDo {
        public int ID { get; set; }
        public string LyDo { get; set; }
    }
    public class UpdateLyDo {
        public int ID { get; set; }
        public string LyDo { get; set; }
    }
}