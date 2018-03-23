using System;
using System.Linq.Expressions;

namespace FactoryMind.Template.Core
{
    public static class ExpressionComposer
    {
        public static Expression<Func<T, bool>> Compose<T>(Expression<Func<T, bool>> expression, Func<Expression, UnaryExpression> composer)
        {
            var parameter = expression.Parameters[0];
            var composedBody = composer(expression.Body);
            return Expression.Lambda<Func<T, bool>>(composedBody, parameter);
        }

        public static Expression<Func<T, bool>> Compose<T>(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right, Func<Expression, Expression, BinaryExpression> composer)
        {
            var leftParameter = left.Parameters[0];
            var rightParameter = right.Parameters[0];
            var visitor = new ParameterVisitor(rightParameter, leftParameter);
            var replacedRightBody = visitor.Visit(right.Body);

            var composedBody = composer(left.Body, replacedRightBody);
            return Expression.Lambda<Func<T, bool>>(composedBody, leftParameter);
        }

        private class ParameterVisitor : ExpressionVisitor
        {
            private readonly ParameterExpression _parameterToSobstitute;
            private readonly ParameterExpression _sobstitutor;

            public ParameterVisitor(ParameterExpression parameterToSobstitute, ParameterExpression sobstitutor)
            {
                _parameterToSobstitute = parameterToSobstitute;
                _sobstitutor = sobstitutor;
            }

            protected override Expression VisitParameter(ParameterExpression node) =>
                node == _parameterToSobstitute ? _sobstitutor : base.VisitParameter(node);
        }
    }
}
