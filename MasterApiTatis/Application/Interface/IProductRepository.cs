using MasterApiTatis.Domain.Models;

namespace MasterApiTatis.Application.Interface
{
    public interface IProductRepository
    {

        //intefas  con todos los metodo para interactuar 
        //con el repositorio ose alogica de nefocio 
        Task<IEnumerable<Producto>> GetAllProductsAsync();
        Task<Producto> GetProductByIdAsync(string id);
        Task AddProductAsync(Producto product);
        Task UpdateProductAsync(Producto product);
        Task<bool> ProductExistsAsync(string id);
    }
}
