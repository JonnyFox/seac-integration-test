using System;

namespace FactoryMind.Template.Business.Infrastructure
{
    /// <inheritdoc />
    /// <summary>
    /// Use this attribute to decorate an IOperation with a decorator that instances DecoratorType
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class DecoratorAttribute : Attribute
    {
        public int Priority { get; }
        public abstract Type DecoratorType { get; }

        protected DecoratorAttribute(int priority = 0)
        {
            Priority = priority;
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// Use this mandatory attribute in the costructor of the decorator in order to obtain the decoratee
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class DecorateeAttribute : Attribute
    { }

    /// <inheritdoc />
    /// <summary>
    /// Use this optional attribute in the costructor of the decorator in order to obtain its DecoratorAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class DecoratorMarkerAttribute : Attribute
    { }
}
