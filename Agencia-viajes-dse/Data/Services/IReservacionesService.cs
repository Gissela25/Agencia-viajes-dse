using Agencia_viajes_dse.Data.Base;
using Agencia_viajes_dse.Data.ViewModels;
using Agencia_viajes_dse.Models;

namespace Agencia_viajes_dse.Data.Services
{
    public interface IReservacionesService:IEntityBaseRepository<Reservacion>
    {
        Task<Reservacion> GetReservacionByIdAsync(int id);
        Task<NewReservacionDropdownsVM> GetNewReservacionDropdownsValues();

        //Task<Destino> GetDestinoByIdAsync(int id);

        Task AddNewReservacionAsync(NewReservacionVM data);

        Task UpdateReservacionAsync(NewReservacionVM data);
    }
}
