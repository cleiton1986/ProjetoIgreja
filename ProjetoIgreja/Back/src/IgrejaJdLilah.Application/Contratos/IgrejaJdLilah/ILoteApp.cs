using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;

namespace IgrejaJdLilah.Application.Contratos.IgrejaJdLilah
{
    public interface ILoteApp
    {
      Task<Lote[]>GetAllLotesByAsync(bool include);
      Task<Lote[]>GetLotesByIdAsync(int loteId, bool include);
      Task<Lote>GetLoteByIdAsync(int loteId, bool include);
      Lote GetLoteById(int loteId, bool include);  
      Task<Lote> AlterarLote(Lote model);
      Task<bool> ExcluirLote(int loteId, bool include);
      Task<bool> ExcluirLoteRange(Lote[] model);
      Task<Lote>AddLote(Lote model);
    }
}