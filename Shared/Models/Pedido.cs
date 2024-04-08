using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class Pedido
{
    [Key]
    public int PedidoId { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Fecha_Pedido { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "Es Requerido Especificar la dirección de envio")]
    public string Direccion { get; set; } = string.Empty;
    //aqi poner un select para seleccionar el estado del pedido
    public string Estado { get; set; } = string.Empty;

}
