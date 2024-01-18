using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Models
{
    [Table("subgrup")]
    public class  SubGrupo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codsubgrup { get; set; }

        [StringLength(25, MinimumLength = 5 )]   
        public required string dessubgrup { get; set; }

        public required bool estado {  get; set; } 
    }
}
