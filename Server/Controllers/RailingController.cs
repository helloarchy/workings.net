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
    public class RailingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RailingController(ApplicationDbContext context)
        {
            _context = context;
        }

        /**
         * Read all railings
         */
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var railings = await _context.Railings.ToListAsync();
            return Ok(railings);
        }
        
        /**
         * Read a single railing by id
         */
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var railing = await _context.Railings.FirstOrDefaultAsync(a=>a.Id ==id);
            return Ok(railing);
        }
        
        /**
         * Create a new railing
         */
        [HttpPost]
        public async Task<IActionResult> Post(Railing railing)
        {
            _context.Add(railing);
            await _context.SaveChangesAsync();
            return Ok(railing.Id); 
        }
        
        /**
         * Update an existing Railing by record
         */
        [HttpPut]
        public async Task<IActionResult> Put(Railing railing)
        {
            _context.Entry(railing).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
        /**
         * Delete a Railing by id
         */
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var railing = new Railing { Id = id };
            _context.Remove(railing);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}