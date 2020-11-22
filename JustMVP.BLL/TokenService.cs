using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JustMVP.BLL.Interfaces;
using JustMVP.Domain;
using JustMVP.Domain.Infrastructure.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JustMVP.BLL
{
    public class TokenService : ITokenService
    {
        private readonly IOptions<JwtOptions> _jwtOptions;
        private readonly UserManager<User> _userManager;

        public TokenService(IOptions<JwtOptions> jwtOptions, 
            UserManager<User> userManager)
        {
            _jwtOptions = jwtOptions;
            _userManager = userManager;
        }

        public string GenerateJwt(int userId, string userName)
        {
            var key = _jwtOptions.Value.IssuerSigningKey;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()), 
                    new Claim(ClaimTypes.Name, userName), 
                }),
                Expires = DateTime.MaxValue,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
