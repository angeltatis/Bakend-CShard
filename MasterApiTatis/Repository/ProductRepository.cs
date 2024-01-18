using MasterApiTatis.Context;
using MasterApiTatis.Interface;
using MasterApiTatis.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterApiTatis.Repository
{
    public class ProductRepository :  IProductRepository
    {
        //llamamos el dbcontext para utilizar los metodos del EF core 8  

        private readonly MyDbContext _context;

        //constructor del repositorio 
        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }

        //Obtener todos Los productos 
        public async Task<IEnumerable<Producto>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        //Obtener producto por codigo
        public async Task<Producto> GetProductByIdAsync(string id)
        {
            return await _context.Products.FindAsync(id);
        }

        //agregar productos a las base de datos 
        public async Task AddProductAsync(Producto product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        //actuizar productos existentes 
        public async Task UpdateProductAsync(Producto product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //validacion de que el produto exista antes de hacer la creacion 
        public async Task<bool> ProductExistsAsync(string id)
        {
            return await _context.Products.AnyAsync(e => e.codpro == id);
        }
    }
}
