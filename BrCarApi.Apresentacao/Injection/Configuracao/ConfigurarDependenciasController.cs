
using BrCarApi.Dominio.Infraestrutura.Configuracao;
using Microsoft.Practices.Unity;

namespace BrCarApi.Apresentacao.InjecaoDependencia.Configuracao
{
    internal partial class ConfiguracaoDependencia
    {
        internal static void ConfigurarDependenciasController(IUnityContainer unityContainer)
        {
            // CONFIGURAÇÃO
            unityContainer.RegisterType<ILeitorDeConfiguracao, LeitorDeConfiguracao>();
           // unityContainer.RegisterType<IEmailServico, EmailServico>();
           // unityContainer.RegisterType<IGeradorDeEmail, GeradorDeEmail>();

            // MODELVIEW
           // unityContainer.RegisterType<EmitenteDestinatarioViewModel>();

            // CONTROLLER
           // unityContainer.RegisterType<ControllerBase>();
            //unityContainer.RegisterType<ContaController>();
            //unityContainer.RegisterType<HomeController>();
        }
    }
}