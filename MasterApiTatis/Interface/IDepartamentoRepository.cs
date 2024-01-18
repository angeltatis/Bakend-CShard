using MasterApiTatis.Models;

namespace MasterApiTatis.Interface
{
    public interface IDepartamentoRepository
    {
        //repositorio para los DEPARTAMENTO
        Task<IEnumerable<Departamento>> ObtenerTodosLosDepartamentosAsync();
        Task<Departamento> ObtenerDepartamentoPorCodigo(int id);
        void crearDepartamento(Departamento departamento);
        void actualizarDepartamento(Departamento departamento);
        void CambiarEstadoDepartamento(Departamento departamento, bool newEstado);
        bool DepartamentoExistsAsync(int id);
        Task GuardarAsync();
    }
}
