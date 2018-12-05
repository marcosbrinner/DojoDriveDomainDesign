using BrCarApi.Dominio.Entidades.Clientes;
using BrCarApi.Dominio.Repositorio.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BrCarApi.Infraestrutura.Servicos.Cliente
{
    public class ClientesServico : IDisposable, IService<Clientes>
    {
        private readonly IRepositorioClientes _repositorioClientes;

        public ClientesServico(IRepositorioClientes repositorioClientes)
        {
            _repositorioClientes = repositorioClientes;
        }

        public ClientesServico()
        {
        }      

        public IQueryable<Clientes> Read(Expression<Func<Clientes, bool>> predicate)
        {
            return _repositorioClientes.Read(predicate);
        }

        public void Create(Clientes entidade)
        {
            _repositorioClientes.Create(entidade);
            _repositorioClientes.Commit();
        }

        public void Update(Clientes entidade)
        {
            _repositorioClientes.Update(entidade);
            _repositorioClientes.Commit();
        }

        public void Commit()
        {
            _repositorioClientes.Commit();
        }

        public void Delete(Func<Clientes, bool> predicate)
        {
            _repositorioClientes.Delete(predicate);
            _repositorioClientes.Commit();
        }
       
        public void Dispose()
        {
            if (_repositorioClientes != null)
            {
                _repositorioClientes.Dispose();
            }

            GC.SuppressFinalize(this);
        }       
    }
}
