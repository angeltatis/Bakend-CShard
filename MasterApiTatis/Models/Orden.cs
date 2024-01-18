using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Models
{
    [Table("orden")]
    public class Orden
    {
        [Key]
        public int  Id { get; set; }

        [Column("numord")]

    /*    se configura en api afluent 
        modelBuilder.Entity<Blog>()
       .HasIndex(b => b.Url)
        .IsUnique();
        [Index(IsUnique = true)]*/



        public required string  numorde { get; set; }

        [ForeignKey("codmon")]
        [Column ("codsup")]
        public required int codsupl { get; set; }

        [ForeignKey ("codmon")]
        [Column("codmone")]
        public required int codmone { get; set; }
        [ForeignKey("codcondi")]
        [Column("codcondi")]
        public required int codcondi { get; set; }

        [Column ("fecini")]        
        public required DateTime fecini { get; set; }


        [Column("fecent")]
        public required DateTime fecent { get; set; }

        [Column("notped")]
        public string notped { get; set; }

        [Column ("estado")]
        public required bool  estado { get; set; } = true;

//prueba
    }
}
