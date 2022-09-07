using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ManageUse
{
    public class MainItem
    {
        public string E_DIVISION_CODE { set; get; } // khoi
        public string E_DEPARTMENT_CODE { set; get; } //phong ban
        public string E_DIVISION { set; get; } // khoi
        public string E_DEPARTMENT { set; get; } //phong ban
        public string paname { set; get; } // 
        public string MaVung { set; get; } //vung
        public string MaTinh { set; get; } //khu vuc
        public string storeNo { set; get; } //CH
        public string CodeEmp { set; get; } //ma NV
        public string PositionName { set; get; } // chức danh
        public string fcode { set; get; } // ma CN
        public string fname { set; get; } //ten CN
        public string parentcode { set; get; } //ma du an
        public string createdate { set; get; } //ngày phân quyền
        public string createby { set; get; } //người phân quyền 
        public int flevel { set; get; }
        public int vcount { set; get; } = 0;
        public string reportpath { set; get; }
        public string menu { set; get; }
        public string fname_L1 { set; get; }
        public string ProfileName { set; get; }
        public string modifydate { set; get; }
        public string modifyby { set; get; }
        public string fChildCode { set; get; } 

    }
}