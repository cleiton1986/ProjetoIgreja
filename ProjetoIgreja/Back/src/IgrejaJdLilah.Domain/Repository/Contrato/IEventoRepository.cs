using System.Collections.Generic;
using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Base;

namespace IgrejaJdLilah.Domain.Repository.Contrato
{
    public interface IEventoRepository : IRepositoryBase<Evento>
    {
      Task<Evento[]>GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
      Task<Evento[]>GetAllEventosByAsync(bool includePalestrantes);
      Task<Evento>GetEventoByIdAsync(int eventoId, bool includePalestrantes);
      Evento GetEventoById(int enventoId, bool includeEndereco);
      Task<bool> Alterar(Evento model);
      Task<bool> Excluir(Evento model);
      Task<bool> ExcluirRange(Evento[] model);
      Task<bool>InseriAsync(Evento model);
    }
}