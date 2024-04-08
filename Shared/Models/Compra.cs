using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Shared.Models;

public class Compra
{
    [Key]
    public int CompraId { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Fecha_Compra { get; set; } = DateTime.Now;
    public int No_Compra { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido.")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "El Teléfono solo puede contener dígitos.")]
    [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "La longitud debe ser de 10 dígitos")] 
    public string Telefono { get; set; } = string.Empty;
    [Range(minimum: 0, maximum: 10000000000000000000, ErrorMessage = "La cantidad es menor o igual a 0 o es demasiado alto para el sistema Favor ingresar otro monto")]
    public int Cantidad { get; set; } = 0;
    public decimal SubTotal { get; set; }
    public decimal ITBIS { get; set; }
    public decimal Total { get; set; }

    [ForeignKey("Compra")]
    public ICollection<Compras_Detalles> Detalle { get; set; } = new List<Compras_Detalles>();
}

