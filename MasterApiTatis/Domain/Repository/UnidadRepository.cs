using MasterApiTatis.Application.Interface;
using MasterApiTatis.Domain.Models;
using MasterApiTatis.Infraestructur.Context;
using Microsoft.EntityFrameworkCore;

namespace MasterApiTatis.Domain.Repository
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
        public async Task AddUnidAsync(Unidad unid)
        {
            _context.Unids.AddAsync(unid);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExisteUnidadCondescripcion(string desuni)
        {
            return await _context.Unids.AnyAsync(d => d.desuni == desuni);
        }


        //obtener unidades
        public async Task<IEnumerable<Unidad>> GetAllUnidsAsync()
        {
            return await _context.Unids.ToListAsync();
        }

        //obtener unidad porsu id con el timpo  agrgar mas  
        public async Task<Unidad> GetUnidByIdAsync(int id)
        {
            return await _context.Unids.FindAsync(id);
        }

        //obtener para validad si existe la unida antes de hacer el insert en la 
        //base de datos 

        public async Task<bool> UnidExistsAsync(int id)
        {
            return await _context.Unids.AnyAsync(e => e.coduni == id);
        }

        public async Task UpdateUnidAsync(Unidad unid)
        {
            _context.Entry(unid).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
