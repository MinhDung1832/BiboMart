using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using NPOI.HPSF;
using ProductAllTool.Common;
using ProductAllTool.DataAccess;
using ProductAllTool.Models.Approve;
using ProductAllTool.Models.ManageUser;

namespace ProductAllTool.Controllers
{
    public class ManagerUserController : Controller
    {
        private string uid = "admin";
        private string menu;
        private bool checkpermission(string action)
        {
            List<permissioninfo> ls = (List<permissioninfo>)Session["permission"];
            if (ls.Where(x => x.controller == "ManagerUser" && x.action == action).Count() > 0)
                return true;
            else return false;
        }

        #region Index
        public ActionResult Index()
        {
            var lst_store = DataAccess.DataAccess.SP_BBM_ManageUse_Store_get(uid);
            ViewBag.lst_store = lst_store;
            var lst_vung = DataAccess.DataAccess.SP_BBM_ManageUse_getVung(uid);
            ViewBag.lst_vung = lst_vung;
            var lst_tinh = DataAccess.DataAccess.SP_BBM_ManageUse_getTinh(uid);
            ViewBag.lst_tinh = lst_tinh;
            var lst_division = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getDivison();
            ViewBag.lst_division = lst_division;
            var lst_department = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getDepartment();
            ViewBag.lst_department = lst_department;
            var lst_user = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getuser();
            ViewBag.lst_user = lst_user;
            var lst_parent = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getparent(menu);
            ViewBag.lst_parent = lst_parent;
            var lst_fchild = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getChild(menu);
            ViewBag.lst_fchild = lst_fchild;
            return View();
        }

