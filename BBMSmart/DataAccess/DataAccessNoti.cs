using Newtonsoft.Json;
using ProductAllTool.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProductAllTool.DataAccess
{
    public class DataAccessNoti
    {
        private static string strCon = ConfigurationManager.AppSettings.Get("strConn");

        public static string sp_createNoti (string userid, Notifyinfo it)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_createNoti", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("StartDate", it.StartDate));
                    cmd.Parameters.Add(new SqlParameter("Source", it.Source));
                    cmd.Parameters.Add(new SqlParameter("TargetType", it.TargetType));
                    cmd.Parameters.Add(new SqlParameter("Target", it.Target));
                    cmd.Parameters.Add(new SqlParameter("Title", it.Title));
                    cmd.Parameters.Add(new SqlParameter("Detail", it.Detail));
                    var result = (string)cmd.ExecuteScalar();

                    con.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_createNoti");
                    return ex.Message.ToString();
                }
            }
        }

        public static DataTable sp_getNotiManage(string userid, string FromDate, string ToDate, string Source, string TargetType,
                                           string Title, string Status)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_getNotiManage", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("FromDate", FromDate == "" ? null : FromDate));
                    cmd.Parameters.Add(new SqlParameter("ToDate", ToDate == "" ? null : ToDate));
                    cmd.Parameters.Add(new SqlParameter("Source", Source));
                    cmd.Parameters.Add(new SqlParameter("TargetType", TargetType));
                    cmd.Parameters.Add(new SqlParameter("Title", Title));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getNotiManage");
                return ds.Tables[0];
            }
        }

        public static DataTable sp_getNotiApr(string userid, string FromDate, string ToDate, string Source, string TargetType,
                                           string Title, string Detail)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_getNotiApr", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("FromDate", FromDate==""?null: FromDate));
                    cmd.Parameters.Add(new SqlParameter("ToDate", ToDate == "" ? null : ToDate));
                    cmd.Parameters.Add(new SqlParameter("Source", Source));
                    cmd.Parameters.Add(new SqlParameter("TargetType", TargetType));
                    cmd.Parameters.Add(new SqlParameter("Title", Title));
                    cmd.Parameters.Add(new SqlParameter("Detail", Detail));

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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getNotiApr");
                return ds.Tables[0];
            }
        }

        public static string sp_approveNoti(string userid, string lstID, string Status)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_approveNoti", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("ID", lstID));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    var result = (string)cmd.ExecuteScalar();

                    con.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_createNoti");
                    return ex.Message.ToString();
                }
            }
        }

        public static DataTable sp_getNoti(string userid, string FromDate, string ToDate,int notRead)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_getNoti", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("FromDate", FromDate == "" ? null : FromDate));
                    cmd.Parameters.Add(new SqlParameter("ToDate", ToDate == "" ? null : ToDate));
                    cmd.Parameters.Add(new SqlParameter("notRead", notRead));
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
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getNoti");
                return ds.Tables[0];
            }
        }

        public static List<Notifyinfo> sp_getNotiIndex(string userid)
        {
            List<Notifyinfo> it_r = new List<Notifyinfo>();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_getNoti", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("FromDate", null ));
                    cmd.Parameters.Add(new SqlParameter("ToDate", null ));
                    cmd.Parameters.Add(new SqlParameter("notRead", 1));
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Notifyinfo it = new Notifyinfo
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            Title = reader["Title"].ToString(),
                            Detail = reader["Detail"].ToString()
                        };

                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_getNotiIndex");
                return it_r;
            }
        }

        public static string sp_readNoti(string userid, int NotiID)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_readNoti", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("NotiID", NotiID));
                    var result = (string)cmd.ExecuteScalar();

                    con.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_readNoti");
                    return ex.Message.ToString();
                }
            }
        }
    }
}
