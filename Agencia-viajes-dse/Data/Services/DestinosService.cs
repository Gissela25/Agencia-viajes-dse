using Agencia_viajes_dse.Data.Base;
using Agencia_viajes_dse.Data.ViewModels;
using Agencia_viajes_dse.Models;

namespace Agencia_viajes_dse.Data.Services
{
    public class DestinosService:EntityBaseRepository<Destino>,IDestinosService
    {
        private readonly AppDbContext _context;
        public DestinosService(AppDbContext context):base(context)
        {
            _context = context;
        }

        public Task<Destino> GetDestinoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<NewDestinoDropdownsVM> GetNewDestinoDropdownsValues()
        {
            throw new NotImplementedException();
        }
    }
}
