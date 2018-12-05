using BrCarApi.Dominio.Entidades.Clientes;
using BrCarApi.Dominio.Entity;
using BrCarApi.Dominio.InjecaoDependencia;
using BrCarApi.Infraestrutura.Services.Livros;
using BrCarApi.Infraestrutura.Servicos.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrCarApi.Apresentacao.Controllers
{
    public class HomeController : Controller
    {
        public ClientesServico ClientesServico
        {
            get
            {
                return Injection.Instancia.Resolver<ClientesServico>();
            }
        }
        public CategoriasServico CategoriaServico
        {
            get
            {
                return Injection.Instancia.Resolver<CategoriasServico>();
            }
        }

        public LivrosServico LivroServico
        {
            get
            {
                return Injection.Instancia.Resolver<LivrosServico>();
            }
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ClientesServico.Create(new Clientes
            {
                CliCPF = 11482196689,
                CliEmail = "marcos@outlook.com",
                CliNome = "Marcos",
                CliSenha = "123456",
                CliTelefone = 31991335853

            });
            var categoria = new Categoria
            {
                Descricao = "Romance",
                Nome = "Romance"
            };
            CategoriaServico.Create(categoria);
            var livro = new Livro
            {
                Autor = "Reis Fofinho",
                Editora = "Mateus marido",
                Titulo = "Romance Eterno",
            };
            LivroServico.Create(livro);
            return View();
        }
    }
}
