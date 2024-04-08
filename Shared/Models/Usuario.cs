using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class Usuario
{
    [Key]
    public int UsuarioId { get; set; }

    [Required(ErrorMessage = "Debe ingresar un Nombre.")]
    [RegularExpression(@"^[a-zA-ZñÑ\s]+$", ErrorMessage = "No se aceptan números ni caracteres especiales.")]
    [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "La longitud debe ser de 2 a 30 dígitos")]
    public string Nombre_Usuario { get; set; } = string.Empty;

    [Required(ErrorMessage = "Debe ingresar una contraseña.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,15}$", 
    ErrorMessage = "La contraseña debe tener entre 8 y 15 caracteres, al menos una letra mayúscula, al menos una letra minúscula, al menos un dígito, sin espacios en blanco y al menos un caracter especial.")] 
    public string Contrasena { get; set; } = string.Empty;
    [Required]
    public string Rol { get; set; } = "Cliente";
}
