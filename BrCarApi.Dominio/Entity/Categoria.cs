using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrCarApi.Dominio.Entity
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<Livro> Livros { get; set; }
    }
}