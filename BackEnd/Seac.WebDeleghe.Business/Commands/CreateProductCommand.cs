﻿using System.Threading.Tasks;
using Seac.WebDeleghe.Business.Infrastructure;
using Seac.WebDeleghe.Core.Exceptions;
using Seac.WebDeleghe.Data;
using Seac.WebDeleghe.Data.Entities;
using Seac.WebDeleghe.Data.Extensions;
using Seac.WebDeleghe.Data.Specifications;

namespace Seac.WebDeleghe.Business.Commands
{
    public sealed class BuyProductCommand : Command
    {
        public readonly int ProductId;

        public BuyProductCommand(int productId)
        {
            ProductId = productId;
        }
    }

    internal sealed class BuyProductCommandHandler : CommandHandler<BuyProductCommand>
    {
        private readonly IUserAccessor _userAccessor;

        public BuyProductCommandHandler(ApplicationDbContext context, IUserAccessor userAccessor) // Eventually use the ct accessor
            : base(context)
        {
            _userAccessor = userAccessor;
        }

        public override async Task ExecuteAsync(BuyProductCommand command)
        {
            var product = await Context.FindSingleOrDefaultAsync(Spec.Products.ById(command.ProductId));
            if (product == null)
            {
                throw new NotFoundException();
            }

            var userProduct = new UserProduct
            {
                UserId = _userAccessor.CurrentUser.Id,
                ProductId = command.ProductId
            };

            await Context.UserProducts.AddAsync(userProduct);
            await Context.SaveChangesAsync();
        }
    }
}