using Agencia_viajes_dse.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agencia_viajes_dse.Models
{
    public class Destino
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Costo_Principal { get; set; }
        public TDestino TDestino { get; set; }
        public TLugar TLugar { get; set; }
        public string Img { get; set; }
        public string Img2 { get; set; }
        public string Img3 {get; set; }

        //Relaciones
        public List<Destino_AR> Destinos_ARs { get; set; }
        public List<Destino_Gastos> Destinos_Gastos { get; set; }

        public List<Img> Imgs { get; set; }

        public List<Reservacion> Reservaciones { get; set; }
    }
}
