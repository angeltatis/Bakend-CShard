using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Domain.Models
{
    [Table("solicitudNcfD")]
    public class SolicitudNcfD
    {
        [Key]
        [Column("codsolncfd")]
        public int Codsolncfd { get; set; }

        [Column("codser", TypeName = "nvarchar(1)")] // Ajusta el tipo de dato según tus necesidades
        public string Codser { get; set; }

        [Column("codtipncf", TypeName = "nvarchar(255)")] // Ajusta el tipo de dato según tus necesidades
        public string Codtipncf { get; set; }

        [Column("codsol", TypeName = "nvarchar(255)")] // Ajusta el tipo de dato según tus necesidades
        public string Codsol { get; set; }

        [Column("secini")]
        public long Secini { get; set; }

        [Column("secfin")]
        public long Secfin { get; set; }

        [Column("secact")]
        public long Secact { get; set; }

        public bool Estado { get; set; } = true;

        // Relaciones
        [ForeignKey("Codser")]
        public SerieNcf SerieNcf { get; set; }

        [ForeignKey("Codtipncf")]
        public TipoNcf TipoNcf { get; set; }

        [ForeignKey("Codsol")]
        public SolicitudNcf SolicitudNcf { get; set; }
    }
}
