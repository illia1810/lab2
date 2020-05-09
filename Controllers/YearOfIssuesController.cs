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
    public class YearOfIssuesController : ControllerBase
    {
        private readonly AutomobilesDBContext _context;

        public YearOfIssuesController(AutomobilesDBContext context)
        {
            _context = context;
        }

        // GET: api/YearOfIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YearOfIssue>>> GetYearOfIssue()
        {
            return await _context.YearOfIssue.ToListAsync();
        }

        // GET: api/YearOfIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YearOfIssue>> GetYearOfIssue(int id)
        {
            var yearOfIssue = await _context.YearOfIssue.FindAsync(id);

            if (yearOfIssue == null)
            {
                return NotFound();
            }

            return yearOfIssue;
        }

        // PUT: api/YearOfIssues/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYearOfIssue(int id, YearOfIssue yearOfIssue)
        {
            if (id != yearOfIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(yearOfIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YearOfIssueExists(id))
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

        // POST: api/YearOfIssues
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<YearOfIssue>> PostYearOfIssue(YearOfIssue yearOfIssue)
        {
            _context.YearOfIssue.Add(yearOfIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYearOfIssue", new { id = yearOfIssue.Id }, yearOfIssue);
        }

        // DELETE: api/YearOfIssues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YearOfIssue>> DeleteYearOfIssue(int id)
        {
            var yearOfIssue = await _context.YearOfIssue.FindAsync(id);
            if (yearOfIssue == null)
            {
                return NotFound();
            }

            _context.YearOfIssue.Remove(yearOfIssue);
            await _context.SaveChangesAsync();

            return yearOfIssue;
        }

        private bool YearOfIssueExists(int id)
        {
            return _context.YearOfIssue.Any(e => e.Id == id);
        }
    }
}
