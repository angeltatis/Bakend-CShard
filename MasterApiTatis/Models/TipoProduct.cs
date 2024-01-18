
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Models
{

    /*Entidad de tipo de productos para la configuracion del mismo producto 
      nombre de la tabla: tippro
      primari ke: codtippro
      lleva su descripcion 
      estado: por defecto activo 
     */
    [Table("tippro")]
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
