using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class Compras_Detalles
{
    [Key]
    public int Id { get; set; }
    public int CompraId { get; set; }

    [Required(ErrorMessage = "Debe ingresar un Producto.")]
    [RegularExpression(@"^[a-zA-ZñÑ\s]+$", ErrorMessage = "No se aceptan números ni caracteres especiales.")]
    [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "La longitud debe ser de 2 a 30 dígitos")]
    public string Nombre_Producto { get; set; } = string.Empty;

    [Required(ErrorMessage = "Es requerido que ingreses la cantidad de productos que desea")]
    [Range(minimum: 0, maximum: 10000000000000000000, ErrorMessage = "La cantidad es menor o igual a 0 o es demasiado alto para el sistema Favor ingresar otro monto")]
    public int Cantidad_Prod { get; set; }

}

