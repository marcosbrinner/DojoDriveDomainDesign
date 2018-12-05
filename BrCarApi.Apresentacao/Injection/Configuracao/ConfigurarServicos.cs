using BrCarApi.Infraestrutura.Services.Livros;
using BrCarApi.Infraestrutura.Servicos.Cliente;
using Microsoft.Practices.Unity;

namespace BrCarApi.Apresentacao.InjecaoDependencia.Configuracao
{
    internal partial class ConfiguracaoDependencia
    {
        internal static void ConfigurarServicos(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<ClientesServico>();
            unityContainer.RegisterType<CategoriasServico>();
            unityContainer.RegisterType<LivrosServico>();
        }
    }
}
