using MasterApiTatis.Models;

namespace MasterApiTatis.Interface
{
    public interface IUnidadRepository
    {
        //intefas  con todos los metodo para interactuar 
        //con el repositorio ose alogica de nefocio 

        Task<IEnumerable<Unid>> GetAllUnidsAsync();
        Task<Unid> GetUnidByIdAsync(int id);
        Task AddUnidAsync(Unid unid);
        Task UpdateUnidAsync(Unid unid);
        Task<bool> UnidExistsAsync(int id);
    }
}
