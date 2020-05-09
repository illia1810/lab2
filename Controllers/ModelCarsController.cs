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
    public class ModelCarsController : ControllerBase
    {
        private readonly AutomobilesDBContext _context;

        public ModelCarsController(AutomobilesDBContext context)
        {
            _context = context;
        }

        // GET: api/ModelCars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelCar>>> GetModelCar()
        {
            return await _context.ModelCar.ToListAsync();
        }

        // GET: api/ModelCars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelCar>> GetModelCar(int id)
        {
            var modelCar = await _context.ModelCar.FindAsync(id);

            if (modelCar == null)
            {
                return NotFound();
            }

            return modelCar;
        }

        // PUT: api/ModelCars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelCar(int id, ModelCar modelCar)
        {
            if (id != modelCar.Id)
            {
                return BadRequest();
            }

            _context.Entry(modelCar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelCarExists(id))
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

        // POST: api/ModelCars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ModelCar>> PostModelCar(ModelCar modelCar)
        {
            _context.ModelCar.Add(modelCar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModelCar", new { id = modelCar.Id }, modelCar);
        }

        // DELETE: api/ModelCars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ModelCar>> DeleteModelCar(int id)
        {
            var modelCar = await _context.ModelCar.FindAsync(id);
            if (modelCar == null)
            {
                return NotFound();
            }

            _context.ModelCar.Remove(modelCar);
            await _context.SaveChangesAsync();

            return modelCar;
        }

        private bool ModelCarExists(int id)
        {
            return _context.ModelCar.Any(e => e.Id == id);
        }
    }
}
