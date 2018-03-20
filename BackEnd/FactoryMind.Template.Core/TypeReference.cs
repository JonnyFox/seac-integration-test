using System;

namespace FactoryMind.Template.Core
{
    public static class TypeReference
    {
        public static TypeReference<TImplementation> For<TImplementation>() =>
            new TypeReference<TImplementation>(typeof(TImplementation));

        public static TypeReference<TService> For<TService, TImplementation>() where TImplementation : TService =>
            new TypeReference<TService>(typeof(TImplementation));
    }

    public sealed class TypeReference<T>
    {
        public Type ReferencedType { get; }

        internal TypeReference(Type referencedType)
        {
            ReferencedType = referencedType;
        }

        public static implicit operator Type(TypeReference<T> source) =>
            source.ReferencedType;
    }
}
