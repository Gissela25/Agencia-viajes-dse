using Agencia_viajes_dse.Data.Base;
using Agencia_viajes_dse.Models;

namespace Agencia_viajes_dse.Data.Services
{
    public class GEsService: EntityBaseRepository<Gastos_Extra>, IGEsService
    {
        public GEsService(AppDbContext context) : base(context)
        {

        }
    }
}
