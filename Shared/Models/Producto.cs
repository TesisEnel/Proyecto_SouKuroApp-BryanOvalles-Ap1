using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    ICollection<Producto> Productos { get; set; } = new List<Producto>();
    
}
