using BrCarApi.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BrCarApi.Infraestrutura.ORM.Mapping
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            HasKey(x => x.IdCategoria)
                .Property(x => x.IdCategoria)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(x => x.Livros)
                .WithMany(x => x.Categorias)
                .Map(x => { x.MapLeftKey("LivroId");            x.MapRightKey("CategoriaId");
                    x.ToTable("LivrosCategorias");
                });
        }
    }
}