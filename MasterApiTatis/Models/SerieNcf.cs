using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Models
{
    [Table("serieNcf")]
    public class SerieNcf
    {
        [Key]
        [Column("codser", TypeName = "nvarchar(1)")]
        public string Codser { get; set; }

        public bool Estado { get; set; } = true;

        // Relaciones
        public List<SolicitudNcfD> SolicitudNcfd { get; set; }
    }
}
