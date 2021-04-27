using Microsoft.AspNetCore.Mvc;
using workings.Server.Data;

namespace workings.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public ClientController(ApplicationDbContext context)
        {
            this._context = context;
        }
    }
}