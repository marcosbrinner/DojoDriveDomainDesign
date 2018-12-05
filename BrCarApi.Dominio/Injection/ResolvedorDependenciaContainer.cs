using System;

namespace BrCarApi.Dominio.InjecaoDependencia
{
    /// <summary>
    /// Container para a instância do resolvedor de dependência na camada de domínio.
    /// </summary>
    public static class Injection
    {
        /// <summary>
        /// Objeto utilizado como lock.
        /// </summary>
        private readonly static object _lock = new object();

        /// <summary>
        /// Instância (interna) do resolvedor de dependência.
        /// </summary>
        private static IResolvedorDependencia _resolvedorDependencia;


        /// <summary>
        /// Instância interna do resolvedor de dependência.
        /// </summary>
        public static IResolvedorDependencia Instancia
        {
            get
            {
                lock (_lock)
                {
                    return _resolvedorDependencia;
                }
            }

            set
            {
                lock (_lock)
                {
                    if (_resolvedorDependencia != null)
                    {
                        throw new Exception("Resolvedor de dependência já inicializado.");
                    }
                    _resolvedorDependencia = value;
                }
            }
        }
    }
}
