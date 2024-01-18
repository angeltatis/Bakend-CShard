using MasterApiTatis.Models;

namespace MasterApiTatis.Services
{
    public interface IDepartamentoService
    {

        Task<IEnumerable<Departamento>> GetAllDepartamentosAsync();
        Task<Departamento> GetDepartamentoAsync(int id);
        Task UpdateDepartamentoAsync(int id, Departamento departamento);
        Task CreateDepartamentoAsync(Departamento departamento);
        Task <bool> ExistDepartamento(int id);
        Task ToggleDepartamentoStatusAsync(int id);
    }
}
