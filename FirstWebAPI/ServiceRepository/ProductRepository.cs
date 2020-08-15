using FirstWebAPI.Data;
using FirstWebAPI.Models;
using FirstWebAPI.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstWebAPI.ServiceRepository
{
    public class ProductRepository : IProduct
    {
        private ProductsDbContext productDbContext;
        public ProductRepository(ProductsDbContext productsDbContext)
        {
            this.productDbContext = productsDbContext;
        }

        public Product GetProduct(int id)
        {
            var result = productDbContext.Products.SingleOrDefault(n => n.ProductId == id);
            if (result == null)
            {
                throw new Exception("Invalid Id, Data not found");
            }
            return result;
        }

        public IEnumerable<Product> GetProductList()
        {
            return productDbContext.Products;
        }


        public void AddProduct(Product product)
        {

            try
            {
                productDbContext.Add(product);
                productDbContext.SaveChanges(true);


            }
            catch (Exception ex)
            {
                throw new Exception("Cannot update data. " + ex.Message);
            }
        }

        

        public void UpdateProduct(int productId, Product product)
        {

            if (productId != product.ProductId)
            {
                throw new Exception("Invalid ID");
            }
            try
            {
                productDbContext.Products.Update(product);
                productDbContext.SaveChanges(true);

            }
            catch (Exception ex)
            {
                throw new Exception("Cannot update prroduct ---->" + ex.Message);
            }
        }

        public void DeleteProduct(int productId)
        {
            try
            {
                var result = productDbContext.Products.Find(productId);
                productDbContext.Products.Remove(result);
                productDbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Cannot delete prroduct, Id not found ------>" + ex.Message);
            }
        }

    }
}