        [HttpPost]
        public ActionResult SP_BBM_getlst_main_ManageUse(string E_DIVISION_CODE, string E_DEPARTMENT_CODE, string paname, string MaVung, string MaTinh, string storeNo, string CodeEmp, string PositionName, string fcode)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    // var strMahang = "";     
                    var obj = DataAccess.DataAccess.SP_BBM_getlst_main_ManageUse(E_DIVISION_CODE, E_DEPARTMENT_CODE, paname, MaVung, MaTinh, storeNo, CodeEmp, PositionName, fcode);
                    return Json(obj);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBM_getlst_main_ManageUse");
            }
            return RedirectToAction("Login", "Account");

        }

        #endregion

        #region phân quyền
        public ActionResult PhanQuyen()
        {
            var lst_division = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getDivison();
            ViewBag.lst_division = lst_division;
            var lst_department = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getDepartment();
            ViewBag.lst_department = lst_department;
            var lst_user = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getuser();
            ViewBag.lst_user = lst_user;
            var lst_parent = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getparent(menu);
            ViewBag.lst_parent = lst_parent;
            var lst_fchild = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getChild(menu);
            ViewBag.lst_fchild = lst_fchild;
            var lst_Nvu = DataAccess.DataAccess.SP_BBM_ManageUse_getNghiepVu();
            ViewBag.lst_Nvu = lst_Nvu;
            return View();
        }

        public ActionResult QuanLyPhanQuyen()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var lst_division = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getDivison();
                ViewBag.lst_division = lst_division;

                var lst_department = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getDepartment();
                ViewBag.lst_department = lst_department;
                var lst_Nvu = DataAccess.DataAccess.SP_BBM_ManageUse_getNghiepVu();
                ViewBag.lst_Nvu = lst_Nvu;
                var lst_parent = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getparent(menu);
                ViewBag.lst_parent = lst_parent;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult QLPhanQuyen()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var lst_division = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getDivison();
                ViewBag.lst_division = lst_division;
                var lst_department = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getDepartment();
                ViewBag.lst_department = lst_department;
                var lst_Nvu = DataAccess.DataAccess.SP_BBM_ManageUse_getNghiepVu();
                ViewBag.lst_Nvu = lst_Nvu;
                var lst_parent = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getparent(menu);
                ViewBag.lst_parent = lst_parent;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult getFunctionParent(string menu)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var lst_parent = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getparent(menu);
                    return Json(lst_parent);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getFunctionParent");
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult getFunctionchild(string menu)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var lst_fchild = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getChild(menu);
                    return Json(lst_fchild);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getFunctionchild");
            }
            return RedirectToAction("Login", "Account");

        }

        public ActionResult getDepartment_datalist(string Division_Code)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var lst_department = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getDepartment(Division_Code);
                    return Json(lst_department);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getDepartment_datalist");
            }
            return RedirectToAction("Login", "Account");

        }

        public ActionResult getBoPhan(string Division_Code, string Department)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var lst_bophan = DataAccess.DataAccess.SP_BBM_ManageUse_Header_get_E_Section(Division_Code, Department);
                    return Json(lst_bophan);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getBoPhan");
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult getUserList(string Division_Code, string Department)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var lst_user = DataAccess.DataAccess.SP_BBM_ManageUse_ListUser(Division_Code, Department);
                    return Json(lst_user);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getUserList");
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult getPositionList(string Division_Code, string Department)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var lst_user = DataAccess.DataAccess.SP_BBM_ManageUse_ListPosition(Division_Code, Department);
                    return Json(lst_user);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getPositionList");
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult getlistUserFunction(string fcode, string fChildCode, string user_div, string user_dep, string user_pos, string userid)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    DataTable table = DataAccess.DataAccess.sp_bbs_get_sys_list_user_function(fcode, fChildCode, user_div, user_dep, user_pos, userid);

                    List<sys_list_user_function> listper = table.AsEnumerable().Select(m => new sys_list_user_function()
                    {
                        fcode = m.Field<string>("fcode"),
                        fChildCode = m.Field<string>("fChildCode"),
                        fname_L1 = m.Field<string>("fname_L1"),
                        fname = m.Field<string>("fname"),
                        CodeEmp = m.Field<string>("CodeEmp"),
                        ProfileName = m.Field<string>("ProfileName"),
                        PositionName = m.Field<string>("PositionName"),
                        E_DIVISION = m.Field<string>("E_DIVISION"),
                        E_DEPARTMENT = m.Field<string>("E_DEPARTMENT"),
                        modifydate = m.Field<string>("modifydate"),
                        modifyby = m.Field<string>("modifyby"),
                        ischeck = int.Parse(m.Field<decimal>("ischeck").ToString())
                    }).ToList();

                    Session["peron_edit"] = listper;

                    return PartialView("~/Views/ManagerUser/Partial/__QuanLyPhanQuyen.cshtml", table);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getlistUserFunction");
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult getlistUserQLPhanQuyen(string fcode, string fChildCode, string user_div, string user_dep, string user_pos, string userid)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    DataTable table = DataAccess.DataAccess.sp_bbs_get_sys_list_user_function_QLPhanQuyen(fcode, fChildCode, user_div, user_dep, user_pos, userid);

                    List<sys_list_user_function> listper = table.AsEnumerable().Select(m => new sys_list_user_function()
                    {
                        fcode = m.Field<string>("fcode"),
                        fChildCode = m.Field<string>("fChildCode"),
                        fname_L1 = m.Field<string>("fname_L1"),
                        fname = m.Field<string>("fname"),
                        CodeEmp = m.Field<string>("CodeEmp"),
                        ProfileName = m.Field<string>("ProfileName"),
                        PositionName = m.Field<string>("PositionName"),
                        E_DIVISION = m.Field<string>("E_DIVISION"),
                        E_DEPARTMENT = m.Field<string>("E_DEPARTMENT"),
                        modifydate = m.Field<string>("modifydate"),
                        modifyby = m.Field<string>("modifyby"),
                        ischeck = int.Parse(m.Field<decimal>("ischeck").ToString())
                    }).ToList();

                    Session["peron_edit"] = listper;

                    return PartialView("~/Views/ManagerUser/Partial/__QLPhanQuyen.cshtml", table);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getlistUserQLPhanQuyen");
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Per_onEdit(sys_list_user_function it)
        {
            try
            {
                List<sys_list_user_function> onEdit = (List<sys_list_user_function>)Session["peron_edit"];

                var fill = onEdit.FirstOrDefault(s => s.fChildCode == it.fChildCode && s.CodeEmp == it.CodeEmp && s.ischeck != it.ischeck);

                if (fill != null)
                {
                    fill.ischeck = it.ischeck;

                    Session["peron_edit"] = onEdit;
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "peron_edit");
                return Json(new { code = 1, message = "" });
            }
        }

        public ActionResult Per_onEditAll(int ischeck)
        {
            try
            {
                List<sys_list_user_function> onEdit = (List<sys_list_user_function>)Session["peron_edit"];
                foreach (sys_list_user_function it in onEdit)
                {
                    it.ischeck = ischeck;
                }

                Session["peron_edit"] = onEdit;



                return Json(new { code = 0, message = "" });

            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "peron_edit");
                return Json(new { code = 1, message = "" });
            }
        }

        //updatepremision
        public ActionResult setPermission()
        {
            List<sys_list_user_function> lstper = (List<sys_list_user_function>)Session["peron_edit"];
            try
            {
                bool rs = false;
                foreach (sys_list_user_function p in lstper)
                {
                    if (p.fChildCode == "S050101")
                    {
                        string a = "";
                    }
                    rs = DataAccess.DataAccess.SP_BBS_updateUserPermission(p.CodeEmp, p.fChildCode, Session["uid"].ToString(), p.ischeck);

                }
                return Json(rs);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "SP_BBS_updateUserPermission");
                return null;
            }
        }
        #endregion

        #region Đề xuất phân quyền
        public ActionResult PermissionSuggest()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                if (!checkpermission("PermissionSuggest")) return RedirectToAction("Index", "Home");

                var lst_division = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getDivison();
                ViewBag.lst_division = lst_division;
                var lst_department = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getDepartment();
                ViewBag.lst_department = lst_department;
                var lst_Nvu = DataAccess.DataAccess.SP_BBM_ManageUse_getNghiepVu();
                ViewBag.lst_Nvu = lst_Nvu;
                var lst_parent = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getparent(menu);
                ViewBag.lst_parent = lst_parent;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult GetListPermissionSuggest(string fcode, string fChildCode, string user_div, string user_dep, string user_pos, string userid)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    DataTable table = DataAccess.DataAccess.sp_bbs_get_sys_list_user_function_QLPhanQuyen(fcode, fChildCode, user_div, user_dep, user_pos, userid);

                    List<sys_list_user_function> listdx = table.AsEnumerable().Select(m => new sys_list_user_function()
                    {
                        fcode = m.Field<string>("fcode"),
                        fChildCode = m.Field<string>("fChildCode"),
                        fname_L1 = m.Field<string>("fname_L1"),
                        fname = m.Field<string>("fname"),
                        CodeEmp = m.Field<string>("CodeEmp"),
                        ProfileName = m.Field<string>("ProfileName"),
                        PositionName = m.Field<string>("PositionName"),
                        E_DIVISION = m.Field<string>("E_DIVISION"),
                        E_DEPARTMENT = m.Field<string>("E_DEPARTMENT"),
                        modifydate = m.Field<string>("modifydate"),
                        modifyby = m.Field<string>("modifyby"),
                        ischeck = int.Parse(m.Field<decimal>("ischeck").ToString())
                    }).ToList();

                    Session["dx_edit"] = listdx;

                    return PartialView("~/Views/ManagerUser/Partial/__PermissionSuggest.cshtml", table);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListPermissionSuggest");
            }
            return RedirectToAction("Login", "Account");
        }

        #endregion

        #region Duyệt phân quyền (1)
        public ActionResult PermissionAccept()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                if (!checkpermission("PermissionAccept")) return RedirectToAction("Index", "Home");

                var lst_division = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getDivison();
                ViewBag.lst_division = lst_division;
                var lst_department = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getDepartment();
                ViewBag.lst_department = lst_department;
                var lst_Nvu = DataAccess.DataAccess.SP_BBM_ManageUse_getNghiepVu();
                ViewBag.lst_Nvu = lst_Nvu;
                var lst_parent = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getparent(menu);
                ViewBag.lst_parent = lst_parent;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult GetListPermissionccept01(string fcode, string fChildCode, string user_div, string user_dep, string user_pos, string userid)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    DataTable table = DataAccess.DataAccess.sp_bbs_get_sys_list_user_function_PermissionAccept01(fcode, fChildCode, user_div, user_dep, user_pos, userid);

                    List<sys_list_user_function> listdx = table.AsEnumerable().Select(m => new sys_list_user_function()
                    {
                        fcode = m.Field<string>("fcode"),
                        fChildCode = m.Field<string>("fChildCode"),
                        fname_L1 = m.Field<string>("fname_L1"),
                        fname = m.Field<string>("fname"),
                        CodeEmp = m.Field<string>("CodeEmp"),
                        ProfileName = m.Field<string>("ProfileName"),
                        PositionName = m.Field<string>("PositionName"),
                        E_DIVISION = m.Field<string>("E_DIVISION"),
                        E_DEPARTMENT = m.Field<string>("E_DEPARTMENT"),
                        modifydate = m.Field<string>("modifydate"),
                        modifyby = m.Field<string>("modifyby"),
                        ischeck = int.Parse(m.Field<decimal>("ischeck").ToString())
                    }).ToList();

                    Session["dx_edit"] = listdx;

                    return PartialView("~/Views/ManagerUser/Partial/__PermissionAccept.cshtml", table);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListPermissionccept01");
            }
            return RedirectToAction("Login", "Account");
        }

        #endregion

        #region Duyệt phân quyền (2)
        public ActionResult PermissionManage()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                if (!checkpermission("PermissionManage")) return RedirectToAction("Index", "Home");

                var lst_division = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getDivison();
                ViewBag.lst_division = lst_division;
                var lst_department = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getDepartment();
                ViewBag.lst_department = lst_department;
                var lst_Nvu = DataAccess.DataAccess.SP_BBM_ManageUse_getNghiepVu();
                ViewBag.lst_Nvu = lst_Nvu;
                var lst_parent = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getparent(menu);
                ViewBag.lst_parent = lst_parent;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult GetListPermissionccept02(string fcode, string fChildCode, string user_div, string user_dep, string user_pos, string userid)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    DataTable table = DataAccess.DataAccess.sp_bbs_get_sys_list_user_function_PermissionAccept02(fcode, fChildCode, user_div, user_dep, user_pos, userid);

                    List<sys_list_user_function> listdx = table.AsEnumerable().Select(m => new sys_list_user_function()
                    {
                        fcode = m.Field<string>("fcode"),
                        fChildCode = m.Field<string>("fChildCode"),
                        fname_L1 = m.Field<string>("fname_L1"),
                        fname = m.Field<string>("fname"),
                        CodeEmp = m.Field<string>("CodeEmp"),
                        ProfileName = m.Field<string>("ProfileName"),
                        PositionName = m.Field<string>("PositionName"),
                        E_DIVISION = m.Field<string>("E_DIVISION"),
                        E_DEPARTMENT = m.Field<string>("E_DEPARTMENT"),
                        modifydate = m.Field<string>("modifydate"),
                        modifyby = m.Field<string>("modifyby"),
                        ischeck = int.Parse(m.Field<decimal>("ischeck").ToString())
                    }).ToList();

                    Session["dx_edit"] = listdx;

                    return PartialView("~/Views/ManagerUser/Partial/__PermissionManage.cshtml", table);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListPermissionccept02");
            }
            return RedirectToAction("Login", "Account");
        }

        #endregion

        #region QuanLyPhanQuyenGetWayNV
        public ActionResult QuanLyPhanQuyenGetWayNV()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var lst_division = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getDivison();
                ViewBag.lst_division = lst_division;

                var lst_department = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getDepartment();
                ViewBag.lst_department = lst_department;
                var lst_Nvu = DataAccess.DataAccess.SP_BBM_ManageUse_getNghiepVu();
                ViewBag.lst_Nvu = lst_Nvu;
                var lst_parent = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getparent(menu);
                ViewBag.lst_parent = lst_parent;

                var lst_CN = DataAccess.DataAccess.getFunctionParent_Vendor();
                ViewBag.lst_CN = lst_CN;

                return View();
            }
            else
            {
                SystemFunctions.SaveSession("ManagerUser", "QuanLyPhanQuyenGetWayNV");
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult getFunctionchild_Vendor(string menu)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    var lst_fchild = DataAccess.DataAccess.getFunctionchild_Vendor(menu);
                    return Json(lst_fchild);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getFunctionchild_Vendor");
            }
            return RedirectToAction("Login", "Account");

        }

        [HttpPost]
        public ActionResult getlistUserFunction_Vendor(string fcode, string fChildCode, string user_div, string user_dep, string user_pos, string userid)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    DataTable table = DataAccess.DataAccess.sp_VENDOR_get_sys_list_user_function(fcode, fChildCode, user_div, user_dep, user_pos, userid);

                    List<sys_list_user_function> listper = table.AsEnumerable().Select(m => new sys_list_user_function()
                    {
                        fcode = m.Field<string>("fcode"),
                        fChildCode = m.Field<string>("fChildCode"),
                        fname_L1 = m.Field<string>("fname_L1"),
                        fname = m.Field<string>("fname"),
                        CodeEmp = m.Field<string>("CodeEmp"),
                        ProfileName = m.Field<string>("ProfileName"),
                        PositionName = m.Field<string>("PositionName"),
                        E_DIVISION = m.Field<string>("E_DIVISION"),
                        E_DEPARTMENT = m.Field<string>("E_DEPARTMENT"),
                        modifydate = m.Field<string>("modifydate"),
                        modifyby = m.Field<string>("modifyby"),
                        ischeck = int.Parse(m.Field<decimal>("ischeck").ToString())
                    }).ToList();

                    Session["peron_edit_getwayNV"] = listper;

                    return PartialView("~/Views/ManagerUser/Partial/__QuanLyPhanQuyenGetWayNV.cshtml", table);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getlistUserFunction_Vendor");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult setPermission_Vendor()
        {
            List<sys_list_user_function> lstper = (List<sys_list_user_function>)Session["peron_edit_getwayNV"];
            try
            {
                bool rs = false;
                foreach (sys_list_user_function p in lstper)
                {
                    if (p.fChildCode == "S050101")
                    {
                        string a = "";
                    }
                    rs = DataAccess.DataAccess.sp_Verdor_sys_update_user_permission(p.CodeEmp, p.fcode,p.fChildCode, Session["uid"].ToString(), p.ischeck);

                }
                return Json(rs);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "sp_Verdor_sys_update_user_permission");
                return null;
            }
        }
        public ActionResult Per_onEditAll_Vendor(int ischeck)
        {
            try
            {
                List<sys_list_user_function> onEdit = (List<sys_list_user_function>)Session["peron_edit_getwayNV"];
                foreach (sys_list_user_function it in onEdit)
                {
                    it.ischeck = ischeck;
                }
                Session["peron_edit_getwayNV"] = onEdit;
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "peron_edit_getwayNV");
                return Json(new { code = 1, message = "" });
            }
        }
        public ActionResult Per_onEdit_Vendor(sys_list_user_function it)
        {
            try
            {
                List<sys_list_user_function> onEdit = (List<sys_list_user_function>)Session["peron_edit_getwayNV"];
                var fill = onEdit.FirstOrDefault(s => s.fChildCode == it.fChildCode && s.CodeEmp == it.CodeEmp && s.ischeck != it.ischeck);
                if (fill != null)
                {
                    fill.ischeck = it.ischeck;
                    Session["peron_edit_getwayNV"] = onEdit;
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "peron_edit_getwayNV");
                return Json(new { code = 1, message = "" });
            }
        }

        #endregion



        #region QuanLyPhanQuyenGetWayNCC
        public ActionResult QuanLyPhanQuyenGetWayNCC()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var lst_division = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getDivison();
                ViewBag.lst_division = lst_division;

                var lst_department = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getDepartment();
                ViewBag.lst_department = lst_department;
                var lst_Nvu = DataAccess.DataAccess.SP_getway_PhongBan();
                ViewBag.lst_Nvu = lst_Nvu;
                var lst_parent = DataAccess.DataAccess.SP_BBM_ManageUse_Header_getparent(menu);
                ViewBag.lst_parent = lst_parent;

                var lst_CN = DataAccess.DataAccess.getFunctionParent_Vendor();
                ViewBag.lst_CN = lst_CN;

                return View();
            }
            else
            {
                SystemFunctions.SaveSession("ManagerUser", "QuanLyPhanQuyenGetWayNCC");
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        public ActionResult getlistUserFunction_Vendor_NCC(string fcode, string fPhongBan)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    DataTable table = DataAccess.DataAccess.sp_VENDOR_get_sys_list_user_function_NCC(fcode, fPhongBan);
                    var listper = (from DataRow dr in table.Rows
                                   select new sys_list_user_function_NCC()
                                   {
                                       PhongBan = dr["PhongBan"].ToString(),
                                       ChucNang = dr["ChucNang"].ToString(),
                                       MaChucNang = dr["MaChucNang"].ToString(),
                                       flevel = dr["flevel"].ToString(),
                                       // orderby = dr["orderby"].ToString(),
                                       parentcode = dr["parentcode"].ToString(),
                                       action = dr["action"].ToString(),
                                       controller = dr["controller"].ToString(),
                                       NguoiCapNhat = dr["NguoiCapNhat"].ToString(),
                                       NgayCapNhat = dr["NgayCapNhat"].ToString(),
                                       isCheck = dr["isCheck"].ToString(),
                                   }).ToList();

                    Session["peron_edit_getwayNCC"] = listper;
                    return PartialView("~/Views/ManagerUser/Partial/__QuanLyPhanQuyenGetWayNCC.cshtml", table);
                }
            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getlistUserFunction_Vendor");
            }
            return RedirectToAction("Login", "Account");
        }
        //public ActionResult setPermission_Vendor_NCCs(string Phongban, string MaChucNang)
        //{
        //    List<sys_list_user_function_NCC> lstper = (List<sys_list_user_function_NCC>)Session["peron_edit_getwayNCC"];
        //    try
        //    {
        //        bool rs = false;
        //        foreach (sys_list_user_function_NCC p in lstper)
        //        {
        //            rs = DataAccess.DataAccess.sp_Verdor_sys_update_user_permission_NCC(MaChucNang, Session["uid"].ToString(), Phongban);

        //        }
        //        return Json(rs);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "setPermission_Vendor_NCC");
        //        return null;
        //    }
        //}

        [HttpPost]
        public ActionResult setPermission_Vendor_NCC(string[] MaChucNang, string Phongban)
        {
            try
            {
                for (int i = 0; i < MaChucNang.Length; i++)
                {
                    string[] Value = MaChucNang[i].ToString().Split('-');
                    DataAccess.DataAccess.sp_Verdor_sys_update_user_permission_NCC(Value[0].ToString(), Value[1].ToString(), Value[2].ToString(), Value[3].ToString(), Session["uid"].ToString(), Phongban);
                }
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "setPermission_Vendor_NCC");
                return Json(new { code = 1, message = "" });
            }
        }

        [HttpPost]
        public ActionResult sp_Verdor_sys_update_user_permission_NCC_Update(string Phongban)
        {
            try
            {
                DataAccess.DataAccess.sp_Verdor_sys_update_user_permission_NCC_Update(Phongban);
                return Json(new { code = 0, message = "" });
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "setPermission_Vendor_NCC");
                return Json(new { code = 1, message = "" });
            }
        }


        #endregion

    }
}
