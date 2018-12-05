using BrCarApi.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BrCarApi.Infraestrutura.ORM.Mapping
{
    public class LivroMap : EntityTypeConfiguration<Livro>
    {
        public LivroMap()
        {
            HasKey(x => x.IdLivro)
                .Property(x => x.IdLivro)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}