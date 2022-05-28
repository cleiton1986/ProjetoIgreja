using System.Threading.Tasks;
using IgrejaJdLilah.Application.Model;
using IgrejaJdLilah.Domain.Entidades;

namespace IgrejaJdLilah.Application.Contratos.IgrejaJdLilah
{
    public interface IEventoApp
    {
      Task<EventoViewModel[]>GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
      Task<EventoViewModel[]>GetAllEventosByAsync(bool includePalestrantes);
      Task<string[]> GetAllEventosImagensByAsync();
      Task<EventoViewModel>GetEventoByIdAsync(int eventoId, bool includePalestrantes);      
      EventoViewModel GetEventoById(int enventoId, bool includeEndereco);
      Task<EventoViewModel> AleterarEvento(EventoViewModel model);
      Task<bool> ExcluirEvento(int eventoId);
      Task<bool> ExcluirEventoRange(EventoViewModel[] model);
      Task<EventoViewModel>AddEvento(EventoViewModel model);
    }
}