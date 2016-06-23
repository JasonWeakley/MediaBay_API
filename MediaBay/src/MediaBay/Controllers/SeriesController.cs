using MediaBay.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaBay.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("AllowNewDevelopmentEnvironment")]
    public class SeriesController : Controller
    {
        // By creating a private context you allow yourself to 
        // work with a "copy" of the DB that you then will be 
        // able to use in the GET, POST, PUT, & DELETE methods below.
        private MediaBayContext _context;

        public SeriesController(MediaBayContext context)
        {
            _context = context;
        }

        // GET api/series
        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // the _context.NameOfDbContext is "Series"
            IQueryable<Series> productSeries = from s in _context.Series
                                           select s;

            if (productSeries == null)
            {
                return NotFound();
            }

            return Ok(productSeries);

        }

        // GET api/series/5
        [HttpGet("{id}", Name = "GetSeries")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Series series = _context.Series.Single(m => m.SeriesId == id);

            if (series == null)
            {
                return NotFound();
            }

            return Ok(series);
        }

        // POST api/series
        [EnableCors("AllowNewDevelopmentEnvironment")]
        [HttpPost]
        public IActionResult Post([FromBody]Series series)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Series.Add(series);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SeriesExists(series.SeriesId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetSeries", new { id = series.SeriesId }, series);
        }

        // PUT api/series
        //[HttpPut("{id}")]
        // For some reason [HttpPut] doesn't work here, and I don't know why, 
        // even though it works this way on ProductController.

        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody] Series series)
        {
            //series.SeriesId = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(series).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeriesExists(id))
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

        // DELETE api/series/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Series series = _context.Series.Single(m => m.SeriesId == id);
            if (series == null)
            {
                return NotFound();
            }

            _context.Series.Remove(series);
            _context.SaveChanges();

            return Ok(series);
        }

        private bool SeriesExists(int id)
        {
            return _context.Series.Count(e => e.SeriesId == id) > 0;
        }

    }
}
