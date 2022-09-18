using Agencia_viajes_dse.Data;
using Agencia_viajes_dse.Data.Services;
using Agencia_viajes_dse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Agencia_viajes_dse.Controllers
{
    public class ReservacionesController : Controller
    {
        private readonly IReservacionesService _service;

        public ReservacionesController(IReservacionesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allReservaciones = await _service.GetAllAsync(n => n.Destinos);
            return View(allReservaciones);
        }

        public async Task<IActionResult> Create(int id)
        {
            //var comprobatedestino = await _service.GetDestinoByIdAsync(id);
            var response = new NewReservacionVM()
            {
                FechaSalida = DateTime.UtcNow,
                FechaRegreso = DateTime.UtcNow,
                Id_Destinos = id,
            };
            var reservacionesDropdownsData = await _service.GetNewReservacionDropdownsValues();
            ViewBag.destinos = new SelectList(reservacionesDropdownsData.DestinoS, "Id", "Nombre");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewReservacionVM reservacion)
        {
            if(!ModelState.IsValid)
            {
                var reservacionesDropdownsData = await _service.GetNewReservacionDropdownsValues();
                ViewBag.destinos = new SelectList(reservacionesDropdownsData.DestinoS, "Id", "Nombre");
                return View(reservacion);
            };
            await _service.AddNewReservacionAsync(reservacion);
            return RedirectToAction("Index","Destinos");

          
        }


        public async Task<IActionResult> Edit(int id)
        {
            //var comprobatedestino = await _service.GetDestinoByIdAsync(id);
            var reservacionDetails = await _service.GetReservacionByIdAsync(id);
            if(reservacionDetails == null) return View("NotFound");

            var response = new NewReservacionVM()
            {
                Id = reservacionDetails.Id,
                Nombre = reservacionDetails.Nombre,
                Apellido = reservacionDetails.Apellido,
                Correo = reservacionDetails.Correo,
                FechaSalida = reservacionDetails.FechaSalida,
                FechaRegreso = reservacionDetails.FechaRegreso,
                Id_Destinos = reservacionDetails.Id_Destino,
            };

            var reservacionesDropdownsData = await _service.GetNewReservacionDropdownsValues();
            ViewBag.destinos = new SelectList(reservacionesDropdownsData.DestinoS, "Id", "Nombre");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewReservacionVM reservacion)
        {
            if (id != reservacion.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var reservacionesDropdownsData = await _service.GetNewReservacionDropdownsValues();
                ViewBag.destinos = new SelectList(reservacionesDropdownsData.DestinoS, "Id", "Nombre");
                return View(reservacion);
            }
            //var comprobatedestino = await _service.GetDestinoByIdAsync(id);
            await _service.UpdateReservacionAsync(reservacion);
            return RedirectToAction("Index", "Reservaciones");


        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var reservacionDetails = await _service.GetReservacionByIdAsync(id);
            if (reservacionDetails == null) return View("NotFound");

            var response = new NewReservacionVM()
            {
                Id = reservacionDetails.Id,
                Nombre = reservacionDetails.Nombre,
                Apellido = reservacionDetails.Apellido,
                Correo = reservacionDetails.Correo,
                FechaSalida = reservacionDetails.FechaSalida,
                FechaRegreso = reservacionDetails.FechaRegreso,
                Id_Destinos = reservacionDetails.Id_Destino,
            };

            var reservacionesDropdownsData = await _service.GetNewReservacionDropdownsValues();
            ViewBag.destinos = new SelectList(reservacionesDropdownsData.DestinoS, "Id", "Nombre");
            return View(response);
        }

        [HttpPost ,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservacionDetails = await _service.GetReservacionByIdAsync(id);
            if (reservacionDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction("Index", "Reservaciones");
        }


    }
}
