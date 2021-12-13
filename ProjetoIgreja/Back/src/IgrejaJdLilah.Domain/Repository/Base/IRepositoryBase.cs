using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IgrejaJdLilah.Domain.Entidades;

namespace IgrejaJdLilah.Domain.Repository.Base
{
    public interface IRepositoryBase<T> : IDisposable where T : class
    {
        
        bool Inseri(T entity);
        bool Altera(T entity);
        bool Exclui(T entity);
        bool ExcluirRenge(T[] entity);
        T ObterPorId(int id);
        int Salvar();
        void Refresh(T entity);

        IEnumerable<T> SelecionarTodos(params Expression<Func<T, object>>[] includes);

        ///TODO: Os Metodos async deverão ser implementado de acordo com sua necessidade de utilização de processos paralelos
        Task<bool> InserirAsync(T entidade);
        Task<bool> AlterarAsync(T entity);
        Task<bool> ExcluirAsync(T entity);
        Task<T> ObterPorIdAsync(int id);
        Task<bool> SalvarAsync();
        Task<IEnumerable<T>> SelecionarTodosAsync(params Expression<Func<T, object>>[] includes);

    }
}