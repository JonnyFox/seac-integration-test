using System.Linq;
using Seac.WebDeleghe.Business.Commands;
using Seac.WebDeleghe.Business.Decorators;
using Seac.WebDeleghe.Business.Queries;
using Seac.WebDeleghe.Business.Tests.Infrastructure;
using Seac.WebDeleghe.Core.Cqrs;
using Seac.WebDeleghe.Domain;
using Xunit;

namespace Seac.WebDeleghe.Business.Tests.Decoration
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