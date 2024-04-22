using Netflix3d.Application.Features.Mediator.Results.AppUserResults;
using Netflix3d.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Application.Abstractions
{
    public interface ITokenServices
    {
        Task<JwtSecurityToken> CreateToken(AppUser user, IList<string> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetClaimsPrincipalFromExpiredToken(string token);
    }
}
