using System;
using System.Linq.Expressions;

namespace Seac.WebDeleghe.Core.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right) =>
            ExpressionComposer.Compose(left, right, Expression.AndAlso);

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right) =>
            ExpressionComposer.Compose(left, right, Expression.Or);

        public static Expression<Func<T, bool>> Negation<T>(this Expression<Func<T, bool>> source) =>
            ExpressionComposer.Compose(source, Expression.Not);
    }
}
