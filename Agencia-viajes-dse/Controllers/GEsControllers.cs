using Agencia_viajes_dse.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agencia_viajes_dse.Controllers
{
    public class GEsControllers : Controller
    {

        private readonly AppDbContext _context;

        public GEsControllers(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allGEs = await _context.Gastos_Extras.ToListAsync();
            return View();
        }
    }
}
