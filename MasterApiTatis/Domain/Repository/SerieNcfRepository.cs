using MasterApiTatis.Application.Interface;
using MasterApiTatis.Domain.Models;
using MasterApiTatis.Infraestructur.Context;
using Microsoft.EntityFrameworkCore;

namespace MasterApiTatis.Domain.Repository
{
    // Define la clase SerieNcfRepository que implementa la interfaz ISerieNcfRepository.
    public class SerieNcfRepository : ISerieNcfRepository
    {
        // Contexto de la base de datos (Entity Framework Core) inyectado a través del constructor.
        private readonly MyDbContext _context;

        // Constructor de la clase que recibe el contexto de la base de datos y lo asigna a una variable local.
        public SerieNcfRepository(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Método asíncrono para obtener todos los Series Ncf de la base de datos.

        public async Task<IEnumerable<SerieNcf>> GetAllSeriesAsync()
        {
            return await _context.seriesNcf.ToListAsync();
        }

        // Método asíncrono para obtener un Serie  ncf por su ID.
        public async Task<SerieNcf> GetSerieByIdAsync(string codserncf)
        {
            var serie = await _context.seriesNcf.FindAsync(codserncf);
            if (serie == null)
            {
                // Si no se encuentra la Serie ncf , lanza una excepción de tipo KeyNotFoundException.
                throw new KeyNotFoundException("Serie  not found.");
            }
            return serie;
        }


    }
}
