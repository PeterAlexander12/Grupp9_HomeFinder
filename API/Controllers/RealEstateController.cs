using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeFinder.Data;
using HomeFinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private readonly HomeFinderContext _context;

        public RealEstateController(HomeFinderContext context)
        {
            _context = context;
        }

        // GET: api/RealEstate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RealEstate>>> GetRealEstate()
        {
            return await _context.RealEstate.ToListAsync();
        }

        // GET: api/RealEstate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RealEstate>> GetRealEstate(int id)
        {
            var realEstate = await _context.RealEstate.FindAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            return realEstate;
        }

        // PUT: api/RealEstate/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRealEstate(int id, RealEstate realEstate)
        {
            if (id != realEstate.Id)
            {
                return BadRequest();
            }

            _context.Entry(realEstate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealEstateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RealEstates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RealEstate>> PostRealEstate(RealEstate realEstate)
        {
            _context.RealEstate.Add(realEstate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRealEstate", new { id = realEstate.Id }, realEstate);
        }

        // DELETE: api/RealEstate/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRealEstate(int id)
        {
            var realEstate = await _context.RealEstate.FindAsync(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            _context.RealEstate.Remove(realEstate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RealEstateExists(int id)
        {
            return _context.RealEstate.Any(e => e.Id == id);
        }
    }
}
