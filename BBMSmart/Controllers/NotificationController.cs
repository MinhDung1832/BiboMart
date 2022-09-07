using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using ProductAllTool.Common;
using ProductAllTool.Models.Approve;
using ProductAllTool.Models.ManageSales;

namespace ProductAllTool.Controllers
{
    public class NotificationController : Controller
    {
        private bool checkpermission(string action)
        {
            List<permissioninfo> ls = (List<permissioninfo>)Session["permission"];
            if (ls.Where(x => x.controller.ToUpper() == "NOTIFICATION" && x.action.ToUpper() == action.ToUpper()).Count() > 0)
                return true;
            else return false;
        }

        public ActionResult CreateNoti()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                //if (!checkpermission("CreateNoti")) return RedirectToAction("Index", "Home");

                return View();
            }
            else
            {
                SystemFunctions.SaveSession("Notification", "CreateNoti");
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult ManageNoti()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                //if (!checkpermission("ManageNoti")) return RedirectToAction("Index", "Home");

                return View();
            }
            else
            {
                SystemFunctions.SaveSession("Notification", "ManageNoti");
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult ManageNotiNV()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                //if (!checkpermission("ManageNoti")) return RedirectToAction("Index", "Home");

                return View();
            }
            else
            {
                SystemFunctions.SaveSession("Notification", "ManageNotiNV");
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult ApproveNoti()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                //if (!checkpermission("ManageNoti")) return RedirectToAction("Index", "Home");

                return View();
            }
            else
            {
                SystemFunctions.SaveSession("Notification", "ManageNoti");
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult CreateNotify(Notifyinfo it)
        {
            try
            {
                string rs = DataAccess.DataAccessNoti.sp_createNoti(Session["uid"].ToString(), it);

                return Json(new { result = rs });

            }
            catch (Exception ex)
            {
                return Json(new { result = ex.Message });
            }
        }

        public ActionResult GetListManageNoti(string FromDate, string ToDate, string Source, string TargetType,
                                           string Title, string Status)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    DataTable table = DataAccess.DataAccessNoti.sp_getNotiManage(Session["uid"].ToString(),
                        FromDate,  ToDate,  Source,  TargetType,Title,  Status);
                    return PartialView("~/Views/Notification/Partial/__ManageNoti.cshtml", table);
                }
                SystemFunctions.SaveSession("Notification", "ManageNoti");
                return RedirectToAction("Login", "Account");

            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListManageNoti");
                SystemFunctions.SaveSession("Notification", "ManageNoti");
                return RedirectToAction("Login", "Account");
            }

        }

        public ActionResult GetListAprNoti(string FromDate, string ToDate, string Source, string TargetType,
                                           string Title, string Detail)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    DataTable table = DataAccess.DataAccessNoti.sp_getNotiApr(Session["uid"].ToString(), FromDate, 
                        ToDate, Source, TargetType, Title, Detail);
                    return PartialView("~/Views/Notification/Partial/__ApproveNoti.cshtml", table);
                }
                SystemFunctions.SaveSession("Notification", "ApproveNoti");
                return RedirectToAction("Login", "Account");

            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListManageNoti");
                SystemFunctions.SaveSession("Notification", "ManageNoti");
                return RedirectToAction("Login", "Account");
            }

        }

        public ActionResult ApproveNotify(string lstID, string Status)
        {
            try
            {
                string rs = DataAccess.DataAccessNoti.sp_approveNoti(Session["uid"].ToString(), lstID, Status);

                return Json(new { result = rs });

            }
            catch (Exception ex)
            {
                return Json(new { result = ex.Message });
            }
        }


        public ActionResult GetListManageNotiNV(string FromDate, string ToDate)
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    DataTable table = DataAccess.DataAccessNoti.sp_getNoti(Session["uid"].ToString(),
                        FromDate, ToDate, 0);
                    return PartialView("~/Views/Notification/Partial/__ManageNotiNV.cshtml", table);
                }
                SystemFunctions.SaveSession("Notification", "ManageNotiNV");
                return RedirectToAction("Login", "Account");

            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListManageNoti");
                SystemFunctions.SaveSession("Notification", "ManageNoti");
                return RedirectToAction("Login", "Account");
            }

        }

        public ActionResult GetNotiNV()
        {
            try
            {
                if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
                {
                    List< Notifyinfo> lst = DataAccess.DataAccessNoti.sp_getNotiIndex(Session["uid"].ToString());
                    return Json(lst);
                }
                return RedirectToAction("Login", "Account");

            }
            catch (Exception ex)
            {
                DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(ex), "GetListManageNoti");
                SystemFunctions.SaveSession("Notification", "ManageNoti");
                return RedirectToAction("Login", "Account");
            }

        }

        public ActionResult ReadNoti(int NotiID)
        {
            try
            {
                string rs = DataAccess.DataAccessNoti.sp_readNoti(Session["uid"].ToString(), NotiID);

                return Json(new { result = rs });

            }
            catch (Exception ex)
            {
                return Json(new { result = ex.Message });
            }
        }

    }

    public class Notifyinfo
    {
        public int ID { get; set; }
        public string StartDate { get; set; }
        public string Source { get; set; }
        public string TargetType { get; set; }
        public string Target { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
    }

}