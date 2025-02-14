using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmploiController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Récupère toutes les emplois enregistrées
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emploi>>> GetEmplois()
        {
            return await _context.Emplois.ToListAsync();
        }
        /// <summary>
        /// Récupère toutes les emplois par ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Emploi>> GetEmplois(int id)
        {
            var emploi = await _context.Emplois.FirstOrDefaultAsync(p => p.Id == id);

            if (emploi == null)
            {
                return NotFound();
            }

            return emploi;
        }
        /// <summary>
        /// Enregistre un emploi pour une personne
        /// </summary>
        [HttpPost("{personneId}/Emplois")]
        public async Task<IActionResult> PostEmplois(int personneId, [FromBody] Emploi emploi)
        {
            var personne = await _context.Personnes.FindAsync(personneId);

            if (personne == null)
            {
                return NotFound(new { message = "Utilisateur non trouvée." });
            }
            if (emploi == null)
            {
                return NotFound(new { message = "Cet untilisateur n'est pas dans la bdd" });
            }
            if (emploi.DateDebut == null)
            {
                return BadRequest(new { message = "La date de début d'emploi est obligatoire." });
            }
            if (emploi.DateDebut > DateTime.Now)
            {
                return BadRequest(new { message = "La date de début ne peut pas être inférieure à aujourd'hui." });
            }
            _context.Emplois.Add(emploi);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmplois), new { id = emploi.Id }, emploi);

        }
    }
}
