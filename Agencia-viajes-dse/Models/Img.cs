using System.ComponentModel.DataAnnotations.Schema;

namespace Agencia_viajes_dse.Models
{
    public class Img
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        //Destino

        public int Id_Destino { get; set; }
        [ForeignKey("Id_Destino")]

        public Destino Destinos { get; set; }
    }
}
