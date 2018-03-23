using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FactoryMind.Template.Business.Decorators;
using FactoryMind.Template.Business.Infrastructure;
using FactoryMind.Template.Data;
using FactoryMind.Template.Data.Entities;
using FactoryMind.Template.Data.Extensions;
using FactoryMind.Template.Data.Specifications;
using FactoryMind.Template.Domain;
using Microsoft.EntityFrameworkCore;

namespace FactoryMind.Template.Business.Queries
{
    [AuthenticateQuery(UserRole.Admin)]
    public sealed class GetProductUsersQuery : Query<IQueryable<UserDto>>
    {
        public readonly int ProductId;

        public GetProductUsersQuery(int productId)
        {
            ProductId = productId;
        }
    }

    internal sealed class GetProductUsersQueryHandler : QueryableHandler<GetProductUsersQuery, UserDto>
    {
        public GetProductUsersQueryHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        { }

        protected override IQueryable<UserDto> Execute(GetProductUsersQuery query) => Context
            .FindBy(Spec.UserProducts.ByProductId(query.ProductId))
            .Include(up => up.User)
            .Select(up => up.User)
            .ProjectTo<UserDto>(Mapper.ConfigurationProvider);
    }
}