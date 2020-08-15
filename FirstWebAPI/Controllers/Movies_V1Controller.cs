using FirstWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FirstWebAPI.Controllers
{
      [ApiVersion("1.0")]                                                           // API Versioning in Query string  http://localhost:49515/api/Movies?api-version=1.0
     //[Route("api/v{version:apiVersion}/Movies")]                                 // API Versioning in URL Path       http://localhost:49515/api/v1/Movies
    //Or [Route("api/{v:apiVersion}/Movies")]                                     // API Versioning in URL Path        http://localhost:49515/api/2.0/Movies
    [Route("api/Movies")]                                                        //API Versioning in headers           http://localhost:49515/api/Movies Pass version in headers in postman. For Headers Key = x-api-version, value = 1.0, For Media Type Key=Accept, Value = application/json;v=1.0
    [ApiController]
    public class Movies_V1Controller : ControllerBase
    {
        static List<Movies_V1> movieList = new List<Movies_V1>()
        {

          new Movies_V1(){ MovieId = 1, MovieName = "Bahubali The Beginning", ReleaseYear = 2015 },
          new Movies_V1(){ MovieId = 2,MovieName = "Bahubali The Conclusion", ReleaseYear = 2017},
          new Movies_V1(){ MovieId = 3,MovieName = "Sahoo", ReleaseYear = 2019},
          };

        [HttpGet]
        public IEnumerable<Movies_V1> Get()                                                 
        {

            return movieList;
        }

        // GET: api/Movies/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Movies
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Movies/5
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
