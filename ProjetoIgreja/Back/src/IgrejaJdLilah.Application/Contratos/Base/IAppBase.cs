using System;

namespace IgrejaJdLilah.Application.Base
{
    public interface IAppBase<T> : IDisposable where T : class
    {
        void Inserir(T entity);
        void Alterar(T entity);
        void Excluir(int id, string usuarioAlteracao);
        T ObterPorId(int id);
    }
}