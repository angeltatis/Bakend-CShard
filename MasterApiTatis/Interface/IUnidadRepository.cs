using MasterApiTatis.Models;

namespace MasterApiTatis.Interface
{
    public interface IUnidadRepository
    {
        //intefas  con todos los metodo para interactuar 
        //con el repositorio ose alogica de nefocio 

        Task<IEnumerable<Unidad>> GetAllUnidsAsync();
        Task<Unidad> GetUnidByIdAsync(int id);
        Task AddUnidAsync(Unidad unid);
        Task UpdateUnidAsync(Unidad unid);
        Task<bool> UnidExistsAsync(int id);
    }
}
