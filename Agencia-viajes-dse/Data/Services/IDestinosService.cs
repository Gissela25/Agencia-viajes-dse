using Agencia_viajes_dse.Data.Base;
using Agencia_viajes_dse.Data.ViewModels;
using Agencia_viajes_dse.Models;

namespace Agencia_viajes_dse.Data.Services
{
    public interface IDestinosService:IEntityBaseRepository<Destino>
    {
        Task<Destino> GetDestinoByIdAsync(int id);
        Task<NewDestinoDropdownsVM> GetNewDestinoDropdownsValues();

        Task AddNewDestinoAsync(NewDestinoVM data);

        Task UpdateDestinoAsync(NewDestinoVM data);
    }
}
