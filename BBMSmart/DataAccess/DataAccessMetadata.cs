using Newtonsoft.Json;
using ProductAllTool.Models.SourceProduct;
using ProductAllTool.Models.ManageSales;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ProductAllTool.Models.Approve;
using ProductAllTool.Common;
using ProductAllTool.Models.Thongtindoithu;

namespace ProductAllTool.DataAccess
{
    public class DataAccessMetadata
    {
        private static string strCon = ConfigurationManager.AppSettings.Get("strConn");
        private static string strConn1101 = ConfigurationManager.AppSettings.Get("strConn1.101");
        private static string strConnDWH = ConfigurationManager.AppSettings.Get("strConnDWH");

        public static List<objCombox> sp_po_getTansuatRR()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_po_getTansuatRR", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_po_getTansuatRR");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_filter_getsalestype()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_getsalestype", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_getsalestype");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_bbs_filter_getchucdanh()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_getchucdanh", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_getchucdanh");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_filter_getcusrank()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_getcusrank", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_getcusrank");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_filter_getTuoiFinal()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_getTuoiFinal", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_getTuoiFinal");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_filter_getfrequency()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_getfrequency", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_getfrequency");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_bbs_getallVendor()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getallVendor", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getallVendor");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_filter_getCH_OfflineApr()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_getCH_OfflineApr", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_getCH_OfflineApr");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_bbs_getallFunction()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getallFunction", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getallFunction");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_getFunction_noCCDC()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getFunction_noCCDC", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getFunction_noCCDC");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_Competeoffline_NCC()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_Competeoffline_NCC", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_Competeoffline_NCC");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_getBrand_NCC()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getBrand_NCC", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getBrand_NCC");
                    return it_r;
                }
            }
        }

        public static List<brandnccfunction> sp_bbs_getBrand_NCC_function()
        {
            List<brandnccfunction> it_r = new List<brandnccfunction>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getBrand_NCC_function", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        brandnccfunction it = new brandnccfunction
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            Functioncode = reader["Functioncode"].ToString(),
                            Functionname = reader["Functionname"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getBrand_NCC_function");
                    return it_r;
                }
            }
        }

        public static List<filtercusomerloyalty> sp_bbs_getfilter_CustomerLoyalty(string userid)
        {
            List<filtercusomerloyalty> it_r = new List<filtercusomerloyalty>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getfilter_CustomerLoyalty", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        filtercusomerloyalty it = new filtercusomerloyalty
                        {
                            MaNhomKH = reader["MaNhomKH"].ToString(),
                            NhomKH = reader["NhomKH"].ToString(),
                            MaTinh = reader["MaTinh"].ToString(),
                            TenTinh = reader["TenTinh"].ToString(),
                            MaCH = reader["MaCH"].ToString(),
                            TenCH = reader["TenCH"].ToString(),
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getfilter_CustomerLoyalty");
                    return it_r;
                }
            }
        }

        public static List<filteroosstore> sp_bbs_getfilter_oosstore(string userid)
        {
            List<filteroosstore> it_r = new List<filteroosstore>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getfilter_oosstore", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        filteroosstore it = new filteroosstore
                        {
                            BrandCode = reader["BrandCode"].ToString(),
                            BrandName = reader["BrandName"].ToString(),
                            MaTinh = reader["MaTinh"].ToString(),
                            TenTinh = reader["TenTinh"].ToString(),
                            MaCH = reader["MaCH"].ToString(),
                            TenCH = reader["TenCH"].ToString(),
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString(),
                            MaNcc = reader["MaNcc"].ToString(),
                            TenNCC = reader["TenNCC"].ToString(),
                            Mien = reader["Mien"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getfilter_oosstore");
                    return it_r;
                }
            }
        }
        public static List<filteroosstore> sp_bbs_getfilter_oos(string userid)
        {
            List<filteroosstore> it_r = new List<filteroosstore>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getfilter_oos", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        filteroosstore it = new filteroosstore
                        {
                            BrandCode = reader["BrandCode"].ToString(),
                            BrandName = reader["BrandName"].ToString(),
                            MaTinh = reader["MaTinh"].ToString(),
                            TenTinh = reader["TenTinh"].ToString(),
                            MaCH = reader["MaCH"].ToString(),
                            TenCH = reader["TenCH"].ToString(),
                            MaHang = reader["MaHang"].ToString(),
                            TenHang = reader["TenHang"].ToString(),
                            MaNcc = reader["MaNcc"].ToString(),
                            TenNCC = reader["TenNCC"].ToString(),
                            Mien = reader["Mien"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getfilter_oos");
                    return it_r;
                }
            }
        }

        public static List<filter_pushsale> sp_bbs_getfilter_pushsale()
        {
            List<filter_pushsale> it_r = new List<filter_pushsale>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getfilter_pushsale", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        filter_pushsale it = new filter_pushsale
                        {
                            CategoryCode = reader["Catcode"].ToString(),
                            CategoryName = reader["Catname"].ToString(),
                            FunctionCode = reader["Funccode"].ToString(),
                            FunctionName = reader["Funcname"].ToString(),
                            BrandCode = reader["Brandcode"].ToString(),
                            BrandName = reader["Brandname"].ToString(),
                            StoreNo = reader["StoreNo"].ToString(),
                            StoreName = reader["StoreName"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getfilter_pushsale");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_getBrand_NCC_RR()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getBrand_NCC_RR", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getBrand_NCC_RR");
                    return it_r;
                }
            }
        }
        public static List<filterRR> sp_bbs_getfilter_DPGP()
        {
            List<filterRR> it_r = new List<filterRR>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getfilter_DPGP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        filterRR it = new filterRR
                        {
                            Brandncc = reader["Brandncc"].ToString(),
                            Nguonnhap = reader["Nguonnhap"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),
                            DivCode = reader["DivCode"].ToString(),
                            DivName = reader["DivName"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getfilter_DPGP");
                    return it_r;
                }
            }
        }

        public static List<filterRR> sp_bbs_getfilter_TraNCC()
        {
            List<filterRR> it_r = new List<filterRR>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getfilter_TraNCC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        filterRR it = new filterRR
                        {
                            Brandncc = reader["Brandncc"].ToString(),
                            Nguonnhap = reader["Nguonnhap"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),
                            DivCode = reader["DivCode"].ToString(),
                            DivName = reader["DivName"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getfilter_TraNCC");
                    return it_r;
                }
            }
        }

        public static List<filterRR> sp_bbs_getfilter_RR()
        {
            List<filterRR> it_r = new List<filterRR>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getfilter_RR", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        filterRR it = new filterRR
                        {
                            Brandncc = reader["Brandncc"].ToString(),
                            Nguonnhap = reader["Nguonnhap"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),
                            DivCode = reader["DivCode"].ToString(),
                            DivName = reader["DivName"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getfilter_RR");
                    return it_r;
                }
            }
        }

        public static List<filterRO> sp_bbs_getfilter_RO()
        {
            List<filterRO> it_r = new List<filterRO>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getfilter_RO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        filterRO it = new filterRO
                        {
                            Brandncc = reader["Brandncc"].ToString(),
                            CatCode = reader["CatCode"].ToString(),
                            CatName = reader["CatName"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),
                            GroupCode = reader["GroupCode"].ToString(),
                            GroupName = reader["GroupName"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getfilter_RO");
                    return it_r;
                }
            }
        }

        public static List<itemks> sp_bbs_GetList_Item4ks()
        {
            List<itemks> it_r = new List<itemks>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_GetList_Item4ks", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        itemks it = new itemks
                        {
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            GBLALL = decimal.Parse(reader["GBLALL"].ToString())
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_GetList_Item4ks");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_bbs_getLeadType()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getLeadType", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getLeadType");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_bbs_getDoiThu()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getDoiThu", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getDoiThu");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_getDoiThuONL()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getDoiThuONL", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getDoiThuONL");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_bbs_geteLaderGroup()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_geteaderGroup", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_geteaderGroup");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_getThuNhap()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getThuNhap", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getThuNhap");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_getChienDich()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getChienDich", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getChienDich");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_bbs_getBrand_NCC_GiabanOnline()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getBrand_NCC_GiabanOnline", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getBrand_NCC_GiabanOnline");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_getNhomChienGia()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getNhomChienGia", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getNhomChienGia");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_getallKieuNhapKhau()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getallKieuNhapKhau", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getallKieuNhapKhau");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_bbs_Competeoffline_brand()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_Competeoffline_brand", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_Competeoffline_brand");
                    return it_r;
                }
            }
        }

        public static List<DivCatGroupFunc> sp_bbs_DivCatGroupFunc(string uid)
        {
            List<DivCatGroupFunc> it_r = new List<DivCatGroupFunc>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_DivCatGroupFunc", con);
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

        public static List<NNDivFunc> sp_bbs_filter_NAR_getNNDivFunc(string uid)
        {
            List<NNDivFunc> it_r = new List<NNDivFunc>();


            using (var con = new SqlConnection(strCon))
            {
                con.Open();

                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_NAR_getNNDivFunc", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("userid", uid));

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        NNDivFunc it = new NNDivFunc
                        {
                            DivisionCode = reader["DivisionCode"].ToString(),
                            DivisionName = reader["DivisionName"].ToString(),
                            FunctionCode = reader["FunctionCode"].ToString(),
                            FunctionName = reader["FunctionName"].ToString(),
                            NguonNhap = reader["NguonNhap"].ToString(),
                            MaNCC = reader["MaNCC"].ToString(),
                            TenNCC = reader["TenNCC"].ToString(),
                        };

                        it_r.Add(it);
                    }
                    con.Close();

                    return it_r;

                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_NAR_getNNDivFunc");
                    return it_r;
                }
            }

        }

        public static List<Cuahang_Tinh> sp_bbs_getlistCH_Tinh(string uid)
        {
            List<Cuahang_Tinh> it_r = new List<Cuahang_Tinh>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getlistCH_Tinh", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", uid));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Cuahang_Tinh it = new Cuahang_Tinh
                        {
                            Matinh = reader["Matinh"].ToString(),
                            TenTinh = reader["TenTinh"].ToString(),
                            MaCuahang = reader["MaCuahang"].ToString(),
                            TenCuahang = reader["TenCuahang"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getlistCH_Tinh");
                    return it_r;
                }
            }
        }

        public static List<Cuahang_Tinh> sp_bbs_filter_MienTinhCH(string uid)
        {
            List<Cuahang_Tinh> it_r = new List<Cuahang_Tinh>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_MienTinhCH", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", uid));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Cuahang_Tinh it = new Cuahang_Tinh
                        {
                            MaMien = reader["MaMien"].ToString(),
                            TenMien = reader["TenMien"].ToString(),
                            Matinh = reader["Matinh"].ToString(),
                            TenTinh = reader["TenTinh"].ToString(),
                            MaCuahang = reader["MaCuahang"].ToString(),
                            TenCuahang = reader["TenCuahang"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getlistCH_Tinh");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_filter_OFFLINE_getItem()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_OFFLINE_getItem", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_OFFLINE_getItem");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_bbs_filter_HQOFFLINE_getItem()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_HQOFFLINE_getItem", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_HQOFFLINE_getItem");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_bbs_filter_getallBrand()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_getallBrand", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_getallBrand");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_filter_getallVendor()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_getallVendor", con);//
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_getallVendor");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_GetListInventoryNcc_Vendor_filter()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetListInventoryNcc_Vendor_filter", con);//sp_bbs_filter_getallVendor
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_getallVendor");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_bbs_filter_getLCbyUser(string userid)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_getLCbyUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_getLCbyUser");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_filter_getphuongthuckhaosat()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_getphuongthuckhaosat", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_getphuongthuckhaosat");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_bbs_filter_getloaikm()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_getloaikm", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_getloaikm");
                    return it_r;
                }
            }
        }

        public static List<brfn> sp_bbs_filter_getbrandfunctionkhaosat(string userid)
        {
            List<brfn> it_r = new List<brfn>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_getbrandfunctionkhaosat", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        brfn it = new brfn
                        {
                            brand_code = reader["brand_code"].ToString(),
                            brand_name = reader["brand_name"].ToString(),
                            function_code = reader["function_code"].ToString(),
                            function_name = reader["function_name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_getbrandfunctionkhaosat");
                    return it_r;
                }
            }
        }

        public static List<brfn> sp_bbs_filter_getbrandfunctionTDH(string userid)
        {
            List<brfn> it_r = new List<brfn>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_getbrandfunctionTDH", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        brfn it = new brfn
                        {
                            brand_code = reader["BrandCode"].ToString(),
                            brand_name = reader["BrandName"].ToString(),
                            function_code = reader["FunctionCode"].ToString(),
                            function_name = reader["FunctionName"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_getbrandfunctionTDH");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_filter_getfunctionkhaosat(string userid)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_getfunctionkhaosat", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_getfunctionkhaosat");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_filter_getbrandkhaosat(string userid)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_getbrandkhaosat", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_getbrandkhaosat");
                    return it_r;
                }
            }
        }


        //be nguyen tu KPI sang :(


        public class storeItem
        {
            public string no { set; get; }
            public string name { set; get; }
        }

        public class staffItem
        {
            public string no { set; get; }
            public string name { set; get; }
        }

        public class productItem
        {
            public string no { set; get; }
            public string name { set; get; }
        }


        public class TypeConformItem
        {
            public string no { set; get; }
            public string name { set; get; }
        }

        public class TypeDiscountItem
        {
            public string no { set; get; }
            public string name { set; get; }
        }
        public class BrandInfo
        {
            public string Brand_Code { get; set; }
            public string Brand_Name { get; set; }
        }
        public class ReportItem
        {
            public string id { set; get; }
            public string bbm_no { set; get; }
            public string bbm_name { set; get; }
            public string staff_no { set; get; }
            public string staff_name { set; get; }
            public string item_no { set; get; }
            public string item_name { set; get; }
            public string competitor_no { set; get; }
            public string competitor_name { set; get; }
            public string competitorStore_no { set; get; }
            public string competitorStore_name { set; get; }
            public string competitorPrice { set; get; }
            public string typeDiscount { set; get; }
            public string typeComform { set; get; }
            public string description { set; get; }
            public string dateReport { set; get; }
            public string createdDate { set; get; }
            public string modifyDate { set; get; }
            public int action { set; get; }
            public string soluong { set; get; }
            public string tongthuong { set; get; }
            public string cusname { set; get; }
            public string cusphone { set; get; }
        }
        public class competitorItem
        {
            public string bbm_no { set; get; }
            public string bbm_name { set; get; }
            public string competitor_no { set; get; }
            public string competitor_name { set; get; }
            public string competitorStore_no { set; get; }
            public string competitorStore_name { set; get; }
            public string competitorStore_address { set; get; }

        }
        public class competitorInfo
        {
            public string code { set; get; }
            public string Name { set; get; }
            public string Brand_Code { set; get; }
            public string Brand_Name { set; get; }
        }


        #region LCManage
        public static List<objCombox> SP_BBM_DoiThu_Store_get()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBM_DoiThu_Store_get", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_DoiThu_Store_get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_BBM_DoiThu_MoHinhKinhDoanh_get()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBM_DoiThu_MoHinhKinhDoanh_get", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_DoiThu_MoHinhKinhDoanh_get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_BBM_DoiThu_DanhSachDoiThu_get()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBM_DoiThu_DanhSachDoiThu_get", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_DoiThu_DanhSachDoiThu_get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_BBM_DoiThu_VS_ASM_get()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBM_DoiThu_VS_ASM_get", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_DoiThu_VS_ASM_get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> SP_BBM_DoiThu_Tinh_Get()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBM_DoiThu_Tinh_Get", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_DoiThu_Tinh_Get");
                    return it_r;
                }
            }
        }
        public static List<objCombox> getCuaHangBBM_ASM(string StoreCode)
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("getCuaHangBBM_ASM", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("StoreCode", StoreCode));

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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getCuaHangBBM_ASM");
                    return it_r;
                }
            }
        }
        public class ASM_Store
        {
            public string ASMName { get; set; }
            public string ASMCode { get; set; }
            public string StoreName { get; set; }
            public string StoreCode { get; set; }
        }
        public static List<ASM_Store> getCuaHangBBM_ASMFull()
        {
            List<ASM_Store> it_r = new List<ASM_Store>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("getCuaHangBBM_ASMFull", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ASM_Store it = new ASM_Store
                        {
                            ASMCode = reader["ASMCode"].ToString(),
                            ASMName = reader["ASMName"].ToString(),
                            StoreCode = reader["StoreCode"].ToString(),
                            StoreName = reader["StoreName"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getCuaHangBBM_ASMFull");
                    return it_r;
                }
            }
        }
        public static bool createupdate_thongtindoithu(string userid, Thongtindoithu info)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_bbs_createupdate_thongtindoithu", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("ID", info.ID));
                    cmd.Parameters.Add(new SqlParameter("Cuahang_BBM_Code", info.Cuahang_BBM_Code));
                    cmd.Parameters.Add(new SqlParameter("Cuahang_BBM_Name", info.Cuahang_BBM_Name));
                    cmd.Parameters.Add(new SqlParameter("Mohinh_doithu_Code", info.Mohinh_doithu_Code));
                    cmd.Parameters.Add(new SqlParameter("Mohinh_doithu_Name", info.Mohinh_doithu_Name));
                    cmd.Parameters.Add(new SqlParameter("Ten_doithu_Code", info.Ten_doithu_Code));
                    cmd.Parameters.Add(new SqlParameter("Ten_doithu_Name", info.Ten_doithu_Name));
                    cmd.Parameters.Add(new SqlParameter("CH_doithu", info.CH_doithu));
                    cmd.Parameters.Add(new SqlParameter("Phuong_Xa_Code", info.Phuong_Xa_Code));
                    cmd.Parameters.Add(new SqlParameter("Quan_Huyen_Code", info.Quan_Huyen_Code));
                    cmd.Parameters.Add(new SqlParameter("Tinh_Thanhpho_Code", info.Tinh_Thanhpho_Code));
                    cmd.Parameters.Add(new SqlParameter("Phuong_Xa_Name", info.Phuong_Xa_Name));
                    cmd.Parameters.Add(new SqlParameter("Quan_Huyen_Name", info.Quan_Huyen_Name));
                    cmd.Parameters.Add(new SqlParameter("Tinh_Thanhpho_Name", info.Tinh_Thanhpho_Name));
                    cmd.Parameters.Add(new SqlParameter("Thutu_canhtranh", info.Thutu_canhtranh));
                    cmd.Parameters.Add(new SqlParameter("Lydo_sapxep", info.Lydo_sapxep));
                    cmd.Parameters.Add(new SqlParameter("Khoangcach", info.Khoangcach != null ? info.Khoangcach : "0"));
                    cmd.Parameters.Add(new SqlParameter("Chieurong", info.Chieurong != null ? info.Chieurong : "0"));

                    cmd.Parameters.Add(new SqlParameter("ASM_Code", info.ASM_Code));
                    cmd.Parameters.Add(new SqlParameter("ASM_Name", info.ASM_Name));

                    cmd.Parameters.Add(new SqlParameter("Dientich_KD", info.Dientich_KD != null ? info.Dientich_KD : "0"));
                    cmd.Parameters.Add(new SqlParameter("Sotang_KD", info.Sotang_KD != null ? info.Sotang_KD : "0"));
                    cmd.Parameters.Add(new SqlParameter("DS_dukien", info.DS_dukien));
                    cmd.Parameters.Add(new SqlParameter("Chinhsach_CSKH", info.Chinhsach_CSKH));
                    cmd.Parameters.Add(new SqlParameter("Danhgia_DVKH", info.Danhgia_DVKH));
                    cmd.Parameters.Add(new SqlParameter("Lydo_DVKH", info.Lydo_DVKH));
                    cmd.Parameters.Add(new SqlParameter("Danhgia_Trainghiem", info.Danhgia_Trainghiem));
                    cmd.Parameters.Add(new SqlParameter("Lydo_Trainghiem", info.Lydo_Trainghiem));
                    cmd.Parameters.Add(new SqlParameter("Danhgia_Hanghoa", info.Danhgia_Hanghoa));
                    cmd.Parameters.Add(new SqlParameter("Lydo_Hanghoa", info.Lydo_Hanghoa));
                    cmd.Parameters.Add(new SqlParameter("Anh1", info.Anh1));
                    cmd.Parameters.Add(new SqlParameter("Anh2", info.Anh2));
                    cmd.Parameters.Add(new SqlParameter("Anh3", info.Anh3));
                    cmd.Parameters.Add(new SqlParameter("Anh4", info.Anh4));
                    cmd.Parameters.Add(new SqlParameter("Anh5", info.Anh5));
                    cmd.Parameters.Add(new SqlParameter("Anh6", info.Anh6));
                    cmd.Parameters.Add(new SqlParameter("Anh7", info.Anh7));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_createupdate_thongtindoithu");
                    return false;
                }
            }
        }
        public static DataTable Get_thongtindoithu(string userid, string mien, string tinh, string quan, string cuahang, string doithu)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_get_thongtindoithu", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("mien", mien));
                    cmd.Parameters.Add(new SqlParameter("tinh", tinh));
                    cmd.Parameters.Add(new SqlParameter("quan", quan));
                    cmd.Parameters.Add(new SqlParameter("cuahang", cuahang));
                    cmd.Parameters.Add(new SqlParameter("doithu", doithu));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_get_thongtindoithu");
                return ds.Tables[0];
            }
        }
        public static bool Update_Status_Thongtindoithu(string ID, string HanhDong)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_Status_Thongtindoithu", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_Thongtindoithu");
                    return false;
                }
            }
        }
        public static DataTable get_TrangThai_DoiThu(string ID)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("get_TrangThai_DoiThu", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "get_TrangThai_DoiThu");
                return ds.Tables[0];
            }
        }
        public static Thongtindoithu Listget_DoiThu(string ID)
        {
            Thongtindoithu itr = new Thongtindoithu();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_get_DoiThu_ID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Thongtindoithu it = new Thongtindoithu
                        {
                            ID = reader["ID"].ToString(),
                            Cuahang_BBM_Code = reader["Cuahang_BBM_Code"].ToString(),
                            Cuahang_BBM_Name = reader["Cuahang_BBM_Name"].ToString(),
                            Mohinh_doithu_Code = reader["Mohinh_doithu_Code"].ToString(),
                            Mohinh_doithu_Name = reader["Mohinh_doithu_Name"].ToString(),
                            Ten_doithu_Code = reader["Ten_doithu_Code"].ToString(),
                            Ten_doithu_Name = reader["Ten_doithu_Name"].ToString(),
                            CH_doithu = reader["CH_doithu"].ToString(),
                            Phuong_Xa_Code = reader["Phuong_Xa_Code"].ToString(),
                            Quan_Huyen_Code = reader["Quan_Huyen_Code"].ToString(),
                            Tinh_Thanhpho_Code = reader["Tinh_Thanhpho_Code"].ToString(),
                            Phuong_Xa_Name = reader["Phuong_Xa_Name"].ToString(),
                            Quan_Huyen_Name = reader["Quan_Huyen_Name"].ToString(),
                            Tinh_Thanhpho_Name = reader["Tinh_Thanhpho_Name"].ToString(),
                            Thutu_canhtranh = reader["Thutu_canhtranh"].ToString(),
                            Lydo_sapxep = reader["Lydo_sapxep"].ToString(),
                            Khoangcach = reader["Khoangcach"].ToString(),
                            Chieurong = reader["Chieurong"].ToString(),
                            ASM_Code = reader["ASM_Code"].ToString(),
                            ASM_Name = reader["ASM_Name"].ToString(),
                            Dientich_KD = reader["Dientich_KD"].ToString(),
                            Sotang_KD = reader["Sotang_KD"].ToString(),
                            DS_dukien = reader["DS_dukien"].ToString(),
                            Chinhsach_CSKH = reader["Chinhsach_CSKH"].ToString(),
                            Danhgia_DVKH = reader["Danhgia_DVKH"].ToString(),
                            Lydo_DVKH = reader["Lydo_DVKH"].ToString(),
                            Danhgia_Trainghiem = reader["Danhgia_Trainghiem"].ToString(),
                            Lydo_Trainghiem = reader["Lydo_Trainghiem"].ToString(),
                            Danhgia_Hanghoa = reader["Danhgia_Hanghoa"].ToString(),
                            Lydo_Hanghoa = reader["Lydo_Hanghoa"].ToString(),
                            Anh1 = reader["Anh1"].ToString(),
                            Anh2 = reader["Anh2"].ToString(),
                            Anh3 = reader["Anh3"].ToString(),
                            Anh4 = reader["Anh4"].ToString(),
                            Anh5 = reader["Anh5"].ToString(),
                            Anh6 = reader["Anh6"].ToString(),
                            Anh7 = reader["Anh7"].ToString(),
                            Status = reader["Status"].ToString(),

                        };
                        itr = it;
                    }
                    con.Close();
                    return itr;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_get_DoiThu_ID");
                    return itr;
                }
            }
        }
        #endregion

        public static List<asmrsmstore> sp_bbs_filter_get_RSM_ASM_Store(string userid)
        {
            List<asmrsmstore> it_r = new List<asmrsmstore>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_get_RSM_ASM_Store", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        asmrsmstore it = new asmrsmstore
                        {
                            RSM_Code = reader["RSM_Code"].ToString(),
                            RSM_Name = reader["RSM_Name"].ToString(),
                            ASM_Code = reader["ASM_Code"].ToString(),
                            ASM_Name = reader["ASM_Name"].ToString(),
                            Store_Code = reader["Store_Code"].ToString(),
                            Store_Name = reader["Store_Name"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_get_RSM_ASM_Store");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_filter_getloaike()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_getloaike", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_getloaike");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_filter_getHangMuc_CLVH()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_getHangMuc_CLVH", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_getHangMuc_CLVH");
                    return it_r;
                }
            }
        }

        #region LPartner

        public static DataTable Get_thongtinpartner(string userid, string DoiTac, string TrangThai)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_bbs_get_thongtinDoiTac", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("DoiTac  ", DoiTac));
                    cmd.Parameters.Add(new SqlParameter("TrangThai", TrangThai));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Get_thongtinpartner");
                return ds.Tables[0];
            }
        }

        public static ThongtinDoitac Listget_DoiTac(string ID)
        {
            ThongtinDoitac itr = new ThongtinDoitac();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_get_DoiTac_ID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ThongtinDoitac it = new ThongtinDoitac
                        {
                            ID = reader["ID"].ToString(),
                            Mohinh_DoiTac_Code = reader["Mohinh_DoiTac_Code"].ToString(),
                            Mohinh_DoiTac_Name = reader["Mohinh_DoiTac_Name"].ToString(),
                            Ten_DoiTac_Name = reader["Ten_DoiTac_Name"].ToString(),
                            MienCode = reader["MienCode"].ToString(),
                            MienName = reader["MienName"].ToString(),
                            Phuong_Xa_Code = reader["Phuong_Xa_Code"].ToString(),
                            Quan_Huyen_Code = reader["Quan_Huyen_Code"].ToString(),
                            Tinh_Thanhpho_Code = reader["Tinh_Thanhpho_Code"].ToString(),
                            Phuong_Xa_Name = reader["Phuong_Xa_Name"].ToString(),
                            Quan_Huyen_Name = reader["Quan_Huyen_Name"].ToString(),
                            Tinh_Thanhpho_Name = reader["Tinh_Thanhpho_Name"].ToString(),
                            DiaChiCuThe = reader["DiaChiCuThe"].ToString(),
                            QuyMo = reader["QuyMo"].ToString(),
                            DoanhSoThang = reader["DoanhSoThang"].ToString(),
                            SoLuongNhanSu = reader["SoLuongNhanSu"].ToString(),
                            DivisionCode = reader["DivisionCode"].ToString(),
                            DivisionName = reader["DivisionName"].ToString(),
                            BrandCode = reader["BrandCode"].ToString(),
                            BrandName = reader["BrandName"].ToString(),
                            ProductCode = reader["ProductCode"].ToString(),
                            ProductName = reader["ProductName"].ToString(),
                            NguoiLienHe = reader["NguoiLienHe"].ToString(),
                            DienThoaiLienHe = reader["DienThoaiLienHe"].ToString(),
                            FileUpLoad = reader["FileUpLoad"].ToString(),
                            Status = reader["Status"].ToString()
                        };
                        itr = it;
                    }
                    con.Close();
                    return itr;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Listget_DoiTac");
                    return itr;
                }
            }
        }
        public static bool createupdate_thongtinDoiTac(string userid, ThongtinDoitac info)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_createupdate_thongtinDoitac", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("ID", info.ID));
                    cmd.Parameters.Add(new SqlParameter("Mohinh_DoiTac_Code", info.Mohinh_DoiTac_Code));
                    cmd.Parameters.Add(new SqlParameter("Mohinh_DoiTac_Name", info.Mohinh_DoiTac_Name));
                    cmd.Parameters.Add(new SqlParameter("Ten_DoiTac_Name", info.Ten_DoiTac_Name));
                    cmd.Parameters.Add(new SqlParameter("MienCode", info.MienCode));
                    cmd.Parameters.Add(new SqlParameter("MienName", info.MienName));
                    cmd.Parameters.Add(new SqlParameter("Phuong_Xa_Code", info.Phuong_Xa_Code));
                    cmd.Parameters.Add(new SqlParameter("Quan_Huyen_Code", info.Quan_Huyen_Code));
                    cmd.Parameters.Add(new SqlParameter("Tinh_Thanhpho_Code", info.Tinh_Thanhpho_Code));
                    cmd.Parameters.Add(new SqlParameter("Phuong_Xa_Name", info.Phuong_Xa_Name));
                    cmd.Parameters.Add(new SqlParameter("Quan_Huyen_Name", info.Quan_Huyen_Name));
                    cmd.Parameters.Add(new SqlParameter("Tinh_Thanhpho_Name", info.Tinh_Thanhpho_Name));
                    cmd.Parameters.Add(new SqlParameter("DiaChiCuThe", info.DiaChiCuThe));
                    cmd.Parameters.Add(new SqlParameter("QuyMo", Decimal.Parse(info.QuyMo != null ? info.QuyMo.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("DoanhSoThang", Decimal.Parse(info.DoanhSoThang != null ? info.DoanhSoThang.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("SoLuongNhanSu", Decimal.Parse(info.SoLuongNhanSu != null ? info.SoLuongNhanSu.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("DivisionCode", info.DivisionCode));
                    cmd.Parameters.Add(new SqlParameter("DivisionName", info.DivisionName));
                    cmd.Parameters.Add(new SqlParameter("BrandCode", info.BrandCode));
                    cmd.Parameters.Add(new SqlParameter("BrandName", info.BrandName));
                    cmd.Parameters.Add(new SqlParameter("ProductCode", info.ProductCode));
                    cmd.Parameters.Add(new SqlParameter("ProductName", info.ProductName));
                    cmd.Parameters.Add(new SqlParameter("NguoiLienHe", info.NguoiLienHe));
                    cmd.Parameters.Add(new SqlParameter("DienThoaiLienHe", info.DienThoaiLienHe));
                    cmd.Parameters.Add(new SqlParameter("FileUpLoad", info.FileUpLoad != null ? info.FileUpLoad : ""));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "createupdate_thongtinDoiTac");
                    return false;
                }
            }
        }
        public static bool createupdate_thongtinDoiTacExel(string userid, ThongtinDoitac info)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_createupdate_thongtinDoitac", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    cmd.Parameters.Add(new SqlParameter("ID", info.ID));
                    cmd.Parameters.Add(new SqlParameter("Mohinh_DoiTac_Code", info.Mohinh_DoiTac_Code));
                    cmd.Parameters.Add(new SqlParameter("Mohinh_DoiTac_Name", info.Mohinh_DoiTac_Name));
                    cmd.Parameters.Add(new SqlParameter("Ten_DoiTac_Name", info.Ten_DoiTac_Name));
                    cmd.Parameters.Add(new SqlParameter("MienCode", info.MienCode));
                    cmd.Parameters.Add(new SqlParameter("MienName", info.MienName));
                    cmd.Parameters.Add(new SqlParameter("Phuong_Xa_Code", info.Phuong_Xa_Code));
                    cmd.Parameters.Add(new SqlParameter("Quan_Huyen_Code", info.Quan_Huyen_Code));
                    cmd.Parameters.Add(new SqlParameter("Tinh_Thanhpho_Code", info.Tinh_Thanhpho_Code));
                    cmd.Parameters.Add(new SqlParameter("Phuong_Xa_Name", info.Phuong_Xa_Name));
                    cmd.Parameters.Add(new SqlParameter("Quan_Huyen_Name", info.Quan_Huyen_Name));
                    cmd.Parameters.Add(new SqlParameter("Tinh_Thanhpho_Name", info.Tinh_Thanhpho_Name));
                    cmd.Parameters.Add(new SqlParameter("DiaChiCuThe", info.DiaChiCuThe));
                    cmd.Parameters.Add(new SqlParameter("QuyMo", Decimal.Parse(info.QuyMo != "" ? info.QuyMo.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("DoanhSoThang", Decimal.Parse(info.DoanhSoThang != "" ? info.DoanhSoThang.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("SoLuongNhanSu", Decimal.Parse(info.SoLuongNhanSu != "" ? info.SoLuongNhanSu.Replace(",", "") : "0")));
                    cmd.Parameters.Add(new SqlParameter("DivisionCode", info.DivisionCode));
                    cmd.Parameters.Add(new SqlParameter("DivisionName", info.DivisionName));
                    cmd.Parameters.Add(new SqlParameter("BrandCode", info.BrandCode));
                    cmd.Parameters.Add(new SqlParameter("BrandName", info.BrandName));
                    cmd.Parameters.Add(new SqlParameter("ProductCode", info.ProductCode));
                    cmd.Parameters.Add(new SqlParameter("ProductName", info.ProductName));
                    cmd.Parameters.Add(new SqlParameter("NguoiLienHe", info.NguoiLienHe));
                    cmd.Parameters.Add(new SqlParameter("DienThoaiLienHe", info.DienThoaiLienHe));
                    cmd.Parameters.Add(new SqlParameter("FileUpLoad", info.FileUpLoad != null ? info.FileUpLoad : ""));

                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "createupdate_thongtinDoiTac");
                    return false;
                }
            }
        }
        public static DataTable get_TrangThai_DoiTac(string ID)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("get_TrangThai_DoiTac", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30000;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    { sda.Fill(ds); }

                    con.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "get_TrangThai_DoiTac");
                return ds.Tables[0];
            }
        }

        public static List<objCombox> SP_BBM_DoiTac_Fillter_get()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BBM_DoiTac_Fillter_get", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_DoiTac_Fillter_get");
                    return it_r;
                }
            }
        }

        public static bool SP_DELETE_DoiTac(string ID)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_DELETE_DoiTac", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_DELETE_DoiTac");
                    return false;
                }
            }
        }
        public static bool Update_Status_DoiTac(string ID, string HanhDong)
        {
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update_Status_DoiTac", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("ID", ID));
                    cmd.Parameters.Add(new SqlParameter("HanhDong", HanhDong));
                    var reader = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "Update_Status_DoiTac");
                    return false;
                }
            }
        }
        public static List<objCombox> sp_Doitac_MD_Sub_get()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Doitac_MD_Sub_get", con);//
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

        public static List<objCombox> SP_DoiTac_Get_Brand(string Div)
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_DoiTac_Get_Brand", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("Div", Div));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_DoiTac_Get_Brand");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_DoiTac_Get_MaHang(string Brand)
        {
            List<objCombox> it_r = new List<objCombox>();

            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DoiTac_Get_MaHang", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("Brand", Brand));
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_DoiTac_Get_MaHang");
                    return it_r;
                }
            }
        }
        #endregion


        public static List<filter_AR> sp_bbs_getfilter_AR(string userid)
        {
            List<filter_AR> it_r = new List<filter_AR>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getfilter_AR", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        filter_AR it = new filter_AR
                        {
                            BrandNccCode = reader["Code"].ToString(),
                            BrandNccName = reader["Name"].ToString(),
                            ItemCode = reader["ItemCode"].ToString(),
                            ItemName = reader["ItemName"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getfilter_AR");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_getlist_VAT()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getlist_VAT", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getlist_VAT");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_getlist_DOTUOI()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getlist_DOTUOI", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getlist_DOTUOI");
                    return it_r;
                }
            }
        }
        public static List<objCombox> sp_bbs_getlist_MAU()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getlist_MAU", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getlist_MAU");
                    return it_r;
                }
            }
        }

        #region Chia hàng ngoài AR tự động
        public static List<filter_AR_Auto> sp_bbs_getfilter_AR_Auto(string userid)
        {
            List<filter_AR_Auto> it_r = new List<filter_AR_Auto>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_getfilter_AR_Auto", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", userid));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        filter_AR_Auto it = new filter_AR_Auto
                        {
                            MaNCC = reader["MaNCC"].ToString(),
                            TenNCC = reader["TenNCC"].ToString(),
                            BrandCode = reader["BrandCode"].ToString(),
                            BrandName = reader["BrandName"].ToString(),
                            ItemCode = reader["ItemCode"].ToString(),
                            ItemName = reader["ItemName"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_getfilter_AR_Auto");
                    return it_r;
                }
            }
        }

        public static List<Cuahang_Tinh_AR_Auto> sp_bbs_filter_AR_Auto_MienTinhCH(string uid)
        {
            List<Cuahang_Tinh_AR_Auto> it_r = new List<Cuahang_Tinh_AR_Auto>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_AR_Auto_MienTinhCH", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userid", uid));
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Cuahang_Tinh_AR_Auto it = new Cuahang_Tinh_AR_Auto
                        {
                            MaMien = reader["MaMien"].ToString(),
                            TenMien = reader["TenMien"].ToString(),
                            MaTinh = reader["MaTinh"].ToString(),
                            TenTinh = reader["TenTinh"].ToString(),
                            MaCH = reader["MaCH"].ToString(),
                            TenCH = reader["TenCH"].ToString()
                        };
                        it_r.Add(it);
                    }
                    con.Close();
                    return it_r;
                }
                catch (Exception ex)
                {
                    con.Close();
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_AR_Auto_MienTinhCH");
                    return it_r;
                }
            }
        }

        public static List<objCombox> sp_bbs_filter_AR_Auto_KhoChia()
        {
            List<objCombox> it_r = new List<objCombox>();
            using (var con = new SqlConnection(strCon))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_bbs_filter_AR_Auto_KhoChia", con);
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
                    LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_bbs_filter_AR_Auto_KhoChia");
                    return it_r;
                }
            }
        }

        #endregion
    }
}
