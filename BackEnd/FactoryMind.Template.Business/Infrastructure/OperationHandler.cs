using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FactoryMind.Template.Core.Cqrs;
using FactoryMind.Template.Data;

namespace FactoryMind.Template.Business.Infrastructure
{
    internal abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        protected readonly ApplicationDbContext Context;
        protected readonly IMapper Mapper;

        protected QueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public abstract Task<TResult> ExecuteAsync(TQuery query);
    }

    internal abstract class QueryableHandler<TQuery, TResult> : IQueryHandler<TQuery, IQueryable<TResult>>
        where TQuery : IQuery<IQueryable<TResult>>
    {
        protected readonly ApplicationDbContext Context;
        protected readonly IMapper Mapper;

        protected QueryableHandler(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public virtual Task<IQueryable<TResult>> ExecuteAsync(TQuery query) => Task.FromResult(Execute(query));

        protected abstract IQueryable<TResult> Execute(TQuery query);
    }

    internal abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        protected readonly ApplicationDbContext Context;

        protected CommandHandler(ApplicationDbContext context)
        {
            Context = context;
        }

        public abstract Task ExecuteAsync(TCommand command);
    }
}