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
    public class BlindRodController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BlindRodController(ApplicationDbContext context)
        {
            _context = context;
        }

        /**
         * Read all rods
         */
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rods = await _context.BlindRods.ToListAsync();
            return Ok(rods);
        }
        
        /**
         * Read a single blindRod by id
         */
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var blindRod = await _context.BlindRods.FirstOrDefaultAsync(a=>a.Id ==id);
            return Ok(blindRod);
        }
        
        /**
         * Create a new blindRod
         */
        [HttpPost]
        public async Task<IActionResult> Post(BlindRod blindRod)
        {
            _context.Add(blindRod);
            await _context.SaveChangesAsync();
            return Ok(blindRod.Id); 
        }
        
        /**
         * Update an existing BlindRod by record
         */
        [HttpPut]
        public async Task<IActionResult> Put(BlindRod blindRod)
        {
            _context.Entry(blindRod).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
        /**
         * Delete a BlindRod by id
         */
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blindRod = new BlindRod { Id = id };
            _context.Remove(blindRod);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}