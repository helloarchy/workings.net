using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workings.Server.Data;
using workings.Shared;

namespace workings.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlindLiningController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BlindLiningController(ApplicationDbContext context)
        {
            _context = context;
        }

        /**
         * Read all linings
         */
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var linings = await _context.BlindLinings.ToListAsync();
            return Ok(linings);
        }
        
        /**
         * Read a single blindLining by id
         */
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var blindLining = await _context.BlindLinings.FirstOrDefaultAsync(a=>a.Id ==id);
            return Ok(blindLining);
        }
        
        /**
         * Create a new blindLining
         */
        [HttpPost]
        public async Task<IActionResult> Post(BlindLining blindLining)
        {
            _context.Add(blindLining);
            await _context.SaveChangesAsync();
            return Ok(blindLining.Id); 
        }
        
        /**
         * Update an existing BlindLining by record
         */
        [HttpPut]
        public async Task<IActionResult> Put(BlindLining blindLining)
        {
            _context.Entry(blindLining).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
        /**
         * Delete a BlindLining by id
         */
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blindLining = new BlindLining { Id = id };
            _context.Remove(blindLining);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}