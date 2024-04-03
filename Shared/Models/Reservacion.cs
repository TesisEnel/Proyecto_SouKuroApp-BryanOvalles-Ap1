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

		[Required]
		public string Nombre_Cliente { get; set; } = string.Empty;

		[Required]
		public string Cedula { get; set; } = string.Empty;


		[Required]
		public DateTime Fecha { get; set; }
	}
}
