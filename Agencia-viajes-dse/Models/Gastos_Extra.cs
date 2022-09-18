using Agencia_viajes_dse.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Agencia_viajes_dse.Models
{
    public class Gastos_Extra:IEntityBase
    {
        public int Id { get; set; }

        [Display(Name = "Gastos Extra")]
        public string Nombre { get; set; }


        public List<Destino_Gastos> Destinos_Gastos { get; set; }
    }
}
