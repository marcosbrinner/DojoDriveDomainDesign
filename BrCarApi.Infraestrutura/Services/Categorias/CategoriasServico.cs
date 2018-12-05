using BrCarApi.Dominio.Entity;
using BrCarApi.Dominio.IRepository.Interface;
using BrCarApi.Dominio.Repositorio.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BrCarApi.Infraestrutura.Servicos.Cliente
{
    public class CategoriasServico : IDisposable, IService<Categoria>
    {
        private readonly IRepositorioCategoria _repositorioCategorias;

        public CategoriasServico(IRepositorioCategoria repositorioCategorias)
        {
            _repositorioCategorias = repositorioCategorias;
        }

        public CategoriasServico()
        {
        }      

        public IQueryable<Categoria> Read(Expression<Func<Categoria, bool>> predicate)
        {
            return _repositorioCategorias.Read(predicate);
        }

        public void Create(Categoria entidade)
        {
            _repositorioCategorias.Create(entidade);
            _repositorioCategorias.Commit();
        }

        public void Update(Categoria entidade)
        {
            _repositorioCategorias.Update(entidade);
            _repositorioCategorias.Commit();
        }

        public void Commit()
        {
            _repositorioCategorias.Commit();
        }

        public void Delete(Func<Categoria, bool> predicate)
        {
            _repositorioCategorias.Delete(predicate);
            _repositorioCategorias.Commit();
        }
       
        public void Dispose()
        {
            if (_repositorioCategorias != null)
            {
                _repositorioCategorias.Dispose();
            }

            GC.SuppressFinalize(this);
        }       
    }
}
