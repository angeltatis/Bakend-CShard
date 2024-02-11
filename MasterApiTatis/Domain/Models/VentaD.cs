using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Domain.Models
{
    [Table("ventadetalle")]
    public class VentaD
    {
        [Key]
        [Column("codvend")]
        public int Codvend { get; set; }

        [Column("codven")]
        public int Codven { get; set; }

        [Column("codpro")]
        public string Codpro { get; set; }

        [Column("coduni")]
        public int Coduni { get; set; }

        [Column("canpro", TypeName = "decimal(16,2)")]
        public decimal Canpro { get; set; }

        [Column("precio", TypeName = "decimal(16,2)")]
        public decimal Precio { get; set; }

        [Column("itebi", TypeName = "decimal(16,2)")]
        public decimal Itebi { get; set; }

        [Column("importe", TypeName = "decimal(16,2)")]
        public decimal Importe { get; set; }

        [Column("estado")]
        public bool Estado { get; set; } = true;

        [ForeignKey("Codven")]
        public Venta Venta { get; set; }

        [ForeignKey("Codpro")]
        public Producto Producto { get; set; }

        [ForeignKey("Coduni")]
        public Unidad Unidad { get; set; }
    }
}
