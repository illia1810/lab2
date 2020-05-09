using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cars.Models;

namespace Cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceCategoriesController : ControllerBase
    {
        private readonly AutomobilesDBContext _context;

        public PriceCategoriesController(AutomobilesDBContext context)
        {
            _context = context;
        }

        // GET: api/PriceCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriceCategory>>> GetPriceCategory()
        {
            return await _context.PriceCategory.ToListAsync();
        }

        // GET: api/PriceCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PriceCategory>> GetPriceCategory(int id)
        {
            var priceCategory = await _context.PriceCategory.FindAsync(id);

            if (priceCategory == null)
            {
                return NotFound();
            }

            return priceCategory;
        }

        // PUT: api/PriceCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPriceCategory(int id, PriceCategory priceCategory)
        {
            if (id != priceCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(priceCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceCategoryExists(id))
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

        // POST: api/PriceCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PriceCategory>> PostPriceCategory(PriceCategory priceCategory)
        {
            _context.PriceCategory.Add(priceCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPriceCategory", new { id = priceCategory.Id }, priceCategory);
        }

        // DELETE: api/PriceCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PriceCategory>> DeletePriceCategory(int id)
        {
            var priceCategory = await _context.PriceCategory.FindAsync(id);
            if (priceCategory == null)
            {
                return NotFound();
            }

            _context.PriceCategory.Remove(priceCategory);
            await _context.SaveChangesAsync();

            return priceCategory;
        }

        private bool PriceCategoryExists(int id)
        {
            return _context.PriceCategory.Any(e => e.Id == id);
        }
    }
}
