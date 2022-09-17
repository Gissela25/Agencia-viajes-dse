using Agencia_viajes_dse.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agencia_viajes_dse.Controllers
{
    public class ReservacionesController : Controller
    {
        private readonly AppDbContext _context;

        public ReservacionesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allReservaciones = await _context.Reservaciones.ToListAsync();
            return View();
        }
    }
}
