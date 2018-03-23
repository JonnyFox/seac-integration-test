﻿using System.Threading.Tasks;
using Seac.WebDeleghe.Core.Cqrs;

namespace Seac.WebDeleghe.Business.Infrastructure
{
    internal abstract class QueryDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        internal readonly IQueryHandler<TQuery, TResult> Decoratee;

        protected QueryDecorator([Decoratee]IQueryHandler<TQuery, TResult> decoratee)
        {
            Decoratee = decoratee;
        }

        public abstract Task<TResult> ExecuteAsync(TQuery query);
    }
}