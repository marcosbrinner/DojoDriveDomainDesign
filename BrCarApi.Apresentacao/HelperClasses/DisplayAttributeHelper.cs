using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BrCarApi.Apresentacao.HelperClasses
{
    public class DisplayAttributeHelper
    {
        public Dictionary<string, string> GetDisplayName<T>()
        {
            var propriedadesClasse = new Dictionary<string, string>();
            foreach (var propertyInfo in typeof(T).GetProperties())
            {
                var displayAttribute = propertyInfo
                    .GetCustomAttribute(typeof(DisplayAttribute), true) as DisplayAttribute;
                if (displayAttribute != null)
                {
                    propriedadesClasse.Add(propertyInfo.Name, displayAttribute.Name);
                }
            }
            return propriedadesClasse;
        }
    }
}