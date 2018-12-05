using BrCarApi.Dominio.IRepository.Interface;
using BrCarApi.Dominio.Repositorio.Interfaces;
using BrCarApi.Infraestrutura.ORM.Repositorio;
using BrCarApi.Infraestrutura.ORM.Repository;
using Microsoft.Practices.Unity;

namespace BrCarApi.Apresentacao.InjecaoDependencia.Configuracao 
{
    internal partial class ConfiguracaoDependencia
    {
        internal static void ConfigurarRepositorios(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<Context>(new InjectionFactory(instancia => new Context()));

            unityContainer.RegisterType(typeof(IRepositorioClientes), typeof(RepositorioClientes));
            unityContainer.RegisterType(typeof(IRepositorioCategoria), typeof(RepositorioCategoria));
            unityContainer.RegisterType(typeof(IRepositorioLivro), typeof(RepositorioLivro));
        }
    }
}

