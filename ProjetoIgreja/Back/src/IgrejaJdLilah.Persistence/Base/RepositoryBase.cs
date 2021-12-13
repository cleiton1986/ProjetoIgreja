using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Repository.Base;
using IgrejaJdLilah.Persistence.Contexto;
using Microsoft.EntityFrameworkCore;

namespace IgrejaJdLilah.Persistence.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private IgrejaJdLilahContext _contexto;
        private bool disposed = false;
        public RepositoryBase(IgrejaJdLilahContext contexto)
         {
              _contexto = contexto;
         }
        public bool Inseri(T entity) 
        {
            _contexto.Set<T>().Add(entity);
             return Salvar() > 0;
        }
        public bool Altera(T entity)
        {
            //Aguarda o estatus de salvamento para concluir
           //_contexto.Entry(entity).State = EntityState.Modified;
           _contexto.Entry(entity);
           return Salvar() > 0;
        }
        public bool Exclui(T entity)
        {
            //_contexto.Remove(entity);
            _contexto.Set<T>().Remove(entity);
            return Salvar() > 0;
        }
        public int Salvar()
        {
             return _contexto.SaveChanges();
        }
        public bool ExcluirRenge(T[] entity)
        {
            _contexto.Set<T[]>().RemoveRange(entity);
           return Salvar() > 0;
        }
        public T ObterPorId(int id)
        {
            return _contexto.Set<T>().Find(id);
        }

        public void Dispose()
        {
             Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (!Equals(_contexto, null))
                {
                    _contexto.Dispose();
                }
            }

            disposed = true;
        }
        public void Refresh(T entity)
        {
            _contexto.Entry<T>(entity).Reload();
        }
        public IEnumerable<T> SelecionarTodos(params Expression<Func<T, object>>[] includes)    
        {
            var query = _contexto.Set<T>().AsQueryable();
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
      
        #region Assínclonos
        public virtual async Task<bool> InserirAsync(T entidade)
        {
             _contexto.Set<T>().Add(entidade);
            return await CommitAsync() > 0;
        }
        public virtual async Task<bool> AlterarAsync(T entity)
        {
            _contexto.Set<T>().Update(entity);
            return await CommitAsync() > 0;
        }
        public virtual async Task<bool> ExcluirAsync(T entity)
        {
            _contexto.Set<T>().Remove(entity);
            return await CommitAsync() > 0;
        }
        public virtual async Task<T> ObterPorIdAsync(int id)
        {
            return await _contexto.Set<T>().FindAsync(id);
        }
        public virtual async Task<bool> ExcluirRengeAsync(T[] entity)
        {
            _contexto.Set<T[]>().Remove(entity);
            return await CommitAsync() > 0;
        }
      
        //public virtual async Task<IList<T>> SelecionarTodosAsync(params Expression<Func<T, object>>[] includes)    
        //  {
        //AsQueryable
        //  var query = await _contexto.Set<T>().AsNoTracking().ToListAsync();
        //  if (includes != null)
        //  query = includes.Aggregate(query, (current, include) => current.Include(include));
        // return query;
        // }
        public async Task<int> CommitAsync()
        {
            return await _contexto.SaveChangesAsync();
        }
        public async Task<bool> SalvarAsync()
        {
            return (await _contexto.SaveChangesAsync()) > 0;
        }
        public Task<IEnumerable<T>> SelecionarTodosAsync(params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}