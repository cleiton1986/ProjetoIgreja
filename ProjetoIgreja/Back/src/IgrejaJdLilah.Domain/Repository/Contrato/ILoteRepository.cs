using System;
using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Base;

namespace IgrejaJdLilah.Domain.Repository.Contrato
{
    public interface ILoteRepository : IRepositoryBase<Lote>
    {
        
      Task<Lote[]>GetAllLoteByAsync(bool includeEvento);
      Task<Lote[]>GetLoteByIdEventoAsync(int eventoId, bool includeEvento);
      Task<Lote[]>GetLotesByIdAsync(int loteId, bool includeEvento);    
      Task<Lote> GetLoteByLoteIdAsync(int Id, bool include);
      Lote GetLoteById(int Id, bool includeEvento);
      Task<bool> Alterar(Lote model);
      Task<bool> Excluir(Lote model);
      Task<bool> ExcluirRange(Lote[] model);
     
    }
}