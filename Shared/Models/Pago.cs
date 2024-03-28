using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class Pago
{
    [Key]
    public int PagoId { get; set; }
    [Required]
    public DateTime Fecha_Pago { get; set; } = DateTime.Now;
    [Required]
    public decimal Monto { get; set; } = 0;
    [Required]
    public string Metodo { get; set; } = string.Empty;
    [Required]
    public string Estado { get; set; } = string.Empty;
    [Required]
    public Pedido _Pedido { get; set; } = new Pedido();
    [Required]
    public Compra _Compra { get; set; } = new Compra();

    ICollection<Pago> Pagos { get; set; } = new List<Pago>();
    
}
