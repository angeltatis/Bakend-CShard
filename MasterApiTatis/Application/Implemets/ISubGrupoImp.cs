using Microsoft.Data.SqlClient;
using MasterApiTatis.Domain.Models;
using MasterApiTatis.Application.Interface;
using MasterApiTatis.Infraestructur.Services;
using MasterApiTatis.Application.Funciones;

namespace MasterApiTatis.Application.Implemets
{
    public class ISubGrupoImp : ISubGrupoService
    {
        private readonly ISubGrupoRepository _subGrupoRepository;
        private readonly ILogger<ISubGrupoImp> _logger;

        public ISubGrupoImp(ISubGrupoRepository subGrupoRepository, ILogger<ISubGrupoImp> logger)
        {
            _subGrupoRepository = subGrupoRepository ?? throw new ArgumentException(nameof(subGrupoRepository));
            _logger = logger ?? throw new ArgumentException(nameof(logger));
        }

        public async Task CreateSubGrupoAsync(SubGrupo subGrupo)
        {
            try
            {
                _subGrupoRepository.crearSubGrupo(subGrupo);
                await _subGrupoRepository.GuardarAsyc();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error al crear Sub grupo" + ex.Message);
                throw new DatabaseException("Error al insertar los datos: ", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Inesperado " + ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<SubGrupo>> GetAllSubGruposAsync()
        {
            try
            {
                return await _subGrupoRepository.ObtenerSubGrupoAsync();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error al Obtener Sub grupo" + ex.Message);
                throw new DatabaseException("Error al Obtener los datos: ", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Inesperado " + ex.Message);
                throw;
            }
        }

        public async Task<SubGrupo> GetSubGrupoAsync(int id)
        {

            try
            {
                return await _subGrupoRepository.ObtenerPorCodigo(id);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error al crear Sub grupo" + ex.Message);
                throw new DatabaseException("Error al insertar los datos: ", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Inesperado " + ex.Message);
                throw;
            }
        }

        public Task<bool> SubGrupoExist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task ToggleSubGrupoStatusAsync(int id)
        {
            var subgrupo = await _subGrupoRepository.ObtenerPorCodigo(id);


            try
            {
                if (subgrupo == null)
                {
                    throw new KeyNotFoundException("No se Encontro el SubGrupo");
                }

                _subGrupoRepository.cambioEstado(subgrupo, !subgrupo.estado);
                await _subGrupoRepository.GuardarAsyc();

            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error al Cambiar Estado Sub grupo" + ex.Message);
                throw new DatabaseException("Error al Cambiar Estado los datos: ", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Inesperado " + ex.Message);
                throw;
            }

        }

        public async Task UpdateSubGrupoAsync(int id, SubGrupo subGrupo)
        {
            try
            {
                if (id != subGrupo.codsubgrup)
                {
                    throw new KeyNotFoundException("El id no coincide con el id del subgrupo");
                }
                _subGrupoRepository.actualizarSubGrupo(subGrupo);

                await _subGrupoRepository.GuardarAsyc();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error al crear Sub grupo" + ex.Message);
                throw new DatabaseException("Error al insertar los datos: ", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Inesperado " + ex.Message);
                throw;
            }
        }
    }
}
