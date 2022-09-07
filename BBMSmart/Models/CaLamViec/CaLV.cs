using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.CaLamViec
{
    public class CaLV
    {
        public int ID { get; set; }
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string ChucDanh { get; set; }
        public string MaPB { get; set; }
        public string TenPB { get; set; }
        public string BoPhan { get; set; }
        public string LoaiCa { get; set; }
        public string Ca { get; set; }
        public string NoiLam { get; set; }
        public string Ngay { get; set; }
        public string MaCH { get; set; }
        public string TenCH { get; set; }
        public string NhanCa { get; set; }
        public string DoiCa { get; set; }
        public string Loai { get; set; }
        public string LoaiNghi { get; set; }
        public string LyDoNghi { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        public string LoaiCong { get; set; }
        public string SoGioNghi { get; set; }
        public string TrangThai { get; set; }

        public static implicit operator List<object>(CaLV v)
        {
            throw new NotImplementedException();
        }
    }
    public class AddNC
    {
        public string Ca { get; set; }
        public string type { get; set; }
    }
    public class SetDaDuyet
    {
        public string TenNV { get; set; }
    }
}