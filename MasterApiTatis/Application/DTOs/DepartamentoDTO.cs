using MasterApiTatis.Domain.Models;

namespace MasterApiTatis.Application.DTOs
{
    public class DepartamentoDTO
    {
        public int Coddep { get; set; }
        public string Desdep { get; set; }
        public bool Estado { get; set; } = true;

        public List<ProductoDTO> Productos { get; set; }
    }
}
