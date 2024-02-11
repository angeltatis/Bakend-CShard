using MasterApiTatis.Domain.Models;
using System.Drawing;

namespace MasterApiTatis.Application.Interface
{
    public interface ISerieNcfRepository
    {
        //intefas  con todos los metodo para interactuar 
        //con el repositorio ose alogica de nefocio 

        Task<IEnumerable<SerieNcf>> GetAllSeriesAsync();
        Task<SerieNcf> GetSerieByIdAsync(string codserncf);

    }
}
