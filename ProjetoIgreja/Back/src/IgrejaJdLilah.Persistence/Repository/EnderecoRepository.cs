using System.Linq;
using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Contrato;
using IgrejaJdLilah.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using IgrejaJdLilah.Persistence.Contexto;

namespace IgrejaJdLilah.Persistence.Repository
{
    public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
    {
        private readonly IgrejaJdLilahContext _contexto;
        public EnderecoRepository(IgrejaJdLilahContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<Endereco[]> GetAllEnderecoByAsync()
        {
            IQueryable<Endereco> query = _contexto.Enderecos
                                                   .AsNoTracking();
            query = query.OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }
        public async Task<Endereco[]> GetAllEnderecosByCepAsync(string cep)
        {
            IQueryable<Endereco> query  = _contexto.Enderecos
                                                    .AsNoTracking();

            query = query.OrderBy(c => c.Cep).Where(e => e.Cep.ToLower().Contains(cep.ToLower()));
            return await query.ToArrayAsync();
        }
        public async Task<Endereco> GetEnderecoByEventoIdAsync(int eventoId)
        {
           IQueryable<Endereco> query = _contexto.Enderecos.AsNoTracking();
           query = query.OrderBy(c => c.Cep).Where(e => e.Id == eventoId);
           return await query.FirstOrDefaultAsync();
        }
        public async Task<bool> InseriAsync(Endereco model)
        {
            return await InserirAsync(model);
        }
        public async Task<bool> Alterar(Endereco model)
        {
            return await AlterarAsync(model);
        }
        public async Task<bool> Excluir(Endereco model)
        {
            return await ExcluirAsync(model);
        }
        public async Task<bool> ExcluirRange(Endereco[] model)
        {
           return await ExcluirRengeAsync(model);
        }
        public Endereco GetEnderecoById(int enderecoId)
        {
             IQueryable<Endereco> query = _contexto.Enderecos.AsNoTracking();

            query = query.OrderBy(c => c.Id)
                         .Where(c => c.Id == enderecoId);
            return  query.FirstOrDefault();
        }
        public async Task<Endereco> GetEnderecoByIdAsync(int enderecoId)
        {
           IQueryable<Endereco> query = _contexto.Enderecos.AsNoTracking();
           query = query.OrderBy(c => c.Cep).Where(e => e.Id == enderecoId);
           return await query.FirstOrDefaultAsync();
        }
    }
}