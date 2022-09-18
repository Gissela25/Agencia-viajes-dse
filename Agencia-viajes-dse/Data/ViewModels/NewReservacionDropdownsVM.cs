using Agencia_viajes_dse.Models;

namespace Agencia_viajes_dse.Data.ViewModels
{
    public class NewReservacionDropdownsVM
    {
        public NewReservacionDropdownsVM()
        {
            DestinoS = new List<Destino>();
        }

        public List<Destino> DestinoS { get; set; }
    }
}
