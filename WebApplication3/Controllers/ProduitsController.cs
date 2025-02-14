//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WebApplication3.Data;
//using WebApplication3.Models;

//namespace WebApplication3.Controllers
//{
//    public class ProduitsController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public ProduitsController(ApplicationDbContext context)
//        {
//            _context = context;
//        }
       
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Produits>>> GetProduits()
//        {
//            return await _context.Produits.Include(p => p.TypeProduit).ToListAsync();
//        }
       
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Produits>> GetProduit(int id)
//        {
//            var produit = await _context.Produits.Include(p => p.TypeProduit).FirstOrDefaultAsync(p => p.Id == id);

//            if (produit == null)
//            {
//                return NotFound();
//            }

//            return produit;
//        }
      
//        [HttpPost]
//        public async Task<ActionResult<Produits>> PostProduit(Produits produit)
//        {
            
//            var typeExiste = await _context.TypeProduits.AnyAsync(t => t.Id == produit.TypeProduit.Id);
//            if (!typeExiste)
//            {
//                return BadRequest("Le TypeProduit spécifié n'existe pas.");
//            }

//            _context.Produits.Add(produit);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction(nameof(GetProduit), new { id = produit.Id }, produit);
//        }
        
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutProduit(int id, Produits produit)
//        {
//            if (id != produit.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(produit).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!_context.Produits.Any(p => p.Id == id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

      
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteProduit(int id)
//        {
//            var produit = await _context.Produits.FindAsync(id);
//            if (produit == null)
//            {
//                return NotFound();
//            }

//            _context.Produits.Remove(produit);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }
//    }

//}

