using Agencia_viajes_dse.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agencia_viajes_dse.Controllers
{
    public class DestinosController : Controller
    {
        private readonly AppDbContext _context;

        public DestinosController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allDestinos = await _context.Destinos.ToListAsync();
            return View();
        }
    }
}
