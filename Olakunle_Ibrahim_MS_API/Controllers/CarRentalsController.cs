using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Olakunle_Ibrahim_MS_API.Models;

namespace Olakunle_Ibrahim_MS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRentalsController : ControllerBase
    {
        private readonly chateragent _context;

        public CarRentalsController(chateragent context)
        {
            _context = context;
        }

        // GET: api/CarRentals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarRental>>> GetCarRental()
        {
            return await _context.CarRental.ToListAsync();
        }

        // GET: api/CarRentals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarRental>> GetCarRental(string id)
        {
            var carRental = await _context.CarRental.FindAsync(id);

            if (carRental == null)
            {
                return NotFound();
            }

            return carRental;
        }

        // PUT: api/CarRentals/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarRental(string id, CarRental carRental)
        {
            if (id != carRental.CompanyCode)
            {
                return BadRequest();
            }

            _context.Entry(carRental).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarRentalExists(id))
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

        // POST: api/CarRentals
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CarRental>> PostCarRental(CarRental carRental)
        {
            _context.CarRental.Add(carRental);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CarRentalExists(carRental.CompanyCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCarRental", new { id = carRental.CompanyCode }, carRental);
        }

        // DELETE: api/CarRentals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarRental>> DeleteCarRental(string id)
        {
            var carRental = await _context.CarRental.FindAsync(id);
            if (carRental == null)
            {
                return NotFound();
            }

            _context.CarRental.Remove(carRental);
            await _context.SaveChangesAsync();

            return carRental;
        }

        private bool CarRentalExists(string id)
        {
            return _context.CarRental.Any(e => e.CompanyCode == id);
        }
    }
}
