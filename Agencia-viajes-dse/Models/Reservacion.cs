using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agencia_viajes_dse.Models
{
    public class Reservacion
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaRegreso { get; set; }

        public int Id_Destino { get; set; }
        [ForeignKey("Id_Destino")]

        public Destino Destinos { get; set; }
    }
}
