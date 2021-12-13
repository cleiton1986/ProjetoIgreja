using System.Collections.Generic;
using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Base;

namespace IgrejaJdLilah.Domain.Repository.Contrato
{
    public interface IContatoRepository : IRepositoryBase<Contato>
    {
        Task<Contato[]>GetContatosAllAsync(bool includeEndereco);
        Task<Contato[]>GetAllContatoByDenominacaoAsync(string denominacao, bool includeEndereco);
        Task<Contato>GetContatoByEmailAsync(string email, bool includeEndereco);
        Task<Contato>GetContatoByContatoIdAsync(int contatoId, bool includeEndereco);
        Contato GetContatoByContatoId(int contatoId, bool includeEndereco);
        Task<bool> Alterar(Contato contato);
        Task<bool> Excluir(Contato contato);
        Task<bool> ExcluirRange(Contato[] contato);
        Task<bool>InseriAsync(Contato contato);
    }
}