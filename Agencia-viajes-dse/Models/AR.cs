using Agencia_viajes_dse.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Agencia_viajes_dse.Models
{
    public class AR:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Avisos/Recomendaciones")]
        [Required(ErrorMessage = "Avisos o Recomendaciones es requerida")]
        public string Nombre { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Descripcion es requerida")]
        public string Descripcion { get; set; }
     

        //Relaciones
        public List<Destino_AR> Destinos_ARs { get; set; }
    }
}
