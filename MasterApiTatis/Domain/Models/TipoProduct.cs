
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Domain.Models
{

    [Table("tipo_producto")]
    public class TipoProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codtippro { get; set; }

        [Required]
        public string destippro { get; set; }

        public bool valexi { get; set; }
        [Required]
        public bool estado { get; set; } = true;
    }
}
