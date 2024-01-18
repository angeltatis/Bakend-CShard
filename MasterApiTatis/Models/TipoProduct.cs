
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Models
{

    [Table("tipo_producto")]
    public class TipoProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codtippro { get; set; }

        public required string destippro { get; set; }

        public bool valexi { get; set; }

        public required bool estado { get; set; } = true;
    }
}
