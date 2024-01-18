
using MasterApiTatis.Interface;
using MasterApiTatis.Models;
using MasterApiTatis.Services;

namespace MasterApiTatis.Implemets
{

    // Implementación del servicio 'UnidProductService' con inyección del repositorio.
    public class IUnidProductImp : IUnidProductService
    {
        private readonly IUnidProductRepository _unidProductRepository;

        // Constructor que inyecta el repositorio a través de la interfaz 'IUnidProductRepository'.
        public IUnidProductImp(IUnidProductRepository unidProductRepository)
        {
            _unidProductRepository = unidProductRepository;
        }

        // Crea un nuevo 'ProductUnid' de forma asíncrona.
        public async Task CreateProductUnidAsync(ProductUnid productUnid)
        {
            _unidProductRepository.Add(productUnid);
            await _unidProductRepository.SaveAsync();
        }

        // Obtiene todos los 'ProductUnid' de forma asíncrona.
        public async Task<IEnumerable<ProductUnid>> GetAllProductUnidsAsync()
        {
            return await _unidProductRepository.GetAllAsync();
        }

        // Obtiene un 'ProductUnid' por su ID de forma asíncrona.
        public async Task<ProductUnid> GetProductUnidAsync(int id)
        {
            return await _unidProductRepository.GetByIdAsync(id);
        }

        // Cambia el estado de un 'ProductUnid' basado en su ID de forma asíncrona.
        public async Task ToggleProductUnidStatusAsync(int id)
        {
            var productUnid = await _unidProductRepository.GetByIdAsync(id);
            if (productUnid == null)
            {
                throw new KeyNotFoundException("No se encontró el ProductUnid con el ID proporcionado.");
            }
            _unidProductRepository.ChangeStatus(productUnid, !productUnid.estado);
            await _unidProductRepository.SaveAsync();
        }

        // Actualiza un 'ProductUnid' existente basado en su ID de forma asíncrona.
        public async Task UpdateProductUnidAsync(int id, ProductUnid productUnid)
        {
            if (id != productUnid.codunipro)
            {
                throw new ArgumentException("El ID no coincide con el ID del objeto ProductUnid.");
            }
            _unidProductRepository.Update(productUnid);
            await _unidProductRepository.SaveAsync();
        }
    }
}
