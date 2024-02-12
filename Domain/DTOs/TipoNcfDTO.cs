using MasterApiTatis.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace MasterApiTatis.Application.DTOs
{
    public class TipoNcfDTO
    {
        [StringLength(2, MinimumLength = 2, ErrorMessage = "El codigo debe tener entre 2 y 2 caracteres")]
        [RegularExpression("^[^<>]*$", ErrorMessage = "El codigo contiene caracteres inválidos")]
        public string Codtipncf { get; set; }

        public string Tipncfdes { get; set; }
        public string Desserie { get; set; }
        public bool Estado { get; set; } = true;
        public List<VentaDTO> Ventas { get; set; }
        public List<SolicitudNcfD> SolicitudNcfD { get; set; }
    }
}
