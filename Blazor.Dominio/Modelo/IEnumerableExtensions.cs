using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Dominio.Modelo
{
    public static class IEnumerableExtensions
    {
 
        public static void Each<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null)
            {
                return;
            }

            if (enumerable is T[])
            {
                (enumerable as T[]).Each(action);
                return;
            }

            foreach (T item in enumerable)
            {
                action(item);
            }
        }

 
        public static bool None<T>(this IEnumerable<T> enumerable)
        {
            return !enumerable.Any();
        }

 
        public static T Single<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable != null)
            {
                return enumerable.FirstOrDefault();
            }

            return default(T);
        }

 
        public static string JoinStrings(this IEnumerable<string> enumerable, string separator = ", ")
        {
            return string.Join(separator, enumerable);
        }
 
        public static string ToCsv<T>(this IEnumerable<T> enumerable, string separador = ",")
        {
            Type typeFromHandle = typeof(T);
            PropertyInfo[] propriedades = typeFromHandle.GetProperties();
            string value = string.Join(separador, propriedades.Select((PropertyInfo f) => f.GetDisplayName()).ToArray());
            StringBuilder csvdata = new StringBuilder();
            csvdata.AppendLine(value);
            enumerable.Each(delegate (T v)
            {
                csvdata.AppendLine(ToCsvFields(separador, propriedades, v));
            });
            return csvdata.ToString();
        }

        private static string ToCsvFields(string separador, PropertyInfo[] campos, object o)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PropertyInfo obj in campos)
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Append(separador);
                }

                object value = obj.GetValue(o);
                if (value != null)
                {
                    stringBuilder.Append(value.ToString());
                }
            }

            return stringBuilder.ToString();
        }
    }
}
