namespace Agencia_viajes_dse.Models
{
    public class Gastos_Extra
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Destino_Gastos> Destinos_Gastos { get; set; }
    }
}
