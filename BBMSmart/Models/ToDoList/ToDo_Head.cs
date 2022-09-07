using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ToDoList
{
    public class ToDo_Head
    {
        public string requirementCode { set; get; }
        public string requirementName { set; get; }
        public string positionCode { set; get; }
        public string reqImg { set; get; }
        public string status { set; get; }
        public string createBy { set; get; }
        public string createDate { set; get; }
        public string points { set; get; }
    }
}