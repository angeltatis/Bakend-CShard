using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Models
{
    [Table("compra")]
    public class Compra
    {

        [Key]
        public  string codcomp { get; set; }

        [Required]
        public bool estado { get; set; } = true;
    }
}
