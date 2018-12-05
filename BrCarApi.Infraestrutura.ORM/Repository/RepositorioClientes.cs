using BrCarApi.Dominio.Entidades.Clientes;
using BrCarApi.Dominio.Repositorio.Interfaces;

namespace BrCarApi.Infraestrutura.ORM.Repositorio
{
    public class RepositorioClientes : Repository<Clientes>, IRepositorioClientes
    {
        public RepositorioClientes(Context contexto) : base(contexto)
        {
        }
    }
}