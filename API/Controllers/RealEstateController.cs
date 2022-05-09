using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        readonly IRealEstateRepository _repository;

        public RealEstateController(IRealEstateRepository repository)
        {
            _repository = repository;
        }

        // GET: api/RealEstatelist
        [HttpGet("list")]
        public async Task<ActionResult<List<RealEstateVm>>> GetRealEstates()
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
        public async Task<ActionResult<RealEstateVm>> GetRealEstate(int id)
        {
            try
            {
                var realEstate = await _repository.GetRealEstateAsync(id);

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

        // GET: api/RealEstate/byaddress/address
        [HttpGet("byaddress/{address}")]
        public async Task<ActionResult<RealEstateVm>> GetRealEstate(string address)
        {

            try
            {
                var model = await _repository.GetRealEstateAsync(address);

                if (model is null)
                {
                    return NotFound($"Vi kunde inte hitta någon fastighet med adress {address}.");
                }

                return Ok(model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // PUT: api/RealEstate/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRealEstate(int id, PostRealEstateVm model)
        {
            try
            {
                await _repository.UpdateRealEstateAsync(id, model);

                if (await _repository.SaveAllAsync())
                {
                    return NoContent();
                }

                return StatusCode(500, "Ett fel inträffade när fastigheten skulle uppdateras");
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        // PATCH: api/RealEstate/5
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateRealEstate(int id, PatchRealEstateVm model)
        {
            try
            {
                await _repository.UpdateRealEstateAsync(id, model);

                if (await _repository.SaveAllAsync())
                {
                    return NoContent();
                }

                return StatusCode(500, "Ett fel inträffade när fastigheten skulle uppdateras");
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/RealEstates
        [HttpPost]
        public async Task<ActionResult> AddRealEstate(PostRealEstateVm model)
        {

            try
            {
                if (await _repository.GetRealEstateAsync(model.Address) is not null)
                {
                    return BadRequest($"Det finns redan en fastighet registrerad på angiven adress.");
                }

                await _repository.AddRealEstateAsync(model);

                return await _repository.SaveAllAsync() ? StatusCode(201) : StatusCode(500, "Det gick inte att spara fastigheten");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        // DELETE: api/RealEstate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRealEstate(int id)
        {
            try
            {
                await _repository.DeleteRealEstateAsync(id);

                if (await _repository.SaveAllAsync())
                {
                    return NoContent();
                }

                return StatusCode(500, "Ett fel har inträffat");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
    }
}
