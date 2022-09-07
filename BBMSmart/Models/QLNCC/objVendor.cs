using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.QLNCC
{
    public class RouteInfo
    {
        public int RespId { get; set; }

        public string RespMsg { get; set; }
    }
    public class objVendor
    { 
        public decimal DSY1 { set; get; }
        public decimal DSYTD { set; get; }
        public decimal TargetDS { set; get; }
        public decimal DTFY { set; get; }
        public decimal LFLDSFY { set; get; }
        public decimal SLTon { set; get; }
        public decimal GTTon { set; get; }
        public decimal GPM2F { set; get; }
        public decimal DTY_1 { set; get; }
        public decimal DTYTD { set; get; }
        public decimal DS30 { set; get; }
        public decimal GAPDSD30 { set; get; }

    }
    public class objTruongNganhHang
    {
        public decimal XepHang { set; get; }
        public decimal L4LSoLuong { set; get; }
        public decimal L4LDoanhSo { set; get; }
    }
    public class objThucDayDS
    {
        public decimal ChiTieu { set; get; }
        public decimal DSMTD { set; get; }
        public decimal UocDat { set; get; }
        public decimal DoanhSoMTDON { set; get; }
        public decimal TagetON { set; get; }
    }

    public class objSaleTarget
    {
        public decimal ONLTargetDT { set; get; }
        public decimal ONLDT { set; get; }
        public decimal ONLUocDatDT { set; get; }

        public decimal OFF_TargetDT { set; get; }
        public decimal OFF_DT { set; get; }
        public decimal OFF_UocDatDT { set; get; }

        public decimal WS_TargetDT { set; get; }
        public decimal WS_DT { set; get; }
        public decimal WS_UocDatDT { set; get; }

        public decimal TargetDT { set; get; }
        public decimal DT { set; get; }
        public decimal UocDatDT { set; get; }


        public decimal NSQC { set; get; }
        public decimal QuyThuong { set; get; }

    }

    public class objTangTruongNH
    {
        public decimal L4LSoLuong { set; get; }
        public decimal L4LDoanhSo { set; get; }
    }
    public class objDatHangBoSung
    {
        public decimal SoNgayOOS { set; get; }
        public decimal DSmatDoOOS { set; get; }
    }

    public class objProductandBrand
    {
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string BrandCode { set; get; }
        public string BrandName { set; get; }
    }
    public class RangeReviewAcceptinfo
    {
        public string MaHang { set; get; }
        public string status { set; get; }
        public string MaNCC { set; get;}
    }

    public class rangereviewinfoRR
    {
        public string Mahang { set; get; }
        public string Rangereview { set; get; }
        public string requestnote { set; get; }
        public int status { set; get; }
        public string ModifyDate { set; get; }
        public string Range { set; get; }
        public string MaNCC { set; get; }
        public string GPFunction { set; get; }

    }

    public class RRNDReEntry
    {
        public string MaHang { set; get; }
        public string MaNCC { set; get; }
        public string NNNgungKD { set; get; }
        public string KetQua { set; get; }

    }

    public class objCHKhaiTruong
    {
        public string RegionCode { set; get; }
        public string RegionName { set; get; }
        public string MaTinh { set; get; }
        public string TenTinh { set; get; }
        public string StoreNo { set; get; }
        public string StoreName { set; get; }
        public string NgayBanHang { set; get; }
        public string ASM_Code { set; get; }
        public string ASM_Name { set; get; } 
    }


    public class objOrderVendor
    {
        public string VendorNo { set; get; }
        public string VendorName { set; get; }
        public string BrandCode { set; get; }
        public string BrandName { set; get; }
        public string FunctionName { set; get; }
        public string Range { set; get; }
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string XepHang631SKUs { set; get; }
        public string GiaNhap { set; get; }
        public string Stockday { set; get; }
        public string SlTon { set; get; }
        public string SlBanD30 { set; get; }
        public string DiscountAmount { set; get; }
        public string DiscountPercent { set; get; }
        public string OrderValue { set; get; }
        public string ChietKhau { set; get; }
        public string SoLuongDat { set; get; }
        public string LoaiCK { set; get; }
        public string ThanhTien { set; get; }
        public string HinhAnh { set; get; }
        public string link { set; get; }
        public string Status { set; get; }
        public string KhoNhan { set; get; }
        public string OrderVendorID { set; get; }


    }

    public class objOrderGrandOpening
    {
        public string VendorNo { set; get; }
        public string MienNo { set; get; }
        public string SoPo { set; get; }
        public string SourceOrderGrandOpening { set; get; }
    }

}