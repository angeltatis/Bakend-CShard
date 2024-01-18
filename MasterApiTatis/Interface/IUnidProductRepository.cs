using MasterApiTatis.Models;

namespace MasterApiTatis.Interface
{
    public interface IUnidProductRepository
    {
        Task<IEnumerable<ProductUnid>> GetAllAsync();
        Task<ProductUnid> GetByIdAsync(int id);
        void Update(ProductUnid productUnid);
        void Add(ProductUnid productUnid);
        void ChangeStatus(ProductUnid productUnid, bool newState);
        bool Exists(int id);
        Task SaveAsync();
    }
}
