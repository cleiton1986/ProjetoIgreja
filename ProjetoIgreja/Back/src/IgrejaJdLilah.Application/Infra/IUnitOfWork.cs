using System;

namespace IgrejaJdLilah.Application.Infra
{   public interface IUnitOfWork : IDisposable
    {
        void BeginTrasaction();
        void Commit();
        void Rollback();
        void Salvar(string usuario);
    }
}