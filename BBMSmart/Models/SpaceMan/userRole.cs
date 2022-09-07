using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.SpaceMan
{
    public class userRole
    {
        public string userID { set; get; }
        public string roleCode { set; get; }
        public string controlCode { set; get; }
        public string controlName { set; get; }
        public string create_act { set; get; }
        public string edit_act { set; get; }
        public string accept_act { set; get; }
        public string view_act { set; get; }
        public string root_act { set; get; }
        public string points_act { set; get; }
        public string Div { set; get; }
        public string source { set; get; }
    }
}