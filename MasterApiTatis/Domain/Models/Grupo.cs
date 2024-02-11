using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Domain.Models
{

    //entidad de grupos


    [Table("grupo")] //nombre de la tabla 
    public class Grupo
    {
        [Key] //indetificamos el  primari key 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codgrup { get; set; }

        [StringLength(25, MinimumLength = 5)] //como minimo para  registar la descripcion deve de tener 5 letras 
        public required string desgrup { get; set; }

        //configuramos el estado del grupo que deve de iniciar activo por defecto 
        public required bool estado { get; set; } = true;
    }
}
