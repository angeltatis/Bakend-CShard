using MasterApiTatis.Application.DTOs;
using MasterApiTatis.Domain.Models;

namespace MasterApiTatis.Infraestructur.Services
{
    public interface IDepartamentoService
    {

        Task<IEnumerable<DepartamentoDTO>> GetAllDepartamentosAsync();
        Task<DepartamentoDTO> GetDepartamentoAsync(int id);
        Task UpdateDepartamentoAsync(int id, DepartamentoDTO departamento);
        Task CreateDepartamentoAsync(DepartamentoDTO departamento);
        Task<bool> ExistDepartamento(int id);
        Task ToggleDepartamentoStatusAsync(int id);
    }
}
