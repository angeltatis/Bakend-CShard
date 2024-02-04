using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Models
{
    [Table("liquidacion")]
    public class Liquidacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "codiLiq")]
        public int CodiLiq { get; set; }

        [Column(name: "codmon")]
        public int Codmon { get; set; }

        public int Codbl { get; set; }

        public DateTime FeciLiq { get; set; }

        public decimal Importe { get; set; }

        public decimal Tasadu { get; set; }

        public decimal Coscifrd { get; set; }

        public decimal Cosfact { get; set; }

        public decimal Otrcos { get; set; }

        [Column(TypeName = "TEXT")]
        public string Nota { get; set; }

        [Column(name: "estado")]
        public bool Estado { get; set; } = true;

        public List<LiquidacionD> Detalles { get; set; }

        // Relaciones
        [ForeignKey("Codmon")]
        public Moneda Moneda { get; set; }
    }
}
