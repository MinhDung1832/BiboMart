using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAllTool.Models.HRM
{

    public class HRMMenu
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public int MenuCode { set; get; }
    }
    public class balancedScoreInfo
    {
        public string congty { set; get; }
        public string khoi { set; get; }
    }
    public class objJobHRM
    {
        public string SourceJob { set; get; }
    }
    public class HRMJobInfo
    {
        public int ID { set; get; }
        public string CodeEmp { set; get; }
        public string NameEmp { set; get; }
        public string CapBac { set; get; }
        public string CapBacCode { set; get; }
        public string PositionCode { set; get; }
        public string PositionName { set; get; }
        public string CodeJob { set; get; }
        public string NameJob { set; get; }
        public string TanSuatThucHien { set; get; }
        public string ThoiLuongThucHien { set; get; }
        public string TotalTime { set; get; }
        public string TongTGLamViec { set; get; }
        public int Status { set; get; }
        public string ModifyDate { set; get; }
        public string ModifyBy { set; get; }
        public int ischecked { set; get; }
    }
    public class KPITieuChi
    {
        public string ThuocDo { set; get; }
        public string percentKPI { set; get; }
        public string MaDuAn { set; get; }
    }
    public class ObjKPIDepartment
    {
        public string SourceKPIDepartment { get; set; }

    }
    public class User_Member
    {
        public string Khoi { set; get; }
        public string Phongban { set; get; }
    }

    public class HRMUyQuyen
    {
        public int ID { set; get; }
        public string LoaiVB { set; get; }
        public string SoVB { set; get; }
        public string DiaChi { set; get; }
        public string CongTy { set; get; }
        public string NgayHieuLuc { set; get; }
        public string NguoiUyQuyen { set; get; }
        public string NguoiDuocUyQuyen { set; get; }
        public string MaChucDanh { set; get; }
        public string ChucDanh { set; get; }
        public string NoiDung { set; get; }
        public string MaNoiDung { set; get; }
        public string MaChucNangCon { set; get; }
        public string MaChucNang { set; get; }
        public string ChucNangCon { set; get; }
        public string MaNganSach { set; get; }
        public string NSDuocDuyet { set; get; }
        public string NSDuocDuyetTu { set; get; }
        public string NSDuocDuyetDen { set; get; }
        public string CreatedBy { set; get; }

    }

    public class addDuyetInOut
    {
        public string GioRaVaoThucTe { set; get; }
        public string LoaiCa { set; get; }
        public string LyDoTuChoi { set; get; }
    }

    public class AddDuyetDieuChuyenNSCH
    {
        public string MaNVdc { set; get; }
        public string MaCHnhan { set; get; }
        public string TenCHnhan { set; get; }
        public string ChucDanhnhan { set; get; }
        public string SLThieu { set; get; }
        public string LoaiDieuChuyen { set; get; }
    }


    public class UpdateDuyetDSDieuChuyenNSCH
    {
        public string ID { set; get; }
      
    }



    public class Obj_HoSoUngVien
    {
        public string ID { set; get; }
        public string ViTriTuyenDung { set; get; }
        public string KeHoachTuyen { set; get; }
        public string NoiLamViec { set; get; }
        public string NgayNopHoSo { set; get; }
        public string NgayCoTheDiLam { set; get; }
        public string NgayDiLam { set; get; }
        public string SoNgayThuViec { set; get; }
        public string ThoiGianLamViec { set; get; }
        public string Ky { set; get; }
        public string SoVongPhongVan { set; get; }
        public string PhongBanUT { set; get; }
        public string ChucDanh { set; get; }
        public string ChucVu { set; get; }
        public string NguoiQuanLyTrucTiep { set; get; }
        public string LoaiLoaDong { set; get; }
        public string LoaiNhanVien { set; get; }
        public string CapBacCM { set; get; }
        public string KhuVucLamViec { set; get; }
        public string NgachLuong { set; get; }
        public string BacLuong { set; get; }
        public string LuongDeNghi { set; get; }
        public string LuongHienTai { set; get; }
        public string LuongDuocDuyet { set; get; }
        public string LuongThuViec { set; get; }
        public string TienTeChung { set; get; }
        public string PhuCap { set; get; }
        public string PhuCapQuanLy { set; get; }
        public string PhuCapNgonNgu { set; get; }
        public string PhuCapKyNang { set; get; }
        public string PhuCapDiLai { set; get; }
        public string TruongTotNghiep { set; get; }
        public string NamTotNghiep { set; get; }
        public string SoNamKinhNghiem { set; get; }
        public string SoNamOViTriOT { set; get; }
        public string CongTyLanGanNhat { set; get; }
        public string ChuyenNganh { set; get; }
        public string XepLoai { set; get; }
        public string TayNghe { set; get; }
        public string ViTriNganhDaLam { set; get; }
        public string NguonTuyenDung { set; get; }
        public string TrangThai { set; get; }
        public string DiemManh { set; get; }
        public string DiemYeu { set; get; }
        public string MongDoiCuaBan { set; get; }
        public string DinhHuongNgheNghiep { set; get; }
        public string DiCongTac { set; get; }
        public string DaRutHoSo { set; get; }
        public string MucTieuCaNhan { set; get; }
        public string KeHoachCaNhan { set; get; }
        public string NangKhieu { set; get; }
        public string CacHoatDongNgoaiKhoa { set; get; }

    }
    public class Obj_KhaiBao_HoSoUngVien
    {
        public string ID { set; get; }
        public string TenUngVien { set; get; }
        public string MaUngVien { set; get; }
        public string SobaoDanh { set; get; }
        public string GioiTinh { set; get; }
        public string TinhTrangHonNhan { set; get; }
        public string NgaySinh { set; get; }
        public string NoiSinh { set; get; }
        public string NguyenQuan { set; get; }
        public string QuocTich { set; get; }
        public string TonGiao { set; get; }
        public string TrinhDoVanHoa { set; get; }
        public string TrinhDoHocVan { set; get; }
        public string TenThuongGoi { set; get; }
        public string TenTiengHoa { set; get; }
        public string SoCMND { set; get; }
        public string NgayCapCMND { set; get; }
        public string NoiCap { set; get; }
        public string MST { set; get; }
        public string NgayApDung { set; get; }
        public string CoQuanQuanLy { set; get; }
        public string SoHoChieu { set; get; }
        public string NoiCapHoChieu { set; get; }
        public string NgayCap { set; get; }
        public string NgayHetHanHoChieu { set; get; }
        public string SoTheCanCuoc { set; get; }
        public string DienThoaiDiDong { set; get; }
        public string DienThoaiNha { set; get; }
        public string DienThoaiDiDong2 { set; get; }
        public string Email { set; get; }
        public string QuocGiaThuongTru { set; get; }
        public string TinhThanhCode { set; get; }
        public string TinhThanh { set; get; }
        public string QuanHuyenCode { set; get; }
        public string QuanHuyen { set; get; }
        public string PhuongXaCode { set; get; }
        public string PhuongXa { set; get; }
        public string DiaChiThuongTru { set; get; }
        public string QuocGiaCMND { set; get; }
        public string TinhThanhCMNDCode { set; get; }
        public string TinhThanhCMND { set; get; }
        public string QuanHuyenCMNDCode { set; get; }
        public string QuanHuyenCMND { set; get; }
        public string PhuongXaCMNDCode { set; get; }
        public string PhuongXaCMND { set; get; }
        public string DiaChiCMND { set; get; }
        public string QuocGiaTamTru { set; get; }
        public string TinhThanhTamTruCode { set; get; }
        public string TinhThanhTamTru { set; get; }
        public string QuanHuyenTamTruCode { set; get; }
        public string QuanHuyenTamTru { set; get; }
        public string PhuongXaTamTruCode { set; get; }
        public string PhuongXaTamTru { set; get; }
        public string DiaChiThuongTruTamTru { set; get; }
        public string TinhTrangSucKhoe { set; get; }
        public string ChieuCao { set; get; }
        public string CanNang { set; get; }
        public string MatTrai { set; get; }
        public string MatPhai { set; get; }
        public string BenhLy { set; get; }
        public string HuyetAp { set; get; }
        public string NhipTim { set; get; }
        public string BangLaiXe { set; get; }
        public string Status { set; get; }
        public string CreateBy { set; get; }
        public string CreateDate { set; get; }
        public string ModifyBy { set; get; }
        public string ModifyDate { set; get; }
    }

    public class Obj_ThongTinNhanSu
    {
        public string ttcn_Ma_Nhan_Vien { set; get; }
        public string ttcn_Ho_Ten { set; get; }
	    public string ttcn_Cong_Ty { set; get; }
	    public string ttcn_Khoi { set; get; }
	    public string ttcn_Phong_Ban { set; get; }
	    public string ttcn_Bo_Phan { set; get; }
	    public string ttcv_Chuc_Danh_Hien_Tai { set; get; }
	    public string ttcv_Ngay_Bo_Nhiem { set; get; }
        public string ttcv_Quyet_Dinh_Bo_Nhiem { set; get; }
	    public string ttcv_Che_Do_Lam_Viec { set; get; }
	    public string ttcv_Dia_Diem_Lam_Viec { set; get; }
	    public string ttlv_Tinh_Trang_Lam_Viec { set; get; }
	    public string ttlv_Ngay_Vao_Cong_Ty { set; get; }
	    public string ttlv_Loai_Hd_Hien_Tai { set; get; }
	    public string ttlv_Ngay_Het_Hd_Hien_Tai { set; get; }
	    public string ttlv_Ngay_Nghi_Thai_San { set; get; }
	    public string ttlv_Ngay_Di_Lam_Lai { set; get; }
	    public decimal ltv_Luong_P1 { set; get; }
        public decimal ltv_Luong_P2 { set; get; }
        public decimal ltv_Luong_P3 { set; get; }
        public decimal ltv_Phu_Cap_Xang_Xe { set; get; }
        public decimal ltv_Phu_Cap_Dien_Thoai { set; get; }
        public decimal ltv_Phu_Cap_Khac { set; get; }
        public decimal lct_Luong_P1 { set; get; }
        public decimal lct_Luong_Bhxh { set; get; }
        public decimal lct_Luong_P2 { set; get; }
        public decimal lct_Luong_P3 { set; get; }
        public decimal lct_Phu_Cap_Xang_Xe { set; get; }
        public decimal lct_Phu_Cap_Dien_Thoai { set; get; }
        public decimal lct_Phu_Cap_Khac { set; get; }
        public string tdl_So_Quyet_Dinh { set; get; }
	    public string tdl_Ngay_Thay_Doi { set; get; }
	    public string tdl_Ly_Do_Thay_Doi { set; get; }
	    public decimal tdl_Luong_P1_Moi { set; get; }
        public decimal tdl_Luong_P2_Moi { set; get; }
        public decimal tdl_Luong_P3_Moi { set; get; }
        public decimal tdl_Phu_Cap_Xang_Xe { set; get; }
        public decimal tdl_Phu_Cap_Dien_Thoai { set; get; }
        public decimal tdl_Phu_Cap_Khac { set; get; }
        public string tdct_So_Quyet_Dinh { set; get; }
	    public string tdct_Ngay_Dieu_Chuyen { set; get; }
	    public string tdct_Chuc_Danh_Cu { set; get; }
	    public string tdct_Phong_Ban_Cu { set; get; }
	    public string tdct_Bo_Phan_Cu { set; get; }
	    public string tdct_Chuc_Danh_Moi { set; get; }
	    public string tdct_Phong_Ban_Moi { set; get; }
	    public string tdct_Bo_Phan_Moi { set; get; }
	    public decimal tdct_Muc_Luong_Moi { set; get; }
        public string ltd_Tuyen_Moi { set; get; }
	    public string ltd_Nghi_Quay_Lai { set; get; }
	    public string ltd_Thai_San_Lam_Lai { set; get; }
	    public string td_Trinh_Do { set; get; }
	    public string td_Chuyen_Nganh { set; get; }
	    public string td_Truong_Dao_Tao { set; get; }
	    public decimal td_Nam_Tot_Nghiep { set; get; }
        public string cmnd_So_Cmnd_Cccd { set; get; }
	    public string cmnd_Noi_Cap { set; get; }
	    public string cmnd_Ngay_Cap { set; get; }
	    public string cmnd_Dia_Chi_Tam_Tru { set; get; }
	    public string cmnd_Dia_Chi_Thuong_Tru { set; get; }
	    public string nlh_Ho_Ten { set; get; }
	    public string nlh_So_Dien_Thoai { set; get; }
	    public string nlh_Email { set; get; }
	    public string Tinh_Trang_Hon_Nhan { set; get; }
	    public string cc_Ho_Ten_Con_1 { set; get; }
	    public string cc_Ngay_Sinh1 { set; get; }
	    public string cc_Ho_Ten_Con_2 { set; get; }
	    public string cc_Ngay_Sinh2 { set; get; }
	    public string clhs_So_Yeu_Ly_Lich { set; get; }
	    public string clhs_Cmnd_Cccd { set; get; }
	    public string clhs_So_Ho_Khau { set; get; }
	    public string clhs_Bang_Cap { set; get; }
	    public string clhs_Giay_Kham_Suc_Khoe { set; get; }
	    public string clhs_Luu_Quyen_So { set; get; }
	    public string ttcl_So_Tai_Khoan_1 { set; get; }
	    public string ttcl_Ngan_Hang_1 { set; get; }
	    public string ttcl_So_Tai_Khoan_2 { set; get; }
	    public string ttcl_Ngan_Hang_2 { set; get; }
	    public string ttcl_So_Tai_Khoan_3 { set; get; }
	    public string ttcl_Ngan_Hang_3 { set; get; }
	    public string ttcl_Email_Chuyen_Luong { set; get; }
	    public string ttcl_Ma_So_Thue_Tncn { set; get; }
	    public string bhxh_So_So_Bhxh { set; get; }
	    public decimal bhxh_So_Nguoi_Phu_Thuoc { set; get; }
        public string nv_Ngay_Nhan_Don { set; get; }
	    public string nv_Nguon_Tiep_Nhan { set; get; }
	    public string nv_Ly_Do_Nghi_Viec { set; get; }
	    public string nv_Tinh_Trang_Ban_Giao { set; get; }
	    public string nv_Ngay_Ra_Qdnv { set; get; }
	    public string clnv_Don_Xin_Nghi_Viec { set; get; }
	    public string clnv_Quan_Ly_Xac_Nhan { set; get; }
	    public string clnv_Hanh_Chinh { set; get; }
	    public string clnv_Ke_Toan { set; get; }
	    public string clnv_Kiem_Soat_Noi_Bo { set; get; }
	    public string clnv_Cntt { set; get; }
	    public string clnv_Kiem_Ke { set; get; }

    }

    public class empinfo
    {
        public string MaNV { set; get; }
        public string TenNV { set; get; }
        public string MaCD { set; get; }
        public string TenCD { set; get; }
        public string MaCB { set; get; }
        public string TenCB { set; get; }

    }

    public class pccvinfo
    {
        public string MaNV { set; get; }
        public string MaCV { set; get; }
        public int Status { set; get; }

    }

    public class khaibaocongviechanhdong
    {
        public int ID { set; get; }
        public string Tenhanhdong { set; get; }
        public string TenCV { set; get; }
        public string MaCV { set; get; }
        public string MaChucdanh { set; get; }
        public string Chitieu1 { set; get; }
        public string Chitieu2 { set; get; }
        public string Chitieu3 { set; get; }
        public string Chitieu4 { set; get; }
        public string Chitieu5 { set; get; }
        public string Chitieu6 { set; get; }
        public string Chitieu7 { set; get; }
        public string Chitieu8 { set; get; }
        public string Chitieu9 { set; get; }
        public string Chitieu10 { set; get; }
        public string Tansuat { set; get; }
        public string Thoigian { set; get; }
        public string Tongthoigian { set; get; }

    }

}