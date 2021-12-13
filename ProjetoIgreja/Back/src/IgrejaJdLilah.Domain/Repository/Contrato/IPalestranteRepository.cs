using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Base;

namespace IgrejaJdLilah.Domain.Repository.Contrato
{
    public interface IPalestranteRepository : IRepositoryBase<Palestrante>
    {
      Task<Palestrante[]>GetAllPalestrantesByNomeAsync(string nome, bool include);
      Task<Palestrante[]>GetAllPalestrantesByDenominacaoAsync(string denominacao, bool include);
      Task<Palestrante[]>GetAllPalestrantesByMesmaDenominacaoAsync(bool mesmaDenominacao, bool include);
      Task<Palestrante[]>GetAllPalestrantesByAsync(bool include);
      Task<Palestrante>GetPalestranteByIdAsync(int palestrantesId, bool include);    
      Task<bool>InseriAsync(Palestrante lote);  
      Palestrante GetPalestranteById(int Id, bool include);
      Task<bool> Alterar(Palestrante palestrante);
      Task<bool> Excluir(Palestrante palestrante);
      Task<bool> ExcluirRange(Palestrante[] palestrante);
    }
}