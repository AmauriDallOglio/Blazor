using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Dominio.Modelo
{
    public static class TypeExtensions
    {

        //public static IEnumerable<Type> GetParentTypes(this Type type)
        //{
        //    if (!(type == null) && !(type.BaseType == null))
        //    {
        //        Type[] interfaces = type.GetInterfaces();
        //        for (int i = 0; i < interfaces.Length; i++)
        //        {
        //            yield return interfaces[i];
        //        }

        //        Type currentBaseType = type.BaseType;
        //        while (currentBaseType != typeof(object))
        //        {
        //            yield return currentBaseType;
        //            currentBaseType = currentBaseType.BaseType;
        //        }
        //    }
        //}


        public static IEnumerable<MethodInfo> GetAllMethods(this Type type)
        {
            if (type == null)
            {
                return Enumerable.Empty<MethodInfo>();
            }

            if (type == typeof(object))
            {
                return type.GetTypeInfo().DeclaredMethods.Where((MethodInfo m) => !m.IsStatic);
            }

            return type.GetTypeInfo().DeclaredMethods.Where((MethodInfo m) => !m.IsStatic).Concat(type.GetTypeInfo().BaseType.GetAllMethods());
        }


        //public static bool IsSubclassOfRawGeneric(this Type generic, Type toCheck)
        //{
        //    while (toCheck != null && toCheck != typeof(object))
        //    {
        //        Type type = (toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck);
        //        if (generic == type)
        //        {
        //            return true;
        //        }

        //        toCheck = toCheck.BaseType;
        //    }

        //    return false;
        //}


        //public static string GetDescription(this Type type)
        //{
        //    DescriptionAttribute customAttribute = type.GetCustomAttribute<DescriptionAttribute>();
        //    if (customAttribute != null)
        //    {
        //        return customAttribute.Description;
        //    }

        //    return type.Name.SplitPascalCase();
        //}


        public static string GetDisplayName(this MemberInfo member)
        {
            DisplayNameAttribute customAttribute = member.GetCustomAttribute<DisplayNameAttribute>();
            if (customAttribute != null)
            {
                return customAttribute.DisplayName;
            }

            DescriptionAttribute customAttribute2 = member.GetCustomAttribute<DescriptionAttribute>();
            if (customAttribute2 != null)
            {
                return customAttribute2.Description;
            }

            return DisplayNameDictionary.CorrectMemberName(member.Name);
        }


        //public static PropertySelection SelectProperty(this Type type, string propertyPath)
        //{
        //    string text = propertyPath;
        //    string[] array = null;
        //    if (propertyPath.Contains(' '))
        //    {
        //        array = propertyPath.Split(' ');
        //        text = array[0];
        //    }

        //    string[] array2 = (text.Contains('.') ? text.Split('.') : new string[1] { text });
        //    PropertySelection propertySelection = PropertySelection.Select(type, array2[0]);
        //    for (int i = 1; i < array2.Length; i++)
        //    {
        //        propertySelection = propertySelection.Push(array2[i]);
        //    }

        //    array?.Skip(1).Each(propertySelection.AddOn);
        //    return propertySelection;
        //}

        //public static IEnumerable<PropertySelection> SelectProperties(this Type type, string propertiesPaths)
        //{
        //    return (propertiesPaths.Contains(';') ? propertiesPaths.Split(';') : (propertiesPaths.Contains(',') ? propertiesPaths.Split(',') : new string[1] { propertiesPaths })).Select(delegate (string path)
        //    {
        //        try
        //        {
        //            return type.SelectProperty(path.Trim());
        //        }
        //        catch (Exception innerException)
        //        {
        //            throw new ArgumentException("A classe '" + type.Name + "' não contém a propriedade '" + path.Trim() + "'", innerException);
        //        }
        //    });
        //}


        //public static IEnumerable<PropertyFilter> GetPropertiesForFilter(this Type filterType, Type entityType)
        //{
        //    return from p in filterType.GetProperties()
        //           where !PropertyFilter.reservedProperties.Contains(p.Name)
        //           select new Tuple<PropertyInfo, CondicaoAttribute>(p, p.GetCustomAttribute<CondicaoAttribute>(inherit: true) ?? new CondicaoAttribute()) into t
        //           where !t.Item2.Ignore
        //           select new PropertyFilter(t.Item1, t.Item2, entityType);
        //}
    }
}
