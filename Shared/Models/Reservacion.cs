using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
	public class Reservacion
	{
		[Key]
		public int ReservacionId { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Nombre.")]
        [RegularExpression(@"^[a-zA-ZñÑ\s]+$", ErrorMessage = "No se aceptan números ni caracteres especiales.")]
        [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "La longitud debe ser de 2 a 30 dígitos")]
        public string Nombre_Cliente { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo {0} es Requerido.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "La cedula solo puede contener dígitos.")]
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "La longitud debe ser de 11 dígitos")]
        public string Cedula { get; set; } = string.Empty;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
	}
}
