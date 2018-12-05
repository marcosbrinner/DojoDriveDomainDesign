using Microsoft.Practices.Unity;


namespace BrCarApi.Infraestrutura.InjecaoDependencia.Configuracao 
{
    internal partial class ConfiguracaoDependencias
    {
        /// <summary>
        /// Configura as dependências do Logger.
        /// </summary>
        /// <param name="container">Container das configurações</param>
        private void ConfigurarDependenciasMvc(IUnityContainer container)
        {
            //container.RegisterType<IControllerFactory>(new InjectionFactory(instancia => null));
            //container.RegisterType<IControllerActivator>(new InjectionFactory(instancia => null));
            //container.RegisterType<IViewPageActivator>(new InjectionFactory(instancia => null));
            //container.RegisterType<ModelMetadataProvider>(new InjectionFactory(instancia => null));
        }
    }
}
