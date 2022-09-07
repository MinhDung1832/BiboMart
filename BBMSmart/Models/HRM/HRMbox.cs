using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.HRM
{

    public class HRMbox
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

    public class HRMbooking
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public string KhuVuc { set; get; }
    }

    public class HRMbookingAdd
    {
        public string RoomCode { set; get; }
        public string RoomName { set; get; }
        public string NoiDung { set; get; }
        public string ThanhPhan { set; get; }
        public string StartTime { set; get; }
        public string EndTime { set; get; }
    }

    public class backLink_DinhBien
    {
        public string CodeEmp { set; get; }
        public string E_SECTION { set; get; }
        public string E_SECTION_CODE { set; get; }
        public string Level { set; get; }
        public string backName { set; get; }
        public string backLink { set; get; }
        public int isDesktop { set; get; }
    }

    public class DinhBienPhanCaAddHis
    {
        public string store { set; get; }
        public string Ca1Chot { set; get; }
        public string Ca2Chot { set; get; }
        public string Ca3Chot { set; get; }
        public string Ngay { set; get; }
        public string ChucDanhTT { set; get; }
        public string NhanVien { set; get; }
        public string PhanCa { set; get; }
    }

    public class DinhBienPhanCaAddSupport
    {
        public string store_sp { set; get; }
        public string Ngay_sp { set; get; }
        public string Ca_sp { set; get; }
        public string ChucDanh_sp { set; get; }
        public string slthieu { set; get; }
    }

    public class DinhBienPhanCaAdd
    {
        public string store { set; get; }
        public string Ca1Chot { set; get; }
        public string Ca2Chot { set; get; }
        public string Ca3Chot { set; get; }
        public string QLSTca1 { set; get; }
        public string NVTNca1 { set; get; }
        public string NVTVca1 { set; get; }
        public string NVTDca1 { set; get; }
        public string QLSTca2 { set; get; }
        public string NVTNca2 { set; get; }
        public string NVTVca2 { set; get; }
        public string NVTDca2 { set; get; }
        public string QLSTca3 { set; get; }
    }

    public class DuyetInOutAdd
    {
        public string GioRaVaoThucTe { set; get; }
        public string LoaiCa { set; get; }
        public string LyDoTuChoi { set; get; }
        public string CodeEmp { set; get; }
        public string TimeLog { set; get; }
        public string type { set; get; }
        public string status { set; get; }

    }


}