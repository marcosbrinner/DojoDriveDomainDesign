
using BrCarApi.Dominio.InjecaoDependencia;
using BrCarApi.Infraestrutura.InjecaoDependencia.Configuracao;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArquivarNFe.Infraestrutura.InjecaoDependencia
{
    /// <summary>
    /// Resolvedor de dependências.
    /// </summary>
    public sealed class ResolvedorDependencia : IResolvedorDependencia
    {
        /// <summary>
        /// Instância da classe.
        /// </summary>
        private static ResolvedorDependencia _instancia = null;

        /// <summary>
        /// Lock para acesso à instância da classe.
        /// </summary>
        private static readonly object _instanciaLock = new object();

        /// <summary>
        /// Wrapper para a instância da classe.
        /// </summary>
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
                var configuracaoDependencias = new ConfiguracaoDependencias();
                var unityContainer = configuracaoDependencias.ObterUnityContainer(webBasedSessionProvider);
                _instancia = new ResolvedorDependencia(unityContainer);
            }
        }

        /// <summary>
        /// Container com as dependências configuradas.
        /// </summary>
        private readonly IUnityContainer _unityContainer;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="unityContainer">Container com a dependências configuradas</param>
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
                    _unityContainer.ResolveAll(tipo) :
                    Enumerable.Empty<object>();
        }
    }
}
