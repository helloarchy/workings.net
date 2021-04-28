using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workings.Server.Data;
using workings.Shared;

namespace workings.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        /**
         * Read all clients
         */
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clients = await _context.Clients.ToListAsync();
            return Ok(clients);
        }
        
        /**
         * Read a single businessClient by id
         */
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(a=>a.Id ==id);
            return Ok(client);
        }
        
        /**
         * Create a new businessClient
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