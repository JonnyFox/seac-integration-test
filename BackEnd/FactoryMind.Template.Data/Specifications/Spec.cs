using System;
using System.Linq.Expressions;
using FactoryMind.Template.Data.Infrastructure;

namespace FactoryMind.Template.Data.Specifications
{
    public static partial class Spec
    {
        private static Specification<TEntity> Create<TEntity>(Expression<Func<TEntity, bool>> body) =>
            Specification.Create(body);
    }
}
