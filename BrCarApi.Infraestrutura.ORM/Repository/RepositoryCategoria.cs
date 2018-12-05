using BrCarApi.Dominio.Entity;
using BrCarApi.Dominio.IRepository.Interface;
using BrCarApi.Infraestrutura.ORM.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrCarApi.Infraestrutura.ORM.Repository
{
    public class RepositorioCategoria : Repository<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoria(Context contexto) : base(contexto)
        {

        }
    }
}