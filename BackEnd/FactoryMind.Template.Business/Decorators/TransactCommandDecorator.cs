﻿using System;
using System.Threading.Tasks;
using FactoryMind.Template.Business.Infrastructure;
using FactoryMind.Template.Core.Cqrs;
using FactoryMind.Template.Data;

namespace FactoryMind.Template.Business.Decorators
{
    public class TransactAttribute : DecoratorAttribute
    {
        public override Type DecoratorType => typeof(TransactCommandDecorator<>);
    }

    internal sealed class TransactCommandDecorator<TCommand> : CommandDecorator<TCommand>
        where TCommand : ICommand
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICancellationTokenAccessor _cancellationTokenAccessor;

        public TransactCommandDecorator([Decoratee]ICommandHandler<TCommand> decoratee, ApplicationDbContext dbContext, ICancellationTokenAccessor cancellationTokenAccessor)
            :base(decoratee)
        {
            _dbContext = dbContext;
            _cancellationTokenAccessor = cancellationTokenAccessor;
        }

        public override async Task ExecuteAsync(TCommand command)
        {
            var database = _dbContext.Database;
            if (database.CurrentTransaction != null)
            {
                await Decoratee.ExecuteAsync(command);
                return;
            }
            
            using (var transaction = await database.BeginTransactionAsync(_cancellationTokenAccessor.CancellationToken))
            {
                await Decoratee.ExecuteAsync(command);
                transaction.Commit();
            }
        }
    }
}