using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace BrCarApi.Dominio.Utilitarios
{
    public static class StringUtil
    {
        public static bool ESomenteDigitos(this string original)
        {
            return original == null ? false : new Regex("^[0-9]+$").IsMatch(original);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.AndAlso);
        }

        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // zip parameters (map from parameters of second to parameters of first)
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] })
    .ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with the parameters in the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // create a merged lambda expression with parameters from the first expression
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        class ParameterRebinder : ExpressionVisitor
        {
            readonly Dictionary<ParameterExpression, ParameterExpression> map;

            ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
            {
                this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
            }

            public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
            {
                return new ParameterRebinder(map).Visit(exp);
            }

            protected override Expression VisitParameter(ParameterExpression p)
            {

                if (map.TryGetValue(p, out ParameterExpression replacement))
                {
                    p = replacement;
                }

                return base.VisitParameter(p);
            }
        }

        public static string SomenteDigitos(this string original)
        {
            return new Regex("[^0-9]").Replace(original, string.Empty);
        }

        public static bool Like(this string original, string aComparar)
        {
            return original == null || aComparar == null ?
                original == null && aComparar == null :
                original.SemAcentuacao().ToLower().Contains(aComparar.SemAcentuacao().ToLower());
        }

        public static string SemAcentuacao(this string original)
        {
            return original == null ? null :
                Encoding.UTF8.GetString(Encoding.GetEncoding("ISO-8859-8").GetBytes(original));
        }

        public static string SepararPorVirgula(this IList<string> listaString)
        {
            var textoSeparadoPorVirgula = String.Join(", ", listaString);

            var index = textoSeparadoPorVirgula.LastIndexOf(',');
            if (listaString.Count > 1 && index > 1)
            {
                textoSeparadoPorVirgula = textoSeparadoPorVirgula.Remove(index, 1);
                textoSeparadoPorVirgula = textoSeparadoPorVirgula.Insert(index, " e");
            }
            return textoSeparadoPorVirgula;
        }        
    }
}
