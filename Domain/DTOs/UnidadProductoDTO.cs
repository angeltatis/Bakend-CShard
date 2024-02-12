using System.ComponentModel.DataAnnotations;

namespace MasterApiTatis.Application.DTOs
{
    public class UnidadProductoDTO
    {
        public int Id { get; set; }
        public decimal Canpro { get; set; }
        public decimal Cospro1 { get; set; }
        public decimal Cospro2 { get; set; }
        public decimal Prepro1 { get; set; }
        public decimal Prepro2 { get; set; }
        public bool Estado { get; set; } = true;

        [Range(1, 99999, ErrorMessage = "El código de la unidad debe ser mayor o igual a 1 y menor o igual a 99999")]
        public int Coduni { get; set; }

        [Required(ErrorMessage = "El Codigo no puede ser nulo")]
        [StringLength(20, ErrorMessage = "El Codigo debe tener entre 1 y 20 caracteres")]
        [RegularExpression("^[^<>]*$", ErrorMessage = "El Codigo contiene caracteres inválidos")]
        public string Codpro { get; set; }
    }
}
