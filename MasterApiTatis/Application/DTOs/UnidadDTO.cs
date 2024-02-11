using System.ComponentModel.DataAnnotations;

namespace MasterApiTatis.Application.DTOs
{
    public class UnidadDTO
    {
        [Range(1, 99999, ErrorMessage = "El código de la unidad debe ser mayor o igual a 1 y menor o igual a 99999")]
        public int Coduni { get; set; }

        [Required(ErrorMessage = "La descripción no puede ser nula")]
        [StringLength(100, ErrorMessage = "La descripción debe tener entre 1 y 100 caracteres")]
        [RegularExpression("^[^<>]*$", ErrorMessage = "La descripción contiene caracteres inválidos")]
        public string Desuni { get; set; }

        public bool Estado { get; set; } = true;
    }
}
