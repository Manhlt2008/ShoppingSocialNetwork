using Admin.DAL;
using Admin.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            ProductBL producBL = new ProductBL();
            List<Product> lstProduct = new List<Product>();
            lstProduct = producBL.GetAllProduct();
            return View(lstProduct);
        }
        public ActionResult Edit(int productId)
        {
            ProductBL producBL = new ProductBL();
            var productDetail = producBL.GetProductByProductId(productId);
            return View(productDetail);
        }
        public JsonResult InsertProduct(Product model)
        {
            int rs = -1;
            ProductBL producBL = new ProductBL();
            try
            {
                model.CreateDate = DateTime.Now;
                model.ModifyDate = DateTime.Now;
                model.CreateBy = 1;//Fix tạm      
                producBL.Insert(model);
                rs = 1;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(System.Web.HttpContext.Current.Server.MapPath("~"), "[InsertProduct]", ex.ToString());
            }
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateProduct(Product model)
        {
            int rs = -1;  
            ProductBL producBL = new ProductBL();
            try
            {
                model.ModifyDate = DateTime.Now;
                model.ModifyBy = 1;//Fix tạm      
                producBL.Update(model);
                rs = 1;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(System.Web.HttpContext.Current.Server.MapPath("~"), "[UpdateProduct]", ex.ToString());
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