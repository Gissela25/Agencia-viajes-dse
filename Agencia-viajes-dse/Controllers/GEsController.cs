using Agencia_viajes_dse.Data.Services;
using Agencia_viajes_dse.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agencia_viajes_dse.Controllers
{
    public class GEsController : Controller
    {
        private readonly IGEsService _service;


        public GEsController(IGEsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allGEs = await _service.GetAllAsync();
            return View(allGEs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Nombre")] Gastos_Extra ge)
        {
            if (!ModelState.IsValid)
            {
                await _service.AddAsync(ge);
                return RedirectToAction(nameof(Index));
            }

            return View(ge);

        }
        public async Task<IActionResult> Details(int id)
        {
            var geDetails = await _service.GetByIdAsync(id);

            if (geDetails == null) return View("NotFound");
            return View(geDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var geDetails = await _service.GetByIdAsync(id);

            if (geDetails == null) return View("NotFound");
            return View(geDetails);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, [Bind("Id, Nombre")] Gastos_Extra ge)
        {
            if (!ModelState.IsValid)
            {
                await _service.UpdateAsync(id, ge);
                return RedirectToAction(nameof(Index));
            }
            return View(ge);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var geDetails = await _service.GetByIdAsync(id);

            if (geDetails == null) return View("NotFound");
            return View(geDetails);
        }

        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DelereConfirmed(int id)
        {
            var geDetails = await _service.GetByIdAsync(id);

            if (geDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }


    }
}
