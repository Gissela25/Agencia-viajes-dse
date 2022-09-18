using Agencia_viajes_dse.Data.Base;
using Agencia_viajes_dse.Models;

namespace Agencia_viajes_dse.Data.Services
{
    public class ARsService: EntityBaseRepository<AR>, IARsService
    {
        public ARsService(AppDbContext context) : base(context)
        {

        }
    }
}
