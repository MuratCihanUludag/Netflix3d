using MediatR;
using Microsoft.AspNetCore.Identity;
using Netflix3d.Application.Abstractions;
using Netflix3d.Application.Abstractions.AutoMapper;
using Netflix3d.Application.Features.Mediator.Queries.RefreshTokenQueries;
using Netflix3d.Application.Features.Mediator.Results.RefreshTokenResults;
using Netflix3d.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenQueries, RefreshTokenQueriesResult>
    {

        private readonly UserManager<AppUser> _userManager;
        private ITokenServices _tokenService;

        public RefreshTokenCommandHandler(UserManager<AppUser> userManager, ITokenServices tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<RefreshTokenQueriesResult> Handle(RefreshTokenQueries request, CancellationToken cancellationToken)
        {
            var principal = _tokenService.GetClaimsPrincipalFromExpiredToken(request.AccessToken);
            string email = principal.FindFirstValue(ClaimTypes.Email);

            var user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);

            if (user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new Exception("Oturum Acma suresi sona ermistir.Lutfen tekara giris yapiniz.");

            JwtSecurityToken newAccessToken = await _tokenService.CreateToken(user, roles);
            string newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);
            return new()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken
            };
        }
    }
}
