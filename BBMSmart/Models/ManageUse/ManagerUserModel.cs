using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ManageUser
{
    public class sys_list_user_function
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
        public int ischeck { set; get; }

    }

    public class ManagerUserModel
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
        public string Name { set; get; }


    }

    public class Permission
    {
        public string userid { set; get; }
        public string FunctionCode { set; get; }
        public int ischeck { set; get; }

    }

    public class StoreItem
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public string MaVung { set; get; }
        public string TenVung { set; get; }
        public string MaTinh { set; get; }
        public string TenTinh { set; get; }
    }

    public class BiboSmartMenu
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public int MenuCode { set; get; }
    }
    public class sys_list_user_function_NCC
    {
        public string PhongBan { set; get; }
        public string ChucNang { set; get; }
        public string MaChucNang { set; get; }
        public string flevel { set; get; }
        public string orderby { set; get; }
        public string parentcode { set; get; }
        public string action { set; get; }
        public string controller { set; get; }
        public string NguoiCapNhat { set; get; }
        public string NgayCapNhat { set; get; }
        public string isCheck { set; get; }
        public string fcode { set; get; }
        public string fPhongBan { set; get; }
    }
}
