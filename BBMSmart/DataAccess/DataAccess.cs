using Lib.Utils.Package;
using Microsoft.AspNetCore.Authentication;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductAllTool.DataAccess.DataConnection;
using ProductAllTool.Models;
using ProductAllTool.Models.comparePrice;
using ProductAllTool.Models.ScoreStore;
using ProductAllTool.Models.SourceProduct;
using ProductAllTool.Models.SpaceMan;
using ProductAllTool.Models.StoreLayout;
using ProductAllTool.Models.ToDoList;
using ProductAllTool.Models.ManageSales;
using ProductAllTool.Models.ManageUser;
using ProductAllTool.Views.ScoreStore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using ProductAllTool.Models.Approve;
using ProductAllTool.Models.Po;
using ProductAllTool.Models.StockTransfer;
using ProductAllTool.Models.HRM;
using ProductAllTool.Models.QLNCC;
using static ProductAllTool.Models.QLNCC.objVendor;
using System.Globalization;
using ProductAllTool.Models.Report;

namespace ProductAllTool.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class DataAccess
    {
        private static string strCon = ConfigurationManager.AppSettings.Get("strConn");
        private static string strConn1101 = ConfigurationManager.AppSettings.Get("strConn1.101");
        private static string strConnDWH = ConfigurationManager.AppSettings.Get("strConnDWH");


        //public static List<ItemPushSales> SP_BBMSMART_PO_GETLIST_PUSHSALES_HANGTANG_Mobile(string uid, decimal SumTotalPushSales, string ItemCode, string Type)
        //{

        //    List<ItemPushSales> it_r = new List<ItemPushSales>();
        //    using (var con = new SqlConnection(strCon))
        //    {
        //        con.Open();

        //        try
        //        {
        //            DataTable dt = new DataTable();
        //            dt.Clear();
        //            dt.Columns.Add("ItemNo", typeof(string));
        //            dt.Columns.Add("GBL", typeof(string));
        //            dt.Columns.Add("SoLuong", typeof(string));
        //            dt.Columns.Add("NextStep", typeof(string));

        //            //DataTable dtcart = new DataTable();
        //            DataRow dr = dt.NewRow();
        //            dr["ItemNo"] = "100023";
        //            dr["GBL"] = "405000";
        //            dr["SoLuong"] = "1";
        //            dr["NextStep"] = "Push Sale";
        //            dt.Rows.Add(dr);


        //            //dt.Rows.Add("100023", 405000, 1, "FALSE");
        //            //dt.Rows.Add("114544", 140000, 1, "Push Sale");

        //            SqlCommand cmd = new SqlCommand("SP_BBMSMART_PO_GETLIST_PUSHSALES_HANGTANG_Mobile", con);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.Add(new SqlParameter("uid", uid));
        //            cmd.Parameters.Add(new SqlParameter("SumTotalPushSales", SumTotalPushSales));
        //            cmd.Parameters.Add(new SqlParameter("ItemCode", ItemCode));
        //            cmd.Parameters.Add(new SqlParameter("Type", Type));
        //            SqlParameter dtparam = cmd.Parameters.AddWithValue("@ProductArr", dt);
        //            dtparam.SqlDbType = SqlDbType.Structured;
        //            var reader = cmd.ExecuteReader();


        //            while (reader.Read())
        //            {
        //                ItemPushSales it = new ItemPushSales
        //                {
        //                    MaHang = reader["MaHang"].ToString(),
        //                    TenHang = reader["TenHang"].ToString(),
        //                    GBL = reader["GBL"].ToString(),
        //                    StoreNo = reader["StoreNo"].ToString(),
        //                    SlTon = reader["SlTon"].ToString(),
        //                    HinhAnh = reader["HinhAnh"].ToString(),
        //                    link = reader["link"].ToString(),
        //                    NextStep = reader["NextStep"].ToString()
        //                };

        //                it_r.Add(it);
        //            }
        //            con.Close();

        //            return it_r;

        //        }
        //        catch (Exception ex)
        //        {
        //            con.Close();
        //            LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBMSMART_PO_GETLIST_PUSHSALES_HANGTANG_Mobile");
        //            return it_r;
        //        }
        //    }
        //}

        public static bool SP_BIBOSMART_Insert_Coupon_Marcom(string uid, objCoupon it)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_Insert_Coupon_Marcom", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("AccountNo", it.AccountNo));
                    cmd.Parameters.Add(new SqlParameter("PhoneNo", it.PhoneNo));
                    cmd.Parameters.Add(new SqlParameter("Coupon", it.Coupon));
                    cmd.Parameters.Add(new SqlParameter("CampaignCode", it.CampaignCode));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", uid));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_Insert_Coupon_Marcom");
                return false;
            }
        }

        public static List<Marcom_CouponCode_ERP> GetList_Marcom_CouponCode_ERP(string CouponCode)
        {
            List<Marcom_CouponCode_ERP> it_r = new List<Marcom_CouponCode_ERP>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetList_Marcom_CouponCode_ERP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("CouponCode", CouponCode));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Marcom_CouponCode_ERP it = new Marcom_CouponCode_ERP
                        {
                            CouponCode = reader["CouponCode"].ToString(),
                            MACOUPON = reader["MACOUPON"].ToString(),
                            Price = reader["Price"].ToString(),
                            DateKetThuc = reader["DateKetThuc"].ToString(),
                            status = reader["status"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetList_Marcom_CouponCode_ERP");
                    return it_r;
                }
            }
        }

        public static bool SP_BIBOSMART_MS_ChangeStatusMarcom(string userId, string MaChienDich, string status)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_MS_ChangeStatusMarcom", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("CreateBy", userId));
                    cmd.Parameters.Add(new SqlParameter("MaChienDich", MaChienDich));
                    cmd.Parameters.Add(new SqlParameter("status", status));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_MS_ChangeStatusMarcom");
                    return false;
                }
            }
        }
        public static DataTable SP_BIBOSMART_MS_GetListApproveMarcom(string chiendich, string LoaiHinh, string NhomKH, string CTKM, string NgayGui, string Status)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_MS_GetListApproveMarcom", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;

                    cmd.Parameters.Add(new SqlParameter("chiendich", chiendich));
                    cmd.Parameters.Add(new SqlParameter("LoaiHinh", LoaiHinh));
                    cmd.Parameters.Add(new SqlParameter("NhomKH", NhomKH));
                    cmd.Parameters.Add(new SqlParameter("CTKM", CTKM));
                    cmd.Parameters.Add(new SqlParameter("NgayGui", NgayGui));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_MS_GetListApproveMarcom");
                return ds.Tables[0];
            }
        }
        public static DataTable SP_BIBOSMART_MS_GetListMarcom(string chiendich, string LoaiHinh, string NhomKH, string CTKM, string TuNgay, string Status, string DenNgay)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_MS_GetListMarcom", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;

                    cmd.Parameters.Add(new SqlParameter("chiendich", chiendich));
                    cmd.Parameters.Add(new SqlParameter("LoaiHinh", LoaiHinh));
                    cmd.Parameters.Add(new SqlParameter("NhomKH", NhomKH));
                    cmd.Parameters.Add(new SqlParameter("CTKM", CTKM));
                    cmd.Parameters.Add(new SqlParameter("TuNgay", TuNgay));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    cmd.Parameters.Add(new SqlParameter("DenNgay", DenNgay));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_MS_GetListMarcom");
                return ds.Tables[0];
            }
        }

        public static string GetCodeMarcom_MCD()
        {
            string chuoi = "0";
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_ManageSales_GetCode_CampaignMarcom", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        chuoi = reader["Code"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    return chuoi;
                }
            }
            return chuoi;
        }

        public static List<objCombox> GetCodeMarcom()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_ManageSales_GetCode_CampaignMarcom", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetCodeMarcom");
                    return it_r;
                }
            }
        }
        public static bool sp_BBM_SMART_MS_UPDATE_MaCTKM_Marcom(string MaChienDich, string codeKM)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_SMART_MS_UPDATE_MaCTKM_Marcom", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("MaChienDich", MaChienDich.Trim()));
                    cmd.Parameters.Add(new SqlParameter("MaCTKM", codeKM));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_SMART_MS_UPDATE_MaCTKM_Marcom");
                    return false;
                }
            }
        }

        public static bool sp_BBM_SMART_MS_UPDATE_CampaignMarcom(
        string MaChienDich,
        string LoaiHinhTiepCan,
        string NhomKH,
        string BrandCode,
        string FunctionCode,
        string BrandName,
        string FunctionName,
        string MaTinh,
        string StoreCode,
        string TenTinh,
        string StoreName,
        string TaiApp,
        string startDate,
        string EndDate,
        string TimeHour,
        string TypeSMS,
        string TimeSend,
        string DangMoApp,
        string phamvi,
        string ThietBi,
        string LinkWeb,
        string DoanhThu,
        string ChiPhi,
        string displayMarcom,
        string AppCTKM,
        string TieuDe,
        string NoiDung,
        string MoTa,
        string linkImage,
        string createBy,
        string LocNgayTao,
        string LocNgayDen,
        string WeeklyTime,
        string TanSuat,

        string CouponCode,
        string TongCoupon,
        string SoTienCoupon,
        string NgayKetThucCoupon,


        //Case
        string TypeCase,
        string TypePopup,
        string priority,
        string StatusPopup,

        string repeat,
        string delay,
        string interval,

        string TitleAction,
        string PositionAction


           )
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_SMART_MS_UPDATE_CampaignMarcom", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("MaChienDich", MaChienDich.Trim()));
                    cmd.Parameters.Add(new SqlParameter("LoaiHinh", LoaiHinhTiepCan));
                    cmd.Parameters.Add(new SqlParameter("NhomKH", NhomKH));
                    cmd.Parameters.Add(new SqlParameter("BrandCode", BrandCode));
                    cmd.Parameters.Add(new SqlParameter("FunctionCode", FunctionCode));

                    cmd.Parameters.Add(new SqlParameter("BrandName", BrandName));
                    cmd.Parameters.Add(new SqlParameter("FunctionName", FunctionName));

                    cmd.Parameters.Add(new SqlParameter("MaTinh", MaTinh));
                    cmd.Parameters.Add(new SqlParameter("StoreCode", StoreCode));

                    cmd.Parameters.Add(new SqlParameter("TenTinh", TenTinh));
                    cmd.Parameters.Add(new SqlParameter("StoreName", StoreName));

                    cmd.Parameters.Add(new SqlParameter("TaiApp", TaiApp));

                    cmd.Parameters.Add(new SqlParameter("StartDate", DateTime.Parse(startDate)));
                    if (TimeSend == "daily" || TimeSend == "Weekly")
                    {
                        cmd.Parameters.Add(new SqlParameter("EndDate", DateTime.Parse(EndDate)));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("EndDate", DBNull.Value));
                    }

                    cmd.Parameters.Add(new SqlParameter("TimeHour", TimeHour));
                    cmd.Parameters.Add(new SqlParameter("TypeSMS", TypeSMS));
                    cmd.Parameters.Add(new SqlParameter("TimeSend", TimeSend));
                    cmd.Parameters.Add(new SqlParameter("DangMoApp", DangMoApp));
                    cmd.Parameters.Add(new SqlParameter("PhamVi", phamvi));
                    cmd.Parameters.Add(new SqlParameter("ThietBi", ThietBi));
                    cmd.Parameters.Add(new SqlParameter("LinkWeb", LinkWeb));
                    cmd.Parameters.Add(new SqlParameter("DoanhThu", decimal.Parse(DoanhThu != "" ? DoanhThu : "0")));
                    cmd.Parameters.Add(new SqlParameter("ChiPhi", decimal.Parse(ChiPhi != "" ? ChiPhi : "0")));
                    cmd.Parameters.Add(new SqlParameter("Display", displayMarcom));
                    cmd.Parameters.Add(new SqlParameter("CTKM", AppCTKM));
                    cmd.Parameters.Add(new SqlParameter("TieuDe", TieuDe));
                    cmd.Parameters.Add(new SqlParameter("NoiDung", NoiDung));
                    cmd.Parameters.Add(new SqlParameter("MoTa", MoTa));
                    cmd.Parameters.Add(new SqlParameter("LinkImage", linkImage));
                    cmd.Parameters.Add(new SqlParameter("createBy", createBy));
                    if (String.IsNullOrWhiteSpace(LocNgayTao))
                    {
                        cmd.Parameters.Add(new SqlParameter("LocNgayTao", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("LocNgayTao", DateTime.Parse(LocNgayTao)));
                    }

                    if (String.IsNullOrWhiteSpace(LocNgayDen))
                    {
                        cmd.Parameters.Add(new SqlParameter("LocNgayDen", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("LocNgayDen", DateTime.Parse(LocNgayDen)));
                    }
                    cmd.Parameters.Add(new SqlParameter("WeeklyTime", WeeklyTime));
                    cmd.Parameters.Add(new SqlParameter("TanSuat", TanSuat));




                    cmd.Parameters.Add(new SqlParameter("CouponCode", CouponCode));
                    cmd.Parameters.Add(new SqlParameter("TongCoupon", decimal.Parse(TongCoupon != "" ? TongCoupon : "0")));
                    cmd.Parameters.Add(new SqlParameter("SoTienCoupon", decimal.Parse(SoTienCoupon != "" ? SoTienCoupon : "0")));
                    if (String.IsNullOrWhiteSpace(NgayKetThucCoupon))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayKetThucCoupon", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayKetThucCoupon", DateTime.Parse(NgayKetThucCoupon)));
                    }
                    // case
                    cmd.Parameters.Add(new SqlParameter("TypeCase", TypeCase));
                    cmd.Parameters.Add(new SqlParameter("TypePopup", TypePopup));
                    cmd.Parameters.Add(new SqlParameter("priority", priority));
                    cmd.Parameters.Add(new SqlParameter("StatusPopup", StatusPopup));

                    cmd.Parameters.Add(new SqlParameter("repeat", repeat));
                    cmd.Parameters.Add(new SqlParameter("delay", delay));
                    cmd.Parameters.Add(new SqlParameter("interval", interval));

                    cmd.Parameters.Add(new SqlParameter("TitleAction", TitleAction));
                    cmd.Parameters.Add(new SqlParameter("PositionAction", PositionAction));


                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_SMART_MS_UPDATE_CampaignMarcom");
                    return false;
                }
            }
        }
        public static bool sp_BBM_SMART_MS_INSERT_CampaignMarcom(
        string MaChienDich,
        string NhomKH,
        string BrandCode,
        string BrandName,
        string FunctionCode,
        string FunctionName,
        string MaTinh,
        string TenTinh,
        string StoreCode,
        string StoreName,
        string TaiApp,
        string LoaiHinhTiepCan,
        string startDate,
        string EndDate,
        string TimeHour,
        string TypeSMS,
        string TimeSend,
        string DangMoApp,
        string phamvi,
        string ThietBi,
        string LinkWeb,
        string DoanhThu,
        string ChiPhi,
        string displayMarcom,
        string AppCTKM,
        string TieuDe,
        string NoiDung,
        string MoTa,
        string linkImage,
        string createBy,
        string MaCDRemind,
        string LocNgayTao,
        string LocNgayDen,
        string WeeklyTime,
        string TanSuat,
        string CouponCode,
        string TongCoupon,
        string SoTienCoupon,
        string NgayKetThucCoupon,


        //Case
        string TypeCase,
        string TypePopup,
        string priority,
        string StatusPopup,

        string repeat,
        string delay,
        string interval,

        string TitleAction,
        string PositionAction

            )
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_SMART_MS_INSERT_CampaignMarcom", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("MaChienDich", MaChienDich.Trim()));
                    cmd.Parameters.Add(new SqlParameter("NhomKH", NhomKH.Trim()));
                    cmd.Parameters.Add(new SqlParameter("BrandCode", BrandCode.Trim()));
                    cmd.Parameters.Add(new SqlParameter("BrandName", BrandName.Trim()));
                    cmd.Parameters.Add(new SqlParameter("FunctionCode", FunctionCode.Trim()));
                    cmd.Parameters.Add(new SqlParameter("FunctionName", FunctionName.Trim()));
                    cmd.Parameters.Add(new SqlParameter("MaTinh", MaTinh.Trim()));
                    cmd.Parameters.Add(new SqlParameter("TenTinh", TenTinh.Trim()));
                    cmd.Parameters.Add(new SqlParameter("StoreCode", StoreCode.Trim()));
                    cmd.Parameters.Add(new SqlParameter("StoreName", StoreName.Trim()));

                    cmd.Parameters.Add(new SqlParameter("TaiApp", TaiApp.Trim()));

                    cmd.Parameters.Add(new SqlParameter("LoaiHinh", LoaiHinhTiepCan));
                    if (TimeSend == "scheduleTime" || TimeSend == "daily" || TimeSend == "Weekly")
                    {
                        cmd.Parameters.Add(new SqlParameter("StartDate", DateTime.Parse(startDate)));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("StartDate", DateTime.Parse("1900-01-01")));
                    }

                    if (TimeSend == "daily" || TimeSend == "Weekly")
                    {
                        cmd.Parameters.Add(new SqlParameter("EndDate", DateTime.Parse(EndDate)));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("EndDate", DBNull.Value));
                    }

                    cmd.Parameters.Add(new SqlParameter("TimeHour", TimeHour));
                    cmd.Parameters.Add(new SqlParameter("TypeSMS", TypeSMS));
                    cmd.Parameters.Add(new SqlParameter("TimeSend", TimeSend));
                    cmd.Parameters.Add(new SqlParameter("DangMoApp", DangMoApp));

                    cmd.Parameters.Add(new SqlParameter("PhamVi", phamvi));
                    cmd.Parameters.Add(new SqlParameter("ThietBi", ThietBi));
                    cmd.Parameters.Add(new SqlParameter("LinkWeb", LinkWeb));
                    cmd.Parameters.Add(new SqlParameter("DoanhThu", decimal.Parse(DoanhThu != "" ? DoanhThu : "0")));
                    cmd.Parameters.Add(new SqlParameter("ChiPhi", decimal.Parse(ChiPhi != "" ? ChiPhi : "0")));
                    cmd.Parameters.Add(new SqlParameter("Display", displayMarcom));
                    cmd.Parameters.Add(new SqlParameter("CTKM", AppCTKM));
                    cmd.Parameters.Add(new SqlParameter("TieuDe", TieuDe));
                    cmd.Parameters.Add(new SqlParameter("NoiDung", NoiDung));
                    cmd.Parameters.Add(new SqlParameter("MoTa", MoTa));
                    cmd.Parameters.Add(new SqlParameter("LinkImage", linkImage));
                    cmd.Parameters.Add(new SqlParameter("createBy", createBy));
                    cmd.Parameters.Add(new SqlParameter("MaCDRemind", MaCDRemind));

                    if (String.IsNullOrWhiteSpace(LocNgayTao))
                    {
                        cmd.Parameters.Add(new SqlParameter("LocNgayTao", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("LocNgayTao", DateTime.Parse(LocNgayTao)));
                    }

                    if (String.IsNullOrWhiteSpace(LocNgayDen))
                    {
                        cmd.Parameters.Add(new SqlParameter("LocNgayDen", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("LocNgayDen", DateTime.Parse(LocNgayDen)));
                    }
                    cmd.Parameters.Add(new SqlParameter("WeeklyTime", WeeklyTime));
                    cmd.Parameters.Add(new SqlParameter("TanSuat", TanSuat));

                    cmd.Parameters.Add(new SqlParameter("CouponCode", CouponCode));
                    cmd.Parameters.Add(new SqlParameter("TongCoupon", decimal.Parse(TongCoupon != "" ? TongCoupon : "0")));
                    cmd.Parameters.Add(new SqlParameter("SoTienCoupon", decimal.Parse(SoTienCoupon != "" ? SoTienCoupon : "0")));
                    if (String.IsNullOrWhiteSpace(NgayKetThucCoupon))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayKetThucCoupon", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayKetThucCoupon", DateTime.Parse(NgayKetThucCoupon)));
                    }
                    // case
                    cmd.Parameters.Add(new SqlParameter("TypeCase", TypeCase));
                    cmd.Parameters.Add(new SqlParameter("TypePopup", TypePopup));
                    cmd.Parameters.Add(new SqlParameter("priority", priority));
                    cmd.Parameters.Add(new SqlParameter("StatusPopup", StatusPopup));

                    cmd.Parameters.Add(new SqlParameter("repeat", repeat));
                    cmd.Parameters.Add(new SqlParameter("delay", delay));
                    cmd.Parameters.Add(new SqlParameter("interval", interval));

                    cmd.Parameters.Add(new SqlParameter("TitleAction", TitleAction));
                    cmd.Parameters.Add(new SqlParameter("PositionAction", PositionAction));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_SMART_MS_INSERT_CampaignMarcom");
                    return false;
                }
            }
        }

        public static bool sp_BBM_SMART_MS_INSERT_CampaignMarcom_Remind(
       string MaChienDich,
       string NhomKH,
       //string BrandCode,
       //string BrandName,
       //string FunctionCode,
       //string FunctionName,
       //string TaiApp,
       string LoaiHinhTiepCan,
       string startDate,
       string TimeHour,
       string TypeSMS,
       string TimeSend,
       string DangMoApp,
       string phamvi,
       string ThietBi,
       string LinkWeb,
       string DoanhThu,
       string ChiPhi,
       string displayMarcom,
       string AppCTKM,
       string TieuDe,
       string NoiDung,
       string linkImage,
       string createBy,
       string MaCDRemind
           )
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_SMART_MS_INSERT_CampaignMarcom_Remind", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("MaChienDich", MaChienDich.Trim()));
                    cmd.Parameters.Add(new SqlParameter("NhomKH", NhomKH.Trim()));
                    //cmd.Parameters.Add(new SqlParameter("BrandCode", BrandCode.Trim()));
                    //cmd.Parameters.Add(new SqlParameter("BrandName", BrandName.Trim()));
                    //cmd.Parameters.Add(new SqlParameter("FunctionCode", FunctionCode.Trim()));
                    //cmd.Parameters.Add(new SqlParameter("FunctionName", FunctionName.Trim()));

                    //cmd.Parameters.Add(new SqlParameter("TaiApp", TaiApp.Trim()));

                    cmd.Parameters.Add(new SqlParameter("LoaiHinh", LoaiHinhTiepCan));
                    if (TimeSend == "scheduleTime")
                    {
                        cmd.Parameters.Add(new SqlParameter("StartDate", DateTime.Parse(startDate)));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("StartDate", DateTime.Parse("1900-01-01")));
                    }

                    cmd.Parameters.Add(new SqlParameter("TimeHour", TimeHour));
                    cmd.Parameters.Add(new SqlParameter("TypeSMS", TypeSMS));
                    cmd.Parameters.Add(new SqlParameter("TimeSend", TimeSend));
                    cmd.Parameters.Add(new SqlParameter("DangMoApp", DangMoApp));

                    cmd.Parameters.Add(new SqlParameter("PhamVi", phamvi));
                    cmd.Parameters.Add(new SqlParameter("ThietBi", ThietBi));
                    cmd.Parameters.Add(new SqlParameter("LinkWeb", LinkWeb));
                    cmd.Parameters.Add(new SqlParameter("DoanhThu", decimal.Parse(DoanhThu != "" ? DoanhThu : "0")));
                    cmd.Parameters.Add(new SqlParameter("ChiPhi", decimal.Parse(ChiPhi != "" ? ChiPhi : "0")));
                    cmd.Parameters.Add(new SqlParameter("Display", displayMarcom));
                    cmd.Parameters.Add(new SqlParameter("CTKM", AppCTKM));
                    cmd.Parameters.Add(new SqlParameter("TieuDe", TieuDe));
                    cmd.Parameters.Add(new SqlParameter("NoiDung", NoiDung));
                    cmd.Parameters.Add(new SqlParameter("LinkImage", linkImage));
                    cmd.Parameters.Add(new SqlParameter("createBy", createBy));
                    cmd.Parameters.Add(new SqlParameter("MaCDRemind", MaCDRemind));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_SMART_MS_INSERT_CampaignMarcom_Remind");
                    return false;
                }
            }
        }

        #region QLVH

        public static DataTable SP_BBSmart_GetList_DatHangBoSung(string RSMCode, string ASMCode, string MaCH, string GroupCode, string BrandCode, string MaHang)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_GetList_TruongNganhHang", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;

                    cmd.Parameters.Add(new SqlParameter("RSMCode", RSMCode));
                    cmd.Parameters.Add(new SqlParameter("ASMCode", ASMCode));
                    cmd.Parameters.Add(new SqlParameter("MaCH", MaCH));
                    cmd.Parameters.Add(new SqlParameter("GroupCode", GroupCode));
                    cmd.Parameters.Add(new SqlParameter("BrandCode", BrandCode));
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBSmart_GetList_DatHangBoSung");
                return ds.Tables[0];
            }
        }

        public static DataTable sp_BBSmart_GetList_TruongNganhHang(string RSMCode, string ASMCode, string MaCH, string GroupCode, string Brand, string MaHang, string strStore)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_GetList_TruongNganhHang", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;

                    cmd.Parameters.Add(new SqlParameter("RSMCode", RSMCode));
                    cmd.Parameters.Add(new SqlParameter("ASMCode", ASMCode));
                    cmd.Parameters.Add(new SqlParameter("MaCH", MaCH));
                    cmd.Parameters.Add(new SqlParameter("GroupCode", GroupCode));
                    cmd.Parameters.Add(new SqlParameter("Brand", Brand));
                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("strStore", strStore));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_GetList_TruongNganhHang");
                return ds.Tables[0];
            }
        }
        public static List<objCombox> sp_BBSmart_GetList_Combobox(string procedure)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(procedure, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), procedure);
                    return it_r;
                }
            }
        }


        public static List<objCombox> sp_BBSmart_GetList_Item()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_GetList_Item", con);//
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_GetList_Item");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_BBSmart_GetList_Item_filter()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_GetList_Item_filter", con);//sp_BBSmart_GetList_Item
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_GetList_Item");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_qlkd_getMahang()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_getMahang", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_qlkd_getMahang");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_qlkd_getMahang_View()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_getMahang_View", con);//
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_qlkd_getMahang");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_BBSmart_GetList_Vung()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_GetList_Vung", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_GetList_Vung");
                    return it_r;
                }
            }
        }
        public static List<objComboxKhuVuc> sp_BBSmart_GetList_KhuVuc()
        {
            List<objComboxKhuVuc> it_r = new List<objComboxKhuVuc>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_GetList_KhuVuc", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objComboxKhuVuc it = new objComboxKhuVuc
                        {
                            RSM_Code = reader["RSM_Code"].ToString(),
                            RSM_Name = reader["RSM_Name"].ToString(),
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_GetList_KhuVuc");
                    return it_r;
                }
            }
        }

        public static DataTable SP_BBSmart_GetList_ThucDayDoanhSoCH(string userid, string RSMCode, string ASMCode, string MaCH, string TenCH, string MaTinh, string Fromvalue, string Tovalue, string SoThangHoatDong)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBSmart_GetList_ThucDayDoanhSoCH", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("RSMCode", RSMCode));
                    cmd.Parameters.Add(new SqlParameter("ASMCode", ASMCode));
                    cmd.Parameters.Add(new SqlParameter("MaCH", MaCH));
                    cmd.Parameters.Add(new SqlParameter("TenCH", TenCH));
                    cmd.Parameters.Add(new SqlParameter("MaTinh", MaTinh));
                    cmd.Parameters.Add(new SqlParameter("Fromvalue", int.Parse(Fromvalue)));
                    cmd.Parameters.Add(new SqlParameter("Tovalue", int.Parse(Tovalue)));
                    cmd.Parameters.Add(new SqlParameter("SoThangHoatDong", SoThangHoatDong));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBSmart_GetList_ThucDayDoanhSoCH");
                return ds.Tables[0];
            }
        }

        #endregion
        #region QLNCC

        public static DataTable SP_BBSMART_QLNCC_GETLIST_QLNCC_02(string NguonNhapCode, string functionCode, string Division, string VendorNo, string productNo, string Brand, string hanhdong)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBSMART_QLNCC_GETLIST_QLNCC_02", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;

                    cmd.Parameters.Add(new SqlParameter("NguonNhapCode", NguonNhapCode));
                    cmd.Parameters.Add(new SqlParameter("functionCode", functionCode));
                    cmd.Parameters.Add(new SqlParameter("Division", Division));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("productNo", productNo));
                    cmd.Parameters.Add(new SqlParameter("Brand", Brand));
                    cmd.Parameters.Add(new SqlParameter("HanhDong", hanhdong));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                    return ds.Tables[0];

                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBSMART_QLNCC_GETLIST_QLNCC_02");
                return ds.Tables[0];
            }
        }

        public static DataTable SP_BBSMART_QLNCC_GETLIST_QLNCC_01(string NguonNhapCode, string Status, string Division, string VendorNo, string ContractNo, string Brand, string LoaiHD)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBSMART_QLNCC_GETLIST_QLNCC_01", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;

                    cmd.Parameters.Add(new SqlParameter("NguonNhapCode", NguonNhapCode));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    cmd.Parameters.Add(new SqlParameter("Division", Division));
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    cmd.Parameters.Add(new SqlParameter("ContractNo", ContractNo));
                    cmd.Parameters.Add(new SqlParameter("Brand", Brand));
                    cmd.Parameters.Add(new SqlParameter("LoaiHD", LoaiHD));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBSMART_QLNCC_GETLIST_QLNCC_01");
                return ds.Tables[0];
            }
        }

        public static List<objCombox> SP_BBSMART_QLNCC_GETLIST_NCC()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBSMART_QLNCC_GETLIST_NCC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBSMART_QLNCC_GETLIST_NCC");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_BBSMART_QLNCC_GETLIST_BRAND01(string VendorNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBSMART_QLNCC_GETLIST_BRAND01", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBSMART_QLNCC_GETLIST_BRAND01");
                    return it_r;
                }
            }
        }

        public static List<objProductandBrand> SP_BBSMART_QLNCC_GETLIST_Product(string VendorNo)
        {
            List<objProductandBrand> it_r = new List<objProductandBrand>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBSMART_QLNCC_GETLIST_Product", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objProductandBrand it_ = new objProductandBrand
                        {
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBSMART_QLNCC_GETLIST_Product");
                    return it_r;
                }
            }
        }

        public static List<objProductandBrand> SP_BBSMART_QLNCC_GETLIST_Brand(string VendorNo)
        {
            List<objProductandBrand> it_r = new List<objProductandBrand>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBSMART_QLNCC_GETLIST_Brand", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("VendorNo", VendorNo));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objProductandBrand it_ = new objProductandBrand
                        {
                            BrandCode = reader["BrandCode"].ToString(),
                            BrandName = reader["BrandName"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBSMART_QLNCC_GETLIST_Brand");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_BBSMART_QLNCC_GETLIST_NguonNhap()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBSMART_QLNCC_GETLIST_NguonNhap", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBSMART_QLNCC_GETLIST_NguonNhap");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_BBSmart_getloaihinhhoptac()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_getloaihinhhoptac", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Loại hình hợp tác"].ToString(),
                            Name = reader["Loại hình hợp tác"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_getloaihinhhoptac");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_BBSmart_QLNCC_GET_DIV()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_QLNCC_GET_DIV", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Div"].ToString(),
                            Name = reader["Div"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_QLNCC_GET_DIV");
                    return it_r;
                }
            }
        }
        #endregion

        #region ProductIMG_v1
        public static List<ItemWeb> getProduct(string typeFill, string lsSku)
        {
            List<ItemWeb> lts = new List<ItemWeb>();

            LogBuild.CreateLogger("Start get:" + lsSku, "getProduct");

            try
            {
                Console.WriteLine("Openning Connection ...");
                MySqlConnection conn = DBUtils.GetDBConnection();

                conn.Open();

                Console.WriteLine("Connection successful!");

                string sql = @"SELECT
	sku,
	online_name AS 'name',
    HOit.ManufacturerCode,
	HOit.DivisionCode,
	HOit.CategoryCode,
	HOit.GroupCode,
	CASE
WHEN special_to_date >= NOW()
AND NOW() >= special_from_date THEN
	format(special_price, 0)
WHEN LENGTH(price_region) = 0
OR price_region IS NULL THEN
	price
ELSE
	format(
		SUBSTRING_INDEX(
			SUBSTRING_INDEX(price_region, '""', 4),

            '""' ,-1
		),
		0
	)
END AS price,
 CONCAT(prd.base_image, image) AS 'image_link'
FROM
    ncs_product prd
LEFT JOIN tbl_ERP_HO_Item HOit ON HOit.NO = prd.sku
WHERE
    " + typeFill + @" IN(" + lsSku + @")
ORDER BY FIELD(" + typeFill + @"," + lsSku + @")";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                DbDataReader reader = cmd.ExecuteReader();

                #region get all data from database

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ItemWeb it = new ItemWeb
                        {
                            sku = reader.GetValue(0).ToString(),
                            name = reader.GetValue(1).ToString(),
                            ManufacturerCode = reader.GetValue(2).ToString(),
                            DivisionCode = reader.GetValue(3).ToString(),
                            CategoryCode = reader.GetValue(4).ToString(),
                            GroupCode = reader.GetValue(5).ToString(),
                            price = reader.GetValue(6).ToString(),
                            image_link = reader.GetValue(7).ToString()
                        };

                        lts.Add(it);
                    }
                }

                conn.Close();
                #endregion

                LogBuild.CreateLogger(JsonConvert.SerializeObject(lts), "getProduct");

                return lts;
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(ex.ToString(), "getProduct");

                return lts;
            }
        }
        #endregion
        #region ProductIMG_v2


        //run data all fk
        public static List<ItemWeb> getProduct_v2(string typeFill, string dataFill)
        {
            //List<ItemWeb> it_s = new List<ItemWeb>();

            //if (typeFill == "sku")
            //{
            //    var ls_it = dataFill.Split(',');
            //    foreach (var i in ls_it)
            //    {
            //        var sb_it = await crawl_info_Mag(i);
            //        if (sb_it.sku != null)
            //        {
            //            ItemWeb it = new ItemWeb
            //            {
            //                sku = sb_it.sku,
            //                name = sb_it.name,
            //                price = sb_it.price,
            //                image_link = sb_it.image_link
            //            };

            //            it_s.Add(it);
            //        }
            //    }
            //}
            //else
            //{
            //get list from sql
            var ls_bn = sp_ProductTool_ProductIMG_get_sku(typeFill, dataFill);
            //foreach (var i in ls_bn)
            //{
            //    var sb_it = await crawl_info_Mag(i.sku);
            //    if (sb_it.sku != null)
            //    {
            //        ItemWeb it = new ItemWeb
            //        {
            //            sku = sb_it.sku,
            //            name = sb_it.name,
            //            price = sb_it.price,
            //            image_link = sb_it.image_link
            //        };

            //        it_s.Add(it);
            //    }
            //}
            //}

            return ls_bn;
        }

        //get sku by attribute
        public static List<ItemWeb> sp_ProductTool_ProductIMG_get_sku(string typeFill, string dataFill)
        {
            LogBuild.CreateLogger("Start get:" + dataFill + "--------" + dataFill, "getProduct");
            List<ItemWeb> it_s = new List<ItemWeb>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand("sp_ProductTool_ProductIMG_get_sku", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("typeFill", typeFill));
                cmd.Parameters.Add(new SqlParameter("dataFill", dataFill));

                try
                {

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ItemWeb it = new ItemWeb
                        {
                            sku = reader["sku"].ToString(),
                            name = reader["name"].ToString(),
                            price = reader["price"].ToString(),
                            image_link = reader["image_link"].ToString(),
                            url = reader["url"].ToString()
                        };

                        it_s.Add(it);
                    }
                    con.Close();

                    return it_s;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ProductIMG_get_sku");
                    return it_s;
                }
            }

        }

        //crawl web
        public async static Task<ItemWeb> crawl_info_Mag(string sku)
        {
            ItemWeb it = new ItemWeb();

            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer to1ln1hfsst9du6hsfba6ifxtt9u1crt");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:71.0) Gecko/20100101 Firefox/71.0");

                string url = @"https://bibomart.com.vn/rest/all/V1/products/" + sku;

                HttpResponseMessage response = await client.GetAsync(url);

                if ((int)response.StatusCode != 200)
                {
                    LogBuild.CreateLogger(response.StatusCode.ToString(), "crawl_info_Mag");
                    return it;

                }
                else
                {
                    string res = await response.Content.ReadAsStringAsync();

                    var data = JObject.Parse(res);

                    //var rt = (long)data["item"]["price"] / 100000;
                    it.sku = data["sku"].ToString();
                    it.name = data["name"].ToString();
                    it.price = data["price"].ToString();

                    var ls_att = JArray.Parse(data["custom_attributes"].ToString());
                    foreach (var i in ls_att)
                    {
                        if (i["attribute_code"].ToString() == "thumbnail")
                        {
                            it.image_link = "https://bibomart.com.vn/media/catalog/product/" + i["value"].ToString();
                        }
                    }


                    return it;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(sku, "crawl_info_Mag");
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getShopee");
                return it;
            }
        }

        #endregion

        #region NoHope

        public static bool sp_ProductTool_Competeoffline_update(string createBy, int type, objCompeteOffline item)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_Competeoffline_update", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add(new SqlParameter("MaHang", item.MaHang));
                    cmd.Parameters.Add(new SqlParameter("MaCH", item.MaCH));
                    cmd.Parameters.Add(new SqlParameter("GiaTaiCH", item.GiaTaiCH));
                    cmd.Parameters.Add(new SqlParameter("accept_Price", item.accept_Price));
                    cmd.Parameters.Add(new SqlParameter("createBy", createBy));
                    cmd.Parameters.Add(new SqlParameter("type", type));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_Competeoffline_update");
                    return false;
                }
            }
        }

        public static bool sp_qlkd_Insert_MinPSQuanLyTonKho(string MaHang, string MaCH, int PSUpdate, string createUser)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_Insert_MinPSQuanLyTonKho", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("MaHang", MaHang));
                    cmd.Parameters.Add(new SqlParameter("MaCH", MaCH));
                    cmd.Parameters.Add(new SqlParameter("PSUpdate", PSUpdate));
                    cmd.Parameters.Add(new SqlParameter("createUser", createUser));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_qlkd_Insert_MinPSQuanLyTonKho");
                    return false;
                }
            }
        }


        public static bool sp_ProductTool_Competeoffline_Insert(string createBy, int type, objCompeteOffline item)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_Competeoffline_Insert", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add(new SqlParameter("MaHang", item.MaHang));
                    cmd.Parameters.Add(new SqlParameter("MaCH", item.MaCH));
                    cmd.Parameters.Add(new SqlParameter("GiaTaiCH", item.GiaTaiCH));
                    cmd.Parameters.Add(new SqlParameter("GiaDieuChinh", item.GiaDieuChinh));
                    cmd.Parameters.Add(new SqlParameter("createBy", createBy));
                    cmd.Parameters.Add(new SqlParameter("type", type));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_Competeoffline_Insert");
                    return false;
                }
            }
        }

        //manhln 08/04/2021
        public static List<objCombox> sp_qlkd_Sub_Range()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_Sub_Range", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_qlkd_Sub_BrandErp");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_qlkd_Sub_LoaiCTKM()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_Sub_LoaiCTKM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_qlkd_Sub_LoaiCTKM");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_qlkd_Sub_Range2()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_Sub_Range2", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_qlkd_Sub_Range2");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_HistoryPriceAll_TuNgay()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_HistoryPriceAll_TuNgay", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Code"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_HistoryPriceAll_TuNgay");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_BBMSMART_INSERT_PUSHSALES_MARCOMHIS_New_COUNT(string NhomKH, string Brand, string Function, string MaTinh, string store, string TaiApp, string LocNgayTao, string LocNgayDen, string isEmail, string birthday, string ChildOld)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBMSMART_INSERT_PUSHSALES_MARCOMHIS_New_COUNT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("NhomKH", NhomKH != null ? NhomKH : ""));
                    cmd.Parameters.Add(new SqlParameter("Brand", Brand != null ? Brand : ""));
                    cmd.Parameters.Add(new SqlParameter("Function", Function != null ? Function : ""));
                    cmd.Parameters.Add(new SqlParameter("MaTinh", MaTinh != null ? MaTinh : ""));
                    cmd.Parameters.Add(new SqlParameter("store", store != null ? store : ""));
                    cmd.Parameters.Add(new SqlParameter("TaiApp", TaiApp != null ? TaiApp : ""));
                    if (String.IsNullOrWhiteSpace(LocNgayTao))
                    {
                        cmd.Parameters.Add(new SqlParameter("LocNgayTao", ""));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("LocNgayTao", DateTime.Parse(LocNgayTao)));
                    }

                    if (String.IsNullOrWhiteSpace(LocNgayDen))
                    {
                        cmd.Parameters.Add(new SqlParameter("LocNgayDen", ""));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("LocNgayDen", DateTime.Parse(LocNgayDen)));
                    }
                    cmd.Parameters.Add(new SqlParameter("isEmail", isEmail != null ? isEmail : ""));
                    cmd.Parameters.Add(new SqlParameter("birthday", birthday != null ? birthday : ""));
                    cmd.Parameters.Add(new SqlParameter("ChildOld", ChildOld != null ? ChildOld : ""));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Code"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBMSMART_INSERT_PUSHSALES_MARCOMHIS_New_COUNT");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_bbs_getfilter_CampaignMarcom_Store()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getfilter_CampaignMarcom_Store", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getfilter_CampaignMarcom_Store");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_getfilter_CampaignMarcom_Provin()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getfilter_CampaignMarcom_Provin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getfilter_CampaignMarcom_Provin");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_getfilter_CampaignMarcom_old()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getfilter_CampaignMarcom_old", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getfilter_CampaignMarcom_old");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_getfilter_CampaignMarcom_child_old()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getfilter_CampaignMarcom_child_old", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getfilter_CampaignMarcom_child_old");
                    return it_r;
                }
            }
        }

        public static List<filterMarcom> sp_bbs_getfilter_CampaignMarcom(string NhomKH)
        {
            List<filterMarcom> it_r = new List<filterMarcom>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getfilter_CampaignMarcom", con);
                    cmd.Parameters.Add(new SqlParameter("NhomKH", NhomKH));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300000;

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        filterMarcom it = new filterMarcom
                        {
                            BrandName = reader["BrandName"].ToString(),
                            BrandCode = reader["BrandCode"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),
                            NhomKH = reader["NhomKH"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getfilter_CampaignMarcom");
                    return it_r;
                }
            }
        }


        public static List<filterMarcomProvinStore> sp_bbs_getfilter_CampaignMarcom_Provin_Store(string NhomKH)
        {
            List<filterMarcomProvinStore> it_r = new List<filterMarcomProvinStore>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getfilter_CampaignMarcom_Provin_Store", con);
                    cmd.Parameters.Add(new SqlParameter("NhomKH", NhomKH));
                    cmd.CommandType = CommandType.StoredProcedure;

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        filterMarcomProvinStore it = new filterMarcomProvinStore
                        {
                            MaCH = reader["MaCH"].ToString(),
                            TenCH = reader["TenCH"].ToString(),
                            MaTinh = reader["MaTinh"].ToString(),
                            TenTinh = reader["TenTinh"].ToString(),
                            NhomKH = reader["NhomKH"].ToString(),

                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getfilter_CampaignMarcom_Provin_Store");
                    return it_r;
                }
            }
        }


        public static List<objCombox> ShowNameBrand(string Brand)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("ShowNameBrand", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Brand", Brand != null ? Brand : ""));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ShowNameBrand");
                    return it_r;
                }
            }
        }
        public static List<objCombox> ShowNameFunction(string Function)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("ShowNameFunction", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Function", Function != null ? Function : ""));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ShowNameFunction");
                    return it_r;
                }
            }
        }

        public static List<objCombox> ShowNameTinh(string MaTinh)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("ShowNameTinh", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaTinh", MaTinh != null ? MaTinh : ""));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ShowNameTinh");
                    return it_r;
                }
            }
        }
        public static List<objCombox> ShowNameStore(string store)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("ShowNameStore", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("store", store != null ? store : ""));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ShowNameStore");
                    return it_r;
                }
            }
        }


        public static List<objCombox> sp_FunErp_CampaignMarcom(string NhomKH, string Brand)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_FunErp_CampaignMarcom", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("NhomKH", NhomKH));
                    cmd.Parameters.Add(new SqlParameter("Brand", Brand));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_FunErp_CampaignMarcom");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_ProviceErp_CampaignMarcom(string NhomKH, string Brand, string funct)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProviceErp_CampaignMarcom", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("NhomKH", NhomKH));
                    if (Brand.Length > 500)
                    {
                        cmd.Parameters.Add(new SqlParameter("Brand", ""));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("Brand", Brand));
                    }
                    if (funct.Length > 500)
                    {
                        cmd.Parameters.Add(new SqlParameter("funct", ""));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("funct", funct));
                    }

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProviceErp_CampaignMarcom");
                    return it_r;
                }
            }
        }


        public static List<objCombox> sp_store_CampaignMarcom(string MaTinh)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_store_CampaignMarcom", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaTinh", MaTinh));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_store_CampaignMarcom");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_province_CampaignMarcom(string NhomKH)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_province_CampaignMarcom", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("NhomKH", NhomKH));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_province_CampaignMarcom");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_BrandErp_CampaignMarcom(string NhomKH)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BrandErp_CampaignMarcom", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("NhomKH", NhomKH));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BrandErp_CampaignMarcom");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_qlkd_Sub_BrandErp()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_Sub_BrandErp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_qlkd_Sub_BrandErp");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_qlkd_Sub_BrandErp_filter()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_Sub_BrandErp_filter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_qlkd_Sub_BrandErp");
                    return it_r;
                }
            }
        }
        public static List<objTonKho> getListPopupItemPS(string itemNo, string storeNo)
        {
            List<objTonKho> it_r = new List<objTonKho>();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_getPopupItemPS", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("itemNo", itemNo));
                    cmd.Parameters.Add(new SqlParameter("storeNo", storeNo));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objTonKho it = new objTonKho
                        {
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString(),
                            MaCH = reader["MaCH"].ToString(),
                            TenCH = reader["TenCH"].ToString(),
                            PS = decimal.Parse(reader["PS"].ToString()),
                            PSUpdate = decimal.Parse(reader["PSUpdate"].ToString())
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getListPopupItemPS");
                return it_r;
            }
        }

        public static List<objCombox> sp_qlkd_getVendor()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_getVendor", con);//sp_qlkd_getVendor
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_qlkd_getVendor");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_qlkd_getVendor_inventory_fiter()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_getVendor_inventory_fiter", con);//sp_qlkd_getVendor
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_qlkd_getVendor");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_qlkd_getVendor_View()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_getVendor_View", con);//
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_qlkd_getVendor");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_qlkd_getStoreLocation()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_getStoreLocation", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_qlkd_getStoreLocation");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_getTieuchuantrainghiem()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getTieuchuantrainghiem", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getTieuchuantrainghiem");
                    return it_r;
                }
            }
        }

        public static List<objComboxEx> sp_bbs_getTieuchuantrainghiemcon()
        {
            List<objComboxEx> it_r = new List<objComboxEx>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getTieuchuantrainghiemcon", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objComboxEx it = new objComboxEx
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            ParentCode = reader["ParentCode"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getTieuchuantrainghiemcon");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_VendorTool_MD_Sub_get_tradingtem()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_VendorTool_MD_Sub_get_tradingtem", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_VendorTool_MD_Sub_get_tradingtem");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_VendorTool_MD_Sub_get()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_VendorTool_MD_Sub_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_VendorTool_MD_Sub_get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_bbs_getlistCH()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getlistCH", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getlistCH");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_bbs_getlistCH_filter()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getlistCH_filter", con);//sp_bbs_getlistCH
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getlistCH");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_bbs_getlistCH_User(string userid)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getlistCH_User", con);
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getlistCH_User");
                    return it_r;
                }
            }
        }

        public static List<objCombox> getSub_GeneralProductPotingGroupErp()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_getSub_GeneralProductPotingGroupErp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getSub_GeneralProductPotingGroupErp");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_qlkd_getInputSource()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_getInputSource", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_qlkd_getInputSource");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_ProductTool_getSubFunction()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_getSubFunction", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_getSubFunction");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_ProductTool_getSubFunctionFull()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_getSubFunctionFull", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_getSubFunction");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_BBSmart_GetList_Function_NOIDIA_v2()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_GetList_Function_NOIDIA_v2", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_GetList_Function_NOIDIA_v2");
                    return it_r;
                }
            }
        }

        public static List<objCustomerLoyalty> sp_GetListCustomerLoyalty_excel(string FunctionCode, string HHKG, string maNCC, string BrandCode, string Range, string mahang, string tenhang, string strMahang)
        {
            List<objCustomerLoyalty> it_s = new List<objCustomerLoyalty>();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetListCustomerLoyalty", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("FunctionCode", FunctionCode));
                    //cmd.Parameters.Add(new SqlParameter("nguonnhapCode", nguonnhapCode));
                    cmd.Parameters.Add(new SqlParameter("HHKG", HHKG));
                    cmd.Parameters.Add(new SqlParameter("maNCC", maNCC));
                    cmd.Parameters.Add(new SqlParameter("BrandCode", BrandCode));
                    cmd.Parameters.Add(new SqlParameter("Range", Range));
                    cmd.Parameters.Add(new SqlParameter("mahang", mahang));
                    cmd.Parameters.Add(new SqlParameter("tenhang", tenhang));
                    cmd.Parameters.Add(new SqlParameter("strMahang", strMahang));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCustomerLoyalty it = new objCustomerLoyalty
                        {
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString(),
                            MaKH = reader["MaKH"].ToString(),
                            TenKH = reader["TenKH"].ToString(),
                            TuoiCon1 = int.Parse(reader["TuoiCon1"].ToString()),
                            TuoiCon2 = int.Parse(reader["TuoiCon2"].ToString()),

                            SoLuongCuoi = decimal.Parse(reader["SoLuongCuoi"].ToString()),
                            NgayMuaCuoi = reader["NgayMuaCuoi"].ToString(),
                            MaCH = reader["MaCH"].ToString(),
                            TenCH = reader["TenCH"].ToString(),

                            SoNgaySuDung1SP = decimal.Parse(reader["SoNgaySuDung1SP"].ToString()),
                            SoNgayQuaHan = int.Parse(reader["SoNgayQuaHan"].ToString())

                        };
                        it_s.Add(it);
                    }
                    con.Close();
                    return it_s;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_GetListCustomerLoyalty");
                return it_s;
            }
        }





        public static List<objCompeteOffline> sp_GetListAcceptCompeteOffline(string FunctionCode, string nguonnhapCode, string HHKG, string maNCC, string BrandCode, string Range, string mahang, string tenhang, string strMahang)
        {
            List<objCompeteOffline> it_s = new List<objCompeteOffline>();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetListAcceptCompeteOffline", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("FunctionCode", FunctionCode));
                    cmd.Parameters.Add(new SqlParameter("nguonnhapCode", nguonnhapCode));
                    cmd.Parameters.Add(new SqlParameter("HHKG", HHKG));
                    cmd.Parameters.Add(new SqlParameter("maNCC", maNCC));
                    cmd.Parameters.Add(new SqlParameter("BrandCode", BrandCode));
                    cmd.Parameters.Add(new SqlParameter("Range", Range));
                    cmd.Parameters.Add(new SqlParameter("mahang", mahang));
                    cmd.Parameters.Add(new SqlParameter("tenhang", tenhang));
                    cmd.Parameters.Add(new SqlParameter("strMahang", strMahang));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCompeteOffline it = new objCompeteOffline
                        {
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString(),
                            MaCH = reader["MaCH"].ToString(),
                            TenCH = reader["TenCH"].ToString(),
                            L4LSL = decimal.Parse(reader["L4LSL"].ToString()),
                            L4LDT = reader["L4LDT"].ToString(),
                            L4LGP = reader["L4LGP"].ToString(),
                            GiaTaiCH = reader["GiaTaiCH"].ToString(),
                            GiaDoiThu = reader["GiaDoiThu"].ToString(),
                            TenDoiThu = reader["TenDoiThu"].ToString(),
                            GiaDieuChinh = reader["GiaDieuChinh"].ToString(),
                            createDate = reader["createDate"].ToString(),
                            accept_Price = reader["accept_Price"].ToString()
                        };

                        it_s.Add(it);
                    }
                    con.Close();
                    return it_s;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_GetListAcceptCompeteOffline");
                return it_s;
            }
        }


        public static List<objCompeteOnline> sp_GetListCompeteOnline_excel(string FunctionCode, string nguonnhapCode, string HHKG, string maNCC, string BrandCode, string Range, string mahang, string tenhang, string strMahang)
        {
            List<objCompeteOnline> it_s = new List<objCompeteOnline>();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetListCompeteOnline", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("FunctionCode", FunctionCode));
                    cmd.Parameters.Add(new SqlParameter("nguonnhapCode", nguonnhapCode));
                    cmd.Parameters.Add(new SqlParameter("HHKG", HHKG));
                    cmd.Parameters.Add(new SqlParameter("maNCC", maNCC));
                    cmd.Parameters.Add(new SqlParameter("BrandCode", BrandCode));
                    cmd.Parameters.Add(new SqlParameter("Range", Range));
                    cmd.Parameters.Add(new SqlParameter("mahang", mahang));
                    cmd.Parameters.Add(new SqlParameter("tenhang", tenhang));
                    cmd.Parameters.Add(new SqlParameter("strMahang", strMahang));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCompeteOnline it = new objCompeteOnline
                        {
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString(),
                            MaDoiThu = reader["MaDoiThu"].ToString(),
                            TenDoiThu = reader["TenDoiThu"].ToString(),
                            GiaBBM = reader["GiaBBM"].ToString(),

                            GiaDoiThu = reader["GiaDoiThu"].ToString(),
                            LinkDoiThu = reader["LinkDoiThu"].ToString(),
                            NgayKhaiBao = reader["NgayKhaiBao"].ToString()
                        };

                        it_s.Add(it);
                    }
                    con.Close();
                    return it_s;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_GetListCompeteOnline");
                return it_s;
            }
        }

        public static List<objInventory> sp_GetListInventory_excel(string FunctionCode, string HHKG, string maNCC, string BrandCode, string Range, string mahang, string tenhang, string strMahang, string storeLocation)
        {
            List<objInventory> it_s = new List<objInventory>();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetListInventory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("dateFill", dateFill));

                    cmd.Parameters.Add(new SqlParameter("FunctionCode", FunctionCode));
                    //cmd.Parameters.Add(new SqlParameter("nguonnhapCode", nguonnhapCode));
                    cmd.Parameters.Add(new SqlParameter("HHKG", HHKG));
                    cmd.Parameters.Add(new SqlParameter("maNCC", maNCC));
                    cmd.Parameters.Add(new SqlParameter("BrandCode", BrandCode));
                    cmd.Parameters.Add(new SqlParameter("Range", Range));
                    cmd.Parameters.Add(new SqlParameter("mahang", mahang));
                    cmd.Parameters.Add(new SqlParameter("tenhang", tenhang));
                    cmd.Parameters.Add(new SqlParameter("strMahang", strMahang));
                    cmd.Parameters.Add(new SqlParameter("storeLocation", storeLocation));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objInventory it = new objInventory
                        {
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString(),
                            MaCH = reader["MaCH"].ToString(),
                            TenCH = reader["TenCH"].ToString(),
                            DSD30 = decimal.Parse(reader["DSD30"].ToString()),
                            PS = decimal.Parse(reader["PS"].ToString()),
                            SLTon = decimal.Parse(reader["SLTon"].ToString()),
                            SoNgayOOS = int.Parse(reader["SoNgayOOS"].ToString()),
                            SaleLost_N = decimal.Parse(reader["SaleLost_N"].ToString()),
                            SaleLost = reader["SaleLost"].ToString()
                        };

                        it_s.Add(it);
                    }
                    con.Close();
                    return it_s;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_GetListInventory");
                return it_s;
            }
        }

        //public static List<objManageSales> sp_GetListManageSales(string FunctionCode, string nguonnhapCode, string HHKG, string maNCC, string BrandCode, string Range, string mahang, string tenhang)
        //{
        //    List<objManageSales> it_s = new List<objManageSales>();
        //    try
        //    {
        //        using (var con = new SqlConnection(strCon))
        //        {
        //            con.Open();
        //            SqlCommand cmd = new SqlCommand("sp_GetListManageSales", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            //cmd.Parameters.Add(new SqlParameter("dateFill", dateFill));

        //            cmd.Parameters.Add(new SqlParameter("FunctionCode", FunctionCode));
        //            cmd.Parameters.Add(new SqlParameter("nguonnhapCode", nguonnhapCode));
        //            cmd.Parameters.Add(new SqlParameter("HHKG", HHKG));
        //            cmd.Parameters.Add(new SqlParameter("maNCC", maNCC));
        //            cmd.Parameters.Add(new SqlParameter("BrandCode", BrandCode));
        //            cmd.Parameters.Add(new SqlParameter("Range", Range));
        //            cmd.Parameters.Add(new SqlParameter("mahang", mahang));
        //            cmd.Parameters.Add(new SqlParameter("tenhang", tenhang));

        //            var reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                objManageSales it = new objManageSales
        //                {
        //                    MaHang = reader["MaHang"].ToString(),
        //                    TenHang = reader["TenHang"].ToString(),
        //                    GiaNhap = reader["GiaNhap"].ToString(),
        //                    GiaBan = reader["GiaBan"].ToString(),

        //                    GP = decimal.Parse(reader["GP"].ToString()),
        //                    L4LSL = decimal.Parse(reader["L4LSL"].ToString()),
        //                    //L4LDT = decimal.Parse(reader["L4LDT"].ToString()),
        //                    //L4LGP = decimal.Parse(reader["L4LGP"].ToString()),
        //                    L4LDT = reader["L4LDT"].ToString(),
        //                    L4LGP = reader["L4LGP"].ToString(),
        //                    XepHang631SKUs = int.Parse(reader["XepHang631SKUs"].ToString()),
        //                    DTSKU = decimal.Parse(reader["DTSKU"].ToString())
        //                };
        //                it_s.Add(it);
        //            }
        //            con.Close();
        //            return it_s;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_GetListManageSales");
        //        return it_s;
        //    }
        //}

        public static DataTable sp_GetListInventory(string userid, string mien, string tinh, string store, string ncc, string brand, string mahang)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetListInventory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 60000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("mien", mien));
                    cmd.Parameters.Add(new SqlParameter("tinh", tinh));
                    cmd.Parameters.Add(new SqlParameter("store", store));
                    cmd.Parameters.Add(new SqlParameter("ncc", ncc));
                    cmd.Parameters.Add(new SqlParameter("brand", brand));
                    cmd.Parameters.Add(new SqlParameter("mahang", mahang));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_GetListInventory");
                return ds.Tables[0];
            }
        }

        public static DataTable sp_GetListInventoryNcc(string FunctionCode, string HHKG, string maNCC, string BrandCode, string Range, string mahang, string strMahang, string storeLocation, string div, string maCH)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetListInventoryNcc", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    //cmd.Parameters.Add(new SqlParameter("dateFill", dateFill));

                    cmd.Parameters.Add(new SqlParameter("FunctionCode", FunctionCode));
                    //cmd.Parameters.Add(new SqlParameter("nguonnhapCode", nguonnhapCode));
                    cmd.Parameters.Add(new SqlParameter("HHKG", HHKG));
                    cmd.Parameters.Add(new SqlParameter("maNCC", maNCC));
                    cmd.Parameters.Add(new SqlParameter("maCH", maCH));
                    cmd.Parameters.Add(new SqlParameter("BrandCode", BrandCode));
                    cmd.Parameters.Add(new SqlParameter("Range", Range));
                    cmd.Parameters.Add(new SqlParameter("mahang", mahang));
                    cmd.Parameters.Add(new SqlParameter("strMahang", strMahang));
                    cmd.Parameters.Add(new SqlParameter("storeLocation", storeLocation));
                    cmd.Parameters.Add(new SqlParameter("div", div));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_GetListInventory");
                return ds.Tables[0];
            }
        }

        public static DataTable sp_GetListInventoryStore(string userid, string mien, string tinh, string store, string ncc, string brand, string mahang)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetListInventoryStore", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("mien", mien));
                    cmd.Parameters.Add(new SqlParameter("tinh", tinh));
                    cmd.Parameters.Add(new SqlParameter("store", store));
                    cmd.Parameters.Add(new SqlParameter("ncc", ncc));
                    cmd.Parameters.Add(new SqlParameter("brand", brand));
                    cmd.Parameters.Add(new SqlParameter("mahang", mahang));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_GetListInventory");
                return ds.Tables[0];
            }
        }
        public static DataTable sp_GetListManageSales(string userid, string kenhban, string nguonnhap, string brand, string maNCC, string storeLocation, string Nhom, string StoreNo, string mahang)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetListManageSales", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("kenhban", kenhban));
                    cmd.Parameters.Add(new SqlParameter("nguonnhap", nguonnhap));
                    cmd.Parameters.Add(new SqlParameter("brand", brand));
                    cmd.Parameters.Add(new SqlParameter("maNCC", maNCC));
                    cmd.Parameters.Add(new SqlParameter("storeLocation", storeLocation));
                    cmd.Parameters.Add(new SqlParameter("Nhom", Nhom));
                    cmd.Parameters.Add(new SqlParameter("StoreNo", StoreNo));
                    cmd.Parameters.Add(new SqlParameter("mahang", mahang));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        sda.Fill(ds);

                    }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_GetListManageSales");
                return ds.Tables[0];
            }
        }

        public static DataTable sp_GetListManageSalesECOM(string userid, string StoreNo, string storeLocation, string maNCC, string BrandCode, string Range, string mahang, string kenhban, string div, string RSMCode)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetListManageSales_ECOM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    //cmd.Parameters.Add(new SqlParameter("dateFill", dateFill));
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("StoreNo", StoreNo));
                    cmd.Parameters.Add(new SqlParameter("storeLocation", storeLocation));
                    cmd.Parameters.Add(new SqlParameter("maNCC", maNCC));
                    cmd.Parameters.Add(new SqlParameter("BrandCode", BrandCode));
                    cmd.Parameters.Add(new SqlParameter("Range", Range));
                    cmd.Parameters.Add(new SqlParameter("mahang", mahang));
                    cmd.Parameters.Add(new SqlParameter("kenhban", kenhban));
                    cmd.Parameters.Add(new SqlParameter("div", div));
                    cmd.Parameters.Add(new SqlParameter("RSMCode", RSMCode));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        sda.Fill(ds);

                    }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_GetListManageSales_ECOM");
                return ds.Tables[0];
            }
        }

        public static DataTable sp_GetListTransfer(string FunctionCode, string HHKG, string maNCC, string BrandCode, string Range, string mahang, string strMahang, string storeLocation, string div, string maCH)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetListTransfer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    //cmd.Parameters.Add(new SqlParameter("dateFill", dateFill));

                    cmd.Parameters.Add(new SqlParameter("FunctionCode", FunctionCode));
                    //cmd.Parameters.Add(new SqlParameter("nguonnhapCode", nguonnhapCode));
                    cmd.Parameters.Add(new SqlParameter("HHKG", HHKG));
                    cmd.Parameters.Add(new SqlParameter("maNCC", maNCC));
                    cmd.Parameters.Add(new SqlParameter("maCH", maCH));
                    cmd.Parameters.Add(new SqlParameter("BrandCode", BrandCode));
                    cmd.Parameters.Add(new SqlParameter("Range", Range));
                    cmd.Parameters.Add(new SqlParameter("mahang", mahang));
                    cmd.Parameters.Add(new SqlParameter("strMahang", strMahang));
                    cmd.Parameters.Add(new SqlParameter("storeLocation", storeLocation));
                    cmd.Parameters.Add(new SqlParameter("div", div));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_GetListTransfer");
                return ds.Tables[0];
            }
        }




        #endregion

        #region ComparePrice

        #region get Data

        public static List<compareHeader> sp_ProductTool_ComparePrice_get_Header()
        {
            List<compareHeader> it_s = new List<compareHeader>();

            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_ComparePrice_get_Header", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("dateFill", dateFill));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        compareHeader it = new compareHeader
                        {
                            compareCode = reader["compareCode"].ToString(),
                            compareName = reader["compareName"].ToString()
                        };

                        it_s.Add(it);
                    }
                    con.Close();

                    return it_s;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ComparePrice_get_Header");
                return it_s;
            }
        }

        public static List<compareLine> sp_qlkd_GetOnlinePrice(compareLine it, string strMaHang)
        {
            List<compareLine> it_s = new List<compareLine>();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_qlkd_GetOnlinePrice", con);
                    cmd.CommandTimeout = 30000;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("sku", it.sku));

                    cmd.Parameters.Add(new SqlParameter("divCode", it.DivisionCode));
                    cmd.Parameters.Add(new SqlParameter("catCode", it.CategoryCode));
                    cmd.Parameters.Add(new SqlParameter("groupCode", it.GroupCode));
                    cmd.Parameters.Add(new SqlParameter("functionCode", it.FunctionCode));
                    cmd.Parameters.Add(new SqlParameter("vendorCode", it.VendorNo));
                    cmd.Parameters.Add(new SqlParameter("brandCode", it.BrandCode));
                    cmd.Parameters.Add(new SqlParameter("strMahang", strMaHang));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        compareLine its = new compareLine
                        {
                            lineNo = reader["lineNo"].ToString(),
                            compareCode = reader["compareCode"].ToString(),
                            compareName = reader["compareName"].ToString(),
                            sku = reader["sku"].ToString(),
                            url = reader["url"].ToString(),
                            name = reader["name"].ToString(),
                            brand = reader["brand"].ToString(),
                            XepHang = reader["XepHang"].ToString(),
                            bb_price = reader["bb_price"].ToString(),
                            GiaMuaNet = reader["GiaMuaNet"].ToString(),
                            comparePrice = reader["comparePrice"].ToString(),
                            compareLink = reader["compareLink"].ToString(),
                            subName = reader["subName"].ToString(),
                            modifyDate = reader["modifyDate"].ToString(),
                            promo = reader["promo"].ToString(),
                            DivisionCode = reader["DivisionCode"].ToString(),
                            DivisionName = reader["DivisionName"].ToString(),
                            CategoryCode = reader["CategoryCode"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            GroupCode = reader["GroupCode"].ToString(),
                            GroupName = reader["GroupName"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),
                            VendorNo = reader["VendorNo"].ToString(),
                            VendorName = reader["VendorName"].ToString(),
                            BrandCode = reader["BrandCode"].ToString(),
                            BrandName = reader["BrandName"].ToString(),
                            CP_Name = reader["CP_Name"].ToString(),
                        };

                        it_s.Add(its);
                    }
                    con.Close();
                    return it_s;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ComparePrice_get_RP");
                return it_s;
            }
        }

        public static List<compareLine> sp_ProductTool_ComparePrice_get_RP(compareLine it)
        {
            List<compareLine> it_s = new List<compareLine>();

            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_ComparePrice_get_RP_v2", con);
                    cmd.CommandTimeout = 30000;


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("sku", it.sku));

                    cmd.Parameters.Add(new SqlParameter("divCode", it.DivisionCode));
                    cmd.Parameters.Add(new SqlParameter("catCode", it.CategoryCode));
                    cmd.Parameters.Add(new SqlParameter("groupCode", it.GroupCode));
                    cmd.Parameters.Add(new SqlParameter("functionCode", it.FunctionCode));
                    cmd.Parameters.Add(new SqlParameter("vendorCode", it.VendorNo));
                    cmd.Parameters.Add(new SqlParameter("brandCode", it.BrandCode));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        compareLine its = new compareLine
                        {

                            lineNo = reader["lineNo"].ToString(),
                            compareCode = reader["compareCode"].ToString(),
                            compareName = reader["compareName"].ToString(),
                            sku = reader["sku"].ToString(),
                            url = reader["url"].ToString(),
                            name = reader["name"].ToString(),
                            brand = reader["brand"].ToString(),
                            XepHang = reader["XepHang"].ToString(),
                            bb_price = reader["bb_price"].ToString(),
                            GiaMuaNet = reader["GiaMuaNet"].ToString(),
                            comparePrice = reader["comparePrice"].ToString(),
                            compareLink = reader["compareLink"].ToString(),
                            subName = reader["subName"].ToString(),
                            modifyDate = reader["modifyDate"].ToString(),
                            promo = reader["promo"].ToString(),

                            DivisionCode = reader["DivisionCode"].ToString(),
                            DivisionName = reader["DivisionName"].ToString(),
                            CategoryCode = reader["CategoryCode"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            GroupCode = reader["GroupCode"].ToString(),
                            GroupName = reader["GroupName"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),
                            VendorNo = reader["VendorNo"].ToString(),
                            VendorName = reader["VendorName"].ToString(),
                            BrandCode = reader["BrandCode"].ToString(),
                            BrandName = reader["BrandName"].ToString(),
                            CP_Name = reader["CP_Name"].ToString(),
                        };

                        it_s.Add(its);
                    }
                    con.Close();

                    return it_s;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ComparePrice_get_RP");
                return it_s;
            }
        }

        public static List<RP_Accept_Item> sp_ProductTool_ComparePrice_get_RP_Accept(compareLine it)
        {
            List<RP_Accept_Item> it_s = new List<RP_Accept_Item>();

            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_ComparePrice_get_RP_Accept", con);
                    cmd.CommandTimeout = 30000;


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("sku", it.sku));

                    cmd.Parameters.Add(new SqlParameter("divCode", it.DivisionCode));

                    cmd.Parameters.Add(new SqlParameter("catCode", it.CategoryCode));
                    cmd.Parameters.Add(new SqlParameter("groupCode", it.GroupCode));
                    cmd.Parameters.Add(new SqlParameter("functionCode", it.FunctionCode));
                    cmd.Parameters.Add(new SqlParameter("vendorCode", it.VendorNo));
                    cmd.Parameters.Add(new SqlParameter("brandCode", it.BrandCode));

                    cmd.Parameters.Add(new SqlParameter("status_Acc", it.lineNo));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        RP_Accept_Item its = new RP_Accept_Item
                        {

                            lineNo = reader["lineNo"].ToString(),
                            compareCode = reader["compareCode"].ToString(),
                            compareName = reader["compareName"].ToString(),
                            sku = reader["sku"].ToString(),
                            url = reader["url"].ToString(),
                            name = reader["name"].ToString(),
                            brand = reader["brand"].ToString(),
                            XepHang = reader["XepHang"].ToString(),
                            bb_price = reader["bb_price"].ToString(),
                            GiaMuaNet = reader["GiaMuaNet"].ToString(),
                            comparePrice = reader["comparePrice"].ToString(),
                            compareLink = reader["compareLink"].ToString(),
                            subName = reader["subName"].ToString(),
                            modifyDate = reader["modifyDate"].ToString(),
                            promo = reader["promo"].ToString(),

                            DivisionCode = reader["DivisionCode"].ToString(),
                            DivisionName = reader["DivisionName"].ToString(),
                            CategoryCode = reader["CategoryCode"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            GroupCode = reader["GroupCode"].ToString(),
                            GroupName = reader["GroupName"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),
                            VendorNo = reader["VendorNo"].ToString(),
                            VendorName = reader["VendorName"].ToString(),
                            BrandCode = reader["BrandCode"].ToString(),
                            BrandName = reader["BrandName"].ToString(),

                            ActionId = int.Parse(reader["ActionId"].ToString()),
                            salesPrice = int.Parse(reader["salesPrice"].ToString()),
                            accept_salesPrice = int.Parse(reader["accept_salesPrice"].ToString()),
                            GL_D = decimal.Parse(reader["GL_D"].ToString()),
                            GL_A = decimal.Parse(reader["GL_A"].ToString()),
                            CP_Name = reader["CP_Name"].ToString(),
                            status_Acc = int.Parse(reader["status_Acc"].ToString()),
                        };

                        it_s.Add(its);
                    }
                    con.Close();

                    return it_s;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ComparePrice_get_RP_Accept");
                return it_s;
            }
        }

        public static sourceItem sp_ProductTool_ComparePrice_get_ProductInfo(string sku)
        {
            sourceItem it = new sourceItem();

            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_ComparePrice_get_ProductInfo", con);
                    cmd.CommandTimeout = 30000;


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("sku", sku));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        sourceItem its = new sourceItem
                        {

                            sku = reader["sku"].ToString(),
                            name = reader["name"].ToString(),
                            url_link = reader["url_link"].ToString(),
                        };

                        it = its;
                    }
                    con.Close();

                    return it;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ComparePrice_get_ProductInfo");
                return it;
            }
        }

        public static List<MDS_DivCatGroupFunc> sp_ProductTool_ComparePrice_get_CPType()
        {
            List<MDS_DivCatGroupFunc> it_s = new List<MDS_DivCatGroupFunc>();

            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_ComparePrice_get_CPType", con);
                    cmd.CommandTimeout = 30000;


                    cmd.CommandType = CommandType.StoredProcedure;

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        MDS_DivCatGroupFunc its = new MDS_DivCatGroupFunc
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_s.Add(its);
                    }
                    con.Close();

                    return it_s;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ComparePrice_get_CPType");
                return it_s;
            }
        }

        public static List<MDS_DivCatGroupFunc> sp_ProductTool_ComparePrice_ActionType_get()
        {
            List<MDS_DivCatGroupFunc> it_s = new List<MDS_DivCatGroupFunc>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_ComparePrice_ActionType_get", con);
                    cmd.CommandTimeout = 30000;


                    cmd.CommandType = CommandType.StoredProcedure;

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        MDS_DivCatGroupFunc its = new MDS_DivCatGroupFunc
                        {
                            Code = reader["code"].ToString(),
                            Name = reader["name"].ToString(),
                        };

                        it_s.Add(its);
                    }
                    con.Close();

                    return it_s;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ComparePrice_ActionType_get");
                    return it_s;
                }

            }
        }


        #endregion


        #region Action Data

        public static bool sp_ProductTool_ComparePrice_disable_Line(string link)
        {

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_ComparePrice_disable_Line", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("link", link));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ComparePrice_disable_Line");
                    return false;
                }
            }

        }

        public static bool sp_ProductTool_ComparePrice_add_Line(string uid, compareLine it)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_ComparePrice_add_Line", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("sku", it.sku));
                    cmd.Parameters.Add(new SqlParameter("compareCode", it.compareCode));
                    cmd.Parameters.Add(new SqlParameter("compareLink", it.compareLink));
                    cmd.Parameters.Add(new SqlParameter("subName", it.subName));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ComparePrice_add_Line");
                return false;
            }
        }

        public static bool sp_ProductTool_ComparePrice_Action_add(string uid, int type, compareAction it)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_ComparePrice_Action_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("type", type));

                    cmd.Parameters.Add(new SqlParameter("id", it.id));
                    cmd.Parameters.Add(new SqlParameter("sku", it.sku));
                    cmd.Parameters.Add(new SqlParameter("compare_LineID", it.compare_LineID));
                    cmd.Parameters.Add(new SqlParameter("corePrice", it.corePrice));
                    cmd.Parameters.Add(new SqlParameter("salesPrice", Regex.Replace(it.salesPrice, "[^-.0-9]", "")));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ComparePrice_Action_add");
                    return false;
                }
            }
        }

        public static bool sp_ProductTool_ComparePrice_Request_Wait_add(string uid, string sku)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_ComparePrice_Request_Wait_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("sku", sku));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ComparePrice_Request_Wait_add");
                    return false;
                }
            }
        }

        #endregion

        #endregion

        #region loginAllWay

        public static bool LoginDomain(string uid, string pwd)
        {
            bool flag = false;

            if (uid == "admin")
            {
                flag = true;
            }
            else
            {
                try
                {
                    //PrincipalContext pc = new PrincipalContext(ContextType.Domain, region + ".BIBOMART.LOCAL");
                    PrincipalContext pc = new PrincipalContext(ContextType.Domain, "BIBOMART.LOCAL");
                    flag = pc.ValidateCredentials(uid, pwd);
                }
                catch (Exception ex)
                {
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "LoginDomain");
                    flag = false;
                }
            }


            return flag;
        }

        public static bool LoginEmail(string username, string password)
        {
            try
            {
                const string serverName = "smtp.bibomart.net";

                const int port = 465;
                //const SecurityMode securityMode = SecurityMode.Implicit;
                // Create a new instance of the Pop3Client class.
                MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient();
                // Connect to the server.
                client.Connect(serverName, port, MailKit.Security.SecureSocketOptions.SslOnConnect);

                // Login to the server.
                client.Authenticate(username, password);

                // Close the connection.
                client.Disconnect(true);

                return true;
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "LoginEmail");
                return false;
            }
        }

        public static DataTable LoginEmpID(string username, string password)
        {
            // if (username == "admin")
            // {
            //     return true;
            // }

            var table = SqlHelper.ExecuteTable(
                               strConn1101,
                               "sp_LoginInfo",
                               username,
                               AES.Encrypt(password),
                               "E", 0);

            return table;

            //if (table.HasRow())
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }


        #endregion

        #region StoreLayout

        #region DataAction

        #region getData
        public static List<Models.StoreLayout.userRole> sp_ProductTool_get_UserRole(string uid)
        {
            List<Models.StoreLayout.userRole> it_r = new List<Models.StoreLayout.userRole>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_get_UserRole_v2", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userID", uid));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Models.StoreLayout.userRole it = new Models.StoreLayout.userRole
                        {
                            userID = reader["userID"].ToString(),
                            roleCode = reader["roleCode"].ToString(),
                            roleName = reader["roleName"].ToString(),
                            storeNo = reader["storeNo"].ToString(),
                            storeName = reader["storeName"].ToString(),
                            countShelf = int.Parse(reader["countShelf"].ToString()),
                            controlCode = reader["controlCode"].ToString(),
                            view_act = int.Parse(reader["view_act"].ToString()),
                            create_act = int.Parse(reader["create_act"].ToString()),
                            edit_act = int.Parse(reader["edit_act"].ToString()),
                            accept_act = int.Parse(reader["accept_act"].ToString()),
                            points_act = int.Parse(reader["points_act"].ToString()),
                        };

                        it_r.Add(it);

                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_get_UserRole");
                    return it_r;

                }
            }

        }

        public static List<storeShelf> sp_ProductTool_get_UserStoreShelf(int type, string uid, string storeNo, string id)
        {
            List<storeShelf> it_r = new List<storeShelf>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_get_UserStoreShelf", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("type", type));
                    cmd.Parameters.Add(new SqlParameter("userID", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", storeNo));
                    cmd.Parameters.Add(new SqlParameter("id", id));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        storeShelf it = new storeShelf
                        {
                            id = int.Parse(reader["id"].ToString()),
                            storeNo = reader["storeNo"].ToString(),
                            shelfNo = reader["shelfNo"].ToString(),
                            sub_id = reader["sub_id"].ToString(),
                            shelfName = reader["shelfName"].ToString(),
                            catNo = reader["catNo"].ToString(),
                            catName = reader["catName"].ToString(),
                            img_link = reader["img_link"].ToString(),
                            status = int.Parse(reader["status"].ToString()),
                            createdBy = reader["createdBy"].ToString(),
                            modifyBy = reader["modifyBy"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            modifyDate = reader["modifyDate"].ToString(),
                            comment = reader["comment"].ToString()
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_get_UserStoreShelf");
                    return it_r;
                }
            }

        }

        public static List<storeShelf_v2> sp_ProductTool_get_UserStoreShelf_v2(int type, string uid, string storeNo, string id)
        {
            List<storeShelf_v2> it_r = new List<storeShelf_v2>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_get_UserStoreShelf_v2", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("type", type));
                    cmd.Parameters.Add(new SqlParameter("userID", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", storeNo));
                    cmd.Parameters.Add(new SqlParameter("id", id));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        storeShelf_v2 it = new storeShelf_v2
                        {
                            id = reader["id"].ToString(),
                            storeNo = reader["storeNo"].ToString(),
                            shelfNo = reader["shelfNo"].ToString(),
                            shelfName = reader["shelfName"].ToString(),
                            divCode = reader["divCode"].ToString(),
                            catCode = reader["catCode"].ToString(),
                            groupCode = reader["groupCode"].ToString(),
                            brandCode = reader["brandCode"].ToString(),
                            functionCode = reader["functionCode"].ToString(),
                            img_id = reader["img_id"].ToString(),
                            render_list = reader["render_list"].ToString(),
                            img_link = reader["img_link"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            createdBy = reader["createdBy"].ToString(),
                            modifyDate = reader["modifyDate"].ToString(),
                            modifyBy = reader["modifyBy"].ToString()

                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_get_UserStoreShelf_v2");
                    return it_r;
                }
            }

        }

        public static List<shelf_Possession> sp_ProductTool_get_ShelfPossession(string userID, string shelfCode)
        {
            List<shelf_Possession> it_r = new List<shelf_Possession>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_get_ShelfPossession", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userID", userID));
                    cmd.Parameters.Add(new SqlParameter("shelfCode", shelfCode));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        shelf_Possession it = new shelf_Possession
                        {
                            shelfNo = reader["shelfNo"].ToString(),
                            shelfName = reader["shelfName"].ToString(),
                            height = decimal.Parse(reader["height"].ToString()),
                            width = decimal.Parse(reader["width"].ToString()),
                            depth = decimal.Parse(reader["depth"].ToString()),
                            level = int.Parse(reader["level"].ToString()),
                            P_height = decimal.Parse(reader["P_height"].ToString()),

                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_get_ShelfPossession");
                    return it_r;
                }
            }

        }

        public static List<MagentoCategory> sp_ProductTool_get_MagentoCategory()
        {
            List<MagentoCategory> it_r = new List<MagentoCategory>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_get_MagentoCategory", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        MagentoCategory it = new MagentoCategory
                        {
                            id = reader["id"].ToString(),
                            level = int.Parse(reader["level"].ToString()),
                            parent_id = reader["parent_id"].ToString(),
                            name = reader["name"].ToString(),
                            patch = reader["patch"].ToString(),
                            product_count = int.Parse(reader["product_count"].ToString())
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_get_MagentoCategory");
                    return it_r;
                }
            }

        }

        public static List<MagentoProduct> sp_ProductTool_get_MagentoProduct(string catID)
        {
            List<MagentoProduct> it_r = new List<MagentoProduct>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_get_MagentoProduct", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("catID", catID));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        MagentoProduct it = new MagentoProduct
                        {
                            id = reader["id"].ToString(),
                            sku = reader["sku"].ToString(),
                            catID = reader["catID"].ToString(),
                            name = reader["name"].ToString(),
                            price = reader["price"].ToString(),
                            image_link = reader["image_link"].ToString()
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_get_MagentoProduct");
                    return it_r;
                }
            }

        }

        public static List<MagentoProduct_v2> sp_ProductTool_get_MagentoProduct_v2(string catID)
        {
            List<MagentoProduct_v2> it_r = new List<MagentoProduct_v2>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_get_MagentoProduct_v2", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("catID", catID));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        MagentoProduct_v2 it = new MagentoProduct_v2
                        {
                            id = reader["id"].ToString(),
                            sku = reader["sku"].ToString(),
                            catID = reader["catID"].ToString(),
                            name = reader["name"].ToString(),
                            price = reader["price"].ToString(),
                            image_link = reader["image_link"].ToString(),
                            height = decimal.Parse(reader["height"].ToString()),
                            width = decimal.Parse(reader["width"].ToString()),
                            z_index = int.Parse(reader["z_index"].ToString()),
                            display = decimal.Parse(reader["display"].ToString()),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {

                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_get_MagentoProduct_v2");
                    return it_r;
                }
            }

        }

        public static List<StoreRender> sp_ProductTool_Img_get_StoreRender(int type, string uid, string storeNo, string id)
        {
            List<StoreRender> it_r = new List<StoreRender>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_Img_get_StoreRender", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("type", type));
                    cmd.Parameters.Add(new SqlParameter("userID", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", storeNo));
                    cmd.Parameters.Add(new SqlParameter("id", id));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        StoreRender it = new StoreRender
                        {
                            id = reader["id"].ToString(),
                            storeNo = reader["storeNo"].ToString(),
                            name = reader["name"].ToString(),
                            linkImage = reader["linkImage"].ToString(),
                            status = int.Parse(reader["status"].ToString()),
                            createdBy = reader["createdBy"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            modifyBy = reader["modifyBy"].ToString(),
                            modifyDate = reader["modifyDate"].ToString()
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_Img_get_StoreRender");
                    return it_r;
                }
            }

        }

        public static List<storeShelf> sp_ProductTool_get_ScoreLayout(string uid, string storeNo)
        {
            List<storeShelf> it_r = new List<storeShelf>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_get_ScoreLayout", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userID", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", storeNo));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        storeShelf it = new storeShelf
                        {
                            id = int.Parse(reader["id"].ToString()),
                            storeNo = reader["storeNo"].ToString(),
                            shelfNo = reader["shelfNo"].ToString(),
                            shelfName = reader["shelfName"].ToString(),
                            catNo = reader["catNo"].ToString(),
                            catName = reader["catName"].ToString(),
                            img_link = reader["img_link"].ToString(),
                            status = int.Parse(reader["status"].ToString()),
                            createdBy = reader["createdBy"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            comment = reader["comment"].ToString()
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_get_ScoreLayout");
                    return it_r;
                }
            }

        }

        public static List<scoreItem> sp_ProductTool_ScoreLayout_RP(string uid, string dateFill, string dataFill)
        {
            List<scoreItem> it_r = new List<scoreItem>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_ScoreLayout_RP", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userID", uid));
                    cmd.Parameters.Add(new SqlParameter("dateFill", dateFill));
                    cmd.Parameters.Add(new SqlParameter("dataFill", dataFill));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        scoreItem it = new scoreItem
                        {
                            id = reader["id"].ToString(),
                            storeNo = reader["storeNo"].ToString(),
                            shelfNo = reader["shelfNo"].ToString(),
                            shelfName = reader["shelfName"].ToString(),
                            catNo = reader["catNo"].ToString(),
                            img_link = reader["img_link"].ToString(),
                            createdBy = reader["createdBy"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            acceptBy = reader["acceptBy"].ToString(),
                            acceptDate = reader["acceptDate"].ToString(),
                            points = int.Parse(reader["points"].ToString()),
                            pointBy = reader["pointBy"].ToString(),
                            pointDate = reader["pointDate"].ToString()

                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;


                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ScoreLayout_RP");
                    return it_r;
                }
            }

        }
        #endregion

        #region actionData
        public static bool sp_ProductTool_Add_ImgStoreShelf(string uid, storeShelf it)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_Add_ImgStoreShelf", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userID", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", it.storeNo));
                    cmd.Parameters.Add(new SqlParameter("shelfNo", it.shelfNo));
                    cmd.Parameters.Add(new SqlParameter("sub_id", it.sub_id));
                    cmd.Parameters.Add(new SqlParameter("catNo", it.catNo));
                    cmd.Parameters.Add(new SqlParameter("img_link", it.img_link));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    //if (reader > 0)
                    //{
                    return true;
                    //}
                    //else
                    //{
                    //    return false;
                    //}
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_Add_ImgStoreShelf");
                return false;
            }
        }

        public static bool sp_ProductTool_Add_ImgStoreShelf_v2(string uid, storeShelf_v2 it)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_Add_ImgStoreShelf_v2", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userID", uid));
                    cmd.Parameters.Add(new SqlParameter("refSS_Code", it.id));
                    cmd.Parameters.Add(new SqlParameter("img_link", it.img_link));
                    cmd.Parameters.Add(new SqlParameter("render_list", it.render_list));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    //if (reader > 0)
                    //{
                    return true;
                    //}
                    //else
                    //{
                    //    return false;
                    //}
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_Add_ImgStoreShelf_v2");
                return false;
            }
        }

        public static bool sp_ProductTool_update_ImgStoreShelf(int type, string uid, int id, string cmt)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_update_ImgStoreShelf", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userID", uid));
                    cmd.Parameters.Add(new SqlParameter("id", id));
                    cmd.Parameters.Add(new SqlParameter("type", type));
                    cmd.Parameters.Add(new SqlParameter("description", cmt));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_update_ImgStoreShelf");
                return false;
            }
        }

        public static bool sp_ProductTool_Img_add_StoreRender(StoreRender it, string uid)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_Img_add_StoreRender", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userID", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", it.storeNo));
                    cmd.Parameters.Add(new SqlParameter("name", it.name));
                    cmd.Parameters.Add(new SqlParameter("linkImage", it.linkImage));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    //if (reader > 0)
                    //{
                    return true;
                    //}
                    //else
                    //{
                    //    return false;
                    //}
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_Img_add_StoreRender");
                return false;
            }
        }

        public static bool sp_ProductTool_Img_update_StoreRender(string uid, string id, string storeNo)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_Img_update_StoreRender", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userID", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", storeNo));
                    cmd.Parameters.Add(new SqlParameter("id", id));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_Img_update_StoreRender");
                return false;
            }
        }

        public static bool sp_ProductTool_add_ScoreLayout(string uid, ShelfList it)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_add_ScoreLayout", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userID", uid));
                    cmd.Parameters.Add(new SqlParameter("ImageID", it.imgID));
                    cmd.Parameters.Add(new SqlParameter("description", it.description));
                    cmd.Parameters.Add(new SqlParameter("status", it.imgStatus));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_add_ScoreLayout");
                return false;
            }
        }
        #endregion

        #endregion

        #endregion

        #region SpaceMan

        public static List<StoreList> sp_SpaceMan_StoreList_get(string uid)
        {
            List<StoreList> it_r = new List<StoreList>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_StoreList_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        StoreList it = new StoreList
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            provinceCode = reader["provinceCode"].ToString(),
                            provinceName = reader["provinceName"].ToString(),
                            total_Shelf = reader["total_Shelf"].ToString(),
                            totalFloor = int.Parse(reader["totalFloor"].ToString()),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_SpaceMan_StoreList_get");
                    return it_r;
                }
            }

        }

        public static List<ItemList> sp_SpaceMan_ShelfItem_get(string uid, ItemList it)
        {
            List<ItemList> it_r = new List<ItemList>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_ShelfItem_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;


                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", it.storeNo));
                    cmd.Parameters.Add(new SqlParameter("shelfCode", it.shelfCode));
                    cmd.Parameters.Add(new SqlParameter("subCode", it.subCode));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ItemList its = new ItemList
                        {
                            storeNo = reader["storeNo"].ToString(),
                            shelfCode = reader["shelfCode"].ToString(),
                            subCode = reader["subCode"].ToString(),
                            itemNo = reader["itemNo"].ToString(),
                            itemName = reader["itemName"].ToString(),
                            img_link = reader["img_link"].ToString(),
                            presentStock = reader["presentStock"].ToString(),
                            site = reader["site"].ToString(),
                            rate = reader["rate"].ToString(),
                            range = reader["range"].ToString(),
                            Brand = reader["Brand"].ToString(),
                            MaxChot = reader["MaxChot"].ToString(),
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_SpaceMan_ShelfItem_get");
                    return it_r;
                }

            }
        }


        public static List<ShelfList> sp_SpaceMan_Store_shelfList_get(string uid, string storeNo, int type)
        {
            List<ShelfList> it_r = new List<ShelfList>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_Store_shelfList_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", storeNo));
                    cmd.Parameters.Add(new SqlParameter("type", type));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ShelfList its = new ShelfList
                        {
                            storeNo = reader["storeNo"].ToString(),
                            shelfCode = reader["shelfCode"].ToString(),
                            subCode = reader["subCode"].ToString(),
                            shelfName = reader["shelfName"].ToString(),
                            imgID = reader["imgID"].ToString(),
                            img_link = reader["img_link"].ToString(),
                            createdBy = reader["createdBy"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            imgStatus = reader["imgStatus"].ToString(),
                            Division = reader["Division"].ToString(),
                            Category = reader["Category"].ToString(),
                            Group_Name = reader["Group_Name"].ToString(),
                            Function = reader["Function"].ToString(),
                            img_root = reader["img_root"].ToString(),
                            imgStatusName = reader["imgStatusName"].ToString()
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_SpaceMan_Store_shelfList_get");
                    return it_r;
                }
            }

        }

        public static List<Models.SpaceMan.userRole> sp_qlkd_UserRole_get(string uid)
        {

            List<Models.SpaceMan.userRole> it_s = new List<Models.SpaceMan.userRole>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_qlkd_UserRole_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Models.SpaceMan.userRole its = new Models.SpaceMan.userRole
                        {
                            userID = reader["userID"].ToString(),
                            roleCode = reader["roleCode"].ToString(),
                            controlCode = reader["controlCode"].ToString(),
                            controlName = reader["controlName"].ToString(),
                            create_act = reader["create_act"].ToString(),
                            edit_act = reader["edit_act"].ToString(),
                            accept_act = reader["accept_act"].ToString(),
                            view_act = reader["view_act"].ToString(),
                            root_act = reader["root_act"].ToString(),
                            Div = reader["Div"].ToString(),
                            source = reader["source"].ToString(),
                        };

                        it_s.Add(its);
                    }
                    con.Close();

                    return it_s;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_qlkd_UserRole_get");
                    return it_s;
                }
            }
        }

        public static List<Models.SpaceMan.userRole> sp_ProductTool_SpaceMan_UserRole_get(string uid)
        {

            List<Models.SpaceMan.userRole> it_s = new List<Models.SpaceMan.userRole>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_UserRole_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Models.SpaceMan.userRole its = new Models.SpaceMan.userRole
                        {
                            userID = reader["userID"].ToString(),
                            roleCode = reader["roleCode"].ToString(),
                            controlCode = reader["controlCode"].ToString(),
                            controlName = reader["controlName"].ToString(),
                            create_act = reader["create_act"].ToString(),
                            edit_act = reader["edit_act"].ToString(),
                            accept_act = reader["accept_act"].ToString(),
                            view_act = reader["view_act"].ToString(),
                            root_act = reader["root_act"].ToString(),
                            points_act = reader["points_act"].ToString(),
                        };

                        it_s.Add(its);
                    }
                    con.Close();

                    return it_s;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_UserRole_get");
                    return it_s;
                }
            }

        }

        public static bool sp_SpaceMan_Img_StoreShelf_add(string uid, ShelfList it)
        {

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_Img_StoreShelf_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", it.storeNo));
                    cmd.Parameters.Add(new SqlParameter("shelfNo", it.shelfCode));
                    cmd.Parameters.Add(new SqlParameter("sub_id", it.subCode));
                    cmd.Parameters.Add(new SqlParameter("img_link", it.img_link));


                    var reader = cmd.ExecuteNonQuery();

                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_SpaceMan_Img_StoreShelf_add");
                    return false;
                }
            }




        }

        public static bool sp_SpaceMan_Img_StoreShelf_update(string uid, ShelfList it)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_Img_StoreShelf_update", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("imgID", it.imgID));
                    cmd.Parameters.Add(new SqlParameter("type", it.imgStatus));
                    cmd.Parameters.Add(new SqlParameter("description", it.description));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();
                }

                return true;

            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_SpaceMan_Img_StoreShelf_update");
                return false;
            }
        }

        public static bool sp_ProductTool_SpaceMan_ref_Store_Shelf_Item_add(string uid, ItemList it)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_ref_Store_Shelf_Item_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", it.storeNo));
                    cmd.Parameters.Add(new SqlParameter("shelfCode", it.shelfCode));
                    cmd.Parameters.Add(new SqlParameter("subCode", it.subCode));
                    cmd.Parameters.Add(new SqlParameter("itemNo", it.itemNo));
                    cmd.Parameters.Add(new SqlParameter("presentStock", it.presentStock));
                    cmd.Parameters.Add(new SqlParameter("site", it.site));
                    cmd.Parameters.Add(new SqlParameter("rate", it.rate));


                    var reader = cmd.ExecuteNonQuery();

                    con.Close();
                }

                return true;

            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_ref_Store_Shelf_Item_add");
                return false;
            }
        }

        public static bool sp_ProductTool_SpaceMan_ref_Store_Shelf_Item_disbale(string uid, ItemList it)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_ref_Store_Shelf_Item_disbale", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", it.storeNo));
                    cmd.Parameters.Add(new SqlParameter("shelfCode", it.shelfCode));
                    cmd.Parameters.Add(new SqlParameter("subCode", it.subCode));


                    var reader = cmd.ExecuteNonQuery();

                    con.Close();
                }

                return true;

            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_ref_Store_Shelf_Item_disbale");
                return false;
            }
        }

        public static List<StoreLayout_Line> sp_ProductTool_SpaceMan_StoreLayout_Line_get(string uid, string storeNo)
        {
            List<StoreLayout_Line> it_r = new List<StoreLayout_Line>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_StoreLayout_Line_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;


                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", storeNo));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        StoreLayout_Line its = new StoreLayout_Line
                        {
                            storeNo = reader["storeNo"].ToString(),
                            SL_Code = reader["SL_Code"].ToString(),
                            SL_Name = reader["SL_Name"].ToString(),
                            link = reader["link"].ToString()
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_StoreLayout_Line_get");
                    return it_r;
                }
            }

        }

        public static bool sp_ProductTool_SpaceMan_StoreLayout_Line_add(string uid, StoreLayout_Line it)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_StoreLayout_Line_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", it.storeNo));
                    cmd.Parameters.Add(new SqlParameter("SL_Code", it.SL_Code));
                    cmd.Parameters.Add(new SqlParameter("link", it.link));


                    var reader = cmd.ExecuteNonQuery();

                    con.Close();
                }

                return true;

            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_StoreLayout_Line_add");
                return false;
            }
        }

        public static bool sp_ProductTool_SpaceMan_ScoreLayout_add(string uid, ScoreLayout it)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_ScoreLayout_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("ImageID", it.ImageID));
                    cmd.Parameters.Add(new SqlParameter("description", it.description));
                    cmd.Parameters.Add(new SqlParameter("status", it.status));


                    var reader = cmd.ExecuteNonQuery();

                    con.Close();
                }

                return true;

            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_ScoreLayout_add");
                return false;
            }
        }

        public static bool sp_ProductTool_SpaceMan_Store_Shelf_ImgRoot_add(string uid, ImgRoot it)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_Store_Shelf_ImgRoot_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", it.storeNo));
                    cmd.Parameters.Add(new SqlParameter("shelfCode", it.shelfCode));
                    cmd.Parameters.Add(new SqlParameter("subCode", it.subCode));
                    cmd.Parameters.Add(new SqlParameter("img_root", it.img_root));


                    var reader = cmd.ExecuteNonQuery();

                    con.Close();
                }

                return true;

            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_Store_Shelf_ImgRoot_add");
                return false;
            }
        }

        public static List<ImgRoot> sp_ProductTool_SpaceMan_Store_Shelf_ImgRoot_get(string uid, string storeNo)
        {
            List<ImgRoot> it_r = new List<ImgRoot>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_Store_Shelf_ImgRoot_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", storeNo));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ImgRoot its = new ImgRoot
                        {
                            storeNo = reader["storeNo"].ToString(),
                            shelfCode = reader["shelfCode"].ToString(),
                            subCode = reader["subCode"].ToString(),
                            img_root = reader["img_root"].ToString(),
                            status = reader["status"].ToString(),

                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_Store_Shelf_ImgRoot_get");
                    return it_r;
                }
            }

        }

        public static List<ShelfList> sp_ProductTool_SpaceMan_Img_StoreShelf_getAll(string uid, ShelfList it)
        {
            List<ShelfList> it_r = new List<ShelfList>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_Img_StoreShelf_getAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", it.storeNo));
                    cmd.Parameters.Add(new SqlParameter("shelfNo", it.shelfCode));
                    cmd.Parameters.Add(new SqlParameter("sub_id", it.subCode));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ShelfList its = new ShelfList
                        {
                            storeNo = reader["storeNo"].ToString(),
                            shelfCode = reader["shelfCode"].ToString(),
                            subCode = reader["subCode"].ToString(),
                            shelfName = reader["shelfName"].ToString(),
                            imgID = reader["imgID"].ToString(),
                            img_link = reader["img_link"].ToString(),
                            createdBy = reader["createdBy"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            imgStatus = reader["imgStatus"].ToString(),
                            Division = reader["Division"].ToString(),
                            Category = reader["Category"].ToString(),
                            Group_Name = reader["Group_Name"].ToString(),
                            Function = reader["Function"].ToString(),
                            img_root = reader["img_root"].ToString(),
                            imgStatusName = reader["imgStatusName"].ToString()
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {

                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_Img_StoreShelf_getAll");
                    return it_r;
                }
            }

        }

        public static List<ShelfList> sp_ProductTool_SpaceMan_Store_Shelf_ImgRoot_getAll(string uid, ShelfList it)
        {
            List<ShelfList> it_r = new List<ShelfList>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_Store_Shelf_ImgRoot_getAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", it.storeNo));
                    cmd.Parameters.Add(new SqlParameter("shelfNo", it.shelfCode));
                    cmd.Parameters.Add(new SqlParameter("sub_id", it.subCode));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ShelfList its = new ShelfList
                        {
                            storeNo = reader["storeNo"].ToString(),
                            shelfCode = reader["shelfCode"].ToString(),
                            subCode = reader["subCode"].ToString(),
                            createdDate = reader["createDate"].ToString(),
                            img_root = reader["img_root"].ToString()
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_Store_Shelf_ImgRoot_getAll");
                    return it_r;
                }
            }

        }

        public static List<StoreLayout_Line> sp_ProductTool_SpaceMan_StoreLayout_Line_getAll(string uid, string storeNo)
        {
            List<StoreLayout_Line> it_r = new List<StoreLayout_Line>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_StoreLayout_Line_getAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", storeNo));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        StoreLayout_Line its = new StoreLayout_Line
                        {
                            storeNo = reader["storeNo"].ToString(),
                            SL_Code = reader["SL_Code"].ToString(),
                            link = reader["link"].ToString(),
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_StoreLayout_Line_getAll");
                    return it_r;
                }
            }

        }

        public static List<RateNew> sp_ProductTool_SpaceMan_RP_RateNew(string uid, string fromDate, string toDate)
        {
            List<RateNew> it_r = new List<RateNew>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_RP_RateNew", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("fromDate", fromDate));
                    cmd.Parameters.Add(new SqlParameter("toDate", toDate));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        RateNew its = new RateNew
                        {
                            storeNo = reader["storeNo"].ToString(),
                            provinceCode = reader["provinceCode"].ToString(),
                            total_new = int.Parse(reader["total_new"].ToString()),
                            total_accept = int.Parse(reader["total_accept"].ToString()),
                            rate = decimal.Parse(reader["rate"].ToString())
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_RP_RateNew");
                    return it_r;
                }
            }

        }

        public static List<FQ_Score> sp_ProductTool_SpaceMan_RP_FQ(string uid, string year, string month)
        {
            List<FQ_Score> it_r = new List<FQ_Score>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_RP_FQ", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("year", year));
                    cmd.Parameters.Add(new SqlParameter("month", month));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        FQ_Score its = new FQ_Score
                        {
                            staffNo = reader["staffNo"].ToString(),
                            staffName = reader["staffName"].ToString(),
                            positionCode = reader["positionCode"].ToString(),
                            positionName = reader["positionName"].ToString(),
                            m_year = reader["m_year"].ToString(),
                            m_month = reader["m_month"].ToString(),
                            qtyDay = int.Parse(reader["qtyDay"].ToString()),
                            qty = int.Parse(reader["qty"].ToString())
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_RP_FQ");
                    return it_r;
                }
            }

        }

        public static List<Adv_Header> sp_ProductTool_SpaceMan_Adv_Header_get(string uid)
        {
            List<Adv_Header> it_r = new List<Adv_Header>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_Adv_Header_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Adv_Header its = new Adv_Header
                        {
                            no = reader["id"].ToString(),
                            name = reader["name"].ToString()
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_Adv_Header_get");
                    return it_r;
                }
            }

        }

        public static List<Adv_Line> sp_ProductTool_SpaceMan_Adv_Line_get(string uid, string storeNo)
        {
            List<Adv_Line> it_r = new List<Adv_Line>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_Adv_Line_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", storeNo));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Adv_Line its = new Adv_Line
                        {
                            id = reader["id"].ToString(),
                            storeNo = reader["storeNo"].ToString(),
                            headerId = reader["headerId"].ToString(),
                            headerName = reader["headerName"].ToString(),
                            imgLink = reader["imgLink"].ToString(),
                            description = reader["description"].ToString(),
                            status = reader["status"].ToString(),
                            createdBy = reader["createdBy"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            modifyBy = reader["modifyBy"].ToString(),
                            modifyDate = reader["modifyDate"].ToString(),
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {

                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_Adv_Line_get");
                    return it_r;
                }
            }

        }

        public static bool sp_ProductTool_SpaceMan_Adv_Line_add(string uid, Adv_Line it)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_Adv_Line_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", it.storeNo));
                    cmd.Parameters.Add(new SqlParameter("headerId", it.headerId));
                    cmd.Parameters.Add(new SqlParameter("imgLink", it.imgLink));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_Adv_Line_add");
                return false;
            }
        }


        public static bool sp_ProductTool_SpaceMan_Adv_Line_update(string uid, Adv_Line it)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_Adv_Line_update", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("lineId", it.id));
                    cmd.Parameters.Add(new SqlParameter("status", it.status));
                    cmd.Parameters.Add(new SqlParameter("description", it.description));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_Adv_Line_update");
                return false;
            }
        }

        public static List<LayoutItem> sp_ProductTool_SpaceMan_LayoutType_get()
        {
            List<LayoutItem> it_r = new List<LayoutItem>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_LayoutType_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        LayoutItem its = new LayoutItem
                        {
                            Code = reader["code"].ToString(),
                            Name = reader["name"].ToString(),
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {

                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_LayoutType_get");
                    return it_r;
                }
            }
        }


        public static List<LayoutItem> sp_ProductTool_SpaceMan_OutdoorType_get()
        {
            List<LayoutItem> it_r = new List<LayoutItem>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_OutdoorType_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        LayoutItem its = new LayoutItem
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {

                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_OutdoorType_get");
                    return it_r;
                }
            }
        }

        public static List<LayoutItem> sp_ProductTool_SpaceMan_Syn3DType_get()
        {
            List<LayoutItem> it_r = new List<LayoutItem>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_Syn3DType_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        LayoutItem its = new LayoutItem
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {

                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_Syn3DType_get");
                    return it_r;
                }
            }
        }

        public static List<LayoutLine> sp_ProductTool_SpaceMan_Layout_Line_get(string uid, LayoutLine it)
        {
            List<LayoutLine> it_r = new List<LayoutLine>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_Layout_Line_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", it.storeNo));
                    cmd.Parameters.Add(new SqlParameter("type", it.type));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        LayoutLine its = new LayoutLine
                        {
                            id = reader["id"].ToString(),
                            storeNo = reader["storeNo"].ToString(),
                            type = reader["type"].ToString(),
                            subType = reader["subType"].ToString(),
                            floorNo = reader["floorNo"].ToString(),
                            typeCode = reader["typeCode"].ToString(),
                            imgLink = reader["imgLink"].ToString(),
                            status = reader["status"].ToString(),
                            description = reader["description"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            createdBy = reader["createdBy"].ToString(),
                            modifyDate = reader["modifyDate"].ToString(),
                            modifyBy = reader["modifyBy"].ToString(),

                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {

                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_Layout_Line_get");
                    return it_r;
                }
            }
        }


        public static bool sp_ProductTool_SpaceMan_Layout_Line_add(string uid, LayoutLine it)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SpaceMan_Layout_Line_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", it.storeNo));
                    cmd.Parameters.Add(new SqlParameter("type", it.type));
                    cmd.Parameters.Add(new SqlParameter("subType", it.subType));
                    cmd.Parameters.Add(new SqlParameter("floorNo", it.floorNo));
                    cmd.Parameters.Add(new SqlParameter("typeCode", it.typeCode != null ? it.typeCode : ""));
                    cmd.Parameters.Add(new SqlParameter("imgLink", it.imgLink));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {

                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SpaceMan_Layout_Line_add");
                    return false;
                }
            }
        }

        #endregion

        #region SourceProduct

        public static List<sourceItem> sp_ProductTool_SourceProduct_Info_get(string uid, string str_fillter, string status)
        {
            List<sourceItem> it_r = new List<sourceItem>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SourceProduct_Info_get", con);
                    cmd.CommandTimeout = 3000;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("fillter", str_fillter));
                    cmd.Parameters.Add(new SqlParameter("type", status));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        sourceItem it = new sourceItem
                        {
                            id = reader["id"].ToString(),
                            sku = reader["sku"].ToString(),
                            name = reader["name"].ToString(),
                            vendorCode = reader["vendorCode"].ToString(),
                            vendorName = reader["vendorName"].ToString(),
                            Total_PR_Qty = reader["Total_PR_Qty"].ToString(),
                            descriptions = reader["descriptions"].ToString(),
                            imgLink = reader["imgLink"].ToString(),
                            corePrice = reader["corePrice"].ToString(),
                            price = reader["price"].ToString(),
                            url_link = reader["url_link"].ToString(),
                            DivisionCode = reader["DivisionCode"].ToString(),
                            DivisionName = reader["DivisionName"].ToString(),
                            CategoryCode = reader["CategoryCode"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            GroupCode = reader["GroupCode"].ToString(),
                            GroupName = reader["GroupName"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),
                            UoM = reader["UoM"].ToString(),
                            status = reader["status"].ToString(),
                            createBy = reader["createBy"].ToString(),
                            createDate = reader["createDate"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SourceProduct_Info_get");
                    return it_r;
                }
            }

        }

        public static bool sp_ProductTool_SourceProduct_Info_add(string uid, sourceItem it)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SourceProduct_Info_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("id", it.id));
                    cmd.Parameters.Add(new SqlParameter("sku", it.sku));
                    cmd.Parameters.Add(new SqlParameter("name", it.name));
                    cmd.Parameters.Add(new SqlParameter("vendorName", it.vendorName));
                    cmd.Parameters.Add(new SqlParameter("descriptions", it.descriptions));
                    cmd.Parameters.Add(new SqlParameter("imgLink", it.imgLink));
                    cmd.Parameters.Add(new SqlParameter("corePrice", it.corePrice));
                    cmd.Parameters.Add(new SqlParameter("price", it.price));
                    cmd.Parameters.Add(new SqlParameter("url_link", it.url_link));
                    cmd.Parameters.Add(new SqlParameter("Division", it.DivisionCode));
                    cmd.Parameters.Add(new SqlParameter("Category", it.CategoryCode));
                    cmd.Parameters.Add(new SqlParameter("GroupProduct", it.GroupCode));
                    cmd.Parameters.Add(new SqlParameter("FunctionProduct", it.FunctionCode));
                    cmd.Parameters.Add(new SqlParameter("UoM", it.UoM));



                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SourceProduct_Info_add");
                return false;
            }
        }

        public static bool sp_ProductTool_SourceProduct_Info_update(string uid, sourceItem it)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SourceProduct_Info_update", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("type", int.Parse(it.status)));
                    cmd.Parameters.Add(new SqlParameter("id", it.id));
                    cmd.Parameters.Add(new SqlParameter("description", it.descriptions));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SourceProduct_Info_update");
                return false;
            }
        }

        public static List<DivCatGroupFunc> sp_ProductTool_SourceProduct_DivCatGroupFunc_get(string uid)
        {
            List<DivCatGroupFunc> it_r = new List<DivCatGroupFunc>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SourceProduct_DivCatGroupFunc_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DivCatGroupFunc it = new DivCatGroupFunc
                        {
                            DivisionCode = reader["DivisionCode"].ToString(),
                            DivisionName = reader["DivisionName"].ToString(),
                            CategoryCode = reader["CategoryCode"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            GroupCode = reader["GroupCode"].ToString(),
                            GroupName = reader["GroupName"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),
                            UoM = reader["UoM"].ToString()
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SourceProduct_DivCatGroupFunc_get");
                    return it_r;
                }
            }

        }



        public static List<MDS_DivCatGroupFunc> sp_ProductTool_MDS_DivCatGroupFunc_get(string uid, string type, string fillter)
        {

            // div-cat-group-func

            List<MDS_DivCatGroupFunc> it_r = new List<MDS_DivCatGroupFunc>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_MDS_DivCatGroupFunc_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("type", type));
                    cmd.Parameters.Add(new SqlParameter("fillter", fillter));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        MDS_DivCatGroupFunc it = new MDS_DivCatGroupFunc
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;

                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_MDS_DivCatGroupFunc_get");
                    return it_r;
                }
            }

        }

        public static bool sp_ProductTool_MDS_DivCatGroupFunc_add(string uid, string type, string Code, string Name, string ParentCode)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_MDS_DivCatGroupFunc_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("type", type));
                    cmd.Parameters.Add(new SqlParameter("Code", Code));
                    cmd.Parameters.Add(new SqlParameter("Name", Name));
                    cmd.Parameters.Add(new SqlParameter("ParentCode", ParentCode != null ? ParentCode : ""));


                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_MDS_DivCatGroupFunc_add");
                return false;
            }
        }

        public static List<DivCatGroupFunc> sp_ProductTool_SourceProduct_DivCatGroupFunc_v2_get(string uid)
        {
            List<DivCatGroupFunc> it_r = new List<DivCatGroupFunc>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_SourceProduct_DivCatGroupFunc_v2_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DivCatGroupFunc it = new DivCatGroupFunc
                        {
                            DivisionCode = reader["DivisionCode"].ToString(),
                            DivisionName = reader["DivisionName"].ToString(),
                            CategoryCode = reader["CategoryCode"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            GroupCode = reader["GroupCode"].ToString(),
                            GroupName = reader["GroupName"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),

                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;

                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_SourceProduct_DivCatGroupFunc_v2_get");
                    return it_r;
                }
            }

        }
        public static List<DivCatGroupFunc> sp_SourceProduct_DivCatGroupFunc_v2_get_ProNew()
        {
            List<DivCatGroupFunc> it_r = new List<DivCatGroupFunc>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_SourceProduct_DivCatGroupFunc_v2_get_ProNew", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DivCatGroupFunc it = new DivCatGroupFunc
                        {
                            DivisionCode = reader["DivisionCode"].ToString(),
                            DivisionName = reader["DivisionName"].ToString(),
                            CategoryCode = reader["CategoryCode"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            GroupCode = reader["GroupCode"].ToString(),
                            GroupName = reader["GroupName"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),

                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;

                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_SourceProduct_DivCatGroupFunc_v2_get_ProNew");
                    return it_r;
                }
            }

        }
        public static List<DivCatGroupFunc> sp_bbs_DivCatGroupFunc_KM(string uid)
        {
            List<DivCatGroupFunc> it_r = new List<DivCatGroupFunc>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_DivCatGroupFunc_KM", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DivCatGroupFunc it = new DivCatGroupFunc
                        {
                            DivisionCode = reader["DivisionCode"].ToString(),
                            DivisionName = reader["DivisionName"].ToString(),
                            CategoryCode = reader["CategoryCode"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            GroupCode = reader["GroupCode"].ToString(),
                            GroupName = reader["GroupName"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),

                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;

                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_DivCatGroupFunc_KM");
                    return it_r;
                }
            }

        }

        #endregion

        #region ScoreStore

        public static List<storeItem> sp_ProductTool_ScoreStore_StoreList_get(string uid)
        {
            List<storeItem> it_r = new List<storeItem>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_ScoreStore_StoreList_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        storeItem it = new storeItem
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            provinceCode = reader["provinceCode"].ToString(),
                            provinceName = reader["provinceName"].ToString()
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ScoreStore_StoreList_get");
                    return it_r;
                }
            }

        }


        public static List<ScoreStoreHeader> sp_ProductTool_ScoreStore_Header_get(string uid)
        {
            List<ScoreStoreHeader> it_r = new List<ScoreStoreHeader>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_ScoreStore_Header_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ScoreStoreHeader it = new ScoreStoreHeader
                        {
                            departmentCode = reader["departmentCode"].ToString(),
                            departmentName = reader["departmentName"].ToString(),
                            requirementCode = reader["requirementCode"].ToString(),
                            requirementName = reader["requirementName"].ToString(),
                            reqImg = reader["reqImg"].ToString(),
                            points = reader["points"].ToString(),
                            status = int.Parse(reader["status"].ToString()),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;

                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ScoreStore_Header_get");
                    return it_r;
                }
            }

        }

        public static List<ScoreStoreHeader> sp_ProductTool_ScoreStore_Header_get_v2(string uid, string storeNo)
        {
            List<ScoreStoreHeader> it_r = new List<ScoreStoreHeader>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_ScoreStore_Header_get_v2", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", storeNo));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ScoreStoreHeader it = new ScoreStoreHeader
                        {
                            departmentCode = reader["departmentCode"].ToString(),
                            departmentName = reader["departmentName"].ToString(),
                            requirementCode = reader["requirementCode"].ToString(),
                            requirementName = reader["requirementName"].ToString(),
                            reqImg = reader["reqImg"].ToString(),
                            points = reader["points"].ToString(),
                            status = int.Parse(reader["status"].ToString()),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ScoreStore_Header_get_v2");
                    return it_r;
                }
            }

        }

        public static List<reportItem> sp_ProductTool_ScoreStore_Report(string uid, string storeNo, string fromDate, string toDate)
        {
            List<reportItem> it_r = new List<reportItem>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_ScoreStore_Report", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("storeNo", storeNo));

                    if (fromDate.Length > 0)
                    {
                        cmd.Parameters.Add(new SqlParameter("fromDate", fromDate));
                    }

                    if (toDate.Length > 0)
                    {
                        cmd.Parameters.Add(new SqlParameter("toDate", toDate));
                    }





                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        reportItem it = new reportItem
                        {
                            departmentCode = reader["departmentCode"].ToString(),
                            requirementCode = reader["requirementCode"].ToString(),
                            requirementName = reader["requirementName"].ToString(),
                            storeNo = reader["storeNo"].ToString(),
                            status = reader["status"].ToString(),
                            statusName = reader["statusName"].ToString(),
                            imageSource = reader["imageSource"].ToString(),
                            description = reader["description"].ToString(),
                            createBy = reader["createBy"].ToString(),
                            createDate = reader["createDate"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;

                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ScoreStore_Report");
                    return it_r;
                }
            }

        }

        public static bool sp_ProductTool_ScoreStore_Header_add(string uid, ScoreStoreHeader it)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_ScoreStore_Header_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("departmentCode", it.departmentCode != null ? it.departmentCode : ""));
                    cmd.Parameters.Add(new SqlParameter("requirementCode", it.requirementCode != null ? it.requirementCode : ""));
                    cmd.Parameters.Add(new SqlParameter("requirementName", it.requirementName != null ? it.requirementName : ""));
                    cmd.Parameters.Add(new SqlParameter("points", it.points != null ? it.points : "0"));
                    cmd.Parameters.Add(new SqlParameter("status", it.status));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ScoreStore_Header_add");
                return false;
            }
        }

        public static bool sp_ProductTool_ScoreStore_Lines_add(string uid, ScoreStoreLine it)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_ScoreStore_Lines_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("requirementCode", it.requirementCode));
                    cmd.Parameters.Add(new SqlParameter("storeNo", it.storeNo));
                    cmd.Parameters.Add(new SqlParameter("type", it.type));
                    cmd.Parameters.Add(new SqlParameter("imageSource", it.imageSource != null ? it.imageSource : ""));
                    cmd.Parameters.Add(new SqlParameter("description", it.description != null ? it.description : ""));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ScoreStore_Lines_add");
                return false;
            }
        }
        #endregion

        #region toDoList

        public static List<ToDo_Head> sp_ProductTool_ToDoList_Header_get(string uid)
        {
            List<ToDo_Head> it_r = new List<ToDo_Head>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_ToDoList_Header_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ToDo_Head it = new ToDo_Head
                        {
                            requirementCode = reader["requirementCode"].ToString(),
                            requirementName = reader["requirementName"].ToString(),
                            positionCode = reader["positionCode"].ToString(),
                            reqImg = reader["reqImg"].ToString(),
                            status = reader["status"].ToString(),
                            points = reader["points"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ToDoList_Header_get");
                    return it_r;
                }
            }
        }


        public static List<permissioninfo> sp_ProductTool_getPermissionforAdmin(string uid)
        {
            List<permissioninfo> it_r = new List<permissioninfo>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_getPermissionAdmin", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userID", uid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        permissioninfo it = new permissioninfo
                        {

                            fcode = reader["fcode"].ToString(),
                            fname = reader["fname"].ToString(),
                            paname = reader["paname"].ToString(),

                            vcount = int.Parse(reader["ischeck"].ToString()),

                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ToDoList_Header_get");
                    return it_r;
                }
            }
        }

        public static bool sp_ProductTool_updatePermission(string uid, List<permissioninfo> lst)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_updatePermission", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    string fcode = String.Join("|", lst.Where(x => x.vcount == 1).Select(x => x.fcode));
                    cmd.Parameters.Add(new SqlParameter("userID", uid));
                    cmd.Parameters.Add(new SqlParameter("fcode", fcode));
                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ToDoList_Header_get");
                    return false;
                }
            }
        }

        public static List<permissioninfo> sp_ProductTool_getPermissionforAdminBBS(string uid)
        {
            List<permissioninfo> it_r = new List<permissioninfo>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_getPermissionAdminBBS", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userID", uid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        permissioninfo it = new permissioninfo
                        {

                            fcode = reader["fcode"].ToString(),
                            flevel = int.Parse(reader["flevel"].ToString()),
                            fname = reader["fname"].ToString(),
                            paname = reader["paname"].ToString(),
                            parentcode = reader["parentcode"].ToString(),
                            reportpath = reader["reportpath"].ToString(),
                            vcount = int.Parse(reader["ischeck"].ToString()),

                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_getPermissionAdminBBS");
                    return it_r;
                }
            }
        }

        public static List<permissioninfo> sp_bbs_getFunctionbyGroup(string groupcode)
        {
            List<permissioninfo> it_r = new List<permissioninfo>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_getFunctionbyGroup", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("groupcode", groupcode));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        permissioninfo it = new permissioninfo
                        {

                            fcode = reader["fcode"].ToString(),
                            flevel = int.Parse(reader["flevel"].ToString()),
                            fname = reader["fname"].ToString(),
                            paname = reader["paname"].ToString(),
                            parentcode = reader["parentcode"].ToString(),
                            reportpath = reader["reportpath"].ToString(),
                            vcount = int.Parse(reader["ischeck"].ToString()),

                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getFunctionbyGroup");
                    return it_r;
                }
            }
        }


        public static List<groupinfo> sp_bbs_getGroupbyUser(string userID)
        {
            List<groupinfo> it_r = new List<groupinfo>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_getGroupbyUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userID", userID));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        groupinfo it = new groupinfo
                        {

                            gcode = reader["groupcode"].ToString(),
                            gname = reader["groupname"].ToString(),
                            vcount = int.Parse(reader["ischeck"].ToString()),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getGroupbyUser");
                    return it_r;
                }
            }
        }

        public static bool sp_ProductTool_updatePermissionBBS(string uid, string modifyby, List<permissioninfo> lst)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_updatePermissionBBS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    string fcode = String.Join("|", lst.Where(x => x.vcount == 1).Select(x => x.fcode));
                    cmd.Parameters.Add(new SqlParameter("userID", uid));
                    cmd.Parameters.Add(new SqlParameter("fcode", fcode));
                    cmd.Parameters.Add(new SqlParameter("modifyby", modifyby));
                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_updatePermissionBBS");
                    return false;
                }
            }
        }

        public static bool sp_bbs_updatePermissionGroup(string groupcode, List<permissioninfo> lst)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_updatePermissionGroup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    string fcode = String.Join("|", lst.Where(x => x.vcount == 1).Select(x => x.fcode));
                    cmd.Parameters.Add(new SqlParameter("groupcode", groupcode));
                    cmd.Parameters.Add(new SqlParameter("fcode", fcode));
                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_updatePermissionGroup");
                    return false;
                }
            }
        }

        public static bool sp_bbs_updateGroupUser(string userID, List<groupinfo> lst)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_updateGroupUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    string gcode = String.Join("|", lst.Where(x => x.vcount == 1).Select(x => x.gcode));
                    cmd.Parameters.Add(new SqlParameter("userID", userID));
                    cmd.Parameters.Add(new SqlParameter("gcode", gcode));
                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_updateGroupUser");
                    return false;
                }
            }
        }


        public static List<permissioninfo> sp_ProductTool_getPermissionbyUser(string uid)
        {
            List<permissioninfo> it_r = new List<permissioninfo>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ProductTool_getPermissionbyUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userID", uid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        permissioninfo it = new permissioninfo
                        {
                            fcode = reader["fcode"].ToString(),
                            fname = reader["fname"].ToString(),
                            flevel = int.Parse(reader["flevel"].ToString()),
                            parentcode = reader["parentcode"].ToString(),
                            action = reader["action"].ToString(),
                            controller = reader["controller"].ToString(),
                            reportpath = reader["reportpath"].ToString(),
                            vcount = int.Parse(reader["vcount"].ToString()),

                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ToDoList_Header_get");
                    return it_r;
                }
            }
        }


        public static List<permissioninfo> sp_ProductTool_getPermissionbyUserBBS(string uid)
        {
            List<permissioninfo> it_r = new List<permissioninfo>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_getPermissionbyUserBBS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userID", uid));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        permissioninfo it = new permissioninfo
                        {
                            fcode = reader["fcode"].ToString(),
                            fname = reader["fname"].ToString(),
                            flevel = int.Parse(reader["flevel"].ToString()),
                            parentcode = reader["parentcode"].ToString(),
                            action = reader["action"].ToString(),
                            controller = reader["controller"].ToString(),
                            reportpath = reader["reportpath"].ToString(),
                            vcount = int.Parse(reader["vcount"].ToString()),
                            menu = reader["menu"].ToString(),
                            En_Name = reader["En_Name"].ToString(),
                            VN_Name = reader["VN_Name"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_getPermissionbyUserBBS");
                    return it_r;
                }
            }
        }

        public static bool sp_ProductTool_ToDoList_Lines_add(string uid, ToDo_Lines it)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ProductTool_ToDoList_Lines_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("requirementCode", it.requirementCode));
                    cmd.Parameters.Add(new SqlParameter("storeNo", it.storeNo));
                    cmd.Parameters.Add(new SqlParameter("type", it.type));
                    cmd.Parameters.Add(new SqlParameter("imageSource", it.imageSource != null ? it.imageSource : ""));
                    cmd.Parameters.Add(new SqlParameter("description", it.description != null ? it.description : ""));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ProductTool_ToDoList_Lines_add");
                    return false;
                }

            }
        }


        #endregion

        #region POtong

        public static List<objCombox> sp_po_getNguonNhap()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_po_getNguonNhap", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_po_getNguonNhap");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_po_getLydodexuat()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBS_Lydodexuat", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBS_Lydodexuat");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_po_getLydodexuatRR()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBS_LydodexuatRR", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBS_LydodexuatRR");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_po_getUser()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConn1101))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBS_GetUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBS_GetUser101");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_getlistGroup()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getlistGroup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getlistGroup");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_po_getMuavu()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_po_getMuavu", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_po_getMuavu");
                    return it_r;
                }
            }
        }

        public static List<quayke> sp_bbs_getlistQK()
        {
            List<quayke> it_r = new List<quayke>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getlistQK", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        quayke it = new quayke
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            Name = reader["Name"].ToString(),
                            Code = reader["Code"].ToString(),
                            High = decimal.Parse(reader["High"].ToString()),
                            HighNet = decimal.Parse(reader["HighNet"].ToString()),
                            Width = decimal.Parse(reader["Width"].ToString()),
                            WidthNet = decimal.Parse(reader["WidthNet"].ToString()),
                            Depth = decimal.Parse(reader["Depth"].ToString()),
                            DepthNet = decimal.Parse(reader["DepthNet"].ToString()),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getlistQK");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_po_getMien()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_po_getMien", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_po_getMien");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_po_getCang()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_po_getCang", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_po_getCang");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_po_getXuatxu()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBS_Xuatxu", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBS_Xuatxu");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_getChannel()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getChannel", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getChannel");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_getReason()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getReason", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getReason");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_po_getRRHanhDong()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_po_getRRHanhDong", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_po_getRRHanhDong");
                    return it_r;
                }
            }
        }
        #endregion

        #region Trainghiem

        public static List<trainghiem> sp_BBSmart_GetListTraiNghiem(string userid, string MaCH, string Danhmuccon)
        {
            List<trainghiem> it_r = new List<trainghiem>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBSmart_GetListTraiNghiem", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("MaCH", MaCH));
                    cmd.Parameters.Add(new SqlParameter("Danhmuccon", Danhmuccon));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        trainghiem it = new trainghiem
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            MaCH = reader["MaCH"].ToString(),
                            TenCh = reader["TenCh"].ToString(),
                            Danhmuc = reader["Danhmuc"].ToString(),
                            Danhmuccon = reader["Danhmuccon"].ToString(),
                            imgurl = reader["imgurl"].ToString(),
                            STT = reader["STT"].ToString(),
                            ghichu = reader["ghichu"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_GetListTraiNghiem");
                    return it_r;
                }
            }
        }

        public static List<CustomerAutoInfo> sp_GetListCustomerAutoDetail(string userid, string MemberCardNo)
        {
            List<CustomerAutoInfo> it_r = new List<CustomerAutoInfo>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_GetListCustomerAutoDetail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("MemberCardNo", MemberCardNo));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CustomerAutoInfo it = new CustomerAutoInfo
                        {
                            ItemNo = reader["ItemNo"].ToString(),
                            ItemName = reader["ItemName"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_GetListCustomerAutoDetail");
                    return it_r;
                }
            }
        }

        public static bool sp_BBSmart_deleteTraiNghiem(string userid, int ID)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBSmart_deleteTraiNghiem", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("ID", ID));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_deleteTraiNghiem");
                    return false;
                }
            }
        }

        public static bool sp_BBSmart_createupdateTraiNghiem(string userid, trainghiem info)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_createupdateTraiNghiem", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("ID", info.ID));
                    cmd.Parameters.Add(new SqlParameter("MaCH", info.MaCH));
                    cmd.Parameters.Add(new SqlParameter("TenCh", info.TenCh));
                    cmd.Parameters.Add(new SqlParameter("Danhmuc", info.Danhmuc));
                    cmd.Parameters.Add(new SqlParameter("Danhmuccon", info.Danhmuccon));
                    cmd.Parameters.Add(new SqlParameter("ghichu", info.ghichu));
                    cmd.Parameters.Add(new SqlParameter("imgurl", info.imgurl == null ? "" : info.imgurl));
                    cmd.Parameters.Add(new SqlParameter("STT", info.STT));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_createupdateTraiNghiem");
                    return false;
                }
            }
        }

        public static DataTable sp_GetListCustomerAuto(string userid, string storeid)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_GetListCustomerAuto", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("storeid", storeid));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }
                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_GetListCustomerAuto");
                return ds.Tables[0];
            }
        }

        public static bool sp_bbs_UpdateCustomerAuto(string userid, string MemberCardNo, string ChannelType, string isbuy, string reason)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_UpdateCustomerAuto", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("MemberCardNo", MemberCardNo));
                    cmd.Parameters.Add(new SqlParameter("ChannelType", ChannelType));
                    cmd.Parameters.Add(new SqlParameter("isBuy", isbuy));
                    cmd.Parameters.Add(new SqlParameter("reason", reason));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_UpdateCustomerAuto");
                    return false;
                }
            }
        }

        #endregion

        #region box lọc phân quyền
        public static List<StoreItem> SP_BBM_ManageUse_Store_get(string uid)
        {
            List<StoreItem> it_r = new List<StoreItem>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBM_ManageUse_Store_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        StoreItem it_ = new StoreItem
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_ManageUse_Store_get");
                    return it_r;
                }
            }
        }

        public static List<StoreItem> SP_BBM_ManageUse_getTinh(string uid)
        {
            List<StoreItem> it_r = new List<StoreItem>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBM_ManageUse_getTinh", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        StoreItem it_ = new StoreItem
                        {
                            MaTinh = reader["MaTinh"].ToString(),
                            TenTinh = reader["TenTinh"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_ManageUse_getTinh");
                    return it_r;
                }
            }
        }

        public static List<StoreItem> SP_BBM_ManageUse_getVung(string uid)
        {
            List<StoreItem> it_r = new List<StoreItem>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBM_ManageUse_getVung", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        StoreItem it_ = new StoreItem
                        {
                            MaVung = reader["MaVung"].ToString(),
                            TenVung = reader["TenVung"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_ManageUse_getVung");
                    return it_r;
                }
            }
        }

        public static List<ManagerUserModel> SP_BBM_ManageUse_Header_getDivison()
        {
            List<ManagerUserModel> it_r = new List<ManagerUserModel>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBM_ManageUse_Header_getDivison", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ManagerUserModel it_ = new ManagerUserModel
                        {
                            E_DIVISION_CODE = reader["E_DIVISION_CODE"].ToString(),
                            E_DIVISION = reader["E_DIVISION"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_ManageUse_Header_getDivison");
                    return it_r;
                }
            }
        }

        public static List<ManagerUserModel> SP_BBM_ManageUse_Header_getDepartment()
        {
            List<ManagerUserModel> it_r = new List<ManagerUserModel>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBM_ManageUse_Header_getDepartment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ManagerUserModel it_ = new ManagerUserModel
                        {
                            E_DEPARTMENT_CODE = reader["E_DEPARTMENT_CODE"].ToString(),
                            E_DEPARTMENT = reader["E_DEPARTMENT"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_ManageUse_Header_getDepartment");
                    return it_r;
                }
            }
        }
        public static List<ManagerUserModel> SP_BBM_ManageUse_ListUser(string Division_Code, string Deparment)
        {
            List<ManagerUserModel> it_r = new List<ManagerUserModel>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBM_ManageUse_get_list_user", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("DivisionCode", Division_Code));
                    cmd.Parameters.Add(new SqlParameter("Deparment", Deparment));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ManagerUserModel it_ = new ManagerUserModel
                        {
                            CodeEmp = reader["CodeEmp"].ToString(),
                            ProfileName = reader["ProfileName"].ToString(),
                            Code = reader["Code"].ToString(),
                            PositionName = reader["PositionName"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_ManageUse_get_list_user");
                    return it_r;
                }
            }
        }

        public static List<ManagerUserModel> SP_BBM_ManageUse_ListPosition(string Division_Code, string Deparment)
        {
            List<ManagerUserModel> it_r = new List<ManagerUserModel>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBM_ManageUse_ListPosition", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("DivisionCode", Division_Code));
                    cmd.Parameters.Add(new SqlParameter("Deparment", Deparment));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ManagerUserModel it_ = new ManagerUserModel
                        {
                            Code = reader["Code"].ToString(),
                            PositionName = reader["PositionName"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_ManageUse_ListPosition");
                    return it_r;
                }
            }
        }

        public static List<ManagerUserModel> SP_BBM_ManageUse_Header_getuser()
        {
            List<ManagerUserModel> it_r = new List<ManagerUserModel>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBM_ManageUse_Header_getuser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ManagerUserModel it_ = new ManagerUserModel
                        {
                            CodeEmp = reader["CodeEmp"].ToString(),
                            ProfileName = reader["ProfileName"].ToString(),
                            Code = reader["Code"].ToString(),
                            PositionName = reader["PositionName"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_ManageUse_Header_getuser");
                    return it_r;
                }
            }
        }
        public static List<BiboSmartMenu> SP_BBM_ManageUse_getNghiepVu()
        {
            List<BiboSmartMenu> it_r = new List<BiboSmartMenu>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBM_ManageUse_getNghiepVu", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        BiboSmartMenu it_ = new BiboSmartMenu
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            MenuCode = int.Parse(reader["MenuCode"].ToString()),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_ManageUse_getNghiepVu");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_BBM_ManageUse_Header_getDepartment(string Division_Code)
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBM_ManageUse_Header_getDepartment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("DivisionCode", Division_Code));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it_ = new objCombox
                        {
                            Code = reader["fcode"].ToString(),
                            Name = reader["fname"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_ManageUse_Header_get");
                    return it_r;
                }
            }
        }

        public static List<ManagerUserModel> SP_BBM_ManageUse_Header_getChild(string menu)
        {
            List<ManagerUserModel> it_r = new List<ManagerUserModel>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBM_ManageUse_Header_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("menu", menu));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ManagerUserModel it_ = new ManagerUserModel
                        {
                            fcode = reader["fcode"].ToString(),
                            fname = reader["fname"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_ManageUse_Header_get");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_BBM_ManageUse_Header_getparent(string menu)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBM_ManageUse_Header_getparent", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("menu", menu));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_ManageUse_Header_getparent");
                    return it_r;
                }
            }
        }

        public static List<sys_list_user_function> SP_BBM_getlst_main_ManageUse(string E_DIVISION_CODE, string E_DEPARTMENT_CODE, string paname, string MaVung, string MaTinh, string storeNo, string CodeEmp, string PositionName, string fcode)
        {
            List<sys_list_user_function> it_s = new List<sys_list_user_function>();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBM_ManageUse_Main_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("E_DIVISION_CODE", E_DIVISION_CODE));
                    cmd.Parameters.Add(new SqlParameter("E_DEPARTMENT_CODE", E_DEPARTMENT_CODE));
                    cmd.Parameters.Add(new SqlParameter("CodeEmp", CodeEmp));
                    cmd.Parameters.Add(new SqlParameter("PositionName", PositionName));
                    cmd.Parameters.Add(new SqlParameter("fcode", fcode));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        sys_list_user_function it = new sys_list_user_function
                        {
                            fcode = reader["fcode"].ToString(),
                            fname = reader["fname"].ToString(),
                            modifydate = reader["createdate"].ToString(),
                            modifyby = reader["createby"].ToString(),
                            ischeck = int.Parse(reader["ischeck"].ToString()),
                            fChildCode = reader["fChildCode"].ToString(),
                        };

                        it_s.Add(it);
                    }
                    con.Close();
                    return it_s;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_ManageUse_Main_get");
                return it_s;
            }
        }

        public static List<ManagerUserModel> SP_BBM_ManageUse_Header_get_E_Section(string Division_Code, string Deparment)
        {
            List<ManagerUserModel> it_r = new List<ManagerUserModel>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBM_ManageUse_Header_get_E_Section", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("DivisionCode", Division_Code));
                    cmd.Parameters.Add(new SqlParameter("Deparment", Deparment));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ManagerUserModel it_ = new ManagerUserModel
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_ManageUse_Header_get_E_Section");
                    return it_r;
                }
            }
        }

        #endregion

        #region PQ -- QLPQ
        public static DataTable sp_bbs_get_sys_list_user_function_QLPhanQuyen(string fcode, string fChildCode, string user_div, string user_dep, string user_pos, string userid)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_get_sys_list_user_function_QLPhanQuyen", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("fcode", fcode != null ? fcode : ""));
                    cmd.Parameters.Add(new SqlParameter("fChildCode", fChildCode != null ? fChildCode : ""));
                    cmd.Parameters.Add(new SqlParameter("user_div", user_div));
                    cmd.Parameters.Add(new SqlParameter("user_dep", user_dep));
                    cmd.Parameters.Add(new SqlParameter("user_pos", user_pos));
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_get_sys_list_user_function_QLPhanQuyen");
                return ds.Tables[0];
            }
        }
        public static DataTable sp_bbs_get_sys_list_user_function(string fcode, string fChildCode, string user_div, string user_dep, string user_pos, string userid)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_get_sys_list_user_function", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("fcode", fcode != null ? fcode : ""));
                    cmd.Parameters.Add(new SqlParameter("fChildCode", fChildCode != null ? fChildCode : ""));
                    cmd.Parameters.Add(new SqlParameter("user_div", user_div));
                    cmd.Parameters.Add(new SqlParameter("user_dep", user_dep));
                    cmd.Parameters.Add(new SqlParameter("user_pos", user_pos));
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_get_sys_list_user_function");
                return ds.Tables[0];
            }
        }

        public static bool SP_BBS_updateUserPermission(string uid, string functionCode, string ModifyBy, int isChecked)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_sys_update_user_permission", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", uid));
                    cmd.Parameters.Add(new SqlParameter("functionCode", functionCode));
                    cmd.Parameters.Add(new SqlParameter("ModifyBy", ModifyBy));
                    cmd.Parameters.Add(new SqlParameter("isChecked", isChecked));
                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_sys_update_user_permission");
                    return false;
                }
            }
        }
        #endregion

        #region Đề xuất phân quyền

        public static DataTable sp_GetListPermissionSuggest(string fcode, string fChildCode, string user_div, string user_dep, string user_pos, string userid)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_get_sys_list_user_function_PermissionSuggest", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("fcode", fcode != null ? fcode : ""));
                    cmd.Parameters.Add(new SqlParameter("fChildCode", fChildCode != null ? fChildCode : ""));
                    cmd.Parameters.Add(new SqlParameter("user_div", user_div));
                    cmd.Parameters.Add(new SqlParameter("user_dep", user_dep));
                    cmd.Parameters.Add(new SqlParameter("user_pos", user_pos));
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_get_sys_list_user_function_PermissionSuggest");
                return ds.Tables[0];
            }
        }
        #endregion

        #region Duyệt phân quyền (1)
        public static DataTable sp_bbs_get_sys_list_user_function_PermissionAccept01(string fcode, string fChildCode, string user_div, string user_dep, string user_pos, string userid)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_get_sys_list_user_function_PermissionAccept01", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("fcode", fcode != null ? fcode : ""));
                    cmd.Parameters.Add(new SqlParameter("fChildCode", fChildCode != null ? fChildCode : ""));
                    cmd.Parameters.Add(new SqlParameter("user_div", user_div));
                    cmd.Parameters.Add(new SqlParameter("user_dep", user_dep));
                    cmd.Parameters.Add(new SqlParameter("user_pos", user_pos));
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_get_sys_list_user_function_PermissionAccept01");
                return ds.Tables[0];
            }
        }
        #endregion

        #region Duyệt phân quyền (2)
        public static DataTable sp_bbs_get_sys_list_user_function_PermissionAccept02(string fcode, string fChildCode, string user_div, string user_dep, string user_pos, string userid)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_get_sys_list_user_function_PermissionAccept02", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("fcode", fcode != null ? fcode : ""));
                    cmd.Parameters.Add(new SqlParameter("fChildCode", fChildCode != null ? fChildCode : ""));
                    cmd.Parameters.Add(new SqlParameter("user_div", user_div));
                    cmd.Parameters.Add(new SqlParameter("user_dep", user_dep));
                    cmd.Parameters.Add(new SqlParameter("user_pos", user_pos));
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_get_sys_list_user_function_PermissionAccept02");
                return ds.Tables[0];
            }
        }
        #endregion

        #region Xây dựng bộ sưu tập 

        public static List<itemBST> sp_BBSmart_GetListThuongHieu(string uid)
        {
            List<itemBST> it_r = new List<itemBST>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_GetListThuongHieu", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;

                    cmd.Parameters.Add(new SqlParameter("userid", uid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        itemBST it_ = new itemBST
                        {
                            ThuongHieu = reader["Thương hiệu"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_GetListThuongHieu");
                    return it_r;
                }
            }
        }

        public static List<itemBST> sp_BBSmart_GetListDoTuoi(string uid)
        {
            List<itemBST> it_r = new List<itemBST>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_BBSmart_GetListDoTuoi", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;

                    cmd.Parameters.Add(new SqlParameter("userid", uid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        itemBST it_ = new itemBST
                        {
                            DaiTuoi = reader["Name 2"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBSmart_GetListDoTuoi");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_collection_GetLstCodeBST()
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_collection_GetLstCodeBST", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it_ = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_collection_GetLstCodeBST");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_collection_GetLstNameBST()
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_collection_GetLstNameBST", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it_ = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_collection_GetLstNameBST");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_collection_getrangereview()
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_collection_getrangereview", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it_ = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_collection_getrangereview");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_collection_lstNguonNhap()
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_collection_lstNguonNhap", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it_ = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_collection_lstNguonNhap");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_collection_lstMuaVu()
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_collection_lstMuaVu", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it_ = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_collection_lstMuaVu");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_collection_lstbrand()
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_collection_lstbrand", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it_ = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_collection_lstbrand");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_collection_getbrand(string funct)
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_collection_getbrand", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("funct", funct));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it_ = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_collection_getbrand");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_collection_getMuaVu(string funct)
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_collection_getMuaVu", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("funct", funct));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it_ = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_collection_getMuaVu");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_collection_getNguonNhap(string funct)
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_collection_getNguonNhap", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("funct", funct));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it_ = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_collection_getNguonNhap");
                    return it_r;
                }
            }
        }

        public static List<DivCatGroupFuncollect> sp_collection_SourceProduct_DivCatGroupFunc_v2_get(string uid)
        {
            List<DivCatGroupFuncollect> it_r = new List<DivCatGroupFuncollect>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_collection_SourceProduct_DivCatGroupFunc_v2_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DivCatGroupFuncollect it = new DivCatGroupFuncollect
                        {
                            DivisionCode = reader["DivisionCode"].ToString(),
                            DivisionName = reader["DivisionName"].ToString(),
                            CategoryCode = reader["CategoryCode"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            GroupCode = reader["GroupCode"].ToString(),
                            GroupName = reader["GroupName"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString()

                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;

                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_collection_SourceProduct_DivCatGroupFunc_v2_get");
                    return it_r;
                }
            }

        }

        public static DataTable sp_bbs_collection_GetLstproductImg(string userid, string cat, string group, string funct, string range, string brand, string nguonnhap, string muavu)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_collection_GetLstproductImg", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("cat", cat));
                    cmd.Parameters.Add(new SqlParameter("group", group));
                    cmd.Parameters.Add(new SqlParameter("funct", funct));
                    cmd.Parameters.Add(new SqlParameter("range", range));
                    cmd.Parameters.Add(new SqlParameter("brand", brand));
                    cmd.Parameters.Add(new SqlParameter("nguonnhap", nguonnhap));
                    cmd.Parameters.Add(new SqlParameter("muavu", muavu));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_collection_GetLstproductImg");
                return ds.Tables[0];
            }
        }

        public static List<collectiondetail> sp_bbs_collection_GetLstproduct(string userid, string mahang)
        {
            List<collectiondetail> it_r = new List<collectiondetail>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_collection_GetLstproduct", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("mahang", mahang));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        collectiondetail it = new collectiondetail
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            hinhanh = reader["hinhanh"].ToString(),
                            SLton = reader["SLton"].ToString(),
                            GiaBanAll = reader["GiaBanAll"].ToString(),
                            CategoryCode = reader["CategoryCode"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            GroupCode = reader["GroupCode"].ToString(),
                            GroupName = reader["GroupName"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),
                            BrandCode = reader["BrandCode"].ToString(),
                            BrandName = reader["BrandName"].ToString(),
                            NguonNhapCode = reader["NguonNhapCode"].ToString(),
                            NguonNhapName = reader["NguonNhapName"].ToString(),
                            MuaVuCode = reader["MuaVuCode"].ToString(),
                            MuaVuName = reader["MuaVuName"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_collection_GetLstproduct");
                    return it_r;
                }
            }
        }

        #endregion

        #region StockTransfer

        private static string str_StockTransfer_conn = ConfigurationManager.AppSettings.Get("str_StockTransfer_conn");

        public static List<StockItem> sp_BBM_SMART_stockTransfer_itemTransfer_get(string uid)
        {
            List<StockItem> it_r = new List<StockItem>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_SMART_stockTransfer_itemTransfer_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;


                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        StockItem its = new StockItem
                        {
                            transFromCode = reader["transFromCode"].ToString(),
                            transToCode = reader["transToCode"].ToString(),
                            transToName = reader["transToName"].ToString(),
                            transTypeCode = reader["transTypeCode"].ToString(),
                            transTypeName = reader["transTypeName"].ToString(),
                            groupCode = reader["groupCode"].ToString(),
                            groupName = reader["groupName"].ToString(),
                            itemCode = reader["itemCode"].ToString(),
                            itemName = reader["itemName"].ToString(),
                            quantityRequired = int.Parse(reader["quantityRequired"].ToString()),
                            volume = decimal.Parse(reader["volume"].ToString()),
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_SMART_stockTransfer_itemTransfer_get");
                    return it_r;
                }

            }
        }

        public static List<PackItem> sp_BBM_SMART_stockTransfer_packHeader_get(string uid, int type, string createdDate)
        {
            List<PackItem> it_r = new List<PackItem>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_SMART_stockTransfer_packHeader_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;


                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("type", type));
                    cmd.Parameters.Add(new SqlParameter("createdDate", createdDate));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PackItem its = new PackItem
                        {
                            Code = reader["Code"].ToString(),
                            transFrom = reader["transFrom"].ToString(),
                            transFromName = reader["transFromName"].ToString(),
                            transFrom_Router = reader["transFrom_Router"].ToString(),
                            transFrom_stt = reader["transFrom_stt"].ToString(),
                            transTo = reader["transTo"].ToString(),
                            transToName = reader["transToName"].ToString(),
                            transTo_Router = reader["transTo_Router"].ToString(),
                            transTo_stt = reader["transTo_stt"].ToString(),
                            transType = reader["transType"].ToString(),
                            weight = decimal.Parse(reader["weight"].ToString()),
                            boxType = reader["boxType"].ToString(),
                            boxQuantity = int.Parse(reader["boxQuantity"].ToString()),
                            boxLength = int.Parse(reader["boxLength"].ToString()),
                            boxWidth = int.Parse(reader["boxWidth"].ToString()),
                            boxDepth = int.Parse(reader["boxDepth"].ToString()),
                            volume = decimal.Parse(reader["volume"].ToString()),
                            createdBy = reader["createdBy"].ToString(),
                            createdDate = reader["createdDate"].ToString(),
                            transBy = reader["transBy"].ToString(),
                            transDate = reader["transDate"].ToString(),
                            receiverBy = reader["receiverBy"].ToString(),
                            receiverDate = reader["receiverDate"].ToString(),
                            warehouse = reader["warehouse"].ToString(),
                            assignFor = reader["assignFor"].ToString(),
                            status = int.Parse(reader["status"].ToString()),
                            transTypeName = reader["transTypeName"].ToString(),
                            StatusERP = reader["StatusERP"].ToString(),
                            Group = reader["Group"].ToString()
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_SMART_stockTransfer_packHeader_get");
                    return it_r;
                }

            }
        }

        public static List<transRouterItem> sp_BBM_SMART_stockTransfer_transRouter_get(string uid)
        {
            List<transRouterItem> it_r = new List<transRouterItem>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_SMART_stockTransfer_transRouter_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;


                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        transRouterItem its = new transRouterItem
                        {
                            transFrom = reader["transFrom"].ToString(),
                            transTo = reader["transTo"].ToString(),
                            transToName = reader["transToName"].ToString(),
                            codeRouter = reader["codeRouter"].ToString(),
                            transRouter = reader["transRouter"].ToString(),
                            level = reader["stt"].ToString(),
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_SMART_stockTransfer_transRouter_get");
                    return it_r;
                }

            }
        }

        public static List<FillterItem> sp_BBM_SMART_stockTransfer_transferType_get(string uid)
        {
            List<FillterItem> it_r = new List<FillterItem>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_SMART_stockTransfer_transferType_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;


                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        FillterItem its = new FillterItem
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_SMART_stockTransfer_transferType_get");
                    return it_r;
                }

            }
        }

        public static List<boxType> sp_BBM_SMART_stockTransfer_boxType_get(string uid)
        {
            List<boxType> it_r = new List<boxType>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_SMART_stockTransfer_boxType_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;


                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        boxType its = new boxType
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            Length = int.Parse(reader["Length"].ToString()),
                            Width = int.Parse(reader["Width"].ToString()),
                            Depth = int.Parse(reader["Depth"].ToString()),
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_SMART_stockTransfer_boxType_get");
                    return it_r;
                }

            }
        }

        public static List<backLink_Item> sp_BBM_SMART_stockTransfer_backLink_get(string uid)
        {
            List<backLink_Item> it_r = new List<backLink_Item>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_SMART_stockTransfer_backLink_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;


                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        backLink_Item its = new backLink_Item
                        {
                            CodeEmp = reader["CodeEmp"].ToString(),
                            E_SECTION_CODE = reader["E_SECTION_CODE"].ToString(),
                            E_SECTION = reader["E_SECTION"].ToString(),
                            Level = reader["Level"].ToString(),
                            backName = reader["backName"].ToString(),
                            backLink = reader["backLink"].ToString(),
                            isMobile = int.Parse(reader["isMobile"].ToString()),

                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_SMART_stockTransfer_backLink_get");
                    return it_r;
                }

            }
        }

        public static List<FillterItem> sp_BBM_SMART_stockTransfer_Transporter_get(string uid)
        {
            List<FillterItem> it_r = new List<FillterItem>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_SMART_stockTransfer_Transporter_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;


                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        FillterItem its = new FillterItem
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_SMART_stockTransfer_Transporter_get");
                    return it_r;
                }

            }
        }

        public static List<packLine> sp_BBM_SMART_stockTransfer_packLine_get(string uid, string headerCode)
        {
            List<packLine> it_r = new List<packLine>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_SMART_stockTransfer_packLine_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;


                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("headerCode", headerCode));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        packLine its = new packLine
                        {
                            headerCode = reader["headerCode"].ToString(),
                            itemNo = reader["itemNo"].ToString(),
                            itemName = reader["itemName"].ToString(),
                            qtyPerPack = int.Parse(reader["qtyPerPack"].ToString()),
                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_SMART_stockTransfer_packLine_get");
                    return it_r;
                }

            }
        }

        public static PackItem sp_BBM_SMART_stockTransfer_packHeader_add(string uid, PackItem it)
        {
            PackItem it_r = new PackItem();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_SMART_stockTransfer_packHeader_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 1000;

                    var boxType = it.boxType != "" ? it.boxType : "";
                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    cmd.Parameters.Add(new SqlParameter("transFrom", it.transFrom));
                    cmd.Parameters.Add(new SqlParameter("transTo", it.transTo));
                    cmd.Parameters.Add(new SqlParameter("transType", it.transType));
                    cmd.Parameters.Add(new SqlParameter("weight", it.weight));
                    cmd.Parameters.Add(new SqlParameter("boxType", boxType));
                    cmd.Parameters.Add(new SqlParameter("boxQuantity", it.boxQuantity));
                    cmd.Parameters.Add(new SqlParameter("boxLength", it.boxLength));
                    cmd.Parameters.Add(new SqlParameter("boxWidth", it.boxWidth));
                    cmd.Parameters.Add(new SqlParameter("boxDepth", it.boxDepth));
                    cmd.Parameters.Add(new SqlParameter("volume", it.volume));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PackItem its = new PackItem
                        {
                            Code = reader["Code"].ToString(),
                            transFrom = reader["transFrom"].ToString(),
                            transTo = reader["transTo"].ToString(),

                        };

                        it_r = its;
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_SMART_stockTransfer_packHeader_add");
                    return it_r;
                }

            }
        }

        public static bool sp_BBM_SMART_stockTransfer_packLine_add(string uid, packLine it)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_SMART_stockTransfer_packLine_add", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;

                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    cmd.Parameters.Add(new SqlParameter("headerCode", it.headerCode));
                    cmd.Parameters.Add(new SqlParameter("itemNo", it.itemNo));
                    cmd.Parameters.Add(new SqlParameter("qtyPerPack", it.qtyPerPack));
                    cmd.Parameters.Add(new SqlParameter("totalQty", it.totalQty));
                    cmd.Parameters.Add(new SqlParameter("Flag", it.Flag));
                    cmd.Parameters.Add(new SqlParameter("Type", it.Type));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_SMART_stockTransfer_packHeader_get");
                    return false;
                }

            }
        }

        public static bool sp_BBM_SMART_stockTransfer_packHeader_update(string uid, string packCode, int type, string assignFor)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBM_SMART_stockTransfer_packHeader_update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;


                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    cmd.Parameters.Add(new SqlParameter("packCode", packCode));
                    cmd.Parameters.Add(new SqlParameter("type", type));
                    cmd.Parameters.Add(new SqlParameter("assignFor", assignFor));

                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BBM_SMART_stockTransfer_packHeader_update");
                    return false;
                }

            }
        }
        #endregion

        #region KPIDepartment
        public static DataTable sp_bbs_get_KPIDepartment(string Department, string khoi)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_get_KPIDepartment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("Department", Department));
                    cmd.Parameters.Add(new SqlParameter("khoi", khoi));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_get_KPIDepartment");
                return ds.Tables[0];
            }
        }
        public static List<objCombox> sp_KPI_Chi_Tieu_khoi()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_KPI_Chi_Tieu_khoi", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_KPI_Chi_Tieu_khoi");
                    return it_r;
                }
            }
        }
        public static List<KPITieuChi> GetListKPITieuChi(string KPIChiTieuTrial)
        {
            List<KPITieuChi> it_r = new List<KPITieuChi>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetListKPITieuChi", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("KPIChiTieuTrial", KPIChiTieuTrial));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        KPITieuChi it_ = new KPITieuChi
                        {
                            MaDuAn = reader["MaDuAn"].ToString(),
                            ThuocDo = reader["ThuocDo"].ToString(),
                            percentKPI = reader["percentKPI"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListKPITieuChi");
                    return it_r;
                }
            }
        }

        public static bool SP_KPIDepartment_DELETE_UPDATE(string KhoiCode, string PhongBanCode)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_KPIDepartment_DELETE_UPDATE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("KhoiCode", KhoiCode));
                    cmd.Parameters.Add(new SqlParameter("PhongBanCode", PhongBanCode));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_KPIDepartment_DELETE_UPDATE");
                    return false;
                }
            }
        }
        public static bool DeleteKPIDepartment(string ID)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("DeleteKPIDepartment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "DeleteKPIDepartment");
                    return false;
                }
            }
        }

        public static bool SP_INSERT_KPIDepartment(string IDelete, string KhoiName, string KhoiCode, string PhongBanName, string PhongBanCode, string Khoi, string MangCongViec, string TenSIAs, string KPIKhoi, string MaDuAn, string ThuocDo, string PhanTramKPIKhoi, string PhongBanNameKPI, string PhongBanCodeKPI, string KPIChiTieuPhong, string PhanTramKPIPhong, string Status, string CreateBy)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_INSERT_KPIDepartment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDelete", IDelete.ToString()));
                    cmd.Parameters.Add(new SqlParameter("KhoiName", KhoiName.ToString()));
                    cmd.Parameters.Add(new SqlParameter("KhoiCode", KhoiCode.ToString()));
                    cmd.Parameters.Add(new SqlParameter("PhongBanName", PhongBanName.ToString()));
                    cmd.Parameters.Add(new SqlParameter("PhongBanCode", PhongBanCode.ToString()));
                    cmd.Parameters.Add(new SqlParameter("Khoi", Khoi));
                    cmd.Parameters.Add(new SqlParameter("MangCongViec", MangCongViec));
                    cmd.Parameters.Add(new SqlParameter("TenSIAs", TenSIAs));
                    cmd.Parameters.Add(new SqlParameter("KPIKhoi", KPIKhoi));
                    cmd.Parameters.Add(new SqlParameter("MaDuAn", MaDuAn));
                    cmd.Parameters.Add(new SqlParameter("ThuocDo", ThuocDo));
                    cmd.Parameters.Add(new SqlParameter("PhanTramKPIKhoi", PhanTramKPIKhoi));
                    cmd.Parameters.Add(new SqlParameter("PhongBanNameKPI", PhongBanNameKPI));
                    cmd.Parameters.Add(new SqlParameter("PhongBanCodeKPI", PhongBanCodeKPI));
                    cmd.Parameters.Add(new SqlParameter("KPIChiTieuPhong", KPIChiTieuPhong));
                    cmd.Parameters.Add(new SqlParameter("PhanTramKPIPhong", PhanTramKPIPhong));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));

                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_INSERT_KPIDepartment");
                    return false;
                }
            }
        }
        public static List<User_Member> SP_get_User_Member(string IDThanhVien)
        {
            List<User_Member> it_r = new List<User_Member>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_get_User_Member", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IDThanhVien", IDThanhVien));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        User_Member it = new User_Member
                        {
                            Khoi = reader["Khoi"].ToString(),
                            Phongban = reader["Phongban"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_get_User_Member");
                    return it_r;
                }
            }
        }

        public static List<objCombox> KPIChiTieuTrial_datalist(string Khoi)
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("KPIChiTieuTrial_datalist", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("Khoi", Khoi));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it_ = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "KPIChiTieuTrial_datalist");
                    return it_r;
                }
            }
        }
        #endregion

        #region HRMJob
        public static List<objCombox> SP_HR_BoPhan(string Phongban)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_HR_BoPhan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Phongban", Phongban));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_HR_BoPhan");
                    return it_r;
                }
            }
        }

        #endregion

        #region Report
        #region Kinh doanh nhãn hàng new 
        public static List<objCombox> SP_BBM_Report_Brand()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBM_Report_Brand", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_Report_Brand");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_BBM_Report_ChuongTrinh(string brand)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBM_Report_ChuongTrinh", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("brand", brand));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_Report_ChuongTrinh");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_BBM_Report_Fitter_Thang_Tuan_get(string brand, string chuongtrinh)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBM_Report_Fitter_Thang_Tuan_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("brand", brand));
                    cmd.Parameters.Add(new SqlParameter("chuongtrinh", chuongtrinh));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_Report_Fitter_Thang_Tuan_get");
                    return it_r;
                }
            }
        }

        public static DataTable Get_BaoCaoKinhDoanh_Thang_CH(string Thang, string nhanhang, string chuongtrinh)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_Business_brand_month_report2", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
                    cmd.Parameters.Add(new SqlParameter("nhanhang", nhanhang));
                    cmd.Parameters.Add(new SqlParameter("chuongtrinh", chuongtrinh));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_Business_brand_month_report2");
                return ds.Tables[0];
            }
        }

        public static DataTable Get_BaoCaoKinhDoanh_Thang_ASM(string Thang, string nhanhang, string chuongtrinh)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_Business_brand_month_report3", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
                    cmd.Parameters.Add(new SqlParameter("nhanhang", nhanhang));
                    cmd.Parameters.Add(new SqlParameter("chuongtrinh", chuongtrinh));


                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_Business_brand_month_report3");
                return ds.Tables[0];
            }
        }

        public static DataTable Get_BaoCaoKinhDoanh_Tuan_NhanVien(string Thang, string nhanhang, string chuongtrinh)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_Business_brand_WEEK_report2", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
                    cmd.Parameters.Add(new SqlParameter("nhanhang", nhanhang));
                    cmd.Parameters.Add(new SqlParameter("chuongtrinh", chuongtrinh));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_Business_brand_WEEK_report2");
                return ds.Tables[0];
            }
        }

        #endregion

        public static List<objCombox> SP_BBM_Report_Thang_get()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBM_Report_Thang_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_Report_Thang_get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_BBM_Report_Tuan_get(string Thang)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBM_Report_Tuan_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_Report_Tuan_get");
                    return it_r;
                }
            }
        }

        public static List<Obj_BaoCaoKinhDoanh> SP_BBM_Report_Fitter_Thang_get(string nhanhang, string Thang)
        {
            List<Obj_BaoCaoKinhDoanh> it_r = new List<Obj_BaoCaoKinhDoanh>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBM_Report_Fitter_Thang_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("nhanhang", nhanhang));
                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Obj_BaoCaoKinhDoanh it = new Obj_BaoCaoKinhDoanh
                        {
                            Taget = reader["Taget"].ToString(),
                            ThucDat = reader["ThucDat"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_Report_Fitter_Thang_get");
                    return it_r;
                }
            }
        }
        public static List<Obj_BaoCaoKinhDoanh> SP_BBM_Report_Fitter_Tuan_get(string Thang, string Tuan)
        {
            List<Obj_BaoCaoKinhDoanh> it_r = new List<Obj_BaoCaoKinhDoanh>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBM_Report_Fitter_Tuan_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
                    cmd.Parameters.Add(new SqlParameter("Tuan", Tuan));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Obj_BaoCaoKinhDoanh it = new Obj_BaoCaoKinhDoanh
                        {
                            Taget = reader["Taget"].ToString(),
                            ThucDat = reader["ThucDat"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_Report_Fitter_Tuan_get");
                    return it_r;
                }
            }
        }

        public static List<Obj_BaoCaoKinhDoanh_VanHanh> Get_BaoCaoKinhDoanh_VanHanh(string Thang, string nhanhang)
        {
            List<Obj_BaoCaoKinhDoanh_VanHanh> it_r = new List<Obj_BaoCaoKinhDoanh_VanHanh>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_Business_brand_month_report1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
                    cmd.Parameters.Add(new SqlParameter("nhanhang", nhanhang));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Obj_BaoCaoKinhDoanh_VanHanh it = new Obj_BaoCaoKinhDoanh_VanHanh
                        {
                            Target = reader["Target"].ToString(),
                            ThucDat = reader["ThucDat"].ToString(),
                            PhanTramDat = reader["PhanTramDat"].ToString(),
                            PhanTramThuong = reader["PhanTramThuong"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_BaoCaoKinhDoanh_VanHanh");
                    return it_r;
                }
            }
        }

        public static List<Obj_BaoCaoKinhDoanh_TopVung> Get_BaoCaoKinhDoanh_TopVung(string Thang, string nhanhang)
        {
            List<Obj_BaoCaoKinhDoanh_TopVung> it_r = new List<Obj_BaoCaoKinhDoanh_TopVung>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_Business_brand_month_report3", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Thang", Thang));
                    cmd.Parameters.Add(new SqlParameter("nhanhang", nhanhang));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Obj_BaoCaoKinhDoanh_TopVung it = new Obj_BaoCaoKinhDoanh_TopVung
                        {
                            ASM_code = reader["ASM_code"].ToString(),
                            ThucDat = reader["ThucDat"].ToString(),
                            DoanhSo = reader["DoanhSo"].ToString(),
                            SoLuong = reader["SoLuong"].ToString(),
                            Thuong = reader["Thuong"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_BaoCaoKinhDoanh_TopVung");
                    return it_r;
                }
            }
        }
        //Tuần
        public static List<Obj_BaoCaoKinhDoanh_TopKinhDoanhOnline> Get_BaoCaoKinhDoanh_TopDoanhSo(string Thang, string Tuan, string nhanhang)
        {
            List<Obj_BaoCaoKinhDoanh_TopKinhDoanhOnline> it_r = new List<Obj_BaoCaoKinhDoanh_TopKinhDoanhOnline>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_Business_brand_WEEK_report1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("thang", Thang));
                    cmd.Parameters.Add(new SqlParameter("tuan", Tuan));
                    cmd.Parameters.Add(new SqlParameter("nhanhang", nhanhang));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Obj_BaoCaoKinhDoanh_TopKinhDoanhOnline it = new Obj_BaoCaoKinhDoanh_TopKinhDoanhOnline
                        {
                            Target = reader["Target"].ToString(),
                            ThucDat = reader["ThucDat"].ToString(),
                            PhanTramDat = reader["PhanTramDat"].ToString(),
                            PhanTramThuong = reader["PhanTramThuong"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_BaoCaoKinhDoanh_TopDoanhSo");
                    return it_r;
                }
            }
        }


        public static List<Obj_BaoCaoKinhDoanh_TopNhanVien> Get_BaoCaoKinhDoanh_TopSieuThi(string Tuan, string nhanhang)
        {
            List<Obj_BaoCaoKinhDoanh_TopNhanVien> it_r = new List<Obj_BaoCaoKinhDoanh_TopNhanVien>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_Business_brand_WEEK_report2", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("tuan", Tuan));
                    cmd.Parameters.Add(new SqlParameter("nhanhang", nhanhang));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Obj_BaoCaoKinhDoanh_TopNhanVien it = new Obj_BaoCaoKinhDoanh_TopNhanVien
                        {
                            MaNV = reader["MaNV"].ToString(),
                            DoanhSo = reader["DoanhSo"].ToString(),
                            Thuong = reader["Thuong"].ToString(),
                            SoLuong = reader["SoLuong"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_BaoCaoKinhDoanh_TopSieuThi");
                    return it_r;
                }
            }
        }

        public static List<Obj_BaoCaoKinhDoanh_TopKhuVuc> Get_BaoCaoKinhDoanh_TopKhuVuc(string Thang, string Tuan, string nhanhang)
        {
            List<Obj_BaoCaoKinhDoanh_TopKhuVuc> it_r = new List<Obj_BaoCaoKinhDoanh_TopKhuVuc>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_Business_brand_WEEK_report4", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("thang", Thang));
                    cmd.Parameters.Add(new SqlParameter("tuan", Tuan));
                    cmd.Parameters.Add(new SqlParameter("nhanhang", nhanhang));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Obj_BaoCaoKinhDoanh_TopKhuVuc it = new Obj_BaoCaoKinhDoanh_TopKhuVuc
                        {
                            ASM = reader["ASM"].ToString(),
                            DoanhSo = reader["DoanhSo"].ToString(),
                            TangTruong = reader["TangTruong"].ToString(),
                            Thuong = reader["Thuong"].ToString(),
                            SoLuong = reader["SoLuong"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_BaoCaoKinhDoanh_TopKhuVuc");
                    return it_r;
                }
            }
        }

        public static List<objCheckbox> PhanQuyen_Business(string userid, string StoreSql)
        {
            List<objCheckbox> it_r = new List<objCheckbox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(StoreSql, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCheckbox it = new objCheckbox
                        {
                            value = reader["value"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "PhanQuyen_Business");
                    return it_r;
                }
            }
        }
        #endregion
        //
        public static List<notiinfo> sp_bbs_getNotiApprove(string userid)
        {
            List<notiinfo> it_r = new List<notiinfo>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_getNotiApprove", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userid", userid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        notiinfo it = new notiinfo
                        {
                            fcode = reader["fcode"].ToString(),
                            fname = reader["fname"].ToString(),
                            action = reader["action"].ToString(),
                            controller = reader["controller"].ToString(),
                            waiting = int.Parse(reader["waiting"].ToString()),

                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getNotiApprove");
                    return it_r;
                }
            }
        }

        #region Thúc đẩy doanh số nhân viên
        public static List<objCombox> sp_bbs_ThucDayDSNV_getlstCH()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_ThucDayDSNV_getlstCH", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_ThucDayDSNV_getlstCH");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_ThucDayDSNV_getlstNV()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_ThucDayDSNV_getlstNV", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_ThucDayDSNV_getlstNV");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_ThucDayDSNV_getlstPostision()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_ThucDayDSNV_getlstPostision", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_ThucDayDSNV_getlstPostision");
                    return it_r;
                }
            }
        }

        public static DataTable sp_bbs_ThucDayDSNV_getlst(string userid, string store, string NhanVien, string postision, string month)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_ThucDayDSNV_getlst", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("store", store));
                    cmd.Parameters.Add(new SqlParameter("NhanVien", NhanVien));
                    cmd.Parameters.Add(new SqlParameter("postision", postision));
                    cmd.Parameters.Add(new SqlParameter("month", month));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_ThucDayDSNV_getlst");
                return ds.Tables[0];
            }
        }
        #endregion

        #region THÚC ĐẨY DOANH SỐ NHÃN HÀNG
        public static DataTable GetListBrandSales(string Vung, string Brand, string KhuVuc, string StoreNo, string NgayBatDau, string NgayKetThuc)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("S_GET_LIST_BRANDSALES", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("Vung", Vung));
                    cmd.Parameters.Add(new SqlParameter("Brand", Brand));
                    cmd.Parameters.Add(new SqlParameter("KhuVuc", KhuVuc));
                    cmd.Parameters.Add(new SqlParameter("StoreNo", StoreNo));
                    cmd.Parameters.Add(new SqlParameter("NgayBatDau", NgayBatDau));
                    cmd.Parameters.Add(new SqlParameter("NgayKetThuc", NgayKetThuc));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListBrandSales");
                return ds.Tables[0];
            }
        }
        #endregion

        #region HistoryCoins
        public static List<objCombox> SP_BBMSMART_HistoryCoins_GetInfoCustomer(string SoDienThoai)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBMSMART_HistoryCoins_GetInfoCustomer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("SoDienThoai", SoDienThoai));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["MemberCard"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBMSMART_HistoryCoins_GetInfoCustomer");
                    return it_r;
                }
            }
        }
        public static List<Obj_HistoryCoins> SP_BBMSMART_HistoryCoins_GetInfoCustomer_MemberCard(string SoDienThoai)
        {
            List<Obj_HistoryCoins> it_r = new List<Obj_HistoryCoins>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBMSMART_HistoryCoins_GetInfoCustomer_MemberCard", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("SoDienThoai", SoDienThoai));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Obj_HistoryCoins it = new Obj_HistoryCoins
                        {
                            AccountNo = reader["AccountNo"].ToString(),
                            PhoneNo = reader["PhoneNo"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            Address = reader["Address"].ToString(),
                            City = reader["City"].ToString(),
                            Gender = reader["Gender"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBMSMART_HistoryCoins_GetInfoCustomer_MemberCard");
                    return it_r;
                }
            }
        }
        public static DataTable HistoryCoins_GetList(string Membercard, string userid)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("HistoryCoins_GetList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("Membercard", Membercard));
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "HistoryCoins_GetList");
                return ds.Tables[0];
            }
        }

        public static List<Obj_CustomersChange> HistoryCoins_GetInfoCustomer_MemberCard_Change(string MemberCard)
        {
            List<Obj_CustomersChange> it_r = new List<Obj_CustomersChange>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("HistoryCoins_GetInfoCustomer_MemberCard_Change", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MemberCard", MemberCard));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Obj_CustomersChange it = new Obj_CustomersChange
                        {
                            MemberCard = reader["MemberCard"].ToString(),
                            AccountNo = reader["AccountNo"].ToString(),
                            PhoneNo = reader["PhoneNo"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            Address = reader["Address"].ToString(),
                            City = reader["City"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            DateBirth = reader["DateBirth"].ToString(),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            DateBirth_News = reader["DateBirth_News"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "HistoryCoins_GetInfoCustomer_MemberCard_Change");
                    return it_r;
                }
            }
        }
        public static List<Obj_CustomersChange> HistoryCoins_GetInfoCustomer_Phone_MemberCard_Change(string SoDienThoai)
        {
            List<Obj_CustomersChange> it_r = new List<Obj_CustomersChange>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("HistoryCoins_GetInfoCustomer_Phone_MemberCard_Change", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("SoDienThoai", SoDienThoai));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Obj_CustomersChange it = new Obj_CustomersChange
                        {
                            MemberCard = reader["MemberCard"].ToString(),
                            AccountNo = reader["AccountNo"].ToString(),
                            PhoneNo = reader["PhoneNo"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            Address = reader["Address"].ToString(),
                            City = reader["City"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            DateBirth = reader["DateBirth"].ToString(),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            DateBirth_News = reader["DateBirth_News"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "HistoryCoins_GetInfoCustomer_Phone_MemberCard_Change");
                    return it_r;
                }
            }
        }

        public static bool Create_Customers_Change_MemberCart(string userid, objMemberCart info, string ContenERP)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Create_Customers_Change_MemberCart", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MemberCart", info.MemberCart));
                    cmd.Parameters.Add(new SqlParameter("HoTen", info.HoTen));
                    cmd.Parameters.Add(new SqlParameter("DiaChi", info.DiaChi));
                    cmd.Parameters.Add(new SqlParameter("DienThoai", info.DienThoai));
                    cmd.Parameters.Add(new SqlParameter("GioiTinh", info.GioiTinh != null ? info.GioiTinh : "0"));
                    if (String.IsNullOrWhiteSpace(info.NgaySinh))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgaySinh", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgaySinh", DateTime.Parse(info.NgaySinh)));
                    }
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("ContenERP", ContenERP));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Create_Customers_Change_MemberCart");
                    return false;
                }
            }

        }
        public static DataTable sp_ApproveCustomersChange_Get(string Status, string StoreId)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ApproveCustomersChange_Get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    cmd.Parameters.Add(new SqlParameter("StoreId", StoreId));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_ApproveCustomersChange_Get");
                return ds.Tables[0];
            }
        }

        public static objMemberCart ApproveCustomersChange_PopUp_Detail(string ID)
        {
            objMemberCart itr = new objMemberCart();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("ApproveCustomersChange_PopUp_Detail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objMemberCart it = new objMemberCart
                        {
                            ID = reader["ID"].ToString(),
                            MemberCart = reader["MemberCart"].ToString(),
                            HoTen = reader["HoTen"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            DienThoai = reader["DienThoai"].ToString(),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            NgaySinh = reader["NgaySinh"].ToString(),
                            EmployName = reader["EmployName"].ToString(),
                            StoreName = reader["StoreName"].ToString(),
                        };
                        itr = it;
                    }
                    con.Close();
                    return itr;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ApproveCustomersChange_PopUp_Detail");
                    return itr;
                }
            }
        }
        public static List<objCombox> GetInfoCustomer_MemberCard_TonBiXu(string MemberCard)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("GetInfoCustomer_MemberCard_TonBiXu", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MemberCard", MemberCard));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Code"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetInfoCustomer_MemberCard_TonBiXu");
                    return it_r;
                }
            }
        }


        public static List<objCombox> ApproveCustomersChange_Detail_Store()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("ApproveCustomersChange_Detail_Store", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "ApproveCustomersChange_Detail_Store");
                    return it_r;
                }
            }
        }
        public static bool Update_Status_ApproveCustomers(string ID, string HanhDong, string uid)
        {
            string[] Value = ID.Split('-');
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_Status_ApproveCustomers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", Value[0]));
                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_ApproveCustomers");
                    return false;
                }
            }
        }
        public static bool Update_Status_ApproveCustomers_ERP(string ID, string HanhDong, string ContenERP, string uid)
        {
            string[] Value = ID.Split('-');
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_Status_ApproveCustomers_ERP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", Value[0]));
                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
                    cmd.Parameters.Add(new SqlParameter("ContenERP", ContenERP));
                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_ApproveCustomers_ERP");
                    return false;
                }
            }
        }
        public static bool Delete_ApproveCustomers(string ID)
        {
            string[] Value = ID.Split('-');
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Delete_ApproveCustomers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", Value[0]));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Delete_ApproveCustomers");
                    return false;
                }
            }
        }
        #endregion

        public static List<objCombox> SP_BBMSMART_MarCom_GetFullMonth(string TuNgay, string DenNgay, string Weeks)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBMSMART_MarCom_GetFullMonth", con);
                    cmd.Parameters.Add(new SqlParameter("TuNgay", TuNgay));
                    cmd.Parameters.Add(new SqlParameter("DenNgay", DenNgay));
                    cmd.Parameters.Add(new SqlParameter("Weeks", Weeks));
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["days"].ToString(),
                            Name = reader["date"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBMSMART_MarCom_GetFullMonth");
                    return it_r;
                }
            }
        }

        #region CampaignFlashSale
        public static List<objCombox> CampaignFlashSale_Images_Price(string ItemNo)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BBSmart_GetList_CampaignFlashSale_Images_Price", con);
                    cmd.Parameters.Add(new SqlParameter("ItemNo", ItemNo));
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Price"].ToString(),
                            Name = reader["Images"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CampaignFlashSale_Images_Price");
                    return it_r;
                }
            }
        }
        public static List<objCombox> CampaignFlashSale_MAAUTO()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_CampaignFlashSale_MAAUTO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["MaChienDich"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_CampaignFlashSale_MAAUTO");
                    return it_r;
                }
            }
        }

        public static bool Save_CampaignFlashSale_Header(CampaignFlashSale_Header info, string MaChienDich, string CreateBy)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Save_CampaignFlashSale_Header", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaChienDich", MaChienDich != null ? MaChienDich : ""));
                    cmd.Parameters.Add(new SqlParameter("TenChienDich", info.TenChienDich != null ? info.TenChienDich : ""));
                    cmd.Parameters.Add(new SqlParameter("TrangThai", info.TrangThai != null ? info.TrangThai : ""));
                    if (String.IsNullOrWhiteSpace(info.TuNgay))
                    {
                        cmd.Parameters.Add(new SqlParameter("TuNgay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("TuNgay", DateTime.Parse(info.TuNgay)));
                    }
                    cmd.Parameters.Add(new SqlParameter("TimeHourTuNgay", info.TimeHourTuNgay != null ? info.TimeHourTuNgay : ""));
                    if (String.IsNullOrWhiteSpace(info.DenNgay))
                    {
                        cmd.Parameters.Add(new SqlParameter("DenNgay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("DenNgay", DateTime.Parse(info.DenNgay)));
                    }
                    cmd.Parameters.Add(new SqlParameter("TimeHourDenNgay", info.TimeHourDenNgay != null ? info.TimeHourDenNgay : ""));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Save_ReportDeposit_TradingTem");
                    return false;
                }
            }
        }

        public static bool Update_CampaignFlashSale_Header(CampaignFlashSale_Header info, string ModifyBy)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_CampaignFlashSale_Header", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaChienDich", info.MaChienDich != null ? info.MaChienDich : ""));
                    cmd.Parameters.Add(new SqlParameter("TenChienDich", info.TenChienDich != null ? info.TenChienDich : ""));
                    cmd.Parameters.Add(new SqlParameter("TrangThai", info.TrangThai != null ? info.TrangThai : ""));
                    if (String.IsNullOrWhiteSpace(info.TuNgay))
                    {
                        cmd.Parameters.Add(new SqlParameter("TuNgay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("TuNgay", DateTime.Parse(info.TuNgay)));
                    }
                    cmd.Parameters.Add(new SqlParameter("TimeHourTuNgay", info.TimeHourTuNgay != null ? info.TimeHourTuNgay : ""));
                    if (String.IsNullOrWhiteSpace(info.DenNgay))
                    {
                        cmd.Parameters.Add(new SqlParameter("DenNgay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("DenNgay", DateTime.Parse(info.DenNgay)));
                    }
                    cmd.Parameters.Add(new SqlParameter("TimeHourDenNgay", info.TimeHourDenNgay != null ? info.TimeHourDenNgay : ""));
                    cmd.Parameters.Add(new SqlParameter("ModifyBy", ModifyBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_CampaignFlashSale_Header");
                    return false;
                }
            }
        }
        public static bool Save_CampaignFlashSale_Line(CampaignFlashSale_Line info, string MaChienDich, string CreateBy)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Save_CampaignFlashSale_Line", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaChienDich", MaChienDich != null ? MaChienDich : ""));
                    cmd.Parameters.Add(new SqlParameter("ItemNo", info.ItemNo != null ? info.ItemNo : ""));
                    cmd.Parameters.Add(new SqlParameter("NamePro", info.NamePro != null ? info.NamePro : ""));

                    cmd.Parameters.Add(new SqlParameter("Price", Decimal.Parse(info.Price.Replace(",", "") != "" ? info.Price.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("Images", info.Images != null ? info.Images : ""));
                    cmd.Parameters.Add(new SqlParameter("PriceFlashSale", Decimal.Parse(info.PriceFlashSale.Replace(",", "") != "" ? info.PriceFlashSale.Replace(",", "") : "0")));

                    cmd.Parameters.Add(new SqlParameter("SLFlashSale", Decimal.Parse(info.SLFlashSale.Replace(",", "") != "" ? info.SLFlashSale.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("SLBan", Decimal.Parse(info.SLBan.Replace(",", "") != "" ? info.SLBan.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("SLBanChayHang", Decimal.Parse(info.SLBanChayHang.Replace(",", "") != "" ? info.SLBanChayHang.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("SLBaThucTe", Decimal.Parse(info.SLBaThucTe.Replace(",", "") != "" ? info.SLBaThucTe.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("TrangThai", info.TrangThai != null ? info.TrangThai : ""));
                    cmd.Parameters.Add(new SqlParameter("CreateBy", CreateBy));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Save_CampaignFlashSale_Line");
                    return false;
                }
            }
        }
        public static List<CampaignFlashSale_Header> CampaignFlashSale_Edit(string MaChienDich)
        {
            List<CampaignFlashSale_Header> it_r = new List<CampaignFlashSale_Header>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("CampaignFlashSale_Edit", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaChienDich ", MaChienDich));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CampaignFlashSale_Header it = new CampaignFlashSale_Header
                        {
                            ID = reader["ID"].ToString(),
                            MaChienDich = reader["MaChienDich"].ToString(),
                            TenChienDich = reader["TenChienDich"].ToString(),
                            TrangThai = reader["TrangThai"].ToString(),
                            TuNgay = reader["TuNgay"].ToString(),
                            TimeHourTuNgay = reader["TimeHourTuNgay"].ToString(),
                            DenNgay = reader["DenNgay"].ToString(),
                            TimeHourDenNgay = reader["TimeHourDenNgay"].ToString(),
                            CreateBy = reader["CreateBy"].ToString(),
                            CreateDate = reader["CreateDate"].ToString(),
                            ModifyBy = reader["ModifyBy"].ToString(),
                            ModifyDate = reader["ModifyDate"].ToString(),
                            StatusDuyet = reader["StatusDuyet"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_PROMOTION_HEADER_DETAIL");
                    return it_r;
                }
            }
        }
        public static List<CampaignFlashSale_Header> CampaignFlashSale_MaChienDich_Detail(string MaChienDich)
        {
            List<CampaignFlashSale_Header> it_r = new List<CampaignFlashSale_Header>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("CampaignFlashSale_MaChienDich_Detail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaChienDich ", MaChienDich));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CampaignFlashSale_Header it = new CampaignFlashSale_Header
                        {
                            ID = reader["ID"].ToString(),
                            MaChienDich = reader["MaChienDich"].ToString(),
                            TenChienDich = reader["TenChienDich"].ToString(),
                            TrangThai = reader["TrangThai"].ToString(),
                            TuNgay = reader["TuNgay"].ToString(),
                            TimeHourTuNgay = reader["TimeHourTuNgay"].ToString(),
                            DenNgay = reader["DenNgay"].ToString(),
                            TimeHourDenNgay = reader["TimeHourDenNgay"].ToString(),
                            CreateBy = reader["CreateBy"].ToString(),
                            CreateDate = reader["CreateDate"].ToString(),
                            ModifyBy = reader["ModifyBy"].ToString(),
                            ModifyDate = reader["ModifyDate"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_PROMOTION_HEADER_DETAIL");
                    return it_r;
                }
            }
        }

        public static List<CampaignFlashSale_Line> CampaignFlashSale_line_Edit(string MaChienDich)
        {
            List<CampaignFlashSale_Line> it_r = new List<CampaignFlashSale_Line>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("CampaignFlashSale_line_Edit", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaChienDich ", MaChienDich));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CampaignFlashSale_Line it = new CampaignFlashSale_Line
                        {
                            ID = reader["ID"].ToString(),
                            MaChienDich = reader["MaChienDich"].ToString(),
                            ItemNo = reader["ItemNo"].ToString(),
                            NamePro = reader["NamePro"].ToString(),
                            Price = reader["Price"].ToString(),
                            Images = reader["Images"].ToString(),
                            PriceFlashSale = reader["PriceFlashSale"].ToString(),
                            SLFlashSale = reader["SLFlashSale"].ToString(),
                            SLBan = reader["SLBan"].ToString(),
                            SLBanChayHang = reader["SLBanChayHang"].ToString(),
                            SLBaThucTe = reader["SLBaThucTe"].ToString(),
                            TrangThai = reader["TrangThai"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_KM_PROMOTION_HEADER_DETAIL");
                    return it_r;
                }
            }
        }

        public static DataTable CampaignFlashSale_List(string ChienDich, string TrangThai)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CampaignFlashSale_List", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("MaChienDich", ChienDich));
                    cmd.Parameters.Add(new SqlParameter("TrangThai", TrangThai));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CampaignFlashSale_List");
                return ds.Tables[0];
            }
        }

        public static DataTable CampaignFlashSale_Apr(string ChienDich, string TrangThai)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CampaignFlashSale_Apr", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("MaChienDich", ChienDich));
                    cmd.Parameters.Add(new SqlParameter("TrangThai", TrangThai));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CampaignFlashSale_Apr");
                return ds.Tables[0];
            }
        }
        public static bool CampaignFlashSale_Delete(string MaChienDich)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("CampaignFlashSale_Delete", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaChienDich", MaChienDich));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CampaignFlashSale_Delete");
                    return false;
                }
            }
        }

        public static bool CampaignFlashSale_Update_Status(string MaChienDich, string HanhDong, string uid)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("CampaignFlashSale_Update_Status", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaChienDich", MaChienDich));
                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CampaignFlashSale_Update_Status");
                    return false;
                }
            }
        }

        public static List<CampaignFlashSale_Line> CampaignFlashSale_GetProItem_ERP_Line(string MaChienDich)
        {
            List<CampaignFlashSale_Line> it_r = new List<CampaignFlashSale_Line>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("CampaignFlashSale_GetProItem_ERP_Line", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("MaChienDich", MaChienDich));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CampaignFlashSale_Line it = new CampaignFlashSale_Line
                        {
                            ItemNo = reader["ItemNo"].ToString(),
                            NamePro = reader["NamePro"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CampaignFlashSale_GetProItem_ERP_Line");
                    return it_r;
                }
            }

        }
        #endregion


        public static DataTable sp_bbs_GetList_TangTruongDSCH(string userid, string RSMCode, string ASMCode, string MaTinh, string MaCH, string ThoigianHD,string kenhban)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_GetList_TangTruongDSCH", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("RSMCode", RSMCode));
                    cmd.Parameters.Add(new SqlParameter("ASMCode", ASMCode));
                    cmd.Parameters.Add(new SqlParameter("MaTinh", MaTinh));
                    cmd.Parameters.Add(new SqlParameter("MaCH", MaCH));
                    cmd.Parameters.Add(new SqlParameter("ThoigianHD", ThoigianHD));
                    cmd.Parameters.Add(new SqlParameter("kenhban", kenhban));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_GetList_TangTruongDSCH");
                return ds.Tables[0];
            }
        }

        public static List<objCombox> sp_getlist_HanhDongQTNS()
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_getlist_HanhDongQTNS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it_ = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getlist_HanhDongQTNS");
                    return it_r;
                }
            }
        }

        #region QuanLyPhanQuyen_VENDORS_NV
        public static List<objCombox> getFunctionParent_Vendor()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_VENDORS_ManageUse_Header_getparent", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_VENDORS_ManageUse_Header_getparent");
                    return it_r;
                }
            }
        }
        public static List<ManagerUserModel> getFunctionchild_Vendor(string menu)
        {
            List<ManagerUserModel> it_r = new List<ManagerUserModel>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_Vendor_ManageUse_Header_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("menu", menu));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ManagerUserModel it_ = new ManagerUserModel
                        {
                            fcode = reader["fcode"].ToString(),
                            fname = reader["fname"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_Vendor_ManageUse_Header_get");
                    return it_r;
                }
            }
        }
        public static DataTable sp_VENDOR_get_sys_list_user_function(string fcode, string fChildCode, string user_div, string user_dep, string user_pos, string userid)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_VENDOR_get_sys_list_user_function", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("fcode", fcode != null ? fcode : ""));
                    cmd.Parameters.Add(new SqlParameter("fChildCode", fChildCode != null ? fChildCode : ""));
                    cmd.Parameters.Add(new SqlParameter("user_div", user_div));
                    cmd.Parameters.Add(new SqlParameter("user_dep", user_dep));
                    cmd.Parameters.Add(new SqlParameter("user_pos", user_pos));
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_VENDOR_get_sys_list_user_function");
                return ds.Tables[0];
            }
        }
        public static bool sp_Verdor_sys_update_user_permission(string uid, string fcode, string functionCode, string ModifyBy, int isChecked)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_Verdor_sys_update_user_permission", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", uid));
                    cmd.Parameters.Add(new SqlParameter("fcode", fcode));
                    cmd.Parameters.Add(new SqlParameter("functionCode", functionCode));
                    cmd.Parameters.Add(new SqlParameter("ModifyBy", ModifyBy));
                    cmd.Parameters.Add(new SqlParameter("isChecked", isChecked));
                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Verdor_sys_update_user_permission");
                    return false;
                }
            }
        }
        public static DataTable sp_VENDOR_get_sys_list_user_function_NCC(string fcode, string fPhongBan)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_VENDOR_get_sys_list_user_function_NCC", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("fcode", fcode != null ? fcode : ""));
                    cmd.Parameters.Add(new SqlParameter("fPhongBan", fPhongBan != null ? fPhongBan : ""));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_VENDOR_get_sys_list_user_function_NCC");
                return ds.Tables[0];
            }
        }
        public static bool sp_Verdor_sys_update_user_permission_NCC(string functionCode, string PhongBans, string fcode, string TypePhongBan, string ModifyBy, string PhongBan)
        {

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Verdor_sys_update_user_permission_NCC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("functionCode", functionCode));
                    cmd.Parameters.Add(new SqlParameter("fcode", fcode));
                    cmd.Parameters.Add(new SqlParameter("ModifyBy", ModifyBy));
                    cmd.Parameters.Add(new SqlParameter("PhongBan", PhongBans));
                    cmd.Parameters.Add(new SqlParameter("TypePhongBan", TypePhongBan));
                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Verdor_sys_update_user_permission_NCC");
                    return false;
                }
            }
        }
        public static bool sp_Verdor_sys_update_user_permission_NCC_Update(string Phongban)
        {

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Verdor_sys_update_user_permission_NCC_Update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("PhongBan", Phongban));
                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Verdor_sys_update_user_permission_NCC_Update");
                    return false;
                }
            }
        }
        public static List<BiboSmartMenu> SP_getway_PhongBan()
        {
            List<BiboSmartMenu> it_r = new List<BiboSmartMenu>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_getway_PhongBan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        BiboSmartMenu it_ = new BiboSmartMenu
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_getway_PhongBan");
                    return it_r;
                }
            }
        }
        #endregion

        #region index

        public static List<MotaCVinfo> sp_index_getMotaCV(string userid)
        {
            List<MotaCVinfo> it_r = new List<MotaCVinfo>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_index_getMotaCV", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userid", userid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        MotaCVinfo it = new MotaCVinfo
                        {
                            Title = reader["Title"].ToString(),
                            Detail = reader["Detail"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_index_getMotaCV");
                    return it_r;
                }
            }
        }

        public static List<SieusaoKPIinfo> sp_index_getSieusaoKPI(string userid)
        {
            List<SieusaoKPIinfo> it_r = new List<SieusaoKPIinfo>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_index_getSieusaoKPI", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userid", userid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SieusaoKPIinfo it = new SieusaoKPIinfo
                        {
                            ProfilePicture = reader["ProfilePicture"].ToString(),
                            MaNV = reader["MaNV"].ToString(),
                            TenNV = reader["TenNV"].ToString(),
                            Score = reader["Score"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_index_getSieusaoKPI");
                    return it_r;
                }
            }
        }

        public static List<SieusaoDoanhthuinfo> sp_index_getSieusaoDoanhthu(string userid)
        {
            List<SieusaoDoanhthuinfo> it_r = new List<SieusaoDoanhthuinfo>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_index_getSieusaoDoanhthu", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userid", userid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SieusaoDoanhthuinfo it = new SieusaoDoanhthuinfo
                        {
                            ProfilePicture = reader["ProfilePicture"].ToString(),
                            MaNV = reader["MaNV"].ToString(),
                            TenNV = reader["TenNV"].ToString(),
                            Score = reader["Score"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_index_getSieusaoDoanhthu");
                    return it_r;
                }
            }
        }

        public static List<Bonusinfo> sp_index_getBonus(string userid)
        {
            List<Bonusinfo> it_r = new List<Bonusinfo>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_index_getBonus", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userid", userid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Bonusinfo it = new Bonusinfo
                        {
                            Picture = reader["Picture"].ToString(),
                            Title = reader["Title"].ToString(),
                            Detail = reader["Detail"].ToString()
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_index_getBonus");
                    return it_r;
                }
            }
        }

        public static List<Bantininfo> sp_index_getBantin(string userid)
        {
            List<Bantininfo> it_r = new List<Bantininfo>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_index_getBantin", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userid", userid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Bantininfo it = new Bantininfo
                        {
                            Creator = reader["Creator"].ToString(),
                            Title = reader["Title"].ToString(),
                            Detail = reader["Detail"].ToString(),
                            Link = reader["Link"].ToString()
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_index_getBantin");
                    return it_r;
                }
            }
        }
        #endregion


        
    }
}
