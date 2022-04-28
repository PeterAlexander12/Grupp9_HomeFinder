using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
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
        readonly IRealEstateRepository _repository;

        public RealEstateController(HomeFinderContext context, IRealEstateRepository repository)
        {
            _repository = repository;
        }

        // GET: api/RealEstate
        [HttpGet]
        public async Task<ActionResult> GetRealEstates()
        {
            try
            {
                return Ok(await _repository.GetRealEstates());

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // GET: api/RealEstate/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetRealEstate(int id)
        {
            try
            {
                var realEstate = await _repository.GetRealEstate(id);

                if (realEstate == null)
                {
                    return NotFound();
                }

                return Ok(realEstate);
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // PUT: api/RealEstate/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<RealEstate>> PutRealEstate(RealEstate realEstate)
        {
            try
            {
                var realEstateToUpdate = await _repository.GetRealEstate(realEstate.Id);

                if (realEstateToUpdate == null)
                {
                    return NotFound($"RealEstate with Id = {realEstate.Id} not found");
                }

                return await _repository.UpdateRealEstate(realEstate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
            
        }

        // POST: api/RealEstates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RealEstate>> PostRealEstate(RealEstate realEstate)
        {
            try
            {
                if (realEstate == null)
                {
                    return BadRequest();
                }

                var newRealEstate = await _repository.AddRealEstate(realEstate);
                return CreatedAtAction(nameof(GetRealEstate), new { id = newRealEstate.Id }, newRealEstate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new RealEstate");

            }


        }

        // DELETE: api/RealEstate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RealEstate>> DeleteRealEstate(int id)
        {
            try
            {
                var realEstateToDelete = await _repository.GetRealEstate(id);

                if (realEstateToDelete == null)
                {
                    return NotFound($"RealEstate with Id = {id} not found");
                }

                return await _repository.DeleteRealEstate(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }

        //private bool RealEstateExists(int id)
        //{
        //    return _context.RealEstate.Any(e => e.Id == id);
        //}
    }
}
