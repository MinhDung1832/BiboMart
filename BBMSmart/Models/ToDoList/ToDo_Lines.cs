using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ToDoList
{
    public class ToDo_Lines
    {
        public string requirementCode { set; get; }
        public string storeNo { set; get; }
        public string type { set; get; }
        public string imageSource { set; get; }
        public string description { set; get; }
        public string status { set; get; }
        public string createBy { set; get; }
        public string createDate { set; get; }
    }
}