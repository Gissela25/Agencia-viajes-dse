namespace Agencia_viajes_dse.Models
{
    public class Destino_AR
    {
        public int Id_Destino { get; set; }
        public Destino Destino { get; set; }

        public int Id_AR { get; set; }
        public AR AR { get; set; }
    }
}
