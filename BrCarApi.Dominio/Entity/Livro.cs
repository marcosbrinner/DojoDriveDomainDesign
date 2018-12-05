using System.Collections.Generic;

namespace BrCarApi.Dominio.Entity
{
    public class Livro
    {
        public int IdLivro { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }

        public ICollection<Categoria> Categorias { get; set; }
    }
}