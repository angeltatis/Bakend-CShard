using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Domain.Models
{
    [Table("venta")]
    public class Venta
    {
        [Key]
        [Column("codven")]
        public int Codven { get; set; }

        [Column("codcli")]
        public int Codcli { get; set; }

        [Column("codmon")]
        public int Codmon { get; set; }

        [Column("codcon")]
        public int Codcon { get; set; }

        [Column("codtipncf")]
        public string Codtipncf { get; set; }

        [Column("ncf")]
        public string Ncf { get; set; }

        [Column("fectra", TypeName = "datetime2")]
        public DateTime Fectra { get; set; }

        [Column("fecven", TypeName = "datetime2")]
        public DateTime? Fecven { get; set; }

        [Column("desven", TypeName = "decimal(10,2)")]
        public decimal Desven { get; set; }

        [Column("itbistotal", TypeName = "decimal(10,2)")]
        public decimal Itbistotal { get; set; }

        [Column("otro", TypeName = "decimal(10,2)")]
        public decimal Otro { get; set; }

        [Column("total", TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }

        [Column("estado")]
        public bool Estado { get; set; } = true;

        public List<VentaD> DetallesVentas { get; set; }

        [ForeignKey("Codcli")]
        public Cliente Cliente { get; set; }

        [ForeignKey("Codmon")]
        public Moneda Moneda { get; set; }

        [ForeignKey("Codcon")]
        public Condicion Condicion { get; set; }

        [ForeignKey("Codtipncf")]
        public TipoNcf TipoNcf { get; set; }
    }
}
