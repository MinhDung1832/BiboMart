using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.StoreLayout
{
    public class userRole
    {
        public string userID { set; get; }
        public string roleCode { set; get; }
        public string roleName { set; get; }
        public string storeNo { set; get; }
        public string storeName { set; get; }
        public int countShelf { set; get; }
        public string controlCode { set; get; }
        public int view_act { set; get; }
        public int create_act { set; get; }
        public int edit_act { set; get; }
        public int accept_act { set; get; }
        public int points_act { set; get; }
    }
}