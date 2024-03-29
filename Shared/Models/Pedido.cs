using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class Pedido
{
    [Key]
    public int PedidoId { get; set; }
    [Required]
    public DateTime Fecha_Pedido { get; set; } = DateTime.Now;
    [Required]
    public string Direccion { get; set; } = string.Empty;
    [Required]
    public string Estado { get; set; } = string.Empty;
    
}
