using Lib.Utils.Package;
using Microsoft.AspNetCore.Authentication;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using ProductAllTool.DataAccess.DataConnection;
using ProductAllTool.Models;
using ProductAllTool.Models.comparePrice;
using ProductAllTool.Models.ScoreStore;
using ProductAllTool.Models.SourceProduct;
using ProductAllTool.Models.SpaceMan;
using ProductAllTool.Models.StoreLayout;
using ProductAllTool.Models.ToDoList;
using ProductAllTool.Models.ManageSales;
using ProductAllTool.Models.ManageUse;
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
using ProductAllTool.Models.HRM;
using ProductAllTool.Models.CaLamViec;

namespace ProductAllTool.DataAccess
{
    public class DataAccessTT
    {
        private static string strCon = ConfigurationManager.AppSettings.Get("strConn");
        private static string strConn1101 = ConfigurationManager.AppSettings.Get("strConn1.101");
        private static string strConnDWH = ConfigurationManager.AppSettings.Get("strConnDWH");
        private static string strConnTHUCTAP = ConfigurationManager.AppSettings.Get("strConnTHUCTAP");

        #region Thuc Tap 3
        public static List<objCombox> sp_Brand()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Brand", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Brand");
                    return it_r;
                }
            }
        }
        public static int AR_CreateLyDo(string userid, int id, string LyDo)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("AR_CreateLyDo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("id", id));
                    cmd.Parameters.Add(new SqlParameter("LyDo", LyDo));
                    cmd.ExecuteNonQuery();

                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "AR_CreateLyDo");
                return 0;
            }
        }
        public static int sp_lydo_update(string userid,int id, string lydo)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_lydo_update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("id", id));
                    cmd.Parameters.Add(new SqlParameter("lydo", lydo));
                    cmd.ExecuteNonQuery();

                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_lydo_update");
                return 0;
            }
        }
        public static int CLV_setTuChoi(string userid, string TenNV)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CLV_setTuChoi", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("TenNV", TenNV));
                    cmd.ExecuteNonQuery();

                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CLV_setTuChoi");
                return 0;
            }
        }
        public static int CLV_setDaDuyet(string userid, string TenNV)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CLV_setDaDuyet", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("TenNV", TenNV));
                    cmd.ExecuteNonQuery();

                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CLV_setDaDuyet");
                return 0;
            }
        }
        public static int CLV_AddListNC(string userid, string Ca,string type)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CLV_AddListNC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("Ca", Ca));
                    cmd.Parameters.Add(new SqlParameter("type", type));
                    cmd.ExecuteNonQuery();

                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CLV_AddListNC");
                return 0;
            }
        }
        public static DataTable getLstLyDo(string userid, int ID, string LyDo)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("getLstLyDo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("LyDo", LyDo));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getLstLyDo");
                return ds.Tables[0];
            }
        }
        public static List<objCombox> AR_MaHang()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("AR_MaHang", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "AR_MaHang");
                    return it_r;
                }
            }
        }
        public static List<objCombox> AR_MIEN()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("AR_MIEN", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "AR_MIEN");
                    return it_r;
                }
            }
        }
        public static List<objCombox> AR_CuaHang()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("AR_CuaHang", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "AR_CuaHang");
                    return it_r;
                }
            }
        }
        public static List<objCombox> AR_Tinh()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("AR_Tinh", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "AR_Tinh");
                    return it_r;
                }
            }
        }
        public static List<objCombox> CLV_Ca()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("CLV_Ca", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CLV_Ca");
                    return it_r;
                }
            }
        }
        public static List<objCombox> CLV_NoiLam()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("CLV_NoiLam", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CLV_NoiLam");
                    return it_r;
                }
            }
        }
        public static List<objCombox> CLV_CuaHang()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("CLV_CuaHang", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CLV_CuaHang");
                    return it_r;
                }
            }
        }
        public static List<objCombox> CLV_LoaiNghi()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("CLV_LoaiNghi", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CLV_LoaiNghi");
                    return it_r;
                }
            }
        }
        public static List<objCombox> CLV_Ca_NoiLam()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("CLV_Ca_NoiLam", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CLV_Ca_NoiLam");
                    return it_r;
                }
            }
        }
        public static DataTable sp_getList(string userid, string brand, string mahang, string mien)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_getList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("brand", brand));
                    cmd.Parameters.Add(new SqlParameter("mahang", mahang));
                    cmd.Parameters.Add(new SqlParameter("mien", mien));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getList");
                return ds.Tables[0];
            }
        }
        public static DataTable CLV_GetList(string userid, string TuNgay, string DenNgay, string Ca,string NoiLam)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CLV_GetList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    if (String.IsNullOrWhiteSpace(TuNgay))
                    {
                        cmd.Parameters.Add(new SqlParameter("TuNgay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("TuNgay", DateTime.Parse(TuNgay)));
                    }

                    if (String.IsNullOrWhiteSpace(DenNgay))
                    {
                        cmd.Parameters.Add(new SqlParameter("DenNgay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("DenNgay", DateTime.Parse(DenNgay)));
                    }
                    
                    cmd.Parameters.Add(new SqlParameter("Ca", Ca));
                    cmd.Parameters.Add(new SqlParameter("NoiLam", NoiLam));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CLV_GetList");
                return ds.Tables[0];
            }
        }
        public static DataTable CLV_getListNC2(string userid,string TenCH,string Ca)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CLV_getListNC2", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("TenCH", TenCH));
                    cmd.Parameters.Add(new SqlParameter("Ca", Ca));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CLV_getListNC2");
                return ds.Tables[0];
            }
        }
        public static DataTable CLV_getListDC(string userid,string TuNgay,string DenNgay)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CLV_getListDC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    if (String.IsNullOrWhiteSpace(TuNgay))
                    {
                        cmd.Parameters.Add(new SqlParameter("TuNgay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("TuNgay", DateTime.Parse(TuNgay)));
                    }

                    if (String.IsNullOrWhiteSpace(DenNgay))
                    {
                        cmd.Parameters.Add(new SqlParameter("DenNgay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("DenNgay", DateTime.Parse(DenNgay)));
                    }
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CLV_getListDC");
                return ds.Tables[0];
            }
        }
        public static DataTable CLV_getListDuyetNghi(string userid,string TuNgay,string DenNgay)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CLV_getListDuyetNghi", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    if (String.IsNullOrWhiteSpace(TuNgay))
                    {
                        cmd.Parameters.Add(new SqlParameter("TuNgay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("TuNgay", DateTime.Parse(TuNgay)));
                    }

                    if (String.IsNullOrWhiteSpace(DenNgay))
                    {
                        cmd.Parameters.Add(new SqlParameter("DenNgay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("DenNgay", DateTime.Parse(DenNgay)));
                    }
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CLV_getListDuyetNghi");
                return ds.Tables[0];
            }
        }
        public static DataTable CLV_getListXN1(string userid,string TuNgay,string DenNgay)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CLV_getListXN1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    if (String.IsNullOrWhiteSpace(TuNgay))
                    {
                        cmd.Parameters.Add(new SqlParameter("TuNgay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("TuNgay", DateTime.Parse(TuNgay)));
                    }

                    if (String.IsNullOrWhiteSpace(DenNgay))
                    {
                        cmd.Parameters.Add(new SqlParameter("DenNgay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("DenNgay", DateTime.Parse(DenNgay)));
                    }
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CLV_getListXN1");
                return ds.Tables[0];
            }
        }
        public static DataTable CLV_getListNC1(string userid)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strConnTHUCTAP))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CLV_getListNC1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CLV_getListNC1");
                return ds.Tables[0];
            }
        }
        public static List<CaLV> CLV_getListUser(string userid)
        {
            List<CaLV> it_r = new List<CaLV>();

            using (var con = new SqlConnection(strConnTHUCTAP))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("CLV_getListUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CaLV it_ = new CaLV
                        {
                            MaNV = reader["MaNV"].ToString(),
                            TenNV = reader["TenNV"].ToString(),
                            ChucDanh = reader["ChucDanh"].ToString(),
                            BoPhan = reader["BoPhan"].ToString(),
                            TenCH = reader["TenCH"].ToString(),
                            TenPB = reader["TenPB"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "CLV_getListUser");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_BBS_HRM_GET_CAPBAC(string Code)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_GET_HRM_GET_CAPBAC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("Code", Code));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it_ = new objCombox
                        {
                            Code = reader["CapBac"].ToString(),
                            Name = reader["TenChucDanh"].ToString(),
                        };
                        it_r.Add(it_);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_GET_CAPBAC");
                    return it_r;
                }
            }
        }


        public static List<objCombox> SP_BBS_HRM_GetList_BoPhan(string E_DIVISION_CODE, string E_DEPARTMENT_CODE)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_GetList_BoPhan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("E_DIVISION_CODE", E_DIVISION_CODE));
                    cmd.Parameters.Add(new SqlParameter("E_DEPARTMENT_CODE", E_DEPARTMENT_CODE));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it_ = new objCombox
                        {
                            Code = reader["E_SECTION_CODE"].ToString(),
                            Name = reader["E_SECTION"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_GetList_BoPhan");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_BBS_HRM_getDepartment(string Division_Code)
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_getDepartment", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_getDepartment");
                    return it_r;
                }
            }
        }

        public static List<HRMbox> SP_BBS_HRM_get_list_user(string Division_Code, string Deparment)
        {
            List<HRMbox> it_r = new List<HRMbox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_get_list_user", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("DivisionCode", Division_Code));
                    cmd.Parameters.Add(new SqlParameter("Deparment", Deparment));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HRMbox it_ = new HRMbox
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_get_list_user");
                    return it_r;
                }
            }
        }

        public static List<HRMbox> SP_BBS_HRM_get_ListPosition(string Division_Code, string Deparment)
        {
            List<HRMbox> it_r = new List<HRMbox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_get_ListPosition", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("DivisionCode", Division_Code));
                    cmd.Parameters.Add(new SqlParameter("Deparment", Deparment));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HRMbox it_ = new HRMbox
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_get_ListPosition");
                    return it_r;
                }
            }
        }

        public static List<balancedScoreInfo> sp_bbs_get_sys_list_company()
        {
            List<balancedScoreInfo> it_r = new List<balancedScoreInfo>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_get_sys_list_company", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        balancedScoreInfo it_ = new balancedScoreInfo
                        {
                            congty = reader["congty"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_get_sys_list_company");
                    return it_r;
                }
            }
        }
        public static List<balancedScoreInfo> sp_bbs_get_sys_list_Division()
        {
            List<balancedScoreInfo> it_r = new List<balancedScoreInfo>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_get_sys_list_Division", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        balancedScoreInfo it_ = new balancedScoreInfo
                        {
                            khoi = reader["khoi"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_get_sys_list_Division");
                    return it_r;
                }
            }
        }


        public static List<objCombox> sp_bbs_get_sys_list_capbac()
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_get_sys_list_capbac", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objCombox it_ = new objCombox
                        {
                            Code = reader["Code"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_get_sys_list_capbac");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_getlist_balancedscorecard_SIA()
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_getlist_balancedscorecard_SIA", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getlist_balancedscorecard_SIA");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_getlist_balancedscorecard_Khoi()
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_getlist_balancedscorecard_Khoi", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getlist_balancedscorecard_Khoi");
                    return it_r;
                }
            }
        }
        public static DataTable sp_bbs_get_sys_list_BalancedScoreCard(string nam, string congty, string khoi, string sia)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_get_sys_list_BalancedScoreCard", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("nam", nam));
                    cmd.Parameters.Add(new SqlParameter("congty", congty));
                    cmd.Parameters.Add(new SqlParameter("khoi", khoi));
                    cmd.Parameters.Add(new SqlParameter("sia", sia));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_get_sys_list_BalancedScoreCard");
                return ds.Tables[0];
            }
        }

        public static DataTable sp_bbs_get_sys_list_Job(string user_div, string user_dep, string user_pos)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_get_sys_list_Job", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("user_div", user_div));
                    cmd.Parameters.Add(new SqlParameter("user_dep", user_dep));
                    cmd.Parameters.Add(new SqlParameter("user_pos", user_pos));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_get_sys_list_Job");
                return ds.Tables[0];
            }
        }
        public static bool sp_BiBoMart_Add_HRM_Job(string userid, string CapBac, string CapBacCode, string PositionCode, string PositionName, string CodeJob, string NameJob, string TanSuatThucHien, string ThoiLuongThucHien, string TotalTime)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_Add_sys_main_HRM_Job", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("CapBac", CapBac != null ? CapBac : ""));
                    cmd.Parameters.Add(new SqlParameter("CapBacCode", CapBacCode != null ? CapBacCode : ""));
                    cmd.Parameters.Add(new SqlParameter("PositionCode", PositionCode));
                    cmd.Parameters.Add(new SqlParameter("PositionName", PositionName));
                    cmd.Parameters.Add(new SqlParameter("CodeJob", CodeJob != "" ? CodeJob : ""));
                    cmd.Parameters.Add(new SqlParameter("NameJob", NameJob));
                    cmd.Parameters.Add(new SqlParameter("TanSuatThucHien", TanSuatThucHien));
                    cmd.Parameters.Add(new SqlParameter("ThoiLuongThucHien", ThoiLuongThucHien));
                    cmd.Parameters.Add(new SqlParameter("TotalTime", TotalTime));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_BiBoMart_Add_HRM_Job");
                    return false;
                }
            }
        }

        public static bool sp_bbs_Add_sys_main_HRM_Job(string userid, HRMJobInfo info)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_Add_sys_main_HRM_Job", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("CapBac", info.CapBac != null ? info.CapBac : ""));
                    cmd.Parameters.Add(new SqlParameter("CapBacCode", info.CapBacCode));
                    cmd.Parameters.Add(new SqlParameter("PositionCode", info.PositionCode));
                    cmd.Parameters.Add(new SqlParameter("PositionName", info.PositionName));
                    cmd.Parameters.Add(new SqlParameter("CodeJob", info.CodeJob != null ? info.CodeJob : ""));
                    cmd.Parameters.Add(new SqlParameter("NameJob", info.NameJob));
                    cmd.Parameters.Add(new SqlParameter("TanSuatThucHien", info.TanSuatThucHien));
                    cmd.Parameters.Add(new SqlParameter("ThoiLuongThucHien", info.ThoiLuongThucHien));
                    cmd.Parameters.Add(new SqlParameter("TotalTime", info.TotalTime));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_Add_sys_main_HRM_Job");
                    return false;
                }
            }
        }

        public static DataTable sp_bbs_get_sys_list_Job_detail_edit(string userid, string PositionCode, string CodeJob)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_get_sys_list_Job_detail_edit", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("PositionCode", PositionCode));
                    cmd.Parameters.Add(new SqlParameter("CodeJob", CodeJob));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_get_sys_list_Job_detail_edit");
                return ds.Tables[0];
            }
        }

        public static DataTable sp_bbs_get_sys_list_diagram(string user_div, string user_dep, string user_part, string user_pos, string userid, string user_statusHD)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_get_sys_list_diagram", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("user_div", user_div));
                    cmd.Parameters.Add(new SqlParameter("user_dep", user_dep));
                    cmd.Parameters.Add(new SqlParameter("user_part", user_part));
                    cmd.Parameters.Add(new SqlParameter("user_pos", user_pos));
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("user_statusHD", user_statusHD));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_get_sys_list_diagram");
                return ds.Tables[0];
            }
        }

        public static DataTable sp_bbs_get_sys_list_diagram_detail(string userid, string CodeEmp)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_get_sys_list_diagram_detail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("CodeEmp", CodeEmp));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_get_sys_list_diagram_detail");
                return ds.Tables[0];
            }
        }

        public static bool SP_BBS_HRM_addDiagram(string userid, string CodeEmp, string NameEmp, string CapBac, string CapBacCode, string PositionCode,
            string PositionName, string CodeJob, string NameJob, string TanSuatThucHien, string ThoiLuongThucHien, string TotalTime, int ischecked)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_addDiagram", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("CodeEmp", CodeEmp));
                    cmd.Parameters.Add(new SqlParameter("NameEmp", NameEmp));
                    cmd.Parameters.Add(new SqlParameter("CapBac", CapBac != null ? CapBac : ""));
                    cmd.Parameters.Add(new SqlParameter("CapBacCode", CapBacCode != null ? CapBacCode : ""));
                    cmd.Parameters.Add(new SqlParameter("PositionCode", PositionCode));
                    cmd.Parameters.Add(new SqlParameter("PositionName", PositionName));
                    cmd.Parameters.Add(new SqlParameter("CodeJob", CodeJob));
                    cmd.Parameters.Add(new SqlParameter("NameJob", NameJob));
                    cmd.Parameters.Add(new SqlParameter("TanSuatThucHien", TanSuatThucHien));
                    cmd.Parameters.Add(new SqlParameter("ThoiLuongThucHien", ThoiLuongThucHien));
                    cmd.Parameters.Add(new SqlParameter("TotalTime", TotalTime));
                    cmd.Parameters.Add(new SqlParameter("ischecked", ischecked));
                    var reader = cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_addDiagram");
                    return false;
                }
            }
        }

        public static int sp_bbs_updateDiagram(string userid, string CodeJob)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_updateDiagram", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("CodeJob", CodeJob));
                    cmd.ExecuteNonQuery();

                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_updateDiagram");
                return 0;
            }
        }

        public static int sp_bbs_addDiagramTotaltime(string userid, string CodeEmp, string NameEmp, string CapBac, string CapBacCode, string PositionCode,
            string PositionName, string CodeJob, string NameJob, string TanSuatThucHien, string ThoiLuongThucHien, string TotalTime, int ischecked)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_addDiagramTotaltime", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("CodeEmp", CodeEmp));
                    cmd.Parameters.Add(new SqlParameter("NameEmp", NameEmp));
                    cmd.Parameters.Add(new SqlParameter("CapBac", CapBac != null ? CapBac : ""));
                    cmd.Parameters.Add(new SqlParameter("CapBacCode", CapBacCode != null ? CapBacCode : ""));
                    cmd.Parameters.Add(new SqlParameter("PositionCode", PositionCode));
                    cmd.Parameters.Add(new SqlParameter("PositionName", PositionName));
                    cmd.Parameters.Add(new SqlParameter("CodeJob", CodeJob));
                    cmd.Parameters.Add(new SqlParameter("NameJob", NameJob));
                    cmd.Parameters.Add(new SqlParameter("TanSuatThucHien", TanSuatThucHien));
                    cmd.Parameters.Add(new SqlParameter("ThoiLuongThucHien", ThoiLuongThucHien));
                    cmd.Parameters.Add(new SqlParameter("TotalTime", TotalTime));
                    cmd.Parameters.Add(new SqlParameter("ischecked", ischecked));
                    cmd.ExecuteNonQuery();

                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_addDiagramTotaltime");
                return 0;
            }
        }
        #endregion

        
    }
}


