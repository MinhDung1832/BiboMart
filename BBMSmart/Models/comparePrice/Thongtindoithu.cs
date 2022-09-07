using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.Thongtindoithu
{
    public class Thongtindoithu
    {
        public string ID { set; get; }
        public string Cuahang_BBM_Code { set; get; }
        public string Cuahang_BBM_Name { set; get; }
        public string Mohinh_doithu_Code { set; get; }
        public string Mohinh_doithu_Name { set; get; }
        public string Ten_doithu_Code { set; get; }
        public string Ten_doithu_Name { set; get; }
        public string CH_doithu { set; get; }
        public string Phuong_Xa_Code { set; get; }
        public string Quan_Huyen_Code { set; get; }
        public string Tinh_Thanhpho_Code { set; get; }
        public string Phuong_Xa_Name { set; get; }
        public string Quan_Huyen_Name { set; get; }
        public string Tinh_Thanhpho_Name { set; get; }
        public string Thutu_canhtranh { set; get; }
        public string Lydo_sapxep { set; get; }
        public string Khoangcach { set; get; }
        public string Chieurong { set; get; }
        public string ASM_Code { set; get; }
        public string ASM_Name { set; get; }
        public string Dientich_KD { set; get; }
        public string Sotang_KD { set; get; }
        public string DS_dukien { set; get; }
        public string Chinhsach_CSKH { set; get; }
        public string Danhgia_DVKH { set; get; }
        public string Lydo_DVKH { set; get; }
        public string Danhgia_Trainghiem { set; get; }
        public string Lydo_Trainghiem { set; get; }
        public string Danhgia_Hanghoa { set; get; }
        public string Lydo_Hanghoa { set; get; }
        public string Anh1 { set; get; }
        public string Anh2 { set; get; }
        public string Anh3 { set; get; }
        public string Anh4 { set; get; }
        public string Anh5 { set; get; }
        public string Anh6 { set; get; }
        public string Anh7 { set; get; }
        public string Status { set; get; }
        public string CreateBy { set; get; }
        public string CreateDate { set; get; }
        public string ModifyBy { set; get; }
        public string ModifyDate { set; get; }
    }

    public class addthongtindoithu
    {
        public string userid { set; get; }
        public string MaCH { set; get; }
        public string TenCH { set; get; }
        public string DoiThu_Code { set; get; }
        public string DoiThu_Name { set; get; }
        public string Mien { set; get; }
        public string Tinh { set; get; }
        public string Quan { set; get; }
        public string Phuong { set; get; }
        public string DiaChi { set; get; }
        public string DienTichKD { set; get; }
        public string MatTien { set; get; }
        public string ViTri { set; get; }
        public string DoPhuThiTruong { set; get; }
        public string DoPhuThiTruongName { set; get; }
        public string NganhHangKD { set; get; }
        public string NganhHangKDName { set; get; }
        public string NhanHangKD { set; get; }
        public string NhanHangKDName { set; get; }
        public string AnhMatTien { set; get; }
        public string AnhChieuDi { set; get; }
        public string AnhChieuVe { set; get; }
        public string AnhBenTrong { set; get; }
        public string Status { set; get; }
        public string CreateBy { set; get; }
        public string CreateDate { set; get; }


    }
    public class DanhSachDoiThu
    {

        public string MoHinhKD { set; get; }
        public string MoHinhKDName { set; get; }
        public string MaDoiThu { set; get; }
        public string TenDoiThu { set; get; }

    }
    public class Updatethongtindoithu
    {
        public string ID { set; get; }
        public string Type { set; get; } 

    }
    public class ThongtinDoitac
    {
        public string ID { set; get; }
        public string Mohinh_DoiTac_Code { set; get; }
        public string Mohinh_DoiTac_Name { set; get; }
        public string Ten_DoiTac_Name { set; get; }
        public string MienCode { set; get; }
        public string MienName { set; get; }
        public string Phuong_Xa_Code { set; get; }
        public string Quan_Huyen_Code { set; get; }
        public string Tinh_Thanhpho_Code { set; get; }
        public string Phuong_Xa_Name { set; get; }
        public string Quan_Huyen_Name { set; get; }
        public string Tinh_Thanhpho_Name { set; get; }
        public string DiaChiCuThe { set; get; }
        public string QuyMo { set; get; }
        public string DoanhSoThang { set; get; }
        public string SoLuongNhanSu { set; get; }
        public string DivisionCode { set; get; }
        public string DivisionName { set; get; }
        public string BrandCode { set; get; }
        public string BrandName { set; get; }
        public string ProductCode { set; get; }
        public string ProductName { set; get; }
        public string NguoiLienHe { set; get; }
        public string DienThoaiLienHe { set; get; }
        public string FileUpLoad { set; get; }
        public string Status { set; get; }
        public string CreateBy { set; get; }
        public string CreateDate { set; get; }
        public string ModifyBy { set; get; }
        public string ModifyDate { set; get; }

    }
}