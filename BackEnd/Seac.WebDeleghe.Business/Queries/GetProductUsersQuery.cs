using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Seac.WebDeleghe.Business.Decorators;
using Seac.WebDeleghe.Business.Infrastructure;
using Seac.WebDeleghe.Data;
using Seac.WebDeleghe.Data.Entities;
using Seac.WebDeleghe.Data.Extensions;
using Seac.WebDeleghe.Data.Specifications;
using Seac.WebDeleghe.Domain;
using Microsoft.EntityFrameworkCore;

namespace Seac.WebDeleghe.Business.Queries
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