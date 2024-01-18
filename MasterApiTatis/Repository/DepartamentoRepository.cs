using MasterApiTatis.Context;
using MasterApiTatis.Interface;
using MasterApiTatis.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterApiTatis.Repository
{
    public class DepartamentoRepository :  IDepartamentoRepository
    {
        //llamamos el dbcontext para utilizar los metodos del EF core 8  

        private readonly MyDbContext _context;

        //constructor del repositorio 
        public DepartamentoRepository(MyDbContext context)
        {
            _context = context;
        }

        public void actualizarDepartamento(Departamento departamento)
        {
            if (departamento == null) throw new ArgumentNullException(nameof(departamento));
            _context.Entry(departamento).State = EntityState.Modified;
        }

        public void CambiarEstadoDepartamento(Departamento departamento, bool newEstado)
        {
            if (departamento == null) throw new ArgumentNullException(nameof(departamento));
            departamento.estado = newEstado;
            _context.Entry(departamento).State = EntityState.Modified;
        }

        public void crearDepartamento(Departamento departamento)
        {
            if (departamento == null) throw new ArgumentNullException(nameof(departamento));
            _context.departamentos.Add(departamento);
        }

        public bool DepartamentoExistsAsync(int id)
        {
            return _context.departamentos.Any(e => e.coddep == id);
        }

        public async Task GuardarAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async  Task<Departamento> ObtenerDepartamentoPorCodigo(int id)
        {
            var deparamento = await _context.departamentos.FindAsync(id);
            if (deparamento == null)
            {
                // Si no se encuentra el ProductUnid, lanza una excepción de tipo KeyNotFoundException.
                throw new KeyNotFoundException("deparamento not found.");
            }
            return deparamento;
        }

        public async Task<IEnumerable<Departamento>> ObtenerTodosLosDepartamentosAsync()
        {
            return await _context.departamentos.ToListAsync();
        }
    }
}
