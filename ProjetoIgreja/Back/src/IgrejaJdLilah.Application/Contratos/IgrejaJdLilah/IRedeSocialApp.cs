using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;

namespace IgrejaJdLilah.Application.Contratos.IgrejaJdLilah
{
    public interface IRedeSocialApp
    {
        Task<RedeSocial[]>GetAllRedeSocialByNomeAsync(string nome, bool includeEventosPalestrentes);    
        Task<RedeSocial[]>GetAllRedeSocialAllAsync(bool includeEventosPalestrentes);
        Task<RedeSocial[]>GetRedeSocialByPalestranteIdAsync(int palestranteId, bool includePalestrante);
        Task<RedeSocial[]>GetRedeSocialByIdEventoAsync(int eventoId, bool includeEvento);
        Task<RedeSocial>GetRedeSocialByRedeSocialIdAsync(int redeSocialId, bool includeEventosPalestrentes);
        RedeSocial GetRedeSocialById(int redeSocialId, bool include);
        Task<RedeSocial> AddRedeSocial(RedeSocial model);
        Task<RedeSocial> AleterarEvento(RedeSocial model);
        Task<bool> ExcluirRedeSocial(int redeSocialId);
        Task<bool> ExcluirRedeSocialRange(RedeSocial[] model);
         
    }
}