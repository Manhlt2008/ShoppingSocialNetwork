using Admin.DAL;
using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class UserGroupController:Controller
    {
        public ActionResult Index()
        {
            UserGroupBL UsergBL = new UserGroupBL();
            List<UserGroup> lstUG = new List<UserGroup>();
            lstUG = UsergBL.GetListUserGroup();
            return View(lstUG);
        }
        public ActionResult Edit(string groupId)
        {
            UserGroupBL UsergBL = new UserGroupBL();
            var userDetail = UsergBL.GetUserGroupById(groupId);
            return View(userDetail);
        }
        public JsonResult InsertUserGroup(UserGroup model)
        {
            int rs = -1;
            UserGroupBL UsergBL = new UserGroupBL();
            try
            {
                UsergBL.Insert(model);
                rs = 1;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(System.Web.HttpContext.Current.Server.MapPath("~"), "[InsertUserGroup]", ex.ToString());
            }
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateUserGroup(UserGroup model)
        {
            int rs = -1;
            UserGroupBL UsergBL = new UserGroupBL();
            try
            {     
                UsergBL.Update(model);
                rs = 1;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(System.Web.HttpContext.Current.Server.MapPath("~"), "[UpdateUserGroup]", ex.ToString());
            }
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteProduct(int productId)
        {
            int rs = -1;
            ProductBL producBL = new ProductBL();
            try
            {
                producBL.Delete(productId);
                rs = 1;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(System.Web.HttpContext.Current.Server.MapPath("~"), "[DeleteProduct] productId=", productId.ToString() + ex.ToString());
            }
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
    }
}