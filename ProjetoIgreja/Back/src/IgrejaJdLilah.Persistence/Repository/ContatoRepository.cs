using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;
using IgrejaJdLilah.Domain.Repository.Contrato;
using IgrejaJdLilah.Persistence.Base;
using IgrejaJdLilah.Persistence.Contexto;
using Microsoft.EntityFrameworkCore;

namespace IgrejaJdLilah.Persistence.Repository
{
    public class ContatoRepository : RepositoryBase<Contato>, IContatoRepository
    {
        private readonly IgrejaJdLilahContext _contexto;
        public ContatoRepository(IgrejaJdLilahContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }
        public async Task<Contato[]> GetAllContatoByDenominacaoAsync(string denominacao, bool includeEndereco = false)
        {
            IQueryable<Contato> query = _contexto.Contatos;

            if(includeEndereco)
                query = query.Include(c => c.Endereco);

            query = query.OrderBy(c => c.Denominacao)
                         .Where(c => c.Denominacao.ToLower().Contains(denominacao.ToLower()));
            return await query.ToArrayAsync();
        }
        public async Task<Contato[]> GetContatosAllAsync(bool includeEndereco = false)
        {
            IQueryable<Contato> query = _contexto.Contatos;

            if(includeEndereco)
                query = query.Include(c => c.Endereco);

            query = query.OrderBy(c => c.Id);
            return  await query.ToArrayAsync();
        }
        public async Task<Contato> GetContatoByEmailAsync(string email, bool includeEndereco = false)
        {
            IQueryable<Contato> query = _contexto.Contatos;
            if(includeEndereco)
                query = query.Include(c => c.Endereco);

            query = query.OrderBy(c => c.Email)
                         .Where(c => c.Email.ToLower().Contains(email.ToLower()));
            return  await query.FirstOrDefaultAsync();
        }
        public async Task<Contato> GetContatoByContatoIdAsync(int contatoId, bool includeEndereco = false)
        {
            IQueryable<Contato> query = _contexto.Contatos;

            if(includeEndereco)
                query = query.Include(c => c.Endereco);

            query = query.OrderBy(c => c.Id)
                         .Where(c => c.Id == contatoId);
            return  await query.FirstOrDefaultAsync();
        }
        public async Task<bool> Alterar(Contato contato)
        {
            return await AlterarAsync(contato);
        }
        public async Task<bool> Excluir(Contato contato)
        {
            return await ExcluirAsync(contato);
        }
        public async Task<bool> InseriAsync(Contato contato)
        {
           return await InserirAsync(contato);
        }
        public async Task<bool> ExcluirRange(Contato[] contato)
        {
            return await ExcluirRengeAsync(contato);

        }
        public Contato GetContatoByContatoId(int contatoId, bool includeEndereco = false)
        {
            IQueryable<Contato> query = _contexto.Contatos;

            if(includeEndereco)
                query = query.Include(c => c.Endereco);

            query = query.OrderBy(c => c.Nome)
                         .Where(c => c.Id == contatoId);
            return  query.FirstOrDefault();
        }

    }
}