using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class Producto
{
    [Key]
    public int ProcuctoId { get; set; }
    [Required]
    public string Nombre { get; set; } = string.Empty;
    [Required]
    public string Descripcion { get; set; } = string.Empty;
    [Required]
    public decimal Precio { get; set; } = 0;
    [Required]
    public int Stock { get; set; } = 0;

    [ForeignKey("ProductoId")]
    ICollection<Producto_Detalle> ProductoDetalle { get; set; } = new List<Producto_Detalle>();
    
}
