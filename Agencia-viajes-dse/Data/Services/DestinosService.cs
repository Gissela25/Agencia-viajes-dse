using Agencia_viajes_dse.Data.Base;
using Agencia_viajes_dse.Data.ViewModels;
using Agencia_viajes_dse.Models;
using Microsoft.EntityFrameworkCore;

namespace Agencia_viajes_dse.Data.Services
{
    public class DestinosService:EntityBaseRepository<Destino>,IDestinosService
    {
        private readonly AppDbContext _context;
        public DestinosService(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task AddNewDestinoAsync(NewDestinoVM data)
        {
            var newDestino = new Destino()
            {
                Nombre = data.Nombre,
                Descripcion = data.Descripcion,
                Costo_Principal = data.Costo_Principal,
                TDestino = data.TDestino,
                TLugar = data.TLugar,
                Img = data.Img,
                Img2 = data.Img2,
                Img3 = data.Img3,

            };

            await _context.Destinos.AddAsync(newDestino);
            await _context.SaveChangesAsync();

            foreach(var dgeid in data.Gastos_Extraids)
            {
                var newDestinoGE = new Destino_Gastos()
                {
                    Id_Destino = newDestino.Id,
                    Id_Gastos = dgeid
                };
                await _context.Destinos_Gastos.AddAsync(newDestinoGE);
            }
            await _context.SaveChangesAsync();

            foreach(var arid in data.ARids)
            {
                var newDestinoAR = new Destino_AR()
                {
                    Id_Destino = newDestino.Id,
                    Id_AR = arid
                };
                await _context.Destino_ARs.AddAsync(newDestinoAR);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Destino> GetDestinoByIdAsync(int id)
        {
            var destinoDetails = await _context.Destinos
              .Include(dg => dg.Destinos_Gastos).ThenInclude(g => g.Gastos_Extra)
              .Include(dar => dar.Destinos_ARs).ThenInclude(ar => ar.AR)
              .FirstOrDefaultAsync(n => n.Id == id);
            return destinoDetails;
        }

        public async Task<NewDestinoDropdownsVM> GetNewDestinoDropdownsValues()
        {
             var response = new NewDestinoDropdownsVM()
             {
             ARs = await _context.ARS.OrderBy(n => n.Nombre).ToListAsync(),
             Gastos_Extras = await _context.Gastos_Extras.OrderBy(n => n.Nombre).ToListAsync()
             };


            return response;
        }

        public async Task UpdateDestinoAsync(NewDestinoVM data)
        {
            var dbDestino = await _context.Destinos.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbDestino != null)
            {
                dbDestino.Nombre = data.Nombre;
                dbDestino.Descripcion = data.Descripcion;
                dbDestino.Costo_Principal = data.Costo_Principal;
                dbDestino.TDestino = data.TDestino;
                dbDestino.TLugar = data.TLugar;
                dbDestino.Img = data.Img;
                dbDestino.Img2 = data.Img2;
                dbDestino.Img3 = data.Img3;
                await _context.SaveChangesAsync();
            }


            var existingActorsDb = _context.Destinos_Gastos.Where(n=> n.Id_Destino == data.Id).ToList();
            _context.Destinos_Gastos.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();



            foreach (var dgeid in data.Gastos_Extraids)
            {
                var newDestinoGE = new Destino_Gastos()
                {
                    Id_Destino = data.Id,
                    Id_Gastos = dgeid
                };
                await _context.Destinos_Gastos.AddAsync(newDestinoGE);
            }
            await _context.SaveChangesAsync();

            var existingActorsDb2 = _context.Destino_ARs.Where(n => n.Id_Destino == data.Id).ToList();
            _context.Destino_ARs.RemoveRange(existingActorsDb2);
            await _context.SaveChangesAsync();

            foreach (var arid in data.ARids)
            {
                var newDestinoAR = new Destino_AR()
                {
                    Id_Destino = data.Id,
                    Id_AR = arid
                };
                await _context.Destino_ARs.AddAsync(newDestinoAR);
            }
            await _context.SaveChangesAsync();
        }
    }
}
