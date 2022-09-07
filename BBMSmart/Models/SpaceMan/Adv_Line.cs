using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.SpaceMan
{
    public class Adv_Line
    {
        public string id { set; get; }
        public string storeNo { set; get; }
        public string headerId { set; get; }
        public string headerName { set; get; }
        public string imgLink { set; get; }
        public string description { set; get; }
        public string status { set; get; }
        public string createdBy { set; get; }
        public string createdDate { set; get; }
        public string modifyBy { set; get; }
        public string modifyDate { set; get; }

    }
}