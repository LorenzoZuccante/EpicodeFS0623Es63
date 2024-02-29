using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScarpaMondo.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ScarpaMondo.Controllers
{
    public class ArticoloController : Controller
    {
        private readonly ScarpaMondoContext _context;

        public ArticoloController(ScarpaMondoContext context)
        {
            _context = context;
        }

        // GET: Articolo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Articoli.Where(a => !a.IsDeleted).ToListAsync()); // Mostra solo articoli non soft-deleted
        }

        // GET: Articolo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articolo = await _context.Articoli
                .FirstOrDefaultAsync(m => m.ArticoloId == id && !m.IsDeleted); // Controlla anche IsDeleted qui
            if (articolo == null)
            {
                return NotFound();
            }

            return View(articolo);
        }

        // GET: Articolo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articolo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticoloId,Nome,Prezzo,Descrizione,ImmagineCopertinaUrl,ImmagineAggiuntiva1Url,ImmagineAggiuntiva2Url,InVetrina")] Articolo articolo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articolo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articolo);
        }

        // GET: Articolo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articolo = await _context.Articoli.FindAsync(id);
            if (articolo == null || articolo.IsDeleted) // Verifica anche se l'articolo è stato soft-deleted
            {
                return NotFound();
            }
            return View(articolo);
        }

        // POST: Articolo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticoloId,Nome,Prezzo,Descrizione,ImmagineCopertinaUrl,ImmagineAggiuntiva1Url,ImmagineAggiuntiva2Url,InVetrina")] Articolo articolo)
        {
            if (id != articolo.ArticoloId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articolo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticoloExists(articolo.ArticoloId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(articolo);
        }

        // Soft Delete action
        public async Task<IActionResult> SoftDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articolo = await _context.Articoli.FindAsync(id);
            if (articolo == null)
            {
                return NotFound();
            }

            articolo.IsDeleted = true; // Setta IsDeleted su true invece di rimuovere fisicamente
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Articolo/Delete/5 for hard delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articolo = await _context.Articoli
                .FirstOrDefaultAsync(m => m.ArticoloId == id);
            if (articolo == null || articolo.IsDeleted) // Considera anche IsDeleted qui
            {
                return NotFound();
            }

            return View(articolo);
        }

        // POST: Articolo/Delete/5 for hard delete
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articolo = await _context.Articoli.FindAsync(id);
            if (articolo != null)
            {
                _context.Articoli.Remove(articolo);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ArticoloExists(int id)
        {
            return _context.Articoli.Any(e => e.ArticoloId == id);
        }
    }
}
