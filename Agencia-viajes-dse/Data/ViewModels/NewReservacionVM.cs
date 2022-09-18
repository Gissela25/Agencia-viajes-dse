using Agencia_viajes_dse.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agencia_viajes_dse.Models
{
    public class NewReservacionVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Nombre(s)")]
        [Required(ErrorMessage ="El nombre es requerido")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido(s)")]
        [Required(ErrorMessage = "El apellido es requerido")]
        public string Apellido { get; set; }
        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El Correo es requerido")]
        [EmailAddress(ErrorMessage ="El correo electrónico es invalido")]
        public string Correo { get; set; }
        [Display(Name ="Fecha de Salida")]
        [Required(ErrorMessage ="Debes ingresar una fecha de inicio")]
        [DataType(DataType.Date)]
        public DateTime FechaSalida { get; set; }
        [Display(Name = "Fecha de Regreso")]
        [Required(ErrorMessage = "Debes ingresar una fecha de inicio")]
        [DataType(DataType.Date)]
        public DateTime FechaRegreso { get; set; }

        [Display(Name ="Destino")]
        [Required(ErrorMessage ="Debes seleccionar el lugar")]
        public int Id_Destinos { get; set; }

    }
}
