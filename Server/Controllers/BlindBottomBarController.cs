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
    public class BlindBottomBarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BlindBottomBarController(ApplicationDbContext context)
        {
            _context = context;
        }

        /**
         * Read all Bottom Bars
         */
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bottomBars = await _context.BlindBottomBars.ToListAsync();
            return Ok(bottomBars);
        }
        
        /**
         * Read a single Blind Bottom Bar by id
         */
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var blindBottomBar = await _context.BlindBottomBars.FirstOrDefaultAsync(a=>a.Id ==id);
            return Ok(blindBottomBar);
        }
        
        /**
         * Create a new Blind Bottom Bar
         */
        [HttpPost]
        public async Task<IActionResult> Post(BlindBottomBar blindBottomBar)
        {
            _context.Add(blindBottomBar);
            await _context.SaveChangesAsync();
            return Ok(blindBottomBar.Id); 
        }
        
        /**
         * Update an existing Blind Bottom Bar by record
         */
        [HttpPut]
        public async Task<IActionResult> Put(BlindBottomBar blindBottomBar)
        {
            _context.Entry(blindBottomBar).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
        /**
         * Delete a Blind Bottom Bar by id
         */
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blindBottomBar = new BlindBottomBar { Id = id };
            _context.Remove(blindBottomBar);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}