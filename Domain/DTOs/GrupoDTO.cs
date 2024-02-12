using MasterApiTatis.Domain.Models;

namespace MasterApiTatis.Application.DTOs
{
    public class GrupoDTO
    {
        public int Codgrup { get; set; }
        public string Desgrup { get; set; }
        public bool Estado { get; set; } = true;

        public List<ProductoDTO> Productos { get; set; }
    }
}
