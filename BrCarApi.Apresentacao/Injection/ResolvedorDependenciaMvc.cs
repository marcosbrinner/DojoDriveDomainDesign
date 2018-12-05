using BrCarApi.Dominio.InjecaoDependencia;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using IDependencyResolverMvc = System.Web.Mvc.IDependencyResolver;
using IDependencyResolverWebApi = System.Web.Http.Dependencies.IDependencyResolver;

namespace   BrCarApi.Apresentacao.InjecaoDependencia
{
    public class ResolvedorDependenciaMvc : IDependencyResolverMvc, IDependencyResolverWebApi
    {
        private IResolvedorDependencia _resolvedorDependencia;

        public ResolvedorDependenciaMvc(IResolvedorDependencia resolvedorDependencia)
        {
            _resolvedorDependencia = resolvedorDependencia;
        }

        public object GetService(Type serviceType)
        {
            return _resolvedorDependencia.Resolver(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolvedorDependencia.ResolverTodos(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return new ResolvedorDependenciaMvc(_resolvedorDependencia);
        }

        public void Dispose()
        {
            _resolvedorDependencia = null;
        }
    }
}