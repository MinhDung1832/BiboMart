using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.Approve
{
    public class approvemodel
    {
        public int autoid { set; get; }
        public string ItemCode { set; get; }
        public string ItemName { set; get; }
        public string Store { set; get; }
        public string RequestType { set; get; }
        public string Descriptions { set; get; }
        public string Status { set; get; }
        public string ModifyDate { set; get; }

    }

    public class permissioninfo
    {
        public string fcode { set; get; }
        public string fname { set; get; }
        public string paname { set; get; }
        public int flevel { set; get; }
        public string parentcode { set; get; }
        public string action { set; get; }
        public string controller { set; get; }
        public int vcount { set; get; } = 0;
        public string reportpath { set; get; }
        public string menu { set; get; }
        public string En_Name { set; get; }

        public string VN_Name { set; get; }
    }

    public class potonginfo
    {
        public string Function { set; get; }
        public string NguonNhap { set; get; }
        public decimal POTongMienBac { set; get; }
        public decimal POTongMienNam { set; get; }
        public decimal POTongToanQuoc { set; get; }
        public decimal POQuaHan { set; get; }
        public decimal GiaTriPOTongToanQuoc { set; get; }
        public decimal TonKho { set; get; }
        public decimal Intransit { set; get; }
        public decimal POTongCR { set; get; }
        public decimal DatThem { set; get; }
        public decimal QuaHan { set; get; }
        public string MuaVu { set; get; }
        public string Mien { set; get; }
        public string MaNCC { set; get; }
        public string Brand { set; get; }
        public string Cang_NhaMay_Code { set; get; }
        public decimal SUMQuaHan { set; get; }
    }

    public class rangereviewinfo
    {
        public string Mahang { set; get; }
        public string Rangereview { set; get; }
        public string requestnote { set; get; }
        public int status { set; get; }
        public string ModifyDate { set; get; }
        public string Range { set; get; }
        public string MaNCC { set; get; }

    }

    public class newproductinfo
    {
        public int ID { set; get; }
        public string FunctionCode { set; get; }
        public string FunctionName { set; get; }
        public decimal SLDat { set; get; }
        //
        public string imgurl { set; get; }
        public string linksp { set; get; }
        public string bstcode { set; get; }
        public string bstname { set; get; }
        public string yeucau { set; get; }
        //
        public string ncc { set; get; }
        public string xuatxu { set; get; }
        public string cangxuat { set; get; }
        public string moq { set; get; }
        public string sltonkho { set; get; }
        public string leadtimesx { set; get; }
        public string mausac { set; get; }
        public string trongluong { set; get; }
        //
        public decimal spdai { set; get; }
        public decimal sprong { set; get; }
        public decimal spcao { set; get; }
        public decimal slthung { set; get; }
        public decimal thungdai { set; get; }
        public decimal thungrong { set; get; }
        public decimal thungcao { set; get; }
        //
        public string size { set; get; }
        public string tuoi { set; get; }
        //
        public string ncc_cur { set; get; }
        public decimal ncc_tygia { set; get; }
        public decimal ncc_gia { set; get; }
        public string ncc_loaiFw { set; get; }
        public decimal ncc_thetich { set; get; }
        public decimal ncc_giaFw { set; get; }
        public decimal ncc_VAT { set; get; }
        public decimal ncc_gianhap { set; get; }
        //
        public decimal sl_ch { set; get; }
        public decimal sl_mau { set; get; }
        public decimal sl_color { set; get; }
        public decimal sl_size { set; get; }
        //
        public string transferWay { set; get; }
        //
        public int N_ID { set; get; }
        public int type { set; get; }
        public string DivCode { set; get; }
        public string CatCode { set; get; }
        public string GroupCode { set; get; }
        public string DivName { set; get; }
        public string CatName { set; get; }
        public string GroupName { set; get; }

        public string N_Name { set; get; }
        public string N_Brand { set; get; }
        public string N_xuatxu { set; get; }
        public string N_UoM { set; get; }
        public string N_trongluong { set; get; }
        public decimal N_spdai { set; get; }
        public decimal N_sprong { set; get; }
        public decimal N_spcao { set; get; }
        public decimal N_pack_sl { set; get; }
        public string N_pack_baobi1 { set; get; }
        public string N_pack_baobi2 { set; get; }
        public decimal N_thungdai { set; get; }
        public decimal N_thungrong { set; get; }
        public decimal N_thungcao { set; get; }
        public string N_imgurl { set; get; }
        public string N_linksp { set; get; }
        public string N_BarCode { set; get; }
        public string N_ncc_gianhap { set; get; }
        public decimal N_ncc_VAT { set; get; }
        public decimal N_MOQ { set; get; }
        public decimal N_SL_min_CH { set; get; }

        //
        public string Status { set; get; }
        public string CreateDate { set; get; }
        public string CreateBy { set; get; }
        public string ModifyDate { set; get; }
        public string ModifyBy { set; get; }
        public string ApproveDate { set; get; }
        public string ApproveBy { set; get; }
        public int Hangmau { set; get; }


    }

    public class newproductinfoND
    {
        public int ID { set; get; }
        public string FunctionCode { set; get; }
        public string FunctionName { set; get; }
        public string SLDat { set; get; }
        //
        public string imgurl { set; get; }
        public string linksp { set; get; }
        public string bstcode { set; get; }
        public string bstname { set; get; }
        public string yeucau { set; get; }
        //
        public string ncc { set; get; }
        public string xuatxu { set; get; }
        public string moq { set; get; }
        public string sltonkho { set; get; }
        public string leadtimesx { set; get; }
        public string mausac { set; get; }
        public string trongluong { set; get; }
        //
        public string spdai { set; get; }
        public string sprong { set; get; }
        public string spcao { set; get; }
        public string slthung { set; get; }
        public string thungdai { set; get; }
        public string thungrong { set; get; }
        public string thungcao { set; get; }
        //
        public string size { set; get; }
        public string tuoi { set; get; }
        //
        public string ncc_thetich { set; get; }
        public string ncc_gianhap { set; get; }
        //
        public string sl_ch { set; get; }
        public string sl_mau { set; get; }
        public string sl_color { set; get; }
        public string sl_size { set; get; }
        //
        public string Status { set; get; }
        public string CreateDate { set; get; }
        public string CreateBy { set; get; }
        public string ModifyDate { set; get; }
        public string ModifyBy { set; get; }
        public string ApproveDate { set; get; }
        public string ApproveBy { set; get; }
        public int Hangmau { set; get; }

    }

    public class newproductinfo_Step2
    {
        public int ID { set; get; }
        //   public int IDstep2 { set; get; }
        public int ProductID { set; get; }
        public string moq { set; get; }
        public string sltonkho { set; get; }
        public string leadtimesx { set; get; }
        public string leadtimenk { set; get; }
        public string slOEM { set; get; }
        public decimal slthung { set; get; }
        public decimal thungdai { set; get; }
        public decimal thungrong { set; get; }
        public decimal thungcao { set; get; }
        public string ncc_cur { set; get; }
        public decimal ncc_tygia { set; get; }
        public decimal ncc_gia { set; get; }
        public string ncc_loaiFw { set; get; }
        public decimal ncc_thetich { set; get; }
        public decimal ncc_giaFw { set; get; }
        public string ncc_loaiFwCode { set; get; }
        public decimal ncc_VAT { set; get; }
        public decimal ncc_gianhap { set; get; }
        public string NgayNKdukien { set; get; }
        public string transferWay { set; get; }
        public decimal GBLTamTinhNew { set; get; }
        public string Status { set; get; }
        public string CreateDate { set; get; }
        public string CreateBy { set; get; }
        public string ModifyDate { set; get; }
        public string ModifyBy { set; get; }
        public string ApproveDate { set; get; }
        public string ApproveBy { set; get; }
        public string ApproveNote { set; get; }


    }

    public class apprPrd
    {
        public int ID { get; set; }
        public string Phanhoiyeucau { get; set; }
        public string status { get; set; }
    }

    public class fileinfo2
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Note { get; set; }
    }
    public class trainghiem
    {
        public int ID { get; set; }
        public string MaCH { get; set; }
        public string TenCh { get; set; }
        public string Danhmuc { get; set; }
        public string Danhmuccon { get; set; }
        public string imgurl { get; set; }
        public string STT { get; set; }
        public string ghichu { get; set; }
    }


    public class quayke
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal High { get; set; }
        public decimal Width { get; set; }
        public decimal Depth { get; set; }
        public decimal HighNet { get; set; }
        public decimal WidthNet { get; set; }
        public decimal DepthNet { get; set; }
    }
    public class SetUp_Pro
    {
        public int id { get; set; }
        public string LoaiCaiDat { get; set; }
        public string MucTieuCTKM { get; set; }
        public string MaCTKM { get; set; }
        public string TenCTKM { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        public string Dinhky_VongLap { get; set; }
        public string StoreGroupType { get; set; }
        public string StoreGroup { get; set; }
        public string CreateStore_Channel { get; set; }
        public string Message1 { get; set; }
        public string Message2 { get; set; }
        public string Message3 { get; set; }
        public string PriceGroup { get; set; }
        public string CustomerDiscGroup { get; set; }
        public string CreatePriceByStore { get; set; }
        public string CreateCustomerGroup { get; set; }
        public string CouponCode { get; set; }
        public string CouponQtyNeeded { get; set; }
        public string SalesTypeFilter { get; set; }
        public string AmountToTrigger { get; set; }
        public string MemberType { get; set; }
        public string MemberValue { get; set; }
        public string MemberAttibute { get; set; }
        public string MemberAttibuteValue { get; set; }
        public string TenderTypeCode { get; set; }
        public string TenderTypeValue { get; set; }
        public string Status { get; set; }
        public string Code_SP { get; set; }
        public string Date_Send { get; set; }
        public string Code_AP { get; set; }
        public string ApprovalPerson { get; set; }
        public string Date_App { get; set; }
        public string createdate { get; set; }
        public string createby { get; set; }
        public string modifydate { get; set; }
        public string modifyby { get; set; }
    }

    public class groupinfo
    {
        public string gcode { set; get; }
        public string gname { set; get; }
        public int vcount { set; get; }

    }
    public class CustomerAutoInfo
    {
        public string PostCode { set; get; }

        public string StoreNo { set; get; }

        public string MemberCardNo { set; get; }

        public string AccountNo { set; get; }

        public string FullName { set; get; }

        public string PhoneNo { set; get; }

        public string ChildYear { set; get; }

        public string Date { set; get; }

        public string ItemNo { set; get; }
        public string ItemName { set; get; }
        public string Quantity { set; get; }

        public string ItemExpectedUseDate { set; get; }

        public string ExpectedPurchaseDate { set; get; }

        public string QuantityExpected { set; get; }

        public string WKExpected { set; get; }

        public string Createdate { set; get; }

        public string istatus { set; get; }

        public string Buydate { set; get; }

        public string StaffID { set; get; }

        public string ChannelType { set; get; }
    }

    public class narinfo
    {
        public string ID { set; get; }
        public string NguonNhap { set; get; }
        public string Div { set; get; }
        public string Function { set; get; }
        public string MuaVu { set; get; }
        public string MaNCC { set; get; }
        public string Mien { set; get; }
        public string Brand { set; get; }
        public string Cang { set; get; }
        public string KieuNhapKhau { set; get; }
        public decimal M3 { set; get; }
        public string Acm { set; get; }
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string HinhAnh { set; get; }
        public string LinkSP { set; get; }
        public decimal GiaNhap { set; get; }
        public decimal PoDatthem { set; get; }
        public decimal slbany1 { set; get; }
        public decimal slbanytd { set; get; }
        public decimal slband30 { set; get; }
        public decimal SlTon { set; get; }
        public decimal SLDat { set; get; }
        public decimal ThanhTien { set; get; }
        public string LoaiDatHang { set; get; }
        public string Status { set; get; }
        public string timestamp { set; get; }
        public string PoNo { set; get; }
        public string CreateBy { set; get; }
        public string CreateDate { set; get; }
        public string ApproveBy { set; get; }
        public string ApproveDate { set; get; }
        public string ReviewBy { set; get; }
        public string ReviewDate { set; get; }
        public string HisBy { set; get; }
        public string HisDate { set; get; }
    }

    public class collectioninfo
    {
        public int ID { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public string cat { set; get; }
        public string muavu { set; get; }
        public string doituong { set; get; }
        public string gioitinh { set; get; }
        public string thunhap { set; get; }
        public string USP { set; get; }
        public string thongdiep { set; get; }
        public string Themelink { set; get; }
        public string Description { set; get; }

    }

    public class collectiondetail
    {
        public int ID { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public string cat { set; get; }
        public string muavu { set; get; }
        public string doituong { set; get; }
        public string gioitinh { set; get; }
        public string thunhap { set; get; }
        public string USP { set; get; }
        public string thongdiep { set; get; }
        public string hinhanh { set; get; }
        public string SLton { set; get; }
        public string GiaBanAll { set; get; }
        public string DivisionCode { set; get; }
        public string DivisionName { set; get; }
        public string CategoryCode { set; get; }
        public string CategoryName { set; get; }
        public string GroupCode { set; get; }
        public string GroupName { set; get; }
        public string FunctionCode { set; get; }
        public string FunctionName { set; get; }
        public string BrandCode { set; get; }
        public string BrandName { set; get; }
        public string NguonNhapCode { set; get; }
        public string NguonNhapName { set; get; }
        public string MuaVuCode { set; get; }
        public string MuaVuName { set; get; }

    }

    public class collectiondetailadd
    {
        public string ID { set; get; }
        public string mahang { set; get; }

    }

    public class collectiondetailupdate
    {
        public string stt { set; get; }
        public string slcombo { set; get; }

    }

    public class itemhangmoiinfo
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public string bstcode { set; get; }
        public string bstname { set; get; }
        public string hinhanh { set; get; }
        public string sldat { set; get; }

        public int stt { set; get; }
    }
    public class ExrateList
    {
        public string DateTime { set; get; }
        public Exrate Exrate { set; get; }
        public string Source { set; get; }
    }
    public class Exrate
    {
        public string CurrencyCode { set; get; }
        public string CurrencyName { set; get; }
        public string Buy { set; get; }
        public string Transfer { set; get; }
        public string Sell { set; get; }
    }

    public class giaonl
    {
        public string mahang { set; get; }
        public decimal giamoi { set; get; }
        public string gpmoi { set; get; }
        public decimal giaapprove { set; get; }
        public int isapprove { set; get; }
        public string salecode { set; get; }
        public string rr { set; get; }
        public string rrname { set; get; }

    }

    public class giaoffl
    {
        public string mahang { set; get; }
        public string macuahang { set; get; }
        public decimal giamoi { set; get; }
        public decimal gpmoi { set; get; }
        public decimal giaapprove { set; get; }
        public int isapprove { set; get; }
    }

    public class ERPsaleprice
    {
        public string Sales_Code { set; get; }
        public string Item_No { set; get; }
        public decimal Unit_Price { set; get; }
    }

    public class ERPItemSpecialGroup
    {
        public string Item_No { set; get; }
        public string Special_Group_Code { set; get; }
    }

    public class pretransferinfo
    {
        public string mahang { set; get; }
        public string cuahang { set; get; }
        public string hanhdongduyet { set; get; }
        public int isapprove { set; get; }
        public decimal sldieuchuyen { set; get; }
        public decimal Unit_Price { set; get; }
    }
    public class poquahaninfo
    {
        public string mahang { set; get; }
        public decimal sldchot { set; get; }
        public string action1 { set; get; }
        public string nguonnhap { set; get; }
        public string action2 { set; get; }
        public int ID { set; get; }
        public string MaNCC { set; get; }
    }

    public class nextstepinfo
    {
        public string TrangThaiDonHang { set; get; }
        public string DienGiaiTrangThai { set; get; }
        public string NextStep { set; get; }
    }

    public class NNDivFunc
    {
        public string DivisionCode { set; get; }
        public string DivisionName { set; get; }
        public string FunctionCode { set; get; }
        public string FunctionName { set; get; }
        public string NguonNhap { set; get; }
        public string MaNCC { set; get; }
        public string TenNCC { set; get; }

    }

    public class Cuahang_Tinh
    {
        public string MaMien { set; get; }
        public string TenMien { set; get; }
        public string Matinh { set; get; }
        public string TenTinh { set; get; }
        public string MaCuahang { set; get; }
        public string TenCuahang { set; get; }
    }

    public class brfn
    {
        public string brand_code { set; get; }
        public string brand_name { set; get; }
        public string function_code { set; get; }
        public string function_name { set; get; }
    }

    public class brandnccfunction
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public string Functioncode { set; get; }
        public string Functionname { set; get; }
    }

    public class asmrsmstore
    {
        public string ASM_Code { set; get; }
        public string ASM_Name { set; get; }
        public string RSM_Code { set; get; }
        public string RSM_Name { set; get; }
        public string Store_Code { set; get; }
        public string Store_Name { set; get; }
    }
    public class xatonerp
    {
        public string Mahang { set; get; }
        public decimal GiaKM { set; get; }
        public decimal GiabanALL { set; get; }

    }
    public class filtercusomerloyalty
    {
        public string NhomKH { set; get; }
        public string MaNhomKH { set; get; }
        public string MaTinh { set; get; }
        public string TenTinh { set; get; }
        public string MaCH { set; get; }
        public string TenCH { set; get; }
        public string MaHang { set; get; }
        public string TenHang { set; get; }
    }

    public class filteroosstore
    {
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string MaCH { set; get; }
        public string TenCH { set; get; }
        public string MaTinh { set; get; }
        public string TenTinh { set; get; }
        public string Mien { set; get; }
        public string MaNcc { set; get; }
        public string TenNCC { set; get; }
        public string BrandCode { set; get; }
        public string BrandName { set; get; }

    }

    public class thietketieuchuandetail
    {
        public string ImgUrl { set; get; }
        public string Orderby { set; get; }
        public string CreateDate { set; get; }
    }

    public class DemandItem
    {
        public int ID { set; get; }
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string MaNCC { set; get; }
        public decimal GiaNhapCu { set; get; }
        public decimal GiaNhap { set; get; }
        public decimal VAT { set; get; }
        public decimal GiaNhapVAT { set; get; }
        public decimal SLton { set; get; }
        public string DateSP { set; get; }
        public decimal ForcastD30 { set; get; }
        public decimal ForcastD90 { set; get; }
        public decimal SLDat { set; get; }
        public decimal Amount { set; get; }
        public decimal CM3 { set; get; }
        public decimal QPC { set; get; }
        public string DVT { set; get; }

        public decimal SoCHCaiAR { set; get; }
        public decimal SoCHDangHD { set; get; }
        public decimal DailySalesBQ { set; get; }
        public decimal SLDatNew { set; get; }
        public decimal AmountNew { set; get; }

        public string CreateDate { set; get; }
        public string Nguon { set; get; }


    }

    public class notiinfo
    {
        public string fcode { set; get; }
        public string fname { set; get; }
        public string action { set; get; }
        public string controller { set; get; }
        public int waiting { set; get; } = 0;
    }

    public class ARitem
    {
        public string mahang { set; get; }
        public string mach { set; get; }
        public decimal psmoi { set; get; }
        public decimal dsmoi { set; get; }
        public decimal sldat { set; get; }
        public string fromdate { set; get; }
        public string todate { set; get; }
        public int fstatus { set; get; }

        public decimal TopSaleFunction { set; get; }
        public decimal PS { set; get; }
        public decimal DailySalesErp { set; get; }
        public decimal MinPSFunction { set; get; }
        public decimal SlTon { set; get; }
        public decimal SlBanD30 { set; get; }
    }

    public class TOSOfilter
    {
        public string ItemNo { set; get; }
        public string ItemName { set; get; }
        public string StoreCode { set; get; }
        public string StoreName { set; get; }
    }
    public class UpdateTBay
    {
        public string ItemNo { set; get; }
        public int ID { set; get; }
    }

    public class MotaCVinfo
    {
        public string Title { set; get; }
        public string Detail { set; get; }
    }

    public class SieusaoKPIinfo
    {
        public string ProfilePicture { set; get; }
        public string MaNV { set; get; }
        public string TenNV { set; get; }
        public string Score { set; get; }
    }
    public class SieusaoDoanhthuinfo
    {
        public string ProfilePicture { set; get; }
        public string MaNV { set; get; }
        public string TenNV { set; get; }
        public string Score { set; get; }
    }

    public class Bonusinfo
    {
        public string Picture { set; get; }
        public string Title { set; get; }
        public string Detail { set; get; }
    }

    public class Bantininfo
    {
        public string Creator { set; get; }
        public string Title { set; get; }
        public string Detail { set; get; }
        public string Link { set; get; }
    }

    public class chidinhhotdealinfo
    {
        public int ID { set; get; }
        public string Mahang { set; get; }
        public string Tenhang { set; get; }
        public decimal GPF { set; get; }
        public decimal GPB { set; get; }
        public decimal GPG { set; get; }
        public string Fromdate { set; get; }
        public string Todate { set; get; }
        public decimal SLDX { set; get; }
        public decimal SLAD { set; get; }
        public string Status { set; get; }
        public string RequestBy { set; get; }
        public string RequestDate { set; get; }
        public string ApproveBy { set; get; }
        public string ApproveDate { set; get; }
    }
}