using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.ManageSales
{
    public class objCompeteOffline
    {
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string MaCH { set; get; }
        public string TenCH { set; get; }
        public decimal L4LSL { set; get; }
        public string L4LDT { set; get; }
        public string L4LGP { set; get; }
        public string GiaTaiCH { set; get; }
        public string GiaDoiThu { set; get; }
        public string TenDoiThu { set; get; }
        public string GiaDieuChinh { set; get; }
        public string createDate { set; get; }
        public string accept_Price { set; get; }

    }
    public class objMarcom
    {
        public string SourceMarcom { get; set; }
        public string arrItem { get; set; }
        public string MaChienDich { get; set; }
        public string MaKH { get; set; }
        public string NhomKh { get; set; }
        public string MaHang { get; set; }
        public string Phone { get; set; }
        public string AccountNo { get; set; }
        public string Coupon { get; set; }
        public string NoiDung { get; set; }
        public string HangKh { get; set; }
        public string TinhThanh { get; set; }
        public string StoreNo { get; set; }
        public string Div { get; set; }
        public string Brand { get; set; }
        public string TaiApp { get; set; }
        public string Function { get; set; }
        public string LocNgayTao { get; set; }
        public string LocNgayDen { get; set; }
        public string MaTinh { get; set; }
        public string Store { get; set; }
        public string isEmail { get; set; }
        public string birthday { get; set; }
        public string ChildOld { get; set; }



    }

    public class objItemMarcom
    {
        public string MaChienDich { get; set; }
        public string NhomKH { get; set; }
        public string LoaiHinh { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string TimeSend { get; set; }
        public string DangMoApp { get; set; }
        public string PhamVi { get; set; }
        public string ThietBi { get; set; }
        public string LinkWeb { get; set; }
        public string DoanhThu { get; set; }
        public string ChiPhi { get; set; }
        public string Display { get; set; }
        public string CTKM { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string LinkImage { get; set; }
        public string Status { get; set; }
        public string StatusSend { get; set; }
        public string MaCTKM { get; set; }
        public string TimeSendPushSMS { get; set; }
        public string TimeSendPushApp { get; set; }
        public string TimeHour { get; set; }
        public string TypeSMS { get; set; }
        public string Brand { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public string FunctionCode { get; set; }
        public string TaiApp { get; set; }
        public string FunctionName { get; set; }
        public string ChiPhiSMS { get; set; }
        public string SlKhach { get; set; }
        public string LocNgayTao { get; set; }
        public string LocNgayDen { get; set; }
        public string MaTinh { get; set; }
        public string TenTinh { get; set; }
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public string WeeklyTime { get; set; }
        public string TanSuat { get; set; }
        public string CouponCode { get; set; }
        public string TongCoupon { get; set; }
        public string SoTienCoupon { get; set; }
        public string NgayKetThucCoupon { get; set; }
        public string MoTa { get; set; }


        public string TypeCase { get; set; }
        public string TypePopup { get; set; }
        public string priority { get; set; }
        public string StatusPopup { get; set; }
        public string repeat { get; set; }
        public string delay { get; set; }
        public string interval { get; set; }
        public string TitleAction { get; set; }
        public string PositionAction { get; set; }
    }
    public class objCustomerD7
    {
        public string MaChienDich { get; set; }
        public string MaKH { get; set; }
        public string HoTen { get; set; }
        public string KenhBan { get; set; }
        public string MaHang { get; set; }
        public string Tenhang { get; set; }
        public string NhomKH { get; set; }

    }
    public class Detail_DaiLy
    {
        public string ID { get; set; }
        public string MaChienDich { get; set; }
        public string TenChienDich { get; set; }
        public string NgayGui { get; set; }
        public string TrangThai { get; set; }
        public string StatusCode { get; set; }
        public string StatusBlock { get; set; }
    }
    public class Marcom_Weekly
    {
        public string Weekly { get; set; }
    }
}