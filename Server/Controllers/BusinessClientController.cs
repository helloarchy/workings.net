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
    public class BusinessClientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BusinessClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        /**
         * Read all business clients
         */
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var businessClients = await _context.BusinessClients.ToListAsync();
            return Ok(businessClients);
        }
        
        /**
         * Read a single business client by id
         */
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var businessClient = await _context.BusinessClients.FirstOrDefaultAsync(a=>a.Id ==id);
            return Ok(businessClient);
        }
        
        /**
         * Create a new business client
         */
        [HttpPost]
        public async Task<IActionResult> Post(BusinessClient businessClient)
        {
            _context.Add(businessClient);
            await _context.SaveChangesAsync();
            return Ok(businessClient.Id); 
        }
        
        /**
         * Update an existing Business Client by record
         */
        [HttpPut]
        public async Task<IActionResult> Put(BusinessClient businessClient)
        {
            _context.Entry(businessClient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
        /**
         * Delete a Business Client by id
         */
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var businessClient = new BusinessClient { Id = id };
            _context.Remove(businessClient);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}