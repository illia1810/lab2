using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cars;
using Cars.Models;

namespace Cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelCarYearsController : ControllerBase
    {
        private readonly AutomobilesDBContext _context;

        public ModelCarYearsController(AutomobilesDBContext context)
        {
            _context = context;
        }

        // GET: api/ModelCarYears
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelCarYear>>> GetModelCarYear()
        {
            return await _context.ModelCarYear.ToListAsync();
        }

        // GET: api/ModelCarYears/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelCarYear>> GetModelCarYear(int id)
        {
            var modelCarYear = await _context.ModelCarYear.FindAsync(id);

            if (modelCarYear == null)
            {
                return NotFound();
            }

            return modelCarYear;
        }

        // PUT: api/ModelCarYears/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelCarYear(int id, ModelCarYear modelCarYear)
        {
            if (id != modelCarYear.Id)
            {
                return BadRequest();
            }

            _context.Entry(modelCarYear).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelCarYearExists(id))
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

        // POST: api/ModelCarYears
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ModelCarYear>> PostModelCarYear(ModelCarYear modelCarYear)
        {
            _context.ModelCarYear.Add(modelCarYear);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModelCarYear", new { id = modelCarYear.Id }, modelCarYear);
        }

        // DELETE: api/ModelCarYears/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ModelCarYear>> DeleteModelCarYear(int id)
        {
            var modelCarYear = await _context.ModelCarYear.FindAsync(id);
            if (modelCarYear == null)
            {
                return NotFound();
            }

            _context.ModelCarYear.Remove(modelCarYear);
            await _context.SaveChangesAsync();

            return modelCarYear;
        }

        private bool ModelCarYearExists(int id)
        {
            return _context.ModelCarYear.Any(e => e.Id == id);
        }
    }
}
