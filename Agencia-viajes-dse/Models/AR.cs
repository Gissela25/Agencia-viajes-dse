using System.ComponentModel.DataAnnotations;

namespace Agencia_viajes_dse.Models
{
    public class AR
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        //Relaciones
        public List<Destino_AR> Destinos_ARs { get; set; }
    }
}
