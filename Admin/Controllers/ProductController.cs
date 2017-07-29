using Admin.DAL;
using Admin.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        
        public ActionResult Index()
        {
            ProductBL producBL = new ProductBL();
            List<Product> lstProduct = new List<Product>();
            lstProduct = producBL.GetAllProduct();
            ViewBag.ProductType = producBL.GetAllProductType();
            return View(lstProduct);
        }
        public ActionResult Edit(int productId)
        {
            ProductBL producBL = new ProductBL();
            var productDetail = producBL.GetProductByProductId(productId);
            ViewBag.ProductType = producBL.GetAllProductType();
            return View(productDetail);
        }
        public JsonResult InsertProduct(Product model)
        {
            int rs = -1;
            ProductBL producBL = new ProductBL();
            try
            {
                model.CreatedAt = DateTime.Now;
                model.ModifiedAt = DateTime.Now;
                model.CreatedBy = 1;//Fix tạm      
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
                model.ModifiedAt = DateTime.Now;
                model.ModifiedBy = 1;//Fix tạm      
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

        public ActionResult ProductType()
        {
            ProductBL producBL = new ProductBL();
            List<ProductType> lstProductType = new List<ProductType>();
            lstProductType = producBL.GetAllProductType();
            return View(lstProductType);  
        }
        public JsonResult InsertProductType(ProductType model)
        {
            int rs = -1;
            ProductBL producBL = new ProductBL();
            try
            {
                producBL.InsertProductType(model);
                rs = 1;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(System.Web.HttpContext.Current.Server.MapPath("~"), "[InsertProductType]", ex.ToString());
            }
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditProType(int ProTypeId)
        {
            ProductBL producBL = new ProductBL();
            var productDetail = producBL.GetProductTypeById(ProTypeId);
            return View(productDetail);
        }
        public JsonResult UpdateProductType(ProductType model)
        {
            int rs = -1;
            ProductBL producBL = new ProductBL();
            try
            {
                producBL.UpdateProductType(model);
                rs = 1;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(System.Web.HttpContext.Current.Server.MapPath("~"), "[UpdateProductType]", ex.ToString());
            }
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteProductType(int proTypeId)
        {
            int rs = -1;
            ProductBL producBL = new ProductBL();
            try
            {
                producBL.DeleteProductType(proTypeId);
                rs = 1;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(System.Web.HttpContext.Current.Server.MapPath("~"), "[DeleteProductType] proTypeId=", proTypeId.ToString() + ex.ToString());
            }
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
    }
}