using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpendingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SpendingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Spendings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spending>>> GetSpendings()
        {
            return await _context.Spendings.ToListAsync();
        }

        // GET: api/Spendings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Spending>> GetSpending(int id)
        {
            var spending = await _context.Spendings.FindAsync(id);

            if (spending == null)
            {
                return NotFound();
            }

            return spending;
        }

        // PUT: api/Spendings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpending(int id, Spending spending)
        {
            if (id != spending.Id)
            {
                return BadRequest();
            }

            _context.Entry(spending).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpendingExists(id))
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

        // POST: api/Spendings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Spending>> PostSpending(Spending spending)
        {
            _context.Spendings.Add(spending);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpending", new { id = spending.Id }, spending);
        }

        // DELETE: api/Spendings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpending(int id)
        {
            var spending = await _context.Spendings.FindAsync(id);
            if (spending == null)
            {
                return NotFound();
            }

            _context.Spendings.Remove(spending);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpendingExists(int id)
        {
            return _context.Spendings.Any(e => e.Id == id);
        }
    }
}
