using FirstWebAPI.Data;
using FirstWebAPI.Models;
using FirstWebAPI.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        IProduct product;
        ProductsDbContext productDbContext;
        public ProductsController(IProduct iProduct)
        {

            this.product = iProduct;
        }

        private static List<Product> productList = new List<Product>();

        [HttpGet("GetProductList")]                                 //http://localhost:49515/api/products/GetProductList query string

        public IEnumerable<Product> GetProductList()
        {
            return product.GetProductList();
        }



        [HttpGet("GetProduct")]                      //http://localhost:49515/api/products/GetProduct?id=1 query string
        public IActionResult GetProduct(int id)
        {
            var result = product.GetProduct(id);
            return Ok(result);
        }



        [HttpGet("SortedResult")]                                   //http://localhost:49515/api/products/SortedResult?sortPrice=desc query string
        public IEnumerable<Product> SortedResult(string sortPrice)
        {
            IQueryable<Product> products;
            switch (sortPrice)
            {
                case "desc":
                    products = productDbContext.Products.OrderByDescending(p => p.ProductPrice);
                    break;
                case "asc":
                    products = productDbContext.Products.OrderBy(p => p.ProductPrice);
                    break;
                default:
                    products = productDbContext.Products;

                    break;
            }
            return products;
        }



        [HttpGet("GetPaging")]
        public IEnumerable<Product> GetPaging(int? pageNumber, int? PageSize)            // "?" is to check if object is null
        {                                                                               // http://localhost:49515/api/products?pageNumber=3&PageSize=2
            int pageNum = pageNumber ?? 1;                                             // http://localhost:49515/api/products?pageNumber=&PageSize=
            int pageSize = PageSize ?? 2;                                             // Parameters are given null and null paramters are handled with ? operator
            var result = from p in productDbContext.Products.OrderBy(a => a.ProductId) select p;
            var items = result.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();              //Skip method skips the result of the page, take will take the size of the page by skipping the specified result
            return items;
        }


        [HttpGet("GetSearching")]
        public IEnumerable<Product> GetSearching(string searchProduct)
        {
            var result = productDbContext.Products.Where(p => p.ProductName.Contains(searchProduct)).ToList();
            return result;
        }



        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Product data is inavlid");
            }
            product.AddProduct(p);
            return Ok("Product Added");
        }


        [HttpPut("{id}", Name = "UpdateProduct")]                                //http://localhost:49515/api/products/Put?productId=3 query string

        public IActionResult UpdateProduct(int productId, Product p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (productId != p.ProductId)
            {
                return BadRequest("Id not equal");
            }
            product.UpdateProduct(productId, p);
            return StatusCode(StatusCodes.Status201Created);
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int productId)
        {
            // productDbContext.Products.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            product.DeleteProduct(productId);
            return Ok("Product Deleted");
        }
    }
}