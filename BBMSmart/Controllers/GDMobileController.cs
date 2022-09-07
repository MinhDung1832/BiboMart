using ProductAllTool.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductAllTool.Models.CaLamViec;
using ProductAllTool.Models.ManageSales;
using ProductAllTool.Models.Approve;
using System.Data;
using Newtonsoft.Json;
using ProductAllTool.DataAccess;

namespace ProductAllTool.Controllers
{
    public class GDMobileController : Controller
    {
        private bool checkpermission(string action)
        {
            List<permissioninfo> ls = (List<permissioninfo>)Session["permission"];
            if (ls.Where(x => x.controller == "GDMobile" && x.action == action).Count() > 0)
                return true;
            else return false;
        }
        // GET: GDMobile
        public ActionResult LayoutMobileTT3()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                var lst_Ca = DataAccess.DataAccessTT.CLV_Ca();
                ViewBag.lst_Ca = lst_Ca;
                var lst_NoiLam = DataAccess.DataAccessTT.CLV_NoiLam();
                ViewBag.lst_NoiLam = lst_NoiLam;
                var lst_CuaHang = DataAccess.DataAccessTT.CLV_CuaHang();
                ViewBag.lst_CuaHang = lst_CuaHang;
                var lst_LoaiNghi = DataAccess.DataAccessTT.CLV_LoaiNghi();
                ViewBag.lst_LoaiNghi = lst_LoaiNghi;
                var lst_Ca_NoiLam = DataAccess.DataAccessTT.CLV_Ca_NoiLam();
                ViewBag.lst_Ca_NoiLam = lst_Ca_NoiLam;
                return View();
            }
            else
            {
                SystemFunctions.SaveSession("GDMobile", "LayoutMobileTT3");
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult CLVGetListDC(string TuNgay, string DenNgay)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                DataTable table = DataAccess.DataAccessTT.CLV_getListDC(Session["uid"].ToString(), TuNgay, DenNgay);

                return PartialView("~/Views/GDMobile/Tabs/__DoiCaMobile.cshtml", table);

            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult CLVGetList(string TuNgay, string DenNgay, string Ca,string NoiLam)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                DataTable table = DataAccess.DataAccessTT.CLV_GetList(Session["uid"].ToString(), TuNgay, DenNgay, Ca, NoiLam);

                return PartialView("~/Views/GDMobile/Tabs/__LichCaMobile.cshtml", table);

            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult CLVGetListNC2(string TenCH,string Ca)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                DataTable table = DataAccess.DataAccessTT.CLV_getListNC2(Session["uid"].ToString(),TenCH,Ca);

                return PartialView("~/Views/GDMobile/Tabs/__NhanCaMobile1.cshtml", table);

            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult CLVGetTableDuyetNghi(string TuNgay,string DenNgay)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                DataTable table = DataAccess.DataAccessTT.CLV_getListDuyetNghi(Session["uid"].ToString(),TuNgay,DenNgay);

                return PartialView("~/Views/GDMobile/Tabs/__DuyetMobile.cshtml", table);

            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult CLVGetListXN1(string TuNgay,string DenNgay)
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                DataTable table = DataAccess.DataAccessTT.CLV_getListXN1(Session["uid"].ToString(),TuNgay,DenNgay);

                return PartialView("~/Views/GDMobile/Tabs/__XinNghiMobile.cshtml", table);

            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult CLVGetListNC1()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                DataTable table = DataAccess.DataAccessTT.CLV_getListNC1(Session["uid"].ToString());

                return PartialView("~/Views/GDMobile/Tabs/__NhanCaMobile.cshtml", table);

            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult CLVGetListUser()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                List<CaLV> lstUser = DataAccess.DataAccessTT.CLV_getListUser(Session["uid"].ToString());

                return Json(lstUser);

            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult setTuChoi(List<SetDaDuyet> lst)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    foreach (SetDaDuyet po in lst)
                    {
                        DataAccess.DataAccessTT.CLV_setDaDuyet(Session["uid"].ToString(), po.TenNV);
                    }
                    return Json(1);
                }
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "setTuChoi");
                return Json(null);
            }
        }
        public ActionResult setDaDuyet(List<SetDaDuyet> lst)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    foreach (SetDaDuyet po in lst)
                    {
                        DataAccess.DataAccessTT.CLV_setDaDuyet(Session["uid"].ToString(), po.TenNV);
                        
                    }
                    return Json(1);
                }
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "setDaDuyet");
                return Json(null);
            }
        }
        public ActionResult AddListNC(List<AddNC> lst)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    foreach (AddNC po in lst)
                    {
                        DataAccess.DataAccessTT.CLV_AddListNC(Session["uid"].ToString(), po.Ca,po.type);
                    }
                    return Json(1);
                }
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "AddListNC");
                return Json(null);
            }
        }
    }
}