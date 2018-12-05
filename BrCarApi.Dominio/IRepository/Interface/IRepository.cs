using System;
using System.Linq;
using System.Linq.Expressions;

namespace BrCarApi.Dominio.Repositorio.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        IQueryable<T> Read(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        void Delete(Func<T, bool> predicate);
        void Commit();
        void Dispose();
    }
}
