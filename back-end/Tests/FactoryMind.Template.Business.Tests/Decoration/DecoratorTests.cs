using System.Linq;
using FactoryMind.Template.Business.Commands;
using FactoryMind.Template.Business.Decorators;
using FactoryMind.Template.Business.Queries;
using FactoryMind.Template.Business.Tests.Infrastructure;
using FactoryMind.Template.Core.Cqrs;
using FactoryMind.Template.Domain;
using Xunit;

namespace FactoryMind.Template.Business.Tests.Decoration
{
    public class DecoratorTest : BaseTest
    {
        [Fact]
        public void Should_DecorateQuery_When_UsingDecoratorAttributes()
        {
            //Act
            var handler = Resolve<IQueryHandler<GetProductUsersQuery, IQueryable<UserDto>>>() as AuthenticateQueryDecorator<GetProductUsersQuery, IQueryable<UserDto>>;

            //Assert
            Assert.NotNull(handler);
            Assert.True(handler.Decoratee is GetProductUsersQueryHandler);
        }

        [Fact]
        public void Should_DecorateCommand_When_UsingDecoratorAttributes()
        {
            //Act
            var handler = Resolve<ICommandHandler<CreateProductCommand>>() as AuthenticateCommandDecorator<CreateProductCommand>;

            //Assert
            Assert.NotNull(handler);

            var innerHandler = handler.Decoratee as TransactCommandDecorator<CreateProductCommand>;
            Assert.NotNull(innerHandler);

            Assert.True(innerHandler.Decoratee is CreateProductCommandHandler);
        }
    }
}