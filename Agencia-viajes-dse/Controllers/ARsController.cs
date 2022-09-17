using Agencia_viajes_dse.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agencia_viajes_dse.Controllers
{
    public class ARsController : Controller
    {
        private readonly AppDbContext _context;

        public ARsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allARs = await _context.ARS.ToListAsync();
            return View();
        }
    }
}
