using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workings.Server.Data;
using Workings.Shared;

namespace Workings.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlindRailingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BlindRailingController(ApplicationDbContext context)
        {
            _context = context;
        }

        /**
         * Read all railings
         */
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var railings = await _context.BlindRailings.ToListAsync();
            return Ok(railings);
        }
        
        /**
         * Read a single blindRailing by id
         */
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var blindRailing = await _context.BlindRailings.FirstOrDefaultAsync(a=>a.Id ==id);
            return Ok(blindRailing);
        }
        
        /**
         * Create a new blindRailing
         */
        [HttpPost]
        public async Task<IActionResult> Post(BlindRailing blindRailing)
        {
            _context.Add(blindRailing);
            await _context.SaveChangesAsync();
            return Ok(blindRailing.Id); 
        }
        
        /**
         * Update an existing BlindRailing by record
         */
        [HttpPut]
        public async Task<IActionResult> Put(BlindRailing blindRailing)
        {
            _context.Entry(blindRailing).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
        /**
         * Delete a BlindRailing by id
         */
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blindRailing = new BlindRailing { Id = id };
            _context.Remove(blindRailing);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}