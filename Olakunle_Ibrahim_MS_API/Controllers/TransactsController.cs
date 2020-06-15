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
    public class TransactsController : ControllerBase
    {
        private readonly chateragent _context;

        public TransactsController(chateragent context)
        {
            _context = context;
        }

        // GET: api/Transacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transact>>> GetTransact()
        {
            return await _context.Transact.ToListAsync();
        }

        // GET: api/Transacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transact>> GetTransact(int id)
        {
            var transact = await _context.Transact.FindAsync(id);

            if (transact == null)
            {
                return NotFound();
            }

            return transact;
        }

        // PUT: api/Transacts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransact(int id, Transact transact)
        {
            if (id != transact.TransactId)
            {
                return BadRequest();
            }

            _context.Entry(transact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactExists(id))
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

        // POST: api/Transacts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Transact>> PostTransact(Transact transact)
        {
            _context.Transact.Add(transact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransact", new { id = transact.TransactId }, transact);
        }

        // DELETE: api/Transacts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Transact>> DeleteTransact(int id)
        {
            var transact = await _context.Transact.FindAsync(id);
            if (transact == null)
            {
                return NotFound();
            }

            _context.Transact.Remove(transact);
            await _context.SaveChangesAsync();

            return transact;
        }

        private bool TransactExists(int id)
        {
            return _context.Transact.Any(e => e.TransactId == id);
        }
    }
}
