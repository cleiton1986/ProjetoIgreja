using System.Linq;
using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Contrato;
using IgrejaJdLilah.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using IgrejaJdLilah.Persistence.Contexto;

namespace IgrejaJdLilah.Persistence.Repository
{
    public class RedeSocialRepository : RepositoryBase<RedeSocial>, IRedeSocialRepository
    {
        private readonly IgrejaJdLilahContext _contexto;
        public RedeSocialRepository(IgrejaJdLilahContext contexto) : base(contexto)
        {
           _contexto = contexto;
        }
        public async Task<RedeSocial> GetRedeSocialByIdAsync(int redeSocialId, bool includeEventosPalestrentes = false)
        {
            IQueryable<RedeSocial> query = _contexto.RedeSociais.AsNoTracking();
  

            if(includeEventosPalestrentes)
            {
               query = query 
                      .Include(r => r.Evento)
                      .Include(r => r.Palestrante);
                    //  .ThenInclude(r => r.PalestranteEventos);

            }
            
            query = query.OrderBy(r => r.Id)
                         .Where(r => r.Id == redeSocialId);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<RedeSocial[]> GetAllRedeSocialAllAsync(bool includeEventosPalestrentes)
        {
             IQueryable<RedeSocial> query = _contexto.RedeSociais.AsNoTracking();
  
            if(includeEventosPalestrentes)
            {
               query = query 
                      .Include(r => r.Evento)
                      .Include(r => r.Palestrante);
                    //  .ThenInclude(r => r.PalestranteEventos);

            }
            
            query = query.OrderBy(r => r.Id);
            return await query.ToArrayAsync();
        }
        public async Task<RedeSocial[]> GetAllRedeSocialByNomeAsync(string nome, bool includeEventosPalestrentes)
        {
           IQueryable<RedeSocial> query = _contexto.RedeSociais.AsNoTracking();
  
            if(includeEventosPalestrentes)
            {
               query = query 
                      .Include(r => r.Evento)
                      .Include(r => r.Palestrante);
                     // .ThenInclude(r => r.PalestranteEventos);

            }
            
            query = query.OrderBy(r => r.Id)
                         .Where(r => r.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }
        public async Task<RedeSocial[]> GetRedeSocialByIdPalestranteAsync(int palestranteId, bool includePalestrante)
        {
            IQueryable<RedeSocial> query = _contexto.RedeSociais.AsNoTracking();
  
            if(includePalestrante)
            {
               query = query 
                      .Include(r => r.Evento)
                      .Include(r => r.Palestrante);
                     // .ThenInclude(r => r.PalestranteEventos);
            }
            
            query = query.OrderBy(r => r.Id)
                         .Where(r => r.PalestranteId == palestranteId);

            return await query.ToArrayAsync();
        }
        public async Task<RedeSocial[]> GetRedeSocialByIdEventoAsync(int eventoId, bool includeEvento)
        {
            IQueryable<RedeSocial> query = _contexto.RedeSociais.AsNoTracking();
  
            if(includeEvento)
               query = query .Include(r => r.Evento);
     
            query = query.OrderBy(r => r.Id)
                         .Where(r => r.EventoId == eventoId);
            return await query.ToArrayAsync();
        }
        public async Task<RedeSocial[]> GetRedeSocialByPalestranteIdAsync(int palestranteId, bool include)
        {
            IQueryable<RedeSocial> query = _contexto.RedeSociais.AsNoTracking();
  
            if(include)
               query = query .Include(r => r.Palestrante);

            
            query = query.OrderBy(r => r.Id)
                         .Where(r => r.PalestranteId == palestranteId);
            return await query.ToArrayAsync();
        }
        public async Task<bool> InseriAsync(RedeSocial redeSocial)
        {
            return await InserirAsync(redeSocial);
        }
        public RedeSocial GetRedeSocialById(int redeSocialId, bool include)
        {
            IQueryable<RedeSocial> redeSocials = _contexto.RedeSociais.AsNoTracking();

            if(include)
            {
                redeSocials = redeSocials
                             .Include(r => r.Evento)
                             .Include(r => r.Palestrante);
                             //.ThenInclude(r => r.PalestranteEventos);
            }

            redeSocials = redeSocials.OrderBy(c => c.Id)
                         .Where(c => c.Id == redeSocialId);
            return  redeSocials.FirstOrDefault();
        }
        public async Task<bool> Alterar(RedeSocial redeSocial)
        {
            return await AlterarAsync(redeSocial);
        }
        public async Task<bool> Excluir(RedeSocial redeSocial)
        {
           return await ExcluirAsync(redeSocial);
        }
        public async Task<bool> ExcluirRange(RedeSocial[] redeSocial)
        {
            return await ExcluirRengeAsync(redeSocial);
        }
    }
}