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
    public class BlindStackController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BlindStackController(ApplicationDbContext context)
        {
            _context = context;
        }

        /**
         * Read all stacks
         */
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var stacks = await _context.BlindStacks.ToListAsync();
            return Ok(stacks);
        }
        
        /**
         * Read a single blindStack by id
         */
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var blindStack = await _context.BlindStacks.FirstOrDefaultAsync(a=>a.Id ==id);
            return Ok(blindStack);
        }
        
        /**
         * Create a new blindStack
         */
        [HttpPost]
        public async Task<IActionResult> Post(BlindStack blindStack)
        {
            _context.Add(blindStack);
            await _context.SaveChangesAsync();
            return Ok(blindStack.Id); 
        }
        
        /**
         * Update an existing BlindStack by record
         */
        [HttpPut]
        public async Task<IActionResult> Put(BlindStack blindStack)
        {
            _context.Entry(blindStack).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
        /**
         * Delete a BlindStack by id
         */
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blindStack = new BlindStack { Id = id };
            _context.Remove(blindStack);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}