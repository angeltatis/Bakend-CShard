using MasterApiTatis.Models;

namespace MasterApiTatis.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Producto>> GetAllProductsAsync();
        Task<Producto> GetProductAsync(string id);
        Task CreateProductAsync(Producto product);
        Task UpdateProductAsync(string id, Producto product);
        Task ToggleProductStatusAsync(string id);
        Task<bool> ProductExistsAsync(string id);
    }
}
