using MasterApiTatis.Models;

namespace MasterApiTatis.Services
{
    public interface IGrupoService
    {

        Task<IEnumerable<Grupo>> GetAllGruposAsync();
        Task<Grupo> GetGrupoAsync(int id);
        Task UpdateGrupoAsync(int id, Grupo grupo);
        Task CreateGrupoAsync(Grupo grupo);
        Task<bool> grupoExiste(int id);
        Task ToggleGrupoStatusAsync(int id);
    }
}
