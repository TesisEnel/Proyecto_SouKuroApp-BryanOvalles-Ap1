using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class Informe
{
    [Key]
    public int InformeId { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Fecha_Inicio { get; set; } = DateTime.Now;
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Fecha_Final { get; set; } = DateTime.Now;
    [ForeignKey("Compra")]
    public int CompraId { get; set; }
    public decimal Total_Compras { get; set; } = 0;
    public decimal Gastado { get; set; } = 0;

}
