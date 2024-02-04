using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Models
{
    [Table("solicitudNcf")]
    public class SolicitudNcf
    {
        [Key]
        [Column("codsol", TypeName = "nvarchar(255)")] // Ajusta el tipo de dato según tus necesidades
        public string Codsol { get; set; }

        [Column("codser", TypeName = "nvarchar(1)")] // Ajusta el tipo de dato según tus necesidades
        public string Codser { get; set; }

        [Column("fecsol")]
        public DateTime Fecsol { get; set; }

        [Column("fecven")]
        public DateTime Fecven { get; set; }

        public bool Estado { get; set; } = true;

        // Relaciones
        public List<SolicitudNcfD> Detallesncf { get; set; }

        [ForeignKey("Codser")]
        public SerieNcf Serie { get; set; }
    }
}
