using System.Linq;
using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Contrato;
using IgrejaJdLilah.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using IgrejaJdLilah.Persistence.Contexto;
using System;

namespace IgrejaJdLilah.Persistence.Repository
{
    public class EventoRepository : RepositoryBase<Evento>, IEventoRepository
    {
       private readonly IgrejaJdLilahContext _contexto;
       public EventoRepository(IgrejaJdLilahContext contexto) : base(contexto)
       {
          _contexto = contexto;
          //Não segura a requisição para que o entity trabalhe nos métadados
         // _contexto.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
       }

        public async Task<Evento[]> GetAllEventosByAsync(bool includePalestrante = false)
        {
             IQueryable<Evento> query = _contexto.Eventos
                                                 .Include(e => e.Lotes)
                                                 .Include(e => e.RedeSociais);

            if(includePalestrante)
            {
                query = query
                    .Include(e => e.PalestranteEventos)
                    //Dentro de palestrante eventos inclua os palestrantes
                    .ThenInclude(e => e.Palestrante);
            }
            
            query = query.OrderBy(e => e.Id)
                             .AsNoTracking();
            return await query.ToArrayAsync();
        }
        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
             IQueryable<Evento> query = _contexto.Eventos
                                                .Include(e => e.Lotes)
                                                .Include(e => e.RedeSociais);

            if(includePalestrante)
            {
                query = query
                    .Include(e => e.PalestranteEventos)
                    //Dentro de palestrante eventos inclua os palestrantes
                    .ThenInclude(e => e.Palestrante);
            }
            
            query = query.OrderBy(e => e.Id)
                         .AsNoTracking()
                         .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));
           
            return await query.ToArrayAsync();
        }
        public Evento GetEventoById(int enventoId, bool include = false)
        {
            IQueryable<Evento> evento = _contexto.Eventos
                                       .Include(e => e.Lotes)
                                       .Include(e => e.RedeSociais);
            
            if(include)
            {
                 evento = evento
                    .Include(e => e.PalestranteEventos)
                    //Dentro de palestrante eventos inclua os palestrantes
                    .ThenInclude(e => e.Palestrante);
            }
                

            evento = evento.OrderBy(c => c.Id)
                           .AsNoTracking()
                           .Where(c => c.Id == enventoId);
            return  evento.FirstOrDefault();
        }
        public async Task<bool> InseriAsync(Evento model)
        {
             return await InserirAsync(model);
        }
        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _contexto.Eventos
                                                .Include(e => e.Lotes)
                                                .Include(e => e.RedeSociais);

            if(includePalestrante)
            {
                query = query
                    .Include(e => e.PalestranteEventos)
                    //Dentro de palestrante eventos inclua os palestrantes
                    .ThenInclude(e => e.Palestrante);
            }
            
            query = query.AsNoTracking()
                         .OrderBy(e => e.Id)
                         .Where(e => e.Id == eventoId);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<bool> Alterar(Evento model)
        {
             return await AlterarAsync(model);
        }
        public async Task<bool> Excluir(Evento model)
        {
            return await ExcluirAsync(model);
        }
        public async Task<bool> ExcluirRange(Evento[] model)
        {
            return await ExcluirRengeAsync(model);
        }

    }
}