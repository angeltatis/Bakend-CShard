using MasterApiTatis.Models;

namespace MasterApiTatis.Services
{
    public interface IUnidadService 
    {
        Task<IEnumerable<Unid>> GetAllUnidsAsync();
        Task<Unid> GetUnidByIdAsync(int id);
        Task AddUnidAsync(Unid unid);
        Task UpdateUnidAsync(int id, Unid unid);
        Task desactivarUnidAsync(int id);
        Task<bool> UnidExistsAsync(int id);
    }
}
