
using MasterApiTatis.Interface;
using MasterApiTatis.Models;
using MasterApiTatis.Services;

namespace MasterApiTatis.Implemets
{

    //implementamos el servisio eservisio con iyeciones del repositorio 

    public class ProductImp : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductImp(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductAsync(string id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task CreateProductAsync(Product product)
        {
            await _productRepository.AddProductAsync(product);
        }

        public async Task UpdateProductAsync(string id, Product product)
        {
            if (id != product.codpro)
                throw new ArgumentException("ID mismatch");

            if (!await _productRepository.ProductExistsAsync(id))
                throw new KeyNotFoundException("Product not found");

            await _productRepository.UpdateProductAsync(product);
        }

        public async Task ToggleProductStatusAsync(string id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
                throw new KeyNotFoundException("Product not found");

            product.estado = !product.estado;
            await _productRepository.UpdateProductAsync(product);
        }


        public Task<bool> ProductExistsAsync(string id)
        {
            return _productRepository.ProductExistsAsync(id);
        }
    }
}
