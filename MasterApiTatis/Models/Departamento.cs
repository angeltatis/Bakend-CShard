using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Models
{
    [Table("depar")]
    public class Departamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        public int coddep { get; set; }

        public required string desdep { get; set; }

        public required bool estado { get; set; } = true;


    }
}
