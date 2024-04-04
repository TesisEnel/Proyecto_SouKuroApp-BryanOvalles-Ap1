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
		public int PedidoId { get; set; }

		[Required]
		public string Nombre_Cliente { get; set; } = string.Empty;

		[Required]
		public int Numero_Entrada { get; set; }

		[Required]
		public int Num_Mesa { get; set; }

	
		public string Estado_Entrega { get; set; } = string.Empty;

		
		public string Estado_Pago { get; set; } = string.Empty;

		[ForeignKey("Centro_de_Pedidos")]
		public ICollection<Centro_Detalle> Detalle { get; set; } = new List<Centro_Detalle>();

	}
}
