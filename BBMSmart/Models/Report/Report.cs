using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.Report
{
    public class Obj_BaoCaoKinhDoanh
    {
        public string Taget { set; get; }
        public string ThucDat { set; get; }
    }

    public class Obj_BaoCaoKinhDoanh_VanHanh
    {
        public string Target { set; get; }
        public string ThucDat { set; get; }
        public string PhanTramDat { set; get; }
        public string PhanTramThuong { set; get; }
    }
    public class Obj_BaoCaoKinhDoanh_TopVung
    {
        public string RSM_code { set; get; }
        public string ASM_code { set; get; }
        public string ThucDat { set; get; }
        public string DoanhSo { set; get; }
        public string SoLuong { set; get; }
        public string Thuong { set; get; }
    }
    public class Obj_BaoCaoKinhDoanh_TopKinhDoanhOnline
    {
        public string Target { set; get; }
        public string ThucDat { set; get; }
        public string PhanTramDat { set; get; }
        public string PhanTramThuong { set; get; }
    }

    public class Obj_BaoCaoKinhDoanh_TopSieuThi
    {
        public string store { set; get; }
        public string DoanhSo { set; get; }
        public string TangTruong { set; get; }
        public string Thuong { set; get; }
        public string SoLuong { set; get; }
    }
    public class Obj_BaoCaoKinhDoanh_TopKhuVuc
    {
        public string ASM { set; get; }
        public string DoanhSo { set; get; }
        public string TangTruong { set; get; }
        public string Thuong { set; get; }
        public string SoLuong { set; get; }
    }

    public class Obj_BaoCaoKinhDoanh_TopNhanVien
    {
        public string MaNV { set; get; }
        public string TanNV { set; get; }
        public string DoanhSo { set; get; }
        public string Thuong { set; get; }
        public string SoLuong { set; get; }
    }
}