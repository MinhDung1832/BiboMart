using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ERP_API.Member
{
    public class MemberItem
    {
        public string Name { set; get; }
        public string Phone_No { set; get; }
        public string Address { set; get; } = "";
        public string Address_2 { set; get; } = "";
        public string Post_Code { set; get; } = "";
        public string City { set; get; } = "";
        public string District { set; get; } = "";
        public string Ward { set; get; } = "";
        public string E_Mail { set; get; }
        public int Gender { set; get; } = 0;
        public string Date_of_Birth { set; get; }

        public string Child_1_Name { set; get; } = "";
        public string Child_1_Year { set; get; }
        public int Child_1_Gender { set; get; } = 0;

        public string Child_2_Name { set; get; } = "";
        public string Child_2_Year { set; get; }
        public int Child_2_Gender { set; get; } = 0;

        public string Child_3_Name { set; get; } = "";
        public string Child_3_Year { set; get; }
        public int Child_3_Gender { set; get; } = 0;

        public string Child_4_Name { set; get; } = "";
        public string Child_4_Year { set; get; }
        public int Child_4_Gender { set; get; } = 0;
    }
}
