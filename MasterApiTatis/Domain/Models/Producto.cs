using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Domain.Models
{


    [Table("producto")]
    public class Producto
    {
        [Key]
        [MaxLength(15)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Agrega esto si codpro NO es generado por la base de datos.
        public required string codpro { get; set; }


        [StringLength(100, MinimumLength = 5)] // Usa esto si quieres especificar también una longitud mínima.
        [Display(Name = "Product Name")]
        public required string despro { get; set; } = string.Empty;

        public required int exipro { get; set; }

        //tipo del producto clave foranea 
        [ForeignKey("codtippro")]
        public int? tippro { get; set; }
        public TipoProduct tipoProduct { get; set; }


        //departamento calve foranea 
        [ForeignKey("coddep")]
        public int? coddep { get; set; }
        public Departamento departamento { get; set; }

        //clave foranea de grupo
        [ForeignKey("codgrup")]
        public int? codgrup { get; set; }
        public Grupo grupo { get; set; }

        //clave foranea de dub  grupo
        [ForeignKey("codsubgrup")]
        public required int codsubgrup { get; set; }
        public SubGrupo subgrupo { get; set; }

        public string imgurl { get; set; }

        [DefaultValue(true)]
        [Description("Estado del producto")]
        public required bool estado { get; set; } = true;


    }
}
