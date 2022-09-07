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

namespace ProductAllTool.DataAccess
{
    public class DataAccessHRM
    {
        private static string strCon = ConfigurationManager.AppSettings.Get("strConn");
        private static string strConn1101 = ConfigurationManager.AppSettings.Get("strConn1.101");
        private static string strConnDWH = ConfigurationManager.AppSettings.Get("strConnDWH");

        #region Nhân sự HRM
        public static List<objCombox> SP_BIBOSMART_GET_HRM_LIST_DEPARTMENT()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BIBOSMART_GET_HRM_LIST_DEPARTMENT", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BIBOSMART_GET_HRM_LIST_DEPARTMENT");
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

        #region Đề xuất ủy quyền
        public static List<objCombox> SP_BBS_HRM_UQ_getLoaiVB()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_UQ_getLoaiVB", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_UQ_getLoaiVB");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_BBS_HRM_UQ_getNoiDungUQ()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_UQ_getNoiDungUQ", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_UQ_getNoiDungUQ");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_BBS_HRM_UQ_getMaNganSach()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_UQ_getMaNganSach", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_UQ_getMaNganSach");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_BBS_HRM_UQ_getCongTy()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_UQ_getCongTy", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_UQ_getCongTy");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_BBS_HRM_UQ_getUser()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_UQ_getUser", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_UQ_getUser");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_BBS_HRM_UQ_getposition(string CodeEmp)
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_UQ_getposition", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("CodeEmp", CodeEmp));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_UQ_getposition");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_BBS_HRM_UQ_getfunctionChild()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_UQ_getfunctionChild", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_UQ_getfunctionChild");
                    return it_r;
                }
            }
        }
        public static bool SP_BBS_HRM_DXUQ_Add(string userid, HRMUyQuyen info)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DXUQ_Add", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("LoaiVB", info.LoaiVB != null ? info.LoaiVB : ""));
                    cmd.Parameters.Add(new SqlParameter("SoVB", info.SoVB));
                    cmd.Parameters.Add(new SqlParameter("CongTy", info.CongTy != null ? info.CongTy : ""));
                    cmd.Parameters.Add(new SqlParameter("NgayHieuLuc", info.NgayHieuLuc != null ? info.NgayHieuLuc : ""));
                    cmd.Parameters.Add(new SqlParameter("NguoiUyQuyen", info.NguoiUyQuyen != null ? info.NguoiUyQuyen : ""));
                    cmd.Parameters.Add(new SqlParameter("NguoiDuocUyQuyen", info.NguoiDuocUyQuyen != null ? info.NguoiDuocUyQuyen : ""));
                    cmd.Parameters.Add(new SqlParameter("NoiDung", info.NoiDung));
                    cmd.Parameters.Add(new SqlParameter("MaNoiDung", info.MaNoiDung));
                    cmd.Parameters.Add(new SqlParameter("ChucNangCon", info.ChucNangCon != null ? info.ChucNangCon : ""));
                    cmd.Parameters.Add(new SqlParameter("MaNganSach", info.MaNganSach != null ? info.MaNganSach : ""));

                    if (info.NSDuocDuyet == null)
                        cmd.Parameters.Add(new SqlParameter("NSDuocDuyet", Decimal.Parse("0")));
                    else
                        cmd.Parameters.Add(new SqlParameter("NSDuocDuyet", Decimal.Parse(info.NSDuocDuyet.Replace(",", "") != null ? info.NSDuocDuyet.Replace(",", "") : "0")));

                    if (info.NSDuocDuyetTu == null)
                        cmd.Parameters.Add(new SqlParameter("NSDuocDuyetTu", Decimal.Parse("0")));
                    else
                        cmd.Parameters.Add(new SqlParameter("NSDuocDuyetTu", Decimal.Parse(info.NSDuocDuyetTu.Replace(",", "") != null ? info.NSDuocDuyetTu.Replace(",", "") : "0")));

                    if (info.NSDuocDuyetDen == null)
                        cmd.Parameters.Add(new SqlParameter("NSDuocDuyetDen", Decimal.Parse("0")));
                    else
                        cmd.Parameters.Add(new SqlParameter("NSDuocDuyetDen", Decimal.Parse(info.NSDuocDuyetDen.Replace(",", "") != null ? info.NSDuocDuyetDen.Replace(",", "") : "0")));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DXUQ_Add");
                    return false;
                }
            }
        }

        public static int SP_BBS_HRM_DXUQ_Update(string ID, string userid, string LoaiVB, string SoVB, string CongTy, string NgayHieuLuc, string NguoiUyQuyen, string NguoiDuocUyQuyen, string NoiDung, string MaNoiDung,
            string ChucNangCon, string MaNganSach, string NSDuocDuyet, string NSDuocDuyetTu, string NSDuocDuyetDen)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DXUQ_Update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("LoaiVB", LoaiVB != null ? LoaiVB : ""));
                    cmd.Parameters.Add(new SqlParameter("SoVB", SoVB));
                    cmd.Parameters.Add(new SqlParameter("CongTy", CongTy != null ? CongTy : ""));
                    cmd.Parameters.Add(new SqlParameter("NgayHieuLuc", NgayHieuLuc != null ? NgayHieuLuc : ""));
                    cmd.Parameters.Add(new SqlParameter("NguoiUyQuyen", NguoiUyQuyen != null ? NguoiUyQuyen : ""));
                    cmd.Parameters.Add(new SqlParameter("NguoiDuocUyQuyen", NguoiDuocUyQuyen != null ? NguoiDuocUyQuyen : ""));
                    cmd.Parameters.Add(new SqlParameter("NoiDung", NoiDung));
                    cmd.Parameters.Add(new SqlParameter("MaNoiDung", MaNoiDung));
                    cmd.Parameters.Add(new SqlParameter("ChucNangCon", ChucNangCon != null ? ChucNangCon : ""));
                    cmd.Parameters.Add(new SqlParameter("MaNganSach", MaNganSach != null ? MaNganSach : ""));
                    cmd.Parameters.Add(new SqlParameter("NSDuocDuyet", Decimal.Parse(NSDuocDuyet.Replace(",", "") != "" ? NSDuocDuyet.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("NSDuocDuyetTu", Decimal.Parse(NSDuocDuyetTu.Replace(",", "") != "" ? NSDuocDuyetTu.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("NSDuocDuyetDen", Decimal.Parse(NSDuocDuyetDen.Replace(",", "") != "" ? NSDuocDuyetDen.Replace(",", "") : "0")));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DXUQ_Update");
                return 0;
            }
        }
        #endregion

        #region Danh sách đề xuất ủy quyền
        public static List<objCombox> SP_BBS_HRM_getDepartmentUQ()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_getDepartmentUQ", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_getDepartmentUQ");
                    return it_r;
                }
            }
        }

        public static List<HRMbox> SP_BBS_HRM_DSUQ_get_ListPosition(string Deparment)
        {
            List<HRMbox> it_r = new List<HRMbox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DSUQ_get_ListPosition", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DSUQ_get_ListPosition");
                    return it_r;
                }
            }
        }

        public static List<HRMbox> SP_BBS_HRM_DSUQ_get_list_user(string Position)
        {
            List<HRMbox> it_r = new List<HRMbox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DSUQ_get_list_user", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Position", Position));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HRMbox it_ = new HRMbox
                        {
                            CodeEmp = reader["CodeEmp"].ToString(),
                            ProfileName = reader["ProfileName"].ToString(),
                        };

                        it_r.Add(it_);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DSUQ_get_list_user");
                    return it_r;
                }
            }
        }
        public static DataTable SP_BBS_HRM_getlstDSUQ(string user_div, string user_dep, string user_pos, string userid)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_getlstDSUQ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_getlstDSUQ");
                return ds.Tables[0];
            }
        }

        public static int SP_BBS_HRM_UpdatePermission(string ID, string NguoiDuocUyQuyen, string ChucNangCon, string NgayHieuLuc, string modifyby)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_updatepermission", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("NguoiDuocUyQuyen", NguoiDuocUyQuyen));
                    cmd.Parameters.Add(new SqlParameter("ChucNangCon", ChucNangCon));
                    cmd.Parameters.Add(new SqlParameter("NgayHieuLuc", NgayHieuLuc));
                    cmd.Parameters.Add(new SqlParameter("modifyby", modifyby));
                    cmd.ExecuteNonQuery();

                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_updatepermission");
                return 0;
            }
        }

        public static int SP_BBS_HRM_DSUQ_Add_his(string userid, string LoaiVB, string SoVB, string CongTy, string NgayHieuLuc, string NguoiUyQuyen, string NguoiDuocUyQuyen
         , string NoiDung, string MaNoiDung, string ChucNangCon, string MaNganSach, string NSDuocDuyet, string NSDuocDuyetTu, string NSDuocDuyetDen,
        int type, int status)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DSUQ_Add_his", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("LoaiVB", LoaiVB != null ? LoaiVB : ""));
                    cmd.Parameters.Add(new SqlParameter("SoVB", SoVB));
                    cmd.Parameters.Add(new SqlParameter("CongTy", CongTy != null ? CongTy : ""));
                    cmd.Parameters.Add(new SqlParameter("NgayHieuLuc", NgayHieuLuc != null ? NgayHieuLuc : ""));
                    cmd.Parameters.Add(new SqlParameter("NguoiUyQuyen", NguoiUyQuyen != null ? NguoiUyQuyen : ""));
                    cmd.Parameters.Add(new SqlParameter("NguoiDuocUyQuyen", NguoiDuocUyQuyen != null ? NguoiDuocUyQuyen : ""));
                    cmd.Parameters.Add(new SqlParameter("NoiDung", NoiDung));
                    cmd.Parameters.Add(new SqlParameter("MaNoiDung", MaNoiDung));
                    cmd.Parameters.Add(new SqlParameter("ChucNangCon", ChucNangCon != null ? ChucNangCon : ""));
                    cmd.Parameters.Add(new SqlParameter("MaNganSach", MaNganSach != null ? MaNganSach : ""));
                    cmd.Parameters.Add(new SqlParameter("NSDuocDuyet", Decimal.Parse(NSDuocDuyet.Replace(",", "") != "" ? NSDuocDuyet.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("NSDuocDuyetTu", Decimal.Parse(NSDuocDuyetTu.Replace(",", "") != "" ? NSDuocDuyetTu.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("NSDuocDuyetDen", Decimal.Parse(NSDuocDuyetDen.Replace(",", "") != "" ? NSDuocDuyetDen.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("type", type));
                    cmd.Parameters.Add(new SqlParameter("status", status));
                    cmd.ExecuteNonQuery();

                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DSUQ_Add_his");
                return 0;
            }
        }

        public static DataTable SP_BBS_HRM_getlstDXUQEdit(string userid, string SoVB)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_getlstDXUQEdit", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("SoVB", SoVB));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_getlstDXUQEdit");
                return ds.Tables[0];
            }
        }

        #endregion

        #region Duyệt ủy quyền 
        public static DataTable SP_BBS_HRM_getlstDUQ(string user_div, string user_dep, string user_pos, string userid)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_getlstDUQ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_getlstDUQ");
                return ds.Tables[0];
            }
        }
        public static DataTable SP_BBS_HRM_getlstDUQDetail(string userid, string NoiDung)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_getlstDUQDetail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("NoiDung", NoiDung));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_getlstDUQDetail");
                return ds.Tables[0];
            }
        }
        #endregion

        #region Lịch sử duyệt ủy quyền
        public static DataTable SP_BBS_HRM_getlstDUQHis(string user_dep, string user_pos, string user_ND, string userid)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_getlstDUQHis", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("user_dep", user_dep));
                    cmd.Parameters.Add(new SqlParameter("user_pos", user_pos));
                    cmd.Parameters.Add(new SqlParameter("user_ND", user_ND));
                    cmd.Parameters.Add(new SqlParameter("userid", userid));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_getlstDUQHis");
                return ds.Tables[0];
            }
        }
        public static int SP_BBS_HRM_updatepermissionCancel(string ID, string NguoiDuocUyQuyen, string ChucNangCon, string modifyby)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_updatepermissionCancel", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("NguoiDuocUyQuyen", NguoiDuocUyQuyen));
                    cmd.Parameters.Add(new SqlParameter("ChucNangCon", ChucNangCon));
                    cmd.Parameters.Add(new SqlParameter("modifyby", modifyby));
                    cmd.ExecuteNonQuery();

                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_updatepermissionCancel");
                return 0;
            }
        }
        #endregion

        #region Duyệt In Out 
        public static List<objCombox> SP_BBS_HRM_InOut_LstBoPhan()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_InOut_LstBoPhan", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_InOut_LstBoPhan");
                    return it_r;
                }
            }
        }

        public static DataTable SP_BBS_HRM_InOut_getlstDuyet(string userid, string fromdate, string todate, string bophan, string trangthai)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_InOut_getlstDuyet", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("fromdate", fromdate));
                    cmd.Parameters.Add(new SqlParameter("todate", todate));
                    cmd.Parameters.Add(new SqlParameter("bophan", bophan));
                    cmd.Parameters.Add(new SqlParameter("trangthai", trangthai));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_InOut_getlstDuyet");
                return ds.Tables[0];
            }
        }

        public static int SP_BBS_HRM_InOut_AddDuyet(string userid, string GioRaVaoThucTe, string LoaiCa, string LyDoTuChoi, string CodeEmp, string TimeLog, string status)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_InOut_AddDuyet", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("GioRaVaoThucTe", GioRaVaoThucTe));
                    cmd.Parameters.Add(new SqlParameter("LoaiCa", LoaiCa));
                    cmd.Parameters.Add(new SqlParameter("LyDoTuChoi", LyDoTuChoi != null ? LyDoTuChoi : ""));
                    cmd.Parameters.Add(new SqlParameter("CodeEmp", CodeEmp));
                    cmd.Parameters.Add(new SqlParameter("TimeLog", TimeLog));
                    cmd.Parameters.Add(new SqlParameter("status", status));
                    cmd.ExecuteNonQuery();

                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_InOut_AddDuyet");
                return 0;
            }
        }
        #endregion

        #region DS Duyệt In Out
        public static DataTable SP_BBS_HRM_InOut_getlstDSDuyet(string userid, string fromdate, string todate, string bophan, string trangthai)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_InOut_getlstDSDuyet", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("fromdate", fromdate));
                    cmd.Parameters.Add(new SqlParameter("todate", todate));
                    cmd.Parameters.Add(new SqlParameter("bophan", bophan));
                    cmd.Parameters.Add(new SqlParameter("trangthai", trangthai));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_InOut_getlstDSDuyet");
                return ds.Tables[0];
            }
        }
        #endregion

        #region Obj_HoSoUngVien
        public static bool Save_HoSoUngVien_UngTuyen(string userid, Obj_HoSoUngVien info)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Save_HoSoUngVien_UngTuyen", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("ViTriTuyenDung", info.ViTriTuyenDung));
                    cmd.Parameters.Add(new SqlParameter("KeHoachTuyen", info.KeHoachTuyen));
                    cmd.Parameters.Add(new SqlParameter("NoiLamViec", info.NoiLamViec));

                    if (String.IsNullOrWhiteSpace(info.NgayNopHoSo))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayNopHoSo", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayNopHoSo", DateTime.Parse(info.NgayNopHoSo)));
                    }

                    if (String.IsNullOrWhiteSpace(info.NgayCoTheDiLam))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayCoTheDiLam", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayCoTheDiLam", DateTime.Parse(info.NgayCoTheDiLam)));
                    }

                    if (String.IsNullOrWhiteSpace(info.NgayDiLam))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayDiLam", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayDiLam", DateTime.Parse(info.NgayDiLam)));
                    }

                    cmd.Parameters.Add(new SqlParameter("SoNgayThuViec", info.SoNgayThuViec));
                    cmd.Parameters.Add(new SqlParameter("ThoiGianLamViec", info.ThoiGianLamViec));
                    cmd.Parameters.Add(new SqlParameter("Ky", info.Ky));


                    cmd.Parameters.Add(new SqlParameter("SoVongPhongVan", info.SoVongPhongVan));
                    cmd.Parameters.Add(new SqlParameter("PhongBanUT", info.PhongBanUT));
                    cmd.Parameters.Add(new SqlParameter("ChucDanh", info.ChucDanh));
                    cmd.Parameters.Add(new SqlParameter("ChucVu", info.ChucVu));
                    cmd.Parameters.Add(new SqlParameter("NguoiQuanLyTrucTiep", info.NguoiQuanLyTrucTiep));
                    cmd.Parameters.Add(new SqlParameter("LoaiLoaDong", info.LoaiLoaDong));
                    cmd.Parameters.Add(new SqlParameter("LoaiNhanVien", info.LoaiNhanVien));
                    cmd.Parameters.Add(new SqlParameter("CapBacCM", info.CapBacCM));
                    cmd.Parameters.Add(new SqlParameter("KhuVucLamViec", info.KhuVucLamViec));

                    cmd.Parameters.Add(new SqlParameter("NgachLuong", info.NgachLuong));
                    cmd.Parameters.Add(new SqlParameter("BacLuong", info.BacLuong));
                    cmd.Parameters.Add(new SqlParameter("LuongDeNghi", info.LuongDeNghi));
                    cmd.Parameters.Add(new SqlParameter("LuongHienTai", info.LuongHienTai));
                    cmd.Parameters.Add(new SqlParameter("LuongDuocDuyet", info.LuongDuocDuyet));
                    cmd.Parameters.Add(new SqlParameter("LuongThuViec", info.LuongThuViec));
                    cmd.Parameters.Add(new SqlParameter("TienTeChung", info.TienTeChung));

                    cmd.Parameters.Add(new SqlParameter("PhuCap", info.PhuCap));
                    cmd.Parameters.Add(new SqlParameter("PhuCapQuanLy", info.PhuCapQuanLy));
                    cmd.Parameters.Add(new SqlParameter("PhuCapNgonNgu", info.PhuCapNgonNgu));
                    cmd.Parameters.Add(new SqlParameter("PhuCapKyNang", info.PhuCapKyNang));
                    cmd.Parameters.Add(new SqlParameter("PhuCapDiLai", info.PhuCapDiLai));
                    cmd.Parameters.Add(new SqlParameter("TruongTotNghiep", info.TruongTotNghiep));
                    cmd.Parameters.Add(new SqlParameter("NamTotNghiep", info.NamTotNghiep));
                    cmd.Parameters.Add(new SqlParameter("SoNamKinhNghiem", info.SoNamKinhNghiem));

                    cmd.Parameters.Add(new SqlParameter("SoNamOViTriOT", info.SoNamOViTriOT));
                    cmd.Parameters.Add(new SqlParameter("CongTyLanGanNhat", info.CongTyLanGanNhat));
                    cmd.Parameters.Add(new SqlParameter("ChuyenNganh", info.ChuyenNganh));
                    cmd.Parameters.Add(new SqlParameter("XepLoai", info.XepLoai));
                    cmd.Parameters.Add(new SqlParameter("TayNghe", info.TayNghe));

                    cmd.Parameters.Add(new SqlParameter("ViTriNganhDaLam", info.ViTriNganhDaLam));
                    cmd.Parameters.Add(new SqlParameter("NguonTuyenDung", info.NguonTuyenDung));
                    cmd.Parameters.Add(new SqlParameter("TrangThai", info.TrangThai));
                    cmd.Parameters.Add(new SqlParameter("DiemManh", info.DiemManh));
                    cmd.Parameters.Add(new SqlParameter("DiemYeu", info.DiemYeu));
                    cmd.Parameters.Add(new SqlParameter("MongDoiCuaBan", info.MongDoiCuaBan));
                    cmd.Parameters.Add(new SqlParameter("DinhHuongNgheNghiep", info.DinhHuongNgheNghiep));

                    cmd.Parameters.Add(new SqlParameter("DiCongTac", info.DiCongTac));
                    cmd.Parameters.Add(new SqlParameter("DaRutHoSo", info.DaRutHoSo));
                    cmd.Parameters.Add(new SqlParameter("MucTieuCaNhan", info.MucTieuCaNhan));
                    cmd.Parameters.Add(new SqlParameter("KeHoachCaNhan", info.KeHoachCaNhan));
                    cmd.Parameters.Add(new SqlParameter("NangKhieu", info.NangKhieu));
                    cmd.Parameters.Add(new SqlParameter("CacHoatDongNgoaiKhoa", info.CacHoatDongNgoaiKhoa));


                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Save_HoSoUngVien_UngTuyen");
                    return false;
                }
            }
        }
        #endregion

        #region Obj_KhaiBao_HoSoUngVien
        public static bool Save_KhaiBao_HoSoUngVien(string userid, Obj_KhaiBao_HoSoUngVien info)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Save_KhaiBao_HoSoUngVien", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("TenUngVien", info.TenUngVien));
                    cmd.Parameters.Add(new SqlParameter("MaUngVien", info.MaUngVien));
                    cmd.Parameters.Add(new SqlParameter("SobaoDanh", info.SobaoDanh));
                    cmd.Parameters.Add(new SqlParameter("GioiTinh", info.GioiTinh));
                    cmd.Parameters.Add(new SqlParameter("TinhTrangHonNhan", info.TinhTrangHonNhan));
                    if (String.IsNullOrWhiteSpace(info.NgaySinh))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgaySinh", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgaySinh", DateTime.Parse(info.NgaySinh)));
                    }
                    cmd.Parameters.Add(new SqlParameter("NoiSinh", info.NoiSinh));
                    cmd.Parameters.Add(new SqlParameter("NguyenQuan", info.NguyenQuan));
                    cmd.Parameters.Add(new SqlParameter("QuocTich", info.QuocTich));
                    cmd.Parameters.Add(new SqlParameter("TonGiao", info.TonGiao));
                    cmd.Parameters.Add(new SqlParameter("TrinhDoVanHoa", info.TrinhDoVanHoa));
                    cmd.Parameters.Add(new SqlParameter("TrinhDoHocVan", info.TrinhDoHocVan));
                    cmd.Parameters.Add(new SqlParameter("TenThuongGoi", info.TenThuongGoi));
                    cmd.Parameters.Add(new SqlParameter("TenTiengHoa", info.TenTiengHoa));
                    cmd.Parameters.Add(new SqlParameter("SoCMND", info.SoCMND));
                    if (String.IsNullOrWhiteSpace(info.NgayCapCMND))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayCapCMND", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayCapCMND", DateTime.Parse(info.NgayCapCMND)));
                    }

                    cmd.Parameters.Add(new SqlParameter("NoiCap", info.NoiCap));
                    cmd.Parameters.Add(new SqlParameter("MST", info.MST));
                    if (String.IsNullOrWhiteSpace(info.NgayApDung))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayApDung", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayApDung", DateTime.Parse(info.NgayApDung)));
                    }
                    cmd.Parameters.Add(new SqlParameter("CoQuanQuanLy", info.CoQuanQuanLy));
                    cmd.Parameters.Add(new SqlParameter("SoHoChieu", info.SoHoChieu));
                    cmd.Parameters.Add(new SqlParameter("NoiCapHoChieu", info.NoiCapHoChieu));

                    if (String.IsNullOrWhiteSpace(info.NgayCap))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayCap", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayCap", DateTime.Parse(info.NgayCap)));
                    }

                    if (String.IsNullOrWhiteSpace(info.NgayHetHanHoChieu))
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayHetHanHoChieu", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("NgayHetHanHoChieu", DateTime.Parse(info.NgayHetHanHoChieu)));
                    }
                    cmd.Parameters.Add(new SqlParameter("SoTheCanCuoc", info.SoTheCanCuoc));
                    cmd.Parameters.Add(new SqlParameter("DienThoaiDiDong", info.DienThoaiDiDong));
                    cmd.Parameters.Add(new SqlParameter("DienThoaiNha", info.DienThoaiNha));
                    cmd.Parameters.Add(new SqlParameter("DienThoaiDiDong2", info.DienThoaiDiDong2));
                    cmd.Parameters.Add(new SqlParameter("Email", info.Email));
                    cmd.Parameters.Add(new SqlParameter("QuocGiaThuongTru", info.QuocGiaThuongTru));
                    cmd.Parameters.Add(new SqlParameter("TinhThanhCode", info.TinhThanhCode));
                    cmd.Parameters.Add(new SqlParameter("TinhThanh", info.TinhThanh));
                    cmd.Parameters.Add(new SqlParameter("QuanHuyenCode", info.QuanHuyenCode));
                    cmd.Parameters.Add(new SqlParameter("QuanHuyen", info.QuanHuyen));
                    cmd.Parameters.Add(new SqlParameter("PhuongXaCode", info.PhuongXaCode));
                    cmd.Parameters.Add(new SqlParameter("PhuongXa", info.PhuongXa));
                    cmd.Parameters.Add(new SqlParameter("DiaChiThuongTru", info.DiaChiThuongTru));
                    cmd.Parameters.Add(new SqlParameter("QuocGiaCMND", info.QuocGiaCMND));
                    cmd.Parameters.Add(new SqlParameter("TinhThanhCMNDCode", info.TinhThanhCMNDCode));
                    cmd.Parameters.Add(new SqlParameter("TinhThanhCMND", info.TinhThanhCMND));
                    cmd.Parameters.Add(new SqlParameter("QuanHuyenCMNDCode", info.QuanHuyenCMNDCode));
                    cmd.Parameters.Add(new SqlParameter("QuanHuyenCMND", info.QuanHuyenCMND));
                    cmd.Parameters.Add(new SqlParameter("PhuongXaCMNDCode", info.PhuongXaCMNDCode));
                    cmd.Parameters.Add(new SqlParameter("PhuongXaCMND", info.PhuongXaCMND));
                    cmd.Parameters.Add(new SqlParameter("DiaChiCMND", info.DiaChiCMND));
                    cmd.Parameters.Add(new SqlParameter("QuocGiaTamTru", info.QuocGiaTamTru));
                    cmd.Parameters.Add(new SqlParameter("TinhThanhTamTruCode", info.TinhThanhTamTruCode));
                    cmd.Parameters.Add(new SqlParameter("TinhThanhTamTru", info.TinhThanhTamTru));
                    cmd.Parameters.Add(new SqlParameter("QuanHuyenTamTruCode", info.QuanHuyenTamTruCode));
                    cmd.Parameters.Add(new SqlParameter("QuanHuyenTamTru", info.QuanHuyenTamTru));
                    cmd.Parameters.Add(new SqlParameter("PhuongXaTamTruCode", info.PhuongXaTamTruCode));
                    cmd.Parameters.Add(new SqlParameter("PhuongXaTamTru", info.PhuongXaTamTru));
                    cmd.Parameters.Add(new SqlParameter("DiaChiThuongTruTamTru", info.DiaChiThuongTruTamTru));
                    cmd.Parameters.Add(new SqlParameter("TinhTrangSucKhoe", info.TinhTrangSucKhoe));
                    cmd.Parameters.Add(new SqlParameter("ChieuCao", info.ChieuCao));
                    cmd.Parameters.Add(new SqlParameter("CanNang", info.CanNang));
                    cmd.Parameters.Add(new SqlParameter("MatTrai", info.MatTrai));
                    cmd.Parameters.Add(new SqlParameter("MatPhai", info.MatPhai));
                    cmd.Parameters.Add(new SqlParameter("BenhLy", info.BenhLy));
                    cmd.Parameters.Add(new SqlParameter("HuyetAp", info.HuyetAp));
                    cmd.Parameters.Add(new SqlParameter("NhipTim", info.NhipTim));
                    cmd.Parameters.Add(new SqlParameter("BangLaiXe", info.BangLaiXe));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Save_KhaiBao_HoSoUngVien");
                    return false;
                }
            }
        }


        #endregion

        #region Booking phòng họp
        public static List<HRMbooking> SP_BBS_HRM_BookingRoom_getDSPhongHop(string uid)
        {
            List<HRMbooking> it_r = new List<HRMbooking>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_BookingRoom_getDSPhongHop", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("uid", uid));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HRMbooking it = new HRMbooking
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            KhuVuc = reader["KhuVuc"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_BookingRoom_getDSPhongHop");
                    return it_r;
                }
            }
        }

        public static DataTable SP_BBS_HRM_getlstBookingTime(string userid, string time, string phong)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_getlstBookingTime", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("time", time));
                    cmd.Parameters.Add(new SqlParameter("phong", phong));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_getlstBookingTime");
                return ds.Tables[0];
            }
        }

        public static bool SP_BBS_HRM_BookingRoom_Add(string userid, HRMbookingAdd info)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_BookingRoom_Add", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("RoomCode", info.RoomCode));
                    cmd.Parameters.Add(new SqlParameter("RoomName", info.RoomName));
                    cmd.Parameters.Add(new SqlParameter("NoiDung", info.NoiDung));
                    cmd.Parameters.Add(new SqlParameter("ThanhPhan", info.ThanhPhan));
                    if (String.IsNullOrWhiteSpace(info.StartTime))
                    {
                        cmd.Parameters.Add(new SqlParameter("StartTime", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("StartTime", DateTime.Parse(info.StartTime)));
                    }
                    if (String.IsNullOrWhiteSpace(info.EndTime))
                    {
                        cmd.Parameters.Add(new SqlParameter("EndTime", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("EndTime", DateTime.Parse(info.EndTime)));
                    }
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_BookingRoom_Add");
                    return false;
                }
            }
        }

        public static DataTable SP_BBS_HRM_checktime(string userid, string phong, string time, string StartTime, string EndTime)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_checktime", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("time", time));
                    cmd.Parameters.Add(new SqlParameter("phong", phong));
                    if (String.IsNullOrWhiteSpace(StartTime))
                    {
                        cmd.Parameters.Add(new SqlParameter("StartTime", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("StartTime", DateTime.Parse(StartTime)));
                    }
                    if (String.IsNullOrWhiteSpace(EndTime))
                    {
                        cmd.Parameters.Add(new SqlParameter("EndTime", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("EndTime", DateTime.Parse(EndTime)));
                    }
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_checktime");
                return ds.Tables[0];
            }
        }

        #endregion

        #region Định biên và phân ca

        public static List<backLink_DinhBien> SP_BBS_HRM_DinhBienPhanCa_backLink_get(string uid)
        {
            List<backLink_DinhBien> it_r = new List<backLink_DinhBien>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DinhBienPhanCa_backLink_get", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;


                    cmd.Parameters.Add(new SqlParameter("uid", uid));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        backLink_DinhBien its = new backLink_DinhBien
                        {
                            CodeEmp = reader["CodeEmp"].ToString(),
                            E_SECTION_CODE = reader["E_SECTION_CODE"].ToString(),
                            E_SECTION = reader["E_SECTION"].ToString(),
                            Level = reader["Level"].ToString(),
                            backName = reader["backName"].ToString(),
                            backLink = reader["backLink"].ToString(),
                            isDesktop = int.Parse(reader["isDesktop"].ToString()),

                        };

                        it_r.Add(its);
                    }
                    con.Close();

                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DinhBienPhanCa_backLink_get");
                    return it_r;
                }

            }
        }

        public static List<objCombox> SP_BBS_HRM_DinhBienPhanCa_getstore(string uid)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DinhBienPhanCa_getstore", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("uid", uid));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DinhBienPhanCa_getstore");
                    return it_r;
                }
            }
        }

        public static empinfo sp_getChucvu_user(string userid)
        {
            empinfo it_r = new empinfo();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_getChucvu_user", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        empinfo it_ = new empinfo
                        {
                            MaNV = reader["MaNV"].ToString(),
                            TenNV = reader["TenNV"].ToString(),
                            MaCD = reader["MaCD"].ToString(),
                            TenCD = reader["TenCD"].ToString(),
                            MaCB = reader["MaCB"].ToString(),
                            TenCB = reader["TenCB"].ToString(),
                        };
                        it_r = it_;
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getChucvu_user");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_BBS_HRM_DinhBienPhanCa_getfillter_QLST(string store)
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DinhBienPhanCa_getfillter_QLST", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("store", store));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DinhBienPhanCa_getfillter_QLST");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_BBS_HRM_DinhBienPhanCa_getfillter_NVTV(string store, string Phanca, string ngay)
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DinhBienPhanCa_getfillter_NVTV", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("store", store));
                    cmd.Parameters.Add(new SqlParameter("Phanca", Phanca));
                    if (String.IsNullOrWhiteSpace(ngay))
                    {
                        cmd.Parameters.Add(new SqlParameter("ngay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("ngay", DateTime.Parse(ngay)));
                    }
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DinhBienPhanCa_getfillter_NVTV");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_BBS_HRM_DinhBienPhanCa_getfillter_NVTN(string store, string Phanca, string ngay)
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DinhBienPhanCa_getfillter_NVTN", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("store", store));
                    cmd.Parameters.Add(new SqlParameter("Phanca", Phanca));
                    if (String.IsNullOrWhiteSpace(ngay))
                    {
                        cmd.Parameters.Add(new SqlParameter("ngay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("ngay", DateTime.Parse(ngay)));
                    }
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DinhBienPhanCa_getfillter_NVTN");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_BBS_HRM_DinhBienPhanCa_getfillter_NVTD(string store, string Phanca, string ngay)
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DinhBienPhanCa_getfillter_NVTD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("store", store));
                    cmd.Parameters.Add(new SqlParameter("Phanca", Phanca));
                    if (String.IsNullOrWhiteSpace(ngay))
                    {
                        cmd.Parameters.Add(new SqlParameter("ngay", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("ngay", DateTime.Parse(ngay)));
                    }
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DinhBienPhanCa_getfillter_NVTD");
                    return it_r;
                }
            }
        }

        public static DataTable SP_BBS_HRM_DinhBienPhanCa_getlst(string userid, string store)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DinhBienPhanCa_getlst", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("store", store));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DinhBienPhanCa_getlst");
                return ds.Tables[0];
            }
        }

        public static int SP_BBS_HRM_DinhBienPhanCa_Add(string userid, string store, string Ca1Chot, string Ca2Chot, string Ca3Chot, string Ngay, string ChucDanhTT, string NhanVien, string PhanCa)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DinhBienPhanCa_Add", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("store", store));
                    cmd.Parameters.Add(new SqlParameter("Ca1Chot", Decimal.Parse(Ca1Chot.Replace(",", "") != "" ? Ca1Chot.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("Ca2Chot", Decimal.Parse(Ca1Chot.Replace(",", "") != "" ? Ca2Chot.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("Ca3Chot", Decimal.Parse(Ca1Chot.Replace(",", "") != "" ? Ca3Chot.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("Ngay", Ngay != null ? Ngay : ""));
                    cmd.Parameters.Add(new SqlParameter("ChucDanhTT", ChucDanhTT));
                    cmd.Parameters.Add(new SqlParameter("NhanVien", NhanVien));
                    cmd.Parameters.Add(new SqlParameter("PhanCa", PhanCa));
                    cmd.ExecuteNonQuery();

                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DinhBienPhanCa_Add");
                return 0;
            }
        }

        public static int SP_BBS_HRM_DinhBienPhanCa_Addold(string userid, string store, string Ca1Chot, string Ca2Chot, string Ca3Chot, string QLSTca1, string NVTNca1, string NVTVca1, string NVTDca1, string QLSTca2, string NVTNca2, string NVTVca2, string NVTDca2, string QLSTca3)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DinhBienPhanCa_Addold", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("store", store));
                    cmd.Parameters.Add(new SqlParameter("Ca1Chot", Decimal.Parse(Ca1Chot.Replace(",", "") != "" ? Ca1Chot.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("Ca2Chot", Decimal.Parse(Ca1Chot.Replace(",", "") != "" ? Ca2Chot.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("Ca3Chot", Decimal.Parse(Ca1Chot.Replace(",", "") != "" ? Ca3Chot.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("QLSTca1", QLSTca1));
                    cmd.Parameters.Add(new SqlParameter("NVTNca1", NVTNca1));
                    cmd.Parameters.Add(new SqlParameter("NVTVca1", NVTVca1));
                    cmd.Parameters.Add(new SqlParameter("NVTDca1", NVTDca1));
                    cmd.Parameters.Add(new SqlParameter("QLSTca2", QLSTca2));
                    cmd.Parameters.Add(new SqlParameter("NVTNca2", NVTNca2));
                    cmd.Parameters.Add(new SqlParameter("NVTVca2", NVTVca2));
                    cmd.Parameters.Add(new SqlParameter("NVTDca2", NVTDca2));
                    cmd.Parameters.Add(new SqlParameter("QLSTca3", QLSTca3));
                    cmd.ExecuteNonQuery();

                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DinhBienPhanCa_Addold");
                return 0;
            }
        }


        public static int SP_BBS_HRM_DinhBienPhanCa_Support_Add(string userid, string store_sp, string Ngay_sp, string Ca_sp, string ChucDanh_sp, string slthieu)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DinhBienPhanCa_Support_Add", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("store_sp", store_sp));
                    if (String.IsNullOrWhiteSpace(Ngay_sp))
                    {
                        cmd.Parameters.Add(new SqlParameter("Ngay_sp", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("Ngay_sp", DateTime.Parse(Ngay_sp)));
                    }
                    cmd.Parameters.Add(new SqlParameter("Ca_sp", Ca_sp));
                    cmd.Parameters.Add(new SqlParameter("ChucDanh_sp", ChucDanh_sp));
                    cmd.Parameters.Add(new SqlParameter("slthieu", Decimal.Parse(slthieu.Replace(",", "") != "" ? slthieu.Replace(",", "") : "0")));
                    cmd.ExecuteNonQuery();

                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DinhBienPhanCa_Support_Add");
                return 0;
            }
        }

        public static DataTable SP_BBS_HRM_DinhBienPhanCa_getdetailsupport_ShiftQLST(string userid, string store, string date)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DinhBienPhanCa_getdetailsupport_ShiftQLST", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("store", store));
                    if (String.IsNullOrWhiteSpace(date))
                    {
                        cmd.Parameters.Add(new SqlParameter("date", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("date", DateTime.Parse(date)));
                    }
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DinhBienPhanCa_getdetailsupport_ShiftQLST");
                return ds.Tables[0];
            }
        }
        #endregion

        #region Duyệt điều chuyển NSCH
        public static List<objCombox> SP_BBS_HRM_DieuChuyenNSCH_getPostision(string uid)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DieuChuyenNSCH_getPostision", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("uid", uid));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DieuChuyenNSCH_getPostision");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_BBS_HRM_DieuChuyenNSCH_getProvinceStore(string uid)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DieuChuyenNSCH_getProvinceStore", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("uid", uid));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DieuChuyenNSCH_getProvinceStore");
                    return it_r;
                }
            }
        }

        public static DataTable SP_BBS_HRM_DieuChuyenNSCH_getlst(string userid, string LoaiDieuChuyen, string Province, string Postision, string Store)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DieuChuyenNSCH_getlst", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("LoaiDieuChuyen", LoaiDieuChuyen));
                    cmd.Parameters.Add(new SqlParameter("Province", Province));
                    cmd.Parameters.Add(new SqlParameter("Postision", Postision));
                    cmd.Parameters.Add(new SqlParameter("Store", Store));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DieuChuyenNSCH_getlst");
                return ds.Tables[0];
            }
        }

        public static DataTable SP_BBS_HRM_DieuChuyenNSCH_getlstDetails(string userid, string LoaiDieuChuyen)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DieuChuyenNSCH_getlstDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("LoaiDieuChuyen", LoaiDieuChuyen));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DieuChuyenNSCH_getlstDetails");
                return ds.Tables[0];
            }
        }

        public static int SP_BBS_HRM_DieuChuyenNSCH_Add(string userid, string MaNVdc, string MaCHnhan, string TenCHnhan, string ChucDanhnhan, string SLThieu, string LoaiDieuChuyen)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DieuChuyenNSCH_Add", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("MaNVdc", MaNVdc));
                    cmd.Parameters.Add(new SqlParameter("MaCHnhan", MaCHnhan));
                    cmd.Parameters.Add(new SqlParameter("TenCHnhan", TenCHnhan));
                    cmd.Parameters.Add(new SqlParameter("ChucDanhnhan", ChucDanhnhan));
                    cmd.Parameters.Add(new SqlParameter("SLThieu", Decimal.Parse(SLThieu.Replace(",", "") != "" ? SLThieu.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("LoaiDieuChuyen", LoaiDieuChuyen));
                    cmd.ExecuteNonQuery();

                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DieuChuyenNSCH_Add");
                return 0;
            }
        }

        #endregion

        #region Danh sách điều chuyển NSCH

        public static List<objCombox> SP_BBS_HRM_DSDieuChuyenNSCH_getStoreChuyen(string uid)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DSDieuChuyenNSCH_getStoreChuyen", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("uid", uid));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DSDieuChuyenNSCH_getStoreChuyen");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_BBS_HRM_DSDieuChuyenNSCH_getStoreNhan(string uid)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DSDieuChuyenNSCH_getStoreNhan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("uid", uid));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DSDieuChuyenNSCH_getStoreNhan");
                    return it_r;
                }
            }
        }

        public static List<objCombox> SP_BBS_HRM_DSDieuChuyenNSCH_getUser(string uid)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DSDieuChuyenNSCH_getUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("uid", uid));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DSDieuChuyenNSCH_getUser");
                    return it_r;
                }
            }
        }

        public static DataTable SP_BBS_HRM_DSDieuChuyenNSCH_getlst(string userid, string CHchuyen, string CHnhan, string NhanVien, string frDate, string toDate)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DSDieuChuyenNSCH_getlst", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("CHchuyen", CHchuyen));
                    cmd.Parameters.Add(new SqlParameter("CHnhan", CHnhan));
                    cmd.Parameters.Add(new SqlParameter("NhanVien", NhanVien));
                    if (String.IsNullOrWhiteSpace(frDate))
                    {
                        cmd.Parameters.Add(new SqlParameter("frDate", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("frDate", DateTime.Parse(frDate)));
                    }
                    if (String.IsNullOrWhiteSpace(toDate))
                    {
                        cmd.Parameters.Add(new SqlParameter("toDate", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("toDate", DateTime.Parse(toDate)));
                    }
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DSDieuChuyenNSCH_getlst");
                return ds.Tables[0];
            }
        }

        public static int SP_BBS_HRM_DSDieuChuyenNSCH_Update(string userid, string ID)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_HRM_DSDieuChuyenNSCH_Update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("ID", ID));

                    cmd.ExecuteNonQuery();

                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_DSDieuChuyenNSCH_Update");
                return 0;
            }
        }
        #endregion

        #region Điều chuyển nhân sự
        public static List<objCombox> SP_BBS_DieuChuyenNhanSu_getUser(string uid)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBS_DieuChuyenNhanSu_getUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("uid", uid));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_DieuChuyenNhanSu_getUser");
                    return it_r;
                }
            }
        }

        public static DataTable SP_BBS_DieuChuyenNhanSu_getlst(string userid, string DCNS_frDate, string DCNS_toDate, string DCNS_uid)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BBS_DieuChuyenNhanSu_getlst", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                
                    if (String.IsNullOrWhiteSpace(DCNS_frDate))
                    {
                        cmd.Parameters.Add(new SqlParameter("DCNS_frDate", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("DCNS_frDate", DateTime.Parse(DCNS_frDate)));
                    }
                    if (String.IsNullOrWhiteSpace(DCNS_toDate))
                    {
                        cmd.Parameters.Add(new SqlParameter("DCNS_toDate", DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("DCNS_toDate", DateTime.Parse(DCNS_toDate)));
                    }
                    cmd.Parameters.Add(new SqlParameter("DCNS_uid", DCNS_uid));

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_DieuChuyenNhanSu_getlst");
                return ds.Tables[0];
            }
        }
        #endregion 

        #region Thông tin nhân sự
        public static Obj_ThongTinNhanSu sp_get_Thong_Tin_Nhan_Su(string userid)
        {
            Obj_ThongTinNhanSu it_r = new Obj_ThongTinNhanSu();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_get_Thong_Tin_Nhan_Su", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Obj_ThongTinNhanSu it = new Obj_ThongTinNhanSu
                        {
                            ttcn_Ma_Nhan_Vien = reader["ttcn_Ma_Nhan_Vien"].ToString(),
                            ttcn_Ho_Ten = reader["ttcn_Ho_Ten"].ToString(),
                            ttcn_Cong_Ty = reader["ttcn_Cong_Ty"].ToString(),
                            ttcn_Khoi = reader["ttcn_Khoi"].ToString(),
                            ttcn_Phong_Ban = reader["ttcn_Phong_Ban"].ToString(),
                            ttcn_Bo_Phan = reader["ttcn_Bo_Phan"].ToString(),
                            ttcv_Chuc_Danh_Hien_Tai = reader["ttcv_Chuc_Danh_Hien_Tai"].ToString(),
                            ttcv_Ngay_Bo_Nhiem = reader["ttcv_Ngay_Bo_Nhiem"].ToString(),
                            ttcv_Quyet_Dinh_Bo_Nhiem = reader["ttcv_Quyet_Dinh_Bo_Nhiem"].ToString(),
                            ttcv_Che_Do_Lam_Viec = reader["ttcv_Che_Do_Lam_Viec"].ToString(),
                            ttcv_Dia_Diem_Lam_Viec = reader["ttcv_Dia_Diem_Lam_Viec"].ToString(),
                            ttlv_Tinh_Trang_Lam_Viec = reader["ttlv_Tinh_Trang_Lam_Viec"].ToString(),
                            ttlv_Ngay_Vao_Cong_Ty = reader["ttlv_Ngay_Vao_Cong_Ty"].ToString(),
                            ttlv_Loai_Hd_Hien_Tai = reader["ttlv_Loai_Hd_Hien_Tai"].ToString(),
                            ttlv_Ngay_Het_Hd_Hien_Tai = reader["ttlv_Ngay_Het_Hd_Hien_Tai"].ToString(),
                            ttlv_Ngay_Nghi_Thai_San = reader["ttlv_Ngay_Nghi_Thai_San"].ToString(),
                            ttlv_Ngay_Di_Lam_Lai = reader["ttlv_Ngay_Di_Lam_Lai"].ToString(),
                            ltv_Luong_P1 = decimal.Parse(reader["ltv_Luong_P1"].ToString()),
                            ltv_Luong_P2 = decimal.Parse(reader["ltv_Luong_P2"].ToString()),
                            ltv_Luong_P3 = decimal.Parse(reader["ltv_Luong_P3"].ToString()),
                            ltv_Phu_Cap_Xang_Xe = decimal.Parse(reader["ltv_Phu_Cap_Xang_Xe"].ToString()),
                            ltv_Phu_Cap_Dien_Thoai = decimal.Parse(reader["ltv_Phu_Cap_Dien_Thoai"].ToString()),
                            ltv_Phu_Cap_Khac = decimal.Parse(reader["ltv_Phu_Cap_Khac"].ToString()),
                            lct_Luong_P1 = decimal.Parse(reader["lct_Luong_P1"].ToString()),
                            lct_Luong_Bhxh = decimal.Parse(reader["lct_Luong_Bhxh"].ToString()),
                            lct_Luong_P2 = decimal.Parse(reader["lct_Luong_P2"].ToString()),
                            lct_Luong_P3 = decimal.Parse(reader["lct_Luong_P3"].ToString()),
                            lct_Phu_Cap_Xang_Xe = decimal.Parse(reader["lct_Phu_Cap_Xang_Xe"].ToString()),
                            lct_Phu_Cap_Dien_Thoai = decimal.Parse(reader["lct_Phu_Cap_Dien_Thoai"].ToString()),
                            lct_Phu_Cap_Khac = decimal.Parse(reader["lct_Phu_Cap_Khac"].ToString()),
                            tdl_So_Quyet_Dinh = reader["tdl_So_Quyet_Dinh"].ToString(),
                            tdl_Ngay_Thay_Doi = reader["tdl_Ngay_Thay_Doi"].ToString(),
                            tdl_Ly_Do_Thay_Doi = reader["tdl_Ly_Do_Thay_Doi"].ToString(),
                            tdl_Luong_P1_Moi = decimal.Parse(reader["tdl_Luong_P1_Moi"].ToString()),
                            tdl_Luong_P2_Moi = decimal.Parse(reader["tdl_Luong_P2_Moi"].ToString()),
                            tdl_Luong_P3_Moi = decimal.Parse(reader["tdl_Luong_P3_Moi"].ToString()),
                            tdl_Phu_Cap_Xang_Xe = decimal.Parse(reader["tdl_Phu_Cap_Xang_Xe"].ToString()),
                            tdl_Phu_Cap_Dien_Thoai = decimal.Parse(reader["tdl_Phu_Cap_Dien_Thoai"].ToString()),
                            tdl_Phu_Cap_Khac = decimal.Parse(reader["tdl_Phu_Cap_Khac"].ToString()),
                            tdct_So_Quyet_Dinh = reader["tdct_So_Quyet_Dinh"].ToString(),
                            tdct_Ngay_Dieu_Chuyen = reader["tdct_Ngay_Dieu_Chuyen"].ToString(),
                            tdct_Chuc_Danh_Cu = reader["tdct_Chuc_Danh_Cu"].ToString(),
                            tdct_Phong_Ban_Cu = reader["tdct_Phong_Ban_Cu"].ToString(),
                            tdct_Bo_Phan_Cu = reader["tdct_Bo_Phan_Cu"].ToString(),
                            tdct_Chuc_Danh_Moi = reader["tdct_Chuc_Danh_Moi"].ToString(),
                            tdct_Phong_Ban_Moi = reader["tdct_Phong_Ban_Moi"].ToString(),
                            tdct_Bo_Phan_Moi = reader["tdct_Bo_Phan_Moi"].ToString(),
                            tdct_Muc_Luong_Moi = decimal.Parse(reader["tdct_Muc_Luong_Moi"].ToString()),
                            ltd_Tuyen_Moi = reader["ltd_Tuyen_Moi"].ToString(),
                            ltd_Nghi_Quay_Lai = reader["ltd_Nghi_Quay_Lai"].ToString(),
                            ltd_Thai_San_Lam_Lai = reader["ltd_Thai_San_Lam_Lai"].ToString(),
                            td_Trinh_Do = reader["td_Trinh_Do"].ToString(),
                            td_Chuyen_Nganh = reader["td_Chuyen_Nganh"].ToString(),
                            td_Truong_Dao_Tao = reader["td_Truong_Dao_Tao"].ToString(),
                            td_Nam_Tot_Nghiep = decimal.Parse(reader["td_Nam_Tot_Nghiep"].ToString()),
                            cmnd_So_Cmnd_Cccd = reader["cmnd_So_Cmnd_Cccd"].ToString(),
                            cmnd_Noi_Cap = reader["cmnd_Noi_Cap"].ToString(),
                            cmnd_Ngay_Cap = reader["cmnd_Ngay_Cap"].ToString(),
                            cmnd_Dia_Chi_Tam_Tru = reader["cmnd_Dia_Chi_Tam_Tru"].ToString(),
                            cmnd_Dia_Chi_Thuong_Tru = reader["cmnd_Dia_Chi_Thuong_Tru"].ToString(),
                            nlh_Ho_Ten = reader["nlh_Ho_Ten"].ToString(),
                            nlh_So_Dien_Thoai = reader["nlh_So_Dien_Thoai"].ToString(),
                            nlh_Email = reader["nlh_Email"].ToString(),
                            Tinh_Trang_Hon_Nhan = reader["Tinh_Trang_Hon_Nhan"].ToString(),
                            cc_Ho_Ten_Con_1 = reader["cc_Ho_Ten_Con_1"].ToString(),
                            cc_Ngay_Sinh1 = reader["cc_Ngay_Sinh1"].ToString(),
                            cc_Ho_Ten_Con_2 = reader["cc_Ho_Ten_Con_2"].ToString(),
                            cc_Ngay_Sinh2 = reader["cc_Ngay_Sinh2"].ToString(),
                            clhs_So_Yeu_Ly_Lich = reader["clhs_So_Yeu_Ly_Lich"].ToString(),
                            clhs_Cmnd_Cccd = reader["clhs_Cmnd_Cccd"].ToString(),
                            clhs_So_Ho_Khau = reader["clhs_So_Ho_Khau"].ToString(),
                            clhs_Bang_Cap = reader["clhs_Bang_Cap"].ToString(),
                            clhs_Giay_Kham_Suc_Khoe = reader["clhs_Giay_Kham_Suc_Khoe"].ToString(),
                            clhs_Luu_Quyen_So = reader["clhs_Luu_Quyen_So"].ToString(),
                            ttcl_So_Tai_Khoan_1 = reader["ttcl_So_Tai_Khoan_1"].ToString(),
                            ttcl_Ngan_Hang_1 = reader["ttcl_Ngan_Hang_1"].ToString(),
                            ttcl_So_Tai_Khoan_2 = reader["ttcl_So_Tai_Khoan_2"].ToString(),
                            ttcl_Ngan_Hang_2 = reader["ttcl_Ngan_Hang_2"].ToString(),
                            ttcl_So_Tai_Khoan_3 = reader["ttcl_So_Tai_Khoan_3"].ToString(),
                            ttcl_Ngan_Hang_3 = reader["ttcl_Ngan_Hang_3"].ToString(),
                            ttcl_Email_Chuyen_Luong = reader["ttcl_Email_Chuyen_Luong"].ToString(),
                            ttcl_Ma_So_Thue_Tncn = reader["ttcl_Ma_So_Thue_Tncn"].ToString(),
                            bhxh_So_So_Bhxh = reader["bhxh_So_So_Bhxh"].ToString(),
                            bhxh_So_Nguoi_Phu_Thuoc = decimal.Parse(reader["bhxh_So_Nguoi_Phu_Thuoc"].ToString()),
                            nv_Ngay_Nhan_Don = reader["nv_Ngay_Nhan_Don"].ToString(),
                            nv_Nguon_Tiep_Nhan = reader["nv_Nguon_Tiep_Nhan"].ToString(),
                            nv_Ly_Do_Nghi_Viec = reader["nv_Ly_Do_Nghi_Viec"].ToString(),
                            nv_Tinh_Trang_Ban_Giao = reader["nv_Tinh_Trang_Ban_Giao"].ToString(),
                            nv_Ngay_Ra_Qdnv = reader["nv_Ngay_Ra_Qdnv"].ToString(),
                            clnv_Don_Xin_Nghi_Viec = reader["clnv_Don_Xin_Nghi_Viec"].ToString(),
                            clnv_Quan_Ly_Xac_Nhan = reader["clnv_Quan_Ly_Xac_Nhan"].ToString(),
                            clnv_Hanh_Chinh = reader["clnv_Hanh_Chinh"].ToString(),
                            clnv_Ke_Toan = reader["clnv_Ke_Toan"].ToString(),
                            clnv_Kiem_Soat_Noi_Bo = reader["clnv_Kiem_Soat_Noi_Bo"].ToString(),
                            clnv_Cntt = reader["clnv_Cntt"].ToString(),
                            clnv_Kiem_Ke = reader["clnv_Kiem_Ke"].ToString()
                        };
                        it_r = it;
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_BookingRoom_getDSPhongHop");
                    return it_r;
                }
            }
        }

        public static string sp_update_Thong_Tin_Nhan_Su(string userid, Obj_ThongTinNhanSu it)
        {

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_update_Thong_Tin_Nhan_Su", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("ttcn_Ma_Nhan_Vien", it.ttcn_Ma_Nhan_Vien));
                    cmd.Parameters.Add(new SqlParameter("ttcn_Ho_Ten", it.ttcn_Ho_Ten));
                    cmd.Parameters.Add(new SqlParameter("ttcn_Cong_Ty", it.ttcn_Cong_Ty));
                    cmd.Parameters.Add(new SqlParameter("ttcn_Khoi", it.ttcn_Khoi));
                    cmd.Parameters.Add(new SqlParameter("ttcn_Phong_Ban", it.ttcn_Phong_Ban));
                    cmd.Parameters.Add(new SqlParameter("ttcn_Bo_Phan", it.ttcn_Bo_Phan));
                    cmd.Parameters.Add(new SqlParameter("ttcv_Chuc_Danh_Hien_Tai", it.ttcv_Chuc_Danh_Hien_Tai));
                    cmd.Parameters.Add(new SqlParameter("ttcv_Ngay_Bo_Nhiem", it.ttcv_Ngay_Bo_Nhiem));
                    cmd.Parameters.Add(new SqlParameter("ttcv_Quyet_Dinh_Bo_Nhiem", it.ttcv_Quyet_Dinh_Bo_Nhiem));
                    cmd.Parameters.Add(new SqlParameter("ttcv_Che_Do_Lam_Viec", it.ttcv_Che_Do_Lam_Viec));
                    cmd.Parameters.Add(new SqlParameter("ttcv_Dia_Diem_Lam_Viec", it.ttcv_Dia_Diem_Lam_Viec));
                    cmd.Parameters.Add(new SqlParameter("ttlv_Tinh_Trang_Lam_Viec", it.ttlv_Tinh_Trang_Lam_Viec));
                    cmd.Parameters.Add(new SqlParameter("ttlv_Ngay_Vao_Cong_Ty", it.ttlv_Ngay_Vao_Cong_Ty));
                    cmd.Parameters.Add(new SqlParameter("ttlv_Loai_Hd_Hien_Tai", it.ttlv_Loai_Hd_Hien_Tai));
                    cmd.Parameters.Add(new SqlParameter("ttlv_Ngay_Het_Hd_Hien_Tai", it.ttlv_Ngay_Het_Hd_Hien_Tai));
                    cmd.Parameters.Add(new SqlParameter("ttlv_Ngay_Nghi_Thai_San", it.ttlv_Ngay_Nghi_Thai_San));
                    cmd.Parameters.Add(new SqlParameter("ttlv_Ngay_Di_Lam_Lai", it.ttlv_Ngay_Di_Lam_Lai));
                    cmd.Parameters.Add(new SqlParameter("ltv_Luong_P1", it.ltv_Luong_P1));
                    cmd.Parameters.Add(new SqlParameter("ltv_Luong_P2", it.ltv_Luong_P2));
                    cmd.Parameters.Add(new SqlParameter("ltv_Luong_P3", it.ltv_Luong_P3));
                    cmd.Parameters.Add(new SqlParameter("ltv_Phu_Cap_Xang_Xe", it.ltv_Phu_Cap_Xang_Xe));
                    cmd.Parameters.Add(new SqlParameter("ltv_Phu_Cap_Dien_Thoai", it.ltv_Phu_Cap_Dien_Thoai));
                    cmd.Parameters.Add(new SqlParameter("ltv_Phu_Cap_Khac", it.ltv_Phu_Cap_Khac));
                    cmd.Parameters.Add(new SqlParameter("lct_Luong_P1", it.lct_Luong_P1));
                    cmd.Parameters.Add(new SqlParameter("lct_Luong_Bhxh", it.lct_Luong_Bhxh));
                    cmd.Parameters.Add(new SqlParameter("lct_Luong_P2", it.lct_Luong_P2));
                    cmd.Parameters.Add(new SqlParameter("lct_Luong_P3", it.lct_Luong_P3));
                    cmd.Parameters.Add(new SqlParameter("lct_Phu_Cap_Xang_Xe", it.lct_Phu_Cap_Xang_Xe));
                    cmd.Parameters.Add(new SqlParameter("lct_Phu_Cap_Dien_Thoai", it.lct_Phu_Cap_Dien_Thoai));
                    cmd.Parameters.Add(new SqlParameter("lct_Phu_Cap_Khac", it.lct_Phu_Cap_Khac));
                    cmd.Parameters.Add(new SqlParameter("tdl_So_Quyet_Dinh", it.tdl_So_Quyet_Dinh));
                    cmd.Parameters.Add(new SqlParameter("tdl_Ngay_Thay_Doi", it.tdl_Ngay_Thay_Doi));
                    cmd.Parameters.Add(new SqlParameter("tdl_Ly_Do_Thay_Doi", it.tdl_Ly_Do_Thay_Doi));
                    cmd.Parameters.Add(new SqlParameter("tdl_Luong_P1_Moi", it.tdl_Luong_P1_Moi));
                    cmd.Parameters.Add(new SqlParameter("tdl_Luong_P2_Moi", it.tdl_Luong_P2_Moi));
                    cmd.Parameters.Add(new SqlParameter("tdl_Luong_P3_Moi", it.tdl_Luong_P3_Moi));
                    cmd.Parameters.Add(new SqlParameter("tdl_Phu_Cap_Xang_Xe", it.tdl_Phu_Cap_Xang_Xe));
                    cmd.Parameters.Add(new SqlParameter("tdl_Phu_Cap_Dien_Thoai", it.tdl_Phu_Cap_Dien_Thoai));
                    cmd.Parameters.Add(new SqlParameter("tdl_Phu_Cap_Khac", it.tdl_Phu_Cap_Khac));
                    cmd.Parameters.Add(new SqlParameter("tdct_So_Quyet_Dinh", it.tdct_So_Quyet_Dinh));
                    cmd.Parameters.Add(new SqlParameter("tdct_Ngay_Dieu_Chuyen", it.tdct_Ngay_Dieu_Chuyen));
                    cmd.Parameters.Add(new SqlParameter("tdct_Chuc_Danh_Cu", it.tdct_Chuc_Danh_Cu));
                    cmd.Parameters.Add(new SqlParameter("tdct_Phong_Ban_Cu", it.tdct_Phong_Ban_Cu));
                    cmd.Parameters.Add(new SqlParameter("tdct_Bo_Phan_Cu", it.tdct_Bo_Phan_Cu));
                    cmd.Parameters.Add(new SqlParameter("tdct_Chuc_Danh_Moi", it.tdct_Chuc_Danh_Moi));
                    cmd.Parameters.Add(new SqlParameter("tdct_Phong_Ban_Moi", it.tdct_Phong_Ban_Moi));
                    cmd.Parameters.Add(new SqlParameter("tdct_Bo_Phan_Moi", it.tdct_Bo_Phan_Moi));
                    cmd.Parameters.Add(new SqlParameter("tdct_Muc_Luong_Moi", it.tdct_Muc_Luong_Moi));
                    cmd.Parameters.Add(new SqlParameter("ltd_Tuyen_Moi", it.ltd_Tuyen_Moi));
                    cmd.Parameters.Add(new SqlParameter("ltd_Nghi_Quay_Lai", it.ltd_Nghi_Quay_Lai));
                    cmd.Parameters.Add(new SqlParameter("ltd_Thai_San_Lam_Lai", it.ltd_Thai_San_Lam_Lai));
                    cmd.Parameters.Add(new SqlParameter("td_Trinh_Do", it.td_Trinh_Do));
                    cmd.Parameters.Add(new SqlParameter("td_Chuyen_Nganh", it.td_Chuyen_Nganh));
                    cmd.Parameters.Add(new SqlParameter("td_Truong_Dao_Tao", it.td_Truong_Dao_Tao));
                    cmd.Parameters.Add(new SqlParameter("td_Nam_Tot_Nghiep", it.td_Nam_Tot_Nghiep));
                    cmd.Parameters.Add(new SqlParameter("cmnd_So_Cmnd_Cccd", it.cmnd_So_Cmnd_Cccd));
                    cmd.Parameters.Add(new SqlParameter("cmnd_Noi_Cap", it.cmnd_Noi_Cap));
                    cmd.Parameters.Add(new SqlParameter("cmnd_Ngay_Cap", it.cmnd_Ngay_Cap));
                    cmd.Parameters.Add(new SqlParameter("cmnd_Dia_Chi_Tam_Tru", it.cmnd_Dia_Chi_Tam_Tru));
                    cmd.Parameters.Add(new SqlParameter("cmnd_Dia_Chi_Thuong_Tru", it.cmnd_Dia_Chi_Thuong_Tru));
                    cmd.Parameters.Add(new SqlParameter("nlh_Ho_Ten", it.nlh_Ho_Ten));
                    cmd.Parameters.Add(new SqlParameter("nlh_So_Dien_Thoai", it.nlh_So_Dien_Thoai));
                    cmd.Parameters.Add(new SqlParameter("nlh_Email", it.nlh_Email));
                    cmd.Parameters.Add(new SqlParameter("Tinh_Trang_Hon_Nhan", it.Tinh_Trang_Hon_Nhan));
                    cmd.Parameters.Add(new SqlParameter("cc_Ho_Ten_Con_1", it.cc_Ho_Ten_Con_1));
                    cmd.Parameters.Add(new SqlParameter("cc_Ngay_Sinh1", it.cc_Ngay_Sinh1));
                    cmd.Parameters.Add(new SqlParameter("cc_Ho_Ten_Con_2", it.cc_Ho_Ten_Con_2));
                    cmd.Parameters.Add(new SqlParameter("cc_Ngay_Sinh2", it.cc_Ngay_Sinh2));
                    cmd.Parameters.Add(new SqlParameter("clhs_So_Yeu_Ly_Lich", it.clhs_So_Yeu_Ly_Lich));
                    cmd.Parameters.Add(new SqlParameter("clhs_Cmnd_Cccd", it.clhs_Cmnd_Cccd));
                    cmd.Parameters.Add(new SqlParameter("clhs_So_Ho_Khau", it.clhs_So_Ho_Khau));
                    cmd.Parameters.Add(new SqlParameter("clhs_Bang_Cap", it.clhs_Bang_Cap));
                    cmd.Parameters.Add(new SqlParameter("clhs_Giay_Kham_Suc_Khoe", it.clhs_Giay_Kham_Suc_Khoe));
                    cmd.Parameters.Add(new SqlParameter("clhs_Luu_Quyen_So", it.clhs_Luu_Quyen_So));
                    cmd.Parameters.Add(new SqlParameter("ttcl_So_Tai_Khoan_1", it.ttcl_So_Tai_Khoan_1));
                    cmd.Parameters.Add(new SqlParameter("ttcl_Ngan_Hang_1", it.ttcl_Ngan_Hang_1));
                    cmd.Parameters.Add(new SqlParameter("ttcl_So_Tai_Khoan_2", it.ttcl_So_Tai_Khoan_2));
                    cmd.Parameters.Add(new SqlParameter("ttcl_Ngan_Hang_2", it.ttcl_Ngan_Hang_2));
                    cmd.Parameters.Add(new SqlParameter("ttcl_So_Tai_Khoan_3", it.ttcl_So_Tai_Khoan_3));
                    cmd.Parameters.Add(new SqlParameter("ttcl_Ngan_Hang_3", it.ttcl_Ngan_Hang_3));
                    cmd.Parameters.Add(new SqlParameter("ttcl_Email_Chuyen_Luong", it.ttcl_Email_Chuyen_Luong));
                    cmd.Parameters.Add(new SqlParameter("ttcl_Ma_So_Thue_Tncn", it.ttcl_Ma_So_Thue_Tncn));
                    cmd.Parameters.Add(new SqlParameter("bhxh_So_So_Bhxh", it.bhxh_So_So_Bhxh));
                    cmd.Parameters.Add(new SqlParameter("bhxh_So_Nguoi_Phu_Thuoc", it.bhxh_So_Nguoi_Phu_Thuoc));
                    cmd.Parameters.Add(new SqlParameter("nv_Ngay_Nhan_Don", it.nv_Ngay_Nhan_Don));
                    cmd.Parameters.Add(new SqlParameter("nv_Nguon_Tiep_Nhan", it.nv_Nguon_Tiep_Nhan));
                    cmd.Parameters.Add(new SqlParameter("nv_Ly_Do_Nghi_Viec", it.nv_Ly_Do_Nghi_Viec));
                    cmd.Parameters.Add(new SqlParameter("nv_Tinh_Trang_Ban_Giao", it.nv_Tinh_Trang_Ban_Giao));
                    cmd.Parameters.Add(new SqlParameter("nv_Ngay_Ra_Qdnv", it.nv_Ngay_Ra_Qdnv));
                    cmd.Parameters.Add(new SqlParameter("clnv_Don_Xin_Nghi_Viec", it.clnv_Don_Xin_Nghi_Viec));
                    cmd.Parameters.Add(new SqlParameter("clnv_Quan_Ly_Xac_Nhan", it.clnv_Quan_Ly_Xac_Nhan));
                    cmd.Parameters.Add(new SqlParameter("clnv_Hanh_Chinh", it.clnv_Hanh_Chinh));
                    cmd.Parameters.Add(new SqlParameter("clnv_Ke_Toan", it.clnv_Ke_Toan));
                    cmd.Parameters.Add(new SqlParameter("clnv_Kiem_Soat_Noi_Bo", it.clnv_Kiem_Soat_Noi_Bo));
                    cmd.Parameters.Add(new SqlParameter("clnv_Cntt", it.clnv_Cntt));
                    cmd.Parameters.Add(new SqlParameter("clnv_Kiem_Ke", it.clnv_Kiem_Ke));

                    var reader = cmd.ExecuteScalar().ToString();
                    con.Close();
                    return reader;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_HRM_BookingRoom_getDSPhongHop");
                    return ex.Message;
                }
            }
        }
        #endregion

        #region Phân công công việc
        public static DataTable sp_getlist_Phancongcongviec(string userid)
        {
            DataSet ds = new DataSet();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_getlist_Phancongcongviec", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getlist_Phancongcongviec");
                    return ds.Tables[0];
                }
            }
        }

        public static DataTable sp_getlist_Motacongviec(string userid)
        {
            DataSet ds = new DataSet();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_getlist_Motacongviec", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getlist_Motacongviec");
                    return ds.Tables[0];
                }
            }
        }
        public static string sp_update_PhanCongCongViec(string userid, string MaNV, string MaCV, int Status)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_PhanCongCongViec", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("MaNV", MaNV));
                    cmd.Parameters.Add(new SqlParameter("MaCV", MaCV));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    string rs = cmd.ExecuteScalar().ToString();

                    con.Close();
                    return rs;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_update_PhanCongCongViec");
                return ex.Message;
            }
        }


        #endregion

        #region Khai báo công việc
        public static DataTable sp_getlist_Danhmuc_Congviec_Hanhdong(string userid, string Tenhanhdong)
        {
            DataSet ds = new DataSet();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_getlist_Danhmuc_Congviec_Hanhdong", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("Tenhanhdong", Tenhanhdong));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getlist_Danhmuc_Congviec_Hanhdong");
                    return ds.Tables[0];
                }
            }
        }

        public static string sp_insertupdate_Danhmuc_Congviec_Hanhdong(string userid, khaibaocongviechanhdong it)
        {

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_insertupdate_Danhmuc_Congviec_Hanhdong", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("ID", it.ID));
                    cmd.Parameters.Add(new SqlParameter("Tenhanhdong", it.Tenhanhdong));
                    cmd.Parameters.Add(new SqlParameter("TenCV", it.TenCV));
                    cmd.Parameters.Add(new SqlParameter("MaCV", it.MaCV));
                    cmd.Parameters.Add(new SqlParameter("MaChucdanh", it.MaChucdanh));
                    cmd.Parameters.Add(new SqlParameter("Chitieu1", it.Chitieu1));
                    cmd.Parameters.Add(new SqlParameter("Chitieu2", it.Chitieu2));
                    cmd.Parameters.Add(new SqlParameter("Chitieu3", it.Chitieu3));
                    cmd.Parameters.Add(new SqlParameter("Chitieu4", it.Chitieu4));
                    cmd.Parameters.Add(new SqlParameter("Chitieu5", it.Chitieu5));
                    cmd.Parameters.Add(new SqlParameter("Chitieu6", it.Chitieu6));
                    cmd.Parameters.Add(new SqlParameter("Chitieu7", it.Chitieu7));
                    cmd.Parameters.Add(new SqlParameter("Chitieu8", it.Chitieu8));
                    cmd.Parameters.Add(new SqlParameter("Chitieu9", it.Chitieu9));
                    cmd.Parameters.Add(new SqlParameter("Chitieu10", it.Chitieu10));
                    cmd.Parameters.Add(new SqlParameter("Tansuat", it.Tansuat));
                    cmd.Parameters.Add(new SqlParameter("Thoigian", it.Thoigian));
                    cmd.Parameters.Add(new SqlParameter("Tongthoigian", it.Tongthoigian));

                    string rs = cmd.ExecuteScalar().ToString();

                    con.Close();
                    return rs;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_insertupdate_Danhmuc_Congviec_Hanhdong");
                    return ex.Message;
                }
            }
        }

        #endregion
    }
}


