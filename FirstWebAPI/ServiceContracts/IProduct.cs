using FirstWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebAPI.ServiceContracts
{
    public interface IProduct
    {
        #region Methods
        //CRUD Operations
        IEnumerable<Product> GetProductList();
        Product GetProduct(int id);
      
        void AddProduct(Product product);
        void UpdateProduct(int productId, Product product);
        void DeleteProduct(int productId);
        #endregion
    }
}
