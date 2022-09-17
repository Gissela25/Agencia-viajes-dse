namespace Agencia_viajes_dse.Models
{
    public class Destino_Gastos
    {
        public int Id_Gastos { get; set; }
        public  Gastos_Extra Gastos_Extra { get; set; }

        public int Id_Destino { get; set; }
        public Destino Destino { get; set; }
    }
}
