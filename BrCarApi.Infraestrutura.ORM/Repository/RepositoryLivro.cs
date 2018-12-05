using BrCarApi.Dominio.Entity;
using BrCarApi.Dominio.IRepository.Interface;
using BrCarApi.Infraestrutura.ORM.Repositorio;

namespace BrCarApi.Infraestrutura.ORM.Repository
{
    public class RepositorioLivro : Repository<Livro>, IRepositorioLivro
    {
        public RepositorioLivro(Context contexto) : base(contexto)
        {

        }
    }
}