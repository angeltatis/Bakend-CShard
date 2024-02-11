using MasterApiTatis.Application.Interface;
using MasterApiTatis.Domain.Models;
using MasterApiTatis.Infraestructur.Context;
using Microsoft.EntityFrameworkCore;


namespace MasterApiTatis.Domain.Repository
{
    public class GrupoRepository : IGrupoRepository
    {
        //llamamos el dbcontext para utilizar los metodos del EF core 8  

        private readonly MyDbContext _context;

        //constructor del repositorio 
        public GrupoRepository(MyDbContext context)
        {
            _context = context;
        }

        public async void Add(Grupo grupo)
        {
            _context.grupos.Add(grupo);
            await _context.SaveChangesAsync();
        }

        public void ChangeStatus(Grupo grupo, bool newState)
        {
            if (grupo == null)
                throw new ArgumentNullException(nameof(grupo));
            grupo.estado = newState;
            _context.Entry(grupo).State = EntityState.Modified;
        }

        public bool Exists(int id)
        {
            return _context.grupos.Any(e => e.codgrup == id);
        }

        public async Task<Grupo> ObtenerGrupoPorCodigo(int id)
        {
            var grupo = await _context.grupos.FindAsync(id);
            if (grupo == null)
            {
                // Si no se encuentra el ProductUnid, lanza una excepción de tipo KeyNotFoundException.
                throw new KeyNotFoundException("grupo not found.");
            }
            return grupo;
        }

        public async Task<IEnumerable<Grupo>> ObtenerTodosLosGruposAsync()
        {
            return await _context.grupos.ToListAsync();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Grupo grupo)
        {
            if (grupo == null) throw new ArgumentNullException(nameof(grupo));
            _context.Entry(grupo).State = EntityState.Modified;
        }
    }
}
