using MasterApiTatis.Models;

namespace MasterApiTatis.Services
{
    public interface IUnidadService 
    {
        Task<IEnumerable<Unidad>> GetAllUnidsAsync();
        Task<Unidad> GetUnidByIdAsync(int id);
        Task AddUnidAsync(Unidad unid);
        Task UpdateUnidAsync(int id, Unidad unid);
        Task desactivarUnidAsync(int id);
        Task<bool> UnidExistsAsync(int id);
        Task<bool> ExisteConDescripcion(string desuni);
    }
}
