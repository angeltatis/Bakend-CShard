using MasterApiTatis.Application.Interface;
using MasterApiTatis.Domain.Models;
using MasterApiTatis.Infraestructur.Services;

namespace MasterApiTatis.Application.Implemets
{
    public class UnidadImp : IUnidadService
    {
        private readonly IUnidadRepository _unidadRepository;

        public UnidadImp(IUnidadRepository unidadRepository)
        {
            _unidadRepository = unidadRepository;
        }

        public async Task AddUnidAsync(Unidad unid)
        {
            await _unidadRepository.AddUnidAsync(unid);
        }

        public async Task desactivarUnidAsync(int id)
        {
            var unid = await _unidadRepository.GetUnidByIdAsync(id);

            if (unid == null)
            {
                throw new KeyNotFoundException("Unidad no existe");
            }

            unid.estado = !unid.estado;
            await _unidadRepository.UpdateUnidAsync(unid);
        }

        public async Task<bool> ExisteConDescripcion(string desuni)
        {
            return await _unidadRepository.ExisteUnidadCondescripcion(desuni);
        }

        public async Task<IEnumerable<Unidad>> GetAllUnidsAsync()
        {
            return await _unidadRepository.GetAllUnidsAsync();
        }

        public async Task<Unidad> GetUnidByIdAsync(int id)
        {
            return await _unidadRepository.GetUnidByIdAsync(id);
        }

        public async Task<bool> UnidExistsAsync(int id)
        {
            return await _unidadRepository.UnidExistsAsync(id);
        }

        public async Task UpdateUnidAsync(int id, Unidad unid)
        {
            if (id != unid.coduni)
                throw new ArgumentException("Id mismathc");
            // Check if the Unid exists in the repository
            bool exists = await _unidadRepository.UnidExistsAsync(unid.coduni);
            if (!exists)
            {
                throw new KeyNotFoundException("Unidad no existe.");
            }

            // If the Unid exists, update it
            await _unidadRepository.UpdateUnidAsync(unid);
        }
    }
}
