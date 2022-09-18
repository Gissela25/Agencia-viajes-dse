using Agencia_viajes_dse.Data.Base;
using Agencia_viajes_dse.Data.ViewModels;
using Agencia_viajes_dse.Models;
using Microsoft.EntityFrameworkCore;

namespace Agencia_viajes_dse.Data.Services
{
    public class ReservacionesService : EntityBaseRepository<Reservacion>, IReservacionesService
    {
        private readonly AppDbContext _context;
        public ReservacionesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewReservacionAsync(NewReservacionVM data)
        {
            var newReservacion = new Reservacion()
            {
                Nombre = data.Nombre,
                Apellido = data.Apellido,
                Correo = data.Correo,
                FechaRegreso = data.FechaRegreso,
                FechaSalida = data.FechaSalida,
                Id_Destino = data.Id_Destinos,
            };
            await _context.Reservaciones.AddAsync(newReservacion);
            await _context.SaveChangesAsync();
        }

        public async Task<NewReservacionDropdownsVM> GetNewReservacionDropdownsValues()
        {
            var response = new NewReservacionDropdownsVM()
            {
                DestinoS = await _context.Destinos.OrderBy(n => n.Nombre).ToListAsync()
            };
            return response;
        }

        public async Task<Reservacion> GetReservacionByIdAsync(int id)
        {
            var destinoDetails = await _context.Reservaciones
                .Include(des => des.Destinos)
                .FirstOrDefaultAsync(n => n.Id == id);
            return destinoDetails;
        }

        public async Task UpdateReservacionAsync(NewReservacionVM data)
        {
            var dbReservacion = await _context.Reservaciones.FirstOrDefaultAsync(n => n.Id == data.Id);
            if(dbReservacion != null)
            {
                dbReservacion.Nombre = data.Nombre;
                dbReservacion.Apellido = data.Apellido;
                dbReservacion.Correo = data.Correo;
                dbReservacion.FechaRegreso = data.FechaRegreso;
                dbReservacion.FechaSalida = data.FechaSalida;
                dbReservacion.Id_Destino = data.Id_Destinos;
                await _context.SaveChangesAsync();
            }
        }
    }
}
