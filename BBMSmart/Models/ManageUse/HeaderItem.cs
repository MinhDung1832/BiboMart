using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ManageUse
{
    public class HeaderItem
    {
        public string E_DIVISION_CODE { set; get; } //khối
        public string E_DIVISION { set; get; } // tên khối
        public string E_DEPARTMENT_CODE { set; get; } // phòng ban
        public string E_DEPARTMENT { set; get; } // tên phòng ban
        public string fcode { set; get; } // mã du an
        public string fname { set; get; } //ten dự án
        public string CodeEmp { set; get; } // mã nv
        public string ProfileName { set; get; } //tên nv
        public string PositionName { set; get; } // chuc danh
        public string parentcode { set; get; } //cn cha
        public string paname { set; get; } // 
        public string createDate { set; get; } 
        public string createBy { set; get; }    
        public int flevel { set; get; }
        public int vcount { set; get; } = 0;
        public string reportpath { set; get; }
        public string menu { set; get; }
        public string Code { set; get; }

    }
}