using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Base;

namespace IgrejaJdLilah.Domain.Repository.Contrato
{
    public interface IRedeSocialRepository : IRepositoryBase<RedeSocial>
    {
        Task<RedeSocial[]>GetAllRedeSocialByNomeAsync(string nome, bool includeEventosPalestrentes);    
        Task<RedeSocial[]>GetAllRedeSocialAllAsync(bool includeEventosPalestrentes);
        Task<RedeSocial[]>GetRedeSocialByPalestranteIdAsync(int palestranteId, bool includePalestrante);
        Task<RedeSocial[]>GetRedeSocialByIdEventoAsync(int eventoId, bool includeEvento);
        Task<RedeSocial>GetRedeSocialByIdAsync(int redeSocialId, bool includeEventosPalestrentes);
        Task<bool>InseriAsync(RedeSocial redeSocial);  
        RedeSocial GetRedeSocialById(int redeSocialId, bool include);
        Task<bool> Alterar(RedeSocial redeSocial);
        Task<bool> Excluir(RedeSocial redeSocial);
        Task<bool> ExcluirRange(RedeSocial[] redeSocial);
    }
}