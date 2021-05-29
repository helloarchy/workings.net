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
    public class BlindProfileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BlindProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        /**
         * Read all blind profiles
         */
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var blindProfiles = await _context.BlindProfiles
                .Include(bp => bp.BlindBottomBar)
                .Include(bp => bp.BlindRailing)
                .Include(bp => bp.BlindRod)
                .Include(bp => bp.BlindStack)
                .Include(bp => bp.BusinessClient)
                .ToListAsync();
            return Ok(blindProfiles);
        }

        /**
         * Read a single blind profile by id
         */
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var blindProfile = await _context.BlindProfiles
                .Include(bp => bp.BlindBottomBar)
                .Include(bp => bp.BlindRailing)
                .Include(bp => bp.BlindRod)
                .Include(bp => bp.BlindStack)
                .Include(bp => bp.BusinessClient)
                .FirstOrDefaultAsync(bp => bp.Id == id);
            return Ok(blindProfile);
        }

        /**
         * Create a new blind profile
         */
        [HttpPost]
        public async Task<IActionResult> Post(BlindProfile blindProfile)
        {
            _context.Add(blindProfile);
            await _context.SaveChangesAsync();
            return Ok(blindProfile.Id);
        }

        /**
         * Update an existing Blind Profile by record
         */
        [HttpPut]
        public async Task<IActionResult> Put(BlindProfile blindProfile)
        {
            _context.Entry(blindProfile).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /**
         * Delete a Blind Profile by id
         */
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blindProfile = new BlindProfile {Id = id};
            _context.Remove(blindProfile);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}