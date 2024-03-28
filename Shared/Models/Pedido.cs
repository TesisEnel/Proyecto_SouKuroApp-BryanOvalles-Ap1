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
    public Proveedor _Proveedor { get; set; } = new Proveedor();
    [Required]
    public string Direccion { get; set; } = string.Empty;
    [Required]
    public Compra compra { get; set; } = new Compra();
    
    ICollection<Pedido> Pedidos{ get; set; } = new List<Pedido>();

}
