using MasterApiTatis.Models;

namespace MasterApiTatis.Services
{
    public interface IUnidProductService
    {
        Task<IEnumerable<ProductUnid>> GetAllProductUnidsAsync();
        Task<ProductUnid> GetProductUnidAsync(int id);
        Task UpdateProductUnidAsync(int id, ProductUnid productUnid);
        Task CreateProductUnidAsync(ProductUnid productUnid);
        Task ToggleProductUnidStatusAsync(int id);
    }
}
