using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Domain.Models
{
    [Table("tipoNcf")]
    public class TipoNcf
    {
        [Key]
        [Column("codtipncf", TypeName = "nvarchar(2)")]
        public string Codtipncf { get; set; }

        [Column("tipncfdes", TypeName = "nvarchar(250)")]
        public string Tipncfdes { get; set; }

        [Column("desserie", TypeName = "nvarchar(250)")]
        public string Desserie { get; set; }

        public bool Estado { get; set; } = true;

        public List<Venta> Ventas { get; set; }

        public List<SolicitudNcfD> SolicitudNcfD { get; set; }

        public List<Suplidor> Suplidores { get; set; }
    }
}
