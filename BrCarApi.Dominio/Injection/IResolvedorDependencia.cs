using System;
using System.Collections.Generic;
namespace BrCarApi.Dominio.InjecaoDependencia
{
        /// <summary>
        /// Resolvedor de dependências.
        /// </summary>
        public interface IResolvedorDependencia
        {
            /// <summary>
            /// Resolve a dependência passada ou retorna null se a dependência não estiver configurada.
            /// </summary>
            /// <typeparam name="T">Tipo da dependência</typeparam>
            /// <returns>A dependência resolvida ou null se a dependência não estiver configurada</returns>
            T Resolver<T>();

            /// <summary>
            /// Resolve a dependência passada ou retorna null se a dependência não estiver configurada.
            /// </summary>
            /// <param name="tipo">Tipo da dependência</param>
            /// <returns>A dependência resolvida ou null se a dependência não estiver configurada</returns>
            object Resolver(Type tipo);

            /// <summary>
            /// Resolve a dependência passada ou retorna null se a dependência não estiver configurada.
            /// </summary>
            /// <typeparam name="T">Tipo da dependência</typeparam>
            /// <returns>As dependências resolvidas ou null se a dependência não estiver configurada.</returns>
            IEnumerable<T> ResolverTodos<T>();

            /// <summary>
            /// Resolve a dependência passada ou retorna null se a dependência não estiver configurada.
            /// </summary>
            /// <param name="tipo">Tipo da dependência</param>
            /// <returns>As dependências resolvidas ou null se a dependência não estiver configurada</returns>
            IEnumerable<object> ResolverTodos(Type tipo);
        }
    }
