using MasterApiTatis.Application.Interface;
using MasterApiTatis.Domain.Models;
using MasterApiTatis.Funciones;
using MasterApiTatis.Infraestructur.Services;
using Microsoft.Data.SqlClient;

namespace MasterApiTatis.Application.Implemets
{
    public class IDepartamentoImp : IDepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly ILogger<IDepartamentoImp> _logger;

        public IDepartamentoImp(IDepartamentoRepository departamentoRepository, ILogger<IDepartamentoImp> logger)
        {
            _departamentoRepository = departamentoRepository ?? throw new ArgumentNullException(nameof(departamentoRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task CreateDepartamentoAsync(Departamento departamento)
        {
            try
            {
                _departamentoRepository.crearDepartamento(departamento);
                await _departamentoRepository.GuardarAsync();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error al crear Departamento" + ex.Message);
                throw new DatabaseException("Error al insertar los datos: ", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Inesperado " + ex.Message);
                throw;
            }
        }

        public Task<bool> ExistDepartamento(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Departamento>> GetAllDepartamentosAsync()
        {
            try
            {
                return await _departamentoRepository.ObtenerTodosLosDepartamentosAsync();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error al Obtener Todos los departamentos" + ex.Message);
                throw new DatabaseException("Error al Obtener los datos: ", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Inesperado " + ex.Message);
                throw;
            }
        }

        public async Task<Departamento> GetDepartamentoAsync(int id)
        {
            try
            {
                return await _departamentoRepository.ObtenerDepartamentoPorCodigo(id);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error al Obtner Departamento" + ex.Message);
                throw new DatabaseException("Error al Obtener los datos: ", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Inesperado " + ex.Message);
                throw;
            }
        }

        public async Task ToggleDepartamentoStatusAsync(int id)
        {
            var departamento = await _departamentoRepository.ObtenerDepartamentoPorCodigo(id);
            try
            {
                if (departamento == null)
                {
                    throw new KeyNotFoundException("No se encontro el departamento");
                }

                _departamentoRepository.CambiarEstadoDepartamento(departamento, !departamento.estado);
                await _departamentoRepository.GuardarAsync();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error al Cambiar Estado departamento" + ex.Message);
                throw new DatabaseException("Error al Cambiar los datos: ", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Inesperado " + ex.Message);
                throw;
            }
        }

        public async Task UpdateDepartamentoAsync(int id, Departamento departamento)
        {
            try
            {
                if (id != departamento.coddep)
                {
                    throw new KeyNotFoundException("El codigo no coincide con el del departamento");
                }
                _departamentoRepository.actualizarDepartamento(departamento);
                await _departamentoRepository.GuardarAsync();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error al Actualizar departamento" + ex.Message);
                throw new DatabaseException("Error al Actualizar los datos: ", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Inesperado " + ex.Message);
                throw;
            }
        }
    }
}
