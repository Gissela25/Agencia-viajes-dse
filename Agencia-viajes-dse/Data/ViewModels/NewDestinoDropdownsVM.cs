using Agencia_viajes_dse.Models;

namespace Agencia_viajes_dse.Data.ViewModels
{
    public class NewDestinoDropdownsVM
    {
        public NewDestinoDropdownsVM()
        {
            ARs = new List<AR>();
            Gastos_Extras = new List<Gastos_Extra>();
        }

        public List<AR> ARs { get; set; }
        public List<Gastos_Extra> Gastos_Extras { get; set; }

    }
}
