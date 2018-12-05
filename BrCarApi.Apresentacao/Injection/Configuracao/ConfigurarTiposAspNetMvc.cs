using Microsoft.Practices.Unity;
using System.Net.Http.Formatting;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Hosting;
using System.Web.Http.Tracing;
using System.Web.Http.Validation;
using System.Web.Mvc;
using System.Web.Mvc.Async;

namespace BrCarApi.Apresentacao.InjecaoDependencia.Configuracao
{
    internal partial class ConfiguracaoDependencia
    {
        internal static void ConfigurarTiposAspNetMvc(IUnityContainer container)
        {
            container.RegisterType<IControllerFactory>(new InjectionFactory(instancia => null));
            container.RegisterType<IControllerActivator>(new InjectionFactory(instancia => null));
            container.RegisterType<IViewPageActivator>(new InjectionFactory(instancia => null));
            container.RegisterType<ModelMetadataProvider>(new InjectionFactory(instancia => null));
            container.RegisterType<ITempDataProvider>(new InjectionFactory(instancia => null));
            container.RegisterType<IAsyncActionInvoker>(new InjectionFactory(instancia => null));
            container.RegisterType<IActionInvoker>(new InjectionFactory(instancia => null));
            container.RegisterType<IAuthorizationFilter>(new InjectionFactory(instancia => null));
            container.RegisterType<IActionFilter>(new InjectionFactory(instancia => null));
            container.RegisterType<IResultFilter>(new InjectionFactory(instancia => null));
            container.RegisterType<IExceptionFilter>(new InjectionFactory(instancia => null));
            container.RegisterType<IHostBufferPolicySelector>(new InjectionFactory(instancia => null));
            container.RegisterType<ITraceManager>(new InjectionFactory(instancia => null));
            container.RegisterType<ITraceWriter>(new InjectionFactory(instancia => null));
            container.RegisterType<IHttpControllerSelector>(new InjectionFactory(instancia => null));
            container.RegisterType<IAssembliesResolver>(new InjectionFactory(instancia => null));
            container.RegisterType<IHttpControllerTypeResolver>(new InjectionFactory(instancia => null));
            container.RegisterType<IHttpActionSelector>(new InjectionFactory(instancia => null));
            container.RegisterType<IActionValueBinder>(new InjectionFactory(instancia => null));
            container.RegisterType<IContentNegotiator>(new InjectionFactory(instancia => null));
            container.RegisterType<IHttpControllerActivator>(new InjectionFactory(instancia => null));
            container.RegisterType<IBodyModelValidator>(new InjectionFactory(instancia => null));
            container.RegisterType<IHttpActionInvoker>(new InjectionFactory(instancia => null));
            container.RegisterType<ITempDataProviderFactory>(new InjectionFactory(instancia => null));
            container.RegisterType<IAsyncActionInvokerFactory>(new InjectionFactory(instancia => null));
            container.RegisterType<IActionInvokerFactory>(new InjectionFactory(instancia => null));
        }
    }
}