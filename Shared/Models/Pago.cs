using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class Pago
{
    [Key]
    public int PagoId { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Fecha_Pago { get; set; } = DateTime.Now;
    [ForeignKey("Compra")]
    public int CompraId { get; set; }
    //aqui poner un select para seleccionar el metodo de pago
    public string Metodo { get; set; } = string.Empty;
    //aqui poner un select para seleccionar el estado del pago
    public string Estado { get; set; } = string.Empty;
    
}
