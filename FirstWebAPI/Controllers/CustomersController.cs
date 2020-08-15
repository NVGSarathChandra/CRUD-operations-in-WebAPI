using FirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace FirstWebAPI
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static List<Customers> customerList = new List<Customers>()
        {
            new Customers(){CustomerID=1,email="",phoneNumber="35000"},
            new Customers(){CustomerID=2,email="",phoneNumber="37000"},
          new Customers(){  CustomerID=3,email="",phoneNumber="36000" }
        };


        [HttpGet("GetCustomerList")]
        public IActionResult GetCustomerList()
        {
                return Ok(customerList);

        }


        [HttpPost]
        public IActionResult Post([FromBody] Customers Customer)
        {
            if (ModelState.IsValid)
            {
            customerList.Add(Customer);
                return Ok(StatusCodes.Status201Created);

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}