using MasterApiTatis.Application.Interface;
using MasterApiTatis.Domain.Models;
using MasterApiTatis.Infraestructur.Context;
using Microsoft.EntityFrameworkCore;

namespace MasterApiTatis.Domain.Repository
{
    public class TipoProductRepository : ITipoProductoRepository
    {
        //llamamos el dbcontext para utilizar los metodos del EF core 8  

        private readonly MyDbContext _context;

        //constructor del repositorio 
        public TipoProductRepository(MyDbContext context)
        {
            _context = context;
        }

        public void actualizarTipoProd(TipoProduct tipoProduct)
        {
            if (tipoProduct == null) throw new ArgumentNullException(nameof(tipoProduct));
            _context.Entry(tipoProduct).State = EntityState.Modified;
        }

        public void CambiarTipoProducto(TipoProduct tipoProduct, bool newEstado)
        {
            if (tipoProduct == null) throw new ArgumentNullException(nameof(tipoProduct));
            tipoProduct.estado = newEstado;
            _context.Entry(tipoProduct).State = EntityState.Modified;
        }

        public void crearTipoProd(TipoProduct tipoProduct)
        {
            if (tipoProduct == null) throw new ArgumentNullException(nameof(tipoProduct));
            _context.tipos.Add(tipoProduct);
        }

        public async Task GuardarAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TipoProduct> ObtenerPorCodigo(int id)
        {
            var tipoProducto = await _context.tipos.FindAsync(id);

            if (tipoProducto == null)
            {
                // Si no se encuentra el ProductUnid, lanza una excepción de tipo KeyNotFoundException.
                throw new KeyNotFoundException("tipoProducto not found.");
            }
            return tipoProducto;
        }

        public async Task<IEnumerable<TipoProduct>> ObtenerTipProdAsync()
        {
            return await _context.tipos.ToListAsync();
        }

        public bool tipoProdExistAsync(int id)
        {
            return _context.tipos.Any(e => e.codtippro == id);
        }
    }
}
