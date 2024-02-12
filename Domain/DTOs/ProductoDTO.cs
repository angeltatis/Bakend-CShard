using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MasterApiTatis.Application.DTOs
{
    public class ProductoDTO
    {

        [Required(ErrorMessage = "El Codigo no puede ser nulo")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "El Codigo debe tener entre 1 y 20 caracteres")]
        [RegularExpression("^[^<>]*$", ErrorMessage = "El Codigo contiene caracteres inválidos")]
        public string Codpro { get; set; }

        [Required(ErrorMessage = "La descripción no puede ser nula")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "La descripción debe tener entre 1 y 100 caracteres")]
        [RegularExpression("^[^<>]*$", ErrorMessage = "La descripción contiene caracteres inválidos")]
        public string Despro { get; set; }

        public bool Estado { get; set; } = true;

        // Si necesitas incluir las unidades del producto en el DTO, considera usar un DTO separado para UnidadProducto
        public List<UnidadProductoDTO> UnidadsProductos { get; set; }

    }
}
