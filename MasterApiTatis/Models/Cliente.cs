using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Models
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codcli { get; set; }

        public string Numdoc { get; set; }


        public string Nom1 { get; set; }

        public string Nom2 { get; set; }

        [Column(name: "codcon")]
        public int Codcon { get; set; }


        public string Apepat { get; set; }

        public string Apemat { get; set; }


        public string Email { get; set; }

        public string Telefone { get; set; }


        public bool Estado { get; set; }

        public List<Venta> Venta { get; set; }

        // Relación
        [ForeignKey("Codcon")]
        public Condicion Condicion { get; set; }
    }
}
