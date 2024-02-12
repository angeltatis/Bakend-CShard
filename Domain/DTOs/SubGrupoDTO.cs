using MasterApiTatis.Domain.Models;

namespace MasterApiTatis.Application.DTOs
{
    public class SubGrupoDTO
    {
        public int Codsubgrup { get; set; }
        public string Dessubgrup { get; set; }
        public bool Estado { get; set; } = true;

        public List<ProductoDTO> Productos { get; set; }
    }
}
