using BrCarApi.Dominio.Entity;
using BrCarApi.Dominio.IRepository.Interface;
using BrCarApi.Infraestrutura.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BrCarApi.Infraestrutura.Services.Livros
{
    public class LivrosServico : IDisposable, IService<Livro>
    {
        private readonly IRepositorioLivro _repositorioLivros;

        public LivrosServico(IRepositorioLivro repositorioLivros)
        {
            _repositorioLivros = repositorioLivros;
        }

        public LivrosServico()
        {

        }

        public IQueryable<Livro> Read(Expression<Func<Livro, bool>> predicate)
        {
            return _repositorioLivros.Read(predicate);
        }

        public void Create(Livro entidade)
        {
            _repositorioLivros.Create(entidade);
            _repositorioLivros.Commit();
        }

        public void Update(Livro entidade)
        {
            _repositorioLivros.Update(entidade);
            _repositorioLivros.Commit();
        }

        public void Commit()
        {
            _repositorioLivros.Commit();
        }

        public void Delete(Func<Livro, bool> predicate)
        {
            _repositorioLivros.Delete(predicate);
            _repositorioLivros.Commit();
        }

        public void Dispose()
        {
            if (_repositorioLivros != null)
            {
                _repositorioLivros.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}