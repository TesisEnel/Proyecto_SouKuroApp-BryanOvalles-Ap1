using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Proveedor
{
    [Key]
    public int ProveedorId { get; set; }
    [Required]
    public string Nombre { get; set; } = string.Empty;
    [Required]
    public string Direccion { get; set; } = string.Empty;
    [Required]
    public string Telefono { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    
    ICollection<Proveedor> Proveedores { get; set; } = new List<Proveedor>();
}