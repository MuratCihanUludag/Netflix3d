using Netflix3d.Application.Dtos;
using Netflix3d.Application.Features.Mediator.Results.AppUserResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


using Microsoft.IdentityModel.Tokens;
using Netflix3d.Application.Services;
using System.IdentityModel.Tokens.Jwt;

namespace Netflix3d.Application.Tools
{
    public static class JwtTokenGenerator
    {
        public static TokenResponseDto TokenGenerator(GetCheckAppUserQueryResult result)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrWhiteSpace(result.Role))
                claims.Add(new Claim(ClaimTypes.Role, result.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()));
            if (!string.IsNullOrWhiteSpace(result.Email))
                claims.Add(new Claim(ClaimTypes.Email, result.Email));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.Token["Token:SecurityKey"]));
            var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.Now.AddMinutes(Convert.ToInt32(Configuration.Token["Token:Expiration"]));

            var token = new JwtSecurityToken(issuer: Configuration.Token["Token:Issuer"],
                                             audience: Configuration.Token["Token:Audience"],
                                             claims: claims,
                                             notBefore: DateTime.UtcNow,
                                             expires: expireDate,
                                             signingCredentials: signinCredentials);

            JwtSecurityTokenHandler tokenHandler = new();
            return new TokenResponseDto(tokenHandler.WriteToken(token), expireDate);
        }
    }
}
