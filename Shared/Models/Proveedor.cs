using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Proveedor
{
    [Key]
    public int ProveedorId { get; set; }
    [Required(ErrorMessage = "Debe ingresar un Nombre.")]
    [RegularExpression(@"^[a-zA-ZñÑ\s]+$", ErrorMessage = "No se aceptan números ni caracteres especiales.")]
    [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "La longitud debe ser de 2 a 30 dígitos")]
    public string Nombre { get; set; } = string.Empty;
    [Required(ErrorMessage = "Es Requerido Especificar la dirección")]
    public string Direccion { get; set; } = string.Empty;
    [Required(ErrorMessage = "El campo {0} es requerido.")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "El Teléfono solo puede contener dígitos.")]
    [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "La longitud debe ser de 10 dígitos")]
    public string Telefono { get; set; } = string.Empty;
    [EmailAddress(ErrorMessage = "El formato para el email no es válido.")]
    [RegularExpression(@"^[^\s]+@[^\s]+\.[^\s]+$", ErrorMessage = "El email no puede contener espacios.")]
    public string Email { get; set; } = string.Empty;
    
    ICollection<Proveedor> Proveedores { get; set; } = new List<Proveedor>();
}