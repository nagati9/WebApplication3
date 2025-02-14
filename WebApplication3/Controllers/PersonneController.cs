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

        /// <summary>
        /// Récupère toutes les personnes enregistrées
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personne>>> GetPersonnes()
        {
            return await _context.Personnes
                .Include(p => p.Emplois)
                .OrderBy(p => p.Nom)
                .ToListAsync();
        }

        /// <summary>
        /// Récupère la personne enregistrée par ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Personne>> GetPersonnes(int id)
        {
            var personne = await _context.Personnes.Include(p => p.Emplois).FirstOrDefaultAsync(p => p.Id == id);

            if (personne == null)
            {
                return NotFound();
            }

            return personne;
        }

        /// <summary>
        /// Enregistre une nouvelle personne 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> PostPersonnes(Personne personne)
        {
            if (personne == null)
            {
                return NotFound(new { message = "Cet untilisateur n'est pas dans la bdd" });
            }
            _context.Personnes.Add(personne);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPersonnes), new { id = personne.Id }, personne);

        }
    }
}
