using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;

namespace IgrejaJdLilah.Application.Contratos.IgrejaJdLilah
{
    public interface IEventoApp
    {
      Task<Evento[]>GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
      Task<Evento[]>GetAllEventosByAsync(bool includePalestrantes);
      Task<Evento>GetEventoByIdAsync(int eventoId, bool includePalestrantes);      
      Evento GetEventoById(int enventoId, bool includeEndereco);
      Task<Evento> AleterarEvento(Evento model);
      Task<bool> ExcluirEvento(int eventoId);
      Task<bool> ExcluirEventoRange(Evento[] model);
      Task<Evento>AddEvento(Evento model);
    }
}