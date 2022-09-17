using Agencia_viajes_dse.Data;
using Agencia_viajes_dse.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agencia_viajes_dse.Controllers
{
    public class DestinosController : Controller
    {
        private readonly IDestinosService _service;

        public DestinosController(IDestinosService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allDestinos = await _service.GetAllAsync();
            return View(allDestinos);
        }
    }
}
