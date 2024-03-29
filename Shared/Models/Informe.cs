using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class Informe
{
    [Key]
    public int InformeId { get; set; }
    [Required]
    public DateTime Fecha_Inicio { get; set; } = DateTime.Now;
    [Required]
    public DateTime Fecha_Final { get; set; } = DateTime.Now;
    [Required]
    public decimal Total_Compras { get; set; } = 0;
    [Required]
    public decimal Gastado { get; set; } = 0;

}
