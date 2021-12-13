using System.Linq;
using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Contrato;
using IgrejaJdLilah.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using IgrejaJdLilah.Persistence.Contexto;

namespace IgrejaJdLilah.Persistence.Repository
{
    public class LoteRepository : RepositoryBase<Lote>, ILoteRepository
    {
        private readonly IgrejaJdLilahContext _contexto;
        public LoteRepository(IgrejaJdLilahContext contexto) : base(contexto)
        {
          _contexto = contexto;
        }
       
        public async Task<Lote[]> GetAllLoteByAsync(bool includeEvento = false)
        {
            IQueryable<Lote> query = _contexto.Lote;

            if(includeEvento)
            {
                query = query
                    .Include(l => l.Evento)
                    //Dentro de evento  inclua os palestrantes
                    .ThenInclude(e => e.PalestranteEventos);
            }
            
            query = query.AsNoTracking()
                          .OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }
        public Lote GetLoteById(int loteId, bool includeEvento = false)
        {
             IQueryable<Lote> lote = _contexto.Lote.AsNoTracking();

            if(includeEvento)
                 lote = lote.Include(l => l.Evento);

            lote = lote.OrderBy(c => c.Id)
                         .Where(c => c.Id == loteId);
            return  lote.FirstOrDefault();
        }
        public async Task<Lote[]> GetLotesByIdAsync(int loteId, bool includeEvento = false)
        {
            IQueryable<Lote> query = _contexto.Lote.AsNoTracking();

            if(includeEvento)
            {
                query = query
                    .Include(l => l.Evento)
                    //Dentro de evento  inclua os palestrantes
                    .ThenInclude(e => e.PalestranteEventos);
            }
            query = query.Where(l => l.Id == loteId);
            return await query.ToArrayAsync();
        }
        public async Task<Lote[]> GetLoteByIdEventoAsync(int eventoId, bool includeEvento = false)
        {
             IQueryable<Lote> query = _contexto.Lote.AsNoTracking();

            if(includeEvento)
                query = query.Include(l => l.Evento);

            query = query.OrderBy(e => e.EventoId)
                         .Where(e => e.EventoId == eventoId);

            return await query.ToArrayAsync();
        }
        public async Task<bool> InseriAsync(Lote model)
        {
            return await InserirAsync(model);
        }
        public async Task<bool> Alterar(Lote model)
        {
            return await AlterarAsync(model);
        }
        public async Task<bool> Excluir(Lote model)
        {
             return await ExcluirAsync(model);
        }
        public async Task<bool> ExcluirRange(Lote[] model)
        {
            return await ExcluirRengeAsync(model);
        }
        public Lote GetLotesById(int loteId, bool includeEvento = false)
        {
             IQueryable<Lote> lote = _contexto.Lote.AsNoTracking();

            if(includeEvento)
                 lote = lote.Include(l => l.Evento);

            lote = lote.OrderBy(c => c.Id)
                         .Where(c => c.Id == loteId);
            return  lote.FirstOrDefault();
        }
        public async Task<Lote> GetLoteByLoteIdAsync(int loteId, bool include)
        {
            IQueryable<Lote> lote =  _contexto.Lote.AsNoTracking();

            if(include)
               lote = lote.Include(l => l.Evento);
       
            lote =  lote.OrderBy(c => c.Id)
                         .Where(c => c.Id == loteId);
            return await lote.FirstOrDefaultAsync();
        }

    }
}