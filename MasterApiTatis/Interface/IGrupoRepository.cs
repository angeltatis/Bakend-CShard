using MasterApiTatis.Models;

namespace MasterApiTatis.Interface
{
    public interface IGrupoRepository
    {
        //repositorio para los Grupos

        Task<IEnumerable<Grupo>> ObtenerTodosLosGruposAsync();
        Task<Grupo> ObtenerGrupoPorCodigo(int  id);
        void Update(Grupo grupo);
        void Add(Grupo grupo);
        void ChangeStatus(Grupo grupo, bool newState);
        bool Exists(int id);
        Task SaveAsync();
    }
}
