using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;

namespace IgrejaJdLilah.Application.Contratos.IgrejaJdLilah
{
    public interface IPalestrantesApp
    {
      Task<Palestrante[]>GetAllPalestrantesByNomeAsync(string nome, bool include);
      Task<Palestrante[]>GetAllPalestrantesByDenominacaoAsync(string denominacao, bool include);
      Task<Palestrante[]>GetAllPalestrantesByMesmaDenominacaoAsync(bool mesmaDenominacao, bool include);
      Task<Palestrante[]>GetAllPalestrantesByAsync(bool include);
      Task<Palestrante>GetPalestranteByIdAsync(int palestrantesId, bool include);    
      Task<Palestrante> AddeEvento(Palestrante model);  
      Palestrante GetPalestranteById(int palestranteId, bool include);
      Task<Palestrante> AleterarEvento(Palestrante model);
      Task<bool> ExcluirPalestrante(int model, bool include);
      Task<bool> ExcluirPalestranteRange(Palestrante[] model);
    }
}