using MasterApiTatis.Domain.Models;

namespace MasterApiTatis.Infraestructur.Services
{
    public interface IUnidProductService
    {
        Task<IEnumerable<Unidad_producto>> GetAllProductUnidsAsync();
        Task<Unidad_producto> GetProductUnidAsync(int id);
        Task UpdateProductUnidAsync(int id, Unidad_producto productUnid);
        Task CreateProductUnidAsync(Unidad_producto productUnid);
        Task ToggleProductUnidStatusAsync(int id);
    }
}
