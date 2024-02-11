using MasterApiTatis.Domain.Models;

namespace MasterApiTatis.Infraestructur.Services
{
    public interface ISubGrupoService
    {

        Task<IEnumerable<SubGrupo>> GetAllSubGruposAsync();
        Task<SubGrupo> GetSubGrupoAsync(int id);
        Task UpdateSubGrupoAsync(int id, SubGrupo subGrupo);
        Task CreateSubGrupoAsync(SubGrupo subGrupo);
        Task<bool> SubGrupoExist(int id);
        Task ToggleSubGrupoStatusAsync(int id);
    }
}
