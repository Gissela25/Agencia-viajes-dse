using Agencia_viajes_dse.Data;
using Agencia_viajes_dse.Data.Services;
using Agencia_viajes_dse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agencia_viajes_dse.Controllers
{
    public class ARsController : Controller
    {
        private readonly IARsService _service;

        public ARsController(IARsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allARs = await _service.GetAllAsync();
            return View(allARs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Nombre, Descripcion")] AR ar)
        {
            if (!ModelState.IsValid)
            {
                await _service.AddAsync(ar);
                return RedirectToAction(nameof(Index));
            }

            return View(ar);

        }
        public async Task<IActionResult> Details(int id)
        {
            var arDetails = await _service.GetByIdAsync(id);

            if (arDetails == null) return View("NotFound");
            return View(arDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var arDetails = await _service.GetByIdAsync(id);

            if (arDetails == null) return View("NotFound");
            return View(arDetails);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, [Bind("Id, Nombre, Descripcion")] AR ar)
        {
            if (!ModelState.IsValid)
            {
                await _service.UpdateAsync(id, ar);
                return RedirectToAction(nameof(Index));
            }
            return View(ar);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var arDetails = await _service.GetByIdAsync(id);

            if (arDetails == null) return View("NotFound");
            return View(arDetails);
        }

        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arDetails = await _service.GetByIdAsync(id);
            if (arDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }

  
    }
}
