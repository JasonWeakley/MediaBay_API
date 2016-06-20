using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MediaBay.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

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

            // the _context.NameOfDbContext is "Product"
            IQueryable<Product> products = from p in _context.Product
                                                select p;
                                          
            if(products == null)
            {
                return NotFound();
            }

            return Ok(products);

        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Product.Add(product);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.ProductId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetProduct", new { id = product.ProductId }, product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            product.ProductId = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product product = _context.Product.Single(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            _context.SaveChanges();

            return Ok(product);
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Count(e => e.ProductId == id) > 0;
        }
    }
}
