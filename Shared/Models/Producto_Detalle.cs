using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class Producto_Detalle
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Producto")]
    public int ProductoId { get; set; }
    [Required]
    public string Categoria { get; set; } = string.Empty;    

    ICollection<Producto_Detalle> Productos_Detalles { get; set; } = new List<Producto_Detalle>();

}
