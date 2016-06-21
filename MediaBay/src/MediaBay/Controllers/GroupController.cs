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
    public class GroupController : Controller
    {
        // By creating a private context you allow yourself to 
        // work with a "copy" of the DB that you then will be 
        // able to use in the GET, POST, PUT, & DELETE methods below.
        private MediaBayContext _context;

        public GroupController(MediaBayContext context)
        {
            _context = context;
        }

        // GET api/group
        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // the _context.NameOfDbContext is "Series"
            IQueryable<Group> productGroups = from g in _context.Group
                                              select g;

            if (productGroups == null)
            {
                return NotFound();
            }

            return Ok(productGroups);
        }

        // When in Postman, never, ever, submit POST or PUT inside [], only {}.
        // POST api/group
        [HttpPost]
        public IActionResult Post([FromBody]Group newGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Group.Add(newGroup);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GroupExists(newGroup.GroupId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetGroup", new { id = newGroup.GroupId }, newGroup);
        }

        // When in Postman, never, ever, submit POST or PUT inside [], only {}.
        // PUT api/group
        [HttpPut]
        public IActionResult Put(int id,[FromBody]Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(group).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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
        
        // DELETE api/group
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Group group = _context.Group.Single(m => m.GroupId == id);
            if (group == null)
            {
                return NotFound();
            }

            _context.Group.Remove(group);
            _context.SaveChanges();

            return Ok(group);
        }

        private bool GroupExists(int id)
        {
            return _context.Group.Count(e => e.GroupId == id) > 0;
        }
    }
}
