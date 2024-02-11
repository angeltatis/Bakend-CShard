using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Domain.Models
{
    [Table("liquidacionD")]
    public class LiquidacionD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "coddliqui")]
        public int Coddliqui { get; set; }

        [Column(name: "codpro")]
        public string Codpro { get; set; }

        [Column(name: "codsup")]
        public int Codsup { get; set; }

        [Column(name: "codiLiq")]
        public int CodiLiq { get; set; }

        [Column(name: "codmon")]
        public int Codmon { get; set; }

        public string Desuni { get; set; }

        public decimal Fbo { get; set; }

        public decimal Monto { get; set; }

        public decimal Importe { get; set; }

        public decimal Coscif { get; set; }

        public decimal Cif { get; set; }

        public decimal Porgra { get; set; }

        public decimal Gravamen { get; set; }

        public decimal Porsele { get; set; }

        public decimal Selectivo { get; set; }

        public decimal Subtotal { get; set; }

        public decimal Itebis { get; set; }

        public decimal Total { get; set; }

        public decimal Totalimp { get; set; }

        public decimal Cosdis { get; set; }

        public decimal Totalneto { get; set; }

        [Column(name: "estado")]
        public bool Estado { get; set; } = true;

        // Relaciones
        [ForeignKey("Codpro")]
        public Producto Producto { get; set; }

        [ForeignKey("Codsup")]
        public Suplidor Suplidor { get; set; }

        [ForeignKey("CodiLiq")]
        public Liquidacion Liquidacion { get; set; }

        [ForeignKey("Codmon")]
        public Moneda Moneda { get; set; }
    }
}
