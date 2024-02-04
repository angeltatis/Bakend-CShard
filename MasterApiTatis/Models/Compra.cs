
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Models
{
    [Table("compra")]
    public class Compra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codcom { get; set; }

        [ForeignKey("codsup")]
        public int codsup { get; set; }

        [ForeignKey("codcon")]
        public int codcon { get; set; }

        [ForeignKey("codmon")]
        public int codmon { get; set; }

        [MaxLength(13)]
        //[Index(IsUnique = true)]
        public string ncf { get; set; }

        public DateTime fechaCompra { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal itebiTotal { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal desTotal { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal montoTotal { get; set; }

        public bool status { get; set; } = true;

        public List<CompraD> CompraDetalle { get; set; }

        //referencias del proyecto  

        [ForeignKey("Codsup")]
        public Suplidor Suplidor { get; set; }

        [ForeignKey("Codcon")]
        public Condicion Condicion { get; set; }

        [ForeignKey("Codmon")]
        public Moneda Moneda { get; set; }
    }
}
