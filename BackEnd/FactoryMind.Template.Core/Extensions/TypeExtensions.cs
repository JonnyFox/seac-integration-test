using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FactoryMind.Template.Core.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsInstantiableSubclassOf(this TypeInfo source, Type baseType) =>
            baseType.IsAssignableFrom(source) && !source.IsAbstract && !source.IsInterface;

        public static bool IsInstantiableSubclassOf<TBaseType>(this TypeInfo source) =>
            source.IsInstantiableSubclassOf(typeof(TBaseType));

        public static IEnumerable<TypeInfo> GetInstantiableSubypesOf(this Assembly source, Type baseType) =>
            source.DefinedTypes.Where(t => t.IsInstantiableSubclassOf(baseType)).ToList();

        public static IEnumerable<TypeInfo> GetInstantiableSubypesOf<TBaseType>(this Assembly source) =>
            source.GetInstantiableSubypesOf(typeof(TBaseType));
    }
}