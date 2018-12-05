using BrCarApi.Dominio.Infraestrutura.Configuracao;
using Microsoft.Practices.Unity;

namespace BrCarApi.Infraestrutura.InjecaoDependencia.Configuracao
{
    /// <summary>
    /// Configurador de dependências.
    /// </summary>
    internal partial class ConfiguracaoDependencias
    {
        private readonly ILeitorDeConfiguracao _leitorDeConfiguracao;

        public ConfiguracaoDependencias()
        {
            _leitorDeConfiguracao = new LeitorDeConfiguracao();
        }

        /// <summary>
        /// Retorna um IUnityContainer com as dependências configuradas.
        /// </summary>
        /// <param name="webBasedSessionProvider">true para utilizar WebBaseSessionProvider para o NHibernate,
        /// false para utilizar ThreadBasedSessionProvider</param>
        /// <returns>IUnityContainer com as dependências configuradas</returns>
        internal IUnityContainer ObterUnityContainer(bool webBasedSessionProvider)
        {
            var container = new UnityContainer();
            //ConfigurarNhibernate(container, webBasedSessionProvider);
            ConfigurarDependenciasMvc(container);
            //ConfigurarRepositorios(container);
            //ConfigurarServicos(container);
            //ConfigurarValidadores(container);
            //ConfigurarLogger(container);
            return container;
        }
    }

}
