using Newtonsoft.Json;
using ProductAllTool.DataAccess;
using ProductAllTool.Models.Approve;
using ProductAllTool.Models.ManageSales;
using ProductAllTool.Models.StockTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using ProductAllTool.Models.Goods;
using System.Data;
using Lib.Utils.Package;
using ProductAllTool.Models.HRM;

namespace ProductAllTool.Controllers
{
    public class AccountController : Controller
    {
       
    // GET: Account
    public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginMobile()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection ip_form)
        {
            string uid = ip_form["uid"];

            string pwd = ip_form["pwd"];

            bool bn = false;
            DataTable datatable= new DataTable();
            bool isemp = false;
            if (uid.Contains("bibomart."))
            {
                bn = DataAccess.DataAccess.LoginDomain(uid.Split('.')[1], pwd);
            }
            else
            {
                datatable = DataAccess.DataAccess.LoginEmpID(uid, pwd);
                bn = datatable.HasRow();
                isemp = true;
            }


            if (bn == true)
            {
                if (uid.Contains("bibomart."))
                {
                    Session["uid"] = uid.Split('.')[1].ToUpper();
                }
                else
                {
                    Session["uid"] = uid.ToUpper();
                    if (isemp) {
                    Session["StoreId"] = datatable.Rows[0]["StoreId"].ToString();
                    Session["StoreName"] = datatable.Rows[0]["StoreName"].ToString();
                    }
                }

                List<permissioninfo> per = DataAccess.DataAccess.sp_ProductTool_getPermissionbyUserBBS(uid);
                Session["permission"] = per;

                var menu = per.Select(s => new permissioninfo { menu = s.menu, En_Name = s.En_Name }).DistinctBy(s => s.menu).ToList();
                Session["menu"] = menu;

                List<backLink_Item> ls_link = DataAccess.DataAccess.sp_BBM_SMART_stockTransfer_backLink_get(Session["uid"].ToString());
                Session["ls_link"] = ls_link;

               
               
                //back to current view

                if (Session["prev_action"]!=null && Session["prev_control"] != null)
                {
                    try
                    {
                        return RedirectToAction(Session["prev_action"].ToString(), Session["prev_control"].ToString());
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("", "");
                    }
                }
                else
                {
                    return RedirectToAction("", "");
                }

                

             //   return RedirectToAction("", "");
            }
            else
            {
                @Session["err"] = "Tài khoản đăng nhập không đúng";
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginMobile(FormCollection ip_form)
        {
            string uid = ip_form["uid"];

            string pwd = ip_form["pwd"];

            bool bn = false;
            DataTable datatable = new DataTable();
            bool isemp = false;
            if (uid.Contains("bibomart."))
            {
                bn = DataAccess.DataAccess.LoginDomain(uid.Split('.')[1], pwd);
            }
            else
            {
                datatable = DataAccess.DataAccess.LoginEmpID(uid, pwd);
                bn = datatable.HasRow();
                isemp = true;
            }

            if (bn == true)
            {
                if (uid.Contains("bibomart."))
                {
                    Session["uid"] = uid.Split('.')[1].ToUpper();
                }
                else
                {
                    Session["uid"] = uid.ToUpper();
                    if (isemp)
                    {
                        Session["StoreId"] = datatable.Rows[0]["StoreId"].ToString();
                        Session["StoreName"] = datatable.Rows[0]["StoreName"].ToString();
                    }
                }
                //
                List<permissioninfo> per = DataAccess.DataAccess.sp_ProductTool_getPermissionbyUserBBS(uid);
                Session["permission"] = per;

                List<backLink_Item> ls_link = DataAccess.DataAccess.sp_BBM_SMART_stockTransfer_backLink_get(Session["uid"].ToString());
                Session["ls_link"] = ls_link;

              

                return RedirectToAction("", "");
            }
            else
            {
                @Session["err"] = "Tài khoản đăng nhập không đúng";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Contents.RemoveAll();

            return RedirectToAction("Login");
        }

        public ActionResult Manage()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                List<permissioninfo> ls = (List<permissioninfo>)Session["permission"];
                if(ls.Where(x => x.fcode == "S0000").Count() >0)
                {
                    var list_User = DataAccess.DataAccess.sp_po_getUser();
                    ViewBag.listUser = list_User;
                    return View();

                }
                else return RedirectToAction("Index", "Home");

            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult ManageUser()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
               // List<permissioninfo> ls = (List<permissioninfo>)Session["permission"];
              //  if (ls.Where(x => x.fcode == "S000").Count() > 0)
               // {
                    var list_User = DataAccess.DataAccess.sp_po_getUser();
                    ViewBag.listUser = list_User;
                    return View();

              //  }
              //  else return RedirectToAction("Index", "Home");

            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult ManageGroup()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
             //   List<permissioninfo> ls = (List<permissioninfo>)Session["permission"];
              //  if (ls.Where(x => x.fcode == "S000").Count() > 0)
              //  {
                 //   var list_User = DataAccess.DataAccess.sp_po_getUser();
                    var list_Group = DataAccess.DataAccess.sp_bbs_getlistGroup();
                    ViewBag.listGroup = list_Group;
                    //ViewBag.listUser = list_User;
                    return View();

              //  }
              //  else return RedirectToAction("Index", "Home");

            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult getPermission(string empid)
        {
            try
            {
                List<permissioninfo> its = DataAccess.DataAccess.sp_ProductTool_getPermissionforAdminBBS(empid);
                Session["peron_edit"] = its;
                return Json(its);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getPermissionAdmin");
                return null;
            }
        }

        public ActionResult getGroupbyUser(string empid)
        {
            try
            {
                List<groupinfo> its = DataAccess.DataAccess.sp_bbs_getGroupbyUser(empid);
                return Json(its);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getGroupbyUser");
                return null;
            }
        }

        public ActionResult getFunctionbyGroup(string gid)
        {
            try
            {
                List<permissioninfo> its = DataAccess.DataAccess.sp_bbs_getFunctionbyGroup(gid);
                return Json(its);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getFunctionbyGroup");
                return null;
            }
        }

        public ActionResult setMenuload(string menuload)
        {
            try
            {
                Session["menuload"] = menuload;
                return null;
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "setMenuload");
                return null;
            }
        }

        public ActionResult Per_onEdit(permissioninfo it)
        {
            try
            {
                List<permissioninfo> onEdit = (List<permissioninfo>)Session["peron_edit"];

                var fill = onEdit.FirstOrDefault(s => s.fcode == it.fcode && s.vcount != it.vcount);

                if (fill != null)
                {
                    fill.vcount = it.vcount;

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

        public ActionResult setPermission(/*List<permissioninfo> lstper, */string empid)
        {
            List<permissioninfo> lst = (List<permissioninfo>)Session["peron_edit"];
            try
            {
                bool rs = DataAccess.DataAccess.sp_ProductTool_updatePermissionBBS(empid, Session["uid"].ToString(), lst);
                return Json(rs);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "updatePermission");
                return null;
            }
        }

        public ActionResult setGroupUser(List<groupinfo> lstper, string empid)
        {
            try
            {
                bool rs = DataAccess.DataAccess.sp_bbs_updateGroupUser(empid, lstper);
                return Json(rs);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "setGroupUser");
                return null;
            }
        }

        public ActionResult setPermissionGroup(List<permissioninfo> lstper, string gid)
        {
            try
            {
                bool rs = DataAccess.DataAccess.sp_bbs_updatePermissionGroup(gid, lstper);
                return Json(rs);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "setPermissionGroup");
                return null;
            }
        }

        public ActionResult getNoti()
        {
            try
            {
                List<notiinfo> lst = DataAccess.DataAccess.sp_bbs_getNotiApprove(Session["uid"].ToString());
                return Json(lst);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getNoti");
                return null;
            }
        }

        public ActionResult getMotaCV()
        {
            try
            {
                List<MotaCVinfo> lst = DataAccess.DataAccess.sp_index_getMotaCV(Session["uid"].ToString());
                return Json(lst);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getMotaCV");
                return null;
            }
        }

        public ActionResult getSieusaoKPI()
        {
            try
            {
                List<SieusaoKPIinfo> lst = DataAccess.DataAccess.sp_index_getSieusaoKPI(Session["uid"].ToString());
                return Json(lst);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getSieusaoKPI");
                return null;
            }
        }

        public ActionResult getSieusaoDoanhthu()
        {
            try
            {
                List<SieusaoDoanhthuinfo> lst = DataAccess.DataAccess.sp_index_getSieusaoDoanhthu(Session["uid"].ToString());
                return Json(lst);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getSieusaoDoanhthu");
                return null;
            }
        }

        public ActionResult getBonus()
        {
            try
            {
                List<Bonusinfo> lst = DataAccess.DataAccess.sp_index_getBonus(Session["uid"].ToString());
                return Json(lst);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getBonus");
                return null;
            }
        }
        public ActionResult getBantin()
        {
            try
            {
                List<Bantininfo> lst = DataAccess.DataAccess.sp_index_getBantin(Session["uid"].ToString());
                return Json(lst);
            }
            catch (Exception ex)
            {
                LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "getBantin");
                return null;
            }
        }




    }
}