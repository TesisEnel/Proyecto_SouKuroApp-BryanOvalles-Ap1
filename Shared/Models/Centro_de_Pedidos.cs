using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
	public class Centro_de_Pedidos
	{
		[Key]
		public int PedidoClienteId { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Nombre Valido.")]
        [RegularExpression(@"^[a-zA-ZñÑ\s]+$", ErrorMessage = "No se aceptan números ni caracteres especiales.")]
        [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "La longitud debe ser de 2 a 30 dígitos")]
        public string Nombre_Cliente { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El Numero de Entrada solo puede contener dígitos.")]
        [Range(0, 9999999, ErrorMessage = "La longitud debe ser de 7 dígitos")]
        public int Numero_Entrada { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El Numero de Mesa solo puede contener dígitos.")]
        [Range(1, 40, ErrorMessage = "La longitud va desde la Mesa 1 hasta la 40")]
        public int Num_Mesa { get; set; }
		//preguntar ai esto se activa del lado del administrador
		public string Estado_Entrega { get; set; } = string.Empty;
        //preguntar ai esto se activa del lado del administrador
        public string Estado_Pago { get; set; } = string.Empty;

		[ForeignKey("Centro_de_Pedidos")]
		public ICollection<Centro_Detalle> Detalle { get; set; } = new List<Centro_Detalle>();

	}
}
