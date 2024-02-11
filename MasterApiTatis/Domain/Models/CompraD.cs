using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Domain.Models
{
    [Table("comprad")]
    public class CompraD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codcomd { get; set; }

        [Required]
        public int Codcom { get; set; }

        [MaxLength(25)]
        public string Codpro { get; set; }

        [Required]
        [Column(TypeName = "decimal(16,2)")]
        public decimal Cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(16,2)")]
        public decimal Precio { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal Despro { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal Itebi { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal Importe { get; set; }

        public bool Estado { get; set; } = true;

        // Relaciones con otras tablas
        [ForeignKey("Codpro")]
        public Producto Producto { get; set; }

        [ForeignKey("Codcom")]
        public Compra Compra { get; set; }

        [ForeignKey("Coduni")]
        public Unidad Unidad { get; set; }
    }
}
