using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class Venta
{
    [Key]
    public int VentaId { get; set; }

    [Required]
    public string NombreCliente { get; set; } = string.Empty;

    [Required]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required]
    public Producto producto { get; set; }
}
