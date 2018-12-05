using ArquivarNFe.Apresentacao.InjecaoDependencia;
using BrCarApi.Apresentacao.InjecaoDependencia;
using BrCarApi.Dominio.InjecaoDependencia;
using System.Web.Mvc;

 namespace BrCarApi.Apresentacao
    {
        public class ConfiguradorInjecaoDependencia
        {
            internal static void Configurar()
            {
                // CONFIGURA A INJEÇÃO DE DEPENDÊNCIA
                ResolvedorDependencia.Configurar(true);

                // INJETA DEPENDÊNCIA NO DOMÍNIO
                Injection.Instancia = ResolvedorDependencia.Instancia;

                // CONFIGURA A INJEÇÃO DE DEPENDÊNCIA - MVC 4
                DependencyResolver.SetResolver(new ResolvedorDependenciaMvc(ResolvedorDependencia.Instancia));

                // CONFIGURA A INJEÇÃO DE DEPENDÊNCIA - WebApi
                // TODO: NÃO NECESSÁRIO
            }
        }
    }
