using MasterApiTatis.Application.Interface;
using MasterApiTatis.Domain.Models;
using MasterApiTatis.Infraestructur.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace MasterApiTatis.Domain.Repository
{
    public class SubGrupoRepository : ISubGrupoRepository
    {
        //llamamos el dbcontext para utilizar los metodos del EF core 8  

        private readonly MyDbContext _context;

        //constructor del repositorio 
        public SubGrupoRepository(MyDbContext context)
        {
            _context = context;
        }

        public void actualizarSubGrupo(SubGrupo subGrupo)
        {
            if (subGrupo == null) throw new ArgumentNullException(nameof(subGrupo));
            _context.Entry(subGrupo).State = EntityState.Modified;
        }

        public void cambioEstado(SubGrupo subGrupo, bool nuwEstado)
        {
            if (subGrupo == null) throw new Exception(nameof(subGrupo));
            subGrupo.estado = nuwEstado;
            _context.Entry(subGrupo).State = EntityState.Modified;
        }

        public void crearSubGrupo(SubGrupo subGrupo)
        {
            if (subGrupo == null) throw new ArgumentNullException(nameof(subGrupo));
            _context.subGrupos.Add(subGrupo);
        }

        public async Task GuardarAsyc()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<SubGrupo> ObtenerPorCodigo(int id)
        {
            var subGrupo = await _context.subGrupos.FindAsync(id);
            if (subGrupo == null)
            {
                // Si no se encuentra el ProductUnid, lanza una excepción de tipo KeyNotFoundException.
                throw new KeyNotFoundException("ProductUnid not found.");
            }
            return subGrupo;
        }

        public async Task<IEnumerable<SubGrupo>> ObtenerSubGrupoAsync()
        {
            return await _context.subGrupos.ToListAsync();
        }

        public bool SubGrupoExistAsync(int id)
        {
            return _context.subGrupos.Any(e => e.codsubgrup == id);
        }
    }
}
