using System.Linq;
using System.Threading.Tasks;
using FactoryMind.Template.Data;
using FactoryMind.Template.Data.Entities;
using FactoryMind.Template.Data.Extensions;
using FactoryMind.Template.Data.Specifications;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace FactoryMind.Template.Auth.Infrastructure
{
    internal sealed class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly ApplicationDbContext _dbContext;

        public ResourceOwnerPasswordValidator(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _dbContext.FindSingleOrDefaultAsync(Spec.Users.ByUsername(context.UserName));
            if (user == null)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest, "Wrong email or password");
                return;
            }

            context.Result = new GrantValidationResult(user.Id.ToString(), "password");
        }
    }
}