using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Models
{
    [Table("unidad_producto")]
    public class Unidad_producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codunipro { get; set; }


        [Required(ErrorMessage = "El código del producto es obligatorio.")]
        [MaxLength(15, ErrorMessage = "El código del producto no debe exceder los 15 caracteres.")]
        public string codpro { get; set; }

        [ForeignKey("codpro")]
        public Producto product { get; set; }

        [Required(ErrorMessage = "El código de la unidad es obligatorio.")]
        [ForeignKey("coduni")]
        public int coduni { get; set; }



        [Required]
        public decimal precio1 { get; set; }


        public decimal precio2 { get; set; }

        public decimal precio3 { get; set; }

        public required decimal costo1 { get; set; }

        public decimal costo2 { get; set; }

        public decimal costo3 { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool estado { get; set; }


    }
}
