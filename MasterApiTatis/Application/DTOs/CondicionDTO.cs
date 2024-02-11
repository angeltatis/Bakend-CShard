using System.ComponentModel.DataAnnotations;

namespace MasterApiTatis.Application.DTOs
{
    public class CondicionDTO
    {
        public int Codcon { get; set; }

        [StringLength(45, MinimumLength = 1, ErrorMessage = "La descripcion no puede ser menor a 1 ni mayor a 45")]
        [RegularExpression("^[^<>]*$", ErrorMessage = "La descripción contiene caracteres inválidos")]
        public string Descon { get; set; }

        public int Candi { get; set; }
        public bool Estado { get; set; }

        // Considera incluir contadores para representar la cantidad de entidades relacionadas
        // en lugar de incluir las colecciones completas
        public int TotalSuplidores { get; set; }
        public int TotalOrdenes { get; set; }
        public int TotalClientes { get; set; }
        public int TotalFacturas { get; set; }
        public int TotalCompras { get; set; }
    }
}
