using MasterApiTatis.Funciones;
using MasterApiTatis.Interface;
using MasterApiTatis.Models;
using MasterApiTatis.Services;
using Microsoft.Data.SqlClient;

namespace MasterApiTatis.Implemets
{
    public class ITipoProductImp : ITipoProductService
    {
        private readonly ITipoProductoRepository _tipoProductoRepository;
        private readonly ILogger<ITipoProductImp> _logger;

        public ITipoProductImp(ITipoProductoRepository tipoProductoRepository, ILogger<ITipoProductImp> logger)
        {
            _tipoProductoRepository = tipoProductoRepository ?? throw new ArgumentNullException(nameof(tipoProductoRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task CreateTipoProductAsync(TipoProduct tipoProduct)
        {
            try
            {
                _tipoProductoRepository.crearTipoProd(tipoProduct);
                await _tipoProductoRepository.GuardarAsync();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error al crear Tipo Producto" + ex.Message);
                throw new DatabaseException("Error al insertar los datos: ", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Inesperado " + ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<TipoProduct>> GetAllTipoProductsAsync()
        {
            try
            {
                return await _tipoProductoRepository.ObtenerTipProdAsync();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error al Obtenr todos Tipos de productos" + ex.Message);
                throw new DatabaseException("Error al insertar los datos: ", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Inesperado " + ex.Message);
                throw;
            }
        }

        public async Task<TipoProduct> GetProductUnidAsync(int id)
        {
            try
            {
                return await _tipoProductoRepository.ObtenerPorCodigo(id);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error al Obtner tipo producto" + ex.Message);
                throw new DatabaseException("Error al insertar los datos: ", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Inesperado " + ex.Message);
                throw;
            }
        }

        public Task<TipoProduct> GetTipoProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TipoExist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task ToggleTipoProductStatusAsync(int id)
        {
            var tipopro = await _tipoProductoRepository.ObtenerPorCodigo(id);
            try
            {
                if (tipopro != null)
                {
                    throw new KeyNotFoundException("El tipo de Producto no se encuentra");
                }
                _tipoProductoRepository.CambiarTipoProducto(tipopro, !tipopro.estado);
                await _tipoProductoRepository.GuardarAsync();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error al Cambiar estado al Tipo Product" + ex.Message);
                throw new DatabaseException("Error al insertar los datos: ", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Inesperado " + ex.Message);
                throw;
            }
        }

        public async Task UpdateTipoProductAsync(int id, TipoProduct tipoProduct)
        {

            try
            {
                if(id  != tipoProduct.codtippro)
                {
                    throw new KeyNotFoundException("El id registrado no coincide con el del  TipoProducto");
                }
                _tipoProductoRepository.actualizarTipoProd(tipoProduct);
                await _tipoProductoRepository.GuardarAsync();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error al Actualizar Tipo Product " + ex.Message);
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
