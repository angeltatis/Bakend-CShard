using MasterApiTatis.Domain.Models;

namespace MasterApiTatis.Application.Interface
{
    public interface IUnidProductRepository
    {
        Task<IEnumerable<Unidad_producto>> GetAllAsync();
        Task<Unidad_producto> GetByIdAsync(int id);
        void Update(Unidad_producto productUnid);
        void Add(Unidad_producto productUnid);
        void ChangeStatus(Unidad_producto productUnid, bool newState);
        bool Exists(int id);
        Task SaveAsync();
    }
}
