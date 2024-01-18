using MasterApiTatis.Context;
using MasterApiTatis.Interface;
using MasterApiTatis.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterApiTatis.Repository
{
    // Define la clase UnidProductRepository que implementa la interfaz IUnidProductRepository.
    public class UnidProductRepository : IUnidProductRepository
    {
        // Contexto de la base de datos (Entity Framework Core) inyectado a través del constructor.
        private readonly MyDbContext _context;

        // Constructor de la clase que recibe el contexto de la base de datos y lo asigna a una variable local.
        public UnidProductRepository(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Método asíncrono para obtener todos los ProductUnid de la base de datos.
        public async Task<IEnumerable<Unidad_producto>> GetAllAsync()
        {
            return await _context.ProductUnids.ToListAsync();
        }

        // Método asíncrono para obtener un ProductUnid por su ID.
        public async Task<Unidad_producto> GetByIdAsync(int id)
        {
            var productUnid = await _context.ProductUnids.FindAsync(id);
            if (productUnid == null)
            {
                // Si no se encuentra el ProductUnid, lanza una excepción de tipo KeyNotFoundException.
                throw new KeyNotFoundException("ProductUnid not found.");
            }
            return productUnid;
        }

        // Método para agregar un nuevo ProductUnid al contexto (prepararlo para ser insertado en la base de datos).
        public void Add(Unidad_producto productUnid)
        {
            if (productUnid == null) throw new ArgumentNullException(nameof(productUnid));
            _context.ProductUnids.Add(productUnid);
        }

        // Método para marcar un ProductUnid existente como modificado.
        public void Update(Unidad_producto productUnid)
        {
            if (productUnid == null) throw new ArgumentNullException(nameof(productUnid));
            _context.Entry(productUnid).State = EntityState.Modified;
        }

        // Método para cambiar el estado de un ProductUnid.
        public void ChangeStatus(Unidad_producto productUnid, bool newState)
        {
            if (productUnid == null) throw new ArgumentNullException(nameof(productUnid));
            productUnid.estado = newState;
            _context.Entry(productUnid).State = EntityState.Modified;
        }

        // Método para verificar si un ProductUnid existe en la base de datos.
        public bool Exists(int id)
        {
            return _context.ProductUnids.Any(e => e.codunipro == id);
        }

        // Método asíncrono para guardar los cambios en la base de datos.
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
