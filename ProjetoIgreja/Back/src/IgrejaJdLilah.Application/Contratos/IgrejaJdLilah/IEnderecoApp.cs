using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;

namespace IgrejaJdLilah.Application.Contratos.IgrejaJdLilah
{
    public interface IEnderecoApp
    {
      Task<Endereco[]>GetAllEnderecosByCepAsync(string cep);
      Task<Endereco[]>GetAllEnderecoByAsync();
      Task<Endereco>GetEventoByIdAsync(int enderecoId);
      Task<Endereco> GetEnderecoByIdAsync(int enderecoId);
      Endereco GetEnderecoById(int enderecoId);
      Task<Endereco> AlterarEndereco(Endereco model);
      Task<bool> ExcluirEndereco(int endereco);
      Task<bool> ExcluirEnderecoRange(Endereco[] model);
      Task<Endereco>AddEnderco(Endereco model); 
    }
}