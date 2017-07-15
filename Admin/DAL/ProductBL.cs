using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.DAL
{
    public class ProductBL
    {
        #region Product
        public void Insert(Product pro)
        {
            using (var context = MainDBContext.MainDB())
            {
                context.StoredProcedure("Product_Insert")
                    .Parameter("ProTypeID", pro.ProTypeID)
                    .Parameter("Name", pro.Name)
                    .Parameter("Price", pro.Price)
                    .Parameter("UnitName", pro.UnitName)
                    .Parameter("Description", pro.Description) 
                    .Parameter("CreatedBy", pro.CreatedBy)
                    .Parameter("ModifiedBy", pro.ModifiedBy)  
                    .Execute();
            }
        }

        public void Update(Product pro)
        {
            using (var context = MainDBContext.MainDB())
            {
                context.StoredProcedure("Product_Update")
                    .Parameter("ProductId", pro.ProductId)
                    .Parameter("ProTypeID", pro.ProTypeID)
                    .Parameter("Name", pro.Name)
                    .Parameter("Price", pro.Price)
                    .Parameter("UnitName", pro.UnitName)
                    .Parameter("Description", pro.Description) 
                    .Parameter("ModifiedBy", pro.ModifiedBy)
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
        #endregion

        #region ProductType
        public void InsertProductType(ProductType pro)
        {
            using (var context = MainDBContext.MainDB())
            {
                context.StoredProcedure("ProductType_Insert")
                    .Parameter("ProTypeId", pro.ProTypeId)
                    .Parameter("Name", pro.Name)
                    .Parameter("Note", pro.Note)           
                    .Execute();
            }
        }

        public void UpdateProductType(ProductType pro)
        {
            using (var context = MainDBContext.MainDB())
            {
                context.StoredProcedure("ProductType_Update")
                    .Parameter("ProTypeId", pro.ProTypeId)
                    .Parameter("Name", pro.Name)
                    .Parameter("Note", pro.Note)       
                    .Execute();
            }
        }

        public void DeleteProductType(int productTypeId)
        {
            using (var context = MainDBContext.MainDB())
            {
                context.StoredProcedure("ProductType_Delete").Parameter("ProTypeId", productTypeId).Execute();
            }
        }

        public List<ProductType> GetAllProductType()
        {
            using (var context = MainDBContext.MainDB())
            {
                return context.StoredProcedure("ProductType_GetAll").QueryMany<ProductType>();
            }
        }
        public ProductType GetProductTypeById(int productTypeId)
        {
            ProductType pr = new ProductType();
            using (var context = MainDBContext.MainDB())
            {
                var result = context.StoredProcedure("ProductType_GetById")
                    .Parameter("ProTypeId", productTypeId)
                    .QuerySingle<ProductType>();
                pr = result;
            }
            return pr;
        }
        #endregion
    }
}