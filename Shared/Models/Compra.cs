using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

    public class Compra
    {
        [Key]
        public int CompraId { get; set; }

        [Required]
        public DateTime Fecha_Compra { get; set; } = DateTime.Now;

        [Required]
        public string NFC { get; set; } = string.Empty;

        [Required]
        public int No_Compra { get; set; }

        [Required]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal SubTotal { get; set; }

        [Required]
        public decimal ITBIS { get; set; }

        [Required]
        public decimal Total { get; set; }

        [ForeignKey("Compra")]
        public ICollection<Compras_Detalles> Detalle { get; set; } = new List<Compras_Detalles>();
    }

