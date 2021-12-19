using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;

namespace IgrejaJdLilah.Application.Contratos.IgrejaJdLilah
{
    public interface IContatoApp 
    {
        Task<Contato[]>GetContatosAllAsync(bool include);
        Task<Contato[]>GetAllContatoByDenominacaoAsync(string denominacao, bool include);
        Task<Contato>GetContatoByEmailAsync(string email, bool include);
        Task<Contato>GetContatoByContatoIdAsync(int contatoId, bool include);
        Task<Contato> AlterarContato(Contato model);
        Task<bool> ExcluirContato(int contatoId);
        Task<Contato> AddContato(Contato model);
        Contato GetContatoByContatoId(int contatoId, bool include);

    }
}