using Agencia_viajes_dse.Data;
using Agencia_viajes_dse.Data.Services;
using Agencia_viajes_dse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<IActionResult> Filter(string searchString)
        {
            var allDestinos = await _service.GetAllAsync();
            if(!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allDestinos.Where(n => n.Nombre.Contains(searchString) || n.Descripcion.Contains(searchString)
                || n.TLugar.ToString().Contains(searchString)
                || n.TDestino.ToString().Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
            return View("Index", allDestinos);
        }

        public async Task<IActionResult> Filters(string searchByPlace, string searhByDestination, string searhByPrice)
        {
            var allDestinos = await _service.GetAllAsync();
            //if (!string.IsNullOrEmpty(searchByPlace) || !string.IsNullOrEmpty(searhByDestination))
            //{
            //    var filteredResult = allDestinos.Where(n => n.TLugar.ToString().Contains(searchByPlace)
            //    & n.TDestino.ToString().Contains(searhByDestination)
            //    & n.Costo_Principal <= searhByPrice
            //    || n.Costo_Principal <= searhByPrice).ToList();
            //    return View("Index", filteredResult);
            //}
            if(!string.IsNullOrEmpty(searchByPlace))
            {
                allDestinos = allDestinos.Where(n => n.TLugar.ToString().Contains(searchByPlace)).ToList();
            }
            if (!string.IsNullOrEmpty(searhByDestination))
            {
                allDestinos = allDestinos.Where(n => n.TDestino.ToString().Contains(searhByDestination)).ToList();
            }
            if(!string.IsNullOrEmpty(searhByPrice))
            {
                double price = double.Parse(searhByPrice);
                allDestinos = allDestinos.Where(n => n.Costo_Principal <= price).ToList();
            }
            return View("Index", allDestinos);
        }


        public async Task<IActionResult> Details(int id)
        {
            var destinoDetail = await _service.GetDestinoByIdAsync(id);
            return View(destinoDetail);
        }

        public async  Task<IActionResult> Create()
        {
            var destinoDropdownsData = await _service.GetNewDestinoDropdownsValues();

            ViewBag.ars = new SelectList(destinoDropdownsData.ARs, "Id", "Nombre");
            ViewBag.ges = new SelectList(destinoDropdownsData.Gastos_Extras, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewDestinoVM destino)
        {
            if(!ModelState.IsValid)
            {
                var destinoDropdownsData = await _service.GetNewDestinoDropdownsValues();
                ViewBag.ars = new SelectList(destinoDropdownsData.ARs, "Id", "Nombre");
                ViewBag.ges = new SelectList(destinoDropdownsData.Gastos_Extras, "Id", "Nombre");
                return View(destino);
            }
            await _service.AddNewDestinoAsync(destino);
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Edit(int id)
        {
            var destinoDetails = await _service.GetDestinoByIdAsync(id);
            if (destinoDetails == null) return View("NotFound");

            var response = new NewDestinoVM()
            {
                Id = destinoDetails.Id,
                Nombre = destinoDetails.Nombre,
                Descripcion = destinoDetails.Descripcion,
                Costo_Principal = destinoDetails.Costo_Principal,
                TDestino = destinoDetails.TDestino,
                TLugar = destinoDetails.TLugar,
                Img = destinoDetails.Img,
                Img2 = destinoDetails.Img2,
                Img3 = destinoDetails.Img3,
                ARids = destinoDetails.Destinos_ARs.Select(n => n.Id_AR).ToList(),
                Gastos_Extraids = destinoDetails.Destinos_Gastos.Select(n => n.Id_Gastos).ToList(),

            };
            var destinoDropdownsData = await _service.GetNewDestinoDropdownsValues();

            ViewBag.ars = new SelectList(destinoDropdownsData.ARs, "Id", "Nombre");
            ViewBag.ges = new SelectList(destinoDropdownsData.Gastos_Extras, "Id", "Nombre");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewDestinoVM destino)
        {
            if (id != destino.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var destinoDropdownsData = await _service.GetNewDestinoDropdownsValues();
                ViewBag.ars = new SelectList(destinoDropdownsData.ARs, "Id", "Nombre");
                ViewBag.ges = new SelectList(destinoDropdownsData.Gastos_Extras, "Id", "Nombre");
                return View(destino);
            }
            await _service.UpdateDestinoAsync(destino);
            return RedirectToAction(nameof(Index));
        }
    }
}
