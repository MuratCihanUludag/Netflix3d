using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Netflix3d.Application.Abstractions;
using Netflix3d.Application.Abstractions.AutoMapper;
using Netflix3d.Application.Expections;
using Netflix3d.Application.Features.Mediator.Queries.AppUserQueries;
using Netflix3d.Application.Features.Mediator.Results.AppUserResults;
using Netflix3d.Application.Repositories;
using Netflix3d.Application.Services;
using Netflix3d.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<LoginQuery, LoginQueryResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenServices _tokenServices;



        public GetCheckAppUserQueryHandler(UserManager<AppUser> userManager, ITokenServices tokenServices)
        {
            _userManager = userManager;
            _tokenServices = tokenServices;
        }

        public async Task<LoginQueryResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByEmailAsync(request.Email);
            bool checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (user is null || !checkPassword)
                throw new Exception("Email ya da sifre hatalı");

            var roles = await _userManager.GetRolesAsync(user);
            JwtSecurityToken token = await _tokenServices.CreateToken(user, roles);
            string refreshToken = _tokenServices.GenerateRefreshToken();
            _ = int.TryParse(Configuration.Token["Token:RefreshTokenValidateDay"], out int refreshTokenValidateDay);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidateDay);

            await _userManager.UpdateAsync(user);
            await _userManager.UpdateSecurityStampAsync(user);

            var _token = new JwtSecurityTokenHandler().WriteToken(token);
            await _userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);
            return new()
            {
                Token = _token,
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            };
        }
    }
}
