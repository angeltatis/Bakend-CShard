using MasterApiTatis.Domain.Models;

namespace MasterApiTatis.Application.DTOs
{
    public class TipoProductoDTO
    {
        public int Codtippro { get; set; }
        public string Destippro { get; set; }
        public bool Estado { get; set; } = true;
        public List<ProductoDTO> Productos { get; set; }
    }
}
