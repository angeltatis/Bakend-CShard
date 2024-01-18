using MasterApiTatis.Models;

namespace MasterApiTatis.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductAsync(string id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(string id, Product product);
        Task ToggleProductStatusAsync(string id);
        Task<bool> ProductExistsAsync(string id);
    }
}
