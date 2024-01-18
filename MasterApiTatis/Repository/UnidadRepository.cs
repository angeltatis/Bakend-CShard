using MasterApiTatis.Context;
using MasterApiTatis.Interface;
using MasterApiTatis.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterApiTatis.Repository
{
    public class UnidadRepository : IUnidadRepository
    {
        //llamamos el dbcontext para utilizar los metodos del EF core 8  

        private readonly MyDbContext _context;

        //constructor del repositorio 
        public UnidadRepository(MyDbContext context)
        {
            _context = context;
        }

        //crear unidad
        public async Task AddUnidAsync(Unid unid)
        {
            _context.Unids.AddAsync(unid);
            await _context.SaveChangesAsync();
        }


        //obtener unidades
        public async Task<IEnumerable<Unid>> GetAllUnidsAsync()
        {
            return await _context.Unids.ToListAsync();
        }

        //obtener unidad porsu id con el timpo  agrgar mas  
        public async Task<Unid> GetUnidByIdAsync(int id)
        {
            return await _context.Unids.FindAsync(id);
        }

        //obtener para validad si existe la unida antes de hacer el insert en la 
        //base de datos 

        public async Task<bool> UnidExistsAsync(int id)
        {
            return await _context.Unids.AnyAsync(e => e.coduni == id);
        }

        public async Task UpdateUnidAsync(Unid unid)
        {
            _context.Entry(unid).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
