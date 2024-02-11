using MasterApiTatis.Domain.Models;

namespace MasterApiTatis.Infraestructur.Services
{
    public interface ISerieNcfService
    {
        Task<IEnumerable<SerieNcf>> GetAllSeriesAsync();
        Task<SerieNcf> GetSerieByIdAsync(string codserncf);

    }
}
