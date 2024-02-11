
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Domain.Models
{
    [Table("orden")]
    public class Orden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codord { get; set; }

        public int Codmon { get; set; }

        public int Codcon { get; set; }

        public int Codsup { get; set; }

        [Required]
        public DateTime Fecpro { get; set; }

        [Required]
        public DateTime Fecfin { get; set; }

        [Required]
        public decimal Itebis { get; set; }

        [Required]
        public decimal Total { get; set; }

        public bool Estado { get; set; } = true;

        public List<OrdenD> Detalles { get; set; }

        // Relaciones
        [ForeignKey("Codmon")]
        public Moneda Moneda { get; set; }

        [ForeignKey("Codcon")]
        public Condicion Condicion { get; set; }

        [ForeignKey("Codsup")]
        public Suplidor Suplidor { get; set; }
    }
}
