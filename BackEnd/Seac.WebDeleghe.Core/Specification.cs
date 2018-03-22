using System;
using System.Linq.Expressions;
using Seac.WebDeleghe.Core.Extensions;

namespace Seac.WebDeleghe.Core
{
    public class Specification<T>
    {
        public readonly Expression<Func<T, bool>> Expression;
        private readonly Lazy<Func<T, bool>> _lazyDelegate;

        public Specification(Expression<Func<T, bool>> expression)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            _lazyDelegate = new Lazy<Func<T, bool>>(Expression.Compile);
        }

        public Func<T, bool> Delegate => _lazyDelegate.Value;

        public Specification<T> And(Specification<T> clause) => Expression.And(clause.Expression);

        public Specification<T> AndNot(Specification<T> clause) => And(clause.Negation());

        public Specification<T> Or(Specification<T> clause) => Expression.Or(clause.Expression);

        public Specification<T> OrNot(Specification<T> clause) => Or(clause.Negation());

        public Specification<T> Negation() => Expression.Negation();


        public override string ToString() => Expression.ToString();

        public override int GetHashCode() => Expression.GetHashCode();

        public override bool Equals(object obj) => Expression.Equals(obj);


        public static implicit operator Func<T, bool>(Specification<T> specification) => specification.Delegate;

        public static implicit operator Expression<Func<T, bool>>(Specification<T> specification) => specification.Expression;

        public static implicit operator Specification<T>(Expression<Func<T, bool>> expression) => Specification.Create(expression);


        public static Specification<T> operator &(Specification<T> left, Specification<T> right) => left.And(right);

        public static Specification<T> operator |(Specification<T> left, Specification<T> right) => left.Or(right);

        public static Specification<T> operator !(Specification<T> source) => source.Negation();
    }

    public static class Specification
    {
        public static Specification<TEntity> Create<TEntity>(Expression<Func<TEntity, bool>> spec) => new Specification<TEntity>(spec);
    }
}
