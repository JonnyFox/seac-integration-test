using System.Threading.Tasks;
using AutoMapper;
using Seac.WebDeleghe.Core.Exceptions;
using Seac.WebDeleghe.Data;
using Seac.WebDeleghe.Data.Entities;
using Seac.WebDeleghe.Domain;

namespace Seac.WebDeleghe.Business.Commands
{
    public sealed class CreateProductCommand : CreateEntityCommand<ProductDto>
    {
        public CreateProductCommand(ProductDto dto) : base(dto)
        { }
    }

    internal sealed class CreateProductCommandHandler : CreateEntityCommandHandler<Product, ProductDto>
    {
        public CreateProductCommandHandler(ApplicationDbContext context, IMapper mapper, ICancellationTokenAccessor cancellationTokenAccessor)
            : base(context, mapper, cancellationTokenAccessor)
        { }

        protected override Task ValidateAsync(ProductDto dto)
        {
            if (string.IsNullOrEmpty(dto.Name))
            {
                throw new BadRequestException("Nome prodotto non valido");
            }

            return base.ValidateAsync(dto);
        }
    }
}