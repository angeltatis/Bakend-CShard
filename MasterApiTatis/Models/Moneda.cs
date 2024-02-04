using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Models
{
    [Table("moneda")]
    public class Moneda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "codmon")]
        public int Codmon { get; set; }

        [Column(name: "desmon")]
        public string Desmon { get; set; }

        public decimal Tasa { get; set; }

        [Column(name: "estado")]
        public bool Estado { get; set; }

        // Relaciones
        // En tu entidad Moneda
        public List<Compra> Compras { get; set; }

        // En tu entidad Orden
        public List<Orden> Ordenes { get; set; }

        // En tu entidad Venta
        public List<Venta> Facturas { get; set; }
    }
}
