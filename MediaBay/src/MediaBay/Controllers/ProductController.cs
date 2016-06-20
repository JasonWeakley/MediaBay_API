using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MediaBay.Models;

// For more information on enabling Web API for empty projects, 
// visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MediaBay.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("AllowNewDevelopmentEnvironment")]
    public class ProductController : Controller
    {
        // By creating a private context you allow yourself to 
        // work with a "copy" of the DB that you then will be 
        // able to use in the GET, POST, PUT, & DELETE methods below.
        private MediaBayContext _context;

        public ProductController(MediaBayContext context)
        {
            _context = context;
        }



        // GET: api/admin
        //[HttpGet("{id}", Name = "Product")]
        [HttpGet]
        public IActionResult GetProduct([FromQuery] int? adminId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (adminId == null)
            //{
            //    return BadRequest();
            //}

            // the _context.NameOfDbContext is Products
            IQueryable<Product> adminProducts = from p in _context.Products select p;
                                          
                                          //select new Product
                                          //{
                                          //    Name = p.Name
                                          //});
           if(adminProducts == null)
            {
                return NotFound();
            }

            return Ok(adminProducts);

        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
