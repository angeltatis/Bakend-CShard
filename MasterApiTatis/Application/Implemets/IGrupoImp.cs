using MasterApiTatis.Application.Funciones;
using MasterApiTatis.Application.Interface;
using MasterApiTatis.Domain.Models;
using MasterApiTatis.Infraestructur.Services;
using Microsoft.Data.SqlClient;


namespace MasterApiTatis.Application.Implemets
{
    public class IGrupoImp : IGrupoService
    {
        private readonly IGrupoRepository _grupoRepository;
        private readonly ILogger<IGrupoImp> _logger;

        public IGrupoImp(IGrupoRepository grupoRepository, ILogger<IGrupoImp> logger)
        {
            _grupoRepository = grupoRepository ?? throw new ArgumentNullException(nameof(grupoRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task CreateGrupoAsync(Grupo grupo)
        {
            try
            {
                _grupoRepository.Add(grupo);
                await _grupoRepository.SaveAsync();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error al Crear grupos desde la base de datos");
                throw new DatabaseException("Error al acceder a la base de datos", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al obtener grupos");
                throw;
            }
        }

        public async Task<IEnumerable<Grupo>> GetAllGruposAsync()
        {
            try
            {
                return await _grupoRepository.ObtenerTodosLosGruposAsync();
            }
            catch (SqlException ex)
            {
                // Log the exception details
                throw new Exception("Error al obtener grupos desde la base de datos" + ex.Message);
            }
            catch (Exception ex)
            {
                // Log unexpected exceptions
                throw new Exception("Error inesperado al obtener grupos: " + ex.Message);
            }
        }

        public async Task<Grupo> GetGrupoAsync(int id)
        {
            try
            {
                return await _grupoRepository.ObtenerGrupoPorCodigo(id);
            }
            catch (SqlException ex)
            {
                // Log the exception details
                throw new Exception("Error al obtener grupos desde la base de datos" + ex.Message);

            }
            catch (Exception ex)
            {
                // Log unexpected exceptions
                throw new Exception("Error inesperado al obtener grupos: " + ex.Message);

            }
        }

        public Task<bool> grupoExiste(int id)
        {
            throw new NotImplementedException();
        }

        public async Task ToggleGrupoStatusAsync(int id)
        {
            var grupo = await _grupoRepository.ObtenerGrupoPorCodigo(id);
            try
            {
                if (grupo == null)
                {
                    throw new KeyNotFoundException("No se encontro el grupo.");
                }
                _grupoRepository.ChangeStatus(grupo, !grupo.estado);
                await _grupoRepository.SaveAsync();
            }
            catch (SqlException ex)
            {
                // Log the exception details
                throw new Exception("Error al obtener grupos desde la base de datos" + ex.Message);
            }
            catch (Exception ex)
            {
                // Log unexpected exceptions
                throw new Exception("Error inesperado al obtener grupos: " + ex.Message);
            }
        }

        public async Task UpdateGrupoAsync(int id, Grupo grupo)
        {

            try
            {
                if (id != grupo.codgrup)
                {
                    throw new ArgumentException("El ID no coincide con el ID del objeto Grupo.");
                }
                _grupoRepository.Update(grupo);
                await _grupoRepository.SaveAsync();
            }
            catch (SqlException ex)
            {
                // Log the exception details
                throw new Exception("Error al obtener grupos desde la base de datos" + ex.Message);
            }
            catch (Exception ex)
            {
                // Log unexpected exceptions
                throw new Exception("Error inesperado al obtener grupos: " + ex.Message);
            }
        }
    }
}
