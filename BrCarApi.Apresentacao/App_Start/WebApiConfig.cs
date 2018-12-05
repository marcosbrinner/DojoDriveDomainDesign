using BrCarApi.Apresentacao.HelperClasses.Handlers;
using BrCarApi.Apresentacao.HelperClasses.Loggers;
using BrCarApi.Dominio.Entidades.Clientes;
using Microsoft.Data.Edm;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.OData.Builder;

namespace Apresentacao
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // FORMATADORES JSON
            config.Formatters.JsonFormatter.SerializerSettings.Culture = CultureInfo.GetCultureInfo("pt-BR");
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new IsoDateTimeConverter());
            config.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            // IGNORA REFERENCIA CIRCULAR
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            // Web API configuration and services
            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            // Serviços e configuração da API da Web
            config.SuppressDefaultHostAuthentication();

            // Rotas da API da Web
            //config.MapHttpAttributeRoutes();

            var hostAuthenticationFilter = new HostAuthenticationFilter(OAuthDefaults.AuthenticationType);
            config.Filters.Add(hostAuthenticationFilter);
            // config.Filters.Add(new HostAuthenticationFilter("Bearer"));			


            // Serviços e configuração da API da Web

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<Clientes>("Clientes");
          
            return builder.GetEdmModel();
        }
    }
}
