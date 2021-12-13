using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IgrejaJdLilah.Domain;

namespace IgrejaJdLilah.Persistence
{
    public interface IIgrejaJdLilahPersistence<T> : IDisposable where T : class
    {
        //Todos e qualquer atualizar,add, deletar e salvar
        //Sera ultilizado um desses métodos
         void add(T entity);
         void Update(T entity);
         void Delete(T entity);
         void DeleteRange(T[] entity);
         Task<bool> SaveChangesAsync();

       //void Delete<T>(T entity) where T: class;
       //void DeleteRange<T>(T[] entity) where T: class;
        IEnumerable<T> SelecionarTodos(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> SelecionarTodosAsync(params Expression<Func<T, object>>[] includes);
    }
}