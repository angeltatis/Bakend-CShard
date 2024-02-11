using MasterApiTatis.Application.Interface;
using MasterApiTatis.Domain.Models;
using MasterApiTatis.Infraestructur.Services;
using MasterApiTatis.Repository;

namespace MasterApiTatis.Application.Implemets
{
    public class ISerieNcfImp : ISerieNcfService
    {
        private readonly ISerieNcfRepository _serieNcfRepository;

        public ISerieNcfImp(ISerieNcfRepository serieNcfRepository)
        {
            _serieNcfRepository = serieNcfRepository;
        }

        public async Task<IEnumerable<SerieNcf>> GetAllSeriesAsync()
        {
            return await _serieNcfRepository.GetAllSeriesAsync();
        }

        public async Task<SerieNcf> GetSerieByIdAsync(string codserncf)
        {
            return await _serieNcfRepository.GetSerieByIdAsync(codserncf);

        }


    }
}
