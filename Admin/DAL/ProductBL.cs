using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.DAL
{
    public class ProductBL
    {
        #region CRUD
        public void Insert(Product pro)
        {
            using (var context = MainDBContext.MainDB())
            {
                context.StoredProcedure("Product_Insert")
                    .Parameter("Name", pro.Name)
                    .Parameter("Description", pro.Description)
                    .Parameter("Price", pro.Price)
                    .Parameter("CreateDate", pro.CreateDate)
                    .Parameter("CreateBy", pro.CreateBy)  
                    .Execute();
            }
        }

        public void Update(Product pro)
        {
            using (var context = MainDBContext.MainDB())
            {
                context.StoredProcedure("Product_Update")
                    .Parameter("ProductId", pro.ProductId)
                    .Parameter("Name", pro.Name)
                    .Parameter("Description", pro.Description)
                    .Parameter("Price", pro.Price)
                    .Parameter("ModifyBy", pro.ModifyBy)
                    .Execute();
            }
        }

        public void Delete(int productId)
        {
            using (var context = MainDBContext.MainDB())
            {
                context.StoredProcedure("Product_Delete").Parameter("ProductId", productId).Execute();
            }
        }
        #endregion
        public List<Product> GetAllProduct()
        {
            using (var context = MainDBContext.MainDB())
            {
                return context.StoredProcedure("Product_GetAll").QueryMany<Product>();
            }
        }
        public Product GetProductByProductId(int productId)
        {
            Product pr = new Product();
            using (var context = MainDBContext.MainDB())
            {
                var result = context.StoredProcedure("Product_GetById")
                    .Parameter("ProductId", productId)
                    .QuerySingle<Product>();
                pr = result;
            }
            return pr;
        }
    }
}