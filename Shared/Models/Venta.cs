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

    [Required(ErrorMessage = "Debe ingresar un Nombre.")]
    [RegularExpression(@"^[a-zA-ZñÑ\s]+$", ErrorMessage = "No se aceptan números ni caracteres especiales.")]
    [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "La longitud debe ser de 2 a 30 dígitos")]
    public string Nombre_Usuario { get; set; } = string.Empty;
    public string NombreCliente { get; set; } = string.Empty;

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Fecha { get; set; } = DateTime.Now;

}
