using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Base;

namespace IgrejaJdLilah.Domain.Repository.Contrato
{
    public interface IEnderecoRepository : IRepositoryBase<Endereco>
    {
      Task<Endereco[]>GetAllEnderecosByCepAsync(string cep);
      Task<Endereco[]>GetAllEnderecoByAsync();
      Task<Endereco>GetEnderecoByEventoIdAsync(int enderecoId);
      Task<Endereco>GetEnderecoByIdAsync(int enderecoId);
      Endereco GetEnderecoById(int enderecoId);
      Task<bool> Alterar(Endereco model);
      Task<bool> Excluir(Endereco model);
      Task<bool> ExcluirRange(Endereco[] model);
      Task<bool>InseriAsync(Endereco model);
    }
}