using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FactoryMind.Template.Business;
using FactoryMind.Template.Data;
using FactoryMind.Template.Data.Extensions;
using FactoryMind.Template.Data.Specifications;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace FactoryMind.Template.Auth.Infrastructure
{
    internal sealed class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICancellationTokenAccessor _cancellationTokenAccessor;

        public ProfileService(ApplicationDbContext dbContext, ICancellationTokenAccessor cancellationTokenAccessor)
        {
            _dbContext = dbContext;
            _cancellationTokenAccessor = cancellationTokenAccessor;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            context.IssuedClaims = context.Subject.Claims.ToList();

            var userId = int.Parse(context.IssuedClaims.Single(c => c.Type == "sub").Value);
            var user = await _dbContext.FindSingleAsync(Spec.Users.ById(userId), ct: _cancellationTokenAccessor.CancellationToken);

            context.IssuedClaims.Add(new Claim(ClaimNames.Id, user.Id.ToString()));
            context.IssuedClaims.Add(new Claim(ClaimNames.Role, ((int)user.Role).ToString()));
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.CompletedTask;
        }
    }
}