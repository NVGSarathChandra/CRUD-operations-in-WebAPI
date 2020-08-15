using FirstWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FirstWebAPI.Controllers
{
    [ApiVersion("2.0")]                                                         // API Versioning in Query string  http://localhost:49515/api/Movies?api-version=2.0
    //[Route("api/v{version:apiVersion}/Movies")]                              // API Versioning in URL Path       http://localhost:49515/api/v2/Movies
    //Or [Route("api/{v:apiVersion}/Movies")]                                 // API Versioning in URL Path        http://localhost:49515/api/2.0/Movies
    [Route("api/Movies")]                                                    //API Versioning in headers           http://localhost:49515/api/Movies Pass version in headers in postman. For Headers Key= x-api-version, value = 2.0, For Media Type Key=Accept, Value= application/json;v=2.0
    [ApiController]
    public class Movies_v2Controller : ControllerBase
    {
        static List<Movies_v2> moviesList = new List<Movies_v2>()
        {
             new Movies_v2(){ MovieId = 1, MovieName = "Sahoo",  LeadActor= "Prabhas"},
             new Movies_v2(){ MovieId = 2,MovieName = "Temper", LeadActor = "Jr. NTR"},
             new Movies_v2(){ MovieId = 3,MovieName = "Maharshi", LeadActor = "Mahesh"}
        };


        // GET: api/Movies_v2
        [HttpGet]
        public IEnumerable<Movies_v2> Get()
        {
            return moviesList;
        }

        // GET: api/Movies_v2/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Movies_v2
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Movies_v2/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
