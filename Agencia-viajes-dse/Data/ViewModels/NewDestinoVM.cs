using Agencia_viajes_dse.Data.Base;
using Agencia_viajes_dse.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agencia_viajes_dse.Models
{
    public class NewDestinoVM
    {
        public int Id { get; set; }
        [Display(Name ="Nombre")]
        [Required(ErrorMessage ="El nombre es requerido")]
        public string Nombre { get; set; }
        [Display(Name  = "Descripción del lugar")]
        [Required(ErrorMessage = "La descripcion del lugar es requerida")]
        public string Descripcion { get; set; }
        [Display(Name  = "Costo del viaje en $")]
        [Required(ErrorMessage = "El costo principal es obligatorio")]
        public double Costo_Principal { get; set; }
        [Display(Name  = "Tipo de destino")]
        [Required(ErrorMessage = "Selcciona el tipo de destino")]
        public TDestino TDestino { get; set; }
        [Display(Name = "Tipo de lugar")]
        [Required(ErrorMessage = "Selecciona el tipo lugar")]
        public TLugar TLugar { get; set; }
        [Display(Name  = "Imagen Principal")]
        [Required(ErrorMessage = "Es necesario ingresar la imagen principal")]
        public string Img { get; set; }
        [Display(Name = "Imagen Secundaria")]
        [Required(ErrorMessage = "Es neceasrio ingresa la segunda imagen")]
        public string Img2 { get; set; }
        [Display(Name = "Imagen Terciaria")]
        [Required(ErrorMessage = "Es neceario ingresar la tercera imagen")]
        public string Img3 {get; set; }

        //Relaciones
        [Display(Name = "Aviso/Recomendacion")]
        [Required(ErrorMessage = "Debes selecionar la recomendacion")]
        public List<int> ARids { get; set; }
        [Display(Name = "Gastos extra")]
        [Required(ErrorMessage = "Selecciona el gasto extra")]
        public List<int> Gastos_Extraids { get; set; }

        //public List<Reservacion> Reservaciones { get; set; }
    }
}
