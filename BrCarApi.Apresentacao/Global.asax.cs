using BrCarApi.Apresentacao;
using System;
using System.Globalization;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Apresentacao
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ConfiguradorInjecaoDependencia.Configurar();

            var binder = new NullableDateTimeBinder();
            ModelBinders.Binders.Add(typeof(DateTime), binder);
            ModelBinders.Binders.Add(typeof(DateTime?), binder);
        }
        public class NullableDateTimeBinder : IModelBinder
        {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, value);

                return value?.ConvertTo(typeof(DateTime), CultureInfo.CurrentCulture);
            }
        }
    }
}
