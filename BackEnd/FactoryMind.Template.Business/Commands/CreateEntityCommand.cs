using System.Threading.Tasks;
using AutoMapper;
using FactoryMind.Template.Business.Infrastructure;
using FactoryMind.Template.Core.Exceptions;
using FactoryMind.Template.Data;
using FactoryMind.Template.Data.Infrastructure;

namespace FactoryMind.Template.Business.Commands
{
    public abstract class CreateEntityCommand<TDto> : Command
    {
        public readonly TDto Dto;

        protected CreateEntityCommand(TDto dto)
        {
            Dto = dto;
        }
    }

    internal abstract class CreateEntityCommandHandler<TEntity, TDto> : CommandHandler<CreateEntityCommand<TDto>>
        where TEntity : class, IEntity
    {
        private readonly IMapper _mapper;
        private readonly ICancellationTokenAccessor _cancellationTokenAccessor;

        protected CreateEntityCommandHandler(ApplicationDbContext context, IMapper mapper, ICancellationTokenAccessor cancellationTokenAccessor) : base(context)
        {
            _mapper = mapper;
            _cancellationTokenAccessor = cancellationTokenAccessor;
        }

        public override async Task ExecuteAsync(CreateEntityCommand<TDto> command)
        {
            var dto = command.Dto;
            if (dto == null)
            {
                throw new BadRequestException();
            }

            await ValidateAsync(dto);

            var entity = _mapper.Map<TEntity>(dto);
            Context.Add(entity);

            await Context.SaveChangesAsync(_cancellationTokenAccessor.CancellationToken);
        }

        protected virtual Task ValidateAsync(TDto dto) => Task.CompletedTask; // Do nothing by default
    }
}