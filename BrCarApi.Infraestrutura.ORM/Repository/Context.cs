using BrCarApi.Dominio.Entidades.Clientes;
using BrCarApi.Dominio.Entity;
using BrCarApi.Infraestrutura.ORM.Mapeamentos;
using BrCarApi.Infraestrutura.ORM.Mapping;
using System.Data.Entity;
using System.Diagnostics;

namespace BrCarApi.Infraestrutura.ORM.Repositorio
{
    public class Context : DbContext
    {
        #region Propriedades
        public virtual DbSet<Clientes> Cce { get; set; }
        public virtual DbSet<Livro> Livro { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }


        #endregion

        #region Ctor

        public Context()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Database.Log = x => Debug.WriteLine(x);
        }

        #endregion

        #region Métodos

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new ClientesMap());


            modelBuilder.Configurations.Add(new LivroMap());


            modelBuilder.Configurations.Add(new CategoriaMap());

        }

        #endregion
    }
}
