using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApiTatis.Models
{
    [Table("condicion")]
    public class Condicion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "codcon")]
        public int Codcon { get; set; }

        
        public string Descon { get; set; }

        [Column(name: "candi")]
        public int Candi { get; set; }
        
        public bool Estado { get; set; } = true;

        public List<Suplidor> Suplidores { get; set; }

        public List<Orden> Orden { get; set; }

        public List<Cliente> Clientes { get; set; }

        public List<Venta> Facturas { get; set; }

        public List<Compra> Compras { get; set; }
    }
}
