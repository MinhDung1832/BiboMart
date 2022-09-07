using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ManageSales
{
    public class thongtindoithudetail
    {
        public string MaCH { set; get; }
        public string TenCH { set; get; }
        public string MaMien { set; get; }
        public string TenMien { set; get; }
        public string MaTinh { set; get; }
        public string TenTinh { set; get; }
        public string MaQuan { set; get; }
        public string TenQuan { set; get; }
        public string MaPhuong { set; get; }
        public string TenPhuong { set; get; }

    }
    public class objCombox
    {
        public string Code { set; get; }
        public string Name { set; get; }

    }

    public class ThongTinDTPost
    {
        public string ID { set; get; }
        public string MaCH { set; get; }
        public string TenCH { set; get; }
        public string DoiThu_Code { set; get; }
        public string DoiThu_Name { set; get; }
        public string Mien_Code { set; get; }
        public string Tinh_Code { set; get; }
        public string Quan_Code { set; get; }
        public string Phuong_Code { set; get; }
        public string DiaChi { set; get; }
        public string DoPhuThiTruong { set; get; }
        public string DienTichKD { set; get; }
        public string MatTien { set; get; }
        public string ViTri { set; get; }
        public string NganhHangKD { set; get; }
        public string NhanHangKD { set; get; }
        public string AnhMatTien { set; get; }
        public string AnhChieuDi { set; get; }
        public string AnhChieuVe { set; get; }
        public string AnhBenTrong { set; get; }

    }

    public class objFillterCombo
    {
        public string CategoryCode { set; get; }
        public string CategoryName { set; get; }
        public string DivisionCode { set; get; }
        public string DivisionName { set; get; }
        public string FunctionCode { set; get; }
        public string FunctionName { set; get; }
    }

    public class objBarcode
    {
        public string MaCH { set; get; }
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string Unit_of_Measure_Code { set; get; }
        public decimal Discount_Percent { set; get; }
        public string Barcode { set; get; }

    }

    public class objThuongDC
    {
        public decimal PhatDC { set; get; }
        public decimal ThuongDC { set; get; }

    }

    public class objTranferReport
    {
        public decimal SLDongKien { set; get; }
        public decimal SLYeuCau { set; get; }
        public decimal SLTaoSOTO { set; get; }
        public decimal SLNhapKho { set; get; }

    }

    public class objTransfer
    {
        public decimal SLDC { set; get; }
        public decimal GiaTriDC { set; get; }
        public decimal SLChuaDC { set; get; }
        public decimal SLHangThua { set; get; }
        public decimal ThuongVH { set; get; }
        public decimal ThuongCH { set; get; }
        public decimal totalPhat { set; get; }

    }


    public class objComboxEx
    {
        public string Code { set; get; }
        public string ParentCode { set; get; }
        public string Name { set; get; }

    }

    public class objComboxKhuVuc
    {
        public string RSM_Code { set; get; }
        public string RSM_Name { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }

    }

    public class objComboCoverImport
    {
        public string Type { set; get; }
        public string port { set; get; }
        public string packType { set; get; }
        public int Price { set; get; }
    }
}