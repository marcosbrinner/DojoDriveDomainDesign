using BrCarApi.Dominio.Repositorio.Interfaces;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace BrCarApi.Infraestrutura.ORM.Repositorio
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        public Context _contexto;

        public Repository(Context contexto)
        {
            _contexto = contexto;
        }

        public void Create(T entity)
        {
            _contexto.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _contexto.Entry(entity).State = EntityState.Modified;
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public void Delete(Func<T, bool> predicate)
        {
            _contexto.Set<T>()
                .Where(predicate)
                .ToList()
                .ForEach(x => _contexto.Set<T>().Remove(x));
        }

        public void Dispose()
        {
            if (_contexto != null)
            {
                _contexto.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public IQueryable<T> Read(Expression<Func<T, bool>> predicate)
        {
            var resultado = _contexto.Set<T>().Where(predicate);
            return resultado;
        }

    }
}
