using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
	public class Centro_Detalle
	{
		[Key]
		public int Id { get; set; }

		public int PedidoId { get; set; }

		[Required]
		public string  Nombre_Produc {  get; set; } = string.Empty;

		[Required]
		public int Cantidad { get; set; }


	}
}
