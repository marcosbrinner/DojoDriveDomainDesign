using BrCarApi.Apresentacao.InjecaoDependencia.Configuracao;
using BrCarApi.Dominio.InjecaoDependencia;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArquivarNFe.Apresentacao.InjecaoDependencia
{
    public sealed class ResolvedorDependencia : IResolvedorDependencia
    {
        private static ResolvedorDependencia _instancia = null;
        private readonly IUnityContainer _unityContainer;
        private static readonly object _instanciaLock = new object();
        public static IResolvedorDependencia Instancia
        {
            get
            {
                lock (_instanciaLock)
                {
                    if (_instancia == null)
                    {
                        throw new Exception("Resolvedor de dependência não configurado!");
                    }
                    return _instancia;
                }
            }
        }

        public ResolvedorDependencia(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public T Resolver<T>()
        {
            return (T)Resolver(typeof(T));
        }

        public object Resolver(Type tipo)
        {
            return _unityContainer.Resolve(tipo);
        }

        public IEnumerable<T> ResolverTodos<T>()
        {
            return ResolverTodos(typeof(T)).Cast<T>();
        }

        public IEnumerable<object> ResolverTodos(Type tipo)
        {
            return
                _unityContainer.IsRegistered(tipo) && !(tipo.IsAbstract || tipo.IsInterface) ?
                    _unityContainer.ResolveAll(tipo) : Enumerable.Empty<object>();
        }

        #region MÉTODOS

        /// <summary>
        /// Configura as dependências.
        /// </summary>
        /// <param name="webBasedSessionProvider">true para utilizar WebBaseSessionProvider para o NHibernate,
        /// false para utilizar ThreadBasedSessionProvider</param>
        public static void Configurar(bool webBasedSessionProvider)
        {
            lock (_instanciaLock)
            {
                if (_instancia != null)
                {
                    throw new Exception("Resolvedor de dependência já configurado!");
                }

                var unityContainer = new UnityContainer();
                ConfiguracaoDependencia.ConfigurarDependenciasController(unityContainer);
                ConfiguracaoDependencia.ConfigurarRepositorios(unityContainer);
                ConfiguracaoDependencia.ConfigurarServicos(unityContainer);
                ConfiguracaoDependencia.ConfigurarTiposAspNetMvc(unityContainer);

                _instancia = new ResolvedorDependencia(unityContainer);
            }
        }

        #endregion
    }
}