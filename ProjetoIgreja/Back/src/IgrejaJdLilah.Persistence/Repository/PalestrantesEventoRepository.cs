using System.Linq;
using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Contrato;
using IgrejaJdLilah.Persistence.Base;
using IgrejaJdLilah.Persistence.Contexto;
using Microsoft.EntityFrameworkCore;

namespace IgrejaJdLilah.Persistence.Repository
{
    public class PalestrantesEventoRepository: RepositoryBase<PalestranteEvento>, IPalestranteEventoRepository
    {
        private readonly IgrejaJdLilahContext _contexto;
        public PalestrantesEventoRepository(IgrejaJdLilahContext contexto) : base(contexto)
        {
          _contexto = contexto;
        }
        public async Task<PalestranteEvento[]> GetAllPalestranteEventoAllAsync(bool includeEventosPalestrentes = false)
        {
            IQueryable<PalestranteEvento> query = _contexto.PalestranteEvento.AsNoTracking();

            if(includeEventosPalestrentes)
            {
                query = query 
                       .Include(e => e.Evento)
                       .Include(p => p.Palestrante)
                       .ThenInclude(p => p.RedeSociais);             
            }
                
            query = query.OrderBy(e => e.EventoId);
                   
            return await query.ToArrayAsync();
        }
        public async Task<PalestranteEvento[]> GetPalestranteEventoByIdEventoAsync(int eventoId, bool includeEvento = false)
        {
            IQueryable<PalestranteEvento> query = _contexto.PalestranteEvento.AsNoTracking();

            if(includeEvento)
                query = query .Include(e => e.Evento);

            query = query.OrderBy(e => e.EventoId)
                         .Where(e => e.EventoId == eventoId);
            return await query.ToArrayAsync();
        }
        public async Task<PalestranteEvento[]> GetPalestranteEventoByPalestranteIdAsync(int palestranteId, bool includePalestrante = false)
        {
            IQueryable<PalestranteEvento> query = _contexto.PalestranteEvento.AsNoTracking();

            if(includePalestrante)
            {
                query = query
                    .Include(e => e.Palestrante)
                    //Dentro de palestrante eventos inclua os palestrantes
                    .ThenInclude(e => e.RedeSociais);
            }
            
            query = query.OrderBy(e => e.PalestranteId)
                         .Where(e => e.PalestranteId == palestranteId);
            return await query.ToArrayAsync();
        }
    }
}