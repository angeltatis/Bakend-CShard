using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Domain.Models
{
    [Table("ordenD")]
    public class OrdenD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Numdord { get; set; }

        public string Codpro { get; set; }

        public int Codord { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Precio { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Itebis { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Importe { get; set; }

        public bool Estado { get; set; } = true;

        // Relaciones
        [ForeignKey("Codpro")]
        public Producto Producto { get; set; }

        [ForeignKey("Codord")]
        public Orden Orden { get; set; }
    }
}
