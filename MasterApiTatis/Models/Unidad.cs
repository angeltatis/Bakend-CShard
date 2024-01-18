using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Models
{

    [Table("unidad")]
    public class Unidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int coduni { get; set; }

        [Required]
        [MaxLength(100)]
        public string desuni { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool estado { get; set; } = true;

    }
}
