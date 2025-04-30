using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication23.ModelsDB;

namespace WebApplication23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsInCountriesController : ControllerBase
    {
        private readonly PlantsContext _context;

        public PlantsInCountriesController(PlantsContext context)
        {
            _context = context;
        }

        // GET: api/PlantsInCountries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantsInCountry>>> GetPlantsInCountries()
        {
            return await _context.PlantsInCountries.ToListAsync();
        }

        // GET: api/PlantsInCountries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantsInCountry>> GetPlantsInCountry(int id)
        {
            var plantsInCountry = await _context.PlantsInCountries.FindAsync(id);

            if (plantsInCountry == null)
            {
                return NotFound();
            }

            return plantsInCountry;
        }

        // PUT: api/PlantsInCountries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantsInCountry(int id, PlantsInCountry plantsInCountry)
        {
            if (id != plantsInCountry.Страна)
            {
                return BadRequest();
            }

            _context.Entry(plantsInCountry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantsInCountryExists(id))
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

        // POST: api/PlantsInCountries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlantsInCountry>> PostPlantsInCountry(PlantsInCountry plantsInCountry)
        {
            _context.PlantsInCountries.Add(plantsInCountry);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlantsInCountryExists(plantsInCountry.Страна))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlantsInCountry", new { id = plantsInCountry.Страна }, plantsInCountry);
        }

        // DELETE: api/PlantsInCountries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlantsInCountry(int id)
        {
            var plantsInCountry = await _context.PlantsInCountries.FindAsync(id);
            if (plantsInCountry == null)
            {
                return NotFound();
            }

            _context.PlantsInCountries.Remove(plantsInCountry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlantsInCountryExists(int id)
        {
            return _context.PlantsInCountries.Any(e => e.Страна == id);
        }
    }
}
