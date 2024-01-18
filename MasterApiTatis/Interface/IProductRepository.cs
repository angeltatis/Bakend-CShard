using MasterApiTatis.Models;

namespace MasterApiTatis.Interface
{
    public interface IProductRepository
    {

        //intefas  con todos los metodo para interactuar 
        //con el repositorio ose alogica de nefocio 
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(string id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task<bool> ProductExistsAsync(string id);
    }
}
