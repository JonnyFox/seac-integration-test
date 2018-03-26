using System;
using System.Linq.Expressions;
using Seac.WebDeleghe.Data.Infrastructure;

namespace Seac.WebDeleghe.Data.Specifications
{
    public static partial class Spec
    {
        private static Specification<TEntity> Create<TEntity>(Expression<Func<TEntity, bool>> body) =>
            Specification.Create(body);
    }
}
