using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScarpaMondo.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ScarpaMondo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ScarpaMondoContext _context;

        public HomeController(ILogger<HomeController> logger, ScarpaMondoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var articoliInVetrina = await _context.Articoli
                .Where(a => a.InVetrina && !a.IsDeleted)
                .ToListAsync();
            return View(articoliInVetrina);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
