using System.Linq;
using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Contrato;
using IgrejaJdLilah.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using IgrejaJdLilah.Persistence.Contexto;

namespace IgrejaJdLilah.Persistence.Repository
{
    public class PalestranteRepository: RepositoryBase<Palestrante>, IPalestranteRepository
    {
       private readonly IgrejaJdLilahContext _contexto;
        public PalestranteRepository(IgrejaJdLilahContext contexto) : base(contexto)
        {
          _contexto = contexto;
        }

        public async Task<Palestrante[]> GetAllPalestrantesByAsync(bool includeEndereco = true)
        {
             IQueryable<Palestrante> query = _contexto.Palestrantes
                                                      .AsNoTracking();

            if(includeEndereco)
            {
                query = query
                        .Include(p => p.RedeSociais)
                        .Include(p => p.Endereco);
            }
                
            query = query.OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesByDenominacaoAsync(string denominacao, bool include = true)
        {
              IQueryable<Palestrante> query = _contexto.Palestrantes
                                                        .AsNoTracking();

            if(include){
               query = query
                       .Include(p => p.RedeSociais)
                       .Include(p => p.Endereco);
            }

            query = query.OrderBy(e => e.Id)
                         .Where(p => p.Denominacao.ToLower().Contains(denominacao.ToLower()));
            return await query.ToArrayAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesByMesmaDenominacaoAsync(bool mesmaDenominacao, bool include = true)
        {
              IQueryable<Palestrante> query = _contexto.Palestrantes;

            if(include)
            {
                query = query
                       .Include(p => p.RedeSociais)
                       .Include(p => p.Endereco);
            }
                
            query = query.OrderBy(e => e.Id)
                          .AsNoTracking()
                         .Where(p => p.FazParteMesmaDenominacao == mesmaDenominacao);
            return await query.ToArrayAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool include = true)
        {
            IQueryable<Palestrante> query = _contexto.Palestrantes
                                                      .AsNoTracking();
                                             
            if(include)
            {
                query = query.Include(p => p.Endereco)
                             .Include(p => p.RedeSociais);
            }
                
            query = query.OrderBy(e => e.Id)
                          .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }
        public async Task<Palestrante> GetPalestranteByIdAsync(int palestrantesId, bool include = true)
        {
            
             IQueryable<Palestrante> query = _contexto.Palestrantes
                                                      .AsNoTracking();
                                            
            if(include)
            {
                query = query
                    .Include(p => p.RedeSociais)
                    .Include(p => p.Endereco);
            }
            
            query = query.OrderBy(e => e.Id).Where(p => p.Id == palestrantesId);;
            return await query.FirstOrDefaultAsync();
        }
        public Palestrante GetPalestranteById(int palestranteId, bool include = true)
        {
             IQueryable<Palestrante> palestrante = _contexto.Palestrantes.AsNoTracking();

            if(include)
            {
                palestrante = palestrante
                             .Include(p => p.RedeSociais)
                             .Include(p => p.Endereco);
            }

            palestrante = palestrante.OrderBy(c => c.Id)
                         .Where(c => c.Id == palestranteId);
            return  palestrante.FirstOrDefault();
        }
        public async Task<bool> InseriAsync(Palestrante palestrante)
        {
             return await InserirAsync(palestrante);
        }
        public async Task<bool> Alterar(Palestrante palestrante)
        {
           return await AlterarAsync(palestrante);
        }
        public async Task<bool> Excluir(Palestrante palestrante)
        {
            return await ExcluirAsync(palestrante);
        }
        public async Task<bool> ExcluirRange(Palestrante[] palestrante)
        {
            return await ExcluirRengeAsync(palestrante);
        }
    }
}