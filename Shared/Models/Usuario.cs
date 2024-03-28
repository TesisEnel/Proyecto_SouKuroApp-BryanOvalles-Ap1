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

    [Required]
    public string Nombre_Usuario { get; set; } = string.Empty;

    [Required]
    public string Contrasena { get; set; } = string.Empty;

    [Required]

    public string Rol { get; set; } = string.Empty;
}
