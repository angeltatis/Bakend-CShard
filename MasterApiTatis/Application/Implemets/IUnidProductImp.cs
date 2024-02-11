using MasterApiTatis.Application.Interface;
using MasterApiTatis.Domain.Models;
using MasterApiTatis.Infraestructur.Services;

namespace MasterApiTatis.Application.Implemets
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
        public async Task CreateProductUnidAsync(Unidad_producto productUnid)
        {
            _unidProductRepository.Add(productUnid);
            await _unidProductRepository.SaveAsync();
        }

        // Obtiene todos los 'ProductUnid' de forma asíncrona.
        public async Task<IEnumerable<Unidad_producto>> GetAllProductUnidsAsync()
        {
            return await _unidProductRepository.GetAllAsync();
        }

        // Obtiene un 'ProductUnid' por su ID de forma asíncrona.
        public async Task<Unidad_producto> GetProductUnidAsync(int id)
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
        public async Task UpdateProductUnidAsync(int id, Unidad_producto productUnid)
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
