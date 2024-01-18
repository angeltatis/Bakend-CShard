using MasterApiTatis.Models;

namespace MasterApiTatis.Interface
{
    public interface ITipoProductoRepository
    {
        //repositorio de la interfaces  

        Task<IEnumerable<TipoProduct>> ObtenerTipProdAsync();
        Task<TipoProduct> ObtenerPorCodigo(int id);
        void crearTipoProd(TipoProduct tipoProduct);
        void actualizarTipoProd(TipoProduct tipoProduct);
        void  CambiarTipoProducto(TipoProduct tipoProduct, bool newEstado);
        bool tipoProdExistAsync(int id);
        Task GuardarAsync();

    }
}
