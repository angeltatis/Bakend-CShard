using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Domain.Models
{
    [Table("suplidor")]
    public class Suplidor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codsup { get; set; }

        [MaxLength(255)]
        [Column("rnc", TypeName = "nvarchar(45)")]
        public string Rnc { get; set; }

        [MaxLength(255)]
        [Column("nomsup", TypeName = "nvarchar(45)")]
        public string Nomsup { get; set; }

        [MaxLength(255)]
        [Column("desdir", TypeName = "nvarchar(255)")]
        public string Desdir { get; set; }

        [MaxLength(255)]
        [Column("telefono", TypeName = "nvarchar(20)")]
        public string Telefono { get; set; }

        [MaxLength(255)]
        [Column("codtipncf", TypeName = "nvarchar(2)")]
        public string Codtipncf { get; set; }

        [ForeignKey("Codcon")]
        public int Codcon { get; set; }

        public bool Estado { get; set; } = true;

        // Estoy relacionado con
        public List<Orden> Ordenes { get; set; }

        public List<LiquidacionD> LiquidacionD { get; set; }

        public List<Compra> Compras { get; set; }

        // Relaciones
        [ForeignKey("Codcon")]
        public Condicion Condicion { get; set; }

        [ForeignKey("Codtipncf")]
        public TipoNcf TipoNcf { get; set; }
    }
}
