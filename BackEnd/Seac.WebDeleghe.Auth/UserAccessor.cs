using System;
using System.Linq;
using System.Security.Claims;
using Seac.WebDeleghe.Auth.Infrastructure;
using Seac.WebDeleghe.Business;
using Seac.WebDeleghe.Business.Identity;
using Seac.WebDeleghe.Core.Exceptions;
using Seac.WebDeleghe.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace Seac.WebDeleghe.Auth
{
    public sealed class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Lazy<ApplicationUser> _authenticatedUserLazy;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _authenticatedUserLazy = new Lazy<ApplicationUser>(GetCurrentUser);
        }

        public ApplicationUser CurrentUser => _authenticatedUserLazy.Value;

        private ApplicationUser GetCurrentUser()
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims.ToLookup(c => c.Type);

            return new ApplicationUser
            {
                Id = int.Parse(GetClaimValue(claims, ClaimNames.Id)),
                Role = (UserRole)int.Parse(GetClaimValue(claims, ClaimNames.Role))
            };
        }

        private static string GetClaimValue(ILookup<string, Claim> claims, string claimName)
        {
            if (!claims.Contains(claimName))
            {
                throw new UnauthorizedException($"Claim {claimName} non trovato");
            }

            return claims[claimName].First().Value;
        }
    }
}