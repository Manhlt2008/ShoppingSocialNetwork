using Admin.Common;
using Admin.DAL;
using Admin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Admin.Controllers
{
    public class AccountController: BaseController
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public JsonResult LoginPost(string userName,string pass)
        {
            int flag = FlagStatus.ServerError;
            try
            {
                string MD5Pass = Lib.Encrypt(pass);
                UserListBL uBL = new UserListBL();
                //UserModel usermodel = new UserModel();
                if (userName != string.Empty && pass != string.Empty)
                {
                    var user = uBL.GetUserByUserPass(userName, MD5Pass);
                    if (user != null)//nếu tồn tại trong hệ thống thì get DB xem ở nhóm nào, quyền gì
                    {
                        var usermodel = uBL.GetPermission_ByUserName(userName);
                        FormsAuthentication.SetAuthCookie(JsonConvert.SerializeObject(usermodel, Formatting.None), false);
                        flag = FlagStatus.Success;
                    }
                    else
                    {
                        flag = FlagStatus.DataNotFound;
                    }
                } 
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(Server.MapPath("~"), "[LoginPost]", ex.ToString());
                return Json(flag , JsonRequestBehavior.AllowGet);
            }
            return Json(flag , JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}