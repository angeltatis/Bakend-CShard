using MasterApiTatis.Domain.Models;

namespace MasterApiTatis.Application.Interface
{
    public interface ISubGrupoRepository
    {
        //repositorio de la interfaces  

        Task<IEnumerable<SubGrupo>> ObtenerSubGrupoAsync();
        Task<SubGrupo> ObtenerPorCodigo(int id);
        void crearSubGrupo(SubGrupo subGrupo);
        void actualizarSubGrupo(SubGrupo subGrupo);
        void cambioEstado(SubGrupo subGrupo, bool nuwEstado);
        bool SubGrupoExistAsync(int id);
        Task GuardarAsyc();
    }
}
