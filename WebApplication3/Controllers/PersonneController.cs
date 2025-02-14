using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonneController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonneController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personne>>> GetPersonnes()
        {
            return await _context.Personnes
                .Include(p => p.Emplois)
                .OrderBy(p => p.Nom)
                .ToListAsync();
        }

    }
}
